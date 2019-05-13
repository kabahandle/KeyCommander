namespace KCommander.UserForms
{
    partial class frmEditMacro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditMacro));
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowInRightClickMenu = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMacro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxHelp = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkDirect = new System.Windows.Forms.CheckBox();
            this.chkStdOut = new System.Windows.Forms.CheckBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "フラグ：";
            // 
            // chkShowInRightClickMenu
            // 
            this.chkShowInRightClickMenu.AutoSize = true;
            this.chkShowInRightClickMenu.Location = new System.Drawing.Point(66, 8);
            this.chkShowInRightClickMenu.Name = "chkShowInRightClickMenu";
            this.chkShowInRightClickMenu.Size = new System.Drawing.Size(153, 16);
            this.chkShowInRightClickMenu.TabIndex = 0;
            this.chkShowInRightClickMenu.Text = "右クリックメニューに表示する";
            this.chkShowInRightClickMenu.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "カテゴリ：";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(66, 47);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 20);
            this.cmbCategory.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "タイトル：";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(66, 73);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(217, 19);
            this.tbxTitle.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "マクロ：";
            // 
            // tbxMacro
            // 
            this.tbxMacro.Location = new System.Drawing.Point(14, 114);
            this.tbxMacro.Name = "tbxMacro";
            this.tbxMacro.Size = new System.Drawing.Size(525, 19);
            this.tbxMacro.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "ヘルプ：";
            // 
            // tbxHelp
            // 
            this.tbxHelp.Location = new System.Drawing.Point(15, 152);
            this.tbxHelp.Multiline = true;
            this.tbxHelp.Name = "tbxHelp";
            this.tbxHelp.ReadOnly = true;
            this.tbxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxHelp.Size = new System.Drawing.Size(594, 166);
            this.tbxHelp.TabIndex = 9;
            this.tbxHelp.TabStop = false;
            this.tbxHelp.Text = resources.GetString("tbxHelp.Text");
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(545, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(545, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkDirect
            // 
            this.chkDirect.AutoSize = true;
            this.chkDirect.Location = new System.Drawing.Point(66, 25);
            this.chkDirect.Name = "chkDirect";
            this.chkDirect.Size = new System.Drawing.Size(95, 16);
            this.chkDirect.TabIndex = 2;
            this.chkDirect.Text = "ダイレクトモード";
            this.chkDirect.UseVisualStyleBackColor = true;
            // 
            // chkStdOut
            // 
            this.chkStdOut.AutoSize = true;
            this.chkStdOut.Location = new System.Drawing.Point(225, 8);
            this.chkStdOut.Name = "chkStdOut";
            this.chkStdOut.Size = new System.Drawing.Size(143, 16);
            this.chkStdOut.TabIndex = 1;
            this.chkStdOut.Text = "実行後、標準出力を開く";
            this.chkStdOut.UseVisualStyleBackColor = true;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(545, 112);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 6;
            this.btnFile.Text = "実行ファイル";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // frmEditMacro
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(621, 330);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.chkStdOut);
            this.Controls.Add(this.chkDirect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxHelp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxMacro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkShowInRightClickMenu);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditMacro";
            this.Text = "マクロ編集";
            this.Load += new System.EventHandler(this.frmEditMacro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowInRightClickMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMacro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxHelp;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkDirect;
        private System.Windows.Forms.CheckBox chkStdOut;
        private System.Windows.Forms.Button btnFile;
    }
}