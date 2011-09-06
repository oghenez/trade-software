using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client.forms
{
    public partial class companyList : baseClass.forms.companyList
    {
        public companyList()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void LockEdit(bool lockState)
        {
            lockState = true;
            base.LockEdit(lockState);
            editBtn.Enabled = false;
            deleteBtn.Enabled = false;
            saveBtn.Enabled = false;
        }
        protected override void UpdateData(DataRow row) { return; }
        public override void AddNew(string code) { return; }
    }
}
