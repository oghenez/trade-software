namespace baseClass.controls
{
    partial class stockCodeSelectByWatchList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.watchListCb = new common.controls.baseComboBox();
            this.stockGV = new common.controls.baseDataGridView();
            this.stockSource = new System.Windows.Forms.BindingSource(this.components);
            this.myTmpDS = new data.tmpDS();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.refreshBtn = new baseClass.controls.baseButton();
            this.stockExchangeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceVariantColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stockGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).BeginInit();
            this.SuspendLayout();
            // 
            // watchListCb
            // 
            this.watchListCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.watchListCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.watchListCb.FormattingEnabled = true;
            this.watchListCb.Location = new System.Drawing.Point(0, 0);
            this.watchListCb.myValue = "";
            this.watchListCb.Name = "watchListCb";
            this.watchListCb.Size = new System.Drawing.Size(244, 24);
            this.watchListCb.TabIndex = 1;
            this.watchListCb.SelectionChangeCommitted += new System.EventHandler(this.watchListCb_SelectionChangeCommitted);
            // 
            // stockGV
            // 
            this.stockGV.AllowUserToAddRows = false;
            this.stockGV.AllowUserToDeleteRows = false;
            this.stockGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stockGV.AutoGenerateColumns = false;
            this.stockGV.ColumnHeadersHeight = 30;
            this.stockGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stockExchangeColumn,
            this.codeColumn,
            this.priceColumn,
            this.priceVariantColumn,
            this.stockNameColumn});
            this.stockGV.DataSource = this.stockSource;
            this.stockGV.DisableReadOnlyColumn = false;
            this.stockGV.Location = new System.Drawing.Point(0, 25);
            this.stockGV.Name = "stockGV";
            this.stockGV.ReadOnly = true;
            this.stockGV.RowHeadersWidth = 20;
            this.stockGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.stockGV.Size = new System.Drawing.Size(264, 348);
            this.stockGV.TabIndex = 10;
            this.stockGV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockGV_CellDoubleClick);
            this.stockGV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.stockGV_DataBindingComplete);
            // 
            // stockSource
            // 
            this.stockSource.DataMember = "stockCode";
            this.stockSource.DataSource = this.myTmpDS;
            // 
            // myTmpDS
            // 
            this.myTmpDS.DataSetName = "tmpDS";
            this.myTmpDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.xls";
            this.saveFileDialog.Filter = "(*.xls)|*.xls|All files (*.*)|*.*";
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Image = global::baseClass.Properties.Resources.refresh;
            this.refreshBtn.Location = new System.Drawing.Point(244, 1);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(18, 21);
            this.refreshBtn.TabIndex = 2;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // stockExchangeColumn
            // 
            this.stockExchangeColumn.DataPropertyName = "stockExchange";
            this.stockExchangeColumn.HeaderText = "Exchange";
            this.stockExchangeColumn.Name = "stockExchangeColumn";
            this.stockExchangeColumn.ReadOnly = true;
            this.stockExchangeColumn.Width = 65;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = "code";
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.Width = 45;
            // 
            // priceColumn
            // 
            this.priceColumn.DataPropertyName = "price";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.priceColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.priceColumn.HeaderText = "Price";
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.ReadOnly = true;
            this.priceColumn.Width = 65;
            // 
            // priceVariantColumn
            // 
            this.priceVariantColumn.DataPropertyName = "priceVariant";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N1";
            dataGridViewCellStyle2.NullValue = null;
            this.priceVariantColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.priceVariantColumn.HeaderText = "+/-";
            this.priceVariantColumn.Name = "priceVariantColumn";
            this.priceVariantColumn.ReadOnly = true;
            this.priceVariantColumn.Width = 50;
            // 
            // stockNameColumn
            // 
            this.stockNameColumn.DataPropertyName = "name";
            this.stockNameColumn.HeaderText = "Name";
            this.stockNameColumn.Name = "stockNameColumn";
            this.stockNameColumn.ReadOnly = true;
            this.stockNameColumn.Visible = false;
            // 
            // stockCodeSelectByWatchList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.stockGV);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.watchListCb);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "stockCodeSelectByWatchList";
            this.Size = new System.Drawing.Size(266, 375);
            this.Resize += new System.EventHandler(this.form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.stockGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTmpDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private common.controls.baseComboBox watchListCb;
        protected baseButton refreshBtn;
        protected System.Windows.Forms.BindingSource stockSource;
        protected common.controls.baseDataGridView stockGV;
        protected System.Windows.Forms.SaveFileDialog saveFileDialog;
        protected data.tmpDS myTmpDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockExchangeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceVariantColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockNameColumn;

    }
}
