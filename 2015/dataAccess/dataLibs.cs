﻿using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms; 
using System.Data;
using System.Text;
using System.Drawing;
using System.Xml;
using commonTypes;
using commonClass;
using System.Net;

namespace DataAccess
{
    public class PleaseWait : common.PleaseWait
    {
        protected override common.forms.baseSlashForm DefaultSplashForm()
        {
            return new forms.splashForm();
        }
    }
    public enum ConnState : byte { None = 0, Connected = 1, Disconnected = 2 };
    public delegate void OnErrorEvent(Exception er);
    public delegate void OnConnStateChangedEvent(ConnState state);
    public static class Libs
    {
        public static ConnState myConnState = ConnState.None;
        public static OnErrorEvent OnError = null;
        public static OnConnStateChangedEvent OnConnStateChanged = null;

        const int constMaxReceivedMessageSize = 655360000;
        const int constMaxStringContentLength = 655360000;
        const int constMaxBytesPerRead = 65536000;

        #region system
        private static ServiceReference1.StockServiceClient _myClient = null;
        private static ServiceReference1.StockServiceClient myClient
        {
            get
            {
                if (_myClient == null || _myClient.State != System.ServiceModel.CommunicationState.Opened)
                {
                    Libs.myConnState = ConnState.Disconnected;
                }
                if (Libs.myConnState != ConnState.Connected)
                {
                    if (!OpenConnection()) return null;

                    Libs.myConnState = (_myClient.IsWorking()? ConnState.Connected:ConnState.Disconnected);
                    if (OnConnStateChanged != null) OnConnStateChanged(Libs.myConnState);
                }
                return _myClient;
            }
        }

        public static bool OpenConnection()
        {
            if (common.Settings.myWsConInfos.Length <= 0) return false;
            return OpenConnection(common.Settings.myWsConInfos[0]);
        }
        private static bool OpenConnection(common.wsConnectionInfo wsInfo)
        {
            if (_myClient != null) _myClient.Abort();
            //Basic binding
            _myClient = new ServiceReference1.StockServiceClient("basicEndpoint");
            //_myClient.Endpoint=new System.ServiceModel.Description.ServiceEndpoint(
            System.ServiceModel.BasicHttpBinding binding = (_myClient.Endpoint.Binding as System.ServiceModel.BasicHttpBinding);

            //Secure binding
            //_myClient = new ServiceReference1.StockServiceClient("wsEndpoint");
            //System.ServiceModel.WSHttpBinding binding = (_myClient.Endpoint.Binding as System.ServiceModel.WSHttpBinding);

            binding.OpenTimeout = TimeSpan.FromSeconds(wsInfo.timeoutInSecs);
            binding.CloseTimeout = TimeSpan.FromSeconds(wsInfo.timeoutInSecs);
            binding.SendTimeout = TimeSpan.FromSeconds(wsInfo.timeoutInSecs);

            binding.MaxBufferSize = constMaxReceivedMessageSize; //Basic HTTP require MaxBufferSize=MaxReceivedMessageSize
            binding.MaxReceivedMessageSize = constMaxReceivedMessageSize;
            binding.ReaderQuotas.MaxStringContentLength = constMaxStringContentLength;
            binding.ReaderQuotas.MaxBytesPerRead = constMaxBytesPerRead;

            //Proxy  must before setting Endpoint ?
            binding.UseDefaultWebProxy = false;
            if (wsInfo.useProxy)
            {
                if (wsInfo.useDefaultProxy) binding.UseDefaultWebProxy = true;
                else
                {
                    if (wsInfo.proxyAddress.Trim() != "" && wsInfo.proxyPort.Trim() != "")
                    {
                        binding.ProxyAddress = new Uri(wsInfo.proxyAddress.Trim() + ":" + wsInfo.proxyPort.Trim());
                        binding.BypassProxyOnLocal = true;
                        binding.UseDefaultWebProxy = false;
                    }
                }
            }
            //Endpoint settings
            _myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress(wsInfo.URI);
            if (wsInfo.isWindowAuthentication)
            {
                _myClient.ClientCredentials.Windows.ClientCredential.UserName = wsInfo.account;
                _myClient.ClientCredentials.Windows.ClientCredential.Password = wsInfo.password;
            }
            else
            {
                _myClient.ClientCredentials.UserName.UserName = wsInfo.account;
                _myClient.ClientCredentials.UserName.Password = wsInfo.password;
            }

            ServicePointManager.Expect100Continue = false; //loi proxy http://chrishaas.wordpress.com/2009/11/02/fixing-the-remote-server-returned-an-error-417-expectation-failed/
            ServicePointManager.UseNagleAlgorithm = true;
            ServicePointManager.CheckCertificateRevocationList = true;
            //ServicePointManager.DefaultConnectionLimit = ServicePointManager.DefaultPersistentConnectionLimit;

            //For testing
            if (Settings.sysDebugMode)
            {
                if (Settings.environmentMode == Settings.environmentDebugMode.localHP || Settings.environmentMode == Settings.environmentDebugMode.localT440)
                {
                    _myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://localhost:8731/wsServices/DataLibs");
                    _myClient.ClientCredentials.Windows.ClientCredential.UserName = "";
                    _myClient.ClientCredentials.Windows.ClientCredential.Password = "";
                }
            }
            //End testing

            _myClient.Open();
            myConnState = ConnState.Connected;
            
            return true;
        }
        private static void CloseConnection()
        {
            if (_myClient != null && (_myClient.State == System.ServiceModel.CommunicationState.Opened) )
            {
                _myClient.Close();
            }
            _myClient = null;
        }
        public static void ResetService()
        {
            using (new PleaseWait())
            {
                try
                {
                    CloseConnection();
                    myClient.ClearCache();
                    myClient.Reset();
                    GlobalSettings globalSetting = Settings.sysGlobal;
                    myClient.Load_Global_Settings(ref globalSetting);
                    Settings.sysGlobal = globalSetting;
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
            }
        }
        public static void Reset()
        {
            CloseConnection();
        }
        public static bool TestConnection(common.wsConnectionInfo wsInfo, out string msg)
        {
            msg = "";
            try
            {
                CloseConnection();
                OpenConnection(wsInfo);
                return true;
            }
            catch (Exception er)
            {
                msg = er.Message;
                return false;
            }
        }

        private static common.DictionaryList cacheData = new common.DictionaryList();
        public static string MakeCacheKey(object sender, string key)
        {
            return MakeCacheKey(sender.ToString(), key);
        }
        private static string MakeCacheKey(string type, string key)
        {
            return type + "-" + key;
        }
        public static void AddCache(string cacheKey, object data)
        {
            cacheData.Add(cacheKey, data);
        }
        public static object GetCache(string cacheKey)
        {
            return cacheData.Find(cacheKey);
        }
        public static void ClearCache(string cacheKey)
        {
            cacheData.Remove(cacheKey);

        }
        public static void ClearCache()
        {
            cacheData.Clear();
        }

        public static bool CheckConnection()
        {
            try
            {
                lock (myClient)
                {
                    return myClient.IsWorking();
                }
            }
            catch(Exception er)
            {
                OnError(er);
            }
            return false;
        }

        public static DateTime GetServerDateTime()
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetServerDateTime();
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return common.Consts.constNullDate; 
        }

        #endregion

        #region System variables
        public static void LoadSystemVars()
        {
            //DataTable tbl =  myClient.Test("select * from investor");

            object dummyObj;
            dummyObj = myStockCodeTbl;
            dummyObj = myStockExchangeTbl;
            //dummyObj = mySysCodeCatTbl;
            //dummyObj = myCountryTbl;
            //dummyObj = myInvestorCatTbl;
            //dummyObj = myEmployeeRangeTbl;
            //dummyObj = myBizSectorTbl;
            //dummyObj = myBizSubSectorTbl;
            //dummyObj = myBizSuperSectorTbl;
            //dummyObj = myBizSectorTbl;
            //dummyObj = myBizIndustryTbl;
            //GetStockFull(true);
            GetSystemWatchList();
        }

        
        public static databases.tmpDS.stockCodeDataTable myStockCodeTbl
        {
            get
            {
                try
                {
                    lock (myClient)
                    {
                        string cacheKey = MakeCacheKey("StockList", "Enable");
                        object obj = GetCache(cacheKey);
                        if (obj != null) return (databases.tmpDS.stockCodeDataTable)obj;
                        databases.tmpDS.stockCodeDataTable tbl = myClient.GetStockByStatus(AppTypes.CommonStatus.Enable);
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
            set
            {
                ClearCache(MakeCacheKey("StockList", "Enable"));
            }
        }

        /// <summary>
        /// Stock Exchange table
        /// </summary>
        public static databases.baseDS.stockExchangeDataTable myStockExchangeTbl
        {
            get
            {
                try
                {
                    lock (myClient)
                    {
                        string cacheKey = MakeCacheKey("stockExchange", "All");
                        object obj = GetCache(cacheKey);
                        if (obj != null) return (databases.baseDS.stockExchangeDataTable)obj;
                        databases.baseDS.stockExchangeDataTable tbl = myClient.GetStockExchange();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
            set
            {
                ClearCache(MakeCacheKey("stockExchange", "All"));
            }
        }
        public static databases.baseDS.sysCodeCatDataTable mySysCodeCatTbl
        {
            get
            {
                try
                {
                    lock (myClient)
                    {
                        string cacheKey = MakeCacheKey("SysCodeCat", "All");
                        object obj = GetCache(cacheKey);
                        if (obj != null) return (databases.baseDS.sysCodeCatDataTable)obj;
                        databases.baseDS.sysCodeCatDataTable tbl = myClient.GetSysCodeCat();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }
        
        /// <summary>
        /// Currency table
        /// </summary>
        public static databases.baseDS.currencyDataTable myCurrencyTbl
        {
            get
            {
                try
                {
                    lock (myClient)
                    {
                        string cacheKey = MakeCacheKey("Currency", "All");
                        object obj = GetCache(cacheKey);
                        if (obj != null) return (databases.baseDS.currencyDataTable)obj;
                        databases.baseDS.currencyDataTable tbl = myClient.GetCurrency();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }

        /// <summary>
        /// Country table
        /// </summary>
        public static databases.baseDS.countryDataTable myCountryTbl
        {
            get
            {
                try
                {
                   string cacheKey = MakeCacheKey("Country", "All");
                   object obj = GetCache(cacheKey);
                   if (obj != null) return (databases.baseDS.countryDataTable)obj;
                   lock (myClient)
                   {
                        databases.baseDS.countryDataTable tbl = myClient.GetCountry();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }

        /// <summary>
        /// Investor categories
        /// </summary>
        public static databases.baseDS.investorCatDataTable myInvestorCatTbl
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("InvestorCat", "All");
                    object obj = GetCache(cacheKey);
                    if (obj != null) return (databases.baseDS.investorCatDataTable)obj;
                    lock (myClient)
                    {
                        databases.baseDS.investorCatDataTable tbl = myClient.GetInvestorCat();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }
        public static databases.baseDS.employeeRangeDataTable myEmployeeRangeTbl
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("EmployeeRange", "All");
                    object obj = GetCache(cacheKey);
                    if (obj != null) return (databases.baseDS.employeeRangeDataTable)obj;
                    lock (myClient)
                    {
                        databases.baseDS.employeeRangeDataTable tbl = myClient.GetEmployeeRange();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }
        public static databases.baseDS.bizSectorDataTable myBizSectorTbl
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("BizSector", "All");
                    object obj = GetCache(cacheKey);
                    if (obj != null) return (databases.baseDS.bizSectorDataTable)obj;
                    lock (myClient)
                    {
                        databases.baseDS.bizSectorDataTable tbl = myClient.GetBizSector();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }

        public static databases.baseDS.bizSubSectorDataTable myBizSubSectorTbl
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("BizSubSector", "All");
                    object obj = GetCache(cacheKey);
                    if (obj != null) return (databases.baseDS.bizSubSectorDataTable)obj;
                    lock (myClient)
                    {
                        databases.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }
        public static databases.baseDS.bizSuperSectorDataTable myBizSuperSectorTbl
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("BizSuperSector", "All");
                    object obj = GetCache(cacheKey);
                    if (obj != null) return (databases.baseDS.bizSuperSectorDataTable)obj;
                    lock (myClient)
                    {
                        databases.baseDS.bizSuperSectorDataTable tbl = myClient.GetBizSuperSector();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }
        public static databases.baseDS.bizIndustryDataTable myBizIndustryTbl
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("BizIndustry", "All");
                    object obj = GetCache(cacheKey);
                    if (obj != null) return (databases.baseDS.bizIndustryDataTable)obj;
                    lock (myClient)
                    {
                        databases.baseDS.bizIndustryDataTable tbl = myClient.GetBizIndustry();
                        AddCache(cacheKey, tbl);
                        return tbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }
        #endregion

        #region Load/Get

        public static databases.baseDS.feedbackCatDataTable GetFeedbackCat(string cultureCode)
        {
            try
            {
                lock (myClient)
                {
                    string cacheKey = MakeCacheKey("feedbackCat", cultureCode);
                    databases.baseDS.feedbackCatDataTable tbl = myClient.GetFeedbackCat(cultureCode);
                    AddCache(cacheKey, tbl);
                    return tbl;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.sysLogDataTable GetSyslog_ByDate(DateTime frDate, DateTime toDate)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetSyslog_ByDate(frDate, toDate);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.sysLogDataTable GetSyslog_BySQL(string sql)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetSyslog_BySQL(sql);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.messagesDataTable GetMesssage_ByDate(DateTime frDate, DateTime toDate)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetMesssage_ByDate(frDate, toDate);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.messagesDataTable GetMesssage_BySql(string sql)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetMesssage_BySql(sql);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }


        public static databases.baseDS.priceDataDataTable GetAbnormalData(string code,DateTime frDate,DateTime toDate,string timeScaleCode)
        {
            try
            {
                //return myClient.GetAbnormalData(code, frDate, toDate, timeScaleCode);
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static bool LoadData(databases.baseDS.exchangeDetailDataTable tbl,string code)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.exchangeDetailDataTable tmpTbl = myClient.GetExchangeDetail(code);
                    if (tmpTbl == null) return false;
                    common.system.Concat(tmpTbl, 0, tbl);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return true;
        }

        public static databases.baseDS.stockCodeDataTable GetStockFull(bool force)
        {
            try
            {
                string cacheKey = MakeCacheKey("StockFull", "All");
                if (!force)
                {
                    object obj = GetCache(cacheKey);
                    if (obj != null) return (databases.baseDS.stockCodeDataTable)obj;
                }
                lock (myClient)
                {
                    databases.baseDS.stockCodeDataTable tbl = myClient.GetStockFull();
                    AddCache(cacheKey, tbl);
                    return tbl;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.portfolioDataTable GetSystemWatchList()
        {
            try
            {
                string cacheKey = MakeCacheKey("SysWatchList", "List");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.portfolioDataTable)obj;
                lock (myClient)
                {
                    databases.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByType(AppTypes.PortfolioTypes.SysWatchList);
                    AddCache(cacheKey, tbl);
                    return tbl;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.portfolioRow GetPortfolio_DefaultStrategy()
        {
            try
            {
                string cacheKey = MakeCacheKey("SysPortfolio", "DefaultStrategy");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.portfolioRow)obj;
                lock (myClient)
                {
                    databases.baseDS.portfolioRow row = null;
                    databases.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByType(AppTypes.PortfolioTypes.PortfolioDefaultStrategy);
                    if (tbl.Count == 0)
                    {
                        row = tbl.NewportfolioRow();
                        databases.AppLibs.InitData(row);
                        row.type = (byte)AppTypes.PortfolioTypes.PortfolioDefaultStrategy;
                        row.code = Consts.constMarkerNEW;
                        row.investorCode = commonClass.SysLibs.sysLoginCode;
                        tbl.AddportfolioRow(row);
                        myClient.UpdatePortfolio(ref tbl);
                    }
                    row = tbl[0];
                    AddCache(cacheKey, row);
                    return row;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.portfolioRow GetPortfolio_ByCode(string code)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByCode(code);
                    if (tbl.Count == 0) return null;
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.portfolioDataTable GetPortfolio_ByType(AppTypes.PortfolioTypes type)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetPortfolio_ByType(type);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.portfolioDataTable GetPortfolio_ByInvestorAndType(string investorCode, AppTypes.PortfolioTypes type)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetPortfolio_ByInvestorAndType(investorCode, type);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.portfolioDataTable GetPortfolio_ByInvestor(string investorCode)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetPortfolio_ByInvestor(investorCode);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByCode(string portfolioCode)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetPortfolioDetail_ByCode(portfolioCode);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByType(AppTypes.PortfolioTypes[] types)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetPortfolioDetail_ByType(types);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.tradeAlertDataTable GetTradeAlert(DateTime frDate, DateTime toDate, string investor, byte statusMask)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetTradeAlert(frDate, toDate, investor, statusMask);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.tradeAlertDataTable GetTradeAlert_BySQL(string sql)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetTradeAlert_BySQL(sql);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.transactionsDataTable GetTransactions_BySQL(string sql)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetTransaction_BySQL(sql);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.investorStockDataTable GetOwnedStock_ByPortfolio(string portfolio)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetOwnedStock_ByPortfolio(portfolio);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.tmpDS.investorStockDataTable GetOwnedStockSum_ByInvestor(string investorCode)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetOwnedStockSum_ByInvestor(investorCode);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.tmpDS.stockCodeDataTable GetStock_InPortfolio(StringCollection portfolios)
        {
            lock (myClient)
            {
                return myClient.GetStock_InPortfolio(common.system.Collection2List(portfolios));
            }
        }
        private static databases.tmpDS.stockCodeDataTable StockFromCodeList(string[] codes)
        {
            try
            {
                databases.tmpDS.stockCodeDataTable retTbl = new databases.tmpDS.stockCodeDataTable();

                databases.tmpDS.stockCodeRow stockRow;
                databases.tmpDS.stockCodeDataTable stockCodeTbl = myStockCodeTbl;
                for (int idx = 0; idx < codes.Length; idx++)
                {
                    stockRow = stockCodeTbl.FindBycode(codes[idx]);
                    if (stockRow != null) retTbl.ImportRow(stockRow);
                }
                return retTbl;
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.tmpDS.stockCodeDataTable GetStock_ByWatchList(StringCollection codes)
        {
            try
            {
                lock (myClient)
                {
                    string[] codeList = myClient.GetStockList_ByWatchList(common.system.Collection2List(codes));
                    return StockFromCodeList(codeList);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static string[] GetStockList_ByWatchList(StringCollection codes)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetStockList_ByWatchList(common.system.Collection2List(codes));
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static string[] GetStockList_ByBizSector(StringCollection codes)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetStockList_ByBizSector(common.system.Collection2List(codes));
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;

        }

        public static databases.tmpDS.stockCodeDataTable GetStock_ByBizSector(StringCollection bizSector)
        {
            try
            {
                lock (myClient)
                {
                    return StockFromCodeList(myClient.GetStockList_ByBizSector(common.system.Collection2List(bizSector)));
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.bizSubSectorDataTable GetBizSubSector_ByIndustry(string code)
        {
            try
            {
                string cacheKey = MakeCacheKey("BizSubSector_ByIndustry", code);
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.bizSubSectorDataTable)obj;
                lock (myClient)
                {
                    databases.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_ByIndustry(code);
                    AddCache(cacheKey, tbl);
                    return tbl;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySuperSector(string code)
        {
            try
            {
                string cacheKey = MakeCacheKey("BizSubSector_BySuperSector", code);
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.bizSubSectorDataTable)obj;
                lock (myClient)
                {
                    databases.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_BySuperSector(code);
                    AddCache(cacheKey, tbl);
                    return tbl;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySector(string code)
        {
            try
            {
                string cacheKey = MakeCacheKey("BizSubSector_BySector", code);
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.bizSubSectorDataTable)obj;
                lock (myClient)
                {
                    databases.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_BySector(code);
                    AddCache(cacheKey, tbl);
                    return tbl;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        
        public static databases.baseDS.investorDataTable GetInvestor_BySQL(string sql)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetInvestor_BySQL(sql);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.investorDataTable GetInvestor_ByCode(string code)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetInvestor_ByCode(code);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.investorDataTable GetInvestor_ByAccount(string account)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
                    //string sql = "SELECT * FROM " + tbl.TableName +
                    //                                   " WHERE " + tbl.accountColumn.ColumnName + "=N'" + account + "'";
                    string sql = "SELECT * FROM " + tbl.TableName +
                                                       " WHERE " + tbl.accountColumn.ColumnName + "='" + account + "'";
                    return myClient.GetInvestor_BySQL(sql);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.investorDataTable GetInvestor_ByCriteria(string criteria)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
                    return myClient.GetInvestor_BySQL("SELECT * FROM " + tbl.TableName + (criteria.Trim() == "" ? "" : " WHERE " + criteria));
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.tmpDS.investorDataTable GetInvestorShortList()
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetInvestorShortList();
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }


        public static databases.baseDS.sysCodeCatDataTable GetSysCodeCat()
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetSysCodeCat();
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.sysCodeDataTable GetSysCode(string catCode)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetSysCode(catCode);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }


        public static databases.baseDS.priceDataDataTable GetPriceData(string stockCode,string timeScaleCode,DateTime frDate, DateTime toDate)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetPriceData(stockCode, timeScaleCode, frDate, toDate);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;

        }


        private class LastPriceCache
        {
            public DateTime CacheTime = common.Consts.constNullDate;
            public databases.baseDS.lastPriceDataDataTable DataTbl = null;
        }
        public static databases.baseDS.lastPriceDataDataTable myLastDailyClosePrice
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("LastPrice", "Close");
                    LastPriceCache lastPriceCache = (LastPriceCache)GetCache(cacheKey);
                    if (lastPriceCache != null && 
                        common.dateTimeLibs.DateDiffInSecs(lastPriceCache.CacheTime, DateTime.Now) <= commonTypes.Settings.sysGlobal.RefreshDataInSecs)
                        return lastPriceCache.DataTbl;

                    lock (myClient)
                    {
                        if (lastPriceCache == null) lastPriceCache = new LastPriceCache();
                        string timeScaleCode = AppTypes.TimeScaleFromType(AppTypes.TimeScaleTypes.Day).Code;
                        lastPriceCache.DataTbl = myClient.GetLastPriceSum(AppTypes.PriceDataType.Close, timeScaleCode);
                        lastPriceCache.CacheTime = DateTime.Now;
                        AddCache(cacheKey, lastPriceCache);
                        return lastPriceCache.DataTbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }
        public static databases.baseDS.lastPriceDataDataTable myLastDailyOpenPrice
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("LastPrice", "Open");
                    LastPriceCache lastPriceCache = (LastPriceCache)GetCache(cacheKey);
                    if (lastPriceCache != null && lastPriceCache.CacheTime== DateTime.Today)
                        return lastPriceCache.DataTbl;
                    lock (myClient)
                    {
                        if (lastPriceCache == null) lastPriceCache = new LastPriceCache();
                        string timeScaleCode = AppTypes.TimeScaleFromType(AppTypes.TimeScaleTypes.Day).Code;
                        lastPriceCache.DataTbl = myClient.GetLastPriceSum(AppTypes.PriceDataType.Open, timeScaleCode);
                        lastPriceCache.CacheTime = DateTime.Today;
                        AddCache(cacheKey, lastPriceCache);
                        return lastPriceCache.DataTbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }

        /// <summary>
        /// Lay Volume trong ngay cua mot Stock
        /// </summary>
        public static databases.baseDS.lastPriceDataDataTable myLastDailyVolume
        {
            get
            {
                try
                {
                    string cacheKey = MakeCacheKey("LastPrice", "Volume");
                    LastPriceCache lastPriceCache = (LastPriceCache)GetCache(cacheKey);
                    if (lastPriceCache != null && lastPriceCache.CacheTime == DateTime.Today)
                        return lastPriceCache.DataTbl;
                    lock (myClient)
                    {
                        if (lastPriceCache == null) lastPriceCache = new LastPriceCache();
                        string timeScaleCode = AppTypes.TimeScaleFromType(AppTypes.TimeScaleTypes.Day).Code;
                        lastPriceCache.DataTbl = myClient.GetLastPriceSum(AppTypes.PriceDataType.Volume, timeScaleCode);
                        lastPriceCache.CacheTime = DateTime.Today;
                        AddCache(cacheKey, lastPriceCache);
                        return lastPriceCache.DataTbl;
                    }
                }
                catch (Exception er)
                {
                    if (OnError != null) OnError(er);
                }
                return null;
            }
        }
        public static bool GetTransactionInfo(ref TransactionInfo transInfo)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetTransactionInfo(ref transInfo);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return false;
        }

        public static DateTime GetLastAlertTime(string investorCode)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetLastAlertTime(investorCode);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return common.Consts.constNullDate;
        }

        public static databases.baseDS.priceDataDataTable GetData_ByTimeScale_Code_FrDate(string timeScaleCode, string stockCode, DateTime fromDate)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetData_ByTimeScale_Code_FrDate(timeScaleCode, stockCode, fromDate);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.priceDataDataTable GetData_ByTimeScale_Code_DateRange(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetData_ByTimeScale_Code_DateRange(timeScaleCode, stockCode, frDate, toDate);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static int GetData_TotalRow(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetData_TotalRow(timeScaleCode, stockCode, frDate, toDate);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return -1;
        }
        #endregion 

        #region Delete
        public static void DeleteData(databases.baseDS.stockExchangeRow row)
        {
            try
            {
                lock (myClient)
                {
                    myClient.DeleteStockExchange(row.code);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        public static void DeleteData(databases.baseDS.stockCodeRow row)
        {
            try
            {
                lock (myClient)
                {
                    myClient.DeleteStock(row.code);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        public static void DeleteData(databases.baseDS.investorRow row)
        {
            try
            {
                lock (myClient)
                {
                    myClient.DeleteInvestor(row.code);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        public static void DeleteData(databases.baseDS.portfolioRow row)
        {
            try
            {
                lock (myClient)
                {
                    myClient.DeletePortfolio(row.code);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }

        public static void DeleteData(databases.baseDS.sysCodeCatRow row)
        {
            try
            {
                lock (myClient)
                {
                    myClient.DeleteSysCodeCat(row.category);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        public static void DeleteData(databases.baseDS.sysCodeRow row)
        {
            try
            {
                lock (myClient)
                {
                    myClient.DeleteSysCode(row.category, row.code);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }

        public static void DeleteTradeAlert(int alertId)
        {
            try
            {
                lock (myClient)
                {
                    myClient.DeleteTradeAlert(alertId);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        #endregion

        #region Update
        public static void UpdateData(databases.baseDS.priceDataDataTable data)
        {
            try
            {
                lock (myClient)
                {
                    myClient.UpdatePriceData(ref data);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        public static databases.baseDS.sysCodeCatRow UpdateData(databases.baseDS.sysCodeCatRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.sysCodeCatDataTable tbl = new databases.baseDS.sysCodeCatDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateSysCodeCat(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.sysCodeRow UpdateData(databases.baseDS.sysCodeRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.sysCodeDataTable tbl = new databases.baseDS.sysCodeDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateSysCode(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.stockCodeRow UpdateData(databases.baseDS.stockCodeRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.stockCodeDataTable tbl = new databases.baseDS.stockCodeDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateStock(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.investorRow UpdateData(databases.baseDS.investorRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateInvestor(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.portfolioRow UpdateData(databases.baseDS.portfolioRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdatePortfolio(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static void UpdateData(databases.baseDS.portfolioDetailDataTable tbl)
        {
            try
            {
                lock (myClient)
                {
                    myClient.UpdatePortfolioDetail(ref tbl);
                    tbl.AcceptChanges();
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }

        public static databases.baseDS.stockExchangeRow UpdateData(databases.baseDS.stockExchangeRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.stockExchangeDataTable tbl = new databases.baseDS.stockExchangeDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateStockExchange(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static bool UpdateData(databases.baseDS.exchangeDetailDataTable data)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.exchangeDetailDataTable tbl = new databases.baseDS.exchangeDetailDataTable();
                    common.system.Concat(data, 0, tbl);
                    myClient.UpdateExchangeDetail(ref tbl);
                    data.AcceptChanges();
                    return true;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return false;
        }
        public static databases.baseDS.transactionsRow UpdateData(databases.baseDS.transactionsRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.transactionsDataTable tbl = new databases.baseDS.transactionsDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateTransactions(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.investorStockRow UpdateData(databases.baseDS.investorStockRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.investorStockDataTable tbl = new databases.baseDS.investorStockDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateInvestorStock(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.tradeAlertRow UpdateData(databases.baseDS.tradeAlertRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.tradeAlertDataTable tbl = new databases.baseDS.tradeAlertDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateTradeAlert(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.messagesRow UpdateData(databases.baseDS.messagesRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.messagesDataTable tbl = new databases.baseDS.messagesDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateMessage(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static databases.baseDS.sysAutoKeyPendingRow UpdateData(databases.baseDS.sysAutoKeyPendingRow row)
        {
            try
            {
                lock (myClient)
                {
                    databases.baseDS.sysAutoKeyPendingDataTable tbl = new databases.baseDS.sysAutoKeyPendingDataTable();
                    tbl.ImportRow(row);
                    myClient.UpdateSysAutoKeyPending(ref tbl);
                    row.AcceptChanges();
                    return tbl[0];
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        #endregion Update

        #region client
        public static double[][] Estimate_Matrix_LastBizWeight(DataParams dataParam,string[] stockCodeList, string[] strategyList)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.Estimate_Matrix_LastBizWeight(dataParam, stockCodeList, strategyList);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static decimal[][] Estimate_Matrix_Profit(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                         string[] stocks, string[] strategyList, EstimateOptions option)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.Estimate_Matrix_Profit(timeRange, timeScaleCode, stocks, strategyList, option);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type, string stockCode, 
                                                                        string portfolioCode, int qty, decimal feePerc)
        {
            try
            {
                lock (myClient)
                {
                    string errorText = "";
                    databases.baseDS.transactionsDataTable retVal = myClient.MakeTransaction(out errorText, type, stockCode, portfolioCode, qty, feePerc);
                    if (retVal == null) common.system.ShowErrorMessage(errorText);
                    return retVal;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null; 
        }

        private class AnalysisDataCache
        {
            public databases.baseDS.priceDataDataTable dataTbl = null;
            public int firstData=0;
        }
        private static string MakeAnalysisDataCacheKey(commonClass.BaseAnalysisData dataObj)
        {
            try
            {
                return "AnalysisData" + "-" + dataObj.DataStockCode + "-" + dataObj.DataTimeRange.ToString() + "-" +
                        dataObj.DataTimeScale.Code;
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static void ClearAnalysisDataCache(commonClass.BaseAnalysisData dataObj)
        {
            try
            {
                cacheData.Remove(MakeAnalysisDataCacheKey(dataObj));
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        public static bool LoadAnalysisData(commonClass.BaseAnalysisData dataObj)
        {
            try
            {
                AnalysisDataCache data;
                string cacheKey = MakeAnalysisDataCacheKey(dataObj);
                object obj = GetCache(cacheKey);
                if (obj != null)
                {
                    data = (AnalysisDataCache)obj;
                    dataObj.priceDataTbl = (databases.baseDS.priceDataDataTable)data.dataTbl.Copy();
                    return true;
                }
                using (new PleaseWait())
                {
                    lock (myClient)
                    {
                        data = new AnalysisDataCache();
                        int firstData = 0;
                        DataParams dataParam = new DataParams(dataObj.DataTimeScale.Code, dataObj.DataTimeRange, dataObj.DataMaxCount);
                        data.dataTbl = myClient.GetAnalysis_Data(out firstData, dataObj.DataStockCode, dataParam);
                        data.firstData = firstData;
                        AddCache(cacheKey, data);
                        dataObj.priceDataTbl = (databases.baseDS.priceDataDataTable)data.dataTbl.Copy();
                        dataObj.FirstDataStartAt = firstData;
                    }
                }
                return true;
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return false;
        }

        public static TradePointInfo[] GetTradePointWithEstimationDetail(DataParams dataParam,string stockCode, string strategyCode, 
                                                                         EstimateOptions options,out databases.tmpDS.tradeEstimateDataTable toTbl,
                                                                            out application.StrategyStatistics statistics)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.GetTradePointWithEstimationDetail(out toTbl,out statistics, dataParam, stockCode, strategyCode, options);
                }
            }
            catch (Exception er)
            {
                toTbl = null;
                statistics = null;
                if (OnError != null) OnError(er);
            }
            return null;
        }
        
        //Updated data from the last read/update point
        public static int UpdateAnalysisData(commonClass.BaseAnalysisData dataObj)
        {
            try
            {
                int lastDataIdx = dataObj.priceDataTbl.Count - 1;
                DateTime lastDateTime;
                if (lastDataIdx < 0) lastDateTime = Settings.sysStartDataDate;
                else lastDateTime = dataObj.priceDataTbl[lastDataIdx].onDate;

                databases.baseDS.priceDataDataTable tbl = GetData_ByTimeScale_Code_FrDate(dataObj.DataTimeScale.Code, dataObj.DataStockCode, lastDateTime);
                if (tbl.Count > 0)
                {
                    //Delete the last data because the updated data will include this one.
                    if (lastDataIdx >= 0)
                    {
                        dataObj.priceDataTbl[lastDataIdx].ItemArray = tbl[0].ItemArray;
                        common.system.Concat(tbl, 1, dataObj.priceDataTbl);
                    }
                    else common.system.Concat(tbl, 0, dataObj.priceDataTbl);

                    //Update data 
                    dataObj.DateTime.UpdateLast(DataLibs.GetDataList(tbl, 0, 0, AppTypes.PriceDataType.DateTime));
                    dataObj.DateTime.Add2Last(DataLibs.GetDataList(tbl, 1, AppTypes.PriceDataType.DateTime));

                    dataObj.Open.UpdateLast(DataLibs.GetDataList(tbl, 0, 0, AppTypes.PriceDataType.Open));
                    dataObj.Open.Add2Last(DataLibs.GetDataList(tbl, 1, AppTypes.PriceDataType.Open));

                    dataObj.High.UpdateLast(DataLibs.GetDataList(tbl, 0, 0, AppTypes.PriceDataType.High));
                    dataObj.High.Add2Last(DataLibs.GetDataList(tbl, 1, AppTypes.PriceDataType.High));

                    dataObj.Low.UpdateLast(DataLibs.GetDataList(tbl, 0, 0, AppTypes.PriceDataType.Low));
                    dataObj.Low.Add2Last(DataLibs.GetDataList(tbl, 1, AppTypes.PriceDataType.Low));

                    dataObj.Close.UpdateLast(DataLibs.GetDataList(tbl, 0, 0, AppTypes.PriceDataType.Close));
                    dataObj.Close.Add2Last(DataLibs.GetDataList(tbl, 1, AppTypes.PriceDataType.Close));

                    dataObj.Volume.UpdateLast(DataLibs.GetDataList(tbl, 0, 0, AppTypes.PriceDataType.Volume));
                    dataObj.Volume.Add2Last(DataLibs.GetDataList(tbl, 1, AppTypes.PriceDataType.Volume));
                }
                return dataObj.priceDataTbl.Count - 1 - lastDataIdx;
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return -1;
        }

        #endregion
        
        #region Configuration
        public static bool Load_Global_Settings()
        {
            try
            {
                lock (myClient)
                {
                    GlobalSettings globSettings = Settings.sysGlobal;
                    myClient.Load_Global_Settings(ref globSettings);
                    Settings.sysGlobal = globSettings;
                    return true;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return false; 
        }
        public static void Save_Global_Settings()
        {
            try
            {
                lock (myClient)
                {
                    GlobalSettings globSettings = Settings.sysGlobal;
                    myClient.Save_Global_Settings(globSettings);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        #endregion

        #region syslog
        public static void WriteLog(AppTypes.SyslogTypes logType, string investorCode, string desc, string source, string msg)
        {
            try
            {
                lock (myClient)
                {
                    myClient.WriteLog((byte)logType, investorCode, desc, source, msg);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        public static void WriteLog(byte logType, string investorCode, string desc, string source, string msg)
        {
            try
            {
                lock (myClient)
                {
                    myClient.WriteLog(logType, investorCode, desc, source, msg);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }
        public static void WriteLog(string investorCode, Exception er)
        {
            try
            {
                lock (myClient)
                {
                    //myClient.WriteExcptionLog(investorCode,
                    //myClient.WriteExcptionLog(investorCode, common.SysLog.MakeData(er));
                }
            }
            catch (Exception ex)
            {
                if (OnError != null) OnError(ex);
            }
        }
        #endregion

        /// <summary>
        /// Get top N  of weekly varriance
        /// </summary>
        /// <param name="topN"></param>
        /// <returns></returns>
        public static databases.tmpDS.dataVarrianceDataTable GetTopPriceVarrianceWeekly(byte topN)
        {
            try
            {
                string cacheKey = MakeCacheKey("PriceVarrianceWeekly", "Market");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.tmpDS.dataVarrianceDataTable)obj;

                lock (myClient)
                {
                    //Maybe there are some holidays or weekend so wee need to look before some days 
                    DateTime beforeDate = DateTime.Today.AddDays(-commonTypes.Settings.sysGlobal.DayScanForLastPrice);
                    databases.tmpDS.dataVarrianceDataTable tbl = myClient.GetTopPriceVarrianceMarket(beforeDate, AppTypes.TimeScaleTypeToCode(AppTypes.TimeScaleTypes.Week), topN);
                    AddCache(cacheKey, tbl);
                    return tbl;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static databases.tmpDS.dataVarrianceDataTable GetTopPriceVarrianceWeeklyOfLoginUser(byte topN)
        {
            try
            {
                string cacheKey = MakeCacheKey("PriceVarrianceWeekly", "Login");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.tmpDS.dataVarrianceDataTable)obj;

                lock (myClient)
                {
                    //Maybe there are some holidays or weekend so wee need to look before some days 
                    DateTime beforeDate = DateTime.Today.AddDays(-commonTypes.Settings.sysGlobal.DayScanForLastPrice);
                    databases.tmpDS.dataVarrianceDataTable tbl = myClient.GetTopPriceVarrianceUser(beforeDate, AppTypes.TimeScaleTypeToCode(AppTypes.TimeScaleTypes.Week),
                                                                                                   commonClass.SysLibs.sysLoginCode, topN);
                    AddCache(cacheKey, tbl);
                    return tbl;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        public static void ReAggregatePriceData(string code)
        {
            try
            {
                lock (myClient)
                {
                    myClient.ReAggregatePriceData(code);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
        }

        //In testing
        public static databases.tmpDS.priceDiagnoseDataTable DiagnosePrice_CloseAndNextOpen(DateTime frDate, DateTime toDate, 
                                                                                            string timeScaleCode,
                                                                                            string exchangeCode,string code, 
                                                                                            double variancePerc, 
                                                                                            double variance,byte precision)
        {
            try
            {
                lock (myClient)
                {
                    return myClient.DiagnosePrice_CloseAndNextOpen(frDate, toDate, timeScaleCode, exchangeCode, code, variancePerc, variance, precision);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        ///// <summary>
        /// Update data to the most recent from the last update.
        /// </summary>
        /// <returns>Number of updated items</returns>
        //public static int UpdateAnalysisData()
        //{
        //    int numberOfUpdate = UpdateAnalysisData(this);
        //    this.ClearCache();
        //    return numberOfUpdate;
        //}

        public static XmlDocument GetXmlDocumentSTRATEGY()
        {
            try
            {
                lock (myClient)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(myClient.GetXmlDoc2StringSTRATEGY());
                    return xmlDoc;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }
        public static XmlDocument GetXmlDocumentINDICATOR()
        {
            try
            {
                lock (myClient)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(myClient.GetXmlDoc2StringINDICATOR());
                    return xmlDoc;
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return null;
        }

        //public static DataValues[] GetIndicatorData(string code, DataParams dataParam, string metaName)
        //{
        //    try
        //    {
        //        string cacheKey = MakeCacheKey("IndicatorData", dataParam.ToUniqueString());
        //        cacheKey = MakeCacheKey(cacheKey,metaName);
        //        object obj = GetCache(cacheKey);
        //        if (obj != null) return (DataValues[])obj;
        //        lock (myClient)
        //        {
        //            DataValues[] data = myClient.GetIndicatorData(code, dataParam, metaName);
        //            AddCache(cacheKey, data);
        //            return data;
        //        }
        //    }
        //    catch (Exception er)
        //    {
        //        if (OnError != null) OnError(er);
        //    }
        //    return null;
        //}

        /// <summary>
        /// Tim chien luoc tot nhat 
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="timeFrame"></param>
        /// <returns></returns>
        public static string GetBestStrategyCode(string stockCode,string timeFrame,int order)
        {
            string bestStrategyCode = "STR041";
            try
            {
                lock (myClient)
                {
                    return myClient.GetBestStrategyCode(stockCode,timeFrame,order);
                }
            }
            catch (Exception er)
            {
                if (OnError != null) OnError(er);
            }
            return bestStrategyCode;
        }
    }
}
