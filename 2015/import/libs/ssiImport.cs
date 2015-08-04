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
    /// <summary>
    /// Import stock data of HOSE and HASTC from  http://banggia.ssi.com.vn/AjaxWebService.asmx
    /// </summary>
    public class ssi_StockImport : generalImport
    {
        public override databases.baseDS.priceDataDataTable GetImportFromCSV(string fileName, string market, OnUpdatePriceData onUpdateDataFunc)
        {
            return null;
        }

        /// <summary>
        /// Override method - /// Import stock data of HOSE and HASTC from  http://banggia.ssi.com.vn/AjaxWebService.asmx
        /// </summary>
        /// <param name="updateTime"></param>
        /// <param name="exchangeDetailRow"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Private - SU dung ASPWebservices
        /// </summary>
        /// <param name="updateTime"></param>
        /// <param name="exchangeDetailRow"></param>
        /// <returns></returns>
        private databases.importDS.importPriceDataTable GetPriceFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
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
                        //s = client.GetDataHoSTC2();
                        s = client.GetHoseStockQuote(0);
                        break;
                    case "HASTC_SSI":
                        //s = client.GetDataHaSTC2();
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
                    importRow.isTotalVolume = false;//day ko phai total volume. Cai nay la volume tung thoi diem
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
                String s = client.GetMarketAllIndex(0);
                List<string> tradeList = new List<string>(s.Split('$'));
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
                    vnIdx.TotalAmt = decimal.Parse(tradeData[2], dataCulture);

                    vn30Idx.Value = decimal.Parse(tradeData[11], dataCulture);
                    vn30Idx.TotalQty = decimal.Parse(tradeData[14], dataCulture);
                    vn30Idx.TotalAmt = decimal.Parse(tradeData[15], dataCulture);
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

    public class ssi_hastcIdxImport : marketImport
    {
        static MarketData hnIdx = new MarketData("HNX-IDX");
        static MarketData hnIdx30 = new MarketData("HNX30-IDX"); 

        public override databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            if (!GetData(exchangeDetailRow, ref hnIdx, ref hnIdx30)) return null;
            databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
            AddImportRow(updateTime, hnIdx, true, importPriceTbl);
            //AddImportRow(updateTime, vn30Idx, false, importPriceTbl);

            Imports.Libs.AddNewCode(exchangeDetailRow.marketCode, importPriceTbl, null);
            databases.DbAccess.UpdateData(importPriceTbl);

            databases.baseDS.priceDataDataTable priceTbl = new databases.baseDS.priceDataDataTable();
            Imports.Libs.AddImportPrice(importPriceTbl, priceTbl);
            databases.DbAccess.UpdateData(priceTbl);
            return priceTbl;
        }

        protected bool GetData(databases.baseDS.exchangeDetailRow exchangeDetailRow, ref MarketData hnIdx, ref MarketData hnIdx30)
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
                String s = client.GetMarketAllIndex(0);//.GetDataHaSTC2_Index();
                List<string> tradeList = new List<string>(s.Split('#'));
                for (int i = 0; i < tradeList.Count; i++)
                {
                    List<string> tradeData = new List<string>(tradeList[i].Split('|'));
                    if (tradeData[5].Trim() == "")
                    {
                        continue;
                    }
                    hnIdx.Value = decimal.Parse(tradeData[5], dataCulture);
                    hnIdx.TotalQty = decimal.Parse(tradeData[3], dataCulture);
                    hnIdx.TotalAmt = decimal.Parse(tradeData[4], dataCulture);

                    hnIdx30.Value = decimal.Parse(tradeData[10], dataCulture);
                    hnIdx30.TotalQty = decimal.Parse(tradeData[11], dataCulture);
                    hnIdx30.TotalAmt = decimal.Parse(tradeData[12], dataCulture);
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
}
