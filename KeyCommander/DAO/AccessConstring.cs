using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAOs
{
    class AccessConstring
    {
        //public static string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\\Data\\main.mdb";
        public static string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\App_Data\\main.mdb";
        public static string conSettingString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\App_Data\\data.mdb";
    }
}
