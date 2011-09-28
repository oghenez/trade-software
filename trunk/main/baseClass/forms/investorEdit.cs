using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class investorEdit : baseClass.forms.baseMasterEdit 
    {
        data.baseDS.portfolioDataTable watchListTbl = new data.baseDS.portfolioDataTable();
        public investorEdit()
        {
            try
            {
                InitializeComponent();
                watchListSource.DataSource = watchListTbl;
                codeEd.BackColor = common.settings.sysColorDisableBG;
                codeEd.ForeColor = common.settings.sysColorDisableFG;

                accountEd.MaxLength  = myDataSet.investor.accountColumn.MaxLength;
                passwordEd.MaxLength = myDataSet.investor.passwordColumn.MaxLength;
                firstNameEd.MaxLength = myDataSet.investor.firstNameColumn.MaxLength;
                lastNameEd.MaxLength = myDataSet.investor.lastNameColumn.MaxLength;
                address1Ed.MaxLength = myDataSet.investor.address1Column.MaxLength;
                address2Ed.MaxLength = myDataSet.investor.address2Column.MaxLength;
                displayNameEd.MaxLength = myDataSet.investor.displayNameColumn.MaxLength;
                phoneEd.MaxLength = myDataSet.investor.phoneColumn.MaxLength;
                emailEd.MaxLength = myDataSet.investor.emailColumn.MaxLength;


                this.sexCb.DataBindings.Clear();
                this.sexCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", investorSource, myDataSet.investor.sexColumn.ColumnName, true));

                this.statusCb.DataBindings.Clear();
                this.statusCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", investorSource, myDataSet.investor.statusColumn.ColumnName, true));

                countryCb.LoadData();
                sexCb.LoadData();
                statusCb.LoadData();
                investorCatCb.LoadData();

                this.allowToChangeDeleteCode = false;
                this.myFormCode = this.Name;
                myMasterSource = investorSource;
            }
            catch (Exception ex)
            {
                common.system.ShowErrorMessage(ex.Message.ToString());
            }
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
                    myDataSet.investor.Clear();
                    application.dataLibs.LoadData(myDataSet.investor, code);
                }
                if (myMasterSource.Current == null) return;
                this.SetFirstFocus();
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                common.system.ShowErrorMessage(ex.Message.ToString());
            }
        }
        protected virtual void MakeDisplayName()
        {
            if(displayNameEd.Text.Trim()=="")
                displayNameEd.Text = firstNameEd.Text; 
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
            if (passwordEd.Text.Trim().Length < application.Settings.sysPasswordMinLen)
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
                NotifyError(expireDatelbl);
                retVal = false;
            }
            if (statusCb.Visible && statusCb.myValue == application.AppTypes.CommonStatus.None)
            {
                NotifyError(statusLbl);
                retVal = false;
            }
            if (!retVal && showMsg) this.ShowMessage("Dữ liệu không hợp lệ.");
            return retVal;
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null)
            {
                application.dataLibs.UpdateData(myDataSet.investor);
            }
            else
            {
                data.baseDS.investorRow investorRow = (data.baseDS.investorRow)row;
                if (investorRow.code.Trim() == "")
                {
                    common.myAutoKeyInfo info = application.sysLibs.GetAutoKey(myDataSet.investor.TableName, false);
                    investorRow.code = info.value.ToString().PadLeft(myDataSet.investor.codeColumn.MaxLength, '0');
                }
                application.dataLibs.UpdateData(investorRow);
                if (myDataSet.portfolio.Count == 0)
                {
                    application.dataLibs.CreateBlankPorpolio(myDataSet.portfolio, investorRow);
                    //application.dataLibs.SetDefaultPorpolio(myDataSet.portfolio, myDataSet.portfolio[0].code);
                }
            }
        }
        public override void AddNew(string code)
        {
            //int saveType = unitEd.Text.Trim();
            this.AddNewRow();
            data.baseDS.investorRow row = (data.baseDS.investorRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);
            row.code = code;
            CurrentDataChanged();
        }
        protected override void LoadData()
        {
            base.LoadData();
            CurrentDataChanged();
        }

        //Get key value in a row.
        protected override string GetKeyValue(DataRow dr)
        {
            return ((data.baseDS.investorRow)dr).code;
        }
        //When delete a code, deleted code in existing data must be changed to retain the intergrity
        protected override bool ChangeCode(DataRowView drOld, string toCode, bool deleteAfterChange)
        {
            //toCode = toCode.Trim();
            //if (toCode == "") return true;

            //data.baseDS.investorRow oldRow = (data.baseDS.investorRow)drOld.Row;
            //data.baseDS.investorRow newRow = application.dataLibs.Getprojects(toCode);
            //if (newRow == null) newRow = CreateDuplicate(oldRow, toCode);
            ////??projectsTA.ChangeprojectsCode(oldRow.code, newRow.code);

            //if (deleteAfterChange) RemoveCurrent();
            return true;
        }

        protected override DataRow FindCode(string code, bool showSelectionIfnotFound)
        {
            return null;
            //baseClass.interfaces.myprojectsFind.Find(code, showSelectionIfnotFound);
            //return baseClass.interfaces.myprojectsFind.selectedDataRow;
        }
        protected virtual void CurrentDataChanged()
        {
            if (myMasterSource.Current == null) return;
            data.baseDS.investorRow investorRow = (data.baseDS.investorRow)((DataRowView)myMasterSource.Current).Row;
            passwordEd2.Text = investorRow.password;
            LoadDetailData(investorRow);
            LockEdit(this.isLockEdit);
        }
        protected void LoadDetailData(data.baseDS.investorRow investorRow)
        {
            LoadPortfolio(investorRow);
            LoadWathList(investorRow);
        }

        protected void LoadPortfolio(data.baseDS.investorRow investorRow)
        {
            myDataSet.portfolio.Clear();
            application.dataLibs.LoadPortfolioByInvestor(myDataSet.portfolio, investorRow.code, application.AppTypes.PortfolioTypes.Portfolio);
        }
        protected void LoadWathList(data.baseDS.investorRow investorRow)
        {
            this.watchListTbl.Clear();
            application.dataLibs.LoadPortfolioByInvestor(this.watchListTbl, investorRow.code, application.AppTypes.PortfolioTypes.WatchList);
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

        private void firstNameEd_Validated(object sender, EventArgs e)
        {
            MakeDisplayName();
        }

        private void lastNameEd_TextChanged(object sender, EventArgs e)
        {
            MakeDisplayName();
        }
        private void EditWatchList()
        {
            if (this.isNewRow(((DataRowView)myMasterSource.Current).Row))
            {
                common.system.ShowMessage("Xin vui lòng lưu dữ liệu trước khi thực hiện tác vụ này");
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
                    common.system.ShowMessage("Xin vui lòng lưu dữ liệu trước khi thực hiện tác vụ này");
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
                    common.system.ShowMessage("Xin vui lòng lưu dữ liệu trước khi thực hiện tác vụ này");
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