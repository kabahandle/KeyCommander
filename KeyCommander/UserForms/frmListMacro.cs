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
    public partial class frmListMacro : Form
    {
        private static readonly int NUM_COLUMN = -1;

        public frmListMacro()
        {
            InitializeComponent();
        }

        private void btnEditMacro_Click(object sender, EventArgs e)
        {
            if (this.listMyMacroListView.SelectedItems.Count <= 0)
            {
                return;
            }

            frmEditMacro edit = new frmEditMacro();

            MyItem4MacroListView i = this.listMyMacroListView.SelectedItems[0] as MyItem4MacroListView;

            edit.item = new MyItem4MacroListView( i.Flag, i.Category, i.Title, i.Macro );

            List<string> categoris = null;
            this.listMyMacroListView.GetCategoryList(out categoris);
            edit.Categories = categoris;

            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyItem4MacroListView item = edit.item;
                i.Flag = item.Flag;
                i.Category = item.Category;
                i.Title = item.Title;
                i.Macro = item.Macro;

                this.listMyMacroListView.Sort();
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmEditMacro edit = new frmEditMacro();
            edit.item = new UserClasses.MyItem4MacroListView("", "", "", "");
            
            List<string> categoris = null;
            this.listMyMacroListView.GetCategoryList(out categoris);
            edit.Categories = categoris;

            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MyItem4MacroListView item = edit.item;
                this.listMyMacroListView.Items.Add(item);
                this.listMyMacroListView.Sort();
            }

        }

        private void frmListMacro_FormClosing(object sender, FormClosingEventArgs e)
        {
            ListMacro lm = ListMacro.GetInstance();
            List<MyItem4MacroListView> macros = new List<MyItem4MacroListView>();
            foreach (MyItem4MacroListView item in this.listMyMacroListView.Items)
            {
                macros.Add(item);
            }
            lm.Macros = macros;

            lm.Save();

            lm.Load();

            this.listMyMacroListView.Items.Clear();
        }

        private void frmListMacro_Load(object sender, EventArgs e)
        {
            ListMacro lm = ListMacro.GetInstance();
            //lm.Load();
            this.listMyMacroListView.Items.Clear();
            foreach (MyItem4MacroListView item in lm.Macros)
            {
                this.listMyMacroListView.Items.Add(item);
            }
            this.listMyMacroListView.ColumnClick += this.DoColumnClick;
            this.listMyMacroListView.Columns[4].Width = 400;
        }

        private void btnDeleteMacro_Click(object sender, EventArgs e)
        {
            if (this.listMyMacroListView.SelectedItems.Count <= 0)
            {
                return;
            }

            MyItem4MacroListView i = this.listMyMacroListView.SelectedItems[0] as MyItem4MacroListView;

            if (MessageBox.Show("マクロ：" + i.Title + " を削除しますか？", "削除", MessageBoxButtons.OKCancel)
                == System.Windows.Forms.DialogResult.OK)
            {
                this.listMyMacroListView.Items.Remove(i);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listMyMacroListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.btnEditMacro_Click(sender, e);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.listMyMacroListView.SelectedItems.Count <= 0)
            {
                return;
            }

            MyItem4MacroListView i = this.listMyMacroListView.SelectedItems[0] as MyItem4MacroListView;

            if (MessageBox.Show("マクロ：" + i.Title + " をコピーしますか？", "コピー", MessageBoxButtons.OKCancel)
                == System.Windows.Forms.DialogResult.OK)
            {
                this.listMyMacroListView.Items.Add( new MyItem4MacroListView( i.Flag, i.Category, i.Title, i.Macro ));
                this.listMyMacroListView.Sort();
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

                if (this.colNum == frmListMacro.NUM_COLUMN)
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
            this.listMyMacroListView.ListViewItemSorter = colcmp;
            this.listMyMacroListView.Sort();
        }

    }
}
