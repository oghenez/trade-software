using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceConsumer.QuantumStockServiceProvider;

namespace ServiceConsumer.Gateway
{
    public static class Statics
    {
        public static StockServiceClient svc_Client;
        public static string svc_User = "test";
        public static string svc_Password = "123";
    }
}
