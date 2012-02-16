using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Transactions;
using commonTypes;

namespace baseClass.forms
{
    public partial class baseMasterEdit : common.forms.baseMasterEditForm 
    {
        public baseMasterEdit()
        {
            InitializeComponent();
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

        protected override void ShowError(Exception er)
        {
            switch (Settings.sysWriteLogException)
            {
                case AppTypes.SyslogMedia.Database:
                    DataAccess.Libs.WriteSyslog(er, commonClass.SysLibs.sysLoginCode);
                    break;
                case AppTypes.SyslogMedia.File:
                    commonClass.SysLibs.WriteSysLog(er, commonClass.SysLibs.sysLoginCode);
                    break;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                switch (Settings.sysWriteLogException)
                {
                    case AppTypes.SyslogMedia.Database:
                        common.stringLibs.MakeString(common.Consts.constTab.ToString(), new string[] {commonClass.SysLibs.sysLoginCode, "Opened : " + this.Name });
                        DataAccess.Libs.WriteSyslog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Opened : " + this.Name,null,null);
                        break;
                    case AppTypes.SyslogMedia.File:
                        commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Opened : " + this.Name);
                        break;
                }
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                switch (Settings.sysWriteLogException)
                {
                    case AppTypes.SyslogMedia.Database:
                        DataAccess.Libs.WriteSyslog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Closed : " + this.Name, null, null);
                        break;
                    case AppTypes.SyslogMedia.File:
                        commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Closed : " + this.Name);
                        break;
                }
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
    }
}