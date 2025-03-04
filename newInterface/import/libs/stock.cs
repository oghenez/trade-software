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

    public class vnIdxImport : marketImport
    {
        static MarketData vnIdx = new MarketData("VN-IDX");
        static MarketData vn30Idx = new MarketData("VN30-IDX");
        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            if (!GetData(exchangeDetailRow, ref vnIdx, ref vn30Idx)) return null;
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            AddImportRow(updateTime, vnIdx,true,importPriceTbl);
            AddImportRow(updateTime, vn30Idx, false, importPriceTbl);

            Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
            databases.DbAccess.UpdateData(importPriceTbl);

            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
            databases.DbAccess.UpdateData(priceTbl);
            return priceTbl;
        }

        protected virtual bool GetData(databases.baseDS.exchangeDetailRow exchangeDetailRow, ref MarketData vnIdx, ref MarketData vn30Idx)
        {
            CultureInfo dataCulture = common.language.GetCulture("en-US");
            //Hose
            clientHOSE.HoSTC_ServiceSoapClient client = new Imports.clientHOSE.HoSTC_ServiceSoapClient();
            client.Endpoint.Address = new System.ServiceModel.EndpointAddress(exchangeDetailRow.address);

            System.ServiceModel.BasicHttpBinding binding = (client.Endpoint.Binding as System.ServiceModel.BasicHttpBinding);

            binding.OpenTimeout = TimeSpan.FromSeconds(Consts.constWebServiceTimeOutInSecs);
            binding.CloseTimeout = binding.OpenTimeout;
            binding.SendTimeout = binding.OpenTimeout;

            binding.MaxReceivedMessageSize = Consts.constWebServiceMaxReceivedMessageSize;
            binding.MaxBufferSize = Consts.constWebServiceMaxReceivedMessageSize;

            binding.ReaderQuotas.MaxStringContentLength = Consts.constWebServiceMaxStringContentLength;
            binding.ReaderQuotas.MaxBytesPerRead = Consts.constWebServiceMaxBytesPerRead;

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

            vnIdx.Value = decimal.Parse(dRow[0], dataCulture);
            vnIdx.TotalQty = decimal.Parse(dRow[4], dataCulture);
            vnIdx.TotalAmt = decimal.Parse(dRow[5], dataCulture);

            vn30Idx.Value = decimal.Parse(dRow[9], dataCulture);
            vn30Idx.TotalQty = 0;
            vn30Idx.TotalAmt = 0;

            return true;
        }
    }
    public class hnIdxImport : marketImport
    {
        static MarketData hastcIdx = new MarketData("HNX-IDX");

        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            if (!Get_IDX_HASTC(exchangeDetailRow.address, ref hastcIdx)) return null;
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            AddImportRow(updateTime, hastcIdx, true, importPriceTbl);

            Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
            databases.DbAccess.UpdateData(importPriceTbl);

            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
            databases.DbAccess.UpdateData(priceTbl);
            return priceTbl;
        }


        static bool Get_IDX_HASTC(string address, ref MarketData hastcIdx)
        {
            bool retVal = true;
            CultureInfo dataCulture = common.language.GetCulture("en-US");
            HttpWebRequest wRequest = HttpWebRequest.Create(new Uri(address)) as HttpWebRequest;
            HttpWebResponse wResponse = wRequest.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(wResponse.GetResponseStream());
            string htmlContent = reader.ReadToEnd();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlContent);
            HtmlAgilityPack.HtmlNode nodeHNXIndex = doc.GetElementbyId("IDX");
            HtmlAgilityPack.HtmlNode nodeTongKL = doc.GetElementbyId("QTY");
            if (nodeHNXIndex!=null)
                 hastcIdx.Value = decimal.Parse(nodeHNXIndex.InnerHtml, dataCulture);
            else retVal = false;
            if (nodeTongKL != null) hastcIdx.TotalQty = decimal.Parse(nodeTongKL.InnerHtml, dataCulture);
            else retVal = false;
            hastcIdx.TotalAmt = 0;
            return retVal;
        }
    }


    //Import stock data of HOSE and HASTC from  http://banggia.ssi.com.vn/AjaxWebService.asmx
    public class ssi_StockImport : generalImport
    {
        public override databases.baseDS.priceDataDataTable GetImportFromCSV(string fileName, string market, OnUpdatePriceData onUpdateDataFunc)
        {
            return null;
        }
        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            databases.importDS.importPriceDataTable importPriceTbl = GetPriceFromWeb(updateTime, exchangeDetailRow);
            if (importPriceTbl == null) return null;

            Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
            databases.DbAccess.UpdateData(importPriceTbl);
            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
            databases.DbAccess.UpdateData(priceTbl);
            return priceTbl;
        }
        private databases.importDS.importPriceDataTable GetPriceFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            int idx = 0;
            clientSSI.AjaxWebServiceSoapClient client = null;
            try
            {
                client = new clientSSI.AjaxWebServiceSoapClient();
                client.Endpoint.Address = new System.ServiceModel.EndpointAddress(exchangeDetailRow.address);
                System.ServiceModel.BasicHttpBinding binding = (client.Endpoint.Binding as System.ServiceModel.BasicHttpBinding);

                binding.OpenTimeout = TimeSpan.FromSeconds(Consts.constWebServiceTimeOutInSecs);
                binding.CloseTimeout = binding.OpenTimeout;
                binding.SendTimeout = binding.OpenTimeout;

                binding.MaxReceivedMessageSize = Consts.constWebServiceMaxReceivedMessageSize;
                binding.MaxBufferSize = Consts.constWebServiceMaxReceivedMessageSize;

                binding.ReaderQuotas.MaxStringContentLength = Consts.constWebServiceMaxStringContentLength;
                binding.ReaderQuotas.MaxBytesPerRead = Consts.constWebServiceMaxBytesPerRead;

                String s = String.Empty;
                switch (exchangeDetailRow.code.ToUpper().Trim())
                {
                    case "HOSE_SSI":
                        s = client.GetDataHoSTC2();
                        break;
                    case "HASTC_SSI":
                        s = client.GetDataHaSTC2();
                        break;
                    default: return null;
                }
                //Parsing
                List<string> tradeList = new List<string>(s.Split('#'));
                databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
                CultureInfo dataCulture = application.AppLibs.GetCulture(exchangeDetailRow.culture);
                for (idx = 0; idx < tradeList.Count; idx++)
                {
                    List<string> tradeData = new List<string>(tradeList[idx].Split('|'));
                    if (tradeData[8].Trim() == "" || tradeData[9].Trim() == "")
                    {
                        continue;
                    }
                    databases.importDS.importPriceRow importRow = importPriceTbl.NewimportPriceRow();
                    databases.AppLibs.InitData(importRow);
                    importRow.stockCode = tradeData[0].ToString();
                    importRow.onDate = updateTime;
                    importRow.closePrice = decimal.Parse(tradeData[8], dataCulture);
                    importRow.volume = decimal.Parse(tradeData[9], dataCulture);
                    importRow.isTotalVolume = true;
                    importPriceTbl.AddimportPriceRow(importRow);
                }
                return importPriceTbl;
            }
            catch (Exception er)
            {
                common.SysLog.WriteLog("Error : " + er.Message);
                return null;
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }
        }
    }

    //Import INDEX data of HOSE and HASTC from  http://banggia.ssi.com.vn/AjaxWebService.asmx
    public class ssi_vnIdxImport : vnIdxImport
    {
        protected override bool GetData(databases.baseDS.exchangeDetailRow exchangeDetailRow, ref MarketData vnIdx, ref MarketData vn30Idx)
        {
            clientSSI.AjaxWebServiceSoapClient client = null;
            try
            {
                client = new clientSSI.AjaxWebServiceSoapClient();
                client.Endpoint.Address = new System.ServiceModel.EndpointAddress(exchangeDetailRow.address);
                System.ServiceModel.BasicHttpBinding binding = (client.Endpoint.Binding as System.ServiceModel.BasicHttpBinding);

                binding.OpenTimeout = TimeSpan.FromSeconds(Consts.constWebServiceTimeOutInSecs);
                binding.CloseTimeout = binding.OpenTimeout;
                binding.SendTimeout = binding.OpenTimeout;

                binding.MaxReceivedMessageSize = Consts.constWebServiceMaxReceivedMessageSize;
                binding.MaxBufferSize = Consts.constWebServiceMaxReceivedMessageSize;

                binding.ReaderQuotas.MaxStringContentLength = Consts.constWebServiceMaxStringContentLength;
                binding.ReaderQuotas.MaxBytesPerRead = Consts.constWebServiceMaxBytesPerRead;

                CultureInfo dataCulture = application.AppLibs.GetCulture(exchangeDetailRow.culture);
                String s = client.GetDataHoSTC2_Index();
                List<string> tradeList = new List<string>(s.Split('#'));
                for (int i = 0; i < tradeList.Count; i++)
                {
                    List<string> tradeData = new List<string>(tradeList[i].Split('|'));
                    if (tradeData[0].Trim() == "" || tradeData[1].Trim() == "" ||
                        tradeData[8].Trim() == "" || tradeData[9].Trim() == "")
                    {
                        continue;
                    }
                    vnIdx.Value = decimal.Parse(tradeData[0], dataCulture);
                    vnIdx.TotalQty = decimal.Parse(tradeData[1], dataCulture);
                    vnIdx.TotalAmt = 0;

                    vn30Idx.Value = decimal.Parse(tradeData[11], dataCulture);
                    vn30Idx.TotalQty = decimal.Parse(tradeData[14], dataCulture); ;
                    vn30Idx.TotalAmt = 0;
                    return true;
                }
            }
            catch (WebException e)
            {
                return false;
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }

            return true;
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
