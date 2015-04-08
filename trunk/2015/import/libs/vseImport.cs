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
    public class vnIdxImport : marketImport
    {
        static MarketData vnIdx = new MarketData("VN-IDX");
        static MarketData vn30Idx = new MarketData("VN30-IDX");
        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            if (!GetData(exchangeDetailRow, ref vnIdx, ref vn30Idx)) return null;
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            AddImportRow(updateTime, vnIdx, true, importPriceTbl);
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
            string[] dRow = rows[8].Split('|');

            vnIdx.Value = decimal.Parse(dRow[0], dataCulture);
            vnIdx.TotalQty = decimal.Parse(dRow[4], dataCulture);
            vnIdx.TotalAmt = decimal.Parse(dRow[5], dataCulture);

            vn30Idx.Value = decimal.Parse(dRow[10], dataCulture);
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
            //bool retVal = true;
            //CultureInfo dataCulture = common.language.GetCulture("en-US");
            //HttpWebRequest wRequest = HttpWebRequest.Create(new Uri(address)) as HttpWebRequest;
            //HttpWebResponse wResponse = wRequest.GetResponse() as HttpWebResponse;
            //StreamReader reader = new StreamReader(wResponse.GetResponseStream());
            //string htmlContent = reader.ReadToEnd();
            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(htmlContent);
            //HtmlAgilityPack.HtmlNode nodeHNXIndex = doc.GetElementbyId("IDX");
            //HtmlAgilityPack.HtmlNode nodeTongKL = doc.GetElementbyId("QTY");
            //if (nodeHNXIndex!=null)
            //     hastcIdx.Value = decimal.Parse(nodeHNXIndex.InnerHtml, dataCulture);
            //else retVal = false;
            //if (nodeTongKL != null) hastcIdx.TotalQty = decimal.Parse(nodeTongKL.InnerHtml, dataCulture);
            //else retVal = false;
            //hastcIdx.TotalAmt = 0;
            //return retVal;

            bool retVal = true;
            CultureInfo dataCulture = common.language.GetCulture("en-US");
            System.Net.WebRequest webReq = System.Net.WebRequest.Create(address);
            System.Net.WebResponse webRes = webReq.GetResponse();
            System.IO.Stream mystream = webRes.GetResponseStream();
            if (mystream == null) return false;

            HtmlAgilityPack.HtmlDocument myHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            myHtmlDoc.Load(mystream);

            List<String> row = new List<string>();
            try
            {
                //string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[3]/div[2]/table/";                    
                string xpathGoldTable = "//*[@id='hnxidx']";
                var askNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable);
                hastcIdx.Value = decimal.Parse(askNode.InnerText, dataCulture);
                //code
                row.Add("XAUUSD");
                //Bid/Ask                    
                //string xpathGoldTable

                if (askNode != null)
                    row.Add(askNode.InnerText.Trim());
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return retVal;
        }
    }
}
