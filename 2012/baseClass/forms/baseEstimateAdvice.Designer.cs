namespace baseClass.forms
{
    partial class baseEstimateAdvice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseEstimateAdvice));
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGrid = new common.control.baseDataGridView();
            this.ignored = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tradeActionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeEstimateSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new data.tmpDS();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.estimateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolBoxPnl = new System.Windows.Forms.Panel();
            this.closeThisBtn = new baseClass.controls.baseButton();
            this.optionBtn = new baseClass.controls.baseButton();
            this.countLbl = new baseClass.controls.baseLabel();
            this.chartBtn = new baseClass.controls.baseButton();
            this.refreshBtn = new baseClass.controls.baseButton();
            this.showTransOnlyChk = new baseClass.controls.baseCheckBox();
            this.exportBtn = new baseClass.controls.baseButton();
            this.chartPnl = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeEstimateSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimateChart)).BeginInit();
            this.toolBoxPnl.SuspendLayout();
            this.chartPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(440, 93);
            this.closeBtn.Size = new System.Drawing.Size(64, 24);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(920, 449);
            this.okBtn.Size = new System.Drawing.Size(57, 24);
            this.okBtn.TabIndex = 10;
            this.okBtn.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(919, 7);
            this.TitleLbl.Size = new System.Drawing.Size(428, 24);
            this.TitleLbl.Text = "TÌM KIẾM";
            this.TitleLbl.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "code";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ignored,
            this.tradeActionDataGridViewTextBoxColumn,
            this.onDateDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.stockAmt,
            this.cashAmt,
            this.totalAmt,
            this.feeAmt,
            this.revenueDataGridViewTextBoxColumn});
            this.dataGrid.DataSource = this.tradeEstimateSource;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(908, 586);
            this.dataGrid.TabIndex = 20;
            this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // ignored
            // 
            this.ignored.DataPropertyName = "ignored";
            this.ignored.HeaderText = "";
            this.ignored.Name = "ignored";
            this.ignored.ReadOnly = true;
            this.ignored.Width = 30;
            // 
            // tradeActionDataGridViewTextBoxColumn
            // 
            this.tradeActionDataGridViewTextBoxColumn.DataPropertyName = "tradeAction";
            this.tradeActionDataGridViewTextBoxColumn.HeaderText = "";
            this.tradeActionDataGridViewTextBoxColumn.Name = "tradeActionDataGridViewTextBoxColumn";
            this.tradeActionDataGridViewTextBoxColumn.ReadOnly = true;
            this.tradeActionDataGridViewTextBoxColumn.Width = 45;
            // 
            // onDateDataGridViewTextBoxColumn
            // 
            this.onDateDataGridViewTextBoxColumn.DataPropertyName = "onDate";
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.onDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.onDateDataGridViewTextBoxColumn.HeaderText = "Thời gian";
            this.onDateDataGridViewTextBoxColumn.Name = "onDateDataGridViewTextBoxColumn";
            this.onDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.onDateDataGridViewTextBoxColumn.Width = 140;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Giá";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 60;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "qty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Lượng";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 80;
            // 
            // stockAmt
            // 
            this.stockAmt.DataPropertyName = "stockAmt";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.stockAmt.DefaultCellStyle = dataGridViewCellStyle5;
            this.stockAmt.HeaderText = "Giá.trị.CP";
            this.stockAmt.Name = "stockAmt";
            this.stockAmt.ReadOnly = true;
            // 
            // cashAmt
            // 
            this.cashAmt.DataPropertyName = "cashAmt";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.cashAmt.DefaultCellStyle = dataGridViewCellStyle6;
            this.cashAmt.HeaderText = "Tiền mặt";
            this.cashAmt.Name = "cashAmt";
            this.cashAmt.ReadOnly = true;
            // 
            // totalAmt
            // 
            this.totalAmt.DataPropertyName = "totalAmt";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.totalAmt.DefaultCellStyle = dataGridViewCellStyle7;
            this.totalAmt.HeaderText = "Tổng.giá.trị";
            this.totalAmt.Name = "totalAmt";
            this.totalAmt.ReadOnly = true;
            this.totalAmt.Width = 110;
            // 
            // feeAmt
            // 
            this.feeAmt.DataPropertyName = "feeAmt";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.feeAmt.DefaultCellStyle = dataGridViewCellStyle8;
            this.feeAmt.HeaderText = "Phí GD";
            this.feeAmt.Name = "feeAmt";
            this.feeAmt.ReadOnly = true;
            this.feeAmt.Width = 90;
            // 
            // revenueDataGridViewTextBoxColumn
            // 
            this.revenueDataGridViewTextBoxColumn.DataPropertyName = "revenue";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.revenueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.revenueDataGridViewTextBoxColumn.HeaderText = "Lợi.nhuận";
            this.revenueDataGridViewTextBoxColumn.Name = "revenueDataGridViewTextBoxColumn";
            this.revenueDataGridViewTextBoxColumn.ReadOnly = true;
            this.revenueDataGridViewTextBoxColumn.Width = 90;
            // 
            // tradeEstimateSource
            // 
            this.tradeEstimateSource.DataMember = "tradeEstimate";
            this.tradeEstimateSource.DataSource = this.myTmpDS;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.xls";
            this.saveFileDialog.Filter = "(*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // estimateChart
            // 
            chartArea1.AxisX.LabelStyle.Format = "dd/MM/yy";
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.LabelStyle.Format = "N0";
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.estimateChart.ChartAreas.Add(chartArea1);
            this.estimateChart.DataSource = this.tradeEstimateSource;
            this.estimateChart.Location = new System.Drawing.Point(4, 3);
            this.estimateChart.Name = "estimateChart";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = true;
            series1.Name = "profitSeries";
            series1.XValueMember = "onDate";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "revenue";
            this.estimateChart.Series.Add(series1);
            this.estimateChart.Size = new System.Drawing.Size(898, 360);
            this.estimateChart.TabIndex = 296;
            // 
            // toolBoxPnl
            // 
            this.toolBoxPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolBoxPnl.Controls.Add(this.closeThisBtn);
            this.toolBoxPnl.Controls.Add(this.optionBtn);
            this.toolBoxPnl.Controls.Add(this.countLbl);
            this.toolBoxPnl.Controls.Add(this.chartBtn);
            this.toolBoxPnl.Controls.Add(this.refreshBtn);
            this.toolBoxPnl.Controls.Add(this.showTransOnlyChk);
            this.toolBoxPnl.Controls.Add(this.exportBtn);
            this.toolBoxPnl.Location = new System.Drawing.Point(-2, 586);
            this.toolBoxPnl.Name = "toolBoxPnl";
            this.toolBoxPnl.Size = new System.Drawing.Size(912, 34);
            this.toolBoxPnl.TabIndex = 297;
            // 
            // closeThisBtn
            // 
            this.closeThisBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeThisBtn.Image = global::baseClass.Properties.Resources.close;
            this.closeThisBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeThisBtn.Location = new System.Drawing.Point(326, 5);
            this.closeThisBtn.Name = "closeThisBtn";
            this.closeThisBtn.Size = new System.Drawing.Size(65, 24);
            this.closeThisBtn.TabIndex = 5;
            this.closeThisBtn.Text = "Đóng";
            this.closeThisBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeThisBtn.UseVisualStyleBackColor = true;
            this.closeThisBtn.Click += new System.EventHandler(this.closeThisBtn_Click);
            // 
            // optionBtn
            // 
            this.optionBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionBtn.Image = global::baseClass.Properties.Resources.configure;
            this.optionBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optionBtn.Location = new System.Drawing.Point(179, 5);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(82, 24);
            this.optionBtn.TabIndex = 3;
            this.optionBtn.Text = "Tùy biến";
            this.optionBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.optionBtn.UseVisualStyleBackColor = true;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // countLbl
            // 
            this.countLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLbl.Location = new System.Drawing.Point(856, 5);
            this.countLbl.Name = "countLbl";
            this.countLbl.Size = new System.Drawing.Size(47, 20);
            this.countLbl.TabIndex = 11;
            this.countLbl.Text = "xxx";
            // 
            // chartBtn
            // 
            this.chartBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartBtn.Image = global::baseClass.Properties.Resources.indicator;
            this.chartBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chartBtn.Location = new System.Drawing.Point(102, 5);
            this.chartBtn.Name = "chartBtn";
            this.chartBtn.Size = new System.Drawing.Size(77, 24);
            this.chartBtn.TabIndex = 2;
            this.chartBtn.Text = "Biểu đồ";
            this.chartBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chartBtn.UseVisualStyleBackColor = true;
            this.chartBtn.Click += new System.EventHandler(this.chartBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::baseClass.Properties.Resources.refresh;
            this.refreshBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreshBtn.Location = new System.Drawing.Point(28, 5);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(74, 24);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "Làm lại";
            this.refreshBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // showTransOnlyChk
            // 
            this.showTransOnlyChk.AutoSize = true;
            this.showTransOnlyChk.Checked = true;
            this.showTransOnlyChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTransOnlyChk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showTransOnlyChk.Location = new System.Drawing.Point(738, 4);
            this.showTransOnlyChk.Name = "showTransOnlyChk";
            this.showTransOnlyChk.Size = new System.Drawing.Size(115, 20);
            this.showTransOnlyChk.TabIndex = 10;
            this.showTransOnlyChk.Text = "Các giao dịch ";
            this.showTransOnlyChk.UseVisualStyleBackColor = true;
            this.showTransOnlyChk.CheckedChanged += new System.EventHandler(this.showTransOnlyChk_CheckedChanged);
            // 
            // exportBtn
            // 
            this.exportBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.Image = global::baseClass.Properties.Resources.export;
            this.exportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exportBtn.Location = new System.Drawing.Point(261, 5);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(65, 24);
            this.exportBtn.TabIndex = 4;
            this.exportBtn.Text = "Excel";
            this.exportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // chartPnl
            // 
            this.chartPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chartPnl.Controls.Add(this.estimateChart);
            this.chartPnl.Location = new System.Drawing.Point(0, 74);
            this.chartPnl.Name = "chartPnl";
            this.chartPnl.Size = new System.Drawing.Size(906, 370);
            this.chartPnl.TabIndex = 298;
            this.chartPnl.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "code";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã số";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fullName";
            dataGridViewCellStyle12.Format = "d";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn2.HeaderText = "Họ và tên";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "address1";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn3.HeaderText = "Địa chỉ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 350;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "mobile";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn4.HeaderText = "Di.động";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 220;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "estAmt";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn5.HeaderText = "GT Cổ phiếu";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 130;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "revenue";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn6.HeaderText = "Lợi nhuận";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "totalAmt";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "N0";
            dataGridViewCellStyle17.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn7.HeaderText = "Tổng";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 110;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "revenue";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            dataGridViewCellStyle18.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn8.HeaderText = "Lợi nhuận";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 110;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "revenue";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N0";
            dataGridViewCellStyle19.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn9.HeaderText = "Lợi.nhuận";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 90;
            // 
            // baseEstimateAdvice
            // 
            this.ClientSize = new System.Drawing.Size(907, 645);
            this.Controls.Add(this.chartPnl);
            this.Controls.Add(this.toolBoxPnl);
            this.Controls.Add(this.dataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseEstimateAdvice";
            this.Text = "Danh gia / Estimation";
            this.Load += new System.EventHandler(this.baseAdviceEstimate_Load);
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.baseAdviceEstimate_myOnAccept);
            this.Resize += new System.EventHandler(this.baseAdviceEstimate_Resize);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.toolBoxPnl, 0);
            this.Controls.SetChildIndex(this.chartPnl, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeEstimateSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estimateChart)).EndInit();
            this.toolBoxPnl.ResumeLayout(false);
            this.toolBoxPnl.PerformLayout();
            this.chartPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tradeEstimateSource;
        private data.tmpDS myTmpDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        protected common.control.baseDataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private baseClass.controls.baseCheckBox showTransOnlyChk;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected baseClass.controls.baseButton exportBtn;
        protected System.Windows.Forms.DataVisualization.Charting.Chart estimateChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        protected baseClass.controls.baseButton refreshBtn;
        protected baseClass.controls.baseButton chartBtn;
        protected baseClass.controls.baseLabel countLbl;
        protected System.Windows.Forms.Panel toolBoxPnl;
        protected baseClass.controls.baseButton optionBtn;
        protected baseClass.controls.baseButton closeThisBtn;
        protected System.Windows.Forms.Panel chartPnl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ignored;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeActionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenueDataGridViewTextBoxColumn;
    }
}
