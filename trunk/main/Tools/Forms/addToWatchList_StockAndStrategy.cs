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
    public partial class addToWatchList_StockAndStrategy : baseAddToWatchList
    {
        private data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
        private StringCollection myStrategyCodes = null;
        private string myStockCode = null;
        private AppTypes.TimeRanges myTimeRange = AppTypes.TimeRanges.All;

        public addToWatchList_StockAndStrategy()
        {
            InitializeComponent();
        }
        public static addToWatchList_StockAndStrategy GetForm(string formName)
        {
            string cacheKey = typeof(addToWatchList_StockAndStrategy).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            addToWatchList_StockAndStrategy form = (addToWatchList_StockAndStrategy)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new addToWatchList_StockAndStrategy();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        public void ShowForm(StringCollection strategyCodes, AppTypes.TimeRanges timeRange)
        {
            watchListLb.LoadData(sysLibs.sysLoginCode, false);
            this.myStrategyCodes = strategyCodes;
            this.myTimeRange = timeRange;
            this.ShowDialog();
        }
        protected override void SaveWatchList()
        {
            data.baseDS.portfolioDetailDataTable portfolioDataTbl = new data.baseDS.portfolioDetailDataTable();
            portfolioTbl.Clear();
            for (int portfolioIdx = 0; portfolioIdx < watchListLb.myCheckedValues.Count; portfolioIdx++)
            {
                data.baseDS.portfolioRow portfolioRow = dataLibs.FindAndCache(portfolioTbl, watchListLb.myCheckedValues[portfolioIdx]);
                if (portfolioRow == null) continue;
                portfolioDataTbl.Clear();
                application.dataLibs.LoadData(portfolioDataTbl, portfolioRow.code);
                data.baseDS.portfolioDetailRow dataRow;
                common.MultiValueString mvString = new common.MultiValueString();
                for (int idx = 0; idx < myStrategyCodes.Count; idx++)
                {
                    dataRow = portfolioDataTbl.FindByportfoliocodesubCode(portfolioRow.code, this.myStockCode, this.myStrategyCodes[idx]);
                    if (dataRow == null)
                    {
                        dataRow = portfolioDataTbl.NewportfolioDetailRow();
                        dataLibs.InitData(dataRow);
                        dataRow.portfolio = portfolioRow.code;
                        dataRow.code = this.myStockCode;
                        dataRow.subCode = this.myStrategyCodes[idx];
                        portfolioDataTbl.AddportfolioDetailRow(dataRow);
                    }
                    mvString.myFormatString = dataRow.data; 
                    //mvString.Add(this.myTimeRange.ToString());
                }
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
