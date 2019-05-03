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
    public partial class frmEditAssoc : Form
    {
        public MyItem4AssocListView item
        {
            get;
            set;
        }

        
        public frmEditAssoc()
        {
            InitializeComponent();
        }

        private void frmEditAssoc_Load(object sender, EventArgs e)
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
                        chkPause.Checked = true;
                    }
                    else
                    {
                        chkPause.Checked = false;
                    }

                    if (item.Flag.Contains("S"))
                    {
                        chkStdOut.Checked = true;
                    }
                    else
                    {
                        chkStdOut.Checked = false;
                    }
                    if (item.Flag.Contains("O"))
                    {
                        this.chkDOS.Checked = true;
                    }
                    else
                    {
                        this.chkDOS.Checked = false;
                    }
                }
                else
                {
                    chkShowInRightClickMenu.Checked = false;
                    chkPause.Checked = false;
                }

                tbxExt.Text = this.item.Ext;
                tbxNum.Text = this.item.NumString;
                tbxTitle.Text = this.item.Title;

                tbxCommand.Text = this.item.Command;

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
            if (chkPause.Checked == true)
            {
                //this.item.Flag += "P";
                this.item.Flag += "D";
            }
            if (chkStdOut.Checked == true)
            {
                this.item.Flag += "S";
            }
            if (this.chkDOS.Checked == true)
            {
                this.item.Flag += "O";
            }
            this.item.Ext = tbxExt.Text;
            this.item.NumString = tbxNum.Text;
            this.item.Title = tbxTitle.Text;
            this.item.Command = tbxCommand.Text;

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
                this.tbxCommand.Text = "\"" + dlg.FileName + "\"";
            }
            
        }

        private void chkStdOut_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
