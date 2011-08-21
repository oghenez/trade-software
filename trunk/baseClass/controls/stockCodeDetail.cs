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
        private data.baseDS.companyDataTable myCompanyTbl = new data.baseDS.companyDataTable(); 
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

            this.regDateEd.DataBindings.Clear();
            this.regDateEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.regDateColumn.ColumnName, true));

            this.noSharesEd.DataBindings.Clear();
            this.noSharesEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.noOpenSharesColumn.ColumnName, true));
            
            this.noForeignOwnSharesEd.DataBindings.Clear();
            this.noForeignOwnSharesEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.noForeignOwnSharesColumn.ColumnName, true));

            this.targetPriceEd.DataBindings.Clear();
            this.targetPriceEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.targetPriceColumn.ColumnName, true));

            this.targetPriceVariantEd.DataBindings.Clear();
            this.targetPriceVariantEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.targetPriceVariantColumn.ColumnName, true));

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
            stockCodeEd.ReadOnly = state;
            regDateEd.ReadOnly = state;
            noSharesEd.ReadOnly = state;
            noForeignOwnSharesEd.ReadOnly = state;
            targetPriceEd.ReadOnly = state;
            targetPriceVariantEd.ReadOnly = state;
            stockMarketCb.Enabled = !state;
            statusCb.Enabled = !state;
        }
        public virtual void SetFocus()
        {
            this.Focus();
            stockCodeEd.Focus();
        }
    }
}
