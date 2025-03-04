using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using commonClass;

namespace Trade.Forms
{
    public partial class alertFilter : baseClass.forms.baseDialogForm  
    {
        public alertFilter()
        {
            try
            {
                InitializeComponent();
                statusCb.LoadData();
                portfolioCb.LoadData();
                strategyCb.LoadData();
                timeScaleCb.LoadData();
        
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("filter");
            dateRangeChk.Text = Languages.Libs.GetString("onDate");
            codeChk.Text = Languages.Libs.GetString("code");
            portfolioChk.Text = Languages.Libs.GetString("portfolio");
            strategyChk.Text = Languages.Libs.GetString("strategy");
            timeScaleChk.Text = Languages.Libs.GetString("timeScale");
            statusChk.Text = Languages.Libs.GetString("status");

            portfolioCb.SetLanguage();
            timeScaleCb.SetLanguage();
            strategyCb.SetLanguage();
            statusCb.SetLanguage();
        }
        
        public void SetDateRange(bool enable,bool check)
        {
            dateRangeChk.Enabled  = enable;
            dateRangeChk.Checked = check;
            dateRangeChk_CheckedChanged(null,null);
            if (!enable) dateRange.Enabled = false;
        }
        public DateTime myFromDate
        {
            get { return dateRange.frDate;}
            set { dateRange.frDate = value;}
        }
        public DateTime myToDate
        {
            get { return dateRange.toDate; }
            set { dateRange.toDate = value; }
        }

        public void SetPortfolio(bool enable, bool check)
        {
            portfolioChk.Enabled = enable;
            portfolioChk.Checked = check;
            portfolioChk_CheckedChanged(null, null);
            if (!enable) portfolioCb.Enabled = false;
        }
        public string myPortfolio
        {
            get { return portfolioCb.myValue; }
            set { portfolioCb.myValue = value; }
        }

        public void SetStockCode(bool enable, bool check)
        {
            codeChk.Enabled = enable;
            codeChk.Checked = check;
            stockChk_CheckedChanged(null, null);
            if (!enable) codeEd.Enabled = false;
        }
        public string myStockCode
        {
            get { return codeEd.Text; }
            set { codeEd.Text = value; }
        }

        public void SetStatus(bool enable, bool check)
        {
            statusChk.Enabled = enable;
            statusChk.Checked = check;
            statusChk_CheckedChanged(null, null);
            if (!enable) statusCb.Enabled = false;
        }
        public AppTypes.CommonStatus myStatus
        {
            get { return statusCb.myValue; }
            set { statusCb.myValue = value; }
        }

        protected override bool BeforeAcceptProcess()
        {
            bool retVal = true;
            ClearNotifyError();
            if (dateRange.Enabled && !dateRange.GetDateRange()) retVal = false;
            return retVal;
        }
        public string GetSQL()
        {
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            string condCmd = "";
            condCmd += (condCmd == "" ? "" : " AND ") +
                "(" + tradeAlertTbl.portfolioColumn.ColumnName +
                    " IN (" +
                    " SELECT " + portfolioTbl.codeColumn.ColumnName +
                    " FROM " + portfolioTbl.TableName +
                    " WHERE " + portfolioTbl.investorCodeColumn.ColumnName + "=N'" + commonClass.SysLibs.sysLoginCode + "'))";

            if (dateRangeChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.onTimeColumn.ColumnName + 
                    " BETWEEN '" + common.system.ConvertToSQLDateString(dateRange.frDate,false) + "' AND '"+
                                   common.system.ConvertToSQLDateString(dateRange.toDate.AddDays(1).AddSeconds(-1),false) + "')";
            if (statusChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.statusColumn.ColumnName + " & " + ((byte)statusCb.myValue).ToString() + ">0)";

            if (portfolioChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.portfolioColumn.ColumnName + "=N'" + portfolioCb.myValue + "')";

            if (strategyChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.strategyColumn.ColumnName + "=N'" + strategyCb.myValue + "')";

            
            if (timeScaleChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.timeScaleColumn.ColumnName + "='" + timeScaleCb.myValue.Code + "')";

            if (codeChk.Checked)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.stockCodeColumn.ColumnName + "=N'" + codeEd.Text.Trim() + "')";

            string sqlCmd = "SELECT * FROM " + tradeAlertTbl.TableName +
                            (condCmd == "" ? "" : " WHERE " + condCmd) +
                            " ORDER BY " + tradeAlertTbl.onTimeColumn.ColumnName + " DESC";
            return sqlCmd;
        }

        #region event handler
        private void dateRangeChk_CheckedChanged(object sender, EventArgs e)
        {
            dateRange.Enabled = dateRangeChk.Checked;
        }
        private void statusChk_CheckedChanged(object sender, EventArgs e)
        {
            statusCb.Enabled = statusChk.Checked;
        }
        private void portfolioChk_CheckedChanged(object sender, EventArgs e)
        {
            portfolioCb.Enabled = portfolioChk.Checked;
        }
        private void strategyChk_CheckedChanged(object sender, EventArgs e)
        {
            strategyCb.Enabled = strategyChk.Checked;
        }
        private void stockChk_CheckedChanged(object sender, EventArgs e)
        {
            codeEd.Enabled = codeChk.Checked;
        }
        private void timeScaleChk_CheckedChanged(object sender, EventArgs e)
        {
            timeScaleCb.Enabled = timeScaleChk.Checked;
        }
        #endregion
    }    
}