using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class strategyEdit : baseMasterEdit   
    {
        public strategyEdit()
        {
            try
            {
                InitializeComponent();
                codeEd.isToUpperCase = true;
                myMasterSource = strategySource;

                StrategyTypesCb.LoadData();
                categoryCb.LoadData();

                listGrid.DisableReadOnlyColumn = false;

                codeEd.MaxLength = myDataSet.strategy.codeColumn.MaxLength;
                descriptionEd.MaxLength = myDataSet.strategy.descriptionColumn.MaxLength;

                LockEdit(true);
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
            this.myDataSet.strategy.Clear();
            application.dataLibs.LoadData(this.myDataSet.strategy,false);
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.StrategyTypesCb.Enabled = !lockState;
            this.codeEd.Enabled = !lockState;
            this.descriptionEd.Enabled = !lockState;
            this.categoryCb.Enabled = !lockState;
            this.weightEd.Enabled = !lockState;
            this.indicatorSpecsEd.Enabled = !lockState;
            this.noteEd.Enabled = !lockState;
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
            if (indicatorSpecsEd.Text.Trim() == "")
            {
                NotifyError(indicatorSpecsLbl);
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
            data.baseDS.strategyRow row = (data.baseDS.strategyRow)((DataRowView)myMasterSource.Current).Row;
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
                application.dataLibs.UpdateData(myDataSet.strategy);
                return;
            }
            application.dataLibs.UpdateData((data.baseDS.strategyRow)row);
        }

        private void listGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message.ToString());  
            return;
        }

        private void codeEd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = this.CheckDuplicateKey(codeEd.Text.Trim(),myDataSet.strategy.codeColumn.ColumnName);
        }
    }    
}