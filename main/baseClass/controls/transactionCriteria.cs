using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using application;
using commonClass;

namespace baseClass.controls
{
    public partial class transactionCriteria : common.controls.baseUserControl
    {
        private data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
        public transactionCriteria()
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
        public override void SetLanguage()
        {
            base.SetLanguage();
            stockCodeChk.Text = Languages.Libs.GetString("code");
            stockExchangeChk.Text = Languages.Libs.GetString("exchange");
            dateRangeChk.Text = Languages.Libs.GetString("dateTime");
            portfolioChk.Text = Languages.Libs.GetString("portfolio");
            portfolioCb.SetLanguage();
            stockExchangeCb.SetLanguage();
        }
        public void Init()
        {
            stockExchangeCb.LoadData();
            portfolioCb.LoadData(AppTypes.PortfolioTypes.Portfolio, commonClass.SysLibs.sysLoginCode, false); 
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
            string investorCode = commonClass.SysLibs.sysLoginCode;

            data.baseDS.transactionsDataTable transactionsTbl = new data.baseDS.transactionsDataTable();
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            string sqlCmd = "SELECT * FROM " + transactionsTbl.TableName;
            string filter = "";

            string portfolioCond = "";
            if (investorCode.Trim() != "")
            {
                portfolioCond +=(portfolioCond == "" ? "" : " AND ") +
                                 portfolioTbl.investorCodeColumn.ColumnName + "=N'" + investorCode.Trim() + "'";
            }
            if (portfolioCond != "")
            {
                filter += (filter == "" ? "" : " AND ") +
                          transactionsTbl.portfolioColumn.ColumnName + " IN " + common.Consts.constCRLF +
                          "(SELECT " + portfolioTbl.codeColumn.ColumnName + " FROM " + portfolioTbl.TableName +
                          " WHERE " + portfolioCond + ")";
            }

            if (this.stockExchangeChk.Checked && this.stockExchangeCb.myValue != "")
            {
                filter += (filter == "" ? "" : " AND ") +  
                transactionsTbl.stockCodeColumn.ColumnName + " IN (SELECT " +stockCodeTbl.codeColumn.ColumnName +
                " FROM " + stockCodeTbl.TableName  + " WHERE " + stockCodeTbl.stockExchangeColumn.ColumnName + "=N'" + this.stockExchangeCb.myValue.Trim() + "')";
            }
            if (this.dateRangeChk.Checked && this.dateRange.GetDateRange())
            {
                filter += (filter == "" ? "" : " AND ") +
                           "("+ transactionsTbl.onTimeColumn.ColumnName +
                           " BETWEEN '" + common.system.ConvertToSQLDateString(this.dateRange.frDate) + "' AND '" +
                           common.system.ConvertToSQLDateString(this.dateRange.toDate) + "')";
            }
            if (this.stockCodeEd.Enabled && this.stockCodeEd.Text.Trim()!="")
            {
                filter += (filter == "" ? "" : " AND ") +
                           transactionsTbl.stockCodeColumn.ColumnName + " =N'" + this.stockCodeEd.Text.Trim() + "'";
            }

            if (portfolioChk.Checked && portfolioCb.myValue.Trim() != "")
            {
                filter += (filter == "" ? "" : " AND ") +
                           transactionsTbl.portfolioColumn.ColumnName + " =N'" + portfolioCb.myValue.Trim() + "'";
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