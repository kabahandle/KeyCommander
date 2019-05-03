using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KCommander.UserClasses
{
    public class FormSizeSaveAdapter
    {
        private readonly string saveFileName = "formsize.txt";
        private frmKeyCommander form = null;
        public FormSizeSaveAdapter(frmKeyCommander form_)
        {
            this.form = form_;
        }

        public void Save()
        {
            if (this.form != null)
            {
#if DEBUG
                FileStream fs = File.Open(Application.StartupPath + @"\" + this.saveFileName, FileMode.OpenOrCreate);
#else
                FileStream fs = File.Open(DataFilePath.Path + @"\" + this.saveFileName, FileMode.OpenOrCreate);
#endif
                StreamWriter w = new StreamWriter(fs, Encoding.Default);
                w.WriteLine(this.form.Top);
                w.WriteLine(this.form.Left);
                w.WriteLine(this.form.Height);
                w.WriteLine(this.form.Width);
                w.WriteLine(this.form.IsHelpViewHided().ToString());
                w.WriteLine(this.form.splitContainer1.SplitterDistance.ToString());
                w.WriteLine(this.form.splitContainer2.SplitterDistance.ToString());
                w.Flush();
                fs.Close();
            }
        }

        public void Load()
        {
#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\" + this.saveFileName, FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\" + this.saveFileName, FileMode.OpenOrCreate);
#endif
            StreamReader r = new StreamReader(fs, Encoding.Default);

            int[] sizes = new int[4] { 0, 0, 0, 0 };
            int i = 0;
            string line = "";
            bool IsHelpViewHided = false;
            while ((line = r.ReadLine()) != null)
            {
                int tmp = 0;
                if (int.TryParse(line, out tmp) == true)
                {
                    sizes[i] = tmp;
                }
                else
                {
                    sizes[i] = 0;
                }
                i++;
                if (i >= 4)
                {
                    break;
                }
            }

            if (sizes[0] > 0)
            {
                this.form.Top = sizes[0];
            }
            if (sizes[1] > 0)
            {
                this.form.Left = sizes[1];
            }
            if (sizes[2] > 0)
            {
                this.form.Height = sizes[2];
            }
            if (sizes[3] > 0)
            {
                this.form.Width = sizes[3];
            }

            if ((line = r.ReadLine()) != null)
            {
                line = line.Trim();
                bool.TryParse(line, out IsHelpViewHided);

                if (IsHelpViewHided)
                {
                    this.form.HideHelpView();
                }
                else
                {
                    this.form.ShowHelpView();
                }
            }

            i = 0;
            int[] splitterDistance = new int[2] { 0, 0 };

            while ((line = r.ReadLine()) != null)
            {
                int tmp = 0;
                if (int.TryParse(line, out tmp) == true)
                {
                    splitterDistance[i] = tmp;
                }
                else
                {
                    splitterDistance[i] = 0;
                }


                i++;
                if (i >= 2) break;
            }
            if (splitterDistance[0] > 0)
            {
                this.form.splitContainer1.SplitterDistance = splitterDistance[0];
            }
            if (splitterDistance[1] > 0)
            {
                this.form.splitContainer2.SplitterDistance = splitterDistance[1];
            }

            fs.Close();
        }

    }
}
