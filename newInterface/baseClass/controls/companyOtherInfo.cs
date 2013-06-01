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
    public partial class companyOtherInfo : common.controls.baseUserControl
    {
        private BindingSource myDataSource = null;
        public companyOtherInfo()
        {
            InitializeComponent();
            SetMaxLength();
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            bizSectorLb.SetLanguage();
            bizSectorLbl.Text = Languages.Libs.GetString("bizSector");
        }
        private void SetMaxLength()
        {
            databases.baseDS.stockCodeDataTable tbl = new databases.baseDS.stockCodeDataTable();
            bizSectorLb.maxLen = tbl.bizSectorsColumn.MaxLength;
        }

        public virtual void Init() 
        {
            bizSectorLb.LoadData();
        }
        public void SetDataSource(System.Windows.Forms.BindingSource dataSrc)
        {
            this.myDataSource = dataSrc;
            databases.baseDS.stockCodeDataTable tbl = (databases.baseDS.stockCodeDataTable)this.myDataSource.DataSource;
            this.bizSectorLb.DataBindings.Clear();
            this.bizSectorLb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", this.myDataSource, tbl.bizSectorsColumn.ColumnName, true));
        }
        public virtual bool CheckData()
        {
            bool retVal = true;
            ClearNotifyError();
            return retVal;
        }
        public virtual void LockEdit(bool state)
        {
            bizSectorLb.Enabled = !state;
        }
        public virtual void SetFocus()
        {
            this.Focus();
            bizSectorLb.Focus();
        }
    }
}
