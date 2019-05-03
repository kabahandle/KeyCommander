using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DAOs
{
    class settingsDAO : MyDAOBase
    {
        public settingsDAO(DAOContext con) : base(con) { }

        public void selectSetting(string strgKey, out int intValue)
        {
            string sql = @"select *
                            from settings
                            where
                                SETTINGKEY like @pkey";

            this.ClearParameters();
            this.AddParameter("pkey", DbType.String, strgKey);

            DataTable tbl = base.GetTable(sql);

            if (tbl.Rows.Count > 0)
            {
                int ret = 0;
                int.TryParse(tbl.Rows[0]["INTVALUE"].ToString(), out ret);
                intValue = ret;
            }
            else
            {
                intValue = 0;
            }
        }

        public void selectSetting(string strgKey, out string strgValue)
        {
            string sql = @"select *
                            from settings
                            where
                                SETTINGKEY like @pkey";

            this.ClearParameters();
            this.AddParameter("pkey", DbType.String, strgKey);

            DataTable tbl = base.GetTable(sql);

            if (tbl.Rows.Count > 0)
            {
                strgValue = tbl.Rows[0]["TEXTVALUE"].ToString();
            }
            else
            {
                strgValue = "";
            }
        }

        public bool isExistSetting(string strgKey)
        {
            string sql = @"select *
                            from settings
                            where
                                SETTINGKEY like @pkey";

            this.ClearParameters();
            this.AddParameter("pkey", DbType.String, strgKey);

            DataTable tbl = base.GetTable(sql);

            if (tbl.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #region //数値設定

        public int updateDate(string strgKey, int intValue)
        {
            string sql = @"update settings
                            set
                                INTVALUE = @pintvalue
                            where
                                SETTINGKEY like @pkey";

            this.ClearParameters();
            this.AddParameter("pintvalue", DbType.Int32, intValue);
            this.AddParameter("pkey", DbType.String, strgKey);

            return base.ExecuteNonQuery(sql);
        }

        public int insertNew(string strgKey, int intValue)
        {
            string sql = @"insert into
                            settings(
                                 SETTINGKEY
                                ,INTVALUE
                            )
                            values(
                                 @pkey
                                ,@pintvalue
                            )";

            this.ClearParameters();
            this.AddParameter("pkey", DbType.String, strgKey);
            this.AddParameter("pintvalue", DbType.Int32, intValue);

            return base.ExecuteNonQuery(sql);
        }

        public int mergeSettings(string strgKey, int intValue)
        {
            if (this.isExistSetting(strgKey))
            {
                return this.updateDate(strgKey, intValue);
            }
            else
            {
                return this.insertNew(strgKey, intValue);
            }
        }

        #endregion

        #region //文字設定

        public int updateDate(string strgKey, string strgValue)
        {
            string sql = @"update settings
                            set
                                TEXTVALUE = @ptextvalue
                            where
                                SETTINGKEY like @pkey";

            this.ClearParameters();
            this.AddParameter("ptextvalue", DbType.String, strgValue);
            this.AddParameter("pkey", DbType.String, strgKey);

            return base.ExecuteNonQuery(sql);
        }

        public int insertNew(string strgKey, string strgValue)
        {
            string sql = @"insert into
                            settings(
                                SETTINGKEY
                                ,TEXTVALUE
                            )
                            values(
                                @ppkey
                                ,@pptextvalue
                            )";

            this.ClearParameters();
            this.AddParameter("ppkey", DbType.String, strgKey);
            this.AddParameter("pptextvalue", DbType.String, strgValue);

            return base.ExecuteNonQuery(sql);
        }

        public int mergeSettings(string strgKey, string strgValue)
        {
            if (this.isExistSetting(strgKey))
            {
                return this.updateDate(strgKey, strgValue);
            }
            else
            {
                return this.insertNew(strgKey, strgValue);
            }
        }

        #endregion
    }
}
