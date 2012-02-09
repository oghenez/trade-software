using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Drawing;
using System.Reflection;
using commonClass;

namespace application
{
    public class AnalysisData : commonClass.BaseAnalysisData 
    {
        public AnalysisData() : base() { }
        public AnalysisData(string code, DataParams dataParam,AppTypes.DataAccessMode accessMode) :
            base(code,AppTypes.TimeScaleFromCode(dataParam.TimeScale), dataParam.TimeRange, dataParam.MaxDataCount, accessMode) { }

        public DataParams myDataParam
        {
            get
            {
                return new DataParams(this.DataTimeScale.Code, this.DataTimeRange, this.DataMaxCount);
            }
        }
        public AnalysisData New(string stockCode)
        {
            return new AnalysisData(stockCode, this.myDataParam, commonClass.Settings.sysAccessMode);
        }

        public override void LoadData()
        {
            //commonClass.SysLibs.WriteSystemLog("LoadData", this.DataStockCode, this.DataMaxCount.ToString());
            priceDataTbl.Clear();
            switch (this.AccessMode)
            {
                case AppTypes.DataAccessMode.Local:
                     AppLibs.LoadAnalysisData(this);
                     break;
                case AppTypes.DataAccessMode.WebService:
                     DataAccess.Libs.LoadAnalysisData(this);
                     break;
            }
        }

        ///// <summary>
        /// Update data to the most recent from the last update.
        /// </summary>
        /// <returns>Number of updated items</returns>
        public override int UpdateDataFromLastTime()
        {
            int numberOfUpdate = 0;
            switch (this.AccessMode)
            {
                case AppTypes.DataAccessMode.Local:
                    numberOfUpdate = AppLibs.UpdateAnalysisData(this);
                    break;
                case AppTypes.DataAccessMode.WebService:
                    numberOfUpdate = DataAccess.Libs.UpdateAnalysisData(this); 
                    break;
            }
            this.ClearCache();
            return numberOfUpdate;
        }
    }

    /// <summary>
    /// The class provides functions for market indicators
    /// See http://www.onlinetradingconcepts.com/TechnicalAnalysis/MarketThrust.html
    /// </summary>
    public class MarketData
    {
        private enum DataTypes : byte { Advancing, Declining, NonChange };
        private enum DataFields : byte { Count, Volume, DateTime };
        private common.DictionaryList Cache = new common.DictionaryList();
        private DateTime StartDateTime = common.Consts.constNullDate, EndDateTime = common.Consts.constNullDate;
        private commonClass.AppTypes.TimeScale TimeScale = commonClass.AppTypes.MainDataTimeScale;
        private string StockCodeList = null;

        private static data.tmpDS.marketDataDataTable GetMarketData(DateTime frDate, DateTime toDate, commonClass.AppTypes.TimeScale timeScale, string stockCodeList,DataTypes type)
        {
            string sqlCond = "";
            if (timeScale != commonClass.AppTypes.MainDataTimeScale)
            {
                sqlCond += (sqlCond == "" ? "" : " AND ") + " type='" + timeScale.Code + "'";
            }
            sqlCond += (sqlCond == "" ? "" : " AND ") +
                        "onDate BETWEEN '" + common.system.ConvertToSQLDateString(frDate) + "'" +
                        " AND '" + common.system.ConvertToSQLDateString(toDate) + "'";

            sqlCond += (sqlCond == "" ? "" : " AND ");
            switch (type)
            {
                case DataTypes.Advancing: sqlCond += "closePrice>openPrice"; break;
                case DataTypes.Declining: sqlCond += "closePrice<openPrice"; break;
                default: sqlCond += "closePrice=openPrice"; break;
            }

            if (stockCodeList != null && stockCodeList != "")
            {
                sqlCond += (sqlCond == "" ? "" : " AND ") + " stockCode IN  (" + stockCodeList + ")";
            }
            else
            {
                sqlCond += (sqlCond == "" ? "" : " AND ") + 
                    " stockCode IN  (SELECT code FROM stockCode WHERE status & " + ((byte)commonClass.AppTypes.CommonStatus.Enable).ToString() + ">0)";
            }
            string sqlCmd =
                "SELECT onDate,COUNT(*) AS val0,SUM(volume) AS val1" +
                " FROM " + (timeScale == commonClass.AppTypes.MainDataTimeScale ? "priceData" : "priceDataSum") +
                " WHERE " + sqlCond +
                " GROUP BY onDate ORDER BY onDate";
            data.tmpDS.marketDataDataTable tbl = new data.tmpDS.marketDataDataTable();
            DbAccess.LoadFromSQL(tbl, sqlCmd);
            return tbl;
        }
        private static commonClass.DataSeries MakeData(data.tmpDS.marketDataDataTable dataTbl, DataFields type)
        {
            commonClass.DataSeries ds = new commonClass.DataSeries();
            switch (type)
            {
                case DataFields.Count:
                    for (int idx = 0; idx < dataTbl.Count; idx++) ds.Add(dataTbl[idx].val0); break;
                case DataFields.Volume:
                    for (int idx = 0; idx < dataTbl.Count; idx++) ds.Add(dataTbl[idx].val1); break;
                case DataFields.DateTime:
                    for (int idx = 0; idx < dataTbl.Count; idx++) ds.Add(dataTbl[idx].onDate.ToOADate()); break;
            }
            return ds;
        }
        private void Init(DateTime startDateTime, DateTime endDateTime, commonClass.AppTypes.TimeScale timeScale, StringCollection stockCodes)
        {
            this.Cache.Clear();
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            if (stockCodes != null && stockCodes.Count != 0)
                this.StockCodeList = common.system.MakeConditionStr(stockCodes, "'", "'", ",");
            else this.StockCodeList = null;
            this.TimeScale = timeScale;
        }

        //Constructors
        private MarketData(DateTime startDateTime, DateTime endDateTime, commonClass.AppTypes.TimeScale timeScale, StringCollection stockCodes)
        {
            this.Init(startDateTime, endDateTime, timeScale, stockCodes);
        }
        private MarketData(DateTime startDateTime, DateTime endDateTime, commonClass.AppTypes.TimeScale timeScale)
        {
            this.Init(startDateTime, endDateTime, timeScale, null);
        }

        /// <summary>
        /// Constructors to create a market indicator's data for all enable stock
        /// </summary>
        /// <param name="timeRange"></param>
        /// <param name="timeScale"></param>
        public MarketData(commonClass.AppTypes.TimeRanges timeRange, commonClass.AppTypes.TimeScale timeScale)
        {
            DateTime startDate = DateTime.Today, endDate = DateTime.Today;
            commonClass.AppTypes.GetDate(timeRange, out startDate, out endDate);
            this.Init(startDate, endDate, timeScale, null);
        }

        /// <summary>
        /// Constructors to create a market indicator's data for specific stock list
        /// </summary>
        /// <param name="timeRange"></param>
        /// <param name="timeScale"></param>
        /// <param name="stockCodes"></param>
        public MarketData(commonClass.AppTypes.TimeRanges timeRange, commonClass.AppTypes.TimeScale timeScale, StringCollection stockCodes)
        {
            DateTime startDate = DateTime.Today, endDate = DateTime.Today;
            commonClass.AppTypes.GetDate(timeRange, out startDate, out endDate);
            this.Init(startDate, endDate, timeScale, stockCodes);
        }
        public MarketData(commonClass.BaseAnalysisData data, StringCollection stockCodes)
        {
            DateTime startDate = DateTime.Today, endDate = DateTime.Today;
            commonClass.AppTypes.GetDate(data.DataTimeRange, out startDate, out endDate);
            this.Init(startDate,endDate,data.DataTimeScale, stockCodes);
        }
        public MarketData(commonClass.BaseAnalysisData data)
        {
            DateTime startDate = DateTime.Today, endDate = DateTime.Today;
            commonClass.AppTypes.GetDate(data.DataTimeRange, out startDate, out endDate);
            this.Init(startDate, endDate, data.DataTimeScale, null);

        }

        public commonClass.DataSeries AdvancingIssues
        {
            get
            {
                object dataObj = Cache.Find("data-advancing");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Advancing);
                    Cache.Add("data-advancing",dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("AdvancingIssues");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.Count);
                Cache.Add("AdvancingIssues", ds);
                return ds;
            }
        }
        public commonClass.DataSeries AdvancingVolume
        {
            get
            {
                object dataObj = Cache.Find("data-advancing");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Advancing);
                    Cache.Add("data-advancing", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("AdvancingVolume");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.Volume);
                Cache.Add("AdvancingVolume", ds);
                return ds;

            }
        }
        public commonClass.DataSeries AdvancingDateTime
        {
            get
            {
                object dataObj = Cache.Find("data-advancing");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Advancing);
                    Cache.Add("data-advancing", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("AdvancingDateTime");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.DateTime);
                Cache.Add("AdvancingDateTime", ds);
                return ds;

            }
        }

        public commonClass.DataSeries DecliningIssues
        {
            get
            {
                object dataObj = Cache.Find("data-declining");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Declining);
                    Cache.Add("data-declining", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("DecliningIssues");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.Count);
                Cache.Add("DecliningIssues", ds);
                return ds;
            }
        }
        public commonClass.DataSeries DecliningVolume
        {
            get
            {
                data.tmpDS.marketDataDataTable dataTbl = null;
                object dataObj = Cache.Find("data-declining");
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Declining);
                    Cache.Add("data-declining", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("DecliningVolume");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.Volume);
                Cache.Add("DecliningVolume", ds);
                return ds;
            }
        }
        public commonClass.DataSeries DecliningDateTime
        {
            get
            {
                data.tmpDS.marketDataDataTable dataTbl = null;
                object dataObj = Cache.Find("data-declining");
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Declining);
                    Cache.Add("data-declining", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("DecliningDateTime");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.DateTime);
                Cache.Add("DecliningDateTime", ds);
                return ds;
            }
        }

        public commonClass.DataSeries NonChangeIssues
        {
            get
            {
                object dataObj = Cache.Find("data-NonChange");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.NonChange);
                    Cache.Add("data-NonChange", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;


                object obj = Cache.Find("NonChangeIssues");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.Count);
                Cache.Add("NonChangeIssues", ds);
                return ds;
            }
        }
        public commonClass.DataSeries NonChangeVolume
        {
            get
            {
                object dataObj = Cache.Find("data-NonChange");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.NonChange);
                    Cache.Add("data-NonChange", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("NonChangeVolume");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.Volume);
                Cache.Add("NonChangeVolume", ds);
                return ds;
            }
        }
        public commonClass.DataSeries NonChangeDateTime
        {
            get
            {
                object dataObj = Cache.Find("data-NonChange");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = GetMarketData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.NonChange);
                    Cache.Add("data-NonChange", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("NonChangeDateTime");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries ds = MakeData(dataTbl, DataFields.DateTime);
                Cache.Add("NonChangeDateTime", ds);
                return ds;
            }
        }

        /// <summary>
        /// Sample code for Market class
        /// </summary>
        private class Samples
        {
            //Create from analysis data for all enable stocks
            //private MarketData Create1()
            //{
            //    commonClass.BaseAnalysisData stockData = new commonClass.BaseAnalysisData(commonClass.AppTypes.TimeRanges.Y1, 
            //                                                                       commonClass.AppTypes.TimeScaleFromCode("D1"), "SSI",
            //                                                                       AppTypes.DataAccessMode.WebService);
            //    return new MarketData(stockData);
            //}

            //Create from analysis data for stocks : ACB, FPT
            //private MarketData Create2()
            //{
            //    StringCollection list = new StringCollection();
            //    list.AddRange(new string[] { "ACB", "FPT" });

            //    commonClass.BaseAnalysisData stockData = new commonClass.BaseAnalysisData(commonClass.AppTypes.TimeRanges.Y1, 
            //                                                                      commonClass.AppTypes.TimeScaleFromCode("D1"), "SSI",
            //                                                                      AppTypes.DataAccessMode.WebService);
            //    return new MarketData(stockData);
            //}

            //Create in specific time range and time scale for stocks : ACB, FPT
            private MarketData Create3()
            {
                StringCollection list = new StringCollection();
                list.AddRange(new string[]{"ACB","FPT"});
                return new MarketData(commonClass.AppTypes.TimeRanges.Y1, commonClass.AppTypes.TimeScaleFromCode("D1"), list);
            }
            
            //Get market indicator series
            private void Access(MarketData data)
            {
                commonClass.DataSeries ds;
                ds = data.AdvancingIssues;
                ds = data.AdvancingVolume;
                ds = data.AdvancingDateTime;

                ds = data.DecliningIssues;
                ds = data.DecliningVolume;

                ds = data.NonChangeIssues;
                ds = data.NonChangeVolume;
            }
        }
    }
}
