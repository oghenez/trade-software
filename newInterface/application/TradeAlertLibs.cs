using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using commonTypes;
using commonClass;

namespace application
{
    public class TradeAlert
    {
        public delegate void onProcessStart(int stockCodeCount);
        public delegate bool onProcessItem(string stockcode);
        public delegate void onProcessEnd();

        private class TradeAlertItem
        {
            public TradePointInfo TradePoint = null;
            public AppTypes.TimeScale TimeScale =  AppTypes.MainDataTimeScale;
            public string StockCode="", Strategy="";
            public DateTime OnDateTime = common.Consts.constNullDate;
            public double Price=0,Volume=0;
            public TradeAlertItem(string stockCode, string strategy, AppTypes.TimeScale timeScale, DateTime onDateTime,
                                  double price, double volume, TradePointInfo tradePoint)
            {
                this.StockCode = stockCode;
                this.TimeScale = timeScale;
                this.Strategy = strategy;
                this.OnDateTime = onDateTime;
                this.Price = price;
                this.Volume = volume;
                this.TradePoint = tradePoint;
            }
        }

        //private static void SaveLastRunTime(DateTime onTime)
        //{
        //    StringCollection aFields = new StringCollection();
        //    StringCollection aValues = new StringCollection();
        //    aFields.Add(Configuration.configKeys.sysTradeAlertLastRun.ToString());
        //    aValues.Add(onTime.ToString());
        //    application.Configuration.SaveConfig(aFields, aValues);
        //}
        
        //withAplicableCheckInAlert = true : Sell alerts only create when user owned stock that is applible to sell

       
        /// <summary>
        /// Create alerts for all stock in portfolio and return number of alerts created
        /// </summary>
        /// <param name="alertList"> all alert resulted from analysis </param>
        private static int CreateTradeAlert(TradeAlertItem[] alertList)
        {
            int noAlertCreated = 0;
            string msg;
            StringCollection timeScaleList;

            databases.baseDS.tradeAlertRow tradeAlertRow;
            databases.baseDS.tradeAlertDataTable tradeAlertTbl = new databases.baseDS.tradeAlertDataTable();

            //Watch list : sort by  Stock code + Strategy code
            databases.baseDS.portfolioDetailDataTable watchlistTbl = databases.DbAccess.GetPortfolioDetail_ByType(new AppTypes.PortfolioTypes[] { AppTypes.PortfolioTypes.WatchList});
            DataView watchlistView = new DataView(watchlistTbl);
            
            watchlistView.Sort = watchlistTbl.codeColumn.ColumnName + "," + watchlistTbl.subCodeColumn.ColumnName;

            //Portfolio : Sort by  Stock code 
            databases.tmpDS.investorStockDataTable investorStockTbl = new databases.tmpDS.investorStockDataTable();
            databases.DbAccess.LoadStockOwnedByAll(investorStockTbl);

            DataView investorStockView = new DataView(investorStockTbl);
            investorStockView.Sort = investorStockTbl.stockCodeColumn.ColumnName;

            DataRowView[] foundRows;
            // Only create alerts for codes in user's watchlist. 
            for (int alertId = 0; alertId < alertList.Length; alertId++)
            {
                databases.baseDS.portfolioDetailRow portfolioDetailRow;
                //===============================================
                // Check if alert's strategy in user's wish list 
                //===============================================
                foundRows = watchlistView.FindRows(new object[] { alertList[alertId].StockCode, alertList[alertId].Strategy.Trim() });
                for (int dataIdx = 0; dataIdx < foundRows.Length; dataIdx++)
                {
                    // Check if alert's time scale in user's wish list ??
                    portfolioDetailRow = ((databases.baseDS.portfolioDetailRow)foundRows[dataIdx].Row);
                    timeScaleList = common.MultiValueString.String2List(portfolioDetailRow.data.Trim());
                    if (!timeScaleList.Contains(alertList[alertId].TimeScale.Code)) continue;
                    
                    //Ignore duplicate alerts.
                    tradeAlertRow = databases.DbAccess.GetOneAlert(alertList[alertId].OnDateTime,
                                                                   portfolioDetailRow.portfolio,
                                                                   alertList[alertId].StockCode,
                                                                   alertList[alertId].Strategy,
                                                                   alertList[alertId].TimeScale.Code,
                                                                   AppTypes.CommonStatus.All);
                    if (tradeAlertRow != null) continue;
                    string infoText = alertList[alertId].TradePoint.BusinessInfo.ToText().Trim();
                    infoText = (infoText != "" ? infoText : common.Consts.constNotAvailable);

                    //Create alert template message, AlertMessageText() will convert it to specified-language text.
                    msg = Consts.constTextMergeMarkerLEFT + "price" + Consts.constTextMergeMarkerRIGHT + " : " + alertList[alertId].Price.ToString() + common.Consts.constCRLF +
                          Consts.constTextMergeMarkerLEFT + "volume" + Consts.constTextMergeMarkerRIGHT + " : " + alertList[alertId].Volume.ToString() + common.Consts.constCRLF +
                          Consts.constTextMergeMarkerLEFT + "marketInfo" + Consts.constTextMergeMarkerRIGHT + " : " + infoText + common.Consts.constCRLF;
                    CreateTradeAlert(tradeAlertTbl, portfolioDetailRow.portfolio, alertList[alertId].StockCode, alertList[alertId].Strategy,
                                     alertList[alertId].TimeScale, alertList[alertId].TradePoint, alertList[alertId].OnDateTime, msg);
                    noAlertCreated++;
                }

                //===============================================
                // Create alerts for all codes in user's porfolio
                //===============================================
                foundRows = investorStockView.FindRows(new object[] { alertList[alertId].StockCode });
                for (int dataIdx = 0; dataIdx < foundRows.Length; dataIdx++)
                {
                    // Check if alert's time scale in user's wish list ??
                    databases.tmpDS.investorStockRow investorStockRow = ((databases.tmpDS.investorStockRow)foundRows[dataIdx].Row);
                    if (investorStockRow.qty == 0) continue;

                    //Ignore duplicate alerts.
                    tradeAlertRow = databases.DbAccess.GetOneAlert(alertList[alertId].OnDateTime,
                                                                   investorStockRow.portfolio,
                                                                   alertList[alertId].StockCode,
                                                                   alertList[alertId].Strategy,
                                                                   alertList[alertId].TimeScale.Code,
                                                                   AppTypes.CommonStatus.All);
                    if (tradeAlertRow != null) continue;

                    string infoText = alertList[alertId].TradePoint.BusinessInfo.ToText().Trim();
                    infoText = (infoText != "" ? infoText : common.Consts.constNotAvailable);

                    //Create alert template message, AlertMessageText() will convert it to specified-language text.
                    msg = Consts.constTextMergeMarkerLEFT + "price" + Consts.constTextMergeMarkerRIGHT + " : " + alertList[alertId].Price.ToString() + common.Consts.constCRLF +
                          Consts.constTextMergeMarkerLEFT + "volume" + Consts.constTextMergeMarkerRIGHT + " : " + alertList[alertId].Volume.ToString() + common.Consts.constCRLF +
                          Consts.constTextMergeMarkerLEFT + "marketInfo" + Consts.constTextMergeMarkerRIGHT + " : " + infoText + common.Consts.constCRLF;
                    msg += Consts.constTextMergeMarkerLEFT + "ownedQty" + Consts.constTextMergeMarkerRIGHT + " : " + investorStockRow.qty.ToString() + common.Consts.constCRLF;
                    CreateTradeAlert(tradeAlertTbl, investorStockRow.portfolio, alertList[alertId].StockCode, alertList[alertId].Strategy,
                                     alertList[alertId].TimeScale, alertList[alertId].TradePoint, alertList[alertId].OnDateTime, msg);
                    noAlertCreated++;
                }

            }
            databases.DbAccess.UpdateData(tradeAlertTbl);
            return noAlertCreated;
        }


        private static void CreateTradeAlert(databases.baseDS.tradeAlertDataTable tradeAlertTbl,string portfolioCode,
                                             string stockCode, string strategy, AppTypes.TimeScale timeScale, TradePointInfo info, DateTime onTime, string msg)
        {
            databases.baseDS.tradeAlertRow row = tradeAlertTbl.NewtradeAlertRow();
            databases.AppLibs.InitData(row);
            row.onTime = onTime;
            row.portfolio = portfolioCode;
            row.stockCode = stockCode;
            row.timeScale = timeScale.Code; 
            row.strategy = strategy; 
            row.status = (byte)AppTypes.CommonStatus.New; 
            row.tradeAction = (byte)info.TradeAction;
            row.subject = info.TradeAction.ToString();
            row.msg = msg;
            tradeAlertTbl.AddtradeAlertRow(row);
        }

        //public static int CreateTradeAlert()
        //{
        //    CreateTradeAlert(null, null, null);
        //}
        public static int CreateTradeAlert(onProcessStart onStartFunc, onProcessItem onProcessItemFunc, onProcessEnd onEndFunc)
        {
            DateTime frDate = common.Consts.constNullDate;
            DateTime toDate = DateTime.Now;
            
            //Run all strategy analysis for all stocks.
            databases.tmpDS.stockCodeDataTable stockCodeTbl = new databases.tmpDS.stockCodeDataTable();
            databases.DbAccess.LoadData(stockCodeTbl, AppTypes.CommonStatus.Enable);

            application.AnalysisData data = new application.AnalysisData();
            data.DataTimeRange = AppTypes.TimeRanges.None;
            data.DataMaxCount = Settings.sysGlobal.AlertDataCount;

            TradeAlertItem[] tradeAlertList = new TradeAlertItem[0];
            StringCollection strategyList = new StringCollection();
            for (int idx = 0; idx < application.Strategy.Data.MetaList.Values.Length; idx++)
            {
                application.Strategy.Meta meta = (application.Strategy.Meta)application.Strategy.Data.MetaList.Values[idx];
                if (meta.Type != AppTypes.StrategyTypes.Strategy) continue;
                strategyList.Add(((application.Strategy.Meta)application.Strategy.Data.MetaList.Values[idx]).Code);
            }

            if (onStartFunc != null) onStartFunc(stockCodeTbl.Count);
            
            DateTime alertDate;
            DateTime alertFrDate = toDate.Date;
            DateTime alertToDate = toDate;
            for (int stockCodeIdx = 0; stockCodeIdx < stockCodeTbl.Count; stockCodeIdx++)
            {
                if (onProcessItemFunc != null)
                    if (!onProcessItemFunc(stockCodeTbl[stockCodeIdx].code)) break;

                //foreach (AppTypes.TimeScale timeScale in AppTypes.myTimeScales) //???
                AppTypes.TimeScale timeScale = AppTypes.TimeScaleFromType(AppTypes.TimeScaleTypes.Day);
                {
                    data.DataStockCode = stockCodeTbl[stockCodeIdx].code;
                    data.DataTimeScale = timeScale;
                    data.LoadData();
                    for (int strategyIdx = 0; strategyIdx < strategyList.Count; strategyIdx++)
                    {
                        application.Strategy.Data.ClearCache();
                        application.Strategy.Data.TradePoints advices = application.Strategy.Libs.Analysis(data, strategyList[strategyIdx].Trim());
                        
                        if ( (advices == null) || (advices.Count==0)) continue;
                        
                        //Only check the last advices for alert
                        TradePointInfo tradeInfo = (TradePointInfo)advices[advices.Count-1];
                        alertDate = DateTime.FromOADate(data.DateTime[tradeInfo.DataIdx]);
                        
                        //Ignore alerts that out of date range.
                        if (alertDate < alertFrDate || alertDate > alertToDate) continue;
                        Array.Resize(ref tradeAlertList, tradeAlertList.Length + 1);

                        tradeAlertList[tradeAlertList.Length - 1] = new TradeAlertItem(stockCodeTbl[stockCodeIdx].code.Trim(), strategyList[strategyIdx].Trim(),
                                                                                 timeScale, alertDate,
                                                                                 data.Close[tradeInfo.DataIdx],
                                                                                 data.Volume[tradeInfo.DataIdx],tradeInfo);
                    }
                }
            }
            //Create alerts in the day
            int noAlertCreated = CreateTradeAlert(tradeAlertList);

            //Save last lun date
            //SaveLastRunTime(toDate);
            if (onEndFunc != null) onEndFunc();
            stockCodeTbl.Dispose();
            return noAlertCreated;
        }
    }
}
