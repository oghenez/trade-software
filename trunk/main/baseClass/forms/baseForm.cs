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
            return application.commonLibs.GetFormPermission(this.myFormCode);
        }

        public void WriteError(string code,string msg)
        {
            if (!application.Settings.sysLogError) return;
            common.fileFuncs.WriteLog(DateTime.Now.ToString() + " : " + this.Name + " : " + code + " : " + msg);
        }
    }
}
