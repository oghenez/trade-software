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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 65.62);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 75.54);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 60.45);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 55.73);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint10 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 70.42);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dailyChangeGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyChangeGV.RowsDefaultCellStyle = dataGridViewCellStyle4;
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
            chartArea6.Area3DStyle.IsClustered = true;
            chartArea6.Area3DStyle.IsRightAngleAxes = false;
            chartArea6.Area3DStyle.Perspective = 10;
            chartArea6.Area3DStyle.PointGapDepth = 0;
            chartArea6.Area3DStyle.Rotation = 0;
            chartArea6.Area3DStyle.WallWidth = 0;
            chartArea6.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea6.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea6.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea6.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea6.BackColor = System.Drawing.Color.Transparent;
            chartArea6.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea6.BorderWidth = 0;
            chartArea6.Name = "Default";
            chartArea6.ShadowColor = System.Drawing.Color.Transparent;
            this.top10biggestChangeChart.ChartAreas.Add(chartArea6);
            this.top10biggestChangeChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend5.Alignment = System.Drawing.StringAlignment.Center;
            legend5.BackColor = System.Drawing.Color.Transparent;
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend5.Enabled = false;
            legend5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend5.IsTextAutoFit = false;
            legend5.Name = "Default";
            this.top10biggestChangeChart.Legends.Add(legend5);
            this.top10biggestChangeChart.Location = new System.Drawing.Point(0, 0);
            this.top10biggestChangeChart.Name = "top10biggestChangeChart";
            this.top10biggestChangeChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series6.ChartArea = "Default";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(65)))), ((int)(((byte)(140)))), ((int)(((byte)(240)))));
            series6.CustomProperties = "DoughnutRadius=60, PieLabelStyle=Disabled, PieDrawingStyle=SoftEdge";
            series6.IsValueShownAsLabel = true;
            series6.IsXValueIndexed = true;
            series6.Label = "#VAL";
            series6.Legend = "Default";
            series6.Name = "Default";
            dataPoint6.CustomProperties = "Exploded=false";
            dataPoint6.Label = "France";
            dataPoint7.CustomProperties = "Exploded=false";
            dataPoint7.Label = "Canada";
            dataPoint8.CustomProperties = "Exploded=false";
            dataPoint8.Label = "UK";
            dataPoint9.CustomProperties = "Exploded=false";
            dataPoint9.Label = "USA";
            dataPoint10.CustomProperties = "Exploded=false";
            dataPoint10.Label = "Italy";
            series6.Points.Add(dataPoint6);
            series6.Points.Add(dataPoint7);
            series6.Points.Add(dataPoint8);
            series6.Points.Add(dataPoint9);
            series6.Points.Add(dataPoint10);
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.top10biggestChangeChart.Series.Add(series6);
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
            chartArea7.AlignWithChartArea = "VolumeArea";
            chartArea7.Area3DStyle.IsClustered = true;
            chartArea7.Area3DStyle.IsRightAngleAxes = false;
            chartArea7.Area3DStyle.Perspective = 10;
            chartArea7.Area3DStyle.PointGapDepth = 0;
            chartArea7.Area3DStyle.Rotation = 0;
            chartArea7.Area3DStyle.WallWidth = 0;
            chartArea7.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea7.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea7.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea7.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea7.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea7.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea7.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea7.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea7.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea7.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea7.AxisY2.MajorGrid.Enabled = false;
            chartArea7.BackColor = System.Drawing.Color.Transparent;
            chartArea7.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea7.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea7.Name = "PriceArea";
            chartArea7.Position.Auto = false;
            chartArea7.Position.Height = 60F;
            chartArea7.Position.Width = 89.71918F;
            chartArea7.Position.X = 4.712329F;
            chartArea7.Position.Y = 5F;
            chartArea7.ShadowColor = System.Drawing.Color.Transparent;
            chartArea8.AlignWithChartArea = "PriceArea";
            chartArea8.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea8.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea8.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea8.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea8.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea8.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea8.AxisX.MajorGrid.Enabled = false;
            chartArea8.AxisX.MajorTickMark.Enabled = false;
            chartArea8.AxisY.MajorGrid.Enabled = false;
            chartArea8.AxisY2.MajorGrid.Enabled = false;
            chartArea8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea8.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea8.Name = "VolumeArea";
            chartArea8.Position.Auto = false;
            chartArea8.Position.Height = 30F;
            chartArea8.Position.Width = 89.71918F;
            chartArea8.Position.X = 4.712329F;
            chartArea8.Position.Y = 65F;
            chartArea8.ShadowColor = System.Drawing.Color.Transparent;
            this.vnIdxChart.ChartAreas.Add(chartArea7);
            this.vnIdxChart.ChartAreas.Add(chartArea8);
            this.vnIdxChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Alignment = System.Drawing.StringAlignment.Far;
            legend6.BackColor = System.Drawing.Color.Transparent;
            legend6.DockedToChartArea = "PriceArea";
            legend6.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend6.IsTextAutoFit = false;
            legend6.Name = "vnIndex";
            this.vnIdxChart.Legends.Add(legend6);
            this.vnIdxChart.Location = new System.Drawing.Point(0, 0);
            this.vnIdxChart.Name = "vnIdxChart";
            series7.BorderColor = System.Drawing.Color.Blue;
            series7.ChartArea = "PriceArea";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Blue;
            series7.CustomProperties = "DoughnutRadius=60, PieLabelStyle=Disabled, PieDrawingStyle=SoftEdge";
            series7.IsXValueIndexed = true;
            series7.Legend = "vnIndex";
            series7.LegendText = "VN-Index";
            series7.Name = "vnIndex";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series8.ChartArea = "VolumeArea";
            series8.Color = System.Drawing.Color.Navy;
            series8.IsXValueIndexed = true;
            series8.Legend = "vnIndex";
            series8.MarkerSize = 30;
            series8.Name = "Volume";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.vnIdxChart.Series.Add(series7);
            this.vnIdxChart.Series.Add(series8);
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
            chartArea9.AlignWithChartArea = "VolumeArea";
            chartArea9.Area3DStyle.IsClustered = true;
            chartArea9.Area3DStyle.IsRightAngleAxes = false;
            chartArea9.Area3DStyle.Perspective = 10;
            chartArea9.Area3DStyle.PointGapDepth = 0;
            chartArea9.Area3DStyle.Rotation = 0;
            chartArea9.Area3DStyle.WallWidth = 0;
            chartArea9.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea9.AxisX.IsMarginVisible = false;
            chartArea9.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea9.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea9.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea9.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea9.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea9.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea9.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea9.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea9.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea9.AxisY2.MajorGrid.Enabled = false;
            chartArea9.BackColor = System.Drawing.Color.Transparent;
            chartArea9.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            chartArea9.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea9.Name = "PriceArea";
            chartArea9.Position.Auto = false;
            chartArea9.Position.Height = 60F;
            chartArea9.Position.Width = 89.72893F;
            chartArea9.Position.X = 5F;
            chartArea9.Position.Y = 5F;
            chartArea9.ShadowColor = System.Drawing.Color.Transparent;
            chartArea10.AlignWithChartArea = "PriceArea";
            chartArea10.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea10.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea10.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
            chartArea10.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea10.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            chartArea10.AxisX.MajorGrid.Enabled = false;
            chartArea10.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea10.AxisY.IsMarginVisible = false;
            chartArea10.AxisY.MajorGrid.Enabled = false;
            chartArea10.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea10.AxisY2.IsMarginVisible = false;
            chartArea10.AxisY2.MajorGrid.Enabled = false;
            chartArea10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            chartArea10.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea10.Name = "VolumeArea";
            chartArea10.Position.Auto = false;
            chartArea10.Position.Height = 30F;
            chartArea10.Position.Width = 89.72893F;
            chartArea10.Position.X = 4.708428F;
            chartArea10.Position.Y = 65F;
            chartArea10.ShadowColor = System.Drawing.Color.Transparent;
            this.hnxChart.ChartAreas.Add(chartArea9);
            this.hnxChart.ChartAreas.Add(chartArea10);
            this.hnxChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Alignment = System.Drawing.StringAlignment.Far;
            legend7.BackColor = System.Drawing.Color.Transparent;
            legend7.DockedToChartArea = "PriceArea";
            legend7.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend7.IsTextAutoFit = false;
            legend7.Name = "hnxIndex";
            legend8.DockedToChartArea = "VolumeArea";
            legend8.Enabled = false;
            legend8.Name = "Volume";
            legend8.Title = "Volume";
            this.hnxChart.Legends.Add(legend7);
            this.hnxChart.Legends.Add(legend8);
            this.hnxChart.Location = new System.Drawing.Point(0, 0);
            this.hnxChart.Name = "hnxChart";
            series9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series9.ChartArea = "PriceArea";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series9.IsXValueIndexed = true;
            series9.Legend = "hnxIndex";
            series9.LegendText = "HNX-Index";
            series9.Name = "hnxIndex";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series10.ChartArea = "VolumeArea";
            series10.Color = System.Drawing.Color.Navy;
            series10.IsXValueIndexed = true;
            series10.Legend = "Volume";
            series10.Name = "Volume";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.hnxChart.Series.Add(series9);
            this.hnxChart.Series.Add(series10);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
