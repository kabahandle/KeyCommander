namespace KCommander.UserForms
{
    partial class frmListMacro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListMacro));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteMacro = new System.Windows.Forms.Button();
            this.btnEditMacro = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.listMyMacroListView = new KCommander.UserClasses.MyMacroListView();
            this.pnlTop.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnCopy);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.btnDeleteMacro);
            this.pnlTop.Controls.Add(this.btnEditMacro);
            this.pnlTop.Controls.Add(this.btnNew);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(619, 53);
            this.pnlTop.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(293, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "コピー";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(532, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteMacro
            // 
            this.btnDeleteMacro.Location = new System.Drawing.Point(198, 12);
            this.btnDeleteMacro.Name = "btnDeleteMacro";
            this.btnDeleteMacro.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteMacro.TabIndex = 2;
            this.btnDeleteMacro.Text = "マクロ削除...";
            this.btnDeleteMacro.UseVisualStyleBackColor = true;
            this.btnDeleteMacro.Click += new System.EventHandler(this.btnDeleteMacro_Click);
            // 
            // btnEditMacro
            // 
            this.btnEditMacro.Location = new System.Drawing.Point(105, 12);
            this.btnEditMacro.Name = "btnEditMacro";
            this.btnEditMacro.Size = new System.Drawing.Size(75, 23);
            this.btnEditMacro.TabIndex = 1;
            this.btnEditMacro.Text = "マクロ編集...";
            this.btnEditMacro.UseVisualStyleBackColor = true;
            this.btnEditMacro.Click += new System.EventHandler(this.btnEditMacro_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "新規マクロ...";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.listMyMacroListView);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 53);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(619, 252);
            this.pnlCenter.TabIndex = 0;
            // 
            // listMyMacroListView
            // 
            this.listMyMacroListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMyMacroListView.FullRowSelect = true;
            this.listMyMacroListView.HideSelection = false;
            this.listMyMacroListView.Location = new System.Drawing.Point(0, 0);
            this.listMyMacroListView.MultiSelect = false;
            this.listMyMacroListView.Name = "listMyMacroListView";
            this.listMyMacroListView.Size = new System.Drawing.Size(619, 252);
            this.listMyMacroListView.TabIndex = 4;
            this.listMyMacroListView.UseCompatibleStateImageBehavior = false;
            this.listMyMacroListView.View = System.Windows.Forms.View.Details;
            this.listMyMacroListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listMyMacroListView_MouseDoubleClick);
            // 
            // frmListMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 305);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListMacro";
            this.Text = "マクロ一覧";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListMacro_FormClosing);
            this.Load += new System.EventHandler(this.frmListMacro_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCenter;
        private UserClasses.MyMacroListView listMyMacroListView;
        private System.Windows.Forms.Button btnEditMacro;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDeleteMacro;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCopy;
    }
}