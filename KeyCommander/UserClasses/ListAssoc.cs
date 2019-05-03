using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class ListAssoc
    {
        private readonly string AssocFilename = "assoc.txt";

        private static ListAssoc singleton = new ListAssoc();

        public static ListAssoc GetInstance()
        {
            return ListAssoc.singleton;
        }

        private List<MyItem4AssocListView> assocs = new List<MyItem4AssocListView>();
        public List<MyItem4AssocListView> Assocs
        {
            get
            {
                return this.assocs;
            }
            set
            {
                this.assocs = value;
            }
        }

        ListAssoc()
        {
        }

        public void Load()
        {
            this.assocs.Clear();

#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\" + this.AssocFilename, FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\" + this.AssocFilename, FileMode.OpenOrCreate);
#endif
            StreamReader r = new StreamReader(fs);
            string line = "";

            while ((line = r.ReadLine()) != null)
            {
                string[] cols = line.Split('\t');
                if (cols.Length != 5)
                {
                    continue;
                }
                MyItem4AssocListView item = new MyItem4AssocListView(cols[0], cols[1], cols[2], cols[3], cols[4]);
                this.assocs.Add(item);
            }

            r.Close();
            fs.Close();
        }

        public void Save()
        {
            FileStream fs = null;
            StreamWriter w = null;
            try
            {
                try
                {
#if DEBUG
                    fs = File.Open(Application.StartupPath + @"\" + this.AssocFilename, FileMode.OpenOrCreate | FileMode.Truncate);
#else
                    fs = File.Open(DataFilePath.Path + @"\" + this.AssocFilename, FileMode.OpenOrCreate | FileMode.Truncate);
#endif
                    w = new StreamWriter(fs);
                }
                catch (Exception excp)
                {
#if DEBUG
                    fs = File.Open(Application.StartupPath + @"\" + this.AssocFilename, FileMode.OpenOrCreate);
#else
                    fs = File.Open(DataFilePath.Path + @"\" + this.AssocFilename, FileMode.OpenOrCreate);
#endif
                    w = new StreamWriter(fs);
                }

                foreach (MyItem4AssocListView item in this.assocs)
                {
                    w.WriteLine(
                        item.Flag + "\t"
                        + item.Ext + "\t"
                        + item.NumString + "\t"
                        + item.Title + "\t"
                        + item.Command
                        );
                    w.Flush();
                }

            }
            catch (Exception excep)
            {
            }
            finally
            {
                if (w != null)
                {
                    w.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public List<MyItem4AssocListView> GetAssocCommandsFromExt( string ext)
        {
            List<MyItem4AssocListView> list =  new List<MyItem4AssocListView>();
            foreach (MyItem4AssocListView item in this.Assocs)
            {
                if (ext != null && ext.ToUpper().Equals(("."+item.Ext).ToUpper()))
                {
                    if (item != null && item.Flag.Contains("M"))
                    {
                        list.Add(item);
                    }
                }
            }
            list.Sort(this.comparison);
            return list;
        }

        public int comparison(MyItem4AssocListView x, MyItem4AssocListView y)
        {
            int ret = 0;
            if ((ret = x.Ext.CompareTo(y.Ext)) == 0)
            {
                ret = x.Num.CompareTo(y.Num);
            }
            return ret;
        }

        public void SortByExt()
        {
            this.assocs.Sort(this.comparison);
        }

    }
}

