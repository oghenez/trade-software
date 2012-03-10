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

    public class MarketIndex
    {
        public string code = "";
        public decimal Value = 0, TotalQty=0, TotalAmt=0;
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
            metaStock meta = GetMeta();
            if (meta==null) return null;

            databases.importDS.importPriceDataTable importPriceTbl = GetPriceFromWeb(updateTime, meta, exchangeDetailRow);
            Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
            databases.DbAccess.UpdateData(importPriceTbl);

            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
            databases.DbAccess.UpdateData(priceTbl);
            return priceTbl;
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
            //Data in
            CultureInfo CultureInfoUS = common.language.GetCulture("en-US");
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            this.mappingList = CreateMapping(priceMeta, importPriceTbl);

            databases.baseDS.priceDataRow priceDataRow;

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
                        if (importRow.openPrice == 0)
                        {
                            priceDataRow = databases.DbAccess.GetLastPriceData(importRow.stockCode);
                            if (priceDataRow == null) importRow.openPrice = importRow.lowPrice;
                            else importRow.openPrice = priceDataRow.closePrice;
                        }
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
                    importRow[(string)obj] = val;
                }
                columnCount++;
            }
            return importPriceTbl;
        }

        // Return common.extSortedList that store the mapping [Column in web page] -> [importPrice column]
        private common.extSortedList CreateMapping(metaStock meta, databases.importDS.importPriceDataTable dataTbl)
        {
            common.extSortedList list = new common.extSortedList();

            list.Add(meta.openPriceColId.ToString(), dataTbl.openPriceColumn.ColumnName);
            list.Add(meta.highPriceColId.ToString(), dataTbl.highPriceColumn.ColumnName);
            list.Add(meta.lowPriceColId.ToString(), dataTbl.lowPriceColumn.ColumnName);
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
    public class vnIndexImport : stockImport
    {
        //Unused
        protected override metaStock GetMeta() { return null; }
        static DateTime myOpenPriceDate = DateTime.Today;
        static decimal myOpenPrice = decimal.MinValue;
        static MarketIndex vnIdx = new MarketIndex();
        static MarketIndex vn30Idx = new MarketIndex();
        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            if (!Get_IDX_HOSE(exchangeDetailRow.address, ref vnIdx, ref vn30Idx)) return null;
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            AddImportRow(updateTime, vnIdx,  "^VNINDEX", importPriceTbl);
            AddImportRow(updateTime, vn30Idx,"^V30INDEX", importPriceTbl);

            Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
            databases.DbAccess.UpdateData(importPriceTbl);

            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
            databases.DbAccess.UpdateData(priceTbl);
            return priceTbl;
        }

        private void AddImportRow(DateTime updateTime, MarketIndex marketIndex, string code, databases.importDS.importPriceDataTable tbl)
        {
            databases.importDS.importPriceRow importRow = tbl.NewimportPriceRow();
            databases.AppLibs.InitData(importRow);
            importRow.onDate = updateTime;
            importRow.stockCode = code;
            importRow.volume = marketIndex.TotalQty;
            importRow.closePrice = marketIndex.Value;
            importRow.highPrice = marketIndex.Value;
            importRow.lowPrice = marketIndex.Value;
            if (myOpenPriceDate != updateTime.Date || myOpenPrice == decimal.MinValue)
            {
                databases.baseDS.priceDataRow row = databases.DbAccess.GetLastPriceData(importRow.stockCode);
                if (row != null) myOpenPrice = row.closePrice;
                else myOpenPrice = importRow.closePrice;
                myOpenPriceDate = updateTime.Date;
            }
            importRow.openPrice = myOpenPrice;
            tbl.AddimportPriceRow(importRow);
        }

        private static bool Get_IDX_HOSE(string address, ref MarketIndex vnIdx, ref MarketIndex vn30Idx)
        {
            //Hose
            clientHOSE.HoSTC_ServiceSoapClient client = new Imports.clientHOSE.HoSTC_ServiceSoapClient();
            client.Endpoint.Address = new System.ServiceModel.EndpointAddress(address);
            string[] arr = client.GetLiveTotalMKT().Split('*');
            string content = string.Empty;
            List<string> rows = new List<string>();
            foreach (var item in arr)
            {
                if (item.Trim() == "") continue;
                rows.Add(item);
                content += item + Environment.NewLine;
            }
            string[] dRow = rows[rows.Count - 1].Split('|');

            vnIdx.Value = decimal.Parse(dRow[0]);
            vnIdx.TotalQty = decimal.Parse(dRow[4]);
            vnIdx.TotalAmt = decimal.Parse(dRow[5]);

            vn30Idx.Value = decimal.Parse(dRow[9]);
            vn30Idx.TotalQty = 0;
            vn30Idx.TotalAmt = 0;

            return true;
        }

    }
    public class vnIdxImport : stockImport
    {
        private class openPrice
        {
            public DateTime onDate = DateTime.Today;
            public decimal value = decimal.MinValue;
        }
        common.DictionaryList myOpenPriceList = new common.DictionaryList();

        protected override metaStock GetMeta() { return null; }//Unused
        MarketIndex vnIdx = new MarketIndex();
        MarketIndex vn30Idx = new MarketIndex();
        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            if (!Get_IDX_HOSE(exchangeDetailRow.address, ref vnIdx, ref vn30Idx)) return null;
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            AddImportRow(updateTime, vnIdx, "VN-IDX", true,importPriceTbl);
            AddImportRow(updateTime, vn30Idx, "VN30-IDX", false, importPriceTbl);

            Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
            databases.DbAccess.UpdateData(importPriceTbl);

            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
            databases.DbAccess.UpdateData(priceTbl);
            return priceTbl;
        }
        protected void AddImportRow(DateTime updateTime, MarketIndex marketIndex, string code,bool isTotalVolume, databases.importDS.importPriceDataTable tbl)
        {
            databases.importDS.importPriceRow oldImportRow;
            databases.importDS.importPriceRow importRow = tbl.NewimportPriceRow();
            databases.AppLibs.InitData(importRow);
            importRow.isTotalVolume = isTotalVolume;
            importRow.onDate = updateTime;
            importRow.stockCode = code;
            importRow.volume = marketIndex.TotalQty;
            importRow.closePrice = marketIndex.Value;
            importRow.highPrice = marketIndex.Value;
            importRow.lowPrice = marketIndex.Value;

            openPrice checkOpenPrice = (openPrice)myOpenPriceList.Find(importRow.stockCode);
            if (checkOpenPrice == null)
                checkOpenPrice= new openPrice();

            if ( (checkOpenPrice.onDate != updateTime.Date) || (checkOpenPrice.value == decimal.MinValue) )
            {
                databases.baseDS.priceDataRow row = databases.DbAccess.GetLastPriceData(importRow.stockCode);
                if (row != null) checkOpenPrice.value  = row.closePrice;
                else checkOpenPrice.value = importRow.closePrice;
                checkOpenPrice.onDate = updateTime.Date;
                myOpenPriceList.Add(importRow.stockCode, checkOpenPrice);
            }
            importRow.openPrice = checkOpenPrice.value;
            //Only add new when there are some changes 
            oldImportRow = lastImportData.Find(importRow);
            if (!lastImportData.IsSameData(importRow, oldImportRow))
            {
                tbl.AddimportPriceRow(importRow);
                lastImportData.Update(importRow);
            }
            else importRow.CancelEdit();
        }
        private static bool Get_IDX_HOSE(string address, ref MarketIndex vnIdx, ref MarketIndex vn30Idx)
        {
            //Hose
            clientHOSE.HoSTC_ServiceSoapClient client = new Imports.clientHOSE.HoSTC_ServiceSoapClient();
            client.Endpoint.Address = new System.ServiceModel.EndpointAddress(address);
            string[] arr = client.GetLiveTotalMKT().Split('*');
            string content = string.Empty;
            List<string> rows = new List<string>();
            foreach (var item in arr)
            {
                if (item.Trim() == "") continue;
                rows.Add(item);
                content += item + Environment.NewLine;
            }
            string[] dRow = rows[rows.Count - 1].Split('|');

            vnIdx.Value = decimal.Parse(dRow[0]);
            vnIdx.TotalQty = decimal.Parse(dRow[4]);
            vnIdx.TotalAmt = decimal.Parse(dRow[5]);

            vn30Idx.Value = decimal.Parse(dRow[9]);
            vn30Idx.TotalQty = 0;
            vn30Idx.TotalAmt = 0;

            return true;
        }
    }
    public class hnIdxImport : vnIdxImport
    {
        static string addresswBrowser;
        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            if (!Get_IDX_HASTC(exchangeDetailRow.address, ref hastcIdx)) return null;
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            AddImportRow(updateTime, hastcIdx, "HNX-IDX", true, importPriceTbl);

            Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
            databases.DbAccess.UpdateData(importPriceTbl);

            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
            databases.DbAccess.UpdateData(priceTbl);
            return priceTbl;
        }

        static MarketIndex hastcIdx = new MarketIndex();
        //End- Add STA Thread for WebBrowser - TUAN
        static bool Get_IDX_HASTC(string address, ref MarketIndex hastcIdx)
        {
            HttpWebRequest wRequest = HttpWebRequest.Create(new Uri(address)) as HttpWebRequest;
            HttpWebResponse wResponse = wRequest.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(wResponse.GetResponseStream());
            string htmlContent = reader.ReadToEnd();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlContent);
            HtmlAgilityPack.HtmlNode nodeHNXIndex = doc.GetElementbyId("IDX");
            HtmlAgilityPack.HtmlNode nodeTongKL = doc.GetElementbyId("TTQTY");
            hastcIdx.Value = decimal.Parse(nodeHNXIndex.InnerHtml);
            hastcIdx.TotalQty = decimal.Parse(nodeTongKL.InnerHtml);
            hastcIdx.TotalAmt = 0;   
            return true;
        }
    }

    public class Libs
    {
        public static bool ImportFromCVS(string csvFileName, string marketCode,databases.baseDS.priceDataDataTable priceDataTbl,OnUpdatePriceData onUpdateDataFunc)
        {
            CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(marketCode);
            return Imports.Libs.CSV_ImportParse(csvFileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDD,
                                                marketCode, exchangeCulture, priceDataTbl, DoImportRow, onUpdateDataFunc, null);

        }
        static DateTime tmpDate = common.Consts.constNullDate;
        static double tmpVal = 0;
        public static importOHLCV DoImportRow(LumenWorks.Framework.IO.Csv.CsvReader csv, importStat importStat)
        {
            importOHLCV data = new importOHLCV();
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
    }
}
