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

                this.myMasterSource = stockCodeSource;
                LoadData();

                companyGeneral.Init();
                companyOtherInfo.Init();
                companyStock.Init();

                companyGeneral.SetDataSource(this.myMasterSource);
                companyStock.SetDataSource(this.myMasterSource);
                companyOtherInfo.SetDataSource(this.myMasterSource);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        protected override void ReLoadData()
        {
            this.ShowMessage("");
            this.myMasterSource.DataSource = DataAccess.Libs.GetStockFull(true); 
        }
        protected override void LoadData()
        {
            this.ShowMessage("");
            this.myMasterSource.DataSource = DataAccess.Libs.GetStockFull(false); 
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            companyGeneral.SetLanguage();
            companyStock.SetLanguage();
            companyOtherInfo.SetLanguage();
        }

        public void ShowCompany(string code)
        {
            try
            {
                stockCodeSource.Filter = "";
                if (code == null)
                {
                    AddNew("");
                    LockEdit(false);
                }
                else
                {
                    LockEdit(true);
                    stockCodeSource.Filter = myDataSet.stockCode.codeColumn+"'" +  code + "'" ;
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
            if (!retVal && showMsg) this.ShowMessage(Languages.Libs.GetString("invalidData"));
            return retVal;
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null) return;
            databases.baseDS.stockCodeRow stockCodeRow = (myMasterSource.Current as DataRowView).Row as databases.baseDS.stockCodeRow;
            stockCodeRow.ItemArray = DataAccess.Libs.UpdateData(row as databases.baseDS.stockCodeRow).ItemArray;
            stockCodeRow.AcceptChanges();
        }

        protected override void RemoveCurrent()
        {
            this.ShowMessage("");
            if (myMasterSource.Current == null) return;
            databases.baseDS.stockCodeRow row = (databases.baseDS.stockCodeRow)(myMasterSource.Current as DataRowView).Row;
            if (row.HasVersion(DataRowVersion.Original))
                DataAccess.Libs.DeleteData(row);
            base.RemoveCurrent();
        }
        public override void AddNew(string code)
        {
            databases.baseDS.stockCodeRow lastRow = (databases.baseDS.stockCodeRow)((DataRowView)myMasterSource.Current).Row;
            databases.baseDS.stockCodeRow row = (databases.baseDS.stockCodeRow)((DataRowView)myMasterSource.AddNew()).Row;
            if (row == null) return;
            databases.AppLibs.InitData(row);
            row.code = code;
            if (lastRow != null)
            {
                row.stockExchange = lastRow.stockExchange;
            }
            int position = myMasterSource.Position;
            myMasterSource.Position = -1;
            myMasterSource.Position = position;
            SetFirstFocus();
        }
        //Get key value in a row.
        protected override string GetKeyValue(DataRow dr)
        {
            return ((databases.baseDS.stockCodeRow)dr).code;
        }
        protected override DataRow FindCode(string code, bool showSelectionIfnotFound)
        {
            baseClass.forms.companyFind form = baseClass.forms.companyFind.GetForm("");
            form.Find(code, showSelectionIfnotFound);
            return form.selectedDataRow;
        }
    }
}