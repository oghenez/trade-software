using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Linq;
using commonTypes;
using System.Data;

namespace test
{
    public class goldImport
    {
        public static void ImportKitco(string url)
        {
            System.Net.WebRequest webReq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webRes = webReq.GetResponse();
            System.IO.Stream mystream = webRes.GetResponseStream();
            if (mystream == null) return;

            HtmlAgilityPack.HtmlDocument myHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            myHtmlDoc.Load(mystream);

            List<String> row = new List<string>();
            try
            {
                //string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[3]/div[2]/table/";
                //string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[1]/div[2]/table/";
                string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[2]/div[2]/table/";
                //code
                row.Add("XAUUSD");
                //last
                //var askNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable + "tr[1]/td[3]");
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
                //change
                var changeNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable + "tr[3]/td[2]/span/font");
                row.Add(changeNode.InnerText.Trim());
            }
            catch (System.Exception ex)
            {
                return;
            }

            //return Convert2ForexData(row);
        }

        public static void ImportSJC(string url)
        {
            System.Net.WebRequest webReq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webRes = webReq.GetResponse();
            System.IO.Stream mystream = webRes.GetResponseStream();
            if (mystream == null) return;

            HtmlAgilityPack.HtmlDocument myHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            myHtmlDoc.Load(mystream);

            List<String> row = new List<string>();
            try
            {
                //string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[3]/div[2]/table/";
                //string xpathGoldTable = "//*[@id='main_container']/tr[1]/td[1]/div[1]/div[2]/table/";
                //string xpathGoldTable = "//*[@id='price']";
                //HtmlNodeCollection tdNodeCollection = myHtmlDoc
                //                     .DocumentNode
                //                     .SelectNodes("//div[@id = 'price']");
                

                //foreach (HtmlNode tdNode in tdNodeCollection)
                //{
                //    Console.WriteLine(tdNode.InnerText);
                //}

                //var askNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable).ChildNodes[2];
                //string xpathGoldTable = "//*[@class='right_box']";
                string xpathGoldTable ="*[@id='price']";
                var askNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable).SelectSingleNode("//table[2]");
                //code
                row.Add("SJC");
                //last
                //var askNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable + "tr[1]/td[3]");
                //string xpathGoldTable
                
                //if (askNode != null)
                //    row.Add(askNode.InnerText.Trim());        
            }
            catch (System.Exception ex)
            {
                return;
            }

            //return Convert2ForexData(row);
        }

        public static void ImportVNIndex(string url)
        {
            System.Net.WebRequest webReq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webRes = webReq.GetResponse();
            System.IO.Stream mystream = webRes.GetResponseStream();
            if (mystream == null) return;

            HtmlAgilityPack.HtmlDocument myHtmlDoc = new HtmlAgilityPack.HtmlDocument();
            myHtmlDoc.Load(mystream);

            List<String> row = new List<string>();
            try
            {
                string xpathGoldTable = "//*[@id='hsxidx']";
                //string xpathGoldTable = "//*[@style]";                
                var askNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable);
                //var askNode = myHtmlDoc.DocumentNode.SelectNodes(xpathGoldTable).Select(p=>p.InnerText.ToString());
                //code
                row.Add("SJC");
                //last
                //var askNode = myHtmlDoc.DocumentNode.SelectSingleNode(xpathGoldTable + "tr[1]/td[3]");
                //string xpathGoldTable

                if (askNode != null)
                    row.Add(askNode.InnerText.Trim());        
            }
            catch (System.Exception ex)
            {
                return;
            }

            //return Convert2ForexData(row);
        }

        public static void GetPriceFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            //CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(market);

            int idx = 0;
            clientSSI.AjaxWebServiceSoapClient client = null;
            try
            {
                client = new clientSSI.AjaxWebServiceSoapClient();
                //client = new clientSSI.AjaxWebServiceSoapClient(exchangeDetailRow.address);
                //HoSTC_ServiceSoapClient
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
                    default: return;//return null;
                }
                //Parsing
                List<string> tradeList = new List<string>(s.Split('#'));
                databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
                //CultureInfo dataCulture = application.AppLibs.GetCulture(exchangeDetailRow.culture);
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
                    //importRow.closePrice = decimal.Parse(tradeData[8], dataCulture);
                    //importRow.volume = decimal.Parse(tradeData[9], dataCulture);
                    importRow.isTotalVolume = true;
                    importPriceTbl.AddimportPriceRow(importRow);
                }
                //return importPriceTbl;
            }
            catch (Exception er)
            {
                common.SysLog.WriteLog("Error : " + er.Message);
                //return null;
            }
            finally
            {
                if (client != null && client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
            }
        }

        static void Main()
        {
            //ImportKitco("http://kitco.com");
            //ImportSJC("http://www.sjc.com.vn/?n=0");
            //Import VNIndex
            //ImportVNIndex("http://online2.mhbs.vn/quote/hose.aspx");
            //ImportVNIndex("file://C:/Shared/qnguyen37/mhbs/MHBS - bang gia HOSE.htm");
            DataView myDataView = new DataView(application.SysLibs.myExchangeDetailTbl);
            myDataView.Sort = application.SysLibs.myExchangeDetailTbl.orderIdColumn.ToString();
            string[] parts;
            databases.baseDS.stockExchangeRow marketRow;
            databases.baseDS.exchangeDetailRow exchangeDetailRow;
            commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational, "", "Start");
            for (int idx1 = 0; idx1 < application.SysLibs.myStockExchangeTbl.Count; idx1++)
            {
                marketRow = application.SysLibs.myStockExchangeTbl[idx1];
                //if (IsHolidays(updateTime, marketRow.holidays)) continue;

                // WorkTimes can have multipe parts separated by charater |
                parts = marketRow.workTime.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                //StringCollection confWorkTimes = new StringCollection();
                //for(int idx2=0;idx2<parts.Length;idx2++) confWorkTimes.Add(parts[idx2]);
                //if (!IsWorktime(updateTime, confWorkTimes)) continue;

                myDataView.RowFilter = application.SysLibs.myExchangeDetailTbl.marketCodeColumn.ColumnName + "='" + marketRow.code + "' AND " +
                                       application.SysLibs.myExchangeDetailTbl.isEnabledColumn.ColumnName + "=true";
                if (myDataView.Count == 0) continue;


                bool retVal = true;
                exchangeDetailRow = (databases.baseDS.exchangeDetailRow)myDataView[0].Row;
                exchangeDetailRow = application.SysLibs.myExchangeDetailTbl.FindBycode("HOSE_SSI");

                GetPriceFromWeb(DateTime.Now, exchangeDetailRow);
            }
            
        }
    }
}
