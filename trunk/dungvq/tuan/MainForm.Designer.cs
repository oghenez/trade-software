namespace test
{
    partial class MainForm
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
            this.myGraphObj = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indicatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marketWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.candleStickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.yearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.leftPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.indicatorPanel1 = new test1.Panel.IndicatorPanel();
            this.marketWatchPanel1 = new test1.Panel.MarketWatchPanel();
            this.tsDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // myGraphObj
            // 
            this.myGraphObj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myGraphObj.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.myGraphObj.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.myGraphObj.Location = new System.Drawing.Point(291, 57);
            this.myGraphObj.Name = "myGraphObj";
            this.myGraphObj.ScrollGrace = 0;
            this.myGraphObj.ScrollMaxX = 0;
            this.myGraphObj.ScrollMaxY = 0;
            this.myGraphObj.ScrollMaxY2 = 0;
            this.myGraphObj.ScrollMinX = 0;
            this.myGraphObj.ScrollMinY = 0;
            this.myGraphObj.ScrollMinY2 = 0;
            this.myGraphObj.Size = new System.Drawing.Size(616, 590);
            this.myGraphObj.TabIndex = 1;
            this.myGraphObj.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.myGraphObj_PointValueEvent);
            this.myGraphObj.ZoomEvent += new ZedGraph.ZedGraphControl.ZoomEventHandler(this.myGraphObj_ZoomEvent);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewsToolStripMenuItem,
            this.chartsToolStripMenuItem,
            this.chartsToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indicatorsToolStripMenuItem,
            this.marketWatchToolStripMenuItem});
            this.viewsToolStripMenuItem.Image = global::test1.Properties.Resources.barChart1;
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            this.viewsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.viewsToolStripMenuItem.Text = "View";
            // 
            // indicatorsToolStripMenuItem
            // 
            this.indicatorsToolStripMenuItem.Name = "indicatorsToolStripMenuItem";
            this.indicatorsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.indicatorsToolStripMenuItem.Text = "Indicators";
            this.indicatorsToolStripMenuItem.Click += new System.EventHandler(this.indicatorsToolStripMenuItem_Click);
            // 
            // marketWatchToolStripMenuItem
            // 
            this.marketWatchToolStripMenuItem.Name = "marketWatchToolStripMenuItem";
            this.marketWatchToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.marketWatchToolStripMenuItem.Text = "Market Watch";
            this.marketWatchToolStripMenuItem.Click += new System.EventHandler(this.marketWatchToolStripMenuItem_Click);
            // 
            // chartsToolStripMenuItem
            // 
            this.chartsToolStripMenuItem.Name = "chartsToolStripMenuItem";
            this.chartsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.chartsToolStripMenuItem.Text = "Insert";
            // 
            // chartsToolStripMenuItem1
            // 
            this.chartsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.candleStickToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.barToolStripMenuItem});
            this.chartsToolStripMenuItem1.Image = global::test1.Properties.Resources.barChart2;
            this.chartsToolStripMenuItem1.Name = "chartsToolStripMenuItem1";
            this.chartsToolStripMenuItem1.Size = new System.Drawing.Size(69, 20);
            this.chartsToolStripMenuItem1.Text = "Charts";
            // 
            // candleStickToolStripMenuItem
            // 
            this.candleStickToolStripMenuItem.Image = global::test1.Properties.Resources.candeleStick;
            this.candleStickToolStripMenuItem.Name = "candleStickToolStripMenuItem";
            this.candleStickToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.candleStickToolStripMenuItem.Text = "Candle Stick";
            this.candleStickToolStripMenuItem.Click += new System.EventHandler(this.candleStickToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Image = global::test1.Properties.Resources.lineChart;
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // barToolStripMenuItem
            // 
            this.barToolStripMenuItem.Image = global::test1.Properties.Resources.barChart2;
            this.barToolStripMenuItem.Name = "barToolStripMenuItem";
            this.barToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.barToolStripMenuItem.Text = "Bar";
            this.barToolStripMenuItem.Click += new System.EventHandler(this.barToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::test1.Properties.Resources.candeleStick;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::test1.Properties.Resources.barChart2;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::test1.Properties.Resources.lineChart;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yearToolStripMenuItem,
            this.monthToolStripMenuItem,
            this.weekToolStripMenuItem,
            this.dayToolStripMenuItem,
            this.hourToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::test1.Properties.Resources.report;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // yearToolStripMenuItem
            // 
            this.yearToolStripMenuItem.CheckOnClick = true;
            this.yearToolStripMenuItem.Name = "yearToolStripMenuItem";
            this.yearToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.yearToolStripMenuItem.Text = "Year";
            // 
            // monthToolStripMenuItem
            // 
            this.monthToolStripMenuItem.CheckOnClick = true;
            this.monthToolStripMenuItem.Name = "monthToolStripMenuItem";
            this.monthToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.monthToolStripMenuItem.Text = "Month";
            // 
            // weekToolStripMenuItem
            // 
            this.weekToolStripMenuItem.CheckOnClick = true;
            this.weekToolStripMenuItem.Name = "weekToolStripMenuItem";
            this.weekToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.weekToolStripMenuItem.Text = "Week";
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.CheckOnClick = true;
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.dayToolStripMenuItem.Text = "Day";
            // 
            // hourToolStripMenuItem
            // 
            this.hourToolStripMenuItem.CheckOnClick = true;
            this.hourToolStripMenuItem.Name = "hourToolStripMenuItem";
            this.hourToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.hourToolStripMenuItem.Text = "Hour";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "H5",
            "D1",
            "D5",
            "W",
            "W2",
            "M",
            "M3",
            "M6",
            "Y"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.Text = "Preodicity";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(919, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.indicatorPanel1);
            this.leftPanel.Controls.Add(this.marketWatchPanel1);
            this.leftPanel.Location = new System.Drawing.Point(12, 57);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(262, 590);
            this.leftPanel.TabIndex = 7;
            this.leftPanel.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.leftPanel_ControlRemoved);
            // 
            // indicatorPanel1
            // 
            this.indicatorPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.indicatorPanel1.Location = new System.Drawing.Point(3, 3);
            this.indicatorPanel1.Name = "indicatorPanel1";
            this.indicatorPanel1.Size = new System.Drawing.Size(252, 289);
            this.indicatorPanel1.TabIndex = 0;
            // 
            // marketWatchPanel1
            // 
            this.marketWatchPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.marketWatchPanel1.Location = new System.Drawing.Point(3, 298);
            this.marketWatchPanel1.Name = "marketWatchPanel1";
            this.marketWatchPanel1.Size = new System.Drawing.Size(252, 289);
            this.marketWatchPanel1.TabIndex = 1;
            // 
            // tsDate
            // 
            this.tsDate.Name = "tsDate";
            this.tsDate.Size = new System.Drawing.Size(31, 17);
            this.tsDate.Text = "Date";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 672);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.myGraphObj);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Stock Charts";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ZedGraph.ZedGraphControl myGraphObj;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem candleStickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem yearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private test1.Panel.IndicatorPanel indicatorPanel1;
        private System.Windows.Forms.ToolStripMenuItem indicatorsToolStripMenuItem;
        private test1.Panel.MarketWatchPanel marketWatchPanel1;
        private System.Windows.Forms.ToolStripMenuItem marketWatchToolStripMenuItem;
        public System.Windows.Forms.FlowLayoutPanel leftPanel;
        private System.Windows.Forms.ToolStripStatusLabel tsDate;


    }
}