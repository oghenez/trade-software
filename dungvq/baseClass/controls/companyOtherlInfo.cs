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
    public partial class companyOtherInfo : common.control.baseUserControl
    {
        public companyOtherInfo()
        {
            InitializeComponent();
            SetMaxLength();
        }
        private void SetMaxLength()
        {
            data.baseDS.companyDataTable tbl = new data.baseDS.companyDataTable();
            bizSectorClb.maxLen = tbl.bizSectorsColumn.MaxLength;
        }

        public virtual void Init() 
        {
            capitalUnitCb.LoadData();
            bizSectorClb.LoadData();
            employeeRangeCb.LoadData();
        }
        public virtual void SetData(data.baseDS.companyRow row)
        {
            estDateEd.myDateTime = row.estDate;
            capitalAmtEd.Value = row.capital;
            capitalUnitCb.myValue = row.capitalUnit;
            employeeRangeCb.myValue = row.employees;

            bool saveShowCheckedOnly = bizSectorClb.ShowCheckedOnly;
            bizSectorClb.ShowCheckedOnly = false; 
            bizSectorClb.myItemString = row.bizSectors;
            bizSectorClb.ShowCheckedOnly = saveShowCheckedOnly; 
        }
        public virtual void GetData(data.baseDS.companyRow row)
        {
            row.estDate = estDateEd.myDateTime;
            row.capital = capitalAmtEd.Value;
            row.capitalUnit = capitalUnitCb.myValue;
            row.employees = employeeRangeCb.myValue;
            row.bizSectors = bizSectorClb.myItemString;
        }
        public virtual bool CheckData()
        {
            bool retVal = true;
            ClearNotifyError();
            if (estDateEd.myDateTime==common.Consts.constNullDate)
            {
                NotifyError(estDateLbl);
                retVal = false;
            }
            if (capitalUnitCb.myValue == "")
            {
                NotifyError(capitalAmtLbl);
                retVal = false;
            }
            return retVal;
        }
        public virtual void LockEdit(bool state)
        {
            estDateEd.ReadOnly = state;
            capitalAmtEd.ReadOnly = state;
            capitalUnitCb.Enabled = !state;
            employeeRangeCb.Enabled = !state;
            bizSectorClb.Enabled = !state;
        }
        public virtual void SetFocus()
        {
            this.Focus();
            estDateEd.Focus();
        }
    }
}
