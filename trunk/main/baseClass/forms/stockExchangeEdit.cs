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
    public partial class stockExchangeEdit : baseMasterEdit   
    {
        public stockExchangeEdit()
        {
            try
            {
                InitializeComponent();
                codeEd.isToUpperCase = true;
                codeEd.MaxLength = myDataSet.stockExchange.codeColumn.MaxLength;
                nameEd.MaxLength = myDataSet.stockExchange.descriptionColumn.MaxLength;

                myMasterSource = stockExchangeSource;
                countryCb.LoadData();
                listGrid.DisableReadOnlyColumn = false;
                LockEdit(true);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("stockExchange");

            codeLbl.Text = language.GetString("code");
            nameLbl.Text = language.GetString("name");
            countryLbl.Text = language.GetString("country");
            weightLbl.Text = language.GetString("weight");

            codeColumn.HeaderText = language.GetString("code");
            nameColumn.HeaderText = language.GetString("name");
        }

        protected override void SetFirstFocus()
        {
            this.codeEd.Focus();
        }

        protected override void LoadData()
        {
            this.myDataSet.stockExchange.Clear();
            application.dataLibs.LoadData(this.myDataSet.stockExchange);
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.codeEd.Enabled = !lockState;
            this.nameEd.Enabled = !lockState;
            this.countryCb.Enabled = !lockState;
            this.weightEd.Enabled = !lockState;
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
            if (nameEd.Text.Trim() == "")
            {
                NotifyError(nameLbl);
                retVal = false;
            }
            if (countryCb.myValue.Trim() == "")
            {
                NotifyError(countryLbl);
                retVal = false;
            }
            return retVal;
        }

        public override void AddNew(string code)
        {
            this.AddNewRow();
            data.baseDS.stockExchangeRow row = (data.baseDS.stockExchangeRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);
            row.code = code;
        }

        protected override void UpdateData(DataRow row )
        {
            if (row == null)
            {
                application.dataLibs.UpdateData(myDataSet.stockExchange);
                return;
            }
            application.dataLibs.UpdateData((data.baseDS.stockExchangeRow)row);
        }

        private void listGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message.ToString());  
            return;
        }

        private void codeEd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = this.CheckDuplicateKey(codeEd.Text.Trim(),myDataSet.stockExchange.codeColumn.ColumnName);
        }
    }    
}