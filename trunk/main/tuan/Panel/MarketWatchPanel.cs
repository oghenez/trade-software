using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using test;

namespace test1.Panel
{
    public partial class MarketWatchPanel : UserControl
    {
        public MainForm _mFormParent = null;
        public MarketWatchPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mFormParent.leftPanel.Controls.Remove(this);
        }
    }
}
