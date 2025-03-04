namespace baseClass.forms
{
    partial class baseTradeAnalysis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseTradeAnalysis));
            this.toolPnl = new System.Windows.Forms.Panel();
            this.tradeEstimateBtn = new baseClass.controls.baseButton();
            this.chartTiming = new baseClass.controls.chartTiming();
            this.cbStrategy = new baseClass.controls.cbStrategy();
            this.resetBtn = new baseClass.controls.baseButton();
            this.stockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.priceDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataSet = new data.baseDS();
            this.myMenuStrip = new System.Windows.Forms.MenuStrip();
            this.indicatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeEstimateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lineChartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.candleStickChartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.myMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolPnl
            // 
            this.toolPnl.Controls.Add(this.tradeEstimateBtn);
            this.toolPnl.Controls.Add(this.chartTiming);
            this.toolPnl.Controls.Add(this.cbStrategy);
            this.toolPnl.Controls.Add(this.resetBtn);
            this.toolPnl.Location = new System.Drawing.Point(0, 557);
            this.toolPnl.Name = "toolPnl";
            this.toolPnl.Size = new System.Drawing.Size(970, 29);
            this.toolPnl.TabIndex = 237;
            // 
            // tradeEstimateBtn
            // 
            this.tradeEstimateBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tradeEstimateBtn.Image = global::baseClass.Properties.Resources.report;
            this.tradeEstimateBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tradeEstimateBtn.Location = new System.Drawing.Point(584, 5);
            this.tradeEstimateBtn.Name = "tradeEstimateBtn";
            this.tradeEstimateBtn.Size = new System.Drawing.Size(27, 22);
            this.tradeEstimateBtn.TabIndex = 10;
            this.tradeEstimateBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.myToolTip.SetToolTip(this.tradeEstimateBtn, "Đánh giá");
            this.tradeEstimateBtn.UseVisualStyleBackColor = true;
            // 
            // chartTiming
            // 
            this.chartTiming.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTiming.Location = new System.Drawing.Point(25, 5);
            this.chartTiming.myTimeRange = application.AppTypes.TimeRanges.None;
            this.chartTiming.Name = "chartTiming";
            this.chartTiming.Size = new System.Drawing.Size(389, 22);
            this.chartTiming.TabIndex = 0;
            // 
            // cbStrategy
            // 
            this.cbStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Location = new System.Drawing.Point(413, 4);
            this.cbStrategy.myValue = "";
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(170, 24);
            this.cbStrategy.TabIndex = 2;
            // 
            // resetBtn
            // 
            this.resetBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Image = global::baseClass.Properties.Resources.undo;
            this.resetBtn.Location = new System.Drawing.Point(611, 5);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(27, 22);
            this.resetBtn.TabIndex = 11;
            this.resetBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.myToolTip.SetToolTip(this.resetBtn, "Làm lại");
            this.resetBtn.UseVisualStyleBackColor = true;
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
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.Salmon;
            chartArea1.Name = "priceArea";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 41.68786F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 10.62428F;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LabelStyle.Format = "dd-MM-yy";
            chartArea2.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.ScrollBar.Enabled = false;
            chartArea2.AxisY.LabelStyle.Format = "n0";
            chartArea2.AxisY.LineColor = System.Drawing.Color.Gray;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.MidnightBlue;
            chartArea2.Name = "volumeArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 41.68786F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 55.31214F;
            this.stockChart.ChartAreas.Add(chartArea1);
            this.stockChart.ChartAreas.Add(chartArea2);
            this.stockChart.DataSource = this.priceDataSource;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.SameAsSeriesOrder;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "mainLegend";
            legend1.Position.Auto = false;
            legend1.Position.Height = 7F;
            legend1.Position.Width = 100F;
            legend1.Position.Y = 4F;
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.stockChart.Legends.Add(legend1);
            this.stockChart.Location = new System.Drawing.Point(0, 27);
            this.stockChart.Name = "stockChart";
            series1.BorderColor = System.Drawing.Color.Gray;
            series1.ChartArea = "priceArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DarkSlateBlue;
            series1.Legend = "mainLegend";
            series1.LegendText = "Giá";
            series1.Name = "priceSeries";
            series1.XValueMember = "onDate";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "closePrice";
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "volumeArea";
            series2.Color = System.Drawing.Color.DarkBlue;
            series2.IsVisibleInLegend = false;
            series2.Legend = "mainLegend";
            series2.LegendText = "Số lượng";
            series2.Name = "volumeSeries";
            series2.XValueMember = "onDate";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            this.stockChart.Series.Add(series1);
            this.stockChart.Series.Add(series2);
            this.stockChart.Size = new System.Drawing.Size(968, 520);
            this.stockChart.TabIndex = 240;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "priceTitle";
            title1.Position.Auto = false;
            title1.Position.Height = 4.579683F;
            title1.Position.Width = 94F;
            title1.Position.Y = 3F;
            this.stockChart.Titles.Add(title1);
            // 
            // priceDataSource
            // 
            this.priceDataSource.DataMember = "priceData";
            this.priceDataSource.DataSource = this.myDataSet;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.indicatorMenuItem.Name = "indicatorMenuItem";
            this.indicatorMenuItem.Size = new System.Drawing.Size(58, 20);
            this.indicatorMenuItem.Text = "Chỉ số";
            // 
            // analysisMenuItem
            // 
            this.analysisMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradeEstimateMenuItem,
            this.chartTypeMenu});
            this.analysisMenuItem.Name = "analysisMenuItem";
            this.analysisMenuItem.Size = new System.Drawing.Size(80, 20);
            this.analysisMenuItem.Text = "Phân tích";
            // 
            // tradeEstimateMenuItem
            // 
            this.tradeEstimateMenuItem.Name = "tradeEstimateMenuItem";
            this.tradeEstimateMenuItem.Size = new System.Drawing.Size(146, 22);
            this.tradeEstimateMenuItem.Text = "Đánh giá";
            // 
            // chartTypeMenu
            // 
            this.chartTypeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineChartTypeMenu,
            this.candleStickChartTypeMenu});
            this.chartTypeMenu.Name = "chartTypeMenu";
            this.chartTypeMenu.Size = new System.Drawing.Size(146, 22);
            this.chartTypeMenu.Text = "Biểu đồ";
            // 
            // lineChartTypeMenu
            // 
            this.lineChartTypeMenu.Checked = true;
            this.lineChartTypeMenu.CheckOnClick = true;
            this.lineChartTypeMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineChartTypeMenu.Name = "lineChartTypeMenu";
            this.lineChartTypeMenu.Size = new System.Drawing.Size(150, 22);
            this.lineChartTypeMenu.Text = "Đường";
            // 
            // candleStickChartTypeMenu
            // 
            this.candleStickChartTypeMenu.CheckOnClick = true;
            this.candleStickChartTypeMenu.Name = "candleStickChartTypeMenu";
            this.candleStickChartTypeMenu.Size = new System.Drawing.Size(150, 22);
            this.candleStickChartTypeMenu.Text = "Dạng nến";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.ClientSize = new System.Drawing.Size(970, 610);
            this.Controls.Add(this.myMenuStrip);
            this.Controls.Add(this.toolPnl);
            this.Controls.Add(this.stockChart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baseTradeAnalysis";
            this.Resize += new System.EventHandler(this.tradeAnalysis_Resize);
            this.Controls.SetChildIndex(this.stockChart, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.toolPnl, 0);
            this.Controls.SetChildIndex(this.myMenuStrip, 0);
            this.toolPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.myMenuStrip.ResumeLayout(false);
            this.myMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.chartTiming chartTiming;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        protected System.Windows.Forms.Panel toolPnl;
        private System.Windows.Forms.BindingSource priceDataSource;
        protected System.Windows.Forms.DataVisualization.Charting.Chart stockChart;
        protected System.Windows.Forms.MenuStrip myMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem indicatorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeEstimateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartTypeMenu;
        private System.Windows.Forms.ToolStripMenuItem lineChartTypeMenu;
        private System.Windows.Forms.ToolStripMenuItem candleStickChartTypeMenu;
        protected data.baseDS myDataSet;
        protected baseClass.controls.baseButton resetBtn;
        protected baseClass.controls.baseButton tradeEstimateBtn;
        protected baseClass.controls.cbStrategy cbStrategy;

    }
}