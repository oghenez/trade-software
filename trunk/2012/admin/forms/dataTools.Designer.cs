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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.exchangeLbl = new baseClass.controls.baseLabel();
            this.exchangeCb = new baseClass.controls.cbStockExchange();
            this.diagnoseBtn = new baseClass.controls.baseButton();
            this.priceDiagnoseSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS = new databases.tmpDS();
            this.diagTimeScaleCb = new baseClass.controls.cbTimeScale();
            this.diagTimeScaleLbl = new baseClass.controls.baseLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.searchPg = new System.Windows.Forms.TabPage();
            this.srcCodeLbl = new common.controls.baseLabel();
            this.srcCodeEd = new baseClass.controls.txtStockCode();
            this.resultPnl = new common.controls.basePanel();
            this.resultGrid = new common.controls.baseDataGridView();
            this.srcCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcCloseDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcClosePriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcOpenPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcOpenDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcVarianceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.srcSelectColumn = new common.controls.gridViewImageColumn();
            this.srcFrDateLbl = new common.controls.baseLabel();
            this.srcFrDateEd = new common.controls.baseDate();
            this.srcToDateLbl = new common.controls.baseLabel();
            this.srcToDateEd = new common.controls.baseDate();
            this.varianceParamGb = new System.Windows.Forms.GroupBox();
            this.checkVarianceEd = new common.controls.numberTextBox();
            this.baseLabel1 = new baseClass.controls.baseLabel();
            this.checkVariancePercEd = new common.controls.numberTextBox();
            this.variancetLb = new baseClass.controls.baseLabel();
            this.dataAdjPg = new System.Windows.Forms.TabPage();
            this.dataAjustPnl = new common.controls.basePanel();
            this.dataAdjGrid = new common.controls.baseDataGridView();
            this.dataOnDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataHighPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataLowPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataOpenPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataClosePriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVolumeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSelectColumn = new common.controls.gridViewImageColumn();
            this.priceDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.baseDS = new databases.baseDS();
            this.dataAdjGb = new System.Windows.Forms.GroupBox();
            this.reAggregateBtn = new baseClass.controls.baseButton();
            this.dataTimeScaleLbl = new baseClass.controls.baseLabel();
            this.dataTimeScaleCb = new baseClass.controls.cbTimeScale();
            this.testAdjustDataBtn = new baseClass.controls.baseButton();
            this.varianceLbl = new common.controls.baseLabel();
            this.dataVarianceEd = new common.controls.numberTextBox();
            this.loadPriceBtn = new baseClass.controls.baseButton();
            this.saveDataBtn = new baseClass.controls.baseButton();
            this.adjustToDateLbl = new common.controls.baseLabel();
            this.adjWeightLbl = new common.controls.baseLabel();
            this.dataToDateEd = new common.controls.baseDate();
            this.dataCodeLbl = new common.controls.baseLabel();
            this.dataWeightEd = new common.controls.numberTextBox();
            this.dataCodeEd = new baseClass.controls.txtStockCode();
            ((System.ComponentModel.ISupportInitialize)(this.priceDiagnoseSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).BeginInit();
            this.tabControl.SuspendLayout();
            this.searchPg.SuspendLayout();
            this.resultPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.varianceParamGb.SuspendLayout();
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
            // exchangeLbl
            // 
            this.exchangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exchangeLbl.Location = new System.Drawing.Point(94, 50);
            this.exchangeLbl.Name = "exchangeLbl";
            this.exchangeLbl.Size = new System.Drawing.Size(88, 18);
            this.exchangeLbl.TabIndex = 148;
            this.exchangeLbl.Text = "Exchange";
            // 
            // exchangeCb
            // 
            this.exchangeCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exchangeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exchangeCb.FormattingEnabled = true;
            this.exchangeCb.Location = new System.Drawing.Point(93, 69);
            this.exchangeCb.myValue = "";
            this.exchangeCb.Name = "exchangeCb";
            this.exchangeCb.Size = new System.Drawing.Size(187, 24);
            this.exchangeCb.TabIndex = 10;
            // 
            // diagnoseBtn
            // 
            this.diagnoseBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagnoseBtn.Image = global::admin.Properties.Resources.run;
            this.diagnoseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.diagnoseBtn.isDownState = false;
            this.diagnoseBtn.Location = new System.Drawing.Point(615, 16);
            this.diagnoseBtn.Name = "diagnoseBtn";
            this.diagnoseBtn.Size = new System.Drawing.Size(84, 66);
            this.diagnoseBtn.TabIndex = 30;
            this.diagnoseBtn.Text = "Search";
            this.diagnoseBtn.UseVisualStyleBackColor = true;
            this.diagnoseBtn.Click += new System.EventHandler(this.diagnoseBtn_Click);
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
            this.diagTimeScaleCb.Location = new System.Drawing.Point(279, 23);
            this.diagTimeScaleCb.Name = "diagTimeScaleCb";
            this.diagTimeScaleCb.SelectedValue = "RT";
            this.diagTimeScaleCb.Size = new System.Drawing.Size(93, 24);
            this.diagTimeScaleCb.TabIndex = 3;
            // 
            // diagTimeScaleLbl
            // 
            this.diagTimeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diagTimeScaleLbl.Location = new System.Drawing.Point(281, 4);
            this.diagTimeScaleLbl.Name = "diagTimeScaleLbl";
            this.diagTimeScaleLbl.Size = new System.Drawing.Size(88, 18);
            this.diagTimeScaleLbl.TabIndex = 157;
            this.diagTimeScaleLbl.Text = "Time scale";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.searchPg);
            this.tabControl.Controls.Add(this.dataAdjPg);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(10, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(758, 475);
            this.tabControl.TabIndex = 158;
            // 
            // searchPg
            // 
            this.searchPg.Controls.Add(this.resultPnl);
            this.searchPg.Controls.Add(this.srcCodeLbl);
            this.searchPg.Controls.Add(this.srcCodeEd);
            this.searchPg.Controls.Add(this.srcFrDateLbl);
            this.searchPg.Controls.Add(this.srcFrDateEd);
            this.searchPg.Controls.Add(this.srcToDateLbl);
            this.searchPg.Controls.Add(this.srcToDateEd);
            this.searchPg.Controls.Add(this.diagnoseBtn);
            this.searchPg.Controls.Add(this.exchangeLbl);
            this.searchPg.Controls.Add(this.diagTimeScaleLbl);
            this.searchPg.Controls.Add(this.diagTimeScaleCb);
            this.searchPg.Controls.Add(this.exchangeCb);
            this.searchPg.Controls.Add(this.varianceParamGb);
            this.searchPg.Location = new System.Drawing.Point(4, 25);
            this.searchPg.Name = "searchPg";
            this.searchPg.Padding = new System.Windows.Forms.Padding(3);
            this.searchPg.Size = new System.Drawing.Size(750, 446);
            this.searchPg.TabIndex = 0;
            this.searchPg.Text = "Search";
            this.searchPg.UseVisualStyleBackColor = true;
            // 
            // srcCodeLbl
            // 
            this.srcCodeLbl.AutoSize = true;
            this.srcCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcCodeLbl.Location = new System.Drawing.Point(280, 51);
            this.srcCodeLbl.Name = "srcCodeLbl";
            this.srcCodeLbl.Size = new System.Drawing.Size(46, 16);
            this.srcCodeLbl.TabIndex = 171;
            this.srcCodeLbl.Text = "Mã số";
            // 
            // srcCodeEd
            // 
            this.srcCodeEd.BackColor = System.Drawing.Color.White;
            this.srcCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcCodeEd.ForeColor = System.Drawing.Color.Black;
            this.srcCodeEd.isRequired = true;
            this.srcCodeEd.isToUpperCase = true;
            this.srcCodeEd.Location = new System.Drawing.Point(279, 69);
            this.srcCodeEd.Name = "srcCodeEd";
            this.srcCodeEd.Size = new System.Drawing.Size(93, 24);
            this.srcCodeEd.TabIndex = 11;
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
            this.resultPnl.Size = new System.Drawing.Size(748, 341);
            this.resultPnl.TabIndex = 155;
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AllowUserToDeleteRows = false;
            this.resultGrid.AutoGenerateColumns = false;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srcCodeColumn,
            this.srcCloseDateColumn,
            this.srcClosePriceColumn,
            this.srcOpenPriceColumn,
            this.srcOpenDateColumn,
            this.srcVarianceColumn,
            this.srcSelectColumn});
            this.resultGrid.DataSource = this.priceDiagnoseSource;
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGrid.Location = new System.Drawing.Point(0, 0);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.ReadOnly = true;
            this.resultGrid.RowTemplate.Height = 24;
            this.resultGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultGrid.Size = new System.Drawing.Size(744, 337);
            this.resultGrid.TabIndex = 10;
            this.resultGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultGrid_CellContentClick);
            // 
            // srcCodeColumn
            // 
            this.srcCodeColumn.DataPropertyName = "code";
            this.srcCodeColumn.HeaderText = "Code";
            this.srcCodeColumn.Name = "srcCodeColumn";
            this.srcCodeColumn.ReadOnly = true;
            // 
            // srcCloseDateColumn
            // 
            this.srcCloseDateColumn.DataPropertyName = "date1";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "g";
            dataGridViewCellStyle11.NullValue = null;
            this.srcCloseDateColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.srcCloseDateColumn.HeaderText = "Date";
            this.srcCloseDateColumn.Name = "srcCloseDateColumn";
            this.srcCloseDateColumn.ReadOnly = true;
            this.srcCloseDateColumn.Width = 140;
            // 
            // srcClosePriceColumn
            // 
            this.srcClosePriceColumn.DataPropertyName = "price1";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.srcClosePriceColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.srcClosePriceColumn.HeaderText = "Close";
            this.srcClosePriceColumn.Name = "srcClosePriceColumn";
            this.srcClosePriceColumn.ReadOnly = true;
            // 
            // srcOpenPriceColumn
            // 
            this.srcOpenPriceColumn.DataPropertyName = "price2";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.srcOpenPriceColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.srcOpenPriceColumn.HeaderText = "Open";
            this.srcOpenPriceColumn.Name = "srcOpenPriceColumn";
            this.srcOpenPriceColumn.ReadOnly = true;
            // 
            // srcOpenDateColumn
            // 
            this.srcOpenDateColumn.DataPropertyName = "date2";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Format = "g";
            this.srcOpenDateColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.srcOpenDateColumn.HeaderText = "Date ";
            this.srcOpenDateColumn.Name = "srcOpenDateColumn";
            this.srcOpenDateColumn.ReadOnly = true;
            this.srcOpenDateColumn.Width = 140;
            // 
            // srcVarianceColumn
            // 
            this.srcVarianceColumn.DataPropertyName = "variance";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Format = "N3";
            dataGridViewCellStyle15.NullValue = null;
            this.srcVarianceColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.srcVarianceColumn.HeaderText = "+/-";
            this.srcVarianceColumn.Name = "srcVarianceColumn";
            this.srcVarianceColumn.ReadOnly = true;
            this.srcVarianceColumn.Width = 75;
            // 
            // srcSelectColumn
            // 
            this.srcSelectColumn.DataPropertyName = "variance";
            this.srcSelectColumn.HeaderText = "";
            this.srcSelectColumn.myValue = "";
            this.srcSelectColumn.Name = "srcSelectColumn";
            this.srcSelectColumn.ReadOnly = true;
            this.srcSelectColumn.Width = 25;
            // 
            // srcFrDateLbl
            // 
            this.srcFrDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcFrDateLbl.Location = new System.Drawing.Point(92, 4);
            this.srcFrDateLbl.Name = "srcFrDateLbl";
            this.srcFrDateLbl.Size = new System.Drawing.Size(88, 18);
            this.srcFrDateLbl.TabIndex = 168;
            this.srcFrDateLbl.Text = "Từ ngày";
            // 
            // srcFrDateEd
            // 
            this.srcFrDateEd.BeepOnError = true;
            this.srcFrDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcFrDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.srcFrDateEd.Location = new System.Drawing.Point(93, 23);
            this.srcFrDateEd.Mask = "00/00/0000";
            this.srcFrDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.srcFrDateEd.Name = "srcFrDateEd";
            this.srcFrDateEd.Size = new System.Drawing.Size(93, 24);
            this.srcFrDateEd.TabIndex = 1;
            // 
            // srcToDateLbl
            // 
            this.srcToDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcToDateLbl.Location = new System.Drawing.Point(185, 4);
            this.srcToDateLbl.Name = "srcToDateLbl";
            this.srcToDateLbl.Size = new System.Drawing.Size(88, 18);
            this.srcToDateLbl.TabIndex = 166;
            this.srcToDateLbl.Text = "Đến ngày";
            // 
            // srcToDateEd
            // 
            this.srcToDateEd.BeepOnError = true;
            this.srcToDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.srcToDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.srcToDateEd.Location = new System.Drawing.Point(186, 23);
            this.srcToDateEd.Mask = "00/00/0000";
            this.srcToDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.srcToDateEd.Name = "srcToDateEd";
            this.srcToDateEd.Size = new System.Drawing.Size(93, 24);
            this.srcToDateEd.TabIndex = 2;
            // 
            // varianceParamGb
            // 
            this.varianceParamGb.Controls.Add(this.checkVarianceEd);
            this.varianceParamGb.Controls.Add(this.baseLabel1);
            this.varianceParamGb.Controls.Add(this.checkVariancePercEd);
            this.varianceParamGb.Controls.Add(this.variancetLb);
            this.varianceParamGb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varianceParamGb.Location = new System.Drawing.Point(384, 3);
            this.varianceParamGb.Name = "varianceParamGb";
            this.varianceParamGb.Size = new System.Drawing.Size(206, 91);
            this.varianceParamGb.TabIndex = 30;
            this.varianceParamGb.TabStop = false;
            this.varianceParamGb.Text = "Variance";
            // 
            // checkVarianceEd
            // 
            this.checkVarianceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkVarianceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.checkVarianceEd.Location = new System.Drawing.Point(100, 52);
            this.checkVarianceEd.myFormat = "##0.#0";
            this.checkVarianceEd.Name = "checkVarianceEd";
            this.checkVarianceEd.Size = new System.Drawing.Size(70, 24);
            this.checkVarianceEd.TabIndex = 2;
            this.checkVarianceEd.Text = "1.00";
            this.checkVarianceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.checkVarianceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.checkVarianceEd.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            // 
            // baseLabel1
            // 
            this.baseLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel1.Location = new System.Drawing.Point(29, 53);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(66, 21);
            this.baseLabel1.TabIndex = 160;
            this.baseLabel1.Text = "Value";
            // 
            // checkVariancePercEd
            // 
            this.checkVariancePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkVariancePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.checkVariancePercEd.Location = new System.Drawing.Point(100, 20);
            this.checkVariancePercEd.myFormat = "##0.##0";
            this.checkVariancePercEd.Name = "checkVariancePercEd";
            this.checkVariancePercEd.Size = new System.Drawing.Size(70, 24);
            this.checkVariancePercEd.TabIndex = 1;
            this.checkVariancePercEd.Text = "0.050";
            this.checkVariancePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.checkVariancePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.checkVariancePercEd.Value = new decimal(new int[] {
            50,
            0,
            0,
            196608});
            // 
            // variancetLb
            // 
            this.variancetLb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variancetLb.Location = new System.Drawing.Point(29, 23);
            this.variancetLb.Name = "variancetLb";
            this.variancetLb.Size = new System.Drawing.Size(66, 21);
            this.variancetLb.TabIndex = 151;
            this.variancetLb.Text = "Percent";
            // 
            // dataAdjPg
            // 
            this.dataAdjPg.Controls.Add(this.dataAjustPnl);
            this.dataAdjPg.Controls.Add(this.dataAdjGb);
            this.dataAdjPg.Location = new System.Drawing.Point(4, 25);
            this.dataAdjPg.Name = "dataAdjPg";
            this.dataAdjPg.Padding = new System.Windows.Forms.Padding(3);
            this.dataAdjPg.Size = new System.Drawing.Size(750, 446);
            this.dataAdjPg.TabIndex = 1;
            this.dataAdjPg.Text = "Tools";
            this.dataAdjPg.UseVisualStyleBackColor = true;
            // 
            // dataAjustPnl
            // 
            this.dataAjustPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataAjustPnl.Controls.Add(this.dataAdjGrid);
            this.dataAjustPnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataAjustPnl.haveCloseButton = false;
            this.dataAjustPnl.isExpanded = true;
            this.dataAjustPnl.Location = new System.Drawing.Point(-1, 99);
            this.dataAjustPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.dataAjustPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.dataAjustPnl.myWeight = 0;
            this.dataAjustPnl.Name = "dataAjustPnl";
            this.dataAjustPnl.Size = new System.Drawing.Size(751, 345);
            this.dataAjustPnl.TabIndex = 10;
            // 
            // dataAdjGrid
            // 
            this.dataAdjGrid.AllowUserToAddRows = false;
            this.dataAdjGrid.AutoGenerateColumns = false;
            this.dataAdjGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAdjGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataOnDateColumn,
            this.dataHighPriceColumn,
            this.dataLowPriceColumn,
            this.dataOpenPriceColumn,
            this.dataClosePriceColumn,
            this.dataVolumeColumn,
            this.dataSelectColumn});
            this.dataAdjGrid.DataSource = this.priceDataSource;
            this.dataAdjGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataAdjGrid.Location = new System.Drawing.Point(0, 0);
            this.dataAdjGrid.Name = "dataAdjGrid";
            this.dataAdjGrid.RowTemplate.Height = 24;
            this.dataAdjGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAdjGrid.Size = new System.Drawing.Size(747, 341);
            this.dataAdjGrid.TabIndex = 10;
            this.dataAdjGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataAdjGrid_CellContentClick);
            // 
            // dataOnDateColumn
            // 
            this.dataOnDateColumn.DataPropertyName = "onDate";
            this.dataOnDateColumn.HeaderText = "Date/Time";
            this.dataOnDateColumn.Name = "dataOnDateColumn";
            this.dataOnDateColumn.Width = 140;
            // 
            // dataHighPriceColumn
            // 
            this.dataHighPriceColumn.DataPropertyName = "highPrice";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = null;
            this.dataHighPriceColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataHighPriceColumn.HeaderText = "High";
            this.dataHighPriceColumn.Name = "dataHighPriceColumn";
            // 
            // dataLowPriceColumn
            // 
            this.dataLowPriceColumn.DataPropertyName = "lowPrice";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = null;
            this.dataLowPriceColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataLowPriceColumn.HeaderText = "Low";
            this.dataLowPriceColumn.Name = "dataLowPriceColumn";
            // 
            // dataOpenPriceColumn
            // 
            this.dataOpenPriceColumn.DataPropertyName = "openPrice";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N2";
            dataGridViewCellStyle18.NullValue = null;
            this.dataOpenPriceColumn.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataOpenPriceColumn.HeaderText = "Open";
            this.dataOpenPriceColumn.Name = "dataOpenPriceColumn";
            // 
            // dataClosePriceColumn
            // 
            this.dataClosePriceColumn.DataPropertyName = "closePrice";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N2";
            dataGridViewCellStyle19.NullValue = null;
            this.dataClosePriceColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataClosePriceColumn.HeaderText = "Close";
            this.dataClosePriceColumn.Name = "dataClosePriceColumn";
            // 
            // dataVolumeColumn
            // 
            this.dataVolumeColumn.DataPropertyName = "volume";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Format = "N0";
            dataGridViewCellStyle20.NullValue = null;
            this.dataVolumeColumn.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataVolumeColumn.HeaderText = "Volume";
            this.dataVolumeColumn.Name = "dataVolumeColumn";
            this.dataVolumeColumn.Width = 120;
            // 
            // dataSelectColumn
            // 
            this.dataSelectColumn.DataPropertyName = "onDate";
            this.dataSelectColumn.HeaderText = "";
            this.dataSelectColumn.myValue = "";
            this.dataSelectColumn.Name = "dataSelectColumn";
            this.dataSelectColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataSelectColumn.Width = 25;
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
            this.dataAdjGb.Controls.Add(this.reAggregateBtn);
            this.dataAdjGb.Controls.Add(this.dataTimeScaleLbl);
            this.dataAdjGb.Controls.Add(this.dataTimeScaleCb);
            this.dataAdjGb.Controls.Add(this.testAdjustDataBtn);
            this.dataAdjGb.Controls.Add(this.varianceLbl);
            this.dataAdjGb.Controls.Add(this.dataVarianceEd);
            this.dataAdjGb.Controls.Add(this.loadPriceBtn);
            this.dataAdjGb.Controls.Add(this.saveDataBtn);
            this.dataAdjGb.Controls.Add(this.adjustToDateLbl);
            this.dataAdjGb.Controls.Add(this.adjWeightLbl);
            this.dataAdjGb.Controls.Add(this.dataToDateEd);
            this.dataAdjGb.Controls.Add(this.dataCodeLbl);
            this.dataAdjGb.Controls.Add(this.dataWeightEd);
            this.dataAdjGb.Controls.Add(this.dataCodeEd);
            this.dataAdjGb.Location = new System.Drawing.Point(6, -3);
            this.dataAdjGb.Name = "dataAdjGb";
            this.dataAdjGb.Size = new System.Drawing.Size(744, 99);
            this.dataAdjGb.TabIndex = 1;
            this.dataAdjGb.TabStop = false;
            // 
            // reAggregateBtn
            // 
            this.reAggregateBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reAggregateBtn.Image = global::admin.Properties.Resources.run;
            this.reAggregateBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.reAggregateBtn.isDownState = false;
            this.reAggregateBtn.Location = new System.Drawing.Point(453, 61);
            this.reAggregateBtn.Name = "reAggregateBtn";
            this.reAggregateBtn.Size = new System.Drawing.Size(107, 34);
            this.reAggregateBtn.TabIndex = 23;
            this.reAggregateBtn.Text = "Aggregate";
            this.reAggregateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reAggregateBtn.UseVisualStyleBackColor = true;
            this.reAggregateBtn.Click += new System.EventHandler(this.reAggregateBtn_Click);
            // 
            // dataTimeScaleLbl
            // 
            this.dataTimeScaleLbl.AutoSize = true;
            this.dataTimeScaleLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTimeScaleLbl.Location = new System.Drawing.Point(292, 11);
            this.dataTimeScaleLbl.Name = "dataTimeScaleLbl";
            this.dataTimeScaleLbl.Size = new System.Drawing.Size(74, 16);
            this.dataTimeScaleLbl.TabIndex = 174;
            this.dataTimeScaleLbl.Text = "Time scale";
            // 
            // dataTimeScaleCb
            // 
            this.dataTimeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataTimeScaleCb.Enabled = false;
            this.dataTimeScaleCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTimeScaleCb.FormattingEnabled = true;
            this.dataTimeScaleCb.Location = new System.Drawing.Point(293, 30);
            this.dataTimeScaleCb.Name = "dataTimeScaleCb";
            this.dataTimeScaleCb.SelectedValue = "RT";
            this.dataTimeScaleCb.Size = new System.Drawing.Size(98, 24);
            this.dataTimeScaleCb.TabIndex = 173;
            // 
            // testAdjustDataBtn
            // 
            this.testAdjustDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testAdjustDataBtn.Image = global::admin.Properties.Resources.select;
            this.testAdjustDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.testAdjustDataBtn.isDownState = false;
            this.testAdjustDataBtn.Location = new System.Drawing.Point(226, 61);
            this.testAdjustDataBtn.Name = "testAdjustDataBtn";
            this.testAdjustDataBtn.Size = new System.Drawing.Size(120, 34);
            this.testAdjustDataBtn.TabIndex = 21;
            this.testAdjustDataBtn.Text = "Auto-adjust";
            this.testAdjustDataBtn.UseVisualStyleBackColor = true;
            this.testAdjustDataBtn.Click += new System.EventHandler(this.testAdjustDataBtn_Click);
            // 
            // varianceLbl
            // 
            this.varianceLbl.AutoSize = true;
            this.varianceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varianceLbl.Location = new System.Drawing.Point(392, 12);
            this.varianceLbl.Name = "varianceLbl";
            this.varianceLbl.Size = new System.Drawing.Size(65, 16);
            this.varianceLbl.TabIndex = 172;
            this.varianceLbl.Text = "Variance";
            // 
            // dataVarianceEd
            // 
            this.dataVarianceEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataVarianceEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dataVarianceEd.Location = new System.Drawing.Point(390, 30);
            this.dataVarianceEd.myFormat = "##0.##0";
            this.dataVarianceEd.Name = "dataVarianceEd";
            this.dataVarianceEd.Size = new System.Drawing.Size(75, 24);
            this.dataVarianceEd.TabIndex = 3;
            this.dataVarianceEd.Text = "0.050";
            this.dataVarianceEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataVarianceEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dataVarianceEd.Value = new decimal(new int[] {
            50,
            0,
            0,
            196608});
            this.dataVarianceEd.Validated += new System.EventHandler(this.varianceEd_Validated);
            // 
            // loadPriceBtn
            // 
            this.loadPriceBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadPriceBtn.Image = global::admin.Properties.Resources.refresh;
            this.loadPriceBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadPriceBtn.isDownState = false;
            this.loadPriceBtn.Location = new System.Drawing.Point(119, 61);
            this.loadPriceBtn.Name = "loadPriceBtn";
            this.loadPriceBtn.Size = new System.Drawing.Size(107, 34);
            this.loadPriceBtn.TabIndex = 20;
            this.loadPriceBtn.Text = "Load";
            this.loadPriceBtn.UseVisualStyleBackColor = true;
            this.loadPriceBtn.Click += new System.EventHandler(this.loadPriceBtn_Click);
            // 
            // saveDataBtn
            // 
            this.saveDataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDataBtn.Image = global::admin.Properties.Resources.save;
            this.saveDataBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveDataBtn.isDownState = false;
            this.saveDataBtn.Location = new System.Drawing.Point(346, 61);
            this.saveDataBtn.Name = "saveDataBtn";
            this.saveDataBtn.Size = new System.Drawing.Size(107, 34);
            this.saveDataBtn.TabIndex = 22;
            this.saveDataBtn.Text = "Save";
            this.saveDataBtn.UseVisualStyleBackColor = true;
            this.saveDataBtn.Click += new System.EventHandler(this.saveDataBtn_Click);
            // 
            // adjustToDateLbl
            // 
            this.adjustToDateLbl.AutoSize = true;
            this.adjustToDateLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustToDateLbl.Location = new System.Drawing.Point(118, 11);
            this.adjustToDateLbl.Name = "adjustToDateLbl";
            this.adjustToDateLbl.Size = new System.Drawing.Size(70, 16);
            this.adjustToDateLbl.TabIndex = 164;
            this.adjustToDateLbl.Text = "Đến ngày";
            // 
            // adjWeightLbl
            // 
            this.adjWeightLbl.AutoSize = true;
            this.adjWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjWeightLbl.Location = new System.Drawing.Point(464, 12);
            this.adjWeightLbl.Name = "adjWeightLbl";
            this.adjWeightLbl.Size = new System.Drawing.Size(94, 16);
            this.adjWeightLbl.TabIndex = 170;
            this.adjWeightLbl.Text = "HS điều chỉnh";
            // 
            // dataToDateEd
            // 
            this.dataToDateEd.BeepOnError = true;
            this.dataToDateEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataToDateEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dataToDateEd.Location = new System.Drawing.Point(119, 30);
            this.dataToDateEd.Mask = "00/00/0000";
            this.dataToDateEd.myDateTime = new System.DateTime(((long)(0)));
            this.dataToDateEd.Name = "dataToDateEd";
            this.dataToDateEd.Size = new System.Drawing.Size(93, 24);
            this.dataToDateEd.TabIndex = 1;
            // 
            // dataCodeLbl
            // 
            this.dataCodeLbl.AutoSize = true;
            this.dataCodeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCodeLbl.Location = new System.Drawing.Point(213, 12);
            this.dataCodeLbl.Name = "dataCodeLbl";
            this.dataCodeLbl.Size = new System.Drawing.Size(46, 16);
            this.dataCodeLbl.TabIndex = 169;
            this.dataCodeLbl.Text = "Mã số";
            // 
            // dataWeightEd
            // 
            this.dataWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dataWeightEd.Location = new System.Drawing.Point(465, 30);
            this.dataWeightEd.myFormat = " ##0.##0";
            this.dataWeightEd.Name = "dataWeightEd";
            this.dataWeightEd.Size = new System.Drawing.Size(94, 24);
            this.dataWeightEd.TabIndex = 10;
            this.dataWeightEd.TabStop = false;
            this.dataWeightEd.Text = "0.050";
            this.dataWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataWeightEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.dataWeightEd.Value = new decimal(new int[] {
            50,
            0,
            0,
            196608});
            this.dataWeightEd.Validated += new System.EventHandler(this.adjWeightEd_Validated);
            // 
            // dataCodeEd
            // 
            this.dataCodeEd.BackColor = System.Drawing.Color.White;
            this.dataCodeEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCodeEd.ForeColor = System.Drawing.Color.Black;
            this.dataCodeEd.isRequired = true;
            this.dataCodeEd.isToUpperCase = true;
            this.dataCodeEd.Location = new System.Drawing.Point(212, 30);
            this.dataCodeEd.Name = "dataCodeEd";
            this.dataCodeEd.Size = new System.Drawing.Size(82, 24);
            this.dataCodeEd.TabIndex = 2;
            // 
            // dataTools
            // 
            this.ClientSize = new System.Drawing.Size(776, 496);
            this.Controls.Add(this.tabControl);
            this.Name = "dataTools";
            this.Text = "Data tools";
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.priceDiagnoseSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.searchPg.ResumeLayout(false);
            this.searchPg.PerformLayout();
            this.resultPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.varianceParamGb.ResumeLayout(false);
            this.varianceParamGb.PerformLayout();
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

        private baseClass.controls.baseLabel exchangeLbl;
        private baseClass.controls.baseButton diagnoseBtn;
        private common.controls.numberTextBox checkVariancePercEd;
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
        protected baseClass.controls.baseButton saveDataBtn;
        protected common.controls.baseDate dataToDateEd;
        protected common.controls.numberTextBox dataWeightEd;
        protected baseClass.controls.txtStockCode dataCodeEd;
        protected common.controls.baseLabel dataCodeLbl;
        protected common.controls.baseLabel adjWeightLbl;
        protected System.Windows.Forms.GroupBox dataAdjGb;
        protected baseClass.controls.baseButton loadPriceBtn;
        protected common.controls.baseDataGridView dataAdjGrid;
        protected databases.baseDS baseDS;
        protected System.Windows.Forms.BindingSource priceDataSource;
        protected databases.tmpDS tmpDS;
        protected System.Windows.Forms.BindingSource priceDiagnoseSource;
        protected common.controls.baseLabel adjustToDateLbl;
        protected common.controls.baseLabel varianceLbl;
        protected common.controls.numberTextBox dataVarianceEd;
        protected baseClass.controls.baseButton testAdjustDataBtn;
        protected baseClass.controls.baseButton reAggregateBtn;
        private baseClass.controls.baseLabel dataTimeScaleLbl;
        private baseClass.controls.cbTimeScale dataTimeScaleCb;
        private System.Windows.Forms.GroupBox varianceParamGb;
        private baseClass.controls.baseLabel baseLabel1;
        private baseClass.controls.baseLabel variancetLb;
        protected common.controls.baseLabel srcFrDateLbl;
        protected common.controls.baseDate srcFrDateEd;
        protected common.controls.baseLabel srcToDateLbl;
        protected common.controls.baseDate srcToDateEd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataOnDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataHighPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataLowPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataOpenPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataClosePriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataVolumeColumn;
        private common.controls.gridViewImageColumn dataSelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcCloseDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcClosePriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcOpenPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcOpenDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn srcVarianceColumn;
        private common.controls.gridViewImageColumn srcSelectColumn;
        protected common.controls.baseLabel srcCodeLbl;
        protected baseClass.controls.txtStockCode srcCodeEd;
    }
}
