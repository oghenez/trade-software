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
using application;
using commonClass;

namespace Imports
{
    public class Gold
    {
        private static CultureInfo _goldCulture = null;
        private static CultureInfo goldCulture
        {
            get
            {
                if (_goldCulture==null) 
                    common.system.ThrowException("[goldCulture] was not set!");
                return _goldCulture;
            }
            set
            {
                _goldCulture = value;
            }
        }

        public class forexImport : generalImport
        {
            public override databases.baseDS.priceDataDataTable GetImportFromCSV(string fileName,string market, OnUpdatePriceData onUpdateDataFunc)
            {
                CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(market);
                databases.baseDS.priceDataDataTable priceDataTbl = new databases.baseDS.priceDataDataTable();
                if(!Imports.Libs.CSV_ImportParse(fileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDD,
                                                 market, exchangeCulture, priceDataTbl, DoImportRow, onUpdateDataFunc, null))
                    return null;
                return priceDataTbl;
            }
            public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime,databases.baseDS.exchangeDetailRow exchangeDetailRow)
            {
                // Different culture has differebr strt of week, ie in VN culture : start of week is Monday (not Sunday) 
                if (_goldCulture==null)
                    _goldCulture = application.AppLibs.GetExchangeCulture(exchangeDetailRow.marketCode);

                databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
                ForexData[] frData = ImportForex(exchangeDetailRow.address);
                ForexData goldData = frData[3]; //Gold at price 4
                //Only add new when there are some changes 
                if (lastForexData != null)
                {
                    if (lastForexData.last == goldData.last &&
                        lastForexData.high == goldData.high &&
                        lastForexData.low == goldData.low) return null;
                }
                else lastForexData = new ForexData();
                lastForexData.last = goldData.last;
                lastForexData.high = goldData.high;
                lastForexData.low = goldData.low;

                databases.importDS.importPriceRow importRow;
                importRow = importPriceTbl.NewimportPriceRow();
                databases.AppLibs.InitData(importRow);
                importRow.onDate = updateTime;
                importRow.stockCode = goldData.code;
                importRow.closePrice = goldData.last;
                importRow.highPrice = goldData.high;
                importRow.lowPrice = goldData.low;

                if (goldOpenPriceDate != updateTime.Date || goldOpenPrice == decimal.MinValue)
                {
                    databases.baseDS.priceDataRow row = databases.DbAccess.GetLastPriceData(importRow.stockCode);
                    if (row != null) goldOpenPrice = row.closePrice;
                    else goldOpenPrice = importRow.closePrice;
                    goldOpenPriceDate = updateTime.Date;
                }
                importRow.openPrice = goldOpenPrice;

                importPriceTbl.AddimportPriceRow(importRow);
                Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
                databases.DbAccess.UpdateData(importPriceTbl);

                databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
                Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
                databases.DbAccess.UpdateData(priceTbl);

                return priceTbl;
            }
        }
        public static bool ImportFromCVS(string csvFileName, string marketCode,
                                         databases.baseDS.priceDataDataTable priceDataTbl,
                                         Imports.OnUpdatePriceData onUpdateDataFunc)
        {

            CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(marketCode);
            return Imports.Libs.CSV_ImportParse(csvFileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDDhhmmss,
                                                      marketCode, exchangeCulture,
                                                      priceDataTbl, DoImportRow, onUpdateDataFunc, null);

        }
        static DateTime tmpDate = common.Consts.constNullDate;
        static double tmpVal = 0;
        static Imports.importOHLCV DoImportRow(LumenWorks.Framework.IO.Csv.CsvReader csv, Imports.importStat importStat)
        {
            Imports.importOHLCV data = new Imports.importOHLCV();
            if (csv[0] == null) return null;
            data.code = csv[0];

            if (!common.dateTimeLibs.Str2Date(csv[1] + csv[2], importStat.dateFormat, out tmpDate)) return null;
            data.dateTime = tmpDate;

            if (!double.TryParse(csv[3], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Open = tmpVal;

            if (!double.TryParse(csv[4], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.High = tmpVal;

            if (!double.TryParse(csv[5], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Low = tmpVal;

            if (!double.TryParse(csv[6], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Close = tmpVal;

            if (!double.TryParse(csv[7], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Volume = tmpVal;
            return data;
        }

        //Update from http://www.forex.com/uk/index.html
        private class ForexData
        {
            public string code = "";
            public decimal last = 0, high = 0, low = 0, changed = 0;
        }
        private static ForexData[] ImportForex(string url)
        {
            System.Net.WebRequest webReq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webRes = webReq.GetResponse();
            System.IO.Stream mystream = webRes.GetResponseStream();
            if (mystream == null) return null;

            HtmlAgilityPack.HtmlDocument myHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            myHtmlDoc.Load(mystream);

            int iColumn = 0;
            var myNode = myHtmlDoc.DocumentNode.SelectNodes("//table[@id='fund_list_table']/tr/td[1]");

            List<string> anchorTags = new List<string>();
            if (myNode == null) return null;

            ForexData[] result = new ForexData[0];
            foreach (HtmlNode link in myNode)
            {
                ++iColumn;
                string att = link.InnerText;
                HtmlNode thuxem = link.ParentNode;
                String attt = thuxem.InnerHtml;
                if (att == "Pair")
                {
                    HtmlNode nodeOfDataRow = link.ParentNode;   //Lấy node tên column
                    nodeOfDataRow = nodeOfDataRow.NextSibling;  // Lấy hàng dữ liệu đầu tiên
                    string asdf = nodeOfDataRow.InnerHtml;

                    while (nodeOfDataRow != null)
                    {
                        HtmlNode nodeOfRow = nodeOfDataRow.FirstChild;  //Lấy ô dữ liệu đầu tiên
                        List<String> row = new List<string>();
                        while (nodeOfRow != null)   // Lấy các ô dữ liệu tiếp theo
                        {
                            //Kiem tra xem chuoi co hop le
                            if (!nodeOfRow.InnerText.Contains("<!--") && nodeOfRow.InnerText.Length > 0)
                                row.Add(nodeOfRow.InnerText);
                            nodeOfRow = nodeOfRow.NextSibling;
                        }
                        if (row.Count >= 4)
                        {
                            ForexData data = Convert2ForexData(row);
                            if (data != null)
                            {
                                Array.Resize(ref result, result.Length + 1);
                                result[result.Length - 1] = data;
                            }
                        }
                        nodeOfDataRow = nodeOfDataRow.NextSibling;  // Lay Du Lieu Dong Tiep theo
                    }
                }
            }
            return result;
        }
        private static ForexData Convert2ForexData(List<string> row)
        {
            decimal last = 0, high = 0, low = 0, changed = 0;
            if (!common.system.StrToDecimal(row[1].Trim(), goldCulture, out last)) return null;
            string[] parts = row[2].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) return null;
            if (!common.system.StrToDecimal(parts[0].Trim(), goldCulture, out high)) return null;
            if (!common.system.StrToDecimal(parts[1].Trim(), goldCulture, out low)) return null;
            if (!common.system.StrToDecimal(row[3].Trim(), goldCulture, out changed)) return null;
            ForexData data = new ForexData();
            data.code = row[0].Replace("/", "").Replace(" ", "");
            data.last = last;
            data.high = high;
            data.low = low;
            data.changed = changed;
            return data;
        }
        private static ForexData lastForexData = null;
        private static DateTime goldOpenPriceDate = DateTime.Today;  
        private static decimal goldOpenPrice = decimal.MinValue;
        public static void ResetGetPrice()
        { 
            goldOpenPriceDate = DateTime.Today;  
            goldOpenPrice = decimal.MinValue;
        }
    }
}
