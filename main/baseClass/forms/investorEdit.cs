using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using commonClass;

namespace baseClass.forms
{
    public partial class investorEdit : baseClass.forms.baseMasterEdit 
    {
        data.baseDS.investorDataTable dummyInvestorTbl = new data.baseDS.investorDataTable();
        data.baseDS.portfolioDataTable watchListTbl = new data.baseDS.portfolioDataTable();

        public investorEdit()
        {
            try
            {
                InitializeComponent();
                myMasterSource = investorSource;
                myMasterSource.DataSource = dummyInvestorTbl;
                watchListSource.DataSource = watchListTbl;
                codeEd.BackColor = common.settings.sysColorDisableBG;
                codeEd.ForeColor = common.settings.sysColorDisableFG;

                accountEd.MaxLength = dummyInvestorTbl.accountColumn.MaxLength;
                passwordEd.MaxLength = dummyInvestorTbl.passwordColumn.MaxLength;
                firstNameEd.MaxLength = dummyInvestorTbl.firstNameColumn.MaxLength;
                lastNameEd.MaxLength = dummyInvestorTbl.lastNameColumn.MaxLength;
                address1Ed.MaxLength = dummyInvestorTbl.address1Column.MaxLength;
                address2Ed.MaxLength = dummyInvestorTbl.address2Column.MaxLength;
                displayNameEd.MaxLength = dummyInvestorTbl.displayNameColumn.MaxLength;
                phoneEd.MaxLength = dummyInvestorTbl.phoneColumn.MaxLength;
                emailEd.MaxLength = dummyInvestorTbl.emailColumn.MaxLength;

                this.sexCb.DataBindings.Clear();
                this.sexCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", myMasterSource, dummyInvestorTbl.sexColumn.ColumnName, true));

                this.statusCb.DataBindings.Clear();
                this.statusCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", myMasterSource, dummyInvestorTbl.statusColumn.ColumnName, true));

                countryCb.LoadData();
                sexCb.LoadData();
                statusCb.LoadData();
                investorCatCb.LoadData();

                this.allowToChangeDeleteCode = false;
                this.myFormCode = this.Name;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("investor");

            accountLbl.Text = Languages.Libs.GetString("account");
            passwordLbl.Text = Languages.Libs.GetString("password");
            nameLbl.Text = Languages.Libs.GetString("firstName");
            lastNameLbl.Text = Languages.Libs.GetString("lastName");
            displayNameLbl.Text = Languages.Libs.GetString("displayName");

            address1Lbl.Text = Languages.Libs.GetString("address") + " 1";
            address2Lbl.Text = Languages.Libs.GetString("address") + " 2";
            countryLbl.Text = Languages.Libs.GetString("nationality");
            phoneLbl.Text = Languages.Libs.GetString("phone");
            mobileLbl.Text = Languages.Libs.GetString("mobile");
            sexLbl.Text = Languages.Libs.GetString("sex");
            noteLbl.Text = Languages.Libs.GetString("note");

            expireDateLbl.Text = Languages.Libs.GetString("expireDate");
            statusLbl.Text = Languages.Libs.GetString("status");
            investorCatLbl.Text = Languages.Libs.GetString("category");

            portfolioBtn.Text = Languages.Libs.GetString("portfolio");
            watchListBtn.Text = Languages.Libs.GetString("watchListShort");

            sexCb.SetLanguage();
            countryCb.SetLanguage();
        }
        public void ShowInvestor(string code)
        {
            try
            {
                if (code == null)
                {
                    AddNew("");
                    LockEdit(false);
                }
                else
                {
                    LockEdit(true);
                    myMasterSource.DataSource = DataAccess.Libs.GetInvestor_ByCode(code);
                }
                if (myMasterSource.Current == null) return;
                this.SetFirstFocus();
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
        protected virtual void MakeDisplayName()
        {
            displayNameEd.Text = lastNameEd.Text + (lastNameEd.Text.Trim()==""?"":",") +  firstNameEd.Text; 
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            accountEd.ReadOnly = lockState;
            passwordEd.ReadOnly = lockState;
            passwordEd2.ReadOnly = lockState;
            firstNameEd.ReadOnly = lockState;
            lastNameEd.ReadOnly = lockState;
            displayNameEd.ReadOnly = lockState;
            address1Ed.ReadOnly = lockState;
            address2Ed.ReadOnly = lockState;
            emailEd.ReadOnly = lockState;
            phoneEd.ReadOnly = lockState;
            mobileEd.ReadOnly = lockState;
            noteEd.ReadOnly = lockState;

            sexCb.Enabled = !lockState;
            countryCb.Enabled = !lockState;
            phoneEd.Enabled = !lockState;
            investorCatCb.Enabled = !lockState;
            expireDateEd.Enabled = !lockState;
            statusCb.Enabled = !lockState;
        }

        protected override void SetFirstFocus() { accountEd.Focus(); }
        protected override bool DataValid(bool showMsg)
        {
            this.ShowMessage("");
            bool retVal = true;
            ClearNotifyError();
            if (accountEd.Text.Trim() == "" || accountEd.Text.Trim().Length > accountEd.MaxLength)
            {
                NotifyError(accountLbl);
                retVal = false;
            }
            if (passwordEd.Text.Trim().Length < commonClass.Settings.sysPasswordMinLen)
            {
                NotifyError(passwordLbl);
                retVal = false;
            }
            if (passwordEd2.Visible && passwordEd.Text!=passwordEd2.Text)
            {
                NotifyError(passwordLbl);
                NotifyError(passwordEd);
                NotifyError(passwordEd2);
                retVal = false;
            }

            if (firstNameEd.Text.Trim() == "")
            {
                NotifyError(nameLbl);
                retVal = false;
            }
            if (lastNameEd.Text.Trim() == "")
            {
                NotifyError(lastNameLbl);
                retVal = false;
            }
            if (displayNameEd.Visible && displayNameEd.Text.Trim() == "")
            {
                NotifyError(displayNameEd);
                retVal = false;
            }
            if (emailEd.Visible && emailEd.Text.Trim() == "")
            {
                NotifyError(emailLbl);
                retVal = false;
            }
            if (investorCatCb.Visible && investorCatCb.myValue.Trim() == "")
            {
                NotifyError(investorCatLbl);
                retVal = false;
            }
            if (expireDateEd.Visible && expireDateEd.myDateTime == common.Consts.constNullDate)
            {
                NotifyError(expireDateLbl);
                retVal = false;
            }
            if (statusCb.Visible && statusCb.myValue == commonClass.AppTypes.CommonStatus.None)
            {
                NotifyError(statusLbl);
                retVal = false;
            }
            if (!retVal && showMsg) this.ShowMessage(Languages.Libs.GetString("invalidData"));
            return retVal;
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null) return;
            data.baseDS.investorRow investorRow = (investorSource.Current as DataRowView).Row as data.baseDS.investorRow;
            investorRow.ItemArray = DataAccess.Libs.UpdateData(row as data.baseDS.investorRow).ItemArray;
            investorRow.AcceptChanges();
        }
        public override void AddNew(string code)
        {
            data.baseDS.investorRow lastRow = (data.baseDS.investorRow)((DataRowView)myMasterSource.Current).Row;
            data.baseDS.investorRow row = (data.baseDS.investorRow)((DataRowView)myMasterSource.AddNew()).Row;
            if (row == null) return;
            commonClass.AppLibs.InitData(row);
            row.code = Consts.constNotMarkerNEW; 
            if (lastRow != null)
            {
                row.catCode = lastRow.catCode;
                if(!lastRow.IscountryNull()) row.country = lastRow.country;
            }
            int position = myMasterSource.Position;
            myMasterSource.Position = -1;
            myMasterSource.Position = position;
            //CurrentDataChanged();
            SetFirstFocus();
        }
        protected override void LoadData()
        {
            base.LoadData();
            CurrentDataChanged();
        }
        protected override void RemoveCurrent()
        {
            this.ShowMessage("");
            if (myMasterSource.Current == null) return;
            data.baseDS.investorRow row = (data.baseDS.investorRow)(myMasterSource.Current as DataRowView).Row;
            if (row.HasVersion(DataRowVersion.Original))
                DataAccess.Libs.DeleteData(row);
            myMasterSource.RemoveCurrent();
            this.ShowMessage(Languages.Libs.GetString("dataWasDeleted"));
        }

        //Get key value in a row.
        protected override string GetKeyValue(DataRow dr)
        {
            return ((data.baseDS.investorRow)dr).code;
        }

        protected override DataRow FindCode(string code, bool showSelectionIfnotFound)
        {
            forms.investorFind form = forms.investorFind.GetForm("");
            form.Find(code);
            return form.selectedDataRow;
        }
        protected virtual void CurrentDataChanged()
        {
            if (myMasterSource.Current == null) return;
            data.baseDS.investorRow investorRow = (data.baseDS.investorRow)((DataRowView)myMasterSource.Current).Row;
            passwordEd2.Text = investorRow.password;
            LockEdit(this.isLockEdit);
        }
      
        private void investorSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                CurrentDataChanged();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void firstNameEd_TextChanged(object sender, EventArgs e)
        {
            if (this.fOnProccessing) return; 
            MakeDisplayName();
        }

        private void lastNameEd_TextChanged(object sender, EventArgs e)
        {
            if (this.fOnProccessing) return;
            MakeDisplayName();
        }
        private void EditWatchList()
        {
            if (this.isNewRow(((DataRowView)myMasterSource.Current).Row))
            {
                common.system.ShowMessage(Languages.Libs.GetString("pleaseSaveBeforeContinue"));
                return;
            }
            data.baseDS.investorRow investorRow = (data.baseDS.investorRow)((DataRowView)myMasterSource.Current).Row;

            //myWatchListEditForm.ShowForm(investorRow.code);
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowError(e.Exception);
        }

        private void portfolioBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.isNewRow(((DataRowView)myMasterSource.Current).Row))
                {
                    common.system.ShowMessage(Languages.Libs.GetString("pleaseSaveBeforeContinue"));
                    return;
                }
                data.baseDS.investorRow investorRow = (data.baseDS.investorRow)((DataRowView)myMasterSource.Current).Row;
                portfolioEdit form = portfolioEdit.GetForm();
                form.myInvestorCode = investorRow.code; 
                if (this.myDockedPane!= null) form.Show(this.myDockedPane);
                else form.ShowDialog(); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void watchListBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.isNewRow(((DataRowView)myMasterSource.Current).Row))
                {
                    common.system.ShowMessage(Languages.Libs.GetString("pleaseSaveBeforeContinue"));
                    return;
                }
                data.baseDS.investorRow investorRow = (data.baseDS.investorRow)((DataRowView)myMasterSource.Current).Row;
                watchListEdit form = watchListEdit.GetForm("");
                form.myInvestorCode = investorRow.code;
                
                if (this.myDockedPane!= null) form.Show(this.myDockedPane);
                else form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }    
}