using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class MyItem4ShortcutListview : ListViewItem
    {
        private readonly int ITEMID_KEY = 1;
        private readonly int ITEMID_CMD = 2;

        public string Key
        {
            get
            {
                return this.SubItems[ITEMID_KEY].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_KEY].Text = value;
            }
        }

        public string Cmd
        {
            get
            {
                return this.SubItems[ITEMID_CMD].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_CMD].Text = value;
            }
        }

        public MyItem4ShortcutListview(string key, string cmd)
        {
            this.Text = Guid.NewGuid().ToString();
            this.SubItems.Add(key);
            this.SubItems.Add(cmd);
        }

    }
}
