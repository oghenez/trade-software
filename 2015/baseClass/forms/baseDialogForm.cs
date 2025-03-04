using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using commonTypes;

namespace baseClass.forms
{
    public partial class baseDialogForm : common.forms.baseDialogForm  
    {
        public baseDialogForm()
        {
            InitializeComponent();
        }
        protected override void ShowError(Exception er)
        {
            switch(Settings.sysWriteLogException)
            {
                case AppTypes.SyslogMedia.Database: 
                     DataAccess.Libs.WriteLog(commonClass.SysLibs.sysLoginCode,er);
                     break;
                case AppTypes.SyslogMedia.File:
                     commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error,"base001", er);
                     break;
            }
        }

        private void baseDialogForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Font = Settings.sysFontMain;
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
    }    
}