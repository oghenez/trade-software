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
    public partial class companyCriteria : common.controls.baseUserControl
    {
        private data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
        public companyCriteria()
        {
            try
            {
                InitializeComponent();
                tickerCodeEd.isToUpperCase = true;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }

        public void LoadData()
        {
            stockExchangeCb.LoadData();
            statusCb.LoadData();
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            stockExchangeCb.SetLanguage();
            stockExchangeChk.Text = Languages.Libs.GetString("exchange");
            statusChk.Text = Languages.Libs.GetString("status");
            tickerCodeChk.Text = Languages.Libs.GetString("code");
            nameChk.Text = Languages.Libs.GetString("name");
            address1Chk.Text = Languages.Libs.GetString("address");
        }

        public string GetCriteria()
        {
            return GetCriteria(stockCodeTbl.TableName, false);
        }
        public string GetCriteria(string stockCodeAlias, bool withUnicode)
        {

            string filter = "";
            if (this.nameChk.Checked && this.nameEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (stockCodeAlias == "" ? "" : stockCodeAlias + ".") + stockCodeTbl.nameColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.nameEd.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.address1Chk.Checked && this.address1Ed.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (stockCodeAlias == "" ? "" : stockCodeAlias + ".") + stockCodeTbl.address1Column.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.address1Ed.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.stockExchangeChk.Checked && this.stockExchangeCb.myValue != "")
                filter += (filter == "" ? "" : " AND ") + (stockCodeAlias == "" ? "" : stockCodeAlias + ".") + stockCodeTbl.stockExchangeColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.stockExchangeCb.myValue.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";

            if (this.statusChk.Checked)
                filter += (filter == "" ? "" : " AND ") + (stockCodeAlias == "" ? "" : stockCodeAlias + ".") + stockCodeTbl.statusColumn.ColumnName
                    + " = " +  ((byte)this.statusCb.myValue).ToString();

            if (this.tickerCodeChk.Checked && this.tickerCodeEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") + (stockCodeAlias == "" ? "" : stockCodeAlias + ".") + stockCodeTbl.tickerCodeColumn.ColumnName
                    + " LIKE " + (withUnicode ? "N" : "") + "'" + common.Consts.SQL_CMD_ALL_MARKER + this.tickerCodeEd.Text.Trim() + common.Consts.SQL_CMD_ALL_MARKER + "'";
            return filter;
        }

        public string GetSQL()
        {
            string cond = GetCriteria("a", true);
            string sqlCmd = "SELECT a.* FROM " + stockCodeTbl.TableName + " a ";
            if (cond.Trim() != "") sqlCmd += " WHERE " + cond;
            return sqlCmd;
        }

        private void address1Chk_CheckedChanged(object sender, EventArgs e)
        {
            address1Ed.Enabled = address1Chk.Checked;
        }

        private void nameChk_CheckedChanged(object sender, EventArgs e)
        {
            nameEd.Enabled = nameChk.Checked;
        }

        private void stockExchangeChk_CheckedChanged(object sender, EventArgs e)
        {
            stockExchangeCb.Enabled = stockExchangeChk.Checked;
        }

        private void tickerCodeChk_CheckedChanged(object sender, EventArgs e)
        {
            tickerCodeEd.Enabled = tickerCodeChk.Checked;
        }

        private void statusChk_CheckedChanged(object sender, EventArgs e)
        {
            statusCb.Enabled = statusChk.Checked;
        }
    }
}