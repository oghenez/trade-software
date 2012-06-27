using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client.forms
{
    public partial class startSplash : common.forms.baseSlashForm
    {
        public startSplash()
        {
            InitializeComponent();
            if (commonTypes.Consts.constEditionPROFESSIONALL)
                this.BackgroundImage = global::client.Properties.Resources.trader_professional;
            else
                this.BackgroundImage = global::client.Properties.Resources.trader_standard;
        }
    }
}
