namespace baseClass.forms
{
    partial class _baseTradeAnalysis
    {

        //common.libs.appAvailable myAvail = new common.libs.appAvailable();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseTradeAnalysis));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stockCodeGrid = new common.control.baseDataGridView();
            this.tickerCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockExchange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noOpenShares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new data.baseDS();
            this.stockListFilterCb = new common.control.baseComboBox();
            this.stockCodeNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPnl = new System.Windows.Forms.Panel();
            this.tradeEstimateBtn = new baseClass.controls.baseButton();
            this.chartTiming = new baseClass.controls.chartTiming();
            this.stockCountlbl = new common.control.baseLabel();
            this.cbStrategy = new baseClass.controls.cbStrategy();
            this.resetBtn = new baseClass.controls.baseButton();
            this.stockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.priceDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.myMenuStrip = new System.Windows.Forms.MenuStrip();
            this.indicatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indicatorSMA_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indicatorMACD_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeEstimateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeNavigator)).BeginInit();
            this.stockCodeNavigator.SuspendLayout();
            this.toolPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).BeginInit();
            this.myMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1018, 76);
            this.TitleLbl.Size = new System.Drawing.Size(62, 46);
            this.TitleLbl.Visible = false;
            // 
            // stockCodeGrid
            // 
            this.stockCodeGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.stockCodeGrid.AllowUserToAddRows = false;
            this.stockCodeGrid.AllowUserToDeleteRows = false;
            this.stockCodeGrid.AutoGenerateColumns = false;
            this.stockCodeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockCodeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tickerCodeDataGridViewTextBoxColumn,
            this.stockExchange,
            this.noOpenShares});
            this.stockCodeGrid.DataSource = this.stockCodeSource;
            this.stockCodeGrid.Location = new System.Drawing.Point(-1, 54);
            this.stockCodeGrid.Name = "stockCodeGrid";
            this.stockCodeGrid.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCodeGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.stockCodeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stockCodeGrid.Size = new System.Drawing.Size(222, 486);
            this.stockCodeGrid.TabIndex = 232;
            this.stockCodeGrid.DoubleClick += new System.EventHandler(this.stockCodeGrid_DoubleClick);
            // 
            // tickerCodeDataGridViewTextBoxColumn
            // 
            this.tickerCodeDataGridViewTextBoxColumn.DataPropertyName = "tickerCode";
            this.tickerCodeDataGridViewTextBoxColumn.HeaderText = "Mã";
            this.tickerCodeDataGridViewTextBoxColumn.Name = "tickerCodeDataGridViewTextBoxColumn";
            this.tickerCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tickerCodeDataGridViewTextBoxColumn.Width = 60;
            // 
            // stockExchange
            // 
            this.stockExchange.DataPropertyName = "stockExchange";
            this.stockExchange.HeaderText = "Sàn ";
            this.stockExchange.Name = "stockExchange";
            this.stockExchange.ReadOnly = true;
            this.stockExchange.Visible = false;
            this.stockExchange.Width = 80;
            // 
            // noOpenShares
            // 
            this.noOpenShares.DataPropertyName = "noOpenShares";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.noOpenShares.DefaultCellStyle = dataGridViewCellStyle1;
            this.noOpenShares.HeaderText = "S.Lượng";
            this.noOpenShares.Name = "noOpenShares";
            this.noOpenShares.ReadOnly = true;
            // 
            // stockCodeSource
            // 
            this.stockCodeSource.DataMember = "stockCode";
            this.stockCodeSource.DataSource = this.myDataSet;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stockListFilterCb
            // 
            this.stockListFilterCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockListFilterCb.FormattingEnabled = true;
            this.stockListFilterCb.Items.AddRange(new object[] {
            "Tất cả",
            "Mã ưa thích",
            "Ngành ưa thích"});
            this.stockListFilterCb.Location = new System.Drawing.Point(0, 29);
            this.stockListFilterCb.myValue = "";
            this.stockListFilterCb.Name = "stockListFilterCb";
            this.stockListFilterCb.Size = new System.Drawing.Size(222, 26);
            this.stockListFilterCb.TabIndex = 233;
            this.stockListFilterCb.SelectedIndexChanged += new System.EventHandler(this.stockListFilterCb_SelectedIndexChanged);
            // 
            // stockCodeNavigator
            // 
            this.stockCodeNavigator.AddNewItem = null;
            this.stockCodeNavigator.BindingSource = this.stockCodeSource;
            this.stockCodeNavigator.CountItem = null;
            this.stockCodeNavigator.DeleteItem = null;
            this.stockCodeNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.stockCodeNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.stockCodeNavigator.Location = new System.Drawing.Point(4, 12);
            this.stockCodeNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.stockCodeNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.stockCodeNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.stockCodeNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.stockCodeNavigator.Name = "stockCodeNavigator";
            this.stockCodeNavigator.PositionItem = null;
            this.stockCodeNavigator.Size = new System.Drawing.Size(114, 25);
            this.stockCodeNavigator.Stretch = true;
            this.stockCodeNavigator.TabIndex = 235;
            this.stockCodeNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolPnl
            // 
            this.toolPnl.Controls.Add(this.tradeEstimateBtn);
            this.toolPnl.Controls.Add(this.chartTiming);
            this.toolPnl.Controls.Add(this.stockCodeNavigator);
            this.toolPnl.Controls.Add(this.stockCountlbl);
            this.toolPnl.Controls.Add(this.cbStrategy);
            this.toolPnl.Controls.Add(this.resetBtn);
            this.toolPnl.Location = new System.Drawing.Point(0, 542);
            this.toolPnl.Name = "toolPnl";
            this.toolPnl.Size = new System.Drawing.Size(1125, 44);
            this.toolPnl.TabIndex = 237;
            // 
            // tradeEstimateBtn
            // 
            this.tradeEstimateBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeEstimateBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tradeEstimateBtn.Location = new System.Drawing.Point(637, 11);
            this.tradeEstimateBtn.Name = "tradeEstimateBtn";
            this.tradeEstimateBtn.Size = new System.Drawing.Size(74, 24);
            this.tradeEstimateBtn.TabIndex = 239;
            this.tradeEstimateBtn.Text = "Đánh giá";
            this.tradeEstimateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tradeEstimateBtn.UseVisualStyleBackColor = true;
            this.tradeEstimateBtn.Click += new System.EventHandler(this.tradeEstimateBtn_Click);
            // 
            // chartTiming
            // 
            this.chartTiming.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTiming.Location = new System.Drawing.Point(222, 11);
            this.chartTiming.myTiming = application.myTypes.chartTiming.None;
            this.chartTiming.Name = "chartTiming";
            this.chartTiming.Size = new System.Drawing.Size(296, 22);
            this.chartTiming.TabIndex = 0;
            this.chartTiming.myDateAccept += new baseClass.controls.chartTiming.onDateAccept(this.chartTiming_myDateAccept);
            // 
            // stockCountlbl
            // 
            this.stockCountlbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockCountlbl.Location = new System.Drawing.Point(135, 11);
            this.stockCountlbl.Name = "stockCountlbl";
            this.stockCountlbl.Size = new System.Drawing.Size(62, 23);
            this.stockCountlbl.TabIndex = 238;
            this.stockCountlbl.Text = "....";
            this.stockCountlbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbStrategy
            // 
            this.cbStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Location = new System.Drawing.Point(517, 11);
            this.cbStrategy.myValue = "";
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(120, 24);
            this.cbStrategy.TabIndex = 3;
            this.cbStrategy.SelectionChangeCommitted += new System.EventHandler(this.cbStrategy_SelectionChangeCommitted);
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.resetBtn.Location = new System.Drawing.Point(716, 11);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(63, 24);
            this.resetBtn.TabIndex = 4;
            this.resetBtn.Text = "Làm lại";
            this.resetBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // stockChart
            // 
            this.stockChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.stockChart.BorderlineWidth = 2;
            this.stockChart.BorderSkin.BackColor = System.Drawing.Color.White;
            this.stockChart.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.LabelStyle.Format = "dd-MM-yy";
            chartArea1.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.SteelBlue;
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.White;
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.White;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightSteelBlue;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.Salmon;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "priceArea";
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LabelStyle.Format = "dd-MM-yy";
            chartArea2.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.ScrollBar.Enabled = false;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.MidnightBlue;
            chartArea2.Name = "volumeArea";
            this.stockChart.ChartAreas.Add(chartArea1);
            this.stockChart.ChartAreas.Add(chartArea2);
            this.stockChart.DataSource = this.priceDataSource;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "mainLegend";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.stockChart.Legends.Add(legend1);
            this.stockChart.Location = new System.Drawing.Point(222, 31);
            this.stockChart.Name = "stockChart";
            series1.ChartArea = "priceArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.MediumBlue;
            series1.Legend = "mainLegend";
            series1.LegendText = "Giá";
            series1.Name = "priceSeries";
            series1.XValueMember = "onDate";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "closePrice";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "volumeArea";
            series2.Color = System.Drawing.Color.Blue;
            series2.IsVisibleInLegend = false;
            series2.Legend = "mainLegend";
            series2.LegendText = "Số lượng";
            series2.Name = "volumeSeries";
            series2.XValueMember = "onDate";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "volumne";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            this.stockChart.Series.Add(series1);
            this.stockChart.Series.Add(series2);
            this.stockChart.Size = new System.Drawing.Size(746, 507);
            this.stockChart.TabIndex = 240;
            this.stockChart.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.stockChart_GetToolTipText);
            // 
            // priceDataSource
            // 
            this.priceDataSource.DataMember = "priceData";
            this.priceDataSource.DataSource = this.myDataSet;
            // 
            // myMenuStrip
            // 
            this.myMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.myMenuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.myMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indicatorMenuItem,
            this.analysisMenuItem,
            this.exitMenuItem});
            this.myMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.myMenuStrip.Name = "myMenuStrip";
            this.myMenuStrip.Size = new System.Drawing.Size(970, 24);
            this.myMenuStrip.TabIndex = 241;
            // 
            // indicatorMenuItem
            // 
            this.indicatorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indicatorSMA_MenuItem,
            this.indicatorMACD_MenuItem});
            this.indicatorMenuItem.Name = "indicatorMenuItem";
            this.indicatorMenuItem.Size = new System.Drawing.Size(58, 20);
            this.indicatorMenuItem.Text = "Chỉ số";
            // 
            // indicatorSMA_MenuItem
            // 
            this.indicatorSMA_MenuItem.Name = "indicatorSMA_MenuItem";
            this.indicatorSMA_MenuItem.Size = new System.Drawing.Size(127, 22);
            this.indicatorSMA_MenuItem.Tag = "";
            this.indicatorSMA_MenuItem.Text = "SMA";
            this.indicatorSMA_MenuItem.Click += new System.EventHandler(this.indicatorSMA_MenuItem_Click);
            // 
            // indicatorMACD_MenuItem
            // 
            this.indicatorMACD_MenuItem.Name = "indicatorMACD_MenuItem";
            this.indicatorMACD_MenuItem.Size = new System.Drawing.Size(127, 22);
            this.indicatorMACD_MenuItem.Tag = "";
            this.indicatorMACD_MenuItem.Text = "MACD";
            this.indicatorMACD_MenuItem.Click += new System.EventHandler(this.indicatorMACD_MenuItem_Click);
            // 
            // analysisMenuItem
            // 
            this.analysisMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradeEstimateMenuItem});
            this.analysisMenuItem.Name = "analysisMenuItem";
            this.analysisMenuItem.Size = new System.Drawing.Size(80, 20);
            this.analysisMenuItem.Text = "Phân tích";
            // 
            // tradeEstimateMenuItem
            // 
            this.tradeEstimateMenuItem.Name = "tradeEstimateMenuItem";
            this.tradeEstimateMenuItem.Size = new System.Drawing.Size(146, 22);
            this.tradeEstimateMenuItem.Text = "Đánh giá";
            this.tradeEstimateMenuItem.Click += new System.EventHandler(this.tradeEstimateMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(75, 20);
            this.exitMenuItem.Text = "Kết thúc";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "tickerCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "stockExchange";
            this.dataGridViewTextBoxColumn2.HeaderText = "Sàn ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "noOpenShares";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "SL niêm yết";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // baseTradeAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 614);
            this.Controls.Add(this.myMenuStrip);
            this.Controls.Add(this.toolPnl);
            this.Controls.Add(this.stockListFilterCb);
            this.Controls.Add(this.stockCodeGrid);
            this.Controls.Add(this.stockChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.Name = "baseTradeAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phan tich / Analysis";
            this.Resize += new System.EventHandler(this.tradeAnalysis_Resize);
            this.Controls.SetChildIndex(this.stockChart, 0);
            this.Controls.SetChildIndex(this.stockCodeGrid, 0);
            this.Controls.SetChildIndex(this.stockListFilterCb, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.toolPnl, 0);
            this.Controls.SetChildIndex(this.myMenuStrip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeNavigator)).EndInit();
            this.stockCodeNavigator.ResumeLayout(false);
            this.stockCodeNavigator.PerformLayout();
            this.toolPnl.ResumeLayout(false);
            this.toolPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).EndInit();
            this.myMenuStrip.ResumeLayout(false);
            this.myMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.chartTiming chartTiming;
        protected data.baseDS myDataSet;
        protected common.control.baseDataGridView stockCodeGrid;
        private System.Windows.Forms.BindingSource stockCodeSource;
        protected common.control.baseComboBox stockListFilterCb;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private baseClass.controls.baseButton resetBtn;
        private System.Windows.Forms.BindingNavigator stockCodeNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        protected System.Windows.Forms.Panel toolPnl;
        protected common.control.baseLabel stockCountlbl;
        private System.Windows.Forms.BindingSource priceDataSource;
        protected System.Windows.Forms.DataVisualization.Charting.Chart stockChart;
        protected System.Windows.Forms.MenuStrip myMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem indicatorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indicatorSMA_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem indicatorMACD_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        protected baseClass.controls.cbStrategy cbStrategy;
        private System.Windows.Forms.ToolStripMenuItem analysisMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tickerCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockExchange;
        private System.Windows.Forms.DataGridViewTextBoxColumn noOpenShares;
        private baseClass.controls.baseButton tradeEstimateBtn;
        private System.Windows.Forms.ToolStripMenuItem tradeEstimateMenuItem;

    }
}