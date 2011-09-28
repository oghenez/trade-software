using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1.Item
{
    public partial class IndicatorItem : UserControl
    {
        string _caption;
        string _mytooltip;
        ToolTip toolTip = new ToolTip();

        public string Mytooltip
        {
            get { return _mytooltip; }
            set { toolTip.SetToolTip(lbIndicator,value); }
        }

        public string Caption
        {
            get { return lbIndicator.Text; }
            set { lbIndicator.Text = value; }
        }
        public IndicatorItem()
        {
            InitializeComponent();            
        }

        private void lbIndicator_Resize(object sender, EventArgs e)
        {
            this.Width = 30 + lbIndicator.Width;
        }
    }
}
