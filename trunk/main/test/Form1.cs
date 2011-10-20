using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data.system.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
            application.Data data1 = new application.Data();
            data1.DataStockCode = "SSI";
            data1.DataTimeRange = application.AppTypes.TimeRanges.All;
            data1.Reload();

            zedGraphControl1.MasterPane[0].AddCurve("aa", data1.DateTime.Values, data1.Close.Values, Color.Red);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
