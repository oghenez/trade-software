using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using application;

namespace wsTest
{
    public partial class test : common.forms.baseForm
    {
        public test()
        {
            InitializeComponent();
            application.test.LoadTestConfig();
            //Strategy.Settings.sysDirectory = "D:\\work\\stockProject\\code\\dlls";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                DateTime startTime = DateTime.Now;
                this.ShowMessage("Testing...");

                //DoTest2();
                StressTest(1);

                //DateTime endTime = DateTime.Now;
                //this.ShowMessage(common.dateTimeLibs.DateDiffInMilliseconds(startTime, endTime) + "ms");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        private void DoTest2()
        {
            //application.wsData.EstimateOptions estOption = new application.wsData.EstimateOptions();

            //data.tmpDS.tradeEstimateDataTable tbl = new data.tmpDS.tradeEstimateDataTable();
            //application.AppTypes.TimeScale timeScale = application.AppTypes.MainDataTimeScale; 

            //application.Data myData;

            //myData = new application.Data(application.AppTypes.TimeRanges.Y2, timeScale, "ACB"); 
            //Strategy.Data.TradePoints tradePoint1 = Strategy.Libs.Analysis(myData,"STR007");

            //tbl.Clear();
            //Strategy.Libs.EstimateTrading(myData, tradePoint1, estOption, tbl);
            //dataGridView1.DataSource = tbl;

            //myData = new application.Data(application.AppTypes.TimeRanges.Y1, timeScale, "AAA"); 
            //Strategy.Data.TradePoints tradePoint2 = Strategy.Libs.Analysis(myData,"STR007");
            //tbl.Clear();
            //Strategy.Libs.EstimateTrading(myData, tradePoint2, estOption, tbl);
            //dataGridView1.DataSource = tbl;
        }


        private static ServiceReference1.StockServiceClient  _myClient = null;
        public static ServiceReference1.StockServiceClient myClient
        {
            get
            {
                if (_myClient == null)
                {
                    ReOpen();
                }
                if (_myClient.State== System.ServiceModel.CommunicationState.Faulted)
                {
                    ReOpen();
                }
                return _myClient;
            }
        }

        private static void ReOpen()
        {
            if (_myClient != null) _myClient.Abort();
            _myClient = new ServiceReference1.StockServiceClient();
            _myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://localhost:8731/wsServices/DataLibs");

            //_myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://hoidap_online/dataLibs.svc");
            //_myClient.ClientCredentials.Windows.ClientCredential.UserName = "test";
            //_myClient.ClientCredentials.Windows.ClientCredential.Password = "123";
             _myClient.Open();
        }
        private void DoTest()
        {
            ServiceReference1.StockServiceClient testClient = new wsTest.ServiceReference1.StockServiceClient();
            application.AppTypes.TimeRanges timeRange = application.AppTypes.TimeRanges.Y2;
            application.wsData.EstimateOptions estOption = new application.wsData.EstimateOptions();
            string[] stock = new string[] { "ACB", "SSI","FPT"};
            string[] strategy = new string[] { "STR007", "STR026" };

            decimal[][] list = testClient.Estimate_Matrix_Profit(timeRange,"D1", stock, strategy,new wsData.EstimateOptions());
            testClient.Close();
        }


        private void StressTest(int stressCount)
        {
            for (int idx = 0; idx < stressCount; idx++)
            {
                DoTest();
            }
        }
    }
}
