using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Text;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using commonTypes; 

namespace databases
{
    public static class AppLibs
    {
        #region Init data
        public static void InitData(databases.importDS.importPriceRow row)
        {
            row.onDate = common.Consts.constNullDate;
            row.stockCode = "";
            row.closePrice = 0;
            row.volume = 0;
            row.isTotalVolume = false;
        }

        public static void InitData(databases.baseDS.sysLogRow row)
        {
            row.type = 0;
            row.description = "";
        }
        public static void InitData(databases.baseDS.sysCodeRow row)
        {
            row.category = "";
            row.code = "";
            row.description1 = "";
            row.isSystem = false; row.isVisible = true;
        }
        public static void InitData(databases.baseDS.sysCodeCatRow row)
        {
            row.category = "";
            row.description = "";
            row.isSystem = false;
            row.isVisible = true;
        }

        public static void InitData(databases.baseDS.stockCodeRow row)
        {
            row.code = "";
            row.tickerCode = "";
            row.stockExchange = "";
            row.name = "";
            row.address1 = "";
            row.email = "";
            row.website = "";
            row.phone = "";
            row.fax = "";
            row.country = Settings.sysDefaultCountry;
            row.bizSectors = "";

            row.regDate = DateTime.Today;
            row.capitalUnit = Settings.sysMainCurrency;
            row.workingCap = 0;
            row.equity = 0;
            row.totalDebt = 0;
            row.totaAssets = 0;
            row.noOutstandingStock = 1000000;
            row.noListedStock = 1000000;
            row.noTreasuryStock = 0;
            row.noForeignOwnedStock = 0;
            row.bookPrice = 0;
            row.targetPrice = 0;
            row.targetPriceVariant = 0;
            row.sales = 0;
            row.profit = 0;
            row.equity = 0;
            row.totalDebt = 0;
            row.totaAssets = 0;
            row.PB = 0;
            row.EPS = 0;
            row.PE = 0;
            row.ROA = 0;
            row.ROE = 0;
            row.BETA = 0;
            row.status = (byte)AppTypes.CommonStatus.Enable;
        }
        public static void InitData(databases.baseDS.investorRow row)
        {
            row.code = "";
            row.type = 0;
            row.firstName = "";
            row.lastName = "";
            row.displayName = "";
            row.sex = (byte)AppTypes.Sex.Unspecified;
            row.address1 = "";
            row.email = "";
            row.displayName = "";
            row.account = "";
            row.password = "";
            row.catCode = "";
            row.expireDate = DateTime.Today.AddDays(Settings.sysDefaultLoginAccountDayToExpire);
            row.status = (byte)AppTypes.CommonStatus.Enable;
        }
        public static void InitData(databases.baseDS.investorStockRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.buyDate = DateTime.Today;
            row.qty = 0;
            row.buyAmt = 0;
        }
        public static void InitData(databases.baseDS.transactionsRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.onTime = DateTime.Today;
            row.tranType = (byte)AppTypes.TradeActions.None;
            row.qty = 0; row.amt = 0; row.feeAmt = 0;
            row.status = (byte)AppTypes.CommonStatus.None;
        }
        public static void InitData(databases.baseDS.portfolioRow row)
        {
            row.type = (byte)AppTypes.PortfolioTypes.WatchList;
            row.code = "";
            row.name = "";
            row.investorCode = "";
            row.description = "";

            row.startCapAmt = 0;
            row.usedCapAmt = 0;

            row.maxBuyAmtPerc = 100;
            row.stockReducePerc = 50;
            row.stockAccumulatePerc = 50;

            row.interestedSector = "";
            row.interestedStock = "";
        }

        public static void InitData(databases.baseDS.portfolioDetailRow row)
        {
            row.portfolio = "";
            row.code = "";
            row.subCode = "";
            row.data = "";
        }
        public static void InitData(databases.baseDS.exchangeDetailRow row)
        {
            row.code = "";
            row.marketCode = "";
            row.address = "";
            row.isEnabled = true;
            row.orderId = 0;
            row.culture = commonTypes.Consts.constDefaultCultureCode;
        }
        public static void InitData(databases.baseDS.stockExchangeRow row)
        {
            row.code = "";
            row.description = "";
            row.country = "";
            row.workTime = "";
            row.holidays = "";
            row.minBuySellDay = 0;
            row.tranFeePerc = 0;
            row.priceRatio = 1;
            row.volumeRatio = 1;
            row.weight = 0;
            row.priceAmplitude = 0;
        }
        public static void InitData(databases.baseDS.priceDataRow row)
        {
            row.stockCode = "";
            row.onDate = DateTime.Today;
            row.openPrice = 0;
            row.highPrice = 0;
            row.lowPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
        }
        public static void InitData(databases.baseDS.priceDataSumRow row)
        {
            row.type = "";
            row.stockCode = "";
            row.onDate = DateTime.Today;
            row.openPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
            row.highPrice = decimal.MinValue;
            row.lowPrice = decimal.MaxValue;
        }

        public static void InitData(databases.baseDS.tradeAlertRow row)
        {
            row.type = "";
            row.portfolio = "";
            row.stockCode = "";
            row.strategy = "";
            row.timeScale = "";
            row.onTime = DateTime.Today;
            row.status = 0;
            row.tradeAction = (byte)AppTypes.TradeActions.None;
            row.subject = common.Settings.sysNewDataText;
            row.msg = "";
        }
        public static void InitData(databases.baseDS.messagesRow row)
        {
            row.type = (byte)AppTypes.MessageTypes.Feedback;
            row.OnDate = common.Consts.constNullDate;
            row.Subject = "";
            row.MsgBody = "";
            row.SenderId = Consts.constMarkerNEW;
            row.ReceiverId = Consts.constMarkerNEW;;
            row.status = (short)AppTypes.CommonStatus.None;
        }

        public static void InitData(databases.tmpDS.porfolioWatchRow  row)
        {
            row.qty = 0; row.boughtAmt = 0;
            row.boughtPrice = 0;
            row.price = 0;
            row.priceVariant = 0;
            row.amt = 0;
            row.profitVariantAmt = 0;
            row.profitVariantPerc = 0;
        }
        public static void InitData(databases.tmpDS.dataVarrianceRow row)
        {
            row.code = "";
            row.value = 0;
            row.percent = 0;
        }
        

        #endregion

        #region FindAndCache
        private static databases.baseDS myCachedDS = new databases.baseDS();
        private static databases.tmpDS myCachedTmpDS = new databases.tmpDS();
        public static void ClearCache()
        {
            myCachedDS.Clear();
            myCachedTmpDS.Clear();
        }

        public static databases.baseDS.priceDataSumRow FindAndCache(databases.baseDS.priceDataSumDataTable tbl, string stockCode, string timeScale, DateTime onDate)
        {
            databases.baseDS.priceDataSumRow row = tbl.FindBytypestockCodeonDate(timeScale, stockCode, onDate);
            if (row != null) return row;
            databases.baseDSTableAdapters.priceDataSumTA dataTA = new databases.baseDSTableAdapters.priceDataSumTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(tbl, stockCode, timeScale, onDate, onDate);
            row = tbl.FindBytypestockCodeonDate(timeScale, stockCode, onDate);
            if (row != null) return row;
            return null;
        }


        public static databases.baseDS.stockExchangeDataTable myStockExchangeTbl
        {
            get
            {
                if (myCachedDS.stockExchange.Count == 0)
                {
                    DbAccess.LoadData(myCachedDS.stockExchange);
                }
                return myCachedDS.stockExchange;
            }
        }
        public static databases.baseDS.stockExchangeRow FindAndCache_StockExchange(string code)
        {
            databases.baseDS.stockExchangeRow row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.stockExchangeTA dataTA = new databases.baseDSTableAdapters.stockExchangeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.stockExchange);
            row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static databases.baseDS.stockCodeRow FindAndCache_StockCode(string code)
        {
            databases.baseDS.stockCodeRow row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.stockCodeTA dataTA = new databases.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedDS.stockCode, code);
            row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static databases.baseDS.countryRow FindAndCache_Country(string code)
        {
            databases.baseDS.countryRow row = myCachedDS.country.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.countryTA dataTA = new databases.baseDSTableAdapters.countryTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.country);
            row = myCachedDS.country.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static databases.baseDS.portfolioRow FindAndCache(databases.baseDS.portfolioDataTable tbl, string code)
        {
            databases.baseDS.portfolioRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.portfolioTA dataTA = new databases.baseDSTableAdapters.portfolioTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static databases.baseDS.bizSubSectorRow FindAndCache(databases.baseDS.bizSubSectorDataTable tbl, string code)
        {
            databases.baseDS.bizSubSectorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.bizSubSectorTA dataTA = new databases.baseDSTableAdapters.bizSubSectorTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static databases.baseDS.bizSubSectorRow FindAndCache_BizSubSector(string code)
        {
            return FindAndCache(myCachedDS.bizSubSector, code);
        }

        public static databases.tmpDS.stockCodeRow FindAndCache_StockCodeShort(string code)
        {
            databases.tmpDS.stockCodeRow row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            databases.tmpDSTableAdapters.stockCodeTA dataTA = new databases.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedTmpDS.stockCode, code);
            row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static databases.tmpDS.stockCodeRow FindAndCache(databases.tmpDS.stockCodeDataTable tbl, string code)
        {
            databases.tmpDS.stockCodeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.tmpDSTableAdapters.stockCodeTA dataTA = new databases.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static databases.baseDS.investorRow FindAndCache_Investor(string code)
        {
            return FindAndCache(myCachedDS.investor, code);
        }
        public static databases.baseDS.investorRow FindAndCache(databases.baseDS.investorDataTable tbl, string code)
        {
            databases.baseDS.investorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.investorTA dataTA = new databases.baseDSTableAdapters.investorTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        #endregion

        /// <summary>
        /// Copy data from one portfolioDetail data table to another
        /// </summary>
        /// <param name="frDataTbl">Source data</param>
        /// <param name="toDataTbl">Destination data</param>
        /// <param name="porfolioCode">Porfolio code of the data added to destination</param>
        /// <param name="stockCode">Stock code of the data added to destination</param>
        public static void CopyPortfolioData(databases.baseDS.portfolioDetailDataTable frDataTbl,
                                             databases.baseDS.portfolioDetailDataTable toDataTbl,
                                             string porfolioCode, string stockCode)
        {
            databases.baseDS.portfolioDetailRow row;
            for (int idx = 0; idx < frDataTbl.Rows.Count; idx++)
            {
                row = toDataTbl.NewportfolioDetailRow();
                AppLibs.InitData(row);
                row.portfolio = porfolioCode;
                row.code = stockCode;
                row.subCode = frDataTbl[idx].subCode; ;
                row.data = frDataTbl[idx].data;
                toDataTbl.AddportfolioDetailRow(row);
            }
        }

        public static databases.tmpDS.codeListDataTable GetTimeScales()
        {
            databases.tmpDS.codeListDataTable tbl = new databases.tmpDS.codeListDataTable();
            databases.tmpDS.codeListRow row;
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                row = tbl.NewcodeListRow();
                row.code = AppTypes.myTimeScales[idx].Code;
                row.description = AppTypes.myTimeScales[idx].Text;
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }
        public static databases.tmpDS.codeListDataTable GetCommonStatus()
        {
            databases.tmpDS.codeListDataTable tbl = new databases.tmpDS.codeListDataTable();
            databases.tmpDS.codeListRow row;
            foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
            {
                row = tbl.NewcodeListRow();
                row.code = ((byte)item).ToString();
                row.byteValue = (byte)item;
                row.description = item.ToString();
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }
        public static databases.tmpDS.codeListDataTable GetTradeActions()
        {
            databases.tmpDS.codeListDataTable tbl = new databases.tmpDS.codeListDataTable();
            databases.tmpDS.codeListRow row;
            foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
            {
                row = tbl.NewcodeListRow();
                row.code = ((byte)item).ToString();
                row.description = item.ToString();
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }

        ///// <summary>
        ///// Concatenate 2 table
        ///// </summary>
        ///// <param name="frTbl">Source table</param>
        ///// <param name="fromId">The index in source where the copy begins</param>
        ///// <param name="toTbl">Destination table</param>
        //public static void DataConcat(databases.baseDS.priceDataDataTable frTbl, int fromIdx, databases.baseDS.priceDataDataTable toTbl)
        //{
        //    for (int idx = fromIdx; idx < frTbl.Count; idx++)
        //    {
        //        toTbl.ImportRow(frTbl[idx]);
        //    }
        //}

        #region imports
        public class AgrregateInfo
        {
            public byte phase = 0;
            public bool cancel = false;
            public int count = 0, maxCount = 0;
            public void Reset()
            {
                cancel = false;
                count = 0;
                maxCount = 0;
            }
        }
        public delegate void OnAggregateData(AgrregateInfo param);
        public static void ReAggregatePriceData(string code, CultureInfo stockCulture, OnAggregateData onAggregateDataFunc)
        {
            //Load main  pricedata
            baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            DbAccess.LoadData(priceTbl, AppTypes.MainDataTimeScale.Code, DateTime.MinValue, DateTime.MaxValue, code);
            if (priceTbl == null) return;
            //Delete all summ pricedata
            DbAccess.DeletePriceSumData(code);
            ClearLastClosePrices();
            AggregatePriceData(priceTbl, stockCulture, onAggregateDataFunc);
            priceTbl.Dispose();
        }

        /// <summary>
        /// Get aggregation date/time from a date/time
        /// </summary>
        /// <param name="type"></param>
        /// <param name="onDateTime"></param>
        /// <param name="ci"></param>
        /// <returns></returns>
        public static DateTime AggregateDateTime(AppTypes.TimeScale timeScale, DateTime onDateTime, CultureInfo ci)
        {
            if (timeScale.Type == AppTypes.TimeScaleTypes.RealTime) return onDateTime;
            switch (timeScale.Type)
            {
                case AppTypes.TimeScaleTypes.Minnute:
                    int newMin = ((int)(onDateTime.Minute / timeScale.AggregationValue)) * timeScale.AggregationValue;
                    return onDateTime.Date.AddHours(onDateTime.Hour).AddMinutes(newMin);
                case AppTypes.TimeScaleTypes.Hour:
                    int newHour = ((int)(onDateTime.Hour / timeScale.AggregationValue)) * timeScale.AggregationValue;
                    return onDateTime.Date.AddHours(newHour);
                case AppTypes.TimeScaleTypes.Day:
                    int newDay = ((int)((onDateTime.Day - 1) / timeScale.AggregationValue)) * timeScale.AggregationValue + 1;
                    return common.dateTimeLibs.MakeDate(newDay, onDateTime.Month, onDateTime.Year);
                case AppTypes.TimeScaleTypes.Week:
                    int weekNo = onDateTime.DayOfYear / 7;
                    int newWeek = ((int)(weekNo / timeScale.AggregationValue)) * timeScale.AggregationValue;
                    DateTime newDate = common.dateTimeLibs.MakeDate(1, 1, onDateTime.Year).AddDays(newWeek * 7);
                    return common.dateTimeLibs.StartOfWeek(newDate, ci);
                case AppTypes.TimeScaleTypes.Month:
                    int newMonth = ((int)((onDateTime.Month - 1) / timeScale.AggregationValue)) * timeScale.AggregationValue + 1;
                    return common.dateTimeLibs.MakeDate(1, newMonth, onDateTime.Year);
                case AppTypes.TimeScaleTypes.Year:
                    int newYear = ((int)((onDateTime.Year - 1) / timeScale.AggregationValue)) * timeScale.AggregationValue + 1;
                    return common.dateTimeLibs.MakeDate(1, 1, newYear);
                default:
                    common.system.ThrowException("Invalid argument in AggregateDateTime()");
                    break;
            }
            return onDateTime;
        }

        // [lastClosePrices] variable keeps last close price list used for aggregation
        // [lastClosePrices] is updated continuously during aggregation process to refresh the latest values
        private static common.DictionaryList lastClosePrices = new common.DictionaryList();
        private static void ClearLastClosePrices()
        {
            lastClosePrices.Clear();
        }
        
        /// <summary>
        /// Get the all last price (grouped by timescale and stock) from databases
        /// </summary>
        public static void GetLastClosePrices()
        {
            ClearLastClosePrices();
            databases.baseDS.stockCodeDataTable stockCodeTbl = new baseDS.stockCodeDataTable();
            databases.DbAccess.LoadData(stockCodeTbl);

            databases.baseDS.priceDataSumRow priceDataSumRow;
            for (int idx = 0; idx < stockCodeTbl.Count; idx++)
            {
                foreach (AppTypes.TimeScale timeScale in AppTypes.myTimeScales)
                {
                    if (timeScale == AppTypes.MainDataTimeScale) continue;
                    priceDataSumRow = databases.DbAccess.GetLastPrice(timeScale.Code, stockCodeTbl[idx].code);
                    if (priceDataSumRow == null) continue;
                    lastClosePrices.Add(timeScale.Code + stockCodeTbl[idx].code, priceDataSumRow.closePrice);
                }
            }
        }

        /// <summary>
        /// Agrregate a data row to hourly,daily data...
        /// </summary>
        /// <param name="priceRow"> source data arregated to [toSumTbl] </param>
        /// <param name="changeVolume"> volume qty changed and is cumulated to total volume </param>
        /// <param name="timeScale"> aggregate to hour,day,week... data </param>
        /// <param name="cultureInfo"> culture info that need to caculate the start of the week param>
        /// <param name="toSumTbl"> destination table</param>
        public static void AggregatePriceData(databases.baseDS.priceDataRow priceRow, decimal changeVolume, AppTypes.TimeScale timeScale,
                                              CultureInfo cultureInfo, databases.baseDS.priceDataSumDataTable toSumTbl)
        {
            DateTime dataDate = AggregateDateTime(timeScale, priceRow.onDate, cultureInfo);
            databases.baseDS.priceDataSumRow priceDataSumRow;
            priceDataSumRow = AppLibs.FindAndCache(toSumTbl, priceRow.stockCode, timeScale.Code, dataDate);
            if (priceDataSumRow == null)
            {
                priceDataSumRow = toSumTbl.NewpriceDataSumRow();
                databases.AppLibs.InitData(priceDataSumRow);
                priceDataSumRow.type = timeScale.Code;
                priceDataSumRow.stockCode = priceRow.stockCode;
                priceDataSumRow.onDate = dataDate;
                priceDataSumRow.openPrice = priceRow.openPrice;
                priceDataSumRow.closePrice = priceRow.closePrice;

                object lastPriceObj = lastClosePrices.Find(timeScale.Code + priceRow.stockCode);
                if (lastPriceObj!=null)
                {
                    priceDataSumRow.openPrice = (decimal)lastPriceObj;
                }
                else priceDataSumRow.openPrice = priceDataSumRow.closePrice;
                toSumTbl.AddpriceDataSumRow(priceDataSumRow);
            }
            priceDataSumRow.closePrice = priceRow.closePrice;
            lastClosePrices.Add(timeScale.Code + priceRow.stockCode, priceRow.closePrice);

            if (priceDataSumRow.highPrice < priceRow.highPrice) priceDataSumRow.highPrice = priceRow.highPrice;
            if (priceDataSumRow.lowPrice > priceRow.lowPrice) priceDataSumRow.lowPrice = priceRow.lowPrice;
            priceDataSumRow.volume += changeVolume;
        }

        /// <summary>
        /// Agrregate a data table to hourly,daily data...
        /// </summary>
        /// <param name="priceTbl">source data to be aggregated </param>
        /// <param name="cultureCode"></param>
        /// <param name="isDailyPrice">
        ///  Volume can be accumulated real-time or at the end of the day. 
        ///  - If data is collected in realtime, 
        ///  updateVolume table is used to culmulated the volume for each day and that will need some more resources.
        ///  - If data is collected at the end of the day, the voulume alredy is the total volume and updateVolume table 
        ///  should not be used to save resources.
        /// </param>
        /// <param name="onAggregateDataFunc">function that was triggered after each agrregation</param>
        public static void AggregatePriceData(databases.baseDS.priceDataDataTable priceTbl, CultureInfo cultureInfo,
                                                  OnAggregateData onAggregateDataFunc)
            {
                databases.baseDS.priceDataSumDataTable priceSumDataTbl = new databases.baseDS.priceDataSumDataTable();
                AgrregateInfo myAgrregateStat = new AgrregateInfo();
                myAgrregateStat.maxCount = priceTbl.Count;

                decimal changeVolume;
                int lastYear = int.MinValue;
                for (int idx = 0; idx < priceTbl.Count; idx++)
                {
                    myAgrregateStat.count = idx;
                    if (onAggregateDataFunc != null) onAggregateDataFunc(myAgrregateStat);
                    if (myAgrregateStat.cancel)
                    {
                        priceSumDataTbl.Clear();
                        break;
                    }
                    Application.DoEvents();

                    changeVolume = priceTbl[idx].volume;
                    foreach (AppTypes.TimeScale timeScale in AppTypes.myTimeScales)
                    {
                        if (timeScale.Type == AppTypes.TimeScaleTypes.RealTime) continue;
                        AggregatePriceData(priceTbl[idx], changeVolume, timeScale, cultureInfo, priceSumDataTbl);
                    }
                    //Update and clear cache to speed up the performance
                    if (lastYear != priceTbl[idx].onDate.Year)
                    {
                        databases.DbAccess.UpdateData(priceSumDataTbl);
                        priceSumDataTbl.Clear();
                        lastYear = priceTbl[idx].onDate.Year;
                    }
                    //databases.DbAccess.UpdateData(priceDataRow);
                }
                databases.DbAccess.UpdateData(priceSumDataTbl);
                priceSumDataTbl.Dispose();
            }
            
        public static tmpDS.dataVarrianceDataTable GetTopPriceVarriance(DateTime beforeDate, string timeScaleCode, int topN)
        {
            tmpDS.dataVarrianceDataTable tmpDataTbl = GetPriceVarriance(beforeDate, timeScaleCode);
            tmpDS.dataVarrianceRow dataRow;
            DataView dataView = new DataView(tmpDataTbl);
            dataView.Sort = tmpDataTbl.percentColumn + " DESC";
            tmpDS.dataVarrianceDataTable dataTbl = new tmpDS.dataVarrianceDataTable();
            for (int idx = 0; idx < dataView.Count && idx < topN; idx++)
            {
                dataRow = dataTbl.NewdataVarrianceRow();
                dataRow.code = (dataView[idx].Row as tmpDS.dataVarrianceRow).code;
                dataRow.value = (dataView[idx].Row as tmpDS.dataVarrianceRow).value;
                dataRow.percent = (dataView[idx].Row as tmpDS.dataVarrianceRow).percent;
                dataTbl.AdddataVarrianceRow(dataRow);
            }
            return dataTbl;
        }
        public static tmpDS.dataVarrianceDataTable GetTopPriceVarrianceOfUser(DateTime beforeDate, string timeScaleCode, string userCode, int topN)
        {
            tmpDS.interestedCodeDataTable interestedCodeTbl = new tmpDS.interestedCodeDataTable();
            DbAccess.LoadData(interestedCodeTbl, userCode);
            tmpDS.dataVarrianceDataTable tmpDataTbl = GetPriceVarriance(beforeDate, timeScaleCode);

            tmpDS.dataVarrianceRow dataRow;
            DataView dataView = new DataView(tmpDataTbl);
            dataView.Sort = tmpDataTbl.percentColumn + " DESC";

            tmpDS.dataVarrianceDataTable dataTbl = new tmpDS.dataVarrianceDataTable();
            for (int idx1 = 0, idx2 = 0; idx1 < dataView.Count && idx2 < topN; idx1++)
            {
                if (interestedCodeTbl.FindBycode((dataView[idx1].Row as tmpDS.dataVarrianceRow).code) == null) continue;
                dataRow = dataTbl.NewdataVarrianceRow();
                dataRow.code = (dataView[idx1].Row as tmpDS.dataVarrianceRow).code;
                dataRow.value = (dataView[idx1].Row as tmpDS.dataVarrianceRow).value;
                dataRow.percent = (dataView[idx1].Row as tmpDS.dataVarrianceRow).percent;
                dataTbl.AdddataVarrianceRow(dataRow);
                idx2++;
            }
            return dataTbl;
        }
        private static tmpDS.dataVarrianceDataTable GetPriceVarriance(DateTime beforeDate, string timeScaleCode)
        {
            baseDS.lastPriceDataDataTable closeTbl = DbAccess.GetLastPrice(AppTypes.PriceDataType.Close, timeScaleCode, beforeDate);
            baseDS.lastPriceDataDataTable openTbl = DbAccess.GetLastPrice(AppTypes.PriceDataType.Open, timeScaleCode, beforeDate);
            tmpDS.dataVarrianceDataTable tmpDataTbl = new tmpDS.dataVarrianceDataTable();

            baseDS.lastPriceDataRow openPriceRow;
            tmpDS.dataVarrianceRow dataRow;
            for (int idx = 0; idx < closeTbl.Count; idx++)
            {
                openPriceRow = openTbl.FindBystockCode(closeTbl[idx].stockCode);
                if ((openPriceRow == null) || (openPriceRow.value == 0)) continue;
                if (closeTbl[idx].value == openPriceRow.value) continue;

                dataRow = tmpDataTbl.NewdataVarrianceRow();
                dataRow.code = closeTbl[idx].stockCode;
                dataRow.value = closeTbl[idx].value - openPriceRow.value;
                dataRow.percent = dataRow.value / openPriceRow.value;
                tmpDataTbl.AdddataVarrianceRow(dataRow);
            }
            return tmpDataTbl;
        }

        #endregion
    }
}
