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
            this.Text = language.GetString("category");

            codeLbl.Text = language.GetString("code");
            descriptionLbl.Text = language.GetString("name");
            maxLenLbl.Text = language.GetString("maxSize");
            weightLbl.Text = language.GetString("weight");
            tagLbl1.Text = language.GetString("tag")+ " 1";
            tagLbl2.Text = language.GetString("tag") + " 2";
            noteLbl.Text = language.GetString("note");
            isVisibleChk.Text = language.GetString("visible");
            isSystemChk.Text = language.GetString("system");

            codeColumn.HeaderText = language.GetString("code");
            descriptionColumn.HeaderText = language.GetString("description");
            weightColumn.HeaderText = language.GetString("weight");
        }
        protected override void SetFirstFocus()
        {
            this.codeEd.Focus();
        }

        protected override void LoadData()
        {
            this.myDataSet.sysCodeCat.Clear();
            application.dataLibs.LoadData(this.myDataSet.sysCodeCat);
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
            this.AddNewRow();
            codeEd.Text = code;
            this.isSystemChk.Checked = false;
            this.isVisibleChk.Checked = true;
        }

        protected override void UpdateData(DataRow row )
        {
            if (row == null)
            {
                application.dataLibs.UpdateData(myDataSet.sysCodeCat);
                return;
            }
            row[myDataSet.sysCodeCat.isSystemColumn.ColumnName] = (isSystemChk.Checked ? bool.TrueString : bool.FalseString);
            row[myDataSet.sysCodeCat.isVisibleColumn.ColumnName] = (isVisibleChk.Checked ? bool.TrueString : bool.FalseString);
            application.dataLibs.UpdateData((data.baseDS.sysCodeCatRow)row);
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