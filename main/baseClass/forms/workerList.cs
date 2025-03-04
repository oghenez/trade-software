using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class workerList : baseMasterEdit 
    {
        public workerList()
        {
            try
            {
                InitializeComponent();
                workerTypeCb.LoadData();
                myMasterSource = workerSource;
                userAccountEd.isToUpperCase = true; groupAccountEd.isToUpperCase = true;

                userAccountEd.maxlen = myDataSet.workers.loginColumn.MaxLength;
                groupAccountEd.maxlen = myDataSet.workers.loginColumn.MaxLength;

                this.LockEditData(true);
                this.allowToChangeDeleteCode = false;
                toolBox.Controls.Add(newGroupBtn);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        protected override void LoadData()
        {
            data.system.workerTA.Fill(this.myDataSet.workers);
        }

        protected override void SetFirstFocus() 
        {
            userAccountEd.Focus(); 
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.userAccountEd.Enabled = !lockState && !chkSystem.Checked;
            this.passwordEd.Enabled = !lockState;
            this.showPwdChk.Enabled = !lockState;
            this.firstNameEd.Enabled = !lockState;
            this.lastNameEd.Enabled = !lockState;
            this.workerTypeCb.Enabled = !lockState && !chkSystem.Checked;
            this.noteEd.Enabled = !lockState;
            this.telephoneEd.Enabled = !lockState;
            this.emailEd.Enabled = !lockState;
            this.mobileEd.Enabled = !lockState;
            this.expireDateEd.Enabled = !lockState ;

            groupAccountEd.Enabled = !lockState;
            groupNoteEd.Enabled = !lockState;

            if (((DataRowView)myMasterSource.Current).IsNew)
            {
                addMemberBtn.Enabled = false; deleteMemberBtn.Enabled = false;
            }
            else
            {
                addMemberBtn.Enabled = !lockState;
                deleteMemberBtn.Enabled = !lockState;
            } 
            newGroupBtn.Enabled = addNewBtn.Enabled;
        }
        protected override bool DataValid(bool showMsg)
        {
            // There is a strange behavior  that when an object is invisible, 
            // the value of binded object is always empty.
            // The code is to ensure that the correct tab is visible (the binded 
            // object is loaded) and the validate funtion runs correctly.
            int saveIdx = mainPage.SelectedIndex;
            mainPage.SelectedIndex = 0;
            mainPage.SelectedIndex = saveIdx; 
            return DataValid_Worker(showMsg);
        }

        private bool DataValid_Worker(bool showMsg)
        {
            if (userAccountEd.Text.Trim() == "")
            {
                if (showMsg) common.system.ShowErrorMessage("Chưa nhập [" + userAccountLbl.Text + "].");
                this.userAccountEd.Focus();
                return false;
            }
            string tmp = "";
            if (!application.system.PasswordIsValid(passwordEd.Text,out tmp))
            {
                if (showMsg) common.system.ShowErrorMessage(tmp);
                this.passwordEd.Focus();
                return false;
            }
            if (firstNameEd.Text.Trim() == "")
            {
                if (showMsg) common.system.ShowErrorMessage("Chưa nhập [" + firstNameLbl.Text + "].");
                this.firstNameEd.Focus();
                return false;
            }
            if (lastNameEd.Text.Trim().Trim() == "")
            {
                if (showMsg) common.system.ShowErrorMessage("Chưa nhập [" + lastNameLbl.Text + "].");
                this.lastNameEd.Focus();
                return false;
            }
            if (workerTypeCb.myValue.Trim() == "")
            {
                if (showMsg) common.system.ShowErrorMessage("Chưa nhập ["+typeLbl.Text +"].");
                this.workerTypeCb.Focus();
                return false;
            }
            if (mobileEd.Text.Trim() == "")
            {
                if (showMsg) common.system.ShowErrorMessage("Chưa nhập [" + mobileLbl.Text + "].");
                this.mobileEd.Focus();
                return false;
            }
            if (emailEd.Text.Trim() == "")
            {
                if (showMsg) common.system.ShowErrorMessage("Chưa nhập [" + emailLbl.Text + "].");
                this.emailEd.Focus();
                return false;
            }
            if (address1Ed.Text.Trim() == "")
            {
                if (showMsg) common.system.ShowErrorMessage("Chưa nhập [" + address1Lbl.Text + "].");
                this.address1Ed.Focus();
                return false;
            }

            if (expireDateEd.myDateTime == common.Consts.constNullDate)
            {
                if (showMsg) common.system.ShowErrorMessage("["+ expireDateLbl.Text +"] không hợp lệ.");
                this.expireDateEd.Focus();
                return false;
            }
            return true;
        }

        protected override void UpdateData(DataRow row) 
        {
            if (row == null)
            {
                data.system.workerTA.Update(myDataSet.workers);
                myDataSet.workers.AcceptChanges();
            }
            else
            {
                data.system.workerTA.Update(row); 
            }
        }
        public override void AddNew(string loginCode)
        {
            string saveType = workerTypeCb.myValue;
            this.AddNewRow();
            data.baseDS.workersRow row = (data.baseDS.workersRow)((DataRowView)workerSource.Current).Row;
            if (row == null) return;
            chkSystem.Checked = false;
            row.isSystem = false;
            row.isGroup = false;
            row.status = application.Consts.constNotAvailable;
            row.workerType = saveType;
            if (row.isGroup)
            {
                row.firstName = application.Consts.constNotAvailable;
                row.lastName = application.Consts.constNotAvailable;
                row.password = application.Consts.constNotAvailable;
                row.workerType = application.Consts.constNotAvailable;
                row.expireDate = DateTime.Today;
            }
            else
            {
                row.password = "";
            }
            this.userAccountEd.Text = loginCode;
            this.createDateEd.Text = common.system.DateTimeToString(DateTime.Today);
            this.expireDateEd.Text = common.system.DateTimeToString(DateTime.Today.AddDays(application.Settings.sysDefaultWorkerDayToExpire));
            groupMemberLb.Items.Clear();
        }
        
        //Get key value in a row. ??
        protected override string GetKeyValue(DataRow dr)
        {
            return ((data.baseDS.workersRow)dr).login;
        }
        
        //Group can be delte without intergrity checking
        protected override bool BeforeDelete()
        {
            if (chkSystem.Checked)
            {
                common.system.ShowErrorMessage("Không thể xóa tài khỏan này");
                return false;
            }
            return base.BeforeDelete();
        }
        //When delete a code, deleted code in existing data must be changed to retain the intergrity
        //protected override bool ChangeCode(DataRowView drOld, string toCode, bool deleteAfterChange)
        //{
        //    toCode = toCode.Trim();
        //    if (toCode == "") return true;

        //    data.baseDS.workersRow oldRow = (data.baseDS.workersRow)drOld.Row;
        //    data.baseDS.workersRow newRow = application.dataLib.GetWorker(toCode);
        //    if (newRow == null) newRow = CreateDuplicate(oldRow, toCode);

        //    data.system.workerTA.ChangeWorkerId(oldRow.workersId, newRow.workersId);

        //    if (deleteAfterChange) RemoveCurrent();
        //    return true;
        //}
        //private data.baseDS.workersRow CreateDuplicate(data.baseDS.workersRow oldRow, string newCode)
        //{
        //    data.baseDS.workersRow newRow = myDataSet.workers.NewworkerRow();
        //    newRow.ItemArray = oldRow.ItemArray;
        //    newRow.login = newCode;
        //    myDataSet.workers.AddworkerRow(newRow);
        //    data.system.workerTA.Update(newRow);
        //    return newRow;
        //}

        //protected override DataRowView FindCode(string code, bool showSelectionIfnotFound)
        //{
        //    baseClass.interfaces.myWorkerFind.Find(code, showSelectionIfnotFound);
        //    return baseClass.interfaces.myWorkerFind.selectedDataRow;
        //}

        #region even handler
        private void workerEdit_Load(object sender, EventArgs e)
        {
            try
            {
                data.system.workerTA.Fill(this.myDataSet.workers);

                showPwdChk.Visible = application.system.isSupperAdminLogin();
                passwordLbl.Visible = !showPwdChk.Visible;
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }
        private void workerGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            OnDataError(sender, e);
            return;
        }

        private void showPwdChk_CheckedChanged(object sender, EventArgs e)
        {
            this.passwordEd.PasswordChar = (this.showPwdChk.Checked ? (char)0 : '*');
        }

        private void  userAccountEd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = this.CheckDuplicateKey(userAccountEd.Text, myDataSet.workers.loginColumn.ColumnName);
        }
        private void customerGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }
        #endregion
    }
}