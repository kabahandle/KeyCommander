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
    public partial class frmEditMacro : Form
    {
        public MyItem4MacroListView item
        {
            get;
            set;
        }

        public List<string> Categories
        {
            get;
            set;
        }

        public frmEditMacro()
        {
            InitializeComponent();
        }

        private void frmEditMacro_Load(object sender, EventArgs e)
        {
            if (this.item != null)
            {
                if (!string.IsNullOrEmpty(item.Flag))
                {
                    if (item.Flag.Contains("M"))
                    {
                        chkShowInRightClickMenu.Checked = true;
                    }
                    else
                    {
                        chkShowInRightClickMenu.Checked = false;
                    }

                    if (item.Flag.Contains("D"))
                    {
                        chkDirect.Checked = true;
                    }
                    else
                    {
                        chkDirect.Checked = false;
                    }

                    if (item.Flag.Contains("S"))
                    {
                        chkStdOut.Checked = true;
                    }
                    else
                    {
                        chkStdOut.Checked = false;
                    }
                }
                else
                {
                    chkShowInRightClickMenu.Checked = false;
                    chkDirect.Checked = false;
                }

                if (this.Categories != null)
                {
                    foreach (string cat in this.Categories)
                    {
                        cmbCategory.Items.Add(cat);
                    }
                }
                cmbCategory.Text = this.item.Category;

                tbxTitle.Text = this.item.Title;

                tbxMacro.Text = this.item.Macro;

            }
            else
            {
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.item.Flag = "";
            if (chkShowInRightClickMenu.Checked == true)
            {
                this.item.Flag += "M";
            }
            if (chkDirect.Checked == true)
            {
                //this.item.Flag += "P";
                this.item.Flag += "D";
            }
            if( chkStdOut.Checked == true )
            {
                this.item.Flag += "S";
            }
            this.item.Category = cmbCategory.Text;
            this.item.Title = tbxTitle.Text;
            this.item.Macro = tbxMacro.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
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
                this.tbxMacro.Text = "\"" + dlg.FileName + "\"";
            }

        }

        

    }
}
