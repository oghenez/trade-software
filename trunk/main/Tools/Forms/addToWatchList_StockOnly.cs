using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace Tools.Forms
{
    public partial class addToWatchList_StockOnly : baseAddToWatchList
    {
        private common.MultiValueString mvString = new common.MultiValueString();
        private data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
        private StringCollection myStockCodes = null;

        public addToWatchList_StockOnly()
        {
            InitializeComponent();
            stockCodeEd.BackColor = watchListLb.BackColor;
        }
        public static addToWatchList_StockOnly GetForm(string formName)
        {
            string cacheKey = typeof(addToWatchList_StockOnly).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            addToWatchList_StockOnly form = (addToWatchList_StockOnly)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new addToWatchList_StockOnly();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        public void ShowForm(StringCollection stockCodes)
        {
            watchListLb.LoadData(sysLibs.sysLoginCode, false);
            this.myStockCodes = stockCodes;
            this.stockCodeEd.Text = common.system.ToString(this.myStockCodes);
            this.ShowDialog();
        }
        protected override void SaveData()
        {
            data.baseDS.portfolioDetailDataTable defaPortfolioDataTbl = application.dataLibs.GetDefaultPortfolioData();
            data.baseDS.portfolioDetailDataTable portfolioDataTbl = new data.baseDS.portfolioDetailDataTable();
            portfolioTbl.Clear();
            for (int portfolioIdx = 0; portfolioIdx < watchListLb.myCheckedValues.Count; portfolioIdx++)
            {
                data.baseDS.portfolioRow portfolioRow = dataLibs.FindAndCache(portfolioTbl, watchListLb.myCheckedValues[portfolioIdx]);
                if (portfolioRow == null) continue;
                portfolioDataTbl.Clear();
                application.dataLibs.LoadData(portfolioDataTbl, portfolioRow.code);
                mvString.myFormatString = portfolioRow.interestedStock;
                for (int stockIdx = 0; stockIdx < myStockCodes.Count; stockIdx++)
                {
                    if (!mvString.Add(myStockCodes[stockIdx])) continue;
                    mvString.Add(myStockCodes[stockIdx]);
                    //Add default portfolio data
                    DeletePortfolioData(portfolioDataTbl, portfolioRow.code, myStockCodes[stockIdx]);
                    application.dataLibs.CopyPortfolioData(defaPortfolioDataTbl, portfolioDataTbl, portfolioRow.code, myStockCodes[stockIdx]);
                }
                portfolioRow.interestedStock = mvString.myFormatString;
                dataLibs.UpdateData(portfolioRow);
                dataLibs.UpdateData(portfolioDataTbl);
            }
            common.system.ShowMessage("Data ware saved.");
        }
        private void DeletePortfolioData(data.baseDS.portfolioDetailDataTable dataTbl, string portfolioCode,string code)
        {
            for (int idx = 0; idx < dataTbl.Count; idx++)
            {
                if (dataTbl[idx].RowState== DataRowState.Deleted) continue;
                if ( (dataTbl[idx].portfolio==portfolioCode) && (dataTbl[idx].code==code) ) 
                    dataTbl[idx].Delete();
            }
        }
    }
}
