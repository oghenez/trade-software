namespace tools.forms
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
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.testResultDataGrid = new common.control.baseDataGridView();
            this.myDataSet = new data.baseDS();
            this.dateRangeLbl = new baseClass.controls.baseLabel();
            this.dateRangeEd = new baseClass.controls.chartTiming();
            this.stockCodeSelect = new baseClass.controls.stockCodeSelect();
            this.myTmpDS = new data.tmpDS();
            this.mainToolbarPnl = new System.Windows.Forms.Panel();
            this.dataToolbarPnl = new System.Windows.Forms.Panel();
            this.exportStrategyStatsBtn = new baseClass.controls.baseButton();
            this.exportTestResultBtn = new baseClass.controls.baseButton();
            this.chartBtn = new baseClass.controls.baseButton();
            this.strategyEstimateBtn = new baseClass.controls.baseButton();
            this.oneStockEstimateBtn = new baseClass.controls.baseButton();
            this.fullScreenBtn = new baseClass.controls.baseButton();
            this.closeBtn = new baseClass.controls.baseButton();
            this.okBtn = new baseClass.controls.baseButton();
            this.optionBtn = new baseClass.controls.baseButton();
            this.dataPnl = new System.Windows.Forms.Panel();
            this.strategyEstDataGrid = new common.control.baseDataGridView();
            this.optionPnl = new System.Windows.Forms.Panel();
            this.stockCodeLbl = new baseClass.controls.baseLabel();
            this.stockCodeOptionCb = new common.control.baseComboBox();
            this.portfolioCb = new baseClass.controls.cbPortpolio();
            this.strategyLbl = new baseClass.controls.baseLabel();
            this.strategyClb = new baseClass.controls.strategySelect();
            ((System.ComponentModel.ISupportInitialize)(this.testResultDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            this.mainToolbarPnl.SuspendLayout();
            this.dataToolbarPnl.SuspendLayout();
            this.dataPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.strategyEstDataGrid)).BeginInit();
            this.optionPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1054, 7);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLbl.Size = new System.Drawing.Size(250, 24);
            this.TitleLbl.Text = "TÌM KIẾM";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.xls";
            this.saveFileDialog.Filter = "(*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // testResultDataGrid
            // 
            this.testResultDataGrid.AllowUserToAddRows = false;
            this.testResultDataGrid.AllowUserToDeleteRows = false;
            this.testResultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testResultDataGrid.DisableReadOnlyColumn = true;
            this.testResultDataGrid.Location = new System.Drawing.Point(0, 0);
            this.testResultDataGrid.Name = "testResultDataGrid";
            this.testResultDataGrid.ReadOnly = true;
            this.testResultDataGrid.Size = new System.Drawing.Size(378, 342);
            this.testResultDataGrid.TabIndex = 309;
            this.testResultDataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            this.testResultDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.dateRangeEd.myTimeRange = application.AppTypes.TimeRanges.None;
            this.dateRangeEd.myTimeScale = null;
            this.dateRangeEd.Name = "dateRangeEd";
            this.dateRangeEd.Size = new System.Drawing.Size(366, 24);
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
            this.stockCodeSelect.Size = new System.Drawing.Size(398, 364);
            this.stockCodeSelect.TabIndex = 30;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mainToolbarPnl
            // 
            this.mainToolbarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainToolbarPnl.Controls.Add(this.dataToolbarPnl);
            this.mainToolbarPnl.Controls.Add(this.fullScreenBtn);
            this.mainToolbarPnl.Controls.Add(this.closeBtn);
            this.mainToolbarPnl.Controls.Add(this.okBtn);
            this.mainToolbarPnl.Controls.Add(this.optionBtn);
            this.mainToolbarPnl.Location = new System.Drawing.Point(0, 0);
            this.mainToolbarPnl.Name = "mainToolbarPnl";
            this.mainToolbarPnl.Size = new System.Drawing.Size(962, 33);
            this.mainToolbarPnl.TabIndex = 0;
            // 
            // dataToolbarPnl
            // 
            this.dataToolbarPnl.Controls.Add(this.exportStrategyStatsBtn);
            this.dataToolbarPnl.Controls.Add(this.exportTestResultBtn);
            this.dataToolbarPnl.Controls.Add(this.chartBtn);
            this.dataToolbarPnl.Controls.Add(this.strategyEstimateBtn);
            this.dataToolbarPnl.Controls.Add(this.oneStockEstimateBtn);
            this.dataToolbarPnl.Location = new System.Drawing.Point(430, 3);
            this.dataToolbarPnl.Name = "dataToolbarPnl";
            this.dataToolbarPnl.Size = new System.Drawing.Size(308, 24);
            this.dataToolbarPnl.TabIndex = 12;
            // 
            // exportStrategyStatsBtn
            // 
            this.exportStrategyStatsBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportStrategyStatsBtn.Image = Properties.Resources.excel;
            this.exportStrategyStatsBtn.Location = new System.Drawing.Point(118, -1);
            this.exportStrategyStatsBtn.Name = "exportStrategyStatsBtn";
            this.exportStrategyStatsBtn.Size = new System.Drawing.Size(28, 24);
            this.exportStrategyStatsBtn.TabIndex = 5;
            this.myToolTip.SetToolTip(this.exportStrategyStatsBtn, "Xuất đánh giá chiến lược ra Excel");
            this.exportStrategyStatsBtn.UseVisualStyleBackColor = true;
            this.exportStrategyStatsBtn.Click += new System.EventHandler(this.exportStrategyStatsBtn_Click);
            // 
            // exportTestResultBtn
            // 
            this.exportTestResultBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportTestResultBtn.Image = Properties.Resources.excel;
            this.exportTestResultBtn.Location = new System.Drawing.Point(88, -1);
            this.exportTestResultBtn.Name = "exportTestResultBtn";
            this.exportTestResultBtn.Size = new System.Drawing.Size(28, 24);
            this.exportTestResultBtn.TabIndex = 4;
            this.myToolTip.SetToolTip(this.exportTestResultBtn, "Xuất kết quả ra Excel");
            this.exportTestResultBtn.UseVisualStyleBackColor = true;
            this.exportTestResultBtn.Click += new System.EventHandler(this.exportTestResultBtn_Click);
            // 
            // chartBtn
            // 
            this.chartBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartBtn.Image = Properties.Resources.exrate;
            this.chartBtn.Location = new System.Drawing.Point(60, -1);
            this.chartBtn.Name = "chartBtn";
            this.chartBtn.Size = new System.Drawing.Size(28, 24);
            this.chartBtn.TabIndex = 3;
            this.myToolTip.SetToolTip(this.chartBtn, "Biểu đồ lợi nhuận");
            this.chartBtn.UseVisualStyleBackColor = true;
            this.chartBtn.Click += new System.EventHandler(this.chartBtn_Click);
            // 
            // strategyEstimateBtn
            // 
            this.strategyEstimateBtn.Enabled = false;
            this.strategyEstimateBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategyEstimateBtn.Image = Properties.Resources.scale;
            this.strategyEstimateBtn.Location = new System.Drawing.Point(32, -1);
            this.strategyEstimateBtn.Name = "strategyEstimateBtn";
            this.strategyEstimateBtn.Size = new System.Drawing.Size(28, 24);
            this.strategyEstimateBtn.TabIndex = 2;
            this.myToolTip.SetToolTip(this.strategyEstimateBtn, "Đánh giá chiến lược trên mã chọn");
            this.strategyEstimateBtn.UseVisualStyleBackColor = true;
            this.strategyEstimateBtn.Click += new System.EventHandler(this.strategyEstimateBtn_Click);
            // 
            // oneStockEstimateBtn
            // 
            this.oneStockEstimateBtn.Enabled = false;
            this.oneStockEstimateBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneStockEstimateBtn.Image = Properties.Resources.ruler;
            this.oneStockEstimateBtn.Location = new System.Drawing.Point(2, -1);
            this.oneStockEstimateBtn.Name = "oneStockEstimateBtn";
            this.oneStockEstimateBtn.Size = new System.Drawing.Size(28, 24);
            this.oneStockEstimateBtn.TabIndex = 1;
            this.myToolTip.SetToolTip(this.oneStockEstimateBtn, "Đánh giá chiến lược cho mã CK chọn");
            this.oneStockEstimateBtn.UseVisualStyleBackColor = true;
            // 
            // fullScreenBtn
            // 
            this.fullScreenBtn.Enabled = false;
            this.fullScreenBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullScreenBtn.Image = Properties.Resources.fullScreen;
            this.fullScreenBtn.Location = new System.Drawing.Point(76, 3);
            this.fullScreenBtn.Name = "fullScreenBtn";
            this.fullScreenBtn.Size = new System.Drawing.Size(28, 24);
            this.fullScreenBtn.TabIndex = 6;
            this.myToolTip.SetToolTip(this.fullScreenBtn, "Tòan màn hình");
            this.fullScreenBtn.UseVisualStyleBackColor = true;
            this.fullScreenBtn.Click += new System.EventHandler(this.fullScreenBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Image = Properties.Resources.close;
            this.closeBtn.Location = new System.Drawing.Point(106, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(28, 24);
            this.closeBtn.TabIndex = 10;
            this.myToolTip.SetToolTip(this.closeBtn, "Kết thúc");
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Visible = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Image = Properties.Resources.run;
            this.okBtn.Location = new System.Drawing.Point(20, 3);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(28, 24);
            this.okBtn.TabIndex = 1;
            this.myToolTip.SetToolTip(this.okBtn, "Thực hiện");
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // optionBtn
            // 
            this.optionBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionBtn.Image = Properties.Resources.configure;
            this.optionBtn.Location = new System.Drawing.Point(48, 3);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(28, 24);
            this.optionBtn.TabIndex = 4;
            this.myToolTip.SetToolTip(this.optionBtn, "Tùy biến");
            this.optionBtn.UseVisualStyleBackColor = true;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // dataPnl
            // 
            this.dataPnl.Controls.Add(this.strategyEstDataGrid);
            this.dataPnl.Controls.Add(this.testResultDataGrid);
            this.dataPnl.Location = new System.Drawing.Point(440, 35);
            this.dataPnl.Name = "dataPnl";
            this.dataPnl.Size = new System.Drawing.Size(404, 649);
            this.dataPnl.TabIndex = 314;
            // 
            // strategyEstDataGrid
            // 
            this.strategyEstDataGrid.AllowUserToAddRows = false;
            this.strategyEstDataGrid.AllowUserToDeleteRows = false;
            this.strategyEstDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.strategyEstDataGrid.DisableReadOnlyColumn = true;
            this.strategyEstDataGrid.Location = new System.Drawing.Point(0, 415);
            this.strategyEstDataGrid.Name = "strategyEstDataGrid";
            this.strategyEstDataGrid.ReadOnly = true;
            this.strategyEstDataGrid.Size = new System.Drawing.Size(336, 174);
            this.strategyEstDataGrid.TabIndex = 310;
            this.strategyEstDataGrid.Visible = false;
            // 
            // optionPnl
            // 
            this.optionPnl.Controls.Add(this.stockCodeLbl);
            this.optionPnl.Controls.Add(this.stockCodeOptionCb);
            this.optionPnl.Controls.Add(this.portfolioCb);
            this.optionPnl.Controls.Add(this.strategyLbl);
            this.optionPnl.Controls.Add(this.strategyClb);
            this.optionPnl.Controls.Add(this.dateRangeEd);
            this.optionPnl.Controls.Add(this.dateRangeLbl);
            this.optionPnl.Controls.Add(this.stockCodeSelect);
            this.optionPnl.Location = new System.Drawing.Point(0, 35);
            this.optionPnl.Name = "optionPnl";
            this.optionPnl.Size = new System.Drawing.Size(422, 651);
            this.optionPnl.TabIndex = 315;
            // 
            // stockCodeLbl
            // 
            this.stockCodeLbl.AutoSize = true;
            this.stockCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeLbl.Location = new System.Drawing.Point(22, 235);
            this.stockCodeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stockCodeLbl.Name = "stockCodeLbl";
            this.stockCodeLbl.Size = new System.Drawing.Size(114, 16);
            this.stockCodeLbl.TabIndex = 318;
            this.stockCodeLbl.Text = "Mã chứng khóan";
            // 
            // stockCodeOptionCb
            // 
            this.stockCodeOptionCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockCodeOptionCb.FormattingEnabled = true;
            this.stockCodeOptionCb.Items.AddRange(new object[] {
            "Portfolio",
            "Tùy chọn"});
            this.stockCodeOptionCb.Location = new System.Drawing.Point(22, 255);
            this.stockCodeOptionCb.myValue = "";
            this.stockCodeOptionCb.Name = "stockCodeOptionCb";
            this.stockCodeOptionCb.Size = new System.Drawing.Size(127, 26);
            this.stockCodeOptionCb.TabIndex = 20;
            this.stockCodeOptionCb.SelectionChangeCommitted += new System.EventHandler(this.stockCodeOptionCb_SelectionChangeCommitted);
            // 
            // portfolioCb
            // 
            this.portfolioCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portfolioCb.FormattingEnabled = true;
            this.portfolioCb.Location = new System.Drawing.Point(150, 255);
            this.portfolioCb.myValue = "";
            this.portfolioCb.Name = "portfolioCb";
            this.portfolioCb.Size = new System.Drawing.Size(270, 26);
            this.portfolioCb.TabIndex = 21;
            this.portfolioCb.WatchType = application.AppTypes.PortfolioTypes.Portfolio;
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
            this.strategyClb.Size = new System.Drawing.Size(400, 156);
            this.strategyClb.TabIndex = 2;
            // 
            // baseBackTesting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(974, 706);
            this.Controls.Add(this.mainToolbarPnl);
            this.Controls.Add(this.optionPnl);
            this.Controls.Add(this.dataPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "baseBackTesting";
            this.Text = "Kiem tra/ BackTesting";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResizeEnd += new System.EventHandler(this.baseBackTesting_ResizeEnd);
            this.Controls.SetChildIndex(this.dataPnl, 0);
            this.Controls.SetChildIndex(this.optionPnl, 0);
            this.Controls.SetChildIndex(this.mainToolbarPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.testResultDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.mainToolbarPnl.ResumeLayout(false);
            this.dataToolbarPnl.ResumeLayout(false);
            this.dataPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.strategyEstDataGrid)).EndInit();
            this.optionPnl.ResumeLayout(false);
            this.optionPnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected common.control.baseDataGridView testResultDataGrid;
        protected baseClass.controls.baseLabel dateRangeLbl;
        protected baseClass.controls.chartTiming dateRangeEd;
        protected data.baseDS myDataSet;
        protected baseClass.controls.baseButton exportTestResultBtn;
        protected baseClass.controls.baseButton chartBtn;
        protected baseClass.controls.baseButton okBtn;
        protected baseClass.controls.stockCodeSelect stockCodeSelect;
        private data.tmpDS myTmpDS;
        protected baseClass.controls.baseButton optionBtn;
        protected baseClass.controls.baseButton oneStockEstimateBtn;
        protected baseClass.controls.baseButton strategyEstimateBtn;
        protected baseClass.controls.baseButton closeBtn;
        protected System.Windows.Forms.Panel mainToolbarPnl;
        protected baseClass.controls.baseButton fullScreenBtn;
        protected System.Windows.Forms.Panel dataPnl;
        protected common.control.baseDataGridView strategyEstDataGrid;
        protected System.Windows.Forms.Panel optionPnl;
        protected baseClass.controls.baseButton exportStrategyStatsBtn;
        protected System.Windows.Forms.Panel dataToolbarPnl;
        protected baseClass.controls.baseLabel strategyLbl;
        protected baseClass.controls.strategySelect strategyClb;
        protected baseClass.controls.baseLabel stockCodeLbl;
        protected baseClass.controls.cbPortpolio portfolioCb;
        protected common.control.baseComboBox stockCodeOptionCb;
    }
}
