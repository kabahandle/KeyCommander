using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class MyItem4DosemuAliasListview : ListViewItem
    {
        private readonly int ITEMID_ORIG_PATH = 1;
        private readonly int ITEMID_ALIAS_PATH = 2;

        public string originalPath
        {
            get
            {
                return this.SubItems[ITEMID_ORIG_PATH].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_ORIG_PATH].Text = value;
            }
        }

        public string AliasPath
        {
            get
            {
                return this.SubItems[ITEMID_ALIAS_PATH].Text;
            }
            set
            {
                this.SubItems[this.ITEMID_ALIAS_PATH].Text = value;
            }
        }

        public MyItem4DosemuAliasListview(string originalPath, string aliasPath)
        {
            this.Text = Guid.NewGuid().ToString();
            this.SubItems.Add(originalPath);
            this.SubItems.Add(aliasPath);
        }

    }
}
