using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using application;

namespace wsAccess
{
    public class libs
    {
        static libs()
        {
            //Testing 
            //common.settings.sysWebServiceURI = "http://localhost/dataLibs.svc";
        }
        private static dataService.StockServiceClient _myClient = null;
        public static dataService.StockServiceClient myClient
        {
            get
            {
                if (_myClient == null)
                {
                    OpenConnection();
                }
                if (_myClient.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    OpenConnection();
                }
                return _myClient;
            }
        }

        private static void OpenConnection()
        {
            if (_myClient != null) _myClient.Abort();
            _myClient = new dataService.StockServiceClient();
            _myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress(common.settings.myWsConInfos[0].URI);
            //_myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://localhost:8731/wsServices/DataLibs");
            _myClient.ClientCredentials.Windows.ClientCredential.UserName = common.settings.myWsConInfos[0].account;
            _myClient.ClientCredentials.Windows.ClientCredential.Password = common.settings.myWsConInfos[0].password;
            _myClient.Open();
        }
        private static void CloseConnection()
        {
            if (_myClient != null && (_myClient.State == System.ServiceModel.CommunicationState.Opened) )
            {
                _myClient.Close();
            }
            _myClient = null;
        }

        public static void Reset()
        {
            CloseConnection();
            wsAccess.libs.myClient.ClearCache();
        }

        //public static string GetDataKey(application.AppTypes.TimeRanges timeRange,string timeScale,string stockCode)
        //{
        //    return wsAccess.libs.myClient.GetData(timeRange, timeScale, stockCode, false);
        //}
        //public static application.wsData.TradePointInfo[] GetTradePoints(string dataKey,string strategyCode)
        //{
        //    return wsAccess.libs.myClient.Analysis(dataKey, strategyCode);
        //}
        //public static data.tmpDS.tradeEstimateDataTable GetEstimation(string dataKey, application.wsData.TradePointInfo[] tradePoints,application.wsData.EstimateOptions option)
        //{
        //    return wsAccess.libs.myClient.EstimateTrading(dataKey, tradePoints, option);
        //}


        //public static string CreateEstimateOption(application.wsData.EstimateOptions option)
        //{
        //    return wsAccess.libs.myClient.CreateEstimateOption(option);
        //}
        //public static void DisposeEstimateOption(string optionKey)
        //{
        //    wsAccess.libs.myClient.DisposeEstimateOption(optionKey);
        //}
        //public static decimal GetEstimatedProfit(application.AppTypes.TimeRanges timeRange,string timeScale,string optionKey,
        //                                         string stockCode,string strategyCode)
        //{
        //    return wsAccess.libs.myClient.EstimateProfit(timeRange, timeScale, optionKey, stockCode, strategyCode);
        //}
       
    }
}
