namespace Trade.Forms
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
            this.myTmpDS = new data.tmpDS();
            this.dataGrid = new common.controls.baseDataGridView();
            this.stockCodeSource = new System.Windows.Forms.BindingSource(this.components);
            this.filterPnl = new common.controls.basePanel();
            this.transactionCriteria = new baseClass.controls.transactionCriteria();
            this.filterBtn = new baseClass.controls.baseButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tranTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.onTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewColumn = new common.controls.gridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transTypeSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).BeginInit();
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
            // transTypeSource
            // 
            this.transTypeSource.DataMember = "codeList";
            this.transTypeSource.DataSource = this.myTmpDS;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.codeColumn,
            this.nameColumn,
            this.qtyColumn,
            this.amtColumn,
            this.viewColumn});
            this.dataGrid.DataSource = this.transactionsSource;
            this.dataGrid.DisableReadOnlyColumn = false;
            this.dataGrid.Location = new System.Drawing.Point(0, 55);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(824, 277);
            this.dataGrid.TabIndex = 10;
            this.dataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellClick);
            // 
            // stockCodeSource
            // 
            this.stockCodeSource.DataMember = "stockCode";
            this.stockCodeSource.DataSource = this.myDataSet;
            // 
            // filterPnl
            // 
            this.filterPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filterPnl.Controls.Add(this.transactionCriteria);
            this.filterPnl.Controls.Add(this.filterBtn);
            this.filterPnl.haveCloseButton = false;
            this.filterPnl.isExpanded = true;
            this.filterPnl.Visible = true;
            this.filterPnl.Location = new System.Drawing.Point(0, 0);
            this.filterPnl.myIconLocations = common.controls.basePanel.IconLocations.TopRight;
            this.filterPnl.mySizingOptions = common.controls.basePanel.SizingOptions.None;
            this.filterPnl.myWeight = 0;
            this.filterPnl.Name = "filterPnl";
            this.filterPnl.Size = new System.Drawing.Size(824, 52);
            this.filterPnl.TabIndex = 1;
            this.filterPnl.myOnShowStateChanged += new common.controls.basePanel.OnShowStateChanged(this.filterPnl_myOnShowStateChanged);
            // 
            // transactionCriteria
            // 
            this.transactionCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionCriteria.Location = new System.Drawing.Point(38, 0);
            this.transactionCriteria.Name = "transactionCriteria";
            this.transactionCriteria.Size = new System.Drawing.Size(411, 49);
            this.transactionCriteria.TabIndex = 1;
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Image = global::Trade.Properties.Resources.refresh;
            this.filterBtn.Location = new System.Drawing.Point(451, 21);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(20, 23);
            this.filterBtn.TabIndex = 2;
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.xls";
            this.saveFileDialog.Filter = "(*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // tranTypeColumn
            // 
            this.tranTypeColumn.DataPropertyName = "tranType";
            this.tranTypeColumn.DataSource = this.transTypeSource;
            this.tranTypeColumn.DisplayMember = "description";
            this.tranTypeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.tranTypeColumn.HeaderText = "Transaction";
            this.tranTypeColumn.Name = "tranTypeColumn";
            this.tranTypeColumn.ReadOnly = true;
            this.tranTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tranTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.tranTypeColumn.ValueMember = "code";
            // 
            // onTimeColumn
            // 
            this.onTimeColumn.DataPropertyName = "onTime";
            this.onTimeColumn.HeaderText = "Date/Time";
            this.onTimeColumn.Name = "onTimeColumn";
            this.onTimeColumn.ReadOnly = true;
            this.onTimeColumn.Width = 150;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "stockCode";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 80;
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "stockCode";
            this.nameColumn.DataSource = this.stockCodeSource;
            this.nameColumn.DisplayMember = "name";
            this.nameColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.nameColumn.HeaderText = "Description";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.ReadOnly = true;
            this.nameColumn.ValueMember = "code";
            this.nameColumn.Width = 200;
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
            this.qtyColumn.Width = 90;
            // 
            // amtColumn
            // 
            this.amtColumn.DataPropertyName = "amt";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.amtColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amtColumn.HeaderText = "Amount";
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
            this.viewColumn.Width = 25;
            // 
            // transactionList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(824, 358);
            this.Controls.Add(this.filterPnl);
            this.Controls.Add(this.dataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.Name = "transactionList";
            this.Text = "Transactions";
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.Controls.SetChildIndex(this.dataGrid, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.filterPnl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transTypeSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockCodeSource)).EndInit();
            this.filterPnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected data.baseDS myDataSet;
        protected System.Windows.Forms.BindingSource transactionsSource;
        protected System.Windows.Forms.BindingSource transTypeSource;
        protected common.controls.baseDataGridView dataGrid;
        protected common.controls.basePanel filterPnl;
        protected baseClass.controls.baseButton filterBtn;
        protected baseClass.controls.transactionCriteria transactionCriteria;
        protected System.Windows.Forms.BindingSource stockCodeSource;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected data.tmpDS myTmpDS;
        private System.Windows.Forms.DataGridViewComboBoxColumn tranTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtColumn;
        private common.controls.gridViewImageColumn viewColumn;

    }
}