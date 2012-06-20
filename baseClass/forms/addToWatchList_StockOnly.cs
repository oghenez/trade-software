using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using commonClass;

namespace baseClass.Forms
{
    public partial class addToWatchList_StockOnly : baseAddToWatchList
    {
        private common.MultiValueString mvString = new common.MultiValueString();
        private StringCollection myStockCodes = null;

        public addToWatchList_StockOnly()
        {
            InitializeComponent();
            stockCodeEd.BackColor = watchListLb.BackColor;
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            codeLbl.Text = Languages.Libs.GetString("code");
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
            watchListLb.LoadData(commonClass.SysLibs.sysLoginCode, false);
            this.myStockCodes = stockCodes;
            this.stockCodeEd.Text = common.system.ToString(this.myStockCodes);
            this.ShowDialog();
        }
        protected override void SaveData()
        {
            databases.baseDS.portfolioDetailDataTable defaultStrategyTbl = DataAccess.Libs.GetPortfolioDetail_ByCode(DataAccess.Libs.GetPortfolio_DefaultStrategy().code);

            databases.baseDS.portfolioDetailDataTable portfolioDetailTbl;
            for (int portfolioIdx = 0; portfolioIdx < watchListLb.myCheckedValues.Count; portfolioIdx++)
            {
                databases.baseDS.portfolioRow portfolioRow = DataAccess.Libs.GetPortfolio_ByCode(watchListLb.myCheckedValues[portfolioIdx]);
                if (portfolioRow == null) continue;
                portfolioDetailTbl = DataAccess.Libs.GetPortfolioDetail_ByCode(portfolioRow.code);
                mvString.myFormatString = portfolioRow.interestedStock;
                for (int stockIdx = 0; stockIdx < myStockCodes.Count; stockIdx++)
                {
                    if (!mvString.Add(myStockCodes[stockIdx])) continue;
                    mvString.Add(myStockCodes[stockIdx]);
                    //Add default portfolio data
                    DeletePortfolioData(portfolioDetailTbl, portfolioRow.code, myStockCodes[stockIdx]);
                    databases.AppLibs.CopyPortfolioData(defaultStrategyTbl, portfolioDetailTbl, portfolioRow.code, myStockCodes[stockIdx]);
                }
                portfolioRow.interestedStock = mvString.myFormatString;
                DataAccess.Libs.UpdateData(portfolioRow);
                DataAccess.Libs.UpdateData(portfolioDetailTbl);
            }
            common.system.ShowMessage(Languages.Libs.GetString("dataSaved"));
        }
        private void DeletePortfolioData(databases.baseDS.portfolioDetailDataTable dataTbl, string portfolioCode,string code)
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
