using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using ZedGraph;
using commonTypes;
using commonClass;
using application;

namespace test
{
    public partial class genData : baseClass.forms.baseForm
    {
        bool fGenData = false;
        application.AnalysisData myData = null;
        public genData()
        {
            try
            {
                InitializeComponent();
                timer1.Interval = 5000;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        bool fProcessing = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;
                if (fGenData)
                {
                    Libs.GenPriceData(myData.DataStockCode);
                }
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }

        private void genDataBtn_Click(object sender, EventArgs e)
        {
            fGenData = !fGenData;
            timer1.Enabled = fGenData;
            timer1.Interval = (int)intervalEd.Value * 1000;
            
            if (myData==null) myData= new AnalysisData();
            myData.DataStockCode = codeEd.Text;

            genDataBtn.Text  = (fGenData ? "Stop" : "Start");
            this.ShowMessage(fGenData? "Running" : "Stopped");
            if (fGenData) Libs.Reset();

            codeEd.Enabled = !fGenData;
            intervalEd.Enabled = !fGenData;
        }
    }
}
