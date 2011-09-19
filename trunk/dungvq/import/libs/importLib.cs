using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using HtmlAgilityPack;
using System.Linq;
using application;

namespace imports
{
    public class libs
    {
        #region general funcs
        // string(0001 Oil & Gas) ->  (0001,Oil & Gas)
        public static common.myKeyValueItem GetKeyValue(string str)
        {
            int pos = str.IndexOf(' ');
            if (pos <= 0) return null;
            return new common.myKeyValueItem(str.Substring(0, pos).Trim(), str.Substring(pos + 1).Trim());
        }

        //Return common.Consts.constNullDate if not found
        private static DateTime FindLastUpdatePricedata(string stockCode)
        {
            int noToTry = 100;
            data.baseDS.priceDataDataTable priceDataTbl = new data.baseDS.priceDataDataTable();
            DateTime eDate = sysLibs.GetServerDateTime();
            DateTime sDate = eDate.AddDays(-1);
            while (noToTry > 0)
            {
                priceDataTbl.Clear();
                dataLibs.LoadDataOneRow(priceDataTbl, sDate, eDate, stockCode);
                if (priceDataTbl.Count > 0)
                {
                    eDate = priceDataTbl[0].onDate;
                    return eDate;
                }
                eDate = eDate.AddDays(-1);
                sDate = eDate.AddDays(-1);
                noToTry--;
            }
            return common.Consts.constNullDate;
        }

        public delegate void onAggregateData(agrregateStat stat);
        public delegate void onGotData(importStat stat);
        public delegate void onUpdatePriceData(data.baseDS.priceDataRow row);
        public delegate void onAddData(string code);
        public delegate void onEndImportPriceData(data.baseDS.priceDataDataTable tbl);
        public enum processAction : byte { None = 0, Ignore = 1, Added = 2, Error = 3 };
        public class importStat
        {
            public bool cancel = false;
            public processAction actions = processAction.None;
            public DateTime minUpdateDate = DateTime.MaxValue;
            public DateTime maxUpdateDate = DateTime.MinValue;
            public int dataCount = 0, updateCount = 0, errorCount = 0;
            public void Reset()
            {
                cancel = false;
                actions = processAction.None;

                dataCount = 0;
                updateCount = 0;
                errorCount = 0;
                minUpdateDate = DateTime.MaxValue;
                maxUpdateDate = DateTime.MinValue;
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

        //Use the idea from http://www.codeproject.com/KB/database/CsvReader.aspx by Sebastien Lorion 
        public static bool ImportPricedata_CSV(string csvFileName,common.dateTimeLibs.DateTimeFormats dataDateFormat, string stockExchangeForNewCode, string cultureCode,
                                               data.baseDS.priceDataDataTable priceDataTbl,
                                               onGotData onGotDataFunc, onUpdatePriceData onUpdateDataFunc, onEndImportPriceData onEndImportFunc)
        {
            importStat myImportStat = new importStat();
            myImportStat.Reset();
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            data.baseDS.priceDataRow priceDataRow;
            data.baseDS.stockCodeRow stockCodeRow;

            DataRowView[] foundRows;
            dataLibs.LoadData(stockCodeTbl, application.AppTypes.CommonStatus.Enable);
            DataView stockCodeView = new DataView(stockCodeTbl);
            stockCodeView.Sort = stockCodeTbl.codeColumn.ColumnName;

            //<Ticker>,<DTYYYYMMDD>,<Open>,<High>,<Low>,<Close>,<Volume>
            decimal openPrice = 0, highPrice = 0, lowPrice = 0, closePrice = 0,volume = 0;
            bool fError = false;
            DateTime onDate = DateTime.Today;
            CultureInfo dateCultureInfo = new CultureInfo(cultureCode);

            bool fCanceled = false;
            bool foundLastPriceDate = false;
            DateTime lastPriceDate = common.Consts.constNullDate;

            // open the file "data.csv" which is a CSV file with headers
            using (CsvReader csv = new CsvReader(new StreamReader(csvFileName), true))
            {
                // missing fields will not throw an exception,
                // but will instead be treated as if there was a null value
                csv.MissingFieldAction = MissingFieldAction.ReplaceByNull;

                int fieldCount = csv.FieldCount;
                if (fieldCount != 7) return false;
                while (csv.ReadNextRecord())
                {
                    Application.DoEvents();
                    myImportStat.dataCount++;

                    if (csv[0] == null) fError = false;
                    if (csv[1] == null || !common.dateTimeLibs.Str2Date(csv[1],dataDateFormat, out onDate)) fError = true;
                    if (csv[2] == null || !Decimal.TryParse(csv[2], NumberStyles.Number, dateCultureInfo, out openPrice)) fError = true;
                    if (csv[3] == null || !Decimal.TryParse(csv[3], NumberStyles.Number, dateCultureInfo, out highPrice)) fError = true;
                    if (csv[4] == null || !Decimal.TryParse(csv[4], NumberStyles.Number, dateCultureInfo, out lowPrice)) fError = true;
                    if (csv[5] == null || !Decimal.TryParse(csv[5], NumberStyles.Number, dateCultureInfo, out closePrice)) fError = true;
                    if (csv[6] == null || !Decimal.TryParse(csv[6], NumberStyles.Number, dateCultureInfo, out volume)) fError = true;
                    if (fError)
                    {
                        myImportStat.errorCount++;
                        if (onGotDataFunc != null)
                        {
                            myImportStat.actions = processAction.Error;
                            onGotDataFunc(myImportStat);
                            if (myImportStat.cancel)
                            {
                                fCanceled = true; break;
                            }
                        }
                        continue;
                    }
                    foundRows = stockCodeView.FindRows(csv[0]);
                    if (foundRows.Length == 0)
                    {
                        //Try to add new stock code
                        AddNewStockCode(csv[0], stockExchangeForNewCode, stockCodeTbl);
                        dataLibs.UpdateData(stockCodeTbl);
                        dataLibs.UpdateData(stockCodeTbl);

                        foundRows = stockCodeView.FindRows(csv[0]);
                        if (foundRows.Length == 0)
                        {
                            if (onGotDataFunc != null)
                            {
                                myImportStat.actions = processAction.Error;
                                onGotDataFunc(myImportStat);
                                if (myImportStat.cancel)
                                {
                                    fCanceled = true; break;
                                }
                            }
                            continue;
                        }
                    }
                    stockCodeRow = (data.baseDS.stockCodeRow)foundRows[0].Row;

                    // Ignore all data that was in database
                    if (!foundLastPriceDate)
                    {
                        lastPriceDate = FindLastUpdatePricedata(stockCodeRow.code);
                        foundLastPriceDate = true;
                    }
                    if (lastPriceDate != common.Consts.constNullDate && onDate <= lastPriceDate)
                    {
                        if (onGotDataFunc != null)
                        {
                            myImportStat.actions = processAction.Ignore;
                            onGotDataFunc(myImportStat);
                            if (myImportStat.cancel)
                            {
                                fCanceled = true; break;
                            }
                        }
                        continue;
                    }

                    if (priceDataTbl.FindBystockCodeonDate(stockCodeRow.code, onDate) != null)
                    {
                        myImportStat.errorCount++;
                        if (onGotDataFunc != null)
                        {
                            myImportStat.actions = processAction.Error;
                            onGotDataFunc(myImportStat);
                            if (myImportStat.cancel)
                            {
                                fCanceled = true; break;
                            }
                        }
                        continue;
                    }
                    myImportStat.updateCount++;
                    priceDataRow = priceDataTbl.NewpriceDataRow();
                    dataLibs.InitData(priceDataRow);
                    priceDataRow.stockCode = stockCodeRow.code;
                    priceDataRow.onDate = onDate;
                    priceDataRow.openPrice = (openPrice > 0 ? openPrice : lowPrice); //Some error in data
                    priceDataRow.highPrice = highPrice;
                    priceDataRow.lowPrice = lowPrice;
                    priceDataRow.closePrice = closePrice;
                    priceDataRow.volume = volume;
                    priceDataTbl.AddpriceDataRow(priceDataRow);
                    if (onGotDataFunc != null)
                    {
                        myImportStat.actions = processAction.Added;
                        onGotDataFunc(myImportStat);
                        if (myImportStat.cancel)
                        {
                            fCanceled = true; break;
                        }
                    }
                    if (onUpdateDataFunc != null) onUpdateDataFunc(priceDataRow);
                    if (myImportStat.minUpdateDate > onDate) myImportStat.minUpdateDate = onDate;
                    if (myImportStat.maxUpdateDate < onDate) myImportStat.maxUpdateDate = onDate;
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

        //The structure of webpage containing price data, see http://online.mhbs.vn/quote/hose.aspx for an example
        public class importPriceMeta
        {
            public short noRowIgnore = 31;

            public short startAtColId = 0, endAtColId = 25;

            public short buyPrice3ColId = 6, buyVolume3ColId = 7;
            public short buyPrice2ColId = 8, buyVolume2ColId = 9;
            public short buyPrice1ColId = 10, buyVolume1ColId = 11;

            public short openPriceColId = 21, highPriceColId = 22, lowPriceColId = 23, closePriceColId = 12, volumeColId = 13;

            public short sellPrice1ColId = 15, sellVolume1ColId = 16;
            public short sellPrice2ColId = 17, sellVolume2ColId = 18;
            public short sellPrice3ColId = 19, sellVolume3ColId = 20;
        }

        private static importPriceMeta metaHOSE()
        {
            importPriceMeta meta = new importPriceMeta();
            meta.noRowIgnore = 31;
            meta.startAtColId = 0;
            meta.endAtColId = 25;

            meta.buyPrice3ColId = 6;
            meta.buyVolume3ColId = 7;
            meta.buyPrice2ColId = 8;
            meta.buyVolume2ColId = 9;
            meta.buyPrice1ColId = 10;
            meta.buyVolume1ColId = 11;

            meta.openPriceColId = 21;
            meta.highPriceColId = 22;
            meta.lowPriceColId = 23;
            meta.closePriceColId = 12;
            meta.volumeColId = 13;

            meta.sellPrice1ColId = 15;
            meta.sellVolume1ColId = 16;
            meta.sellPrice2ColId = 17;
            meta.sellVolume2ColId = 18;
            meta.sellPrice3ColId = 19;
            meta.sellVolume3ColId = 20;
            return meta;
        }
        private static importPriceMeta metaHASTC()
        {
            importPriceMeta meta = new importPriceMeta();
            meta.noRowIgnore = 31;
            meta.startAtColId = 0;
            meta.endAtColId = 25;

            meta.buyPrice3ColId = 6;
            meta.buyVolume3ColId = 7;
            meta.buyPrice2ColId = 8;
            meta.buyVolume2ColId = 9;
            meta.buyPrice1ColId = 10;
            meta.buyVolume1ColId = 11;

            meta.openPriceColId = -1;
            meta.highPriceColId = 21;
            meta.lowPriceColId = 22;

            meta.closePriceColId = 12;
            meta.volumeColId = 13;

            meta.sellPrice1ColId = 15;
            meta.sellVolume1ColId = 16;
            meta.sellPrice2ColId = 17;
            meta.sellVolume2ColId = 18;
            meta.sellPrice3ColId = 19;
            meta.sellVolume3ColId = 20;
            return meta;
        }

        // Return common.extSortedList that store the mapping [Column in web page] -> [importPrice column]
        public static common.extSortedList CreateMapping(importPriceMeta meta, data.importDS.importPriceDataTable dataTbl)
        {
            common.extSortedList list = new common.extSortedList();
            list.Add(meta.sellPrice1ColId.ToString(), dataTbl.sellPrice1Column.ColumnName);
            list.Add(meta.sellPrice2ColId.ToString(), dataTbl.sellPrice2Column.ColumnName);
            list.Add(meta.sellPrice3ColId.ToString(), dataTbl.sellPrice3Column.ColumnName);

            list.Add(meta.sellVolume1ColId.ToString(), dataTbl.sellVolume1Column.ColumnName);
            list.Add(meta.sellVolume2ColId.ToString(), dataTbl.sellVolume2Column.ColumnName);
            list.Add(meta.sellVolume3ColId.ToString(), dataTbl.sellVolume3Column.ColumnName);

            list.Add(meta.buyPrice1ColId.ToString(), dataTbl.buyPrice1Column.ColumnName);
            list.Add(meta.buyPrice2ColId.ToString(), dataTbl.buyPrice2Column.ColumnName);
            list.Add(meta.buyPrice3ColId.ToString(), dataTbl.buyPrice3Column.ColumnName);

            list.Add(meta.buyVolume1ColId.ToString(), dataTbl.buyVolume1Column.ColumnName);
            list.Add(meta.buyVolume2ColId.ToString(), dataTbl.buyVolume2Column.ColumnName);
            list.Add(meta.buyVolume3ColId.ToString(), dataTbl.buyVolume3Column.ColumnName);

            list.Add(meta.openPriceColId.ToString(), dataTbl.openPriceColumn.ColumnName);
            list.Add(meta.highPriceColId.ToString(), dataTbl.highPriceColumn.ColumnName);
            list.Add(meta.lowPriceColId.ToString(), dataTbl.lowPriceColumn.ColumnName);
            list.Add(meta.closePriceColId.ToString(), dataTbl.closePriceColumn.ColumnName);
            list.Add(meta.volumeColId.ToString(), dataTbl.volumeColumn.ColumnName);
            return list;
        }

        /// <summary>
        /// Import data from URL to tables : importPrice 
        /// The function also detect and add new companies to the database
        /// </summary>
        /// <param name="url">URL to get data</param>
        /// <param name="priceMeta">meta describe the webpage structure</param>
        /// <param name="stockExchangeCode">stock exchange code of imported data </param>
        /// <param name="importPriceTbl"> where to store imported data </param>
        public static void ImportPricedata_URL(string url,importPriceMeta priceMeta,
                                               string stockExchangeCode,data.importDS.importPriceDataTable importPriceTbl)
        {
            DateTime curTime = application.sysLibs.GetServerDateTime();
            DateTime lastPriceDate = curTime.Date.AddMinutes(-1);

            common.extSortedList mappingList = CreateMapping(priceMeta, importPriceTbl);

            data.baseDS.priceDataRow priceDataRow;
            CultureInfo cultureInfo = new CultureInfo("en-US");
            
            // Get the URL specified
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);

            // Get <a> tags that have a href attribute and non-whitespace inner text
            var linksOnPage = from td in document.DocumentNode.Descendants()
                              where td.Name == "td" && td.Attributes["id"] == null
                              select new
                              {
                                  Text = td.InnerText
                              };

            bool fError = false;
            int igmoreRowCount = 0, columnCount = 0;
            decimal val = 0;
            data.importDS.importPriceRow importRow = null;
            string stockCode;
            foreach (var item in linksOnPage)
            {
                //Ignore the first 31 items
                if (++igmoreRowCount <= priceMeta.noRowIgnore) continue;
                if (fError) break;

                if (columnCount==priceMeta.startAtColId)
                {
                    stockCode = item.Text.Trim();
                    importRow = importPriceTbl.NewimportPriceRow();
                    dataLibs.InitData(importRow);
                    importRow.onDate = curTime;
                    importRow.stockCode = stockCode;
                    importRow.stockExchange = stockExchangeCode;
                    columnCount++;
                    continue;
                }
                //Last colume
                if (columnCount==priceMeta.endAtColId)
                {
                    if (importRow.closePrice > 0)
                    {
                        if (importRow.openPrice == 0)
                        {
                            priceDataRow = application.dataLibs.GetLastPrice(lastPriceDate, importRow.stockCode);
                            if(priceDataRow==null) importRow.openPrice = importRow.lowPrice;
                            else importRow.openPrice = priceDataRow.closePrice;
                        }
                        importPriceTbl.AddimportPriceRow(importRow);
                    }
                    else importRow.CancelEdit();
                    columnCount = 0;
                    continue;
                }
                object obj = mappingList.GetValue(columnCount.ToString());
                if (obj != null)
                {
                    val = 0; common.system.StrToDecimal(item.Text, cultureInfo, out val);
                    importRow[(string)obj] = val;
                }
                columnCount++;
            }
        }
        public static void ImportPricedata_URL(string url, string stockExchangeCode,
                                               data.importDS.importPriceDataTable importPriceTbl)
        {
            importPriceMeta meta = (stockExchangeCode == "HOSE" ? metaHOSE() : metaHASTC());
            ImportPricedata_URL(url, meta, stockExchangeCode, importPriceTbl);
        }

        // importPrice->priceData
        public static void AddImportPrice(data.importDS.importPriceDataTable importPriceTbl, data.baseDS.priceDataDataTable priceDataTbl)
        {
            data.baseDS.priceDataRow priceDataRow;
            for (int idx = 0; idx < importPriceTbl.Count; idx++)
            {
                priceDataRow = priceDataTbl.NewpriceDataRow();
                dataLibs.InitData(priceDataRow);
                priceDataRow.onDate = importPriceTbl[idx].onDate;
                priceDataRow.stockCode = importPriceTbl[idx].stockCode;

                priceDataRow.openPrice = importPriceTbl[idx].openPrice;
                priceDataRow.lowPrice = importPriceTbl[idx].lowPrice;
                priceDataRow.highPrice = importPriceTbl[idx].highPrice;
                priceDataRow.closePrice = importPriceTbl[idx].closePrice;
                priceDataRow.volume = importPriceTbl[idx].volume;
                priceDataTbl.AddpriceDataRow(priceDataRow);
            }
        }
        
        // Stock Exchange
        public static data.baseDS.stockExchangeRow AddStockExchange(data.baseDS.stockExchangeDataTable tbl, string code)
        {
            data.baseDS.stockExchangeRow stockExchangeRow = application.dataLibs.FindAndCache(tbl, code);
            if (stockExchangeRow == null)
            {
                stockExchangeRow = tbl.NewstockExchangeRow();
                application.dataLibs.InitData(stockExchangeRow);
                stockExchangeRow.code = code;
                tbl.AddstockExchangeRow(stockExchangeRow);
                application.dataLibs.UpdateData(stockExchangeRow);
                common.fileFuncs.WriteLog(" - Add stockExchange" + common.Consts.constTab + code);
            }
            return stockExchangeRow;
        }

        //Detect new stockCode and create new one
        public static void AddNewStockCode(data.importDS.importPriceDataTable tbl, onAddData onAddstockCodeFunc)
        {
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            for (int count = 0; count < tbl.Count; count++)
            {
                if (tbl[count].RowState == DataRowState.Deleted) continue;
                if (AddNewStockCode(tbl[count].stockCode, tbl[count].stockExchange, stockCodeTbl)!=null &&
                    onAddstockCodeFunc != null) onAddstockCodeFunc(tbl[count].stockCode);
            }
            dataLibs.UpdateData(stockCodeTbl);
        }
        public static void AddNewStockCode(data.baseDS.priceDataDataTable tbl, string stockEchangeCode, onAddData onAddstockCodeFunc)
        {
            data.baseDS.stockCodeDataTable stockCodeTbl = new data.baseDS.stockCodeDataTable();
            for (int count = 0; count < tbl.Count; count++)
            {
                if (tbl[count].RowState == DataRowState.Deleted) continue;
                if (AddNewStockCode(tbl[count].stockCode, stockEchangeCode, stockCodeTbl)!=null &&
                    onAddstockCodeFunc != null) 
                    onAddstockCodeFunc(tbl[count].stockCode);
            }
            dataLibs.UpdateData(stockCodeTbl);
        }
        public static data.baseDS.stockCodeRow AddNewStockCode(string comCode, string stockEchangeCode,
                                                               data.baseDS.stockCodeDataTable toStockCodeTbl)
        {
            data.baseDS.stockCodeRow stockCodeRow;
            stockCodeRow = dataLibs.FindAndCache(toStockCodeTbl, comCode);
            if (stockCodeRow == null)
            {
                stockCodeRow = toStockCodeTbl.NewstockCodeRow();
                dataLibs.InitData(stockCodeRow);
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

        //For command-line update
        private static void UpdatePriceData(data.baseDS.priceDataDataTable priceDataTbl)
        {
            dataLibs.UpdateData(priceDataTbl);
        }
        public static bool ImportPricedata_CSV(string csvFileName,common.dateTimeLibs.DateTimeFormats dataDateTimeFormat,  string stockExchangeCode, string cultureCode)
        {
            return ImportPricedata_CSV(csvFileName, dataDateTimeFormat, stockExchangeCode, cultureCode, new data.baseDS.priceDataDataTable(), null, null, UpdatePriceData);
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
            short dataTimeOffset = (short)common.dateTimeLibs.DateDiffInMins(dataDate, priceRow.onDate);

            data.baseDS.priceDataSumRow priceDataSumRow;
            priceDataSumRow = dataLibs.FindAndCache(toSumTbl, priceRow.stockCode, timeScale.Code, dataDate);
            if (priceDataSumRow == null)
            {
                priceDataSumRow = toSumTbl.NewpriceDataSumRow();
                dataLibs.InitData(priceDataSumRow);
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
                priceDataSumRow.openTimeOffset = (short)dataTimeOffset;
            }
            if (priceDataSumRow.closeTimeOffset > dataTimeOffset)
            {
                priceDataSumRow.closePrice = priceRow.closePrice;
                priceDataSumRow.closeTimeOffset = (short)dataTimeOffset;
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
        public static void AggregatePriceData(data.baseDS.priceDataDataTable priceTbl, string cultureCode,
                                              bool isDailyPrice, 
                                              onAggregateData onAggregateDataFunc)
        {
            CultureInfo cultureInfo = new CultureInfo(cultureCode);

            // [updateVolumeTbl] keeps last update volume data that used to detect change in daily volume.  
            data.baseDS.updateVolumeDataTable updateVolumeTbl = new data.baseDS.updateVolumeDataTable();
            data.baseDS.updateVolumeRow updateVolumeRow;

            data.baseDS.priceDataSumDataTable priceSumDataTbl = new data.baseDS.priceDataSumDataTable();
            agrregateStat myAgrregateStat = new agrregateStat();
            myAgrregateStat.maxCount = priceTbl.Count;
            priceTbl.DefaultView.Sort = priceTbl.onDateColumn.ColumnName + "," + priceTbl.stockCodeColumn.ColumnName;
            data.baseDS.priceDataRow priceDataRow;
            //First, aggregate realtime data to daily data  and hourly data
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
                    updateVolumeTbl.Clear();
                    break;
                }
                if (isDailyPrice)
                {
                    changeVolume = priceDataRow.volume;
                }
                else
                {
                    updateVolumeRow = dataLibs.FindAndCache(updateVolumeTbl, priceDataRow.stockCode, priceDataRow.onDate.Date);
                    if (updateVolumeRow == null)
                    {
                        updateVolumeRow = updateVolumeTbl.NewupdateVolumeRow();
                        dataLibs.InitData(updateVolumeRow);
                        updateVolumeRow.stockCode = priceDataRow.stockCode;
                        updateVolumeRow.onDate = priceDataRow.onDate.Date;
                        updateVolumeTbl.AddupdateVolumeRow(updateVolumeRow);
                    }
                    changeVolume = priceTbl[idx].volume - updateVolumeRow.volume;
                    updateVolumeRow.volume = priceDataRow.volume;
                }
                foreach (AppTypes.TimeScale timeScale in AppTypes.myTimeScales)
                {
                    if (timeScale.Type == AppTypes.TimeScaleTypes.RealTime) continue; 
                    AggregatePriceData(priceDataRow, changeVolume, timeScale, cultureInfo, priceSumDataTbl);
                    Application.DoEvents();
                }
                //Update and clear cache to speed up the performance
                if (lastYear != priceDataRow.onDate.Year)
                {
                    dataLibs.UpdateData(priceSumDataTbl);
                    dataLibs.UpdateData(updateVolumeTbl);
                    priceSumDataTbl.Clear();
                    updateVolumeTbl.Clear();
                    lastYear = priceDataRow.onDate.Year;
                }
            }
            dataLibs.UpdateData(priceSumDataTbl);
            dataLibs.UpdateData(updateVolumeTbl);
        }

        public static void ImportPricedata_URL(string url, string stockExchangeCode)
        {
            data.importDS myImportDS = new data.importDS();
            libs.ImportPricedata_URL(url, stockExchangeCode, myImportDS.importPrice);
            libs.AddNewStockCode(myImportDS.importPrice, null);
            dataLibs.UpdateData(myImportDS.importPrice);

            data.baseDS myBaseDS = new data.baseDS();
            libs.AddImportPrice(myImportDS.importPrice, myBaseDS.priceData);
            dataLibs.UpdateData(myBaseDS.priceData);
            // In VN culture : start of week is Monday (not Sunday) 
            libs.AggregatePriceData(myBaseDS.priceData, "vi-VN", false, null);
        }
        #endregion general funcs
    }
}
