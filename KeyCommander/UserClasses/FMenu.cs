using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace KCommander.UserClasses
{
    public class FMenu : ContextMenuStrip
    {
        public string CurDir
        {
            get;
            set;
        }

        public List<string> Files
        {
            get;
            set;
        }

        public string TargetDir
        {
            get;
            set;
        }

        public event Action DoneMenu;

        public FMenu(string curDir, List<string> files, string targetDir)
            : base()
        {
            this.CurDir = curDir;
            this.Files = files;
            this.TargetDir = targetDir;

            this.BuildCopy();
            this.BuildRename();
            this.BuildDelete();
            this.BuildMove();
            this.BuildNewFile();
            this.BuildNewDir();

        }

        private void RaiseDoneMenu()
        {
            if (this.DoneMenu != null)
            {
                this.DoneMenu();
            }
        }

        virtual protected void BuildNewFile()
        {
            //new file
            ToolStripMenuItem mNewFile = new ToolStripMenuItem();
            mNewFile.Text = "新規ファイル(&N)";
            mNewFile.Click += delegate
            {
                if (string.IsNullOrEmpty(CurDir))
                {
                    return;
                }
                //string part = "new_";
                string filename = "";

                filename = Interaction.InputBox("ファイル名を入力してください。", "ファイル名");
                filename = CurDir + @"\" + filename;

                int i = 1;
                if (File.Exists(filename))
                {
                    for (i = 1; i < int.MaxValue; i++)
                    {
                        string tmpfilename = filename + i.ToString();
                        if (File.Exists(tmpfilename))
                        {
                            continue;
                        }
                        else
                        {
                            try
                            {
                                File.Create(tmpfilename);
                            }
                            catch (Exception ex)
                            {
                            }
                            break;
                        }

                    }
                }
                else
                {
                    try
                    {
                        File.Create(filename);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                this.RaiseDoneMenu();
            };
            this.Items.Add(mNewFile);
        }

        virtual protected void BuildNewDir()
        {
            //new dir
            ToolStripMenuItem mNewDir = new ToolStripMenuItem();
            mNewDir.Text = "新規フォルダ(&F)";
            mNewDir.Click += delegate
            {
                if (string.IsNullOrEmpty(CurDir))
                {
                    return;
                }
                //string part = "fold_";
                string filename = "";

                filename = Interaction.InputBox("フォルダ名を入力してください。", "新規フォルダ");
                filename = CurDir + @"\" + filename;

                int i = 1;
                if (Directory.Exists(filename))
                {
                    for (i = 1; i < int.MaxValue; i++)
                    {
                        string tmpfilename = filename + i.ToString();
                        if (Directory.Exists(tmpfilename))
                        {
                            continue;
                        }
                        else
                        {
                            try
                            {
                                Directory.CreateDirectory(filename);
                            }
                            catch (Exception ex)
                            {
                            }
                            break;
                        }

                    }
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(filename);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                this.RaiseDoneMenu();
            };
            this.Items.Add(mNewDir);
        }

        virtual protected void BuildCopy()
        {
            //Copy
            ToolStripMenuItem mCopy = new ToolStripMenuItem();
            mCopy.Text = "コピー(&C)";
            mCopy.Click += delegate
            {
                if (string.IsNullOrEmpty(CurDir))
                {
                    return;
                }
                if (string.IsNullOrEmpty(TargetDir))
                {
                    return;
                }
                foreach (string file in Files)
                {
                    string fullpath = CurDir + @"\" + file;
                    if (Directory.Exists(fullpath))
                    {   //Dir
                        string targetdir = TargetDir + @"\" + file;
                        if (Directory.Exists(targetdir))
                        {
                        }
                        else
                        {
                            try
                            {
                                Directory.CreateDirectory(targetdir);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else
                    {   //File
                        try
                        {
                            File.Copy(fullpath, TargetDir + @"\" + file, false);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                this.RaiseDoneMenu();
            };
            this.Items.Add(mCopy);
        }
        virtual protected void BuildMove()
        {
            //Copy
            ToolStripMenuItem mMove = new ToolStripMenuItem();
            mMove.Text = "移動(&M)";
            mMove.Click += delegate
            {
                if (string.IsNullOrEmpty(CurDir))
                {
                    return;
                }
                if (string.IsNullOrEmpty(TargetDir))
                {
                    return;
                }
                foreach (string file in Files)
                {
                    string fullpath = CurDir + @"\" + file;
                    if (Directory.Exists(fullpath))
                    {   //Dir
                        try
                        {
                            Directory.Move(fullpath, TargetDir + @"\" + file);
                        }
                        catch (Exception ex)
                        {
                        }

                    }
                    else
                    {   //File
                        try
                        {
                            File.Move(fullpath, TargetDir + @"\" + file);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                this.RaiseDoneMenu();
            };
            this.Items.Add(mMove);
        }

        virtual protected void BuildDelete()
        {
            //delete
            ToolStripMenuItem mDelete = new ToolStripMenuItem();
            mDelete.Text = "削除(&D)";
            mDelete.Click += delegate
            {
                if (string.IsNullOrEmpty(CurDir))
                {
                    return;
                }
                foreach (string file in Files)
                {
                    string fullpath = CurDir + @"\" + file;
                    if (Directory.Exists(fullpath))
                    {   //Dir
                        try
                        {
                            Directory.Delete(fullpath);
                        }
                        catch (Exception ex)
                        {   //まだdir内にファイルがある

                        }
                    }
                    else
                    {
                        try
                        {
                            File.Delete(fullpath);
                        }
                        catch (Exception excp)
                        {
                        }
                    }
                }
                this.RaiseDoneMenu();
            };
            this.Items.Add(mDelete);
        }

        virtual protected void BuildRename()
        {
            //delete
            ToolStripMenuItem mRename = new ToolStripMenuItem();
            mRename.Text = "名前変更(&R)";
            mRename.Click += delegate
            {
                if (string.IsNullOrEmpty(CurDir))
                {
                    return;
                }
                if (Files.Count > 0)
                {
                    string filename = Files[0];
                    string rename = Interaction.InputBox("名前を変更してください。", "名前変更", filename, -1, -1);

                    if (string.IsNullOrEmpty(rename))
                    {
                        return;
                    }

                    string fullpath = CurDir + @"\" + filename;
                    string renamefullpath = CurDir + @"\" + rename;

                    if (Directory.Exists(fullpath))
                    {   //Dir
                        try
                        {
                            Directory.Move(fullpath, renamefullpath);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {   //File

                        try
                        {
                            File.Move(fullpath, renamefullpath);
                        }
                        catch (Exception ex)
                        {
                        }
                    }

                }
                this.RaiseDoneMenu();
            };
            this.Items.Add(mRename);
        }
    }
}
