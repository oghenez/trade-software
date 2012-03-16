using System;
using System.Collections.Generic;
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
        }
        public void RefreshData(bool force)
        {
            databases.tmpDS.dataVarrianceDataTable tbl = DataAccess.Libs.GetPriceVarrianceWeekly(5);
            decimal[] yValues = new decimal[tbl.Count];
            string[] xValues = new string[tbl.Count];
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                yValues[idx] = tbl[idx].percent;
                xValues[idx] = tbl[idx].code;
            }

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

    }
}
