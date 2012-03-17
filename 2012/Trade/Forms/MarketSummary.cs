using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            //Market data
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

            //Chart and grid
            Market_WeeklyTopBiggestChange(xValues, yValues);
            Market_DataDailyChange(topCodes);
        }
        private void Market_WeeklyTopBiggestChange(string[] xValues,decimal[] yValues)
        {
            // Populate series data
            top10Chart.Series["Default"].Points.DataBindXY(xValues, yValues);

            // Set Doughnut chart type
            top10Chart.Series["Default"].ChartType = SeriesChartType.Pie;

            // Set labels style
            top10Chart.Series["Default"]["PieLabelStyle"] = "Inside";

            // Set Doughnut radius percentage
            top10Chart.Series["Default"]["DoughnutRadius"] = "99";

            // Explode data point with label "Italy"
            top10Chart.Series["Default"].Points[yValues.Length - 1]["Exploded"] = "true";

            // Enable 3D
            top10Chart.ChartAreas["Default"].Area3DStyle.Enable3D = true;

            // Set drawing style
            top10Chart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";
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
