using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using commonTypes;

namespace Trade.Forms
{
    public partial class MarketSummary : baseClass.forms.baseForm
    {
        public MarketSummary()
        {
            try
            {
                InitializeComponent();
                
                priceColumn.DefaultCellStyle.Format = "N" + common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskPrice);
                priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                percentColumn.DefaultCellStyle.Format = "N" + common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskPercent);
                percentColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("marketSummary");
            this.TitleLbl.Text = Languages.Libs.GetString("welcomeMarketSummary");
            this.introLbl.Text = Languages.Libs.GetString("softwareIntro");

            this.weeklyChangeLbl.Text = Languages.Libs.GetString("marketWeeklyChange");
            this.dailyChangeLbl.Text = Languages.Libs.GetString("marketDailyChange");

            this.codeColumn.HeaderText = Languages.Libs.GetString("code");
            this.priceColumn.HeaderText = Languages.Libs.GetString("price");
            this.alertNotesColumn.HeaderText = Languages.Libs.GetString("alert");
            dailyChangeGV.Refresh();
        }
        public void RefreshData(bool force)
        {
            Market_Indexes();
            Market_TopBiggestChange();
        }

        private void Market_Indexes()
        {
            DateTime toDate = DateTime.Now;
            DateTime frDate = toDate.AddMonths(-2);
            string timeScaleCode = AppTypes.TimeScaleTypeToCode(AppTypes.TimeScaleTypes.Day);
            DrawLineChart(vnIdxChart, 0, true, "VN-IDX", frDate, toDate, timeScaleCode);
            //DrawLineChart(vnIdxChart, 1, false, "VN30-IDX", frDate, toDate, timeScaleCode);

            //DrawLineChart(hnxChart, 0, true, "HNX-IDX", frDate, toDate, timeScaleCode);
        }

        private void DrawLineChart(Chart chart, int chartSeriesNo,bool isShowVolume, string code, DateTime frDate, DateTime toDate, string timeScaleCode)
        {
          
            databases.baseDS.priceDataDataTable vnidxTbl = DataAccess.Libs.GetPriceData(code,timeScaleCode,frDate, toDate);
            decimal[] yValues = new decimal[vnidxTbl.Count];
            DateTime[] xValues = new DateTime[vnidxTbl.Count];
            decimal[] volValues = new decimal[vnidxTbl.Count];
            for (int idx = 0; idx < vnidxTbl.Count; idx++)
            {
                yValues[idx] = vnidxTbl[idx].closePrice;
                xValues[idx] = vnidxTbl[idx].onDate;
                volValues[idx] = vnidxTbl[idx].volume/100000;
            }
            chart.Series[chartSeriesNo].Points.DataBindXY(xValues, yValues);
            if (isShowVolume)
            {
                chart.Series["Volume"].Points.DataBindXY(xValues, volValues);    
            }            
        }


        private void Market_TopBiggestChange()
        {
            //Weekly Market data
            databases.tmpDS.dataVarrianceDataTable tbl = DataAccess.Libs.GetTopPriceVarrianceWeekly(5);
            decimal[] yValues = new decimal[tbl.Count];
            string[] xValues = new string[tbl.Count];
            StringCollection topCodes = new StringCollection();
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                yValues[idx] = tbl[idx].percent;
                xValues[idx] = tbl[idx].code;
                topCodes.Add(tbl[idx].code);
            }
            top10biggestChangeChart.Series[0].Points.DataBindXY(xValues, yValues);

            //Daily Market data
            Market_DataDailyChange(topCodes);
        }
        private void Market_DataDailyChange(StringCollection codes)
        {
            databases.baseDS.tradeAlertDataTable alertTbl = AppLibs.GetTradeAlertSummaryOfLogin();
            if (alertTbl == null) return;
            DataView alertView = new DataView(alertTbl);
            alertView.Sort = alertTbl.stockCodeColumn.ColumnName;

            databases.baseDS.lastPriceDataRow lastPriceRowOpen, lastPriceRowClose; 
            databases.baseDS.lastPriceDataDataTable openTbl = DataAccess.Libs.myLastDataOpenPrice;
            databases.baseDS.lastPriceDataDataTable closeTbl = DataAccess.Libs.myLastDataClosePrice; 
            databases.tmpDS.dataVarrianceRow varrianceRow;
            myTmpDS.dataVarriance.Clear();
            for (int idx = 0; idx < codes.Count; idx++)
            {
                lastPriceRowOpen = openTbl.FindBystockCode(codes[idx]);
                lastPriceRowClose = closeTbl.FindBystockCode(codes[idx]);
                if (lastPriceRowOpen == null ||lastPriceRowClose == null) continue;
                decimal closePrice = lastPriceRowClose.value;
                decimal openPrice = lastPriceRowOpen.value;
                if (openPrice == 0 || closePrice == 0) continue;

                varrianceRow = myTmpDS.dataVarriance.NewdataVarrianceRow();
                databases.AppLibs.InitData(varrianceRow);
                varrianceRow.code = codes[idx];
                varrianceRow.value = closePrice;
                varrianceRow.percent = ((closePrice-openPrice)/openPrice)*100;

                DataRowView[] foundRows = alertView.FindRows(codes[idx]);
                if (foundRows.Length > 0)
                {
                    varrianceRow.notes = (foundRows[0].Row as databases.baseDS.tradeAlertRow).msg;
                }
                myTmpDS.dataVarriance.AdddataVarrianceRow(varrianceRow);
            }
        }

        #region event viewer
        private void MarketSummary_Resize(object sender, EventArgs e)
        {
            try
            {
                common.system.AutoFitGridColumn(dailyChangeGV, alertNotesColumn.Name);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        
        #endregion event viewer
    }
}
