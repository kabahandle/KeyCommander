namespace KCommander
{
    partial class frmConfirm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoUsingLeast = new System.Windows.Forms.RadioButton();
            this.rdoUsingSomeTimes = new System.Windows.Forms.RadioButton();
            this.rdoUsingWell = new System.Windows.Forms.RadioButton();
            this.rdoUsingMost = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoUsingMost);
            this.groupBox1.Controls.Add(this.rdoUsingWell);
            this.groupBox1.Controls.Add(this.rdoUsingSomeTimes);
            this.groupBox1.Controls.Add(this.rdoUsingLeast);
            this.groupBox1.Location = new System.Drawing.Point(26, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ご使用状況";
            // 
            // rdoUsingLeast
            // 
            this.rdoUsingLeast.AutoSize = true;
            this.rdoUsingLeast.Location = new System.Drawing.Point(27, 32);
            this.rdoUsingLeast.Name = "rdoUsingLeast";
            this.rdoUsingLeast.Size = new System.Drawing.Size(109, 16);
            this.rdoUsingLeast.TabIndex = 0;
            this.rdoUsingLeast.TabStop = true;
            this.rdoUsingLeast.Text = "あまり使っていない";
            this.rdoUsingLeast.UseVisualStyleBackColor = true;
            // 
            // rdoUsingSomeTimes
            // 
            this.rdoUsingSomeTimes.AutoSize = true;
            this.rdoUsingSomeTimes.Location = new System.Drawing.Point(27, 65);
            this.rdoUsingSomeTimes.Name = "rdoUsingSomeTimes";
            this.rdoUsingSomeTimes.Size = new System.Drawing.Size(95, 16);
            this.rdoUsingSomeTimes.TabIndex = 1;
            this.rdoUsingSomeTimes.TabStop = true;
            this.rdoUsingSomeTimes.Text = "時々使っている";
            this.rdoUsingSomeTimes.UseVisualStyleBackColor = true;
            // 
            // rdoUsingWell
            // 
            this.rdoUsingWell.AutoSize = true;
            this.rdoUsingWell.Location = new System.Drawing.Point(27, 97);
            this.rdoUsingWell.Name = "rdoUsingWell";
            this.rdoUsingWell.Size = new System.Drawing.Size(86, 16);
            this.rdoUsingWell.TabIndex = 2;
            this.rdoUsingWell.TabStop = true;
            this.rdoUsingWell.Text = "よく使っている";
            this.rdoUsingWell.UseVisualStyleBackColor = true;
            // 
            // rdoUsingMost
            // 
            this.rdoUsingMost.AutoSize = true;
            this.rdoUsingMost.Location = new System.Drawing.Point(27, 132);
            this.rdoUsingMost.Name = "rdoUsingMost";
            this.rdoUsingMost.Size = new System.Drawing.Size(99, 16);
            this.rdoUsingMost.TabIndex = 3;
            this.rdoUsingMost.TabStop = true;
            this.rdoUsingMost.Text = "かなり使っている";
            this.rdoUsingMost.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(26, 205);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConfirm";
            this.Text = "確認";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoUsingMost;
        private System.Windows.Forms.RadioButton rdoUsingWell;
        private System.Windows.Forms.RadioButton rdoUsingSomeTimes;
        private System.Windows.Forms.RadioButton rdoUsingLeast;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}