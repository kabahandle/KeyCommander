using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCommander.UserClasses
{
    public class MouseRightClickMenu : ContextMenuStrip
    {
        public KeyPressEventHandler DoKeyPress = null;

        public MouseRightClickMenu(KeyPressEventHandler handler) : base() 
        {
            this.DoKeyPress = handler;
            this.BuildMenu();
        }

        private void BuildMenu()
        {
            ToolStripMenuItem mSpace = new ToolStripMenuItem();
            mSpace.Text = "選択(&S)";
            mSpace.Click += (o, e) =>
            {
                if (this.DoKeyPress != null)
                {
                    this.DoKeyPress(o, new KeyPressEventArgs(' '));
                }
            };
            this.Items.Add(mSpace);

            ToolStripMenuItem mAll = new ToolStripMenuItem();
            mAll.Text = "全選択(&A)";
            mAll.Click += (o, e) =>
            {
                if (this.DoKeyPress != null)
                {
                    this.DoKeyPress(o, new KeyPressEventArgs('A'));
                }
            };
            this.Items.Add(mAll);

            ToolStripMenuItem mFile = new ToolStripMenuItem();
            mFile.Text = "ファイルメニュー(&F)";
            mFile.Click += (o, e) =>
            {
                if (this.DoKeyPress != null)
                {
                    this.DoKeyPress(o, new KeyPressEventArgs('F'));
                }
            };
            this.Items.Add(mFile);

            ToolStripMenuItem mMacro = new ToolStripMenuItem();
            mMacro.Text = "マクロ実行(&E)";
            mMacro.Click += (o, e) =>
            {
                if (this.DoKeyPress != null)
                {
                    this.DoKeyPress(o, new KeyPressEventArgs('E'));
                }
            };
            this.Items.Add(mMacro);

            ToolStripMenuItem mAltWin = new ToolStripMenuItem();
            mAltWin.Text = "ウインドウ移動(&R)";
            mAltWin.Click += (o, e) =>
            {
                if (this.DoKeyPress != null)
                {
                    this.DoKeyPress(o, new KeyPressEventArgs('R'));
                }
            };
            this.Items.Add(mAltWin);

            ToolStripMenuItem mGotoFolderCombo = new ToolStripMenuItem();
            mGotoFolderCombo.Text = "フォルダ入力(&T)";
            mGotoFolderCombo.Click += (o, e) =>
            {
                if (this.DoKeyPress != null)
                {
                    this.DoKeyPress(o, new KeyPressEventArgs('T'));
                }
            };
            this.Items.Add(mGotoFolderCombo);

            ToolStripMenuItem mSwitchDetailOrIcon = new ToolStripMenuItem();
            mSwitchDetailOrIcon.Text = "詳細/一覧表示切り替え(&V)";
            mSwitchDetailOrIcon.Click += (o, e) =>
            {
                if (this.DoKeyPress != null)
                {
                    this.DoKeyPress(o, new KeyPressEventArgs('V'));
                }
            };
            this.Items.Add(mSwitchDetailOrIcon);

            ToolStripMenuItem m1WinOr2Win = new ToolStripMenuItem();
            m1WinOr2Win.Text = "1<->2 ウィンドウ切り替え(&W)";
            m1WinOr2Win.Click += (o, e) =>
            {
                if (this.DoKeyPress != null)
                {
                    this.DoKeyPress(o, new KeyPressEventArgs('W'));
                }
            };
            this.Items.Add(m1WinOr2Win);






        }


    }
}
