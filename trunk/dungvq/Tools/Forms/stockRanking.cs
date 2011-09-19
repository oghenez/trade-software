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
    public partial class stockRanking : baseTesting
    {
        public stockRanking()
        {
            try
            {
                InitializeComponent();
                watchListCb.LoadData(application.sysLibs.sysLoginCode, true);
                stockCodeSelect.LoadData();
                stockCodeSelect.LockEdit(false);
                stockCodeSelect.Enabled = false;

                strategyClb.LoadData(AppTypes.StrategyTypes.Strategy, true, false);
                AppTypes.TimeRanges[] timeRanges = new AppTypes.TimeRanges[]
                {
                    AppTypes.TimeRanges.M1, AppTypes.TimeRanges.M3,AppTypes.TimeRanges.M6,
                    AppTypes.TimeRanges.Y1,AppTypes.TimeRanges.Y2,AppTypes.TimeRanges.Y3,AppTypes.TimeRanges.Y4,AppTypes.TimeRanges.Y5,
                };
                timeRangeLb.LoadData(timeRanges);
                cbTimeScale.LoadData();

                stockCodeOptionCb.SelectedIndex = 0;
                stockCodeOptionCb_SelectionChangeCommitted(null, null);

                optionPnl.Location = new Point(0, 0);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public static stockRanking GetForm(string formName)
        {
            string cacheKey = typeof(stockRanking).FullName + (formName != null && formName.Trim() == "" ? "-" + formName.Trim() : "");
            stockRanking form = (stockRanking)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new Forms.stockRanking();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        public bool IsFullScreen
        {
            get{ return this.myFormMode ==formMode.DataOnly;}
            set
            { 
                if (value) this.myFormMode = formMode.DataOnly;
                else this.myFormMode = formMode.OptionWithData;
            }
        }
        public void ExportResult()
        {
            //if (resultDataGrid.DataSource == null)
            //{
            //    common.system.ShowErrorMessage("Không có dữ liệu.");
            //    return;
            //}
            //if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            //common.Export.ExportToExcel((DataTable)resultDataGrid.DataSource, saveFileDialog.FileName);
        }
        public void Execute()
        {
            this.ShowMessage("");
            try
            {
                if (!DataValidate()) return;
                progressBar.Visible = true;
                DateTime startTime = DateTime.Now;
                DoRanking();
                DateTime endTime = DateTime.Now;
                this.myFormMode = formMode.OptionWithData;
                FormResize();
                this.ShowMessage(" Hòan tất : " + common.dateTimeLibs.TimeSpan2String(endTime.Subtract(startTime)));
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }
        
        private enum formMode : byte { OptionOnly = 0, OptionWithData = 1, DataOnly = 2 };
        private formMode myFormMode
        {
            get
            {
                if (resultTab.Visible)
                {
                    if (optionPnl.Visible) return formMode.OptionWithData;
                    return formMode.DataOnly;
                }
                return formMode.OptionOnly;
            }
            set
            {
                switch (value)
                {
                    case formMode.DataOnly:
                        resultTab.Visible = true; optionPnl.Visible = false;
                        break;
                    case formMode.OptionOnly: resultTab.Visible = false; optionPnl.Visible = true; break;
                    case formMode.OptionWithData:
                        resultTab.Visible = true; optionPnl.Visible = true;
                        this.Width = optionPnl.Width + resultTab.Width;
                        break;
                }
                FormResize();
            }
        }

        private common.control.baseDataGridView CurrentDataGridView
        {
            get
            {
                for (int idx = 0; idx < resultTab.SelectedTab.Controls.Count; idx++)
                {
                    if (resultTab.SelectedTab.Controls[idx].GetType() == typeof(common.control.baseDataGridView))
                        return (common.control.baseDataGridView)resultTab.SelectedTab.Controls[idx];
                }
                return null;
            }
        }
        private static void SetDataGrid(common.control.baseDataGridView grid, DataTable tbl)
        {
            grid.DataSource = tbl;

            DataGridViewCellStyle amountCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            amountCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            amountCellStyle.Format = "N" + Settings.sysPrecisionLocal.ToString();
            amountCellStyle.NullValue = null;

            grid.Columns.Clear();
            for (int idx = 0; idx < tbl.Columns.Count; idx++)
            {
                DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                grid.Columns.Add(column);
                column.DataPropertyName = tbl.Columns[idx].ColumnName;
                if (idx == 0)
                {
                    column.HeaderText = "Chiến lược";
                    column.Width = 100;
                    column.Frozen = true;
                }
                else
                {
                    column.HeaderText = tbl.Columns[idx].Caption;
                    column.Width = 90;
                    column.DefaultCellStyle = amountCellStyle;
                }
                column.Name = idx.ToString();
            }
            AdjustTestGridSize(grid);
        }
        private void CreateContextMenu(common.control.baseDataGridView gridView)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(openMenuItem.Text);
            menuItem.Click += new System.EventHandler(openMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(profitEstimateMenu.Text);
            menuItem.Click += new System.EventHandler(profitEstimateMenu_Click);

            //menuItem = contextMenuStrip.Items.Add(addToWatchListMenuItem.Text);
            //menuItem.Click += new System.EventHandler(addToWatchListMenuItem_Click);

            gridView.ContextMenuStrip = contextMenuStrip;
        }

        private static void AdjustTestGridSize(DataGridView grid)
        {
            if (grid.Columns.Count == 0) return;
            int maxVisibleCount = grid.Width / 90;
            if (grid.Columns.Count < maxVisibleCount) common.system.AutoFitGridColumn(grid);
            else
            {
                for (int idx = 1; idx < grid.Columns.Count; idx++) grid.Columns[idx].Width = 90;
            }
        }
        private static DataTable CreateDataTable(StringCollection timeRangeList,StringCollection strategyList)
        {
            // Define the new datatable
            DataTable tbl = new DataTable();

            // Define columns
            DataColumn col = new DataColumn("item");
            tbl.Columns.Add(col);
            for (int idx = 0; idx < timeRangeList.Count; idx++)
            {
                string colName = timeRangeList[idx];
                col = new DataColumn(colName, typeof(Decimal));
                col.Caption = AppTypes.Type2Text(AppTypes.TimeRangeFromCode(timeRangeList[idx]));
                tbl.Columns.Add(col);
            }
            for (int rowId = 0; rowId < strategyList.Count; rowId++)
            {
                tbl.Rows.Add(strategyList[rowId]);
            }
            return tbl;
        }

        private void FormResize()
        {
            switch (this.myFormMode)
            {
                case formMode.OptionOnly:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;
                    strategyClb.Height = optionPnl.Height - strategyClb.Location.Y;
                    this.Width = optionPnl.Width+5;
                    break;
                case formMode.DataOnly:
                    resultTab.Location = new Point(0,0);
                    resultTab.Width = this.ClientRectangle.Width - resultTab.Location.X;
                    resultTab.Height = this.ClientRectangle.Height - resultTab.Location.Y - SystemInformation.CaptionHeight - 3;
                    break;
                case formMode.OptionWithData:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;
                    strategyClb.Height = optionPnl.Height - strategyClb.Location.Y;

                    resultTab.Location = new Point(optionPnl.Location.X + optionPnl.Width, 0);
                    resultTab.Width = this.ClientRectangle.Width - resultTab.Location.X;
                    resultTab.Height = this.ClientRectangle.Height - resultTab.Location.Y - SystemInformation.CaptionHeight - 3;
                    break;
            }

            DataPartResize();
            optionPnl.BringToFront();
            resultTab.BringToFront();
        }
        private void DataPartResize()
        {
            //AdjustTestGridSize(resultDataGrid);
        }

        private bool DataValidate()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.stockCodeSelect.Enabled && this.stockCodeSelect.myCheckedValues.Count == 0)
            {
                NotifyError(stockCodeLbl);
                retVal = false;
            }
            if (this.strategyClb.myCheckedValues.Count == 0)
            {
                NotifyError(strategyLbl);
                retVal = false;
            }
            if (this.timeRangeLb.Enabled && this.timeRangeLb.myCheckedValues.Count == 0)
            {
                NotifyError(allTimeRangeChk);
                retVal = false;
            }
            return retVal;
        }

        private StringCollection StockCodeList()
        {
            StringCollection stockCodeList;
            if (stockCodeSelect.Enabled) stockCodeList = stockCodeSelect.myCheckedValues;
            else
            {
                stockCodeList = new StringCollection();
                //Load stocks in portfolio
                data.baseDS.stockCodeDataTable myStockCodeTbl = new data.baseDS.stockCodeDataTable();
                StringCollection watchList = common.system.List2Collection(watchListCb.GetValues());
                switch (watchListCb.WatchType)
                {
                    case AppTypes.PortfolioTypes.Portfolio:
                        dataLibs.LoadStockCode_ByPortfolios(myStockCodeTbl, watchList);
                        break;
                    default:
                        dataLibs.LoadStockCode_ByWatchList(myStockCodeTbl, watchList);
                        break;
                }

                DataView myStockView = new DataView(myStockCodeTbl);
                data.baseDS.stockCodeRow stockRow;
                myStockView.Sort = myStockCodeTbl.codeColumn.ColumnName + "," + myStockCodeTbl.stockExchangeColumn.ColumnName;
                for (int idx1 = 0; idx1 < myStockView.Count; idx1++)
                {
                    stockRow = (data.baseDS.stockCodeRow)myStockView[idx1].Row;
                    //Ignore duplicate stocks
                    if (stockCodeList.Contains(stockRow.code)) continue;
                    stockCodeList.Add(stockRow.code);
                }
            }
            return stockCodeList;
        }

        private void DoRanking()
        {
            this.myValueType = ValueTypes.Amount;
            this.Amount2PercentDenominator = application.Settings.sysStockTotalCapAmt;

            resultTab.TabPages.Clear();
            StringCollection stockCodeList = StockCodeList();
            StringCollection strategyList = strategyClb.myCheckedValues;
            StringCollection timeRangeList = timeRangeLb.myCheckedValues;
            progressBar.Value = 0; progressBar.Minimum = 0; progressBar.Maximum = stockCodeList.Count * timeRangeList.Count;
            for (int stockCodeId = 0; stockCodeId < stockCodeList.Count; stockCodeId++)
            {
                string stockCode = stockCodeList[stockCodeId].ToString();
                DataTable testRetsultTbl = CreateDataTable(timeRangeList, strategyList);
                common.control.baseDataGridView resultGrid = CreateResultGrid(stockCode, testRetsultTbl);

                for (int colId = 0; colId < timeRangeList.Count; colId++)
                {
                    AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(timeRangeList[colId]);
                    decimal profit = 0;

                    application.Data analysisData = new application.Data(timeRange, cbTimeScale.myValue, stockCode);
                    for (int rowId = 0; rowId < strategyList.Count; rowId++)
                    {
                        profit = 0;
                        //Analysis cached data so we MUST clear cache to ensure the system run correctly
                        Strategy.Data.ClearCache();
                        Strategy.TradePoints advices = Strategy.Libs.Analysis(analysisData, strategyList[rowId]);
                        if (advices != null)
                        {
                            myTmpDS.tradeEstimate.Clear();
                            Strategy.Libs.EstimateTrading(analysisData, advices, new Strategy.Libs.EstimateOptions(), myTmpDS.tradeEstimate);
                            profit = (myTmpDS.tradeEstimate.Count == 0 ? 0 : profit = myTmpDS.tradeEstimate[myTmpDS.tradeEstimate.Count - 1].profit);
                        }
                        testRetsultTbl.Rows[rowId][colId + 1] = profit;
                    }
                    progressBar.Value++;
                    Application.DoEvents();
                }
            }
            FormResize();
        }

        private common.control.baseDataGridView CreateResultGrid(string stockCode, DataTable testRetsultTbl)
        {
            common.control.baseDataGridView dataGridView = new common.control.baseDataGridView();
            resultTab.TabPages.Add(stockCode, stockCode);
            TabPage page = resultTab.TabPages[stockCode];
            page.Controls.Add(dataGridView);
            dataGridView.Location = new Point(0,0);
            dataGridView.Size = new Size(page.Width, page.Height);
            dataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ReadOnly = true;
            dataGridView.DisableReadOnlyColumn = false;
            SetDataGrid(dataGridView, testRetsultTbl);
            CreateContextMenu(dataGridView);
            return dataGridView;
        }

        private void Amount2Percent(common.control.baseDataGridView dataGrid)
        {
            DataTable dataTbl = (DataTable)dataGrid.DataSource;
            decimal val = 0;
            for (int rowId = 0; rowId < dataTbl.Rows.Count; rowId++)
            {
                for (int colId = 1; colId < dataTbl.Columns.Count; colId++)
                {
                    if (!decimal.TryParse(dataTbl.Rows[rowId][colId].ToString(), out val)) continue;
                    dataTbl.Rows[rowId][colId] = (val / this.Amount2PercentDenominator) * 100;
                }
            }
        }
        private void Percent2Amount(common.control.baseDataGridView dataGrid)
        {
            DataTable dataTbl = (DataTable)dataGrid.DataSource;
            decimal val = 0;
            for (int rowId = 0; rowId < dataTbl.Rows.Count; rowId++)
            {
                for (int colId = 1; colId < dataTbl.Columns.Count; colId++)
                {
                    if (!decimal.TryParse(dataTbl.Rows[rowId][colId].ToString(), out val)) continue;
                    dataTbl.Rows[rowId][colId] = (val * this.Amount2PercentDenominator) / 100;
                }
            }
        }

        protected override void Amount2Percent()
        {
            if (this.Amount2PercentDenominator == 0) return;
            for (int tabId = 0; tabId < resultTab.TabPages.Count; tabId++)
            {
                for (int pageId = 0; pageId < resultTab.TabPages[tabId].Controls.Count; pageId++)
                {
                    if (resultTab.TabPages[tabId].Controls[pageId].GetType() != typeof(common.control.baseDataGridView)) continue;
                    Amount2Percent((common.control.baseDataGridView)resultTab.TabPages[tabId].Controls[pageId]);
                    break;
                }
            }
        }
        protected override void Percent2Amount()
        {
            if (this.Amount2PercentDenominator == 0) return;
            for (int tabId = 0; tabId < resultTab.TabPages.Count; tabId++)
            {
                for (int pageId = 0; pageId < resultTab.TabPages[tabId].Controls.Count; pageId++)
                {
                    if (resultTab.TabPages[tabId].Controls[pageId].GetType() != typeof(common.control.baseDataGridView)) continue;
                    Percent2Amount((common.control.baseDataGridView)resultTab.TabPages[tabId].Controls[pageId]);
                    break;
                }
            }
        }

        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.myFormMode = formMode.OptionOnly;
                FormResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                common.control.baseDataGridView resultDataGrid = this.CurrentDataGridView;
                if (resultDataGrid == null) return;
                string stockCode = resultTab.SelectedTab.Name;  

                if (resultDataGrid.CurrentRow == null) return;
                AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(resultDataGrid.Columns[e.ColumnIndex].DataPropertyName);
                data.baseDS.stockCodeRow stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                if (stockCodeRow == null) return;

                string strategyCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                ShowTradeTransactions(stockCodeRow, strategyCode, timeRange,cbTimeScale.myValue);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void form_Resize(object sender, EventArgs e)
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
       
        private void exportResultMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExportResult();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void runMenuItem_Click(object sender, EventArgs e)
        {
            Execute();
        }
        private void fullViewMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IsFullScreen = !IsFullScreen;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                common.control.baseDataGridView resultDataGrid = this.CurrentDataGridView;
                if (resultDataGrid == null) return;

                string stockCode = resultTab.SelectedTab.Name;  
                data.baseDS.stockCodeRow stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                if (stockCodeRow != null) return;

                AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(resultDataGrid.Columns[resultDataGrid.ColumnCount-1].Name);
                ShowStock(stockCodeRow, timeRange, cbTimeScale.myValue);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void addToWatchListMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //common.control.baseDataGridView resultDataGrid = this.CurrentDataGridView;
                //if (resultDataGrid == null) return;

                //string stockCode = resultTab.SelectedTab.Name;  

                //StringCollection stockCodes = new StringCollection();
                //if (resultDataGrid.SelectedRows.Count > 0)
                //{
                //    for (int idx = 0; idx < resultDataGrid.SelectedRows.Count; idx++)
                //        stockCodes.Add(resultDataGrid.SelectedRows[idx].Cells[0].Value.ToString());
                //}
                //else
                //{
                //    if (resultDataGrid.CurrentRow != null)
                //        stockCodes.Add(resultDataGrid.CurrentRow.Cells[0].Value.ToString());
                //}
                //if (stockCodes.Count > 0) this.AddStockToWatchList(stockCodes);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void profitEstimateMenu_Click(object sender, EventArgs e)
        {
            try
            {
                common.control.baseDataGridView resultDataGrid = this.CurrentDataGridView;
                if (resultDataGrid == null) return;

                string stockCode = resultTab.SelectedTab.Name;  
                string strategyCode = "";
                data.baseDS.stockCodeRow stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                if (stockCodeRow == null) return;

                if (resultDataGrid.SelectedRows.Count > 0)
                {
                    for (int rowId = 0; rowId < resultDataGrid.SelectedRows.Count; rowId++)
                    {
                        strategyCode = resultDataGrid.SelectedRows[rowId].Cells[0].Value.ToString();
                        for (int idx = 1; idx < resultDataGrid.ColumnCount; idx++)
                        {
                            AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(resultDataGrid.Columns[idx].DataPropertyName);
                            ShowTradeTransactions(stockCodeRow, strategyCode, timeRange, cbTimeScale.myValue);
                        }
                    }
                }
                else
                {
                    if (resultDataGrid.CurrentRow != null)
                    {
                        strategyCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                        for (int idx = 1; idx < resultDataGrid.ColumnCount; idx++)
                        {
                            AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(resultDataGrid.Columns[idx].DataPropertyName);
                            ShowTradeTransactions(stockCodeRow, strategyCode, timeRange, cbTimeScale.myValue);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void allTimeRangeChk_CheckedChanged(object sender, EventArgs e)
        {
            timeRangeLb.CheckAll(allTimeRangeChk.Checked);
        }
        
        private void stockCodeOptionCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                switch (stockCodeOptionCb.SelectedIndex)
                {
                    case 0:
                        watchListCb.WatchType = AppTypes.PortfolioTypes.WatchList;
                        watchListCb.LoadData(application.sysLibs.sysLoginCode, true);
                        watchListCb.Enabled = true;
                        break;
                    case 1:
                        watchListCb.WatchType = AppTypes.PortfolioTypes.Portfolio;
                        watchListCb.LoadData(application.sysLibs.sysLoginCode, true);
                        watchListCb.Enabled = true;
                        break;
                    default:
                        watchListCb.Enabled = false;
                        break;
                }
                stockCodeSelect.Enabled = !watchListCb.Enabled;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion

    }
}