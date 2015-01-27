using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace client.forms
{
    /// <summary>
    /// Start Splash Window
    /// </summary>
    public partial class startSplash : common.forms.baseSlashForm
    {
        public startSplash()
        {
            InitializeComponent();
            //Tuan - Make the background in transparent border.
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            //Tuan - Make the background in transparent border.
            if (commonTypes.Consts.constEditionPROFESSIONALL)
                this.BackgroundImage = global::client.Properties.Resources.trader_professional;
            else
                this.BackgroundImage = global::client.Properties.Resources.trader_standard;
        }
    }
}
