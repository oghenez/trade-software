namespace Tools.Forms
{
    partial class strategyRanking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(strategyRanking));
            this.myTmpDS = new data.tmpDS();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.codeListLb = new baseClass.controls.stockCodeSelect();
            this.timeScaleLbl = new baseClass.controls.baseLabel();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            this.allTimeRangeChk = new System.Windows.Forms.CheckBox();
            this.codeListLbl = new baseClass.controls.baseLabel();
            this.timeRangeLb = new baseClass.controls.clbTimeRange();
            this.strategyLbl = new baseClass.controls.baseLabel();
            this.strategyClb = new baseClass.controls.strategySelect();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.profitDetailMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.allProfitDetailMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addToWatchListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fullViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportResultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultTab = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            this.optionPnl.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1143, 7);
            this.TitleLbl.Size = new System.Drawing.Size(161, 24);
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // optionPnl
            // 
            this.optionPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.optionPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPnl.Controls.Add(this.codeListLb);
            this.optionPnl.Controls.Add(this.timeScaleLbl);
            this.optionPnl.Controls.Add(this.timeScaleCb);
            this.optionPnl.Controls.Add(this.allTimeRangeChk);
            this.optionPnl.Controls.Add(this.codeListLbl);
            this.optionPnl.Controls.Add(this.timeRangeLb);
            this.optionPnl.Controls.Add(this.strategyLbl);
            this.optionPnl.Controls.Add(this.strategyClb);
            this.optionPnl.Location = new System.Drawing.Point(0, 25);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(471, 651);
            this.optionPnl.TabIndex = 315;
            // 
            // codeListLb
            // 
            this.codeListLb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codeListLb.Location = new System.Drawing.Point(21, 383);
            this.codeListLb.Margin = new System.Windows.Forms.Padding(2);
            this.codeListLb.myItemString = "";
            this.codeListLb.myValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("codeListLb.myValues")));
            this.codeListLb.Name = "codeListLb";
            this.codeListLb.ShowCheckedOnly = false;
            this.codeListLb.Size = new System.Drawing.Size(426, 263);
            this.codeListLb.TabIndex = 30;
            // 
            // timeScaleLbl
            // 
            this.timeScaleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScaleLbl.AutoSize = true;
            this.timeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleLbl.Location = new System.Drawing.Point(268, 7);
            this.timeScaleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeScaleLbl.Name = "timeScaleLbl";
            this.timeScaleLbl.Size = new System.Drawing.Size(74, 16);
            this.timeScaleLbl.TabIndex = 327;
            this.timeScaleLbl.Text = "Time scale";
            // 
            // timeScaleCb
            // 
            this.timeScaleCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(346, 4);
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.Size = new System.Drawing.Size(102, 24);
            this.timeScaleCb.TabIndex = 2;
            // 
            // allTimeRangeChk
            // 
            this.allTimeRangeChk.AutoSize = true;
            this.allTimeRangeChk.Location = new System.Drawing.Point(25, 4);
            this.allTimeRangeChk.Name = "allTimeRangeChk";
            this.allTimeRangeChk.Size = new System.Drawing.Size(92, 21);
            this.allTimeRangeChk.TabIndex = 1;
            this.allTimeRangeChk.Text = "Periodicity";
            this.allTimeRangeChk.UseVisualStyleBackColor = true;
            this.allTimeRangeChk.CheckedChanged += new System.EventHandler(this.allTimeRangeChk_CheckedChanged);
            // 
            // codeListLbl
            // 
            this.codeListLbl.AutoSize = true;
            this.codeListLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeListLbl.Location = new System.Drawing.Point(21, 365);
            this.codeListLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codeListLbl.Name = "codeListLbl";
            this.codeListLbl.Size = new System.Drawing.Size(63, 16);
            this.codeListLbl.TabIndex = 326;
            this.codeListLbl.Text = "Code list";
            // 
            // timeRangeLb
            // 
            this.timeRangeLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timeRangeLb.CheckOnClick = true;
            this.timeRangeLb.FormattingEnabled = true;
            this.timeRangeLb.Location = new System.Drawing.Point(22, 27);
            this.timeRangeLb.MultiColumn = true;
            this.timeRangeLb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("timeRangeLb.myCheckedItems")));
            this.timeRangeLb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("timeRangeLb.myCheckedValues")));
            this.timeRangeLb.myItemString = "";
            this.timeRangeLb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("timeRangeLb.myItemValues")));
            this.timeRangeLb.Name = "timeRangeLb";
            this.timeRangeLb.ShowCheckedOnly = false;
            this.timeRangeLb.Size = new System.Drawing.Size(426, 76);
            this.timeRangeLb.TabIndex = 10;
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(22, 108);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(66, 16);
            this.strategyLbl.TabIndex = 315;
            this.strategyLbl.Text = "Strategy";
            // 
            // strategyClb
            // 
            this.strategyClb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.strategyClb.Location = new System.Drawing.Point(22, 127);
            this.strategyClb.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.strategyClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyClb.myCheckedValues")));
            this.strategyClb.myItemString = "";
            this.strategyClb.Name = "strategyClb";
            this.strategyClb.Size = new System.Drawing.Size(428, 230);
            this.strategyClb.TabIndex = 20;
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1050, 24);
            this.menuStrip.TabIndex = 316;
            // 
            // mainMenuItem
            // 
            this.mainMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runMenuItem,
            this.toolStripSeparator2,
            this.openMenuItem,
            this.toolStripSeparator5,
            this.profitDetailMenu,
            this.allProfitDetailMenu,
            this.toolStripSeparator4,
            this.addToWatchListMenuItem,
            this.toolStripSeparator1,
            this.fullViewMenuItem,
            this.toolStripSeparator3,
            this.exportResultMenuItem});
            this.mainMenuItem.Name = "mainMenuItem";
            this.mainMenuItem.Size = new System.Drawing.Size(133, 20);
            this.mainMenuItem.Text = "Strategy Ranking";
            // 
            // runMenuItem
            // 
            this.runMenuItem.Name = "runMenuItem";
            this.runMenuItem.Size = new System.Drawing.Size(193, 22);
            this.runMenuItem.Text = "Run";
            this.runMenuItem.Click += new System.EventHandler(this.runMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(193, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(190, 6);
            // 
            // profitDetailMenu
            // 
            this.profitDetailMenu.Name = "profitDetailMenu";
            this.profitDetailMenu.Size = new System.Drawing.Size(193, 22);
            this.profitDetailMenu.Text = "Profit Details";
            this.profitDetailMenu.Click += new System.EventHandler(this.profitDetailMenu_Click);
            // 
            // allProfitDetailMenu
            // 
            this.allProfitDetailMenu.Name = "allProfitDetailMenu";
            this.allProfitDetailMenu.Size = new System.Drawing.Size(193, 22);
            this.allProfitDetailMenu.Text = "All Profit Details";
            this.allProfitDetailMenu.Click += new System.EventHandler(this.allProfitDetailMenu_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(190, 6);
            // 
            // addToWatchListMenuItem
            // 
            this.addToWatchListMenuItem.Name = "addToWatchListMenuItem";
            this.addToWatchListMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addToWatchListMenuItem.Text = "To Watch List";
            this.addToWatchListMenuItem.Click += new System.EventHandler(this.addToWatchListMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // fullViewMenuItem
            // 
            this.fullViewMenuItem.Name = "fullViewMenuItem";
            this.fullViewMenuItem.Size = new System.Drawing.Size(193, 22);
            this.fullViewMenuItem.Text = "Full View";
            this.fullViewMenuItem.Click += new System.EventHandler(this.fullViewMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // exportResultMenuItem
            // 
            this.exportResultMenuItem.Name = "exportResultMenuItem";
            this.exportResultMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exportResultMenuItem.Text = "Export";
            this.exportResultMenuItem.Click += new System.EventHandler(this.exportResultMenuItem_Click);
            // 
            // resultTab
            // 
            this.resultTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTab.Location = new System.Drawing.Point(475, 1);
            this.resultTab.Name = "resultTab";
            this.resultTab.SelectedIndex = 0;
            this.resultTab.Size = new System.Drawing.Size(576, 674);
            this.resultTab.TabIndex = 317;
            // 
            // strategyRanking
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1050, 702);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.resultTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "strategyRanking";
            this.Text = "Strategy Ranking";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.Controls.SetChildIndex(this.resultTab, 0);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private data.tmpDS myTmpDS;
        protected System.Windows.Forms.Panel optionPnl;
        protected baseClass.controls.baseLabel strategyLbl;
        protected baseClass.controls.strategySelect strategyClb;
        protected System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullViewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToWatchListMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected baseClass.controls.clbTimeRange timeRangeLb;
        protected System.Windows.Forms.CheckBox allTimeRangeChk;
        private System.Windows.Forms.ToolStripMenuItem profitDetailMenu;
        protected System.Windows.Forms.TabControl resultTab;
        protected baseClass.controls.baseLabel codeListLbl;
        protected baseClass.controls.cbTimeScale timeScaleCb;
        protected baseClass.controls.baseLabel timeScaleLbl;
        private baseClass.controls.stockCodeSelect codeListLb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem allProfitDetailMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
