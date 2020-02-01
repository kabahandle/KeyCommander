using KCommander.UserClasses;
namespace KCommander
{
    partial class frmKeyCommander
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKeyCommander));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpDir = new System.Windows.Forms.GroupBox();
            this.btnClearDirHistory = new System.Windows.Forms.Button();
            this.btnClearCurrentDirHistory = new System.Windows.Forms.Button();
            this.btnSetCmbDir = new System.Windows.Forms.Button();
            this.cmbDir = new KCommander.UserClasses.MyDirCombo();
            this.btnShowIntoTab2 = new System.Windows.Forms.Button();
            this.btnShowIntotab = new System.Windows.Forms.Button();
            this.grpCommandLine = new System.Windows.Forms.GroupBox();
            this.cmbCommandLine = new KCommander.UserClasses.MyCommandLineCombo();
            this.btnClearCurrentHistory = new System.Windows.Forms.Button();
            this.btnExecTab1 = new System.Windows.Forms.Button();
            this.btnClearCommandHistory = new System.Windows.Forms.Button();
            this.btnExecTab2 = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.textBoxHelp = new System.Windows.Forms.TextBox();
            this.panelSideButton = new System.Windows.Forms.Panel();
            this.buttonValiableHelp = new System.Windows.Forms.Button();
            this.buttonCommandLineHelp = new System.Windows.Forms.Button();
            this.buttonKeyHelp = new System.Windows.Forms.Button();
            this.pnlSide1 = new System.Windows.Forms.Panel();
            this.tabCtrlSide1 = new System.Windows.Forms.TabControl();
            this.tabList1 = new System.Windows.Forms.TabPage();
            this.listView1 = new KCommander.UserClasses.MyDirListView();
            this.colHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Flag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Updated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSide2 = new System.Windows.Forms.Panel();
            this.tabCtrlSide2 = new System.Windows.Forms.TabControl();
            this.tabList2 = new System.Windows.Forms.TabPage();
            this.listView2 = new KCommander.UserClasses.MyDirListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Updated2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.timerTopMost = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupFiler = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlTop.SuspendLayout();
            this.grpDir.SuspendLayout();
            this.grpCommandLine.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.panelSideButton.SuspendLayout();
            this.pnlSide1.SuspendLayout();
            this.tabCtrlSide1.SuspendLayout();
            this.tabList1.SuspendLayout();
            this.pnlSide2.SuspendLayout();
            this.tabCtrlSide2.SuspendLayout();
            this.tabList2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupFiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpDir);
            this.pnlTop.Controls.Add(this.grpCommandLine);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1003, 147);
            this.pnlTop.TabIndex = 0;
            // 
            // grpDir
            // 
            this.grpDir.Controls.Add(this.btnClearDirHistory);
            this.grpDir.Controls.Add(this.btnClearCurrentDirHistory);
            this.grpDir.Controls.Add(this.btnSetCmbDir);
            this.grpDir.Controls.Add(this.cmbDir);
            this.grpDir.Controls.Add(this.btnShowIntoTab2);
            this.grpDir.Controls.Add(this.btnShowIntotab);
            this.grpDir.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDir.Location = new System.Drawing.Point(0, 71);
            this.grpDir.Name = "grpDir";
            this.grpDir.Size = new System.Drawing.Size(1003, 75);
            this.grpDir.TabIndex = 1;
            this.grpDir.TabStop = false;
            this.grpDir.Text = "ディレクトリ(&D)";
            this.grpDir.Enter += new System.EventHandler(this.grpDir_Enter);
            // 
            // btnClearDirHistory
            // 
            this.btnClearDirHistory.Location = new System.Drawing.Point(480, 46);
            this.btnClearDirHistory.Name = "btnClearDirHistory";
            this.btnClearDirHistory.Size = new System.Drawing.Size(137, 23);
            this.btnClearDirHistory.TabIndex = 5;
            this.btnClearDirHistory.Text = "履歴クリア([ALT]+[DEL])";
            this.btnClearDirHistory.UseVisualStyleBackColor = true;
            this.btnClearDirHistory.Click += new System.EventHandler(this.btnClearDirHistory_Click);
            // 
            // btnClearCurrentDirHistory
            // 
            this.btnClearCurrentDirHistory.Location = new System.Drawing.Point(312, 46);
            this.btnClearCurrentDirHistory.Name = "btnClearCurrentDirHistory";
            this.btnClearCurrentDirHistory.Size = new System.Drawing.Size(162, 23);
            this.btnClearCurrentDirHistory.TabIndex = 4;
            this.btnClearCurrentDirHistory.Text = "現在の履歴クリア([ALT]+[BS])";
            this.btnClearCurrentDirHistory.UseVisualStyleBackColor = true;
            this.btnClearCurrentDirHistory.Click += new System.EventHandler(this.btnClearCurrentDirHistory_Click);
            // 
            // btnSetCmbDir
            // 
            this.btnSetCmbDir.Location = new System.Drawing.Point(12, 18);
            this.btnSetCmbDir.Name = "btnSetCmbDir";
            this.btnSetCmbDir.Size = new System.Drawing.Size(73, 23);
            this.btnSetCmbDir.TabIndex = 0;
            this.btnSetCmbDir.Text = "Dir開く(&O)";
            this.btnSetCmbDir.UseVisualStyleBackColor = true;
            this.btnSetCmbDir.Click += new System.EventHandler(this.btnSetCmbDir_Click);
            // 
            // cmbDir
            // 
            this.cmbDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDir.FormattingEnabled = true;
            this.cmbDir.IsCompleteOnlyDirectory = true;
            this.cmbDir.Location = new System.Drawing.Point(91, 20);
            this.cmbDir.Name = "cmbDir";
            this.cmbDir.Size = new System.Drawing.Size(900, 20);
            this.cmbDir.TabIndex = 1;
            this.cmbDir.TabStop = false;
            this.cmbDir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDir_KeyDown);
            // 
            // btnShowIntoTab2
            // 
            this.btnShowIntoTab2.Location = new System.Drawing.Point(136, 46);
            this.btnShowIntoTab2.Name = "btnShowIntoTab2";
            this.btnShowIntoTab2.Size = new System.Drawing.Size(170, 23);
            this.btnShowIntoTab2.TabIndex = 3;
            this.btnShowIntoTab2.TabStop = false;
            this.btnShowIntoTab2.Text = "タブ2に表示([SHIFT]+[RET])";
            this.btnShowIntoTab2.UseVisualStyleBackColor = true;
            this.btnShowIntoTab2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowIntotab
            // 
            this.btnShowIntotab.Location = new System.Drawing.Point(12, 46);
            this.btnShowIntotab.Name = "btnShowIntotab";
            this.btnShowIntotab.Size = new System.Drawing.Size(118, 23);
            this.btnShowIntotab.TabIndex = 2;
            this.btnShowIntotab.TabStop = false;
            this.btnShowIntotab.Text = "タブ１に表示([RET])";
            this.btnShowIntotab.UseVisualStyleBackColor = true;
            this.btnShowIntotab.Click += new System.EventHandler(this.btnShowIntotab_Click);
            // 
            // grpCommandLine
            // 
            this.grpCommandLine.Controls.Add(this.cmbCommandLine);
            this.grpCommandLine.Controls.Add(this.btnClearCurrentHistory);
            this.grpCommandLine.Controls.Add(this.btnExecTab1);
            this.grpCommandLine.Controls.Add(this.btnClearCommandHistory);
            this.grpCommandLine.Controls.Add(this.btnExecTab2);
            this.grpCommandLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCommandLine.Location = new System.Drawing.Point(0, 0);
            this.grpCommandLine.Name = "grpCommandLine";
            this.grpCommandLine.Size = new System.Drawing.Size(1003, 71);
            this.grpCommandLine.TabIndex = 0;
            this.grpCommandLine.TabStop = false;
            this.grpCommandLine.Text = "コマンドライン(&C)";
            this.grpCommandLine.Enter += new System.EventHandler(this.grpCommandLine_Enter);
            // 
            // cmbCommandLine
            // 
            this.cmbCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCommandLine.FormattingEnabled = true;
            this.cmbCommandLine.IsCompleteOnlyDirectory = false;
            this.cmbCommandLine.Location = new System.Drawing.Point(12, 17);
            this.cmbCommandLine.Name = "cmbCommandLine";
            this.cmbCommandLine.Size = new System.Drawing.Size(979, 20);
            this.cmbCommandLine.TabIndex = 0;
            this.cmbCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCommandLine_KeyDown);
            // 
            // btnClearCurrentHistory
            // 
            this.btnClearCurrentHistory.Location = new System.Drawing.Point(312, 42);
            this.btnClearCurrentHistory.Name = "btnClearCurrentHistory";
            this.btnClearCurrentHistory.Size = new System.Drawing.Size(162, 23);
            this.btnClearCurrentHistory.TabIndex = 3;
            this.btnClearCurrentHistory.Text = "現在の履歴クリア([ALT]+[BS])";
            this.btnClearCurrentHistory.UseVisualStyleBackColor = true;
            this.btnClearCurrentHistory.Click += new System.EventHandler(this.btnClearCurrentHistory_Click);
            // 
            // btnExecTab1
            // 
            this.btnExecTab1.Location = new System.Drawing.Point(12, 42);
            this.btnExecTab1.Name = "btnExecTab1";
            this.btnExecTab1.Size = new System.Drawing.Size(118, 23);
            this.btnExecTab1.TabIndex = 1;
            this.btnExecTab1.Text = "タブ1で実行([RET])]";
            this.btnExecTab1.UseVisualStyleBackColor = true;
            this.btnExecTab1.Click += new System.EventHandler(this.btnExecTab1_Click);
            // 
            // btnClearCommandHistory
            // 
            this.btnClearCommandHistory.Location = new System.Drawing.Point(480, 42);
            this.btnClearCommandHistory.Name = "btnClearCommandHistory";
            this.btnClearCommandHistory.Size = new System.Drawing.Size(137, 23);
            this.btnClearCommandHistory.TabIndex = 4;
            this.btnClearCommandHistory.Text = "履歴クリア([ALT]+[DEL])";
            this.btnClearCommandHistory.UseVisualStyleBackColor = true;
            this.btnClearCommandHistory.Click += new System.EventHandler(this.btnClearCommandHistory_Click);
            // 
            // btnExecTab2
            // 
            this.btnExecTab2.Location = new System.Drawing.Point(136, 42);
            this.btnExecTab2.Name = "btnExecTab2";
            this.btnExecTab2.Size = new System.Drawing.Size(170, 23);
            this.btnExecTab2.TabIndex = 2;
            this.btnExecTab2.Text = "タブ2で実行([SHIFT]+[RET])";
            this.btnExecTab2.UseVisualStyleBackColor = true;
            this.btnExecTab2.Click += new System.EventHandler(this.btnExecTab2_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.textBoxHelp);
            this.pnlBottom.Controls.Add(this.panelSideButton);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 0);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1003, 147);
            this.pnlBottom.TabIndex = 0;
            // 
            // textBoxHelp
            // 
            this.textBoxHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHelp.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxHelp.Location = new System.Drawing.Point(91, 0);
            this.textBoxHelp.Multiline = true;
            this.textBoxHelp.Name = "textBoxHelp";
            this.textBoxHelp.ReadOnly = true;
            this.textBoxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHelp.Size = new System.Drawing.Size(912, 147);
            this.textBoxHelp.TabIndex = 2;
            this.textBoxHelp.TabStop = false;
            this.textBoxHelp.Text = resources.GetString("textBoxHelp.Text");
            this.textBoxHelp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHelp_KeyPress);
            // 
            // panelSideButton
            // 
            this.panelSideButton.Controls.Add(this.buttonValiableHelp);
            this.panelSideButton.Controls.Add(this.buttonCommandLineHelp);
            this.panelSideButton.Controls.Add(this.buttonKeyHelp);
            this.panelSideButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideButton.Location = new System.Drawing.Point(0, 0);
            this.panelSideButton.Name = "panelSideButton";
            this.panelSideButton.Size = new System.Drawing.Size(91, 147);
            this.panelSideButton.TabIndex = 1;
            // 
            // buttonValiableHelp
            // 
            this.buttonValiableHelp.Location = new System.Drawing.Point(0, 44);
            this.buttonValiableHelp.Name = "buttonValiableHelp";
            this.buttonValiableHelp.Size = new System.Drawing.Size(90, 24);
            this.buttonValiableHelp.TabIndex = 2;
            this.buttonValiableHelp.Text = "変数ヘルプ(&3)";
            this.buttonValiableHelp.UseVisualStyleBackColor = true;
            this.buttonValiableHelp.Click += new System.EventHandler(this.buttonValiableHelp_Click);
            // 
            // buttonCommandLineHelp
            // 
            this.buttonCommandLineHelp.Location = new System.Drawing.Point(0, 22);
            this.buttonCommandLineHelp.Name = "buttonCommandLineHelp";
            this.buttonCommandLineHelp.Size = new System.Drawing.Size(90, 23);
            this.buttonCommandLineHelp.TabIndex = 1;
            this.buttonCommandLineHelp.Text = "CMDヘルプ(&2)";
            this.buttonCommandLineHelp.UseVisualStyleBackColor = true;
            this.buttonCommandLineHelp.Click += new System.EventHandler(this.buttonCommandLineHelp_Click);
            // 
            // buttonKeyHelp
            // 
            this.buttonKeyHelp.Location = new System.Drawing.Point(0, 0);
            this.buttonKeyHelp.Name = "buttonKeyHelp";
            this.buttonKeyHelp.Size = new System.Drawing.Size(90, 23);
            this.buttonKeyHelp.TabIndex = 0;
            this.buttonKeyHelp.Text = "キーヘルプ(&1)";
            this.buttonKeyHelp.UseVisualStyleBackColor = true;
            this.buttonKeyHelp.Click += new System.EventHandler(this.buttonKeyHelp_Click);
            // 
            // pnlSide1
            // 
            this.pnlSide1.Controls.Add(this.tabCtrlSide1);
            this.pnlSide1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSide1.Location = new System.Drawing.Point(0, 0);
            this.pnlSide1.Name = "pnlSide1";
            this.pnlSide1.Size = new System.Drawing.Size(470, 310);
            this.pnlSide1.TabIndex = 0;
            // 
            // tabCtrlSide1
            // 
            this.tabCtrlSide1.Controls.Add(this.tabList1);
            this.tabCtrlSide1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlSide1.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlSide1.Name = "tabCtrlSide1";
            this.tabCtrlSide1.SelectedIndex = 0;
            this.tabCtrlSide1.Size = new System.Drawing.Size(470, 310);
            this.tabCtrlSide1.TabIndex = 0;
            this.tabCtrlSide1.TabStop = false;
            // 
            // tabList1
            // 
            this.tabList1.Controls.Add(this.listView1);
            this.tabList1.Location = new System.Drawing.Point(4, 22);
            this.tabList1.Name = "tabList1";
            this.tabList1.Padding = new System.Windows.Forms.Padding(3);
            this.tabList1.Size = new System.Drawing.Size(462, 284);
            this.tabList1.TabIndex = 0;
            this.tabList1.Text = "タブ1";
            this.tabList1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHead,
            this.Flag,
            this.FileName,
            this.Ext,
            this.FileSize,
            this.Updated});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(456, 278);
            this.listView1.TabIndex = 0;
            this.listView1.TargetDir = null;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // colHead
            // 
            this.colHead.Text = "FN";
            this.colHead.Width = 0;
            // 
            // Flag
            // 
            this.Flag.Text = "選択";
            this.Flag.Width = 32;
            // 
            // FileName
            // 
            this.FileName.Text = "ファイル名";
            this.FileName.Width = 160;
            // 
            // Ext
            // 
            this.Ext.Text = "拡張子";
            this.Ext.Width = 50;
            // 
            // FileSize
            // 
            this.FileSize.Text = "サイズ";
            this.FileSize.Width = 50;
            // 
            // Updated
            // 
            this.Updated.Text = "更新日時";
            this.Updated.Width = 200;
            // 
            // pnlSide2
            // 
            this.pnlSide2.Controls.Add(this.tabCtrlSide2);
            this.pnlSide2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSide2.Location = new System.Drawing.Point(0, 0);
            this.pnlSide2.Name = "pnlSide2";
            this.pnlSide2.Size = new System.Drawing.Size(523, 310);
            this.pnlSide2.TabIndex = 1;
            // 
            // tabCtrlSide2
            // 
            this.tabCtrlSide2.Controls.Add(this.tabList2);
            this.tabCtrlSide2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlSide2.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlSide2.Name = "tabCtrlSide2";
            this.tabCtrlSide2.SelectedIndex = 0;
            this.tabCtrlSide2.Size = new System.Drawing.Size(523, 310);
            this.tabCtrlSide2.TabIndex = 0;
            this.tabCtrlSide2.TabStop = false;
            // 
            // tabList2
            // 
            this.tabList2.Controls.Add(this.listView2);
            this.tabList2.Location = new System.Drawing.Point(4, 22);
            this.tabList2.Name = "tabList2";
            this.tabList2.Padding = new System.Windows.Forms.Padding(3);
            this.tabList2.Size = new System.Drawing.Size(515, 284);
            this.tabList2.TabIndex = 0;
            this.tabList2.Text = "タブ2";
            this.tabList2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.Updated2});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(509, 278);
            this.listView2.TabIndex = 0;
            this.listView2.TargetDir = null;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Head";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "選択";
            this.columnHeader1.Width = 32;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ファイル名";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "拡張子";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "サイズ";
            this.columnHeader4.Width = 50;
            // 
            // Updated2
            // 
            this.Updated2.Text = "更新日時";
            this.Updated2.Width = 200;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "FOLDER02.ICO");
            this.imageList.Images.SetKeyName(1, "NOTE11.ICO");
            this.imageList.Images.SetKeyName(2, "FOLDER05.ICO");
            this.imageList.Images.SetKeyName(3, "CLIP08.ICO");
            // 
            // timerTopMost
            // 
            this.timerTopMost.Enabled = true;
            this.timerTopMost.Interval = 250;
            this.timerTopMost.Tick += new System.EventHandler(this.timerTopMost_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 147);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupFiler);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlBottom);
            this.splitContainer1.Size = new System.Drawing.Size(1003, 479);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupFiler
            // 
            this.groupFiler.Controls.Add(this.splitContainer2);
            this.groupFiler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFiler.Location = new System.Drawing.Point(0, 0);
            this.groupFiler.Name = "groupFiler";
            this.groupFiler.Size = new System.Drawing.Size(1003, 328);
            this.groupFiler.TabIndex = 3;
            this.groupFiler.TabStop = false;
            this.groupFiler.Text = "ファイラー(&L)";
            this.groupFiler.Enter += new System.EventHandler(this.groupFiler_Enter);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 15);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlSide1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnlSide2);
            this.splitContainer2.Size = new System.Drawing.Size(997, 310);
            this.splitContainer2.SplitterDistance = 470;
            this.splitContainer2.TabIndex = 2;
            // 
            // frmKeyCommander
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 626);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKeyCommander";
            this.Text = "KeyCommander";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKCommander_FormClosing);
            this.Load += new System.EventHandler(this.frmKCommander_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKCommander_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmKCommander_KeyPress);
            this.Resize += new System.EventHandler(this.frmKCommander_Resize);
            this.pnlTop.ResumeLayout(false);
            this.grpDir.ResumeLayout(false);
            this.grpCommandLine.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.panelSideButton.ResumeLayout(false);
            this.pnlSide1.ResumeLayout(false);
            this.tabCtrlSide1.ResumeLayout(false);
            this.tabList1.ResumeLayout(false);
            this.pnlSide2.ResumeLayout(false);
            this.tabCtrlSide2.ResumeLayout(false);
            this.tabList2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupFiler.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        public System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlSide1;
        private System.Windows.Forms.Panel pnlSide2;
        private System.Windows.Forms.TabControl tabCtrlSide1;
        private System.Windows.Forms.TabPage tabList1;
        private System.Windows.Forms.TabControl tabCtrlSide2;
        private System.Windows.Forms.TabPage tabList2;
        private MyDirListView listView1;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Ext;
        private System.Windows.Forms.ColumnHeader FileSize;
        private System.Windows.Forms.Button btnSetCmbDir;
        private MyDirCombo cmbDir;
        private System.Windows.Forms.Button btnShowIntotab;
        private System.Windows.Forms.ColumnHeader Flag;
        private MyDirListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnShowIntoTab2;
        private System.Windows.Forms.ColumnHeader colHead;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Timer timerTopMost;
        private System.Windows.Forms.ColumnHeader Updated;
        private System.Windows.Forms.ColumnHeader Updated2;
        private System.Windows.Forms.Button btnExecTab2;
        private System.Windows.Forms.Button btnExecTab1;
        private System.Windows.Forms.Button btnClearCommandHistory;
        private KCommander.UserClasses.MyCommandLineCombo cmbCommandLine;
        private System.Windows.Forms.Button btnClearCurrentHistory;
        private System.Windows.Forms.TextBox textBoxHelp;
        private System.Windows.Forms.Panel panelSideButton;
        private System.Windows.Forms.Button buttonCommandLineHelp;
        private System.Windows.Forms.Button buttonKeyHelp;
        private System.Windows.Forms.Button buttonValiableHelp;
        private System.Windows.Forms.GroupBox grpDir;
        private System.Windows.Forms.GroupBox grpCommandLine;
        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnClearDirHistory;
        private System.Windows.Forms.Button btnClearCurrentDirHistory;
        private System.Windows.Forms.GroupBox groupFiler;
    }
}

