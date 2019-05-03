using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace KCommander.UserClasses
{
    public class MyItem4AssocListView : ListViewItem
    {
        private readonly int ITEMID_FLAG = 1;
        private readonly int ITEMID_EXT = 2;
        private readonly int ITEMID_NUM = 3;
        private readonly int ITEMID_TITLE = 4;
        private readonly int ITEMID_COMMAND = 5;

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

        public string Ext
        {
            get
            {
                return this.SubItems[ITEMID_EXT].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_EXT].Text = value;
            }
        }

        public int Num
        {
            get
            {
                int i = 0;
                int.TryParse(this.SubItems[ITEMID_NUM].Text, out i);
                return i;
            }
            set
            {
                this.SubItems[this.ITEMID_NUM].Text = value.ToString();
            }
        }

        public string NumString
        {
            get
            {
                return this.SubItems[ITEMID_NUM].Text;
            }
            set
            {
                int i = 0;
                int.TryParse(value, out i);
                this.SubItems[this.ITEMID_NUM].Text = i.ToString();
            }
        }

        public string Title
        {
            get
            {
                return this.SubItems[ITEMID_TITLE].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_TITLE].Text = value;
            }
        }

        public string Command
        {
            get
            {
                return this.SubItems[ITEMID_COMMAND].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_COMMAND].Text = value;
            }
        }

        public MyItem4AssocListView(string flag, string ext, string num, string title, string command)
        {
            int num_ = 0;
            int.TryParse(num, out num_);
            this.Text = Guid.NewGuid().ToString();
            this.SubItems.Add(flag);
            this.SubItems.Add(ext);
            this.SubItems.Add(num);
            this.SubItems.Add(title);
            this.SubItems.Add(command);
        }
    }
}
