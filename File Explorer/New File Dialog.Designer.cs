namespace File_Explorer
{
    partial class New_File_Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_File_Dialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.file_location_label = new System.Windows.Forms.Label();
            this.file_name_label = new System.Windows.Forms.Label();
            this.file_name_txtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.file_type_label = new System.Windows.Forms.Label();
            this.file_extentions_comboBox = new System.Windows.Forms.ComboBox();
            this.file_path_txtBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.file_location_label, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.file_name_label, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.file_name_txtBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.file_type_label, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.file_extentions_comboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.file_path_txtBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 139);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(145, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 52);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // file_location_label
            // 
            this.file_location_label.AutoSize = true;
            this.file_location_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_location_label.Location = new System.Drawing.Point(3, 27);
            this.file_location_label.Name = "file_location_label";
            this.file_location_label.Size = new System.Drawing.Size(136, 27);
            this.file_location_label.TabIndex = 1;
            this.file_location_label.Text = "File Location:";
            this.file_location_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // file_name_label
            // 
            this.file_name_label.AutoSize = true;
            this.file_name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_name_label.Location = new System.Drawing.Point(3, 0);
            this.file_name_label.Name = "file_name_label";
            this.file_name_label.Size = new System.Drawing.Size(136, 27);
            this.file_name_label.TabIndex = 0;
            this.file_name_label.Text = "File Name:";
            this.file_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // file_name_txtBox
            // 
            this.file_name_txtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.file_name_txtBox.Location = new System.Drawing.Point(145, 3);
            this.file_name_txtBox.Name = "file_name_txtBox";
            this.file_name_txtBox.Size = new System.Drawing.Size(136, 20);
            this.file_name_txtBox.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // file_type_label
            // 
            this.file_type_label.AutoSize = true;
            this.file_type_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_type_label.Location = new System.Drawing.Point(3, 54);
            this.file_type_label.Name = "file_type_label";
            this.file_type_label.Size = new System.Drawing.Size(136, 27);
            this.file_type_label.TabIndex = 6;
            this.file_type_label.Text = "File Type:";
            this.file_type_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // file_extentions_comboBox
            // 
            this.file_extentions_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.file_extentions_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.file_extentions_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_extentions_comboBox.FormattingEnabled = true;
            this.file_extentions_comboBox.Items.AddRange(new object[] {
            ".txt",
            ".doc",
            ".docx",
            ".ppt",
            ".pptx",
            ".xls",
            ".xlsx",
            ".pdf",
            ".rtf",
            ".bmp",
            ".jpeg",
            ".jpg",
            ".png",
            ".py",
            ""});
            this.file_extentions_comboBox.Location = new System.Drawing.Point(145, 57);
            this.file_extentions_comboBox.Name = "file_extentions_comboBox";
            this.file_extentions_comboBox.Size = new System.Drawing.Size(136, 21);
            this.file_extentions_comboBox.TabIndex = 7;
            // 
            // file_path_txtBox
            // 
            this.file_path_txtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.file_path_txtBox.Location = new System.Drawing.Point(145, 30);
            this.file_path_txtBox.Name = "file_path_txtBox";
            this.file_path_txtBox.Size = new System.Drawing.Size(136, 20);
            this.file_path_txtBox.TabIndex = 8;
            // 
            // New_File_Dialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "New_File_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New File";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label file_location_label;
        private System.Windows.Forms.Label file_name_label;
        private System.Windows.Forms.TextBox file_name_txtBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label file_type_label;
        private System.Windows.Forms.ComboBox file_extentions_comboBox;
        private System.Windows.Forms.TextBox file_path_txtBox;
    }
}