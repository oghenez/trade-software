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
        //protected override void WriteLog(params string[] msg)
        //{
        //    switch (Settings.sysWriteLogException)
        //    {
        //        case AppTypes.SyslogMedia.Database:
        //            byte type = 0; if (!byte.TryParse(msg[0], out type)) return;
        //            AppTypes.SyslogTypes logType = (AppTypes.SyslogTypes)type;
        //            DataAccess.Libs.WriteSyslog(logType,(msg.Length>1?msg[1]:null), (msg.Length>2?msg[2]:null),
        //                            (msg.Length>3?msg[3]:null), (msg.Length>4?msg[4]:null));
        //            break;
        //        case AppTypes.SyslogMedia.File:
        //            commonClass.SysLibs.WriteSysLog(common.stringLibs.MakeString(common.Consts.constTab.ToString(),msg));
        //            break;
        //    }
        //}

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
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
