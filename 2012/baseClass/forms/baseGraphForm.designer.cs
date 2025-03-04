namespace baseClass.forms
{
    partial class baseGraphForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseGraphForm));
            this.myDataSet = new databases.baseDS();
            this.indicatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeEstimateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lineChartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.candleStickChartTypeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainContainer = new baseClass.controls.graphPaneContainer();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1356, 235);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.TitleLbl.Size = new System.Drawing.Size(221, 57);
            this.TitleLbl.Visible = false;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // mainContainer
            // 
            this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainContainer.Location = new System.Drawing.Point(0, 128);
            this.mainContainer.myArrangeOptions = common.controls.childArrangeOptions.Casscade;
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(480, 386);
            this.mainContainer.TabIndex = 246;
            // 
            // baseGraphForm
            // 
            this.ClientSize = new System.Drawing.Size(1284, 822);
            this.Controls.Add(this.mainContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "baseGraphForm";
            this.Resize += new System.EventHandler(this.FormResizeHandler);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.mainContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
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
        public databases.baseDS myDataSet;
        private baseClass.controls.graphPaneContainer mainContainer;
    }
}