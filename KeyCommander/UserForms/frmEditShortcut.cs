using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KCommander.UserClasses;

namespace KCommander.UserForms
{
    public partial class frmEditShortcut : Form
    {
        public MyItem4ShortcutListview item
        {
            get;
            set;
        }


        public frmEditShortcut()
        {
            InitializeComponent();
        }

        private void frmEditAssoc_Load(object sender, EventArgs e)
        {
            if (this.item != null)
            {
                tbxKey.Text = this.item.Key;

                tbxShortcut.Text = this.item.Cmd;

            }
            else
            {
                this.Close();
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.item.Key = tbxKey.Text;
            this.item.Cmd = tbxShortcut.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"c:\";
            dlg.DefaultExt = "exe";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbxShortcut.Text = "\"" + dlg.FileName + "\"";
            }
            
        }

        private void chkStdOut_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
