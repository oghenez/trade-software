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
    public partial class addToWatchList_StockAndStrategy : baseAddToWatchList
    {
        private StringCollection myStrategyCodes = null;
        public addToWatchList_StockAndStrategy()
        {
            try
            {
                InitializeComponent();
                codeEd.BackColor = watchListLb.BackColor;
                timeScaleCb.LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            codeLbl.Text = Languages.Libs.GetString("code");
            timeScaleLbl.Text = Languages.Libs.GetString("timeScale");
            strategyLbl.Text = Languages.Libs.GetString("strategy");

            timeScaleCb.SetLanguage();
            strategyLb.SetLanguage();
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
            watchListLb.LoadData(commonClass.SysLibs.sysLoginCode, false);
            this.myStrategyCodes = strategyCodes;
            this.codeEd.Text = stockCode;
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
            data.baseDS.portfolioDetailDataTable portfolioDataTbl;
            portfolioTbl.Clear();
            for (int portfolioIdx = 0; portfolioIdx < watchListLb.myCheckedValues.Count; portfolioIdx++)
            {
                data.baseDS.portfolioRow portfolioRow = DataAccess.Libs.GetPortfolio_ByCode(watchListLb.myCheckedValues[portfolioIdx]);
                if (portfolioRow == null) continue;
                mvString.myFormatString = portfolioRow.interestedStock;
                mvString.Add(codeEd.Text);
                portfolioRow.interestedStock = mvString.myFormatString;

                portfolioDataTbl = DataAccess.Libs.GetPortfolioDetail_ByCode(portfolioRow.code);
                data.baseDS.portfolioDetailRow dataRow;
                for (int idx = 0; idx < myStrategyCodes.Count; idx++)
                {
                    dataRow = portfolioDataTbl.FindByportfoliocodesubCode(portfolioRow.code, this.codeEd.Text, this.myStrategyCodes[idx]);
                    if (dataRow == null)
                    {
                        dataRow = portfolioDataTbl.NewportfolioDetailRow();
                        commonClass.AppLibs.InitData(dataRow);
                        dataRow.portfolio = portfolioRow.code;
                        dataRow.code = codeEd.Text;
                        dataRow.subCode = this.myStrategyCodes[idx];
                        portfolioDataTbl.AddportfolioDetailRow(dataRow);
                    }
                    mvString.myFormatString = dataRow.data;
                    mvString.Add(timeScaleCb.myValue.Code);
                    dataRow.data = mvString.myFormatString;
                }
                DataAccess.Libs.UpdateData(portfolioRow);
                DataAccess.Libs.UpdateData(portfolioDataTbl);
            }
            common.system.ShowMessage(Languages.Libs.GetString("dataSaved"));
        }
    }
}
