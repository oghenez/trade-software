using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using commonTypes; 

namespace databases
{
    public static class AppLibs
    {
        #region Init data
        public static void InitData(databases.importDS.importPriceRow row)
        {
            row.onDate = common.Consts.constNullDate;
            row.stockCode = "";
            row.closePrice = 0;
            row.openPrice = 0;
            row.highPrice = 0;
            row.lowPrice = 0;
            row.volume = 0;
            row.isTotalVolume = false;
        }

        public static void InitData(databases.baseDS.sysLogRow row)
        {
            row.type = 0;
            row.description = "";
        }
        public static void InitData(databases.baseDS.sysCodeRow row)
        {
            row.category = "";
            row.code = "";
            row.description1 = "";
            row.isSystem = false; row.isVisible = true;
        }
        public static void InitData(databases.baseDS.sysCodeCatRow row)
        {
            row.category = "";
            row.description = "";
            row.isSystem = false;
            row.isVisible = true;
        }

        public static void InitData(databases.baseDS.stockCodeRow row)
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

            row.regDate = DateTime.Today;
            row.capitalUnit = Settings.sysMainCurrency;
            row.workingCap = 0;
            row.equity = 0;
            row.totalDebt = 0;
            row.totaAssets = 0;
            row.noOutstandingStock = 0;
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
        public static void InitData(databases.baseDS.investorRow row)
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
            row.catCode = "";
            row.expireDate = DateTime.Today.AddDays(Settings.sysDefaultLoginAccountDayToExpire);
            row.status = (byte)AppTypes.CommonStatus.Enable;
        }
        public static void InitData(databases.baseDS.investorStockRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.buyDate = DateTime.Today;
            row.qty = 0;
            row.buyAmt = 0;
        }
        public static void InitData(databases.baseDS.transactionsRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.onTime = DateTime.Today;
            row.tranType = (byte)AppTypes.TradeActions.None;
            row.qty = 0; row.amt = 0; row.feeAmt = 0;
            row.status = (byte)AppTypes.CommonStatus.None;
        }
        public static void InitData(databases.baseDS.portfolioRow row)
        {
            row.type = (byte)AppTypes.PortfolioTypes.WatchList;
            row.code = "";
            row.name = "";
            row.investorCode = "";
            row.description = "";

            row.startCapAmt = 0;
            row.usedCapAmt = 0;

            row.maxBuyAmtPerc = 100;
            row.stockReducePerc = 50;
            row.stockAccumulatePerc = 50;

            row.interestedSector = "";
            row.interestedStock = "";
        }

        public static void InitData(databases.baseDS.portfolioDetailRow row)
        {
            row.portfolio = "";
            row.code = "";
            row.subCode = "";
            row.data = "";
        }
        public static void InitData(databases.baseDS.stockExchangeRow row)
        {
            row.code = "";
            row.description = "";
            row.country = "";
            row.workTime = "";
            row.holidays = "";
            row.minBuySellDay = 0;
            row.tranFeePerc = 0;
            row.priceRatio = 1;
            row.volumeRatio = 1;
            row.weight = 0;
        }
        public static void InitData(databases.baseDS.priceDataRow row)
        {
            row.stockCode = "";
            row.onDate = DateTime.Today;
            row.openPrice = 0;
            row.highPrice = 0;
            row.lowPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
        }
        public static void InitData(databases.baseDS.priceDataSumRow row)
        {
            row.type = "";
            row.stockCode = "";
            row.onDate = DateTime.Today;
            row.openPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
            row.highPrice = decimal.MinValue;
            row.lowPrice = decimal.MaxValue;
            row.openTimeOffset = int.MaxValue;
            row.closeTimeOffset = int.MinValue;
        }

        public static void InitData(databases.baseDS.tradeAlertRow row)
        {
            row.type = "";
            row.portfolio = "";
            row.stockCode = "";
            row.strategy = "";
            row.timeScale = "";
            row.onTime = DateTime.Today;
            row.status = 0;
            row.tradeAction = (byte)AppTypes.TradeActions.None;
            row.subject = common.Settings.sysNewDataText;
            row.msg = "";
        }

        public static void InitData(databases.tmpDS.stockCodeRow row)
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

        #region FindAndCache
        private static databases.baseDS myCachedDS = new databases.baseDS();
        private static databases.tmpDS myCachedTmpDS = new databases.tmpDS();
        public static void ClearCache()
        {
            myCachedDS.Clear();
            myCachedTmpDS.Clear();
        }

        public static databases.baseDS.stockExchangeDataTable myStockExchangeTbl
        {
            get
            {
                if (myCachedDS.stockExchange.Count == 0)
                {
                    DbAccess.LoadData(myCachedDS.stockExchange);
                }
                return myCachedDS.stockExchange;
            }
        }
        public static databases.baseDS.stockExchangeRow FindAndCache_StockExchange(string code)
        {
            databases.baseDS.stockExchangeRow row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.stockExchangeTA dataTA = new databases.baseDSTableAdapters.stockExchangeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.stockExchange);
            row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static databases.baseDS.stockCodeRow FindAndCache_StockCode(string code)
        {
            databases.baseDS.stockCodeRow row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.stockCodeTA dataTA = new databases.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedDS.stockCode, code);
            row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static databases.baseDS.countryRow FindAndCache_Country(string code)
        {
            databases.baseDS.countryRow row = myCachedDS.country.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.countryTA dataTA = new databases.baseDSTableAdapters.countryTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.country);
            row = myCachedDS.country.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static databases.baseDS.portfolioRow FindAndCache(databases.baseDS.portfolioDataTable tbl, string code)
        {
            databases.baseDS.portfolioRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.portfolioTA dataTA = new databases.baseDSTableAdapters.portfolioTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static databases.baseDS.bizSubSectorRow FindAndCache(databases.baseDS.bizSubSectorDataTable tbl, string code)
        {
            databases.baseDS.bizSubSectorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.bizSubSectorTA dataTA = new databases.baseDSTableAdapters.bizSubSectorTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static databases.baseDS.bizSubSectorRow FindAndCache_BizSubSector(string code)
        {
            return FindAndCache(myCachedDS.bizSubSector, code);
        }

        public static databases.tmpDS.stockCodeRow FindAndCache_StockCodeShort(string code)
        {
            databases.tmpDS.stockCodeRow row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            databases.tmpDSTableAdapters.stockCodeTA dataTA = new databases.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedTmpDS.stockCode, code);
            row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static databases.tmpDS.stockCodeRow FindAndCache(databases.tmpDS.stockCodeDataTable tbl, string code)
        {
            databases.tmpDS.stockCodeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.tmpDSTableAdapters.stockCodeTA dataTA = new databases.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }

        public static databases.baseDS.investorRow FindAndCache_Investor(string code)
        {
            return FindAndCache(myCachedDS.investor, code);
        }
        public static databases.baseDS.investorRow FindAndCache(databases.baseDS.investorDataTable tbl, string code)
        {
            databases.baseDS.investorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.investorTA dataTA = new databases.baseDSTableAdapters.investorTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        #endregion

        /// <summary>
        /// Copy data from one portfolioDetail data table to another
        /// </summary>
        /// <param name="frDataTbl">Source data</param>
        /// <param name="toDataTbl">Destination data</param>
        /// <param name="porfolioCode">Porfolio code of the data added to destination</param>
        /// <param name="stockCode">Stock code of the data added to destination</param>
        public static void CopyPortfolioData(databases.baseDS.portfolioDetailDataTable frDataTbl,
                                             databases.baseDS.portfolioDetailDataTable toDataTbl,
                                             string porfolioCode, string stockCode)
        {
            databases.baseDS.portfolioDetailRow row;
            for (int idx = 0; idx < frDataTbl.Rows.Count; idx++)
            {
                row = toDataTbl.NewportfolioDetailRow();
                AppLibs.InitData(row);
                row.portfolio = porfolioCode;
                row.code = stockCode;
                row.subCode = frDataTbl[idx].subCode; ;
                row.data = frDataTbl[idx].data;
                toDataTbl.AddportfolioDetailRow(row);
            }
        }

        public static databases.tmpDS.codeListDataTable GetTimeScales()
        {
            databases.tmpDS.codeListDataTable tbl = new databases.tmpDS.codeListDataTable();
            databases.tmpDS.codeListRow row;
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                row = tbl.NewcodeListRow();
                row.code = AppTypes.myTimeScales[idx].Code;
                row.description = AppTypes.myTimeScales[idx].Text;
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }
        public static databases.tmpDS.codeListDataTable GetCommonStatus()
        {
            databases.tmpDS.codeListDataTable tbl = new databases.tmpDS.codeListDataTable();
            databases.tmpDS.codeListRow row;
            foreach (AppTypes.CommonStatus item in Enum.GetValues(typeof(AppTypes.CommonStatus)))
            {
                row = tbl.NewcodeListRow();
                row.code = ((byte)item).ToString();
                row.byteValue = (byte)item;
                row.description = item.ToString();
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }
        public static databases.tmpDS.codeListDataTable GetTradeActions()
        {
            databases.tmpDS.codeListDataTable tbl = new databases.tmpDS.codeListDataTable();
            databases.tmpDS.codeListRow row;
            foreach (AppTypes.TradeActions item in Enum.GetValues(typeof(AppTypes.TradeActions)))
            {
                row = tbl.NewcodeListRow();
                row.code = ((byte)item).ToString();
                row.description = item.ToString();
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }

        /// <summary>
        /// Concatenate 2 table
        /// </summary>
        /// <param name="frTbl">Source table</param>
        /// <param name="fromId">The index in source where the copy begins</param>
        /// <param name="toTbl">Destination table</param>
        public static void DataConcat(databases.baseDS.priceDataDataTable frTbl, int fromIdx, databases.baseDS.priceDataDataTable toTbl)
        {
            for (int idx = fromIdx; idx < frTbl.Count; idx++)
            {
                toTbl.ImportRow(frTbl[idx]);
            }
        }

        public static bool IsUseVietnamese()
        {
            return (common.language.myCulture.Name == "vi-VN");
        }
    }
}
