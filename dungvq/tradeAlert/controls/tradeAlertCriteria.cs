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

namespace tradeAlert.controls
{
    public partial class tradeAlertCriteria : common.control.baseUserControl
    {
        public tradeAlertCriteria()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        public void LoadData()
        {
            tradeAlertStatusCb.LoadData();
            portpolioCb.LoadData();
            strategyCb.LoadData();
        }
        public string GetSQL()
        {
            data.baseDS.portpolioDataTable portpolioTbl = new data.baseDS.portpolioDataTable();
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            string condCmd = "";
            condCmd += (condCmd == "" ? "" : " AND ") +
                "(" + tradeAlertTbl.portpolioColumn.ColumnName +
                    " IN (" +
                    " SELECT " + portpolioTbl.codeColumn.ColumnName +
                    " FROM " + portpolioTbl.TableName +
                    " WHERE " + portpolioTbl.investorCodeColumn.ColumnName + "=N'" + application.sysLibs.sysLoginCode + "'))";

            if (frDateEd.Enabled && !frDateEd.isDateNull())
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.onTimeColumn.ColumnName + ">='" + common.system.ConvertToSQLDateString(frDateEd.myDateTime) + "')";
            if (tradeAlertStatusCb.Enabled)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.statusColumn.ColumnName + " & " + ((byte)tradeAlertStatusCb.myValue).ToString() + ">0)";

            if (portpolioCb.Enabled)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.portpolioColumn.ColumnName + "=N'" + portpolioCb.myValue + "')";

            if (strategyCb.Enabled)
                condCmd += (condCmd == "" ? "" : " AND ") +
                    "(" + tradeAlertTbl.strategyColumn.ColumnName + "=N'" + strategyCb.myValue + "')";

            string sqlCmd = "SELECT * FROM " + tradeAlertTbl.TableName +
                            (condCmd == "" ? "" : " WHERE " + condCmd) +
                            " ORDER BY " + tradeAlertTbl.onTimeColumn.ColumnName + " DESC";
            return sqlCmd;
        }
        #region event handler
        private void tradeAlertStatusChk_CheckedChanged(object sender, EventArgs e)
        {
            tradeAlertStatusCb.Enabled = tradeAlertStatusChk.Checked;
        }
        private void portpolioChk_CheckedChanged(object sender, EventArgs e)
        {
            portpolioCb.Enabled = portpolioChk.Checked;
        }
        private void frDateChk_CheckedChanged(object sender, EventArgs e)
        {
            frDateEd.Enabled = frDateChk.Checked;
        }
        private void strategyChk_CheckedChanged(object sender, EventArgs e)
        {
            strategyCb.Enabled = strategyChk.Checked;
        }
        #endregion
    }
}