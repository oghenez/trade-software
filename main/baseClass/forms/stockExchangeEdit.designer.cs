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
            this.hodidayEd = new common.controls.baseTextBox();
            this.volumeWeightEd = new common.controls.numberTextBox();
            this.transFeePercLbl = new baseClass.controls.baseLabel();
            this.volumeWeightLbl = new baseClass.controls.baseLabel();
            this.buy2SellIntervalLbl = new baseClass.controls.baseLabel();
            this.priceWeightLbl = new baseClass.controls.baseLabel();
            this.buy2SellIntervalEd = new System.Windows.Forms.NumericUpDown();
            this.priceWeightEd = new common.controls.numberTextBox();
            this.transFeePercEd = new common.controls.numberTextBox();
            this.dataSourceLbl = new baseClass.controls.baseLabel();
            this.dataSourceEd = new common.controls.baseTextBox();
            this.daysLbl = new baseClass.controls.baseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockExchangeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buy2SellIntervalEd)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-10, -11);
            this.toolBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Size = new System.Drawing.Size(684, 57);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(390, 11);
            this.exitBtn.Size = new System.Drawing.Size(76, 39);
            this.exitBtn.Text = "Close";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(86, 11);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveBtn.Size = new System.Drawing.Size(76, 39);
            this.saveBtn.Text = "Save";
            this.myToolTip.SetToolTip(this.saveBtn, "Lưu dữ liệu - [F2]");
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(162, 11);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.deleteBtn.Size = new System.Drawing.Size(76, 39);
            // 
            // editBtn
            // 
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(238, 11);
            this.editBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.editBtn.Size = new System.Drawing.Size(76, 39);
            this.editBtn.Text = "Lock";
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(10, 11);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.addNewBtn.Size = new System.Drawing.Size(76, 39);
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
            this.findBtn.Location = new System.Drawing.Point(604, 12);
            this.findBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(314, 11);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.reloadBtn.Size = new System.Drawing.Size(76, 39);
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
            this.printBtn.Location = new System.Drawing.Point(608, 11);
            this.printBtn.Size = new System.Drawing.Size(64, 39);
            this.printBtn.Text = "&Print";
            this.printBtn.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(635, 163);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLbl.Size = new System.Drawing.Size(307, 24);
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
            this.listGrid.DisableReadOnlyColumn = true;
            this.listGrid.Location = new System.Drawing.Point(457, 0);
            this.listGrid.Name = "listGrid";
            this.listGrid.ReadOnly = true;
            this.listGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listGrid.Size = new System.Drawing.Size(479, 571);
            this.listGrid.TabIndex = 153;
            this.listGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.listGrid_DataError);
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 120;
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
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(24, 58);
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
            this.codeEd.isToUpperCase = false;
            this.codeEd.Location = new System.Drawing.Point(24, 79);
            this.codeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.codeEd.Name = "codeEd";
            this.codeEd.Size = new System.Drawing.Size(132, 23);
            this.codeEd.TabIndex = 1;
            this.codeEd.Validating += new System.ComponentModel.CancelEventHandler(this.codeEd_Validating);
            // 
            // nameEd
            // 
            this.nameEd.BackColor = System.Drawing.SystemColors.Window;
            this.nameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "description", true));
            this.nameEd.isToUpperCase = false;
            this.nameEd.Location = new System.Drawing.Point(24, 128);
            this.nameEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.nameEd.Name = "nameEd";
            this.nameEd.Size = new System.Drawing.Size(411, 23);
            this.nameEd.TabIndex = 10;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(24, 107);
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
            this.weightLbl.Location = new System.Drawing.Point(24, 517);
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
            this.weightEd.isToUpperCase = false;
            this.weightEd.Location = new System.Drawing.Point(24, 538);
            this.weightEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.weightEd.Name = "weightEd";
            this.weightEd.Size = new System.Drawing.Size(96, 23);
            this.weightEd.TabIndex = 50;
            // 
            // countryCb
            // 
            this.countryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.stockExchangeSource, "country", true));
            this.countryCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryCb.FormattingEnabled = true;
            this.countryCb.Location = new System.Drawing.Point(24, 179);
            this.countryCb.myValue = "";
            this.countryCb.Name = "countryCb";
            this.countryCb.Size = new System.Drawing.Size(411, 24);
            this.countryCb.TabIndex = 20;
            // 
            // countryLbl
            // 
            this.countryLbl.AutoSize = true;
            this.countryLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLbl.Location = new System.Drawing.Point(24, 158);
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
            this.workTimeLbl.Location = new System.Drawing.Point(24, 317);
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
            this.workTimeEd.isToUpperCase = false;
            this.workTimeEd.Location = new System.Drawing.Point(24, 338);
            this.workTimeEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.workTimeEd.Multiline = true;
            this.workTimeEd.Name = "workTimeEd";
            this.workTimeEd.Size = new System.Drawing.Size(411, 49);
            this.workTimeEd.TabIndex = 40;
            // 
            // hodidayLbl
            // 
            this.hodidayLbl.AutoSize = true;
            this.hodidayLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hodidayLbl.Location = new System.Drawing.Point(24, 393);
            this.hodidayLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hodidayLbl.Name = "hodidayLbl";
            this.hodidayLbl.Size = new System.Drawing.Size(62, 16);
            this.hodidayLbl.TabIndex = 181;
            this.hodidayLbl.Text = "Holidays";
            // 
            // hodidayEd
            // 
            this.hodidayEd.BackColor = System.Drawing.SystemColors.Window;
            this.hodidayEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "holidays", true));
            this.hodidayEd.isToUpperCase = false;
            this.hodidayEd.Location = new System.Drawing.Point(24, 414);
            this.hodidayEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.hodidayEd.Name = "hodidayEd";
            this.hodidayEd.Size = new System.Drawing.Size(411, 23);
            this.hodidayEd.TabIndex = 41;
            // 
            // volumeWeightEd
            // 
            this.volumeWeightEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "volumeRatio", true));
            this.volumeWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.volumeWeightEd.Location = new System.Drawing.Point(294, 230);
            this.volumeWeightEd.myFormat = "###,###,###,###,###";
            this.volumeWeightEd.Name = "volumeWeightEd";
            this.volumeWeightEd.Size = new System.Drawing.Size(135, 24);
            this.volumeWeightEd.TabIndex = 31932;
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
            this.transFeePercLbl.Location = new System.Drawing.Point(24, 210);
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
            this.volumeWeightLbl.Location = new System.Drawing.Point(294, 210);
            this.volumeWeightLbl.Name = "volumeWeightLbl";
            this.volumeWeightLbl.Size = new System.Drawing.Size(90, 16);
            this.volumeWeightLbl.TabIndex = 325;
            this.volumeWeightLbl.Text = "Volume ratio";
            this.volumeWeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buy2SellIntervalLbl
            // 
            this.buy2SellIntervalLbl.AutoSize = true;
            this.buy2SellIntervalLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buy2SellIntervalLbl.Location = new System.Drawing.Point(26, 263);
            this.buy2SellIntervalLbl.Name = "buy2SellIntervalLbl";
            this.buy2SellIntervalLbl.Size = new System.Drawing.Size(66, 16);
            this.buy2SellIntervalLbl.TabIndex = 321;
            this.buy2SellIntervalLbl.Text = "Lock sell ";
            this.buy2SellIntervalLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceWeightLbl
            // 
            this.priceWeightLbl.AutoSize = true;
            this.priceWeightLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceWeightLbl.Location = new System.Drawing.Point(158, 210);
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
            this.buy2SellIntervalEd.Location = new System.Drawing.Point(24, 283);
            this.buy2SellIntervalEd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.buy2SellIntervalEd.Name = "buy2SellIntervalEd";
            this.buy2SellIntervalEd.Size = new System.Drawing.Size(142, 26);
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
            this.priceWeightEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceWeightEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.priceWeightEd.Location = new System.Drawing.Point(159, 230);
            this.priceWeightEd.myFormat = "###,###,###,###,###";
            this.priceWeightEd.Name = "priceWeightEd";
            this.priceWeightEd.Size = new System.Drawing.Size(135, 24);
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
            this.transFeePercEd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transFeePercEd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.transFeePercEd.Location = new System.Drawing.Point(24, 230);
            this.transFeePercEd.myFormat = "###,##0.#0";
            this.transFeePercEd.Name = "transFeePercEd";
            this.transFeePercEd.Size = new System.Drawing.Size(135, 24);
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
            // dataSourceLbl
            // 
            this.dataSourceLbl.AutoSize = true;
            this.dataSourceLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSourceLbl.Location = new System.Drawing.Point(24, 441);
            this.dataSourceLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dataSourceLbl.Name = "dataSourceLbl";
            this.dataSourceLbl.Size = new System.Drawing.Size(87, 16);
            this.dataSourceLbl.TabIndex = 31934;
            this.dataSourceLbl.Text = "Data source";
            // 
            // dataSourceEd
            // 
            this.dataSourceEd.BackColor = System.Drawing.SystemColors.Window;
            this.dataSourceEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stockExchangeSource, "dataSource", true));
            this.dataSourceEd.isToUpperCase = false;
            this.dataSourceEd.Location = new System.Drawing.Point(24, 462);
            this.dataSourceEd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataSourceEd.Multiline = true;
            this.dataSourceEd.Name = "dataSourceEd";
            this.dataSourceEd.Size = new System.Drawing.Size(411, 49);
            this.dataSourceEd.TabIndex = 3193342;
            // 
            // daysLbl
            // 
            this.daysLbl.AutoSize = true;
            this.daysLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daysLbl.Location = new System.Drawing.Point(170, 288);
            this.daysLbl.Name = "daysLbl";
            this.daysLbl.Size = new System.Drawing.Size(39, 16);
            this.daysLbl.TabIndex = 3193343;
            this.daysLbl.Text = "days";
            this.daysLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stockExchangeEdit
            // 
            this.ClientSize = new System.Drawing.Size(935, 594);
            this.Controls.Add(this.daysLbl);
            this.Controls.Add(this.dataSourceLbl);
            this.Controls.Add(this.dataSourceEd);
            this.Controls.Add(this.volumeWeightEd);
            this.Controls.Add(this.transFeePercLbl);
            this.Controls.Add(this.volumeWeightLbl);
            this.Controls.Add(this.buy2SellIntervalLbl);
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
            this.Controls.Add(this.listGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "stockExchangeEdit";
            this.Text = "Stock Exchange";
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.listGrid, 0);
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
            this.Controls.SetChildIndex(this.buy2SellIntervalLbl, 0);
            this.Controls.SetChildIndex(this.volumeWeightLbl, 0);
            this.Controls.SetChildIndex(this.transFeePercLbl, 0);
            this.Controls.SetChildIndex(this.volumeWeightEd, 0);
            this.Controls.SetChildIndex(this.dataSourceEd, 0);
            this.Controls.SetChildIndex(this.dataSourceLbl, 0);
            this.Controls.SetChildIndex(this.daysLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockExchangeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buy2SellIntervalEd)).EndInit();
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
        private common.controls.baseTextBox hodidayEd;
        protected common.controls.numberTextBox volumeWeightEd;
        protected baseClass.controls.baseLabel transFeePercLbl;
        protected baseClass.controls.baseLabel volumeWeightLbl;
        protected baseClass.controls.baseLabel buy2SellIntervalLbl;
        protected baseClass.controls.baseLabel priceWeightLbl;
        private System.Windows.Forms.NumericUpDown buy2SellIntervalEd;
        protected common.controls.numberTextBox priceWeightEd;
        protected common.controls.numberTextBox transFeePercEd;
        private baseClass.controls.baseLabel dataSourceLbl;
        private common.controls.baseTextBox dataSourceEd;
        protected baseClass.controls.baseLabel daysLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
    }
}