namespace admin.forms
{
    partial class diagnoseData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateRangeEd = new common.controls.dateRange2();
            this.exchangeLbl = new baseClass.controls.baseLabel();
            this.variancePercEd = new common.controls.numberTextBox();
            this.exchangeCb = new baseClass.controls.cbStockExchange();
            this.variancetLb = new baseClass.controls.baseLabel();
            this.diagnoseBtn = new baseClass.controls.baseButton();
            this.resultPnl = new common.controls.basePanel();
            this.resultGrid = new common.controls.baseDataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.varianceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDiagnoseSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS = new databases.tmpDS();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            this.timeScaleLbl = new baseClass.controls.baseLabel();
            this.varianceEd = new common.controls.numberTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.searchPg = new System.Windows.Forms.TabPage();
            this.dataAdjPg = new System.Windows.Forms.TabPage();
            this.fixedDataPnl = new common.controls.basePanel();
            this.fixedDataGrid = new common.controls.baseDataGridView();
            this.onDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDS = new databases.baseDS();
            this.fixingGb = new System.Windows.Forms.GroupBox();
            this.fixDataBtn = new baseClass.controls.baseButton();
            this.saveFixDataBtn = new baseClass.controls.baseButton();
            this.adjustToDateLbl = new common.controls.baseLabel();
            this.adjWeightLbl = new common.controls.baseLabel();
            this.adjustToDateEd = new common.controls.baseDate();
            this.adjustCodeLbl = new common.controls.baseLabel();
            this.adjWeightEd = new common.controls.numberTextBox();
            this.adjustCodeEd = new baseClass.controls.txtStockCode();
            this.resultPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDiagnoseSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).BeginInit();
            this.tabControl.SuspendLayout();
            this.searchPg.SuspendLayout();
            this.dataAdjPg.SuspendLayout();
            this.fixedDataPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fixedDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).BeginInit();
            this.fixingGb.SuspendLayout();
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
            // variancePercEd
            // 
            this.variancePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variancePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.variancePercEd.Location = new System.Drawing.Point(313, 74);
            this.variancePercEd.myFormat = "##0.##0";
            this.variancePercEd.Name = "variancePercEd";
            this.variancePercEd.Size = new System.Drawing.Size(44, 24);
            this.variancePercEd.TabIndex = 5;
            this.variancePercEd.Text = "0.050";
            this.variancePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.variancePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.variancePercEd.Value = new decimal(new int[] {
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
            this.date2DataGridViewTextBoxColumn,
            this.price2DataGridViewTextBoxColumn,
            this.varianceDataGridViewTextBoxColumn});
            this.resultGrid.DataSource = this.priceDiagnoseSource;
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.resultGrid.Location = new System.Drawing.Point(0, 0);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.ReadOnly = true;
            this.resultGrid.RowTemplate.Height = 24;
            this.resultGrid.Size = new System.Drawing.Size(612, 364);
            this.resultGrid.TabIndex = 10;
            this.resultGrid.DoubleClick += new System.EventHandler(this.DataGrid_DoubleClick);
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
            // date2DataGridViewTextBoxColumn
            // 
            this.date2DataGridViewTextBoxColumn.DataPropertyName = "date2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "g";
            this.date2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.date2DataGridViewTextBoxColumn.HeaderText = "Date 2";
            this.date2DataGridViewTextBoxColumn.Name = "date2DataGridViewTextBoxColumn";
            this.date2DataGridViewTextBoxColumn.ReadOnly = true;
            this.date2DataGridViewTextBoxColumn.Width = 130;
            // 
            // price2DataGridViewTextBoxColumn
            // 
            this.price2DataGridViewTextBoxColumn.DataPropertyName = "price2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.price2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.price2DataGridViewTextBoxColumn.HeaderText = "Price 2";
            this.price2DataGridViewTextBoxColumn.Name = "price2DataGridViewTextBoxColumn";
            this.price2DataGridViewTextBoxColumn.ReadOnly = true;
            this.price2DataGridViewTextBoxColumn.Width = 80;
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
            // timeScaleCb
            // 
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(91, 74);
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.SelectedValue = "RT";
            this.timeScaleCb.Size = new System.Drawing.Size(223, 24);
            this.timeScaleCb.TabIndex = 3;
            // 
            // timeScaleLbl
            // 
            this.timeScaleLbl.AutoSize = true;
            this.timeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleLbl.Location = new System.Drawing.Point(92, 55);
            this.timeScaleLbl.Name = "timeScaleLbl";
            this.timeScaleLbl.Size = new System.Drawing.Size(74, 16);
            this.timeScaleLbl.TabIndex = 157;
            this.timeScaleLbl.Text = "Time scale";
            // 
            // varianceEd
            // 
            this.varianceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varianceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.varianceEd.Location = new System.Drawing.Point(356, 74);
            this.varianceEd.myFormat = "##0.#0";
            this.varianceEd.Name = "varianceEd";
            this.varianceEd.Size = new System.Drawing.Size(56, 24);
            this.varianceEd.TabIndex = 6;
            this.varianceEd.Text = "10.00";
            this.varianceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.varianceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.varianceEd.Value = new decimal(new int[] {
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
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // searchPg
            // 
            this.searchPg.Controls.Add(this.resultPnl);
            this.searchPg.Controls.Add(this.diagnoseBtn);
            this.searchPg.Controls.Add(this.exchangeLbl);
            this.searchPg.Controls.Add(this.varianceEd);
            this.searchPg.Controls.Add(this.variancetLb);
            this.searchPg.Controls.Add(this.timeScaleLbl);
            this.searchPg.Controls.Add(this.dateRangeEd);
            this.searchPg.Controls.Add(this.timeScaleCb);
            this.searchPg.Controls.Add(this.exchangeCb);
            this.searchPg.Controls.Add(this.variancePercEd);
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
            this.dataAdjPg.Controls.Add(this.fixedDataPnl);
            this.dataAdjPg.Controls.Add(this.fixingGb);
            this.dataAdjPg.Location = new System.Drawing.Point(4, 25);
            this.dataAdjPg.Name = "dataAdjPg";
            this.dataAdjPg.Padding = new System.Windows.Forms.Padding(3);
            this.dataAdjPg.Size = new System.Drawing.Size(613, 446);
            this.dataAdjPg.TabIndex = 1;
            this.dataAdjPg.Text = "Data Adjustment";
            this.dataAdjPg.UseVisualStyleBackColor = true;
            // 
            // fixedDataPnl
            // 
            this.fixedDataPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fixedDataPnl.Controls.Add(this.fixedDataGrid);
            this.fixedDataPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixedDataPnl.haveCloseButton = false;
            this.fixedDataPnl.isExpanded = true;
            this.fixedDataPnl.Location = new System.Drawing.Point(2, 103);
            this.fixedDataPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.fixedDataPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.fixedDataPnl.myWeight = 0;
            this.fixedDataPnl.Name = "fixedDataPnl";
            this.fixedDataPnl.Size = new System.Drawing.Size(616, 341);
            this.fixedDataPnl.TabIndex = 10;
            // 
            // fixedDataGrid
            // 
            this.fixedDataGrid.AllowUserToAddRows = false;
            this.fixedDataGrid.AllowUserToDeleteRows = false;
            this.fixedDataGrid.AutoGenerateColumns = false;
            this.fixedDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fixedDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.onDateDataGridViewTextBoxColumn,
            this.highPriceDataGridViewTextBoxColumn,
            this.lowPriceDataGridViewTextBoxColumn,
            this.openPriceDataGridViewTextBoxColumn,
            this.closePriceDataGridViewTextBoxColumn});
            this.fixedDataGrid.DataSource = this.priceDataSource;
            this.fixedDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.fixedDataGrid.Location = new System.Drawing.Point(0, 0);
            this.fixedDataGrid.Name = "fixedDataGrid";
            this.fixedDataGrid.ReadOnly = true;
            this.fixedDataGrid.RowTemplate.Height = 24;
            this.fixedDataGrid.Size = new System.Drawing.Size(612, 364);
            this.fixedDataGrid.TabIndex = 10;
            this.fixedDataGrid.DoubleClick += new System.EventHandler(this.DataGrid_DoubleClick);
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
            // fixingGb
            // 
            this.fixingGb.Controls.Add(this.fixDataBtn);
            this.fixingGb.Controls.Add(this.saveFixDataBtn);
            this.fixingGb.Controls.Add(this.adjustToDateLbl);
            this.fixingGb.Controls.Add(this.adjWeightLbl);
            this.fixingGb.Controls.Add(this.adjustToDateEd);
            this.fixingGb.Controls.Add(this.adjustCodeLbl);
            this.fixingGb.Controls.Add(this.adjWeightEd);
            this.fixingGb.Controls.Add(this.adjustCodeEd);
            this.fixingGb.Location = new System.Drawing.Point(6, -4);
            this.fixingGb.Name = "fixingGb";
            this.fixingGb.Size = new System.Drawing.Size(601, 101);
            this.fixingGb.TabIndex = 1;
            this.fixingGb.TabStop = false;
            // 
            // fixDataBtn
            // 
            this.fixDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixDataBtn.Image = global::admin.Properties.Resources.run;
            this.fixDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fixDataBtn.isDownState = false;
            this.fixDataBtn.Location = new System.Drawing.Point(135, 61);
            this.fixDataBtn.Name = "fixDataBtn";
            this.fixDataBtn.Size = new System.Drawing.Size(130, 30);
            this.fixDataBtn.TabIndex = 20;
            this.fixDataBtn.Text = "Start";
            this.fixDataBtn.UseVisualStyleBackColor = true;
            this.fixDataBtn.Click += new System.EventHandler(this.fixDataBtn_Click);
            // 
            // saveFixDataBtn
            // 
            this.saveFixDataBtn.Enabled = false;
            this.saveFixDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFixDataBtn.Image = global::admin.Properties.Resources.save;
            this.saveFixDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveFixDataBtn.isDownState = false;
            this.saveFixDataBtn.Location = new System.Drawing.Point(265, 61);
            this.saveFixDataBtn.Name = "saveFixDataBtn";
            this.saveFixDataBtn.Size = new System.Drawing.Size(130, 30);
            this.saveFixDataBtn.TabIndex = 21;
            this.saveFixDataBtn.Text = "Save";
            this.saveFixDataBtn.UseVisualStyleBackColor = true;
            // 
            // adjustToDateLbl
            // 
            this.adjustToDateLbl.AutoSize = true;
            this.adjustToDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustToDateLbl.Location = new System.Drawing.Point(136, 15);
            this.adjustToDateLbl.Name = "adjustToDateLbl";
            this.adjustToDateLbl.Size = new System.Drawing.Size(70, 16);
            this.adjustToDateLbl.TabIndex = 164;
            this.adjustToDateLbl.Text = "Đến ngày";
            // 
            // adjWeightLbl
            // 
            this.adjWeightLbl.AutoSize = true;
            this.adjWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjWeightLbl.Location = new System.Drawing.Point(297, 14);
            this.adjWeightLbl.Name = "adjWeightLbl";
            this.adjWeightLbl.Size = new System.Drawing.Size(94, 16);
            this.adjWeightLbl.TabIndex = 170;
            this.adjWeightLbl.Text = "HS điều chỉnh";
            // 
            // adjustToDateEd
            // 
            this.adjustToDateEd.BeepOnError = true;
            this.adjustToDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustToDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.adjustToDateEd.Location = new System.Drawing.Point(136, 34);
            this.adjustToDateEd.Mask = "00/00/0000";
            this.adjustToDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.adjustToDateEd.Name = "adjustToDateEd";
            this.adjustToDateEd.Size = new System.Drawing.Size(90, 22);
            this.adjustToDateEd.TabIndex = 1;
            // 
            // adjustCodeLbl
            // 
            this.adjustCodeLbl.AutoSize = true;
            this.adjustCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustCodeLbl.Location = new System.Drawing.Point(232, 16);
            this.adjustCodeLbl.Name = "adjustCodeLbl";
            this.adjustCodeLbl.Size = new System.Drawing.Size(46, 16);
            this.adjustCodeLbl.TabIndex = 169;
            this.adjustCodeLbl.Text = "Mã số";
            // 
            // adjWeightEd
            // 
            this.adjWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.adjWeightEd.Location = new System.Drawing.Point(299, 34);
            this.adjWeightEd.myFormat = "##0.##0";
            this.adjWeightEd.Name = "adjWeightEd";
            this.adjWeightEd.Size = new System.Drawing.Size(97, 22);
            this.adjWeightEd.TabIndex = 10;
            this.adjWeightEd.Text = "0.050";
            this.adjWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.adjWeightEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.adjWeightEd.Value = new decimal(new int[] {
            50,
            0,
            0,
            196608});
            // 
            // adjustCodeEd
            // 
            this.adjustCodeEd.BackColor = System.Drawing.Color.White;
            this.adjustCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustCodeEd.ForeColor = System.Drawing.Color.Black;
            this.adjustCodeEd.isRequired = true;
            this.adjustCodeEd.isToUpperCase = true;
            this.adjustCodeEd.Location = new System.Drawing.Point(226, 34);
            this.adjustCodeEd.Name = "adjustCodeEd";
            this.adjustCodeEd.Size = new System.Drawing.Size(73, 22);
            this.adjustCodeEd.TabIndex = 2;
            // 
            // diagnoseData
            // 
            this.ClientSize = new System.Drawing.Size(643, 496);
            this.Controls.Add(this.tabControl);
            this.Name = "diagnoseData";
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
            this.fixedDataPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fixedDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS)).EndInit();
            this.fixingGb.ResumeLayout(false);
            this.fixingGb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private common.controls.dateRange2 dateRangeEd;
        private baseClass.controls.baseLabel exchangeLbl;
        private baseClass.controls.baseButton diagnoseBtn;
        private common.controls.numberTextBox variancePercEd;
        private baseClass.controls.baseLabel variancetLb;
        private baseClass.controls.cbStockExchange exchangeCb;
        protected common.controls.basePanel resultPnl;
        private baseClass.controls.cbTimeScale timeScaleCb;
        private baseClass.controls.baseLabel timeScaleLbl;
        private common.controls.baseDataGridView resultGrid;
        private common.controls.numberTextBox varianceEd;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn varianceDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage searchPg;
        protected common.controls.basePanel fixedDataPnl;
        protected System.Windows.Forms.TabPage dataAdjPg;
        protected baseClass.controls.baseButton saveFixDataBtn;
        protected common.controls.baseDate adjustToDateEd;
        protected common.controls.numberTextBox adjWeightEd;
        protected baseClass.controls.txtStockCode adjustCodeEd;
        protected common.controls.baseLabel adjustCodeLbl;
        protected common.controls.baseLabel adjWeightLbl;
        protected System.Windows.Forms.GroupBox fixingGb;
        protected baseClass.controls.baseButton fixDataBtn;
        protected common.controls.baseDataGridView fixedDataGrid;
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
    }
}
