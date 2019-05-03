using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCommander
{
    public static class DataFilePath
    {
        public static readonly string Path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Ringing-Web\KeyCommander";
        public static readonly string AppData = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string AppData_ringing_Web = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Ringing-Wewb";

        static DataFilePath()
        {
            if (!DataFilePath.Path.StartsWith("C"))
            {
                DataFilePath.Path = "C" + DataFilePath.Path.Substring(1);
            }
        }
    }
}
