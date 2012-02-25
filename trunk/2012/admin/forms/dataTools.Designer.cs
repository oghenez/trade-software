namespace admin.forms
{
    partial class dataTools
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateRangeEd = new common.controls.dateRange2();
            this.exchangeLbl = new baseClass.controls.baseLabel();
            this.checkVariancePercEd = new common.controls.numberTextBox();
            this.exchangeCb = new baseClass.controls.cbStockExchange();
            this.variancetLb = new baseClass.controls.baseLabel();
            this.diagnoseBtn = new baseClass.controls.baseButton();
            this.resultPnl = new common.controls.basePanel();
            this.resultGrid = new common.controls.baseDataGridView();
            this.priceDiagnoseSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS = new databases.tmpDS();
            this.diagTimeScaleCb = new baseClass.controls.cbTimeScale();
            this.diagTimeScaleLbl = new baseClass.controls.baseLabel();
            this.checkVarianceEd = new common.controls.numberTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.searchPg = new System.Windows.Forms.TabPage();
            this.dataAdjPg = new System.Windows.Forms.TabPage();
            this.dataAjustPnl = new common.controls.basePanel();
            this.dataAdjGrid = new common.controls.baseDataGridView();
            this.onDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDS = new databases.baseDS();
            this.dataAdjGb = new System.Windows.Forms.GroupBox();
            this.dataTimeScaleLbl = new baseClass.controls.baseLabel();
            this.dataTimeScaleCb = new baseClass.controls.cbTimeScale();
            this.testAdjustDataBtn = new baseClass.controls.baseButton();
            this.varianceLbl = new common.controls.baseLabel();
            this.varianceEd = new common.controls.numberTextBox();
            this.loadPriceBtn = new baseClass.controls.baseButton();
            this.saveFixDataBtn = new baseClass.controls.baseButton();
            this.adjustToDateLbl = new common.controls.baseLabel();
            this.adjWeightLbl = new common.controls.baseLabel();
            this.adjustToDateEd = new common.controls.baseDate();
            this.adjustCodeLbl = new common.controls.baseLabel();
            this.adjWeightEd = new common.controls.numberTextBox();
            this.adjustCodeEd = new baseClass.controls.txtStockCode();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varianceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDiagnoseSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).BeginInit();
            this.tabControl.SuspendLayout();
            this.searchPg.SuspendLayout();
            this.dataAdjPg.SuspendLayout();
            this.dataAjustPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdjGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.dataAdjGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(916, 340);
            this.TitleLbl.Size = new System.Drawing.Size(10, 46);
            this.TitleLbl.Visible = false;
            // 
            // dateRangeEd
            // 
            this.dateRangeEd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateRangeEd.frDate = new System.DateTime(((long)(0)));
            this.dateRangeEd.Location = new System.Drawing.Point(91, 4);
            this.dateRangeEd.Margin = new System.Windows.Forms.Padding(4);
            this.dateRangeEd.Name = "dateRangeEd";
            this.dateRangeEd.Size = new System.Drawing.Size(162, 45);
            this.dateRangeEd.TabIndex = 1;
            this.dateRangeEd.toDate = new System.DateTime(((long)(0)));
            // 
            // exchangeLbl
            // 
            this.exchangeLbl.AutoSize = true;
            this.exchangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exchangeLbl.Location = new System.Drawing.Point(253, 6);
            this.exchangeLbl.Name = "exchangeLbl";
            this.exchangeLbl.Size = new System.Drawing.Size(69, 16);
            this.exchangeLbl.TabIndex = 148;
            this.exchangeLbl.Text = "Exchange";
            // 
            // checkVariancePercEd
            // 
            this.checkVariancePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkVariancePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.checkVariancePercEd.Location = new System.Drawing.Point(313, 74);
            this.checkVariancePercEd.myFormat = "##0.##0";
            this.checkVariancePercEd.Name = "checkVariancePercEd";
            this.checkVariancePercEd.Size = new System.Drawing.Size(44, 24);
            this.checkVariancePercEd.TabIndex = 5;
            this.checkVariancePercEd.Text = "0.050";
            this.checkVariancePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.checkVariancePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.checkVariancePercEd.Value = new decimal(new int[] {
            50,
            0,
            0,
            196608});
            // 
            // exchangeCb
            // 
            this.exchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exchangeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exchangeCb.FormattingEnabled = true;
            this.exchangeCb.Location = new System.Drawing.Point(252, 25);
            this.exchangeCb.myValue = "";
            this.exchangeCb.Name = "exchangeCb";
            this.exchangeCb.Size = new System.Drawing.Size(164, 24);
            this.exchangeCb.TabIndex = 2;
            // 
            // variancetLb
            // 
            this.variancetLb.AutoSize = true;
            this.variancetLb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variancetLb.Location = new System.Drawing.Point(310, 55);
            this.variancetLb.Name = "variancetLb";
            this.variancetLb.Size = new System.Drawing.Size(65, 16);
            this.variancetLb.TabIndex = 151;
            this.variancetLb.Text = "Variance";
            // 
            // diagnoseBtn
            // 
            this.diagnoseBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagnoseBtn.Image = global::admin.Properties.Resources.run;
            this.diagnoseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.diagnoseBtn.isDownState = false;
            this.diagnoseBtn.Location = new System.Drawing.Point(449, 28);
            this.diagnoseBtn.Name = "diagnoseBtn";
            this.diagnoseBtn.Size = new System.Drawing.Size(81, 66);
            this.diagnoseBtn.TabIndex = 20;
            this.diagnoseBtn.Text = "Start";
            this.diagnoseBtn.UseVisualStyleBackColor = true;
            this.diagnoseBtn.Click += new System.EventHandler(this.diagnoseBtn_Click);
            // 
            // resultPnl
            // 
            this.resultPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultPnl.Controls.Add(this.resultGrid);
            this.resultPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultPnl.haveCloseButton = false;
            this.resultPnl.isExpanded = true;
            this.resultPnl.Location = new System.Drawing.Point(2, 103);
            this.resultPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.resultPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.resultPnl.myWeight = 0;
            this.resultPnl.Name = "resultPnl";
            this.resultPnl.Size = new System.Drawing.Size(616, 341);
            this.resultPnl.TabIndex = 155;
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.AutoGenerateColumns = false;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.date1DataGridViewTextBoxColumn,
            this.price1DataGridViewTextBoxColumn,
            this.price2DataGridViewTextBoxColumn,
            this.date2DataGridViewTextBoxColumn,
            this.varianceDataGridViewTextBoxColumn});
            this.resultGrid.DataSource = this.priceDiagnoseSource;
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.resultGrid.Location = new System.Drawing.Point(0, 0);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.ReadOnly = true;
            this.resultGrid.RowTemplate.Height = 24;
            this.resultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGrid.Size = new System.Drawing.Size(612, 364);
            this.resultGrid.TabIndex = 10;
            this.resultGrid.DoubleClick += new System.EventHandler(this.DataGrid_DoubleClick);
            // 
            // priceDiagnoseSource
            // 
            this.priceDiagnoseSource.DataMember = "priceDiagnose";
            this.priceDiagnoseSource.DataSource = this.tmpDS;
            // 
            // tmpDS
            // 
            this.tmpDS.DataSetName = "tmpDS";
            this.tmpDS.EnforceConstraints = false;
            this.tmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // diagTimeScaleCb
            // 
            this.diagTimeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diagTimeScaleCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagTimeScaleCb.FormattingEnabled = true;
            this.diagTimeScaleCb.Location = new System.Drawing.Point(91, 74);
            this.diagTimeScaleCb.Name = "diagTimeScaleCb";
            this.diagTimeScaleCb.SelectedValue = "RT";
            this.diagTimeScaleCb.Size = new System.Drawing.Size(223, 24);
            this.diagTimeScaleCb.TabIndex = 3;
            // 
            // diagTimeScaleLbl
            // 
            this.diagTimeScaleLbl.AutoSize = true;
            this.diagTimeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagTimeScaleLbl.Location = new System.Drawing.Point(92, 55);
            this.diagTimeScaleLbl.Name = "diagTimeScaleLbl";
            this.diagTimeScaleLbl.Size = new System.Drawing.Size(74, 16);
            this.diagTimeScaleLbl.TabIndex = 157;
            this.diagTimeScaleLbl.Text = "Time scale";
            // 
            // checkVarianceEd
            // 
            this.checkVarianceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkVarianceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.checkVarianceEd.Location = new System.Drawing.Point(356, 74);
            this.checkVarianceEd.myFormat = "##0.#0";
            this.checkVarianceEd.Name = "checkVarianceEd";
            this.checkVarianceEd.Size = new System.Drawing.Size(56, 24);
            this.checkVarianceEd.TabIndex = 6;
            this.checkVarianceEd.Text = "10.00";
            this.checkVarianceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.checkVarianceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.checkVarianceEd.Value = new decimal(new int[] {
            1000,
            0,
            0,
            131072});
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.searchPg);
            this.tabControl.Controls.Add(this.dataAdjPg);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(10, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(621, 475);
            this.tabControl.TabIndex = 158;
            // 
            // searchPg
            // 
            this.searchPg.Controls.Add(this.resultPnl);
            this.searchPg.Controls.Add(this.diagnoseBtn);
            this.searchPg.Controls.Add(this.exchangeLbl);
            this.searchPg.Controls.Add(this.checkVarianceEd);
            this.searchPg.Controls.Add(this.variancetLb);
            this.searchPg.Controls.Add(this.diagTimeScaleLbl);
            this.searchPg.Controls.Add(this.dateRangeEd);
            this.searchPg.Controls.Add(this.diagTimeScaleCb);
            this.searchPg.Controls.Add(this.exchangeCb);
            this.searchPg.Controls.Add(this.checkVariancePercEd);
            this.searchPg.Location = new System.Drawing.Point(4, 25);
            this.searchPg.Name = "searchPg";
            this.searchPg.Padding = new System.Windows.Forms.Padding(3);
            this.searchPg.Size = new System.Drawing.Size(613, 446);
            this.searchPg.TabIndex = 0;
            this.searchPg.Text = "Search";
            this.searchPg.UseVisualStyleBackColor = true;
            // 
            // dataAdjPg
            // 
            this.dataAdjPg.Controls.Add(this.dataAjustPnl);
            this.dataAdjPg.Controls.Add(this.dataAdjGb);
            this.dataAdjPg.Location = new System.Drawing.Point(4, 25);
            this.dataAdjPg.Name = "dataAdjPg";
            this.dataAdjPg.Padding = new System.Windows.Forms.Padding(3);
            this.dataAdjPg.Size = new System.Drawing.Size(613, 446);
            this.dataAdjPg.TabIndex = 1;
            this.dataAdjPg.Text = "Data Adjustment";
            this.dataAdjPg.UseVisualStyleBackColor = true;
            // 
            // dataAjustPnl
            // 
            this.dataAjustPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataAjustPnl.Controls.Add(this.dataAdjGrid);
            this.dataAjustPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataAjustPnl.haveCloseButton = false;
            this.dataAjustPnl.isExpanded = true;
            this.dataAjustPnl.Location = new System.Drawing.Point(1, 104);
            this.dataAjustPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.dataAjustPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.dataAjustPnl.myWeight = 0;
            this.dataAjustPnl.Name = "dataAjustPnl";
            this.dataAjustPnl.Size = new System.Drawing.Size(614, 341);
            this.dataAjustPnl.TabIndex = 10;
            // 
            // dataAdjGrid
            // 
            this.dataAdjGrid.AllowUserToAddRows = false;
            this.dataAdjGrid.AllowUserToDeleteRows = false;
            this.dataAdjGrid.AutoGenerateColumns = false;
            this.dataAdjGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAdjGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onDateDataGridViewTextBoxColumn,
            this.highPriceDataGridViewTextBoxColumn,
            this.lowPriceDataGridViewTextBoxColumn,
            this.openPriceDataGridViewTextBoxColumn,
            this.closePriceDataGridViewTextBoxColumn});
            this.dataAdjGrid.DataSource = this.priceDataSource;
            this.dataAdjGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataAdjGrid.Location = new System.Drawing.Point(0, 0);
            this.dataAdjGrid.Name = "dataAdjGrid";
            this.dataAdjGrid.ReadOnly = true;
            this.dataAdjGrid.RowTemplate.Height = 24;
            this.dataAdjGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAdjGrid.Size = new System.Drawing.Size(610, 340);
            this.dataAdjGrid.TabIndex = 10;
            this.dataAdjGrid.DoubleClick += new System.EventHandler(this.DataGrid_DoubleClick);
            // 
            // onDateDataGridViewTextBoxColumn
            // 
            this.onDateDataGridViewTextBoxColumn.DataPropertyName = "onDate";
            this.onDateDataGridViewTextBoxColumn.HeaderText = "Date/Time";
            this.onDateDataGridViewTextBoxColumn.Name = "onDateDataGridViewTextBoxColumn";
            this.onDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.onDateDataGridViewTextBoxColumn.Width = 145;
            // 
            // highPriceDataGridViewTextBoxColumn
            // 
            this.highPriceDataGridViewTextBoxColumn.DataPropertyName = "highPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.highPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.highPriceDataGridViewTextBoxColumn.HeaderText = "High";
            this.highPriceDataGridViewTextBoxColumn.Name = "highPriceDataGridViewTextBoxColumn";
            this.highPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lowPriceDataGridViewTextBoxColumn
            // 
            this.lowPriceDataGridViewTextBoxColumn.DataPropertyName = "lowPrice";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.lowPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.lowPriceDataGridViewTextBoxColumn.HeaderText = "Low";
            this.lowPriceDataGridViewTextBoxColumn.Name = "lowPriceDataGridViewTextBoxColumn";
            this.lowPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // openPriceDataGridViewTextBoxColumn
            // 
            this.openPriceDataGridViewTextBoxColumn.DataPropertyName = "openPrice";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.openPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.openPriceDataGridViewTextBoxColumn.HeaderText = "Open";
            this.openPriceDataGridViewTextBoxColumn.Name = "openPriceDataGridViewTextBoxColumn";
            this.openPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // closePriceDataGridViewTextBoxColumn
            // 
            this.closePriceDataGridViewTextBoxColumn.DataPropertyName = "closePrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.closePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.closePriceDataGridViewTextBoxColumn.HeaderText = "Close";
            this.closePriceDataGridViewTextBoxColumn.Name = "closePriceDataGridViewTextBoxColumn";
            this.closePriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataSource
            // 
            this.priceDataSource.DataMember = "priceData";
            this.priceDataSource.DataSource = this.baseDS;
            // 
            // baseDS
            // 
            this.baseDS.DataSetName = "baseDS";
            this.baseDS.EnforceConstraints = false;
            this.baseDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataAdjGb
            // 
            this.dataAdjGb.Controls.Add(this.dataTimeScaleLbl);
            this.dataAdjGb.Controls.Add(this.dataTimeScaleCb);
            this.dataAdjGb.Controls.Add(this.testAdjustDataBtn);
            this.dataAdjGb.Controls.Add(this.varianceLbl);
            this.dataAdjGb.Controls.Add(this.varianceEd);
            this.dataAdjGb.Controls.Add(this.loadPriceBtn);
            this.dataAdjGb.Controls.Add(this.saveFixDataBtn);
            this.dataAdjGb.Controls.Add(this.adjustToDateLbl);
            this.dataAdjGb.Controls.Add(this.adjWeightLbl);
            this.dataAdjGb.Controls.Add(this.adjustToDateEd);
            this.dataAdjGb.Controls.Add(this.adjustCodeLbl);
            this.dataAdjGb.Controls.Add(this.adjWeightEd);
            this.dataAdjGb.Controls.Add(this.adjustCodeEd);
            this.dataAdjGb.Location = new System.Drawing.Point(6, -4);
            this.dataAdjGb.Name = "dataAdjGb";
            this.dataAdjGb.Size = new System.Drawing.Size(601, 101);
            this.dataAdjGb.TabIndex = 1;
            this.dataAdjGb.TabStop = false;
            // 
            // dataTimeScaleLbl
            // 
            this.dataTimeScaleLbl.AutoSize = true;
            this.dataTimeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTimeScaleLbl.Location = new System.Drawing.Point(237, 11);
            this.dataTimeScaleLbl.Name = "dataTimeScaleLbl";
            this.dataTimeScaleLbl.Size = new System.Drawing.Size(74, 16);
            this.dataTimeScaleLbl.TabIndex = 174;
            this.dataTimeScaleLbl.Text = "Time scale";
            // 
            // dataTimeScaleCb
            // 
            this.dataTimeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataTimeScaleCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTimeScaleCb.FormattingEnabled = true;
            this.dataTimeScaleCb.Location = new System.Drawing.Point(233, 30);
            this.dataTimeScaleCb.Name = "dataTimeScaleCb";
            this.dataTimeScaleCb.SelectedValue = "RT";
            this.dataTimeScaleCb.Size = new System.Drawing.Size(133, 24);
            this.dataTimeScaleCb.TabIndex = 173;
            // 
            // testAdjustDataBtn
            // 
            this.testAdjustDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testAdjustDataBtn.Image = global::admin.Properties.Resources.select;
            this.testAdjustDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.testAdjustDataBtn.isDownState = false;
            this.testAdjustDataBtn.Location = new System.Drawing.Point(217, 58);
            this.testAdjustDataBtn.Name = "testAdjustDataBtn";
            this.testAdjustDataBtn.Size = new System.Drawing.Size(159, 33);
            this.testAdjustDataBtn.TabIndex = 21;
            this.testAdjustDataBtn.Text = "Change";
            this.testAdjustDataBtn.UseVisualStyleBackColor = true;
            this.testAdjustDataBtn.Click += new System.EventHandler(this.testAdjustDataBtn_Click);
            // 
            // varianceLbl
            // 
            this.varianceLbl.AutoSize = true;
            this.varianceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varianceLbl.Location = new System.Drawing.Point(368, 12);
            this.varianceLbl.Name = "varianceLbl";
            this.varianceLbl.Size = new System.Drawing.Size(65, 16);
            this.varianceLbl.TabIndex = 172;
            this.varianceLbl.Text = "Variance";
            // 
            // varianceEd
            // 
            this.varianceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varianceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.varianceEd.Location = new System.Drawing.Point(366, 30);
            this.varianceEd.myFormat = "##0.##0";
            this.varianceEd.Name = "varianceEd";
            this.varianceEd.Size = new System.Drawing.Size(75, 24);
            this.varianceEd.TabIndex = 3;
            this.varianceEd.Text = "0.050";
            this.varianceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.varianceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.varianceEd.Value = new decimal(new int[] {
            50,
            0,
            0,
            196608});
            this.varianceEd.Validated += new System.EventHandler(this.varianceEd_Validated);
            // 
            // loadPriceBtn
            // 
            this.loadPriceBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadPriceBtn.Image = global::admin.Properties.Resources.refresh;
            this.loadPriceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadPriceBtn.isDownState = false;
            this.loadPriceBtn.Location = new System.Drawing.Point(58, 58);
            this.loadPriceBtn.Name = "loadPriceBtn";
            this.loadPriceBtn.Size = new System.Drawing.Size(159, 33);
            this.loadPriceBtn.TabIndex = 20;
            this.loadPriceBtn.Text = "Load";
            this.loadPriceBtn.UseVisualStyleBackColor = true;
            this.loadPriceBtn.Click += new System.EventHandler(this.loadPriceBtn_Click);
            // 
            // saveFixDataBtn
            // 
            this.saveFixDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFixDataBtn.Image = global::admin.Properties.Resources.save;
            this.saveFixDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveFixDataBtn.isDownState = false;
            this.saveFixDataBtn.Location = new System.Drawing.Point(376, 58);
            this.saveFixDataBtn.Name = "saveFixDataBtn";
            this.saveFixDataBtn.Size = new System.Drawing.Size(159, 33);
            this.saveFixDataBtn.TabIndex = 22;
            this.saveFixDataBtn.Text = "Save";
            this.saveFixDataBtn.UseVisualStyleBackColor = true;
            this.saveFixDataBtn.Click += new System.EventHandler(this.saveFixDataBtn_Click);
            // 
            // adjustToDateLbl
            // 
            this.adjustToDateLbl.AutoSize = true;
            this.adjustToDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustToDateLbl.Location = new System.Drawing.Point(55, 11);
            this.adjustToDateLbl.Name = "adjustToDateLbl";
            this.adjustToDateLbl.Size = new System.Drawing.Size(70, 16);
            this.adjustToDateLbl.TabIndex = 164;
            this.adjustToDateLbl.Text = "Đến ngày";
            // 
            // adjWeightLbl
            // 
            this.adjWeightLbl.AutoSize = true;
            this.adjWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjWeightLbl.Location = new System.Drawing.Point(440, 12);
            this.adjWeightLbl.Name = "adjWeightLbl";
            this.adjWeightLbl.Size = new System.Drawing.Size(94, 16);
            this.adjWeightLbl.TabIndex = 170;
            this.adjWeightLbl.Text = "HS điều chỉnh";
            // 
            // adjustToDateEd
            // 
            this.adjustToDateEd.BeepOnError = true;
            this.adjustToDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustToDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.adjustToDateEd.Location = new System.Drawing.Point(56, 30);
            this.adjustToDateEd.Mask = "00/00/0000";
            this.adjustToDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.adjustToDateEd.Name = "adjustToDateEd";
            this.adjustToDateEd.Size = new System.Drawing.Size(94, 24);
            this.adjustToDateEd.TabIndex = 1;
            // 
            // adjustCodeLbl
            // 
            this.adjustCodeLbl.AutoSize = true;
            this.adjustCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustCodeLbl.Location = new System.Drawing.Point(156, 12);
            this.adjustCodeLbl.Name = "adjustCodeLbl";
            this.adjustCodeLbl.Size = new System.Drawing.Size(46, 16);
            this.adjustCodeLbl.TabIndex = 169;
            this.adjustCodeLbl.Text = "Mã số";
            // 
            // adjWeightEd
            // 
            this.adjWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.adjWeightEd.Location = new System.Drawing.Point(441, 30);
            this.adjWeightEd.myFormat = " ##0.##0";
            this.adjWeightEd.Name = "adjWeightEd";
            this.adjWeightEd.Size = new System.Drawing.Size(94, 24);
            this.adjWeightEd.TabIndex = 10;
            this.adjWeightEd.TabStop = false;
            this.adjWeightEd.Text = "0.050";
            this.adjWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.adjWeightEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.adjWeightEd.Value = new decimal(new int[] {
            50,
            0,
            0,
            196608});
            this.adjWeightEd.Validated += new System.EventHandler(this.adjWeightEd_Validated);
            // 
            // adjustCodeEd
            // 
            this.adjustCodeEd.BackColor = System.Drawing.Color.White;
            this.adjustCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustCodeEd.ForeColor = System.Drawing.Color.Black;
            this.adjustCodeEd.isRequired = true;
            this.adjustCodeEd.isToUpperCase = true;
            this.adjustCodeEd.Location = new System.Drawing.Point(150, 30);
            this.adjustCodeEd.Name = "adjustCodeEd";
            this.adjustCodeEd.Size = new System.Drawing.Size(83, 24);
            this.adjustCodeEd.TabIndex = 2;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 80;
            // 
            // date1DataGridViewTextBoxColumn
            // 
            this.date1DataGridViewTextBoxColumn.DataPropertyName = "date1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.date1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.date1DataGridViewTextBoxColumn.HeaderText = "Date 1";
            this.date1DataGridViewTextBoxColumn.Name = "date1DataGridViewTextBoxColumn";
            this.date1DataGridViewTextBoxColumn.ReadOnly = true;
            this.date1DataGridViewTextBoxColumn.Width = 130;
            // 
            // price1DataGridViewTextBoxColumn
            // 
            this.price1DataGridViewTextBoxColumn.DataPropertyName = "price1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.price1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.price1DataGridViewTextBoxColumn.HeaderText = "Price 1";
            this.price1DataGridViewTextBoxColumn.Name = "price1DataGridViewTextBoxColumn";
            this.price1DataGridViewTextBoxColumn.ReadOnly = true;
            this.price1DataGridViewTextBoxColumn.Width = 80;
            // 
            // price2DataGridViewTextBoxColumn
            // 
            this.price2DataGridViewTextBoxColumn.DataPropertyName = "price2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.price2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.price2DataGridViewTextBoxColumn.HeaderText = "Price 2";
            this.price2DataGridViewTextBoxColumn.Name = "price2DataGridViewTextBoxColumn";
            this.price2DataGridViewTextBoxColumn.ReadOnly = true;
            this.price2DataGridViewTextBoxColumn.Width = 80;
            // 
            // date2DataGridViewTextBoxColumn
            // 
            this.date2DataGridViewTextBoxColumn.DataPropertyName = "date2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "g";
            this.date2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.date2DataGridViewTextBoxColumn.HeaderText = "Date 2";
            this.date2DataGridViewTextBoxColumn.Name = "date2DataGridViewTextBoxColumn";
            this.date2DataGridViewTextBoxColumn.ReadOnly = true;
            this.date2DataGridViewTextBoxColumn.Width = 130;
            // 
            // varianceDataGridViewTextBoxColumn
            // 
            this.varianceDataGridViewTextBoxColumn.DataPropertyName = "variance";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.varianceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.varianceDataGridViewTextBoxColumn.HeaderText = "+/-";
            this.varianceDataGridViewTextBoxColumn.Name = "varianceDataGridViewTextBoxColumn";
            this.varianceDataGridViewTextBoxColumn.ReadOnly = true;
            this.varianceDataGridViewTextBoxColumn.Width = 50;
            // 
            // dataTools
            // 
            this.ClientSize = new System.Drawing.Size(643, 496);
            this.Controls.Add(this.tabControl);
            this.Name = "dataTools";
            this.Text = "Data tools";
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.resultPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDiagnoseSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.searchPg.ResumeLayout(false);
            this.searchPg.PerformLayout();
            this.dataAdjPg.ResumeLayout(false);
            this.dataAjustPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataAdjGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.dataAdjGb.ResumeLayout(false);
            this.dataAdjGb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.dateRange2 dateRangeEd;
        private baseClass.controls.baseLabel exchangeLbl;
        private baseClass.controls.baseButton diagnoseBtn;
        private common.controls.numberTextBox checkVariancePercEd;
        private baseClass.controls.baseLabel variancetLb;
        private baseClass.controls.cbStockExchange exchangeCb;
        protected common.controls.basePanel resultPnl;
        private baseClass.controls.cbTimeScale diagTimeScaleCb;
        private baseClass.controls.baseLabel diagTimeScaleLbl;
        private common.controls.baseDataGridView resultGrid;
        private common.controls.numberTextBox checkVarianceEd;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage searchPg;
        protected common.controls.basePanel dataAjustPnl;
        protected System.Windows.Forms.TabPage dataAdjPg;
        protected baseClass.controls.baseButton saveFixDataBtn;
        protected common.controls.baseDate adjustToDateEd;
        protected common.controls.numberTextBox adjWeightEd;
        protected baseClass.controls.txtStockCode adjustCodeEd;
        protected common.controls.baseLabel adjustCodeLbl;
        protected common.controls.baseLabel adjWeightLbl;
        protected System.Windows.Forms.GroupBox dataAdjGb;
        protected baseClass.controls.baseButton loadPriceBtn;
        protected common.controls.baseDataGridView dataAdjGrid;
        protected databases.baseDS baseDS;
        protected System.Windows.Forms.BindingSource priceDataSource;
        protected databases.tmpDS tmpDS;
        protected System.Windows.Forms.BindingSource priceDiagnoseSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closePriceDataGridViewTextBoxColumn;
        protected common.controls.baseLabel adjustToDateLbl;
        protected common.controls.baseLabel varianceLbl;
        protected common.controls.numberTextBox varianceEd;
        protected baseClass.controls.baseButton testAdjustDataBtn;
        private baseClass.controls.baseLabel dataTimeScaleLbl;
        private baseClass.controls.cbTimeScale dataTimeScaleCb;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varianceDataGridViewTextBoxColumn;
    }
}
