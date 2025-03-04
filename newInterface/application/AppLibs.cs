using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.Drawing;
using System.Transactions;
using commonTypes;
using commonClass;

namespace application
{
    public class AppLibs
    {
        //Number of units to read ahead
        private const int constNumberOfReadAheadUnit = 0;
        public static databases.tmpDS.codeListDataTable GetTimeScales()
        {
            databases.tmpDS.codeListDataTable tbl = new databases.tmpDS.codeListDataTable();
            databases.tmpDS.codeListRow row;
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                row = tbl.NewcodeListRow();
                row.code = AppTypes.myTimeScales[idx].Code;
                row.description = AppTypes.myTimeScales[idx].Description;
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
                row.description = AppTypes.Type2Text(item);
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
                row.byteValue = (byte)item;
                row.description = AppTypes.Type2Text(item);
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }

        //public static databases.tmpDS.codeListDataTable GetDataSourceCodes()
        //{
        //    databases.tmpDS.codeListDataTable tbl = new databases.tmpDS.codeListDataTable();
        //    databases.tmpDS.codeListRow row;
        //    foreach (AppTypes.DataSourceCodes item in Enum.GetValues(typeof(AppTypes.DataSourceCodes)))
        //    {
        //        row = tbl.NewcodeListRow();
        //        row.code = ((short)item).ToString();
        //        row.shortValue = (short)item;
        //        row.description = AppTypes.Type2Text(item);
        //        tbl.AddcodeListRow(row);
        //    }
        //    return tbl;
        //}

        public static DateTime GetWorkDayDate(DateTime frDate, int days) { return frDate.AddDays(days); }

        /// <summary>
        ///  Create records to keep stock transaction (buy,sell...) 
        ///  - transactions
        ///  - investorStock
        /// </summary>
        /// <param name="onDate"></param>
        /// <param name="type"></param>
        /// <param name="stockCode"></param>
        /// <param name="portfolio"></param>
        /// <param name="qty"></param>
        /// <param name="amt"></param>
        public static databases.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type, string stockCode, string portfolioCode, int qty, decimal feePerc,out string errorText)
        {
            errorText="";
            databases.baseDS.stockExchangeRow marketRow = databases.DbAccess.GetStockExchange(stockCode);
            if (marketRow == null) return null;

            errorText="";
            DateTime onTime = DateTime.Now;
            //Price
            databases.baseDS.priceDataRow priceRow = databases.DbAccess.GetLastPriceData(stockCode);
            if (priceRow == null)
            {
                errorText = Languages.Libs.GetString("cannotDoTransaction");
                return null;
            }
            decimal amt = qty * priceRow.closePrice * marketRow.priceRatio;
            decimal feeAmt = (decimal)Math.Round(feePerc * amt / 100, common.system.GetPrecisionFromMask(Settings.sysMaskLocalAmt));

            databases.baseDS.portfolioRow portfolioRow = databases.DbAccess.GetPortfolio(portfolioCode);
            if (portfolioRow == null)
            {
                errorText = String.Format(Languages.Libs.GetString("dataNotFound"), "[portfolio]");
                return null;
            }
            switch (type)
            {
                case AppTypes.TradeActions.Buy:
                case AppTypes.TradeActions.Accumulate:
                    portfolioRow.usedCapAmt += amt;
                    portfolioRow.usedCapAmt += feeAmt;
                    break;
                default: //Sell
                    portfolioRow.usedCapAmt -= amt;
                    portfolioRow.usedCapAmt += feeAmt;
                    break;
            }
            if (portfolioRow.startCapAmt - portfolioRow.usedCapAmt < 0)
            {
                portfolioRow.CancelEdit();
                errorText = String.Format(Languages.Libs.GetString("outOfMoney"), portfolioRow.startCapAmt - portfolioRow.usedCapAmt - amt - feeAmt);
                return null;
            }

            //Create records to store data 
            databases.baseDS.transactionsDataTable transTbl = new databases.baseDS.transactionsDataTable();
            databases.baseDS.investorStockDataTable investorStockTbl = new databases.baseDS.investorStockDataTable();
            databases.baseDS.transactionsRow transRow;
            databases.baseDS.investorStockRow stockRow;

            transRow = transTbl.NewtransactionsRow();
            databases.AppLibs.InitData(transRow);
            transRow.onTime = onTime;
            transRow.tranType = (byte)type;
            transRow.stockCode = stockCode;
            transRow.portfolio = portfolioCode;
            transRow.qty = qty;
            transRow.amt = amt;
            transRow.feeAmt = feeAmt;
            transRow.status = (byte)AppTypes.CommonStatus.Close;
            transTbl.AddtransactionsRow(transRow);

            //Update stock
            DateTime onDate = onTime.Date;
            switch (type)
            {
                case AppTypes.TradeActions.Buy:
                case AppTypes.TradeActions.Accumulate:
                    investorStockTbl.Clear();
                    databases.DbAccess.LoadData(investorStockTbl, stockCode, portfolioCode, onDate);
                    if (investorStockTbl.Count == 0)
                    {
                        stockRow = investorStockTbl.NewinvestorStockRow();
                        databases.AppLibs.InitData(stockRow);
                        stockRow.buyDate = onDate;
                        stockRow.stockCode = stockCode;
                        stockRow.portfolio = portfolioCode;
                        investorStockTbl.AddinvestorStockRow(stockRow);
                    }
                    stockRow = investorStockTbl[0];
                    stockRow.qty += qty; stockRow.buyAmt += amt;
                    break;
                default: //Sell
                    DateTime applicableDate = onDate.AddDays(-marketRow.minBuySellDay);
                    investorStockTbl.Clear();
                    databases.DbAccess.LoadData(investorStockTbl, stockCode, portfolioCode);
                    decimal remainQty = qty;
                    for (int idx = 0; idx < investorStockTbl.Count; idx++)
                    {
                        if (investorStockTbl[idx].buyDate > applicableDate) continue;
                        if (investorStockTbl[idx].qty >= remainQty)
                        {
                            investorStockTbl[idx].buyAmt = (investorStockTbl[idx].qty - remainQty) * (investorStockTbl[idx].qty == 0 ? 0 : investorStockTbl[idx].buyAmt / investorStockTbl[idx].qty);
                            investorStockTbl[idx].qty = (investorStockTbl[idx].qty - remainQty);
                            remainQty = 0;
                        }
                        else
                        {
                            remainQty -= investorStockTbl[idx].qty;
                            investorStockTbl[idx].buyAmt = 0;
                            investorStockTbl[idx].qty = 0;
                        }
                        if (remainQty == 0) break;
                    }
                    if (remainQty > 0)
                    {
                        errorText =  String.Format(Languages.Libs.GetString("outOfQty"), qty - remainQty);
                        return null;
                    }
                    break;
            }
            //Delete empty stock
            for (int idx = 0; idx < investorStockTbl.Count; idx++)
            {
                if (investorStockTbl[idx].qty != 0) continue;
                investorStockTbl[idx].Delete();
            }

            //Update data with transaction support
            TransactionScopeOption tranOption;
            tranOption = (commonClass.SysLibs.sysUseTransactionInUpdate ? TransactionScopeOption.Required : TransactionScopeOption.Suppress);
            using (TransactionScope scope = new TransactionScope(tranOption))
            {
                databases.DbAccess.UpdateData(portfolioRow);
                databases.DbAccess.UpdateData(investorStockTbl);
                databases.DbAccess.UpdateData(transTbl);
                scope.Complete();
            }
            return transTbl;
        }

        /// <summary>
        /// Load stock price data withd some point ahead of the specified date range
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="frDate">Start date </param>
        /// <param name="toDate">End date</param>
        /// <param name="timeScale">Time scale</param>
        /// <param name="noUnitAhead">the number of units(minute,day,hour,week...) to read beyond the start time[frDate].</param>
        /// <param name="toTbl">Table keeps loaded data</param>
        /// <param name="startIdx">specify the row where the data in [frDate,toDate] range starts</param>
        public static void LoadAnalysisData(AnalysisData dataObj)
        {
            int startIdx = dataObj.priceDataTbl.Count;
            if (dataObj.DataTimeRange == AppTypes.TimeRanges.None)
            {
                dataObj.priceDataTbl.Clear();
                databases.DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, dataObj.DataStockCode, dataObj.DataMaxCount + constNumberOfReadAheadUnit);
                dataObj.FirstDataStartAt = 0;
                return;
            }
            int noUnitAhead = constNumberOfReadAheadUnit;

            DateTime toDate = common.Consts.constNullDate;
            DateTime frDate = common.Consts.constNullDate;
            if (!AppTypes.GetDate(dataObj.DataTimeRange, out frDate, out toDate)) return;

            databases.baseDS.priceDataStatDataTable priceStatTbl = databases.DbAccess.GetPriceDataStat(dataObj.DataTimeScale, dataObj.DataStockCode);
            if (priceStatTbl.Count == 0) return;
            DateTime dataMaxDateTime = priceStatTbl[0].maxDate;
            DateTime dataMinDateTime = priceStatTbl[0].minDate;
            int dataTotalCount = priceStatTbl[0].totalCount;

            if (toDate > dataMaxDateTime) toDate = dataMaxDateTime;
            if (frDate < dataMinDateTime) frDate = dataMinDateTime;
            dataObj.priceDataTbl.Clear();
            if (noUnitAhead != 0)
            {
                // Find start date that return sufficient rows as required by [noBarAhead]
                DateTime checkFrDate = common.Consts.constNullDate;
                DateTime checkToDate = frDate.AddSeconds(-1);
                int totalGotRowCount = 0, gotRowCount;
                decimal rangeScale = 1;
                //int loopPass = 0;
                while (true)
                {
                    //loopPass++;
                    switch (dataObj.DataTimeScale.Type)
                    {
                        case AppTypes.TimeScaleTypes.Minnute:
                            checkFrDate = checkToDate.AddMinutes(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Hour:
                            checkFrDate = checkToDate.AddHours(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Day:
                            checkFrDate = checkToDate.AddDays(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Week:
                            checkFrDate = checkToDate.AddDays(-(int)(7 * noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Month:
                            checkFrDate = checkToDate.AddMonths(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Year:
                            checkFrDate = checkToDate.AddYears(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.RealTime:
                            //checkFrDate = checkToDate.AddMinutes(-(int)(commonClass.Settings.sysAutoRefreshInSeconds * noUnitAhead * rangeScale) / 60);
                            checkFrDate = checkToDate.AddMinutes(-(int)(noUnitAhead * rangeScale));
                            break;
                        default: common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }
                    gotRowCount = databases.DbAccess.GetTotalPriceRow(dataObj.DataTimeScale, checkFrDate, checkToDate, dataObj.DataStockCode);
                    //No more data ??
                    if (checkFrDate < dataMinDateTime) break;
                    //Sufficient data ??
                    totalGotRowCount += gotRowCount;
                    if (totalGotRowCount >= noUnitAhead) break;

                    //No data load means the check range not big enough, increse rangeScale by 5 to make it larger scale
                    if (gotRowCount == 0) rangeScale += 5;
                    else
                    {
                        //Estimate the best range scale 
                        // Increase total left sligtly by 3% with the hope that it can take all need.
                        // 5 and 3% had been tested indifferent cases and see that they are the best value.
                        decimal tmpRangeScale = rangeScale * (decimal)(noUnitAhead - totalGotRowCount + noUnitAhead * 0.03) / gotRowCount;
                        rangeScale = (tmpRangeScale > 0 ? tmpRangeScale : rangeScale + 5);
                    }
                    checkToDate = checkFrDate.AddSeconds(-1);
                }
                databases.DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, checkFrDate, frDate.AddSeconds(-1), dataObj.DataStockCode);
                startIdx = dataObj.priceDataTbl.Count - startIdx;
            }
            databases.DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, frDate, toDate, dataObj.DataStockCode);
            dataObj.FirstDataStartAt = startIdx;
        }

        /// <summary>
        /// Updated data from the last read/update point
        /// </summary>
        /// <param name="dataObj"></param>
        /// <returns></returns>
        public static int UpdateAnalysisData(AnalysisData dataObj)
        {
            int lastDataIdx = dataObj.priceDataTbl.Count - 1;
            DateTime lastDateTime;
            if (lastDataIdx < 0) lastDateTime = Settings.sysStartDataDate;
            else lastDateTime = dataObj.priceDataTbl[lastDataIdx].onDate;

            databases.baseDS.priceDataDataTable tbl = new databases.baseDS.priceDataDataTable();
            databases.DbAccess.LoadData(tbl, dataObj.DataTimeScale.Code, lastDateTime, dataObj.DataStockCode);
            if (tbl.Count > 0)
            {
                //Delete the last data because the updated data will include this one.
                if (lastDataIdx >= 0)
                {
                    dataObj.priceDataTbl[lastDataIdx].ItemArray = tbl[0].ItemArray;
                    common.system.Concat(tbl, 1, dataObj.priceDataTbl);
                }
                else common.system.Concat(tbl, 0, dataObj.priceDataTbl);
            }
            return dataObj.priceDataTbl.Count - 1 - lastDataIdx;
        }

        /// <summary>
        /// Diagnose price data for abnomal variance in price
        /// </summary>
        /// <param name="priceDataTbl"></param>
        /// <param name="checkVariancePerc"></param>
        /// <param name="checkVariance"></param>
        /// <param name="precision"></param>
        /// <param name="priceDiagnoseTbl"></param>
        public static void DiagnosePrice_CloseAndNextOpen(databases.baseDS.priceDataDataTable priceDataTbl,
                     double checkVariancePerc, double checkVariance,byte precision, databases.tmpDS.priceDiagnoseDataTable priceDiagnoseTbl)
        {
            string dataFld1 = priceDataTbl.closePriceColumn.ColumnName;
            string dataFld2 = priceDataTbl.openPriceColumn.ColumnName;
            databases.baseDS.priceDataRow priceRow1, priceRow2;
            databases.tmpDS.priceDiagnoseRow priceDiagnoseRow;

            DataView myView = new DataView(priceDataTbl);
            myView.Sort = priceDataTbl.onDateColumn.ColumnName;

            double d1, d2,variancePerc;
            for (int idx = 1; idx < myView.Count; idx++)
            {
                d1 = double.Parse(myView[idx-1][dataFld1].ToString());
                d2 = double.Parse(myView[idx][dataFld2].ToString());
                if (d1 == 0) continue;
                variancePerc = (d2 / d1) - 1;
                if (Math.Abs(d2 - d1) <= checkVariance || Math.Abs(Math.Round(variancePerc, precision)) <= checkVariancePerc) continue;
                priceRow1 = (databases.baseDS.priceDataRow)myView[idx-1].Row;
                priceRow2 = (databases.baseDS.priceDataRow)myView[idx].Row;
                priceDiagnoseRow = priceDiagnoseTbl.NewpriceDiagnoseRow();

                priceDiagnoseRow.code = priceRow2.stockCode;
                priceDiagnoseRow.date1 = priceRow1.onDate;
                priceDiagnoseRow.date2 = priceRow2.onDate;

                priceDiagnoseRow.price1 = d1;
                priceDiagnoseRow.price2 = d2;
                priceDiagnoseRow.variance = variancePerc;
                priceDiagnoseTbl.AddpriceDiagnoseRow(priceDiagnoseRow);
            }
        }


        private static void AjustPriceDataUP(databases.baseDS.priceDataDataTable priceTbl, DateTime toDate, decimal weight)
        {
            if (weight == 0 || priceTbl == null) return;
            //Only adjust before specified date
            byte precisionPrice = common.system.GetPrecisionFromMask(Settings.sysMaskPrice);
            for (int idx = 0; idx < priceTbl.Count; idx++)
            {
                if (priceTbl[idx].RowState == DataRowState.Deleted) continue;
                if (priceTbl[idx].onDate > toDate) continue;
                priceTbl[idx].lowPrice = Math.Round(priceTbl[idx].lowPrice * weight,precisionPrice);
                priceTbl[idx].highPrice = Math.Round(priceTbl[idx].highPrice * weight, precisionPrice);
                priceTbl[idx].closePrice = Math.Round(priceTbl[idx].closePrice * weight, precisionPrice);
                priceTbl[idx].openPrice = Math.Round(priceTbl[idx].openPrice * weight, precisionPrice);
            }
        }
        private static void AjustPriceDataDN(databases.baseDS.priceDataDataTable priceTbl, DateTime toDate, decimal weight)
        {
            if (weight == 0 || priceTbl == null) return;
            byte precisionPrice = common.system.GetPrecisionFromMask(Settings.sysMaskPrice);
            for (int idx = 0; idx < priceTbl.Count; idx++)
            {
                if (priceTbl[idx].RowState == DataRowState.Deleted) continue;
                if (priceTbl[idx].onDate > toDate) continue;
                priceTbl[idx].lowPrice = Math.Round(priceTbl[idx].lowPrice / weight, precisionPrice);
                priceTbl[idx].highPrice = Math.Round(priceTbl[idx].highPrice / weight, precisionPrice);
                priceTbl[idx].closePrice = Math.Round(priceTbl[idx].closePrice / weight, precisionPrice);
                priceTbl[idx].openPrice = Math.Round(priceTbl[idx].openPrice / weight, precisionPrice);
            }
        }
        public static void AjustPriceData(databases.baseDS.priceDataDataTable priceTbl, DateTime toDate, decimal weight)
        {
            if (weight > 0)
            {
                AjustPriceDataUP(priceTbl, toDate, weight);
            }
            else
            {
                AjustPriceDataDN(priceTbl, toDate, -weight);
            }
        }
        //public static void AjustPriceData(string code, DateTime toDate, decimal weight)
        //{
        //    if (weight == 0) return;
        //    //Load main  pricedata
        //    databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
        //    databases.DbAccess.LoadData(priceTbl,AppTypes.MainDataTimeScale.Code, DateTime.MinValue, DateTime.MaxValue, code);
        //    if (priceTbl == null) return;
        //    AjustPriceData(priceTbl, toDate, weight);
        //    databases.DbAccess.UpdateData(priceTbl);
        //    //Delete all summ pricedata
        //    databases.DbAccess.DeletePriceSumData(code);

        //    CultureInfo stockCulture = application.AppLibs.GetStockCulture(code);
        //    //??Imports.AggregatePriceData(priceTbl,stockCulture,null);
        //}


        public static CultureInfo GetCulture(string countryCode)
        {
            if (countryCode == null) return null;
            databases.baseDS.countryRow countryRow = databases.AppLibs.FindAndCache_Country(countryCode);
            if (countryRow == null) return null;
            return common.language.GetCulture((!countryRow.IscultureNull() ? countryRow.culture : Consts.constDefaultCultureCode));
        }

        public static CultureInfo GetExchangeCulture(string code)
        {
            databases.baseDS.stockExchangeRow exchangeRow = databases.AppLibs.FindAndCache_StockExchange(code);
            return GetExchangeCulture(exchangeRow);
        }
        public static CultureInfo GetExchangeCulture(databases.baseDS.stockExchangeRow exchangeRow)
        {
            if (exchangeRow == null) return null;
            return GetCulture(exchangeRow.country);
        }
        public static CultureInfo GetStockCulture(string code)
        {
            return GetExchangeCulture(databases.DbAccess.GetStockExchange(code));
        }
    }
}
