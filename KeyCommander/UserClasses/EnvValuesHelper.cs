using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyCommander
{
    public class EnvValuesHelper
    {
        private static IDictionary envVales = Environment.GetEnvironmentVariables();

        public IDictionary EnvValues
        {
            get
            {
                return EnvValuesHelper.envVales;
            }
            private set
            {
                EnvValuesHelper.envVales = value;
            }
        }

        private static EnvValuesHelper singleton = new EnvValuesHelper();

        EnvValuesHelper()
        {
            
        }

        public static EnvValuesHelper getSingleton()
        {
            return EnvValuesHelper.singleton;
        }
    }
}
