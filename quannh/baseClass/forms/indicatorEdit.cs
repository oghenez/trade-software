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
    public partial class indicatorEdit : baseMasterEdit   
    {
        public indicatorEdit()
        {
            try
            {
                InitializeComponent();
                codeEd.isToUpperCase = true;
                myMasterSource = indicatorSource;
                listGrid.DisableReadOnlyColumn = false;

                codeEd.MaxLength = myDataSet.indicator.codeColumn.MaxLength;
                descriptionEd.MaxLength = myDataSet.indicator.descriptionColumn.MaxLength;
                parameterEd.MaxLength = myDataSet.indicator.parameterColumn.MaxLength;

                LockEdit(true);
                categoryCb.LoadData();
            }
            catch (Exception er)
            {
                ShowError(er);
            }

        }
        protected override void SetFirstFocus()
        {
            this.codeEd.Focus();
        }

        protected override void LoadData()
        {
            this.myDataSet.indicator.Clear();
            application.dataLibs.LoadData(this.myDataSet.indicator,false);
            CurrentDataChanged();
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.codeEd.Enabled = !lockState;
            this.descriptionEd.Enabled = !lockState;
            this.categoryCb.Enabled = !lockState;
            this.noteEd.Enabled = !lockState;
            this.weightEd.Enabled = !lockState;
            this.parameterEd.Enabled = !lockState;
            this.enableChk.Enabled = !lockState;
        }

        protected override bool DataValid(bool showMsg)
        {
            ClearNotifyError();
            bool retVal = base.DataValid(showMsg);
            if (codeEd.Text.Trim() == "") 
            {
                NotifyError(codeLbl);
                retVal = false; 
            }
            if (descriptionEd.Text.Trim() == "")
            {
                NotifyError(descriptionLbl);
                retVal = false;
            }
            if (categoryCb.myValue.Trim() == "")
            {
                NotifyError(categoryLbl);
                retVal = false;
            }
            return retVal;
        }

        public override void AddNew(string code)
        {
            string saveCat = categoryCb.myValue;
            this.AddNewRow();
            data.baseDS.indicatorRow row = (data.baseDS.indicatorRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);
            row.code = code;
            row.catCode = saveCat;
            categoryCb.myValue = saveCat;
        }

        protected override void UpdateData(DataRow row )
        {
            if (row == null)
            {
                application.dataLibs.UpdateData(myDataSet.indicator);
                return;
            }
            data.baseDS.indicatorRow indicatorRow = (data.baseDS.indicatorRow)row;
            application.dataLibs.UpdateData(indicatorRow);
        }

        private void listGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message.ToString());  
            return;
        }

        private void codeEd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = this.CheckDuplicateKey(codeEd.Text.Trim(),myDataSet.indicator.codeColumn.ColumnName);
        }
        protected virtual void CurrentDataChanged()
        {
            if (myMasterSource.Current == null) return;
            data.baseDS.indicatorRow indicatorRow = (data.baseDS.indicatorRow)((DataRowView)myMasterSource.Current).Row;
        }
        private void indicatorSource_CurrentChanged(object sender, EventArgs e)
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