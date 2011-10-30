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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(profitEstimate));
            this.dataGrid = new common.controls.baseDataGridView();
            this.tradeEstimateSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new data.tmpDS();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.chartPnl = new Charts.Controls.baseGraphPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.estimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTransactionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showChartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignored = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(926, 113);
            this.closeBtn.Size = new System.Drawing.Size(64, 24);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(920, 449);
            this.okBtn.Size = new System.Drawing.Size(57, 24);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "Ok";
            this.okBtn.Visible = false;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(919, 7);
            this.TitleLbl.Size = new System.Drawing.Size(87, 20);
            this.TitleLbl.Text = "TÌM KIẾM";
            // 
            // dataGrid
            // 
            this.dataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ignored,
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
            this.dataGrid.DisableReadOnlyColumn = false;
            this.dataGrid.Location = new System.Drawing.Point(1, 24);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(908, 364);
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
            // chartPnl
            // 
            this.chartPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chartPnl.haveCloseButton = true;
            this.chartPnl.isExpanded = true;
            this.chartPnl.Visible = true;
            this.chartPnl.Location = new System.Drawing.Point(0, 397);
            this.chartPnl.myIconLocations = common.controls.basePanel.IconLocations.None;
            this.chartPnl.mySizingOptions = common.controls.basePanel.SizingOptions.Top;
            this.chartPnl.myWeight = 0;
            this.chartPnl.Name = "chartPnl";
            this.chartPnl.Size = new System.Drawing.Size(905, 217);
            this.chartPnl.TabIndex = 298;
            this.chartPnl.myOnShowStateChanged += new common.controls.basePanel.OnShowStateChanged(this.chartPnl_myOnShowStateChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estimationToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(908, 24);
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
            // ignored
            // 
            this.ignored.DataPropertyName = "ignored";
            this.ignored.HeaderText = "";
            this.ignored.Name = "ignored";
            this.ignored.ReadOnly = true;
            this.ignored.Width = 30;
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
            this.onDateColumn.HeaderText = "Date/Time";
            this.onDateColumn.Name = "onDateColumn";
            this.onDateColumn.ReadOnly = true;
            this.onDateColumn.Width = 140;
            // 
            // priceDataColumn
            // 
            this.priceDataColumn.DataPropertyName = "price";
            this.priceDataColumn.HeaderText = "Price";
            this.priceDataColumn.Name = "priceDataColumn";
            this.priceDataColumn.ReadOnly = true;
            this.priceDataColumn.Width = 60;
            // 
            // qtyColumn
            // 
            this.qtyColumn.DataPropertyName = "qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.qtyColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.qtyColumn.HeaderText = "Qty";
            this.qtyColumn.Name = "qtyColumn";
            this.qtyColumn.ReadOnly = true;
            this.qtyColumn.Width = 80;
            // 
            // amountColumn
            // 
            this.amountColumn.DataPropertyName = "stockAmt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.amountColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amountColumn.HeaderText = "Amount";
            this.amountColumn.Name = "amountColumn";
            this.amountColumn.ReadOnly = true;
            // 
            // cashAmtColumn
            // 
            this.cashAmtColumn.DataPropertyName = "cashAmt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.cashAmtColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.cashAmtColumn.HeaderText = "Cash ";
            this.cashAmtColumn.Name = "cashAmtColumn";
            this.cashAmtColumn.ReadOnly = true;
            // 
            // totalAmtColumn
            // 
            this.totalAmtColumn.DataPropertyName = "totalAmt";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.totalAmtColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalAmtColumn.HeaderText = "Total";
            this.totalAmtColumn.Name = "totalAmtColumn";
            this.totalAmtColumn.ReadOnly = true;
            this.totalAmtColumn.Width = 110;
            // 
            // feeAmtColumn
            // 
            this.feeAmtColumn.DataPropertyName = "feeAmt";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.feeAmtColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.feeAmtColumn.HeaderText = "Fee";
            this.feeAmtColumn.Name = "feeAmtColumn";
            this.feeAmtColumn.ReadOnly = true;
            this.feeAmtColumn.Width = 90;
            // 
            // profitColumn
            // 
            this.profitColumn.DataPropertyName = "profit";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.profitColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.profitColumn.HeaderText = "Profit";
            this.profitColumn.Name = "profitColumn";
            this.profitColumn.ReadOnly = true;
            this.profitColumn.Width = 90;
            // 
            // profitEstimate
            // 
            this.ClientSize = new System.Drawing.Size(908, 645);
            this.Controls.Add(this.chartPnl);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "profitEstimate";
            this.Text = " Estimation";
            this.Load += new System.EventHandler(this.baseAdviceEstimate_Load);
            this.myOnProcess += new common.forms.baseDialogForm.onProcess(this.baseAdviceEstimate_myOnAccept);
            this.Resize += new System.EventHandler(this.baseAdviceEstimate_Resize);
            this.Controls.SetChildIndex(this.menuStrip, 0);
            this.Controls.SetChildIndex(this.closeBtn, 0);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.okBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.chartPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tradeEstimateSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tradeEstimateSource;
        private data.tmpDS myTmpDS;
        protected common.controls.baseDataGridView dataGrid;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected Charts.Controls.baseGraphPanel chartPnl;
        protected System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem estimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTransactionMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showChartMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem reloadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ignored;
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
