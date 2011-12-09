using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace baseClass.controls
{
    public partial class stockCodeDetail : common.control.baseUserControl
    {
        private data.baseDS.stockCodeDataTable mystockCodeTbl = new data.baseDS.stockCodeDataTable(); 
        private BindingSource myDataSource = null;
        public stockCodeDetail()
        {
            InitializeComponent();
            SetMaxLength();
            stockCodeEd.isToUpperCase = true;
            tickerCodeEd.isToUpperCase = true;
        }

        public void SetDataSource(System.Windows.Forms.BindingSource dataSrc)
        {
            this.myDataSource = dataSrc;
            data.baseDS.stockCodeDataTable tbl = (data.baseDS.stockCodeDataTable)this.myDataSource.DataSource; 
            this.stockCodeEd.DataBindings.Clear();
            this.stockCodeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.codeColumn.ColumnName, true));

            this.stockMarketCb.DataBindings.Clear();
            this.stockMarketCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.myDataSource, tbl.stockExchangeColumn.ColumnName, true));

            this.tickerCodeEd.DataBindings.Clear();
            this.tickerCodeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.tickerCodeColumn.ColumnName, true));

            this.treasuryStockEd.DataBindings.Clear();
            this.treasuryStockEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.noTreasuryStockColumn.ColumnName, true));

            this.listedStockEd.DataBindings.Clear();
            this.listedStockEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.noListedStockColumn.ColumnName, true));
            
            this.outstandingStockEd.DataBindings.Clear();
            this.outstandingStockEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.noOutstandingStockColumn.ColumnName, true));

            this.foreignOwnStockEd.DataBindings.Clear();
            this.foreignOwnStockEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.noForeignOwnedStockColumn.ColumnName, true));

            this.capitalUnitCb.DataBindings.Clear();
            this.capitalUnitCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.myDataSource, tbl.capitalUnitColumn.ColumnName, true));

            this.workingCapitalEd.DataBindings.Clear();
            this.workingCapitalEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.workingCapColumn.ColumnName, true));

            this.totalAssetEd.DataBindings.Clear();
            this.totalAssetEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.totaAssetsColumn.ColumnName, true));

            this.totalDebtEd.DataBindings.Clear();
            this.totalDebtEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.totalDebtColumn.ColumnName, true));

            this.salesEd.DataBindings.Clear();
            this.salesEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.salesColumn.ColumnName, true));
            
            this.profitEd.DataBindings.Clear();
            this.profitEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.profitColumn.ColumnName, true));

            this.pricePerBookEd.DataBindings.Clear();
            this.pricePerBookEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.PBColumn.ColumnName, true));

            this.earnPerShareEd.DataBindings.Clear();
            this.earnPerShareEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.EPSColumn.ColumnName, true));

            this.prixePerEarningEd.DataBindings.Clear();
            this.prixePerEarningEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.PEColumn.ColumnName, true));

            this.roaEd.DataBindings.Clear();
            this.roaEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.ROAColumn.ColumnName, true));

            this.roeEd.DataBindings.Clear();
            this.roeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.ROEColumn.ColumnName, true));

            this.betaEd.DataBindings.Clear();
            this.betaEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.BETAColumn.ColumnName, true));


            this.bookPriceEd.DataBindings.Clear();
            this.bookPriceEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.bookPriceColumn.ColumnName, true));

            this.targetPriceEd.DataBindings.Clear();
            this.targetPriceEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.targetPriceColumn.ColumnName, true));

            this.targetPriceVariantEd.DataBindings.Clear();
            this.targetPriceVariantEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.targetPriceVariantColumn.ColumnName, true));

            this.regDateEd.DataBindings.Clear();
            this.regDateEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.regDateColumn.ColumnName, true));
            
            this.statusCb.DataBindings.Clear();
            this.statusCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.myDataSource, tbl.statusColumn.ColumnName, true));
        }
        private void SetMaxLength()
        {
            data.baseDS.stockCodeDataTable tbl = new data.baseDS.stockCodeDataTable();
            stockCodeEd.MaxLength = tbl.codeColumn.MaxLength;
            tickerCodeEd.MaxLength = tbl.tickerCodeColumn.MaxLength;
        }
        public virtual void Init() 
        {
            stockMarketCb.LoadData();
            statusCb.LoadData();
            capitalUnitCb.LoadData();
        }

        public virtual bool CheckData()
        {
            myDataSource.EndEdit();
            if (this.myDataSource.Current == null) return true;
            bool retVal = true;
            ClearNotifyError();
            if (stockCodeEd.Text.Trim() == "") 
            {
                NotifyError(stockCodeLbl);
                retVal = false;
            }
            if (stockMarketCb.myValue == "") 
            {
                NotifyError(stockMarketLbl);
                retVal = false;
            }
            if (tickerCodeEd .Text.Trim() == "")
            {
                NotifyError(tickerCodeLbl);
                retVal = false;
            }
            if (regDateEd.myDateTime == common.Consts.constNullDate)
            {
                NotifyError(regDateLbl);
                retVal = false;
            }
            return retVal;
        }
        public virtual void LockEdit(bool state)
        {
            if (myDataSource.Current == null) state = true;
            this.stockCodeEd.ReadOnly = state;
            this.stockMarketCb.Enabled = !state;

            this.treasuryStockEd.Enabled = state;
            this.listedStockEd.Enabled = state;
            this.outstandingStockEd.Enabled = state;
            this.foreignOwnStockEd.Enabled = state;

            this.capitalUnitCb.Enabled = state;
            this.workingCapitalEd.Enabled = state;

            this.totalAssetEd.Enabled = state;
            this.totalDebtEd.Enabled = state;
            this.salesEd.Enabled = state;
            this.profitEd.Enabled = state;

            this.pricePerBookEd.Enabled = state;
            this.earnPerShareEd.Enabled = state;
            this.prixePerEarningEd.Enabled = state;
            this.roaEd.Enabled = state;
            this.roeEd.Enabled = state;
            this.betaEd.Enabled = state;

            this.bookPriceEd.Enabled = state;
            this.targetPriceEd.Enabled = state;
            this.targetPriceVariantEd.Enabled = state;

            this.regDateEd.Enabled = state;
            this.statusCb.Enabled = state;

        }
        public virtual void SetFocus()
        {
            this.Focus();
            stockCodeEd.Focus();
        }
    }
}
