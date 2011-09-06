using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace baseClass.controls
{
    public partial class companyGeneralInfo : common.control.baseUserControl
    {
        private BindingSource myDataSource = null;
        public companyGeneralInfo()
        {
            InitializeComponent();
            SetMaxLength();
            codeEd.isToUpperCase = true;
        }
        private void SetMaxLength()
        {
            data.baseDS.stockCodeDataTable tbl = new data.baseDS.stockCodeDataTable();
            codeEd.MaxLength = tbl.codeColumn.MaxLength;
            nameEd.MaxLength = tbl.nameColumn.MaxLength;
            addressEd1.MaxLength = tbl.address1Column.MaxLength;
            addressEd2.MaxLength = tbl.address2Column.MaxLength;
            phoneEd.MaxLength = tbl.phoneColumn.MaxLength;
            faxEd.MaxLength = tbl.faxColumn.MaxLength;
            emailEd.MaxLength = tbl.emailColumn.MaxLength;
            websiteEd.MaxLength = tbl.websiteColumn.MaxLength;
        }

        public virtual void Init() 
        {
            countryCb.LoadData();
        }
        public void SetDataSource(System.Windows.Forms.BindingSource dataSrc)
        {
            this.myDataSource = dataSrc;
            data.baseDS.stockCodeDataTable tbl = (data.baseDS.stockCodeDataTable)this.myDataSource.DataSource;
            this.codeEd.DataBindings.Clear();
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.codeColumn.ColumnName, true));

            this.nameEd.DataBindings.Clear();
            this.nameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.nameColumn.ColumnName, true));

            this.enNameEd.DataBindings.Clear();
            this.enNameEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.nameEnColumn.ColumnName, true));

            this.addressEd1.DataBindings.Clear();
            this.addressEd1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.address1Column.ColumnName, true));

            this.addressEd2.DataBindings.Clear();
            this.addressEd2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.address2Column.ColumnName, true));

            this.phoneEd.DataBindings.Clear();
            this.phoneEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.phoneColumn.ColumnName, true));

            this.faxEd.DataBindings.Clear();
            this.faxEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.faxColumn.ColumnName, true));

            this.emailEd.DataBindings.Clear();
            this.emailEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.emailColumn.ColumnName, true));

            this.websiteEd.DataBindings.Clear();
            this.websiteEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.myDataSource, tbl.websiteColumn.ColumnName, true));
            
            this.countryCb.DataBindings.Clear();
            this.countryCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.myDataSource, tbl.countryColumn.ColumnName, true));

        }
        public virtual bool CheckData()
        {
            bool retVal = true;
            ClearNotifyError();
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
            if (addressEd1.Text.Trim() == "") 
            {
                NotifyError(addressLbl1);
                retVal = false;
            }
            return retVal;
        }
        public virtual void LockEdit(bool state)
        {
            codeEd.ReadOnly = state;
            nameEd.ReadOnly = state;
            enNameEd.ReadOnly = state;
            addressEd1.ReadOnly = state;
            addressEd2.ReadOnly = state;
            phoneEd.ReadOnly = state;
            faxEd.ReadOnly = state;
            emailEd.ReadOnly = state;
            websiteEd.ReadOnly = state;
            countryCb.Enabled = !state;
        }
        public virtual void SetFocus()
        {
            this.Focus();
            codeEd.Focus();
        }
    }
}
