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
    public partial class sysCodeCatEdit : baseMasterEdit   
    {
        public sysCodeCatEdit()
        {
            InitializeComponent();
            codeEd.isToUpperCase = true;
            myMasterSource = sysCodeCatSource;
            LockEdit(true);
            listGrid.DisableReadOnlyColumn = false;
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("category");

            codeLbl.Text = Languages.Libs.GetString("code");
            descriptionLbl.Text = Languages.Libs.GetString("name");
            maxLenLbl.Text = Languages.Libs.GetString("maxSize");
            weightLbl.Text = Languages.Libs.GetString("weight");
            tagLbl1.Text = Languages.Libs.GetString("tag")+ " 1";
            tagLbl2.Text = Languages.Libs.GetString("tag") + " 2";
            noteLbl.Text = Languages.Libs.GetString("note");
            isVisibleChk.Text = Languages.Libs.GetString("visible");
            isSystemChk.Text = Languages.Libs.GetString("system");

            codeColumn.HeaderText = Languages.Libs.GetString("code");
            descriptionColumn.HeaderText = Languages.Libs.GetString("description");
            weightColumn.HeaderText = Languages.Libs.GetString("weight");
        }
        protected override void SetFirstFocus()
        {
            this.codeEd.Focus();
        }

        protected override void LoadData()
        {
            sysCodeCatSource.DataSource = DataAccess.Libs.GetSysCodeCat(); 
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.codeEd.Enabled = !lockState;
            this.descriptionEd.Enabled = !lockState;
            this.noteEd.Enabled = !lockState;
            this.maxLenEd.Enabled = !lockState;
            this.weightEd.Enabled = !lockState;
            tagEd1.Enabled = !lockState; tagEd2.Enabled = !lockState;
            isVisibleChk.Enabled = !lockState; isSystemChk.Enabled = !lockState;
        }

        protected override bool DataValid(bool showMsg)
        {
            ClearNotifyError();
            if (codeEd.Text.Trim() == "") 
            {
                NotifyError(codeLbl); 
                this.codeEd.Focus(); return false; 
            }
            if (descriptionEd.Text.Trim() == "")
            {
                NotifyError(descriptionLbl); 
                this.descriptionEd.Focus(); return false; 
            }
            return base.DataValid(showMsg);
        }

        public override void AddNew(string code)
        {
            data.baseDS.sysCodeCatRow row = (data.baseDS.sysCodeCatRow)((DataRowView)myMasterSource.AddNew()).Row;
            if (row == null) return;
            commonClass.AppLibs.InitData(row);
            row.category = code;
            int position = myMasterSource.Position;
            myMasterSource.Position = -1;
            myMasterSource.Position = position;
            SetFirstFocus();
        }
        protected override void UpdateData(DataRow row )
        {
            if (row == null) return;
            data.baseDS.sysCodeCatRow sysCodeCatRow = (myMasterSource.Current as DataRowView).Row as data.baseDS.sysCodeCatRow;
            sysCodeCatRow.ItemArray = DataAccess.Libs.UpdateData(row as data.baseDS.sysCodeCatRow).ItemArray;
            sysCodeCatRow.AcceptChanges();
        }
        protected override bool BeforeDelete()
        {
            if (myMasterSource.Current == null) return false;
            if (!base.BeforeDelete()) return false;
            data.baseDS.sysCodeCatRow row = (data.baseDS.sysCodeCatRow)(myMasterSource.Current as DataRowView).Row;
            if (row.isSystem)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("cannotDelete"));
                return false;
            }
            return true;
        }
        protected override void RemoveCurrent()
        {
            this.ShowMessage("");
            if (myMasterSource.Current == null) return;
            data.baseDS.sysCodeCatRow row = (data.baseDS.sysCodeCatRow)(myMasterSource.Current as DataRowView).Row;
            if (row.HasVersion(DataRowVersion.Original))
                DataAccess.Libs.DeleteData(row);
            myMasterSource.RemoveCurrent();
            this.ShowMessage(Languages.Libs.GetString("dataWasDeleted"));
        }

        private void listGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message.ToString());  
            return;
        }

        private void codeEd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = this.CheckDuplicateKey(codeEd.Text.Trim(),myDataSet.sysCodeCat.categoryColumn.ColumnName);
        }
    }    
}