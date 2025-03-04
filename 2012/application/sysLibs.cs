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
using System.Xml;
using System.IO;
using commonTypes;
using commonClass;

namespace application
{
    public class test
    {
        public static bool LoadTestConfig()
        {
            databases.SysLibs.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

            common.Settings.sysProductOwner = Consts.constProductOwner;
            common.Settings.sysProductCode = Consts.constProductCode;

            Configuration.withEncryption = true;
            Configuration.Load_User_Envir();

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
        public static int Permission2Number(string permission)
        {
            if (permission.Trim() == "") return common.Consts.constPermissionNONE;
            int perm = 0;
            if (permission.Contains(Consts.constUserPermissionADD.ToString())) perm += common.Consts.constPermissionADD;
            if (permission.Contains(Consts.constUserPermissionEDIT.ToString())) perm += common.Consts.constPermissionEDIT;
            if (permission.Contains(Consts.constUserPermissionDEL.ToString())) perm += common.Consts.constPermissionDEL;
            return perm;
        }
        public static string Number2Permission(int number)
        {
            if (number == 0) return "";
            string permission = "";
            if ((number & common.Consts.constPermissionADD) > 0) permission += Consts.constUserPermissionADD.ToString();
            if ((number & common.Consts.constPermissionDEL) > 0) permission += Consts.constUserPermissionDEL.ToString();
            if ((number & common.Consts.constPermissionEDIT) > 0) permission += Consts.constUserPermissionEDIT.ToString();
            return permission;
        }
        public static int GetFormPermission(string formCode)
        {
            string permission;
            permission = Consts.constUserPermissionADD.ToString() +
                             Consts.constUserPermissionDEL.ToString() +
                             Consts.constUserPermissionEDIT.ToString();
            return Permission2Number(permission);

            //if (commonClass.SysLibs.isSupperAdminLogin())
            //{
            //    permission = Consts.constUserPermissionADD.ToString() +
            //                 Consts.constUserPermissionDEL.ToString() +
            //                 Consts.constUserPermissionEDIT.ToString();
            //    return Permission2Number(permission);
            //}
            //permission = dataLibs.GetWorkerAllPermission(Consts.constSysPermissionMenu,
            //                                            sysLibs.sysLoginUserId, formCode);
            //return Permission2Number(permission);
        }
    }

    public class SysLibs
    {
        public static common.myAutoKeyInfo GetAutoKey(string key, bool usePending)
        {
            DateTime curTimeStamp = common.Consts.constNullDate;
            databases.baseDS.sysAutoKeyPendingDataTable sysAutoKeyPendingTbl = new databases.baseDS.sysAutoKeyPendingDataTable();
            //First try to re-used unused keys if required
            if (usePending)
            {
                curTimeStamp = DateTime.Now;
                DateTime minTimeStamp = curTimeStamp.AddSeconds(-Settings.sysGlobal.TimeOut_AutoKey);
                sysAutoKeyPendingTbl.Clear();
                databases.DbAccess.LoadData(sysAutoKeyPendingTbl, key);
                if (sysAutoKeyPendingTbl.Count > 0)
                {
                    for (int idx = 0; idx < sysAutoKeyPendingTbl.Count; idx++)
                    {
                        //Still valid : ignore it
                        if (sysAutoKeyPendingTbl[idx].timeStamp > minTimeStamp) continue;

                        //The the first invalid key will be used. Updating the timestamp to make it valid again.
                        sysAutoKeyPendingTbl[idx].timeStamp = curTimeStamp;
                        databases.DbAccess.UpdateData(sysAutoKeyPendingTbl[idx]);
                        return new common.myAutoKeyInfo(key, sysAutoKeyPendingTbl[idx].value, sysAutoKeyPendingTbl[idx].value.Trim());
                    }
                }
            }
            //Then, create a new key and pending key if required
            databases.baseDS.sysAutoKeyRow sysAutoKeyRow = databases.DbAccess.NewAutoKeyValue(key);
            if (usePending) databases.DbAccess.CreateAutoPendingKey(sysAutoKeyRow.key, sysAutoKeyRow.value.ToString(), curTimeStamp);
            string valueStr = sysAutoKeyRow.value.ToString().Trim();
            return new common.myAutoKeyInfo(key, valueStr, valueStr);
        }
        public static void DeleteKeyPending(common.myAutoKeyInfo autoKeyInfo)
        {
            //Remove the used key in pending list
            databases.DbAccess.DeleteAutoKeyPending(autoKeyInfo.key, autoKeyInfo.value);
        }

        public static string GetAutoDataKey(string tblName, bool usePending)
        {
            return GetAutoDataKey(tblName, Settings.sysGlobal.DataKeyPrefix, Settings.sysGlobal.DataKeySize, usePending);
        }
        public static string GetAutoDataKey(string tblName, string prefix, int maxLen, bool usePending)
        {
            common.myAutoKeyInfo keyInfo = GetAutoKey(tblName, usePending);
            if (keyInfo == null) return null;
            return prefix + keyInfo.value.PadLeft(maxLen - prefix.Length, '0');
        }

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
                if (myCachedDS.stockExchange.Count==0)
                {
                    databases.DbAccess.LoadData(myCachedDS.stockExchange);
                }
                return myCachedDS.stockExchange;
            }
        }
        public static databases.baseDS.exchangeDetailDataTable myExchangeDetailTbl
        {
            get
            {
                if (myCachedDS.exchangeDetail.Count == 0)
                {
                    databases.DbAccess.LoadData(myCachedDS.exchangeDetail);
                }
                return myCachedDS.exchangeDetail;
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
        
        public static databases.baseDS.stockCodeRow FindAndCache(databases.baseDS.stockCodeDataTable tbl,string code)
        {
            databases.baseDS.stockCodeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            databases.baseDSTableAdapters.stockCodeTA dataTA = new databases.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static databases.baseDS.stockCodeRow FindAndCache_StockCode(string code)
        {
            return FindAndCache(myCachedDS.stockCode, code);
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
    }
}
