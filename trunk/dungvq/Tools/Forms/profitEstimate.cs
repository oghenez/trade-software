using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using ZedGraph;

namespace Tools.Forms
{
    public partial class profitEstimate : common.forms.baseDialogForm
    {
        public profitEstimate()
        {
            InitializeComponent();
            dataGrid.DisableReadOnlyColumn = false;
            fShowChart = false;
            dataGrid.Location = new Point(0, 0);
        }
        private bool fShowChart
        {
            get { return chartPnl.isVisible; }
            set 
            {
                chartPnl.isVisible= value;
                //dataGrid.Height = this.ClientRectangle.Height - toolBoxPnl.Height - (value ? chartPnl.Height : 0)-5;
                if (value) ShowChart();
                FormResize();
            }
        }
        private Strategy.TradePoints myTradeAdvices = null;
        private application.Data myAnalysisData = null;

        public static profitEstimate GetForm(string formName)
        {
            string cacheKey = typeof(profitEstimate).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            profitEstimate form = (profitEstimate)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new profitEstimate();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        public void Init(application.Data data,Strategy.TradePoints advices)
        {
            this.myAnalysisData = data;
            this.myTradeAdvices = advices;
            ReLoad();
        }
        public void ReLoad()
        {
            if (myTradeAdvices == null)
            {
                common.system.ThrowException("No data found"); return;
            }
            EstimateAdvice(this.myAnalysisData, this.myTradeAdvices, new Strategy.Libs.EstimateOptions(),myTmpDS.tradeEstimate);
            DoFilter();
            fShowChart = fShowChart;
        }
        public void Export()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel(myTmpDS.tradeEstimate, saveFileDialog.FileName);
        }

        private void ShowChart()
        {
            data.tmpDS.tradeEstimateDataTable tbl = myTmpDS.tradeEstimate;
            chartPnl.ResetGraph();
            chartPnl.RemoveAllCurves();
            application.DataSeries xSeries = new DataSeries();
            application.DataSeries ySeries = new DataSeries();
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (!allTransactionMenuItem.Checked && tbl[idx].ignored) continue;
                ySeries.Add((double)tbl[idx].profit);
                xSeries.Add(tbl[idx].onDate.ToOADate());
            }

            //Handle bug in graph for curve with only on point ????
            if (ySeries.Count > 1)
            {
                CurveItem curveItem = AppLibs.PlotChartBar(chartPnl.myGraphPane, xSeries, ySeries, "",
                                                           Settings.sysChartVolumesColor, Settings.sysChartVolumesColor, 1);
                chartPnl.PlotGraph();
            }

        }
        private void DoFilter()
        {
            if (!allTransactionMenuItem.Checked)
                tradeEstimateSource.Filter = myTmpDS.tradeEstimate.ignoredColumn.ColumnName + "=0";
            else tradeEstimateSource.Filter = "";
            this.ShowReccount(tradeEstimateSource.Count);
        }
        private void FormResize()
        {
            dataGrid.Size = new Size(this.ClientRectangle.Width, this.ClientSize.Height - dataGrid.Location.Y-SystemInformation.CaptionHeight);
            chartPnl.Location = new Point(0, this.ClientSize.Height - chartPnl.Height);
            common.system.AutoFitGridColumn(dataGrid);
        }

        protected virtual void EstimateAdvice(application.Data data,
                                              Strategy.TradePoints advices, 
                                              Strategy.Libs.EstimateOptions options,
                                              data.tmpDS.tradeEstimateDataTable toTbl)
        {
            Strategy.Data.ClearCache();
            Strategy.Libs.EstimateTrading(data, advices, options, toTbl);
        }

        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }
        private void baseAdviceEstimate_myOnAccept(object sender,common.baseDialogEvent e)
        {
            try
            {
                ReLoad();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void baseAdviceEstimate_Resize(object sender, EventArgs e)
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
        
        private void baseAdviceEstimate_Load(object sender, EventArgs e)
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

        private void chartPnl_myOnShowStateChanged(object sender)
        {
            try
            {
                fShowChart = chartPnl.isExpanded;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void closeThisBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void allTransactionMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DoFilter();
                fShowChart = fShowChart;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void showChartMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fShowChart = true;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void exportMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Export();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void reloadMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReLoad();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}
