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

namespace application
{
    public class sample_dataLibs
    {
        #region access objects
        private static data.baseDSTableAdapters.companyTA companyTA = new data.baseDSTableAdapters.companyTA();
        private static data.baseDSTableAdapters.stockCodeTA stockCodeTA = new data.baseDSTableAdapters.stockCodeTA();
        #endregion access object
        
        #region get/load method 
        public static void LoadData(data.baseDS.companyDataTable tbl)
        {
            companyTA.ClearBeforeFill = false;
            companyTA.Fill(tbl);
        }
        public static void LoadData(data.baseDS.stockCodeDataTable tbl, string comCode)
        {
            stockCodeTA.ClearBeforeFill = false;
            if (comCode == null) stockCodeTA.Fill(tbl);
            else stockCodeTA.FillByComCode(tbl, comCode);
        }
        #endregion

        //Init
        #region Init
        public static void InitData(data.baseDS.companyRow row)
        {
            row.code  = "";
            row.name = "";
            row.address1 = "";
            row.email = "";
            row.estDate = common.Consts.constNullDate;
            row.capital = 0;
            row.capitalUnit = application.Settings.sysMainCurrency;
            row.country = application.Settings.sysDefaultCountry;
            row.bizSectors = "";
            row.employees  = 0;
        }
        public static void InitData(data.baseDS.stockCodeRow row)
        {
            row.code = "";
            row.tickerCode = "";
            row.stockExchange = "";
            row.regDate = common.Consts.constNullDate; 
            row.comCode = "";
            row.noOpenShares =0;
            row.noShares = 0;
            row.noForeignOwnShares = 0;
            row.status = (byte)application.myTypes.commonStatus.Enable; 
        }
        #endregion

        //Update
        #region Update
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

        public static void UpdateData(data.baseDS.companyRow row)
        {
            companyTA.Update(row);
            row.AcceptChanges();
        }
        public static void UpdateData(data.baseDS.companyDataTable tbl)
        {
            companyTA.Update(tbl);
            tbl.AcceptChanges();
        }
        #endregion Update
        //Find and cache
        #region FindAndCache
        public static data.baseDS.companyRow FindAndCache(data.baseDS.companyDataTable tbl, string code)
        {
            data.baseDS.companyRow  row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.companyTA dataTA = new data.baseDSTableAdapters.companyTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        public static data.baseDS.stockCodeRow FindAndCache(data.baseDS.stockCodeDataTable tbl, string code)
        {
            data.baseDS.stockCodeRow row = tbl.FindBycode(code);
            if (row != null) return row;
            data.baseDSTableAdapters.stockCodeTA dataTA = new data.baseDSTableAdapters.stockCodeTA();
            dataTA.ClearBeforeFill = false;
            dataTA.FillByCode(tbl, code);
            row = tbl.FindBycode(code);
            if (row != null) return row;
            return null;
        }
        #endregion
    }

    public class sample
    {
        public void AddCompany()
        {
            data.baseDS.companyRow companyRow;
            data.baseDS.companyDataTable companyTbl = new data.baseDS.companyDataTable();
            string companyCode = "???";

            companyRow = application.dataLibs.FindAndCache(companyTbl, companyCode);
            if (companyRow == null)
            {
                companyRow = companyTbl.NewcompanyRow();
                application.dataLibs.InitData(companyRow);
                companyRow.code = companyCode;
                companyRow.name = "??";
                companyRow.estDate = DateTime.Today;
                companyTbl.AddcompanyRow(companyRow);
                application.dataLibs.UpdateData(companyRow);
            }
            // Or  application.dataLibs.UpdateData(companyTbl);
        }
    }
}
