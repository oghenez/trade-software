using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using application;

namespace application
{
    public class wsAccess
    {
        static wsAccess()
        {
            //Testing 
            common.settings.sysWebServiceURI = "http://localhost/dataLibs.svc";
        }

        private static dataService.StockServiceClient _myClient = null;
        public static dataService.StockServiceClient myClient
        {
            get
            {
                if (_myClient == null)
                {
                    _myClient = new dataService.StockServiceClient();
                    _myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress(common.settings.sysWebServiceURI);
                    _myClient.Open();
                }
                return _myClient;
            }
        }
        public void Close()
        {
            if (_myClient!=null)_myClient.Close();
            _myClient = null;
        }


        public static data.tmpDS.tradeEstimateDataTable test()
        {
            application.wsAccess.myClient.ClearCache();
            string dataKey = application.wsAccess.myClient.GetData(application.dataService.AppTypesTimeRanges.Y2, "D1", "ACB", true);
            application.dataService.wsDataTradePointInfo[] tradePoints = application.wsAccess.myClient.Analysis(dataKey, "STR007");
            //dataGridView1.DataSource = 
            application.dataService.wsDataEstimateOptions option = new application.dataService.wsDataEstimateOptions();
            return application.wsAccess.myClient.EstimateTrading(dataKey, tradePoints, option);
        }
    }
}
