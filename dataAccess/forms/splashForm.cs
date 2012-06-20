using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataAccess.forms
{
    public partial class splashForm : common.forms.baseSlashForm
    {
        public splashForm()
        {
            InitializeComponent();
        }
        protected override string waitingText
        {
            get { return Languages.Libs.GetString("waitDataLoading"); }
        }
    }
}
