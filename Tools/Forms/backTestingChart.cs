using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tools.Forms
{
    public partial class backTestingChart : common.forms.baseDialogForm
    {
        public backTestingChart()
        {
            InitializeComponent();
        }
        public void ShowChart(DataTable myChartDataTbl)
        {
            estimateChart.Series.Clear();
            estimateChart.DataSource = myChartDataTbl;
            for (int idx = 1; idx < myChartDataTbl.Columns.Count; idx++)
            {
                Series seri = new Series();
                seri.Name = myChartDataTbl.Columns[idx].ColumnName;
                seri.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                seri.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                seri.YValueMembers = myChartDataTbl.Columns[idx].ColumnName;
                seri.XValueMember = myChartDataTbl.Columns[0].ColumnName;
                seri.ChartType = SeriesChartType.Column;
                seri.IsXValueIndexed = true;
                estimateChart.Series.Add(seri);
            }
            estimateChart.DataBind();
            this.ShowForm();
        }
        private void FormResize()
        {
            estimateChart.Height = this.ClientRectangle.Height;
            estimateChart.Width = this.ClientRectangle.Width;
        }

        #region event handler
        private void Form_Resize(object sender, EventArgs e)
        {
            try
            {
                FormResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                FormResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}
