using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Transactions;
namespace baseClass.forms
{
    public partial class baseMasterEdit : common.forms.baseMasterEditForm 
    {
        public baseMasterEdit()
        {
            InitializeComponent();
            this.FormBorderStyle = (commonClass.Settings.sysDebugMode ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle); 
        }
        #region Abtrstract functions
        public override int GetFormPermission()
        {
            return common.Consts.constPermissionADD + common.Consts.constPermissionEDIT + common.Consts.constPermissionDEL;
        }
        protected override void CancelAllChanges() 
        { 
            myDataSet.RejectChanges();
        }
        protected override bool DataChanged() 
        {
            myMasterSource.EndEdit();
            return myDataSet.HasChanges();
        }
        #endregion Abtrstract functions
    }
}