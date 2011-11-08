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
    public partial class profitEstimate : baseClass.forms.baseDialogForm  
    {
        const int constProfitChartMarginBOTTOM = 40;
        const int constProfitChartMarginTOP = 5;

        public profitEstimate()
        {
            try
            {
                InitializeComponent();
                dataGrid.DisableReadOnlyColumn = false;
                IsShowChart = false;
                dataGrid.Location = new Point(0, 0);
                dataGrid.myFixedSizedColumns.Clear();
                dataGrid.myFixedSizedColumns.Add(ignoredColumn.Name);
                dataGrid.myFixedSizedColumns.Add(onDateColumn.Name);
                dataGrid.myFixedSizedColumns.Add(tradeActionColumn.Name);
                dataGrid.myFixedSizedColumns.Add(qtyColumn.Name);
                dataGrid.myFixedSizedColumns.Add(priceDataColumn.Name);


                mainContainer.BringToFront();
                mainContainer.Reset();
                mainContainer.Location = new Point(0, 0);
                mainContainer.AddChild(dataPnl, "data");
                mainContainer.AddChild(chartPnl, "chart");
                mainContainer.myPaneDimensionSpecs = new[,] { { 1, 10, 10 }}; // Display scale (data:chart) = 10:10
                mainContainer.ArrangeChildren();

                CreateContextMenu();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("estimation");
            //Menu
            MainMenuStrip.Text = language.GetString("estimation");
            allTransactionMenuItem.Text = language.GetString("allTransaction");
            showChartMenuItem.Text = language.GetString("showChart");
            reloadMenuItem.Text = language.GetString("reload");
            exportMenuItem.Text = language.GetString("export");

            //Grid
            onDateColumn.HeaderText = language.GetString("onDate");
            priceDataColumn.HeaderText = language.GetString("price");
            qtyColumn.HeaderText = language.GetString("qty");
            amountColumn.HeaderText = language.GetString("amount");
            cashAmtColumn.HeaderText = language.GetString("cashAmt");
            totalAmtColumn.HeaderText = language.GetString("totalAmt");
            feeAmtColumn.HeaderText = language.GetString("feeAmt");
            profitColumn.HeaderText = language.GetString("profit");
        }

        public static profitEstimate GetForm(string formName)
        {
            string cacheKey = typeof(profitEstimate).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            profitEstimate form = (profitEstimate)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new profitEstimate();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        public void Init(application.Data data, wsData.TradePoints advices)
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
            EstimateAdvice(this.myAnalysisData, this.myTradeAdvices, new application.wsData.EstimateOptions(), myTmpDS.tradeEstimate);
            DoFilter();
            PlotProfitChart();
        }
        public void Export()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel(myTmpDS.tradeEstimate, saveFileDialog.FileName);
        }

        public bool IsShowChart
        {
            get { return chartPnl.Visible; }
            set 
            {
                chartPnl.Visible= value;
                FormResize();
            }
        }
        public bool IsShowAllTransactions
        {
            get { return this.allTransactionMenuItem.Checked; }
            set 
            {
                this.allTransactionMenuItem.Checked = value; ;
            }
        }

        private wsData.TradePoints myTradeAdvices = null;
        private application.Data myAnalysisData = null;

        private void PlotProfitChart()
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
                chartPnl.myGraphObj.SetSeriesX(xSeries.Values, Charts.AxisType.DateAsOrdinal);
                chartPnl.myGraphObj.SetFont(application.Settings.sysChartFontSize);
                chartPnl.myGraphObj.ChartMarginTOP = constProfitChartMarginTOP;
                chartPnl.myGraphObj.ChartMarginBOTTOM = constProfitChartMarginBOTTOM;

                CurveItem curveItem = chartPnl.myGraphObj.AddCurveBar("profit", ySeries.Values, Settings.sysChartVolumesColor, Settings.sysChartVolumesColor, 1);
                chartPnl.myGraphObj.DefaultViewport();
                chartPnl.PlotGraph();
            }

        }
        private void DoFilter()
        {
            if (!this.IsShowAllTransactions)
                tradeEstimateSource.Filter = myTmpDS.tradeEstimate.ignoredColumn.ColumnName + "=0";
            else tradeEstimateSource.Filter = "";
            this.ShowReccount(tradeEstimateSource.Count);
        }
        private void FormResize()
        {
            mainContainer.Size = new Size(this.ClientRectangle.Width, this.ClientSize.Height);
            mainContainer.Refresh();
            dataGrid.Size = new Size(this.dataPnl.Width, this.dataPnl.Height - 10);
            dataGrid.AutoFitGridColumn();
        }

        private void CreateContextMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(allTransactionMenuItem.Text);
            menuItem.Click += new System.EventHandler(allTransactionMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(showChartMenuItem.Text);
            menuItem.Click += new System.EventHandler(showChartMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(exportMenuItem.Text);
            menuItem.Click += new System.EventHandler(exportMenuItem_Click);

            dataGrid.ContextMenuStrip = contextMenuStrip;
        }

        /// <summary>
        /// Estimate trade points and set tradepoint's [isValid] property to mark whether a tradepoint is valid or not.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="tradePoints"></param>
        public void CheckTradepoints(application.Data data, wsData.TradePoints tradePoints)
        {
            myTmpDS.tradeEstimate.Clear();
            EstimateAdvice(data, tradePoints, new application.wsData.EstimateOptions(), myTmpDS.tradeEstimate);
            for (int idx = 0; idx < tradePoints.Count; idx++)
            {
                (tradePoints[idx] as wsData.TradePointInfo).isValid = !myTmpDS.tradeEstimate[idx].ignored; 
            }
            this.IsShowAllTransactions = false;
            DoFilter();
            PlotProfitChart();
        }

        protected virtual void EstimateAdvice(application.Data data, wsData.TradePoints advices, wsData.EstimateOptions options,
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
                this.ShowMessage("");
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

        private bool chartPnl_myOnClosing(object sender)
        {
            chartPnl.Visible = false;
            FormResize();
            return true;
        }
        private void allTransactionMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IsShowAllTransactions = !IsShowAllTransactions;
                DoFilter();
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
                IsShowChart = true;
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
