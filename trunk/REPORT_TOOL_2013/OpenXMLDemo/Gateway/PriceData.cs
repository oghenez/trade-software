using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OpenXMLDemo.Gateway
{
    public static class PriceData
    {
        public static DateTime DATE_BEGIN;
        public static DateTime DATE_END;
        public static string STR_TIME_SCALE;
        static void InitForTest()
        {
            DATE_BEGIN = DateTime.Now.AddDays(-30);
            DATE_END = DateTime.Today;
            STR_TIME_SCALE = "D1";
        }
        public static StockService.baseDS.priceDataRow getPriceDataToDay(string code)
        {
            InitForTest();
            Gateway.SerivceHandler.InitService();
            StockService.baseDS.priceDataDataTable tbl = Statics.svc_Client.GetPriceData(code, STR_TIME_SCALE, DATE_BEGIN, DATE_END);
            return tbl.Rows[0] as StockService.baseDS.priceDataRow;            
        }
        public static StockService.baseDS.priceDataDataTable GetPriceData(string code, string timeScale, DateTime begin, DateTime end)
        {                        
            Gateway.SerivceHandler.InitService();
            StockService.baseDS.priceDataDataTable tbl = Statics.svc_Client.GetPriceData(code, timeScale, begin, end);
            return tbl;
        }
    }
}

