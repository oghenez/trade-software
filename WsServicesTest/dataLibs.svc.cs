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
using application;

namespace wsServices
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        data.baseDS.stockCodeDataTable GetStock();

        [OperationContract]
        Strategy.Meta test();
    }
    public class DataLibs : IStockService
    {
        //Start-up function. See http://stackoverflow.com/questions/739268/wcf-application-start-event
        //public DataLibs()
        //{
        //    SetConfig();
        //}

        /// <summary>
        /// Customed config for web services
        /// </summary>
        public static void SetConfig()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            common.configuration.withEncryption = true;

            string executeDir = common.fileFuncs.ConcatFileName(common.system.GetWebRootPath(), "bin");
            Strategy.Settings.sysDirectory = executeDir;
            common.settings.sysConfigFile = common.fileFuncs.ConcatFileName(executeDir, "wsStock.xml");
            data.system.dbConnectionString = common.configuration.GetDbConnectionString();

            //string executeDir = "D:\\work\\stockProject\\code\\dlls";
            //data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
        }

        private static common.DictionaryList sysDataCache = new common.DictionaryList();

        public void ClearCache()
        {
            sysDataCache.Clear();
            Strategy.Data.ClearCache();
        }
        public void DeleteCache(string cacheName)
        {
            sysDataCache.Remove(cacheName);
        }

        private application.Data GetCache_Data(string cacheName)
        {
            object obj = sysDataCache.Find(cacheName);
            if (obj == null) return null;
            return (application.Data)obj;
        }
        private application.wsData.EstimateOptions GetCache_EstimateOptions(string cacheName)
        {
            object obj = sysDataCache.Find(cacheName);
            if (obj == null) return null;
            return (application.wsData.EstimateOptions)obj;
        }

        private static string MakeCacheKey(application.AppTypes.TimeRanges timeRange, string timeScaleCode, string code)
        {
            return "data" + "-" + code + "-" + timeRange.ToString() + "-" + timeScaleCode;
        }
        private static string MakeCacheKey()
        {
            return common.system.UniqueString();
        }

        /// <summary>
        /// Get data and store in cache. Depend on forceReadNew, cached data can be used to boost perfomance
        /// </summary>
        /// <param name="timeRange"></param>
        /// <param name="timeScaleCode"></param>
        /// <param name="code"></param>
        /// <param name="forceReadNew"> if true always read from database, ignore the cached data</param>
        /// <returns>Data key used for data accessing</returns>
        public string GetData(application.AppTypes.TimeRanges timeRange, string timeScaleCode, string code,bool forceReadNew)
        {
            string cacheName = MakeCacheKey(timeRange,timeScaleCode,code);
            if (forceReadNew || sysDataCache.Find(cacheName) == null)
            {
                application.Data myData = new application.Data(timeRange, application.AppTypes.TimeScaleFromCode(timeScaleCode), code);
                sysDataCache.Add(cacheName, myData);
            }
            return cacheName;
        }

        public string CreateEstimateOption(application.wsData.EstimateOptions option)
        {
            string cacheName = MakeCacheKey();
            sysDataCache.Add(cacheName, option);
            return cacheName;
        }
        public void DisposeEstimateOption(string key)
        {
            DeleteCache(key);
        }
        

        //[ServiceKnownType(typeof(wsData.TradePointInfo[]))]
        public application.wsData.TradePointInfo[] Analysis(string dataKey, string strategyCode)
        {
            application.wsData.TradePointInfo[] tradePointList = new application.wsData.TradePointInfo[0];
            application.Data data = GetCache_Data(dataKey);
            if (data == null) return tradePointList;
            Strategy.Meta meta = Strategy.Libs.FindMetaByCode(strategyCode);
            if (meta == null) return tradePointList;
            return Strategy.Libs.ToTradePointInfo(Strategy.Libs.Analysis(data, meta));
        }

        public List<decimal[]> Estimate_Matrix_Profit(application.AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                      string[] stockCodeList, string[] strategyList,
                                                      application.wsData.EstimateOptions option)
        {
            return Strategy.Libs.Estimate_Matrix_Profit(timeRange, application.AppTypes.TimeScaleFromCode(timeScaleCode), 
                                                        common.system.List2Collection(stockCodeList),
                                                        common.system.List2Collection(strategyList), option);
        }
        public List<double[]> Estimate_Matrix_LastBizWeight(application.AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                            string[] stockCodeList, string[] strategyList)
        {
            return Strategy.Libs.Estimate_Matrix_LastBizWeight(timeRange, application.AppTypes.TimeScaleFromCode(timeScaleCode),
                                                        common.system.List2Collection(stockCodeList),
                                                        common.system.List2Collection(strategyList));
        }


        #region test

        public decimal EstimateProfitTEST(application.AppTypes.TimeRanges timeRange, string timeScaleCode,
                                      string estimateOptionKey, string dataCode, string strategyCode)
        {
            application.wsData.EstimateOptions option = GetCache_EstimateOptions(estimateOptionKey);
            if (option == null) return 0;
            return EstimateProfit(timeRange, timeScaleCode, option, dataCode, strategyCode);
        }

        public decimal EstimateProfit(application.AppTypes.TimeRanges timeRange, string timeScaleCode,
                                       application.wsData.EstimateOptions option, string dataCode, string strategyCode)
        {
            application.Data data = GetCache_Data(GetData(timeRange, timeScaleCode, dataCode, false));
            if (data == null) return 0;
            Strategy.Data.TradePoints tradePoints = Strategy.Libs.Analysis(data, strategyCode);
            return Strategy.Libs.EstimateTrading_Profit(data, Strategy.Libs.ToTradePointInfo(tradePoints), option);
        }


        public data.baseDS.stockCodeDataTable GetStock()
        {
            return GetStock("HOSE");
        }
        private data.baseDS.stockCodeDataTable GetStock(string exchangeCode)
        {
            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
            data.baseDSTableAdapters.stockCodeTA stockCodeTA = new data.baseDSTableAdapters.stockCodeTA();
            return stockCodeTA.GetByStockExchange(exchangeCode, ((byte)application.AppTypes.CommonStatus.Enable).ToString());
        }

        public Strategy.Meta test()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            common.configuration.withEncryption = true;

            string executeDir = "D:\\work\\stockProject\\code\\dlls";
            Strategy.Settings.sysDirectory = executeDir;
            common.settings.sysConfigFile = common.fileFuncs.ConcatFileName(executeDir, "wsStock.xml");
            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
            
            return (Strategy.Meta)Strategy.Data.MetaList.Values[0];
        }
        public List<decimal[]> test2()
        {
            List<decimal[]> list = new List<decimal[]>();
            list.Add(new decimal[] { 1, 2 });
            list.Add(new decimal[] { 3, 4 });
            list.Add(new decimal[] { 5, 6 }); 
            return list;
        }
        #endregion
    }
}
