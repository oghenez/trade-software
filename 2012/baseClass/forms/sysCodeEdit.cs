using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class sysCodeEdit :  baseMasterEdit
    {
        public sysCodeEdit()
        {
            try
            {
                InitializeComponent();
                codeEd.isToUpperCase = true;
                inGroupEd.isToUpperCase = true;
                inGroupEd.MaxLength = myDataSet.sysCode.inGroupColumn.MaxLength; 
                myMasterSource = sysCodeSource;
                LockEditData(true);
                categoryCb.LoadData();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message.ToString());
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("classificationSystem");

            categoryLbl.Text = Languages.Libs.GetString("category");
            noteLbl.Text = Languages.Libs.GetString("note");
            visibleChk.Text = Languages.Libs.GetString("visible");
            systemChk.Text = Languages.Libs.GetString("system");


            codeLbl.Text = Languages.Libs.GetString("code");
            inGroupLbl.Text = Languages.Libs.GetString("group");
            desc1Lbl.Text = Languages.Libs.GetString("description") + " 1";
            desc2Lbl.Text = Languages.Libs.GetString("description") + " 2";
            weightLbl.Text = Languages.Libs.GetString("weight");
            tag1Lbl.Text = Languages.Libs.GetString("tag") + " 1";
            tag2Lbl.Text = Languages.Libs.GetString("tag") + " 2";
            editNoteLbl.Text = Languages.Libs.GetString("note");
            
            
            codeColumn.HeaderText = Languages.Libs.GetString("code");
            inGroupColumn.HeaderText = Languages.Libs.GetString("group");
            description1Column.HeaderText = Languages.Libs.GetString("description")+ " 1";
            description1Column.HeaderText = Languages.Libs.GetString("description") + " 2";
            weightColumn.HeaderText = Languages.Libs.GetString("weight");

            categoryCb.SetLanguage();
        }

        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            codeEd.Enabled = !this.isLockEdit;
            inGroupEd.Enabled = !this.isLockEdit;
            desc1Ed.Enabled = !this.isLockEdit;
            desc2Ed.Enabled = !this.isLockEdit;
            weightEd.Enabled = !this.isLockEdit;
            notesEd.Enabled = !this.isLockEdit;
            tag1Ed.Enabled = !this.isLockEdit;
            tag2Ed.Enabled = !this.isLockEdit;
            editIsVisibleChk.Enabled = !this.isLockEdit;
            editPnl.Enabled = !this.isLockEdit;
        }
        protected override void SetFirstFocus() { codeEd.Focus(); }
        protected override bool DataValid(bool showMsg)
        {
            ClearNotifyError();
            if (codeEd.Text.Trim() == "")
            {
                NotifyError(codeLbl);
                this.codeEd.Focus(); return false;
            }
            if (desc1Ed.Text.Trim() == "")
            {
                NotifyError(desc1Lbl);
                this.desc1Ed.Focus(); return false;
            }
            databases.baseDS.sysCodeCatRow row = categoryCb.GetRow(categoryCb.myValue);
            if (row != null & !row.IsmaxCodeLenNull() && row.maxCodeLen > 0 && codeEd.Text.Length > row.maxCodeLen)
            {
                if (showMsg) common.system.ShowErrorMessage(String.Format(Languages.Libs.GetString("dataTooLong"),row.maxCodeLen));
            }
            return true;
        }

        protected override void UpdateData(DataRow row)
        {
            if (row == null) return;
            DataAccess.Libs.UpdateData((databases.baseDS.sysCodeRow)row);
        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            databases.baseDS.sysCodeRow row = (databases.baseDS.sysCodeRow)((DataRowView)sysCodeSource.Current).Row;
            if (row == null) return;
            databases.AppLibs.InitData(row);
            row.code = code;
            row.category = this.categoryCb.SelectedValue.ToString();
        }
        protected override string GetKeyValue(DataRow dr)
        {
            return ((databases.baseDS.sysCodeRow)dr).code;
        }
        protected override void LoadData()
        {
            this.ShowMessage("");
            LoadSyscode();
        }
        protected override bool BeforeDelete()
        {
            if (myMasterSource.Current == null) return false;
            if (!base.BeforeDelete()) return false;
            databases.baseDS.sysCodeRow row = (databases.baseDS.sysCodeRow)(myMasterSource.Current as DataRowView).Row;
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
            databases.baseDS.sysCodeRow row = (databases.baseDS.sysCodeRow)(myMasterSource.Current as DataRowView).Row;
            if (row.HasVersion(DataRowVersion.Original))
                DataAccess.Libs.DeleteData(row);
            myMasterSource.RemoveCurrent();
            this.ShowMessage(Languages.Libs.GetString("dataWasDeleted"));
        }

        private void LoadSyscode()
        {
            codeEd.MaxLength = myDataSet.sysCode.codeColumn.MaxLength;
            if (this.categoryCb.SelectedValue != null)
            {
                string catCode = this.categoryCb.SelectedValue.ToString();
                sysCodeSource.DataSource = DataAccess.Libs.GetSysCode(catCode);
                if(maxLenEd.Value>0) codeEd.MaxLength = (int)maxLenEd.Value;
            }
            this.ShowReccount();
        }

        private void CategoryChanged()
        {
            this.ShowMessage("");
            myDataSet.RejectChanges();
            databases.baseDS.sysCodeCatRow row = categoryCb.GetRow(categoryCb.myValue);
            if (row != null)
            {
                systemChk.Checked = row.isSystem;
                visibleChk.Checked = row.isVisible;
                maxLenEd.Value = (row.IsmaxCodeLenNull() ?-1:row.maxCodeLen);
                notesEd.Text = (row.IsnotesNull() ? "" : row.notes.ToString());
            }
            LoadSyscode();
            
            if (this.systemChk.Checked) LockEdit(true);
            editBtn.Enabled = !this.systemChk.Checked;
        }

        private void syscodeGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowError(e.Exception);
        }

        private void sysCodeCatSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CategoryChanged();
            }
            catch(Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}