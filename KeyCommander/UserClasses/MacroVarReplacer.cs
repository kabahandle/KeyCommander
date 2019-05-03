using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using KeyCommander;
using System.Collections;

namespace KCommander.UserClasses
{
    public class MacroVarReplacer
    {
        private string CurDir
        {
            get;
            set;
        }

        private string CurDrv
        {
            get;
            set;
        }

        private string CurFile
        {
            get;
            set;
        }

        private string CurFileNoExt
        {
            get;
            set;
        }

        private string TargetDir
        {
            get;
            set;
        }

        private string TargetDrv
        {
            get;
            set;
        }

        private List<string> Files
        {
            get;
            set;
        }

        private static Dictionary<string, string> dosBoxDirMounts = new Dictionary<string, string>();
        public static Dictionary<string, string> DosBoxDirMounts
        {
            get
            {
                return MacroVarReplacer.dosBoxDirMounts;
            }
            set
            {
                MacroVarReplacer.dosBoxDirMounts = value;
            }
        }


        public MacroVarReplacer(string curdir, string curfile, ref List<string> files, string targetDir)
        {
            FileHelper fh = FileHelper.GetInstance();

            this.CurDir = curdir;
            this.CurFile = curfile;
            this.CurDrv = fh.GetDrv(curdir);
            string ext = "." + fh.getExt(curfile);
            this.CurFileNoExt = curfile.Replace(ext, "");
            if (!string.IsNullOrEmpty(targetDir))
            {
                this.TargetDir = targetDir;
                this.TargetDrv = fh.GetDrv(targetDir);
            }
            this.Files = files;
        }

        public string Filter(string macro)
        {
            StringBuilder sbFiles = new StringBuilder();
            sbFiles.Append(" ");
            if (this.Files != null)
            {
                foreach (string fn in this.Files)
                {
                    sbFiles.Append(fn);
                    sbFiles.Append(" ");
                }
            }
            string files = sbFiles.ToString();

            //macro = macro.Replace(@"$CC", this.CurFile.Replace(@"\", "/"));
            if (macro.Contains("$CC"))
            {
                //string tmpPath = this.CurDir + @"\" + this.CurFile;
                //Regex regex = new Regex("(^[a-zA-Z]):");
                //string drive = "c";
                //Match m = regex.Match(tmpPath);
                //if (m.Length > 0)
                //{
                //    //m.ToString();

                //    tmpPath = tmpPath.Replace(@"\", "/");
                //    tmpPath = tmpPath.Replace(m.ToString(), "/cygdrive/" + m.ToString().Replace(":", "").ToLower());

                //    macro = macro.Replace("$CC", tmpPath);
                //}
                this.replaceWinPathToCygwinPath(this.CurDir + @"\" + this.CurFile, "$CC", ref macro);
            }
            if (macro.Contains("$PP"))
            {
                this.replaceWinPathToCygwinPath(this.CurDir, "$PP", ref macro);
            }
            if (macro.Contains("$TT"))
            {
                this.replaceWinPathToCygwinPath(this.TargetDir, "$TT", ref macro);
            }

            macro = macro.Replace(@"$A", files);
            macro = macro.Replace(@"$P", this.CurDir);
            macro = macro.Replace(@"$T", this.TargetDir);
            macro = macro.Replace(@"$D", this.CurDrv);
            macro = macro.Replace(@"$d", this.TargetDrv);
            macro = macro.Replace(@"$C", this.CurFile);
            macro = macro.Replace(@"$X", this.CurFileNoExt);
            macro = macro.Replace(@"$Q", "\"");
            macro = macro.Replace(@"$Z", ",");

            int ret = 0;
            StringBuilder sb = new StringBuilder(4096);
            LFN_SFN.GetShortPathName(files, sb, (int)sb.Capacity);
            macro = macro.Replace(@"$a", getMountAppliedDosboxPath(sb.ToString()));
            sb = new StringBuilder(1028);
            LFN_SFN.GetShortPathName(this.CurDir, sb, (int)sb.Capacity);
            macro = macro.Replace(@"$p", getMountAppliedDosboxPath(sb.ToString()));
            sb = new StringBuilder(4096);
            LFN_SFN.GetShortPathName(this.TargetDir, sb, (int)sb.Capacity);
            macro = macro.Replace(@"$t", getMountAppliedDosboxPath(sb.ToString()));
            sb = new StringBuilder(4096);
            LFN_SFN.GetShortPathName(this.CurDir + @"\" + this.CurFile, sb, (int)sb.Capacity);
            macro = macro.Replace(@"$c", getMountAppliedDosboxPath(sb.ToString()));
            sb = new StringBuilder(4096);
            LFN_SFN.GetShortPathName(this.CurDir + @"\" + this.CurFileNoExt, sb, (int)sb.Capacity);
            macro = macro.Replace(@"$x", getMountAppliedDosboxPath(sb.ToString()));


            // 環境変数展開
            macro = this.getMacroEnvValuesExpanded(macro);


            if (!string.IsNullOrEmpty(macro))
            {
                if (macro.Contains(@"$R"))
                {
                    string input = Interaction.InputBox(@"$Rに対する値を入力してください。", "変数入力", "", -1, -1);
                    macro = macro.Replace(@"$R", input);
                }
            }


            return macro;
        }

        public bool IsExitsAllFies( string macro)
        {
            return (!string.IsNullOrEmpty(macro)) && macro.Contains(@"$A");
        }

        private void replaceWinPathToCygwinPath(string fullpath, string replaceMark, ref string macro)
        {
            string tmpPath = fullpath;
            Regex regex = new Regex("(^[a-zA-Z]):");
            string drive = "c";
            Match m = regex.Match(tmpPath);
            if (m.Length > 0)
            {
                //m.ToString();

                tmpPath = tmpPath.Replace(@"\", "/");
                tmpPath = tmpPath.Replace(m.ToString(), "/cygdrive/" + m.ToString().Replace(":", "").ToLower());

                macro = macro.Replace(replaceMark, tmpPath);
            }
        }

        public static string getCygWinPathFromWinPath(string fullpath)
        {
            string tmpPath = fullpath;
            Regex regex = new Regex("(^[a-zA-Z]):");
            string drive = "c";
            Match m = regex.Match(tmpPath);
            if (m.Length > 0)
            {
                //m.ToString();

                tmpPath = tmpPath.Replace(@"\", "/");
                tmpPath = tmpPath.Replace(m.ToString(), "/cygdrive/" + m.ToString().Replace(":", "").ToLower());

                return tmpPath;

            }
            else
            {
                return fullpath;
            }
        }

        public static string getDosPathFromWinPat(string fullpath)
        {
            StringBuilder sb = new StringBuilder(4096);
            LFN_SFN.GetShortPathName(fullpath, sb, (int)sb.Capacity);
            return sb.ToString();
        }

        private string getMountAppliedDosboxPath(string windowsPath)
        {
            string ret = windowsPath;
            foreach (KeyValuePair<string,string> kv in MacroVarReplacer.DosBoxDirMounts)
            {
                ret = ret.Replace(kv.Key, kv.Value);
            }

            return ret;
        }

        private string getMacroEnvValuesExpanded(string macro)
        {
            IDictionary dic = EnvValuesHelper.getSingleton().EnvValues;

            System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(macro, @"(%[^%]*%)");
            foreach (Match m in mc)
            {
                GroupCollection groups = m.Groups;
                for( int i = 0; i < groups.Count; i++ )
                {
                    CaptureCollection captures = groups[i].Captures;
                    for( int j = 0; j < captures.Count; j++ )
                    {
                    string key = captures[j].Value.Replace("%","");
                    if (dic.Contains(key))
                    {
                        string value = dic[key] as string;
                        if (!string.IsNullOrEmpty(value))
                        {
                            macro = macro.Replace("%"+key+"%", value);
                        }
                    }
                    }
                }
            }

            return macro;
        }
    }
}
