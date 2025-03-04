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
using System.ServiceModel;

namespace Imports.Gold 
{
        public class kitcoImport : forexImport
        {
            /// <summary>
            /// Update from http://www.kitco.com/
            /// Su dung XPath de truy van tim ra du lieu
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>

            protected static ForexData ImportKitco(string url)
            {
                System.Net.WebRequest webReq = System.Net.WebRequest.Create(url);
                System.Net.WebResponse webRes = webReq.GetResponse();
                System.IO.Stream mystream = webRes.GetResponseStream();
                if (mystream == null) return null;

                HtmlAgilityPack.HtmlDocument myHtmlDoc = new HtmlAgilityPack.HtmlDocument();
                myHtmlDoc.Load(mystream);

                List<String> row = new List<string>();
                try
                {
                    //string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[3]/div[2]/table/";                    
                    //string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[2]/div[2]/table/";
                    string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[3]/div[2]/table/";                    
                    //code
                    row.Add("XAUUSD");
                    //Bid/Ask                    
                    //string xpathGoldTable
                    var askNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable + "tr[1]/td[2]");
                    if (askNode != null)
                        row.Add(askNode.InnerText.Trim());
                    //high / low
                    var lhNodes = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable + "tr[2]/td[2]");
                    if (lhNodes != null)
                        //row.Add(lhNodes[5].InnerText.Trim()
                        //    + "/" + lhNodes[3].InnerText.Trim().Substring(0, lhNodes[3].InnerText.Length - 2).Trim()); //1781.30 -
                        row.Add(lhNodes.InnerText.Trim());
                    else throw new Exception();
                    //change
                    var changeNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable + "tr[3]/td[2]/span/font");
                    row.Add(changeNode.InnerText.Trim());
                }
                catch (System.Exception er)
                {
                    commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "Cannot read from Kitco", er);
                    return null;
                }

                return Convert2ForexData(row);
            }
            public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
            {
                // Different culture has differebr strt of week, ie in VN culture : start of week is Monday (not Sunday) 
                if (myCulture == null)
                    myCulture = application.AppLibs.GetCulture(exchangeDetailRow.culture);

                databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
                ForexData goldData = ImportKitco(exchangeDetailRow.address);
                if (null == goldData) { return null; }

                AddImportRow(updateTime, goldData, false, importPriceTbl);

                Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
                databases.DbAccess.UpdateData(importPriceTbl);

                databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
                Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
                databases.DbAccess.UpdateData(priceTbl);

                return priceTbl;
            }
        }

        public class forexImport : generalImport
        {
            private static CultureInfo _myCulture = null;
            protected static CultureInfo myCulture
            {
                get
                {
                    return _myCulture;
                }
                set
                {
                    _myCulture = value;
                }
            }

            public override databases.baseDS.priceDataDataTable GetImportFromCSV(string fileName, string market, OnUpdatePriceData onUpdateDataFunc)
            {
                CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(market);
                databases.baseDS.priceDataDataTable priceDataTbl = new databases.baseDS.priceDataDataTable();
                if (!Imports.Libs.CSV_ImportParse(fileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDD,
                                                 market, exchangeCulture, priceDataTbl,Libs.DoImportRow, onUpdateDataFunc, null))
                    return null;
                return priceDataTbl;
            }
            public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
            {
                // Different culture has differebr strt of week, ie in VN culture : start of week is Monday (not Sunday) 
                if (_myCulture == null)
                    _myCulture = application.AppLibs.GetCulture(exchangeDetailRow.culture);

                databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
                ForexData goldData = null;
                ForexData[] frData = ImportForex(exchangeDetailRow.address);
                goldData = frData[3]; //Gold at price 4
                if (null == goldData) { return null; }

                AddImportRow(updateTime, goldData, false, importPriceTbl);

                Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
                databases.DbAccess.UpdateData(importPriceTbl);

                databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
                Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
                databases.DbAccess.UpdateData(priceTbl);

                return priceTbl;
            }
            protected virtual void AddImportRow(DateTime updateTime, ForexData data, bool isTotalVolume, databases.importDS.importPriceDataTable tbl)
            {
                databases.importDS.importPriceRow oldImportRow;
                databases.importDS.importPriceRow importRow = tbl.NewimportPriceRow();
                databases.AppLibs.InitData(importRow);
                importRow.isTotalVolume = isTotalVolume;
                importRow.onDate = updateTime;
                importRow.stockCode = data.code;
                importRow.volume = 0;
                importRow.closePrice = data.last;
                //Only add new when there are some changes 
                oldImportRow = lastImportData.Find(importRow);
                if (!lastImportData.IsSameData(importRow, oldImportRow))
                {
                    tbl.AddimportPriceRow(importRow);
                    lastImportData.Update(importRow);
                }
                else importRow.CancelEdit();
            }

            //Update from http://www.forex.com/uk/index.html
            protected class ForexData
            {
                public string code = "";
                public decimal last = 0, high = 0, low = 0, changed = 0;
            }

            protected static ForexData[] ImportForex(string url)
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
            protected static ForexData Convert2ForexData(List<string> row)
            {
                string[] parts;
                decimal last = 0, high = 0, low = 0, changed = 0;
                //if (!common.system.StrToDecimal(row[1].Trim(), myCulture, out last)) return null;
                parts=row[1].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (!common.system.StrToDecimal(parts[0], myCulture, out last)) return null;

                parts = row[2].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2) return null;
                if (!common.system.StrToDecimal(parts[0].Trim(), myCulture, out high)) return null;
                if (!common.system.StrToDecimal(parts[1].Trim(), myCulture, out low)) return null;
                if (!common.system.StrToDecimal(row[3].Trim(), myCulture, out changed)) return null;
                ForexData data = new ForexData();
                data.code = row[0].Replace("/", "").Replace(" ", "");
                data.last = last;
                data.high = high;
                data.low = low;
                data.changed = changed;
                return data;
            }

            protected class OpenPrice
            {
                public DateTime OnDate = DateTime.Today;
                public decimal Value = decimal.MinValue;
            }
            protected common.DictionaryList myOpenPriceList = new common.DictionaryList();
        }
        
        public class Libs
        {
            static DateTime tmpDate = common.Consts.constNullDate;
            static double tmpVal = 0;
            public static Imports.importOHLCV DoImportRow(LumenWorks.Framework.IO.Csv.CsvReader csv, Imports.importStat importStat)
            {
                Imports.importOHLCV data = new Imports.importOHLCV();
                if (csv[0] == null) return null;
                data.code = csv[0];

                if (!common.dateTimeLibs.Str2Date(csv[1] + csv[2], importStat.dateDataFormat, out tmpDate)) return null;
                data.dateTime = tmpDate;

                if (!double.TryParse(csv[3], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
                if (tmpVal <= 0) return null;
                data.Open = tmpVal;

                if (!double.TryParse(csv[4], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
                if (tmpVal <= 0) return null;
                data.High = tmpVal;

                if (!double.TryParse(csv[5], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
                if (tmpVal <= 0) return null;
                data.Low = tmpVal;

                if (!double.TryParse(csv[6], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
                if (tmpVal <= 0) return null;
                data.Close = tmpVal;

                if (!double.TryParse(csv[7], NumberStyles.Number, importStat.srcCulture, out tmpVal)) return null;
                data.Volume = tmpVal;
                return data;
            }


            public static bool ImportFromCVS(string csvFileName, string marketCode,CultureInfo dataCulture,
                                                    databases.baseDS.priceDataDataTable priceDataTbl,
                                                    Imports.OnUpdatePriceData onUpdateDataFunc)
            {

                return Imports.Libs.CSV_ImportParse(csvFileName, ',', common.dateTimeLibs.DateTimeFormats.YYMMDDhhmmss,
                                                          marketCode, dataCulture,
                                                          priceDataTbl, Libs.DoImportRow, onUpdateDataFunc, null);

            }
        }
}
