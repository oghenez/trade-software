namespace Tools.Forms
{
    partial class profitEstimate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(profitEstimate));
            this.dataGrid = new common.controls.baseDataGridView();
            this.tradeEstimateSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new data.tmpDS();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.estimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTransactionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showChartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContainer = new common.controls.baseContainer();
            this.dataPnl = new common.controls.basePanel();
            this.chartPnl = new Charts.Controls.baseGraphPanel();
            this.ignoredColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tradeActionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashAmtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeAmtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeEstimateSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.dataPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(1214, 241);
            this.closeBtn.Size = new System.Drawing.Size(64, 24);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(1221, 290);
            this.okBtn.Size = new System.Drawing.Size(57, 24);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "Ok";
            this.okBtn.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1210, 202);
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ignoredColumn,
            this.tradeActionColumn,
            this.onDateColumn,
            this.priceDataColumn,
            this.qtyColumn,
            this.amountColumn,
            this.cashAmtColumn,
            this.totalAmtColumn,
            this.feeAmtColumn,
            this.profitColumn});
            this.dataGrid.DataSource = this.tradeEstimateSource;
            this.dataGrid.Location = new System.Drawing.Point(-2, -2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(541, 250);
            this.dataGrid.TabIndex = 20;
            this.dataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
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
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estimationToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1031, 24);
            this.menuStrip.TabIndex = 299;
            // 
            // estimationToolStripMenuItem
            // 
            this.estimationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allTransactionMenuItem,
            this.toolStripSeparator1,
            this.showChartMenuItem,
            this.toolStripSeparator2,
            this.reloadMenuItem,
            this.toolStripSeparator3,
            this.exportMenuItem});
            this.estimationToolStripMenuItem.Name = "estimationToolStripMenuItem";
            this.estimationToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.estimationToolStripMenuItem.Text = "Profit Estimation";
            // 
            // allTransactionMenuItem
            // 
            this.allTransactionMenuItem.CheckOnClick = true;
            this.allTransactionMenuItem.Name = "allTransactionMenuItem";
            this.allTransactionMenuItem.Size = new System.Drawing.Size(182, 22);
            this.allTransactionMenuItem.Text = "All Transactions";
            this.allTransactionMenuItem.Click += new System.EventHandler(this.allTransactionMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // showChartMenuItem
            // 
            this.showChartMenuItem.Name = "showChartMenuItem";
            this.showChartMenuItem.Size = new System.Drawing.Size(182, 22);
            this.showChartMenuItem.Text = "Show Chart";
            this.showChartMenuItem.Click += new System.EventHandler(this.showChartMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // reloadMenuItem
            // 
            this.reloadMenuItem.Name = "reloadMenuItem";
            this.reloadMenuItem.Size = new System.Drawing.Size(182, 22);
            this.reloadMenuItem.Text = "Reload";
            this.reloadMenuItem.Click += new System.EventHandler(this.reloadMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exportMenuItem.Text = "Export";
            this.exportMenuItem.Click += new System.EventHandler(this.exportMenuItem_Click);
            // 
            // mainContainer
            // 
            this.mainContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainContainer.Controls.Add(this.chartPnl);
            this.mainContainer.Controls.Add(this.dataPnl);
            this.mainContainer.Location = new System.Drawing.Point(2, 52);
            this.mainContainer.myArrangeOptions = common.controls.childArrangeOptions.Casscade;
            this.mainContainer.myPaneDimensionSpecs = null;
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(1025, 448);
            this.mainContainer.TabIndex = 300;
            // 
            // dataPnl
            // 
            this.dataPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataPnl.Controls.Add(this.dataGrid);
            this.dataPnl.haveCloseButton = false;
            this.dataPnl.isExpanded = true;
            this.dataPnl.Location = new System.Drawing.Point(0, 0);
            this.dataPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.dataPnl.mySizingOptions = common.controls.basePanel.SizingOptions.Right;
            this.dataPnl.myWeight = 100;
            this.dataPnl.Name = "dataPnl";
            this.dataPnl.Size = new System.Drawing.Size(611, 300);
            this.dataPnl.TabIndex = 0;
            // 
            // chartPnl
            // 
            this.chartPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chartPnl.haveCloseButton = true;
            this.chartPnl.HaveRangeBarX = false;
            this.chartPnl.isExpanded = true;
            this.chartPnl.Location = new System.Drawing.Point(640, 0);
            this.chartPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.chartPnl.mySizingOptions = common.controls.basePanel.SizingOptions.Left;
            this.chartPnl.myWeight = 70;
            this.chartPnl.Name = "chartPnl";
            this.chartPnl.Size = new System.Drawing.Size(366, 446);
            this.chartPnl.TabIndex = 298;
            this.chartPnl.myOnClosing += new common.controls.basePanel.OnClosing(this.chartPnl_myOnClosing);
            // 
            // ignoredColumn
            // 
            this.ignoredColumn.DataPropertyName = "ignored";
            this.ignoredColumn.HeaderText = "";
            this.ignoredColumn.Name = "ignoredColumn";
            this.ignoredColumn.ReadOnly = true;
            this.ignoredColumn.Width = 30;
            // 
            // tradeActionColumn
            // 
            this.tradeActionColumn.DataPropertyName = "tradeAction";
            this.tradeActionColumn.HeaderText = "";
            this.tradeActionColumn.Name = "tradeActionColumn";
            this.tradeActionColumn.ReadOnly = true;
            this.tradeActionColumn.Width = 45;
            // 
            // onDateColumn
            // 
            this.onDateColumn.DataPropertyName = "onDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.onDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.onDateColumn.HeaderText = "Date/Time";
            this.onDateColumn.Name = "onDateColumn";
            this.onDateColumn.ReadOnly = true;
            this.onDateColumn.Width = 140;
            // 
            // priceDataColumn
            // 
            this.priceDataColumn.DataPropertyName = "price";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.priceDataColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.priceDataColumn.HeaderText = "Price";
            this.priceDataColumn.Name = "priceDataColumn";
            this.priceDataColumn.ReadOnly = true;
            this.priceDataColumn.Width = 60;
            // 
            // qtyColumn
            // 
            this.qtyColumn.DataPropertyName = "qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.qtyColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtyColumn.HeaderText = "Qty";
            this.qtyColumn.Name = "qtyColumn";
            this.qtyColumn.ReadOnly = true;
            this.qtyColumn.Width = 80;
            // 
            // amountColumn
            // 
            this.amountColumn.DataPropertyName = "stockAmt";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.amountColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.amountColumn.HeaderText = "Amount";
            this.amountColumn.Name = "amountColumn";
            this.amountColumn.ReadOnly = true;
            // 
            // cashAmtColumn
            // 
            this.cashAmtColumn.DataPropertyName = "cashAmt";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.cashAmtColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.cashAmtColumn.HeaderText = "Cash ";
            this.cashAmtColumn.Name = "cashAmtColumn";
            this.cashAmtColumn.ReadOnly = true;
            // 
            // totalAmtColumn
            // 
            this.totalAmtColumn.DataPropertyName = "totalAmt";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.totalAmtColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalAmtColumn.HeaderText = "Total";
            this.totalAmtColumn.Name = "totalAmtColumn";
            this.totalAmtColumn.ReadOnly = true;
            this.totalAmtColumn.Width = 110;
            // 
            // feeAmtColumn
            // 
            this.feeAmtColumn.DataPropertyName = "feeAmt";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.feeAmtColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.feeAmtColumn.HeaderText = "Fee";
            this.feeAmtColumn.Name = "feeAmtColumn";
            this.feeAmtColumn.ReadOnly = true;
            this.feeAmtColumn.Width = 90;
            // 
            // profitColumn
            // 
            this.profitColumn.DataPropertyName = "profit";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.profitColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.profitColumn.HeaderText = "Profit";
            this.profitColumn.Name = "profitColumn";
            this.profitColumn.ReadOnly = true;
            this.profitColumn.Width = 90;
            // 
            // profitEstimate
            // 
            this.ClientSize = new System.Drawing.Size(1031, 525);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.mainContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "profitEstimate";
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.baseAdviceEstimate_myOnAccept);
            this.Load += new System.EventHandler(this.baseAdviceEstimate_Load);
            this.Resize += new System.EventHandler(this.baseAdviceEstimate_Resize);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.mainContainer, 0);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeEstimateSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.dataPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tradeEstimateSource;
        private data.tmpDS myTmpDS;
        protected common.controls.baseDataGridView dataGrid;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem estimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTransactionMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showChartMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reloadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private common.controls.baseContainer mainContainer;
        protected Charts.Controls.baseGraphPanel chartPnl;
        private common.controls.basePanel dataPnl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ignoredColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeActionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashAmtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeAmtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitColumn;
    }
}
