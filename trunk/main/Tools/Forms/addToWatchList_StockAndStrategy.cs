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
        private StringCollection myStrategyCodes = null;
        public addToWatchList_StockAndStrategy()
        {
            try
            {
                InitializeComponent();
                stockCodeEd.BackColor = watchListLb.BackColor;
                timeScaleCb.LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
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
        public void ShowForm(string stockCode,  StringCollection strategyCodes, AppTypes.TimeScale timeScale)
        {
            watchListLb.LoadData(sysLibs.sysLoginCode, false);
            this.myStrategyCodes = strategyCodes;
            this.stockCodeEd.Text = stockCode;
            this.timeScaleCb.myValue = timeScale;
            strategyLb.Items.Clear();
            for (int idx = 0; idx < strategyCodes.Count; idx++)
            {
                strategyLb.Items.Add(Strategy.Libs.GetMetaName(strategyCodes[idx]));
            }
            this.timeScaleCb.myValue = timeScale;
            this.ShowDialog();
        }
        protected override void SaveData()
        {
            common.MultiValueString mvString = new common.MultiValueString();
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            data.baseDS.portfolioDetailDataTable portfolioDataTbl = new data.baseDS.portfolioDetailDataTable();
            portfolioTbl.Clear();
            for (int portfolioIdx = 0; portfolioIdx < watchListLb.myCheckedValues.Count; portfolioIdx++)
            {
                data.baseDS.portfolioRow portfolioRow = dataLibs.FindAndCache(portfolioTbl, watchListLb.myCheckedValues[portfolioIdx]);
                if (portfolioRow == null) continue;
                mvString.myFormatString = portfolioRow.interestedStock;
                mvString.Add(stockCodeEd.Text);
                portfolioRow.interestedStock = mvString.myFormatString;

                portfolioDataTbl.Clear();
                application.dataLibs.LoadData(portfolioDataTbl, portfolioRow.code);
                data.baseDS.portfolioDetailRow dataRow;
                for (int idx = 0; idx < myStrategyCodes.Count; idx++)
                {
                    dataRow = portfolioDataTbl.FindByportfoliocodesubCode(portfolioRow.code, this.stockCodeEd.Text, this.myStrategyCodes[idx]);
                    if (dataRow == null)
                    {
                        dataRow = portfolioDataTbl.NewportfolioDetailRow();
                        dataLibs.InitData(dataRow);
                        dataRow.portfolio = portfolioRow.code;
                        dataRow.code = stockCodeEd.Text;
                        dataRow.subCode = this.myStrategyCodes[idx];
                        portfolioDataTbl.AddportfolioDetailRow(dataRow);
                    }
                    mvString.myFormatString = dataRow.data;
                    mvString.Add(timeScaleCb.myValue.Code);
                    dataRow.data = mvString.myFormatString;
                }
                dataLibs.UpdateData(portfolioRow);
                dataLibs.UpdateData(portfolioDataTbl);
            }
            common.system.ShowMessage("Data ware saved.");
        }
    }
}
