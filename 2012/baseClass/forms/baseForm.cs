using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class baseForm : common.forms.baseForm
    {
        public baseForm()
        {
            InitializeComponent();
        }
        public override int GetFormPermission()
        {
            return application.CommonLibs.GetFormPermission(this.myFormCode);
        }

        protected override void ShowError(Exception er)
        {
            application.AppLibs.WriteSyslog(commonClass.Settings.sysWriteLogException, commonClass.Settings.sysAccessMode, er);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                application.AppLibs.WriteSyslog(commonClass.Settings.sysWriteLogAccess, commonClass.Settings.sysAccessMode,
                                                commonClass.AppTypes.SyslogTypes.Access,commonClass.SysLibs.sysLoginCode, this.Name + " opened.", null, null);
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
                application.AppLibs.WriteSyslog(commonClass.Settings.sysWriteLogAccess, commonClass.Settings.sysAccessMode,
                                commonClass.AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, this.Name + " closed.", null, null);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
    }
}
