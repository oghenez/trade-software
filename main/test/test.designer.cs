namespace test
{
    partial class test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.indicatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeEstimateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lineChartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.candleStickChartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarPnl = new common.control.basePanel();
            this.dataGb = new System.Windows.Forms.GroupBox();
            this.estimationBtn = new common.control.baseButton();
            this.cbStrategy = new baseClass.controls.cbStrategy();
            this.indicatorBtn = new common.control.baseButton();
            this.timeScaleCb = new baseClass.controls.cbTimeScale();
            this.dataBtn = new common.control.baseButton();
            this.chartTypeGb = new System.Windows.Forms.GroupBox();
            this.volumeChartBtn = new common.control.baseButton();
            this.chartBarBtn = new common.control.baseButton();
            this.chartLineBtn = new common.control.baseButton();
            this.chartCandelBtn = new common.control.baseButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolBarPnl.SuspendLayout();
            this.dataGb.SuspendLayout();
            this.chartTypeGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Location = new System.Drawing.Point(2, 57);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1003, 226);
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
            this.tradeEstimateMenuItem.Size = new System.Drawing.Size(128, 22);
            this.tradeEstimateMenuItem.Text = "Đánh giá";
            // 
            // chartTypeMenu
            // 
            this.chartTypeMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineChartTypeMenu,
            this.candleStickChartTypeMenu});
            this.chartTypeMenu.Name = "chartTypeMenu";
            this.chartTypeMenu.Size = new System.Drawing.Size(128, 22);
            this.chartTypeMenu.Text = "Biểu đồ";
            // 
            // lineChartTypeMenu
            // 
            this.lineChartTypeMenu.Checked = true;
            this.lineChartTypeMenu.CheckOnClick = true;
            this.lineChartTypeMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineChartTypeMenu.Name = "lineChartTypeMenu";
            this.lineChartTypeMenu.Size = new System.Drawing.Size(131, 22);
            this.lineChartTypeMenu.Text = "Đường";
            // 
            // candleStickChartTypeMenu
            // 
            this.candleStickChartTypeMenu.CheckOnClick = true;
            this.candleStickChartTypeMenu.Name = "candleStickChartTypeMenu";
            this.candleStickChartTypeMenu.Size = new System.Drawing.Size(131, 22);
            this.candleStickChartTypeMenu.Text = "Dạng nến";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.exitMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(990, 24);
            this.menuStrip.TabIndex = 245;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItem1.Text = "Chỉ số";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem2.Text = "Phân tích";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem3.Text = "Đánh giá";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem4.Text = "Biểu đồ";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Checked = true;
            this.toolStripMenuItem5.CheckOnClick = true;
            this.toolStripMenuItem5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(139, 22);
            this.toolStripMenuItem5.Text = "Đường";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.CheckOnClick = true;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(139, 22);
            this.toolStripMenuItem6.Text = "Dạng nến";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(67, 20);
            this.exitMenuItem.Text = "Kết thúc";
            // 
            // toolBarPnl
            // 
            this.toolBarPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.toolBarPnl.Controls.Add(this.dataGb);
            this.toolBarPnl.Controls.Add(this.chartTypeGb);
            this.toolBarPnl.haveCloseButton = false;
            this.toolBarPnl.haveShowHideButton = false;
            this.toolBarPnl.isShowState = true;
            this.toolBarPnl.Location = new System.Drawing.Point(0, 23);
            this.toolBarPnl.mySizingOptions = common.control.basePanel.SizingOptions.None;
            this.toolBarPnl.myWeight = 0;
            this.toolBarPnl.Name = "toolBarPnl";
            this.toolBarPnl.Size = new System.Drawing.Size(1269, 34);
            this.toolBarPnl.TabIndex = 0;
            // 
            // dataGb
            // 
            this.dataGb.Controls.Add(this.estimationBtn);
            this.dataGb.Controls.Add(this.cbStrategy);
            this.dataGb.Controls.Add(this.indicatorBtn);
            this.dataGb.Controls.Add(this.timeScaleCb);
            this.dataGb.Controls.Add(this.dataBtn);
            this.dataGb.Location = new System.Drawing.Point(106, -6);
            this.dataGb.Name = "dataGb";
            this.dataGb.Size = new System.Drawing.Size(400, 37);
            this.dataGb.TabIndex = 22;
            this.dataGb.TabStop = false;
            // 
            // estimationBtn
            // 
            this.estimationBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estimationBtn.Image = global::test.Properties.Resources.report;
            this.estimationBtn.isDownState = false;
            this.estimationBtn.Location = new System.Drawing.Point(372, 10);
            this.estimationBtn.Name = "estimationBtn";
            this.estimationBtn.Size = new System.Drawing.Size(22, 22);
            this.estimationBtn.TabIndex = 25;
            this.myToolTip.SetToolTip(this.estimationBtn, "Dữ liệu");
            this.estimationBtn.UseVisualStyleBackColor = true;
            // 
            // cbStrategy
            // 
            this.cbStrategy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStrategy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStrategy.FormattingEnabled = true;
            this.cbStrategy.Location = new System.Drawing.Point(164, 10);
            this.cbStrategy.myValue = "";
            this.cbStrategy.Name = "cbStrategy";
            this.cbStrategy.Size = new System.Drawing.Size(209, 22);
            this.cbStrategy.TabIndex = 20;
            // 
            // indicatorBtn
            // 
            this.indicatorBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indicatorBtn.Image = global::test.Properties.Resources.ruler;
            this.indicatorBtn.isDownState = false;
            this.indicatorBtn.Location = new System.Drawing.Point(140, 10);
            this.indicatorBtn.Name = "indicatorBtn";
            this.indicatorBtn.Size = new System.Drawing.Size(22, 22);
            this.indicatorBtn.TabIndex = 15;
            this.myToolTip.SetToolTip(this.indicatorBtn, "Chỉ số");
            this.indicatorBtn.UseVisualStyleBackColor = true;
            // 
            // timeScaleCb
            // 
            this.timeScaleCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeScaleCb.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeScaleCb.FormattingEnabled = true;
            this.timeScaleCb.Location = new System.Drawing.Point(7, 10);
            this.timeScaleCb.myValue = application.myTypes.timeScales.RealTime;
            this.timeScaleCb.Name = "timeScaleCb";
            this.timeScaleCb.SelectedValue = ((byte)(1));
            this.timeScaleCb.Size = new System.Drawing.Size(112, 22);
            this.timeScaleCb.TabIndex = 20;
            // 
            // dataBtn
            // 
            this.dataBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataBtn.Image = global::test.Properties.Resources.data;
            this.dataBtn.isDownState = false;
            this.dataBtn.Location = new System.Drawing.Point(119, 10);
            this.dataBtn.Name = "dataBtn";
            this.dataBtn.Size = new System.Drawing.Size(22, 22);
            this.dataBtn.TabIndex = 10;
            this.myToolTip.SetToolTip(this.dataBtn, "Dữ liệu");
            this.dataBtn.UseVisualStyleBackColor = true;
            this.dataBtn.Click += new System.EventHandler(this.dataBtn_Click);
            // 
            // chartTypeGb
            // 
            this.chartTypeGb.Controls.Add(this.volumeChartBtn);
            this.chartTypeGb.Controls.Add(this.chartBarBtn);
            this.chartTypeGb.Controls.Add(this.chartLineBtn);
            this.chartTypeGb.Controls.Add(this.chartCandelBtn);
            this.chartTypeGb.Location = new System.Drawing.Point(0, -6);
            this.chartTypeGb.Name = "chartTypeGb";
            this.chartTypeGb.Size = new System.Drawing.Size(105, 37);
            this.chartTypeGb.TabIndex = 1;
            this.chartTypeGb.TabStop = false;
            // 
            // volumeChartBtn
            // 
            this.volumeChartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.volumeChartBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeChartBtn.Image = ((System.Drawing.Image)(resources.GetObject("volumeChartBtn.Image")));
            this.volumeChartBtn.isDownState = true;
            this.volumeChartBtn.Location = new System.Drawing.Point(76, 11);
            this.volumeChartBtn.Name = "volumeChartBtn";
            this.volumeChartBtn.Size = new System.Drawing.Size(22, 22);
            this.volumeChartBtn.TabIndex = 4;
            this.myToolTip.SetToolTip(this.volumeChartBtn, "Volume chart");
            this.volumeChartBtn.UseVisualStyleBackColor = true;
            // 
            // chartBarBtn
            // 
            this.chartBarBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartBarBtn.Image = global::test.Properties.Resources.barChart2;
            this.chartBarBtn.isDownState = false;
            this.chartBarBtn.Location = new System.Drawing.Point(50, 11);
            this.chartBarBtn.Name = "chartBarBtn";
            this.chartBarBtn.Size = new System.Drawing.Size(22, 22);
            this.chartBarBtn.TabIndex = 3;
            this.chartBarBtn.UseVisualStyleBackColor = true;
            // 
            // chartLineBtn
            // 
            this.chartLineBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartLineBtn.Image = global::test.Properties.Resources.lineChart;
            this.chartLineBtn.isDownState = false;
            this.chartLineBtn.Location = new System.Drawing.Point(4, 11);
            this.chartLineBtn.Name = "chartLineBtn";
            this.chartLineBtn.Size = new System.Drawing.Size(22, 22);
            this.chartLineBtn.TabIndex = 1;
            this.chartLineBtn.UseVisualStyleBackColor = true;
            // 
            // chartCandelBtn
            // 
            this.chartCandelBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartCandelBtn.Image = global::test.Properties.Resources.candeleStick;
            this.chartCandelBtn.isDownState = false;
            this.chartCandelBtn.Location = new System.Drawing.Point(27, 11);
            this.chartCandelBtn.Name = "chartCandelBtn";
            this.chartCandelBtn.Size = new System.Drawing.Size(22, 22);
            this.chartCandelBtn.TabIndex = 2;
            this.chartCandelBtn.UseVisualStyleBackColor = true;
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
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 668);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.toolBarPnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "test";
            this.Controls.SetChildIndex(this.mainContainer, 0);
            this.Controls.SetChildIndex(this.toolBarPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolBarPnl.ResumeLayout(false);
            this.dataGb.ResumeLayout(false);
            this.chartTypeGb.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripMenuItem indicatorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeEstimateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartTypeMenu;
        private System.Windows.Forms.ToolStripMenuItem lineChartTypeMenu;
        private System.Windows.Forms.ToolStripMenuItem candleStickChartTypeMenu;
        protected baseClass.controls.cbTimeScale timeScaleCb;
        protected System.Windows.Forms.GroupBox chartTypeGb;
        protected common.control.baseButton chartLineBtn;
        protected common.control.baseButton chartCandelBtn;
        protected common.control.baseButton chartBarBtn;
        protected System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        protected common.control.baseButton dataBtn;
        protected common.control.baseButton indicatorBtn;
        protected baseClass.controls.cbStrategy cbStrategy;
        protected System.Windows.Forms.GroupBox dataGb;
        protected common.control.basePanel toolBarPnl;
        protected common.control.baseButton estimationBtn;
        protected common.control.baseButton volumeChartBtn;
    }
}