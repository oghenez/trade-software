using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using application;
using Indicators;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            application.test.LoadTestConfig();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            application.Data data = new application.Data();
            data.DataStockCode = "SSI";
            data.DataTimeRange = AppTypes.TimeRanges.M2;
            data.DataTimeScale = application.AppTypes.TimeScaleFromCode("D1");
            data.Reload();

            application.Data vnIndexData = data.New("^VNINDEX");
            data.Sync(vnIndexData);
        }
    }
}
