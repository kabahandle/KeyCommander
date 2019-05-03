using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class MacroToolStripMenuItem : ToolStripMenuItem
    {
        public MyItem4MacroListView Item
        {
            get;
            set;
        }

        public MacroToolStripMenuItem()
            : base()
        {
        }
    }
}
