using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using application;

namespace stockTrade
{
    public class libs
    {
        #region strategy estimation
        public delegate void onProcessStart(int stockCodeCount);
        public delegate bool onProcessItem(string stockcode);
        public delegate void onProcessEnd();

        private class tradeAlert
        {
            public analysis.tradePoint tradePoint = null;
            public myTypes.timeScales timeScale =  myTypes.timeScales.RealTime;
            public string stockCode="",strategy="";
            public DateTime onDateTime = common.Consts.constNullDate;
            public decimal price = 0;
            public tradeAlert(string _stockCode, string _strategy,myTypes.timeScales _timeScale,DateTime _onDateTime, analysis.tradePoint _tradePoint)
            {
                this.stockCode = _stockCode;
                this.timeScale = _timeScale;
                this.strategy = _strategy;
                this.onDateTime = _onDateTime;
                this.tradePoint = _tradePoint;
            }
        }

        //private static DateTime GetLastRunTime()
        //{
        //    StringCollection aFields = new StringCollection();
        //    aFields.Add(configuration.configKeys.sysTradeAlertLastRun.ToString());
        //    configuration.GetConfig(ref aFields);
        //    DateTime lastTime = DateTime.Now;
        //    if (!DateTime.TryParse(aFields[0], out lastTime)) return common.Consts.constNullDate;
        //    return lastTime;
        //}
        private static void SaveLastRunTime(DateTime onTime)
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Add(configuration.configKeys.sysTradeAlertLastRun.ToString());
            aValues.Add(onTime.ToString());
            configuration.SaveConfig(aFields, aValues);
        }


        
        //withAplicableCheckInAlert = true : Sell alerts only create when user owned stock that is applible to sell
        private static bool withAplicableCheckInAlert = false;

        /// <summary>
        /// Create alerts for all stock in portfolio
        /// </summary>
        /// <param name="alertList"> all alert resulted from analysis </param>
        /// <param name="frDate">Alert will only create alert in range [frDate,toDate].
        /// It also ensure that in the same day,there in ONLY one new alert of the same type</param>
        /// <param name="toDate"></param>
        private static void CreateTradeAlert(tradeAlert[] alertList,DateTime frDate,DateTime toDate)
        {
            decimal availabeQty;
            string msg;
            StringCollection timeScaleList;

            data.baseDS.tradeAlertRow tradeAlertRow;
            data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();
            data.baseDS.stockCodeExtDataTable stockCodeTbl = new data.baseDS.stockCodeExtDataTable();
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.portfolioDetailDataTable portfolioDetailTbl = new data.baseDS.portfolioDetailDataTable();
            DataView portfolioDetailView = new DataView(portfolioDetailTbl);
            portfolioDetailView.Sort = portfolioDetailTbl.dataCodeColumn.ColumnName;
            DataRowView[] strategyRowFound;

            dataLibs.LoadData(portfolioTbl);
            for (int idx1 = 0; idx1 < portfolioTbl.Count; idx1++)
            {
                // Only alert on stock codes that were selected by user. 
                stockCodeTbl.Clear();
                dataLibs.LoadData(stockCodeTbl, portfolioTbl[idx1]);

                portfolioDetailTbl.Clear();
                dataLibs.LoadData(portfolioDetailTbl, portfolioTbl[idx1].code, myTypes.portfolioDetailDataType.Strategy);

                for (int idx2 = 0; idx2 < alertList.Length; idx2++)
                {
                    // Check if alert's strategy in user's wish list ??
                    strategyRowFound = portfolioDetailView.FindRows(alertList[idx2].strategy.Trim());
                    if (strategyRowFound.Length == 0) continue;
                    
                    // Check if time alert's time scale in user's wish list ??
                    timeScaleList = common.system.MultivalueString2List(((data.baseDS.portfolioDetailRow)strategyRowFound[0].Row).data.Trim());
                    if (!timeScaleList.Contains(((byte)alertList[idx2].timeScale).ToString())) continue; 
                    if (stockCodeTbl.FindBycode(alertList[idx2].stockCode.Trim())==null) continue;

                    //Do not crete alert if there is a NEW one.
                    tradeAlertRow = dataLibs.GetLastAlert(frDate, toDate, portfolioTbl[idx1].code, alertList[idx2].stockCode,
                                                          alertList[idx2].strategy,
                                                          (byte)alertList[idx2].timeScale,
                                                          (byte)application.myTypes.commonStatus.New);
                    if (tradeAlertRow != null) continue;

                    //Availabe stock
                    if (withAplicableCheckInAlert)
                    {
                        availabeQty = application.dataLibs.GetAvailableStock(alertList[idx2].stockCode, portfolioTbl[idx1].code,
                                                               application.Settings.sysStockSell2BuyInterval, alertList[idx2].onDateTime);
                    }
                    else availabeQty = int.MaxValue;

                    //Aplicable to sell
                    if ( (alertList[idx2].tradePoint.tradeAction == analysis.tradeActions.Sell ||
                          alertList[idx2].tradePoint.tradeAction == analysis.tradeActions.ClearAll) && (availabeQty<=0) ) continue;
                    msg = " - Giá : " + alertList[idx2].tradePoint.tradeInfo.price.ToString() + common.Consts.constCRLF +
                          " - K/L giao dịch : " + alertList[idx2].tradePoint.tradeInfo.volume.ToString() + common.Consts.constCRLF +
                          " - Xu hướng : " + alertList[idx2].tradePoint.tradeInfo.marketTrend + common.Consts.constCRLF  +
                          " - K/L sở hữu hợp lệ : " + availabeQty.ToString() + common.Consts.constCRLF;

                    CreateTradeAlert(tradeAlertTbl, portfolioTbl[idx1], alertList[idx2].stockCode, alertList[idx2].strategy,
                                    alertList[idx2].timeScale, alertList[idx2].tradePoint, toDate, msg); 
                }
            }
            dataLibs.UpdateData(tradeAlertTbl);
        }

        private static void CreateTradeAlert(data.baseDS.tradeAlertDataTable tradeAlertTbl,data.baseDS.portfolioRow portfolioRow,
                                             string stockCode, string strategy,myTypes.timeScales timeScale,analysis.tradePoint info, DateTime onTime,string msg)
        {
            data.baseDS.tradeAlertRow row = tradeAlertTbl.NewtradeAlertRow();
            dataLibs.InitData(row);
            row.onTime = onTime;
            row.portfolio = portfolioRow.code;
            row.stockCode = stockCode;
            row.timeScale = (byte)timeScale; 
            row.strategy = strategy; 
            row.status = (byte)myTypes.commonStatus.New; 
            row.tradeAction = (byte)info.tradeAction;
            row.subject = info.tradeAction.ToString();
            row.msg = msg;
            tradeAlertTbl.AddtradeAlertRow(row);
        }

        public static void CreateTradeAlert()
        {
            CreateTradeAlert(null, null, null);
        }
        public static void CreateTradeAlert(onProcessStart onStartFunc, onProcessItem onProcessItemFunc, onProcessEnd onEndFunc)
        {
            CultureInfo cultureInfo = new CultureInfo(Settings.sysCultureCode);
            DateTime frDate = common.Consts.constNullDate;
            DateTime toDate = sysLibs.GetServerDateTime();
            
            //Run all strategy analysis for all stocks.
            data.baseDS.stockCodeExtDataTable stockCodeExtTbl = new data.baseDS.stockCodeExtDataTable();
            dataLibs.LoadData(stockCodeExtTbl,(byte)myTypes.commonStatus.Enable);
            data.baseDS.strategyDataTable strategyTbl = new data.baseDS.strategyDataTable();
            dataLibs.LoadData(strategyTbl,true);

            analysis.workData analysisData = new analysis.workData();

            tradeAlert[] tradeAlertList = new tradeAlert[0];
            analysis.tradePoint tradePoint;

            if (onStartFunc != null) onStartFunc(stockCodeExtTbl.Count);
 
            for (int idx1 = 0; idx1 < stockCodeExtTbl.Count; idx1++)
            {
                if (onProcessItemFunc != null)
                    if (!onProcessItemFunc(stockCodeExtTbl[idx1].code)) break;

                foreach (myTypes.timeScales timeScale in Enum.GetValues(typeof(myTypes.timeScales)))
                {
                    //Move date ahead to ensure that there are sufficient data need in analysis process
                    switch (timeScale)
                    {
                        case myTypes.timeScales.RealTime:
                            frDate = toDate.AddHours(-1);
                            break;
                        case myTypes.timeScales.Hourly:
                            frDate = toDate.Date;
                            break;
                        case myTypes.timeScales.Daily:
                            frDate = toDate.Date;
                            break;
                        case myTypes.timeScales.Weekly:
                            frDate = common.dateTimeLibs.StartOfWeek(toDate, cultureInfo).AddSeconds(-1);
                            break;
                        case myTypes.timeScales.Monthly:
                            frDate = common.dateTimeLibs.MakeDate(1, toDate.Month, toDate.Year).AddSeconds(-1);
                            break;
                        case myTypes.timeScales.Yearly:
                            frDate = common.dateTimeLibs.MakeDate(1, 1, toDate.Year).AddSeconds(-1);
                            break;
                        default:
                            common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }
                    analysisData.Init(timeScale, frDate, toDate, stockCodeExtTbl[idx1]);
             
                    for (int idx2 = 0; idx2 < strategyTbl.Count; idx2++)
                    {
                        analysis.analysisResult advices = appHub.strategy.TradeAnalysis(analysisData, strategyTbl[idx2].code.Trim());
                        if (advices == null) continue;
                        for (int idx3 = 0; idx3 < advices.Count; idx3++)
                        {
                            tradePoint = (analysis.tradePoint)advices[idx3];
                            Array.Resize(ref tradeAlertList, tradeAlertList.Length + 1);
                            tradePoint.tradeInfo.price = analysisData.closePrice[tradePoint.dataIdx];
                            tradeAlertList[tradeAlertList.Length - 1] =
                                new tradeAlert(stockCodeExtTbl[idx1].code.Trim(), strategyTbl[idx2].code.Trim(),
                                                timeScale, analysisData.priceDate[tradePoint.dataIdx], tradePoint);
                        }
                    }
                }
            }
            stockCodeExtTbl.Dispose();
            strategyTbl.Dispose();

            //Create alerts in the day
            CreateTradeAlert(tradeAlertList,toDate.Date,toDate);

            //Save last lun date
            SaveLastRunTime(toDate);
            if (onEndFunc != null) onEndFunc();
        }
        #endregion
    }
}
