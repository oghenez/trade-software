using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using application;
using databases;
using commonTypes;
using common;

namespace baseClass.forms
{
    public partial class syslogViewer : baseForm 
    {
        private bool fProcessing = false;
        private bool _fullMode = false;
        private bool fullMode
        {
            get { return _fullMode; }
            set
            {
                _fullMode = value;
                this.Height = syslogGrid.Location.Y + 7 + 2 * SystemInformation.CaptionHeight + (_fullMode ? syslogGrid.Height : 0);
                this.Width = optionPnl.Location.X + optionPnl.Width + (_fullMode ? infoPnl.Width : 0) + 5;

                infoPnl.Visible = _fullMode;
                syslogGrid.Visible = _fullMode;
                Application.DoEvents();
            }
        }
        public syslogViewer()
        {
            try
            {
                InitializeComponent();
                fullMode = false;
                logTypeCb.LoadData();
                typeCb.LoadData();
                investorEd.BackColor = desc3Ed.BackColor;
                dateTimeEd.BackColor = desc3Ed.BackColor;

                common.system.AutoFitGridColumn(syslogGrid, descriptionColumn.Name);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("systemLog");

            logTypeChk.Text = Languages.Libs.GetString("logType");
            accountChk.Text = Languages.Libs.GetString("account");
            sourceChk.Text = Languages.Libs.GetString("source");
            descChk.Text = Languages.Libs.GetString("description");
            messageChk.Text = Languages.Libs.GetString("information");

            codeLbl.Text = Languages.Libs.GetString("code");
            typeLbl.Text = Languages.Libs.GetString("logType");
            onDateLbl.Text = Languages.Libs.GetString("dateTime");
            investorLbl.Text = Languages.Libs.GetString("investor");
            sourceLbl.Text = Languages.Libs.GetString("source");
            desc3Lbl.Text = Languages.Libs.GetString("description");
            infoLbl.Text = Languages.Libs.GetString("information");

            onDateColumn.HeaderText = Languages.Libs.GetString("dateTime");
            descriptionColumn.HeaderText = Languages.Libs.GetString("description");
            investorCodeColumn.HeaderText = Languages.Libs.GetString("account");
        }

        private void LoadData()
        {
            DataAccess.AppLibs.LoadInvestor(DataAccess.AppLibs.myCacheBaseDS.investor,false);
            investorSource.DataSource = DataAccess.AppLibs.myCacheBaseDS.investor;


            string filter = myBaseDS.sysLog.onDateColumn.ColumnName + " BETWEEN '" +
                                            common.system.ConvertToSQLDateString(dateRange.frDate) + "' AND '" +
                                            common.system.ConvertToSQLDateString(dateRange.toDate) + "'";
            if (accountChk.Checked && accountEd.Text.Trim() != "")
            {
                databases.tmpDS.investorRow row = DataAccess.AppLibs.GetInvestorByAccount(accountEd.Text.Trim());
                if (row != null)
                    filter += (filter == "" ? "" : " AND ") + common.system.MakeSearchExpression(myBaseDS.sysLog.investorCodeColumn.ColumnName, row.code, system.searchOptions.Exact, true);
            }
            if (sourceChk.Checked && sourceEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") +
                    common.system.MakeSearchExpression(myBaseDS.sysLog.sourceColumn.ColumnName, sourceEd.Text.Trim(), system.searchOptions.Contain,true);
            if (descChk.Checked && descEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") +
                    common.system.MakeSearchExpression(myBaseDS.sysLog.descriptionColumn.ColumnName, descEd.Text.Trim(), system.searchOptions.Contain, true);

            if (messageChk.Checked && messageEd.Text.Trim() != "")
                filter += (filter == "" ? "" : " AND ") +
                    common.system.MakeSearchExpression(myBaseDS.sysLog.messageColumn.ColumnName, messageEd.Text.Trim(), system.searchOptions.Contain, true);

            if (logTypeChk.Checked)
            {
                filter += (filter == "" ? "" : " AND ") +
                    myBaseDS.sysLog.typeColumn.ColumnName + " = " + ((byte)logTypeCb.myValue).ToString();
            }
            string sqlCmd = "SELECT * FROM " + myBaseDS.sysLog.TableName + (filter == "" ? "" : " WHERE " + filter);
            syslogSource.DataSource = DataAccess.Libs.GetSyslog_BySQL(sqlCmd);
            
            

            this.ShowReccount(syslogSource.Count);
        }

        #region event handler
        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                fProcessing = true;
                this.ShowMessage("");
                ClearNotifyError();
                if(!dateRange.GetDateRange()) 
                {
                    NotifyError(dateRange);
                    return; 
                }
                
                fullMode = false;
                LoadData();
                fullMode = true;
                fProcessing = false;
                this.ShowReccount(syslogSource.Count);
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void descChk_CheckedChanged(object sender, EventArgs e)
        {
            descEd.Enabled = descChk.Checked;
        }

        private void logTypeChk_CheckedChanged(object sender, EventArgs e)
        {
            logTypeCb.Enabled = logTypeChk.Checked;
        }

        private void messageChk_CheckedChanged(object sender, EventArgs e)
        {
            messageEd.Enabled = messageChk.Checked;
        }

        private void accountChk_CheckedChanged(object sender, EventArgs e)
        {
            accountEd.Enabled = accountChk.Checked;
        }

        private void syslogViewer_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                //fullMode = fullMode;
                common.system.AutoFitGridColumn(syslogGrid, descriptionColumn.Name);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void sourceChk_CheckedChanged(object sender, EventArgs e)
        {
            sourceEd.Enabled = sourceChk.Checked;
        }
        private void syslogSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing || syslogSource.Current==null) return;
                databases.baseDS.sysLogRow logRow = (databases.baseDS.sysLogRow) ((DataRowView)syslogSource.Current).Row;
                investorEd.Text = "";
                if (!logRow.IsinvestorCodeNull())
                {
                    databases.tmpDS.investorRow row = DataAccess.AppLibs.FindAndCache_Investor(logRow.investorCode);
                    if (row != null) investorEd.Text = row.displayName;
                }
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
        #endregion event handler
    }
}