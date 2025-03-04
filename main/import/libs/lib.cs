using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using application;
using commonClass;

namespace imports
{
    public class libs
    {
        public static CultureInfo CultureInfoUS = new CultureInfo("en-US");
        public static CultureInfo CultureInfoVN = new CultureInfo("vi-VN");
        public class importOHLCV : commonClass.OHLCV
        {
            public string code = "";
            public DateTime dateTime = common.Consts.constNullDate;
        }

        #region import
        //Use the idea from http://www.codeproject.com/KB/database/CsvReader.aspx by Sebastien Lorion 
        public static bool ImportOHLCV_CSV(string csvFileName, char delimiter, common.dateTimeLibs.DateTimeFormats dataDateFormat,
                                           string stockExchangeForNewCode, CultureInfo culture,
                                           data.baseDS.priceDataDataTable priceDataTbl,
                                           ImportRow ImportRowFunc,
                                           OnUpdatePriceData onUpdateDataFunc,
                                           OnEndImportPriceData onEndImportFunc)
        {
            libs.importStat myImportStat = new libs.importStat();
            myImportStat.Reset();
            myImportStat.dateFormat = dataDateFormat;
            myImportStat.culture = culture;
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            data.baseDS.priceDataRow priceDataRow;

            DataRowView[] foundRows;
            application.DbAccess.LoadData(stockCodeTbl, AppTypes.CommonStatus.Enable);
            DataView stockCodeView = new DataView(stockCodeTbl);
            stockCodeView.Sort = stockCodeTbl.codeColumn.ColumnName;

            bool fCanceled = false;
            DateTime lastPriceDate = common.Consts.constNullDate;

            importOHLCV data;
            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv = new CsvReader(new StreamReader(csvFileName), true, delimiter))
            {
                // missing fields will not throw an exception,
                // but will instead be treated as if there was a null value
                csv.MissingFieldAction = MissingFieldAction.ReplaceByNull;

                int fieldCount = csv.FieldCount;
                if (fieldCount < 7) return false;
                while (csv.ReadNextRecord())
                {
                    Application.DoEvents();
                    myImportStat.dataCount++;
                    data = ImportRowFunc(csv, myImportStat);
                    if (myImportStat.cancel)
                    {
                        fCanceled = true; break;
                    }
                    if (data == null)
                    {
                        myImportStat.errorCount++;
                        continue;
                    }
                    //Assume that all price must be valid
                    if (data.Open <= 0 || data.High <= 0 || data.Low <= 0 || data.Close <= 0) continue;

                    foundRows = stockCodeView.FindRows(data.code);
                    if (foundRows.Length == 0)
                    {
                        //Try to add new stock code
                        libs.AddNewCode(data.code, stockExchangeForNewCode, stockCodeTbl);
                        application.DbAccess.UpdateData(stockCodeTbl);
                    }

                    // Ignore all data that was in database
                    //if (!foundLastPriceDate)
                    //{
                    //    lastPriceDate = libs.FindLastPriceDate(data.code);
                    //    foundLastPriceDate = true;
                    //}
                    if (lastPriceDate != common.Consts.constNullDate && data.dateTime <= lastPriceDate)
                    {
                        continue;
                    }
                    if (priceDataTbl.FindBystockCodeonDate(data.code, data.dateTime) != null)
                    {
                        myImportStat.errorCount++;
                        continue;
                    }
                    myImportStat.updateCount++;
                    priceDataRow = priceDataTbl.NewpriceDataRow();
                    commonClass.AppLibs.InitData(priceDataRow);
                    priceDataRow.stockCode = data.code;
                    priceDataRow.onDate = data.dateTime;
                    //Try to fix some error in data
                    priceDataRow.openPrice = (decimal)data.Open; 
                    priceDataRow.highPrice = (decimal)data.High;
                    priceDataRow.lowPrice = (decimal)data.Low;
                    priceDataRow.closePrice = (decimal)data.Close;
                    priceDataRow.volume = (decimal)data.Volume;
                    priceDataTbl.AddpriceDataRow(priceDataRow);
                    if (onUpdateDataFunc != null) onUpdateDataFunc(priceDataRow, myImportStat);
                }
            }
            if (fCanceled)
            {
                priceDataTbl.Clear();
                return false;
            }
            if (onEndImportFunc != null) onEndImportFunc(priceDataTbl);
            return true;
        }

       
        #endregion

        public static data.baseDS.stockCodeRow FindAndCache(data.baseDS.stockCodeDataTable tbl, string code)
        {
            data.baseDS.stockCodeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockCodeTA dataTA = new data.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.priceDataSumRow FindAndCache(data.baseDS.priceDataSumDataTable tbl, string stockCode, string timeScale, DateTime onDate)
        {
            data.baseDS.priceDataSumRow row = tbl.FindBytypestockCodeonDate(timeScale, stockCode, onDate);
            if (row != null) return row;
            data.baseDSTableAdapters.priceDataSumTA dataTA = new data.baseDSTableAdapters.priceDataSumTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(tbl, stockCode, timeScale, onDate, onDate);
            row = tbl.FindBytypestockCodeonDate(timeScale, stockCode, onDate);
            if (row != null) return row;
            return null;
        }

        // string(0001 Oil & Gas) ->  (0001,Oil & Gas)
        public static common.myKeyValueItem SplitKeyValue(string str,string separator)
        {
            int pos = str.IndexOf(separator);
            if (pos <= 0) return null;
            return new common.myKeyValueItem(str.Substring(0, pos).Trim(), str.Substring(pos + 1).Trim());
        }

        //Return common.Consts.constNullDate if not found
        //public static DateTime FindLastPriceDate(string stockCode)
        //{
        //    data.baseDS.priceDataRow row = application.DbAccess.GetLastPrice(stockCode);
        //    if (row != null) return row.onDate;
        //    return common.Consts.constNullDate;
        //}

        public delegate importOHLCV ImportRow(LumenWorks.Framework.IO.Csv.CsvReader data,
                                              libs.importStat myImportStat);

        public delegate void OnAggregateData(agrregateStat stat);
        public delegate void OnUpdatePriceData(data.baseDS.priceDataRow row, importStat stat);
        public delegate void OnAddData(string code);
        public delegate void OnEndImportPriceData(data.baseDS.priceDataDataTable tbl);
        public class importStat
        {
            public bool cancel = false;
            public common.dateTimeLibs.DateTimeFormats dateFormat = common.dateTimeLibs.DateTimeFormats.Default;
            public CultureInfo culture = null;           
            public int dataCount = 0, updateCount = 0, errorCount = 0;
            public void Reset()
            {
                cancel = false;
                dataCount = 0;
                updateCount = 0;
                errorCount = 0;
            }
        }
        public class agrregateStat
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
        
        public static void Reset()
        {
            myDailyPrice.Reset();
        }
        // Keep last imported data by day
        public class DailyPrice
        {
            DateTime lastTime = DateTime.Today;
            string timeType = "D1";
            data.baseDS.priceDataSumDataTable priceSumTbl = new data.baseDS.priceDataSumDataTable();
            public void UpdateData(data.importDS.importPriceRow row)
            {
                if (lastTime != row.onDate.Date)
                {
                    Reset();
                    lastTime = row.onDate.Date;
                }
                data.baseDS.priceDataSumRow priceRow = GetData(row);
                if (priceRow == null)
                {
                    priceRow = priceSumTbl.NewpriceDataSumRow();
                    commonClass.AppLibs.InitData(priceRow);
                    priceRow.type = timeType;
                    priceRow.stockCode = row.stockCode;
                    priceRow.onDate = row.onDate.Date;
                    priceSumTbl.AddpriceDataSumRow(priceRow);
                }
                //Now only volume need to be processed
                priceRow.volume = row.volume;
                priceRow.highPrice = row.highPrice;
                priceRow.lowPrice = row.lowPrice;
                priceRow.openPrice = row.openPrice;
                priceRow.closePrice = row.closePrice;
            }
            public data.baseDS.priceDataSumRow GetData(data.importDS.importPriceRow row)
            {
                return FindAndCache(priceSumTbl, row.stockCode, timeType, row.onDate.Date);
            }
            public data.baseDS.priceDataSumRow GetData(string stockCode,DateTime onDate)
            {
                return FindAndCache(priceSumTbl,stockCode, timeType,onDate.Date);
            }
            // Importing can run continuously for many days, 
            // after each day the last data should be reset to reduce system resources
            public void Reset()
            {
                priceSumTbl.Clear();
            }
        }
        private static DailyPrice myDailyPrice = new DailyPrice();
        // importPrice->priceData
        private static void AddImportPrice(data.importDS.importPriceDataTable importPriceTbl,
                                           DailyPrice dailyPrice,data.baseDS.priceDataDataTable priceDataTbl)
        {
            data.baseDS.priceDataSumRow dailyPriceRow;
            data.baseDS.priceDataRow priceDataRow;
            decimal volume = 0;
            for (int idx = 0; idx < importPriceTbl.Count; idx++)
            {
                //Invalid price, ignore
                if (importPriceTbl[idx].closePrice <= 0) continue;

                volume = importPriceTbl[idx].volume;
                // If this is totail volume then minus the last volume to get the real volume in the period
                if (importPriceTbl[idx].isTotalVolume)
                {
                    dailyPriceRow = dailyPrice.GetData(importPriceTbl[idx]);
                    if (dailyPriceRow != null)
                    {
                        volume -= dailyPriceRow.volume;
                    }
                    if (volume <= 0) continue;
                }

                priceDataRow = priceDataTbl.NewpriceDataRow();
                commonClass.AppLibs.InitData(priceDataRow);
                priceDataRow.onDate = importPriceTbl[idx].onDate;
                priceDataRow.stockCode = importPriceTbl[idx].stockCode;
                priceDataRow.openPrice = importPriceTbl[idx].openPrice;
                priceDataRow.lowPrice = importPriceTbl[idx].lowPrice;
                priceDataRow.highPrice = importPriceTbl[idx].highPrice;
                priceDataRow.closePrice = importPriceTbl[idx].closePrice;
                priceDataRow.volume = volume;
                //Fix other invalid price
                if (priceDataRow.highPrice <= 0)  priceDataRow.highPrice = priceDataRow.closePrice;
                if (priceDataRow.lowPrice <= 0) priceDataRow.highPrice = priceDataRow.lowPrice;
                if (priceDataRow.openPrice <= 0) priceDataRow.highPrice = priceDataRow.openPrice;
                priceDataTbl.AddpriceDataRow(priceDataRow);

                //Update the last row
                dailyPrice.UpdateData(importPriceTbl[idx]);
            }
        }
        public static void AddImportPrice(data.importDS.importPriceDataTable importPriceTbl,
                                          data.baseDS.priceDataDataTable priceDataTbl)
        {
            AddImportPrice(importPriceTbl, myDailyPrice, priceDataTbl);
        }


        // Maybe there are someting wrong with price importing, 
        // use ReImportPricedata to add [importPrice] to [priceData,priceDataSum]
        public static void ReImportPricedata(DateTime frDate, DateTime toDate, string stockCode)
        {
            data.importDS myImportDS = new data.importDS();
            data.importDSTableAdapters.importPriceTA importPriceTA = new data.importDSTableAdapters.importPriceTA();

            if (stockCode.Trim() == "") importPriceTA.FillByDate(myImportDS.importPrice, frDate, toDate);
            else importPriceTA.FillByDateAndCode(myImportDS.importPrice, frDate, toDate, stockCode);
            libs.AddNewCode(myImportDS.importPrice, null);
            application.DbAccess.UpdateData(myImportDS.importPrice);

            data.baseDS myBaseDS = new data.baseDS();
            libs.AddImportPrice(myImportDS.importPrice, new DailyPrice(), myBaseDS.priceData);
            application.DbAccess.UpdateData(myBaseDS.priceData);
            // In VN culture : start of week is Monday (not Sunday) 
            libs.AggregatePriceData(myBaseDS.priceData,CultureInfoVN, null);
        }
        
        // Stock Exchange
        public static data.baseDS.stockExchangeRow AddStockExchange(data.baseDS.stockExchangeDataTable tbl, string code)
        {
            data.baseDS.stockExchangeRow stockExchangeRow = application.SysLibs.FindAndCache_StockExchange(code);
            if (stockExchangeRow == null)
            {
                stockExchangeRow = tbl.NewstockExchangeRow();
                commonClass.AppLibs.InitData(stockExchangeRow);
                stockExchangeRow.code = code;
                tbl.AddstockExchangeRow(stockExchangeRow);
                application.DbAccess.UpdateData(stockExchangeRow);
                common.fileFuncs.WriteLog(" - Add stockExchange" + common.Consts.constTab + code);
            }
            return stockExchangeRow;
        }

        //Detect new stockCode and create new one
        public static void AddNewCode(data.importDS.importPriceDataTable tbl, OnAddData onAddstockCodeFunc)
        {
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            for (int count = 0; count < tbl.Count; count++)
            {
                if (tbl[count].RowState == DataRowState.Deleted) continue;
                if (AddNewCode(tbl[count].stockCode, tbl[count].stockExchange, stockCodeTbl)!=null &&
                    onAddstockCodeFunc != null) onAddstockCodeFunc(tbl[count].stockCode);
            }
            application.DbAccess.UpdateData(stockCodeTbl);
        }
        public static void AddNewCode(data.baseDS.priceDataDataTable tbl, string stockEchangeCode, OnAddData onAddstockCodeFunc)
        {
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            for (int count = 0; count < tbl.Count; count++)
            {
                if (tbl[count].RowState == DataRowState.Deleted) continue;
                if (AddNewCode(tbl[count].stockCode, stockEchangeCode, stockCodeTbl)!=null &&
                    onAddstockCodeFunc != null) 
                    onAddstockCodeFunc(tbl[count].stockCode);
            }
            application.DbAccess.UpdateData(stockCodeTbl);
        }
        public static data.baseDS.stockCodeRow AddNewCode(string comCode, string stockEchangeCode,
                                                               data.baseDS.stockCodeDataTable toStockCodeTbl)
        {
            data.baseDS.stockCodeRow stockCodeRow;
            stockCodeRow = libs.FindAndCache(toStockCodeTbl, comCode);
            if (stockCodeRow == null)
            {
                stockCodeRow = toStockCodeTbl.NewstockCodeRow();
                commonClass.AppLibs.InitData(stockCodeRow);
                stockCodeRow.code = comCode;
                stockCodeRow.name = "<New>";
                stockCodeRow.code = comCode;
                stockCodeRow.tickerCode = comCode;
                stockCodeRow.stockExchange = stockEchangeCode;
                stockCodeRow.regDate = DateTime.Today;
                toStockCodeTbl.AddstockCodeRow(stockCodeRow);
            }
            return stockCodeRow;
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
                     return onDateTime.Date.AddHours(newMin);
                case AppTypes.TimeScaleTypes.Hour:
                     int newHour = ((int)(onDateTime.Hour / timeScale.AggregationValue)) * timeScale.AggregationValue;
                     return onDateTime.Date.AddHours(newHour);
                case AppTypes.TimeScaleTypes.Day:
                     int newDay = ((int)((onDateTime.Day - 1) / timeScale.AggregationValue)) * timeScale.AggregationValue + 1;
                     return common.dateTimeLibs.MakeDate(newDay, onDateTime.Month, onDateTime.Year);
                case AppTypes.TimeScaleTypes.Week:
                     int weekNo = onDateTime.DayOfYear / 7;
                     int newWeek = ((int)(weekNo / timeScale.AggregationValue)) * timeScale.AggregationValue;
                     DateTime newDate = common.dateTimeLibs.MakeDate(1, 1, onDateTime.Year).AddDays(newWeek*7);
                     return common.dateTimeLibs.StartOfWeek( newDate, ci);
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

        //Agrregate date time for hourly,daily data...
        //public static DateTime AggregateDateTime(AppTypes.timeScales type, DateTime onDateTime, CultureInfo ci)
        //{
        //    switch (type)
        //    {
        //        case AppTypes.timeScales.Hour1:
        //             return onDateTime.Date.AddHours(onDateTime.Hour);
        //        case AppTypes.timeScales.Hour2:
        //             return onDateTime.Date.AddHours(onDateTime.Hour / 2);
        //        case AppTypes.timeScales.Hour4:
        //             return onDateTime.Date.AddHours(onDateTime.Hour / 4);
        //        case AppTypes.timeScales.Daily:
        //             return onDateTime.Date;
        //        case AppTypes.timeScales.Weekly:
        //             return common.dateTimeLibs.StartOfWeek(onDateTime, ci);
        //        case AppTypes.timeScales.Monthly:
        //             return common.dateTimeLibs.MakeDate(1, onDateTime.Month, onDateTime.Year);
        //        case AppTypes.timeScales.Yearly:
        //             return common.dateTimeLibs.MakeDate(1, 1, onDateTime.Year);
        //        default:
        //            common.system.ThrowException("Invalid argument in AggregateDateTime()");
        //            break;
        //    }
        //    return onDateTime;
        //}

        /// <summary>
        /// Agrregate a data row to hourly,daily data...
        /// </summary>
        /// <param name="priceRow"> source data arregated to [toSumTbl] </param>
        /// <param name="changeVolume"> volume qty changed and is cumulated to total volume </param>
        /// <param name="timeScale"> aggregate to hour,day,week... data </param>
        /// <param name="cultureInfo"> culture info that need to caculate the start of the week param>
        /// <param name="toSumTbl"> destination table</param>
        public static void AggregatePriceData(data.baseDS.priceDataRow priceRow, decimal changeVolume, AppTypes.TimeScale timeScale, 
                                              CultureInfo cultureInfo,data.baseDS.priceDataSumDataTable toSumTbl)
        {
            DateTime dataDate = AggregateDateTime(timeScale, priceRow.onDate, cultureInfo);
            int dataTimeOffset = common.dateTimeLibs.DateDiffInMilliseconds(dataDate, priceRow.onDate);

            data.baseDS.priceDataSumRow priceDataSumRow;
            priceDataSumRow = libs.FindAndCache(toSumTbl, priceRow.stockCode, timeScale.Code, dataDate);
            if (priceDataSumRow == null)
            {
                priceDataSumRow = toSumTbl.NewpriceDataSumRow();
                commonClass.AppLibs.InitData(priceDataSumRow);
                priceDataSumRow.type = timeScale.Code;
                priceDataSumRow.stockCode = priceRow.stockCode;
                priceDataSumRow.onDate = dataDate;
                priceDataSumRow.openPrice = priceRow.openPrice;
                priceDataSumRow.closePrice = priceRow.closePrice;
                toSumTbl.AddpriceDataSumRow(priceDataSumRow);
            }
            if (priceDataSumRow.openTimeOffset > dataTimeOffset)
            {
                priceDataSumRow.openPrice = priceRow.openPrice;
                priceDataSumRow.openTimeOffset = dataTimeOffset;
            }
            if (priceDataSumRow.closeTimeOffset <= dataTimeOffset)
            {
                priceDataSumRow.closePrice = priceRow.closePrice;
                priceDataSumRow.closeTimeOffset = dataTimeOffset;
            }
            if (priceDataSumRow.highPrice < priceRow.highPrice) priceDataSumRow.highPrice = priceRow.highPrice;
            if (priceDataSumRow.lowPrice > priceRow.lowPrice) priceDataSumRow.lowPrice = priceRow.lowPrice;
            priceDataSumRow.volume += changeVolume;
        }
        // Set [dataIsDailyPrice] = true if [priceTbl] contains all day data (not a real time data.

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
        public static void AggregatePriceData(data.baseDS.priceDataDataTable priceTbl,  CultureInfo cultureInfo,
                                              OnAggregateData onAggregateDataFunc)
        {
            data.baseDS.priceDataSumDataTable priceSumDataTbl = new data.baseDS.priceDataSumDataTable();
            agrregateStat myAgrregateStat = new agrregateStat();
            myAgrregateStat.maxCount = priceTbl.Count;
            priceTbl.DefaultView.Sort = priceTbl.onDateColumn.ColumnName + "," + priceTbl.stockCodeColumn.ColumnName;
            data.baseDS.priceDataRow priceDataRow;
            
            decimal changeVolume;
            int lastYear = int.MinValue;
            for (int idx = 0; idx < priceTbl.DefaultView.Count; idx++)
            {
                priceDataRow = (data.baseDS.priceDataRow)priceTbl.DefaultView[idx].Row; 
                myAgrregateStat.count = idx;
                if (onAggregateDataFunc != null) onAggregateDataFunc(myAgrregateStat);
                if (myAgrregateStat.cancel)
                {
                    priceSumDataTbl.Clear();
                    break;
                }
                changeVolume = priceDataRow.volume;
                foreach (AppTypes.TimeScale timeScale in AppTypes.myTimeScales)
                {
                    if (timeScale.Type == AppTypes.TimeScaleTypes.RealTime) continue; 
                    AggregatePriceData(priceDataRow, changeVolume, timeScale, cultureInfo, priceSumDataTbl);
                    Application.DoEvents();
                }
                //Update and clear cache to speed up the performance
                if (lastYear != priceDataRow.onDate.Year)
                {
                    application.DbAccess.UpdateData(priceSumDataTbl);
                    priceSumDataTbl.Clear();
                    lastYear = priceDataRow.onDate.Year;
                }
            }
            application.DbAccess.UpdateData(priceSumDataTbl);
        }
    }
}
