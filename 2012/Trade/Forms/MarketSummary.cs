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
                
                openColumn.DefaultCellStyle.Format = commonTypes.Settings.sysMaskPrice;
                openColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
                closeColumn.DefaultCellStyle.Format = commonTypes.Settings.sysMaskPrice;
                closeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                valueColumn.DefaultCellStyle.Format = commonTypes.Settings.sysMaskPrice;
                valueColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                percentColumn.DefaultCellStyle.Format = commonTypes.Settings.sysMaskPercent;
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
            this.TitleLbl.Text = string.Format(Languages.Libs.GetString("welcomeMarketSummary"), commonClass.SysLibs.sysLoginDisplayName);
            this.introLbl.Text = Languages.Libs.GetString("softwareIntro");

            this.weeklyChangeLbl.Text = Languages.Libs.GetString("marketWeeklyChange");
            this.dailyChangeLbl.Text = Languages.Libs.GetString("marketDailyChange");

            this.codeColumn.HeaderText = Languages.Libs.GetString("code");
            this.openColumn.HeaderText = Languages.Libs.GetString("open");
            this.closeColumn.HeaderText = Languages.Libs.GetString("close");
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
            DrawLineChart(hnxChart, 0, true, "HNX-IDX", frDate, toDate, timeScaleCode);

            //DrawLineChart(hnxChart, 0, true, "HNX-IDX", frDate, toDate, timeScaleCode);
        }
        private void DrawLineChart(Chart chart, int chartSeriesNo,bool isShowVolume, string code, DateTime frDate, DateTime toDate, string timeScaleCode)
        {
          
            databases.baseDS.priceDataDataTable dataTbl = DataAccess.Libs.GetPriceData(code,timeScaleCode,frDate, toDate);
            decimal[] yValues = new decimal[dataTbl.Count];
            DateTime[] xValues = new DateTime[dataTbl.Count];
            decimal[] volValues = new decimal[dataTbl.Count];

            decimal min = decimal.MaxValue;
            decimal max = decimal.MinValue;
            for (int idx = 0; idx < dataTbl.Count; idx++)
            {
                yValues[idx] = dataTbl[idx].closePrice;
                xValues[idx] = dataTbl[idx].onDate;
                volValues[idx] = dataTbl[idx].volume / 100000;
                if (min > yValues[idx]) min = yValues[idx];
                if (max < yValues[idx]) max = yValues[idx];
            }            
            chart.Series[chartSeriesNo].Points.DataBindXY(xValues, yValues);
            chart.ChartAreas[0].AxisY.Minimum = (double)min - 0.1 * (double)min;
            chart.ChartAreas[0].AxisY.Maximum = (double)max + 0.1 * (double)max;
            if (isShowVolume)
            {
                chart.Series["Volume"].Points.DataBindXY(xValues, volValues);    
            }            
        }


        private void Market_TopBiggestChange()
        {
            //Weekly Market data for user's interested code
            databases.tmpDS.dataVarrianceDataTable tbl = DataAccess.Libs.GetTopPriceVarrianceWeeklyOfLoginUser(10);
            //If NONE get weekly data of all the market
            if (tbl.Count==0)  tbl = DataAccess.Libs.GetTopPriceVarrianceWeekly(10);
            decimal[] yValues = new decimal[tbl.Count];
            string[] xValues = new string[tbl.Count];
            StringCollection topCodes = new StringCollection();

            int displayChartCount = Math.Min(tbl.Count, 5);
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (idx < displayChartCount)
                {
                    yValues[idx] = tbl[idx].percent;
                    xValues[idx] = tbl[idx].code;
                }
                topCodes.Add(tbl[idx].code);
            }
            top10biggestChangeChart.Series[0].Points.DataBindXY(xValues, yValues);
            top10biggestChangeChart.Series[0].ChartType = SeriesChartType.Doughnut;

            
             for (int idx = 0; idx < top10biggestChangeChart.Series[0].Points.Count; idx++)
             {
                top10biggestChangeChart.Series[0].Points[idx].Label = xValues[idx] + common.Consts.constCRLF +  (yValues[idx]).ToString(commonTypes.Settings.sysMaskPercent + "%");
                 //top10biggestChangeChart.Series[0].Points[idx]["Exploded"] = "true";
                //top10biggestChangeChart.Series[0].Points[idx].Label = (yValues[idx]).ToString("##%");
             }
            // Set labels style
            top10biggestChangeChart.Series[0]["PieLabelStyle"] = "Inside";
            top10biggestChangeChart.Series[0].MarkerStyle = MarkerStyle.Circle;  

            // Set Doughnut radius percentage
            top10biggestChangeChart.Series[0]["DoughnutRadius"] = "90";

            //Daily Market data
            Market_DataDailyChange(topCodes);
        }
        private void Market_DataDailyChange(StringCollection codes)
        {
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
                varrianceRow.val1 = openPrice;
                varrianceRow.val2 = closePrice;
                varrianceRow.value = (closePrice - openPrice);
                varrianceRow.percent = ((closePrice-openPrice)/openPrice)*100;

                //DataRowView[] foundRows = alertView.FindRows(codes[idx]);
                //if (foundRows.Length > 0)
                //{
                //    varrianceRow.notes = (foundRows[0].Row as databases.baseDS.tradeAlertRow).msg;
                //}
                myTmpDS.dataVarriance.AdddataVarrianceRow(varrianceRow);
            }
        }

        #region event viewer
        private void MarketSummary_Resize(object sender, EventArgs e)
        {
            try
            {
                common.system.AutoFitGridColumn(dailyChangeGV);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        
        #endregion event viewer
    }
}
