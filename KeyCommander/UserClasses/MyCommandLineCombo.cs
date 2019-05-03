using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KCommander.UserClasses
{
    public class MyCommandLineCombo : MyBaseCompleteCombo//ComboBox
    {
        public event Action OnCtrlTPress;

        private int CountToSave { get; set; }

        public MyCommandLineCombo() : base() 
        { 
            base.IsCompleteOnlyDirectory = false;
            this.CountToSave = 0;
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
            FileStream fs = File.Open(Application.StartupPath + @"\cmdlines.txt", FileMode.OpenOrCreate | FileMode.Truncate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\cmdlines.txt", FileMode.OpenOrCreate | FileMode.Truncate);
#endif
            StreamWriter w = new StreamWriter(fs, Encoding.Default);
            foreach (string cmdline in this.Items)
            {
                w.WriteLine(cmdline);
                w.Flush();
            }

            fs.Close();
        }

        public void Clear()
        {
            FileStream fs = null;
            try
            {
#if DEBUG
                fs = File.Open(Application.StartupPath + @"\cmdlines.txt", FileMode.OpenOrCreate | FileMode.Truncate);
#else
                fs = File.Open(Application.StartupPath + @"\cmdlines.txt", FileMode.OpenOrCreate | FileMode.Truncate);
#endif
            }
            finally
            {
                try
                {
                    fs.Close();
                }
                catch (Exception ex)
                {
                }
            }
        }

        public override void Load()
        {
            this.Items.Clear();
#if DEBUG
            FileStream fs = File.Open(Application.StartupPath + @"\cmdlines.txt", FileMode.OpenOrCreate);
#else
            FileStream fs = File.Open(DataFilePath.Path + @"\cmdlines.txt", FileMode.OpenOrCreate);
#endif
            StreamReader r = new StreamReader(fs, Encoding.Default);

            string line = "";
            while ((line = r.ReadLine()) != null)
            {
                this.Items.Add(line);
            }

            fs.Close();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == (int)Keys.T)
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
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;                
            }
            /*
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
            }*/

            base.OnKeyDown(e);
        }

        /* // BASE  へ移動
        private int lastSearchedIndex = 0;
        private string lastSearchedkey = string.Empty;
        private int previousIndex = 0;
        private bool onCompleting = false;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((win32api.GetAsyncKeyState(win32api.VK_CONTROL) & 0x8000) == 0x8000)
            {
                if (e.KeyChar.Equals(' '))
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
            }
            else
            {
                lastSearchedIndex = 0;
                lastSearchedkey = this.Text;
            }

            base.OnKeyPress(e);
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
                    if (line.StartsWith(lastSearchedkey))
                    {
                        onCompleting = true;
                        this.Text = line;
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
            lastSearchedkey = this.Text;
            base.OnTextChanged(e);
        }
        */

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
    }
}
