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
    public partial class strategyRanking : baseTesting
    {
        public strategyRanking()
        {
            try
            {
                InitializeComponent();
                stockCodeSelectLb.LoadData();
                cbTimeScale.LoadData();
                strategyClb.LoadData(AppTypes.StrategyTypes.Strategy, true, false);
                AppTypes.TimeRanges[] timeRanges = new AppTypes.TimeRanges[]
                {
                    AppTypes.TimeRanges.M1, AppTypes.TimeRanges.M3,AppTypes.TimeRanges.M6,
                    AppTypes.TimeRanges.Y1,AppTypes.TimeRanges.Y2,AppTypes.TimeRanges.Y3,AppTypes.TimeRanges.Y4,AppTypes.TimeRanges.Y5,
                };
                timeRangeLb.LoadData(timeRanges);
                optionPnl.Location = new Point(0, 0);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public static strategyRanking GetForm(string formName)
        {
            string cacheKey = typeof(strategyRanking).FullName + (formName != null && formName.Trim() == "" ? "-" + formName.Trim() : "");
            strategyRanking form = (strategyRanking)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new Forms.strategyRanking();
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
        private bool fExecute = false;
        public void Execute()
        {
            if (fExecute) return;
            fExecute = true;
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
                fExecute = false;
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

        private common.controls.baseDataGridView CurrentDataGridView
        {
            get
            {
                for (int idx = 0; idx < resultTab.SelectedTab.Controls.Count; idx++)
                {
                    if (resultTab.SelectedTab.Controls[idx].GetType() == typeof(common.controls.baseDataGridView))
                        return (common.controls.baseDataGridView)resultTab.SelectedTab.Controls[idx];
                }
                return null;
            }
        }
        private static void SetDataGrid(common.controls.baseDataGridView grid, DataTable tbl)
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
                    column.HeaderText = "Strategy";
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
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            AdjustTestGridSize(grid);
        }
        private void CreateContextMenu(common.controls.baseDataGridView gridView)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(openMenuItem.Text);
            menuItem.Click += new System.EventHandler(openMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(profitDetailMenu.Text);
            menuItem.Click += new System.EventHandler(profitDetailMenu_Click );

            menuItem = contextMenuStrip.Items.Add(allProfitDetailMenu.Text);
            menuItem.Click += new System.EventHandler(allProfitDetailMenu_Click);

            menuItem = contextMenuStrip.Items.Add(addToWatchListMenuItem.Text);
            menuItem.Click += new System.EventHandler(addToWatchListMenuItem_Click);

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
                tbl.Rows.Add(Strategy.Libs.GetMetaName(strategyList[rowId]));
            }
            return tbl;
        }

        private void FormResize()
        {
            switch (this.myFormMode)
            {
                case formMode.OptionOnly:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;
                    stockCodeSelectLb.Height = optionPnl.Height - stockCodeSelectLb.Location.Y;
                    this.Width = optionPnl.Width+5;
                    break;
                case formMode.DataOnly:
                    resultTab.Location = new Point(0,0);
                    resultTab.Width = this.ClientRectangle.Width - resultTab.Location.X;
                    resultTab.Height = this.ClientRectangle.Height - resultTab.Location.Y - SystemInformation.CaptionHeight - 3;
                    break;
                case formMode.OptionWithData:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;
                    stockCodeSelectLb.Height = optionPnl.Height - stockCodeSelectLb.Location.Y;

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
            if (this.stockCodeSelectLb.Enabled && this.stockCodeSelectLb.myValues.Count == 0)
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

        private void DoRanking()
        {
            this.myValueType = ValueTypes.Amount;
            this.Amount2PercentDenominator = application.Settings.sysStockTotalCapAmt;

            resultTab.TabPages.Clear();
            StringCollection stockCodeList = stockCodeSelectLb.myValues;
            StringCollection strategyList = strategyClb.myCheckedValues;
            StringCollection timeRangeList = timeRangeLb.myCheckedValues;
            progressBar.Value = 0; progressBar.Minimum = 0; progressBar.Maximum = stockCodeList.Count * timeRangeList.Count;
            for (int stockCodeId = 0; stockCodeId < stockCodeList.Count; stockCodeId++)
            {
                string stockCode = stockCodeList[stockCodeId].ToString();
                DataTable testRetsultTbl = CreateDataTable(timeRangeList, strategyList);
                common.controls.baseDataGridView resultGrid = CreateResultGrid(stockCode, testRetsultTbl);

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

        private common.controls.baseDataGridView CreateResultGrid(string stockCode, DataTable testRetsultTbl)
        {
            common.controls.baseDataGridView dataGridView = new common.controls.baseDataGridView();
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
        private void AddStockToWatchList(string stockCode,StringCollection strategyCodes,AppTypes.TimeScale timeScale)
        {
            addToWatchList_StockAndStrategy myForm = addToWatchList_StockAndStrategy.GetForm("");
            myForm.ShowForm(stockCode,strategyCodes,timeScale);
        }

        private void Amount2Percent(common.controls.baseDataGridView dataGrid)
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
        private void Percent2Amount(common.controls.baseDataGridView dataGrid)
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
        private void AddStockToWatchList(StringCollection stockCodes)
        {
            addToWatchList_StockOnly myForm = addToWatchList_StockOnly.GetForm("");
            myForm.ShowForm(stockCodes);
        }

        protected override void Amount2Percent()
        {
            if (this.Amount2PercentDenominator == 0) return;
            for (int tabId = 0; tabId < resultTab.TabPages.Count; tabId++)
            {
                for (int pageId = 0; pageId < resultTab.TabPages[tabId].Controls.Count; pageId++)
                {
                    if (resultTab.TabPages[tabId].Controls[pageId].GetType() != typeof(common.controls.baseDataGridView)) continue;
                    Amount2Percent((common.controls.baseDataGridView)resultTab.TabPages[tabId].Controls[pageId]);
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
                    if (resultTab.TabPages[tabId].Controls[pageId].GetType() != typeof(common.controls.baseDataGridView)) continue;
                    Percent2Amount((common.controls.baseDataGridView)resultTab.TabPages[tabId].Controls[pageId]);
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
                common.controls.baseDataGridView resultDataGrid = this.CurrentDataGridView;
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
                //FormResize();
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
                common.controls.baseDataGridView resultDataGrid = this.CurrentDataGridView;
                if (resultDataGrid == null || resultDataGrid.CurrentCell==null) return;
                if(resultDataGrid.CurrentCell.ColumnIndex<=0) return;

                string stockCode = resultTab.SelectedTab.Name;  
                data.baseDS.stockCodeRow stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                if (stockCodeRow == null) return;

                int colId = resultDataGrid.CurrentCell.ColumnIndex;
                AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(resultDataGrid.Columns[colId].DataPropertyName);
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
                common.controls.baseDataGridView resultDataGrid = this.CurrentDataGridView;
                if (resultDataGrid == null) return;

                string stockCode = resultTab.SelectedTab.Name;
                StringCollection strategyCodes = new StringCollection();
                for (int idx = 0; idx < resultDataGrid.SelectedRows.Count; idx++)
                {
                    if (resultDataGrid.SelectedRows[idx] == null) continue;
                    Strategy.Meta meta = Strategy.Libs.FindMetaByName(resultDataGrid.SelectedRows[idx].Cells[0].Value.ToString());
                    strategyCodes.Add(meta.Code);
                }
                if (strategyCodes.Count > 0) this.AddStockToWatchList(stockCode, strategyCodes,cbTimeScale.myValue);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void allProfitDetailMenu_Click(object sender, EventArgs e)
        {
            try
            {
                common.controls.baseDataGridView resultDataGrid = this.CurrentDataGridView;
                if (resultDataGrid == null) return;

                string stockCode = resultTab.SelectedTab.Name;  
                data.baseDS.stockCodeRow stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                if (stockCodeRow == null) return;

                if (resultDataGrid.SelectedRows.Count > 0)
                {
                    for (int rowId = 0; rowId < resultDataGrid.SelectedRows.Count; rowId++)
                    {
                        Strategy.Meta meta = Strategy.Libs.FindMetaByName(resultDataGrid.SelectedRows[rowId].Cells[0].Value.ToString());
                        for (int idx = 1; idx < resultDataGrid.ColumnCount; idx++)
                        {
                            AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(resultDataGrid.Columns[idx].DataPropertyName);
                            ShowTradeTransactions(stockCodeRow, meta.Code, timeRange, cbTimeScale.myValue);
                        }
                    }
                }
                else
                {
                    if (resultDataGrid.CurrentRow != null)
                    {
                        Strategy.Meta meta = Strategy.Libs.FindMetaByName(resultDataGrid.CurrentRow.Cells[0].Value.ToString());
                        for (int idx = 1; idx < resultDataGrid.ColumnCount; idx++)
                        {
                            AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(resultDataGrid.Columns[idx].DataPropertyName);
                            ShowTradeTransactions(stockCodeRow, meta.Code, timeRange, cbTimeScale.myValue);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void profitDetailMenu_Click(object sender, EventArgs e)
        {
            try
            {
                common.controls.baseDataGridView resultDataGrid = this.CurrentDataGridView;
                if (resultDataGrid == null || resultDataGrid.CurrentRow == null || resultDataGrid.CurrentCell == null) return;
                if (resultDataGrid.CurrentCell.ColumnIndex<=0) return;

                string stockCode = resultTab.SelectedTab.Name;
                data.baseDS.stockCodeRow stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                if (stockCodeRow == null) return;
                Strategy.Meta meta = Strategy.Libs.FindMetaByName(resultDataGrid.CurrentRow.Cells[0].Value.ToString());

                int colId = resultDataGrid.CurrentCell.ColumnIndex;
                AppTypes.TimeRanges timeRange = AppTypes.TimeRangeFromCode(resultDataGrid.Columns[colId].DataPropertyName);
                ShowTradeTransactions(stockCodeRow, meta.Code, timeRange, cbTimeScale.myValue);
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
        #endregion
    }
}