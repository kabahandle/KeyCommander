using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KCommander.UserClasses
{
    public class MyDirCombo : MyBaseCompleteCombo//ComboBox
    {
        public event Action OnCtrlTPress;

        private int CountToSave { get; set; }

        public MyDirCombo()
            : base()
        {
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            //this.Save();
            this.CountToSave++;
            if (this.CountToSave >= 10)
            {
                this.CountToSave = 0;
                this.Save();
            }
        }

        public override void Save()
        {
#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\dirs.txt", FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\dirs.txt", FileMode.OpenOrCreate);
#endif
            StreamWriter w = new StreamWriter(fs, Encoding.Default);
            foreach (string file in this.Items)
            {
                w.WriteLine(file);
                w.Flush();
            }

            fs.Close();
        }

        public override void Load()
        {
            this.Items.Clear();
#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\dirs.txt", FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\dirs.txt", FileMode.OpenOrCreate);
#endif
            StreamReader r = new StreamReader(fs, Encoding.Default);

            string line = "";
            while ( ( line = r.ReadLine())  != null)
            {
                this.Items.Add(line);
            }

            fs.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == (int)Keys.C)
            {
                if (this.OnCtrlTPress != null)
                {
                    this.OnCtrlTPress();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
            if (e.Control && e.KeyValue == (int)Keys.S)
            {
                this.Save();
            }
            
            base.OnKeyDown(e);
        }
    }
}
