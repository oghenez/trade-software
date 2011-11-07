using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using application;

namespace baseClass.controls
{
    public partial class stockCodeSelect : stockCodeSelectBySector
    {
        public stockCodeSelect()
        {
            try
            {
                InitializeComponent();
                codeGroupCb.LoadData();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }            
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            codeGroupCb.SetLanguage();
        }

        public override void LoadStockList()
        {
            DataView stockCodeView = null;
            common.myKeyValueExt item = (common.myKeyValueExt)codeGroupCb.SelectedItem;
            cbStockSelection.Options watchListType = (cbStockSelection.Options)byte.Parse(item.Attribute1);
            StringCollection stocCodeList = new StringCollection();
            switch (watchListType)
            {
                case cbStockSelection.Options.All:
                    stockCodeClb.myDataTbl = this.myStockCodeTbl;
                    break;
                case cbStockSelection.Options.StockExchange:
                    stockCodeView = new DataView(myStockCodeTbl);
                    stockCodeView.Sort = myStockCodeTbl.codeColumn.ColumnName;
                    stockCodeView.RowFilter = myStockCodeTbl.stockExchangeColumn.ColumnName + "='" + item.Value + "'";
                    for (int idx = 0; idx < stockCodeView.Count; idx++)
                    {
                        stocCodeList.Add(stockCodeView[idx][myStockCodeTbl.codeColumn.ColumnName].ToString());
                    }
                    stockCodeClb.myItemValues = stocCodeList;
                    break;
                case cbStockSelection.Options.SysWatchList:
                case cbStockSelection.Options.WatchList:
                    StringCollection watchList = new StringCollection();
                    //All stock codes of  specified type ??
                    if (item.Value != "")
                    {
                        watchList.Add(item.Value);
                    }
                    else
                    {
                        for (int idx = 0; idx < codeGroupCb.Items.Count; idx++)
                        {
                            common.myKeyValueExt tmpItem = (common.myKeyValueExt)codeGroupCb.Items[idx];
                            if (watchListType != (cbStockSelection.Options)byte.Parse(tmpItem.Attribute1) || (tmpItem.Value == "")) continue;
                            watchList.Add(tmpItem.Value);
                        }
                    }
                    data.tmpDS.stockCodeDataTable tbl = new data.tmpDS.stockCodeDataTable();
                    dataLibs.LoadStockCode_ByWatchList(tbl, watchList);
                    stockCodeView = new DataView(tbl);
                    stockCodeView.Sort = myStockCodeTbl.codeColumn.ColumnName;
                    for (int idx = 0; idx < stockCodeView.Count; idx++)
                    {
                        stocCodeList.Add(stockCodeView[idx][myStockCodeTbl.codeColumn.ColumnName].ToString());
                    }
                    stockCodeClb.myItemValues = stocCodeList;
                    break;
                case cbStockSelection.Options.Others:
                    base.LoadStockList();
                    break;
            }
        }

        private void codeGroupCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            bizSectorTypesSelection.Enabled = (codeGroupCb.myValue == cbStockSelection.Options.Others);
            LoadStockList();
            selectAllChk.Checked = false;
            onlySeletedChk.Checked = false;
        }
    }
}
