using System;
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
    
    public static class Libs
    {
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
                    OpenConnection();
                }
                return _myClient;
            }
        }

        private static void OpenConnection()
        {
            if (common.Settings.myWsConInfos.Length <= 0)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("runSetupToCreateConfigFile"));
                common.system.ExitApplication();
                return;
            }
            OpenConnection(common.Settings.myWsConInfos[0]);
        }
        private static void OpenConnection(common.wsConnectionInfo wsInfo)
        {
            if (_myClient != null) _myClient.Abort();
            _myClient = new ServiceReference1.StockServiceClient();

            System.ServiceModel.WSHttpBinding binding = (_myClient.Endpoint.Binding as System.ServiceModel.WSHttpBinding);

            binding.OpenTimeout = TimeSpan.FromSeconds(wsInfo.timeoutInSecs);
            binding.CloseTimeout = TimeSpan.FromSeconds(wsInfo.timeoutInSecs);
            binding.SendTimeout = TimeSpan.FromSeconds(wsInfo.timeoutInSecs);

            binding.MaxReceivedMessageSize = constMaxReceivedMessageSize;
            binding.ReaderQuotas.MaxStringContentLength = constMaxStringContentLength;
            binding.ReaderQuotas.MaxBytesPerRead = constMaxBytesPerRead;

            //Proxy  must befor setting Endpoint ?
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
            ServicePointManager.DefaultConnectionLimit = ServicePointManager.DefaultPersistentConnectionLimit;

            //For testing
            if (common.Settings.sysTestMode)
            {
                //_myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://localhost:8731/wsServices/DataLibs/?wsdl");
                _myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://localhost:8731/wsServices/DataLibs");
                _myClient.ClientCredentials.Windows.ClientCredential.UserName = "";
                _myClient.ClientCredentials.Windows.ClientCredential.Password = "";
            }
            //End testing

            _myClient.Open();
            //DataTable tbl = _myClient.Test("select * from investor");
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
                CloseConnection();
                myClient.ClearCache();
                myClient.Reset();
                GlobalSettings globalSetting = Settings.sysGlobal;
                myClient.Load_Global_Settings(ref globalSetting);
                Settings.sysGlobal = globalSetting;
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
                return myClient.IsWorking();
            }
            catch{}
            return false;
        }

        public static DateTime GetServerDateTime()
        {
            return myClient.GetServerDateTime();
        }

        #endregion

        #region System variables
        public static void LoadSystemVars()
        {
            //DataTable tbl =  myClient.Test("select * from investor");

            object dummyObj;
            dummyObj = myStockCodeTbl;
            dummyObj = myStockExchangeTbl;
            dummyObj = mySysCodeCatTbl;
            dummyObj = myCountryTbl;
            dummyObj = myInvestorCatTbl;
            dummyObj = myEmployeeRangeTbl;
            dummyObj = myBizSectorTbl;
            dummyObj = myBizSubSectorTbl;
            dummyObj = myBizSuperSectorTbl;
            dummyObj = myBizSectorTbl;
            dummyObj = myBizIndustryTbl;
            //GetStockFull(true);
            GetSystemWatchList();
        }

        public static databases.tmpDS.investorDataTable  myInvestorShortTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("Investor", "Short");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.tmpDS.investorDataTable)obj;
                databases.tmpDS.investorDataTable tbl = myClient.GetInvestorShortList();
                AddCache(cacheKey, tbl);
                return tbl;
            }
            set
            {
                ClearCache(MakeCacheKey("Investor", "Short"));
            }
        }
        public static databases.tmpDS.stockCodeDataTable myStockCodeTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("StockList", "Enable");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.tmpDS.stockCodeDataTable)obj;
                databases.tmpDS.stockCodeDataTable tbl = myClient.GetStockByStatus(AppTypes.CommonStatus.Enable);
                AddCache(cacheKey, tbl);
                return tbl;
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
                string cacheKey = MakeCacheKey("stockExchange", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.stockExchangeDataTable)obj;
                databases.baseDS.stockExchangeDataTable tbl = myClient.GetStockExchange();
                AddCache(cacheKey, tbl);
                return tbl;
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
                string cacheKey = MakeCacheKey("SysCodeCat", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.sysCodeCatDataTable)obj;
                databases.baseDS.sysCodeCatDataTable tbl = myClient.GetSysCodeCat();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }

        /// <summary>
        /// Currency table
        /// </summary>
        public static databases.baseDS.currencyDataTable myCurrencyTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("Currency", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.currencyDataTable)obj;
                databases.baseDS.currencyDataTable tbl = myClient.GetCurrency();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }

        /// <summary>
        /// Country table
        /// </summary>
        public static databases.baseDS.countryDataTable myCountryTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("Country", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.countryDataTable)obj;
                databases.baseDS.countryDataTable tbl = myClient.GetCountry();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }

        /// <summary>
        /// Investor categories
        /// </summary>
        public static databases.baseDS.investorCatDataTable myInvestorCatTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("InvestorCat", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.investorCatDataTable)obj;
                databases.baseDS.investorCatDataTable tbl = myClient.GetInvestorCat();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static databases.baseDS.employeeRangeDataTable myEmployeeRangeTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("EmployeeRange", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.employeeRangeDataTable)obj;
                databases.baseDS.employeeRangeDataTable tbl = myClient.GetEmployeeRange();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static databases.baseDS.bizSectorDataTable myBizSectorTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("BizSector", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.bizSectorDataTable)obj;
                databases.baseDS.bizSectorDataTable tbl = myClient.GetBizSector();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }

        public static databases.baseDS.bizSubSectorDataTable myBizSubSectorTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("BizSubSector", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.bizSubSectorDataTable)obj;
                databases.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static databases.baseDS.bizSuperSectorDataTable myBizSuperSectorTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("BizSuperSector", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.bizSuperSectorDataTable)obj;
                databases.baseDS.bizSuperSectorDataTable tbl = myClient.GetBizSuperSector();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static databases.baseDS.bizIndustryDataTable myBizIndustryTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("BizIndustry", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.bizIndustryDataTable)obj;
                databases.baseDS.bizIndustryDataTable tbl = myClient.GetBizIndustry();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        #endregion

        #region Load/Get

        public static databases.baseDS.stockCodeDataTable GetStockFull(bool force)
        {
            string cacheKey = MakeCacheKey("StockFull", "All");
            if (!force)
            {
                object obj = GetCache(cacheKey);
                if (obj != null) return (databases.baseDS.stockCodeDataTable)obj;
            }
            databases.baseDS.stockCodeDataTable tbl = myClient.GetStockFull();
            AddCache(cacheKey, tbl);
            return tbl;
        }

        public static databases.baseDS.portfolioDataTable GetSystemWatchList()
        {
            string cacheKey = MakeCacheKey("SysWatchList", "List");
            object obj = GetCache(cacheKey);
            if (obj != null) return (databases.baseDS.portfolioDataTable)obj;
            databases.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByType(AppTypes.PortfolioTypes.SysWatchList);
            AddCache(cacheKey, tbl);
            return tbl;
        }
        public static databases.baseDS.portfolioRow GetPortfolio_DefaultStrategy()
        {
            string cacheKey = MakeCacheKey("SysPortfolio", "DefaultStrategy");
            object obj = GetCache(cacheKey);
            if (obj != null) return (databases.baseDS.portfolioRow)obj;
            databases.baseDS.portfolioRow row = null;
            databases.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByType(AppTypes.PortfolioTypes.PortfolioDefaultStrategy);
            if (tbl.Count == 0)
            {
                row = tbl.NewportfolioRow();
                databases.AppLibs.InitData(row);
                row.type = (byte)AppTypes.PortfolioTypes.PortfolioDefaultStrategy;
                row.code = Consts.constNotMarkerNEW;
                row.investorCode = commonClass.SysLibs.sysLoginCode;
                tbl.AddportfolioRow(row);
                myClient.UpdatePortfolio(ref tbl);
            }
            row = tbl[0];
            AddCache(cacheKey, row);
            return row;
        }
        public static databases.baseDS.portfolioRow GetPortfolio_ByCode(string code)
        {
            databases.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByCode(code);
            if (tbl.Count == 0) return null;
            return tbl[0];
        }
        public static databases.baseDS.portfolioDataTable GetPortfolio_ByType(AppTypes.PortfolioTypes type)
        {
            return myClient.GetPortfolio_ByType(type);
        }

        public static databases.baseDS.portfolioDataTable GetPortfolio_ByInvestorAndType(string investorCode, AppTypes.PortfolioTypes type)
        {
            return myClient.GetPortfolio_ByInvestorAndType(investorCode,type);
        }
        public static databases.baseDS.portfolioDataTable GetPortfolio_ByInvestor(string investorCode)
        {
            return myClient.GetPortfolio_ByInvestor(investorCode);
        }

        public static databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByCode(string portfolioCode)
        {
            return myClient.GetPortfolioDetail_ByCode(portfolioCode);
        }
        public static databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByType(AppTypes.PortfolioTypes[] types)
        { 
            return myClient.GetPortfolioDetail_ByType(types);
        }

        public static databases.baseDS.tradeAlertDataTable GetTradeAlert_BySQL(string sql)
        {
            return myClient.GetTradeAlert_BySQL(sql);
        }
        public static databases.baseDS.transactionsDataTable GetTransactions_BySQL(string sql)
        {
            return myClient.GetTransaction_BySQL(sql);
        }

        public static databases.baseDS.investorStockDataTable GetOwnedStock(string portfolio)
        {
            return myClient.GetOwnedStock(portfolio);
        }

        public static databases.tmpDS.stockCodeDataTable GetStock_InPortfolio(StringCollection portfolios)
        {
            return myClient.GetStock_InPortfolio(common.system.Collection2List(portfolios)); 
        }
        private static databases.tmpDS.stockCodeDataTable StockFromCodeList(string[] codes)
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
        public static databases.tmpDS.stockCodeDataTable GetStock_ByWatchList(StringCollection codes)
        {
            string[] codeList = myClient.GetStockList_ByWatchList(common.system.Collection2List(codes));
            return StockFromCodeList(codeList);
        }
        public static string[] GetStockList_ByWatchList(StringCollection codes)
        {
            return myClient.GetStockList_ByWatchList(common.system.Collection2List(codes));
        }
        public static string[] GetStockList_ByBizSector(StringCollection codes)
        {
            return myClient.GetStockList_ByBizSector(common.system.Collection2List(codes));
        }

        public static databases.tmpDS.stockCodeDataTable GetStock_ByBizSector(StringCollection bizSector)
        {
            string[] codeList = myClient.GetStockList_ByBizSector(common.system.Collection2List(bizSector));
            return StockFromCodeList(codeList);
        }

        public static databases.baseDS.bizSubSectorDataTable GetBizSubSector_ByIndustry(string code)
        {
            string cacheKey = MakeCacheKey("BizSubSector_ByIndustry", code);
            object obj = GetCache(cacheKey);
            if (obj != null) return (databases.baseDS.bizSubSectorDataTable)obj;
            databases.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_ByIndustry(code);
            AddCache(cacheKey, tbl);
            return tbl;
        }
        public static databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySuperSector(string code)
        {
            string cacheKey = MakeCacheKey("BizSubSector_BySuperSector", code);
            object obj = GetCache(cacheKey);
            if (obj != null) return (databases.baseDS.bizSubSectorDataTable)obj;
            databases.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_BySuperSector(code);
            AddCache(cacheKey, tbl);
            return tbl;
        }
        public static databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySector(string code)
        {
            string cacheKey = MakeCacheKey("BizSubSector_BySector", code);
            object obj = GetCache(cacheKey);
            if (obj != null) return (databases.baseDS.bizSubSectorDataTable)obj;
            databases.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_BySector(code);
            AddCache(cacheKey, tbl);
            return tbl;
        }
        
        public static databases.baseDS.investorDataTable GetInvestor_BySQL(string sql)
        {
            return myClient.GetInvestor_BySQL(sql);
        }
        public static databases.baseDS.investorDataTable GetInvestor_ByCode(string code)
        {
            return myClient.GetInvestor_ByCode(code);
        }
        public static databases.baseDS.investorDataTable GetInvestor_ByAccount(string account)
        {
            databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
            return myClient.GetInvestor_BySQL("SELECT * FROM " + tbl.TableName + 
                                               " WHERE " + tbl.accountColumn.ColumnName + "=N'" + account + "'");
        }
        public static databases.baseDS.investorDataTable GetInvestor_ByCriteria(string criteria)
        {
            databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
            return myClient.GetInvestor_BySQL("SELECT * FROM " + tbl.TableName + (criteria.Trim()==""?"":" WHERE " + criteria));
        }

        public static databases.baseDS.sysCodeCatDataTable GetSysCodeCat()
        {
            return myClient.GetSysCodeCat();
        }
        public static databases.baseDS.sysCodeDataTable GetSysCode(string catCode)
        {
            return myClient.GetSysCode(catCode);
        }

        public static void GetConfig(ref StringCollection aFields){}
        public static void SaveConfig(StringCollection aFields, StringCollection aValues){}

        public static databases.baseDS.lastPriceDataDataTable GetLastPrice(AppTypes.PriceDataType type)
        {
            return myClient.GetLastPrice(type);
        }
        //public static void GetLastPrice(databases.baseDS.priceDataDataTable tbl, string stockCode)
        //{
        //    object[] data = myClient.GetLastPriceByCode(stockCode);
        //    if (data == null) return;
        //    object aa = data[0];
        //    //return (databases.baseDS.priceDataRow)data;
        //}

        public static bool GetTransactionInfo(ref TransactionInfo transInfo)
        {
            return myClient.GetTransactionInfo(ref transInfo);
        }

        public static DateTime GetLastAlertTime(string investorCode)
        {
            return  myClient.GetLastAlertTime(investorCode);
        }

        public static databases.baseDS.priceDataDataTable GetData_ByTimeScale_Code_FrDate(string timeScaleCode, string stockCode, DateTime fromDate)
        {
            return myClient.GetData_ByTimeScale_Code_FrDate(timeScaleCode, stockCode, fromDate);
        }
        public static databases.baseDS.priceDataDataTable GetData_ByTimeScale_Code_DateRange(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            return myClient.GetData_ByTimeScale_Code_DateRange(timeScaleCode, stockCode, frDate,toDate);
        }
        public static databases.tmpDS.marketDataDataTable GetMarketData_BySQL(string sqlCmd)
        {
            return myClient.GetMarketData_BySQL(sqlCmd);
        }
        public static int GetData_TotalRow(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            return myClient.GetData_TotalRow(timeScaleCode,stockCode, frDate, toDate);
        }
        #endregion 

        #region Delete
        public static void DeleteData(databases.baseDS.stockExchangeRow row)
        {
            myClient.DeleteStockExchange(row.code);
        }
        public static void DeleteData(databases.baseDS.stockCodeRow row)
        {
            myClient.DeleteStock(row.code);
        }
        public static void DeleteData(databases.baseDS.investorRow row)
        {
            myClient.DeleteInvestor(row.code);
        }
        public static void DeleteData(databases.baseDS.portfolioRow row)
        {
            myClient.DeletePortfolio(row.code);
        }

        public static void DeleteData(databases.baseDS.sysCodeCatRow row)
        {
            myClient.DeleteSysCodeCat(row.category);
        }
        public static void DeleteData(databases.baseDS.sysCodeRow row)
        {
            myClient.DeleteSysCode(row.category, row.code);
        }

        public static void DeleteTradeAlert(int alertId)
        {
            myClient.DeleteTradeAlert(alertId);
        }
        #endregion

        #region Update
        public static databases.baseDS.sysCodeCatRow UpdateData(databases.baseDS.sysCodeCatRow row)
        {
            databases.baseDS.sysCodeCatDataTable tbl = new databases.baseDS.sysCodeCatDataTable();
            tbl.ImportRow(row);
            myClient.UpdateSysCodeCat(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static databases.baseDS.sysCodeRow UpdateData(databases.baseDS.sysCodeRow row)
        {
            databases.baseDS.sysCodeDataTable tbl = new databases.baseDS.sysCodeDataTable();
            tbl.ImportRow(row);
            myClient.UpdateSysCode(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }

        public static databases.baseDS.stockCodeRow UpdateData(databases.baseDS.stockCodeRow row)
        {
            databases.baseDS.stockCodeDataTable tbl = new databases.baseDS.stockCodeDataTable();
            tbl.ImportRow(row);
            myClient.UpdateStock(ref tbl); 
            row.AcceptChanges();
            return tbl[0];
        }
        public static databases.baseDS.investorRow UpdateData(databases.baseDS.investorRow row)
        {
            databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
            tbl.ImportRow(row);
            myClient.UpdateInvestor(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static databases.baseDS.portfolioRow UpdateData(databases.baseDS.portfolioRow row)
        {
            databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
            tbl.ImportRow(row);
            myClient.UpdatePortfolio(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static void UpdateData(databases.baseDS.portfolioDetailDataTable tbl)
        {
            myClient.UpdatePortfolioDetail(ref tbl);
            tbl.AcceptChanges();
        }

        public static databases.baseDS.stockExchangeRow UpdateData(databases.baseDS.stockExchangeRow row)
        {
            databases.baseDS.stockExchangeDataTable tbl = new databases.baseDS.stockExchangeDataTable();
            tbl.ImportRow(row);
            myClient.UpdateStockExchange(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static databases.baseDS.transactionsRow UpdateData(databases.baseDS.transactionsRow row)
        {
            databases.baseDS.transactionsDataTable tbl = new databases.baseDS.transactionsDataTable();
            tbl.ImportRow(row);
            myClient.UpdateTransactions(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static databases.baseDS.investorStockRow UpdateData(databases.baseDS.investorStockRow row)
        {
            databases.baseDS.investorStockDataTable tbl = new databases.baseDS.investorStockDataTable();
            tbl.ImportRow(row);
            myClient.UpdateInvestorStock(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static databases.baseDS.tradeAlertRow UpdateData(databases.baseDS.tradeAlertRow row)
        {
            databases.baseDS.tradeAlertDataTable tbl = new databases.baseDS.tradeAlertDataTable();
            tbl.ImportRow(row);
            myClient.UpdateTradeAlert(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }

        public static databases.baseDS.sysAutoKeyPendingRow UpdateData(databases.baseDS.sysAutoKeyPendingRow row)
        {
            databases.baseDS.sysAutoKeyPendingDataTable tbl = new databases.baseDS.sysAutoKeyPendingDataTable();
            tbl.ImportRow(row);
            myClient.UpdateSysAutoKeyPending(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        #endregion Update

        #region client
        public static double[][] Estimate_Matrix_LastBizWeight(DataParams dataParam,string[] stockCodeList, string[] strategyList)
        {
            return myClient.Estimate_Matrix_LastBizWeight(dataParam, stockCodeList, strategyList);
        }

        public static decimal[][] Estimate_Matrix_Profit(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                         string[] stocks, string[] strategyList, EstimateOptions option)
        {
            return myClient.Estimate_Matrix_Profit(timeRange, timeScaleCode, stocks, strategyList, option);
        }

        public static databases.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type, string stockCode, 
                                                                        string portfolioCode, int qty, decimal feePerc)
        { 
            string errorText = "";
            databases.baseDS.transactionsDataTable retVal = myClient.MakeTransaction(out errorText, type, stockCode, portfolioCode, qty, feePerc);
            if (retVal == null)  common.system.ShowErrorMessage(errorText);
            return retVal;
        }

        private class AnalysisDataCache
        {
            public databases.baseDS.priceDataDataTable dataTbl = null;
            public int firstData=0;
        }
        private static string MakeAnalysisDataCacheKey(commonClass.BaseAnalysisData dataObj)
        {
            return "AnalysisData" + "-" + dataObj.DataStockCode + "-" + dataObj.DataTimeRange.ToString() + "-" +
                    dataObj.DataTimeScale.Code;
        }

        public static void ClearAnalysisDataCache(commonClass.BaseAnalysisData dataObj)
        {
            cacheData.Remove(MakeAnalysisDataCacheKey(dataObj));
        }
        public static bool LoadAnalysisData(commonClass.BaseAnalysisData dataObj)
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
                data = new AnalysisDataCache();
                int firstData = 0;
                DataParams dataParam = new DataParams(dataObj.DataTimeScale.Code, dataObj.DataTimeRange, dataObj.DataMaxCount);
                data.dataTbl = myClient.GetAnalysis_Data(out firstData, dataObj.DataStockCode, dataParam);
                data.firstData = firstData;
                AddCache(cacheKey, data);
                dataObj.priceDataTbl = (databases.baseDS.priceDataDataTable)data.dataTbl.Copy();
                dataObj.FirstDataStartAt = firstData;
            }
            return true;
        }

        public static TradePointInfo[] GetTradePointWithEstimationDetail(DataParams dataParam,string stockCode, string strategyCode, 
                                                                         EstimateOptions options,out databases.tmpDS.tradeEstimateDataTable toTbl)
        {
            return myClient.GetTradePointWithEstimationDetail(out toTbl,dataParam, stockCode, strategyCode, options);
        }
        
        //Updated data from the last read/update point
        public static int UpdateAnalysisData(commonClass.BaseAnalysisData dataObj)
        {
            int lastDataIdx = dataObj.priceDataTbl.Count - 1;
            DateTime lastDateTime;
            if (lastDataIdx < 0) lastDateTime = Settings.sysStartDataDate;
            else lastDateTime = dataObj.priceDataTbl[lastDataIdx].onDate;

            databases.baseDS.priceDataDataTable tbl = GetData_ByTimeScale_Code_FrDate(dataObj.DataTimeScale.Code, dataObj.DataStockCode,lastDateTime);
            if (tbl.Count > 0)
            {
                //Delete the last data because the updated data will include this one.
                if (lastDataIdx >= 0)
                {
                    dataObj.priceDataTbl[lastDataIdx].ItemArray = tbl[0].ItemArray;
                    databases.AppLibs.DataConcat(tbl, 1, dataObj.priceDataTbl);
                }
                else databases.AppLibs.DataConcat(tbl, 0, dataObj.priceDataTbl);
            }
            //Update cache
            AnalysisDataCache data = new AnalysisDataCache();
            data.dataTbl = (databases.baseDS.priceDataDataTable)dataObj.priceDataTbl.Copy();
            data.firstData = dataObj.FirstDataStartAt;
            AddCache(MakeAnalysisDataCacheKey(dataObj), data);
            return dataObj.priceDataTbl.Count - 1 - lastDataIdx;
        }

        //public static string GetXml(string fileName)
        //{
        //    return myClient.GetXml(fileName);
        //}

        #endregion
        
        #region Configuration
        public static void Load_Global_Settings()
        {
            GlobalSettings globSettings = Settings.sysGlobal;
            myClient.Load_Global_Settings(ref globSettings);
            Settings.sysGlobal =  globSettings;
        }
        public static void Save_Global_Settings()
        {
            GlobalSettings globSettings = Settings.sysGlobal;
            myClient.Save_Global_Settings(globSettings);
        }
        #endregion

        #region syslog
        public static void WriteSyslog(AppTypes.SyslogTypes logType, string investorCode, string desc, string source, string msg)
        {
            myClient.WriteSyslog(logType,investorCode, desc, source, msg);
        }
        public static void WriteSyslog(Exception er, string investorCode)
        {
            myClient.WriteSyslog(AppTypes.SyslogTypes.Exception,investorCode, er.TargetSite.ToString(), er.Source, er.Message.Trim() + " " + er.StackTrace.Trim());
        }
        #endregion

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
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(myClient.GetXmlDoc2StringSTRATEGY());
            return xmlDoc;
        }
        public static XmlDocument GetXmlDocumentINDICATOR()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(myClient.GetXmlDoc2StringINDICATOR());
            return xmlDoc;
        }
    }
}
