﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
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

        #region system
        //Start-up function. See http://stackoverflow.com/questions/739268/wcf-application-start-event
        public DataLibs()
        {
            SetConfig();
        }

        /// <summary>
        /// Customed config for web services
        /// </summary>
        public static void SetConfig()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            common.configuration.withEncryption = true;
            common.Settings.sysConfigFile = common.fileFuncs.ConcatFileName(commonClass.SysLibs.myExecuteDirectory, commonTypes.Consts.constWebServiceConf);
            databases.SysLibs.dbConnectionString = common.configuration.GetDbConnectionString();
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
            return "data" + "-" + code + "-" + dataParam.TimeRange.ToString() + "-" + dataParam.MaxDataCount.ToString()+ "-" + dataParam.TimeScale;
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
            string cacheName = MakeCacheKey(code,dataParam);
            if (forceReadNew || sysDataCache.Find(cacheName) == null)
            {
                application.AnalysisData myData = new application.AnalysisData(code, dataParam);
                sysDataCache.Add(cacheName, myData);
            }
            return cacheName;
        }

        
        public databases.baseDS.priceDataDataTable GetAnalysis_Data_ByKey(string dataKey,out int firstData)
        {
            firstData = 0;
            object dataObj = sysDataCache.Find(dataKey);
            if (dataObj == null) return null;
            firstData = (dataObj as application.AnalysisData).FirstDataStartAt;
            return (dataObj as application.AnalysisData).priceDataTbl;
        }
        public databases.baseDS.priceDataDataTable GetAnalysis_Data(string code,commonClass.DataParams dataParam, out int firstData)
        {
            string dataKey = LoadAnalysisData(code,dataParam,true);
            return GetAnalysis_Data_ByKey(dataKey, out firstData); 
        }

        //[ServiceKnownType(typeof(TradePointInfo[]))]
        public TradePointInfo[] Analysis(string dataKey, string strategyCode)
        {
            TradePointInfo[] tradePointList = new TradePointInfo[0];
            application.AnalysisData data = GetAnalysisData(dataKey);
            if (data == null) return tradePointList;
            application.Strategy.Meta meta = application.Strategy.Libs.FindMetaByCode(strategyCode);
            if (meta == null) return tradePointList;
            return application.Strategy.Libs.ToTradePointInfo(application.Strategy.Libs.Analysis(data, meta));
        }

        public List<decimal[]> Estimate_Matrix_Profit(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                      string[] stockCodeList, string[] strategyList,
                                                      EstimateOptions option)
        {
            return application.Strategy.Libs.Estimate_Matrix_Profit(timeRange, AppTypes.TimeScaleFromCode(timeScaleCode), 
                                                        common.system.List2Collection(stockCodeList),
                                                        common.system.List2Collection(strategyList), option);
        }

        public List<double[]> Estimate_Matrix_LastBizWeight(DataParams dataParam,string[] stockCodeList, string[] strategyList)
        {
            return application.Strategy.Libs.Estimate_Matrix_LastBizWeight(dataParam,common.system.List2Collection(stockCodeList),
                                                                           common.system.List2Collection(strategyList));
        }

        #endregion Tools

        #region Load/Get data
        public databases.tmpDS.investorDataTable GetInvestorShortList()
        {
            databases.tmpDS.investorDataTable tbl = new databases.tmpDS.investorDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }
        public databases.baseDS.investorDataTable GetInvestor_BySQL(string sql)
        {
            databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
            databases.DbAccess.LoadFromSQL(tbl, sql);
            return tbl;
        }
        public databases.baseDS.investorDataTable GetInvestor_ByCode(string code)
        {
            databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
            databases.DbAccess.LoadData(tbl, code);
            return tbl;
        }
        public databases.baseDS.investorDataTable GetInvestor_ByAccount(string account)
        {
            databases.baseDS.investorDataTable tbl = new databases.baseDS.investorDataTable();
            databases.DbAccess.LoadInvestorByAccount(tbl, account);
            return tbl;
        }

        public databases.tmpDS.stockCodeDataTable GetStockByStatus(AppTypes.CommonStatus status)
        {
            databases.tmpDS.stockCodeDataTable tbl = new databases.tmpDS.stockCodeDataTable();
            databases.DbAccess.LoadData(tbl, status);
            return tbl;
        }
        public databases.baseDS.stockCodeDataTable GetStockFull()
        {
            databases.baseDS.stockCodeDataTable tbl = new databases.baseDS.stockCodeDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }
        public databases.baseDS.stockExchangeDataTable GetStockExchange()
        {
            databases.baseDS.stockExchangeDataTable tbl = new databases.baseDS.stockExchangeDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }

        public databases.baseDS.employeeRangeDataTable GetEmployeeRange()
        {
            databases.baseDS.employeeRangeDataTable tbl = new databases.baseDS.employeeRangeDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }

        public databases.baseDS.bizIndustryDataTable GetBizIndustry()
        {
            databases.baseDS.bizIndustryDataTable tbl = new databases.baseDS.bizIndustryDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }
        public databases.baseDS.bizSuperSectorDataTable GetBizSuperSector()
        {
            databases.baseDS.bizSuperSectorDataTable tbl = new databases.baseDS.bizSuperSectorDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }
        public databases.baseDS.bizSectorDataTable GetBizSector()
        {
            databases.baseDS.bizSectorDataTable tbl = new databases.baseDS.bizSectorDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }

        public databases.baseDS.bizSubSectorDataTable GetBizSubSector()
        {
            databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSectorByIndustry(string industryCode)
        {
            databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
            databases.DbAccess.LoadDataByIndustryCode(tbl, industryCode);
            return tbl;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSectorBySuperSector(string superSectorCode)
        {
            databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
            databases.DbAccess.LoadDataBySuperSectorCode(tbl, superSectorCode);
            return tbl;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSectorBySector(string sectorCode)
        {
            databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
            databases.DbAccess.LoadDataBySectorCode(tbl, sectorCode);
            return tbl;
        }

        public databases.baseDS.countryDataTable GetCountry()
        {
            databases.baseDS.countryDataTable tbl = new databases.baseDS.countryDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }
        public databases.baseDS.currencyDataTable GetCurrency()
        {
            databases.baseDS.currencyDataTable tbl = new databases.baseDS.currencyDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }

        public databases.baseDS.investorCatDataTable GetInvestorCat()
        {
            databases.baseDS.investorCatDataTable tbl = new databases.baseDS.investorCatDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }

        public databases.baseDS.sysCodeDataTable GetSysCode(string catCode)
        {
            databases.baseDS.sysCodeDataTable tbl = new databases.baseDS.sysCodeDataTable();
            databases.DbAccess.LoadData(tbl, catCode);
            return tbl;
        }
        public databases.baseDS.sysCodeCatDataTable GetSysCodeCat()
        {
            databases.baseDS.sysCodeCatDataTable tbl = new databases.baseDS.sysCodeCatDataTable();
            databases.DbAccess.LoadData(tbl);
            return tbl;
        }

        public databases.baseDS.investorStockDataTable GetOwnedStock(string portfolioCode)
        {
            databases.baseDS.investorStockDataTable tbl = new databases.baseDS.investorStockDataTable();
            databases.DbAccess.LoadData(tbl, portfolioCode);
            return tbl;
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
            databases.tmpDS.stockCodeDataTable stockCodeTbl = new databases.tmpDS.stockCodeDataTable();
            databases.DbAccess.LoadStockCode_ByWatchList(stockCodeTbl, common.system.List2Collection(watchList));
            return MakeStockCodeList(stockCodeTbl);
        }
        public string[] GetStockList_ByBizSector(string[] sectors)
        {
            databases.tmpDS.stockCodeDataTable stockCodeTbl = new databases.tmpDS.stockCodeDataTable();
            databases.DbAccess.LoadStockCode_ByBizSectors(stockCodeTbl, common.system.List2Collection(sectors));
            return MakeStockCodeList(stockCodeTbl);
        }

        public databases.tmpDS.stockCodeDataTable GetStock_InPortfolio(string[] portfolios)
        {
            databases.tmpDS.stockCodeDataTable retTbl = new databases.tmpDS.stockCodeDataTable();
            databases.DbAccess.LoadStockCode_ByPortfolios(retTbl, common.system.List2Collection(portfolios));
            return retTbl;
        }
        public databases.tmpDS.stockCodeDataTable GetStock_ByBizSector(string[] bizSectors)
        {
            databases.tmpDS.stockCodeDataTable retTbl = new databases.tmpDS.stockCodeDataTable();
            databases.DbAccess.LoadStockCode_ByBizSectors(retTbl, common.system.List2Collection(bizSectors));
            return retTbl;
        }

        public databases.baseDS.bizSubSectorDataTable GetBizSubSector_ByIndustry(string codes)
        {
            databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
            databases.DbAccess.LoadDataByIndustryCode(tbl, codes);
            return tbl;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySuperSector(string codes)
        {
            databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
            databases.DbAccess.LoadDataBySuperSectorCode(tbl, codes);
            return tbl;
        }
        public databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySector(string codes)
        {
            databases.baseDS.bizSubSectorDataTable tbl = new databases.baseDS.bizSubSectorDataTable();
            databases.DbAccess.LoadDataBySectorCode(tbl, codes);
            return tbl;
        }

        public databases.baseDS.portfolioDataTable GetPortfolio_ByInvestorAndType(string investorCode, AppTypes.PortfolioTypes type)
        {
            databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
            databases.DbAccess.LoadPortfolioByInvestor(tbl, investorCode, type);
            return tbl;
        }
        public databases.baseDS.portfolioDataTable GetPortfolio_ByType(AppTypes.PortfolioTypes type)
        {
            databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
            databases.DbAccess.LoadData(tbl, type);
            return tbl;
        }
        public databases.baseDS.portfolioDataTable GetPortfolio_ByCode(string code)
        {
            databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
            databases.DbAccess.LoadData(tbl, code);
            return tbl;
        }
        public databases.baseDS.portfolioDataTable GetPortfolio_ByInvestor(string investorCode)
        {
            databases.baseDS.portfolioDataTable tbl = new databases.baseDS.portfolioDataTable();
            databases.DbAccess.LoadPortfolioByInvestor(tbl, investorCode);
            return tbl;
        }

        public databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByType(AppTypes.PortfolioTypes[] types)
        {
            return databases.DbAccess.GetPortfolioDetail_ByType(types);
        }
        public databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByCode(string portfolioCode)
        {
            databases.baseDS.portfolioDetailDataTable tbl = new databases.baseDS.portfolioDetailDataTable();
            databases.DbAccess.LoadData(tbl, portfolioCode);
            return tbl;
        }

        public databases.baseDS.tradeAlertDataTable GetTradeAlert_BySQL(string sql)
        {
            databases.baseDS.tradeAlertDataTable tbl = new databases.baseDS.tradeAlertDataTable();
            databases.DbAccess.LoadFromSQL(tbl, sql);
            return tbl;
        }
        public databases.baseDS.transactionsDataTable GetTransaction_BySQL(string sql)
        {
            databases.baseDS.transactionsDataTable tbl = new databases.baseDS.transactionsDataTable();
            databases.DbAccess.LoadFromSQL(tbl, sql);
            return tbl;
        }

        public databases.baseDS.lastPriceDataDataTable GetLastPrice(AppTypes.PriceDataType type)
        {
            string cacheName = "lastPrice-" + type.ToString();
            databases.baseDS.lastPriceDataDataTable dataTbl = null;
            object obj = sysDataCache.Find(cacheName);
            if (obj == null)
            {
                dataTbl = databases.DbAccess.GetLastPrice(type);
                sysDataCache.Add(cacheName, new DataCacheItem(dataTbl));
                return dataTbl;
            }
            if ((obj as DataCacheItem).timeStamp + TimeSpan.FromSeconds(Settings.sysDataDelayTimeInSecs).Ticks > DateTime.Now.Ticks)
            {
                return (databases.baseDS.lastPriceDataDataTable)(obj as DataCacheItem).data;
            }
            dataTbl = databases.DbAccess.GetLastPrice(type);
            sysDataCache.Add(cacheName, new DataCacheItem(dataTbl));
            return dataTbl;
        }

        public bool GetTransactionInfo(ref TransactionInfo transInfo)
        {
            databases.baseDS.priceDataRow priceRow = databases.DbAccess.GetLastPriceData(transInfo.stockCode);
            databases.baseDS.portfolioRow portfolioRow = databases.DbAccess.GetPortfolio(transInfo.portfolio);
            databases.baseDS.stockExchangeRow marketRow = databases.DbAccess.GetStockExchange(transInfo.stockCode);
            if (priceRow == null || portfolioRow == null || marketRow==null) return false;
            transInfo.price = priceRow.closePrice;
            transInfo.priceDate = priceRow.onDate;
            transInfo.availableCash = portfolioRow.startCapAmt - portfolioRow.usedCapAmt;
            transInfo.transFeePerc = marketRow.tranFeePerc;
            transInfo.priceRatio = marketRow.priceRatio;
            return true;
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
        public databases.tmpDS.marketDataDataTable GetMarketData_BySQL(string sqlCmd)
        {
            databases.tmpDS.marketDataDataTable tbl = new databases.tmpDS.marketDataDataTable();
            databases.DbAccess.LoadFromSQL(tbl, sqlCmd);
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

        #endregion

        #region Update
        public void UpdateSysCodeCat(ref databases.baseDS.sysCodeCatDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }
        public void UpdateSysCode(ref databases.baseDS.sysCodeDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }

        public void UpdateStock(ref databases.baseDS.stockCodeDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }
        public void UpdateInvestor(ref databases.baseDS.investorDataTable tbl)
        {
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].code.Trim() == Consts.constNotMarkerNEW)
                {
                    tbl[idx].code = application.SysLibs.GetAutoDataKey(tbl.TableName, false).Trim();
                }
            }
            databases.DbAccess.UpdateData(tbl);
        }
        public void UpdatePortfolio(ref databases.baseDS.portfolioDataTable tbl)
        {
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].code.Trim() == Consts.constNotMarkerNEW)
                {
                    common.myAutoKeyInfo info = application.SysLibs.GetAutoKey(tbl.TableName, false);
                    tbl[idx].code = info.value.ToString().PadLeft(tbl.codeColumn.MaxLength, '0');
                }
            }
            databases.DbAccess.UpdateData(tbl);
        }
        public void UpdatePortfolioDetail(ref databases.baseDS.portfolioDetailDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }
        public void UpdateStockExchange(ref databases.baseDS.stockExchangeDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }
        public void UpdateTransactions(ref databases.baseDS.transactionsDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }
        public void UpdateInvestorStock(ref databases.baseDS.investorStockDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }
        public void UpdateTradeAlert(ref databases.baseDS.tradeAlertDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }

        public void UpdateSysAutoKeyPending(ref databases.baseDS.sysAutoKeyPendingDataTable tbl)
        {
            databases.DbAccess.UpdateData(tbl);
        }
        #endregion

        #region Delete
        public void DeleteStockExchange(string code)
        {
            databases.DbAccess.DeleteStockExchange(code);
        }
        public void DeleteStock(string code)
        {
            databases.DbAccess.DeleteStock(code);
        }
        public void DeleteInvestor(string code)
        {
            databases.DbAccess.DeleteInvestor(code);
        }
        public void DeletePortfolio(string code)
        {
            databases.DbAccess.DeletePortfolio(code);
        }
        public void DeleteTradeAlert(int rowId)
        {
            databases.DbAccess.DeleteTradeAlert(rowId);
        }

        public void DeleteSysCodeCat(string code)
        {
            databases.DbAccess.DeleteSysCodeCat(code);
        }
        public void DeleteSysCode(string catCode,string code)
        {
            databases.DbAccess.DeleteSysCode(catCode,code);
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
            return application.AppLibs.MakeTransaction(type, stockCode, portfolioCode, qty, feePerc,out errorText);
        }
        public TradePointInfo[] GetTradePointWithEstimationDetail(DataParams dataParam,string stockCode, string strategyCode, EstimateOptions options,
                                                                  out databases.tmpDS.tradeEstimateDataTable toTbl)
        {
            string dataKey = LoadAnalysisData(stockCode,dataParam, false);
            TradePointInfo[] tradePoints = Analysis(dataKey, strategyCode);
            toTbl = application.Strategy.Libs.EstimateTrading_Details(sysDataCache.Find(dataKey) as application.AnalysisData, tradePoints, options);
            return tradePoints;
        }

        public string GetXmlDoc2StringSTRATEGY()
        {
            XmlDocument xml = commonClass.Configuration.GetLocalXmlDocSTRATEGY();
            if (xml == null) return null;
            StringWriter writer = new StringWriter();
            xml.Save(writer);
            return writer.ToString();
        }
        public string GetXmlDoc2StringINDICATOR()
        {
            XmlDocument xml = commonClass.Configuration.GetLocalXmlDocINDICATOR();
            if (xml == null) return null;
            StringWriter writer = new StringWriter();
            xml.Save(writer);
            return writer.ToString();
        }

        public void Load_Global_Settings(ref GlobalSettings settings)
        {
            application.Configuration.Load_Global_Settings(ref settings);
        }
        public void Save_Global_Settings(GlobalSettings settings)
        {
            application.Configuration.Save_Global_Settings(settings);
        }

        #endregion

        #region syslog
        public void WriteSyslog(AppTypes.SyslogTypes logType,string investorCode, string desc, string source, string msg)
        {
            databases.DbAccess.WriteSyslog(logType,investorCode, desc, source, msg);
        }
        #endregion syslog

        #region test

        //public object[] GetPriceByCode(string stockCode)
        //{
        //    databases.baseDS.priceDataRow priceRow = databases.DbAccess.GetLastPriceData(stockCode);
        //    if (priceRow == null) return null;
        //    return priceRow.ItemArray;
        //}

        //[OperationBehavior]
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

        