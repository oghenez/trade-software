namespace stockTrade.forms
{
    partial class transactionList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(transactionList));
            this.myDataSet = new data.baseDS();
            this.transactionsSource = new System.Windows.Forms.BindingSource(this.components);
            this.transTypeSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid = new common.control.baseDataGridView();
            this.filterPnl = new common.control.basePanel();
            this.transactionCriteria = new baseClass.controls.transactionCriteria();
            this.filterBtn = new baseClass.controls.baseButton();
            this.tranTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.onTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewColumn = new common.control.gridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transTypeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.filterPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(3435, 201);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(21, 0, 21, 0);
            this.TitleLbl.Size = new System.Drawing.Size(210, 123);
            this.TitleLbl.Visible = false;
            // 
            // myDataSet
            // 
            this.myDataSet.DataSetName = "myDataSet";
            this.myDataSet.EnforceConstraints = false;
            this.myDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transactionsSource
            // 
            this.transactionsSource.DataMember = "transactions";
            this.transactionsSource.DataSource = this.myDataSet;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tranTypeColumn,
            this.onTimeColumn,
            this.stockCodeColumn,
            this.qtyColumn,
            this.amtColumn,
            this.viewColumn});
            this.dataGrid.DataSource = this.transactionsSource;
            this.dataGrid.DisableReadOnlyColumn = true;
            this.dataGrid.Location = new System.Drawing.Point(0, 53);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(624, 201);
            this.dataGrid.TabIndex = 10;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // filterPnl
            // 
            this.filterPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filterPnl.Controls.Add(this.transactionCriteria);
            this.filterPnl.Controls.Add(this.filterBtn);
            this.filterPnl.haveCloseButton = false;
            this.filterPnl.haveShowHideButton = true;
            this.filterPnl.isExpanded = true;
            this.filterPnl.isVisible = true;
            this.filterPnl.Location = new System.Drawing.Point(0, 0);
            this.filterPnl.Margin = new System.Windows.Forms.Padding(4);
            this.filterPnl.mySizingOptions = common.control.basePanel.SizingOptions.None;
            this.filterPnl.myWeight = 0;
            this.filterPnl.Name = "filterPnl";
            this.filterPnl.Size = new System.Drawing.Size(624, 52);
            this.filterPnl.TabIndex = 1;
            this.filterPnl.myOnShowStateChanged += new common.control.basePanel.OnShowStateChanged(this.filterPnl_myOnShowStateChanged);
            // 
            // transactionCriteria
            // 
            this.transactionCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionCriteria.Location = new System.Drawing.Point(38, 0);
            this.transactionCriteria.myPortfolio = "";
            this.transactionCriteria.Name = "transactionCriteria";
            this.transactionCriteria.PortfolioChecked = false;
            this.transactionCriteria.PortfolioEnabled = true;
            this.transactionCriteria.Size = new System.Drawing.Size(486, 49);
            this.transactionCriteria.TabIndex = 1;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::stockTrade.Properties.Resources.refresh;
            this.filterBtn.Location = new System.Drawing.Point(523, 24);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(20, 23);
            this.filterBtn.TabIndex = 2;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // tranTypeColumn
            // 
            this.tranTypeColumn.DataPropertyName = "tranType";
            this.tranTypeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.tranTypeColumn.HeaderText = "Giao dịch";
            this.tranTypeColumn.Name = "tranTypeColumn";
            this.tranTypeColumn.ReadOnly = true;
            this.tranTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tranTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // onTimeColumn
            // 
            this.onTimeColumn.DataPropertyName = "onTime";
            this.onTimeColumn.HeaderText = "Thời gian";
            this.onTimeColumn.Name = "onTimeColumn";
            this.onTimeColumn.ReadOnly = true;
            this.onTimeColumn.Width = 150;
            // 
            // stockCodeColumn
            // 
            this.stockCodeColumn.DataPropertyName = "stockCode";
            this.stockCodeColumn.HeaderText = "Mã";
            this.stockCodeColumn.Name = "stockCodeColumn";
            this.stockCodeColumn.ReadOnly = true;
            this.stockCodeColumn.Width = 80;
            // 
            // qtyColumn
            // 
            this.qtyColumn.DataPropertyName = "qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.qtyColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.qtyColumn.HeaderText = "Khối.lượng";
            this.qtyColumn.Name = "qtyColumn";
            this.qtyColumn.ReadOnly = true;
            this.qtyColumn.Width = 90;
            // 
            // amtColumn
            // 
            this.amtColumn.DataPropertyName = "amt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.amtColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amtColumn.HeaderText = "Giá.trị";
            this.amtColumn.Name = "amtColumn";
            this.amtColumn.ReadOnly = true;
            this.amtColumn.Width = 120;
            // 
            // viewColumn
            // 
            this.viewColumn.HeaderText = "";
            this.viewColumn.myValue = "";
            this.viewColumn.Name = "viewColumn";
            this.viewColumn.ReadOnly = true;
            this.viewColumn.Visible = false;
            this.viewColumn.Width = 25;
            // 
            // transactionList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(624, 276);
            this.Controls.Add(this.filterPnl);
            this.Controls.Add(this.dataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.Name = "transactionList";
            this.Text = "Transactions";
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.filterPnl, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transTypeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.filterPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected data.baseDS myDataSet;
        protected System.Windows.Forms.BindingSource transactionsSource;
        protected System.Windows.Forms.BindingSource transTypeSource;
        protected common.control.baseDataGridView dataGrid;
        protected common.control.basePanel filterPnl;
        protected baseClass.controls.baseButton filterBtn;
        protected baseClass.controls.transactionCriteria transactionCriteria;
        private System.Windows.Forms.DataGridViewComboBoxColumn tranTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtColumn;
        private common.control.gridViewImageColumn viewColumn;

    }
}