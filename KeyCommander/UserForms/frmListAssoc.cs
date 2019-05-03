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
    public partial class frmListAssoc : Form
    {
        private static readonly int NUM_COLUMN = 3;

        public frmListAssoc()
        {
            InitializeComponent();
        }

        private void frmListAssoc_Load(object sender, EventArgs e)
        {
            ListAssoc la = ListAssoc.GetInstance();
            //lm.Load();
            this.listAssoc.Items.Clear();
            foreach (MyItem4AssocListView item in la.Assocs)
            {
                this.listAssoc.Items.Add(item);
            }
            this.listAssoc.ColumnClick += DoColumnClick;

            //はじめに拡張子でソートしておく
            MyColumnComparer colcmp = new MyColumnComparer(2, true);
            this.listAssoc.ListViewItemSorter = colcmp;
            this.listAssoc.Sort();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.listAssoc.SelectedItems.Count <= 0)
            {
                return;
            }

            MyItem4AssocListView i = this.listAssoc.SelectedItems[0] as MyItem4AssocListView;

            if (MessageBox.Show("関連付け：" + i.Title + " を削除しますか？", "削除", MessageBoxButtons.OKCancel)
                == System.Windows.Forms.DialogResult.OK)
            {
                this.listAssoc.Items.Remove(i);
            }

        }

        private void frmListAssoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            ListAssoc la = ListAssoc.GetInstance();
            List<MyItem4AssocListView> assocs = new List<MyItem4AssocListView>();
            foreach (MyItem4AssocListView item in this.listAssoc.Items)
            {
                assocs.Add(item);
            }
            la.Assocs = assocs;

            la.Save();

            this.listAssoc.Items.Clear();

            la.Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.listAssoc.SelectedItems.Count <= 0)
            {
                return;
            }

            frmEditAssoc edit = new frmEditAssoc();

            MyItem4AssocListView i = this.listAssoc.SelectedItems[0] as MyItem4AssocListView;

            edit.item = new MyItem4AssocListView(i.Flag, i.Ext, i.NumString, i.Title, i.Command);

            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyItem4AssocListView item = edit.item;
                i.Flag = item.Flag;
                i.Ext = item.Ext;
                i.Num = item.Num;
                i.Title = item.Title;
                i.Command = item.Command;

                this.listAssoc.Sort();
            }

        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            frmEditAssoc edit = new frmEditAssoc();
            edit.item = new UserClasses.MyItem4AssocListView("", "", "0", "", "");

            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyItem4AssocListView item = edit.item;
                this.listAssoc.Items.Add(item);
                this.listAssoc.Sort();
            }

        }

        private void listAssoc_DoubleClick(object sender, EventArgs e)
        {
            this.btnEdit_Click(sender, e);

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.listAssoc.SelectedItems.Count <= 0)
            {
                return;
            }

            MyItem4AssocListView i = this.listAssoc.SelectedItems[0] as MyItem4AssocListView;

            if (MessageBox.Show("関連付け：" + i.Title + " をコピーしますか？", "コピー", MessageBoxButtons.OKCancel)
                == System.Windows.Forms.DialogResult.OK)
            {
                this.listAssoc.Items.Add( new MyItem4AssocListView( i.Flag, i.Ext, i.NumString, i.Title, i.Command));
                this.listAssoc.Sort();
            }

        }


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

                if (this.colNum == frmListAssoc.NUM_COLUMN)
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
            this.listAssoc.ListViewItemSorter = colcmp;
            this.listAssoc.Sort();
        }



    }
}
