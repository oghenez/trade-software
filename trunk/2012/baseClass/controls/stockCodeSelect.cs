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
                codeGroupCb.LoadData(new cbStockSelection.Options[] { cbStockSelection.Options.All, cbStockSelection.Options.StockExchange, 
                                                                      cbStockSelection.Options.WatchList, cbStockSelection.Options.SysWatchList,
                                                                      cbStockSelection.Options.Sectors}); 
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

        /// <summary>
        /// Load Stock List depends on cbStockSelection.Options
        /// </summary>
        public override void LoadStockList()
        {
            DataView stockCodeView = null;
            common.myKeyValueExt item = (common.myKeyValueExt)codeGroupCb.SelectedItem;
            cbStockSelection.Options watchListType = (cbStockSelection.Options)byte.Parse(item.Attribute1);
            StringCollection stockCodeList = new StringCollection();
            string cacheKey = watchListType.ToString();
            object obj;
            switch (watchListType)
            {
                case cbStockSelection.Options.All:
                     stockCodeClb.myDataTbl = this.myStockCodeTbl;
                     break;
                
                case cbStockSelection.Options.StockExchange:
                     cacheKey = DataAccess.Libs.MakeCacheKey(this, cacheKey + "-" + item.Value);
                     obj = DataAccess.Libs.GetCache(cacheKey);
                     if (obj != null) stockCodeList = (obj as StringCollection);
                     else
                     {
                        stockCodeView = new DataView(myStockCodeTbl);
                        stockCodeView.Sort = myStockCodeTbl.codeColumn.ColumnName;
                        stockCodeView.RowFilter = myStockCodeTbl.stockExchangeColumn.ColumnName + "='" + item.Value + "'";
                        string codeColumnName = myStockCodeTbl.codeColumn.ColumnName;
                        for (int idx = 0; idx < stockCodeView.Count; idx++)
                            stockCodeList.Add(stockCodeView[idx][codeColumnName].ToString());
                     }
                     stockCodeClb.myItemValues = stockCodeList;
                     break;
                case cbStockSelection.Options.SysWatchList:
                case cbStockSelection.Options.WatchList:
                     StringCollection watchList = new StringCollection();
                     //All stock codes of  specified type ??
                     if (item.Value != "")
                     {
                        cacheKey += "-" + item.Value;
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
                     cacheKey = DataAccess.Libs.MakeCacheKey(this, cacheKey);
                     obj = DataAccess.Libs.GetCache(cacheKey);
                     if (obj != null) stockCodeList = (obj as StringCollection);
                     else
                     {
                        stockCodeList = common.system.List2Collection(DataAccess.Libs.GetStockList_ByWatchList(watchList));
                        DataAccess.Libs.AddCache(cacheKey, stockCodeList);
                     }
                     stockCodeClb.myItemValues = stockCodeList;
                     break;
                case cbStockSelection.Options.Sectors:
                     base.LoadStockList();
                     break;
            }
        }
        private void codeGroupCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            bizSectorTypesSelection.Enabled = (codeGroupCb.myValue == cbStockSelection.Options.Sectors);
            LoadStockList();
            selectAllChk.Checked = false;
            onlySeletedChk.Checked = false;
        }

        public void CheckStockCode(string code)
        {
            for (int i = 0; i < stockCodeClb.Items.Count; i++)
                if (stockCodeClb.Items[i].ToString().Contains(code))
                {
                    stockCodeClb.SetItemChecked(i, true);
                    break;
                }
        }
    }
}
