using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace test
{
    public partial class testMarketSummary : baseClass.forms.baseForm
    {
        public testMarketSummary()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {
            try
            {
                databases.tmpDS.dataVarrianceDataTable tbl = DataAccess.Libs.GetPriceVarrianceWeekly(4);
                decimal[] yValues = new decimal[tbl.Count];
                string[] xValues = new string[tbl.Count];
                for (int idx = 0; idx < tbl.Count; idx++)
                {
                    yValues[idx] = tbl[idx].percent;
                    xValues[idx] = tbl[idx].code;
                }

                // Populate series data
                vnIdxChart.Series["Default"].Points.DataBindXY(xValues, yValues);

                // Set Doughnut chart type
                vnIdxChart.Series["Default"].ChartType = SeriesChartType.Pie;

                // Set labels style
                vnIdxChart.Series["Default"]["PieLabelStyle"] = "Inside";

                // Set Doughnut radius percentage
                vnIdxChart.Series["Default"]["DoughnutRadius"] = "99";

                // Explode data point with label "Italy"
                vnIdxChart.Series["Default"].Points[yValues.Length - 1]["Exploded"] = "true";

                // Enable 3D
                vnIdxChart.ChartAreas["Default"].Area3DStyle.Enable3D = true;

                // Set drawing style
                vnIdxChart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
