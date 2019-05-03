namespace KCommander
{
    partial class frmLisence
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbxLisenceKey = new System.Windows.Forms.TextBox();
            this.btnRegist = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRestDays = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTrial = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxMachineName = new System.Windows.Forms.TextBox();
            this.tbxDescMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ライセンスキー：";
            // 
            // tbxLisenceKey
            // 
            this.tbxLisenceKey.Location = new System.Drawing.Point(109, 53);
            this.tbxLisenceKey.Name = "tbxLisenceKey";
            this.tbxLisenceKey.Size = new System.Drawing.Size(217, 19);
            this.tbxLisenceKey.TabIndex = 1;
            // 
            // btnRegist
            // 
            this.btnRegist.Location = new System.Drawing.Point(11, 134);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(75, 23);
            this.btnRegist.TabIndex = 2;
            this.btnRegist.Text = "登録";
            this.btnRegist.UseVisualStyleBackColor = true;
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 134);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "ライセンスキーをご登録下さい";
            // 
            // lblRestDays
            // 
            this.lblRestDays.AutoSize = true;
            this.lblRestDays.Location = new System.Drawing.Point(111, 31);
            this.lblRestDays.Name = "lblRestDays";
            this.lblRestDays.Size = new System.Drawing.Size(17, 12);
            this.lblRestDays.TabIndex = 17;
            this.lblRestDays.Text = "60";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "ライセンス期限残り";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "日";
            // 
            // btnTrial
            // 
            this.btnTrial.Location = new System.Drawing.Point(106, 134);
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Size = new System.Drawing.Size(75, 23);
            this.btnTrial.TabIndex = 20;
            this.btnTrial.Text = "試用";
            this.btnTrial.UseVisualStyleBackColor = true;
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "登録ユーザー名：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "登録マシン名：";
            // 
            // tbxUserName
            // 
            this.tbxUserName.Location = new System.Drawing.Point(109, 78);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(217, 19);
            this.tbxUserName.TabIndex = 23;
            // 
            // tbxMachineName
            // 
            this.tbxMachineName.Location = new System.Drawing.Point(109, 103);
            this.tbxMachineName.Name = "tbxMachineName";
            this.tbxMachineName.Size = new System.Drawing.Size(217, 19);
            this.tbxMachineName.TabIndex = 24;
            // 
            // tbxDescMessage
            // 
            this.tbxDescMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxDescMessage.Location = new System.Drawing.Point(11, 163);
            this.tbxDescMessage.Multiline = true;
            this.tbxDescMessage.Name = "tbxDescMessage";
            this.tbxDescMessage.ReadOnly = true;
            this.tbxDescMessage.Size = new System.Drawing.Size(315, 50);
            this.tbxDescMessage.TabIndex = 25;
            this.tbxDescMessage.Text = "「登録」ボタンを押して登録時、IPアドレス、ユーザー名、マシン名も登録されます。ユーザー名、マシン名の入力は任意です。";
            // 
            // frmLisence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 225);
            this.Controls.Add(this.tbxDescMessage);
            this.Controls.Add(this.tbxMachineName);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTrial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRestDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegist);
            this.Controls.Add(this.tbxLisenceKey);
            this.Controls.Add(this.label1);
            this.Name = "frmLisence";
            this.Text = "ライセンスキーの入力";
            this.Load += new System.EventHandler(this.frmLisence_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxLisenceKey;
        private System.Windows.Forms.Button btnRegist;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRestDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTrial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxMachineName;
        private System.Windows.Forms.TextBox tbxDescMessage;
    }
}