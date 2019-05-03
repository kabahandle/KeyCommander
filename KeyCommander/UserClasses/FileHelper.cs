using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class FileHelper
    {
        static private FileHelper singleton = new FileHelper();
        //ファイル変更監視
        FileSystemWatcher prFileStytemWatcher;

        FileHelper()
        {
            /*
            //==フォルダの変更監視==
            prFileStytemWatcher = new FileSystemWatcher(@"c:\");
            //監視対象のフォルダ
            prFileStytemWatcher.Path = @"c;\";
            //サブフォルダまで監視
            prFileStytemWatcher.IncludeSubdirectories = true;
            //全てを監視
            prFileStytemWatcher.Filter = "";
            //ディレクトリ名、ファイル名、最終更新時間、サイズの変更を監視
            prFileStytemWatcher.NotifyFilter = NotifyFilters.DirectoryName |
                                                NotifyFilters.FileName |
                                                NotifyFilters.LastWrite |
                                                NotifyFilters.Size;
            //監視を開始
            prFileStytemWatcher.EnableRaisingEvents = true;
            //フォルダ内の作成イベント
            prFileStytemWatcher.Created += new FileSystemEventHandler(FileStytemWatcher_Created);
            //フォルダ内の変更イベント
            prFileStytemWatcher.Changed += new FileSystemEventHandler(FileStytemWatcher_Changed);
            //フォルダ内の削除イベント
            prFileStytemWatcher.Deleted += new FileSystemEventHandler(FileStytemWatcher_Deleted);
            //フォルダ内のリネームイベント
            prFileStytemWatcher.Renamed += new RenamedEventHandler(FileStytemWatcher_Renamed);
            */
        }

        static public FileHelper GetInstance()
        {
            return FileHelper.singleton;
        }

        public string GetDrv(string curdir)
        {
            StringBuilder sb = new StringBuilder();
            if (curdir.Length >= 2)
            {
                if (curdir[1] == ':')
                {
                    sb.Append(curdir[0]);
                    sb.Append(curdir[1]);
                }
            }
            return sb.ToString();
        }

        public string[] GetDirectories(string vDirPath)
        {
            return Directory.GetDirectories(vDirPath);
        }

        //パスからフォルダ名・ファイル名を取得
        public string getFileName(string vFilePath)
        {
            string wName;
            string[] wFileNameArray;
            try
            {
                char y = '\\';
                //パスを\で区切り配列に格納
                wFileNameArray = vFilePath.Split(y);
                //最下位のフォルダ名またはファイル名を取得
                wName = wFileNameArray[wFileNameArray.Length - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("例外エラー：" + ex.Message);
                //エラーの場合は空白
                wName = "";
            }
            return wName;
        }

        //フルパスからベースフォルダ名を取得する
        public string getBaseDir(string strgFullPath)
        {
            if (File.Exists(strgFullPath))
            {
                Regex reg = new Regex("[\\\\][^\\\\]*$");
                return reg.Replace(strgFullPath, "");
            }
            else
            {
                return strgFullPath;
            }
        }
        //ファイル名から拡張子を取得する
        public string getExt(string filename)
        {
            Regex reg = new Regex(@".[^\.]*$");
            Match m = reg.Match(filename);
            if (m != null && m.Groups.Count > 0)
            {
                return m.Groups[0].Value.Replace(".","");
            }
            else
            {
                return "";
            }
        }
        //ノードに設定されたパスを削除する
        public bool FileDelete(string vPath)
        {
            bool wRet = true;
            try
            {
                string wMsg = "お気に入りから[   " + getFileName(vPath) + "   ]を削除して宜しいですか？";
                if (MessageBox.Show(wMsg, "確認メッセージ", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (File.Exists(vPath))
                    {
                        File.Delete(vPath);
                    }
                    else if (Directory.Exists(vPath))
                    {
                        //フォルダ内にフォルダまたはファイルが存在しない場合は削除
                        if (Directory.GetFiles(vPath).Length == 0 && Directory.GetDirectories(vPath).Length == 0)
                        {
                            Directory.Delete(vPath);
                        }
                        else
                        {
                            MessageBox.Show("フォルダ内が空でない場合は、削除できません。");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("例外エラー：" + ex.Message);
                wRet = false;
            }
            return wRet;
        }
        //フォルダ内の作成イベント
        private void FileStytemWatcher_Created(object sender, FileSystemEventArgs e)
        {
        }
        //フォルダ内の変更イベント
        private void FileStytemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
        }
        //フォルダ内の削除イベント
        private void FileStytemWatcher_Deleted(object sender, FileSystemEventArgs e)
        { 
        }
        //フォルダ内のリネームイベント
        void FileStytemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
        }

        //ノードに設定されたURLファイル内のUrlをString型で返す
        public string OpenUrlFile(string vPath)
        {
            string wRet = "";
            try
            {
                string wLine;
                string wUrl;
                //ファイルがある場合
                if (File.Exists(vPath))
                {
                    //ファイルを開く
                    StreamReader reader = new StreamReader(vPath, Encoding.Default);
                    //１行ずつ読み込む
                    while (!reader.EndOfStream)
                    {
                        wLine = reader.ReadLine();
                        //「URL=」を含む行を取得
                        if (wLine.IndexOf("URL=") == 0)
                        {
                            //「URL=」を除き、URLを取得する
                            wUrl = wLine.Replace("URL=", "");
                            //タブブラウザにタブを追加
                            //prTabBrowser.AddNewTabPage();
                            //指定URLでWebページを開く
                            //prTabBrowser.ActiveTabPage.WebBrowser.Navigate(wUrl);
                            //Webページを開いたらループ終了
                            return wUrl;
                            break;
                        }
                    }
                    //ファイルを閉じる
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("例外エラー：" + ex.Message);
                wRet = "";
            }
            return wRet;
        }

    }
}
