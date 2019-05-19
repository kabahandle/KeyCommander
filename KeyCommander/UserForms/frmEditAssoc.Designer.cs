namespace KCommander.UserForms
{
    partial class frmEditAssoc
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditAssoc));
            this.chkStdOut = new System.Windows.Forms.CheckBox();
            this.chkPause = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxCommand = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkShowInRightClickMenu = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxHelp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxExt = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxNum = new System.Windows.Forms.TextBox();
            this.chkDOS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkStdOut
            // 
            this.chkStdOut.AutoSize = true;
            this.chkStdOut.Location = new System.Drawing.Point(219, 12);
            this.chkStdOut.Name = "chkStdOut";
            this.chkStdOut.Size = new System.Drawing.Size(143, 16);
            this.chkStdOut.TabIndex = 1;
            this.chkStdOut.Text = "実行後、標準出力を開く";
            this.chkStdOut.UseVisualStyleBackColor = true;
            this.chkStdOut.CheckedChanged += new System.EventHandler(this.chkStdOut_CheckedChanged);
            // 
            // chkPause
            // 
            this.chkPause.AutoSize = true;
            this.chkPause.Location = new System.Drawing.Point(60, 29);
            this.chkPause.Name = "chkPause";
            this.chkPause.Size = new System.Drawing.Size(95, 16);
            this.chkPause.TabIndex = 2;
            this.chkPause.Text = "ダイレクトモード";
            this.chkPause.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(539, 37);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(539, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "ヘルプ：";
            // 
            // tbxCommand
            // 
            this.tbxCommand.Location = new System.Drawing.Point(6, 122);
            this.tbxCommand.Name = "tbxCommand";
            this.tbxCommand.Size = new System.Drawing.Size(529, 19);
            this.tbxCommand.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "実行ファイル：";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(62, 76);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(217, 19);
            this.tbxTitle.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "タイトル：";
            // 
            // chkShowInRightClickMenu
            // 
            this.chkShowInRightClickMenu.AutoSize = true;
            this.chkShowInRightClickMenu.Location = new System.Drawing.Point(60, 12);
            this.chkShowInRightClickMenu.Name = "chkShowInRightClickMenu";
            this.chkShowInRightClickMenu.Size = new System.Drawing.Size(153, 16);
            this.chkShowInRightClickMenu.TabIndex = 0;
            this.chkShowInRightClickMenu.Text = "右クリックメニューに表示する";
            this.chkShowInRightClickMenu.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "フラグ：";
            // 
            // tbxHelp
            // 
            this.tbxHelp.Location = new System.Drawing.Point(7, 168);
            this.tbxHelp.Multiline = true;
            this.tbxHelp.Name = "tbxHelp";
            this.tbxHelp.ReadOnly = true;
            this.tbxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxHelp.Size = new System.Drawing.Size(594, 108);
            this.tbxHelp.TabIndex = 27;
            this.tbxHelp.TabStop = false;
            this.tbxHelp.Text = resources.GetString("tbxHelp.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "拡張子：";
            // 
            // tbxExt
            // 
            this.tbxExt.Location = new System.Drawing.Point(62, 51);
            this.tbxExt.Name = "tbxExt";
            this.tbxExt.Size = new System.Drawing.Size(100, 19);
            this.tbxExt.TabIndex = 4;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(539, 120);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 8;
            this.btnFile.Text = "実行ファイル";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "順番：";
            // 
            // tbxNum
            // 
            this.tbxNum.Location = new System.Drawing.Point(219, 51);
            this.tbxNum.Name = "tbxNum";
            this.tbxNum.Size = new System.Drawing.Size(60, 19);
            this.tbxNum.TabIndex = 5;
            // 
            // chkDOS
            // 
            this.chkDOS.AutoSize = true;
            this.chkDOS.Enabled = false;
            this.chkDOS.Location = new System.Drawing.Point(219, 29);
            this.chkDOS.Name = "chkDOS";
            this.chkDOS.Size = new System.Drawing.Size(75, 16);
            this.chkDOS.TabIndex = 3;
            this.chkDOS.Text = "DOSモード";
            this.chkDOS.UseVisualStyleBackColor = true;
            this.chkDOS.Visible = false;
            // 
            // frmEditAssoc
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(618, 288);
            this.Controls.Add(this.chkDOS);
            this.Controls.Add(this.tbxNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.tbxExt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxHelp);
            this.Controls.Add(this.chkStdOut);
            this.Controls.Add(this.chkPause);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxCommand);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkShowInRightClickMenu);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditAssoc";
            this.Text = "関連付け編集";
            this.Load += new System.EventHandler(this.frmEditAssoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkStdOut;
        private System.Windows.Forms.CheckBox chkPause;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxCommand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkShowInRightClickMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxHelp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxExt;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxNum;
        private System.Windows.Forms.CheckBox chkDOS;
    }
}