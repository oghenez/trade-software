using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
using System.Xml;
using commonClass;

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
            if (common.settings.myWsConInfos.Length <= 0)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("runSetupToCreateConfigFile"));
                common.system.ExitApplication();
                return;
            }
            OpenConnection(common.settings.myWsConInfos[0]);
        }
        private static void OpenConnection(common.configuration.wsConnectionInfo wsInfo)
        {
            if (_myClient != null) _myClient.Abort();
            _myClient = new ServiceReference1.StockServiceClient();

            System.ServiceModel.WSHttpBinding binding = (_myClient.Endpoint.Binding as System.ServiceModel.WSHttpBinding);
            //Proxy  must befor setting Endpoint ?
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
            //For testing
            //_myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://localhost:8731/wsServices/DataLibs/?wsdl");
            //_myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://localhost/DataLibs.svc");
            //_myClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://localhost:8731/wsServices/DataLibs"); 
            //_myClient.ClientCredentials.Windows.ClientCredential.UserName = "";
            //_myClient.ClientCredentials.Windows.ClientCredential.Password = "";
            _myClient.Open();
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
                myClient.Load_Global_Settings();
            }
        }
        public static bool TestConnection(common.configuration.wsConnectionInfo wsInfo, out string msg)
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
        
        //public static string GetAutoDataKey(string tblName)
        //{
        //    return application.SysLibs.GetAutoDataKey(tblName);
        //}
        ////public static string GetAutoDataKey(string tblName, string prefix, int maxLen, bool usePending)
        //{
        //    return application.SysLibs.GetAutoDataKey(tblName, prefix, maxLen, usePending);
        //}
        public static DateTime GetServerDateTime()
        {
            return myClient.GetServerDateTime();
        }

        #endregion

        #region System variables
        public static void LoadSystemVars()
        {
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
            GetStockFull(true);
            GetSystemWatchList();
        }

        public static data.tmpDS.stockCodeDataTable myStockCodeTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("StockList", "Enable");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.tmpDS.stockCodeDataTable)obj;
                data.tmpDS.stockCodeDataTable tbl = myClient.GetStockByStatus(AppTypes.CommonStatus.Enable);
                AddCache(cacheKey, tbl);
                return tbl;
            }
            set
            {
                ClearCache(MakeCacheKey("StockList", "Enable"));
            }
        }

        public static data.baseDS.stockExchangeDataTable myStockExchangeTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("stockExchange", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.stockExchangeDataTable)obj;
                data.baseDS.stockExchangeDataTable tbl = myClient.GetStockExchange();
                AddCache(cacheKey, tbl);
                return tbl;
            }
            set
            {
                ClearCache(MakeCacheKey("stockExchange", "All"));
            }
        }
        public static data.baseDS.sysCodeCatDataTable mySysCodeCatTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("SysCodeCat", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.sysCodeCatDataTable)obj;
                data.baseDS.sysCodeCatDataTable tbl = myClient.GetSysCodeCat();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static data.baseDS.currencyDataTable myCurrencyTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("Currency", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.currencyDataTable)obj;
                data.baseDS.currencyDataTable tbl = myClient.GetCurrency();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static data.baseDS.countryDataTable myCountryTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("Country", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.countryDataTable)obj;
                data.baseDS.countryDataTable tbl = myClient.GetCountry();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static data.baseDS.investorCatDataTable myInvestorCatTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("InvestorCat", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.investorCatDataTable)obj;
                data.baseDS.investorCatDataTable tbl = myClient.GetInvestorCat();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static data.baseDS.employeeRangeDataTable myEmployeeRangeTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("EmployeeRange", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.employeeRangeDataTable)obj;
                data.baseDS.employeeRangeDataTable tbl = myClient.GetEmployeeRange();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static data.baseDS.bizSectorDataTable myBizSectorTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("BizSector", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.bizSectorDataTable)obj;
                data.baseDS.bizSectorDataTable tbl = myClient.GetBizSector();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }

        public static data.baseDS.bizSubSectorDataTable myBizSubSectorTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("BizSubSector", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.bizSubSectorDataTable)obj;
                data.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static data.baseDS.bizSuperSectorDataTable myBizSuperSectorTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("BizSuperSector", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.bizSuperSectorDataTable)obj;
                data.baseDS.bizSuperSectorDataTable tbl = myClient.GetBizSuperSector();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        public static data.baseDS.bizIndustryDataTable myBizIndustryTbl
        {
            get
            {
                string cacheKey = MakeCacheKey("BizIndustry", "All");
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.bizIndustryDataTable)obj;
                data.baseDS.bizIndustryDataTable tbl = myClient.GetBizIndustry();
                AddCache(cacheKey, tbl);
                return tbl;
            }
        }
        #endregion

        #region Load/Get

        public static data.baseDS.stockCodeDataTable GetStockFull(bool force)
        {
            string cacheKey = MakeCacheKey("StockFull", "All");
            if (!force)
            {
                object obj = GetCache(cacheKey);
                if (obj != null) return (data.baseDS.stockCodeDataTable)obj;
            }
            data.baseDS.stockCodeDataTable tbl = myClient.GetStockFull();
            AddCache(cacheKey, tbl);
            return tbl;
        }

        public static data.baseDS.portfolioDataTable GetSystemWatchList()
        {
            string cacheKey = MakeCacheKey("SysWatchList", "List");
            object obj = GetCache(cacheKey);
            if (obj != null) return (data.baseDS.portfolioDataTable)obj;
            data.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByType(AppTypes.PortfolioTypes.SysWatchList);
            AddCache(cacheKey, tbl);
            return tbl;
        }
        public static data.baseDS.portfolioRow GetPortfolio_DefaultStrategy()
        {
            string cacheKey = MakeCacheKey("SysPortfolio", "DefaultStrategy");
            object obj = GetCache(cacheKey);
            if (obj != null) return (data.baseDS.portfolioRow)obj;
            data.baseDS.portfolioRow row = null;
            data.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByType(AppTypes.PortfolioTypes.PortfolioDefaultStrategy);
            if (tbl.Count == 0)
            {
                row = tbl.NewportfolioRow();
                commonClass.AppLibs.InitData(row);
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
        public static data.baseDS.portfolioRow GetPortfolio_ByCode(string code)
        {
            data.baseDS.portfolioDataTable tbl = myClient.GetPortfolio_ByCode(code);
            if (tbl.Count == 0) return null;
            return tbl[0];
        }
        public static data.baseDS.portfolioDataTable GetPortfolio_ByType(AppTypes.PortfolioTypes type)
        {
            return myClient.GetPortfolio_ByType(type);
        }

        public static data.baseDS.portfolioDataTable GetPortfolio_ByInvestorAndType(string investorCode, AppTypes.PortfolioTypes type)
        {
            return myClient.GetPortfolio_ByInvestorAndType(investorCode,type);
        }
        public static data.baseDS.portfolioDataTable GetPortfolio_ByInvestor(string investorCode)
        {
            return myClient.GetPortfolio_ByInvestor(investorCode);
        }

        public static data.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByCode(string portfolioCode)
        {
            return myClient.GetPortfolioDetail_ByCode(portfolioCode);
        }
        public static data.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByType(AppTypes.PortfolioTypes[] types)
        { 
            return myClient.GetPortfolioDetail_ByType(types);
        }

        public static data.baseDS.tradeAlertDataTable GetTradeAlert_BySQL(string sql)
        {
            return myClient.GetTradeAlert_BySQL(sql);
        }
        public static data.baseDS.transactionsDataTable GetTransactions_BySQL(string sql)
        {
            return myClient.GetTransaction_BySQL(sql);
        }

        public static data.baseDS.investorStockDataTable GetOwnedStock(string portfolio)
        {
            return myClient.GetOwnedStock(portfolio);
        }

        public static data.tmpDS.stockCodeDataTable GetStock_InPortfolio(StringCollection portfolios)
        {
            return myClient.GetStock_InPortfolio(common.system.Collection2List(portfolios)); 
        }
        private static data.tmpDS.stockCodeDataTable StockFromCodeList(string[] codes)
        {
            data.tmpDS.stockCodeDataTable retTbl = new data.tmpDS.stockCodeDataTable();

            data.tmpDS.stockCodeRow stockRow;
            data.tmpDS.stockCodeDataTable stockCodeTbl = myStockCodeTbl;
            for (int idx = 0; idx < codes.Length; idx++)
            {
                stockRow = stockCodeTbl.FindBycode(codes[idx]);
                if (stockRow != null) retTbl.ImportRow(stockRow);
            }
            return retTbl;
        }
        public static data.tmpDS.stockCodeDataTable GetStock_ByWatchList(StringCollection codes)
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

        public static data.tmpDS.stockCodeDataTable GetStock_ByBizSector(StringCollection bizSector)
        {
            string[] codeList = myClient.GetStockList_ByBizSector(common.system.Collection2List(bizSector));
            return StockFromCodeList(codeList);
        }

        public static data.baseDS.bizSubSectorDataTable GetBizSubSector_ByIndustry(string code)
        {
            string cacheKey = MakeCacheKey("BizSubSector_ByIndustry", code);
            object obj = GetCache(cacheKey);
            if (obj != null) return (data.baseDS.bizSubSectorDataTable)obj;
            data.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_ByIndustry(code);
            AddCache(cacheKey, tbl);
            return tbl;
        }
        public static data.baseDS.bizSubSectorDataTable GetBizSubSector_BySuperSector(string code)
        {
            string cacheKey = MakeCacheKey("BizSubSector_BySuperSector", code);
            object obj = GetCache(cacheKey);
            if (obj != null) return (data.baseDS.bizSubSectorDataTable)obj;
            data.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_BySuperSector(code);
            AddCache(cacheKey, tbl);
            return tbl;
        }
        public static data.baseDS.bizSubSectorDataTable GetBizSubSector_BySector(string code)
        {
            string cacheKey = MakeCacheKey("BizSubSector_BySector", code);
            object obj = GetCache(cacheKey);
            if (obj != null) return (data.baseDS.bizSubSectorDataTable)obj;
            data.baseDS.bizSubSectorDataTable tbl = myClient.GetBizSubSector_BySector(code);
            AddCache(cacheKey, tbl);
            return tbl;
        }
        
        public static data.baseDS.investorDataTable GetInvestor_BySQL(string sql)
        {
            return myClient.GetInvestor_BySQL(sql);
        }
        public static data.baseDS.investorDataTable GetInvestor_ByCode(string code)
        {
            return myClient.GetInvestor_ByCode(code);
        }
        public static data.baseDS.investorDataTable GetInvestor_ByAccount(string account)
        {
            data.baseDS.investorDataTable tbl = new data.baseDS.investorDataTable();
            return myClient.GetInvestor_BySQL("SELECT * FROM " + tbl.TableName + 
                                               " WHERE " + tbl.accountColumn.ColumnName + "=N'" + account + "'");
        }
        public static data.baseDS.investorDataTable GetInvestor_ByCriteria(string criteria)
        {
            data.baseDS.investorDataTable tbl = new data.baseDS.investorDataTable();
            return myClient.GetInvestor_BySQL("SELECT * FROM " + tbl.TableName + (criteria.Trim()==""?"":" WHERE " + criteria));
        }

        public static data.baseDS.sysCodeCatDataTable GetSysCodeCat()
        {
            return myClient.GetSysCodeCat();
        }
        public static data.baseDS.sysCodeDataTable GetSysCode(string catCode)
        {
            return myClient.GetSysCode(catCode);
        }

        public static void GetConfig(ref StringCollection aFields){}
        public static void SaveConfig(StringCollection aFields, StringCollection aValues){}

        public static data.baseDS.priceDataDataTable GetLastPrice()
        {
            return myClient.GetLastPrice();
        }
        //public static void GetLastPrice(data.baseDS.priceDataDataTable tbl, string stockCode)
        //{
        //    object[] data = myClient.GetLastPriceByCode(stockCode);
        //    if (data == null) return;
        //    object aa = data[0];
        //    //return (data.baseDS.priceDataRow)data;
        //}

        public static bool GetTransactionInfo(ref TransactionInfo transInfo)
        {
            return myClient.GetTransactionInfo(ref transInfo);
        }

        public static DateTime GetLastAlertTime(string investorCode)
        {
            return  myClient.GetLastAlertTime(investorCode);
        }

        public static data.baseDS.priceDataDataTable GetData_ByTimeScale_Code_FrDate(string timeScaleCode, string stockCode, DateTime fromDate)
        {
            return myClient.GetData_ByTimeScale_Code_FrDate(timeScaleCode, stockCode, fromDate);
        }
        public static data.baseDS.priceDataDataTable GetData_ByTimeScale_Code_DateRange(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            return myClient.GetData_ByTimeScale_Code_DateRange(timeScaleCode, stockCode, frDate,toDate);
        }
        public static data.tmpDS.marketDataDataTable GetMarketData_BySQL(string sqlCmd)
        {
            return myClient.GetMarketData_BySQL(sqlCmd);
        }
        public static int GetData_TotalRow(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            return myClient.GetData_TotalRow(timeScaleCode,stockCode, frDate, toDate);
        }
        #endregion 

        #region Delete
        public static void DeleteData(data.baseDS.stockExchangeRow row)
        {
            myClient.DeleteStockExchange(row.code);
        }
        public static void DeleteData(data.baseDS.stockCodeRow row)
        {
            myClient.DeleteStock(row.code);
        }
        public static void DeleteData(data.baseDS.investorRow row)
        {
            myClient.DeleteInvestor(row.code);
        }
        public static void DeleteData(data.baseDS.portfolioRow row)
        {
            myClient.DeletePortfolio(row.code);
        }

        public static void DeleteData(data.baseDS.sysCodeCatRow row)
        {
            myClient.DeleteSysCodeCat(row.category);
        }
        public static void DeleteData(data.baseDS.sysCodeRow row)
        {
            myClient.DeleteSysCode(row.category, row.code);
        }

        public static void DeleteTradeAlert(int alertId)
        {
            myClient.DeleteTradeAlert(alertId);
        }
        #endregion

        #region Update
        public static data.baseDS.sysCodeCatRow UpdateData(data.baseDS.sysCodeCatRow row)
        {
            data.baseDS.sysCodeCatDataTable tbl = new data.baseDS.sysCodeCatDataTable();
            tbl.ImportRow(row);
            myClient.UpdateSysCodeCat(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static data.baseDS.sysCodeRow UpdateData(data.baseDS.sysCodeRow row)
        {
            data.baseDS.sysCodeDataTable tbl = new data.baseDS.sysCodeDataTable();
            tbl.ImportRow(row);
            myClient.UpdateSysCode(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }

        public static data.baseDS.stockCodeRow UpdateData(data.baseDS.stockCodeRow row)
        {
            data.baseDS.stockCodeDataTable tbl = new data.baseDS.stockCodeDataTable();
            tbl.ImportRow(row);
            myClient.UpdateStock(ref tbl); 
            row.AcceptChanges();
            return tbl[0];
        }
        public static data.baseDS.investorRow UpdateData(data.baseDS.investorRow row)
        {
            data.baseDS.investorDataTable tbl = new data.baseDS.investorDataTable();
            tbl.ImportRow(row);
            myClient.UpdateInvestor(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static data.baseDS.portfolioRow UpdateData(data.baseDS.portfolioRow row)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            tbl.ImportRow(row);
            myClient.UpdatePortfolio(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static void UpdateData(data.baseDS.portfolioDetailDataTable tbl)
        {
            myClient.UpdatePortfolioDetail(ref tbl);
            tbl.AcceptChanges();
        }

        public static data.baseDS.stockExchangeRow UpdateData(data.baseDS.stockExchangeRow row)
        {
            data.baseDS.stockExchangeDataTable tbl = new data.baseDS.stockExchangeDataTable();
            tbl.ImportRow(row);
            myClient.UpdateStockExchange(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static data.baseDS.transactionsRow UpdateData(data.baseDS.transactionsRow row)
        {
            data.baseDS.transactionsDataTable tbl = new data.baseDS.transactionsDataTable();
            tbl.ImportRow(row);
            myClient.UpdateTransactions(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static data.baseDS.investorStockRow UpdateData(data.baseDS.investorStockRow row)
        {
            data.baseDS.investorStockDataTable tbl = new data.baseDS.investorStockDataTable();
            tbl.ImportRow(row);
            myClient.UpdateInvestorStock(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        public static data.baseDS.tradeAlertRow UpdateData(data.baseDS.tradeAlertRow row)
        {
            data.baseDS.tradeAlertDataTable tbl = new data.baseDS.tradeAlertDataTable();
            tbl.ImportRow(row);
            myClient.UpdateTradeAlert(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }

        public static data.baseDS.sysAutoKeyPendingRow UpdateData(data.baseDS.sysAutoKeyPendingRow row)
        {
            data.baseDS.sysAutoKeyPendingDataTable tbl = new data.baseDS.sysAutoKeyPendingDataTable();
            tbl.ImportRow(row);
            myClient.UpdateSysAutoKeyPending(ref tbl);
            row.AcceptChanges();
            return tbl[0];
        }
        #endregion Update

        #region client
        public static double[][] Estimate_Matrix_LastBizWeight(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                            string[] stockCodeList, string[] strategyList)
        {
            return myClient.Estimate_Matrix_LastBizWeight(timeRange, timeScaleCode, stockCodeList, strategyList);
        }

        public static decimal[][] Estimate_Matrix_Profit(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                         string[] stocks, string[] strategyList, EstimateOptions option)
        {
            return myClient.Estimate_Matrix_Profit(timeRange, timeScaleCode, stocks, strategyList, option);
        }

        public static data.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type, string stockCode, 
                                                                        string portfolioCode, int qty, decimal feePerc)
        { 
            string errorText = "";
            data.baseDS.transactionsDataTable retVal = myClient.MakeTransaction(out errorText, type, stockCode, portfolioCode, qty, feePerc);
            if (retVal == null)  common.system.ShowErrorMessage(errorText);
            return retVal;
        }

        private class AnalysisDataCache
        {
            public data.baseDS.priceDataDataTable dataTbl = null;
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
                dataObj.priceDataTbl = (data.baseDS.priceDataDataTable)data.dataTbl.Copy();
                return true;
            }
            using (new PleaseWait())
            {
                data = new AnalysisDataCache();
                int firstData = 0;
                data.dataTbl = myClient.GetAnalysis_Data(out firstData, dataObj.DataTimeRange, dataObj.DataTimeScale.Code, dataObj.DataStockCode);
                data.firstData = firstData;
                AddCache(cacheKey, data);
                dataObj.priceDataTbl = (data.baseDS.priceDataDataTable)data.dataTbl.Copy();
                dataObj.FirstDataStartAt = firstData;
            }
            return true;
        }

        public static TradePointInfo[] GetTradePointWithEstimationDetail(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                                         string stockCode, string strategyCode, EstimateOptions options,
                                                                         out data.tmpDS.tradeEstimateDataTable toTbl)
        {
            return myClient.GetTradePointWithEstimationDetail(out toTbl, timeRange, timeScaleCode, stockCode, strategyCode, options);
        }
        
        //Updated data from the last read/update point
        public static int UpdateAnalysisData(commonClass.BaseAnalysisData dataObj)
        {
            int lastDataIdx = dataObj.priceDataTbl.Count - 1;
            DateTime lastDateTime;
            if (lastDataIdx < 0) lastDateTime = commonClass.Settings.sysStartDataDate;
            else lastDateTime = dataObj.priceDataTbl[lastDataIdx].onDate;

            data.baseDS.priceDataDataTable tbl = GetData_ByTimeScale_Code_FrDate(dataObj.DataTimeScale.Code, dataObj.DataStockCode,lastDateTime);
            if (tbl.Count > 0)
            {
                //Delete the last data because the updated data will include this one.
                if (lastDataIdx >= 0)
                {
                    dataObj.priceDataTbl[lastDataIdx].ItemArray = tbl[0].ItemArray;
                    commonClass.AppLibs.DataConcat(tbl, 1, dataObj.priceDataTbl);
                }
                else commonClass.AppLibs.DataConcat(tbl, 0, dataObj.priceDataTbl);
            }
            //Update cache
            AnalysisDataCache data = new AnalysisDataCache();
            data.dataTbl = (data.baseDS.priceDataDataTable)dataObj.priceDataTbl.Copy();
            data.firstData = dataObj.FirstDataStartAt;
            AddCache(MakeAnalysisDataCacheKey(dataObj), data);
            return dataObj.priceDataTbl.Count - 1 - lastDataIdx;
        }

        public static string GetXml(string fileName)
        {
            return myClient.GetXml(fileName);
        }

        #endregion
        
        #region Configuration
        public static void Load_Global_Settings()
        {
            myClient.Load_Global_Settings();
        }
        public static void Save_Global_Settings()
        {
            myClient.Save_Global_Settings();
        }
        #endregion
    }
}
