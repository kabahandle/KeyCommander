using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class ListMacro
    {
        private readonly string MacroFilename = "macro.txt";

        private static ListMacro singleton = new ListMacro();

        private List<MyItem4MacroListView> macros = new List<MyItem4MacroListView>();
        public List<MyItem4MacroListView> Macros
        {
            get
            {
                return this.macros;
            }
            set
            {
                this.macros = value;
            }
        }

        ListMacro()
        {
        }

        public static ListMacro GetInstance()
        {
            return ListMacro.singleton;
        }

        public void Load()
        {
            this.macros.Clear();

#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\" + this.MacroFilename, FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\" + this.MacroFilename, FileMode.OpenOrCreate);
#endif
            StreamReader r = new StreamReader(fs);
            string line = "";

            while( ( line = r.ReadLine() ) != null )
            {
                string[] cols = line.Split('\t');
                if( cols.Length != 4 )
                {
                    continue;
                }
                MyItem4MacroListView item = new MyItem4MacroListView( cols[0], cols[1], cols[2], cols[3]);
                this.macros.Add(item);
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
                    fs = File.Open(Application.StartupPath + @"\" + this.MacroFilename, FileMode.OpenOrCreate | FileMode.Truncate);
#else
                    fs = File.Open(DataFilePath.Path + @"\" + this.MacroFilename, FileMode.OpenOrCreate | FileMode.Truncate);
#endif
                    w = new StreamWriter(fs);
                }
                catch (Exception excp)
                {
#if DEBUG
                    fs = File.Open(Application.StartupPath + @"\" + this.MacroFilename, FileMode.OpenOrCreate);
#else
                    fs = File.Open(DataFilePath.Path + @"\" + this.MacroFilename, FileMode.OpenOrCreate);
#endif
                    w = new StreamWriter(fs);
                }

                foreach (MyItem4MacroListView item in this.macros)
                {
                    w.WriteLine(
                        item.Flag + "\t"
                        + item.Category + "\t"
                        + item.Title + "\t"
                        + item.Macro
                        );
                    w.Flush();
                }

            }
            catch (Exception excp)
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

        private int comparison(MyItem4MacroListView x, MyItem4MacroListView y)
        {
            int ret = 0;
            if ((ret = x.Category.CompareTo(y.Category)) == 0)
            {
                if (!string.IsNullOrEmpty(x.Title))
                {
                    ret = x.Title.CompareTo(y.Title);
                }
                else
                {
                    ret = 0;
                }

            }
            return ret;
        }

        public void SortByCategory()
        {
            this.Macros.Sort(this.comparison);
        }

    }
}
