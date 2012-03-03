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

    }
}
