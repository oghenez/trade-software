using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.Drawing;
using System.Transactions;
using commonClass;

namespace application
{
    public class test
    {
        public static bool LoadTestConfig()
        {
            data.SysLibs.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

            common.settings.sysProductOwner = commonClass.Consts.constProductOwner;
            common.settings.sysProductCode = commonClass.Consts.constProductCode;
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;

            commonClass.Configuration.withEncryption = true;
            Configuration.Load_User_Envir();
            commonClass.SysLibs.SetAppEnvironment();

            commonClass.SysLibs.sysLoginCode = "A00000004";
            return true;
        }
    }
    public class ErrorHandler
    {
        private static string _lastErrorMsg = "";
        public static string lastErrorMessage
        {
            get
            {
                string tmp = _lastErrorMsg; _lastErrorMsg = ""; return tmp;
            }
            set { _lastErrorMsg = value; }
        }
    }
    public class AppLibs
    {
        //Number of units to read ahead
        private const int constNumberOfReadAheadUnit = 100;
        public static data.tmpDS.codeListDataTable GetTimeScales()
        {
            data.tmpDS.codeListDataTable tbl = new data.tmpDS.codeListDataTable();
            data.tmpDS.codeListRow row;
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                row = tbl.NewcodeListRow();
                row.code = AppTypes.myTimeScales[idx].Code;
                row.description = AppTypes.myTimeScales[idx].Description;
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
                row.description = AppTypes.Type2Text(item);
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
                row.byteValue = (byte)item;
                row.description = AppTypes.Type2Text(item);
                tbl.AddcodeListRow(row);
            }
            return tbl;
        }

        public static DateTime GetWorkDayDate(DateTime frDate, int days) { return frDate.AddDays(days); }

        public static data.baseDS.stockExchangeRow GetStockExchange(string stockCode)
        {
            data.baseDS.stockCodeRow stockRow = SysLibs.FindAndCache_StockCode(stockCode);
            if (stockRow == null) return null;
            data.baseDS.stockExchangeRow stockExchangeRow = SysLibs.FindAndCache_StockExchange(stockRow.stockExchange);
            return stockExchangeRow;
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
        public static data.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type, string stockCode, string portfolioCode, int qty, decimal feePerc,out string errorText)
        {
            errorText="";
            data.baseDS.stockExchangeRow marketRow = GetStockExchange(stockCode);
            if (marketRow == null) return null;

            errorText="";
            DateTime onTime = DateTime.Now;
            //Price
            data.baseDS.priceDataRow priceRow = DbAccess.GetLastPriceData(stockCode);
            if (priceRow == null)
            {
                errorText = Languages.Libs.GetString("cannotDoTransaction");
                return null;
            }
            decimal amt = qty * priceRow.closePrice * marketRow.priceRatio;
            decimal feeAmt = (decimal)Math.Round(feePerc * amt / 100, Settings.sysPrecisionLocal);

            data.baseDS.portfolioRow portfolioRow = DbAccess.GetPortfolio(portfolioCode);
            if (portfolioRow == null)
            {
                errorText = String.Format(Languages.Libs.GetString("dataNotFound"), "[portfolio]");
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
                errorText = String.Format(Languages.Libs.GetString("outOfMoney"), portfolioRow.startCapAmt - portfolioRow.usedCapAmt - amt - feeAmt);
                return null;
            }

            //Create records to store data 
            data.baseDS.transactionsDataTable transTbl = new data.baseDS.transactionsDataTable();
            data.baseDS.investorStockDataTable investorStockTbl = new data.baseDS.investorStockDataTable();
            data.baseDS.transactionsRow transRow;
            data.baseDS.investorStockRow stockRow;

            transRow = transTbl.NewtransactionsRow();
            commonClass.AppLibs.InitData(transRow);
            transRow.onTime = onTime;
            transRow.tranType = (byte)type;
            transRow.stockCode = stockCode;
            transRow.portfolio = portfolioCode;
            transRow.qty = qty;
            transRow.amt = amt;
            transRow.feeAmt = feeAmt;
            transRow.status = (byte)AppTypes.CommonStatus.Close;
            transTbl.AddtransactionsRow(transRow);

            //Update stock
            DateTime onDate = onTime.Date;
            switch (type)
            {
                case AppTypes.TradeActions.Buy:
                case AppTypes.TradeActions.Accumulate:
                    investorStockTbl.Clear();
                    DbAccess.LoadData(investorStockTbl, stockCode, portfolioCode, onDate);
                    if (investorStockTbl.Count == 0)
                    {
                        stockRow = investorStockTbl.NewinvestorStockRow();
                        commonClass.AppLibs.InitData(stockRow);
                        stockRow.buyDate = onDate;
                        stockRow.stockCode = stockCode;
                        stockRow.portfolio = portfolioCode;
                        investorStockTbl.AddinvestorStockRow(stockRow);
                    }
                    stockRow = investorStockTbl[0];
                    stockRow.qty += qty; stockRow.buyAmt += amt;
                    break;
                default: //Sell
                    DateTime applicableDate = onDate.AddDays(-marketRow.minBuySellDay);
                    investorStockTbl.Clear();
                    DbAccess.LoadData(investorStockTbl, stockCode, portfolioCode);
                    decimal remainQty = qty;
                    for (int idx = 0; idx < investorStockTbl.Count; idx++)
                    {
                        if (investorStockTbl[idx].buyDate > applicableDate) continue;
                        if (investorStockTbl[idx].qty >= remainQty)
                        {
                            investorStockTbl[idx].buyAmt = (investorStockTbl[idx].qty - remainQty) * (investorStockTbl[idx].qty == 0 ? 0 : investorStockTbl[idx].buyAmt / investorStockTbl[idx].qty);
                            investorStockTbl[idx].qty = (investorStockTbl[idx].qty - remainQty);
                            remainQty = 0;
                        }
                        else
                        {
                            remainQty -= investorStockTbl[idx].qty;
                            investorStockTbl[idx].buyAmt = 0;
                            investorStockTbl[idx].qty = 0;
                        }
                        if (remainQty == 0) break;
                    }
                    if (remainQty > 0)
                    {
                        errorText =  String.Format(Languages.Libs.GetString("outOfQty"), qty - remainQty);
                        return null;
                    }
                    break;
            }
            //Delete empty stock
            for (int idx = 0; idx < investorStockTbl.Count; idx++)
            {
                if (investorStockTbl[idx].qty != 0) continue;
                investorStockTbl[idx].Delete();
            }

            //Update data with transaction support
            TransactionScopeOption tranOption;
            tranOption = (commonClass.SysLibs.sysUseTransactionInUpdate ? TransactionScopeOption.Required : TransactionScopeOption.Suppress);
            using (TransactionScope scope = new TransactionScope(tranOption))
            {
                DbAccess.UpdateData(portfolioRow);
                DbAccess.UpdateData(investorStockTbl);
                DbAccess.UpdateData(transTbl);
                scope.Complete();
            }
            return transTbl;
        }

        /// <summary>
        /// Load stock price data withd some point ahead of the specified date range
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="frDate">Start date </param>
        /// <param name="toDate">End date</param>
        /// <param name="timeScale">Time scale</param>
        /// <param name="noUnitAhead">the number of units(minute,day,hour,week...) to read beyond the start time[frDate].</param>
        /// <param name="toTbl">Table keeps loaded data</param>
        /// <param name="startIdx">specify the row where the data in [frDate,toDate] range starts</param>
        public static void LoadBaseAnalysisData(AnalysisData dataObj) 
        {
            int startIdx = dataObj.priceDataTbl.Count;

            int noUnitAhead = constNumberOfReadAheadUnit;

            DateTime toDate = common.Consts.constNullDate;
            DateTime frDate = common.Consts.constNullDate;
            if (!commonClass.AppTypes.GetDate(dataObj.DataTimeRange, out frDate, out toDate)) return;

            dataObj.priceDataTbl.Clear();
            if (noUnitAhead != 0 &&
                frDate != System.DateTime.MinValue && toDate != System.DateTime.MaxValue)
            {
                // Find start date that return sufficient rows as required by [noBarAhead]
                DateTime checkFrDate = common.Consts.constNullDate;
                DateTime checkToDate = frDate.AddSeconds(-1);
                int totalGotRowCount = 0, gotRowCount;
                decimal rangeScale = 1;
                //int loopPass = 0;
                while (true)
                {
                    //loopPass++;
                    switch (dataObj.DataTimeScale.Type)
                    {
                        case commonClass.AppTypes.TimeScaleTypes.Minnute:
                            checkFrDate = checkToDate.AddMinutes(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Hour:
                            checkFrDate = checkToDate.AddHours(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Day:
                            checkFrDate = checkToDate.AddDays(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Week:
                            checkFrDate = checkToDate.AddDays(-(int)(7 * noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Month:
                            checkFrDate = checkToDate.AddMonths(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.Year:
                            checkFrDate = checkToDate.AddYears(-(int)(noUnitAhead * rangeScale));
                            break;
                        case commonClass.AppTypes.TimeScaleTypes.RealTime:
                            checkFrDate = checkToDate.AddMinutes(-(int)(commonClass.Settings.sysAutoRefreshInSeconds * noUnitAhead * rangeScale) / 60);
                            break;
                        default: common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }
                    gotRowCount = DbAccess.GetTotalPriceRow(dataObj.DataTimeScale, checkFrDate, checkToDate, dataObj.DataStockCode);
                    //No more data ??
                    if (checkFrDate < commonClass.Settings.sysStartDataDate)
                        break;
                    //Sufficient data ??
                    totalGotRowCount += gotRowCount;
                    if (totalGotRowCount >= noUnitAhead) break;

                    checkToDate = checkFrDate.AddSeconds(-1);
                    if (gotRowCount == 0) rangeScale = noUnitAhead;
                    else
                    {
                        if ((decimal)(noUnitAhead - totalGotRowCount) / gotRowCount > 0)
                            rangeScale = rangeScale * (decimal)(noUnitAhead - totalGotRowCount) / gotRowCount;
                        if (rangeScale < 1) rangeScale = 1;
                    }
                }
                DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, checkFrDate, frDate.AddSeconds(-1), dataObj.DataStockCode);
                startIdx = dataObj.priceDataTbl.Count - startIdx;
            }
            DbAccess.LoadData(dataObj.priceDataTbl, dataObj.DataTimeScale.Code, frDate, toDate, dataObj.DataStockCode);
            dataObj.FirstDataStartAt = startIdx;
        }

        //Updated data from the last read/update point
        public static int UpdateAnalysisData(AnalysisData dataObj)
        {
            int lastDataIdx = dataObj.priceDataTbl.Count - 1;
            DateTime lastDateTime;
            if (lastDataIdx < 0) lastDateTime = commonClass.Settings.sysStartDataDate;
            else lastDateTime = dataObj.priceDataTbl[lastDataIdx].onDate;

            data.baseDS.priceDataDataTable tbl = new data.baseDS.priceDataDataTable();
            DbAccess.LoadData(tbl, dataObj.DataTimeScale.Code, lastDateTime, dataObj.DataStockCode);
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
            return dataObj.priceDataTbl.Count - 1 - lastDataIdx;
        }
    }
    public class CommonLibs
    {
        public static string GetUnitTempTableName()
        {
            return "#" + common.system.UniqueString();
        }
        public static bool PasswordIsValid(string password, out string errMsg)
        {
            errMsg = "";
            if (password.TrimEnd().Length < commonClass.Settings.sysPasswordMinLen)
            {
                errMsg = "Mật khẩu phải có ít nhất " + commonClass.Settings.sysPasswordMinLen.ToString() + " ký tự.";
                return false;
            }
            return true;
        }
        public static int Permission2Number(string permission)
        {
            if (permission.Trim() == "") return common.Consts.constPermissionNONE;
            int perm = 0;
            if (permission.Contains(commonClass.Consts.constUserPermissionADD.ToString())) perm += common.Consts.constPermissionADD;
            if (permission.Contains(commonClass.Consts.constUserPermissionEDIT.ToString())) perm += common.Consts.constPermissionEDIT;
            if (permission.Contains(commonClass.Consts.constUserPermissionDEL.ToString())) perm += common.Consts.constPermissionDEL;
            return perm;
        }
        public static string Number2Permission(int number)
        {
            if (number == 0) return "";
            string permission = "";
            if ((number & common.Consts.constPermissionADD) > 0) permission += commonClass.Consts.constUserPermissionADD.ToString();
            if ((number & common.Consts.constPermissionDEL) > 0) permission += commonClass.Consts.constUserPermissionDEL.ToString();
            if ((number & common.Consts.constPermissionEDIT) > 0) permission += commonClass.Consts.constUserPermissionEDIT.ToString();
            return permission;
        }
        public static int GetFormPermission(string formCode)
        {
            string permission;
            permission = commonClass.Consts.constUserPermissionADD.ToString() +
                             commonClass.Consts.constUserPermissionDEL.ToString() +
                             commonClass.Consts.constUserPermissionEDIT.ToString();
            return Permission2Number(permission);

            if (commonClass.SysLibs.isSupperAdminLogin())
            {
                permission = commonClass.Consts.constUserPermissionADD.ToString() +
                             commonClass.Consts.constUserPermissionDEL.ToString() +
                             commonClass.Consts.constUserPermissionEDIT.ToString();
                return Permission2Number(permission);
            }
            //permission = dataLibs.GetWorkerAllPermission(commonClass.Consts.constSysPermissionMenu,
            //                                            sysLibs.sysLoginUserId, formCode);
            //return Permission2Number(permission);
        }
    }

    public class SysLibs
    {
        public static common.myAutoKeyInfo GetAutoKey(string key, bool usePending)
        {
            DateTime curTimeStamp = common.Consts.constNullDate;
            data.baseDS.sysAutoKeyPendingDataTable sysAutoKeyPendingTbl = new data.baseDS.sysAutoKeyPendingDataTable();
            //First try to re-used unused keys if required
            if (usePending)
            {
                curTimeStamp = DateTime.Now;
                DateTime minTimeStamp = curTimeStamp.AddSeconds(-Settings.sysTimeOut_AutoKey);
                sysAutoKeyPendingTbl.Clear();
                DbAccess.LoadData(sysAutoKeyPendingTbl, key);
                if (sysAutoKeyPendingTbl.Count > 0)
                {
                    for (int idx = 0; idx < sysAutoKeyPendingTbl.Count; idx++)
                    {
                        //Still valid : ignore it
                        if (sysAutoKeyPendingTbl[idx].timeStamp > minTimeStamp) continue;

                        //The the first invalid key will be used. Updating the timestamp to make it valid again.
                        sysAutoKeyPendingTbl[idx].timeStamp = curTimeStamp;
                        DbAccess.UpdateData(sysAutoKeyPendingTbl[idx]);
                        return new common.myAutoKeyInfo(key, sysAutoKeyPendingTbl[idx].value, sysAutoKeyPendingTbl[idx].value.Trim());
                    }
                }
            }
            //Then, create a new key and pending key if required
            data.baseDS.sysAutoKeyRow sysAutoKeyRow = DbAccess.NewAutoKeyValue(key);
            if (usePending) DbAccess.CreateAutoPendingKey(sysAutoKeyRow.key, sysAutoKeyRow.value.ToString(), curTimeStamp);
            string valueStr = sysAutoKeyRow.value.ToString().Trim();
            return new common.myAutoKeyInfo(key, valueStr, valueStr);
        }
        public static void DeleteKeyPending(common.myAutoKeyInfo autoKeyInfo)
        {
            //Remove the used key in pending list
            DbAccess.DeleteAutoKeyPending(autoKeyInfo.key, autoKeyInfo.value);
        }

        public static string GetAutoDataKey(string tblName)
        {
            return GetAutoDataKey(tblName, Settings.sysDataKeyPrefix, Settings.sysDataKeySize, false);
        }
        public static string GetAutoDataKey(string tblName, string prefix, int maxLen, bool usePending)
        {
            common.myAutoKeyInfo keyInfo = GetAutoKey(tblName, usePending);
            if (keyInfo == null) return null;
            return prefix + keyInfo.value.PadLeft(maxLen - prefix.Length, '0');
        }

        #region FindAndCache
        private static data.baseDS myCachedDS = new data.baseDS();
        private static data.tmpDS myCachedTmpDS = new data.tmpDS();
        public static void ClearCache()
        {
            myCachedDS.Clear();
            myCachedTmpDS.Clear();
        }

        public static data.baseDS.stockExchangeDataTable myStockExchangeTbl
        {
            get
            {
                if (myCachedDS.stockExchange.Count==0)
                {
                    application.DbAccess.LoadData(myCachedDS.stockExchange);
                }
                return myCachedDS.stockExchange;
            }
        }

        public static data.baseDS.stockExchangeRow FindAndCache_StockExchange(string code)
        {
            data.baseDS.stockExchangeRow row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockExchangeTA dataTA = new data.baseDSTableAdapters.stockExchangeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.Fill(myCachedDS.stockExchange);
            row = myCachedDS.stockExchange.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.stockCodeRow FindAndCache_StockCode(string code)
        {
            data.baseDS.stockCodeRow row = myCachedDS.stockCode.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockCodeTA dataTA = new data.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedDS.stockCode, code);
            row = myCachedDS.stockCode.FindBycode(code);
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
        public static data.baseDS.bizSubSectorRow FindAndCache_BizSubSector(string code)
        {
            return FindAndCache(myCachedDS.bizSubSector, code);
        }

        public static data.tmpDS.stockCodeRow FindAndCache_StockCodeShort(string code)
        {
            data.tmpDS.stockCodeRow row = myCachedTmpDS.stockCode.FindBycode(code);
            if (row != null) return row;
            data.tmpDSTableAdapters.stockCodeTA dataTA = new data.tmpDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(myCachedTmpDS.stockCode, code);
            row = myCachedTmpDS.stockCode.FindBycode(code);
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
        #endregion

    }

    public class Configuration
    {
        public const string constXMLElement_Root = "Application";
        public const string constXMLElement_Sub_System = "System";
        public const string constXMLElement_Sub_Database = "Database";
        public static bool withEncryption
        {
            get { return common.configuration.withEncryption; }
            set { common.configuration.withEncryption = value; }
        }

        public static void GetConfig(ref StringCollection aFields)
        {
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                aFields[idx] = DbAccess.GetConfig(aFields[idx].ToString());
                if (withEncryption && aFields[idx].ToString().Trim() != "")
                {
                    aFields[idx] = common.cryption.Decrypt(aFields[idx].ToString());
                }
            }
        }
        public static void SaveConfig(StringCollection aFields, StringCollection aValues)
        {
            string value;
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                value = aValues[idx].ToString();
                if (withEncryption && (value.Trim() != ""))
                {
                    value = common.cryption.Encrypt(value);
                }
                DbAccess.SaveConfig(aFields[idx].ToString(), value);
            }
        }

        //From database
        public static void Load_Global_Settings()
        {
            int num;
            DateTime dt;
            StringCollection aFields = new StringCollection();
            // Version ,release date and start data date
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.sysProdVersion.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysReleaseDate.ToString()); //For future used
            aFields.Add(commonClass.Configuration.configKeys.sysDataStartDate.ToString());
            GetConfig(ref aFields);

            common.settings.sysProductVersion = aFields[0].ToString();
            //commonClass.SysLibs.sysreleaseDate = aFields[1].ToString();
            GetConfig(ref aFields);
            dt = DateTime.MaxValue; DateTime.TryParse(aFields[2].ToString(), out dt);
            commonClass.SysLibs.sysDataStartDate = dt;

            // System
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.sysCultureCode.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPasswdMinLen.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysUseStrongPassword.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysDebugMode.ToString());

            aFields.Add(commonClass.Configuration.configKeys.sysDataKeyPrefix.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysDataKeySize.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysAutoEditKeySize.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysTimeOutAutoKey.ToString());
            GetConfig(ref aFields);
            if (aFields[0].Trim() != "") Settings.sysCultureCode = aFields[0];


            if (int.TryParse(aFields[1], out num)) Settings.sysPasswordMinLen = (byte)num;
            if (aFields[2].Trim() != "") Settings.sysUseStrongPassword = (aFields[2] == Boolean.TrueString);
            if (aFields[3].Trim() != "") Settings.sysDebugMode = (aFields[3] == Boolean.TrueString);
            if (aFields[4].Trim() != "") Settings.sysDataKeyPrefix = aFields[4].Trim();

            if (int.TryParse(aFields[5], out num)) Settings.sysDataKeySize = num;
            if (int.TryParse(aFields[6], out num)) Settings.sysAutoEditKeySize = num;
            if (int.TryParse(aFields[7], out num)) Settings.sysTimeOut_AutoKey = num;

            //Format
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.sysMaskLocalAmount.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysMaskForeignAmt.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysMaskQty.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysMaskPrice.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysMaskPercent.ToString());

            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionLocal.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionForeign.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionQty.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionPrice.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionPercentage.ToString());

            GetConfig(ref aFields);
            if (aFields[0].Trim() != "") Settings.sysMaskLocalAmt = aFields[0];
            if (aFields[1].Trim() != "") Settings.sysMaskForeignAmt = aFields[1];
            if (aFields[2].Trim() != "") Settings.sysMaskQty = aFields[2];
            if (aFields[3].Trim() != "") Settings.sysMaskPrice = aFields[3];
            if (aFields[4].Trim() != "") Settings.sysMaskPercent = aFields[4];

            if (int.TryParse(aFields[5], out num)) Settings.sysPrecisionLocal = num;
            if (int.TryParse(aFields[6], out num)) Settings.sysPrecisionForeign = num;
            if (int.TryParse(aFields[7], out num)) Settings.sysPrecisionQty = num;
            if (int.TryParse(aFields[8], out num)) Settings.sysPrecisionPrice = num;
            if (int.TryParse(aFields[9], out num)) Settings.sysPrecisionPercentage = num;

            //Email
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.sysSmtpServer.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysSmtpPort.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysSmtpAuthAccount.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysSmtpAuthPassword.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysSmptSSL.ToString());
            GetConfig(ref aFields);

            if (aFields[0].Trim() != "") common.sendMail.mySettings.smtpAddress = aFields[0];
            if (aFields[1].Trim() != "" & int.TryParse(aFields[1], out num)) common.sendMail.mySettings.smtpPort = num;
            common.sendMail.mySettings.authAccount = aFields[2].Trim();
            common.sendMail.mySettings.authPassword = aFields[3].Trim();
            common.sendMail.mySettings.smtpSSL = (aFields[4].Trim() == Boolean.TrueString);

            //Others
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.sysDataStartDate.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysMainCurrency.ToString());
            GetConfig(ref aFields);

            if (DateTime.TryParse(aFields[0], out dt)) commonClass.SysLibs.sysDataStartDate = dt;
            if (aFields[1].Trim() != "") Settings.sysMainCurrency = aFields[1];
        }
        public static void Save_Global_Settings()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear(); aValues.Clear();
            aFields.Add(commonClass.Configuration.configKeys.sysCultureCode.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPasswdMinLen.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysUseStrongPassword.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysDebugMode.ToString());
            aValues.Add(Settings.sysCultureCode);
            aValues.Add(Settings.sysPasswordMinLen.ToString());
            aValues.Add(Settings.sysUseStrongPassword.ToString());
            aValues.Add((Settings.sysDebugMode ? Boolean.TrueString : Boolean.FalseString));

            aFields.Add(commonClass.Configuration.configKeys.sysDataKeyPrefix.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysDataKeySize.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysAutoEditKeySize.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysTimeOutAutoKey.ToString());
            aValues.Add(Settings.sysDataKeyPrefix);
            aValues.Add(Settings.sysDataKeySize.ToString());
            aValues.Add(Settings.sysAutoEditKeySize.ToString());
            aValues.Add(Settings.sysTimeOut_AutoKey.ToString());
            SaveConfig(aFields, aValues);

            //Format
            aFields.Add(commonClass.Configuration.configKeys.sysMaskLocalAmount.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysMaskForeignAmt.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysMaskQty.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysMaskPercent.ToString());

            aValues.Add(Settings.sysMaskLocalAmt);
            aValues.Add(Settings.sysMaskForeignAmt);
            aValues.Add(Settings.sysMaskQty);
            aValues.Add(Settings.sysMaskPercent);

            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionLocal.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionForeign.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionQty.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysPrecisionPercentage.ToString());

            aValues.Add(Settings.sysPrecisionLocal.ToString());
            aValues.Add(Settings.sysPrecisionForeign.ToString());
            aValues.Add(Settings.sysPrecisionQty.ToString());
            aValues.Add(Settings.sysPrecisionPercentage.ToString());
            SaveConfig(aFields, aValues);

            //Mail
            aFields.Clear(); aValues.Clear();
            aFields.Add(commonClass.Configuration.configKeys.sysSmtpServer.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysSmtpPort.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysSmtpAuthAccount.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysSmtpAuthPassword.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysSmptSSL.ToString());

            aValues.Add(common.sendMail.mySettings.smtpAddress);
            aValues.Add(common.sendMail.mySettings.smtpPort.ToString());
            aValues.Add(common.sendMail.mySettings.authAccount);
            aValues.Add(common.sendMail.mySettings.authPassword);
            aValues.Add(common.sendMail.mySettings.smtpSSL ? Boolean.TrueString : Boolean.FalseString);
            SaveConfig(aFields, aValues);


            //Others
            aFields.Clear(); aValues.Clear();
            aFields.Add(commonClass.Configuration.configKeys.sysMainCurrency.ToString());
            aFields.Add(commonClass.Configuration.configKeys.sysDataStartDate.ToString());

            aValues.Add(Settings.sysMainCurrency);
            aValues.Add(commonClass.SysLibs.sysDataStartDate.ToShortDateString());
            SaveConfig(aFields, aValues);
        }

        //All from local config file
        public static void Load_Local_Settings()
        {
            Load_Local_Settings_STOCK();
            Load_Local_Settings_CHART();
            Load_Local_Settings_SYSTEM();
            Load_Local_Settings_USER();
        }
        public static void Save_Local_Settings()
        {
            Save_Local_Settings_STOCK();
            Save_Local_Settings_CHART();
            Save_Local_Settings_SYSTEM();
            Save_Local_Settings_USER();
        }

        public static void Load_Local_Settings_STOCK()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.stockMaxBuyQtyPerc.ToString());
            aFields.Add(commonClass.Configuration.configKeys.stockReduceQtyPerc.ToString());
            aFields.Add(commonClass.Configuration.configKeys.stockAccumulateQtyPerc.ToString());

            aFields.Add(commonClass.Configuration.configKeys.stockTotalCapAmt.ToString());
            aFields.Add(commonClass.Configuration.configKeys.stockMaxBuyAmtPerc.ToString());
            common.configuration.GetConfig(constXMLElement_Root, constXMLElement_Sub_System, aFields);

            decimal d = 0; 
            if (common.system.String2Number_Common(aFields[0], out d)) Settings.sysStockMaxBuyQtyPerc = d;
            if (common.system.String2Number_Common(aFields[1], out d)) Settings.sysStockReduceQtyPerc = d;
            if (common.system.String2Number_Common(aFields[2], out d)) Settings.sysStockAccumulateQtyPerc = d;
            if (common.system.String2Number_Common(aFields[3], out d)) Settings.sysStockTotalCapAmt = d;
            if (common.system.String2Number_Common(aFields[4], out d)) Settings.sysStockMaxBuyAmtPerc = d;
        }
        public static void Save_Local_Settings_STOCK()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.stockMaxBuyQtyPerc.ToString());
            aFields.Add(commonClass.Configuration.configKeys.stockReduceQtyPerc.ToString());
            aFields.Add(commonClass.Configuration.configKeys.stockAccumulateQtyPerc.ToString());
            aFields.Add(commonClass.Configuration.configKeys.stockTotalCapAmt.ToString());
            aFields.Add(commonClass.Configuration.configKeys.stockMaxBuyAmtPerc.ToString());

            aValues.Clear();
            aValues.Add(common.system.Number2String_Common(Settings.sysStockMaxBuyQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockReduceQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockAccumulateQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockTotalCapAmt));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockMaxBuyAmtPerc));
            common.configuration.SaveConfig(constXMLElement_Root, constXMLElement_Sub_System, aFields, aValues);
        }

        public static void Load_Local_Settings_SYSTEM()
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysTimerIntervalInSecs }));

            aFields.Add(common.system.GetName(new { Settings.sysDefaultTimeRange }));
            aFields.Add(common.system.GetName(new { Settings.sysDefaultTimeScale}));

            aFields.Add(common.system.GetName(new { Settings.sysScreeningTimeRange }));
            aFields.Add(common.system.GetName(new { Settings.sysScreeningTimeScale }));


            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_BG}));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_FG }));
            commonClass.Configuration.GetUserSettings("System", aFields);

            int n = 0;
            if (int.TryParse(aFields[0].Trim(),out n)) Settings.sysTimerIntervalInSecs = n;

            if (aFields[1].Trim() != "") Settings.sysDefaultTimeRange = AppTypes.TimeRangeFromCode(aFields[1].Trim());
            if (aFields[2].Trim() != "") Settings.sysDefaultTimeScale = AppTypes.TimeScaleFromCode(aFields[2].Trim());

            if (aFields[3].Trim() != "") Settings.sysScreeningTimeRange = AppTypes.TimeRangeFromCode(aFields[3].Trim());
            if (aFields[4].Trim() != "") Settings.sysScreeningTimeScale = AppTypes.TimeScaleFromCode(aFields[4].Trim());

            if (aFields[5].Trim() != "") Settings.sysPriceColor_Increase_BG = ColorTranslator.FromHtml(aFields[5]);
            if (aFields[6].Trim() != "") Settings.sysPriceColor_Increase_FG = ColorTranslator.FromHtml(aFields[6]);

            if (aFields[7].Trim() != "") Settings.sysPriceColor_Decrease_BG = ColorTranslator.FromHtml(aFields[7]);
            if (aFields[8].Trim() != "") Settings.sysPriceColor_Decrease_FG = ColorTranslator.FromHtml(aFields[8]);

            if (aFields[9].Trim() != "") Settings.sysPriceColor_NotChange_BG = ColorTranslator.FromHtml(aFields[9]);
            if (aFields[10].Trim() != "") Settings.sysPriceColor_NotChange_FG = ColorTranslator.FromHtml(aFields[10]);
        }
        public static void Save_Local_Settings_SYSTEM()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysTimerIntervalInSecs }));

            aFields.Add(common.system.GetName(new { Settings.sysDefaultTimeRange }));
            aFields.Add(common.system.GetName(new { Settings.sysDefaultTimeScale }));

            aFields.Add(common.system.GetName(new { Settings.sysScreeningTimeRange }));
            aFields.Add(common.system.GetName(new { Settings.sysScreeningTimeScale }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_FG }));
            
            aValues.Clear();
            aValues.Add(common.system.Number2String_Common(Settings.sysTimerIntervalInSecs));

            aValues.Add(Settings.sysDefaultTimeRange.ToString());
            aValues.Add(Settings.sysDefaultTimeScale.Code);

            aValues.Add(Settings.sysScreeningTimeRange.ToString());
            aValues.Add(Settings.sysScreeningTimeScale.Code);

            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Increase_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Increase_FG));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Decrease_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Decrease_FG));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_NotChange_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_NotChange_FG));

            commonClass.Configuration.SaveUserSettings("System", aFields, aValues);
        }

        public static void Load_Local_Settings_CHART()
        {
            decimal d = 0;
            //Color page
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartBgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartFgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartGridColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartVolumesColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartLineCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBearCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBullCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarDnColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarUpColor }));
            commonClass.Configuration.GetUserSettings("ChartColors", aFields);

            if (aFields[0].Trim() != "") Settings.sysChartBgColor = ColorTranslator.FromHtml(aFields[0]);
            if (aFields[1].Trim() != "") Settings.sysChartFgColor = ColorTranslator.FromHtml(aFields[1]);
            if (aFields[2].Trim() != "") Settings.sysChartGridColor = ColorTranslator.FromHtml(aFields[2]);
            if (aFields[3].Trim() != "") Settings.sysChartVolumesColor = ColorTranslator.FromHtml(aFields[3]);

            if (aFields[4].Trim() != "") Settings.sysChartLineCandleColor = ColorTranslator.FromHtml(aFields[4]);
            if (aFields[5].Trim() != "") Settings.sysChartBearCandleColor = ColorTranslator.FromHtml(aFields[5]);
            if (aFields[6].Trim() != "") Settings.sysChartBullCandleColor = ColorTranslator.FromHtml(aFields[6]);
            if (aFields[7].Trim() != "") Settings.sysChartBarDnColor = ColorTranslator.FromHtml(aFields[7]);
            if (aFields[8].Trim() != "") Settings.sysChartBarUpColor = ColorTranslator.FromHtml(aFields[8]);

            //Chart page
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartShowDescription }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowVolume }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowGrid }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowLegend }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoomRate}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MouseRate}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MoveCount}));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtRIGHT}));
            commonClass.Configuration.GetUserSettings("ChartSettings", aFields);

            Settings.sysChartShowDescription = (aFields[0].Trim() == Boolean.TrueString);
            Settings.sysChartShowVolume = (aFields[1].Trim() == Boolean.TrueString);
            Settings.sysChartShowGrid = (aFields[2].Trim() == Boolean.TrueString);
            Settings.sysChartShowLegend = (aFields[3].Trim() == Boolean.TrueString);

            if (common.system.String2Number_Common(aFields[4], out d)) Charts.Settings.sysZoomRate = (int)d;
            if (common.system.String2Number_Common(aFields[5], out d)) Charts.Settings.sysPAN_MouseRate = (int)d;
            if (common.system.String2Number_Common(aFields[6], out d)) Charts.Settings.sysPAN_MoveCount = (int)d;

            if (common.system.String2Number_Common(aFields[7], out d)) Charts.Settings.sysViewSpaceAtLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[8], out d)) Charts.Settings.sysViewSpaceAtRIGHT = (int)d; 

            
        }
        public static void Save_Local_Settings_CHART()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartBgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartFgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartGridColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartVolumesColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartLineCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBearCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBullCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarDnColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarUpColor }));

            aValues.Clear();
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBgColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartFgColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartGridColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartVolumesColor));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartLineCandleColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBearCandleColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBullCandleColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBarDnColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBarUpColor));
            commonClass.Configuration.GetUserSettings("ChartColors", aFields);

            //Chart page
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartShowDescription }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowVolume }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowGrid }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowLegend }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoomRate}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MouseRate}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MoveCount}));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtLEFT}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtRIGHT }));

            aValues.Clear();
            aValues.Add(Settings.sysChartShowDescription.ToString());
            aValues.Add(Settings.sysChartShowVolume.ToString());
            aValues.Add(Settings.sysChartShowGrid.ToString());
            aValues.Add(Settings.sysChartShowLegend.ToString());

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysZoomRate));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MouseRate));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MoveCount));

            aValues.Add(common.system.Number2String_Common((decimal)Charts.Settings.sysViewSpaceAtLEFT));
            aValues.Add(common.system.Number2String_Common((decimal)Charts.Settings.sysViewSpaceAtRIGHT));

            commonClass.Configuration.SaveUserSettings("ChartSettings", aFields, aValues);
        }

        public static void Load_Local_Settings_USER()
        {
            StringCollection aFields = new StringCollection();
            //Company
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.companyName.ToString());
            aFields.Add(commonClass.Configuration.configKeys.companyAddr1.ToString());
            aFields.Add(commonClass.Configuration.configKeys.companyAddr2.ToString());
            aFields.Add(commonClass.Configuration.configKeys.companyAddr3.ToString());
            aFields.Add(commonClass.Configuration.configKeys.telephone.ToString());
            aFields.Add(commonClass.Configuration.configKeys.fax.ToString());
            aFields.Add(commonClass.Configuration.configKeys.email.ToString());
            aFields.Add(commonClass.Configuration.configKeys.URL.ToString());
            aFields.Add(commonClass.Configuration.configKeys.companyTaxcode.ToString());

            aFields.Add(commonClass.Configuration.configKeys.bankName.ToString());
            aFields.Add(commonClass.Configuration.configKeys.bankAccount.ToString());
            aFields.Add(commonClass.Configuration.configKeys.bankCode.ToString());

            aFields.Add(commonClass.Configuration.configKeys.director.ToString());
            aFields.Add(commonClass.Configuration.configKeys.chiefAccountant.ToString());
            aFields.Add(commonClass.Configuration.configKeys.headOfManagementBoard.ToString());
            aFields.Add(commonClass.Configuration.configKeys.warehouseManager.ToString());
            aFields.Add(commonClass.Configuration.configKeys.cashier.ToString());
            common.configuration.GetConfig(constXMLElement_Root, constXMLElement_Sub_System, aFields);

            //commonClass.SysLibs.sysCompanyName = aFields[0].ToString();
            commonClass.SysLibs.sysCompanyAddr1 = aFields[1].ToString();
            commonClass.SysLibs.sysCompanyAddr2 = aFields[2].ToString();
            commonClass.SysLibs.sysCompanyAddr3 = aFields[3].ToString();

            commonClass.SysLibs.sysCompanyPhone = aFields[4].ToString();
            commonClass.SysLibs.sysCompanyFax = aFields[5].ToString();
            commonClass.SysLibs.sysCompanyEmail = aFields[6].ToString();
            commonClass.SysLibs.sysCompanyURL = aFields[7].ToString();
            commonClass.SysLibs.sysCompanyTaxCode = aFields[8].ToString();

            commonClass.SysLibs.sysCompanyBankName = aFields[9].ToString();
            commonClass.SysLibs.sysCompanyBankAccount = aFields[10].ToString();
            commonClass.SysLibs.sysCompanyBankCode = aFields[11].ToString();

            commonClass.SysLibs.sysCompanyDirector = aFields[12].ToString();
            commonClass.SysLibs.sysCompanyChiefAccountant = aFields[13].ToString();
            commonClass.SysLibs.sysCompanyHeadOfManagementBoard = aFields[14].ToString();
            commonClass.SysLibs.sysWarehouseManager = aFields[15].ToString();
            commonClass.SysLibs.sysCompanyCashier = aFields[16].ToString();

            //Image and Icon
            aFields.Clear();
            aFields.Add(commonClass.Configuration.configKeys.imgFilePathBackground.ToString());
            aFields.Add(commonClass.Configuration.configKeys.imgFilePathIcon.ToString());
            aFields.Add(commonClass.Configuration.configKeys.imgFilePathComanyLogo1.ToString());
            aFields.Add(commonClass.Configuration.configKeys.imgFilePathComanyLogo2.ToString());
            commonClass.Configuration.GetUserSettings("Others", aFields);

            commonClass.SysLibs.sysImgFilePathBackGround = common.fileFuncs.GetFullPath(aFields[0].ToString());
            commonClass.SysLibs.sysImgFilePathIcon = common.fileFuncs.GetFullPath(aFields[1].ToString());
            commonClass.SysLibs.sysImgFilePathCompanyLogo1 = common.fileFuncs.GetFullPath(aFields[2].ToString());
            commonClass.SysLibs.sysImgFilePathCompanyLogo2 = common.fileFuncs.GetFullPath(aFields[3].ToString());
        }
        public static void Save_Local_Settings_USER()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            aFields.Clear(); aValues.Clear();
            //Company
            aFields.Add(commonClass.Configuration.configKeys.companyName.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyName);
            aFields.Add(commonClass.Configuration.configKeys.companyAddr1.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyAddr1);
            aFields.Add(commonClass.Configuration.configKeys.companyAddr2.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyAddr2);
            aFields.Add(commonClass.Configuration.configKeys.companyAddr3.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyAddr3);
            aFields.Add(commonClass.Configuration.configKeys.telephone.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyPhone);
            aFields.Add(commonClass.Configuration.configKeys.fax.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyFax);
            aFields.Add(commonClass.Configuration.configKeys.email.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyEmail);
            aFields.Add(commonClass.Configuration.configKeys.URL.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyURL);
            aFields.Add(commonClass.Configuration.configKeys.companyTaxcode.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyTaxCode);

            aFields.Add(commonClass.Configuration.configKeys.bankName.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyBankName);
            aFields.Add(commonClass.Configuration.configKeys.bankAccount.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyBankAccount);
            aFields.Add(commonClass.Configuration.configKeys.bankCode.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyBankCode);

            aFields.Add(commonClass.Configuration.configKeys.director.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyDirector);
            aFields.Add(commonClass.Configuration.configKeys.chiefAccountant.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyChiefAccountant);
            aFields.Add(commonClass.Configuration.configKeys.headOfManagementBoard.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyHeadOfManagementBoard);
            aFields.Add(commonClass.Configuration.configKeys.warehouseManager.ToString()); aValues.Add(commonClass.SysLibs.sysWarehouseManager);
            aFields.Add(commonClass.Configuration.configKeys.cashier.ToString()); aValues.Add(commonClass.SysLibs.sysCompanyCashier);
            common.configuration.SaveConfig(constXMLElement_Root, constXMLElement_Sub_System, aFields, aValues);

            //Image and icon
            aFields.Clear(); aValues.Clear();
            aFields.Add(commonClass.Configuration.configKeys.imgFilePathIcon.ToString()); aValues.Add(common.fileFuncs.MakeRelativePath(commonClass.SysLibs.sysImgFilePathIcon));
            aFields.Add(commonClass.Configuration.configKeys.imgFilePathBackground.ToString()); aValues.Add(common.fileFuncs.MakeRelativePath(commonClass.SysLibs.sysImgFilePathBackGround));
            aFields.Add(commonClass.Configuration.configKeys.imgFilePathComanyLogo1.ToString()); aValues.Add(common.fileFuncs.MakeRelativePath(commonClass.SysLibs.sysImgFilePathCompanyLogo1));
            aFields.Add(commonClass.Configuration.configKeys.imgFilePathComanyLogo2.ToString()); aValues.Add(common.fileFuncs.MakeRelativePath(commonClass.SysLibs.sysImgFilePathCompanyLogo2));
            commonClass.Configuration.SaveUserSettings("Others", aFields, aValues);
        }

        public static void Load_User_Envir()
        {
            StringCollection aFields = new StringCollection();
            aFields.Add(commonClass.Configuration.configKeys.LoginName.ToString());
            aFields.Add(commonClass.Configuration.configKeys.loginLocationId.ToString());
            common.configuration.GetConfig("ENVIRONMENT", "Login", aFields);

            commonClass.SysLibs.sysLoginAccount = aFields[0].ToString();
            int id = 0;
            int.TryParse(aFields[1].ToString(), out id);
            commonClass.SysLibs.sysLoginLocationId = id;
        }
        public static void Save_User_Envir()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            aFields.Clear(); aValues.Clear();
            aFields.Add(commonClass.Configuration.configKeys.LoginName.ToString());
            aValues.Add(commonClass.SysLibs.sysLoginAccount);

            aFields.Add(commonClass.Configuration.configKeys.loginLocationId.ToString());
            aValues.Add(commonClass.SysLibs.sysLoginLocationId.ToString());
            common.configuration.SaveConfig("ENVIRONMENT", "Login", aFields, aValues);
        }
    }
}
