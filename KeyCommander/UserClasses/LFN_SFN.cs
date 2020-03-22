using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace KCommander.UserClasses
{
    public  static class LFN_SFN
    {
        //https://www.c-sharpcorner.com/article/convert-long-to-short-file-names-in-C-Sharp/
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]

        public static extern int GetShortPathName(

                 [MarshalAs(UnmanagedType.LPTStr)]

                   string path,

                 [MarshalAs(UnmanagedType.LPTStr)]

                   StringBuilder shortPath,

                 int shortPathLength

                 );

        //http://csharphelper.com/blog/2015/01/convert-between-long-and-short-file-names-in-c/
        // Define GetShortPathName API function.
        //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern uint GetShortPathName(string lpszLongPath,
        //char[] lpszShortPath, int cchBuffer);

        //https://www.c-sharpcorner.com/article/convert-long-to-short-file-names-in-C-Sharp/
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]

        public static extern int GetLongPathName(

                 [MarshalAs(UnmanagedType.LPTStr)]

                   string path,

                 [MarshalAs(UnmanagedType.LPTStr)]

                   StringBuilder longPath,

                 int longPathLength

                 );


        //https://dobon.net/vb/dotnet/file/getshortpath.html
        /// <summary>
        /// 短いファイル名から長いファイル名を取得する
        /// </summary>
        /// <param name="path">短いファイル名（フルパス）</param>
        /// <returns>長いファイル名</returns>
        public static string GetLongPath(string path)
        {
            //ルートディレクトリを取得
            string root = System.IO.Path.GetPathRoot(path);
            //ルートディレクトリ以降を'\'で分割
            string[] folders = path.Substring(root.Length)
                .Split(System.IO.Path.DirectorySeparatorChar);

            string res = root;
            foreach (string name in folders)
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(res);
                //ディレクトリ（またはファイル）を探す
                System.IO.FileSystemInfo[] fsi = di.GetFileSystemInfos(name);
                if (fsi.Length == 1)
                    res = fsi[0].FullName;
                else
                    throw new Exception("ERROR");
            }

            return res;
        }

    }
}
