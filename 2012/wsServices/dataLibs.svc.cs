using System;
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
using application;
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
            common.Settings.sysConfigFile = common.fileFuncs.ConcatFileName(commonClass.SysLibs.myExecuteDirectory, "wsStock.xml");
            data.SysLibs.dbConnectionString = common.configuration.GetDbConnectionString();

            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            common.configuration.withEncryption = true;
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

        private AnalysisData GetAnalysisData(string cacheName)
        {
            object obj = sysDataCache.Find(cacheName);
            if (obj == null) return null;
            return (AnalysisData)obj;
        }

        private static string MakeCacheKey(AppTypes.TimeRanges timeRange, string timeScaleCode, string code)
        {
            return "data" + "-" + code + "-" + timeRange.ToString() + "-" + timeScaleCode;
        }
        private static string MakeCacheKey()
        {
            return common.system.UniqueString();
        }

        public DateTime GetServerDateTime()
        {
            return DateTime.Now;
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
        public string LoadAnalysisData(AppTypes.TimeRanges timeRange, string timeScaleCode, string code, bool forceReadNew)
        {
            string cacheName = MakeCacheKey(timeRange,timeScaleCode,code);
            if (forceReadNew || sysDataCache.Find(cacheName) == null)
            {
                AnalysisData myData = new AnalysisData(timeRange, AppTypes.TimeScaleFromCode(timeScaleCode), code, AppTypes.DataAccessMode.Local);
                sysDataCache.Add(cacheName, myData);
            }
            return cacheName;
        }

        
        public data.baseDS.priceDataDataTable GetAnalysis_Data_ByKey(string dataKey,out int firstData)
        {
            firstData = 0;
            object dataObj = sysDataCache.Find(dataKey);
            if (dataObj == null) return null;
            firstData = (dataObj as AnalysisData).FirstDataStartAt;
            return (dataObj as AnalysisData).priceDataTbl;
        }
        public data.baseDS.priceDataDataTable GetAnalysis_Data(AppTypes.TimeRanges timeRange,string timeScaleCode, string stockCode, out int firstData)
        {
            string dataKey = LoadAnalysisData(timeRange, timeScaleCode, stockCode, true);
            return GetAnalysis_Data_ByKey(dataKey, out firstData); 
        }

        //[ServiceKnownType(typeof(TradePointInfo[]))]
        public TradePointInfo[] Analysis(string dataKey, string strategyCode)
        {
            TradePointInfo[] tradePointList = new TradePointInfo[0];
            AnalysisData data = GetAnalysisData(dataKey);
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
        public List<double[]> Estimate_Matrix_LastBizWeight(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                            string[] stockCodeList, string[] strategyList)
        {
            return application.Strategy.Libs.Estimate_Matrix_LastBizWeight(timeRange, AppTypes.TimeScaleFromCode(timeScaleCode),
                                                        common.system.List2Collection(stockCodeList),
                                                        common.system.List2Collection(strategyList));
        }
        #endregion Tools

        #region Load/Get data
        public data.baseDS.investorDataTable GetInvestor_BySQL(string sql)
        {
            data.baseDS.investorDataTable tbl = new data.baseDS.investorDataTable();
            DbAccess.LoadFromSQL(tbl, sql);
            return tbl;
        }
        public data.baseDS.investorDataTable GetInvestor_ByCode(string code)
        {
            data.baseDS.investorDataTable tbl = new data.baseDS.investorDataTable();
            DbAccess.LoadData(tbl, code);
            return tbl;
        }
        public data.baseDS.investorDataTable GetInvestor_ByAccount(string account)
        {
            data.baseDS.investorDataTable tbl = new data.baseDS.investorDataTable();
            DbAccess.LoadInvestorByAccount(tbl, account);
            return tbl;
        }

        public data.tmpDS.stockCodeDataTable GetStockByStatus(AppTypes.CommonStatus status)
        {
            data.tmpDS.stockCodeDataTable tbl = new data.tmpDS.stockCodeDataTable();
            DbAccess.LoadData(tbl, status);
            return tbl;
        }
        public data.baseDS.stockCodeDataTable GetStockFull()
        {
            data.baseDS.stockCodeDataTable tbl = new data.baseDS.stockCodeDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }
        public data.baseDS.stockExchangeDataTable GetStockExchange()
        {
            data.baseDS.stockExchangeDataTable tbl = new data.baseDS.stockExchangeDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }

        public data.baseDS.employeeRangeDataTable GetEmployeeRange()
        {
            data.baseDS.employeeRangeDataTable tbl = new data.baseDS.employeeRangeDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }

        public data.baseDS.bizIndustryDataTable GetBizIndustry()
        {
            data.baseDS.bizIndustryDataTable tbl = new data.baseDS.bizIndustryDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }
        public data.baseDS.bizSuperSectorDataTable GetBizSuperSector()
        {
            data.baseDS.bizSuperSectorDataTable tbl = new data.baseDS.bizSuperSectorDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }
        public data.baseDS.bizSectorDataTable GetBizSector()
        {
            data.baseDS.bizSectorDataTable tbl = new data.baseDS.bizSectorDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }

        public data.baseDS.bizSubSectorDataTable GetBizSubSector()
        {
            data.baseDS.bizSubSectorDataTable tbl = new data.baseDS.bizSubSectorDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }
        public data.baseDS.bizSubSectorDataTable GetBizSubSectorByIndustry(string industryCode)
        {
            data.baseDS.bizSubSectorDataTable tbl = new data.baseDS.bizSubSectorDataTable();
            DbAccess.LoadDataByIndustryCode(tbl, industryCode);
            return tbl;
        }
        public data.baseDS.bizSubSectorDataTable GetBizSubSectorBySuperSector(string superSectorCode)
        {
            data.baseDS.bizSubSectorDataTable tbl = new data.baseDS.bizSubSectorDataTable();
            DbAccess.LoadDataBySuperSectorCode(tbl, superSectorCode);
            return tbl;
        }
        public data.baseDS.bizSubSectorDataTable GetBizSubSectorBySector(string sectorCode)
        {
            data.baseDS.bizSubSectorDataTable tbl = new data.baseDS.bizSubSectorDataTable();
            DbAccess.LoadDataBySectorCode(tbl, sectorCode);
            return tbl;
        }

        public data.baseDS.countryDataTable GetCountry()
        {
            data.baseDS.countryDataTable tbl = new data.baseDS.countryDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }
        public data.baseDS.currencyDataTable GetCurrency()
        {
            data.baseDS.currencyDataTable tbl = new data.baseDS.currencyDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }

        public data.baseDS.investorCatDataTable GetInvestorCat()
        {
            data.baseDS.investorCatDataTable tbl = new data.baseDS.investorCatDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }

        public data.baseDS.sysCodeDataTable GetSysCode(string catCode)
        {
            data.baseDS.sysCodeDataTable tbl = new data.baseDS.sysCodeDataTable();
            DbAccess.LoadData(tbl,catCode);
            return tbl;
        }
        public data.baseDS.sysCodeCatDataTable GetSysCodeCat()
        {
            data.baseDS.sysCodeCatDataTable tbl = new data.baseDS.sysCodeCatDataTable();
            DbAccess.LoadData(tbl);
            return tbl;
        }

        public data.baseDS.investorStockDataTable GetOwnedStock(string portfolioCode)
        {
            data.baseDS.investorStockDataTable tbl = new data.baseDS.investorStockDataTable();
            DbAccess.LoadData(tbl, portfolioCode);
            return tbl;
        }

        private static string[] MakeStockCodeList(data.tmpDS.stockCodeDataTable stockCodeTbl)
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
            data.tmpDS.stockCodeDataTable stockCodeTbl = new data.tmpDS.stockCodeDataTable();
            DbAccess.LoadStockCode_ByWatchList(stockCodeTbl,common.system.List2Collection(watchList));
            return MakeStockCodeList(stockCodeTbl);
        }
        public string[] GetStockList_ByBizSector(string[] sectors)
        {
            data.tmpDS.stockCodeDataTable stockCodeTbl = new data.tmpDS.stockCodeDataTable();
            DbAccess.LoadStockCode_ByBizSectors(stockCodeTbl, common.system.List2Collection(sectors));
            return MakeStockCodeList(stockCodeTbl);
        }

        public data.tmpDS.stockCodeDataTable GetStock_InPortfolio(string[] portfolios)
        {
            data.tmpDS.stockCodeDataTable retTbl = new data.tmpDS.stockCodeDataTable();
            DbAccess.LoadStockCode_ByPortfolios(retTbl,common.system.List2Collection(portfolios));
            return retTbl;
        }
        public data.tmpDS.stockCodeDataTable GetStock_ByBizSector(string[] bizSectors)
        {
            data.tmpDS.stockCodeDataTable retTbl = new data.tmpDS.stockCodeDataTable();
            DbAccess.LoadStockCode_ByBizSectors(retTbl, common.system.List2Collection(bizSectors));
            return retTbl;
        }

        public data.baseDS.bizSubSectorDataTable GetBizSubSector_ByIndustry(string codes)
        {
            data.baseDS.bizSubSectorDataTable tbl = new data.baseDS.bizSubSectorDataTable();
            DbAccess.LoadDataByIndustryCode(tbl, codes);
            return tbl;
        }
        public data.baseDS.bizSubSectorDataTable GetBizSubSector_BySuperSector(string codes)
        {
            data.baseDS.bizSubSectorDataTable tbl = new data.baseDS.bizSubSectorDataTable();
            DbAccess.LoadDataBySuperSectorCode(tbl, codes);
            return tbl;
        }
        public data.baseDS.bizSubSectorDataTable GetBizSubSector_BySector(string codes)
        {
            data.baseDS.bizSubSectorDataTable tbl = new data.baseDS.bizSubSectorDataTable();
            DbAccess.LoadDataBySectorCode(tbl, codes);
            return tbl;
        }

        public data.baseDS.portfolioDataTable GetPortfolio_ByInvestorAndType(string investorCode, AppTypes.PortfolioTypes type)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            DbAccess.LoadPortfolioByInvestor(tbl, investorCode, type);
            return tbl;
        }
        public data.baseDS.portfolioDataTable GetPortfolio_ByType(AppTypes.PortfolioTypes type)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            DbAccess.LoadData(tbl, type);
            return tbl;
        }
        public data.baseDS.portfolioDataTable GetPortfolio_ByCode(string code)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            DbAccess.LoadData(tbl, code);
            return tbl;
        }
        public data.baseDS.portfolioDataTable GetPortfolio_ByInvestor(string investorCode)
        {
            data.baseDS.portfolioDataTable tbl = new data.baseDS.portfolioDataTable();
            DbAccess.LoadPortfolioByInvestor(tbl, investorCode);
            return tbl;
        }

        public data.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByType(AppTypes.PortfolioTypes[] types)
        {
            return DbAccess.GetPortfolioDetail_ByType(types);
        }
        public data.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByCode(string portfolioCode)
        {
            data.baseDS.portfolioDetailDataTable tbl = new data.baseDS.portfolioDetailDataTable();
            DbAccess.LoadData(tbl, portfolioCode);
            return tbl;
        }

        public data.baseDS.tradeAlertDataTable GetTradeAlert_BySQL(string sql)
        {
            data.baseDS.tradeAlertDataTable tbl = new data.baseDS.tradeAlertDataTable();
            DbAccess.LoadFromSQL(tbl, sql);
            return tbl;
        }
        public data.baseDS.transactionsDataTable GetTransaction_BySQL(string sql)
        {
            data.baseDS.transactionsDataTable tbl = new data.baseDS.transactionsDataTable();
            DbAccess.LoadFromSQL(tbl, sql);
            return tbl;
        }

        public data.baseDS.lastPriceDataDataTable GetLastPrice(AppTypes.PriceDataType type)
        {
            string cacheName = "lastPrice-" + type.ToString();
            data.baseDS.lastPriceDataDataTable dataTbl = null;
            object obj = sysDataCache.Find(cacheName);
            if (obj == null)
            {
                dataTbl = DbAccess.GetLastPrice(type);
                sysDataCache.Add(cacheName, new DataCacheItem(dataTbl));
                return dataTbl;
            }
            if ((obj as DataCacheItem).timeStamp + TimeSpan.FromSeconds(commonClass.Settings.sysDataDelayTimeInSecs).Ticks > DateTime.Now.Ticks)
            {
                return (data.baseDS.lastPriceDataDataTable)(obj as DataCacheItem).data;
            }
            dataTbl = DbAccess.GetLastPrice(type);
            sysDataCache.Add(cacheName, new DataCacheItem(dataTbl));
            return dataTbl;
        }

        public bool GetTransactionInfo(ref TransactionInfo transInfo)
        {
            data.baseDS.priceDataRow priceRow = DbAccess.GetLastPriceData(transInfo.stockCode);
            data.baseDS.portfolioRow portfolioRow = DbAccess.GetPortfolio(transInfo.portfolio);
            data.baseDS.stockExchangeRow marketRow = application.AppLibs.GetStockExchange(transInfo.stockCode);
            if (priceRow == null || portfolioRow == null || marketRow==null) return false;
            transInfo.price = priceRow.closePrice;
            transInfo.priceDate = priceRow.onDate;
            transInfo.availableCash = portfolioRow.startCapAmt - portfolioRow.usedCapAmt;
            transInfo.transFeePerc = marketRow.tranFeePerc;
            transInfo.priceRatio = marketRow.priceRatio;
            return true;
        }

        public data.baseDS.priceDataDataTable GetData_ByTimeScale_Code_FrDate(string timeScaleCode,string stockCode,DateTime fromDate)
        {
            data.baseDS.priceDataDataTable tbl = new data.baseDS.priceDataDataTable();
            DbAccess.LoadData(tbl, timeScaleCode, fromDate, stockCode);
            return tbl;
        }
        public data.baseDS.priceDataDataTable GetData_ByTimeScale_Code_DateRange(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            data.baseDS.priceDataDataTable tbl = new data.baseDS.priceDataDataTable();
            DbAccess.LoadData(tbl, timeScaleCode, frDate, toDate, stockCode);
            return tbl;
        }
        public data.tmpDS.marketDataDataTable GetMarketData_BySQL(string sqlCmd)
        {
            data.tmpDS.marketDataDataTable tbl = new data.tmpDS.marketDataDataTable();
            DbAccess.LoadFromSQL(tbl, sqlCmd);
            return tbl;
        }
        public int GetData_TotalRow(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate)
        {
            return DbAccess.GetTotalPriceRow(AppTypes.TimeScaleFromCode(timeScaleCode), frDate, toDate, stockCode);
        }

        public DateTime GetLastAlertTime(string investorCode)
        {
            return DbAccess.GetLastAlertTime(investorCode);
        }

        #endregion

        #region Update
        public void UpdateSysCodeCat(ref data.baseDS.sysCodeCatDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }
        public void UpdateSysCode(ref data.baseDS.sysCodeDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }

        public void UpdateStock(ref data.baseDS.stockCodeDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }
        public void UpdateInvestor(ref data.baseDS.investorDataTable tbl)
        {
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].code.Trim() == Consts.constNotMarkerNEW)
                {
                    common.myAutoKeyInfo info = application.SysLibs.GetAutoKey(tbl.TableName, false);
                    tbl[idx].code = info.value.ToString().PadLeft(tbl.codeColumn.MaxLength, '0');
                }
            }
            DbAccess.UpdateData(tbl);
        }
        public void UpdatePortfolio(ref data.baseDS.portfolioDataTable tbl)
        {
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].code.Trim() == Consts.constNotMarkerNEW)
                {
                    common.myAutoKeyInfo info = application.SysLibs.GetAutoKey(tbl.TableName, false);
                    tbl[idx].code = info.value.ToString().PadLeft(tbl.codeColumn.MaxLength, '0');
                }
            }
            DbAccess.UpdateData(tbl);
        }
        public void UpdatePortfolioDetail(ref data.baseDS.portfolioDetailDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }
        public void UpdateStockExchange(ref data.baseDS.stockExchangeDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }
        public void UpdateTransactions(ref data.baseDS.transactionsDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }
        public void UpdateInvestorStock(ref data.baseDS.investorStockDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }
        public void UpdateTradeAlert(ref data.baseDS.tradeAlertDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }

        public void UpdateSysAutoKeyPending(ref data.baseDS.sysAutoKeyPendingDataTable tbl)
        {
            DbAccess.UpdateData(tbl);
        }
        #endregion

        #region Delete
        public void DeleteStockExchange(string code)
        {
            DbAccess.DeleteStockExchange(code);
        }
        public void DeleteStock(string code)
        {
            DbAccess.DeleteStock(code);
        }
        public void DeleteInvestor(string code)
        {
            DbAccess.DeleteInvestor(code);
        }
        public void DeletePortfolio(string code)
        {
            DbAccess.DeletePortfolio(code);
        }
        public void DeleteTradeAlert(int rowId)
        {
            DbAccess.DeleteTradeAlert(rowId);
        }

        public void DeleteSysCodeCat(string code)
        {
            DbAccess.DeleteSysCodeCat(code);
        }
        public void DeleteSysCode(string catCode,string code)
        {
            DbAccess.DeleteSysCode(catCode,code);
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
        public data.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type,string stockCode, string portfolioCode, int qty, decimal feePerc,out string errorText)
        {
            return application.AppLibs.MakeTransaction(type, stockCode, portfolioCode, qty, feePerc,out errorText);
        }
        public TradePointInfo[] GetTradePointWithEstimationDetail(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                                  string stockCode, string strategyCode, EstimateOptions options,
                                                                  out data.tmpDS.tradeEstimateDataTable toTbl)
        {
            string dataKey = LoadAnalysisData(timeRange, timeScaleCode, stockCode, false);
            TradePointInfo[] tradePoints = Analysis(dataKey, strategyCode);
            toTbl = application.Strategy.Libs.EstimateTrading_Details(sysDataCache.Find(dataKey) as AnalysisData, tradePoints, options);
            return tradePoints;
        }


        private XmlDocument GetXmlDocument(string fileName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(common.fileFuncs.ConcatFileName(commonClass.SysLibs.myExecuteDirectory, fileName));
            return xml;
        }
        public string GetXml(string fileName)
        {
            XmlDocument xml = GetXmlDocument(fileName);
            if (xml == null) return null;
            StringWriter writer = new StringWriter();
            xml.Save(writer);
            return writer.ToString();
        }        
        
        public void Load_Global_Settings()
        {
            application.Configuration.Load_Global_Settings();
        }
        public void Save_Global_Settings()
        {
            application.Configuration.Save_Global_Settings();
        }

        #endregion

        #region syslog
        public void WriteSyslog(AppTypes.SyslogTypes logType,string investorCode, string desc, string source, string msg)
        {
            DbAccess.WriteSyslog(logType,investorCode, desc, source, msg);
        }
        #endregion syslog

        #region test

        public object[] GetPriceByCode(string stockCode)
        {
            data.baseDS.priceDataRow priceRow = DbAccess.GetLastPriceData(stockCode);
            if (priceRow == null) return null;
            return priceRow.ItemArray;
        }

        //[OperationBehavior]
        public DataTable Test(string sql)
        {
            DataTable tbl = new DataTable("testTbl");
            //populate table with sql query    
            //DbAccess.LoadFromSQL(tbl, "SELECT *  FROM priceData where onDate<'2006/01/01'");
            //DbAccess.LoadFromSQL(tbl, "SELECT TOP 100000 *  FROM priceData"); 
            DbAccess.LoadFromSQL(tbl, sql); 
            return tbl;
        }

        #endregion
    }
}

        