namespace KCommander.UserForms
{
    partial class frmEditShortcut
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxShortcut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxHelp = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // tbxShortcut
            // 
            this.tbxShortcut.Location = new System.Drawing.Point(6, 68);
            this.tbxShortcut.Name = "tbxShortcut";
            this.tbxShortcut.Size = new System.Drawing.Size(529, 19);
            this.tbxShortcut.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "実行ファイル：";
            // 
            // tbxKey
            // 
            this.tbxKey.Location = new System.Drawing.Point(61, 21);
            this.tbxKey.Name = "tbxKey";
            this.tbxKey.Size = new System.Drawing.Size(217, 19);
            this.tbxKey.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "キー：";
            // 
            // tbxHelp
            // 
            this.tbxHelp.Location = new System.Drawing.Point(7, 107);
            this.tbxHelp.Multiline = true;
            this.tbxHelp.Name = "tbxHelp";
            this.tbxHelp.ReadOnly = true;
            this.tbxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxHelp.Size = new System.Drawing.Size(594, 87);
            this.tbxHelp.TabIndex = 27;
            this.tbxHelp.TabStop = false;
            this.tbxHelp.Text = "$C ： カレントファイル（拡張子を含む）と置換します。";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(539, 66);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 8;
            this.btnFile.Text = "実行ファイル";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // frmEditShortcut
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(618, 211);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.tbxHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxShortcut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxKey);
            this.Controls.Add(this.label3);
            this.Name = "frmEditShortcut";
            this.Text = "ショートカット編集";
            this.Load += new System.EventHandler(this.frmEditAssoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxShortcut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxHelp;
        private System.Windows.Forms.Button btnFile;
    }
}