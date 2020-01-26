using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KCommander.UserClasses;
using KCommander.UserForms;
using System.IO;
using DAOs;
using KCommander.UserClass;
using System.Diagnostics;
using KeyCommander.UserClasses;
//using KHRegistory;

namespace KCommander
{
    public partial class frmKeyCommander : Form
    {
        private static string UnderAppData = @"\Ringing-Web\KeyCommander\";

        public static string AppData = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + frmKeyCommander.UnderAppData;

        private readonly string tabDirFile = "tabfiles.txt";
        // ver1.00
        //private string registoryKey = @"Software\TKKC\sub0001";
        // ver1.01
        //private string registoryKey = @"Software\TKKC\sub0002";
        // ver1.03
        //private string registoryKey = @"Software\TKKC\sub0003";
        // ver1.05
        private string registoryKey = @"Software\TKKC\sub0004";

        private readonly bool isDoLicenseCheck = false;

        private FormSizeSaveAdapter formSizeAdapter = null;


        public frmKeyCommander()
        {
            InitializeComponent();

            this.formSizeAdapter = new FormSizeSaveAdapter(this);
        }

        private void btnSetCmbDir_Click(object sender, EventArgs e)
        {

            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            if (string.IsNullOrEmpty(cmbDir.Text))
            {
                fbd.SelectedPath = Application.StartupPath;
            }
            else
            {
                fbd.SelectedPath = cmbDir.Text;
            }
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                //Console.WriteLine(fbd.SelectedPath);
                cmbDir.Items.Add(fbd.SelectedPath);
                cmbDir.Text = fbd.SelectedPath;
                this.cmbDir.Focus();
            }
        }

        private void btnShowIntotab_Click(object sender, EventArgs e)
        {
            foreach (MyDirListView v in this.tabCtrlSide1.SelectedTab.Controls.OfType<MyDirListView>())
            {
                v.Open(cmbDir.Text);
            }
            this.listView1.Focus();
        }

        private void frmKCommander_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.formSizeAdapter != null)
            {
                this.formSizeAdapter.Save();
            }
            this.cmbDir.Save();
            this.cmbCommandLine.Save();
            this.SaveDirs();
            this.listView1.Save(1);
            this.listView2.Save(2);
        }

        private void SaveDirs()
        {
            FileStream fs = null;
            StreamWriter w = null;
            try
            {

#if DEBUG
                fs = File.Open(Application.StartupPath + @"\" + this.tabDirFile, FileMode.OpenOrCreate);
#else
                fs = File.Open(DataFilePath.Path + @"\" + this.tabDirFile, FileMode.OpenOrCreate);
#endif
                w = new StreamWriter(fs);

                w.WriteLine(this.listView1.CurDir);
                w.WriteLine(this.listView2.CurDir);
                w.Flush();
            }
            catch (Exception ex)
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

        private void LoadDirs()
        {
            FileStream fs = null;
            StreamReader r = null;
            try
            {
#if DEBUG
                fs = File.Open(Application.StartupPath + @"\" + this.tabDirFile, FileMode.OpenOrCreate);
#else
                fs = File.Open(DataFilePath.Path + @"\" + this.tabDirFile, FileMode.OpenOrCreate);
#endif
                r = new StreamReader(fs);

                string tmp = "";
                string tmp2 = "";
                tmp2 = r.ReadLine();
                if (string.IsNullOrEmpty(tmp2))
                {
                    return;
                }
                this.listView2.Open(tmp2);
                tmp = r.ReadLine();
                if (string.IsNullOrEmpty(tmp))
                {
                    return;
                }
                this.listView1.Open(tmp);
            }
            catch (Exception ex)
            {
            }
            finally
            {

                if (r != null)
                {
                    r.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
                r = null;
                fs = null;
            }
        }

        /*
        private bool LisenceCheck()
        {
            string mdbKey = "";
            string machinename = Environment.MachineName;
            settingsSingleton.getValue(settingsSingleton.KeyLicenseKey, out mdbKey);
            if (!string.IsNullOrEmpty(mdbKey))
            {
                mdbKey = Crypt.DecryptString(mdbKey, Crypt.cryptseed + machinename);
            }
            else
            {
                mdbKey = "";
            }

            RegJudge j = new RegJudge();
            j.registoryKey = this.registoryKey;

            //mdb保存ライセンスキーと一致するか
            if (!string.IsNullOrEmpty(mdbKey) && j.isMatchWithLisenceKey(mdbKey))
            {
                //ok
                return true;
            }

            //ライセンスキー入力
            frmLisenceOLD001 fL = new frmLisenceOLD001(j.getRegDate());
            fL.ShowDialog();

            settingsSingleton.getValue(settingsSingleton.KeyLicenseKey, out mdbKey);
            if (!string.IsNullOrEmpty(mdbKey))
            {
                mdbKey = Crypt.DecryptString(mdbKey, Crypt.cryptseed + machinename);
            }
            else
            {
                mdbKey = "";
            }

            bool ret = j.juedge(mdbKey, LisenceRestDays.days);    //30日間試用


            //mdb保存ライセンスキーと一致するか
            if (!string.IsNullOrEmpty(mdbKey) && j.isMatchWithLisenceKey(mdbKey))
            {
            }
            else
            {
                if (fL.result == DialogResult.OK)
                {

                    MessageBox.Show("ライセンスキーが一致しません。");
                }
            }

            //bool ret = j.juedge(mdbKey, LisenceRestDays.days);    //30日間試用

            return ret;


            //bool ret = j.juedge(tbxLisenceKey.Text, judgeTerm);
        }
        */


        #region // ライセンス
        private enum LisenceResultType
        {
            OK,
            Cancel,
            KeyMotMathch,
            Trial,  // 試用
        }
        private LisenceResultType LisenceCheck(out bool IsDayError)
        {
            IsDayError = false;
            return LisenceResultType.OK;

            /*

            string mdbKey = "";
            string machinename = Environment.MachineName;
            settingsSingleton.getValue(settingsSingleton.KeyLicenseKey, out mdbKey);
            if (!string.IsNullOrEmpty(mdbKey))
            {
                mdbKey = Crypt.DecryptString(mdbKey, Crypt.cryptseed + machinename);
            }
            else
            {
                mdbKey = "";
            }

            RegJudge j = new RegJudge();
            j.registoryKey = this.registoryKey;

            //mdb保存ライセンスキーと一致するか
            if (!string.IsNullOrEmpty(mdbKey) && j.isMatchWithLisenceKey(mdbKey))
            {
                //ok
                return LisenceResultType.OK;
            }

            //ライセンスキー入力
            frmLisence fL = new frmLisence(j.getRegDate());
            fL.ShowDialog();
            if (fL.result == System.Windows.Forms.DialogResult.Cancel)
            {
                return LisenceResultType.Cancel;
            }
            else if (fL.result == System.Windows.Forms.DialogResult.Retry)
            {   // 試用
            }
            else if (fL.result == System.Windows.Forms.DialogResult.Abort)
            {   //Abort -> 例外
                throw new Exception();
            }

            settingsSingleton.getValue(settingsSingleton.KeyLicenseKey, out mdbKey);
            if (!string.IsNullOrEmpty(mdbKey))
            {
                mdbKey = Crypt.DecryptString(mdbKey, Crypt.cryptseed + machinename);
            }
            else
            {
                mdbKey = "";
            }

            bool ret = j.juedge(mdbKey, LisenceRestDays.days);    //30日間試用
            if (ret == false)
            {
                IsDayError = true;
            }
            else
            {
                IsDayError = false;
            }


            //mdb保存ライセンスキーと一致するか
            if (!string.IsNullOrEmpty(mdbKey) && j.isMatchWithLisenceKey(mdbKey))
            {
                return LisenceResultType.OK;
            }
            else
            {
                if (fL.result == System.Windows.Forms.DialogResult.Retry)
                {   // 試用
                    return LisenceResultType.Trial; // 試用
                }
                else
                {
                    return LisenceResultType.KeyMotMathch;
                }
            }

            //bool ret = j.juedge(mdbKey, LisenceRestDays.days);    //30日間試用

            //return ret;


            //bool ret = j.juedge(tbxLisenceKey.Text, judgeTerm);
             */
        }

        /*
        private void LoopLicenseCheck(out bool isCanceled)
        {
            bool ret = false;
            bool isDaysOver = true;
            isCanceled = false;
            try
            {
                ret = this.LisenceCheck(out isDaysOver, out isCanceled);
            }
            catch (Exception excp_)
            {
                ret = false;
            }
            if (ret == false)
            {
                if (isCanceled == false)
                {
                    MessageBox.Show("ご試用期間" + LisenceRestDays.days.ToString() + "日が過ぎました。"); ;
                    this.LoopLicenseCheck(out isCanceled);
                }
                else
                {   // Cancel
                    //this.Close();
                    return;
                }
            }
            else
            {
                isCanceled = false;
                return;
            }
        }*/
        private void DoLisenceCheck()
        {
            //---- ライセンスチェック ----
            bool isDayError = true;
            LisenceResultType ret = LisenceResultType.Cancel;
            try
            {
                ret = this.LisenceCheck(out isDayError);
            }
            catch (Exception excp_)
            {
                //ret = LisenceResultType.Cancel;
                MessageBox.Show("システムエラー。終了します。");
                this.Close();
            }

            if (ret == LisenceResultType.Cancel)
            {   // キャンセル
                MessageBox.Show("キャンセルしました。");
                this.Close();
            }
            if (isDayError)
            {   // 試用期間でない
                if (ret != LisenceResultType.OK)
                {   // ライセンスキーが一致しない
                    if (ret == LisenceResultType.KeyMotMathch)
                    {
                        MessageBox.Show("ライセンスキーが一致しません。");
                        this.Close();
                    }
                    else if (ret == LisenceResultType.Trial)
                    {   //　試用
                        MessageBox.Show("ご試用期間" + LisenceRestDays.days.ToString() + "日が過ぎました。");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ご試用期間" + LisenceRestDays.days.ToString() + "日が過ぎました。");
                        this.Close();
                    }
                }
                else
                {   // ライセンスキーが一致する
                }
            }
            else
            {   // 試用期間中
                int seed = (int)(DateTime.Now.ToBinary() / (int.MaxValue / 3));
                Random rnd = new Random(seed);

                double d = rnd.NextDouble();

                if (ret != LisenceResultType.OK)
                {
                    // ランダムに確認ダイアログを表示する
                    if (d > 0.3)
                    {
                        frmConfirm confirm = new frmConfirm();
                        confirm.ShowDialog();
                    }

                    if (ret == LisenceResultType.KeyMotMathch)
                    {
                    }
                    else if (ret == LisenceResultType.Trial)
                    {   // 試用
                    }
                    else if (ret == LisenceResultType.OK)
                    {
                    }
                }
                else
                {   // ライセンスキーが一致する
                }
            }
            // --- end of ライセンスチェック ---
        }
        #endregion // ライセンス



        private void frmKCommander_Load(object sender, EventArgs e)
        {
            // https://blogs.msdn.microsoft.com/smartclientdata/2005/08/26/working-with-local-databases/
#if DEBUG
#else
            AppDomain.CurrentDomain.SetData("DataDirectory", System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Ringing-Web\\KeyCommander\\App_Data");
#endif
            /*
            //ライセンスチェック

            bool ret = false;
            try
            {
                ret = this.LisenceCheck();
            }
            catch (Exception excp_)
            {
                ret = false;
            }
            if (ret == false)
            {
                MessageBox.Show("ご試用期間" + LisenceRestDays.days.ToString() + "日が過ぎました。終了します。"); ;
                this.Close();
            }
            */

            if (this.formSizeAdapter != null)
            {
                this.formSizeAdapter.Load();
            }
            this.cmbDir.Load();
            this.cmbDir.OnCtrlTPress += this.CmbDirCtrlCPress;
            this.cmbDir.OnCtrlHPress += this.OnHPressHandler;
            this.cmbDir.OnCtrlBPress += this.OnBPressHandler;
            this.cmbCommandLine.Load();
            this.cmbCommandLine.OnCtrlTPress += this.CmbCmdLineCtrlTPress;
            this.cmbCommandLine.PassTheCurDir += this.OnPassThrCurDirRequested;
            this.cmbCommandLine.OnCtrlHPress += this.OnHPressHandler;
            this.cmbCommandLine.OnCtrlBPress += this.OnBPressHandler;

            this.listView1.SmallImageList = this.imageList;
            this.listView2.SmallImageList = this.imageList;
            this.listView1.OnRPress += delegate()
            {
                this.listView2.Focus();
            };
            this.listView2.OnRPress += delegate()
            {
                this.listView1.Focus();
            };
            this.listView1.OnTPress += delegate()
            {
                this.cmbDir.Focus();
            };
            this.listView2.OnTPress += delegate()
            {
                this.cmbDir.Focus();
            };
            this.listView1.OnChangeCurDir += this.listView2.SetTargetDir;
            this.listView2.OnChangeCurDir += this.listView1.SetTargetDir;
            this.listView2.OnChangeCurDir += this.onChangeDir;
            this.listView1.OnChangeCurDir += this.onChangeDir;
            this.listView2.OnDoneMenu += this.listView1.Open;
            this.listView1.OnDoneMenu += this.listView2.Open;
            this.listView1.OnWPress += this.ToggleListView2;
            this.listView2.OnWPress += this.ToggleListView2;
            this.listView1.OnCPress += delegate
            {
                this.cmbCommandLine.Focus();
            };
            this.listView2.OnCPress += delegate
            {
                this.cmbCommandLine.Focus();
            };
            this.listView1.OnXPress += this.OnXPress;
            this.listView2.OnXPress += this.OnXPress;
            this.listView1.OnHPress += this.OnHPressHandler;
            this.listView2.OnHPress += this.OnHPressHandler;
            this.listView1.OnBPress += this.OnBPressHandler;
            this.listView2.OnBPress += this.OnBPressHandler;
            this.listView1.Load(1);
            this.listView2.Load(2);
            MyDirListView.Focused = this.listView1;

            //メニュー
            this.Menu = new MainMenu();

            this.Menu.MenuItems.Add("ファイル(&F)");
            MenuItem mProgramFolder = new MenuItem("プログラムフォルダ(&P)");
            mProgramFolder.Click += delegate
            {
                var startInfo = new ProcessStartInfo();
#if DEBUG
                startInfo.FileName = Application.StartupPath;// +@"\App_Data";
#else
                startInfo.FileName = frmKeyCommander.AppData;
#endif
                startInfo.Arguments = "";
                Process process = Process.Start(startInfo);
            };
            this.Menu.MenuItems[0].MenuItems.Add(mProgramFolder);
            this.Menu.MenuItems[0].MenuItems.Add("-");
            MenuItem mExit = new MenuItem("終了(&E)");
            mExit.Click += delegate
            {
                this.Close();
            };
            this.Menu.MenuItems[0].MenuItems.Add(mExit);

            
            this.Menu.MenuItems.Add("設定(&S)");

            //this.Menu.MenuItems[1].MenuItems.Add("マクロ(&M)");
            MenuItem mListMacro = new MenuItem("マクロ一覧(&M)");
            mListMacro.Click += delegate
            {
                frmListMacro frmLM = new frmListMacro();
                frmLM.ShowDialog();
            };
            this.Menu.MenuItems[1].MenuItems.Add(mListMacro);

            //this.Menu.MenuItems.Add("関連付け(&A)");
            MenuItem mListAssoc = new MenuItem("関連付け一覧(&A)");
            mListAssoc.Click += delegate
            {
                frmListAssoc frmLA = new frmListAssoc();
                frmLA.ShowDialog();
            };
            this.Menu.MenuItems[1].MenuItems.Add(mListAssoc);

            //this.Menu.MenuItems.Add("ショートカット(&S)");
            MenuItem mListShortcut = new MenuItem("ショートカット一覧(&S)");
            mListShortcut.Click += delegate
            {
                frmListShortcut frmLS = new frmListShortcut();
                frmLS.ShowDialog();
            };
            this.Menu.MenuItems[1].MenuItems.Add(mListShortcut);
            
            //this.Menu.MenuItems.Add("Dosemuエイリアス(&E)");
            MenuItem mDosemuAlias = new MenuItem("Dosboxマウント一覧(&D)");
            mDosemuAlias.Click += delegate
            {
                frmListDosemuDirAlias frmDA = new frmListDosemuDirAlias();
                frmDA.ShowDialog();
            };
            this.Menu.MenuItems[1].MenuItems.Add(mDosemuAlias);


            this.LoadDirs();
            ListMacro lm = ListMacro.GetInstance();
            lm.Load();
            ListAssoc la = ListAssoc.GetInstance();
            la.Load();
            ListShortcut ls = ListShortcut.GetInstance();
            ls.Load();
            ListDosemuAlias ld = ListDosemuAlias.GetInstance();
            ld.Load();

            //this.cmbDir.Focus();

            // ヘルプ
            Showhelp(0);

            /*
             * // 2015/08/01 不採用
            this.btnHide.Parent = this;
            this.btnHide.BringToFront();
             */

            // ライセンスチェック
            if (this.isDoLicenseCheck)
            {
                this.DoLisenceCheck();
            }


        }

        private void onChangeDir(string DirFullpath )
        {
            this.Text = DirFullpath + " - " + VersionSingleton.GetInstance().GetVersion();
        }

        private string OnPassThrCurDirRequested()
        {
            //MyDirListView list = MyDirListView.Focused;
            MyDirListView list = LastFocusedListView.lastFocusedListView;
            if (list != null)
            {
                return list.CurDir;
            }
            return string.Empty;
        }


        private void CmbCmdLineCtrlTPress()
        {
            this.cmbDir.Focus();
        }
        private void CmbDirCtrlCPress()
        {
            this.cmbCommandLine.Focus();
        }

        private bool IsShowListView2 = true;
        private void ToggleListView2()
        {
            if (this.IsShowListView2 == true)
            {
                this.IsShowListView2 = !this.IsShowListView2;
                this.frmKCommander_Resize(this, new EventArgs());
            }
            else
            {
                this.IsShowListView2 = !this.IsShowListView2;
                this.frmKCommander_Resize(this, new EventArgs());
            }
        }

        private void frmKCommander_Resize(object sender, EventArgs e)
        {
            if (this.IsShowListView2 == true)
            {
                //this.pnlSide1.Width = this.Width / 2;
                this.splitContainer2.Panel2Collapsed = false;
            }
            else
            {
                //this.pnlSide1.Width = this.Width;
                this.splitContainer2.Panel2Collapsed = true;
            }

            /*
             * // 2015/08/01 不採用
            this.btnHide.Top = this.Top + this.Height - 33 - 116;
            this.btnHide.Left = this.Left + this.Width - 33 -84;
            this.btnHide.BringToFront();
             */
        }

        private void frmKCommander_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyValue.ToString());
        }

        private void frmKCommander_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (MyDirListView v in this.tabCtrlSide2.SelectedTab.Controls.OfType<MyDirListView>())
            {
                v.Open(cmbDir.Text);
            }
            this.listView2.Focus();
        }

        private void cmbDir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(cmbDir.Text))
                {
                    if (e.Shift == false)
                    {
                        this.listView1.Open(cmbDir.Text);
                        this.listView1.Focus();
                        e.Handled = true;
                    }
                    else
                    {
                        this.listView2.Open(cmbDir.Text);
                        this.listView2.Focus();
                        e.Handled = true;
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                MyDirListView.ReForcus();
            }
        }

        private void timerTopMost_Tick(object sender, EventArgs e)
        {
            //short shiftcode = win32api.GetAsyncKeyState(win32api.VK_SHIFT);
            short altcode = win32api.GetAsyncKeyState(win32api.VK_ALT);
            short keyctrl = win32api.GetAsyncKeyState(win32api.VK_CONTROL);
            //short keycode = win32api.GetAsyncKeyState((int)Keys.LButton);
            if (((altcode & 0x8000) == 0x8000)
                    && (((keyctrl & 0x8000) == 0x8000))
            )
            {
                this.TopMost = true;
                System.Windows.Forms.Application.DoEvents();
                this.TopMost = false;

                System.Windows.Forms.Application.DoEvents();

                this.Activate();

                for (int i = 0; i < 100; i++)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                MyDirListView.ReForcus();

                for (int i = 0; i < 100; i++)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }


        }

        /*
        private void tbxCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                this.listView1.Exec(cmbCommandLine.Text);
                this.listView1.Focus();
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Enter )
            {
                this.listView2.Exec(cmbCommandLine.Text);
                this.listView2.Focus();
                e.Handled = true;
            }

            if( e.Handled == true )
            {
                if (!cmbCommandLine.Items.Contains(cmbCommandLine.Text))
                {
                    this.cmbCommandLine.Items.Add(cmbCommandLine.Text);
                }
            }
        }
        */

        private void btnExecTab1_Click(object sender, EventArgs e)
        {
            if (!cmbCommandLine.Items.Contains(cmbCommandLine.Text))
            {
                this.cmbCommandLine.Items.Add(cmbCommandLine.Text);
            }
            this.listView1.Exec(cmbCommandLine.Text);
            this.listView1.Focus();
        }

        private void btnExecTab2_Click(object sender, EventArgs e)
        {
            if (!cmbCommandLine.Items.Contains(cmbCommandLine.Text))
            {
                this.cmbCommandLine.Items.Add(cmbCommandLine.Text);
            }
            this.listView2.Exec(cmbCommandLine.Text);
            this.listView2.Focus();
        }
        
        private void cmbCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            bool isSaveCommandline = false;
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                this.listView1.Exec(cmbCommandLine.Text);
                //this.listView1.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
                isSaveCommandline = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.listView2.Exec(cmbCommandLine.Text);
                //this.listView2.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
                isSaveCommandline = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                MyDirListView.ReForcus();
            }

            if (isSaveCommandline == true)
            {
                if (!cmbCommandLine.Items.Contains(cmbCommandLine.Text))
                {
                    this.cmbCommandLine.Items.Add(cmbCommandLine.Text);
                }
            }

        }

        private void btnClearCommandHistory_Click(object sender, EventArgs e)
        {
            DialogResult ret = System.Windows.Forms.DialogResult.Cancel;

            ret = MessageBox.Show("履歴を全て削除しますか？", "確認", MessageBoxButtons.OKCancel);

            if (ret == System.Windows.Forms.DialogResult.OK)
            {
                this.cmbCommandLine.Items.Clear();
                this.cmbCommandLine.Text = string.Empty;
                this.cmbCommandLine.Save();
                this.cmbCommandLine.Focus();
                MessageBox.Show("削除しました。");
            }
            else
            {
                MessageBox.Show("キャンセルしました。");
            }
        }

        private void btnClearCurrentHistory_Click(object sender, EventArgs e)
        {
            this.cmbCommandLine.Items.Remove(this.cmbCommandLine.Text);
            this.cmbCommandLine.Text = string.Empty;
            this.cmbCommandLine.Save();
            this.cmbCommandLine.Focus();
        }

        private void OnXPress(MyDirListView sender)
        {
            if (string.IsNullOrEmpty(this.cmbCommandLine.Text))
            {
                return;
            }
            if (this.listView1.Equals(sender))
            {
                this.listView1.Exec(cmbCommandLine.Text);
                this.listView1.Focus();
            }
            else
            {
                this.listView2.Exec(cmbCommandLine.Text);
                this.listView2.Focus();
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lst = sender as ListView;
            if (lst != null)
            {
                if (lst.Sorting == SortOrder.Ascending)
                {
                    lst.Sorting = SortOrder.Descending;
                    //lst.ListViewItemSorter
                }
                else
                {
                    lst.Sorting = SortOrder.Ascending;
                }
                
            }
        }

        static int toggleShowingHelpNo = 1;

        private void buttonKeyHelp_Click(object sender, EventArgs e)
        {
            this.Showhelp(0);
        }

        private void buttonCommandLineHelp_Click(object sender, EventArgs e)
        {
            this.Showhelp(1);
        }

        public void Showhelp(int NoOrder = -1)
        {
            if (NoOrder >= 0)
            {
                toggleShowingHelpNo = NoOrder;
            }
            if (toggleShowingHelpNo == 0)
            {
                string[] lines = {
                        @"【キーヘルプ】",
                        @"[ ]:(スペース)ファイルを選択  [A]: 全て選択  [F]: ファイルメニュー  [E]: 実行メニュー  [R]: 別のリストに移る",
                        @"[Alt+C]: コマンドライン入力へ移動　[Alt+F]: Dir名入力へ移動　[Alt+L]: ファイルリストへ移動　",
                        @"[ESC]: リストビューへ戻る　[X]: コマンドライン実行（コマンドラインに入力があるとき）　[V]: 詳細表示／一覧表示切り替え　",
                        @"[W]: 1ウィンドウ／2ウィンドウ切り替え　[ALT+CTRL]: KY中佐を最前面に表示　[H]: ヘルプ切り替え表示　[B]:ヘルプ表示／非表示",
                        @"[SHIFT+<アルファベット>]:  アルファベットを先頭に持つファイル名検索",
                        @"【コマンドライン時】[Ctrl+Space]: コマンドライン補完（ヒストリから）　[TAB]: コマンドライン補完（Dirから）",
                        @"　　　　　　　　　　[Ctrl+R]: 補完候補を範囲選択（右端側で実行のこと）",
                        @"【Dir時】[Ctrl+Space]: Dir補完（ヒストリから）　[TAB]: Dir補完（Dirから）",
                             };
                textBoxHelp.Lines = lines;

            }
            else if( toggleShowingHelpNo == 1 )
            {
                string[] lines = {
                        @"【コマンドラインヘルプ】",
                        @"[Enter]: タブ１のフォルダで実行　[SHIFT+ENTER]:タブ２のフォルダで実行　[ESC]:キャンセル",
                        @"[Ctrl+Space]: 今まで実行したコマンドを補完（複数回可）",
                        @"> ;XXX   ←　ウィンドウを表示せずに、コマンド実行。",
                        @"> !XXX   ←　コマンド実行後、標準出力をエディタで表示",
                             };
                textBoxHelp.Lines = lines;

            }
            else if (toggleShowingHelpNo == 2)
            {
                string[] lines = {
                        @"【変数ヘルプ】",
                        @"$C ： カレントファイル（拡張子を含む）と置換します。",
                        @"$CC： Cygwin形式のカレントファイル（拡張子を含む）と置換します。",
                        @"$c ： DOS形式のカレントファイル（拡張子を含む）と置換します。",
                        @"$P ： カレントディレクトリのパスと置換します。",
                        @"$PP： Cygwin形式のカレントディレクトリのパスと置換します。",
                        @"$p ： DOS形式のカレントディレクトリのパスと置換します。",
                        @"$T :  ターゲットディレクトリのパスと置換します。",
                        @"$TT :  Cygwin形式のターゲットディレクトリのパスと置換します。",
                        @"$t  :  DOS形式のターゲットディレクトリのパスと置換します。",
                        @"$D ： カレントドライブと置換します。",
                        @"$d  :  DOS形式のターゲットドライブと置換します。",
                        @"$A  :  全てのファイル（拡張子を含む）と置換します。",
                        @"$a  :  DOS形式の全てのファイル（拡張子を含む）と置換します。",
                        @"$X ： カレントファイル（拡張子を含まない）と置換します。",
                        @"$x ： DOS形式のカレントファイル（拡張子を含まない）と置換します。",
                        @"$R ： マクロ実行時、パラメータの追加入力を行う。",
                        @"$Q ： 『""』(ダブルクォーテーション)と置換します。",
                        @"$Z ： 『,』(カンマ)と置換します。",
                        @";   ： 複数のコマンドを指定する(マルチステートメント)場合、コマンドとコマンドの間に書きます。",
                        @"『""』は実行ファイル名をくくる以外の場所では使用しないでください。『""』",
                        @"を使用する場合は $Q を使用してください。$P 等で置換したファイル名に",
                        @"ロングファイルネームが含まれる場合、$Q を使用してファイル名をくくってください。",
                             };

                textBoxHelp.Lines = lines;

            }
            toggleShowingHelpNo++;
            if (toggleShowingHelpNo > 2)
            {
                toggleShowingHelpNo = 0;
            }
            this.textBoxHelp.Focus();
            this.textBoxHelp.SelectionLength = 0;

        }

        private void OnHPressHandler()
        {
            this.Showhelp();
        }

        private void buttonValiableHelp_Click(object sender, EventArgs e)
        {
            this.Showhelp(2);
        }

        // 「B」キー：ヘルプパネルを非常時／表示のトグル
        private int pnlBottomHeightSize = 70;
        private void OnBPressHandler()
        {
            //if (pnlBottom.Height == 0)
            if (this.IsHelpViewHided())
            {
                //pnlBottom.Height = this.pnlBottomHeightSize;
                this.ShowHelpView();
            }
            else
            {
                //pnlBottom.Height = 0;
                this.HideHelpView();
            }
        }

        public bool IsHelpViewHided()
        {
            return (/*pnlBottom.Height*/ this.splitContainer1.Panel2.Height == 0);
        }
        public void ShowHelpView()
        {
            /*pnlBottom.Height*/ //this.splitContainer2.Panel2.Height = this.pnlBottomHeightSize;
            this.splitContainer1.Panel2Collapsed = false;
        }
        public void HideHelpView()
        {
            /*pnlBottom.Height*/ //this.splitContainer2.Panel2.Height = 0;
            this.splitContainer1.Panel2Collapsed = true;
        }

        private void grpCommandLine_Enter(object sender, EventArgs e)
        {
            this.cmbCommandLine.Focus();
        }

        private void grpDir_Enter(object sender, EventArgs e)
        {
            this.cmbDir.Focus();
        }

        private void btnClearCurrentDirHistory_Click(object sender, EventArgs e)
        {
            this.cmbDir.Items.Remove(this.cmbDir.Text);
            this.cmbDir.Text = string.Empty;
            this.cmbDir.Save();
            this.cmbDir.Focus();
        }

        private void btnClearDirHistory_Click(object sender, EventArgs e)
        {
            DialogResult ret = System.Windows.Forms.DialogResult.Cancel;

            ret = MessageBox.Show("履歴を全て削除しますか？", "確認", MessageBoxButtons.OKCancel);

            if (ret == System.Windows.Forms.DialogResult.OK)
            {
                this.cmbDir.Items.Clear();
                this.cmbDir.Text = string.Empty;
                this.cmbDir.Save();
                this.cmbDir.Focus();
                MessageBox.Show("削除しました。");
            }
            else
            {
                MessageBox.Show("キャンセルしました。");
            }
        }

        private void groupFiler_Enter(object sender, EventArgs e)
        {
            this.listView1.Focus();
        }

        private void textBoxHelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'h')
            {
                this.Showhelp(toggleShowingHelpNo);
            }
        }

        /*
         // 2015/08/01 不採用
         //  キー入力でpnlBottomを変更するようにする方針
        private void btnHide_Click(object sender, EventArgs e)
        {
            if ("↓".Equals(btnHide.Text))
            {
                btnHide.Text = "↑";
                pnlBottom.Height = 0;
                btnHide.BringToFront();
            }
            else
            {
                btnHide.Text = "↓";
                pnlBottom.Height = 70;
                btnHide.BringToFront();
            }
        }
         */

    }
}
