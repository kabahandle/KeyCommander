using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class ListDosemuAlias
    {
        private readonly string AssocFilename = "dosemualiases.txt";

        private static ListDosemuAlias singleton = new ListDosemuAlias();

        public static ListDosemuAlias GetInstance()
        {
            return ListDosemuAlias.singleton;
        }

        //private List<MyItem4ShortcutListview> shortcuts = new List<MyItem4ShortcutListview>();
        //public List<MyItem4ShortcutListview> Shortcuts
        //{
        //    get
        //    {
        //        return this.shortcuts;
        //    }
        //    set
        //    {
        //        this.shortcuts = value;
        //    }
        //}

        private int KeyLengthCompare(MyItem4ShortcutListview x, MyItem4ShortcutListview y)
        {
            if (x.Key.Length > y.Key.Length)
            {
                return -1;
            }
            else if (x.Key.Length < y.Key.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //public string Filter(string cmdline)
        //{
        //    List<MyItem4ShortcutListview> list = new List<MyItem4ShortcutListview>();
        //    foreach (MyItem4ShortcutListview item in this.Shortcuts)
        //    {
        //        list.Add(item);
        //    }
        //    list.Sort(KeyLengthCompare);
        //    foreach (MyItem4ShortcutListview item in list)
        //    {
        //        cmdline = cmdline.Replace("#" + item.Key, item.Cmd);
        //    }
        //    return cmdline;
        //}

        public void Load()
        {
            //this.shortcuts.Clear();

#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\" + this.AssocFilename, FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\" + this.AssocFilename, FileMode.OpenOrCreate);
#endif
            StreamReader r = new StreamReader(fs);
            string line = "";

            string originalPath = "";
            string aliasPath = "";
            Dictionary<string, string> aliases = new Dictionary<string, string>();

            while ((line = r.ReadLine()) != null)
            {
                string[] cols = line.Split('\t');
                if (cols.Length < 2)
                {
                    continue;
                }

                originalPath = cols[0];
                aliasPath = cols[1];

                aliases.Add(originalPath, aliasPath);
                
            }

            MacroVarReplacer.DosBoxDirMounts = aliases;

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

                //foreach (MyItem4ShortcutListview item in this.shortcuts)
                foreach(KeyValuePair<string,string> kv in MacroVarReplacer.DosBoxDirMounts)
                {
                    w.WriteLine(
                         kv.Key + "\t"
                        + kv.Value
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

    }
}
