using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KCommander.UserClasses;
using System.Collections;

namespace KCommander.UserForms
{
    public partial class frmListShortcut : Form
    {
        private static readonly int NUM_COLUMN = -1;

        public frmListShortcut()
        {
            InitializeComponent();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            if (this.listShortcuts.SelectedItems.Count < 1)
            {
                return;
            }

            MyItem4ShortcutListview item = this.listShortcuts.SelectedItems[0] as MyItem4ShortcutListview;
            if (item != null)
            {
                this.tbxKey.Text = item.Key;
                this.tbxCommand.Text = item.Cmd;
            }*/
        }

        private void panel1_BackgroundImageLayoutChanged(object sender, EventArgs e)
        {

        }

        private void frmListShortcut_Load(object sender, EventArgs e)
        {
            ListShortcut ls = ListShortcut.GetInstance();
            //lm.Load();
            this.listAliases.Items.Clear();
            foreach (MyItem4ShortcutListview item in ls.Shortcuts)
            {
                this.listAliases.Items.Add(item);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.listAliases.SelectedItems.Count <= 0)
            {
                return;
            }

            MyItem4ShortcutListview i = this.listAliases.SelectedItems[0] as MyItem4ShortcutListview;

            if (MessageBox.Show("ショートカット：" + i.Key + " を削除しますか？", "削除", MessageBoxButtons.OKCancel)
                == System.Windows.Forms.DialogResult.OK)
            {
                this.listAliases.Items.Remove(i);
            }

        }

        private void frmListShortcut_FormClosing(object sender, FormClosingEventArgs e)
        {
            ListShortcut ls = ListShortcut.GetInstance();
            List<MyItem4ShortcutListview> shortcuts = new List<MyItem4ShortcutListview>();
            foreach (MyItem4ShortcutListview item in this.listAliases.Items)
            {
                shortcuts.Add(item);
            }
            ls.Shortcuts = shortcuts;

            ls.Save();

            ls.Load();

            this.listAliases.Items.Clear();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.listAliases.SelectedItems.Count <= 0)
            {
                return;
            }

            frmEditShortcut edit = new frmEditShortcut();

            MyItem4ShortcutListview i = this.listAliases.SelectedItems[0] as MyItem4ShortcutListview;

            edit.item = new MyItem4ShortcutListview(i.Key, i.Cmd);


            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyItem4ShortcutListview item = edit.item;
                i.Key = item.Key;
                i.Cmd = item.Cmd;

                this.listAliases.Sort();
            }
            /*
            if (this.listShortcuts.SelectedItems.Count <= 0)
            {
                return;
            }

            MyItem4ShortcutListview item = this.listShortcuts.SelectedItems[0] as MyItem4ShortcutListview;
            if (item != null)
            {
                item.Key = tbxKey.Text;
                item.Cmd = tbxCommand.Text;
            }
            */

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEditShortcut edit = new frmEditShortcut();
            edit.item = new UserClasses.MyItem4ShortcutListview("", "");


            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyItem4ShortcutListview item = edit.item;
                this.listAliases.Items.Add(item);
                this.listAliases.Sort();
            }
            /*
            MyItem4ShortcutListview item = new MyItem4ShortcutListview( tbxKey.Text, tbxCommand.Text);
            if (item != null)
            {
                this.listShortcuts.Items.Add(item);
                this.listShortcuts.Sort();
            }
            */
        }

        /*
        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = @"c:\";
            dlg.DefaultExt = "exe";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbxCommand.Text = "\"" + dlg.FileName + "\"";
            }

        }*/

        class MyColumnComparer : IComparer
        {
            private int colNum = 0;
            private bool isAsc = false;

            public MyColumnComparer(int colNum, bool isAsc)
            {
                this.colNum = colNum;
                this.isAsc = isAsc;
            }
            public int Compare(object a, object b)
            {
                ListViewItem l1 = a as ListViewItem;
                ListViewItem l2 = b as ListViewItem;
                if (l1 == null | l2 == null) return 0;

                //if( l1.SubItems.Count < this.colNum+1 || l2.SubItems.Count < this.colNum +1 ) return 0;

                if (this.colNum == frmListShortcut.NUM_COLUMN)
                {
                    int i1 = 0;
                    int i2 = 0;
                    int.TryParse(l1.SubItems[this.colNum].Text, out i1);
                    int.TryParse(l2.SubItems[this.colNum].Text, out i2);
                    if (this.isAsc)
                    {
                        return i1.CompareTo(i2);
                    }
                    else
                    {
                        return i2.CompareTo(i1);
                    }
                }

                if (this.isAsc)
                {
                    return l1.SubItems[this.colNum].Text.CompareTo(l2.SubItems[this.colNum].Text);
                }
                else
                {
                    return l2.SubItems[this.colNum].Text.CompareTo(l1.SubItems[this.colNum].Text);
                }


            }
        }
        static int oldCol = -1;
        static bool oldAsc = false;
        public void DoColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            bool isAsc = true;
            if (oldCol != e.Column)
            {
                oldCol = e.Column;
                isAsc = true;
                oldAsc = true;
            }
            else
            {
                isAsc = !oldAsc;
                oldAsc = isAsc;
            }
            //MessageBox.Show(e.Column.ToString()+" "+isAsc.ToString());

            MyColumnComparer colcmp = new MyColumnComparer(e.Column, isAsc);
            this.listAliases.ListViewItemSorter = colcmp;
            this.listAliases.Sort();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.listAliases.SelectedItems.Count <= 0)
            {
                return;
            }

            MyItem4ShortcutListview i = this.listAliases.SelectedItems[0] as MyItem4ShortcutListview;

            if (MessageBox.Show("ショートカット：" + i.Key + " をコピーしますか？", "コピー", MessageBoxButtons.OKCancel)
                == System.Windows.Forms.DialogResult.OK)
            {
                this.listAliases.Items.Add(new MyItem4ShortcutListview(i.Key, i.Cmd));
                this.listAliases.Sort();
            }
        }

        private void listShortcuts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.btnEdit_Click(sender, e);
        }
    }
}
