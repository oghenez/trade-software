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

        public void WriteError(string code,string msg)
        {
            if (!commonClass.Settings.sysLogError) return;
            common.fileFuncs.WriteLog(this.Name + common.Consts.constTab + code + common.Consts.constTab + msg);
        }
    }
}
