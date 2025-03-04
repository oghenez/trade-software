using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using application;
using commonTypes;
using commonClass;

namespace Trade
{
    public static class AppLibs
    {
        public static void OrderForm(string stockCode)
        {
            Trade.Forms.transactionNew form = Trade.Forms.transactionNew.GetForm("");
            form.ClearEditData();
            form.LockEdit(false);
            form.myCode = (stockCode != null ? stockCode : "");
            form.ShowDialog();
        }

        //Merge alert message with specified-language text
        public static string AlertMessageText(string msg)
        {
            return AlertMessageText(msg, null);
        }
        public static string AlertMessageText(string msg,string convertCRLF_ToString)
        {
            if (convertCRLF_ToString!=null)
            {
                msg = msg.Replace(common.Consts.constCRLF,convertCRLF_ToString); 
            }
            common.myKeyValueItem[] tags = new common.myKeyValueItem[4];
            tags[0] = CreateAlertMessageTag("price");
            tags[1] = CreateAlertMessageTag("volume");
            tags[2] = CreateAlertMessageTag("marketInfo");
            tags[3] = CreateAlertMessageTag("ownedQty");
            return common.system.MergeText(msg, tags);
        }
        private static common.myKeyValueItem CreateAlertMessageTag(string key)
        {
            return new common.myKeyValueItem( Consts.constTextMergeMarkerLEFT + key + Consts.constTextMergeMarkerRIGHT, Languages.Libs.GetString(key));
        }

        public static databases.baseDS.tradeAlertDataTable GetTradeAlertSummaryOfLogin()
        {
            DateTime lastAlertDate = DataAccess.Libs.GetLastAlertTime(commonClass.SysLibs.sysLoginCode);
            databases.baseDS.tradeAlertDataTable tradeAlertTbl = DataAccess.Libs.GetTradeAlert(lastAlertDate,lastAlertDate,
                                                                                               commonClass.SysLibs.sysLoginCode,
                                                                                               (byte)common.CommonTypes.CommonStatus.All);
            return MakeAlertSummary(tradeAlertTbl);
        }
        private class SummaryItem
        {
            public SummaryItem(string stockCode, DateTime onDate)
            {
                StockCode = stockCode;
                OnDate = onDate;
            }
            public string StockCode = "";
            public DateTime OnDate = common.Consts.constNullDate;
            public int Qty = 0;
        }
        public static databases.baseDS.tradeAlertDataTable MakeAlertSummary(databases.baseDS.tradeAlertDataTable tbl)
        {
            SummaryItem buyCount, sellCount;
            databases.baseDS.tradeAlertRow sumRow;
            databases.baseDS.tradeAlertDataTable sumTbl = new databases.baseDS.tradeAlertDataTable();
            sumTbl.DefaultView.Sort = sumTbl.onTimeColumn.ColumnName + "," + sumTbl.stockCodeColumn.ColumnName;
            DataRowView[] foundRows;
            common.DictionaryList buyCountList = new common.DictionaryList();
            common.DictionaryList sellCountList = new common.DictionaryList();

            object obj;
            //Sum
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                foundRows = sumTbl.DefaultView.FindRows(new object[] { tbl[idx].onTime.Date, tbl[idx].stockCode });
                if (foundRows.Length != 0)
                    sumRow = (databases.baseDS.tradeAlertRow)foundRows[0].Row;
                else
                {
                    sumRow = sumTbl.NewtradeAlertRow();
                    databases.AppLibs.InitData(sumRow);
                    sumRow.onTime = tbl[idx].onTime.Date;
                    sumRow.stockCode = tbl[idx].stockCode;
                    sumTbl.AddtradeAlertRow(sumRow);
                }
                AppTypes.TradeActions action = (AppTypes.TradeActions)tbl[idx].tradeAction;
                switch (action)
                {
                    case AppTypes.TradeActions.Buy:
                    case AppTypes.TradeActions.Accumulate:
                        obj = buyCountList.Find(sumRow.onTime.ToString() + sumRow.stockCode);
                        if (obj == null)
                            buyCount = new SummaryItem(sumRow.stockCode, sumRow.onTime);
                        else buyCount = (SummaryItem)obj;
                        buyCount.Qty++;
                        buyCountList.Add(sumRow.onTime.ToString() + sumRow.stockCode, buyCount);
                        break;
                    case AppTypes.TradeActions.Sell:
                    case AppTypes.TradeActions.ClearAll:
                        obj = sellCountList.Find(sumRow.onTime.ToString() + sumRow.stockCode);
                        if (obj == null)
                            sellCount = new SummaryItem(sumRow.stockCode, sumRow.onTime);
                        else sellCount = (SummaryItem)obj;
                        sellCount.Qty++;
                        sellCountList.Add(sumRow.onTime.Date.ToString() + sumRow.stockCode, sellCount);
                        break;
                }
            }
            //Make summary message
            for (int idx = 0; idx < sumTbl.Count; idx++)
            {
                sumTbl[idx].msg = "";
                obj = buyCountList.Find(sumTbl[idx].onTime.ToString() + sumTbl[idx].stockCode);
                if (obj != null)
                    sumTbl[idx].msg += (sumTbl[idx].msg.Trim() != "" ? " , " : "") + (obj as SummaryItem).Qty.ToString() + " " + Languages.Libs.GetString("buyAlert");

                obj = sellCountList.Find(sumTbl[idx].onTime.ToString() + sumTbl[idx].stockCode);
                if (obj != null)
                    sumTbl[idx].msg += (sumTbl[idx].msg.Trim() != "" ? " , " : "") + (obj as SummaryItem).Qty.ToString() + " " + Languages.Libs.GetString("sellAlert");
            }
            return sumTbl;
        }
    }
}
