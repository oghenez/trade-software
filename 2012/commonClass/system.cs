using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Text;
using System.Xml;
using System.Windows.Forms; 

namespace commonClass
{
    public static class SysLibs
    {
        //The folder from where the application run
        private static string _executeDirectory = null;
        public static string myExecuteDirectory
        {
            get
            {
                //For testing 
                if (common.Consts.isTestMode)
                    return "D:\\work\\stockProject\\code\\wsServices\\obj\\Debug"; 

                if (_executeDirectory == null)
                {
                    string tmp = common.system.GetWebRootPath();
                    //Run on web server
                    if (tmp != null)
                        _executeDirectory = common.fileFuncs.ConcatFileName(tmp, "bin");
                    else _executeDirectory = common.system.GetExecutePath();
                }
                return _executeDirectory;
            }
        }
        
        public static void SetLanguage()
        {
            AppTypes.ReLoadTimeScales();
        }

        public static DateTime GetWorkDayDate(DateTime frDate, int days) { return frDate.AddDays(days); }

        public static void ExitApplication()
        {
            if (common.Settings.sysDebugMode)
            {
                common.system.ShowMessage(Languages.Libs.GetString("exitApplication"));
                return;
            }
            common.system.ExitApplication();
        }

        public static void SetAppEnvironment()
        {
            common.language.myCulture = new CultureInfo(Settings.sysCultureCode);
        }

        public static bool isSupperAdminLogin(string loginName)
        {
            return loginName.Trim().ToLower() == Settings.sysSuperAdminName;
        }
        public static bool isSupperAdminLogin()
        {
            return isSupperAdminLogin(sysLoginCode);
        }
        public static bool isAdminLogin(string loginType)
        {
            return (loginType.Trim() == Consts.constWorkerTypeAdmin);
        }
        public static bool isAdminLogin()
        {
            return isAdminLogin(sysLoginType);
        }
        public static void ClearLogin()
        {
            sysLoginCode = "";
            sysLoginAccount = "";
            sysLoginType = "";
        }

        public static void WriteSystemLog(string type ,string investorCode, string text)
        {
            common.fileFuncs.WriteLog(DateTime.Now.ToString() + common.Consts.constTab + type + common.Consts.constTab +
                                      (investorCode.Trim() == "" ? common.Consts.constNotAvailable : investorCode.Trim()) + 
                                      common.Consts.constTab + text, 
                                      common.fileFuncs.ConcatFileName(myExecuteDirectory, Consts.constFile_SysLog));
        }
        public static void WriteSystemLog(Exception er, string investorCode)
        {
            WriteSystemLog(AppTypes.SyslogTypes.Exception.ToString(),investorCode,
                           common.system.MakeLogString(er, common.Consts.constTab));
        }

        #region system environment
        public static bool sysUseTransactionInUpdate = false;

        public static short sysConnectionTimeout = 30; //In seconds
        
        //Upload
        //??public static DateTime sysDataStartDate = common.Consts.constNullDate;
        public static int sysLoginUserId = common.Consts.constNullInt;
        
        //public static StringCollection sysLoginInterestedBizSectors = null;
        //public static StringCollection sysLoginInterestedStockCode = null;
        //public static StringCollection sysLoginInterestedStrategy = null;

        //Images and logo
        public static string sysImgFilePathIcon = "";
        public static string sysImgFilePathBackGround = "";
        public static string sysImgFilePathCompanyLogo1 = "";
        public static string sysImgFilePathCompanyLogo2 = "";

        //User
        public static string sysLoginCode = "";
        public static string sysLoginAccount = "";
        public static string sysLoginType = "";
        public static string sysCompanyName = "";
        public static string sysCompanyAddr1 = "";
        public static string sysCompanyAddr2 = "";
        public static string sysCompanyAddr3 = "";
        public static string sysCompanyPhone = "";
        public static string sysCompanyFax = "";
        public static string sysCompanyEmail = "";
        public static string sysCompanyURL = "";
        #endregion system environment
    }
    public static class AppLibs
    {
        #region Init data
        public static void InitData(data.baseDS.sysLogRow row)
        {
            row.type = 0;
            row.description = "";
        }
        public static void InitData(data.baseDS.sysCodeRow row)
        {
            row.category = "";
            row.code = "";
            row.description1 = "";
            row.isSystem = false; row.isVisible = true;
        }
        public static void InitData(data.baseDS.sysCodeCatRow row)
        {
            row.category = "";
            row.description = "";
            row.isSystem = false;
            row.isVisible = true;
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
            row.catCode = "";
            row.expireDate = DateTime.Today.AddDays(Settings.sysDefaultLoginAccountDayToExpire);
            row.status = (byte)AppTypes.CommonStatus.Enable;
        }
        public static void InitData(data.baseDS.investorStockRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.buyDate = DateTime.Today;
            row.qty = 0;
            row.buyAmt = 0;
        }
        public static void InitData(data.baseDS.transactionsRow row)
        {
            row.stockCode = "";
            row.portfolio = "";
            row.onTime = DateTime.Today;
            row.tranType = (byte)AppTypes.TradeActions.None;
            row.qty = 0; row.amt = 0; row.feeAmt = 0;
            row.status = (byte)AppTypes.CommonStatus.None;
        }
        public static void InitData(data.baseDS.portfolioRow row)
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
            row.workTime = "";
            row.holidays = "";
            row.minBuySellDay = 0;
            row.tranFeePerc = 0;
            row.priceRatio = 1;
            row.volumeRatio = 1;
            row.weight = 0;
        }
        public static void InitData(data.baseDS.priceDataRow row)
        {
            row.stockCode = "";
            row.onDate = DateTime.Today;
            row.openPrice = 0;
            row.highPrice = 0;
            row.lowPrice = 0;
            row.closePrice = 0;
            row.volume = 0;
        }
        public static void InitData(data.baseDS.priceDataSumRow row)
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

        public static void InitData(data.baseDS.tradeAlertRow row)
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
                AppLibs.InitData(row);
                row.portfolio = porfolioCode;
                row.code = stockCode;
                row.subCode = frDataTbl[idx].subCode; ;
                row.data = frDataTbl[idx].data;
                toDataTbl.AddportfolioDetailRow(row);
            }
        }

        public static data.tmpDS.codeListDataTable GetTimeScales()
        {
            data.tmpDS.codeListDataTable tbl = new data.tmpDS.codeListDataTable();
            data.tmpDS.codeListRow row;
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                row = tbl.NewcodeListRow();
                row.code = AppTypes.myTimeScales[idx].Code;
                row.description = AppTypes.myTimeScales[idx].Text;
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }
        public static data.tmpDS.codeListDataTable GetCommonStatus()
        {
            data.tmpDS.codeListDataTable tbl = new data.tmpDS.codeListDataTable();
            data.tmpDS.codeListRow row;
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
        public static data.tmpDS.codeListDataTable GetTradeActions()
        {
            data.tmpDS.codeListDataTable tbl = new data.tmpDS.codeListDataTable();
            data.tmpDS.codeListRow row;
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
        public static void DataConcat(data.baseDS.priceDataDataTable frTbl, int fromIdx, data.baseDS.priceDataDataTable toTbl)
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
    public static class Configuration
    {
        public static bool GetUserSettings(string type, StringCollection aFields)
        {
            return common.configuration.GetConfiguration(Settings.sysUserConfigFile, SysLibs.sysLoginCode,type, aFields, false);
        }
        public static bool SaveUserSettings(string type, StringCollection aFields, StringCollection aValues)
        {
            if (SysLibs.sysLoginCode.Trim() == "") return false;
            return common.configuration.SaveConfiguration(Settings.sysUserConfigFile, SysLibs.sysLoginCode, type, aFields, aValues, false);
        }

        //private const string constRootXMLElementStr = "Configuration";
        public const string constXMLElement_Root = "Application";
        public const string constXMLElement_Sub_System = "System";
        public const string constXMLElement_Sub_Database = "Database";
        public static bool withEncryption
        {
            get { return common.configuration.withEncryption; }
            set { common.configuration.withEncryption = value; }
        }

        public static string BuidConnectionString(string serverAddr, string dbName, string account, string password)
        {
            string configStr = "";
            configStr = "Data Source=" + serverAddr.Trim() +
                        ";Initial Catalog=" + dbName.Trim() +
                        ";Persist Security Info=True;User ID=" + account.Trim();
            if (password.Trim() != "") configStr += ";password=" + password;
            return configStr;
        }
    }
}
