using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class CommandMenu : ContextMenuStrip
    {
        public CommandMenu(EventHandler onMenuClick, string ext) : base() 
        {
            this.BuildMenu( onMenuClick, ext );
        }

        private void BuildMenu(EventHandler onMenuClick, string ext)
        {
            ListAssoc la = ListAssoc.GetInstance();
            List<MyItem4AssocListView> list = la.GetAssocCommandsFromExt(ext);

            foreach (MyItem4AssocListView item in list)
            {
                if (!string.IsNullOrEmpty(item.Flag) && item.Flag.Contains("M"))
                {
                    AssocToolStripMenuItem m = new AssocToolStripMenuItem();
                    m.Text = item.Title;
                    m.Item = item;
                    m.Click += onMenuClick;
                    this.Items.Add(m);
                }
            }

        }

    }
}
