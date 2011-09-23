namespace Tools.Forms
{
    partial class stockRanking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockRanking));
            this.myTmpDS = new data.tmpDS();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.timeScaleLbl = new baseClass.controls.baseLabel();
            this.stockCodeLbl = new baseClass.controls.baseLabel();
            this.cbTimeScale = new baseClass.controls.cbTimeScale();
            this.stockCodeOptionCb = new common.control.baseComboBox();
            this.watchListCb = new baseClass.controls.cbWatchList();
            this.stockCodeSelect = new baseClass.controls.stockCodeSelect();
            this.allTimeRangeChk = new System.Windows.Forms.CheckBox();
            this.timeRangeLb = new baseClass.controls.clbTimeRange();
            this.strategyLbl = new baseClass.controls.baseLabel();
            this.strategyClb = new baseClass.controls.strategySelect();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profitEstimateMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.optionPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPnl.Controls.Add(this.timeScaleLbl);
            this.optionPnl.Controls.Add(this.stockCodeLbl);
            this.optionPnl.Controls.Add(this.cbTimeScale);
            this.optionPnl.Controls.Add(this.stockCodeOptionCb);
            this.optionPnl.Controls.Add(this.watchListCb);
            this.optionPnl.Controls.Add(this.stockCodeSelect);
            this.optionPnl.Controls.Add(this.allTimeRangeChk);
            this.optionPnl.Controls.Add(this.timeRangeLb);
            this.optionPnl.Controls.Add(this.strategyLbl);
            this.optionPnl.Controls.Add(this.strategyClb);
            this.optionPnl.Location = new System.Drawing.Point(0, 25);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(455, 651);
            this.optionPnl.TabIndex = 315;
            // 
            // timeScaleLbl
            // 
            this.timeScaleLbl.AutoSize = true;
            this.timeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleLbl.Location = new System.Drawing.Point(276, 279);
            this.timeScaleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeScaleLbl.Name = "timeScaleLbl";
            this.timeScaleLbl.Size = new System.Drawing.Size(52, 16);
            this.timeScaleLbl.TabIndex = 327;
            this.timeScaleLbl.Text = "Dữ liệu";
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLbl.Location = new System.Drawing.Point(21, 9);
            this.stockCodeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(156, 16);
            this.stockCodeLbl.TabIndex = 326;
            this.stockCodeLbl.Text = "Danh sách mã cổ phiếu";
            // 
            // cbTimeScale
            // 
            this.cbTimeScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeScale.FormattingEnabled = true;
            this.cbTimeScale.Location = new System.Drawing.Point(329, 277);
            this.cbTimeScale.Name = "cbTimeScale";
            this.cbTimeScale.Size = new System.Drawing.Size(102, 21);
            this.cbTimeScale.TabIndex = 323;
            // 
            // stockCodeOptionCb
            // 
            this.stockCodeOptionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockCodeOptionCb.FormattingEnabled = true;
            this.stockCodeOptionCb.Items.AddRange(new object[] {
            "Watch List",
            "Portfolio",
            "Tùy chọn"});
            this.stockCodeOptionCb.Location = new System.Drawing.Point(21, 29);
            this.stockCodeOptionCb.myValue = "";
            this.stockCodeOptionCb.Name = "stockCodeOptionCb";
            this.stockCodeOptionCb.Size = new System.Drawing.Size(130, 21);
            this.stockCodeOptionCb.TabIndex = 323;
            this.stockCodeOptionCb.SelectionChangeCommitted += new System.EventHandler(this.stockCodeOptionCb_SelectionChangeCommitted);
            // 
            // watchListCb
            // 
            this.watchListCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.watchListCb.FormattingEnabled = true;
            this.watchListCb.Location = new System.Drawing.Point(150, 29);
            this.watchListCb.myValue = "";
            this.watchListCb.Name = "watchListCb";
            this.watchListCb.Size = new System.Drawing.Size(279, 21);
            this.watchListCb.TabIndex = 324;
            this.watchListCb.WatchType = application.AppTypes.PortfolioTypes.Portfolio;
            // 
            // stockCodeSelect
            // 
            this.stockCodeSelect.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeSelect.Location = new System.Drawing.Point(21, 50);
            this.stockCodeSelect.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.stockCodeSelect.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeSelect.myCheckedValues")));
            this.stockCodeSelect.myItemString = "";
            this.stockCodeSelect.Name = "stockCodeSelect";
            this.stockCodeSelect.ShowCheckedOnly = false;
            this.stockCodeSelect.Size = new System.Drawing.Size(408, 217);
            this.stockCodeSelect.TabIndex = 325;
            // 
            // allTimeRangeChk
            // 
            this.allTimeRangeChk.AutoSize = true;
            this.allTimeRangeChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.allTimeRangeChk.Location = new System.Drawing.Point(24, 276);
            this.allTimeRangeChk.Name = "allTimeRangeChk";
            this.allTimeRangeChk.Size = new System.Drawing.Size(84, 20);
            this.allTimeRangeChk.TabIndex = 2;
            this.allTimeRangeChk.Text = "Thời gian";
            this.allTimeRangeChk.UseVisualStyleBackColor = true;
            this.allTimeRangeChk.CheckedChanged += new System.EventHandler(this.allTimeRangeChk_CheckedChanged);
            // 
            // timeRangeLb
            // 
            this.timeRangeLb.CheckOnClick = true;
            this.timeRangeLb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeRangeLb.FormattingEnabled = true;
            this.timeRangeLb.Location = new System.Drawing.Point(21, 299);
            this.timeRangeLb.MultiColumn = true;
            this.timeRangeLb.myCheckedItems = ((System.Collections.ArrayList)(resources.GetObject("timeRangeLb.myCheckedItems")));
            this.timeRangeLb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("timeRangeLb.myCheckedValues")));
            this.timeRangeLb.myItemString = "";
            this.timeRangeLb.myItemValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("timeRangeLb.myItemValues")));
            this.timeRangeLb.Name = "timeRangeLb";
            this.timeRangeLb.ShowCheckedOnly = false;
            this.timeRangeLb.Size = new System.Drawing.Size(408, 76);
            this.timeRangeLb.TabIndex = 10;
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(21, 381);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(74, 16);
            this.strategyLbl.TabIndex = 315;
            this.strategyLbl.Text = "Chiến lược";
            // 
            // strategyClb
            // 
            this.strategyClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyClb.Location = new System.Drawing.Point(21, 398);
            this.strategyClb.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.strategyClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyClb.myCheckedValues")));
            this.strategyClb.myItemString = "";
            this.strategyClb.Name = "strategyClb";
            this.strategyClb.Size = new System.Drawing.Size(410, 246);
            this.strategyClb.TabIndex = 20;
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1021, 24);
            this.menuStrip.TabIndex = 316;
            // 
            // mainMenuItem
            // 
            this.mainMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runMenuItem,
            this.toolStripSeparator2,
            this.openMenuItem,
            this.profitEstimateMenu,
            this.addToWatchListMenuItem,
            this.toolStripSeparator1,
            this.fullViewMenuItem,
            this.toolStripSeparator3,
            this.exportResultMenuItem});
            this.mainMenuItem.Name = "mainMenuItem";
            this.mainMenuItem.Size = new System.Drawing.Size(111, 20);
            this.mainMenuItem.Text = "Stock Ranking";
            // 
            // runMenuItem
            // 
            this.runMenuItem.Name = "runMenuItem";
            this.runMenuItem.Size = new System.Drawing.Size(196, 22);
            this.runMenuItem.Text = "Run";
            this.runMenuItem.Click += new System.EventHandler(this.runMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // profitEstimateMenu
            // 
            this.profitEstimateMenu.Name = "profitEstimateMenu";
            this.profitEstimateMenu.Size = new System.Drawing.Size(196, 22);
            this.profitEstimateMenu.Text = "Profit Estimation";
            this.profitEstimateMenu.Click += new System.EventHandler(this.profitEstimateMenu_Click);
            // 
            // addToWatchListMenuItem
            // 
            this.addToWatchListMenuItem.Name = "addToWatchListMenuItem";
            this.addToWatchListMenuItem.Size = new System.Drawing.Size(196, 22);
            this.addToWatchListMenuItem.Text = "To Watch List";
            this.addToWatchListMenuItem.Click += new System.EventHandler(this.addToWatchListMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // fullViewMenuItem
            // 
            this.fullViewMenuItem.Name = "fullViewMenuItem";
            this.fullViewMenuItem.Size = new System.Drawing.Size(196, 22);
            this.fullViewMenuItem.Text = "Full View";
            this.fullViewMenuItem.Click += new System.EventHandler(this.fullViewMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(193, 6);
            // 
            // exportResultMenuItem
            // 
            this.exportResultMenuItem.Name = "exportResultMenuItem";
            this.exportResultMenuItem.Size = new System.Drawing.Size(196, 22);
            this.exportResultMenuItem.Text = "Export";
            this.exportResultMenuItem.Click += new System.EventHandler(this.exportResultMenuItem_Click);
            // 
            // resultTab
            // 
            this.resultTab.Location = new System.Drawing.Point(457, 24);
            this.resultTab.Name = "resultTab";
            this.resultTab.SelectedIndex = 0;
            this.resultTab.Size = new System.Drawing.Size(566, 656);
            this.resultTab.TabIndex = 317;
            // 
            // stockRanking
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1021, 702);
            this.Controls.Add(this.resultTab);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "stockRanking";
            this.Text = "Stock Ranking";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.resultTab, 0);
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
        private System.Windows.Forms.ToolStripMenuItem profitEstimateMenu;
        protected System.Windows.Forms.TabControl resultTab;
        protected baseClass.controls.baseLabel stockCodeLbl;
        protected common.control.baseComboBox stockCodeOptionCb;
        protected baseClass.controls.cbWatchList watchListCb;
        protected baseClass.controls.stockCodeSelect stockCodeSelect;
        protected baseClass.controls.cbTimeScale cbTimeScale;
        protected baseClass.controls.baseLabel timeScaleLbl;
    }
}
