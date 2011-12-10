using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        application.AnalysisData myData = new application.AnalysisData();
        public Form2()
        {
            InitializeComponent();
            data.SysLibs.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
            myData.DataStockCode = "SSI";
            myData.DataTimeRange = commonClass.AppTypes.TimeRanges.All;
        }

        private void Reload()
        {
        }

        private void reload_Click(object sender, EventArgs e)
        {
            //using (new PleaseWait(this.Location, new common.forms.baseSlashForm()))
            using (new common.PleaseWait(this.Location))
            {
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
