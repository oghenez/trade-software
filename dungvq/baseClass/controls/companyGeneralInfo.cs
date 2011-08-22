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
        public companyGeneralInfo()
        {
            InitializeComponent();
            SetMaxLength();
            codeEd.isToUpperCase = true;
        }
        private void SetMaxLength()
        {
            data.baseDS.companyDataTable tbl = new data.baseDS.companyDataTable();
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
        public virtual void SetData(data.baseDS.companyRow row)
        {
            codeEd.Text = row.code;
            nameEd.Text = row.name;
            enNameEd.Text = (row.IsnameEnNull() ? "" : row.nameEn);
            addressEd1.Text = row.address1;
            addressEd2.Text = (row.Isaddress2Null()?"":row.address2);
            phoneEd.Text = (row.IsphoneNull() ? "" : row.phone);
            faxEd.Text = (row.IsfaxNull() ? "" : row.fax);
            websiteEd.Text = (row.IswebsiteNull() ? "" : row.website);
            emailEd.Text = row.email;
            countryCb.myValue = row.country;
        }
        public virtual void GetData(data.baseDS.companyRow row)
        {
            row.code = codeEd.Text;
            row.name = nameEd.Text;
            if (enNameEd.Text.Trim() == "") row.SetnameEnNull(); else row.nameEn = enNameEd.Text.Trim();
            row.address1 = addressEd1.Text.Trim();
            if (addressEd2.Text.Trim() == "") row.Setaddress2Null(); else row.address2 = addressEd2.Text.Trim();
            if (phoneEd.Text.Trim() == "") row.SetphoneNull(); else row.phone = phoneEd.Text.Trim();
            if (faxEd.Text.Trim() == "") row.SetfaxNull(); else row.fax = faxEd.Text.Trim();
            if (websiteEd.Text.Trim() == "") row.SetwebsiteNull(); else row.website = websiteEd.Text.Trim();
            row.email = emailEd.Text.Trim();
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
            if (emailEd.Text.Trim() == "")
            {
                NotifyError(emailLbl);
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
