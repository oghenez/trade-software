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
    public partial class companyEdit : baseClass.forms.baseMasterEdit 
    {
        public companyEdit()
        {
            try
            {
                InitializeComponent();
                this.CloseOnSave = true;
                this.allowToChangeDeleteCode = true;
                this.myFormCode = this.Name;
                myMasterSource = companySource;

                companyGeneral.Init();
                companyOtherInfo.Init();
                companyStock.Init();
            }
            catch (Exception ex)
            {
                common.system.ShowErrorMessage(ex.Message.ToString());
            }
        }

        public void ShowCompany(string code)
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
                    myDataSet.company.Clear();
                    application.dataLibs.LoadData(myDataSet.company, code);
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
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            companyGeneral.LockEdit(lockState);
            companyStock.LockEdit(lockState);
            companyOtherInfo.LockEdit(lockState);
        }
        protected override void SetFirstFocus() { companyGeneral.SetFocus(); }
        protected override bool DataValid(bool showMsg)
        {
            this.ShowMessage("");
            bool retVal = true;
            if (!companyGeneral.CheckData()) retVal = false;
            if (!companyOtherInfo.CheckData()) retVal = false;
            if (!companyStock.CheckData()) retVal = false;
            if (!retVal && showMsg) this.ShowMessage("Dữ liệu không hợp lệ.");
            return retVal;
        }
        protected override void UpdateData(DataRow row)
        {
            if (row != null)
            {
                data.baseDS.companyRow companyRow = (data.baseDS.companyRow)row;
                companyGeneral.GetData(companyRow);
                companyOtherInfo.GetData(companyRow);
                application.dataLibs.UpdateData(companyRow);
                companyStock.SaveData(companyRow.code);
            }
            else
            {
                application.dataLibs.UpdateData(myDataSet.company);
            }
        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            data.baseDS.companyRow row = (data.baseDS.companyRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);
            row.code = code;
            CurrentDataChanged();
        }
        //Get key value in a row.
        protected override string GetKeyValue(DataRow dr)
        {
            return ((data.baseDS.companyRow)dr).code;
        }
        //When delete a code, deleted code in existing data must be changed to retain the intergrity
        protected override bool ChangeCode(DataRowView drOld, string toCode, bool deleteAfterChange)
        {
            //toCode = toCode.Trim();
            //if (toCode == "") return true;

            //data.baseDS.companyRow oldRow = (data.baseDS.companyRow)drOld.Row;
            //data.baseDS.companyRow newRow = application.dataLibs.Getprojects(toCode);
            //if (newRow == null) newRow = CreateDuplicate(oldRow, toCode);
            ////??projectsTA.ChangeprojectsCode(oldRow.code, newRow.code);

            //if (deleteAfterChange) RemoveCurrent();
            return true;
        }
        protected override DataRow FindCode(string code, bool showSelectionIfnotFound)
        {
            baseClass.interfaces.myCompanyFind.Find(code, showSelectionIfnotFound);
            return baseClass.interfaces.myCompanyFind.selectedDataRow;
        }

        protected override void LoadData()
        {
            base.LoadData();
            CurrentDataChanged();
        }

        protected virtual void SetData(data.baseDS.companyRow companyRow)
        {
            companyGeneral.SetData(companyRow);
            companyOtherInfo.SetData(companyRow);
            companyStock.LoadData(companyRow.code);
        }

        protected virtual void CurrentDataChanged()
        {
            if (myMasterSource.Current == null) return;
            data.baseDS.companyRow companyRow = (data.baseDS.companyRow)((DataRowView)myMasterSource.Current).Row;
            SetData(companyRow);
            companyOtherInfo.Refresh();
            LockEdit(this.isLockEdit);
        }

        private void companySource_CurrentChanged(object sender, EventArgs e)
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
    }    
}