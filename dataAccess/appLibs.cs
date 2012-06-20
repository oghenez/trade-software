using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms; 
using System.Data;
using System.Text;
using System.Drawing;
using System.Xml;
using commonTypes;
using commonClass;
using System.Net;

namespace DataAccess
{
    public static class AppLibs
    {
        public static databases.tmpDS myCacheBaseDS = new databases.tmpDS();
        public static databases.tmpDS.investorRow FindAndCache_Investor(string code)
        {
            return FindAndCache(myCacheBaseDS.investor, code);
        }
        public static databases.tmpDS.investorRow FindAndCache(databases.tmpDS.investorDataTable tbl, string code)
        {
            databases.tmpDS.investorRow row = tbl.FindBycode(code);
            if (row != null) return row;
            if (tbl.Count == 0)
            {
                LoadInvestor(tbl, false);
                row = tbl.FindBycode(code);
                if (row != null) return row;
            }
            return null;
        }

        public static databases.tmpDS.investorRow GetInvestorByAccount(string account)
        {
            DataView dataView = new DataView(myCacheBaseDS.investor);
            dataView.Sort = myCacheBaseDS.investor.accountColumn.ColumnName;
            DataRowView[] foundRows = dataView.FindRows(new object[] {account});
            if (foundRows.Length == 0) LoadInvestor(myCacheBaseDS.investor, false);

            foundRows = dataView.FindRows(new object[] { account });
            if (foundRows.Length > 0) return (databases.tmpDS.investorRow)foundRows[0].Row;
            return null;
        }
        public static void LoadInvestor(databases.tmpDS.investorDataTable tbl, bool force)
        {
            if (force) tbl.Clear();
            if (tbl.Count > 0) return;
            databases.tmpDS.investorDataTable newTbl = Libs.GetInvestorShortList();
            if (newTbl != null) common.system.Concat(newTbl, 0, tbl);
        }
    }
}
