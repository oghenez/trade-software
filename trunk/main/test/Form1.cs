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

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            application.test.LoadTestConfig();
            InitializeComponent();
            stockCodeSelectLb.LoadData();
            dateRangeEd.LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            application.Data stockData = new Data(dateRangeEd.myTimeRange, dateRangeEd.myTimeScale, "SSI");
            MarketData data = new MarketData(stockData);
            //Get market indicator series
            DataSeries ds = data.AdvancingIssues;
            ds = data.AdvancingVolume;
            ds = data.AdvancingDateTime;

            ds = data.DecliningIssues;
            ds = data.DecliningVolume;

            ds = data.NonChangeIssues;
            ds = data.NonChangeVolume;  
        }
    }
}
