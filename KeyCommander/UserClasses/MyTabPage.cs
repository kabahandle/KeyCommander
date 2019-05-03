using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class MyTabPage : TabPage
    {
        private ListBox listBox = new System.Windows.Forms.ListBox();

        public MyTabPage( string nameText = "TabPage"  ) : base() 
        {
            this.Controls.Add(this.listBox);
            this.Location = new System.Drawing.Point(4, 22);
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(330, 192);
            this.TabIndex = 0;
            this.Text = nameText;
            this.UseVisualStyleBackColor = true;
        }

        public ListBox ListBox
        {
            get
            {
                return this.listBox;
            }
        }

    }
}
