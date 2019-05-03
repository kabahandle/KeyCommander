using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ABCS.Classes
{
    public delegate void OnResizeHook4Form();

    public class SlidingButton : Button
    {
        private Point mouseDownPoint = Point.Empty;
        private Point originalPoint = Point.Empty;
        public OnResizeHook4Form resizeHook = null;

        public void setLeft(int left)
        {
            this.Left = left;

            if (this.resizeHook != null)
            {
                this.resizeHook();
            }

            this.Refresh();
        }

        public int avgX
        {
            get
            {
                return this.Left + this.Width / 2;
            }
            set
            {
                this.Left = value - this.Width / 2;
            }
        }

        public SlidingButton()
            : base()
        {
            this.MouseDown += new MouseEventHandler(SlidingButton_MouseDown1);
            //this.MouseClick += new MouseEventHandler(AnisTabControl_MouseClick);
            this.MouseUp += new MouseEventHandler(SlidingButton_MouseUp1);
            //this.MouseDoubleClick += new MouseEventHandler(SlidingButton_MouseDoubleClick);
            //this.MouseWheel += new MouseEventHandler(AnisTabControl_MouseWheel);
            this.MouseMove += new MouseEventHandler(SlidingButton_MouseMove);

        }
        void SlidingButton_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = e.Location;
                originalPoint = new Point(this.Top, this.Left);
            }
            else
            {
                mouseDownPoint = Point.Empty;
            }
        }

        void SlidingButton_MouseUp1(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        void SlidingButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint != Point.Empty)
            {
                Rectangle mouseMoveRectangle = new Rectangle(
                    mouseDownPoint.X - 5, mouseDownPoint.Y - 5,
                    10, 10);
                Rectangle r = new Rectangle(new Point(0,0), this.Size);
                if (r.Contains(e.Location))
                {

                    Point p = new Point(mouseDownPoint.X - e.Location.X, mouseDownPoint.Y - e.Location.Y);
                    int x = 0;
                    if( p.X > 0 ) 
                    {
                        x = 2;
                    }
                    else 
                    {
                        x = -2;
                    }
                    this.Left -= x;
                    //this.OnMouseUp(e);

                    if (this.resizeHook != null)
                    {
                        this.resizeHook();
                    }

                    this.Refresh();
                }
            }
        }

    }
}
