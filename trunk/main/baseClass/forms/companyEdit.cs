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
                this.myMasterSource = new BindingSource();
                this.myMasterSource.DataSource = myDataSet.stockCode;

                companyGeneral.Init();
                companyOtherInfo.Init();
                companyStock.Init();

                companyGeneral.SetDataSource(this.myMasterSource);
                companyStock.SetDataSource(this.myMasterSource);
                companyOtherInfo.SetDataSource(this.myMasterSource);
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
                    myDataSet.stockCode.Clear();
                    application.dataLibs.LoadData(myDataSet.stockCode, code);
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
                data.baseDS.stockCodeRow stockCodeRow = (data.baseDS.stockCodeRow)row;
                application.dataLibs.UpdateData(stockCodeRow);
            }
            else
            {
                application.dataLibs.UpdateData(myDataSet.stockCode);
            }
        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            data.baseDS.stockCodeRow row = (data.baseDS.stockCodeRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);
            row.code = code;
        }
        //Get key value in a row.
        protected override string GetKeyValue(DataRow dr)
        {
            return ((data.baseDS.stockCodeRow)dr).code;
        }
        //When delete a code, deleted code in existing data must be changed to retain the intergrity
        protected override bool ChangeCode(DataRowView drOld, string toCode, bool deleteAfterChange)
        {
            //toCode = toCode.Trim();
            //if (toCode == "") return true;

            //data.baseDS.stockCodeRow oldRow = (data.baseDS.stockCodeRow)drOld.Row;
            //data.baseDS.stockCodeRow newRow = application.dataLibs.Getprojects(toCode);
            //if (newRow == null) newRow = CreateDuplicate(oldRow, toCode);
            ////??projectsTA.ChangeprojectsCode(oldRow.code, newRow.code);

            //if (deleteAfterChange) RemoveCurrent();
            return true;
        }
        protected override DataRow FindCode(string code, bool showSelectionIfnotFound)
        {
            baseClass.forms.companyFind form = baseClass.forms.companyFind.GetForm("");
            form.Find(code, showSelectionIfnotFound);
            return form.selectedDataRow;
        }
    }
}