namespace baseClass.forms
{
    partial class stockExchangeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stockExchangeEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.listGrid = new common.controls.baseDataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockExchangeSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeLbl = new baseClass.controls.baseLabel();
            this.codeEd = new common.controls.baseTextBox();
            this.nameEd = new common.controls.baseTextBox();
            this.nameLbl = new baseClass.controls.baseLabel();
            this.weightLbl = new baseClass.controls.baseLabel();
            this.weightEd = new common.controls.baseTextBox();
            this.countryCb = new baseClass.controls.cbCountry();
            this.countryLbl = new baseClass.controls.baseLabel();
            this.workTimeLbl = new baseClass.controls.baseLabel();
            this.workTimeEd = new common.controls.baseTextBox();
            this.hodidayLbl = new baseClass.controls.baseLabel();
            this.volumeWeightEd = new common.controls.numberTextBox();
            this.transFeePercLbl = new baseClass.controls.baseLabel();
            this.volumeWeightLbl = new baseClass.controls.baseLabel();
            this.buy2SellInDaysLbl = new baseClass.controls.baseLabel();
            this.priceWeightLbl = new baseClass.controls.baseLabel();
            this.buy2SellIntervalEd = new System.Windows.Forms.NumericUpDown();
            this.priceWeightEd = new common.controls.numberTextBox();
            this.transFeePercEd = new common.controls.numberTextBox();
            this.priceAmplitudeEd = new common.controls.numberTextBox();
            this.priceAmplitudeLbl = new baseClass.controls.baseLabel();
            this.dataSourcePnl = new common.controls.basePanel();
            this.dataSourceGrid = new common.controls.baseDataGridView();
            this.sourceCode = new common.controls.DataGridViewTextBoxColumnExt();
            this.addressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goTrueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goFalseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.exchangeDetailSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS = new databases.tmpDS();
            this.hodidayEd = new common.controls.baseTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockExchangeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buy2SellIntervalEd)).BeginInit();
            this.dataSourcePnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exchangeDetailSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-12, -5);
            this.toolBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Size = new System.Drawing.Size(630, 49);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(486, 5);
            this.exitBtn.Size = new System.Drawing.Size(95, 39);
            this.exitBtn.Text = "Close";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(106, 5);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveBtn.Size = new System.Drawing.Size(95, 39);
            this.saveBtn.Text = "Save";
            this.myToolTip.SetToolTip(this.saveBtn, "Lưu dữ liệu - [F2]");
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(201, 5);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.deleteBtn.Size = new System.Drawing.Size(95, 39);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(296, 5);
            this.editBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.editBtn.Size = new System.Drawing.Size(95, 39);
            this.editBtn.Text = "Lock";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(11, 5);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.addNewBtn.Size = new System.Drawing.Size(95, 39);
            this.myToolTip.SetToolTip(this.addNewBtn, "Thêm dữ liệu mới - [F3]");
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(702, 17);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toExcelBtn.Size = new System.Drawing.Size(64, 39);
            this.toExcelBtn.Text = "Export";
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(643, 12);
            this.findBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(391, 5);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.reloadBtn.Size = new System.Drawing.Size(95, 39);
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(742, 327);
            this.unLockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.unLockBtn.Size = new System.Drawing.Size(34, 26);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(723, 260);
            this.lockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lockBtn.Size = new System.Drawing.Size(34, 26);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(647, 11);
            this.printBtn.Size = new System.Drawing.Size(64, 39);
            this.printBtn.Text = "&Print";
            this.printBtn.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(635, 163);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLbl.Size = new System.Drawing.Size(337, 25);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Text = "THÔNG TIN NHÓM PHÂN LOẠI";
            // 
            // listGrid
            // 
            this.listGrid.AllowUserToAddRows = false;
            this.listGrid.AllowUserToDeleteRows = false;
            this.listGrid.AllowUserToOrderColumns = true;
            this.listGrid.AutoGenerateColumns = false;
            this.listGrid.ColumnHeadersHeight = 25;
            this.listGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.nameColumn});
            this.listGrid.DataSource = this.stockExchangeSource;
            this.listGrid.Location = new System.Drawing.Point(575, -1);
            this.listGrid.Name = "listGrid";
            this.listGrid.ReadOnly = true;
            this.listGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGrid.RowTemplate.Height = 24;
            this.listGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listGrid.Size = new System.Drawing.Size(459, 508);
            this.listGrid.TabIndex = 153;
            this.listGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.listGrid_DataError);
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "description";
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.Width = 300;
            // 
            // stockExchangeSource
            // 
            this.stockExchangeSource.DataMember = "stockExchange";
            this.stockExchangeSource.DataSource = this.myDataSet;
            this.stockExchangeSource.CurrentChanged += new System.EventHandler(this.stockExchangeSource_CurrentChanged);
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(43, 51);
            this.codeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(52, 16);
            this.codeLbl.TabIndex = 165;
            this.codeLbl.Text = "Code *";
            // 
            // codeEd
            // 
            this.codeEd.BackColor = System.Drawing.SystemColors.Window;
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "code", true));
            this.codeEd.isRequired = true;
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(43, 70);
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(102, 23);
            this.codeEd.TabIndex = 1;
            this.codeEd.Validating += new System.ComponentModel.CancelEventHandler(this.codeEd_Validating);
            // 
            // nameEd
            // 
            this.nameEd.BackColor = System.Drawing.SystemColors.Window;
            this.nameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "description", true));
            this.nameEd.isRequired = true;
            this.nameEd.isToUpperCase = false;
            this.nameEd.Location = new System.Drawing.Point(145, 70);
            this.nameEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(388, 23);
            this.nameEd.TabIndex = 10;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(145, 51);
            this.nameLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(55, 16);
            this.nameLbl.TabIndex = 164;
            this.nameLbl.Text = "Name *";
            // 
            // weightLbl
            // 
            this.weightLbl.AutoSize = true;
            this.weightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLbl.Location = new System.Drawing.Point(199, 325);
            this.weightLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.weightLbl.Name = "weightLbl";
            this.weightLbl.Size = new System.Drawing.Size(54, 16);
            this.weightLbl.TabIndex = 175;
            this.weightLbl.Text = "Weight";
            // 
            // weightEd
            // 
            this.weightEd.BackColor = System.Drawing.SystemColors.Window;
            this.weightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "weight", true));
            this.weightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightEd.isRequired = true;
            this.weightEd.isToUpperCase = false;
            this.weightEd.Location = new System.Drawing.Point(199, 343);
            this.weightEd.Name = "weightEd";
            this.weightEd.Size = new System.Drawing.Size(96, 24);
            this.weightEd.TabIndex = 50;
            // 
            // countryCb
            // 
            this.countryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.stockExchangeSource, "country", true));
            this.countryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCb.FormattingEnabled = true;
            this.countryCb.Location = new System.Drawing.Point(43, 118);
            this.countryCb.myValue = "";
            this.countryCb.Name = "countryCb";
            this.countryCb.Size = new System.Drawing.Size(250, 24);
            this.countryCb.TabIndex = 20;
            // 
            // countryLbl
            // 
            this.countryLbl.AutoSize = true;
            this.countryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLbl.Location = new System.Drawing.Point(43, 99);
            this.countryLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.countryLbl.Name = "countryLbl";
            this.countryLbl.Size = new System.Drawing.Size(76, 16);
            this.countryLbl.TabIndex = 177;
            this.countryLbl.Text = "Country  *";
            // 
            // workTimeLbl
            // 
            this.workTimeLbl.AutoSize = true;
            this.workTimeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workTimeLbl.Location = new System.Drawing.Point(43, 198);
            this.workTimeLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.workTimeLbl.Name = "workTimeLbl";
            this.workTimeLbl.Size = new System.Drawing.Size(77, 16);
            this.workTimeLbl.TabIndex = 179;
            this.workTimeLbl.Text = "Work days";
            // 
            // workTimeEd
            // 
            this.workTimeEd.BackColor = System.Drawing.SystemColors.Window;
            this.workTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "workTime", true));
            this.workTimeEd.isRequired = true;
            this.workTimeEd.isToUpperCase = false;
            this.workTimeEd.Location = new System.Drawing.Point(43, 216);
            this.workTimeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.workTimeEd.Multiline = true;
            this.workTimeEd.Name = "workTimeEd";
            this.workTimeEd.Size = new System.Drawing.Size(491, 49);
            this.workTimeEd.TabIndex = 40;
            // 
            // hodidayLbl
            // 
            this.hodidayLbl.AutoSize = true;
            this.hodidayLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hodidayLbl.Location = new System.Drawing.Point(43, 273);
            this.hodidayLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hodidayLbl.Name = "hodidayLbl";
            this.hodidayLbl.Size = new System.Drawing.Size(62, 16);
            this.hodidayLbl.TabIndex = 181;
            this.hodidayLbl.Text = "Holidays";
            // 
            // volumeWeightEd
            // 
            this.volumeWeightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "volumeRatio", true));
            this.volumeWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.volumeWeightEd.Location = new System.Drawing.Point(289, 168);
            this.volumeWeightEd.myFormat = "###,###,###,###,###";
            this.volumeWeightEd.Name = "volumeWeightEd";
            this.volumeWeightEd.Size = new System.Drawing.Size(123, 23);
            this.volumeWeightEd.TabIndex = 32;
            this.volumeWeightEd.TabStop = false;
            this.volumeWeightEd.Text = "10";
            this.volumeWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.volumeWeightEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.volumeWeightEd.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // transFeePercLbl
            // 
            this.transFeePercLbl.AutoSize = true;
            this.transFeePercLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transFeePercLbl.Location = new System.Drawing.Point(43, 149);
            this.transFeePercLbl.Name = "transFeePercLbl";
            this.transFeePercLbl.Size = new System.Drawing.Size(95, 16);
            this.transFeePercLbl.TabIndex = 320;
            this.transFeePercLbl.Text = "Trans fee(%)";
            this.transFeePercLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // volumeWeightLbl
            // 
            this.volumeWeightLbl.AutoSize = true;
            this.volumeWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeWeightLbl.Location = new System.Drawing.Point(292, 149);
            this.volumeWeightLbl.Name = "volumeWeightLbl";
            this.volumeWeightLbl.Size = new System.Drawing.Size(90, 16);
            this.volumeWeightLbl.TabIndex = 325;
            this.volumeWeightLbl.Text = "Volume ratio";
            this.volumeWeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buy2SellInDaysLbl
            // 
            this.buy2SellInDaysLbl.AutoSize = true;
            this.buy2SellInDaysLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buy2SellInDaysLbl.Location = new System.Drawing.Point(43, 323);
            this.buy2SellInDaysLbl.Name = "buy2SellInDaysLbl";
            this.buy2SellInDaysLbl.Size = new System.Drawing.Size(109, 16);
            this.buy2SellInDaysLbl.TabIndex = 321;
            this.buy2SellInDaysLbl.Text = "Lock sell (days)";
            this.buy2SellInDaysLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceWeightLbl
            // 
            this.priceWeightLbl.AutoSize = true;
            this.priceWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceWeightLbl.Location = new System.Drawing.Point(168, 149);
            this.priceWeightLbl.Name = "priceWeightLbl";
            this.priceWeightLbl.Size = new System.Drawing.Size(75, 16);
            this.priceWeightLbl.TabIndex = 322;
            this.priceWeightLbl.Text = "Price ratio";
            this.priceWeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buy2SellIntervalEd
            // 
            this.buy2SellIntervalEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.stockExchangeSource, "minBuySellDay", true));
            this.buy2SellIntervalEd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buy2SellIntervalEd.Location = new System.Drawing.Point(43, 342);
            this.buy2SellIntervalEd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.buy2SellIntervalEd.Name = "buy2SellIntervalEd";
            this.buy2SellIntervalEd.Size = new System.Drawing.Size(157, 26);
            this.buy2SellIntervalEd.TabIndex = 33;
            this.buy2SellIntervalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buy2SellIntervalEd.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // priceWeightEd
            // 
            this.priceWeightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "priceRatio", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.priceWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.priceWeightEd.Location = new System.Drawing.Point(166, 168);
            this.priceWeightEd.myFormat = "###,###,###,###,###";
            this.priceWeightEd.Name = "priceWeightEd";
            this.priceWeightEd.Size = new System.Drawing.Size(123, 23);
            this.priceWeightEd.TabIndex = 31;
            this.priceWeightEd.TabStop = false;
            this.priceWeightEd.Text = "1,000";
            this.priceWeightEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priceWeightEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.priceWeightEd.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // transFeePercEd
            // 
            this.transFeePercEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "tranFeePerc", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.transFeePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.transFeePercEd.Location = new System.Drawing.Point(43, 168);
            this.transFeePercEd.myFormat = "###,##0.#0";
            this.transFeePercEd.Name = "transFeePercEd";
            this.transFeePercEd.Size = new System.Drawing.Size(123, 23);
            this.transFeePercEd.TabIndex = 30;
            this.transFeePercEd.TabStop = false;
            this.transFeePercEd.Text = "0.20";
            this.transFeePercEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.transFeePercEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.transFeePercEd.Value = new decimal(new int[] {
            20,
            0,
            0,
            131072});
            // 
            // priceAmplitudeEd
            // 
            this.priceAmplitudeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "priceAmplitude", true));
            this.priceAmplitudeEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.priceAmplitudeEd.Location = new System.Drawing.Point(412, 168);
            this.priceAmplitudeEd.myFormat = "##0.00";
            this.priceAmplitudeEd.Name = "priceAmplitudeEd";
            this.priceAmplitudeEd.Size = new System.Drawing.Size(123, 23);
            this.priceAmplitudeEd.TabIndex = 33;
            this.priceAmplitudeEd.TabStop = false;
            this.priceAmplitudeEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priceAmplitudeEd.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.priceAmplitudeEd.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // priceAmplitudeLbl
            // 
            this.priceAmplitudeLbl.AutoSize = true;
            this.priceAmplitudeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceAmplitudeLbl.Location = new System.Drawing.Point(411, 149);
            this.priceAmplitudeLbl.Name = "priceAmplitudeLbl";
            this.priceAmplitudeLbl.Size = new System.Drawing.Size(73, 16);
            this.priceAmplitudeLbl.TabIndex = 3193345;
            this.priceAmplitudeLbl.Text = "Amplitude";
            this.priceAmplitudeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataSourcePnl
            // 
            this.dataSourcePnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataSourcePnl.Controls.Add(this.dataSourceGrid);
            this.dataSourcePnl.haveCloseButton = true;
            this.dataSourcePnl.isExpanded = true;
            this.dataSourcePnl.Location = new System.Drawing.Point(-1, 372);
            this.dataSourcePnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.dataSourcePnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.dataSourcePnl.myWeight = 0;
            this.dataSourcePnl.Name = "dataSourcePnl";
            this.dataSourcePnl.Size = new System.Drawing.Size(576, 137);
            this.dataSourcePnl.TabIndex = 3193346;
            // 
            // dataSourceGrid
            // 
            this.dataSourceGrid.AutoGenerateColumns = false;
            this.dataSourceGrid.ColumnHeadersHeight = 25;
            this.dataSourceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sourceCode,
            this.addressColumn,
            this.goTrueColumn,
            this.goFalseColumn,
            this.orderIdColumn,
            this.isEnabled});
            this.dataSourceGrid.DataSource = this.exchangeDetailSource;
            this.dataSourceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSourceGrid.Location = new System.Drawing.Point(0, 0);
            this.dataSourceGrid.Name = "dataSourceGrid";
            this.dataSourceGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSourceGrid.RowTemplate.Height = 24;
            this.dataSourceGrid.Size = new System.Drawing.Size(572, 133);
            this.dataSourceGrid.TabIndex = 154;
            this.dataSourceGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataSourceGrid_DefaultValuesNeeded);
            // 
            // sourceCode
            // 
            this.sourceCode.DataPropertyName = "code";
            this.sourceCode.HeaderText = "Code";
            this.sourceCode.Name = "sourceCode";
            this.sourceCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sourceCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sourceCode.Uppercase = false;
            this.sourceCode.Width = 120;
            // 
            // addressColumn
            // 
            this.addressColumn.DataPropertyName = "address";
            this.addressColumn.HeaderText = "Address";
            this.addressColumn.Name = "addressColumn";
            this.addressColumn.Width = 300;
            // 
            // goTrueColumn
            // 
            this.goTrueColumn.DataPropertyName = "goTrue";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.goTrueColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.goTrueColumn.HeaderText = "When True";
            this.goTrueColumn.Name = "goTrueColumn";
            this.goTrueColumn.Width = 120;
            // 
            // goFalseColumn
            // 
            this.goFalseColumn.DataPropertyName = "goFalse";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.goFalseColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.goFalseColumn.HeaderText = "When False";
            this.goFalseColumn.Name = "goFalseColumn";
            this.goFalseColumn.Width = 120;
            // 
            // orderIdColumn
            // 
            this.orderIdColumn.DataPropertyName = "orderId";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.orderIdColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.orderIdColumn.HeaderText = "#";
            this.orderIdColumn.Name = "orderIdColumn";
            this.orderIdColumn.ReadOnly = true;
            this.orderIdColumn.Width = 30;
            // 
            // isEnabled
            // 
            this.isEnabled.DataPropertyName = "isEnabled";
            this.isEnabled.HeaderText = "";
            this.isEnabled.Name = "isEnabled";
            this.isEnabled.Width = 20;
            // 
            // exchangeDetailSource
            // 
            this.exchangeDetailSource.DataMember = "exchangeDetail";
            this.exchangeDetailSource.DataSource = this.myDataSet;
            // 
            // tmpDS
            // 
            this.tmpDS.DataSetName = "tmpDS";
            this.tmpDS.EnforceConstraints = false;
            this.tmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hodidayEd
            // 
            this.hodidayEd.BackColor = System.Drawing.SystemColors.Window;
            this.hodidayEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "holidays", true));
            this.hodidayEd.isRequired = true;
            this.hodidayEd.isToUpperCase = false;
            this.hodidayEd.Location = new System.Drawing.Point(43, 291);
            this.hodidayEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.hodidayEd.Name = "hodidayEd";
            this.hodidayEd.Size = new System.Drawing.Size(491, 23);
            this.hodidayEd.TabIndex = 41;
            // 
            // stockExchangeEdit
            // 
            this.ClientSize = new System.Drawing.Size(1033, 531);
            this.Controls.Add(this.dataSourcePnl);
            this.Controls.Add(this.listGrid);
            this.Controls.Add(this.priceAmplitudeLbl);
            this.Controls.Add(this.priceAmplitudeEd);
            this.Controls.Add(this.volumeWeightEd);
            this.Controls.Add(this.transFeePercLbl);
            this.Controls.Add(this.volumeWeightLbl);
            this.Controls.Add(this.buy2SellInDaysLbl);
            this.Controls.Add(this.priceWeightLbl);
            this.Controls.Add(this.buy2SellIntervalEd);
            this.Controls.Add(this.priceWeightEd);
            this.Controls.Add(this.transFeePercEd);
            this.Controls.Add(this.hodidayLbl);
            this.Controls.Add(this.hodidayEd);
            this.Controls.Add(this.workTimeLbl);
            this.Controls.Add(this.workTimeEd);
            this.Controls.Add(this.countryLbl);
            this.Controls.Add(this.countryCb);
            this.Controls.Add(this.weightLbl);
            this.Controls.Add(this.weightEd);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.codeEd);
            this.Controls.Add(this.nameEd);
            this.Controls.Add(this.nameLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "stockExchangeEdit";
            this.Text = "Stock Exchange";
            this.Controls.SetChildIndex(this.nameLbl, 0);
            this.Controls.SetChildIndex(this.nameEd, 0);
            this.Controls.SetChildIndex(this.codeEd, 0);
            this.Controls.SetChildIndex(this.codeLbl, 0);
            this.Controls.SetChildIndex(this.weightEd, 0);
            this.Controls.SetChildIndex(this.weightLbl, 0);
            this.Controls.SetChildIndex(this.countryCb, 0);
            this.Controls.SetChildIndex(this.countryLbl, 0);
            this.Controls.SetChildIndex(this.workTimeEd, 0);
            this.Controls.SetChildIndex(this.workTimeLbl, 0);
            this.Controls.SetChildIndex(this.hodidayEd, 0);
            this.Controls.SetChildIndex(this.hodidayLbl, 0);
            this.Controls.SetChildIndex(this.transFeePercEd, 0);
            this.Controls.SetChildIndex(this.priceWeightEd, 0);
            this.Controls.SetChildIndex(this.buy2SellIntervalEd, 0);
            this.Controls.SetChildIndex(this.priceWeightLbl, 0);
            this.Controls.SetChildIndex(this.buy2SellInDaysLbl, 0);
            this.Controls.SetChildIndex(this.volumeWeightLbl, 0);
            this.Controls.SetChildIndex(this.transFeePercLbl, 0);
            this.Controls.SetChildIndex(this.volumeWeightEd, 0);
            this.Controls.SetChildIndex(this.priceAmplitudeEd, 0);
            this.Controls.SetChildIndex(this.priceAmplitudeLbl, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.listGrid, 0);
            this.Controls.SetChildIndex(this.dataSourcePnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockExchangeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buy2SellIntervalEd)).EndInit();
            this.dataSourcePnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSourceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exchangeDetailSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private baseClass.controls.baseLabel codeLbl;
        private common.controls.baseTextBox codeEd;
        private common.controls.baseTextBox nameEd;
        private baseClass.controls.baseLabel nameLbl;
        private System.Windows.Forms.BindingSource stockExchangeSource;
        private baseClass.controls.baseLabel weightLbl;
        private common.controls.baseTextBox weightEd;
        private common.controls.baseDataGridView listGrid;
        private baseClass.controls.baseLabel countryLbl;
        private baseClass.controls.cbCountry countryCb;
        private baseClass.controls.baseLabel workTimeLbl;
        private common.controls.baseTextBox workTimeEd;
        private baseClass.controls.baseLabel hodidayLbl;
        protected common.controls.numberTextBox volumeWeightEd;
        protected baseClass.controls.baseLabel transFeePercLbl;
        protected baseClass.controls.baseLabel volumeWeightLbl;
        protected baseClass.controls.baseLabel buy2SellInDaysLbl;
        protected baseClass.controls.baseLabel priceWeightLbl;
        private System.Windows.Forms.NumericUpDown buy2SellIntervalEd;
        protected common.controls.numberTextBox priceWeightEd;
        protected common.controls.numberTextBox transFeePercEd;
        protected common.controls.numberTextBox priceAmplitudeEd;
        protected baseClass.controls.baseLabel priceAmplitudeLbl;
        private common.controls.basePanel dataSourcePnl;
        private common.controls.baseDataGridView dataSourceGrid;
        private System.Windows.Forms.BindingSource exchangeDetailSource;
        private common.controls.baseTextBox hodidayEd;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private databases.tmpDS tmpDS;
        private common.controls.DataGridViewTextBoxColumnExt sourceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goTrueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goFalseColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabled;
    }
}