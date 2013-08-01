using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections.Specialized;
using commonTypes;

namespace ServiceConsumer.Gateway
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
        public static QuantumStockServiceProvider.baseDS.priceDataRow getPriceDataToDay(string code)
        {
            InitForTest();
            Gateway.ServiceConnector.InitService();            
            QuantumStockServiceProvider.baseDS.priceDataDataTable tbl = Statics.svc_Client.GetPriceData(code, STR_TIME_SCALE, DATE_BEGIN, DATE_END);
            return tbl.Rows[0] as QuantumStockServiceProvider.baseDS.priceDataRow;            
        }
        public static QuantumStockServiceProvider.baseDS.priceDataDataTable GetPriceData(string code, string timeScale, DateTime begin, DateTime end)
        {                        
            Gateway.ServiceConnector.InitService();
            QuantumStockServiceProvider.baseDS.priceDataDataTable tbl = Statics.svc_Client.GetPriceData(code, timeScale, begin, end);            
            return tbl;
        }
        public static StringCollection Market_TopBiggestChange()
        {
            //Weekly Market data for user's interested code     
            DateTime beforeDate = DateTime.Today.AddDays(-7);
            QuantumStockServiceProvider.tmpDS.dataVarrianceDataTable tbl = Statics.svc_Client.GetTopPriceVarrianceOfUser(beforeDate,DateTime.Today, AppTypes.TimeScaleTypeToCode(AppTypes.TimeScaleTypes.Week), commonClass.SysLibs.sysLoginCode, 10);
            //If NONE get weekly data of all the market
            //if (tbl.Count == 0) tbl = DataAccess.Libs.GetTopPriceVarrianceWeekly(10);
            decimal[] yValues = new decimal[tbl.Count];
            string[] xValues = new string[tbl.Count];
            StringCollection topCodes = new StringCollection();

            int displayChartCount = Math.Min(tbl.Count, 5);
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (idx < displayChartCount)
                {
                    yValues[idx] = tbl[idx].percent;
                    xValues[idx] = tbl[idx].code;
                }
                topCodes.Add(tbl[idx].code);
            }
            return topCodes;
        }
    }
}

