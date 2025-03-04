using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;
using common.controls;

namespace baseClass
{
    
    public partial class baseMasterDetailEntry : common.forms.baseMasterDetailForm 
    {
        public baseMasterDetailEntry()
        {
            try
            {
                InitializeComponent();
                editKeyEd.isToUpperCase = true;
                this.FormBorderStyle = (commonClass.Settings.sysDebugMode ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle);
                this.AutoEditKeyMode = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #region override functions
        public override int GetFormPermission()
        {
            return application.commonLibs.GetFormPermission(this.myFormCode);
        }
        protected override string GetNewDataKey(string tblName)
        {
            string key = DataAccess.Libs.GetAutoDataKey(tblName);
            if (key != null) return key;
            this.Close();
            return null;
        }
        protected override common.myAutoKeyInfo GetNewAutoEditKey(string key) 
        {
            return DataAccess.Libs.GetAutoKey(key, true);
        }
        protected override void CloseAutoEditKey(common.myAutoKeyInfo autoKeyInfo)
        {
            DataAccess.Libs.DeleteKeyPending(autoKeyInfo);
        }

        protected override bool RequireTransactionScope() { return commonClass.system.sysUseTransactionInUpdate; }
        
        #endregion override functions
    }
}