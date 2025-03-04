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
    public partial class feedbackEdit : baseMasterEdit 
    {
        public feedbackEdit()
        {
            try
            {
                InitializeComponent();
                messagesSource.DataSource = myDataSet.messages;
                this.myMasterSource = messagesSource;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            feedbackTypeCb.LoadData();

            this.Text = Languages.Libs.GetString("feedback");

            dateTimeLbl.Text  = Languages.Libs.GetString("dateTime");
            codeLbl.Text = Languages.Libs.GetString("code");
            senderNameLbl.Text = Languages.Libs.GetString("sender");
            feedbackTypeLbl.Text = Languages.Libs.GetString("subject");
            contentLbl.Text = Languages.Libs.GetString("contents");
            saveBtn.Text = Languages.Libs.GetString("send");
        }
        public override void AddNew(string code)
        {
            databases.baseDS.messagesRow row = myDataSet.messages.NewmessagesRow();
            databases.AppLibs.InitData(row);
            row.OnDate = DateTime.Now;
            row.SenderId = commonClass.SysLibs.sysLoginCode;
            row.ReceiverId = commonTypes.Settings.sysAdminCode;
            dateTimeEd.myDateTime = row.OnDate;
            myDataSet.messages.AddmessagesRow(row);
            int position = myMasterSource.Position;
            myMasterSource.Position = -1;
            myMasterSource.Position = position;
            SetFirstFocus();
        }

        public void ShowForm()
        {
            databases.tmpDS.investorRow investorRow = DataAccess.AppLibs.FindAndCache_Investor(commonClass.SysLibs.sysLoginCode);
            if (investorRow != null) senderEd.Text = investorRow.displayName;
            AddNew("");
            LockEditData(false);
            this.Show();
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null) return;
            databases.baseDS.messagesRow messagesRow = (myMasterSource.Current as DataRowView).Row as databases.baseDS.messagesRow;
            messagesRow.ItemArray = DataAccess.Libs.UpdateData(row as databases.baseDS.messagesRow).ItemArray;
            messagesRow.AcceptChanges();
            common.system.ShowMessage(Languages.Libs.GetString("feedbackSent"));
            this.Close();
        }
        public override void LockEdit(bool lockState)
        {
            dateTimeEd.ReadOnly = true;
            dateTimeEd.BackColor = common.Settings.sysColorDisableBG;
            dateTimeEd.ForeColor = common.Settings.sysColorDisableFG;

            senderEd.ReadOnly = true; 
            senderEd.BackColor = common.Settings.sysColorDisableBG;
            senderEd.ForeColor = common.Settings.sysColorDisableFG;

            codeEd.ReadOnly = true;
            codeEd.BackColor = common.Settings.sysColorDisableBG;
            codeEd.ForeColor = common.Settings.sysColorDisableFG; 
            
            feedbackTypeCb.Enabled = !lockState;
            contentEd.ReadOnly = lockState;
            contentEd.BackColor = common.Settings.sysColorNormalBG;
            contentEd.ForeColor = common.Settings.sysColorNormalFG; 
            base.LockEdit(lockState);
        }
        protected override void SetFirstFocus() { feedbackTypeCb.Focus(); }
        protected override bool DataValid(bool showMsg)
        {
            this.ShowMessage("");
            ClearNotifyError();
            bool retVal = true;
            if (feedbackTypeCb.myValue.Trim() == "")
            {
                NotifyError(feedbackTypeLbl);
                retVal = false;
            }
            if (contentEd.Text.Trim() == "")
            {
                NotifyError(contentLbl);
                retVal = false;
            }
            if (!retVal && showMsg) this.ShowMessage(Languages.Libs.GetString("invalidData"));
            return retVal;
        }
        
        #region event handler
        #endregion event handler
    }
}