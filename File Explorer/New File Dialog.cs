using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Explorer
{
    public partial class New_File_Dialog : Form
    {
        public string[] file_info;

        public New_File_Dialog()
        {
            InitializeComponent();
        }

        public void Set_Path_label(string str)
        {
            this.file_path_txtBox.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create button was clicked
            this.file_info = new string[3];
            this.file_info[0] = this.file_name_txtBox.Text;
            this.file_info[1] = this.file_path_txtBox.Text;
            
            this.file_info[2] = this.file_extentions_comboBox.Text;
        }
    }
}
