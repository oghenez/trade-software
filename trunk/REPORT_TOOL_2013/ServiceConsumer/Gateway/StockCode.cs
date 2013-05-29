using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceConsumer.Gateway
{
    public static class StockCode
    {
        public static QuantumStockServiceProvider.baseDS.stockCodeDataTable getStockCodeDataTable()
        {
            List<string> lst = new List<string>();
            Gateway.ServiceConnector.InitService();
            QuantumStockServiceProvider.baseDS.stockCodeDataTable tbl = Statics.svc_Client.GetStockFull();
            return tbl;
        }
    }
}
