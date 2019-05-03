using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class AssocToolStripMenuItem : ToolStripMenuItem
    {
        public MyItem4AssocListView Item
        {
            get;
            set;
        }

        public AssocToolStripMenuItem()
            : base()
        {
        }

    }
}
