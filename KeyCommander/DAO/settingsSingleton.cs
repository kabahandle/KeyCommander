using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DAOs
{
    class settingsSingleton
    {
        #region //設定のキー
        public const string KeyUsePredictSocialIME = "KeyUsePredictSocialIME";
        public const string KeyUseNormalSocialIME = "KeyUseNormalSocialIME";
        public const string KeyUsePredictVJE = "KeyUsePredictVJE";
        public const string KeyUseNormalVJE = "KeyUseNormalVJE";
        public const string KeyRaiseClickRase = "KeyRaiseClickRase";
        public const string ValueNoneRaiseOnClick = "ValueNoneRaiseObClick";
        public const string ValueRaiseOnNormalClick = "ValueRaiseOnNormalClick";
        public const string ValueRaiseOnShiftClick = "ValueRaiseOnShiftClick";
        public const string ValueRaiseOnAltClick = "ValueRaiseOnAltClick";
        public const string KeyDoGetMailPer10Min = "KeyDoGetMailPer10Min";
        public const string KeyIsMakeRuleBasicMode = "KeyIsMakeRuleBasicMode";
        public const string KeyNotDisplayLisenceDialog = "KeyNotDisplayLisenceDialog";
        public const string KeyIsAdvancedMode = "KeyIsAdvancedMode";
        public const string KeyJP2ENBatchConvertFolderPath = "KeyJP2ENBatchConvertFolderPath";
        public const string KeyEN2JPBatchConvertFolderPath = "KeyEN2JPBatchConvertFolderPath";
        public const string KeyIsHelpWith = "KeyKeyIsHelpWith";
        public const string KeySplitter1SplitDistance = "KeySplitter1SplitDistance";
        public const string KeySplitter2SplitDistance = "KeySplitter2SplitDistance";

        public const string KeyLicenseKey = "KeyLisenceKey";
        #endregion

        #region //定数
        public const string TRUE = "true";
        public const string FALSE = "false";
        #endregion

        public class values
        {
            public int intValue = 0;
            public string strgValue = "";
            public values(int intvalue, string strgvalue)
            {
                this.intValue = intvalue;
                this.strgValue = strgvalue;
            }
        }
        private static Dictionary<string, values> cache_ = new Dictionary<string,values>();
        private static settingsSingleton sigleton_ = new settingsSingleton();

        settingsSingleton()
        {
        }

        public settingsSingleton getInstance()
        {
            return settingsSingleton.sigleton_;
        }

        public static bool isExistsIntValue(string strgKey)
        {
            Dictionary<string,values> c = settingsSingleton.cache_;

            if (c.ContainsKey(strgKey))
            {

                values v = c[strgKey];
                if (v != null)
                {
                    if (v.intValue != Int32.MinValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool isExistsStringValue(string strgKey)
        {
            Dictionary<string, values> c = settingsSingleton.cache_;

            if (c.ContainsKey(strgKey))
            {
                values v = c[strgKey];
                if (v != null)
                {
                    if (v.strgValue != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void getValue(string strgKey, out int intValue)
        {
            intValue = 0;

            if (!settingsSingleton.isExistsIntValue(strgKey))
            {
                //キャッシュになし
                //DBから読み込む
                using (DAOContext con = new DAOContext(AccessConstring.conSettingString))
                {
                    con.OpenConnection();
                    settingsDAO dao = new settingsDAO(con);

                    dao.selectSetting(strgKey, out intValue);

                    con.CloseConnection();

                    settingsSingleton.cache_[strgKey] = new values(intValue, null);
                }
            }
            else
            {
                //キャッシュにあり
                //キャッシュの値を返す
                values v = settingsSingleton.cache_[strgKey];
                intValue = v.intValue;
            }
        }
        public static void getValue(string strgKey, out string strgValue)
        {
            strgValue = "";

            if (!settingsSingleton.isExistsStringValue(strgKey))
            {
                //キャッシュになし
                //DBから読み込む
                using (DAOContext con = new DAOContext(AccessConstring.conSettingString))
                {
                    con.OpenConnection();
                    settingsDAO dao = new settingsDAO(con);

                    dao.selectSetting(strgKey, out strgValue);

                    con.CloseConnection();

                    settingsSingleton.cache_[strgKey] = new values(Int32.MinValue, strgValue);
                }
            }
            else
            {
                //キャッシュにあり
                //キャッシュの値を返す
                values v = settingsSingleton.cache_[strgKey];
                strgValue = v.strgValue;
            }
        }

        public static bool isEqualsIntValue(values v, int intValue)
        {
            if (v != null)
            {
                if (v.intValue == intValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool isEqualsStringValue(values v, string strgValue)
        {
            if (v != null)
            {
                if (v.strgValue.Equals(strgValue))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void setValue(string strgKey, int intValue)
        {
            using (DAOContext con = new DAOContext(AccessConstring.conSettingString))
            {
                con.OpenConnection();
                settingsDAO dao = new settingsDAO(con);
                dao.mergeSettings(strgKey, intValue);
                con.CloseConnection();
            }
            settingsSingleton.cache_[strgKey] = new values(intValue, null);
        }
        public static void setValue(string strgKey, string strgValue)
        {
            using (DAOContext con = new DAOContext(AccessConstring.conSettingString))
            {
                con.OpenConnection();
                settingsDAO dao = new settingsDAO(con);
                dao.mergeSettings(strgKey, strgValue);
                con.CloseConnection();
            }
            settingsSingleton.cache_[strgKey] = new values(Int32.MinValue, strgValue);
        }
    }
}
