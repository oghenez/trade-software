using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceConsumer.Gateway;
using commonTypes;
using System.Collections.Specialized;

namespace ReportProcessing
{
    public class StockReport
    {
        private static StockReport instance;
        public static StockReport getInstance()
        {
            if (instance==null)
            {
	             instance = new StockReport();
            }
            return instance;
        }
        private StockReport ()
	    {

	    }
        public string Date()
        {
            return DataAccess.Libs.GetServerDateTime().ToLongDateString();
        }
        public string Name(string code)
        {
            databases.baseDS.priceDataRow data = getPriceDataToDay(code);                        
            return data.stockCode;
        }
        public string ClosedPrice(string code)
        {
            databases.baseDS.priceDataRow data = getPriceDataToDay(code);            
            return String.Format("{0:0,0}", data.closePrice*1000)+" VNĐ";
        }
        public string Volume(string code)
        {

            TopBiggestChangeTable();
            databases.baseDS.priceDataRow data = getPriceDataToDay(code);
            return String.Format("{0:0,0}", data.volume);
        }
        public databases.tmpDS.dataVarrianceDataTable TopBiggestChangeTable()
        {
            //Weekly Market data for user's interested code
            databases.tmpDS.dataVarrianceDataTable tbl = DataAccess.Libs.GetTopPriceVarrianceWeeklyOfLoginUser(10);
            //If NONE get weekly data of all the market
            if (tbl.Count == 0) tbl = DataAccess.Libs.GetTopPriceVarrianceWeekly(10);
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
            databases.tmpDS.dataVarrianceDataTable tbl2 = Market_DataDailyChange(topCodes);            
            return Market_DataDailyChange(topCodes);
        }
        public databases.baseDS.priceDataRow getPriceDataToDay(string code)
        {         
            //Gateway.ServiceConnector.InitService();            
            string timeScaleCode = AppTypes.TimeScaleTypeToCode(AppTypes.TimeScaleTypes.Day);
            databases.baseDS.priceDataDataTable tbl = DataAccess.Libs.GetPriceData(code, timeScaleCode, DateTime.Now.AddDays(-1), DateTime.Today);            
            return tbl.Rows[0] as databases.baseDS.priceDataRow;
        }
        private databases.tmpDS.dataVarrianceDataTable Market_DataDailyChange(StringCollection codes)
        {
            databases.baseDS.lastPriceDataRow lastPriceRowOpen, lastPriceRowClose; 
            databases.baseDS.lastPriceDataDataTable openTbl = DataAccess.Libs.myLastDailyOpenPrice;
            databases.baseDS.lastPriceDataDataTable closeTbl = DataAccess.Libs.myLastDailyClosePrice; 
            databases.tmpDS.dataVarrianceRow varrianceRow;              
            databases.tmpDS.dataVarrianceDataTable tbl = new databases.tmpDS.dataVarrianceDataTable();
            for (int idx = 0; idx < codes.Count; idx++)
            {
                lastPriceRowOpen = openTbl.FindBystockCode(codes[idx]);
                lastPriceRowClose = closeTbl.FindBystockCode(codes[idx]);
                if (lastPriceRowOpen == null ||lastPriceRowClose == null) continue;
                decimal closePrice = lastPriceRowClose.value;
                decimal openPrice = lastPriceRowOpen.value;
                if (openPrice == 0 || closePrice == 0) continue;                


                varrianceRow = tbl.NewdataVarrianceRow();
                databases.AppLibs.InitData(varrianceRow);
                varrianceRow.code = codes[idx];
                varrianceRow.val1 = openPrice;
                varrianceRow.val2 = closePrice;
                varrianceRow.value = (closePrice - openPrice);
                varrianceRow.percent = ((closePrice - openPrice) / openPrice) * 100;

                //DataRowView[] foundRows = alertView.FindRows(codes[idx]);
                //if (foundRows.Length > 0)
                //{
                //    varrianceRow.notes = (foundRows[0].Row as databases.baseDS.tradeAlertRow).msg;
                //}
                tbl.AdddataVarrianceRow(varrianceRow);
            }
            return tbl;
        }
    }
}
