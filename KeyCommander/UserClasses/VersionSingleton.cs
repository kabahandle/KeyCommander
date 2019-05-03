using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCommander.UserClasses
{
    public class VersionSingleton
    {
        private readonly string KeyCommanderName = "KeyCommander";
        private readonly string KeyCommanderVersion = "ver1.18";

        private static VersionSingleton singleton = new VersionSingleton();

        VersionSingleton(string addingString = "")
        {
            if (!string.IsNullOrEmpty(addingString))
            {
                this.KeyCommanderVersion = addingString + " - " + this.KeyCommanderName + " " + this.KeyCommanderVersion;
            }
        }

        public static VersionSingleton GetInstance()
        {
            return VersionSingleton.singleton;
        }

        public string GetVersion()
        {
            return this.KeyCommanderName + " " + this.KeyCommanderVersion;
        }
    }    
}
