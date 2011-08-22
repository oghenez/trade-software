using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace baseClass.controls
{
    public partial class transHistoryCriteria : common.control.baseUserControl
    {
        private data.baseDS.companyDataTable companyTbl = new data.baseDS.companyDataTable();
        private data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
        public transHistoryCriteria()
        {
            try
            {
                InitializeComponent();
                stockCodeEd.isToUpperCase = true;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }

        public void Init()
        {
            portfolioCb.LoadData();
            stockExchangeCb.LoadData();
        }
        public string myPortfolio
        {
            get { return portfolioCb.myValue; }
            set { portfolioCb.myValue=value; }
        }
        public bool PortfolioEnabled
        {
            get { return portfolioChk.Enabled; }
            set 
            {
                portfolioChk.Enabled = value;
                portfolioCb.Enabled = value && portfolioChk.Checked; 
            }
        }
        public bool PortfolioChecked
        {
            get { return portfolioChk.Checked; }
            set
            {
                portfolioChk.Checked = value;
            }
        }
        
        public bool CheckValid()
        {
            bool retVal = true;
            ClearNotifyError();
            if (dateRange.Enabled && !dateRange.GetDateRange())
            {
                retVal = false;
                NotifyError(dateRangeChk);
            }
            return retVal;
        }

        public string GetSQL()
        {
            data.baseDS.investorTransHistoryDataTable transHistoryTbl = new data.baseDS.investorTransHistoryDataTable();
            string sqlCmd = "SELECT * FROM " + transHistoryTbl.TableName;
            string filter = "";
            if (portfolioChk.Checked && portfolioCb.myValue!="")
            {
                filter += (filter == "" ? "" : " AND ") + "(" + transHistoryTbl.portfolioColumn.ColumnName + "=N'" + portfolioCb.myValue + "')";
            }
            if (this.stockExchangeChk.Checked && this.stockExchangeCb.myValue != "")
            {
                data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
                filter += (filter == "" ? "" : " AND ") +  
                transHistoryTbl.stockCodeColumn.ColumnName + " IN (SELECT " +stockCodeTbl.codeColumn.ColumnName +
                " FROM " + stockCodeTbl.TableName  + " WHERE " + stockCodeTbl.stockExchangeColumn.ColumnName + "=N'" + this.stockExchangeCb.myValue.Trim() + "')";
            }
            if (this.dateRangeChk.Checked && this.dateRange.GetDateRange())
            {
                filter += (filter == "" ? "" : " AND ") +
                           "("+ transHistoryTbl.onTimeColumn.ColumnName +
                           " BETWEEN '" + common.system.ConvertToSQLDateString(this.dateRange.frDate) + "' AND '" +
                           common.system.ConvertToSQLDateString(this.dateRange.toDate) + "')";
            }
            if (this.stockCodeEd.Enabled && this.stockCodeEd.Text.Trim()!="")
            {
                filter += (filter == "" ? "" : " AND ") +
                           transHistoryTbl.stockCodeColumn.ColumnName + " =N'" + this.stockCodeEd.Text.Trim() + "'";
            }
            if (filter != "") sqlCmd += " WHERE " + filter;
            return sqlCmd;
        }

        private void stockExchangeChk_CheckedChanged(object sender, EventArgs e)
        {
            stockExchangeCb.Enabled = stockExchangeChk.Checked;
        }

        private void stockCodeChk_CheckedChanged(object sender, EventArgs e)
        {
            stockCodeEd.Enabled = stockCodeChk.Checked;
        }

        private void dateRangeChk_CheckedChanged(object sender, EventArgs e)
        {
            dateRange.Enabled = dateRangeChk.Checked;
        }

        private void portfolioChk_CheckedChanged(object sender, EventArgs e)
        {
            portfolioCb.Enabled = portfolioChk.Checked;
        }
    }
}