using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class MyMacroListView : ListView
    {
        private System.Windows.Forms.ColumnHeader ColHead = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader Flag = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader Category = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader Title = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader Macro = new ColumnHeader();


        public MyMacroListView() : base() 
        {
            // 
            // ColHead
            // 
            this.ColHead.Text = "ID";
            this.ColHead.Width = 0;
            // 
            // Flag
            // 
            this.Flag.Text = "フラグ";
            this.Flag.Width = 64;
            // 
            // Category
            // 
            this.Category.Text = "分類";
            this.Category.Width = 160;
            // 
            // Title
            // 
            this.Title.Text = "タイトル";
            this.Title.Width = 128;
            // 
            // Macro
            // 
            this.Macro.Text = "マクロ";
            this.Macro.Width = 50;

            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColHead,
            this.Flag,
            this.Category,
            this.Title,
            this.Macro});


            this.FullRowSelect = true;
            this.HideSelection = false;
            this.MultiSelect = false;
            this.TabIndex = 0;
            this.UseCompatibleStateImageBehavior = false;
            this.View = System.Windows.Forms.View.Details;


        }

        public void GetCategoryList(out List<string> categories)
        {
            categories = new List<string>();

            foreach (ListViewItem i in this.Items)
            {
                MyItem4MacroListView item = i as MyItem4MacroListView;
                if (!categories.Contains(item.Category))
                {
                    categories.Add(item.Category);
                }
            }

            categories.Sort();
        }

    }
}
