using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net;
using application;

namespace wsTest
{
    public class libs
    {
        static libs()
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
    }
}
