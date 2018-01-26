namespace File_Explorer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeDirectory = new System.Windows.Forms.TreeView();
            this.folders_and_files_icons = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logical_disks = new System.Windows.Forms.ComboBox();
            this.fileContent = new System.Windows.Forms.TextBox();
            this.fileAttributes = new System.Windows.Forms.TextBox();
            this.path_txtbox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.delete_file_btn = new System.Windows.Forms.Button();
            this.file_btn = new System.Windows.Forms.Button();
            this.folder_btn = new System.Windows.Forms.Button();
            this.save_btn = new System.Windows.Forms.Button();
            this.edit_file_btn = new System.Windows.Forms.Button();
            this.rename_btn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCommandLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.watcher_ComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rEADMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeDirectory
            // 
            this.treeDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDirectory.ImageIndex = 0;
            this.treeDirectory.ImageList = this.folders_and_files_icons;
            this.treeDirectory.Location = new System.Drawing.Point(3, 49);
            this.treeDirectory.Name = "treeDirectory";
            this.tableLayoutPanel1.SetRowSpan(this.treeDirectory, 3);
            this.treeDirectory.SelectedImageIndex = 0;
            this.treeDirectory.Size = new System.Drawing.Size(204, 419);
            this.treeDirectory.TabIndex = 0;
            this.treeDirectory.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeDirectory_BeforeLabelEdit);
            this.treeDirectory.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeDirectory.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.CollapseTree);
            this.treeDirectory.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.ExpandTree);
            this.treeDirectory.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDirectory_BeforeSelect);
            this.treeDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeDirectory.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDirectory_NodeMouseDoubleClick);
            // 
            // folders_and_files_icons
            // 
            this.folders_and_files_icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("folders_and_files_icons.ImageStream")));
            this.folders_and_files_icons.TransparentColor = System.Drawing.Color.Transparent;
            this.folders_and_files_icons.Images.SetKeyName(0, "thumb_14343429100Drive.png");
            this.folders_and_files_icons.Images.SetKeyName(1, "2000px-Icons8_flat_folder.svg.png");
            this.folders_and_files_icons.Images.SetKeyName(2, "Icons8_flat_opened_folder.svg.png");
            this.folders_and_files_icons.Images.SetKeyName(3, "file-icon-28038.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.79416F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.20584F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 339F));
            this.tableLayoutPanel1.Controls.Add(this.treeDirectory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.logical_disks, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fileContent, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.fileAttributes, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.path_txtbox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 471);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // logical_disks
            // 
            this.logical_disks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logical_disks.FormattingEnabled = true;
            this.logical_disks.Location = new System.Drawing.Point(3, 26);
            this.logical_disks.Name = "logical_disks";
            this.logical_disks.Size = new System.Drawing.Size(204, 21);
            this.logical_disks.TabIndex = 5;
            this.logical_disks.SelectionChangeCommitted += new System.EventHandler(this.logical_disks_SelectionChangeCommitted);
            // 
            // fileContent
            // 
            this.fileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileContent.Location = new System.Drawing.Point(213, 49);
            this.fileContent.Multiline = true;
            this.fileContent.Name = "fileContent";
            this.fileContent.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.fileContent, 3);
            this.fileContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fileContent.Size = new System.Drawing.Size(406, 419);
            this.fileContent.TabIndex = 6;
            // 
            // fileAttributes
            // 
            this.fileAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileAttributes.Location = new System.Drawing.Point(625, 26);
            this.fileAttributes.Multiline = true;
            this.fileAttributes.Name = "fileAttributes";
            this.fileAttributes.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.fileAttributes, 2);
            this.fileAttributes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.fileAttributes.Size = new System.Drawing.Size(334, 158);
            this.fileAttributes.TabIndex = 7;
            this.fileAttributes.WordWrap = false;
            // 
            // path_txtbox
            // 
            this.path_txtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.path_txtbox.Location = new System.Drawing.Point(213, 26);
            this.path_txtbox.Name = "path_txtbox";
            this.path_txtbox.Size = new System.Drawing.Size(406, 20);
            this.path_txtbox.TabIndex = 8;
            this.path_txtbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.path_txtbox_KeyUp);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.delete_file_btn, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.file_btn, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.folder_btn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.save_btn, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.edit_file_btn, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.rename_btn, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(625, 190);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(334, 278);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // delete_file_btn
            // 
            this.delete_file_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delete_file_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delete_file_btn.Location = new System.Drawing.Point(3, 233);
            this.delete_file_btn.Name = "delete_file_btn";
            this.delete_file_btn.Size = new System.Drawing.Size(328, 42);
            this.delete_file_btn.TabIndex = 3;
            this.delete_file_btn.Text = "Delete Selected Folder/File";
            this.delete_file_btn.UseVisualStyleBackColor = true;
            this.delete_file_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // file_btn
            // 
            this.file_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.file_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_btn.Location = new System.Drawing.Point(3, 49);
            this.file_btn.Name = "file_btn";
            this.file_btn.Size = new System.Drawing.Size(328, 40);
            this.file_btn.TabIndex = 1;
            this.file_btn.Text = "New File";
            this.file_btn.UseVisualStyleBackColor = true;
            this.file_btn.Click += new System.EventHandler(this.file_btn_Click);
            // 
            // folder_btn
            // 
            this.folder_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.folder_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folder_btn.Location = new System.Drawing.Point(3, 3);
            this.folder_btn.Name = "folder_btn";
            this.folder_btn.Size = new System.Drawing.Size(328, 40);
            this.folder_btn.TabIndex = 0;
            this.folder_btn.Text = "New Folder";
            this.folder_btn.UseVisualStyleBackColor = true;
            this.folder_btn.Click += new System.EventHandler(this.folder_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.save_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.save_btn.Location = new System.Drawing.Point(3, 187);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(328, 40);
            this.save_btn.TabIndex = 4;
            this.save_btn.Text = "Save File";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // edit_file_btn
            // 
            this.edit_file_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit_file_btn.Location = new System.Drawing.Point(3, 141);
            this.edit_file_btn.Name = "edit_file_btn";
            this.edit_file_btn.Size = new System.Drawing.Size(328, 40);
            this.edit_file_btn.TabIndex = 5;
            this.edit_file_btn.Text = "Edit File";
            this.edit_file_btn.UseVisualStyleBackColor = true;
            this.edit_file_btn.Click += new System.EventHandler(this.edit_file_btn_Click);
            // 
            // rename_btn
            // 
            this.rename_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rename_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rename_btn.Location = new System.Drawing.Point(3, 95);
            this.rename_btn.Name = "rename_btn";
            this.rename_btn.Size = new System.Drawing.Size(328, 40);
            this.rename_btn.TabIndex = 6;
            this.rename_btn.Text = "Rename Selected Folder/File";
            this.rename_btn.UseVisualStyleBackColor = true;
            this.rename_btn.Click += new System.EventHandler(this.rename_btn_Click);
            // 
            // menuStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.menuStrip1, 3);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 23);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCommandLineToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openCommandLineToolStripMenuItem
            // 
            this.openCommandLineToolStripMenuItem.Name = "openCommandLineToolStripMenuItem";
            this.openCommandLineToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openCommandLineToolStripMenuItem.Text = "Open Command Line";
            this.openCommandLineToolStripMenuItem.Click += new System.EventHandler(this.openCommandLineToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripSeparator1,
            this.watcher_ComboBox});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Select Watchers";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // watcher_ComboBox
            // 
            this.watcher_ComboBox.Name = "watcher_ComboBox";
            this.watcher_ComboBox.Size = new System.Drawing.Size(121, 23);
            this.watcher_ComboBox.SelectedIndexChanged += new System.EventHandler(this.watcher_ComboBox_SelectedIndexChanged);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEADMEToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // rEADMEToolStripMenuItem
            // 
            this.rEADMEToolStripMenuItem.Name = "rEADMEToolStripMenuItem";
            this.rEADMEToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.rEADMEToolStripMenuItem.Text = "README";
            this.rEADMEToolStripMenuItem.Click += new System.EventHandler(this.rEADMEToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(978, 510);
            this.Name = "Form1";
            this.Text = "File Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeDirectory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox logical_disks;
        private System.Windows.Forms.TextBox fileContent;
        private System.Windows.Forms.TextBox fileAttributes;
        private System.Windows.Forms.TextBox path_txtbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button delete_file_btn;
        private System.Windows.Forms.Button file_btn;
        private System.Windows.Forms.Button folder_btn;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.ImageList folders_and_files_icons;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCommandLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rEADMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Button edit_file_btn;
        private System.Windows.Forms.Button rename_btn;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox watcher_ComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

