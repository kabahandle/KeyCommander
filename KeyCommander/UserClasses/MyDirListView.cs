using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Collections;
using KeyCommander.UserClasses;

namespace KCommander.UserClasses
{
    public class MyDirListView : ListView
    {
        private static MyDirListView focused = null;
        public static MyDirListView Focused
        {
            get
            {
                return MyDirListView.focused;
            }
            set
            {
                MyDirListView.focused = value;
            }
        }

        private static readonly int NUM_FILENAME_COLUMN = 2;
        private static readonly int NUM_FILEEXT_COLUMN = 3;
        private static readonly int NUM_FILESIZE_COLUMN = 4;

        private bool isControl = false;

        private System.Windows.Forms.ColumnHeader Head = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader Flag = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader FileName = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader Ext = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader FileSize = new ColumnHeader();
        private System.Windows.Forms.ColumnHeader Updated = new ColumnHeader();

        private readonly string dirMark = "<DIR>";
        private List<string> tmpListFiles = null;
        private readonly string strgDetail = "DETAIL";
        private readonly string strgSmallIcon = "SMALLICON";

        public event Action OnRPress;
        public event Action<string> OnChangeCurDir;
        public event Action OnDoneMenu;
        public event Action OnTPress;
        public event Action OnWPress;
        public event Action OnCPress;
        public event Action OnHPress;
        public event Action OnBPress;
        public event Action<MyDirListView> OnXPress;

        private bool toggleIsSelectAll = true;
        private string curDir = "";
        public string CurDir
        {
            get
            {
                return this.curDir;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(value);
                this.curDir = dir.FullName;

                if (this.OnChangeCurDir != null)
                {
                    this.OnChangeCurDir(this.curDir);
                }
            }

        }

        public string TargetDir
        {
            get;
            set;
        }

        public MyDirListView()
            : base()
        {
            // 
            // Head
            // 
            this.Head.Text = "へっだー";
            this.Head.Width = 0;
            // 
            // Flag
            // 
            this.Flag.Text = "フラグ";
            this.Flag.Width = 36;
            // 
            // FileName
            // 
            this.FileName.Text = "ファイル名";
            this.FileName.Width = 160;
            // 
            // Ext
            // 
            this.Ext.Text = "拡張子";
            this.Ext.Width = 50;
            // 
            // FileSize
            // 
            this.FileSize.Text = "サイズ";
            this.FileSize.Width = 50;
            // 
            // Updated
            // 
            this.FileSize.Text = "更新日時";
            this.FileSize.Width = 200;

            this.ColumnClick += DoColumnClick;

            this.FullRowSelect = true;
            this.HideSelection = false;
            this.MultiSelect = false;
            this.TabIndex = 0;
            this.UseCompatibleStateImageBehavior = false;
            this.View = System.Windows.Forms.View.Details;

            this.CurDir = "";

            //イベント
            this.KeyPress += this.MyItem4FileListView_KeyPress;
            this.KeyDown += this.MyItem4FileListView_KeyDown;
            this.MouseDoubleClick += this.MyItem4FileListView_MouseDoubleClick;
            this.MouseClick += this.MyItem4FileList_MouseClick;
        }

        static int oldCol = -1;
        static bool oldAsc = false;
        public void DoColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            bool isAsc = true;
            if (oldCol != e.Column)
            {
                oldCol = e.Column;
                isAsc = true;
                oldAsc = true;
            }
            else
            {
                isAsc = !oldAsc;
                oldAsc = isAsc;
            }
            //MessageBox.Show(e.Column.ToString()+" "+isAsc.ToString());

            MyColumnComparer colcmp = new MyColumnComparer(e.Column, isAsc);
            this.ListViewItemSorter = colcmp;
            this.Sort();
        }
        class MyColumnComparer : IComparer
        {
            private int colNum = 0;
            private bool isAsc = false;

            public MyColumnComparer(int colNum, bool isAsc)
            {
                this.colNum = colNum;
                this.isAsc = isAsc;
            }
            public int Compare(object a, object b)
            {
                ListViewItem l1 = a as ListViewItem;
                ListViewItem l2 = b as ListViewItem;
                if (l1 == null | l2 == null) return 0;

                //if( l1.SubItems.Count < this.colNum+1 || l2.SubItems.Count < this.colNum +1 ) return 0;

                if (this.colNum == MyDirListView.NUM_FILESIZE_COLUMN)
                {
                    int i1 = 0;
                    int i2 = 0;
                    int.TryParse(l1.SubItems[this.colNum].Text, out i1 );
                    int.TryParse(l2.SubItems[this.colNum].Text, out i2 );
                    return this.InnerCompare<int>(i1, i2,
                     l1.SubItems[MyDirListView.NUM_FILEEXT_COLUMN].Text, this.colNum, this.isAsc);
                    /*
                    if (this.isAsc)
                    {
                        return i1.CompareTo(i2);
                    }
                    else
                    {
                        return i2.CompareTo(i1);
                    }*/
                }
                if (this.colNum == MyDirListView.NUM_FILEEXT_COLUMN)
                {
                    return this.InnerCompare<string>(l1.SubItems[this.colNum].Text, l2.SubItems[this.colNum].Text,
                        l1.SubItems[MyDirListView.NUM_FILEEXT_COLUMN].Text, this.colNum, this.isAsc);
                    /*
                    if (this.isAsc)
                    {
                        int ret1 = l1.SubItems[this.colNum].Text.ToLower().CompareTo("<dir>");
                        if (!string.IsNullOrEmpty(l1.SubItems[this.colNum].Text) && ret1 == 0)
                        {
                            return ret1;
                        }
                        else
                        {
                            return l1.SubItems[this.colNum].Text.CompareTo(l2.SubItems[this.colNum].Text);
                        }
                    }
                    else
                    {
                        int ret2 = l1.SubItems[this.colNum].Text.ToLower().CompareTo("<dir>");
                        if (!string.IsNullOrEmpty(l1.SubItems[this.colNum].Text) && ret2 == 0)
                        {
                            return ret2;
                        }
                        else
                        {
                            return l2.SubItems[this.colNum].Text.CompareTo(l1.SubItems[this.colNum].Text);
                        }

                    }
                     */
                }
                if (this.colNum == MyDirListView.NUM_FILENAME_COLUMN)
                {
                    return this.InnerCompare<string>(l1.SubItems[this.colNum].Text, l2.SubItems[this.colNum].Text,
                                l1.SubItems[MyDirListView.NUM_FILEEXT_COLUMN].Text, this.colNum, this.isAsc);
                    
                    /*
                    if (this.isAsc)
                    {
                        int ret1 = l1.SubItems[MyDirListView.NUM_FILEEXT_COLUMN].Text.ToLower().CompareTo("<dir>");
                        if (!string.IsNullOrEmpty(l1.SubItems[MyDirListView.NUM_FILEEXT_COLUMN].Text) && ret1 == 0)
                        {
                            return ret1;
                        }
                        else
                        {
                            return l1.SubItems[this.colNum].Text.CompareTo(l2.SubItems[this.colNum].Text);
                        }
                    }
                    else
                    {
                        int ret2 = l1.SubItems[MyDirListView.NUM_FILEEXT_COLUMN].Text.ToLower().CompareTo("<dir>");
                        if (!string.IsNullOrEmpty(l1.SubItems[MyDirListView.NUM_FILEEXT_COLUMN].Text) && ret2 == 0)
                        {
                            return ret2;
                        }
                        else
                        {
                            return l2.SubItems[this.colNum].Text.CompareTo(l1.SubItems[this.colNum].Text);
                        }
                    }
                     */
                }

                return this.InnerCompare<string>(l1.SubItems[this.colNum].Text, l2.SubItems[this.colNum].Text,
                        l1.SubItems[MyDirListView.NUM_FILEEXT_COLUMN].Text, this.colNum, this.isAsc);
                /*
                if (this.isAsc)
                {
                    //int ret1 = l1.SubItems[this.colNum].Text.ToLower().CompareTo("<dir>");
                    return l1.SubItems[this.colNum].Text.CompareTo(l2.SubItems[this.colNum].Text);                    
                }
                else
                {
                    return l2.SubItems[this.colNum].Text.CompareTo(l1.SubItems[this.colNum].Text);
                }
                */

            }

            private int InnerCompare<T>(T varX, T varY, string dirColVal, int colNum, bool isAsc)
                where T : IComparable
            {
                if (this.isAsc)
                {
                    int ret1 = dirColVal.ToLower().CompareTo("<dir>");
                    if (!string.IsNullOrEmpty(dirColVal) && ret1 == 0)
                    {
                        return ret1;
                    }
                    else
                    {
                        return varX.CompareTo(varY);
                    }
                }
                else
                {
                    int ret2 = dirColVal.ToLower().CompareTo("<dir>");
                    if (!string.IsNullOrEmpty(dirColVal) && ret2 == 0)
                    {
                        return ret2;
                    }
                    else
                    {
                        return varY.CompareTo(varX);
                    }
                }
            }
        }

        private void MyItem4FileList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                MouseRightClickMenu mm = new MouseRightClickMenu(this.MyItem4FileListView_KeyPress);
                //fm.DoneMenu += DoneMenu;
                this.ContextMenuStrip = mm;
                Point p = System.Windows.Forms.Cursor.Position;

                this.ContextMenuStrip.Show(p.X, p.Y);
            }
        }

        public void Open()
        {
            if( string.IsNullOrEmpty( this.CurDir ) )
            {
                return;
            }
            this.Open(this.CurDir);
        }

        public void Open( string dirText )
        {
            try
            {
                string prevDir = this.CurDir;
                int prev_line = 0;
                if (prevDir != null && prevDir.Equals(dirText))
                {
                    foreach (ListViewItem item in this.Items)
                    {
                        if (item != null && item.Equals(this.FocusedItem))
                        {
                            break;
                        }
                        prev_line++;
                    }
                }
                if (prev_line >= this.Items.Count)
                {
                    prev_line = 0;
                }

                if (!Directory.Exists(dirText))
                {
                    return;
                }

                this.CurDir = dirText;

                //ParentDIR
                this.Items.Clear();
                this.Items.Add(new MyItem4FileListView("..", this.dirMark, "0", this.CurDir, this.CurDir + @"\..", "", 0));

                //DIR
                string[] files = Directory.GetDirectories(dirText);
                FileHelper fh = FileHelper.GetInstance();
                foreach (string fullpath in files)
                {
                    string filename = fh.getFileName(fullpath);
                    string ext = "";

                    if (filename != null && filename.IndexOf('.') > 0)
                    {
                        ext = fh.getExt(filename);
                    }

                    // FileInfo の新しいインスタンスを生成する
                    System.IO.FileInfo cFileInfo = new System.IO.FileInfo(fullpath);

                    MyItem4FileListView item = new MyItem4FileListView(filename, this.dirMark, "0", dirText, fullpath, cFileInfo.LastWriteTime.ToShortDateString() + " " + cFileInfo.LastWriteTime.ToShortTimeString(), 0);
                    this.Items.Add(item);
                }

                //FILE
                files = Directory.GetFiles(dirText);
                foreach (string fullpath in files)
                {
                    string filename = fh.getFileName(fullpath);
                    string ext = "";
                    if (filename != null && filename.IndexOf('.') > 0)
                    {
                        ext = fh.getExt(filename);
                    }

                    // FileInfo の新しいインスタンスを生成する
                    System.IO.FileInfo cFileInfo = new System.IO.FileInfo(fullpath);


                    MyItem4FileListView item = new MyItem4FileListView(filename, ext, cFileInfo.Length.ToString(), dirText, fullpath, cFileInfo.LastWriteTime.ToShortDateString() + " " + cFileInfo.LastWriteTime.ToShortTimeString(), 1);
                    this.Items.Add(item);
                }

                if (this.Items.Count > 0)
                {
                    string prevFileName = Path.GetFileName(prevDir).Trim();
                    string curdir = this.curDir;
                    if (!curdir.EndsWith("\\"))
                    {
                        curdir += "\\";
                    }
                    //if (prevrDir != null && prevDir.Equals(this.CurDir))
                    //if (this.CurDir != null && CurDir.Equals(prevDir))
                    if (prevDir != null && prevDir.Equals(curdir + prevFileName))
                    {
                        //if (prev_line > Items.Count)
                        //{
                        //    prev_line = Items.Count - 1;
                        //}

                        //this.Items[prev_line].Focused = true;
                        //this.Items[prev_line].Selected = true;
                        //this.Items[prev_line].EnsureVisible();

                        int prev_line2 = 0;
                        foreach (ListViewItem item in this.Items)
                        {
                            if (item != null && item.Text.Equals(prevFileName))
                            {
                                break;
                            }
                            prev_line2++;
                        }
                        
                        if (prev_line2 > Items.Count)
                        {
                            prev_line2 = Items.Count - 1;
                        }

                        if (this.Items.Count > prev_line2)
                        {
                            this.Items[prev_line2].Focused = true;
                            this.Items[prev_line2].Selected = true;
                            this.Items[prev_line2].EnsureVisible();
                        }

                    }
                    else
                    {
                        this.Items[0].Focused = true;
                        this.Items[0].Selected = true;
                        this.Items[0].EnsureVisible();
                    }
                }

                TabPage tab = this.Parent as TabPage;
                if (tab != null)
                {
                    tab.Text = this.CurDir;
                    if (this.OnChangeCurDir != null)
                    {
                        this.OnChangeCurDir(this.CurDir);
                    }
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "エラー");
            }

        }

        public int FilenameCompare(MyItem4FileListView x, MyItem4FileListView y)
        {
            if (x == null)
            {
                return 1;
            }
            if (y == null)
            {
                return -1;
            }
            if (x.FileName == null)
            {
                return 1;
            }
            if (y.FileName == null)
            {
                return -1;
            }
            return x.FileName.CompareTo(y.FileName);
        }

        private string lastSearchedKey = string.Empty;
        private int lastSearchedIndex = 0;

        private void SearchFilenameByKey(string key)
        {
            /*
            List<MyItem4FileListView> list = new List<MyItem4FileListView>();
            foreach( var item in this.Items )
            {
                MyItem4FileListView fitem = item as MyItem4FileListView;
                if (fitem != null)
                {
                    list.Add(fitem);
                }
            }
            list.Sort(FilenameCompare);
             */
            int index = 0;
            if (!lastSearchedKey.Equals(key))
            {
                lastSearchedIndex = 0;
            }
            lastSearchedKey = key;
            foreach (var item in this.Items)
            {
                index++;
                if (index <= lastSearchedIndex)
                {
                    continue;
                }
                MyItem4FileListView fitem = item as MyItem4FileListView;
                if (fitem == null)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(fitem.FileName))
                {
                    if (fitem.FileName.StartsWith(key))
                    {
                        //this.SelectedItems.Clear();
                        fitem.Focused = true;
                        fitem.Selected = true;
                        fitem.EnsureVisible();
                        lastSearchedIndex = index;
                        return;
                    }
                }
            }
        }
        private void MyItem4FileListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            // メニュー出現位置（デフォルト：マウスカーソル）
            Point p = System.Windows.Forms.Cursor.Position;

            // メニュー出現位置（ListViewItemの位置へ補正）
            ListViewItem boundsitem = null;
            //if (this.SelectedItems.Count > 0)
            {
                //boundsitem = this.SelectedItems[0];
                boundsitem = this.FocusedItem;
                if (boundsitem != null)
                {
                    int xf = (int)(boundsitem.Bounds.X + ((int)(boundsitem.Bounds.Width / 2)));
                    int yf = boundsitem.Bounds.Y + boundsitem.Bounds.Height;
                    p = this.PointToScreen(new Point(xf, yf));
                }
            }

            List<string> files = null;

            if ((win32api.GetAsyncKeyState(win32api.VK_SHIFT)& 0x8000) == 0x8000)
            {
                string key = e.KeyChar.ToString();
                if( string.IsNullOrEmpty(key) )
                {
                    return;
                }
                this.SearchFilenameByKey(key);
                return;
            }

            switch (e.KeyChar.ToString().ToUpper())
            {
                case " ":
                case "　":
                    if (this.SelectedItems.Count > 0)
                    {
                        MyItem4FileListView item = this.SelectedItems[0] as MyItem4FileListView;
                        if (item != null)
                        {
                            if (string.IsNullOrEmpty(item.Flag))
                            {
                                item.Flag = "*";
                            }
                            else
                            {
                                item.Flag = "";
                            }
                            if ((this.SelectedItems.Count > 0)
                                && (this.SelectedIndices[0] + 1 < this.Items.Count))
                            {
                                this.Items[this.SelectedIndices[0] + 1].Selected = true; 
                                this.Items[this.SelectedIndices[0]].EnsureVisible();
                                //this.
                            }
                        }
                        
                    }
                    break;
                case "R":
                    if (this.OnRPress != null)
                    {
                        this.OnRPress();
                    }
                    break;
                case "A":
                    string mark = "";
                    if (this.toggleIsSelectAll)
                    {
                        mark = "*";
                        this.toggleIsSelectAll = !this.toggleIsSelectAll;
                    }
                    else
                    {
                        mark = "";
                        this.toggleIsSelectAll = !this.toggleIsSelectAll;
                    }
                    foreach (ListViewItem i in this.Items)
                    {
                        MyItem4FileListView item = i as MyItem4FileListView;
                        if (item != null)
                        {
                            if (!this.dirMark.Equals(item.Ext))
                            {
                                item.Flag = mark;
                            }
                        }
                    }
                    break;
                case "F":
                    bool isFindFirstFile = true;
                    string firstFile = "";

                    this.ListFiles();

                    /*
                    foreach (ListViewItem i in this.Items)
                    {
                        MyItem4FileListView item = i as MyItem4FileListView;
                        if (item != null)
                        {
                            if (isFindFirstFile)
                            {
                                isFindFirstFile = false;
                                firstFile = item.FileName;
                            }
                            if (!string.IsNullOrEmpty(item.Flag))
                            {
                                files.Add(item.FileName);
                            }
                        }
                    }
                    if (files.Count <= 0 )
                    {
                        if( this.SelectedItems.Count > 0 )
                        {
                            MyItem4FileListView i = this.SelectedItems[0] as MyItem4FileListView;
                            if (i != null)
                            {
                                files.Add(i.FileName);
                            }
                        }
                        else if (isFindFirstFile == false && !string.IsNullOrEmpty(firstFile))
                        {
                            files.Add(firstFile);
                        }
                    }
                    */
                    FMenu fm = new FMenu(this.CurDir, this.tmpListFiles, this.TargetDir);
                    fm.DoneMenu += DoneMenu;
                    this.ContextMenuStrip = fm;

                    this.ContextMenuStrip.Show(p.X, p.Y);
                    
                    break;
                case "E":
                    this.ListFiles();

                    EMenu em = new EMenu(DoMenuClick);
                    this.ContextMenuStrip = em;
                    this.ContextMenuStrip.Show(p.X, p.Y);
                    break;
                case "V":
                    if (this.View == System.Windows.Forms.View.Details)
                    {
                        this.View = System.Windows.Forms.View.SmallIcon;
                    }
                    else
                    {
                        this.View = System.Windows.Forms.View.Details;
                    }
                    break;
                    /* // -> KeyDown
                case "T"://フォルダ入力
                    if (this.OnTPress != null)
                    {
                        this.OnTPress();
                        MyDirListView.focused = this;
                    }
                    break;
                     */
                case "W":
                    if (this.OnWPress != null)
                    {
                        this.OnWPress();
                    }
                    break;
                /* // -> KeyDown
                case "C":
                    if (this.OnCPress != null)
                    {
                        this.OnCPress();
                        MyDirListView.focused = this;
                    }
                    break;
                 */
                case "X":
                    if (this.OnXPress != null)
                    {
                        this.OnXPress(this);
                    }
                    break;
                case "H":
                    if (this.OnHPress != null)
                    {
                        this.OnHPress();
                    }
                    break;
                case "B": // ヘルプパネル非表示／表示
                    if (this.OnBPress != null)
                    {
                        this.OnBPress();
                    }
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void ListFiles()
        {
            List<string> files = new List<string>();
            bool isFindFirstFile = true;
            string firstFile = "";

            foreach (ListViewItem i in this.Items)
            {
                MyItem4FileListView item = i as MyItem4FileListView;
                if (item != null)
                {
                    if (isFindFirstFile)
                    {
                        isFindFirstFile = false;
                        firstFile = item.FileName;
                    }
                    if (!string.IsNullOrEmpty(item.Flag))
                    {
                        files.Add(item.FileName);
                    }
                }
            }
            if (files.Count <= 0)
            {
                if (this.SelectedItems.Count > 0)
                {
                    MyItem4FileListView i = this.SelectedItems[0] as MyItem4FileListView;
                    if (i != null)
                    {
                        files.Add(i.FileName);
                    }
                }
                else if (isFindFirstFile == false && !string.IsNullOrEmpty(firstFile))
                {
                    files.Add(firstFile);
                }
            }

            this.tmpListFiles = files;
        }

        public void DoMenuClick(object sender, EventArgs e)
        {
            MacroToolStripMenuItem menu = sender as MacroToolStripMenuItem;
            string flag = menu.Item.Flag;
            if (menu != null && this.tmpListFiles != null)
            {
                MacroVarReplacer rep = new MacroVarReplacer(this.CurDir, "", ref this.tmpListFiles ,this.TargetDir);
                string macroline = menu.Item.Macro;
                macroline = Interaction.InputBox(@"マクロを実行します。", "マクロ実行", macroline, -1, -1);
                if (string.IsNullOrEmpty(macroline)) return;

                this.PickupFlagFromCommandLineText(ref macroline, ref flag);

                string[] lines = macroline.Split(';');

                foreach (string line in lines)
                {

                    // 2018/11/10: 
                    // マクロの実行はデフォルトでサイレントモードにした
                    // Exec()がデフォルトではCMD画面停止モードに変更になったため。
                    // CommandLineComboのデフォルトが、CMD画面停止となる。
                    string macro = ";" + line;
                    //string macro = line;
                    
                    
                    string localflag = flag;

                    this.ExecCommandLine(flag, macro);

                    /*
                    //string macro = menu.Item.Macro;
                    if (tmpListFiles.Count == 0)
                    {
                        rep = new MacroVarReplacer(this.CurDir, "", ref this.tmpListFiles,this.TargetDir);
                        macro = rep.Filter(macro);

                        this.CallBatch(flag, macro, "");
                        continue;
                    }
                    else if (tmpListFiles.Count == 1)
                    {
                        rep = new MacroVarReplacer(this.CurDir, this.tmpListFiles[0], ref this.tmpListFiles,this.TargetDir);
                        macro = rep.Filter(macro);

                        this.CallBatch(flag, macro, "");
                        continue;
                    }
                    else
                    {

                        //macro = rep.Filter(macro);
                    }

                    foreach (string file in this.tmpListFiles)
                    {
                        rep = new MacroVarReplacer(this.CurDir, file, ref this.tmpListFiles, this.TargetDir);
                        string eachmacro = rep.Filter(macro);

                        this.CallBatch(flag, eachmacro, "");

                        if (rep.IsExitsAllFies(macro))
                        {
                            break;
                        }
                    }*/

                }

                /*
                if (!string.IsNullOrEmpty(flag) && flag.Contains("S"))
                {
#if DEBUG
                    this.CallBatch("M", "notepad \"" + Application.StartupPath + @"\tmp.txt", "");
#else
                    this.CallBatch("M", "notepad \"" + DataFilePath.Path + @"\tmp.txt", "");
#endif
                }*/
            }
            this.DoneMenu();
        }

        private void DoCommandMenu(object sender, EventArgs e)
        {
            AssocToolStripMenuItem menu = sender as AssocToolStripMenuItem;
            if (menu != null)
            {
                string flag = menu.Item.Flag;

                // 2018/11/10: 
                // マクロの実行はデフォルトでサイレントモードにした
                // Exec()がデフォルトではCMD画面停止モードに変更になったため。
                // CommandLineComboのデフォルトが、CMD画面停止となる。
                string cmdline = menu.Item.Command;
                //string cmdline = ";" + menu.Item.Command;

                this.PickupFlagFromCommandLineText(ref cmdline, ref flag);

                MyItem4FileListView item = this.FocusedItem as MyItem4FileListView;
                if (item == null) return;

                /*
                //TODO: macrofilter を使用するようにする。
                if (cmdline.Contains("$CC"))
                {
                    string tmpPath = item.FullPath;
                    Regex regex = new Regex("(^[a-zA-Z]):");
                    string drive = "c";
                    Match m = regex.Match(tmpPath);
                    if (m.Length > 0)
                    {
                        //m.ToString();

                        tmpPath = tmpPath.Replace(@"\", "/");
                        tmpPath = tmpPath.Replace(m.ToString(), "/cygdrive/" + m.ToString().Replace(":","").ToLower());

                        cmdline = cmdline.Replace("$CC", tmpPath);
                    }
                }
                cmdline = cmdline.Replace("$C", item.FullPath);
                StringBuilder sb = new StringBuilder(4096);
                LFN_SFN.GetShortPathName(item.FullPath, sb, (int)sb.Capacity);
                cmdline = cmdline.Replace("$c", sb.ToString());
                */

                //TODO 20190313
                MacroVarReplacer rep = new MacroVarReplacer(this.CurDir, Path.GetFileName(item.FullPath), ref this.tmpListFiles, this.TargetDir);
                cmdline = rep.Filter(cmdline);

                cmdline = Interaction.InputBox(@"実行します。", "実行", cmdline, -1, -1);
                if (string.IsNullOrEmpty(cmdline)) return;
                

                this.CallBatch(flag, cmdline, "");

                if (!string.IsNullOrEmpty(flag) && flag.Contains("S"))
                {
#if DEBUG
                    this.CallBatch("M", "notepad \"" + Application.StartupPath + "\\tmp.txt\"", "");
#else
                    this.CallBatch("M", "notepad \"" + DataFilePath.Path + "\\tmp.txt\"", "");
#endif
                }
            }
            this.DoneMenu();
        }

        private string GetDriveForChangeDriveFromCurDir()
        {
            return this.CurDir.Substring(0, 1) + ":";
        }

        private string ConvertSJIStoUTF8(string text)
        {
            byte[] bytesData = System.Text.Encoding.UTF8.GetBytes(text);
            string ret = '%' + BitConverter.ToString(bytesData).Replace('-', '%');
            return ret;
        }
        private int CallBatch(string flag, string macro, string param)
        {
            //macro = this.ConvertSJIStoUTF8(macro);
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
            startInfo.UseShellExecute = false;
            //startInfo.WorkingDirectory = this.CurDir;
            string cmdFilePath = DataFilePath.Path + @"\";
            //string DRV = this.GetDriveForChangeDriveFromCurDir();

            if (!string.IsNullOrEmpty(flag) && flag.Contains("O"))
            {
                startInfo.Arguments = ("/c " + macro);
                //startInfo.Arguments = param;
                Process process = Process.Start(startInfo);
            }
            else if (!string.IsNullOrEmpty(flag) && flag.Contains("P"))
            {
                startInfo.CreateNoWindow = false;
                if (flag.Contains("S"))
                {
#if DEBUG
                    startInfo.Arguments = string.Format("/c dobatp.bat \"{0}\" \"{1}\" \"{2}\" {3} {4}"/*, DRV*/, Application.StartupPath + @"\tee", DataFilePath.Path + @"\tmp.txt", this.CurDir, macro, param);
                    //startInfo.Arguments = string.Format("/c dobat.cmd \"{0}\" {1} {2}", this.CurDir, macro, param);
                    Console.WriteLine(startInfo.FileName + " /c dobatp.bat: " + macro + param);
#else
                    //startInfo.Arguments = string.Format(" /c \"" + cmdFilePath + "dobattp.bat\" \"{0}\" \"{1}\" \"{2}\" {3} {4}", Application.StartupPath + @"\tee", Application.StartupPath + @"\tmp.txt", this.CurDir, macro, param);
                    startInfo.FileName = "\"" + cmdFilePath + "dobattp.bat\"";
                    startInfo.Arguments = string.Format("\"{0}\" \"{1}\" \"{2}\" {3} {4}", Application.StartupPath + @"\tee", Application.StartupPath + @"\tmp.txt", this.CurDir, macro, param);
                    //startInfo.Arguments = string.Format(" /c " + cmdFilePath + "\\dobat.cmd \"{0}\" {1} {2}", this.CurDir, macro, param);
#endif
                }
                else
                {
#if DEBUG
                    startInfo.Arguments = string.Format("/c dobatp.bat \"{0}\" {1} {2}"/*, DRV*/, this.CurDir, macro, param);
                    //MessageBox.Show(string.Format(System.Environment.GetEnvironmentVariable("ComSpec") + " /c " + cmdFilePath + "dobatp.bat \"{0}\" {1} {2}", this.CurDir, macro, param));
                    Console.WriteLine(startInfo.FileName + "/c dobatp.bat: " + macro + param);
#else
                    //startInfo.Arguments = string.Format(" /c \"" + cmdFilePath + "dobatp.bat\" \"{0}\" {1} {2}", this.CurDir, macro, param);
                    startInfo.FileName = "\"" + cmdFilePath + "dobatp.bat\"";
                    startInfo.Arguments = string.Format("\"{0}\" {1} {2}", this.CurDir, macro, param);
                    //MessageBox.Show(string.Format(System.Environment.GetEnvironmentVariable("ComSpec") + " /c \"" + cmdFilePath + "dobatp.bat\" \"{0}\" {1} {2}", this.CurDir, macro, param));
#endif
                }
                Process process = Process.Start(startInfo);
                //process.WaitForExit();
                //return process.ExitCode;
            }
            else
            {
                startInfo.CreateNoWindow = true;
                if (!string.IsNullOrEmpty(flag) && flag.Contains("S"))
                {
#if DEBUG
                    startInfo.Arguments = string.Format("/c dobatt.bat \"{0}\" \"{1}\" \"{2}\" {3}"/*, DRV*/,Application.StartupPath + @"\tee", DataFilePath.Path + @"\tmp.txt", this.CurDir, macro, param);
                    Console.WriteLine(startInfo.FileName + "/c dobatt.bat: " + macro + param);
#else
                    //startInfo.Arguments = string.Format(" /c \"" + cmdFilePath + "dobatt.bat\" "\"{0}\" \"{1}\" \"{2}\" {3}", cmdFilePath + @"\tee", Application.StartupPath + @"\tmp.txt", this.CurDir, macro, param);
                    startInfo.FileName = "\"" + cmdFilePath + "dobatt.bat\"";
                    startInfo.Arguments = string.Format("\"{0}\" \"{1}\" \"{2}\" {3}", cmdFilePath + @"\tee", Application.StartupPath + @"\tmp.txt", this.CurDir, macro, param);
#endif
                    Process process = Process.Start(startInfo);
                    process.WaitForExit();
                    return process.ExitCode;
                }
                else
                {
#if DEBUG
                    startInfo.Arguments = string.Format("/c dobat.bat \"{0}\" {1} {2}"/*, DRV*/, this.CurDir, macro, param);
                    Console.WriteLine(startInfo.FileName + "/c dobat.bat: " + macro + param);
#else
                    //startInfo.Arguments = string.Format(" /c \"" + cmdFilePath + "dobat.bat\" \"{0}\" {1} {2}", this.CurDir, macro, param);
                    startInfo.FileName = "\"" + cmdFilePath + "dobat.bat\"";
                    startInfo.Arguments = string.Format("\"{0}\" {1} {2}", this.CurDir, macro, param);
#endif
                    Process process = Process.Start(startInfo);

                    //process.WaitForExit();
                    //return process.ExitCode;
                }
            }
            return 0;
        }

        public void DoneMenu()
        {
            this.Open(this.CurDir);
            if (this.OnDoneMenu != null)
            {
                this.OnDoneMenu();
            }
        }

        private void MyItem4FileListView_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectDirOrFile();
                    e.Handled = true;

                    /*
                    if (this.SelectedItems.Count > 0)
                    {
                        MyItem4FileListView item = this.SelectedItems[0] as MyItem4FileListView;
                        if (item != null)
                        {
                            if (this.dirMark.Equals(item.Ext))
                            {   //DIR
                                this.Open(item.FullPath);
                                return;
                            }
                            else
                            {   //FILE
                                MessageBox.Show(item.FullPath);
                            }
                        }
                    }*/
                    break;
                case Keys.C:
                    if (e.Control)
                    {
                        if (this.OnCPress != null)
                        {
                            this.OnCPress();
                            MyDirListView.focused = this;
                            e.Handled = true;
                        }
                    }
                    break;
                case Keys.T:
                    if (e.Control)
                    {
                        if (this.OnTPress != null)
                        {
                            this.OnTPress();
                            MyDirListView.focused = this;
                            e.Handled = true;
                        }
                    }
                    break;
                    if (e.Control)
                    {
                        this.isControl = true;
                    }
                    else
                    {
                        this.isControl = true;
                    }
                default:
                    e.Handled = false;
                    break;

            }
        }

        private void MyItem4FileListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.SelectDirOrFile();
        }

        private void PickupFlagFromCommandLineText(ref string cmdline, ref string flag)
        
        {
            string matchResult = "";
            Regex ex = new Regex(@"^[\!\;]+");
            Match m = ex.Match(cmdline);
            if (m.Groups.Count > 0)
            {
                matchResult = m.Groups[0].Value;
            }
            if (matchResult != null && matchResult.Contains("!"))
            {
                flag += "S";
            }
            if (matchResult != null && matchResult.Contains(";"))
            {
                // 2018/10/19 : ";"はサイレントモードにした
                //if (!flag.Contains("S"))
                //{
                //    flag += "P";
                //}
                //flag += "S";
            }
            else
            {
                // 2018/10/19 : デフォルトでCMDの画面を開くようにした。
                // TODO: 要仕様検討
                if (!flag.Contains("S") && !flag.Contains("D"))
                {
                    flag += "P";
                }
            }
            cmdline = cmdline.Substring(matchResult.Length);
        }

        public void Exec(string cmdline)
        {
            /*
            string flag = "P";
            if (cmdline != null && cmdline.StartsWith(";"))
            {
                flag = "";
                cmdline = cmdline.Substring(1);
            }
             */
            string flag = "";
            
            //cmdline = ";" + cmdline;

            this.PickupFlagFromCommandLineText(ref cmdline, ref flag);

            ListShortcut ls = ListShortcut.GetInstance();
            cmdline = ls.Filter(cmdline);

            this.ListFiles();

            /*
            MacroVarReplacer rep = null;

            if (tmpListFiles.Count == 0)
            {
                rep = new MacroVarReplacer(this.CurDir, "", ref this.tmpListFiles, this.TargetDir);
                cmdline = rep.Filter(cmdline);

                this.CallBatch(flag, cmdline, "");
                return;
            }
            else if (tmpListFiles.Count == 1)
            {
                rep = new MacroVarReplacer(this.CurDir, this.tmpListFiles[0], ref this.tmpListFiles, this.TargetDir);
                cmdline = rep.Filter(cmdline);

                this.CallBatch(flag, cmdline, "");
                return;
            }
            else
            {
                foreach (string file in this.tmpListFiles)
                {
                    rep = new MacroVarReplacer(this.CurDir, file, ref this.tmpListFiles, this.TargetDir);
                    string eachmacro = rep.Filter(cmdline);

                    this.CallBatch(flag, eachmacro, "");

                    if (rep.IsExitsAllFies(cmdline))
                    {
                        break;
                    }
                }
            }
            */
            this.ExecCommandLine(flag, cmdline);

        }

        private void ExecCommandLine( string flag, string cmdline )
        {
            MacroVarReplacer rep = null;

            if (tmpListFiles.Count == 0)
            {
                if (this.SelectedItems.Count >= 1)
                {
                    MyItem4FileListView item = this.SelectedItems[0] as MyItem4FileListView;
                    if (item != null)
                    {
                        string fn = Path.GetFileName(item.FullPath);
                        rep = new MacroVarReplacer(this.CurDir, fn, ref this.tmpListFiles, this.TargetDir);
                    }
                    else
                    {
                        rep = new MacroVarReplacer(this.CurDir, "", ref this.tmpListFiles, this.TargetDir);
                    }
                }
                else
                {
                    rep = new MacroVarReplacer(this.CurDir, "", ref this.tmpListFiles, this.TargetDir);
                }
                cmdline = rep.Filter(cmdline);

                this.CallBatch(flag, cmdline, "");
            }
            else if (tmpListFiles.Count == 1)
            {
                rep = new MacroVarReplacer(this.CurDir, this.tmpListFiles[0], ref this.tmpListFiles, this.TargetDir);
                cmdline = rep.Filter(cmdline);

                this.CallBatch(flag, cmdline, "");
            }
            else
            {
                foreach (string file in this.tmpListFiles)
                {
                    rep = new MacroVarReplacer(this.CurDir, file, ref this.tmpListFiles, this.TargetDir);
                    string eachmacro = rep.Filter(cmdline);

                    this.CallBatch(flag, eachmacro, "");

                    if (rep.IsExitsAllFies(cmdline))
                    {
                        break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(flag) && flag.Contains("S"))
            {
#if DEBUG
                this.CallBatch("M", "notepad \"" + Application.StartupPath + "\\tmp.txt\"", "");
#else
                this.CallBatch("M", "notepad \"" + DataFilePath.Path + "\\tmp.txt\"", "\"");
#endif
            }
        }

        private void SelectDirOrFile()
        {
            //if (this.SelectedItems.Count > 0)
            {
                //MyItem4FileListView item = this.SelectedItems[0] as MyItem4FileListView;
                MyItem4FileListView item = this.FocusedItem as MyItem4FileListView;
                if (item != null)
                {
                    if (this.dirMark.Equals(item.Ext))
                    {   //DIR
                        this.Open(item.FullPath);
                        return;
                    }
                    else
                    {   //FILE
                        //MessageBox.Show(item.FullPath);

                        Point p = System.Windows.Forms.Cursor.Position;

                        if (item != null)
                        {
                            int xf = (int)(item.Bounds.X + ((int)(item.Bounds.Width / 2)));
                            int yf = item.Bounds.Y + item.Bounds.Height;
                            p = this.PointToScreen(new Point(xf, yf));
                        }

                        FileInfo cFiieInfo = new FileInfo(item.FullPath);

                        CommandMenu cm = new CommandMenu(DoCommandMenu, cFiieInfo.Extension);
                        if (cm.Items.Count > 1)
                        {
                            this.ContextMenuStrip = cm;
                            this.ContextMenuStrip.Show(p.X, p.Y);
                        }
                        else if (cm.Items.Count == 1)
                        {
                            this.DoCommandMenu(cm.Items[0], new EventArgs());
                        }
                        else
                        {
                            string cmdline = "\"" + item.FullPath + "\"";
                            cmdline = Interaction.InputBox(@"実行します。", "実行", cmdline, -1, -1);
                            if (string.IsNullOrEmpty(cmdline)) return;


                            this.CallBatch("", cmdline, "");

                        }
                    }
                }
            }

        }
        public void SetTargetDir(string targetDir)
        {
            this.TargetDir = targetDir;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            LastFocusedListView.lastFocusedListView = this;
        }

        public void Save(int no)
        {
#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\window" + no.ToString() + ".txt", FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\window" + no.ToString() + ".txt", FileMode.OpenOrCreate);
#endif
            StreamWriter w = new StreamWriter(fs, Encoding.Default);
            if (this.View == System.Windows.Forms.View.SmallIcon)
            {
                w.WriteLine(this.strgSmallIcon);
            }
            else
            {
                w.WriteLine(this.strgDetail);
            }
            foreach (var col in this.Columns)
            {
                ColumnHeader h = col as ColumnHeader;
                if (h == null) continue;
                w.WriteLine(h.Width);
            }
            w.Flush();
            fs.Close();

        }

        public void Load(int no)
        {
            this.Items.Clear();
#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\window" + no.ToString() + ".txt", FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\window" + no.ToString() + ".txt", FileMode.OpenOrCreate);
#endif
            StreamReader r = new StreamReader(fs, Encoding.Default);

            string line = "";
            line = r.ReadLine();
            if( line != null )
            {
                if( this.strgSmallIcon.Equals(line) )
                {
                    this.View = System.Windows.Forms.View.SmallIcon;
                }
                else
                {
                    this.View = System.Windows.Forms.View.Details;
                }
            }
            List<ColumnHeader> headers = new List<ColumnHeader>();
            foreach (var col in this.Columns)
            {
                ColumnHeader h = col as ColumnHeader;
                if (h == null) continue;
                headers.Add(h);
            }
            int cnt = 0;
            while ((line = r.ReadLine()) != null)
            {
                line = line.Trim();
                int tmp = 0;
                if (int.TryParse(line, out tmp) == true)
                {
                    if (cnt < headers.Count())
                    {
                        headers[cnt].Width = tmp;
                    }
                    cnt++;
                }
            }

            fs.Close();
        }

        public static void ReForcus()
        {
            if (MyDirListView.focused != null)
            {
                MyDirListView.focused.Focus();
            }
        }

        
    }
}
