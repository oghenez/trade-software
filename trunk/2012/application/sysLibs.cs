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

            common.Settings.sysProductOwner = commonClass.Consts.constProductOwner;
            common.Settings.sysProductCode = commonClass.Consts.constProductCode;
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

            common.Settings.sysProductVersion = aFields[0].ToString();
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

            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_Percent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_MinCount }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MovePercent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MoveMinCount}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MouseRate }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_DEFA }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_MIN }));
            
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtRIGHT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginRIGHT}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginBOT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtRIGHT}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtTOP}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtBOT}));

            commonClass.Configuration.GetUserSettings("ChartSettings", aFields);

            Settings.sysChartShowDescription = (aFields[0].Trim() == Boolean.TrueString);
            Settings.sysChartShowVolume = (aFields[1].Trim() == Boolean.TrueString);
            Settings.sysChartShowGrid = (aFields[2].Trim() == Boolean.TrueString);
            Settings.sysChartShowLegend = (aFields[3].Trim() == Boolean.TrueString);

            if (common.system.String2Number_Common(aFields[4], out d)) Charts.Settings.sysZoom_Percent = (int)d;
            if (common.system.String2Number_Common(aFields[5], out d)) Charts.Settings.sysZoom_MinCount = (int)d;

            if (common.system.String2Number_Common(aFields[6], out d)) Charts.Settings.sysPAN_MovePercent = (int)d;
            if (common.system.String2Number_Common(aFields[7], out d)) Charts.Settings.sysPAN_MoveMinCount = (int)d;
            if (common.system.String2Number_Common(aFields[8], out d)) Charts.Settings.sysPAN_MouseRate = (int)d;

            if (common.system.String2Number_Common(aFields[9], out d)) Charts.Settings.sysNumberOfPoint_DEFA = (int)d;
            if (common.system.String2Number_Common(aFields[10], out d)) Charts.Settings.sysNumberOfPoint_MIN = (int)d;

            if (common.system.String2Number_Common(aFields[11], out d)) Charts.Settings.sysViewMinBarAtLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[12], out d)) Charts.Settings.sysViewMinBarAtRIGHT = (int)d;

            if (common.system.String2Number_Common(aFields[13], out d)) Charts.Settings.sysChartMarginLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[14], out d)) Charts.Settings.sysChartMarginRIGHT = (int)d;
            if (common.system.String2Number_Common(aFields[15], out d)) Charts.Settings.sysChartMarginTOP = (int)d;
            if (common.system.String2Number_Common(aFields[16], out d)) Charts.Settings.sysChartMarginBOT = (int)d;

            if (common.system.String2Number_Common(aFields[17], out d)) Charts.Settings.sysViewSpaceAtLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[18], out d)) Charts.Settings.sysViewSpaceAtRIGHT = (int)d;
            if (common.system.String2Number_Common(aFields[19], out d)) Charts.Settings.sysViewSpaceAtTOP = (double)d;
            if (common.system.String2Number_Common(aFields[20], out d)) Charts.Settings.sysViewSpaceAtBOT = (double)d; 
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

            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_Percent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_MinCount}));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MovePercent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MoveMinCount }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MouseRate }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_DEFA }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_MIN }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtRIGHT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginRIGHT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginBOT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtRIGHT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtBOT }));

            aValues.Clear();
            aValues.Add(Settings.sysChartShowDescription.ToString());
            aValues.Add(Settings.sysChartShowVolume.ToString());
            aValues.Add(Settings.sysChartShowGrid.ToString());
            aValues.Add(Settings.sysChartShowLegend.ToString());

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysZoom_Percent));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysZoom_MinCount));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MovePercent));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MoveMinCount));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MouseRate));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysNumberOfPoint_DEFA));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysNumberOfPoint_MIN));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewMinBarAtLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewMinBarAtRIGHT));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginRIGHT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginTOP));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginBOT));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewSpaceAtLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewSpaceAtRIGHT));
            aValues.Add(common.system.Number2String_Common((decimal)Charts.Settings.sysViewSpaceAtTOP));
            aValues.Add(common.system.Number2String_Common((decimal)Charts.Settings.sysViewSpaceAtBOT));

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
