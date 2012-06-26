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
        /// <summary>
        /// COntructor Investor Edit
        /// </summary>
        public investorEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Lock Edit base on lock state
        /// </summary>
        /// <param name="lockState">Lock state</param>
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            accountEd.Enabled = false;
        }
        protected override void SetFirstFocus() { passwordEd.Focus(); }
        /// <summary>
        /// Add new 
        /// </summary>
        /// <param name="code"></param>
        public override void AddNew(string code)
        {
            return;
        }
        /// <summary>
        /// Load data of investor
        /// </summary>
        protected override void LoadData()
        {
            myMasterSource.DataSource = DataAccess.Libs.GetInvestor_ByCode(commonClass.SysLibs.sysLoginCode);
            base.LoadData();

        }
    }
}
