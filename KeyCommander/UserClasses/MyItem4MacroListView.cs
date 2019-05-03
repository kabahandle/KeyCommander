using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class MyItem4MacroListView : ListViewItem
    {
        private readonly int ITEMID_FLAG = 1;
        private readonly int ITEMID_CATEGORY = 2;
        private readonly int ITEMID_TITLE = 3;
        private readonly int ITEMID_MACRO = 4;
        private readonly string dirMark = "<DIR>";
        
        public string Flag
        {
            get
            {
                return this.SubItems[ITEMID_FLAG].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_FLAG].Text = value;
            }
        }

        
        public string Category
        {
            get
            {
                return this.SubItems[this.ITEMID_CATEGORY].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_CATEGORY].Text = value;
            }
        }

        public string Title
        {
            get
            {
                return this.SubItems[this.ITEMID_TITLE].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_TITLE].Text = value;
            }
        }

        public string Macro
        {
            get
            {
                return this.SubItems[this.ITEMID_MACRO].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_MACRO].Text = value;
            }
        }

        public MyItem4MacroListView(string flag, string category, string title, string macro)
        {
            this.Text = Guid.NewGuid().ToString();
            this.SubItems.Add(flag);
            this.SubItems.Add(category);
            this.SubItems.Add(title);
            this.SubItems.Add(macro);
        }

    }
}
