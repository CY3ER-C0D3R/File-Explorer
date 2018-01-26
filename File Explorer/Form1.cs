using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace File_Explorer
{
    public partial class Form1 : Form
    {
        private static FileSystemWatcher _fileWatcher;
        private static FileSystemWatcher _dirWatcher;
        private bool dirFound; 
        private string oldPath;
        private bool shown;
        private bool deletedShown;
        private List<FileSystemWatcher> watchers;

        [System.Runtime.InteropServices.DllImport("uxtheme.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        public static void SetTreeViewTheme(IntPtr treeHandle)
        {
            SetWindowTheme(treeHandle, "explorer", null);
        }

        /// <summary>Returns true if the current application has focus, false otherwise</summary>
        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            var procId = System.Diagnostics.Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }
        
        public Form1()
        {
            InitializeComponent();
            this.shown = false;
            this.watchers = new List<FileSystemWatcher>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //watcher will act as a watchdog for file system changes and will raise an event when a change occurs
            SetTreeViewTheme(this.treeDirectory.Handle);
            this.treeDirectory.ShowLines = false;
            //TreeNodes are the logical disks of the computer
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            this.watcher_ComboBox.Items.Add("All");
            this.watcher_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TreeNode rootNode;
            foreach (DriveInfo d in allDrives)
            {
                //add the drives to combobox and create the base treeview 
                rootNode = new TreeNode(@d.Name);
                rootNode.ImageIndex = 0;
                rootNode.SelectedImageIndex = 0;
                rootNode.Tag = "folder";
                this.treeDirectory.Nodes.Add(rootNode);
                if (!d.IsReady)
                {
                    this.logical_disks.Items.Add(string.Format("{0} {1}", d.Name, d.DriveType));
                }
                else
                {
                    this.logical_disks.Items.Add(string.Format("{0} {1} {2}, size: {3} GB", d.Name, d.DriveType, d.DriveFormat, d.TotalSize / 1073741824)); //add info about driver including size in gigabytes
                    this.watcher_ComboBox.Items.Add(d.Name);
                    CreateWatcher(@d.Name);
                    FillNodes(rootNode);
                }
            }
            this.watcher_ComboBox.Items.Add("None");
            this.watcher_ComboBox.SelectedIndex = 0;
            StartAllWatchers();
        }

        private void CreateWatcher(string path)
        {
            StartGeneralWatchers(path);

            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @path;

            // Watch both files and subdirectories.
            watcher.IncludeSubdirectories = true;

            // Watch for all changes specified in the NotifyFilters enumeration.
            watcher.NotifyFilter = NotifyFilters.Attributes |
            NotifyFilters.CreationTime |
            NotifyFilters.DirectoryName |
            NotifyFilters.FileName |
            NotifyFilters.LastAccess |
            NotifyFilters.LastWrite |
            NotifyFilters.Security |
            NotifyFilters.Size;

            // Watch all files.
            watcher.Filter = "*.*";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            //don't start monitoring yet
            watcher.EnableRaisingEvents = false;

            //add watcher to list of watchers
            this.watchers.Add(watcher);
        }

        private void StartAllWatchers()
        {
            foreach (FileSystemWatcher w in this.watchers)
            {
                w.EnableRaisingEvents = true;
            }
        }

        private void StopAllWatchers()
        {
            foreach (FileSystemWatcher w in this.watchers)
            {
                w.EnableRaisingEvents = false;
            }
        }

        private void StartORStopWatcher(string path, bool start)
        {
            //if start is true start the watcher, else stop it
            foreach (FileSystemWatcher w in this.watchers)
            {
                if (w.Path == path)
                {
                    if (start)
                        w.EnableRaisingEvents = true;
                    else //stop
                        w.EnableRaisingEvents = false;
                }
            }
        }

        private void StartGeneralWatchers(string path)
        {
            _fileWatcher = new FileSystemWatcher(@path);
            _fileWatcher.IncludeSubdirectories = true;
            _fileWatcher.NotifyFilter = NotifyFilters.FileName;
            _fileWatcher.EnableRaisingEvents = true;
            _fileWatcher.Deleted += WatcherActivity;

            _dirWatcher = new FileSystemWatcher(@path);
            _dirWatcher.IncludeSubdirectories = true;
            _dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
            _dirWatcher.EnableRaisingEvents = true;
            _dirWatcher.Deleted += WatcherActivity;
        }

        public void WatcherActivity(object sender, FileSystemEventArgs e)
        {
            if (sender == _dirWatcher)
                this.dirFound = true;
            else
                this.dirFound = false;
        }

        public bool CheckExtentions(FileSystemEventArgs e)
        {
            string[] name = e.Name.Split('\\');
            string[] filename = name[name.Length - 1].Split('.');
            string ext = filename[filename.Length - 1];
            bool found = false;
            foreach (string s in name)
            {
                if (s == "AppData")
                {
                    found = true;
                    break;
                }
            }
            return found || ext == "tmp" || ext == "bin" || ext == "lnk" || ext == "dll" || ext == "mui" || ext == "sys" || ext == "dat";
        }

        public void OnChanged(object source, FileSystemEventArgs e)
        {
            //only alert changes if form is not the main focus of the user
            if (!ApplicationIsActivated() && !this.shown && !CheckExtentions(e))
                this.BeginInvoke(new MethodInvoker(delegate() { ShowChangesInTreeView(source, e); }));
        }

        public void OnRenamed(object source, RenamedEventArgs e)
        {
            //only alert changes if form is not the main focus of the user
            if (!ApplicationIsActivated() && !this.shown && !CheckExtentions(e)) 
                this.BeginInvoke(new MethodInvoker(delegate() { ShowRenamed(source, e); }));
        }

        public void ShowChangesInTreeView(object source, FileSystemEventArgs e)
        {
            //ask user if he wants to go to the file that has changed or not
            if (!shown && (e.ChangeType.ToString() != "Deleted") || (e.ChangeType.ToString() == "Deleted" && !this.deletedShown))
            {
                string msg = string.Format("Attention! file {0} at {1}. View Change?", e.ChangeType, e.FullPath);
                DialogResult d = MessageBox.Show(msg, "File Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                this.shown = true;
                if (d == DialogResult.Yes)
                {
                    // only mark files if user wants to see the changes
                    // when a file is changed mark it as changed until user clicks the file

                    this.treeDirectory.Refresh();
                    this.treeDirectory.CollapseAll();
                    SelectNode(e.FullPath);
                    TreeNode n;
                    if (e.ChangeType.ToString() == "Created")
                    {
                        n = this.treeDirectory.SelectedNode;
                        n.BackColor = Color.LightGreen;
                    }
                    else if (e.ChangeType.ToString() == "Changed")
                    {
                        n = this.treeDirectory.SelectedNode;
                        n.BackColor = Color.LightYellow;
                    }
                    else if (e.ChangeType.ToString() == "Deleted")
                    {
                        TreeNode deleted_file = new TreeNode();
                        string[] path = e.FullPath.Split('\\');
                        deleted_file.Text = path[path.Length - 1];
                        deleted_file.BackColor = Color.LightSalmon;
                        if (this.dirFound)
                        {
                            deleted_file.ImageIndex = 1;
                            deleted_file.SelectedImageIndex = 1;
                        }
                        else //file
                        {
                            deleted_file.ImageIndex = 3;
                            deleted_file.SelectedImageIndex = 3;
                        }
                        this.treeDirectory.SelectedNode.Nodes.Add(deleted_file);
                        this.deletedShown = true;
                    }
                    if (this.treeDirectory.SelectedNode.Parent != null && e.ChangeType.ToString() != "Deleted")
                        this.treeDirectory.SelectedNode = this.treeDirectory.SelectedNode.Parent;
                }
                this.shown = false;
            }
        }

        public void ShowRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            if (!this.shown)
            {
                string msg = string.Format("{0} renamed to {1}. View Changes?", e.OldFullPath, e.FullPath);
                DialogResult d = MessageBox.Show(msg, "File Renamed", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                this.shown = true;
                if (d == DialogResult.Yes)
                {
                    this.treeDirectory.Refresh();
                    this.treeDirectory.CollapseAll();
                    SelectNode(e.FullPath);
                    TreeNode n = this.treeDirectory.SelectedNode;
                    n.BackColor = Color.Magenta;
                    if (this.treeDirectory.SelectedNode.Parent != null)
                        this.treeDirectory.SelectedNode = this.treeDirectory.SelectedNode.Parent;
                }
                this.shown = false;
            }
        }

        private void FillNodes(TreeNode dirNode)
        {
            DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);
            try
            {
                foreach (DirectoryInfo dirItem in dir.GetDirectories())
                {
                    TreeNode newNode = new TreeNode(dirItem.Name);
                    newNode.ImageIndex = 1;
                    newNode.SelectedImageIndex = 1;
                    newNode.Tag = "folder";
                    dirNode.Nodes.Add(newNode);
                    newNode.Nodes.Add("*");
                }
                foreach (FileInfo fileItem in dir.GetFiles())
                {
                    TreeNode newNode = new TreeNode(fileItem.Name);
                    newNode.ImageIndex = 3;
                    newNode.SelectedImageIndex = 3;
                    dirNode.Nodes.Add(newNode);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //show folder icon as closed
                dirNode.ImageIndex = 1;
                dirNode.SelectedImageIndex = 1;
            }
        }

        private void ExpandTree(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "*")
            {
                e.Node.ImageIndex = 2;
                e.Node.SelectedImageIndex = 2;
                this.path_txtbox.Text = e.Node.FullPath;
                e.Node.Nodes.Clear();
                FillNodes(e.Node);
            }
            else 
            {
                this.path_txtbox.Text = e.Node.FullPath;
            }
        }

        private void CollapseTree(object sender, TreeViewCancelEventArgs e)
        {
            if(e.Node.Parent != null)
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 1;
                this.path_txtbox.Text = e.Node.Parent.FullPath; //update path
                //close file related information
                this.fileAttributes.Clear();
                this.fileContent.Clear();
                //close nodes in directory
                e.Node.Nodes.Clear();
                e.Node.Nodes.Add("*");
            }
            else
            {
                this.path_txtbox.Text = e.Node.FullPath;
            }
        }

        private void treeDirectory_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //if a file is opened in editor make sure user know's that the file won't be saved
            if (!this.fileContent.ReadOnly)
            {
                DialogResult d = MessageBox.Show("Exit Editor? Changes in file will not be saved.", "Continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (d == DialogResult.OK)
                    this.fileContent.ReadOnly = true;
            }
            //check unedited and newly created "New Folder"s
            if (this.treeDirectory.SelectedNode != null)
            {
                if (this.treeDirectory.SelectedNode.Text == "New Folder" && this.treeDirectory.SelectedNode.BackColor == Color.YellowGreen)
                {
                    DialogResult d = MessageBox.Show("Create Folder 'New Folder?'\n\rPress Cancel to delete folder.\n\rTo edit name, click the folder and type its name.", "New Folder Created", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (d == DialogResult.OK) //create new folder named "new folder"
                    {
                        Directory.CreateDirectory(this.treeDirectory.SelectedNode.FullPath);
                        this.treeDirectory.SelectedNode.BackColor = Color.Empty;
                    }
                    else //delete node
                    {
                        this.treeDirectory.SelectedNode.Remove();
                        this.deletedShown = false;
                        Refresh();
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.BackColor == Color.LightSalmon) //file had been deleted so remove the node from treeview
                {
                    e.Node.Remove();
                    this.deletedShown = false;
                    Refresh();
                    return;
                }
                else if (!e.Node.BackColor.IsEmpty) //if node was pressed after selection change color back to none
                    e.Node.BackColor = Color.Empty;
                //Update the combobox according to the driver selected 
                if (e.Node.Parent == null &&
                  e.Node.GetType() == typeof(TreeNode))
                {
                    int index = e.Node.Index;
                    this.logical_disks.SelectedItem = this.logical_disks.Items[index];
                    this.treeDirectory.Focus();
                }
                if (File.Exists(this.treeDirectory.SelectedNode.FullPath))
                {
                    this.path_txtbox.Text = e.Node.FullPath;
                    this.fileContent.Clear();
                    new System.Threading.Thread(() =>
                    {
                        System.Threading.Thread.CurrentThread.IsBackground = true;
                        Display_File(this.treeDirectory.SelectedNode.FullPath);
                    }).Start();

                    Display_File_Attr(this.treeDirectory.SelectedNode.FullPath);
                }
                else  //directory
                {
                    this.path_txtbox.Text = e.Node.FullPath;
                    //close file related information
                    this.fileAttributes.Clear();
                    this.fileContent.Clear();
                    Display_Dir_Attr(this.treeDirectory.SelectedNode.FullPath);
                }
            }
        }

        private void treeDirectory_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //save the old path of the folder/file before changing it
            this.oldPath = this.treeDirectory.SelectedNode.FullPath;
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if(this.treeDirectory.SelectedNode != null && this.oldPath != "")
            {
                if ((string)this.treeDirectory.SelectedNode.Tag == "folder" || (string)this.treeDirectory.SelectedNode.Tag == "folder renamed") //if label to edit is a folder label
                    this.BeginInvoke(new Action(() => afterAfterEdit(e.Node, this.oldPath, true)));
                else //file to edit
                    this.BeginInvoke(new Action(() => afterAfterEdit(e.Node, this.oldPath, false)));
            }
        }

        private void afterAfterEdit(TreeNode node, string oldPath, bool directory)
        {
            //if directory is true requested action is to rename/create a directory, else - file.
            //rename the file/directory to the name requested or create the file/directory if doesn't exist

            if ((string)this.treeDirectory.SelectedNode.Tag == "folder renamed" || (string)this.treeDirectory.SelectedNode.Tag == "file renamed")
            {
                if (Directory.Exists(oldPath))
                    this.treeDirectory.SelectedNode.Tag = "folder";
                else
                    this.treeDirectory.SelectedNode.Tag = "file";
                DialogResult d = MessageBox.Show("Save Changes?", "Folder/File Renamed", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK) //rename the file or folder
                {
                    this.treeDirectory.SelectedNode.EndEdit(false); //save changes
                    afterAfterEdit(this.treeDirectory.SelectedNode, oldPath, (string)this.treeDirectory.SelectedNode.Tag == "folder");
                }
                else //don't save
                {
                    this.treeDirectory.SelectedNode.EndEdit(true); //don't save changes
                    TreeNode n = this.treeDirectory.SelectedNode.Parent;
                    if (n != null)
                    {
                        //refresh manually
                        n.Collapse();
                        n.Expand();
                    }
                }
            }
            else if (node.Text != "" && node.Text != null && node.Parent != null)
            {
                string newPath = node.FullPath;
                //if file or folder exist, change their name
                if(File.Exists(@oldPath) || Directory.Exists(@oldPath))
                {
                    try
                    {
                        if (directory)
                            Directory.Move(oldPath, newPath);
                        else //file 
                            File.Move(oldPath, newPath);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //if folder does not exist create it
                {
                    if (directory)
                        Directory.CreateDirectory(newPath);
                    //files are not created in this function, only edited after creation (renamed)
                }
                
            }
            else //return file to its original name
            {
                String[] txt = node.FullPath.Split('\\');
                node.Text = txt[txt.Length - 1];
            }
            // close the editing option
            this.treeDirectory.LabelEdit = false;
            // after end of editing the folder no color is needed to mark it
            this.treeDirectory.SelectedNode.BackColor = Color.Empty;
        }

        private void logical_disks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.treeDirectory.CollapseAll();
            this.treeDirectory.Nodes[this.logical_disks.SelectedIndex].Expand();
            this.treeDirectory.SelectedNode = this.treeDirectory.Nodes[this.logical_disks.SelectedIndex];
        }

        private void path_txtbox_KeyUp(object sender, KeyEventArgs e)
        {
            //if user pressed enter, take the given path and expand it
            if (e.KeyCode == Keys.Enter)
            {
                string path = this.path_txtbox.Text;
                this.treeDirectory.CollapseAll();
                if (File.Exists(@path))
                {
                    //display the file and it's attributes
                    Display_File(path);
                    Display_File_Attr(path);
                }
                else if (Directory.Exists(@path))
                {
                    //display the directory's attributes
                    Display_Dir_Attr(path);
                }
                SelectNode(@path);

            }
        }

        private void SelectNode(string path)
        {
            int index = this.watcher_ComboBox.SelectedIndex;
            this.treeDirectory.Nodes.Clear();
            this.watcher_ComboBox.Items.Clear();
            this.logical_disks.Items.Clear();
            Form1_Load(new object(), new EventArgs());
            this.watcher_ComboBox.SelectedIndex = index;

            var path_list = path.Split('\\').ToList();
            for (int i = 0; i < path_list.Count; i++)
            {
                if (path_list[i] == "")
                    path_list.RemoveAt(i);
            }
            foreach (TreeNode node in this.treeDirectory.Nodes)
            {
                if (node.Text == path_list[0] + "\\")
                {
                    this.treeDirectory.SelectedNode = node;
                    ExpandTreeTo(node, path_list);
                    break;
                }
            }            
        } 

        private void ExpandTreeTo(TreeNode node, List<string> path)
        {
            path.RemoveAt(0);

            node.Expand();

            if (path.Count == 0)
                return;

            foreach (TreeNode currentNode in node.Nodes)
            {
                if (currentNode.Text == path[0])
                {
                    this.treeDirectory.SelectedNode = currentNode;
                    ExpandTreeTo(currentNode, path); //recursive call
                    break;
                }
            }
        }

        private void treeDirectory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // If a node is double-clicked, open the file indicated by the TreeNode.

            try
            {
                // Look for a file extension.
                if (File.Exists(e.Node.FullPath))
                    System.Diagnostics.Process.Start(@e.Node.FullPath);
            }
            // If the file is not found, handle the exception and inform the user.
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Error", "File not found or couldn't be opened.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SystemException)
            {
                //if user accidently double clicks something that is not handled don't through exceptions
            }
        }

        private void Display_File(string filename)
        {
            this.fileContent.Clear();
            StreamReader sr;
            try {
                FileStream fs = new FileStream(@filename,
                FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
            }
            catch {
                //MessageBox.Show("File not found", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string curLine;
            curLine = sr.ReadToEnd();
            this.fileContent.AppendText(curLine);
            sr.Close();
        }

        private void Display_File_Attr(string filename)
        {
            this.fileAttributes.Clear();
            FileInfo f = new FileInfo(@filename);
            this.fileAttributes.AppendText(string.Format("Length: {0} bytes\n", f.Length));
            this.fileAttributes.AppendText(string.Format("Type: {0}\n", f.Extension));
            DateTime dt = File.GetCreationTime(@filename);
            this.fileAttributes.AppendText(string.Format("Date and Time Create file: {0}-{1}-{2}  {3}:{4}:{5}\n", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second));
            dt = File.GetLastAccessTime(@filename);
            this.fileAttributes.AppendText(string.Format("Last access time of file: {0}-{1}-{2}  {3}:{4}:{5}\n", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second));
            dt = File.GetLastWriteTime(@filename);
            this.fileAttributes.AppendText(string.Format("Last Write Time of file: {0}-{1}-{2}  {3}:{4}:{5}\n",dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second));
            this.fileAttributes.AppendText("Attributes of file: ");
            FileAttributes fa = File.GetAttributes(@filename);
            this.fileAttributes.AppendText(fa.ToString());
        }

        private void Display_Dir_Attr(string dirname)
        {
            this.fileAttributes.Clear();
            DateTime dt = Directory.GetCreationTime(@dirname);
            this.fileAttributes.AppendText(string.Format("Date and Time Create Directory: {0}-{1}-{2}  {3}:{4}:{5}\n", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second));
            dt = Directory.GetLastAccessTime(@dirname);
            this.fileAttributes.AppendText(string.Format("Last access time of Directory: {0}-{1}-{2}  {3}:{4}:{5}\n", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second));
            dt = Directory.GetLastWriteTime(@dirname);
            this.fileAttributes.AppendText(string.Format("Last Write Time in Directory: {0}-{1}-{2}  {3}:{4}:{5}\n", dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, dt.Second));
            this.fileAttributes.AppendText("Parent Directory: ");
            DirectoryInfo di = Directory.GetParent(@dirname);
            if (di != null) //directory has parent
                this.fileAttributes.AppendText(di.ToString());
            else
                this.fileAttributes.AppendText("None (Root Directory)");
        }

        private void folder_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(this.treeDirectory.SelectedNode.FullPath))
                {
                    this.treeDirectory.LabelEdit = true;
                    TreeNode newNode = new TreeNode("New Folder");
                    newNode.ImageIndex = 1;
                    newNode.SelectedImageIndex = 1;
                    newNode.Tag = "folder";
                    newNode.Nodes.Add("*");
                    this.treeDirectory.SelectedNode.Nodes.Add(newNode);
                    this.treeDirectory.SelectedNode = newNode;
                    this.treeDirectory.SelectedNode.BackColor = Color.YellowGreen;
                    newNode.Nodes.Add("*");
                    Refresh();
                }
                else
                {
                    DialogResult d = MessageBox.Show("File Selected. Create folder in current folder?", "Create Folder",MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if(DialogResult.OK == d) //create folder in current directory, a.k.a - parent node
                    {
                        this.treeDirectory.SelectedNode = this.treeDirectory.SelectedNode.Parent;
                        folder_btn_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edit_file_btn_Click(object sender, EventArgs e)
        {
            FileInfo f = new FileInfo(this.path_txtbox.Text);
            if (f.Extension != ".txt" && f.Extension != ".py")
            {
                DialogResult d = MessageBox.Show("File may become corrupted due to changes in editor.\n\rAre you sure you want to procced?\n\rNote: You can edit the file in it's designated program by double clicking on it.", "Continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (d == DialogResult.OK)
                    this.fileContent.ReadOnly = false;
            }
            else
                this.fileContent.ReadOnly = false; 
        }

        private void rename_btn_Click(object sender, EventArgs e)
        {
            if (this.treeDirectory.SelectedNode == null || this.treeDirectory.SelectedNode.Parent == null)
            {
                MessageBox.Show("Select a folder or file to rename.", "Rename Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.treeDirectory.LabelEdit = true;
                if (Directory.Exists(this.treeDirectory.SelectedNode.FullPath))
                    this.treeDirectory.SelectedNode.Tag = "folder renamed";
                else //file renamed
                    this.treeDirectory.SelectedNode.Tag = "file renamed";
                this.treeDirectory.SelectedNode.BeginEdit();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (this.treeDirectory.SelectedNode != null && this.treeDirectory.SelectedNode.Parent != null)
            {
                try
                {
                    if (File.Exists(this.treeDirectory.SelectedNode.FullPath))
                        File.Delete(@treeDirectory.SelectedNode.FullPath);
                    else //directory
                        Directory.Delete(@treeDirectory.SelectedNode.FullPath, true); //deletes all subdrectories and folders in the directory
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.treeDirectory.Nodes.Remove(this.treeDirectory.SelectedNode);
                Refresh();
            }
        }

        private void file_btn_Click(object sender, EventArgs e)
        {
            New_File_Dialog n = new New_File_Dialog();
            n.Set_Path_label(this.treeDirectory.SelectedNode.FullPath);
            using (n)
            {
                if (n.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] results = n.file_info;
                        if (results[0] == "" || results[1] == "")
                            throw new Exception("Couldn't create file because relavant fields (name and location) were supplied");
                        string name = results[0];
                        string path = results[1];
                        string extension = results[2];
                        string fullPath = path + "\\" + name + extension;
                        //create a new file at the path requested
                        if ((extension == ".txt") || (extension == ".py") || (extension == "")) //open txt, python and binary files for editing 
                        {
                            DialogResult d = MessageBox.Show("Would you like to open the file to edit in browser?\n(To save the file you must press the save button or else changes wont be made)", "Edit File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (d != DialogResult.Cancel)
                            {
                                this.path_txtbox.Text = fullPath;
                                StreamWriter sw = new StreamWriter(@fullPath);
                                if (d == DialogResult.Yes) //open file in fileContent for editing
                                {
                                    //OpenInEditor
                                    this.fileContent.ReadOnly = false;
                                    this.treeDirectory.Refresh(); 
                                }
                                sw.Close();
                            }
                            if (this.treeDirectory.SelectedNode != null)
                            {
                                this.treeDirectory.SelectedNode.Collapse();
                                this.treeDirectory.SelectedNode.Expand();
                                //SelectNode(fullPath);
                            }
                        }
                        else
                        {
                            var newFile = File.Create(@fullPath);
                            this.path_txtbox.Text = fullPath;
                            string ext = Path.GetExtension(@fullPath);
                            if (ext == null) //not a valid extention
                            {
                                File.Delete(@fullPath);
                                //file deleted
                                throw new Exception("Not a valid File extention.");
                            }
                            else
                            {
                                newFile.Close();
                                //open the file in new process for user if requested
                                DialogResult d = MessageBox.Show("Would you like to open the file to edit in it's default browser?\n(To save the file you must press the save button or else changes wont be made)", "Edit File", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                if(d != DialogResult.Cancel)
                                {
                                    if (File.Exists(@fullPath))
                                        System.Diagnostics.Process.Start(@fullPath);
                                }
                                if (this.treeDirectory.SelectedNode != null)
                                {
                                    this.treeDirectory.SelectedNode.Collapse();
                                    this.treeDirectory.SelectedNode.Expand();
                                    //SelectNode(fullPath);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {

                if (!this.fileContent.ReadOnly) //if text box is editable change it to uneditable and save file
                {
                    string content = this.fileContent.Text;
                    string fullPath = this.path_txtbox.Text;
                    StreamWriter sw = new StreamWriter(@fullPath);
                    sw.WriteLine(content);
                    sw.Close();
                    //close editable option
                    this.fileContent.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openCommandLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cmdStartat = this.path_txtbox.Text;
            if (cmdStartat == "") //if user enters no path use default
            {
                cmdStartat = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
                    ? Environment.GetEnvironmentVariable("HOME")
                    : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
            }
            try
            {
                Directory.SetCurrentDirectory(cmdStartat);
                System.Diagnostics.Process.Start(@"cmd.exe"); //open new command prompt at the location in the path text box
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error opening CMD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to close?\n\rNote: Any unsaved changes will be lost.", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void watcher_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = this.watcher_ComboBox.SelectedItem.ToString();
            if (path == "All")
                StartAllWatchers();
            else if (path == "None")
                StopAllWatchers();
            else
            {
                string[] items = new string[this.watcher_ComboBox.Items.Count];
                for (int i = 0; i < this.watcher_ComboBox.Items.Count; i++)
                {
                    items[i] = this.watcher_ComboBox.Items[i].ToString();
                }
                foreach (string s in items)
                {
                    StartORStopWatcher(s, false);
                }
                StartORStopWatcher(path, true);
            }
        }

        private void rEADMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to my file explorer. Most of the work is intuitive but there are a few things to notice.\n\rFirst of all, there are a few ways to do similar operations. For example, to view files and folders you can use the treeview or simply by writing the path in the text box at the top. Also note that you can use the mouse or the keyboard to move around the treeview. \n\rFurthermore all files will be displayed on the screen in the middle (you will only be able to read and edit properly text files such as: .txt, binary or python files). Double clicking on any file will open it in its default app.\n\rOn the right hand side you will see the file and folder attributes as well as some buttons for different operations on them.\n\rLastly, this program consists of watchers. Their job is to inform you of any changes on files that are done outside of this program (by highlighting the file/folder with colors according to the action preformed on them). If you wish to cancel them or change them to monitor only one drive go to File --> Options. If you wish to open the command line at the current folder you are in simply go to File --> Open Command Line.", "README", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Date: 8/12/2017\n\rPublisher: Yuval Stein\n\rVersion: 1.0\n\rTeacher: Eran Bineth", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}