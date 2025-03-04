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
using HtmlAgilityPack;
using System.Linq;
using commonClass;

namespace imports
{
    public class stock
    {
        public static bool ImportOHLCV_CSV(string csvFileName,string stockExchangeForNewCode,
                                           data.baseDS.priceDataDataTable priceDataTbl,
                                           libs.OnUpdatePriceData onUpdateDataFunc)
        {

            return libs.ImportOHLCV_CSV(csvFileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDD,
                                        stockExchangeForNewCode,libs.CultureInfoVN,
                                        priceDataTbl, DoImportRow, onUpdateDataFunc, null);

        }
        static DateTime tmpDate = common.Consts.constNullDate;
        static double tmpVal = 0;
        private static libs.importOHLCV DoImportRow(LumenWorks.Framework.IO.Csv.CsvReader csv, libs.importStat importStat)
        {
            libs.importOHLCV data = new libs.importOHLCV();
            if (csv[0] == null) return null;
            data.code = csv[0];

            if (!common.dateTimeLibs.Str2Date(csv[1], importStat.dateFormat, out tmpDate)) return null;
            data.dateTime = tmpDate;

            if (!double.TryParse(csv[2], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Open = tmpVal;

            if (!double.TryParse(csv[3], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.High = tmpVal;

            if (!double.TryParse(csv[4], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Low = tmpVal;

            if (!double.TryParse(csv[5], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Close = tmpVal;

            if (!double.TryParse(csv[6], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Volume = tmpVal;
            return data;
        }
        

        //The structure of webpage containing price data, see http://online.mhbs.vn/quote/hose.aspx for an example
        private class importPriceMeta
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
            meta.noRowIgnore = 0;
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
            meta.noRowIgnore = 0;
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
        private static common.extSortedList CreateMapping(importPriceMeta meta, data.importDS.importPriceDataTable dataTbl)
        {
            common.extSortedList list = new common.extSortedList();
            //list.Add(meta.sellPrice1ColId.ToString(), dataTbl.sellPrice1Column.ColumnName);
            //list.Add(meta.sellPrice2ColId.ToString(), dataTbl.sellPrice2Column.ColumnName);
            //list.Add(meta.sellPrice3ColId.ToString(), dataTbl.sellPrice3Column.ColumnName);

            //list.Add(meta.sellVolume1ColId.ToString(), dataTbl.sellVolume1Column.ColumnName);
            //list.Add(meta.sellVolume2ColId.ToString(), dataTbl.sellVolume2Column.ColumnName);
            //list.Add(meta.sellVolume3ColId.ToString(), dataTbl.sellVolume3Column.ColumnName);

            //list.Add(meta.buyPrice1ColId.ToString(), dataTbl.buyPrice1Column.ColumnName);
            //list.Add(meta.buyPrice2ColId.ToString(), dataTbl.buyPrice2Column.ColumnName);
            //list.Add(meta.buyPrice3ColId.ToString(), dataTbl.buyPrice3Column.ColumnName);

            //list.Add(meta.buyVolume1ColId.ToString(), dataTbl.buyVolume1Column.ColumnName);
            //list.Add(meta.buyVolume2ColId.ToString(), dataTbl.buyVolume2Column.ColumnName);
            //list.Add(meta.buyVolume3ColId.ToString(), dataTbl.buyVolume3Column.ColumnName);

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
        private static data.importDS.importPriceDataTable GetPriceFromURL(DateTime updateTime, string url, importPriceMeta priceMeta, string marketCode)
        {
            data.importDS.importPriceDataTable importPriceTbl = new data.importDS.importPriceDataTable();
            common.extSortedList mappingList = CreateMapping(priceMeta, importPriceTbl);

            data.baseDS.priceDataRow priceDataRow;

            // Get the URL specified
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);

            // Get <a> tags that have a href attribute and non-whitespace inner text
            var linksOnPage = from item in document.DocumentNode.Descendants()
                              where item.Name == "td" && item.Attributes["id"] == null
                              select new
                              {
                                  Text = item.InnerText
                              };

            bool fError = false;
            int igmoreRowCount = 0, columnCount = 0;
            decimal val = 0;
            data.importDS.importPriceRow importRow = null;
            string stockCode;
            foreach (var item in linksOnPage)
            {
                //Check whether to ignore some items at the first
                if (++igmoreRowCount <= priceMeta.noRowIgnore) continue;
                if (fError) break;

                if (columnCount == priceMeta.startAtColId)
                {
                    stockCode = item.Text.Trim();
                    importRow = importPriceTbl.NewimportPriceRow();
                    application.DbAccess.InitData(importRow);
                    importRow.onDate = updateTime;
                    importRow.stockCode = stockCode;
                    importRow.stockExchange = marketCode;
                    importRow.isTotalVolume = true;
                    columnCount++;
                    continue;
                }
                //Last column
                if (columnCount == priceMeta.endAtColId)
                {
                    if (importRow.closePrice > 0)
                    {
                        if (importRow.openPrice == 0)
                        {
                            priceDataRow = application.DbAccess.GetLastPriceData(importRow.stockCode);
                            if (priceDataRow == null) importRow.openPrice = importRow.lowPrice;
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
                    val = 0; common.system.StrToDecimal(item.Text, libs.CultureInfoUS, out val);
                    importRow[(string)obj] = val;
                }
                columnCount++;
            }
            return importPriceTbl;
        }
        private static data.importDS.importPriceDataTable GetPriceFromURL(DateTime updateTime, string url, string stockExchangeCode)
        {
            importPriceMeta meta = (stockExchangeCode == "HOSE" ? metaHOSE() : metaHASTC());
            return GetPriceFromURL(updateTime, url, meta, stockExchangeCode);
        }
        public static void ImportPrice_URL(DateTime updateTime, string url, string stockExchangeCode)
        {
            data.importDS.importPriceDataTable importPriceTbl = GetPriceFromURL(updateTime, url, stockExchangeCode);
            libs.AddNewCode(importPriceTbl, null);
            application.DbAccess.UpdateData(importPriceTbl);

            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();
            libs.AddImportPrice(importPriceTbl, priceTbl);
            application.DbAccess.UpdateData(priceTbl);
            // In VN culture : start of week is Monday (not Sunday) 
            libs.AggregatePriceData(priceTbl, libs.CultureInfoVN, null);
        }
    }
   
}
