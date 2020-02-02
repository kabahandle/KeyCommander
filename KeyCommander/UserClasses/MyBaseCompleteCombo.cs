using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace KCommander.UserClasses
{
    public class MyBaseCompleteCombo : ComboBox, IMyCombo4Complete
    {
        private int lastSearchedIndex = 0;
        private string lastSearchedkey = string.Empty;
        private int previousIndex = 0;
        private bool onCompleting = false;

        private int lastSearchedIndexTAB = 0;
        private string lastSearchedkeyTAB = string.Empty;
        private int previousIndexTAB = 0;
        private bool isCompleteOnlyDirectory = true;
        public bool IsCompleteOnlyDirectory
        {
            get
            {
                return this.isCompleteOnlyDirectory;
            }
            set
            {
                this.isCompleteOnlyDirectory = value;
            }
        }

        public event Action OnCtrlHPress;
        public event Action OnCtrlBPress;

        private int currentPos = 0;
        private int lastSelectionStartTAB = 0;

        private string currentHeaderFlag = string.Empty;

        public delegate string PushDirPath();
        public event PushDirPath PassTheCurDir;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //SendKeys.SendWait("{RIGHT}");

            if ((win32api.GetAsyncKeyState(win32api.VK_CONTROL) & 0x8000) == 0x8000)
            {
                //if (e.KeyChar.Equals(' '))
                //{
                //    int index = 0;
                //    searchText(ref index);
                //    if (index == this.Items.Count)
                //    {
                //        lastSearchedIndex = 0;
                //        index = 0;
                //        searchText(ref index);
                //    }
                //    e.Handled = true;
                //    return;
                //}
            }
            else
            {
                lastSearchedIndex = 0;
                lastSearchedkey = this.Text;

                if (!((win32api.GetAsyncKeyState(win32api.VK_TAB) & 0x8000) == 0x8000))
                {
                    /*
                    lastSearchedIndexTAB = 0;
                    lastSearchedkeyTAB = this.Text;
                     */
                }
            }

            //this.SelectionStart = (( this.Text.Count() ) >= 0 ) ? ( this.Text.Count() ) : 0;
            //this.SelectionLength = 0;

            base.OnKeyPress(e);
        }

          // 文字の出現回数をカウント
        public int CountChar(string s, char c) 
        {
            return s.Length - s.Replace(c.ToString(), "").Length;
        }
        private int prevPos = 0;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            string text = this.Text;
            /*
            if (!string.IsNullOrEmpty(text))
            {
                if (text.StartsWith(";"))
                {
                    this.currentHeaderFlag = ";";
                    text = text.Substring(1);
                }
                else if (text.StartsWith("!"))
                {
                    this.currentHeaderFlag = "!";
                    text = text.Substring(1);
                }
                else
                {
                    this.currentHeaderFlag = string.Empty;
                }
            }
            */
            //if (e.Control && e.KeyChar.Equals(' '))
            if (e.Control && e.KeyValue == (int)Keys.R)
            {
                int index = 0;
                searchText(ref index);
                if (index == this.Items.Count)
                {
                    lastSearchedIndex = 0;
                    index = 0;
                    searchText(ref index);
                }
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyValue == (int)Keys.H)
            {
                if (this.OnCtrlHPress != null)
                {
                    this.OnCtrlHPress();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }
            if (e.Control && e.KeyValue == (int)Keys.B)
            {
                if (this.OnCtrlBPress != null)
                {
                    this.OnCtrlBPress();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }
            if (e.Alt && e.KeyValue == (int)Keys.Back)
            {
                this.Items.Remove(this.SelectedItem);
                this.Text = string.Empty;
                this.Save();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
            if (e.Alt && e.KeyValue == (int)Keys.Delete)
            {
                DialogResult ret = DialogResult.Cancel;
                ret = MessageBox.Show("本当に全履歴を消去しますか？", "確認", MessageBoxButtons.OKCancel);
                if (ret == DialogResult.OK)
                {
                    this.Items.Clear();
                    this.Text = string.Empty;
                    this.Save();
                    MessageBox.Show("クリアしました。");
                }
                else
                {
                    MessageBox.Show("キャンセルしました。");
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control && e.KeyValue == (int)Keys.E)
            {
                this.SelectionStart = this.Text.Length;
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
            //if (e.Control && e.KeyValue == (int)Keys.A)
            //{
            //    this.SelectionStart = 0;
            //    e.Handled = true;
            //    e.SuppressKeyPress = true;
            //    return;
            //}


            /*
            if (e.Control && e.KeyValue == (int)Keys.Delete)
            {
                this.Items.Remove(this.Text);
            }*/
            //if (e.Control && e.KeyValue == (int)Keys.R)
            if( e.Control 
                && ( e.KeyValue.Equals(' ') || e.KeyValue.Equals('　')))
            {
                int pos = this.SelectionStart;

                int start = this.SelectionStart;
                int len = this.SelectionLength;
                //if (this.SelectedText.StartsWith("\""))
                //{
                //    start = start - 1;
                //    len = len - 1;
                //}
                //if (this.SelectedText.EndsWith("\""))
                //{
                //    len = len - 1;
                //}

                //this.SelectedText = this.SelectedText.Replace("\"", "");
                //this.SelectionStart = start;
                //this.SelectionLength = len;

                //int pos = this.SelectionStart;
                int pos_bias = 0;
                //bool selWordEndsWithSpace = false;
                if (this.SelectionLength == 0)
                {
                    bool space_inline_mode = false;
                    string selWord = (string.IsNullOrEmpty(this.Text)) ? "" : this.Text.Substring(0, pos);
                    //if (this.Text.Count() > pos
                    //    && (this.Text.Substring(pos + 1, 1).EndsWith(" ") || this.Text.Substring(pos + 1, 1).EndsWith("　")))
                    //{
                    //    selWordEndsWithSpace = true;

                    //    //selWord = selWord.Substring(0, selWord.Length - 1);
                    //}
                    int cnt = 0;
                    char[] selWordsCharReverse = selWord.ToCharArray().Reverse<char>().ToArray<char>();
                    int cntSpaceMax = this.CountChar(selWord, ' ');
                    int cntSpace = 0;
                    foreach (char c in selWordsCharReverse)
                    {
                        pos_bias++;
                        cnt++;


                        if( '"'.Equals(c) /* && ( (cnt < selWordsCharReverse.Length ) && selWordsCharReverse[cnt] != '\\')*/ )
                        {
                            space_inline_mode = !space_inline_mode;
                            continue;
                        }
                        if (' '.Equals(c))
                        {
                            cntSpace++;

                            //if (cntSpace < cntSpaceMax)
                            //{
                            //    continue;
                            //}
                            //else 
                            if (space_inline_mode)
                            {
                                //break; 
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                    int tmpSelStert = pos - pos_bias + 1;
                    if (tmpSelStert <= 1) tmpSelStert = 0;
                    this.SelectionStart = tmpSelStert;
                    //this.SelectionLength = pos_bias;
                    this.SelectionLength = pos_bias - 1;
                    lastSearchedkeyTAB = this.HeaderingMarkSprit(this.SelectedText);
                    lastSelectionStartTAB = this.SelectionStart;

                    prevPos = pos;

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }

                if (pos - lastSelectionStartTAB >= 0)
                {
                    if (pos > 0 && ((this.SelectionStart - 1) > 0))
                    {
                        string prev1Text = this.Text.Substring(this.SelectionStart - 1, 1);

                        if (" ".Equals(prev1Text) || "　".Equals(prev1Text))
                        {

                            //
                            int lentmp = this.SelectionLength;
                            this.SelectionStart = lastSelectionStartTAB - 1;
                            //this.SelectionLength = pos - lastSelectionStartTAB + 1;
                            this.SelectionLength = lentmp + 1;

                            lastSearchedkeyTAB = this.HeaderingMarkSprit(this.SelectedText);
                            lastSelectionStartTAB = this.SelectionStart;

#if DEBUG
                            Console.WriteLine("extend keyTAB=" + lastSearchedkeyTAB);
                            Console.WriteLine("  selstart=" + this.SelectionStart.ToString());
                            Console.WriteLine("  sellen=" + this.SelectionLength.ToString());
                            Console.WriteLine("  pos=" + pos.ToString());
                            Console.WriteLine("  pos_bias=" + pos_bias.ToString());
                            Console.WriteLine("  lastTAB=" + lastSelectionStartTAB.ToString());
#endif

                            e.Handled = true;
                            e.SuppressKeyPress = true;
                            return;
                        }
                    }


                    bool space_inline_mode2 = false;
                    //string selWord = (string.IsNullOrEmpty(this.Text)) ? "" : this.Text.Substring(0, pos);
                    string selWord = this.SelectedText;
                    int cnt = 0;
                    bool isExistsSpace = false;
                    bool isFirstCompletion = true;
                    bool isFirstQuote = true;
                    char[] selWordsCharReverse = selWord.ToCharArray().Reverse<char>().ToArray<char>();
                    int spaceMaxCnt = this.CountChar(selWord, ' ') + this.CountChar(selWord, '　');
                    int spaceCnt = 0;
                    pos_bias = 0;
                    cnt = 0;
                    foreach (char c in selWordsCharReverse)
                    {
                        if ('"'.Equals(c) /* && ( (cnt < selWordsCharReverse.Length ) && selWordsCharReverse[cnt] != '\\')*/ )
                        {
                            //space_inline_mode2 = !space_inline_mode2;
                            if (isFirstQuote)
                            {
                                isFirstQuote = false;
                                space_inline_mode2 = true;
                            }
                            else
                            {
                                space_inline_mode2 = !space_inline_mode2;
                            }
                            continue;
                        }

                        if (' '.Equals(c) || "　".Equals(c.ToString()))
                        {
                            isExistsSpace = true;
                            //spaceCnt++;
                            //if (spaceCnt >= spaceMaxCnt - 1)
                            //{
                            //    break;
                            //}
                            if (space_inline_mode2)
                            {
                                //continue;
                                goto SKIP001;
                            }
                            else if (isFirstCompletion)
                            {
                                isFirstCompletion = false;
                                space_inline_mode2 = true;
                                //continue;
                                goto SKIP001;
                            }
                            else
                            {
                                break;
                            }
                        }
                    SKIP001:
                        pos_bias++;
                        cnt++;
                    }
                    start = this.SelectionStart;
                    int len_bias = 0;
                    int tmpSelStert = lastSelectionStartTAB;/* - pos_bias*/;
                    if (tmpSelStert <= 1)
                    {
                        tmpSelStert = 0;
                    }
//                    if (this.Text.Count() > start && start >= 2 && this.Text.Substring(start - 1, 1) == "\"")
//                    {
//                        start = this.SelectionStart;
//                        len = this.SelectionLength;
//                        this.Text = this.Text.Substring(0, start - 1) + this.Text.Substring(start + 1);
//                        //                       len_bias--;
//                        tmpSelStert = start - 1;
//                        this.SelectionStart = start - 1;
//                        this.SelectionLength = len;
//#if DEBUG
//                        Console.WriteLine("text=" + this.Text + ", tmpSelStart=" + tmpSelStert.ToString());
//#endif
//                    }
                    //if (lastSelectionIndexTAB < pos_bias)
                    if (isExistsSpace)
                    {
                        //tmpSelStert = pos_bias + 1;
                        if (lastSelectionStartTAB - 1 >= 0)
                        {
                            //tmpSelStert = lastSelectionStartTAB - 1;
                            //tmpSelStert = lastSelectionStartTAB - 1 - pos_bias;
                            tmpSelStert = pos - pos_bias;
                        }
                        len_bias = 1;
                    }
                    if (tmpSelStert <= 0)
                    {
                        //tmpSelStert = pos_bias - pos;
                        if (pos > 0)
                        {
                            tmpSelStert = pos - 1;
                        }
                        else
                        {
                            tmpSelStert = pos;
                        }
                    }
                    this.SelectionStart = tmpSelStert;
                    //this.SelectionLength += /*pos_bias +*/ len_bias;
                    this.SelectionLength += pos_bias + len_bias;
                    int lentmp2 = this.SelectionLength;
                    //this.SelectionStart = lastSelectionStartTAB;
                    //this.SelectionLength = pos - lastSelectionStartTAB;


                    lastSearchedkeyTAB = this.HeaderingMarkSprit(this.SelectedText);
                    lastSelectionStartTAB = this.SelectionStart;
                    //prevPos = pos;

#if DEBUG
                    Console.WriteLine("normal keyTAB=" + lastSearchedkeyTAB);
                    Console.WriteLine("  selstart=" + this.SelectionStart.ToString());
                    Console.WriteLine("  sellen=" + this.SelectionLength.ToString());
                    Console.WriteLine("  pos=" + pos.ToString());
                    Console.WriteLine("  pos_bias=" + pos_bias.ToString());
                    Console.WriteLine("  lastTAB=" + lastSelectionStartTAB.ToString());
#endif

                    start = this.SelectionStart;
                    len = this.SelectionLength;
                    if (this.SelectedText.Contains(" ") || this.SelectedText.Contains("　"))
                    {
                        int quotes_num = this.CountChar(this.SelectedText, '"');

                        this.SelectionStart = start;
                        this.SelectionLength = len;

                        this.SelectedText = this.SelectedText.Replace("\"", "");
                        len = len - quotes_num;

                        this.SelectionStart = start;
                        this.SelectionLength = len;

#if DEBUG
                        Console.WriteLine("space: selectedText="+this.SelectedText);
#endif

                        this.SelectedText = "\"" + this.SelectedText;
                        //start = start - 1;
                        len = len + 1;

                        this.SelectedText = this.SelectedText + "\"";
                        len = len + 1;

                        //this.SelectedText = this.SelectedText + " ";
                        //len = len /*+ 1*/;

                        this.SelectionStart = start;
                        this.SelectionLength = len;
                        lastSearchedkeyTAB = this.HeaderingMarkSprit(this.SelectedText/*.Replace("\"","")*/);
                        lastSelectionStartTAB = start;
                    }
                    //if (selWordEndsWithSpace)
                    //{
                    //    start = this.SelectionStart;
                    //    len = this.SelectionLength;
                    //    this.SelectedText = this.SelectedText + " ";
                    //    this.SelectionStart = start;
                    //    this.SelectionLength = len + 1;
                    //}
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }

            if (e.KeyCode == Keys.Tab)
            {
                /*
                if (this.SelectionStart == 0)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
                */

                if (this.SelectionLength == 0 && this.SelectionStart != 0)
                {
                    int pos = this.SelectionStart;
                    if (pos - lastSelectionStartTAB >= 0)
                    {
                        this.SelectionStart = lastSelectionStartTAB;
                        this.SelectionLength = pos - lastSelectionStartTAB;

                        lastSearchedkeyTAB = this.HeaderingMarkSprit(this.SelectedText);
                        lastSelectionStartTAB = this.SelectionStart;
                    }
                    //this.currentPos = this.SelectionStart + this.SelectionLength;
                    //this.SelectionLength = 0;
                    

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }

                List<string> targets = new List<string>();

                if (PassTheCurDir != null)
                {
                    string curListViewDir = PassTheCurDir();
                    string[] _curdirs = null;
                    string[] _curfiles = null;
                    string[] _cursubdirs = null;
                    string[] _cursubfiles = null;
                    List<string> curDirs = new List<string>();
                    List<string> curFiles = new List<string>();
                    List<string> curSubDirs = new List<string>();
                    List<string> curSubFiles = new List<string>();
                    if (!string.IsNullOrEmpty(curListViewDir))
                    {
                        try
                        {
                            _curdirs = Directory.GetDirectories(curListViewDir);
                            _curfiles = Directory.GetFiles(curListViewDir);
                            if (_curdirs != null && _curfiles != null)
                            {
                                foreach (string d in _curdirs)
                                {
                                    //curDirs.Add(Path.GetDirectoryName(d));
                                    curDirs.Add(Path.GetFileName(d));
                                }
                                foreach (string f in _curfiles)
                                {
                                    curFiles.Add(Path.GetFileName(f));
                                }
                            }
                        }
                        catch (Exception excp)
                        {
                        }
                        try
                        {
                            string basedir = string.Empty;
                            string searchFile = string.Empty;
                            System.IO.DirectoryInfo di = null;
                            System.IO.FileInfo[] aryFiles = null;
                            List<string> filepathes = new List<string>();

                            
                            if (!curListViewDir.EndsWith(@"\"))
                            {
                                if (System.IO.Directory.Exists(curListViewDir + @"\" + lastSearchedkeyTAB.Replace("\"", "")))
                                {
                                    basedir = curListViewDir + @"\" + lastSearchedkeyTAB.Replace("\"", "") + "\\";
                                    searchFile = "*";
                                }
                                else
                                {
                                    basedir = Path.GetDirectoryName(curListViewDir + @"\" + lastSearchedkeyTAB.Replace("\"", ""));
                                    searchFile = Path.GetFileName(curListViewDir + @"\" + lastSearchedkeyTAB.Replace("\"", "")) + "*";
                                }
                            }
                            else
                            {
                                if (System.IO.Directory.Exists(curListViewDir + lastSearchedkeyTAB.Replace("\"", "")))
                                {
                                    basedir = curListViewDir + lastSearchedkeyTAB.Replace("\"", "");
                                    searchFile = "*";
                                }
                                else
                                {
                                    basedir = Path.GetDirectoryName(curListViewDir + lastSearchedkeyTAB.Replace("\"", ""));
                                    searchFile = Path.GetFileName(curListViewDir + lastSearchedkeyTAB.Replace("\"", "")) + "*";
                                }
                            }

                            if (basedir.EndsWith(@"\"))
                            {
                                //_cursubdirs = Directory.GetDirectories(curListViewDir + @"\" + lastSearchedkeyTAB);
                                //_cursubfiles = Directory.GetFiles(curListViewDir + @"\" + lastSearchedkeyTAB);
                                _cursubdirs = Directory.GetDirectories(basedir, searchFile);

                                //"C:\test"以下の".txt"ファイルをすべて取得する
                                //di = new System.IO.DirectoryInfo(basedir);
                                //aryFiles = di.GetFiles(lastSearchedkeyTAB.Replace("\"", "").Replace(basedir, "") + "*", System.IO.SearchOption.TopDirectoryOnly);
                                //foreach (System.IO.FileInfo f in aryFiles)
                                //{
                                //    filepathes.Add(f.FullName);
                                //}
                                //_curfiles = filepathes.ToArray<string>();
                                //_curfiles = Directory.GetFiles(basedir, searchFile);
                                //_cursubfiles = Directory.GetFiles(basedir,lastSearchedkeyTAB.Replace("\"", "") + "*");
                                _cursubfiles = Directory.GetFiles(basedir, searchFile);
                            }
                            else
                            {
                                //_cursubdirs = Directory.GetDirectories(curListViewDir + lastSearchedkeyTAB.Replace("\"", ""));
                                //_cursubfiles = Directory.GetFiles(curListViewDir + lastSearchedkeyTAB.Replace("\"", ""));

                                _cursubdirs = Directory.GetDirectories(basedir, searchFile);
                                //_cursubdirs = Directory.GetDirectories(curListViewDir, "*");

                                //_cursubfiles = Directory.GetFiles(basedir + "\\" , lastSearchedkeyTAB.Replace("\"", "") + "*");
                                //di = new System.IO.DirectoryInfo(basedir);
                                //aryFiles = di.GetFiles(lastSearchedkeyTAB.Replace("\"", "").Replace(basedir, "") + "*", System.IO.SearchOption.TopDirectoryOnly);
                                //aryFiles = di.GetFiles(searchFile, System.IO.SearchOption.TopDirectoryOnly);
                                //foreach (System.IO.FileInfo f in aryFiles)
                                //{
                                //    filepathes.Add(f.FullName);
                                //}
                                //_curfiles = filepathes.ToArray<string>();
                                _cursubfiles = Directory.GetFiles(basedir, searchFile);
                            }

                            string drv = basedir.Substring(0, 3);
                            string basedir2 = basedir.Replace(drv, "");
                            if (_cursubdirs != null)
                            {
                                foreach (string d in _cursubdirs)
                                {
                                    curSubDirs.Add(Path.GetDirectoryName(d));
                                    curSubDirs.Add(d.Replace(drv, ""));
                                    curSubDirs.Add(d.Replace(curListViewDir + "\\", ""));
                                    curSubDirs.Add(d);
                                    //curSubDirs.Add(lastSearchedkeyTAB.Replace("\"", "") + Path.GetFileName(d));
                                }
                            }
                            if (_cursubfiles != null)
                            {
                                foreach (string f in _cursubfiles)
                                {
                                    //curSubFiles.Add(lastSearchedkeyTAB.Replace("\"", "") + Path.GetFileName(f));
                                    if (basedir.EndsWith("\\"))
                                    {
                                        curSubFiles.Add((basedir + Path.GetFileName(f)).Replace(curListViewDir + "\\", ""));
                                        curSubFiles.Add(basedir2 + Path.GetFileName(f));
                                        //curSubFiles.Add(basedir2 + Path.GetFileName(f));
                                    }
                                    else
                                    {
                                        curSubFiles.Add((basedir2 + "\\" + Path.GetFileName(f)).Replace(curListViewDir + "\\", ""));
                                        curSubFiles.Add(basedir2 + "\\" + Path.GetFileName(f));
                                    }
                                }
                            }
                        }
                        catch (Exception excp)
                        {
                        }
                        if (curSubDirs != null)
                        {
                            targets.AddRange(curSubDirs);
                        }
                        if (curSubFiles != null)
                        {
                            targets.AddRange(curSubFiles);
                        }
                        //if (_cursubdirs != null)
                        //{
                        //    targets.AddRange(_cursubdirs);
                        //}
                        //if (_cursubfiles != null)
                        //{
                        //    targets.AddRange(_cursubfiles);
                        //}

                    }

                    if (curDirs != null && curFiles != null)
                    {
                        targets.AddRange(curDirs);
                        targets.AddRange(curFiles);
                    }
                }

                string dir = string.Empty;
                try
                {
                    dir = Path.GetDirectoryName(lastSearchedkeyTAB.Replace("\"", ""));

                    // "c:\\"の場合、dirが""になってしまう↑のを改修
                    try
                    {
                        if (string.IsNullOrEmpty(dir))
                        {
                            Regex reg = new Regex(@"^([a-zA-Z]:\\?).*$");
                            Match m = reg.Match(lastSearchedkeyTAB.Replace("\"", ""));
                            if (m.Groups.Count > 0)
                            {
                                if (m.Groups[0].Value.Length > 0)
                                {
                                    dir = m.Groups[0].Value;
                                    if (!string.IsNullOrEmpty(dir)
                                        && !dir.EndsWith(@"\"))
                                    {
                                        dir = dir + @"\";
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }
                catch (Exception ex)
                {
                    return;
                }
                string[] files = null;
                string[] dirs = null;
                if (!string.IsNullOrEmpty(dir))
                {
                    try
                    {
                        files = Directory.GetFiles(dir);
                        dirs = Directory.GetDirectories(dir);
                    }
                    catch (Exception ex)
                    {
                        //2015/07/14
                        //return;
                    }
                }
                if ((files == null || dirs == null)
                    && targets.Count == 0)
                {
                    return;
                }
                else if( files != null && dirs != null )
                {
                    if (isCompleteOnlyDirectory)
                    {
                        targets.AddRange(dirs);
                    }
                    else
                    {
                        targets.AddRange(dirs);
                        targets.AddRange(files);
                    }
                }
                int index = 0;
                searchDir(ref index, ref targets);
                if (index == targets.Count())
                {
                    lastSearchedIndexTAB = 0;
                    index = 0;
                    searchDir(ref index, ref targets);
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.Control && e.KeyCode == Keys.Left)
            {
                //MessageBox.Show("A");
                /*
                this.SelectLeftSideUnit();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
                 */
            }

            /*
            if (e.Control && e.KeyValue == (int)Keys.R)
            {
                int pos = this.SelectionStart;
                if (pos - lastSelectionStartTAB >= 0)
                {
                    this.SelectionStart = lastSelectionStartTAB;
                    this.SelectionLength = pos - lastSelectionStartTAB;

                    lastSearchedkeyTAB = this.HeaderingMarkSprit(this.SelectedText);
                    lastSelectionStartTAB = this.SelectionStart;
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
             */

            if (e.Control && e.KeyCode == Keys.Up)
            {
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.Down)
            {
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                return;
            }

            if (this.SelectionLength > 0 )
            {
                switch (e.KeyCode)
                {
                    /*
                case Keys.A:
case Keys.B:
case Keys.C:
case Keys.D:
case Keys.E:
case Keys.F:
case Keys.G:
case Keys.H:
case Keys.I:
case Keys.J:
case Keys.K:
case Keys.L:
case Keys.M:
case Keys.N:
case Keys.O:
case Keys.P:
case Keys.Q:
case Keys.R:
case Keys.S:
case Keys.T:
case Keys.U:
case Keys.V:
case Keys.W:
case Keys.X:
case Keys.Y:
case Keys.Z:
case Keys.D0:
case Keys.D1:
case Keys.D2:
case Keys.D3:
case Keys.D4:
case Keys.D5:
case Keys.D6:
case Keys.D7:
case Keys.D8:
case Keys.D9:*/
                    case Keys.Alt:
                    case Keys.Apps:
                    case Keys.Back:
                    case Keys.Cancel:
                    case Keys.Capital:
                    //case Keys.CapsLock:
                    case Keys.Clear:
                    case Keys.Control:
                    case Keys.ControlKey:
                    case Keys.Crsel:
                    case Keys.Delete:
                    case Keys.Down:
                    case Keys.End:
                    case Keys.Enter:
                    case Keys.Escape:
                    case Keys.Execute:
                    case Keys.Exsel:
                    case Keys.F1:
                    case Keys.F10:
                    case Keys.F11:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:
                    case Keys.Home:
                    case Keys.Insert:
                    case Keys.LControlKey:
                    case Keys.Left:
                    case Keys.LineFeed:
                    case Keys.LMenu:
                    case Keys.LShiftKey:
                    case Keys.LWin:
                    case Keys.NumLock:
                    case Keys.NumPad0:
                    case Keys.NumPad1:
                    case Keys.NumPad2:
                    case Keys.NumPad3:
                    case Keys.NumPad4:
                    case Keys.NumPad5:
                    case Keys.NumPad6:
                    case Keys.NumPad7:
                    case Keys.NumPad8:
                    case Keys.NumPad9:
                    case Keys.PageDown:
                    case Keys.PageUp:
                    case Keys.Pause:
                    case Keys.Print:
                    case Keys.PrintScreen:
                    case Keys.RButton:
                    case Keys.RControlKey:
                    //case Keys.Return:
                    case Keys.Right:
                    case Keys.RMenu:
                    case Keys.RShiftKey:
                    case Keys.RWin:
                    case Keys.Scroll:
                    case Keys.Shift:
                    case Keys.ShiftKey:
                        break;
                        /*
                    case Keys.OemBackslash:
                    case Keys.Divide:
                        this.SelectionStart = this.SelectionStart + this.SelectionLength + 1;
                        this.SelectionLength = 0;
                        break;*/
                    default:
#if DEBUG
                        Console.WriteLine("normal key input selection="+this.SelectedText);
#endif
                        //this.SelectionStart = this.SelectionStart + this.SelectionLength + 1;
                        this.SelectionStart = this.SelectionStart + this.SelectionLength;
                        this.SelectionLength = 0;
                        //this.SelectionLength++;
                        break;
                }
                if (e.KeyCode == Keys.Delete)   // Keys.Backと同等
                {
                    //e.KeyCode = Keys.Back;
                    this.SelectedText = string.Empty;
                }

            }



            lastSearchedIndexTAB = 0;
            lastSearchedkeyTAB = text;// this.Text;

            
            
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (( e.Control && e.KeyCode == Keys.Left)
                || (e.Control && e.KeyCode == Keys.Right )
                || (e.Shift && e.KeyCode == Keys.Left )
                || (e.Shift && e.KeyCode == Keys.Right )
                )
            {
                lastSearchedkeyTAB = this.HeaderingMarkSprit(this.SelectedText);
                lastSelectionStartTAB = this.SelectionStart;
            }
            /*
             // OnKeyDownへ移行 2015/08/01
            if (e.Control && e.KeyValue == (int)Keys.R)
            {
                int pos = this.SelectionStart;
                if (pos - lastSelectionStartTAB >= 0)
                {
                    this.SelectionStart = lastSelectionStartTAB;
                    this.SelectionLength = pos - lastSelectionStartTAB;
                    lastSearchedkeyTAB = this.SelectedText;
                    lastSelectionStartTAB = this.SelectionStart;
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
             */


            base.OnKeyUp(e);
        }

        /*
        private void SelectLeftSideUnit()
        {
            int curPos = currentPos;
            if (this.Text.Length >= curPos)
            {
                string leftSideText = this.Text.Substring(0, curPos);
                int spacePos = curPos;
                int initPos = spacePos;
                bool isFirst = true;
                foreach (char ch in leftSideText.Reverse())
                {
                    if (isFirst && ch == ' ')
                    {
                        spacePos--;
                        continue;
                    }
                    else if (ch == ' ')
                    {
                        break;
                    }
                    isFirst = false;
                    spacePos--;
                }
                if (spacePos >= 0 && curPos - spacePos >= 0)
                {
                    this.SelectionStart = spacePos;
                    this.SelectionLength = curPos - spacePos;
                }
            }
        }
        */

        protected override bool IsInputKey(Keys keyData)
        {
            //TABキーが押されているか確認する
            if (keyData == Keys.Tab)
            {
                /*
                string dir = Path.GetDirectoryName(lastSearchedkeyTAB);
                if (string.IsNullOrEmpty(dir))
                {
                    return true;
                }
                string[] files = Directory.GetFiles(dir);
                string[] dirs = Directory.GetDirectories(dir);
                int index = 0;
                List<string> targets = new List<string>();
                if (isCompleteOnlyDirectory)
                {
                    targets.AddRange(dirs);
                }
                else
                {
                    targets.AddRange(dirs);
                    targets.AddRange(files);
                }
                searchDir(ref index, ref targets);
                if (index == targets.Count())
                {
                    lastSearchedIndexTAB = 0;
                    index = 0;
                    searchDir(ref index, ref targets);
                }
                 */
                return true;
            }
            return base.IsInputKey(keyData);
        }
        private void searchText(ref int index)
        {
            foreach (object obj in this.Items)
            {
                string line = obj.ToString();
                if (!string.IsNullOrEmpty(line))
                {
                    index++;
                    if (index <= lastSearchedIndex)
                    {
                        continue;
                    }
                    if (line.ToLower().StartsWith(lastSearchedkey.ToLower()))
                    {
                        onCompleting = true;
                        this.Text = line;
                        this.SelectionStart = this.Text.Length;
                        lastSearchedIndex = index;
                        onCompleting = false;
                        break;
                    }
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (onCompleting)
            {
                return;
            }

            string text = this.HeaderingMarkSprit(this.Text);
            /*
            if (!string.IsNullOrEmpty(text))
            {
                if (text.StartsWith(";"))
                {
                    this.currentHeaderFlag = ";";
                    text = text.Substring(1);
                }
                else if (text.StartsWith("!"))
                {
                    this.currentHeaderFlag = "!";
                    text = text.Substring(1);
                }
                else
                {
                    this.currentHeaderFlag = string.Empty;
                }
            }
            */

            lastSearchedkey = text;
            lastSearchedkeyTAB = text;
            currentPos = this.SelectionStart;

            base.OnTextChanged(e);
        }
        protected string HeaderingMarkSprit(string srcText)
        {
            string text = srcText;
            if (!string.IsNullOrEmpty(text))
            {
                if (text.StartsWith(";"))
                {
                    this.currentHeaderFlag = ";";
                    //this.currentHeaderFlag = string.Empty;
                }
                else if (text.StartsWith("!"))
                {
                    this.currentHeaderFlag = "!";
                    text = text.Substring(1);
                }
                else
                {
                    this.currentHeaderFlag = string.Empty;
                    //this.currentHeaderFlag = ";";
                    //text = text.Substring(1);
                }
            }
            else
            {
                return string.Empty;
            }
            return text;
        }

        enum FileSystemType
        {
            FILE,
            DIR,
            NONE
        }

        private FileSystemType FigureOutIsFileOrDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return FileSystemType.DIR;
            }
            else if (File.Exists(path))
            {
                return FileSystemType.FILE;
            }
            else
            {
                return FileSystemType.NONE;
            }
        }

        private void searchDir(ref int index, ref List<string> files )
        {
            foreach (string file in files)
            {
                string fullpath = lastSearchedkeyTAB.Replace("\"","") + @"\" + file;
                FileSystemType type = FigureOutIsFileOrDirectory(file);

                //string file2 = file;
                //bool file2_has_yen_at_end = false;
                //if (file2.EndsWith("\\"))
                //{
                //    file2_has_yen_at_end = true;
                //    file2.Substring(0, file.Length - 1);
                //}

                string file2 = file;
                file2 = file2.Replace("\\\\", "\\");

                if (!string.IsNullOrEmpty(file))
                {
                    index++;
                    if (index <= lastSearchedIndexTAB)
                    {
                        continue;
                    }
                    if (file2.ToLower().StartsWith(lastSearchedkeyTAB.Replace("\"","").ToLower())
                        /*|| (file2 + "\\").ToLower().StartsWith(lastSearchedkeyTAB.Replace("\"","").ToLower())*/ )
                    {
                        //if (file2_has_yen_at_end)
                        //{
                        //    file2 = file2 + "\\";
                        //}
                        //if (lastSearchedkeyTAB.EndsWith("\\"))
                        //{
                        //    file2 = file2 + "\\";
                        //}

                        //if (lastSearchedkeyTAB.Contains(" ") || lastSearchedkeyTAB.Contains("　"))
                        if (file2.Contains(" ") || file2.Contains("　"))
                        {
                            file2 = "\"" + file2 + "\"";
                            lastSearchedkeyTAB = "\"" + lastSearchedkeyTAB + "\"";
                        }
                        onCompleting = true;
                        if (this.SelectedText.Length != 0)
                        {
                            int selStart = this.SelectionStart;
                            this.SelectedText = this.currentHeaderFlag + file2;
                            this.SelectionStart = selStart;
                            this.SelectionLength = file2.Length + this.currentHeaderFlag.Length;
                        }
                        else
                        {
                            this.Text = this.currentHeaderFlag + file2;
                            this.SelectionStart = this.Text.Length;
                        }
//                        if (this.SelectedText.Contains(" ") || this.SelectedText.Contains("　"))
//                        {
//                            int start = 0;
//                            int len = 0;
//                            int quotes_num = this.CountChar(this.SelectedText, '"');

//                            this.SelectionStart = start;
//                            this.SelectionLength = len;

//                            this.SelectedText = this.SelectedText.Replace("\"", "");
//                            len = len - quotes_num;

//                            this.SelectionStart = start;
//                            this.SelectionLength = len;

//#if DEBUG
//                            Console.WriteLine("space: selectedText=" + this.SelectedText);
//#endif

//                            this.SelectedText = "\"" + this.SelectedText;
//                            //start = start - 1;
//                            len = len + 1;

//                            this.SelectedText = this.SelectedText + "\"";
//                            len = len + 1;

//                            //this.SelectedText = this.SelectedText + " ";
//                            //len = len /*+ 1*/;

//                            this.SelectionStart = start;
//                            this.SelectionLength = len;
//                            lastSearchedkeyTAB = this.HeaderingMarkSprit(this.SelectedText/*.Replace("\"","")*/);
//                            lastSelectionStartTAB = start;
//                        }
                        lastSearchedIndexTAB = index;
                        onCompleting = false;
                        break;
                    }
                }
            }
        }

        /*
        private string StripDir(string line)
        {
            StringBuilder ret = new StringBuilder();
            bool isStringMode = false;
            foreach (char c in line.Reverse<char>())
            {
                if (c == '\"')
                {
                    isStringMode = !isStringMode;
                }

                if (c == ' ')
                {
                    if (isStringMode)
                    {
                        ret.Append(c);
                    }
                    else
                    {
                        string rev =  ret.ToString();
                        string 
                    }
                }
            }
        }
        */

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual void Load()
        {
            throw new NotImplementedException();
        }
    }
}
