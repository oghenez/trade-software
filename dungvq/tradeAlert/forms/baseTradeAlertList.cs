using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace tradeAlert.forms
{
    public partial class baseTradeAlertList : common.forms.baseForm
    {
        public baseTradeAlertList()
        {
            try
            {
                InitializeComponent();
                ResizeForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private baseTradeAlertEdit _myTradeAlertEditForm = null;
        private baseTradeAlertEdit myTradeAlertEditForm
        {
            get
            {
                if (_myTradeAlertEditForm == null || _myTradeAlertEditForm.IsDisposed)
                    _myTradeAlertEditForm = GetTradeAlertEditForm();
                return _myTradeAlertEditForm;
            }
        }
        protected virtual baseTradeAlertEdit GetTradeAlertEditForm()
        {
            return new baseTradeAlertEdit();
        }

        protected void ShowReccount()
        {
            base.ShowReccount(myReccount.ToString());
        }
        public int myReccount
        {
            get { return tradeAlertSource.Count; }
        }
        public void LoadData()
        {
            LoadData(application.myTypes.commonStatus.New);
        }
        public void LoadData(application.myTypes.commonStatus status)
        {
            myDataSet.tradeAlert.Clear();
            application.dataLibs.LoadData(myDataSet.tradeAlert, application.sysLibs.sysLoginCode, (byte)status);
            tradeAlertList.myDataSource = tradeAlertSource;
            ShowReccount();
        }
        protected virtual void ResizeForm()
        {
            tradeAlertList.Size  = new Size (this.ClientRectangle.Width,this.ClientRectangle.Height - tradeAlertList.Location.Y - SystemInformation.CaptionHeight-5);
        }

        #region event handler
        private void baseTradeAlert_Resize(object sender, EventArgs e)
        {
            try
            {
                ResizeForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void tradeAlertList_myOnCellClick(tradeAlert.controls.tradeAlertList.gridColumnName colName, data.baseDS.tradeAlertRow row)
        {
            switch (colName)
            {
                case tradeAlert.controls.tradeAlertList.gridColumnName.Cancel:
                    if (common.system.ShowDialogYesNo("Hủy thông báo này ?") == DialogResult.No) return;
                    application.dataLibs.CancelTradeAlert(row);
                    application.dataLibs.UpdateData(row);
                    break;
                case tradeAlert.controls.tradeAlertList.gridColumnName.View:
                    myTradeAlertEditForm.ShowForm(tradeAlertSource, row.id);
                    break;
            }
        }
        #endregion

    }
}