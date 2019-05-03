using DAOs;
using KCommander.UserClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KCommander
{
    public partial class frmLisence : Form
    {
        private readonly string SoftName = "KeyCommander";
        private readonly string Version = "ver1.05";

        private DateTime regdate = new DateTime();

        public DialogResult result = DialogResult.Cancel;

        public frmLisence(DateTime regdate_)
        {
            InitializeComponent();

            //登録レジストリキー
            string mdbKey = "";
            string machinename = Environment.MachineName;
            settingsSingleton.getValue(settingsSingleton.KeyLicenseKey, out mdbKey);
            //mdbKey = Crypt.DecryptString(mdbKey, Crypt.cryptseed+machinename);
            if (!string.IsNullOrEmpty(mdbKey))
            {
                mdbKey = Crypt.DecryptString(mdbKey, Crypt.cryptseed + machinename);
            }

            //tbxLisenceKey.Text = mdbKey;

            //あと何日？
            this.regdate = regdate_;

            TimeSpan restdays = regdate_.AddDays(LisenceRestDays.days) - DateTime.Today;

            if (restdays.Days > LisenceRestDays.days)
            {
                lblRestDays.Text = LisenceRestDays.days.ToString();
            }
            else if( restdays.Days < 0)
            {
                lblRestDays.Text = "0";
            }
            else
            {
                lblRestDays.Text = restdays.Days.ToString();
            }
        }
        private void WebRegist()
        {
            try
            {
                //---------- 登録時、IPとマシン名と日付をサーバーに記録 ----------------
                string url = @"https://la-bit.sakura.ne.jp/lisence/lisence/reg.php";

//                string username = Environment.UserName;
//                int usernameLen = username.Length;
//                if (usernameLen > 3)
//                {
//                    usernameLen = 3;
//                }
//                username = username.Substring(0, usernameLen);
//
//                string machinename = Environment.MachineName;
//                int machinenameLen = machinename.Length;
//                if (machinenameLen > 3)
//                {
//                    machinenameLen = 3;
//                }
//                machinename = machinename.Substring(0, machinenameLen);
  
                System.Net.WebClient wc = new System.Net.WebClient();
                //NameValueCollectionの作成
                System.Collections.Specialized.NameValueCollection ps =
                    new System.Collections.Specialized.NameValueCollection();
                //送信するデータ（フィールド名と値の組み合わせ）を追加
                ps.Add("softname", this.SoftName);
                ps.Add("version", this.Version);
                ps.Add("username", tbxUserName.Text);
                ps.Add("machinename", tbxMachineName.Text);
                //データを送信し、また受信する
                byte[] resData = wc.UploadValues(url, ps);
                wc.Dispose();

                //受信したデータを表示する
                string resText = System.Text.Encoding.UTF8.GetString(resData);
                //MessageBox.Show(resText);
                //---------- end of登録時、IPとマシン名と日付をサーバーに記録 ----------------
            }
            catch (Exception ex)
            {
                // Web登録失敗→「システムエラー」
                throw;
            }
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            try
            {
                this.WebRegist();
            }
            catch(Exception excp )
            {
                this.result = System.Windows.Forms.DialogResult.Abort;
                this.Close();
                return;
            }
            /*
            //---------- 登録時、IPとマシン名と日付をサーバーに記録 ----------------
            string url = @"https://la-bit.sakura.ne.jp/lisence/lisence/reg.php";

            System.Net.WebClient wc = new System.Net.WebClient();
            //NameValueCollectionの作成
            System.Collections.Specialized.NameValueCollection ps =
                new System.Collections.Specialized.NameValueCollection();
            //送信するデータ（フィールド名と値の組み合わせ）を追加
            ps.Add("softname", "キーサーファー");
            ps.Add("username", Environment.UserName);
            ps.Add("machinename", Environment.MachineName);
            //データを送信し、また受信する
            byte[] resData = wc.UploadValues(url, ps);
            wc.Dispose();

            //受信したデータを表示する
            string resText = System.Text.Encoding.UTF8.GetString(resData);
            //MessageBox.Show(resText);
            //---------- end of登録時、IPとマシン名と日付をサーバーに記録 ----------------
            */

            //---- Access に入力されたライセンスキーを登録 ----------------
            string machinename = Environment.MachineName;
            settingsSingleton.setValue(settingsSingleton.KeyLicenseKey, Crypt.EncryptString(tbxLisenceKey.Text, Crypt.cryptseed+machinename));
            this.result = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.result = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private string ipurl = "http://la-bit.sakura.ne.jp/degisai/lisence/ip.php";

        private void frmLisence_Load(object sender, EventArgs e)
        {
            string username = string.Empty;
            int usernameLen = username.Length;
            if (usernameLen > 3)
            {
                usernameLen = 3;
            }
            username = username.Substring(0, usernameLen);

            string machinename = string.Empty;
            int machinenameLen = machinename.Length;
            if (machinenameLen > 3)
            {
                machinenameLen = 3;
            }
            machinename = machinename.Substring(0, machinenameLen);

            this.tbxUserName.Text = username;
            this.tbxMachineName.Text = machinename;

            
            //this.tbxDescMessage.Text
            //    = @"「登録」ボタンを押して登録時、IPアドレス、ユーザー名、マシン名も登録されます。ユーザー名、マシン名の入力は任意です。";

            /*
            //IP取得
            web4Ip.Navigate(this.ipurl);

            while (web4Ip.ReadyState != WebBrowserReadyState.Complete)
            {
                System.Windows.Forms.Application.DoEvents();
            }

            string ipstr = web4Ip.Document.Body.InnerText;
            tbxIp.Text = ipstr;
            */

            /*
            //コンピュータ名取得
            //tbxComputerName.Text = Environment.MachineName;
            string machinename = Environment.MachineName;
            string XXX = "";
            //コンピュータ名を一部隠す（3文字目以降）
            if (machinename.Length > 3)
            {
                for (int i = 0; i < machinename.Length; i++)
                {
                    if (i < 3)
                    {
                        XXX += machinename[i];
                    }
                    else
                    {
                        XXX += "X";
                    }
                }
            }
            else if (machinename.Length == 3)
            {
                for (int i = 0; i < machinename.Length; i++)
                {
                    if (i < 2)
                    {
                        XXX += machinename[i];
                    }
                    else
                    {
                        XXX += "X";
                    }
                }
            }
            else if (machinename.Length == 2)
            {
                for (int i = 0; i < machinename.Length; i++)
                {
                    if (i < 1)
                    {
                        XXX += machinename[i];
                    }
                    else
                    {
                        XXX += "X";
                    }
                }
            }
            else if (machinename.Length == 1)
            {
                XXX = machinename;
            }

            tbxComputerName.Text = XXX;
             */
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            // ----Web登録　テスト用----
            //this.WebRegist();
            // -------------------------


            //this.btnRegist_Click(sender, e);
            this.result = System.Windows.Forms.DialogResult.Retry;
            this.Close();

        }


    }
}
