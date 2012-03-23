namespace Trade.Forms
{
    partial class MarketSummary
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 65.62);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 75.54);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 60.45);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 55.73);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 70.42);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.layoutPnl = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dailyChangeLbl = new common.controls.baseLabel();
            this.dailyChangeGV = new common.controls.baseDataGridView();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVarrianceSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new databases.tmpDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.weeklyChangeLbl = new common.controls.baseLabel();
            this.top10biggestChangeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.marketTitle1Ed = new common.controls.baseLabel();
            this.vnIdxChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.marketTitle2Ed = new common.controls.baseLabel();
            this.hnxChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.introLbl = new baseClass.controls.baseLabel();
            this.layoutPnl.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailyChangeGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVarrianceSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top10biggestChangeChart)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vnIdxChart)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hnxChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(12, 2);
            this.TitleLbl.Size = new System.Drawing.Size(919, 42);
            this.TitleLbl.Text = "Welcome to Market Overview";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layoutPnl
            // 
            this.layoutPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutPnl.ColumnCount = 2;
            this.layoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPnl.Controls.Add(this.splitContainer1, 1, 1);
            this.layoutPnl.Controls.Add(this.splitContainer2, 0, 1);
            this.layoutPnl.Controls.Add(this.splitContainer3, 0, 0);
            this.layoutPnl.Controls.Add(this.splitContainer4, 1, 0);
            this.layoutPnl.Location = new System.Drawing.Point(17, 75);
            this.layoutPnl.Name = "layoutPnl";
            this.layoutPnl.RowCount = 2;
            this.layoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPnl.Size = new System.Drawing.Size(891, 557);
            this.layoutPnl.TabIndex = 149;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(448, 281);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dailyChangeLbl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dailyChangeGV);
            this.splitContainer1.Size = new System.Drawing.Size(440, 273);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 149;
            // 
            // dailyChangeLbl
            // 
            this.dailyChangeLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dailyChangeLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dailyChangeLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.dailyChangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyChangeLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dailyChangeLbl.Location = new System.Drawing.Point(0, 0);
            this.dailyChangeLbl.Name = "dailyChangeLbl";
            this.dailyChangeLbl.Size = new System.Drawing.Size(440, 26);
            this.dailyChangeLbl.TabIndex = 151;
            this.dailyChangeLbl.Text = "Daily Market Change";
            this.dailyChangeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dailyChangeGV
            // 
            this.dailyChangeGV.AllowUserToAddRows = false;
            this.dailyChangeGV.AllowUserToDeleteRows = false;
            this.dailyChangeGV.AutoGenerateColumns = false;
            this.dailyChangeGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dailyChangeGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeColumn,
            this.openColumn,
            this.closeColumn,
            this.valueColumn,
            this.percentColumn});
            this.dailyChangeGV.DataSource = this.dataVarrianceSource;
            this.dailyChangeGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyChangeGV.Location = new System.Drawing.Point(0, 0);
            this.dailyChangeGV.Name = "dailyChangeGV";
            this.dailyChangeGV.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyChangeGV.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dailyChangeGV.RowTemplate.Height = 24;
            this.dailyChangeGV.Size = new System.Drawing.Size(440, 244);
            this.dailyChangeGV.TabIndex = 6;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 70;
            // 
            // openColumn
            // 
            this.openColumn.DataPropertyName = "val1";
            this.openColumn.HeaderText = "Open";
            this.openColumn.Name = "openColumn";
            this.openColumn.ReadOnly = true;
            this.openColumn.Width = 90;
            // 
            // closeColumn
            // 
            this.closeColumn.DataPropertyName = "val2";
            this.closeColumn.HeaderText = "Close";
            this.closeColumn.Name = "closeColumn";
            this.closeColumn.ReadOnly = true;
            this.closeColumn.Width = 90;
            // 
            // valueColumn
            // 
            this.valueColumn.DataPropertyName = "value";
            this.valueColumn.HeaderText = "    +/-";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            this.valueColumn.Width = 70;
            // 
            // percentColumn
            // 
            this.percentColumn.DataPropertyName = "percent";
            this.percentColumn.HeaderText = "   %";
            this.percentColumn.Name = "percentColumn";
            this.percentColumn.ReadOnly = true;
            this.percentColumn.Width = 60;
            // 
            // dataVarrianceSource
            // 
            this.dataVarrianceSource.DataMember = "dataVarriance";
            this.dataVarrianceSource.DataSource = this.myTmpDS;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.EnforceConstraints = false;
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 281);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.weeklyChangeLbl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.top10biggestChangeChart);
            this.splitContainer2.Size = new System.Drawing.Size(439, 273);
            this.splitContainer2.SplitterDistance = 28;
            this.splitContainer2.TabIndex = 150;
            // 
            // weeklyChangeLbl
            // 
            this.weeklyChangeLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.weeklyChangeLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.weeklyChangeLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.weeklyChangeLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weeklyChangeLbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.weeklyChangeLbl.Location = new System.Drawing.Point(0, 0);
            this.weeklyChangeLbl.Name = "weeklyChangeLbl";
            this.weeklyChangeLbl.Size = new System.Drawing.Size(439, 26);
            this.weeklyChangeLbl.TabIndex = 152;
            this.weeklyChangeLbl.Text = "Weekly Market Change";
            this.weeklyChangeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // top10biggestChangeChart
            // 
            this.top10biggestChangeChart.BorderlineColor = System.Drawing.Color.Navy;
            this.top10biggestChangeChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.top10biggestChangeChart.BorderlineWidth = 2;
            this.top10biggestChangeChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.PointGapDepth = 0;
            chartArea1.Area3DStyle.Rotation = 0;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.top10biggestChangeChart.ChartAreas.Add(chartArea1);
            this.top10biggestChangeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.top10biggestChangeChart.Legends.Add(legend1);
            this.top10biggestChangeChart.Location = new System.Drawing.Point(0, 0);
            this.top10biggestChangeChart.Name = "top10biggestChangeChart";
            this.top10biggestChangeChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series1.CustomProperties = "DoughnutRadius=60, PieLabelStyle=Disabled, PieDrawingStyle=SoftEdge";
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Label = "#VAL";
            series1.Legend = "Default";
            series1.Name = "Default";
            dataPoint1.CustomProperties = "Exploded=false";
            dataPoint1.Label = "France";
            dataPoint2.CustomProperties = "Exploded=false";
            dataPoint2.Label = "Canada";
            dataPoint3.CustomProperties = "Exploded=false";
            dataPoint3.Label = "UK";
            dataPoint4.CustomProperties = "Exploded=false";
            dataPoint4.Label = "USA";
            dataPoint5.CustomProperties = "Exploded=false";
            dataPoint5.Label = "Italy";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.top10biggestChangeChart.Series.Add(series1);
            this.top10biggestChangeChart.Size = new System.Drawing.Size(439, 241);
            this.top10biggestChangeChart.TabIndex = 149;
            this.top10biggestChangeChart.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.marketTitle1Ed);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.vnIdxChart);
            this.splitContainer3.Size = new System.Drawing.Size(439, 272);
            this.splitContainer3.SplitterDistance = 31;
            this.splitContainer3.TabIndex = 151;
            // 
            // marketTitle1Ed
            // 
            this.marketTitle1Ed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.marketTitle1Ed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.marketTitle1Ed.Dock = System.Windows.Forms.DockStyle.Top;
            this.marketTitle1Ed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marketTitle1Ed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.marketTitle1Ed.Location = new System.Drawing.Point(0, 0);
            this.marketTitle1Ed.Name = "marketTitle1Ed";
            this.marketTitle1Ed.Size = new System.Drawing.Size(439, 25);
            this.marketTitle1Ed.TabIndex = 153;
            this.marketTitle1Ed.Text = "HOSE";
            this.marketTitle1Ed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vnIdxChart
            // 
            this.vnIdxChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.vnIdxChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.vnIdxChart.BackSecondaryColor = System.Drawing.Color.White;
            this.vnIdxChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.vnIdxChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.vnIdxChart.BorderlineWidth = 2;
            this.vnIdxChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea2.AlignWithChartArea = "VolumeArea";
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.PointGapDepth = 0;
            chartArea2.Area3DStyle.Rotation = 0;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "PriceArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 60F;
            chartArea2.Position.Width = 89.71918F;
            chartArea2.Position.X = 4.712329F;
            chartArea2.Position.Y = 5F;
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            chartArea3.AlignWithChartArea = "PriceArea";
            chartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea3.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea3.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "VolumeArea";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 30F;
            chartArea3.Position.Width = 89.71918F;
            chartArea3.Position.X = 4.712329F;
            chartArea3.Position.Y = 65F;
            chartArea3.ShadowColor = System.Drawing.Color.Transparent;
            this.vnIdxChart.ChartAreas.Add(chartArea2);
            this.vnIdxChart.ChartAreas.Add(chartArea3);
            this.vnIdxChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.DockedToChartArea = "PriceArea";
            legend2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend2.IsTextAutoFit = false;
            legend2.Name = "vnIndex";
            this.vnIdxChart.Legends.Add(legend2);
            this.vnIdxChart.Location = new System.Drawing.Point(0, 0);
            this.vnIdxChart.Name = "vnIdxChart";
            series2.BorderColor = System.Drawing.Color.Blue;
            series2.ChartArea = "PriceArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.CustomProperties = "DoughnutRadius=60, PieLabelStyle=Disabled, PieDrawingStyle=SoftEdge";
            series2.IsXValueIndexed = true;
            series2.Legend = "vnIndex";
            series2.LegendText = "VN-Index";
            series2.Name = "vnIndex";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.ChartArea = "VolumeArea";
            series3.Color = System.Drawing.Color.Navy;
            series3.IsXValueIndexed = true;
            series3.Legend = "vnIndex";
            series3.MarkerSize = 30;
            series3.Name = "Volume";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.vnIdxChart.Series.Add(series2);
            this.vnIdxChart.Series.Add(series3);
            this.vnIdxChart.Size = new System.Drawing.Size(439, 237);
            this.vnIdxChart.TabIndex = 147;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(448, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.marketTitle2Ed);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.hnxChart);
            this.splitContainer4.Size = new System.Drawing.Size(440, 272);
            this.splitContainer4.SplitterDistance = 27;
            this.splitContainer4.TabIndex = 152;
            // 
            // marketTitle2Ed
            // 
            this.marketTitle2Ed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.marketTitle2Ed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.marketTitle2Ed.Dock = System.Windows.Forms.DockStyle.Top;
            this.marketTitle2Ed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marketTitle2Ed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.marketTitle2Ed.Location = new System.Drawing.Point(0, 0);
            this.marketTitle2Ed.Name = "marketTitle2Ed";
            this.marketTitle2Ed.Size = new System.Drawing.Size(440, 26);
            this.marketTitle2Ed.TabIndex = 154;
            this.marketTitle2Ed.Text = "HASTC";
            this.marketTitle2Ed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hnxChart
            // 
            this.hnxChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hnxChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.hnxChart.BackSecondaryColor = System.Drawing.Color.White;
            this.hnxChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.hnxChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.hnxChart.BorderlineWidth = 2;
            this.hnxChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea4.AlignWithChartArea = "VolumeArea";
            chartArea4.Area3DStyle.IsClustered = true;
            chartArea4.Area3DStyle.IsRightAngleAxes = false;
            chartArea4.Area3DStyle.Perspective = 10;
            chartArea4.Area3DStyle.PointGapDepth = 0;
            chartArea4.Area3DStyle.Rotation = 0;
            chartArea4.Area3DStyle.WallWidth = 0;
            chartArea4.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea4.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea4.AxisY2.MajorGrid.Enabled = false;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "PriceArea";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 60F;
            chartArea4.Position.Width = 89.72893F;
            chartArea4.Position.X = 5F;
            chartArea4.Position.Y = 5F;
            chartArea4.ShadowColor = System.Drawing.Color.Transparent;
            chartArea5.AlignWithChartArea = "PriceArea";
            chartArea5.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea5.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea5.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea5.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea5.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea5.AxisY.IsMarginVisible = false;
            chartArea5.AxisY.MajorGrid.Enabled = false;
            chartArea5.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea5.AxisY2.IsMarginVisible = false;
            chartArea5.AxisY2.MajorGrid.Enabled = false;
            chartArea5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            chartArea5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea5.Name = "VolumeArea";
            chartArea5.Position.Auto = false;
            chartArea5.Position.Height = 30F;
            chartArea5.Position.Width = 89.72893F;
            chartArea5.Position.X = 4.708428F;
            chartArea5.Position.Y = 65F;
            chartArea5.ShadowColor = System.Drawing.Color.Transparent;
            this.hnxChart.ChartAreas.Add(chartArea4);
            this.hnxChart.ChartAreas.Add(chartArea5);
            this.hnxChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Alignment = System.Drawing.StringAlignment.Far;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.DockedToChartArea = "PriceArea";
            legend3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend3.IsTextAutoFit = false;
            legend3.Name = "hnxIndex";
            legend4.DockedToChartArea = "VolumeArea";
            legend4.Enabled = false;
            legend4.Name = "Volume";
            legend4.Title = "Volume";
            this.hnxChart.Legends.Add(legend3);
            this.hnxChart.Legends.Add(legend4);
            this.hnxChart.Location = new System.Drawing.Point(0, 0);
            this.hnxChart.Name = "hnxChart";
            series4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series4.ChartArea = "PriceArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.IsXValueIndexed = true;
            series4.Legend = "hnxIndex";
            series4.LegendText = "HNX-Index";
            series4.Name = "hnxIndex";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series5.ChartArea = "VolumeArea";
            series5.Color = System.Drawing.Color.Navy;
            series5.IsXValueIndexed = true;
            series5.Legend = "Volume";
            series5.Name = "Volume";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.hnxChart.Series.Add(series4);
            this.hnxChart.Series.Add(series5);
            this.hnxChart.Size = new System.Drawing.Size(440, 241);
            this.hnxChart.TabIndex = 148;
            // 
            // introLbl
            // 
            this.introLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.introLbl.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introLbl.Location = new System.Drawing.Point(18, 43);
            this.introLbl.Name = "introLbl";
            this.introLbl.Size = new System.Drawing.Size(913, 29);
            this.introLbl.TabIndex = 1;
            this.introLbl.Text = "Quantum is the pioneer software bla bla bla";
            // 
            // MarketSummary
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(931, 673);
            this.Controls.Add(this.introLbl);
            this.Controls.Add(this.layoutPnl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MarketSummary";
            this.Resize += new System.EventHandler(this.MarketSummary_Resize);
            this.Controls.SetChildIndex(this.layoutPnl, 0);
            this.Controls.SetChildIndex(this.introLbl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.layoutPnl.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dailyChangeGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVarrianceSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.top10biggestChangeChart)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vnIdxChart)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hnxChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutPnl;
        private baseClass.controls.baseLabel introLbl;
        protected System.Windows.Forms.BindingSource dataVarrianceSource;
        protected databases.tmpDS myTmpDS;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private common.controls.baseLabel dailyChangeLbl;
        private common.controls.baseDataGridView dailyChangeGV;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private common.controls.baseLabel weeklyChangeLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart top10biggestChangeChart;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private common.controls.baseLabel marketTitle1Ed;
        private System.Windows.Forms.DataVisualization.Charting.Chart vnIdxChart;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private common.controls.baseLabel marketTitle2Ed;
        private System.Windows.Forms.DataVisualization.Charting.Chart hnxChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentColumn;

    }
}
