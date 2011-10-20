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
    public partial class companyStockInfo : common.controls.baseUserControl
    {
        private BindingSource myDataSource = null;
        public companyStockInfo()
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

        public override void SetLanguage()
        {
            base.SetLanguage();
            stockMarketCb.SetLanguage();
            statusCb.SetLanguage();

            stockCodeLbl.Text = language.GetString("code");
            stockMarketLbl.Text = language.GetString("exchange");
            tickerCodeLbl.Text = language.GetString("ticker");
            noListedStockLbl.Text = language.GetString("listedQty");
            outstandingStockLbl.Text = language.GetString("outstandingQty");
            treasuryStockLbl.Text = language.GetString("treasuryQty");
            foreignOwnStockLbl.Text = language.GetString("foreignOwnQty");
            bookPriceLbl.Text = language.GetString("bookPrice");
            targetPriceLbl.Text = language.GetString("targetPrice");
            regDateLbl.Text = language.GetString("regDate");
            statusLblb.Text = language.GetString("status");
        }

        public virtual void Init() 
        {
            stockMarketCb.LoadData();
            statusCb.LoadData();
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
