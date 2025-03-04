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
using commonTypes;
using System.Threading;
using System.Net;

namespace Imports.Stock
{
    //The structure of webpage containing price data, see http://online.mhbs.vn/quote/hose.aspx for an example
    //Tuan add    

    public class metaStock
    {
        public short noRowIgnore = 0;

        public short startAtColId = 0, endAtColId = 0;

        public short openPriceColId = 0, highPriceColId = 0, lowPriceColId = 0, closePriceColId = 0, volumeColId = 0;
    }

    public abstract class stockImport : generalImport
    {
        common.extSortedList mappingList = null;
        public override databases.baseDS.priceDataDataTable GetImportFromCSV(string fileName,string market,OnUpdatePriceData onUpdateDataFunc)
        {
            CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(market);
            databases.baseDS.priceDataDataTable priceDataTbl = new databases.baseDS.priceDataDataTable();
            if (!Imports.Libs.CSV_ImportParse(fileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDD,
                                 market, exchangeCulture, priceDataTbl, Libs.DoImportRow, onUpdateDataFunc, null)) return null;
            return priceDataTbl;
        }
        protected abstract metaStock GetMeta();

        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            try
            {
                databases.importDS.importPriceDataTable importPriceTbl;
                metaStock meta = GetMeta();
                if (meta == null) return null;

                //try
                //{
                    importPriceTbl = GetPriceFromWeb(updateTime, meta, exchangeDetailRow);
                    Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
                    databases.DbAccess.UpdateData(importPriceTbl);
                ////}
                //catch (Exception er)
                //{
                //    commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV004 - Import price error", er);
                //    throw er;
                //}

                //try
                //{
                    databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
                    Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
                    databases.DbAccess.UpdateData(priceTbl);
                    return priceTbl;
                //}
                //catch (Exception er)
                //{
                //    commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV004 - Price Data table", er);
                //    throw er;
                //}
            }

            catch (Exception er)
            {
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV004 - GetImport From Web error", er);
                return null;
            }
            
        }

        /// <summary>
        /// Import data from URL to tables : importPrice 
        /// The function also detect and add new companies to the database
        /// </summary>
        /// <param name="url">URL to get data</param>
        /// <param name="priceMeta">meta describe the webpage structure</param>
        /// <param name="stockExchangeCode">stock exchange code of imported data </param>
        /// <param name="importPriceTbl"> where to store imported data </param>
        public databases.importDS.importPriceDataTable GetPriceFromWeb(DateTime updateTime, metaStock priceMeta,databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            bool bHaveData = false; //Kiem tra xem bang co du lieu hay ko
            //Data in
            CultureInfo CultureInfoUS = common.language.GetCulture("en-US");
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            this.mappingList = CreateMapping(priceMeta, importPriceTbl);

            // Get the URL specified
            var webGet = new HtmlWeb();
            var document = webGet.Load(exchangeDetailRow.address);

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
            databases.importDS.importPriceRow importRow = null;
            databases.importDS.importPriceRow oldImportRow;
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
                    databases.AppLibs.InitData(importRow);
                    importRow.onDate = updateTime;
                    importRow.stockCode = stockCode;
                    importRow.isTotalVolume = true;
                    columnCount++;
                    continue;
                }
                //Last column
                if (columnCount == priceMeta.endAtColId)
                {
                    if (importRow.closePrice > 0)
                    {
                        //Only add new when there are some changes 
                        oldImportRow = lastImportData.Find(importRow);
                        if (!lastImportData.IsSameData(importRow, oldImportRow))
                        {
                            importPriceTbl.AddimportPriceRow(importRow);
                            lastImportData.Update(importRow);
                        }
                        else importRow.CancelEdit();
                    }
                    else importRow.CancelEdit();
                    columnCount = 0;
                    continue;
                }
                object obj = this.mappingList.GetValue(columnCount.ToString());
                if (obj != null)
                {
                    val = 0; common.system.StrToDecimal(item.Text, CultureInfoUS, out val);

                    //15/07: Kiem tra gia tri co bang 0 hay ko. Neu co thi se co loi doc du lieu
                    if (val != 0)
                        bHaveData = true;                    
                    importRow[(string)obj] = val;
                }
                columnCount++;
            }

            //Neu ko co du lieu
            if (!bHaveData) 
                throw new Exception();
            
            return importPriceTbl;
            
        }

        // Return common.extSortedList that store the mapping [Column in web page] -> [importPrice column]
        private common.extSortedList CreateMapping(metaStock meta, databases.importDS.importPriceDataTable dataTbl)
        {
            common.extSortedList list = new common.extSortedList();

            list.Add(meta.closePriceColId.ToString(), dataTbl.closePriceColumn.ColumnName);
            list.Add(meta.volumeColId.ToString(), dataTbl.volumeColumn.ColumnName);
            return list;
        }
    }
    public class hoseImport : stockImport
    {
        protected override metaStock GetMeta()
        { 
            metaStock meta = new metaStock();
            meta.noRowIgnore = 0;
            meta.startAtColId = 0;      meta.endAtColId = 25;
            meta.openPriceColId = 21;   meta.highPriceColId = 22;
            meta.lowPriceColId = 23;    meta.closePriceColId = 12;  meta.volumeColId = 13;
            return meta;
        }
    }
    public class htastcImport : stockImport
    {
        protected override metaStock GetMeta()
        {
            metaStock meta = new metaStock();
            meta.noRowIgnore = 0;
            meta.startAtColId = 0;      meta.endAtColId = 25;
            meta.openPriceColId = -1;   meta.highPriceColId = 21;   meta.lowPriceColId = 22;
            meta.closePriceColId = 12;  meta.volumeColId = 13;      meta.volumeColId = 13;
            return meta;
        }
    }
    public abstract class marketImport : generalImport
    {
        protected class OpenPrice
        {
            public DateTime OnDate = DateTime.Today;
            public decimal Value = decimal.MinValue;
        }

        protected class MarketData
        {
            public MarketData(string code)
            {
                Code = code;
            }
            public string Code = "";
            public decimal Value = 0, TotalQty = 0, TotalAmt = 0;
        }

        protected common.DictionaryList myOpenPriceList = new common.DictionaryList();
        protected virtual void AddImportRow(DateTime updateTime, MarketData marketValue, bool isTotalVolume, databases.importDS.importPriceDataTable tbl)
        {
            databases.importDS.importPriceRow oldImportRow;
            databases.importDS.importPriceRow importRow = tbl.NewimportPriceRow();
            databases.AppLibs.InitData(importRow);
            importRow.isTotalVolume = isTotalVolume;
            importRow.onDate = updateTime;
            importRow.stockCode = marketValue.Code;
            importRow.volume = marketValue.TotalQty;
            importRow.closePrice = marketValue.Value;
            
            //Only add new when there are some changes 
            oldImportRow = lastImportData.Find(importRow);
            if (!lastImportData.IsSameData(importRow, oldImportRow))
            {
                tbl.AddimportPriceRow(importRow);
                lastImportData.Update(importRow);
            }
            else importRow.CancelEdit();
        }

        public override databases.baseDS.priceDataDataTable GetImportFromCSV(string fileName, string market, OnUpdatePriceData onUpdateDataFunc)
        {
            CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(market);
            databases.baseDS.priceDataDataTable priceDataTbl = new databases.baseDS.priceDataDataTable();
            if (!Imports.Libs.CSV_ImportParse(fileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDD,
                                 market, exchangeCulture, priceDataTbl, Libs.DoImportRow, onUpdateDataFunc, null)) return null;
            return priceDataTbl;
        }
    }
    
    public class Libs
    {
        public static bool ImportFromCVS(string csvFileName, string marketCode,CultureInfo dataCulture,
                                         databases.baseDS.priceDataDataTable priceDataTbl,OnUpdatePriceData onUpdateDataFunc)
        {
            return Imports.Libs.CSV_ImportParse(csvFileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDD,
                                                marketCode, dataCulture, priceDataTbl, DoImportRow, onUpdateDataFunc, null);

        }

        public static bool ImportFromCVS_BVSC(string csvFileName, string marketCode, CultureInfo dataCulture,
                                         databases.baseDS.priceDataDataTable priceDataTbl, OnUpdatePriceData onUpdateDataFunc)
        {
            return Imports.Libs.CSV_ImportParse(csvFileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDD,
                                                marketCode, dataCulture, priceDataTbl, DoImportRow, onUpdateDataFunc, null);

        }
        static DateTime tmpDate = common.Consts.constNullDate;
        static double tmpVal = 0;
        public static importOHLCV DoImportRow(LumenWorks.Framework.IO.Csv.CsvReader csv, importStat importStat)
        {
            importOHLCV data = new importOHLCV();
            if (csv[0] == null) return null;
            data.code = csv[0];

            if (!common.dateTimeLibs.Str2Date(csv[1], importStat.dateDataFormat, out tmpDate)) return null;
            data.dateTime = tmpDate;

            if (!double.TryParse(csv[2], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
            data.Open = tmpVal;

            if (!double.TryParse(csv[3], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
            data.High = tmpVal;

            if (!double.TryParse(csv[4], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
            data.Low = tmpVal;

            if (!double.TryParse(csv[5], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
            data.Close = tmpVal;

            if (!double.TryParse(csv[6], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
            data.Volume = tmpVal;
            return data;
        }
    }
}
