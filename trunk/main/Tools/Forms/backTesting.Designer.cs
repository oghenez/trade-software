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
            this.resultDataGrid = new common.controls.baseDataGridView();
            this.dateRangeLbl = new baseClass.controls.baseLabel();
            this.dateRangeEd = new baseClass.controls.chartTiming();
            this.myTmpDS = new data.tmpDS();
            this.dataPnl = new System.Windows.Forms.Panel();
            this.strategyEstimationPnl = new common.controls.basePanel();
            this.strategyEstimationGrid = new common.controls.baseDataGridView();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.stockCodeSelectLb = new baseClass.controls.stockCodeSelect();
            this.stockCodeLbl = new baseClass.controls.baseLabel();
            this.strategyLbl = new baseClass.controls.baseLabel();
            this.strategyClb = new baseClass.controls.strategySelect();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profitDetailMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.allProfitDetailMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addToWatchListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fullViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estimationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportResultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportEstimationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dateRangeLbl.Location = new System.Drawing.Point(22, 3);
            this.dateRangeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateRangeLbl.Name = "dateRangeLbl";
            this.dateRangeLbl.Size = new System.Drawing.Size(76, 16);
            this.dateRangeLbl.TabIndex = 311;
            this.dateRangeLbl.Text = "Periodicity";
            // 
            // dateRangeEd
            // 
            this.dateRangeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeEd.Location = new System.Drawing.Point(21, 21);
            this.dateRangeEd.myTimeRange = application.AppTypes.TimeRanges.Y5;
            this.dateRangeEd.Name = "dateRangeEd";
            this.dateRangeEd.Size = new System.Drawing.Size(378, 24);
            this.dateRangeEd.TabIndex = 1;
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
            this.strategyEstimationPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.strategyEstimationPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.strategyEstimationPnl.myWeight = 0;
            this.strategyEstimationPnl.Name = "strategyEstimationPnl";
            this.strategyEstimationPnl.Size = new System.Drawing.Size(412, 159);
            this.strategyEstimationPnl.TabIndex = 311;
            this.strategyEstimationPnl.myOnClosing += new common.controls.basePanel.OnClosing(this.strategyEstimationPnl_myOnClosing);
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
            this.optionPnl.Controls.Add(this.stockCodeSelectLb);
            this.optionPnl.Controls.Add(this.stockCodeLbl);
            this.optionPnl.Controls.Add(this.strategyLbl);
            this.optionPnl.Controls.Add(this.strategyClb);
            this.optionPnl.Controls.Add(this.dateRangeEd);
            this.optionPnl.Controls.Add(this.dateRangeLbl);
            this.optionPnl.Location = new System.Drawing.Point(2, 30);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(428, 654);
            this.optionPnl.TabIndex = 315;
            // 
            // stockCodeSelectLb
            // 
            this.stockCodeSelectLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.stockCodeSelectLb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeSelectLb.Location = new System.Drawing.Point(21, 250);
            this.stockCodeSelectLb.Margin = new System.Windows.Forms.Padding(2);
            this.stockCodeSelectLb.myItemString = "";
            this.stockCodeSelectLb.myValues = ((System.Collections.Specialized.StringCollection)(resources.GetObject("stockCodeSelectLb.myValues")));
            this.stockCodeSelectLb.Name = "stockCodeSelectLb";
            this.stockCodeSelectLb.ShowCheckedOnly = false;
            this.stockCodeSelectLb.Size = new System.Drawing.Size(379, 398);
            this.stockCodeSelectLb.TabIndex = 5;
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLbl.Location = new System.Drawing.Point(22, 232);
            this.stockCodeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(63, 16);
            this.stockCodeLbl.TabIndex = 318;
            this.stockCodeLbl.Text = "Code list";
            // 
            // strategyLbl
            // 
            this.strategyLbl.AutoSize = true;
            this.strategyLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyLbl.Location = new System.Drawing.Point(22, 50);
            this.strategyLbl.Name = "strategyLbl";
            this.strategyLbl.Size = new System.Drawing.Size(66, 16);
            this.strategyLbl.TabIndex = 315;
            this.strategyLbl.Text = "Strategy";
            // 
            // strategyClb
            // 
            this.strategyClb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyClb.Location = new System.Drawing.Point(21, 68);
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
            this.profitDetailMenu,
            this.allProfitDetailMenu,
            this.addToWatchListMenuItem,
            this.toolStripSeparator1,
            this.fullViewMenuItem,
            this.estimationMenuItem,
            this.toolStripSeparator3,
            this.exportResultMenuItem,
            this.exportEstimationMenuItem});
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
            // profitDetailMenu
            // 
            this.profitDetailMenu.Name = "profitDetailMenu";
            this.profitDetailMenu.Size = new System.Drawing.Size(202, 22);
            this.profitDetailMenu.Text = "Profit Details";
            this.profitDetailMenu.Click += new System.EventHandler(this.profitDetailMenu_Click);
            // 
            // allProfitDetailMenu
            // 
            this.allProfitDetailMenu.Name = "allProfitDetailMenu";
            this.allProfitDetailMenu.Size = new System.Drawing.Size(202, 22);
            this.allProfitDetailMenu.Text = "All Profit Details";
            this.allProfitDetailMenu.Click += new System.EventHandler(this.allProfitDetailMenu_Click);
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
            // backTesting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(842, 709);
            this.Controls.Add(this.dataPnl);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        protected common.controls.baseDataGridView resultDataGrid;
        protected baseClass.controls.baseLabel dateRangeLbl;
        protected baseClass.controls.chartTiming dateRangeEd;
        private data.tmpDS myTmpDS;
        protected System.Windows.Forms.Panel dataPnl;
        protected common.controls.baseDataGridView strategyEstimationGrid;
        protected System.Windows.Forms.Panel optionPnl;
        protected baseClass.controls.baseLabel strategyLbl;
        protected baseClass.controls.strategySelect strategyClb;
        protected baseClass.controls.baseLabel stockCodeLbl;
        protected System.Windows.Forms.MenuStrip menuStrip;
        private common.controls.basePanel strategyEstimationPnl;
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
        private System.Windows.Forms.ToolStripMenuItem allProfitDetailMenu;
        private baseClass.controls.stockCodeSelect stockCodeSelectLb;
        private System.Windows.Forms.ToolStripMenuItem profitDetailMenu;
    }
}
