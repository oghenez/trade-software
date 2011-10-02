using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace application
{
    public class dataLibs
    {
        public static void ClearDbConnection() { }

        #region system
        private static data.baseDSTableAdapters.sysLogTA syslogTA = new data.baseDSTableAdapters.sysLogTA();
        private static data.baseDSTableAdapters.sysConfigTA sysConfigTA = new data.baseDSTableAdapters.sysConfigTA();
        private static data.baseDSTableAdapters.sysCodeCatTA sysCodeCatTA = new data.baseDSTableAdapters.sysCodeCatTA();
        private static data.baseDSTableAdapters.sysCodeTA sysCodeTA = new data.baseDSTableAdapters.sysCodeTA();
        private static data.baseDSTableAdapters.sysAutoKeyTA sysAutoKeyTA = new data.baseDSTableAdapters.sysAutoKeyTA();
        private static data.baseDSTableAdapters.sysAutoKeyPendingTA sysAutoKeyPendingTA = new data.baseDSTableAdapters.sysAutoKeyPendingTA();

        public static bool CheckSystemLog(string logType, string msg)
        {
            return false; 
            //data.baseDS.sysLogDataTable syslogTbl = syslogTA.GetDataByTypeMsg(logType, "'" + msg + common.Consts.SQL_CMD_ALL_MARKER + "'");
            //return (syslogTbl.Count > 0);
        }
        public static bool WriteSystemLog(string logType, string msg, double amt)
        {
            return false; //??
            //data.baseDS.sysLogDataTable syslogTbl = new data.baseDS.sysLogDataTable();
            //data.baseDS.sysLogRow syslogRow;
            //syslogRow = syslogTbl.NewsysLogRow();
            //syslogRow.workerId = sysLibs.sysLoginUserId;
            //syslogRow.locationId = sysLibs.sysLoginLocationId;
            //syslogRow.type = logType;
            //syslogRow.onDate = DateTime.Now;
            //syslogRow.message = msg;
            //syslogRow.amount = amt;
            //syslogTA.Update(syslogRow);
            //return true;
        }

        /// <summary>
        /// Return NULL if the [key] not found
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            data.baseDS.sysConfigDataTable tbl = sysConfigTA.GetByKey(key);
            if (tbl.Count <= 0) return "";
            return tbl[0].value;
        }
        public static void SaveConfig(string key, string value)
        {
            data.baseDS.sysConfigDataTable sysConfigTbl = sysConfigTA.GetByKey(key);
            data.baseDS.sysConfigRow row;
            if (sysConfigTbl.Count == 0)
            {
                row = sysConfigTbl.NewsysConfigRow();
                row.key = key; row.value = value;
                sysConfigTbl.AddsysConfigRow(row);
            }
            else
            {
                row = sysConfigTbl[0];
                row.value = value;
            }
            sysConfigTA.Update(row);
            row.AcceptChanges();
        }

        public static data.baseDS.sysAutoKeyPendingRow UpdateAutoKeyPending(string key, string value, DateTime timestamp)
        {
            data.baseDS.sysAutoKeyPendingDataTable tbl = sysAutoKeyPendingTA.GetByKeyValue(key, value);
            data.baseDS.sysAutoKeyPendingRow row;
            if (tbl.Count > 0)
            {
                row = tbl[0]; row.timeStamp = timestamp;
            }
            else
            {
                row = tbl.NewsysAutoKeyPendingRow();
                row.key = key; row.value = value; row.timeStamp = timestamp;
                tbl.AddsysAutoKeyPendingRow(row);
            }
            sysAutoKeyPendingTA.Update(row);
            row.AcceptChanges();
            return row;
        }
        public static data.baseDS.sysAutoKeyRow NewAutoKeyValue(string key)
        {
            data.baseDS.sysAutoKeyDataTable sysAutoKeyTbl = sysAutoKeyTA.GetByKey(key);
            data.baseDS.sysAutoKeyRow sysAutoKeyRow;
            if (sysAutoKeyTbl.Count == 0)
            {
                sysAutoKeyRow = sysAutoKeyTbl.NewsysAutoKeyRow();
                sysAutoKeyRow.key = key; sysAutoKeyRow.value = 0;
                sysAutoKeyTbl.AddsysAutoKeyRow(sysAutoKeyRow);
            }
            else sysAutoKeyRow = sysAutoKeyTbl[0];
            sysAutoKeyRow.value = sysAutoKeyRow.value + 1;
            sysAutoKeyTA.Update(sysAutoKeyRow);
            sysAutoKeyRow.AcceptChanges();
            return sysAutoKeyRow;
        }
        #endregion system

        #region import
        private static data.importDSTableAdapters.importPriceTA importPriceTA = new data.importDSTableAdapters.importPriceTA();
        public static void InitData(data.importDS.importPriceRow row)
        {
            row.onDate = common.Consts.constNullDate;
            row.stockExchange = "";
            row.stockCode = "";
            row.closePrice = 0;
            row.volume = 0;
            row.openPrice = 0;
            row.highPrice = 0;
            row.closePrice = 0;
        }
        public static void UpdateData(data.importDS.importPriceDataTable tbl)
        {
            importPriceTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.importDS.importPriceRow row)
        {
            importPriceTA.Update(row);
            row.AcceptChanges();
        }

        #endregion

        #region access objects
        private static data.baseDSTableAdapters.bizIndustryTA bizIndustryTA = new data.baseDSTableAdapters.bizIndustryTA();
        private static data.baseDSTableAdapters.bizSuperSectorTA bizSuperSectorTA = new data.baseDSTableAdapters.bizSuperSectorTA();
        private static data.baseDSTableAdapters.bizSectorTA bizSectorTA = new data.baseDSTableAdapters.bizSectorTA();
        private static data.baseDSTableAdapters.bizSubSectorTA bizSubSectorTA = new data.baseDSTableAdapters.bizSubSectorTA();

        private static data.baseDSTableAdapters.countryTA countryTA = new data.baseDSTableAdapters.countryTA();
        private static data.baseDSTableAdapters.currencyTA currencyTA = new data.baseDSTableAdapters.currencyTA();
        private static data.baseDSTableAdapters.strategyCatTA strategyCatTA = new data.baseDSTableAdapters.strategyCatTA();
        private static data.baseDSTableAdapters.indicatorCatTA indicatorCatTA = new data.baseDSTableAdapters.indicatorCatTA();
        private static data.baseDSTableAdapters.investorCatTA investorCatTA = new data.baseDSTableAdapters.investorCatTA();
        private static data.baseDSTableAdapters.employeeRangeTA employeeRangeTA = new data.baseDSTableAdapters.employeeRangeTA();
        private static data.baseDSTableAdapters.stockExchangeTA stockExchangeTA = new data.baseDSTableAdapters.stockExchangeTA();

        private static data.tmpDSTableAdapters.stockCodeTA shortStockCodeTA = new data.tmpDSTableAdapters.stockCodeTA();

        private static data.baseDSTableAdapters.stockCodeTA stockCodeTA = new data.baseDSTableAdapters.stockCodeTA();
        private static data.baseDSTableAdapters.investorTA investorTA = new data.baseDSTableAdapters.investorTA();
        private static data.baseDSTableAdapters.investorStockTA investorStockTA = new data.baseDSTableAdapters.investorStockTA();
        private static data.baseDSTableAdapters.transactionsTA transactionsTA = new data.baseDSTableAdapters.transactionsTA();

        private static data.baseDSTableAdapters.portfolioTA portfolioTA = new data.baseDSTableAdapters.portfolioTA();
        private static data.baseDSTableAdapters.portfolioDetailTA portfolioDetailTA = new data.baseDSTableAdapters.portfolioDetailTA();

        private static data.baseDSTableAdapters.priceDataTA priceDataTA = new data.baseDSTableAdapters.priceDataTA();
        private static data.baseDSTableAdapters.priceDataSumTA priceDataSumTA = new data.baseDSTableAdapters.priceDataSumTA();
        private static data.baseDSTableAdapters.updateVolumeTA updateVolumeTA = new data.baseDSTableAdapters.updateVolumeTA();

        private static data.baseDSTableAdapters.tradeAlertTA tradeAlertTA = new data.baseDSTableAdapters.tradeAlertTA();
        #endregion access object
        
        #region get/load method 
        public static void LoadFromSQL(DataTable tbl, string sqlCmd)
        {
            SqlDataAdapter dataTA = new SqlDataAdapter(sqlCmd, data.system.dbConnectionString);
            dataTA.Fill(tbl);
        }

        public static void LoadData(data.baseDS.sysAutoKeyDataTable tbl)
        {
            sysAutoKeyTA.ClearBeforeFill = false;
            sysAutoKeyTA.Fill(tbl);
        }

        public static void LoadData(data.baseDS.stockExchangeDataTable tbl)
        {
            stockExchangeTA.ClearBeforeFill = false;
            stockExchangeTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.employeeRangeDataTable tbl)
        {
            employeeRangeTA.ClearBeforeFill = false;
            employeeRangeTA.Fill(tbl);
        }

        public static void LoadData(data.baseDS.bizIndustryDataTable tbl)
        {
            bizIndustryTA.ClearBeforeFill = false;
            bizIndustryTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.bizSuperSectorDataTable tbl)
        {
            bizSuperSectorTA.ClearBeforeFill = false;
            bizSuperSectorTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.bizSectorDataTable tbl)
        {
            bizSectorTA.ClearBeforeFill = false;
            bizSectorTA.Fill(tbl);
        }
        
        public static void LoadData(data.baseDS.bizSubSectorDataTable tbl)
        {
            bizSubSectorTA.ClearBeforeFill = false;
            bizSubSectorTA.Fill(tbl);
        }
        public static void LoadDataByIndustryCode(data.baseDS.bizSubSectorDataTable tbl, string industryCode)
        {
            bizSubSectorTA.ClearBeforeFill = false;
            bizSubSectorTA.FillByIndustryCode(tbl, industryCode);
        }
        public static void LoadDataBySuperSectorCode(data.baseDS.bizSubSectorDataTable tbl, string superSectorCode)
        {
            bizSubSectorTA.ClearBeforeFill = false;
            bizSubSectorTA.FillBySuperSector(tbl, superSectorCode);
        }
        public static void LoadDataBySectorCode(data.baseDS.bizSubSectorDataTable tbl, string sectorCode)
        {
            bizSubSectorTA.ClearBeforeFill = false;
            bizSubSectorTA.FillBySectorCode(tbl, sectorCode);
        }

        public static void LoadData(data.baseDS.strategyCatDataTable tbl)
        {
            strategyCatTA.ClearBeforeFill = false;
            strategyCatTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.indicatorCatDataTable tbl)
        {
            indicatorCatTA.ClearBeforeFill = false;
            indicatorCatTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.countryDataTable tbl)
        {
            countryTA.ClearBeforeFill = false;
            countryTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.currencyDataTable tbl)
        {
            currencyTA.ClearBeforeFill = false;
            currencyTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.investorCatDataTable tbl)
        {
            investorCatTA.ClearBeforeFill = false;
            investorCatTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.sysAutoKeyPendingDataTable tbl,string key)
        {
            sysAutoKeyPendingTA.ClearBeforeFill = false;
            sysAutoKeyPendingTA.FillByKey(tbl, key);
        }

        public static void LoadData(data.baseDS.sysCodeDataTable tbl,string catCode)
        {
            sysCodeTA.ClearBeforeFill = false;
            sysCodeTA.FillByCat(tbl,catCode);
        }
        public static void LoadData(data.baseDS.sysCodeCatDataTable tbl)
        {
            sysCodeCatTA.ClearBeforeFill = false;
            sysCodeCatTA.Fill(tbl);
        }

        public static data.baseDS.stockCodeRow GetStockData(string code)
        {
            data.baseDS.stockCodeDataTable tbl = new data.baseDS.stockCodeDataTable();
            LoadData(tbl, code);
            if (tbl.Count > 0) return tbl[0];
            return null;
        }

        //public static void LoadData(data.baseDS.stockCodeDataTable tbl)
        //{
        //    LoadData(tbl, AppTypes.CommonStatus.Enable);
        //}

        public static void LoadData(data.baseDS.stockCodeDataTable tbl, string code)
        {
            stockCodeTA.ClearBeforeFill = false;
            if (code == null) stockCodeTA.Fill(tbl);
            else stockCodeTA.FillByCode(tbl, code);
        }
        public static void LoadData(data.baseDS.stockCodeDataTable tbl, AppTypes.CommonStatus status)
        {
            stockCodeTA.ClearBeforeFill = false;
            stockCodeTA.FillByStatusMask(tbl, ((byte)status).ToString());
        }
        public static void LoadData(data.baseDS.stockCodeDataTable stockCodeTbl, data.baseDS.portfolioRow row)
        {
            StringCollection list;
            list = common.MultiValueString.String2List(row.interestedSector);
            if (list.Count > 0) dataLibs.LoadStockCode_ByBizSectors(stockCodeTbl, list);

            list = common.MultiValueString.String2List(row.interestedStock);
            if (list.Count > 0)
            {
                data.baseDS.stockCodeDataTable tmpTbl = new data.baseDS.stockCodeDataTable();
                dataLibs.LoadStockCode_ByStockCodes(tmpTbl, list);
                for (int idx = 0; idx < tmpTbl.Count; idx++)
                {
                    dataLibs.FindAndCache(stockCodeTbl, tmpTbl[idx].code);
                }
            }
        }

        public static void LoadData(data.baseDS.investorDataTable tbl, string code)
        {
            investorTA.ClearBeforeFill = false;
            if (code == null) investorTA.Fill(tbl);
            else investorTA.FillByCode(tbl, code);
        }

        public static void LoadData(data.baseDS.investorStockDataTable tbl, string portfolioCode)
        {
            investorStockTA.ClearBeforeFill = false;
            investorStockTA.FillByPortfolio(tbl, portfolioCode);
        }
        public static void LoadData(data.baseDS.investorStockDataTable tbl, string stockCode, string portfolio)
        {
            investorStockTA.ClearBeforeFill = false;
            investorStockTA.FillByPortfolioStock(tbl, portfolio, stockCode);
        }
        public static void LoadData(data.baseDS.investorStockDataTable tbl, string stockCode, string portfolio,DateTime buyDate)
        {
            investorStockTA.ClearBeforeFill = false;
            investorStockTA.FillByPortfolioStockBuyDate(tbl, portfolio, stockCode,buyDate);
        }

        public static void LoadData(data.baseDS.transactionsDataTable tbl,string portfolio,string stockCode)
        {
            transactionsTA.ClearBeforeFill = false;
            transactionsTA.FillByPortfolioStockCode(tbl, portfolio,stockCode);
        }

        //public static void LoadData(data.baseDS.portfolioDataTable tbl, AppTypes.PortfolioTypes type)
        //{
        //    portfolioTA.ClearBeforeFill = false;
        //    portfolioTA.FillByTypeMask(tbl,((byte)type).ToString());
        //}
        //public static void LoadData(data.baseDS.portfolioDataTable tbl, byte typeMask)
        //{
        //    portfolioTA.ClearBeforeFill = false;
        //    portfolioTA.FillByTypeMask(tbl, typeMask.ToString());
        //}
        public static void LoadData(data.baseDS.portfolioDataTable tbl, string code)
        {
            portfolioTA.ClearBeforeFill = false;
            portfolioTA.FillByCode(tbl, code);
        }

        public static void LoadData(data.baseDS.portfolioDetailDataTable tbl, string portfolioCode)
        {
            portfolioDetailTA.ClearBeforeFill = false;
            portfolioDetailTA.FillByPortfolio(tbl, portfolioCode);
        }
        public static void LoadData(data.baseDS.portfolioDetailDataTable tbl, AppTypes.PortfolioTypes type)
        {
            portfolioDetailTA.ClearBeforeFill = false;
            portfolioDetailTA.FillByTypeMask(tbl, ((byte)type).ToString());
        }
        public static void LoadData(data.baseDS.portfolioDetailDataTable tbl, byte typeMask)
        {
            portfolioDetailTA.ClearBeforeFill = false;
            portfolioDetailTA.FillByTypeMask(tbl, typeMask.ToString());
        }


        public static void LoadData(data.baseDS.priceDataDataTable tbl, string stockCode)
        {
            priceDataTA.ClearBeforeFill = false;
            priceDataTA.FillByCode(tbl, stockCode); 
        }
        public static void LoadData(data.baseDS.priceDataDataTable tbl,string timeScale,DateTime frDate,DateTime toDate,string stockCode)
        {
            priceDataTA.ClearBeforeFill = false;
            if (timeScale == AppTypes.MainDataTimeScale.Code)
            {
                if (frDate == DateTime.MinValue && toDate == DateTime.MaxValue)
                     priceDataTA.FillByCode(tbl, stockCode);
                else priceDataTA.FillByDateCode(tbl, frDate, toDate, stockCode);
            }            else
            {
                if (frDate == DateTime.MinValue && toDate == DateTime.MaxValue)
                     priceDataTA.FillByTypeCode(tbl, timeScale, stockCode);
                else priceDataTA.FillByTypeDateCode(tbl, timeScale, frDate, toDate, stockCode);
            }
        }
        public static int GetTotalPriceRow(AppTypes.TimeScale timeScale, DateTime frDate, DateTime toDate, string stockCode)
        {
            switch (timeScale.Type)
            {
                case AppTypes.TimeScaleTypes.RealTime:
                    return (int)priceDataTA.GetTotalRow(frDate, toDate, stockCode);
                default:
                    return (int)priceDataTA.GetTotalSumRow(timeScale.Code, frDate, toDate, stockCode);
            }
        }

        public static void LoadDataOneRow(data.baseDS.priceDataDataTable tbl,DateTime frDate, DateTime toDate, string stockCode)
        {
            priceDataTA.ClearBeforeFill = false;
            priceDataTA.FillOneByDateStockCode(tbl, frDate, toDate, stockCode);
        }
        
        public static void LoadData(data.baseDS.tradeAlertDataTable tbl, string portfolio, DateTime frDate, DateTime toDate,byte statusMask)
        {
            tradeAlertTA.ClearBeforeFill = false;
            tradeAlertTA.Fill(tbl,portfolio,frDate,toDate,statusMask.ToString());
        }
        public static data.baseDS.tradeAlertRow GetLastAlert(DateTime frDate, DateTime toDate,string portfolio,
                                                             string stockCode,string strategy,string timeScale,byte statusMask)
        {
            data.baseDS.tradeAlertDataTable tbl = tradeAlertTA.GetOne(frDate, toDate, portfolio, stockCode,strategy,timeScale,statusMask.ToString());
            if (tbl == null || tbl.Count == 0) return null;
            return tbl[0];
        }

        public static data.baseDS.tradeAlertRow GetLastAlertByInvestor(DateTime frDate, DateTime toDate, 
                                                                      string stockCode, string investor, string timeScale, byte statusMask)
        {
            data.baseDS.tradeAlertDataTable tbl = tradeAlertTA.GetOneByInvestor(frDate, toDate,stockCode,timeScale,statusMask.ToString(),investor);
            if (tbl == null || tbl.Count == 0) return null;
            return tbl[0];
        }

        public static void LoadPortfolioByInvestor(data.baseDS.portfolioDataTable tbl, string investorCode,AppTypes.PortfolioTypes type)
        {
            portfolioTA.ClearBeforeFill = false;
            portfolioTA.FillByInvestorCodeAndTypeMask(tbl, investorCode,((byte)type).ToString());
        }
        public static void LoadPortfolioByInvestor(data.baseDS.portfolioDataTable tbl, string investorCode)
        {
            portfolioTA.ClearBeforeFill = false;
            portfolioTA.FillByInvestorCode(tbl, investorCode);
        }

        public static void LoadStockByInvestor(data.baseDS.investorStockDataTable tbl, string investorCode)
        {
            investorStockTA.ClearBeforeFill = false;
            investorStockTA.FillByInvestor(tbl, investorCode);
        }

        public static void LoadInvestorByAccount(data.baseDS.investorDataTable tbl, string account)
        {
            investorTA.ClearBeforeFill = false;
            investorTA.FillByAccount(tbl, account);
        }
        public static void LoadInvestor(data.baseDS.investorDataTable tbl, string cond)
        {
            string sqlCmd = "SELECT * FROM investor WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }

        public static void LoadStockCode_ByStockExchange(data.baseDS.stockCodeDataTable tbl, string stockExchange, AppTypes.CommonStatus status)
        {
            stockCodeTA.FillByStockExchange(tbl, stockExchange,((byte)status).ToString()); 
        }
        public static void LoadStockCode_ByBizSectors(data.baseDS.stockCodeDataTable tbl, StringCollection bizSectors)
        {
            data.baseDS.stockCodeDataTable comTbl = new data.baseDS.stockCodeDataTable();
            string cond = common.system.MakeConditionStr(bizSectors,
                                                         comTbl.bizSectorsColumn.ColumnName + " LIKE N'" +
                                                         common.Consts.SQL_CMD_ALL_MARKER + common.settings.sysListSeparatorPrefix,
                                                         common.settings.sysListSeparatorPostfix + common.Consts.SQL_CMD_ALL_MARKER + "'",
                                                         "OR");
            string sqlCmd = "SELECT * FROM stockCode WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }
        public static void LoadStockCode_ByStockCodes(data.baseDS.stockCodeDataTable tbl, StringCollection stockCode)
        {
            string cond = common.system.MakeConditionStr(stockCode,""+tbl.codeColumn.ColumnName + "=N'","'", "OR");
            string sqlCmd = "SELECT * FROM stockCode WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }
        public static void LoadStockCode_ByPortfolios(data.baseDS.stockCodeDataTable tbl, StringCollection portfolios)
        {
            data.baseDS.investorStockDataTable tmpTbl = new data.baseDS.investorStockDataTable();
            string cond = common.system.MakeConditionStr(portfolios, "b." + tmpTbl.portfolioColumn.ColumnName + "=N'", "'", "OR");
            if (cond.Trim() == "") return;

            tmpTbl.Dispose();

            string sqlCmd = "SELECT DISTINCT a.*" +
                            " FROM stockCode a" +
                            " INNER JOIN investorStock b ON a.code = b.stockCode"+
                            " WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }
        public static void LoadStockCode_ByWatchList(data.baseDS.stockCodeDataTable stockCodeTbl, StringCollection portfolios)
        {
            StringCollection list;
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.portfolioRow portfolioRow;
            for (int idx1 = 0; idx1 < portfolios.Count; idx1++)
            {
                portfolioRow = dataLibs.FindAndCache(portfolioTbl, portfolios[idx1]);
                if (portfolioRow == null) continue;
                list = common.MultiValueString.String2List(portfolioRow.interestedSector);
                if (list.Count > 0) dataLibs.LoadStockCode_ByBizSectors(stockCodeTbl, list);
                list = common.MultiValueString.String2List(portfolioRow.interestedStock);
                if (list.Count <= 0) continue;
                data.baseDS.stockCodeDataTable tmpTbl = new data.baseDS.stockCodeDataTable();
                dataLibs.LoadStockCode_ByStockCodes(tmpTbl, list);
                for (int idx2 = 0; idx2 < tmpTbl.Count; idx2++)
                {
                    dataLibs.FindAndCache(stockCodeTbl, tmpTbl[idx2].code);
                }
            }
            portfolioTbl.Dispose();
        }

        public static void LoadData(data.tmpDS.stockCodeDataTable tbl, AppTypes.CommonStatus status)
        {
            shortStockCodeTA.ClearBeforeFill = false;
            shortStockCodeTA.FillByStatusMask(tbl, ((byte)status).ToString());
        }
        public static void LoadStockCode_ByStockExchange(data.tmpDS.stockCodeDataTable tbl, string stockExchange, AppTypes.CommonStatus status)
        {
            shortStockCodeTA.FillByStockExchange(tbl, stockExchange, ((byte)status).ToString());
        }
        public static void LoadStockCode_ByBizSectors(data.tmpDS.stockCodeDataTable tbl, StringCollection bizSectors)
        {
            data.baseDS.stockCodeDataTable comTbl = new data.baseDS.stockCodeDataTable();
            string cond = common.system.MakeConditionStr(bizSectors,
                                                         comTbl.bizSectorsColumn.ColumnName + " LIKE N'" +
                                                         common.Consts.SQL_CMD_ALL_MARKER + common.settings.sysListSeparatorPrefix,
                                                         common.settings.sysListSeparatorPostfix + common.Consts.SQL_CMD_ALL_MARKER + "'",
                                                         "OR");
            string sqlCmd = "SELECT code, stockExchange, tickerCode, name,0 AS price,0 AS priceVariant FROM stockCode WHERE " + cond;
            LoadFromSQL(tbl, sqlCmd);
        }
        public static void LoadStockCode_ByWatchList(data.tmpDS.stockCodeDataTable stockCodeTbl, StringCollection portfolios)
        {
            StringCollection list;
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.portfolioRow portfolioRow;
            for (int idx1 = 0; idx1 < portfolios.Count; idx1++)
            {
                portfolioRow = dataLibs.FindAndCache(portfolioTbl, portfolios[idx1]);
                if (portfolioRow == null) continue;
                list = common.MultiValueString.String2List(portfolioRow.interestedSector);
                if (list.Count > 0) dataLibs.LoadStockCode_ByBizSectors(stockCodeTbl, list);
                list = common.MultiValueString.String2List(portfolioRow.interestedStock);
                if (list.Count <= 0) continue;
                data.baseDS.stockCodeDataTable tmpTbl = new data.baseDS.stockCodeDataTable();
                dataLibs.LoadStockCode_ByStockCodes(tmpTbl, list);
                for (int idx2 = 0; idx2 < tmpTbl.Count; idx2++)
                {
                    dataLibs.FindAndCache(stockCodeTbl, tmpTbl[idx2].code);
                }
            }
            portfolioTbl.Dispose();
        }

        
        #endregion

        //Init
        #region Init
        public static void InitData(data.baseDS.sysCodeRow row)
        {
            row.category = "";
            row.code = "";
            row.description1 = "";
            row.isSystem = false; row.isVisible = true;
        }
       
        public static void InitData(data.baseDS.stockCodeRow row)
        {
            row.code = "";
            row.tickerCode = "";
            row.stockExchange = "";
            row.name = "";
            row.address1 = "";
            row.email = "";
            row.website = "";
            row.phone = "";
            row.fax = "";
            row.country = Settings.sysDefaultCountry;
            row.bizSectors = "";
            
            row.regDate = common.Consts.constNullDate; 
            row.capitalUnit = Settings.sysMainCurrency;
            row.workingCap = 0;
            row.equity = 0;
            row.totalDebt = 0;
            row.totaAssets = 0;
            row.noOutstandingStock =0;
            row.noListedStock = 0;
            row.noTreasuryStock = 0;
            row.noForeignOwnedStock = 0;
            row.bookPrice = 0;
            row.targetPrice = 0;
            row.targetPriceVariant = 0;
            row.sales = 0;
            row.profit = 0;
            row.equity = 0;
            row.totalDebt = 0;
            row.totaAssets = 0;
            row.PB = 0;
            row.EPS = 0;
            row.PE = 0;
            row.ROA = 0;
            row.ROE = 0;
            row.BETA = 0;
            row.status = (byte)AppTypes.CommonStatus.Enable; 
        }
        public static void InitData(data.baseDS.investorRow row)
        {
            row.code = "";
            row.type = 0;
            row.firstName = "";
            row.lastName = "";
            row.displayName = "";
            row.sex = (byte)AppTypes.Sex.Unspecified;
            row.address1 = "";
            row.email = "";
            row.displayName = "";
            row.account = "";
            row.password = "";
            row.expireDate = sysLibs.GetServerDateTime().AddDays(Settings.sysDefaultLoginAccountDayToExpire); 
            row.status = (byte)AppTypes.CommonStatus.Enable;
        }
        public static void InitData(data.baseDS.investorStockRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.buyDate = common.Consts.constNullDate;
            row.qty = 0;
            row.buyAmt = 0;
        }
        public static void InitData(data.baseDS.transactionsRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.onTime = common.Consts.constNullDate;
            row.tranType = (byte)AppTypes.TradeActions.None;
            row.qty = 0; row.amt = 0; row.feeAmt = 0;
            row.status = (byte)AppTypes.CommonStatus.None; 
        }
        public static void InitData(data.baseDS.portfolioRow row)
        {
            row.type = (byte)AppTypes.PortfolioTypes.WatchList;
            row.code = "";
            row.name = "";
            row.description = "";

            row.startCapAmt = 0;
            row.usedCapAmt = 0;

            row.maxBuyAmtPerc = 100;
            row.stockReducePerc = 50;
            row.stockAccumulatePerc = 50;

            row.interestedSector = "";
            row.interestedStock = "";
        }

        public static void InitData(data.baseDS.portfolioDetailRow row)
        {
            row.portfolio = "";
            row.code = "";
            row.subCode = "";
            row.data = "";
        }
        public static void InitData(data.baseDS.stockExchangeRow row)
        {
            row.code = "";
            row.description = "";
            row.country = "";
            row.weight = 0;
        }
        public static void InitData(data.baseDS.priceDataRow row)
        {
            row.stockCode = "";
            row.onDate = common.Consts.constNullDate; 
            row.openPrice = 0;
            row.highPrice = 0;
            row.lowPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
            row.isUpdate = false;
        }
        public static void InitData(data.baseDS.priceDataSumRow row)
        {
            row.type = "";
            row.stockCode = "";
            row.onDate = common.Consts.constNullDate;
            row.openPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
            row.highPrice = decimal.MinValue;
            row.lowPrice = decimal.MaxValue;
            row.openTimeOffset = short.MaxValue;
            row.closeTimeOffset = short.MinValue;
            row.isUpdate = false;
        }
        public static void InitData(data.baseDS.updateVolumeRow row)
        {
            row.stockCode = "";
            row.onDate = common.Consts.constNullDate;
            row.volume = 0;
        }

        public static void InitData(data.baseDS.tradeAlertRow row)
        {
            row.type = "";
            row.portfolio = "";
            row.stockCode = "";
            row.strategy = "";
            row.timeScale = "";
            row.onTime = common.Consts.constNullDate;
            row.status = 0;
            row.tradeAction = (byte)AppTypes.TradeActions.None; 
            row.subject = common.settings.sysNewDataText;
            row.msg = "";
        }

        public static void InitData(data.tmpDS.stockCodeRow row)
        {
            row.qty = 0; row.boughtAmt = 0;
            row.boughtPrice = 0;
            row.price = 0;
            row.priceVariant = 0;
            row.volume = 0;
            row.amt = 0;
            row.profitVariantAmt = 0;
            row.profitVariantPerc = 0;
        }

        #endregion

        //Update
        #region Update
        public static void UpdateData(data.baseDS.priceDataSumDataTable tbl)
        {
            priceDataSumTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.priceDataSumRow row)
        {
            priceDataSumTA.Update(row);
            row.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.priceDataDataTable tbl)
        {
            priceDataTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.priceDataRow row)
        {
            priceDataTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.updateVolumeDataTable tbl)
        {
            updateVolumeTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.updateVolumeRow row)
        {
            updateVolumeTA.Update(row);
            row.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.stockExchangeDataTable tbl)
        {
            stockExchangeTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.stockExchangeRow row)
        {
            stockExchangeTA.Update(row);
            row.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.stockCodeDataTable tbl)
        {
            stockCodeTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.stockCodeRow row)
        {
            stockCodeTA.Update(row);
            row.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.investorRow row)
        {
            investorTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.investorDataTable tbl)
        {
            investorTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.transactionsRow row)
        {
            transactionsTA.Update(row);
            row.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.investorStockRow row)
        {
            investorStockTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.investorStockDataTable tbl)
        {
            investorStockTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.portfolioRow row)
        {
            portfolioTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.portfolioDataTable tbl)
        {
            portfolioTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.portfolioDetailRow row)
        {
            portfolioDetailTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.portfolioDetailDataTable tbl)
        {
            portfolioDetailTA.Update(tbl);
            tbl.AcceptChanges();
        }


        public static void UpdateData(data.baseDS.tradeAlertRow row)
        {
            tradeAlertTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.tradeAlertDataTable tbl)
        {
            tradeAlertTA.Update(tbl);
            tbl.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.sysCodeCatDataTable tbl)
        {
            sysCodeCatTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.sysCodeCatRow row)
        {
            sysCodeCatTA.Update(row);
            row.AcceptChanges();
        }

        public static void UpdateData(data.baseDS.sysCodeDataTable tbl)
        {
            sysCodeTA.Update(tbl);
            tbl.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.sysCodeRow row)
        {
            sysCodeTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.sysAutoKeyPendingRow row)
        {
            sysAutoKeyPendingTA.Update(row);
            row.AcceptChanges();
        }
        #endregion Update

        #region Set data
        private static void SetTradeAlertStatus(data.baseDS.tradeAlertRow row, AppTypes.CommonStatus stat)
        {
            row.status = (byte)stat;
        }
        public static void CancelTradeAlert(data.baseDS.tradeAlertRow row)
        {
            SetTradeAlertStatus(row, AppTypes.CommonStatus.Ignore);
        }
        public static void RenewTradeAlert(data.baseDS.tradeAlertRow row)
        {
            SetTradeAlertStatus(row, AppTypes.CommonStatus.New);
        }
        public static void CloseTradeAlert(data.baseDS.tradeAlertRow row)
        {
            SetTradeAlertStatus(row, AppTypes.CommonStatus.Close);
        }

        #endregion
        #region delete
        public static void DeletePriceSumData()
        {
            priceDataSumTA.DeleteAll();
        }
        public static void DeletePriceSumData(string stockCode)
        {
            priceDataSumTA.DeleteByStockCode(stockCode);
        }

        public static void DeleteLastUpdateVolume(DateTime endDate)
        {
            updateVolumeTA.DeleteToEndDate(endDate);
        }

        public static void DeletePortfolioData(string porfolioCode, string stockCode)
        {
            portfolioDetailTA.DeleteByPortfolioAndCode(porfolioCode, stockCode);
        }

        public static void DeleteSysCode(string category)
        {
            sysCodeTA.DeleteByCategory(category);
        }
        public static void DeleteTradeAlert(int id)
        {
            tradeAlertTA.Delete(id);
        }
        //Remove the used key in pending list
        public static void DeleteAutoKeyPending(string key,string value)
        {
            sysAutoKeyPendingTA.DeleteByKeyValue(key, value);
        }

        #endregion

        //Find and cache
        #region FindAndCache
        public static data.baseDS.strategyCatRow  FindAndCache(data.baseDS.strategyCatDataTable tbl, string catCode)
        {
            data.baseDS.strategyCatRow row = tbl.FindBycode(catCode);
            if (row != null) return row;
            data.baseDSTableAdapters.strategyCatTA dataTA = new data.baseDSTableAdapters.strategyCatTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(tbl);
            row = tbl.FindBycode(catCode);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.indicatorCatRow FindAndCache(data.baseDS.indicatorCatDataTable tbl, string catCode)
        {
            data.baseDS.indicatorCatRow row = tbl.FindBycode(catCode);
            if (row != null) return row;
            data.baseDSTableAdapters.indicatorCatTA dataTA = new data.baseDSTableAdapters.indicatorCatTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(tbl);
            row = tbl.FindBycode(catCode);
            if (row != null) return row;
            return null;
        }

        public static data.baseDS.stockExchangeRow FindAndCache(data.baseDS.stockExchangeDataTable tbl, string code)
        {
            data.baseDS.stockExchangeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockExchangeTA dataTA = new data.baseDSTableAdapters.stockExchangeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(tbl);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static data.tmpDS.stockCodeRow FindAndCache(data.tmpDS.stockCodeDataTable tbl, string code)
        {
            data.tmpDS.stockCodeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.tmpDSTableAdapters.stockCodeTA dataTA = new data.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.stockCodeRow FindAndCache(data.baseDS.stockCodeDataTable tbl, string code)
        {
            data.baseDS.stockCodeRow  row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockCodeTA dataTA = new data.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.investorRow FindAndCache(data.baseDS.investorDataTable tbl, string code)
        {
            data.baseDS.investorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.investorTA dataTA = new data.baseDSTableAdapters.investorTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.portfolioRow FindAndCache(data.baseDS.portfolioDataTable tbl, string code)
        {
            data.baseDS.portfolioRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.portfolioTA dataTA = new data.baseDSTableAdapters.portfolioTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static data.baseDS.bizSubSectorRow FindAndCache(data.baseDS.bizSubSectorDataTable tbl, string code)
        {
            data.baseDS.bizSubSectorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.bizSubSectorTA dataTA = new data.baseDSTableAdapters.bizSubSectorTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static data.baseDS.priceDataSumRow FindAndCache(data.baseDS.priceDataSumDataTable tbl, string stockCode, string timeScale, DateTime onDate)
        {
            data.baseDS.priceDataSumRow row = tbl.FindBytypestockCodeonDate(timeScale, stockCode, onDate);
            if (row != null) return row;
            data.baseDSTableAdapters.priceDataSumTA dataTA = new data.baseDSTableAdapters.priceDataSumTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(tbl,stockCode,timeScale, onDate, onDate);
            row = tbl.FindBytypestockCodeonDate(timeScale, stockCode, onDate);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.investorStockRow FindAndCache(data.baseDS.investorStockDataTable tbl,string portfolio,string stockCode,DateTime buyDate)
        {
            data.baseDS.investorStockRow row = tbl.FindByportfoliobuyDatestockCode(portfolio, buyDate,stockCode);
            if (row != null) return row;
            data.baseDSTableAdapters.investorStockTA dataTA = new data.baseDSTableAdapters.investorStockTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByPortfolioStockBuyDate(tbl,portfolio,stockCode,buyDate);
            row = tbl.FindByportfoliobuyDatestockCode(portfolio, buyDate, stockCode);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.updateVolumeRow FindAndCache(data.baseDS.updateVolumeDataTable tbl,string stockCode, DateTime onDate)
        {
            data.baseDS.updateVolumeRow row = tbl.FindBystockCodeonDate(stockCode,onDate);
            if (row != null) return row;
            data.baseDSTableAdapters.updateVolumeTA dataTA = new data.baseDSTableAdapters.updateVolumeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(tbl, stockCode, onDate);
            row = tbl.FindBystockCodeonDate(stockCode, onDate);
            if (row != null) return row;
            return null;
        }
        #endregion

        #region others

        public static data.baseDS.sysAutoKeyPendingRow CreateAutoPendingKey(string key, string value, DateTime timeStamp)
        {
            data.baseDS.sysAutoKeyPendingDataTable tbl = sysAutoKeyPendingTA.GetByKeyValue(key, value);
            data.baseDS.sysAutoKeyPendingRow row;
            if (tbl.Count == 0)
            {
                row = tbl.NewsysAutoKeyPendingRow();
                row.key = key; row.value = value;
                row.timeStamp = timeStamp;
                tbl.AddsysAutoKeyPendingRow(row);
            }
            else
            {
                row = tbl[0];
                row.timeStamp = timeStamp;
            }
            sysAutoKeyPendingTA.Update(row);
            return row;
        }
        public static data.baseDS.portfolioRow CreateBlankPorpolio(data.baseDS.portfolioDataTable tbl, data.baseDS.investorRow investorRow)
        {
            data.baseDS.portfolioRow row;
            row = tbl.NewportfolioRow();
            InitData(row);
            common.myAutoKeyInfo info = sysLibs.GetAutoKey(tbl.TableName, false);
            row.code = info.value.ToString().PadLeft(tbl.codeColumn.MaxLength, '0');
            row.investorCode = investorRow.code;
            row.name = common.settings.sysNewDataText;
            tbl.AddportfolioRow(row);
            UpdateData(row);
            return row;
        }
        public static data.baseDS.portfolioRow GetPortfolio(string portfolioCode)
        {
            data.baseDS.portfolioDataTable tbl = portfolioTA.GetByCode(portfolioCode);
            if (tbl.Count == 0) return null;
            return tbl[0];
        }

        public static data.baseDS.portfolioDetailDataTable GetPortfolioData(string portfolioCode)
        {
            return portfolioDetailTA.GetByPortfolio(portfolioCode);
        }

        public static void UpdatePortfolioData(string portfolioCode, string code,string subCode,string data)
        {
            data.baseDS.portfolioDetailDataTable tbl = portfolioDetailTA.Get(portfolioCode,code,subCode);
            data.baseDS.portfolioDetailRow row; 
            if(tbl.Rows.Count!=0) row = tbl[0];
            else
            {
                row = tbl.NewportfolioDetailRow();
                InitData(row);
                row.portfolio = portfolioCode;
                row.code = code;
                row.subCode = subCode;
                tbl.AddportfolioDetailRow(row);
            }
            row.data=data;
            portfolioDetailTA.Update(row);
        }
        public static void RemovePortfolioData(string portfolioCode, string code, string subCode)
        {
            portfolioDetailTA.DeleteRow(portfolioCode, code, subCode);
        }


        /// <summary>
        /// Get system portfolio exists, if is not existed, create it
        /// </summary>
        public static data.baseDS.portfolioRow GetSystemPortfolio()
        {
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.portfolioRow row = dataLibs.FindAndCache(portfolioTbl, Consts.constSysPortfolioCode);
            if (row == null)
            {
                row = portfolioTbl.NewportfolioRow();
                dataLibs.InitData(row);
                row.type = (byte)AppTypes.PortfolioTypes.SysPortfolio;
                row.code = Consts.constSysPortfolioCode;
                row.investorCode = sysLibs.sysLoginCode;
                portfolioTbl.AddportfolioRow(row);
                dataLibs.UpdateData(row);
            }
            return row;
        }
        

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

        public static data.baseDS.transactionsRow MakeStockTransaction(AppTypes.TradeActions type,
                                                string stockCode, string portfolio, int qty,decimal feePerc)
        {
            DateTime onTime = sysLibs.GetServerDateTime();
            //Price
            data.baseDS.priceDataRow priceRow = GetLastPrice(onTime.Date, onTime, stockCode);
            if (priceRow == null)
            {
                common.system.ShowMessage("Không thể thực hiện giao dịch : không có dữ liệu giá.");
                return null;
            }
            decimal amt = qty * priceRow.closePrice * Settings.sysStockPriceWeight;
            decimal feeAmt = (decimal)Math.Round(feePerc * amt / 100, Settings.sysPrecisionLocal);

            data.baseDS.portfolioRow portfolioRow = GetPortfolio(portfolio);
            if (portfolioRow == null)
            {
                common.system.ShowMessage("Dữ liệu [portfolio] không hợp lệ.");
                return null;
            }
            switch (type)
            {
                case AppTypes.TradeActions.Buy:
                case AppTypes.TradeActions.Accumulate:
                    portfolioRow.usedCapAmt += amt;
                    portfolioRow.usedCapAmt += feeAmt;
                    break;
                default: //Sell
                    portfolioRow.usedCapAmt -= amt;
                    portfolioRow.usedCapAmt += feeAmt;
                    break;
            }
            if (portfolioRow.startCapAmt - portfolioRow.usedCapAmt < 0)
            {
                portfolioRow.CancelEdit();
                common.system.ShowMessage("Không đủ tiền trong [portfolio].");
                return null;
            }

            //Create records to store data 
            data.baseDS.transactionsDataTable transTbl = new data.baseDS.transactionsDataTable();
            data.baseDS.investorStockDataTable stockTbl = new data.baseDS.investorStockDataTable();
            data.baseDS.transactionsRow transRow;
            data.baseDS.investorStockRow stockRow;

            transRow = transTbl.NewtransactionsRow();
            InitData(transRow);
            transRow.onTime = onTime;
            transRow.tranType = (byte)type;
            transRow.stockCode = stockCode;
            transRow.portfolio = portfolio;
            transRow.qty = qty;
            transRow.amt = amt;
            transRow.feeAmt = feeAmt;
            transRow.status = (byte)AppTypes.CommonStatus.Close; 
            transTbl.AddtransactionsRow(transRow);

            //Update stock
            DateTime onDate = onTime.Date;  
            switch (type)
            { 
                case AppTypes.TradeActions.Buy :
                case AppTypes.TradeActions.Accumulate:
                     stockTbl.Clear();
                     LoadData(stockTbl, stockCode, portfolio,onDate);
                     if (stockTbl.Count == 0)
                     {
                        stockRow = stockTbl.NewinvestorStockRow();
                        InitData(stockRow);
                        stockRow.buyDate = onDate;
                        stockRow.stockCode = stockCode;
                        stockRow.portfolio = portfolio;
                        stockTbl.AddinvestorStockRow(stockRow);
                     }
                     stockRow = stockTbl[0];
                     stockRow.qty += qty; stockRow.buyAmt += amt; 
                     break;
                default : //Sell
                     DateTime applicableDate = onDate.AddDays(-Settings.sysStockSell2BuyInterval);
                     stockTbl.Clear();
                     LoadData(stockTbl, stockCode, portfolio);
                     decimal remainQty = qty;
                     for (int idx = 0; idx < stockTbl.Count; idx++)
                     {
                        if (stockTbl[idx].buyDate > applicableDate) continue;
                        if (stockTbl[idx].qty >= remainQty)
                        {
                            stockTbl[idx].buyAmt = (stockTbl[idx].qty - remainQty) * (stockTbl[idx].qty == 0 ? 0 : stockTbl[idx].buyAmt / stockTbl[idx].qty);
                            stockTbl[idx].qty = (stockTbl[idx].qty - remainQty);
                            remainQty = 0;
                        }
                        else
                        {
                            remainQty -= stockTbl[idx].qty;
                            stockTbl[idx].buyAmt = 0;
                            stockTbl[idx].qty = 0;
                        }
                        if (remainQty == 0) break;
                     }
                     if (remainQty > 0)
                     {
                        common.system.ShowMessage("Không đủ khối lượng trong [portfolio].");
                        return null;
                     }
                     break;
            }
            //Delete empty stock
            for (int idx = 0; idx < stockTbl.Count;idx++)
            {
                if (stockTbl[idx].qty != 0)  continue;
                stockTbl[idx].Delete();
            }
            
            //Update data with transaction support
            TransactionScopeOption tranOption;
            tranOption = (sysLibs.sysUseTransactionInUpdate ? TransactionScopeOption.Required : TransactionScopeOption.Suppress);
            using (TransactionScope scope = new TransactionScope(tranOption))
            {
                UpdateData(portfolioRow);
                UpdateData(stockTbl);
                UpdateData(transRow);
                scope.Complete();
            }
            return transRow;
        }

        /// <summary>
        /// Find the latest price from [endDate] date
        /// Return null if not found 
        /// </summary>
        private static byte constPriceLookupMaxCount = 100;
        public static data.baseDS.priceDataRow GetLastPrice(string stockCode)
        {
            DateTime onDate = GetLastPriceDate(AppTypes.MainDataTimeScale.Code);
            return GetLastPrice(onDate.Date, onDate, stockCode);
        }

        public static System.DateTime GetLastPriceDate(string timeScale)
        {
            if(timeScale==AppTypes.MainDataTimeScale.Code)  
                return (System.DateTime)priceDataTA.GetMaxDate();

            return (System.DateTime)priceDataSumTA.GetMaxDate(timeScale);
        }

        public static data.baseDS.priceDataRow GetLastPrice(DateTime frDate, DateTime toDate, string stockCode)
        {
            return GetLastPrice(frDate, toDate, AppTypes.MainDataTimeScale.Code, stockCode);
        }
        public static data.baseDS.priceDataRow GetLastPrice(DateTime frDate, DateTime toDate, string timeScale, string stockCode)
        {
            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();

            LoadData(priceTbl, timeScale, frDate, toDate, stockCode);
            //Found that range, continue to find the lastest data
            if (priceTbl.Count > 0)
            {
                DateTime maxDate = priceTbl[0].onDate;
                int maxDateIdx = 0;
                for (int idx = 1; idx < priceTbl.Count; idx++)
                {
                    if (priceTbl[idx].onDate <= maxDate) continue;
                    maxDate = priceTbl[idx].onDate;
                    maxDateIdx = idx;
                }
                return priceTbl[maxDateIdx];
            }
            return null;
        }

        public static data.baseDS.priceDataDataTable GetPrice(DateTime onDate, string timeScale)
        {
            if(timeScale==AppTypes.MainDataTimeScale.Code)
                return priceDataTA.GetByDate(onDate);
            return priceDataTA.GetByTypeDate(timeScale,onDate);
        }


        public static data.baseDS.priceDataRow GetLastPrice(DateTime toDate, string stockCode)
        {
            return GetLastPrice(toDate, AppTypes.MainDataTimeScale.Code, stockCode);
        }
        public static data.baseDS.priceDataRow GetLastPrice(DateTime endDate, string timeScale, string stockCode)
        {
            byte count = 0;
            DateTime frDate, toDate;
            toDate = endDate;
            data.baseDS.priceDataRow priceRow;

            //Try to find the range[frDate,toDate] that contains the data
            while (true)
            {
                frDate = toDate.AddDays(-1);
                priceRow = GetLastPrice(frDate, toDate,timeScale, stockCode);
                if (priceRow != null) return priceRow;
                toDate = frDate;
                count++;
                if (count > constPriceLookupMaxCount) break;
            }
            return null;
        }

        public static data.baseDS.priceDataRow GetNextPrice(DateTime frDate,string stockCode)
        {
            return GetNextPrice(frDate, AppTypes.MainDataTimeScale.Code, stockCode);
        }
        public static data.baseDS.priceDataRow GetNextPrice(DateTime frDate, string timeScaleCode, string stockCode)
        {
            int count = 0;
            DateTime toDate = frDate;
            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();
            while (true)
            {
                toDate = frDate.AddDays(1);
                LoadData(priceTbl, timeScaleCode, frDate, toDate, stockCode);
                //Found that range, continue to find the lastest data
                if (priceTbl.Count > 0)
                {
                    DateTime minDate = priceTbl[0].onDate;
                    int minDateIdx = 0;
                    for (int idx = 1; idx < priceTbl.Count; idx++)
                    {
                        if (priceTbl[idx].onDate > minDate) continue;
                        minDate = priceTbl[idx].onDate;
                        minDateIdx = idx;
                    }
                    return priceTbl[minDateIdx];
                }
                frDate = toDate;
                count++;
                if (count > constPriceLookupMaxCount) break;
            }
            return null;
        }

        /// <summary>
        /// Get the QTY that available to sell. 
        /// Stock applicable to sell is the ones that had bought [buySellInterval] days before (or later) the [sellDate] data
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="portfolio"></param>
        /// <param name="buySellInterval"></param>
        /// <param name="sellDate"></param>
        /// <returns></returns>
        public static decimal GetAvailableStock(string stockCode, string portfolio, int buySellInterval, DateTime sellDate)
        {
            decimal qty = 0;
            decimal buyAmt=0;
            GetOwnStock(stockCode, portfolio, buySellInterval, sellDate, out qty, out buyAmt);
            return qty;
        }

        public static bool GetOwnStock(string stockCode, string portfolio, int buySellInterval, DateTime sellDate,
                                      out decimal qty, out decimal buyAmt)
        {
            qty = 0; buyAmt = 0;
            data.baseDS.investorStockDataTable dataTbl = new data.baseDS.investorStockDataTable();
            LoadData(dataTbl, stockCode, portfolio);
            if (dataTbl.Count == 0) return false;
            DateTime applicableDate = sellDate.AddDays(-Settings.sysStockSell2BuyInterval);
            for (int idx = 0; idx < dataTbl.Count; idx++)
            {
                if (dataTbl[idx].buyDate > applicableDate) continue;
                qty += dataTbl[idx].qty;
                buyAmt += dataTbl[idx].buyAmt;
            }
            return true;
        }


        /// <summary>
        /// Copy data from one portfolioDetail data table to another
        /// </summary>
        /// <param name="frDataTbl">Source data</param>
        /// <param name="toDataTbl">Destination data</param>
        /// <param name="porfolioCode">Porfolio code of the data added to destination</param>
        /// <param name="stockCode">Stock code of the data added to destination</param>
        public static void CopyPortfolioData(data.baseDS.portfolioDetailDataTable frDataTbl,
                                             data.baseDS.portfolioDetailDataTable toDataTbl,
                                             string porfolioCode, string stockCode)
        {
            data.baseDS.portfolioDetailRow row;
            for (int idx = 0; idx < frDataTbl.Rows.Count; idx++)
            {
                row = toDataTbl.NewportfolioDetailRow();
                application.dataLibs.InitData(row);
                row.portfolio = porfolioCode;
                row.code = stockCode;
                row.subCode = frDataTbl[idx].subCode; ;
                row.data = frDataTbl[idx].data;
                toDataTbl.AddportfolioDetailRow(row);
            }
        }


        /// <summary>
        /// Get default portfolioDetail data 
        /// </summary>
        /// <returns></returns>
        public static data.baseDS.portfolioDetailDataTable GetDefaultPortfolioData()
        {
            data.baseDS.portfolioRow portfolioRow = application.dataLibs.GetSystemPortfolio();
            return application.dataLibs.GetPortfolioData(portfolioRow.code);
        }

        public static DateTime GetLastAlertTime(string investorCode)
        {
            object obj = tradeAlertTA.GetLastTimeByInvestor(investorCode);
            if (obj == null) return common.Consts.constNullDate;
            return (DateTime)obj;
        }

        #endregion others
    }
}
