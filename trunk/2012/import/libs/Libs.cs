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
using commonTypes;
using commonClass;

namespace Imports
{
    public class Libs
    {
        public static void ReAggregatePriceData(string code,CultureInfo stockCulture)
        {
            //Load main  pricedata
            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            databases.DbAccess.LoadData(priceTbl, AppTypes.MainDataTimeScale.Code, DateTime.MinValue, DateTime.MaxValue, code);
            if (priceTbl == null) return;
            //Delete all summ pricedata
            databases.DbAccess.DeletePriceSumData(code);
            AggregatePriceData(priceTbl, stockCulture, null);
        }

        //Use the idea from http://www.codeproject.com/KB/database/CsvReader.aspx by Sebastien Lorion 
        public static bool CSV_ImportParse(string csvFileName, char delimiter, common.dateTimeLibs.DateTimeFormats dataDateFormat,
                                           string marketCode, CultureInfo culture,
                                           databases.baseDS.priceDataDataTable priceDataTbl,
                                           ImportRowHandler ImportRowFunc,
                                           OnUpdatePriceData onUpdateDataFunc,
                                           OnEndImportPriceData onEndImportFunc)
        {
            importStat myImportStat = new importStat();
            myImportStat.Reset();
            myImportStat.dateFormat = dataDateFormat;
            myImportStat.culture = culture;
            databases.baseDS.stockCodeDataTable stockCodeTbl = new databases.baseDS.stockCodeDataTable();
            databases.baseDS.priceDataRow priceDataRow;

            DataRowView[] foundRows;
            databases.DbAccess.LoadData(stockCodeTbl, AppTypes.CommonStatus.Enable);
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
                        Imports.Libs.AddNewCode(data.code, marketCode, stockCodeTbl);
                        databases.DbAccess.UpdateData(stockCodeTbl);
                    }

                    // Ignore all data that was in database
                    //if (!foundLastPriceDate)
                    //{
                    //    lastPriceDate = FindLastPriceDate(data.code);
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
                    databases.AppLibs.InitData(priceDataRow);
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



        //Detect new stockCode and create new one
        public static void AddNewCode(string market, databases.importDS.importPriceDataTable tbl, OnAddData onAddstockCodeFunc)
        {
            databases.baseDS.stockCodeDataTable stockCodeTbl = new databases.baseDS.stockCodeDataTable();
            for (int count = 0; count < tbl.Count; count++)
            {
                if (tbl[count].RowState == DataRowState.Deleted) continue;
                if (AddNewCode(tbl[count].stockCode, market, stockCodeTbl) != null &&
                    onAddstockCodeFunc != null) onAddstockCodeFunc(tbl[count].stockCode);
            }
            databases.DbAccess.UpdateData(stockCodeTbl);
        }
        public static void AddNewCode(databases.importDS.importPriceDataTable tbl, OnAddData onAddstockCodeFunc)
        {
            databases.tmpDS.stockCodeRow shortCodeRow;
            databases.baseDS.stockCodeDataTable stockCodeTbl = new databases.baseDS.stockCodeDataTable();
            for (int count = 0; count < tbl.Count; count++)
            {
                if (tbl[count].RowState == DataRowState.Deleted) continue;
                shortCodeRow = databases.AppLibs.FindAndCache_StockCodeShort(tbl[count].stockCode);
                if (shortCodeRow == null) continue;

                if (AddNewCode(tbl[count].stockCode, shortCodeRow.stockExchange, stockCodeTbl) != null &&
                    onAddstockCodeFunc != null) onAddstockCodeFunc(tbl[count].stockCode);
            }
            databases.DbAccess.UpdateData(stockCodeTbl);
        }

        public static void AddNewCode(databases.baseDS.priceDataDataTable tbl, string stockEchangeCode, OnAddData onAddstockCodeFunc)
        {
            databases.baseDS.stockCodeDataTable stockCodeTbl = new databases.baseDS.stockCodeDataTable();
            for (int count = 0; count < tbl.Count; count++)
            {
                if (tbl[count].RowState == DataRowState.Deleted) continue;
                if (AddNewCode(tbl[count].stockCode, stockEchangeCode, stockCodeTbl) != null &&
                    onAddstockCodeFunc != null)
                    onAddstockCodeFunc(tbl[count].stockCode);
            }
            databases.DbAccess.UpdateData(stockCodeTbl);
        }
        public static databases.baseDS.stockCodeRow AddNewCode(string comCode, string stockEchangeCode,
                                                               databases.baseDS.stockCodeDataTable toStockCodeTbl)
        {
            databases.baseDS.stockCodeRow stockCodeRow;
            stockCodeRow = application.SysLibs.FindAndCache(toStockCodeTbl, comCode);
            if (stockCodeRow == null)
            {
                stockCodeRow = toStockCodeTbl.NewstockCodeRow();
                databases.AppLibs.InitData(stockCodeRow);
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

        // string(0001 Oil & Gas) ->  (0001,Oil & Gas)
        public static common.myKeyValueItem SplitKeyValue(string str,string separator)
        {
            int pos = str.IndexOf(separator);
            if (pos <= 0) return null;
            return new common.myKeyValueItem(str.Substring(0, pos).Trim(), str.Substring(pos + 1).Trim());
        }


        public static void Reset()
        {
            myDailyData.Reset();
        }
        // myDailyPrice is used to get transaction volume data from total daily volume data
        public class DailyData
        {
            DateTime lastTime = DateTime.Today;
            string timeType = "D1";
            databases.baseDS.priceDataSumDataTable priceSumTbl = new databases.baseDS.priceDataSumDataTable();
            public void UpdateData(databases.importDS.importPriceRow row)
            {
                if (lastTime != row.onDate.Date)
                {
                    Reset();
                    lastTime = row.onDate.Date;
                }
                databases.baseDS.priceDataSumRow priceRow = GetData(row);
                if (priceRow == null)
                {
                    priceRow = priceSumTbl.NewpriceDataSumRow();
                    databases.AppLibs.InitData(priceRow);
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
            public databases.baseDS.priceDataSumRow GetData(databases.importDS.importPriceRow row)
            {
                return FindAndCache(priceSumTbl, row.stockCode, timeType, row.onDate.Date);
            }
            public databases.baseDS.priceDataSumRow GetData(string stockCode,DateTime onDate)
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

        // Keep last imported data by day
        private static DailyData myDailyData = new DailyData();
        // importPrice->priceData
        private static void AddImportPrice(databases.importDS.importPriceDataTable importPriceTbl,
                                           DailyData dailyPrice, databases.baseDS.priceDataDataTable priceDataTbl)
        {
            databases.baseDS.priceDataSumRow dailyPriceRow;
            databases.baseDS.priceDataRow priceDataRow;
            decimal volume = 0;
            for (int idx = 0; idx < importPriceTbl.Count; idx++)
            {
                //Invalid price, ignore
                if (importPriceTbl[idx].closePrice <= 0) continue;

                volume = importPriceTbl[idx].volume;
                // If this is total volume then minus the last volume to get the real volume in the period
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
                databases.AppLibs.InitData(priceDataRow);
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
        public static void AddImportPrice(databases.importDS.importPriceDataTable importPriceTbl,
                                          databases.baseDS.priceDataDataTable priceDataTbl)
        {
            AddImportPrice(importPriceTbl, myDailyData, priceDataTbl);
        }


        // Maybe there are someting wrong with price importing, 
        // use ReImportPricedata to add [importPrice] to [priceData,priceDataSum]
        public static void ReImportPricedata(DateTime frDate, DateTime toDate, string stockCode, CultureInfo culture)
        {
            databases.importDS myImportDS = new databases.importDS();
            databases.importDSTableAdapters.importPriceTA importPriceTA = new databases.importDSTableAdapters.importPriceTA();

            if (stockCode.Trim() == "") importPriceTA.FillByDate(myImportDS.importPrice, frDate, toDate);
            else importPriceTA.FillByDateAndCode(myImportDS.importPrice, frDate, toDate, stockCode);
            AddNewCode(myImportDS.importPrice, null);
            databases.DbAccess.UpdateData(myImportDS.importPrice);

            databases.baseDS myBaseDS = new databases.baseDS();
            AddImportPrice(myImportDS.importPrice, new DailyData(), myBaseDS.priceData);
            databases.DbAccess.UpdateData(myBaseDS.priceData);
            // In VN culture : start of week is Monday (not Sunday) 
            AggregatePriceData(myBaseDS.priceData, culture, null);
        }
        
        // Stock Exchange
        public static databases.baseDS.stockExchangeRow AddStockExchange(databases.baseDS.stockExchangeDataTable tbl, string code)
        {
            databases.baseDS.stockExchangeRow stockExchangeRow = application.SysLibs.FindAndCache_StockExchange(code);
            if (stockExchangeRow == null)
            {
                stockExchangeRow = tbl.NewstockExchangeRow();
                databases.AppLibs.InitData(stockExchangeRow);
                stockExchangeRow.code = code;
                tbl.AddstockExchangeRow(stockExchangeRow);
                databases.DbAccess.UpdateData(stockExchangeRow);
                common.SysLog.WriteLog(" - Add stockExchange" + common.Consts.constTab + code);
            }
            return stockExchangeRow;
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

        /// <summary>
        /// Agrregate a data row to hourly,daily data...
        /// </summary>
        /// <param name="priceRow"> source data arregated to [toSumTbl] </param>
        /// <param name="changeVolume"> volume qty changed and is cumulated to total volume </param>
        /// <param name="timeScale"> aggregate to hour,day,week... data </param>
        /// <param name="cultureInfo"> culture info that need to caculate the start of the week param>
        /// <param name="toSumTbl"> destination table</param>
        public static void AggregatePriceData(databases.baseDS.priceDataRow priceRow, decimal changeVolume, AppTypes.TimeScale timeScale, 
                                              CultureInfo cultureInfo,databases.baseDS.priceDataSumDataTable toSumTbl)
        {
            DateTime dataDate = AggregateDateTime(timeScale, priceRow.onDate, cultureInfo);
            int dataTimeOffset = common.dateTimeLibs.DateDiffInMilliseconds(dataDate, priceRow.onDate);

            databases.baseDS.priceDataSumRow priceDataSumRow;
            priceDataSumRow = FindAndCache(toSumTbl, priceRow.stockCode, timeScale.Code, dataDate);
            if (priceDataSumRow == null)
            {
                priceDataSumRow = toSumTbl.NewpriceDataSumRow();
                databases.AppLibs.InitData(priceDataSumRow);
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
        public static void AggregatePriceData(databases.baseDS.priceDataDataTable priceTbl,  CultureInfo cultureInfo,
                                              OnAggregateData onAggregateDataFunc)
        {
            databases.baseDS.priceDataSumDataTable priceSumDataTbl = new databases.baseDS.priceDataSumDataTable();
            agrregateStat myAgrregateStat = new agrregateStat();
            myAgrregateStat.maxCount = priceTbl.Count;
            priceTbl.DefaultView.Sort = priceTbl.onDateColumn.ColumnName + "," + priceTbl.stockCodeColumn.ColumnName;
            databases.baseDS.priceDataRow priceDataRow;
            
            decimal changeVolume;
            int lastYear = int.MinValue;
            for (int idx = 0; idx < priceTbl.DefaultView.Count; idx++)
            {
                priceDataRow = (databases.baseDS.priceDataRow)priceTbl.DefaultView[idx].Row; 
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
                    databases.DbAccess.UpdateData(priceSumDataTbl);
                    priceSumDataTbl.Clear();
                    lastYear = priceDataRow.onDate.Year;
                }
            }
            databases.DbAccess.UpdateData(priceSumDataTbl);
        }
    }
}
