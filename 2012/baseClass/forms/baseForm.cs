using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonTypes;

namespace baseClass.forms
{
    public partial class baseForm : common.forms.baseForm
    {
        public baseForm()
        {
            InitializeComponent();
        }
        private bool _logAccess = true;
        public bool LogAccess
        {
            get { return _logAccess; }
            set { _logAccess=value; }
        }
        public override int GetFormPermission()
        {
            return application.CommonLibs.GetFormPermission(this.myFormCode);
        }

        protected override void ShowError(Exception er)
        {
            switch (Settings.sysWriteLogException)
            {
                case AppTypes.SyslogMedia.Database:
                    DataAccess.Libs.WriteLog(commonClass.SysLibs.sysLoginCode, er);
                    break;
                case AppTypes.SyslogMedia.File:
                    commonClass.SysLibs.WriteSysLog(commonClass.SysLibs.sysLoginCode,er);
                    break;
            }
        }
        

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.Font = Settings.sysFontMain;

                if (!LogAccess) return;
                switch (Settings.sysGlobal.WriteLogAccess)
                {
                    case AppTypes.SyslogMedia.Database:
                        DataAccess.Libs.WriteLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Opened : " + this.Name, null, null);
                        break;
                    case AppTypes.SyslogMedia.File:
                        commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Opened : " + this.Name);
                        break;
                }
            }
            catch(Exception er)
            {
                ShowError(er);
            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!LogAccess) return;
                switch (Settings.sysGlobal.WriteLogAccess)
                {
                    case AppTypes.SyslogMedia.Database:
                        DataAccess.Libs.WriteLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Closed : " + this.Name, null, null);
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
