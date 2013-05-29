using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXMLDemo.Gateway
{
    public static class StockCode
    {
        public static StockService.baseDS.stockCodeDataTable getStockCodeDataTable()
        {
            List<string> lst = new List<string>();
            Gateway.SerivceHandler.InitService();
            StockService.baseDS.stockCodeDataTable tbl = Statics.svc_Client.GetStockFull();
            return tbl;
        }
    }
}
