using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Reflection;
using System.Web;
using System.Xml;
using System.IO;
using commonTypes;
using commonClass;

namespace wsServices
{
    public class DataLibs : IStockService
    {
        private class DataCacheItem
        {
            public DataCacheItem(object obj)
            {
                data = obj;
                timeStamp = DateTime.Now.Ticks; 
            }
            public object data = null;
            public long timeStamp = 0; 
        }

        private void WriteSysLogLocal(Exception er)
        {
            commonClass.SysLibs.WriteSysLog(null,er);
        }
        private void WriteSysLogLocal(string msg)
        {
            commonClass.SysLibs.WriteSysLog(msg);
        }

        #region system
        //Start-up function. See http://stackoverflow.com/questions/739268/wcf-application-start-event
        public DataLibs()
        {
            try
            {
                common.configuration.withEncryption = true;
                common.Settings.sysConfigFile = common.fileFuncs.ConcatFileName(Settings.sysExecuteDirectory, commonTypes.Consts.constWebServiceConf);
                databases.SysLibs.dbConnectionString = common.configuration.GetDbConnectionString();

                GlobalSettings globalSetting = Settings.sysGlobal;
                application.Configuration.Load_Global_Settings(ref globalSetting);
                Settings.sysGlobal = globalSetting;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }

        private static common.DictionaryList sysDataCache = new common.DictionaryList();
        public void ClearCache()
        {
            sysDataCache.Clear();
            application.Strategy.Data.ClearCache();
        }

        //Clear all caches to bring the system into initial state
        public void Reset()
        {
            ClearCache();
            application.SysLibs.ClearCache();
        }

        public void DeleteCache(string cacheName)
        {
            sysDataCache.Remove(cacheName);
        }

        private application.AnalysisData GetAnalysisData(string cacheName)
        {
            object obj = sysDataCache.Find(cacheName);
            if (obj == null) return null;
            return (application.AnalysisData)obj;
        }

        private static string MakeCacheKey(string code, commonClass.DataParams dataParam)
        {
            return "data" + "-" + code + "-" + dataParam.ToUniqueString();
        }
        private static string MakeCacheKey()
        {
            return common.system.UniqueString();
        }

        public DateTime GetServerDateTime()
        {
            return DateTime.Now;
        }

        public bool IsWorking()
        {
            return true;
        }
        #endregion

        #region Tools

        /// <summary>
        /// Get data and store in cache. Depend on forceReadNew, cached data can be used to boost perfomance
        /// </summary>
        /// <param name="timeRange"></param>
        /// <param name="timeScaleCode"></param>
        /// <param name="code"></param>
        /// <param name="forceReadNew"> if true always read from database, ignore the cached data</param>
        /// <returns>Data key used for data accessing</returns>
        public string LoadAnalysisData(string code,commonClass.DataParams dataParam, bool forceReadNew)
        {
            try
            {
                string cacheName = MakeCacheKey(code, dataParam);
                if (forceReadNew || sysDataCache.Find(cacheName) == null)
                {
                    application.AnalysisData myData = new application.AnalysisData(code, dataParam);
                    sysDataCache.Add(cacheName, myData);
                }
                return cacheName;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.priceDataDataTable GetAnalysis_Data_ByKey(string dataKey,out int firstData)
        {
            firstData = 0;
            try
            {
                object dataObj = sysDataCache.Find(dataKey);
                if (dataObj == null) return null;
                firstData = (dataObj as application.AnalysisData).FirstDataStartAt;
                return (dataObj as application.AnalysisData).priceDataTbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.priceDataDataTable GetAnalysis_Data(string code,commonClass.DataParams dataParam, out int firstData)
        {
            string dataKey = LoadAnalysisData(code,dataParam,true);
            return GetAnalysis_Data_ByKey(dataKey, out firstData); 
        }

        //[ServiceKnownType(typeof(TradePointInfo[]))]
        public TradePointInfo[] Analysis(string dataKey, string strategyCode)
        {
            try
            {
                TradePointInfo[] tradePointList = new TradePointInfo[0];
                application.AnalysisData data = GetAnalysisData(dataKey);
                if (data == null) return tradePointList;
                application.Strategy.Meta meta = application.Strategy.Libs.FindMetaByCode(strategyCode);
                if (meta == null) return tradePointList;
                return application.Strategy.Libs.ToTradePointInfo(application.Strategy.Libs.Analysis(data, meta));
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public List<decimal[]> Estimate_Matrix_Profit(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                      string[] stockCodeList, string[] strategyList,
                                                      EstimateOptions option)
        {
            try
            {
                return application.Strategy.Libs.Estimate_Matrix_Profit(timeRange, AppTypes.TimeScaleFromCode(timeScaleCode),
                                                            common.system.List2Collection(stockCodeList),
                                                            common.system.List2Collection(strategyList), option);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public List<double[]> Estimate_Matrix_LastBizWeight(DataParams dataParam,string[] stockCodeList, string[] strategyList)
        {
            try
            {
                WriteLog(1, "InvestorCode", "Estimate_Matrix_LastBizWeight", stockCodeList.ToString(), strategyList.ToString());
                return application.Strategy.Libs.Estimate_Matrix_LastBizWeight(dataParam, common.system.List2Collection(stockCodeList),
                                                                               common.system.List2Collection(strategyList));
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.tmpDS.dataVarrianceDataTable GetTopPriceVarrianceMarket(DateTime beforeDate, string timeScaleCode, int topN)
        {
            try
            {
                return databases.AppLibs.GetTopPriceVarriance(beforeDate, timeScaleCode, topN);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.tmpDS.dataVarrianceDataTable GetTopPriceVarrianceUser(DateTime beforeDate, string timeScaleCode, string userCode, int topN)
        {
            try
            {
                return databases.AppLibs.GetTopPriceVarrianceOfUser(beforeDate, timeScaleCode, userCode, topN);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public DataValues[] GetIndicatorData(string code, commonClass.DataParams dataParam, string metaName)
        {
            try
            {
                application.AnalysisData data = GetAnalysisData(LoadAnalysisData(code, dataParam, false));
                if (data == null) return null;
                application.Indicators.Meta meta = application.Indicators.Libs.FindMetaByName(metaName);
                return application.Indicators.Libs.GetIndicatorData(data, meta);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        #endregion Tools

        #region Load/Get data
        public databases.tmpDS.investorDataTable GetInvestorShortList()
        {
            try
            {
                databases.tmpDS.investorDataTable tbl = new databases.tmpDS.investorDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.sysLogDataTable GetSyslog_ByDate(DateTime frDate,DateTime toDate)
        {
            try
            {
                databases.baseDS.sysLogDataTable tbl = new databases.baseDS.sysLogDataTable();
                databases.DbAccess.LoadData(tbl, frDate, toDate);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;

        }
        public databases.baseDS.sysLogDataTable GetSyslog_BySQL(string sql)
        {
            try
            {
                databases.baseDS.sysLogDataTable tbl = new databases.baseDS.sysLogDataTable();
                databases.DbAccess.LoadFromSQL(tbl, sql);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.investorDataTable GetInvestor_BySQL(string sql)
        {
            try
            {
                databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
                databases.DbAccess.LoadFromSQL(tbl, sql);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.investorDataTable GetInvestor_ByCode(string code)
        {
            try
            {
                databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
                databases.DbAccess.LoadData(tbl, code);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.investorDataTable GetInvestor_ByAccount(string account)
        {
            try
            {
                databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
                databases.DbAccess.LoadInvestorByAccount(tbl, account);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.investorDataTable GetInvestor_ByEmail(string email)
        {
            try
            {
                databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
                databases.DbAccess.LoadInvestorByEmail(tbl, email);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.tmpDS.stockCodeDataTable GetStockByStatus(AppTypes.CommonStatus status)
        {
            try
            {
                databases.tmpDS.stockCodeDataTable tbl = new databases.tmpDS.stockCodeDataTable();
                databases.DbAccess.LoadData(tbl, status);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.stockCodeDataTable GetStockFull()
        {
            try
            {
                databases.baseDS.stockCodeDataTable tbl = new databases.baseDS.stockCodeDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.stockExchangeDataTable GetStockExchange()
        {
            try
            {
                databases.baseDS.stockExchangeDataTable tbl = new databases.baseDS.stockExchangeDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.exchangeDetailDataTable GetExchangeDetail(string code)
        {
            try
            {
                databases.baseDS.exchangeDetailDataTable tbl = new databases.baseDS.exchangeDetailDataTable();
                databases.DbAccess.LoadData(tbl, code);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.employeeRangeDataTable GetEmployeeRange()
        {
            try
            {
                databases.baseDS.employeeRangeDataTable tbl = new databases.baseDS.employeeRangeDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.bizIndustryDataTable GetBizIndustry()
        {
            try
            {
                databases.baseDS.bizIndustryDataTable tbl = new databases.baseDS.bizIndustryDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.bizSuperSectorDataTable GetBizSuperSector()
        {
            try
            {
                databases.baseDS.bizSuperSectorDataTable tbl = new databases.baseDS.bizSuperSectorDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.bizSectorDataTable GetBizSector()
        {
            try
            {
                databases.baseDS.bizSectorDataTable tbl = new databases.baseDS.bizSectorDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.bizSubSectorDataTable GetBizSubSector()
        {
            try
            {
                databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSectorByIndustry(string industryCode)
        {
            try
            {
                databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
                databases.DbAccess.LoadDataByIndustryCode(tbl, industryCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSectorBySuperSector(string superSectorCode)
        {
            try
            {
                databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
                databases.DbAccess.LoadDataBySuperSectorCode(tbl, superSectorCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSectorBySector(string sectorCode)
        {
            try
            {
                databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
                databases.DbAccess.LoadDataBySectorCode(tbl, sectorCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.feedbackCatDataTable GetFeedbackCat(string cultureCode)
        {
            try
            {
                databases.baseDS.feedbackCatDataTable tbl = new databases.baseDS.feedbackCatDataTable();
                databases.DbAccess.LoadData(tbl, cultureCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.countryDataTable GetCountry()
        {
            try
            {
                databases.baseDS.countryDataTable tbl = new databases.baseDS.countryDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.currencyDataTable GetCurrency()
        {
            try
            {
                databases.baseDS.currencyDataTable tbl = new databases.baseDS.currencyDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.investorCatDataTable GetInvestorCat()
        {
            try
            {
                databases.baseDS.investorCatDataTable tbl = new databases.baseDS.investorCatDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.sysCodeDataTable GetSysCode(string catCode)
        {
            try
            {
                databases.baseDS.sysCodeDataTable tbl = new databases.baseDS.sysCodeDataTable();
                databases.DbAccess.LoadData(tbl, catCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.sysCodeCatDataTable GetSysCodeCat()
        {
            try
            {
                databases.baseDS.sysCodeCatDataTable tbl = new databases.baseDS.sysCodeCatDataTable();
                databases.DbAccess.LoadData(tbl);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.tmpDS.investorStockDataTable GetOwnedStockSum_ByInvestor(string investorCode)
        {
            try
            {
                databases.tmpDS.investorStockDataTable tbl = new databases.tmpDS.investorStockDataTable();
                databases.DbAccess.LoadData(tbl, investorCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.investorStockDataTable GetOwnedStock_ByPortfolio(string portfolioCode)
        {
            try
            {
                databases.baseDS.investorStockDataTable tbl = new databases.baseDS.investorStockDataTable();
                databases.DbAccess.LoadData(tbl, portfolioCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        private static string[] MakeStockCodeList(databases.tmpDS.stockCodeDataTable stockCodeTbl)
        {
            string[] retList = new string[stockCodeTbl.Count];
            for (int idx = 0; idx < stockCodeTbl.Count; idx++)
            {
                retList[idx] = stockCodeTbl[idx].code;
            }
            return retList;
        }
        public string[] GetStockList_ByWatchList(string[] watchList)
        {
            try
            {
                databases.tmpDS.stockCodeDataTable stockCodeTbl = new databases.tmpDS.stockCodeDataTable();
                databases.DbAccess.LoadStockCode_ByWatchList(stockCodeTbl, common.system.List2Collection(watchList));
                return MakeStockCodeList(stockCodeTbl);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public string[] GetStockList_ByBizSector(string[] sectors)
        {
            try
            {
                databases.tmpDS.stockCodeDataTable stockCodeTbl = new databases.tmpDS.stockCodeDataTable();
                databases.DbAccess.LoadStockCode_ByBizSectors(stockCodeTbl, common.system.List2Collection(sectors));
                return MakeStockCodeList(stockCodeTbl);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.tmpDS.stockCodeDataTable GetStock_InPortfolio(string[] portfolios)
        {
            try
            {
                databases.tmpDS.stockCodeDataTable retTbl = new databases.tmpDS.stockCodeDataTable();
                databases.DbAccess.LoadStockCode_ByPortfolios(retTbl, common.system.List2Collection(portfolios));
                return retTbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.tmpDS.stockCodeDataTable GetStock_ByBizSector(string[] bizSectors)
        {
            try
            {
                databases.tmpDS.stockCodeDataTable retTbl = new databases.tmpDS.stockCodeDataTable();
                databases.DbAccess.LoadStockCode_ByBizSectors(retTbl, common.system.List2Collection(bizSectors));
                return retTbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.bizSubSectorDataTable GetBizSubSector_ByIndustry(string codes)
        {
            try
            {
                databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
                databases.DbAccess.LoadDataByIndustryCode(tbl, codes);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySuperSector(string codes)
        {
            try
            {
                databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
                databases.DbAccess.LoadDataBySuperSectorCode(tbl, codes);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySector(string codes)
        {
            try
            {
                databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
                databases.DbAccess.LoadDataBySectorCode(tbl, codes);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.portfolioDataTable GetPortfolio_ByInvestorAndType(string investorCode, AppTypes.PortfolioTypes type)
        {
            try
            {
                databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
                databases.DbAccess.LoadPortfolioByInvestor(tbl, investorCode, type);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.portfolioDataTable GetPortfolio_ByType(AppTypes.PortfolioTypes type)
        {
            try
            {
                databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
                databases.DbAccess.LoadData(tbl, type);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.portfolioDataTable GetPortfolio_ByCode(string code)
        {
            try
            {
                databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
                databases.DbAccess.LoadData(tbl, code);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.portfolioDataTable GetPortfolio_ByInvestor(string investorCode)
        {
            try
            {
                databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
                databases.DbAccess.LoadPortfolioByInvestor(tbl, investorCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByType(AppTypes.PortfolioTypes[] types)
        {
            try
            {
                return databases.DbAccess.GetPortfolioDetail_ByType(types);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByCode(string portfolioCode)
        {
            try
            {
                databases.baseDS.portfolioDetailDataTable tbl = new databases.baseDS.portfolioDetailDataTable();
                databases.DbAccess.LoadData(tbl, portfolioCode);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }


        public databases.baseDS.tradeAlertDataTable GetTradeAlert(DateTime frDate, DateTime toDate, string investor, byte statusMask)
        {
            try
            {
                return databases.DbAccess.GetTradeAlert(frDate, toDate, investor, statusMask);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.tradeAlertDataTable GetTradeAlert_BySQL(string sql)
        {
            try
            {
                databases.baseDS.tradeAlertDataTable tbl = new databases.baseDS.tradeAlertDataTable();
                databases.DbAccess.LoadFromSQL(tbl, sql);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.transactionsDataTable GetTransaction_BySQL(string sql)
        {
            try
            {
                databases.baseDS.transactionsDataTable tbl = new databases.baseDS.transactionsDataTable();
                databases.DbAccess.LoadFromSQL(tbl, sql);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.priceDataDataTable GetPriceData(string stockCode, string timeScaleCode,DateTime frDate,DateTime toDate)
        {
            try
            {
                databases.baseDS.priceDataDataTable priceDataTbl = new databases.baseDS.priceDataDataTable();
                databases.DbAccess.LoadData(priceDataTbl, timeScaleCode, frDate, toDate, stockCode);
                return priceDataTbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public databases.baseDS.lastPriceDataDataTable GetLastPriceSum(AppTypes.PriceDataType type,string timeScaleCode)
        {
            try
            {
                DateTime fromDate = DateTime.Today.AddDays(-Settings.sysGlobal.DayScanForLastPrice);
                string cacheName = "lastPrice-" + type.ToString();
                databases.baseDS.lastPriceDataDataTable dataTbl = null;
                object obj = sysDataCache.Find(cacheName);
                if (obj == null)
                {
                    dataTbl = databases.DbAccess.GetLastPrice(type,timeScaleCode, fromDate);
                    sysDataCache.Add(cacheName, new DataCacheItem(dataTbl));
                    return dataTbl;
                }
                if ((obj as DataCacheItem).timeStamp + TimeSpan.FromSeconds(Settings.sysDataDelayTimeInSecs).Ticks > DateTime.Now.Ticks)
                {
                    return (databases.baseDS.lastPriceDataDataTable)(obj as DataCacheItem).data;
                }
                dataTbl = databases.DbAccess.GetLastPrice(type,timeScaleCode, fromDate);
                sysDataCache.Add(cacheName, new DataCacheItem(dataTbl));
                return dataTbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        
        public bool GetTransactionInfo(ref TransactionInfo transInfo)
        {
            try
            {
                databases.baseDS.priceDataRow priceRow = databases.DbAccess.GetLastPriceData(transInfo.stockCode);
                databases.baseDS.portfolioRow portfolioRow = databases.DbAccess.GetPortfolio(transInfo.portfolio);
                databases.baseDS.stockExchangeRow marketRow = databases.DbAccess.GetStockExchange(transInfo.stockCode);
                if (priceRow == null || portfolioRow == null || marketRow == null) return false;
                transInfo.price = priceRow.closePrice;
                transInfo.priceDate = priceRow.onDate;
                transInfo.availableCash = portfolioRow.startCapAmt - portfolioRow.usedCapAmt;
                transInfo.transFeePerc = marketRow.tranFeePerc;
                transInfo.priceRatio = marketRow.priceRatio;
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }

        public databases.baseDS.priceDataDataTable GetData_ByTimeScale_Code_FrDate(string timeScaleCode,string stockCode,DateTime fromDate)
        {
            databases.baseDS.priceDataDataTable tbl = new databases.baseDS.priceDataDataTable();
            databases.DbAccess.LoadData(tbl, timeScaleCode, fromDate, stockCode);
            return tbl;
        }
        public databases.baseDS.priceDataDataTable GetData_ByTimeScale_Code_DateRange(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            databases.baseDS.priceDataDataTable tbl = new databases.baseDS.priceDataDataTable();
            databases.DbAccess.LoadData(tbl, timeScaleCode, frDate, toDate, stockCode);
            return tbl;
        }
        

        public int GetData_TotalRow(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            return databases.DbAccess.GetTotalPriceRow(AppTypes.TimeScaleFromCode(timeScaleCode), frDate, toDate, stockCode);
        }

        public DateTime GetLastAlertTime(string investorCode)
        {
            return databases.DbAccess.GetLastAlertTime(investorCode);
        }

        //public databases.baseDS.priceDataDataTable GetAbnormalData(string code,DateTime frDate, DateTime toDate,string timeSacleCode)
        //{
        //    databases.baseDS.priceDataDataTable tbl = new databases.baseDS.priceDataDataTable();
        //    databases.DbAccess.LoadAbnormalData(tbl,code,frDate, toDate,timeSacleCode);
        //    return tbl;
        //}

        public databases.baseDS.messagesDataTable GetMesssage_ByDate(DateTime frDate,DateTime toDate)
        {
            try
            {
                databases.baseDS.messagesDataTable tbl = new databases.baseDS.messagesDataTable();
                databases.DbAccess.LoadData(tbl, frDate, toDate);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public databases.baseDS.messagesDataTable GetMesssage_BySql(string sql)
        {
            try
            {
                databases.baseDS.messagesDataTable tbl = new databases.baseDS.messagesDataTable();
                databases.DbAccess.LoadFromSQL(tbl, sql);
                return tbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        #endregion

        #region Update
        public bool UpdateMessage(ref databases.baseDS.messagesDataTable dataTbl)
        {
            try
            {
                databases.DbAccess.UpdateData(dataTbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }

        public bool UpdatePriceData(ref databases.baseDS.priceDataDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateSysCodeCat(ref databases.baseDS.sysCodeCatDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateSysCode(ref databases.baseDS.sysCodeDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateStock(ref databases.baseDS.stockCodeDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateInvestor(ref databases.baseDS.investorDataTable tbl)
        {
            try
            {
                for (int idx = 0; idx < tbl.Count; idx++)
                {
                    if (tbl[idx].code.Trim() == Consts.constMarkerNEW)
                    {
                        tbl[idx].code = application.SysLibs.GetAutoDataKey(tbl.TableName, false).Trim();
                    }
                }
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdatePortfolio(ref databases.baseDS.portfolioDataTable tbl)
        {
            try
            {
                for (int idx = 0; idx < tbl.Count; idx++)
                {
                    if (tbl[idx].code.Trim() == Consts.constMarkerNEW)
                    {
                        common.myAutoKeyInfo info = application.SysLibs.GetAutoKey(tbl.TableName, false);
                        tbl[idx].code = info.value.ToString().PadLeft(tbl.codeColumn.MaxLength, '0');
                    }
                }
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdatePortfolioDetail(ref databases.baseDS.portfolioDetailDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateStockExchange(ref databases.baseDS.stockExchangeDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateExchangeDetail(ref databases.baseDS.exchangeDetailDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateTransactions(ref databases.baseDS.transactionsDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateInvestorStock(ref databases.baseDS.investorStockDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateTradeAlert(ref databases.baseDS.tradeAlertDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }
        public bool UpdateSysAutoKeyPending(ref databases.baseDS.sysAutoKeyPendingDataTable tbl)
        {
            try
            {
                databases.DbAccess.UpdateData(tbl);
                return true;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return false;
        }

        #endregion

        #region Delete
        public void DeleteStockExchange(string code)
        {
            try
            {
                databases.DbAccess.DeleteStockExchange(code);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        public void DeleteStock(string code)
        {
            try
            {
                databases.DbAccess.DeleteStock(code);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        public void DeleteInvestor(string code)
        {
            try
            {
                databases.DbAccess.DeleteInvestor(code);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        public void DeletePortfolio(string code)
        {
            try
            {
                databases.DbAccess.DeletePortfolio(code);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        public void DeleteTradeAlert(int rowId)
        {
            try
            {
                databases.DbAccess.DeleteTradeAlert(rowId);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }

        public void DeleteSysCodeCat(string code)
        {
            try
            {
                databases.DbAccess.DeleteSysCodeCat(code);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        public void DeleteSysCode(string catCode,string code)
        {
            try
            {
                databases.DbAccess.DeleteSysCode(catCode, code);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        #endregion

        #region application
        /// <summary>
        ///  Create records to keep stock transaction (buy,sell...) 
        ///  - transactions
        ///  - investorStock
        /// </summary>
        /// <param name="onDate"></param>
        /// <param name="type"></param>
        /// <param name="stockCode"></param>
        /// <param name="portfolio"></param>
        /// <param name="qty"></param>
        /// <param name="amt"></param>
        /// 
        public databases.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type,string stockCode, string portfolioCode, int qty, decimal feePerc,out string errorText)
        {
            errorText = "";
            try
            {
                return application.AppLibs.MakeTransaction(type, stockCode, portfolioCode, qty, feePerc, out errorText);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public TradePointInfo[] GetTradePointWithEstimationDetail(DataParams dataParam,string stockCode, string strategyCode, EstimateOptions options,
                                                                  out databases.tmpDS.tradeEstimateDataTable toTbl)
        {
            toTbl = null;
            try
            {
                string dataKey = LoadAnalysisData(stockCode, dataParam, false);
                TradePointInfo[] tradePoints = Analysis(dataKey, strategyCode);
                toTbl = application.Strategy.Libs.EstimateTrading_Details(sysDataCache.Find(dataKey) as application.AnalysisData, tradePoints, options);
                return tradePoints;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public string GetXmlDoc2StringSTRATEGY()
        {
            try
            {
                XmlDocument xml = commonClass.Configuration.GetLocalXmlDocSTRATEGY();
                if (xml == null) return null;
                StringWriter writer = new StringWriter();
                xml.Save(writer);
                return writer.ToString();
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }
        public string GetXmlDoc2StringINDICATOR()
        {
            try
            {
                XmlDocument xml = commonClass.Configuration.GetLocalXmlDocINDICATOR();
                if (xml == null) return null;
                StringWriter writer = new StringWriter();
                xml.Save(writer);
                return writer.ToString();
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public void Load_Global_Settings(ref GlobalSettings settings)
        {
            try
            {
                application.Configuration.Load_Global_Settings(ref settings);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        public void Save_Global_Settings(GlobalSettings settings)
        {
            try
            {
                application.Configuration.Save_Global_Settings(settings);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }


        public databases.tmpDS.priceDiagnoseDataTable DiagnosePrice_CloseAndNextOpen(DateTime frDate, DateTime toDate, string timeScaleCode,
                                                                   string exchangeCode,string code, double variancePerc, double variance,byte precision)
        {
            try
            {
                databases.baseDS.priceDataDataTable priceDataTbl = new databases.baseDS.priceDataDataTable();
                databases.tmpDS.priceDiagnoseDataTable priceDiagnoseTbl = new databases.tmpDS.priceDiagnoseDataTable();
                if (code != null && code.Trim() != "")
                {
                    priceDataTbl.Clear();
                    databases.DbAccess.LoadData(priceDataTbl, timeScaleCode, frDate, toDate, code.Trim());
                    application.AppLibs.DiagnosePrice_CloseAndNextOpen(priceDataTbl, variancePerc, variance,precision, priceDiagnoseTbl);
                }
                else
                {
                    databases.tmpDS.stockCodeDataTable codeTbl = new databases.tmpDS.stockCodeDataTable();
                    databases.DbAccess.LoadStockCode_ByStockExchange(codeTbl, exchangeCode, AppTypes.CommonStatus.Enable);
                    for (int idx = 0; idx < codeTbl.Count; idx++)
                    {
                        priceDataTbl.Clear();
                        databases.DbAccess.LoadData(priceDataTbl, timeScaleCode, frDate, toDate, codeTbl[idx].code);
                        application.AppLibs.DiagnosePrice_CloseAndNextOpen(priceDataTbl, variancePerc, variance,precision, priceDiagnoseTbl);
                    }
                    codeTbl.Dispose();
                }
                priceDataTbl.Dispose();
                return priceDiagnoseTbl;
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
            return null;
        }

        public void AjustPriceData(string code, DateTime toDate, double weight)
        {
            try
            {
                //application.AppLibs.AjustPriceData(code, toDate, (decimal)weight);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
       
        //public void AdjustPriceData(string code, DateTime toDate, double weight)
        //{
        //    try
        //    {
        //        application.AppLibs.AjustPriceData(code, toDate, (decimal)weight);
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteSysLogLocal(ex);
        //    }
        //}

        public void ReAggregatePriceData(string code)
        {
            try
            {
                CultureInfo stockCulture = application.AppLibs.GetStockCulture(code);
                databases.AppLibs.ReAggregatePriceData(code, stockCulture,null);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        #endregion

        #region syslog
        public void WriteLog(byte logType,string investorCode, string desc, string source, string msg)
        {
            try
            {
                databases.DbAccess.WriteSyslog(logType, investorCode, desc, source, msg);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }
        public void WriteExcptionLog(string investorCode, common.SysLog.LogData logData)
        {
            try
            {
                databases.DbAccess.WriteSyslog( AppTypes.SyslogTypes.Exception, investorCode,logData.description,logData.source,
                                                logData.message +" "+ logData.info);
            }
            catch (Exception ex)
            {
                WriteSysLogLocal(ex);
            }
        }

        #endregion syslog


        #region Backward compatible

        public databases.baseDS.lastPriceDataDataTable GetLastPrice(AppTypes.PriceDataType type)
        {
            return GetLastPriceSum(type, AppTypes.TimeScaleFromType(AppTypes.TimeScaleTypes.Day).Code);
        }
        public databases.tmpDS.dataVarrianceDataTable GetTopPriceVarrianceOfUser(DateTime frDate, DateTime toDate, string timeScaleCode, string userCode, int topN)
        {
            return GetTopPriceVarrianceUser(frDate, timeScaleCode, userCode, topN);
        }
        public databases.tmpDS.dataVarrianceDataTable GetTopPriceVarriance(DateTime frDate, DateTime toDate, string timeScaleCode, int topN)
        {
            return GetTopPriceVarrianceMarket(frDate, timeScaleCode, topN);
        }

        #endregion

        #region test
        public DataTable Test(string sql)
        {
            DataTable tbl = new DataTable("testTbl");
            //populate table with sql query    
            //databases.DbAccess.LoadFromSQL(tbl, "SELECT *  FROM priceData where onDate<'2006/01/01'");
            //databases.DbAccess.LoadFromSQL(tbl, "SELECT TOP 100000 *  FROM priceData"); 
            //common.fileFuncs.WriteLog(sql, "D:\\test\\iis\\bin\\aa.log");
            //databases.DbAccess.LoadFromSQL(tbl, sql);
            //common.fileFuncs.WriteLog(tbl.Rows.Count.ToString(), "D:\\test\\iis\\bin\\aa.log");
            return tbl;
        }

        #endregion
    }
}

        