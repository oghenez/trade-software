namespace Tools.Forms
{
    partial class backTesting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(backTesting));
            this.resultDataGrid = new common.control.baseDataGridView();
            this.dateRangeLbl = new baseClass.controls.baseLabel();
            this.dateRangeEd = new baseClass.controls.chartTiming();
            this.stockCodeSelect = new baseClass.controls.stockCodeSelect();
            this.myTmpDS = new data.tmpDS();
            this.dataPnl = new System.Windows.Forms.Panel();
            this.strategyEstimationPnl = new common.control.basePanel();
            this.strategyEstimationGrid = new common.control.baseDataGridView();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.stockCodeLbl = new baseClass.controls.baseLabel();
            this.stockCodeOptionCb = new common.control.baseComboBox();
            this.watchListCb = new baseClass.controls.cbWatchList();
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
            this.estimationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportResultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportEstimationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            this.dataPnl.SuspendLayout();
            this.strategyEstimationPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strategyEstimationGrid)).BeginInit();
            this.optionPnl.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.AllowUserToAddRows = false;
            this.resultDataGrid.AllowUserToDeleteRows = false;
            this.resultDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGrid.DisableReadOnlyColumn = true;
            this.resultDataGrid.Location = new System.Drawing.Point(-1, -1);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.ReadOnly = true;
            this.resultDataGrid.Size = new System.Drawing.Size(408, 342);
            this.resultDataGrid.TabIndex = 309;
            this.resultDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            this.resultDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // dateRangeLbl
            // 
            this.dateRangeLbl.AutoSize = true;
            this.dateRangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeLbl.Location = new System.Drawing.Point(22, 6);
            this.dateRangeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateRangeLbl.Name = "dateRangeLbl";
            this.dateRangeLbl.Size = new System.Drawing.Size(65, 16);
            this.dateRangeLbl.TabIndex = 311;
            this.dateRangeLbl.Text = "Thời gian";
            // 
            // dateRangeEd
            // 
            this.dateRangeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeEd.Location = new System.Drawing.Point(21, 24);
            this.dateRangeEd.Name = "dateRangeEd";
            this.dateRangeEd.Size = new System.Drawing.Size(378, 24);
            this.dateRangeEd.TabIndex = 1;
            // 
            // stockCodeSelect
            // 
            this.stockCodeSelect.Enabled = false;
            this.stockCodeSelect.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeSelect.Location = new System.Drawing.Point(22, 282);
            this.stockCodeSelect.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.stockCodeSelect.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeSelect.myCheckedValues")));
            this.stockCodeSelect.myItemString = "";
            this.stockCodeSelect.Name = "stockCodeSelect";
            this.stockCodeSelect.ShowCheckedOnly = false;
            this.stockCodeSelect.Size = new System.Drawing.Size(377, 361);
            this.stockCodeSelect.TabIndex = 30;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataPnl
            // 
            this.dataPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataPnl.Controls.Add(this.strategyEstimationPnl);
            this.dataPnl.Controls.Add(this.resultDataGrid);
            this.dataPnl.Location = new System.Drawing.Point(433, 30);
            this.dataPnl.Name = "dataPnl";
            this.dataPnl.Size = new System.Drawing.Size(413, 654);
            this.dataPnl.TabIndex = 314;
            // 
            // strategyEstimationPnl
            // 
            this.strategyEstimationPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.strategyEstimationPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.strategyEstimationPnl.Controls.Add(this.strategyEstimationGrid);
            this.strategyEstimationPnl.haveCloseButton = true;
            this.strategyEstimationPnl.isExpanded = true;
            this.strategyEstimationPnl.isVisible = true;
            this.strategyEstimationPnl.Location = new System.Drawing.Point(-1, 493);
            this.strategyEstimationPnl.myIconLocations = common.control.basePanel.IconLocations.None;
            this.strategyEstimationPnl.mySizingOptions = common.control.basePanel.SizingOptions.None;
            this.strategyEstimationPnl.myWeight = 0;
            this.strategyEstimationPnl.Name = "strategyEstimationPnl";
            this.strategyEstimationPnl.Size = new System.Drawing.Size(412, 159);
            this.strategyEstimationPnl.TabIndex = 311;
            this.strategyEstimationPnl.myOnClosing += new common.control.basePanel.OnClosing(this.strategyEstimationPnl_myOnClosing);
            // 
            // strategyEstimationGrid
            // 
            this.strategyEstimationGrid.AllowUserToAddRows = false;
            this.strategyEstimationGrid.AllowUserToDeleteRows = false;
            this.strategyEstimationGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.strategyEstimationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.strategyEstimationGrid.DisableReadOnlyColumn = false;
            this.strategyEstimationGrid.Location = new System.Drawing.Point(-2, -2);
            this.strategyEstimationGrid.Name = "strategyEstimationGrid";
            this.strategyEstimationGrid.ReadOnly = true;
            this.strategyEstimationGrid.Size = new System.Drawing.Size(403, 156);
            this.strategyEstimationGrid.TabIndex = 310;
            // 
            // optionPnl
            // 
            this.optionPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionPnl.Controls.Add(this.stockCodeLbl);
            this.optionPnl.Controls.Add(this.stockCodeOptionCb);
            this.optionPnl.Controls.Add(this.watchListCb);
            this.optionPnl.Controls.Add(this.strategyLbl);
            this.optionPnl.Controls.Add(this.strategyClb);
            this.optionPnl.Controls.Add(this.dateRangeEd);
            this.optionPnl.Controls.Add(this.dateRangeLbl);
            this.optionPnl.Controls.Add(this.stockCodeSelect);
            this.optionPnl.Location = new System.Drawing.Point(2, 30);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(428, 654);
            this.optionPnl.TabIndex = 315;
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLbl.Location = new System.Drawing.Point(22, 235);
            this.stockCodeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(156, 16);
            this.stockCodeLbl.TabIndex = 318;
            this.stockCodeLbl.Text = "Danh sách mã cổ phiếu";
            // 
            // stockCodeOptionCb
            // 
            this.stockCodeOptionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockCodeOptionCb.FormattingEnabled = true;
            this.stockCodeOptionCb.Items.AddRange(new object[] {
            "Watch List",
            "Portfolio",
            "Tùy chọn"});
            this.stockCodeOptionCb.Location = new System.Drawing.Point(22, 255);
            this.stockCodeOptionCb.myValue = "";
            this.stockCodeOptionCb.Name = "stockCodeOptionCb";
            this.stockCodeOptionCb.Size = new System.Drawing.Size(130, 21);
            this.stockCodeOptionCb.TabIndex = 20;
            this.stockCodeOptionCb.SelectionChangeCommitted += new System.EventHandler(this.stockCodeOptionCb_SelectionChangeCommitted);
            // 
            // watchListCb
            // 
            this.watchListCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.watchListCb.FormattingEnabled = true;
            this.watchListCb.Location = new System.Drawing.Point(151, 255);
            this.watchListCb.myValue = "";
            this.watchListCb.Name = "watchListCb";
            this.watchListCb.Size = new System.Drawing.Size(248, 21);
            this.watchListCb.TabIndex = 21;
            this.watchListCb.WatchType = application.AppTypes.PortfolioTypes.Portfolio;
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(22, 53);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(74, 16);
            this.strategyLbl.TabIndex = 315;
            this.strategyLbl.Text = "Chiến lược";
            // 
            // strategyClb
            // 
            this.strategyClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyClb.Location = new System.Drawing.Point(21, 71);
            this.strategyClb.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.strategyClb.myCheckedValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("strategyClb.myCheckedValues")));
            this.strategyClb.myItemString = "";
            this.strategyClb.Name = "strategyClb";
            this.strategyClb.Size = new System.Drawing.Size(378, 156);
            this.strategyClb.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(842, 24);
            this.menuStrip.TabIndex = 316;
            this.menuStrip.Text = "menuStrip1";
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
            this.estimationMenuItem,
            this.toolStripSeparator3,
            this.exportResultMenuItem,
            this.exportEstimationMenuItem,
            this.toolStripSeparator4,
            this.optionsMenuItem});
            this.mainMenuItem.Name = "mainMenuItem";
            this.mainMenuItem.Size = new System.Drawing.Size(101, 20);
            this.mainMenuItem.Text = "Back Testing";
            // 
            // runMenuItem
            // 
            this.runMenuItem.Name = "runMenuItem";
            this.runMenuItem.Size = new System.Drawing.Size(202, 22);
            this.runMenuItem.Text = "Run";
            this.runMenuItem.Click += new System.EventHandler(this.runMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(202, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // profitEstimateMenu
            // 
            this.profitEstimateMenu.Name = "profitEstimateMenu";
            this.profitEstimateMenu.Size = new System.Drawing.Size(202, 22);
            this.profitEstimateMenu.Text = "Profit Estimation";
            this.profitEstimateMenu.Click += new System.EventHandler(this.profitEstimateMenu_Click);
            // 
            // addToWatchListMenuItem
            // 
            this.addToWatchListMenuItem.Name = "addToWatchListMenuItem";
            this.addToWatchListMenuItem.Size = new System.Drawing.Size(202, 22);
            this.addToWatchListMenuItem.Text = "To Watch List";
            this.addToWatchListMenuItem.Click += new System.EventHandler(this.addToWatchListMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // fullViewMenuItem
            // 
            this.fullViewMenuItem.Name = "fullViewMenuItem";
            this.fullViewMenuItem.Size = new System.Drawing.Size(202, 22);
            this.fullViewMenuItem.Text = "Full View";
            this.fullViewMenuItem.Click += new System.EventHandler(this.fullViewMenuItem_Click);
            // 
            // estimationMenuItem
            // 
            this.estimationMenuItem.Name = "estimationMenuItem";
            this.estimationMenuItem.Size = new System.Drawing.Size(202, 22);
            this.estimationMenuItem.Text = "Show Estimation";
            this.estimationMenuItem.Click += new System.EventHandler(this.estimationMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // exportResultMenuItem
            // 
            this.exportResultMenuItem.Name = "exportResultMenuItem";
            this.exportResultMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exportResultMenuItem.Text = "Export Results";
            this.exportResultMenuItem.Click += new System.EventHandler(this.exportResultMenuItem_Click);
            // 
            // exportEstimationMenuItem
            // 
            this.exportEstimationMenuItem.Name = "exportEstimationMenuItem";
            this.exportEstimationMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exportEstimationMenuItem.Text = "Export Estimation";
            this.exportEstimationMenuItem.Click += new System.EventHandler(this.exportEstimationMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(199, 6);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(202, 22);
            this.optionsMenuItem.Text = "Options";
            this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // backTesting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(842, 709);
            this.Controls.Add(this.dataPnl);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "backTesting";
            this.Text = "Back Testing";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.backTesting_Resize);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.dataPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.dataPnl.ResumeLayout(false);
            this.strategyEstimationPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.strategyEstimationGrid)).EndInit();
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected common.control.baseDataGridView resultDataGrid;
        protected baseClass.controls.baseLabel dateRangeLbl;
        protected baseClass.controls.chartTiming dateRangeEd;
        protected baseClass.controls.stockCodeSelect stockCodeSelect;
        private data.tmpDS myTmpDS;
        protected System.Windows.Forms.Panel dataPnl;
        protected common.control.baseDataGridView strategyEstimationGrid;
        protected System.Windows.Forms.Panel optionPnl;
        protected baseClass.controls.baseLabel strategyLbl;
        protected baseClass.controls.strategySelect strategyClb;
        protected baseClass.controls.baseLabel stockCodeLbl;
        protected baseClass.controls.cbWatchList watchListCb;
        protected common.control.baseComboBox stockCodeOptionCb;
        protected System.Windows.Forms.MenuStrip menuStrip;
        private common.control.basePanel strategyEstimationPnl;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResultMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportEstimationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullViewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem estimationMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToWatchListMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem profitEstimateMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
    }
}
