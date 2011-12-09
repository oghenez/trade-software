using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client.forms
{
    public partial class investorEdit : baseClass.forms.investorEdit
    {
        public investorEdit()
        {
            InitializeComponent();
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            accountEd.Enabled = false;
        }
        protected override void SetFirstFocus() { passwordEd.Focus(); }
        public override void AddNew(string code)
        {
            return;
        }
        protected override void LoadData()
        {
            myDataSet.investor.Clear();
            application.dataLibs.LoadData(myDataSet.investor, application.sysLibs.sysLoginCode);
            base.LoadData();

        }
    }
}
