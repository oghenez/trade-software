namespace wsTest
{
    partial class test
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stockSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmpDS1 = new data.tmpDS();
            this.baseDS1 = new data.baseDS();
            this.button1 = new System.Windows.Forms.Button();
            this.useResetChk = new System.Windows.Forms.CheckBox();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockExchangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tickerCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameEnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.websiteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bizSectorsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noListedStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noOutstandingStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noForeignOwnedStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noTreasuryStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetPriceVariantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workingCapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capitalUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDebtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totaAssetsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ePSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rOEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bETADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(607, 2);
            this.TitleLbl.Size = new System.Drawing.Size(10, 25);
            this.TitleLbl.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.stockExchangeDataGridViewTextBoxColumn,
            this.tickerCodeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.nameEnDataGridViewTextBoxColumn,
            this.address1DataGridViewTextBoxColumn,
            this.address2DataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.faxDataGridViewTextBoxColumn,
            this.websiteDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.bizSectorsDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.regDateDataGridViewTextBoxColumn,
            this.noListedStockDataGridViewTextBoxColumn,
            this.noOutstandingStockDataGridViewTextBoxColumn,
            this.noForeignOwnedStockDataGridViewTextBoxColumn,
            this.noTreasuryStockDataGridViewTextBoxColumn,
            this.bookPriceDataGridViewTextBoxColumn,
            this.targetPriceDataGridViewTextBoxColumn,
            this.targetPriceVariantDataGridViewTextBoxColumn,
            this.workingCapDataGridViewTextBoxColumn,
            this.capitalUnitDataGridViewTextBoxColumn,
            this.salesDataGridViewTextBoxColumn,
            this.profitDataGridViewTextBoxColumn,
            this.equityDataGridViewTextBoxColumn,
            this.totalDebtDataGridViewTextBoxColumn,
            this.totaAssetsDataGridViewTextBoxColumn,
            this.pBDataGridViewTextBoxColumn,
            this.ePSDataGridViewTextBoxColumn,
            this.pEDataGridViewTextBoxColumn,
            this.rOADataGridViewTextBoxColumn,
            this.rOEDataGridViewTextBoxColumn,
            this.bETADataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.stockSource;
            this.dataGridView1.Location = new System.Drawing.Point(1, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(563, 329);
            this.dataGridView1.TabIndex = 0;
            // 
            // stockSource
            // 
            this.stockSource.DataMember = "stockCode";
            this.stockSource.DataSource = this.baseDS1;
            // 
            // tmpDS1
            // 
            this.tmpDS1.DataSetName = "tmpDS";
            this.tmpDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baseDS1
            // 
            this.baseDS1.DataSetName = "baseDS";
            this.baseDS1.EnforceConstraints = false;
            this.baseDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // useResetChk
            // 
            this.useResetChk.AutoSize = true;
            this.useResetChk.Location = new System.Drawing.Point(99, 6);
            this.useResetChk.Name = "useResetChk";
            this.useResetChk.Size = new System.Drawing.Size(71, 17);
            this.useResetChk.TabIndex = 145;
            this.useResetChk.Text = "Use reset";
            this.useResetChk.UseVisualStyleBackColor = true;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockExchangeDataGridViewTextBoxColumn
            // 
            this.stockExchangeDataGridViewTextBoxColumn.DataPropertyName = "stockExchange";
            this.stockExchangeDataGridViewTextBoxColumn.HeaderText = "stockExchange";
            this.stockExchangeDataGridViewTextBoxColumn.Name = "stockExchangeDataGridViewTextBoxColumn";
            this.stockExchangeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tickerCodeDataGridViewTextBoxColumn
            // 
            this.tickerCodeDataGridViewTextBoxColumn.DataPropertyName = "tickerCode";
            this.tickerCodeDataGridViewTextBoxColumn.HeaderText = "tickerCode";
            this.tickerCodeDataGridViewTextBoxColumn.Name = "tickerCodeDataGridViewTextBoxColumn";
            this.tickerCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameEnDataGridViewTextBoxColumn
            // 
            this.nameEnDataGridViewTextBoxColumn.DataPropertyName = "nameEn";
            this.nameEnDataGridViewTextBoxColumn.HeaderText = "nameEn";
            this.nameEnDataGridViewTextBoxColumn.Name = "nameEnDataGridViewTextBoxColumn";
            this.nameEnDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // address1DataGridViewTextBoxColumn
            // 
            this.address1DataGridViewTextBoxColumn.DataPropertyName = "address1";
            this.address1DataGridViewTextBoxColumn.HeaderText = "address1";
            this.address1DataGridViewTextBoxColumn.Name = "address1DataGridViewTextBoxColumn";
            this.address1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // address2DataGridViewTextBoxColumn
            // 
            this.address2DataGridViewTextBoxColumn.DataPropertyName = "address2";
            this.address2DataGridViewTextBoxColumn.HeaderText = "address2";
            this.address2DataGridViewTextBoxColumn.Name = "address2DataGridViewTextBoxColumn";
            this.address2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // faxDataGridViewTextBoxColumn
            // 
            this.faxDataGridViewTextBoxColumn.DataPropertyName = "fax";
            this.faxDataGridViewTextBoxColumn.HeaderText = "fax";
            this.faxDataGridViewTextBoxColumn.Name = "faxDataGridViewTextBoxColumn";
            this.faxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // websiteDataGridViewTextBoxColumn
            // 
            this.websiteDataGridViewTextBoxColumn.DataPropertyName = "website";
            this.websiteDataGridViewTextBoxColumn.HeaderText = "website";
            this.websiteDataGridViewTextBoxColumn.Name = "websiteDataGridViewTextBoxColumn";
            this.websiteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bizSectorsDataGridViewTextBoxColumn
            // 
            this.bizSectorsDataGridViewTextBoxColumn.DataPropertyName = "bizSectors";
            this.bizSectorsDataGridViewTextBoxColumn.HeaderText = "bizSectors";
            this.bizSectorsDataGridViewTextBoxColumn.Name = "bizSectorsDataGridViewTextBoxColumn";
            this.bizSectorsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // regDateDataGridViewTextBoxColumn
            // 
            this.regDateDataGridViewTextBoxColumn.DataPropertyName = "regDate";
            this.regDateDataGridViewTextBoxColumn.HeaderText = "regDate";
            this.regDateDataGridViewTextBoxColumn.Name = "regDateDataGridViewTextBoxColumn";
            this.regDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noListedStockDataGridViewTextBoxColumn
            // 
            this.noListedStockDataGridViewTextBoxColumn.DataPropertyName = "noListedStock";
            this.noListedStockDataGridViewTextBoxColumn.HeaderText = "noListedStock";
            this.noListedStockDataGridViewTextBoxColumn.Name = "noListedStockDataGridViewTextBoxColumn";
            this.noListedStockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noOutstandingStockDataGridViewTextBoxColumn
            // 
            this.noOutstandingStockDataGridViewTextBoxColumn.DataPropertyName = "noOutstandingStock";
            this.noOutstandingStockDataGridViewTextBoxColumn.HeaderText = "noOutstandingStock";
            this.noOutstandingStockDataGridViewTextBoxColumn.Name = "noOutstandingStockDataGridViewTextBoxColumn";
            this.noOutstandingStockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noForeignOwnedStockDataGridViewTextBoxColumn
            // 
            this.noForeignOwnedStockDataGridViewTextBoxColumn.DataPropertyName = "noForeignOwnedStock";
            this.noForeignOwnedStockDataGridViewTextBoxColumn.HeaderText = "noForeignOwnedStock";
            this.noForeignOwnedStockDataGridViewTextBoxColumn.Name = "noForeignOwnedStockDataGridViewTextBoxColumn";
            this.noForeignOwnedStockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noTreasuryStockDataGridViewTextBoxColumn
            // 
            this.noTreasuryStockDataGridViewTextBoxColumn.DataPropertyName = "noTreasuryStock";
            this.noTreasuryStockDataGridViewTextBoxColumn.HeaderText = "noTreasuryStock";
            this.noTreasuryStockDataGridViewTextBoxColumn.Name = "noTreasuryStockDataGridViewTextBoxColumn";
            this.noTreasuryStockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bookPriceDataGridViewTextBoxColumn
            // 
            this.bookPriceDataGridViewTextBoxColumn.DataPropertyName = "bookPrice";
            this.bookPriceDataGridViewTextBoxColumn.HeaderText = "bookPrice";
            this.bookPriceDataGridViewTextBoxColumn.Name = "bookPriceDataGridViewTextBoxColumn";
            this.bookPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // targetPriceDataGridViewTextBoxColumn
            // 
            this.targetPriceDataGridViewTextBoxColumn.DataPropertyName = "targetPrice";
            this.targetPriceDataGridViewTextBoxColumn.HeaderText = "targetPrice";
            this.targetPriceDataGridViewTextBoxColumn.Name = "targetPriceDataGridViewTextBoxColumn";
            this.targetPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // targetPriceVariantDataGridViewTextBoxColumn
            // 
            this.targetPriceVariantDataGridViewTextBoxColumn.DataPropertyName = "targetPriceVariant";
            this.targetPriceVariantDataGridViewTextBoxColumn.HeaderText = "targetPriceVariant";
            this.targetPriceVariantDataGridViewTextBoxColumn.Name = "targetPriceVariantDataGridViewTextBoxColumn";
            this.targetPriceVariantDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workingCapDataGridViewTextBoxColumn
            // 
            this.workingCapDataGridViewTextBoxColumn.DataPropertyName = "workingCap";
            this.workingCapDataGridViewTextBoxColumn.HeaderText = "workingCap";
            this.workingCapDataGridViewTextBoxColumn.Name = "workingCapDataGridViewTextBoxColumn";
            this.workingCapDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // capitalUnitDataGridViewTextBoxColumn
            // 
            this.capitalUnitDataGridViewTextBoxColumn.DataPropertyName = "capitalUnit";
            this.capitalUnitDataGridViewTextBoxColumn.HeaderText = "capitalUnit";
            this.capitalUnitDataGridViewTextBoxColumn.Name = "capitalUnitDataGridViewTextBoxColumn";
            this.capitalUnitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salesDataGridViewTextBoxColumn
            // 
            this.salesDataGridViewTextBoxColumn.DataPropertyName = "sales";
            this.salesDataGridViewTextBoxColumn.HeaderText = "sales";
            this.salesDataGridViewTextBoxColumn.Name = "salesDataGridViewTextBoxColumn";
            this.salesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // profitDataGridViewTextBoxColumn
            // 
            this.profitDataGridViewTextBoxColumn.DataPropertyName = "profit";
            this.profitDataGridViewTextBoxColumn.HeaderText = "profit";
            this.profitDataGridViewTextBoxColumn.Name = "profitDataGridViewTextBoxColumn";
            this.profitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // equityDataGridViewTextBoxColumn
            // 
            this.equityDataGridViewTextBoxColumn.DataPropertyName = "equity";
            this.equityDataGridViewTextBoxColumn.HeaderText = "equity";
            this.equityDataGridViewTextBoxColumn.Name = "equityDataGridViewTextBoxColumn";
            this.equityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDebtDataGridViewTextBoxColumn
            // 
            this.totalDebtDataGridViewTextBoxColumn.DataPropertyName = "totalDebt";
            this.totalDebtDataGridViewTextBoxColumn.HeaderText = "totalDebt";
            this.totalDebtDataGridViewTextBoxColumn.Name = "totalDebtDataGridViewTextBoxColumn";
            this.totalDebtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totaAssetsDataGridViewTextBoxColumn
            // 
            this.totaAssetsDataGridViewTextBoxColumn.DataPropertyName = "totaAssets";
            this.totaAssetsDataGridViewTextBoxColumn.HeaderText = "totaAssets";
            this.totaAssetsDataGridViewTextBoxColumn.Name = "totaAssetsDataGridViewTextBoxColumn";
            this.totaAssetsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pBDataGridViewTextBoxColumn
            // 
            this.pBDataGridViewTextBoxColumn.DataPropertyName = "PB";
            this.pBDataGridViewTextBoxColumn.HeaderText = "PB";
            this.pBDataGridViewTextBoxColumn.Name = "pBDataGridViewTextBoxColumn";
            this.pBDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ePSDataGridViewTextBoxColumn
            // 
            this.ePSDataGridViewTextBoxColumn.DataPropertyName = "EPS";
            this.ePSDataGridViewTextBoxColumn.HeaderText = "EPS";
            this.ePSDataGridViewTextBoxColumn.Name = "ePSDataGridViewTextBoxColumn";
            this.ePSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pEDataGridViewTextBoxColumn
            // 
            this.pEDataGridViewTextBoxColumn.DataPropertyName = "PE";
            this.pEDataGridViewTextBoxColumn.HeaderText = "PE";
            this.pEDataGridViewTextBoxColumn.Name = "pEDataGridViewTextBoxColumn";
            this.pEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rOADataGridViewTextBoxColumn
            // 
            this.rOADataGridViewTextBoxColumn.DataPropertyName = "ROA";
            this.rOADataGridViewTextBoxColumn.HeaderText = "ROA";
            this.rOADataGridViewTextBoxColumn.Name = "rOADataGridViewTextBoxColumn";
            this.rOADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rOEDataGridViewTextBoxColumn
            // 
            this.rOEDataGridViewTextBoxColumn.DataPropertyName = "ROE";
            this.rOEDataGridViewTextBoxColumn.HeaderText = "ROE";
            this.rOEDataGridViewTextBoxColumn.Name = "rOEDataGridViewTextBoxColumn";
            this.rOEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bETADataGridViewTextBoxColumn
            // 
            this.bETADataGridViewTextBoxColumn.DataPropertyName = "BETA";
            this.bETADataGridViewTextBoxColumn.HeaderText = "BETA";
            this.bETADataGridViewTextBoxColumn.Name = "bETADataGridViewTextBoxColumn";
            this.bETADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 396);
            this.Controls.Add(this.useResetChk);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "test";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.useResetChk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmpDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseDS1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource stockSource;
        private data.baseDS baseDS1;
        private data.tmpDS tmpDS1;
        private System.Windows.Forms.CheckBox useResetChk;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockExchangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tickerCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameEnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn address1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn address2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn websiteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bizSectorsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noListedStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noOutstandingStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noForeignOwnedStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noTreasuryStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetPriceVariantDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workingCapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capitalUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDebtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totaAssetsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ePSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rOEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bETADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}

