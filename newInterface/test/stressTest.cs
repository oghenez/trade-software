using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class stressTest : common.forms.baseForm 
    {
        const int constStressTestNo = 100;
        StringCollection stockList = new StringCollection();

        int testCount = 0;

        public stressTest()
        {
            InitializeComponent();
            initTest_Webservice();
        }
        BackgroundWorker[] bgWorkerObjs = new BackgroundWorker[constStressTestNo];

        private void initTest_Webservice()
        {
            try
            {
                databases.baseDS.lastPriceDataDataTable tbl = DataAccess.Libs.myLastDailyClosePrice;
                stockList.Clear();
                for (int idx = 0; idx < tbl.Count; idx++)
                {
                    stockList.Add(tbl[idx].stockCode);
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "test", er);
            }
        }

        
        private void webserviceInit()
        {
            for (int idx = 0; idx < constStressTestNo; idx++)
            {
                bgWorkerObjs[idx] = new BackgroundWorker();
                bgWorkerObjs[idx].RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_webservice_RunWorkerCompleted);
            }
        }
        private void webserviceTest()
        {
            for (int idx = 0; idx < bgWorkerObjs.Length; idx++)
            {
                if (bgWorkerObjs[idx]==null) continue;
                if (bgWorkerObjs[idx].IsBusy) 
                    continue;
                bgWorkerObjs[idx].RunWorkerAsync();
            }
        }
        private void webserviceEnd()
        {
            for (int idx = 0; idx < bgWorkerObjs.Length; idx++)
            {
                if (bgWorkerObjs[idx]==null) continue;
                bgWorkerObjs[idx].Dispose();
                bgWorkerObjs[idx]=null;
            }
        }

        private void bgWorker_webservice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                wsTestCountLbl.Text = (++testCount).ToString();
                databases.baseDS.lastPriceDataDataTable tbl1 = DataAccess.Libs.myLastDailyClosePrice;
                int idx = common.system.Random(0, stockList.Count - 1);
                databases.baseDS.priceDataDataTable tbl2 = DataAccess.Libs.GetData_ByTimeScale_Code_FrDate("D1", stockList[idx], DateTime.Today.AddDays(-1));
                //Application.DoEvents();
            }
            catch (Exception er)
            {
                this.ShowError(er);
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "test", er);
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            this.ShowMessage("");
            testCount = 0;

            startBtn.Enabled = false;
            stopBtn.Enabled = true;
            if (webServiceChk.Checked) webserviceInit();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (webServiceChk.Checked) webserviceTest();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            webserviceEnd();
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
        }
    }
}
