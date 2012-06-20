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
using commonTypes;

namespace baseClass.controls
{
    public partial class companyStockInfo : common.controls.baseUserControl
    {
        private BindingSource myDataSource = null;
        public companyStockInfo()
        {
            InitializeComponent();
            SetMaxLength();
            tickerCodeEd.isToUpperCase = true;
        }

        public void SetDataSource(System.Windows.Forms.BindingSource dataSrc)
        {
            this.myDataSource = dataSrc;
            databases.baseDS.stockCodeDataTable tbl = (databases.baseDS.stockCodeDataTable)this.myDataSource.DataSource; 

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
            this.regDateEd.DataBindings.Add(new System.Windows.Forms.Binding("myDateTime", this.myDataSource, tbl.regDateColumn.ColumnName, true));
            
            this.statusCb.DataBindings.Clear();
            this.statusCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.myDataSource, tbl.statusColumn.ColumnName, true));
        }
        private void SetMaxLength()
        {
            databases.baseDS.stockCodeDataTable tbl = new databases.baseDS.stockCodeDataTable();
            tickerCodeEd.MaxLength = tbl.tickerCodeColumn.MaxLength;
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            stockMarketCb.SetLanguage();
            statusCb.SetLanguage();
            stockMarketLbl.Text = Languages.Libs.GetString("exchange");
            tickerCodeLbl.Text = Languages.Libs.GetString("ticker");
            noListedStockLbl.Text = Languages.Libs.GetString("listedQty");
            outstandingStockLbl.Text = Languages.Libs.GetString("outstandingQty");
            treasuryStockLbl.Text = Languages.Libs.GetString("treasuryQty");
            foreignOwnStockLbl.Text = Languages.Libs.GetString("foreignOwnQty");
            bookPriceLbl.Text = Languages.Libs.GetString("bookPrice");
            targetPriceLbl.Text = Languages.Libs.GetString("targetPrice");
            regDateLbl.Text = Languages.Libs.GetString("regDate");
            statusLblb.Text = Languages.Libs.GetString("status");
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
            if (myDataSource == null) return;
            if (myDataSource.Current == null) state = true;
            this.stockMarketCb.Enabled = !state;
            this.tickerCodeEd.Enabled = !state;

            this.treasuryStockEd.Enabled = !state;
            this.listedStockEd.Enabled = !state;
            this.outstandingStockEd.Enabled = !state;
            this.foreignOwnStockEd.Enabled = !state;

            this.bookPriceEd.Enabled = !state;
            this.targetPriceEd.Enabled = !state;
            this.targetPriceVariantEd.Enabled = !state;

            this.regDateEd.Enabled = !state;
            this.statusCb.Enabled = !state;

        }
        public virtual void SetFocus()
        {
            this.Focus();
            stockMarketCb.Focus();
        }
    }
}
