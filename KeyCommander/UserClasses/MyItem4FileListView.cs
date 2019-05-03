using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace KCommander.UserClasses
{
    public class MyItem4FileListView : ListViewItem
    {
        private readonly int SubItem_Flag = 1;
        private readonly int SubItem_FileName = 2;
        private readonly int SubItem_FileExt = 3;
        private readonly int SubItem_FileSize = 4;
        private readonly int SubItem_Updated = 4;

        private readonly string dirMark = "<DIR>";

        /*
        public bool IsSelected
        {
            get;
            set;
        }
        */

        public string Head
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public string Flag
        {
            get
            {
                return this.SubItems[this.SubItem_Flag].Text;
            }
            set
            {
                this.SubItems[this.SubItem_Flag].Text = value;
                this.ImageIndex2 = this.ImageIndex;
            }
        }

        public string FileName
        {
            get
            {
                return this.SubItems[this.SubItem_FileName].Text;
            }
            set
            {
                this.SubItems[this.SubItem_FileName].Text = value;
            }
        }

        public string Ext
        {
            get
            {
                return this.SubItems[this.SubItem_FileExt].Text;
            }
            set
            {
                this.SubItems[this.SubItem_FileExt].Text = value;

            }
        }

        public string FileSize
        {
            get
            {
                return this.SubItems[this.SubItem_FileSize].Text;
            }
            set
            {
                this.SubItems[SubItem_FileSize].Text = value;
            }
        }

        public string Updated
        {
            get
            {
                return this.SubItems[this.SubItem_Updated].Text;
            }
            set
            {
                this.SubItems[SubItem_Updated].Text = value;
            }
        }

        public string Dir
        {
            get;
            set;
        }

        public string FullPath
        {
            get;
            set;
        }

        public MyItem4FileListView(string fileName, string ext, string fileSize, string dir, string fullpath, string updated, int imageIndex) : base()
        {
            /*
            this.FileName = fileName;
            this.Ext = ext;
            this.FileSize = FileSize;
            */

            this.Text = fileName;
            this.SubItems.Add("");
            this.SubItems.Add(fileName);
            this.SubItems.Add(ext);
            this.SubItems.Add(fileSize);
            this.SubItems.Add(updated);
            this.Dir = dir;
            DirectoryInfo dirinfo = new DirectoryInfo(fullpath);
            this.FullPath = dirinfo.FullName;
            this.ImageIndex2 = imageIndex;

            if (this.dirMark.Equals(this.Ext))
            {   //DIR
                this.ForeColor = Color.FromArgb(20, 150, 80);
            }
            else
            {   //FILE
                this.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        public int ImageIndex2
        {
            get
            {
                    return base.ImageIndex;
            }
            set
            {
                if ("*".Equals(this.Flag))
                {
                    if (this.dirMark.Equals(this.Ext))
                    {
                        base.ImageIndex = 2;
                    }
                    else
                    {
                        base.ImageIndex = 3;
                    }
                }
                else
                {
                    if (this.dirMark.Equals(this.Ext))
                    {
                        base.ImageIndex = 0;
                    }
                    else
                    {
                        base.ImageIndex = 1;
                    }
                }
            }

        }
    }
}
