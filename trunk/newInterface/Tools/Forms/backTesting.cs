 using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using commonTypes;
using commonClass;

namespace Tools.Forms
{
    /// <summary>
    /// This class uses historical data to test the strategy implemented for stock, forex, commodities
    /// </summary>
    public partial class backTesting : baseTesting
    {
        /// <summary>
        /// Constructor: set strategy Check List Box, Code List Box, Period, Result, and Estimation Grid
        /// </summary>
        public backTesting()
        {
            try
            {
                InitializeComponent();

                strategyEstimationPnl.Visible = false;

                strategyClb.LoadData(AppTypes.StrategyTypes.Strategy, true, false);
                codeSelectLb.LoadData();
                periodicityEd.LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public DataParams myDataParam
        {
            get
            {
                return new DataParams(periodicityEd.myTimeScale.Code,periodicityEd.myTimeRange,0);
            }
        }
        
        /// <summary>
        /// Set language
        /// </summary>
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("backTest");

            periodicityLbl.Text = Languages.Libs.GetString("periodicity");
            codeListLbl.Text = Languages.Libs.GetString("codeList");
            //Menu
            backTestMenuItem.Text = Languages.Libs.GetString("backTest");
            exportResultMenuItem.Text = Languages.Libs.GetString("exportResult");
            exportEstimationMenuItem.Text = Languages.Libs.GetString("exportEstimation");
            runMenuItem.Text = Languages.Libs.GetString("run");
            fullViewMenuItem.Text = Languages.Libs.GetString("fullView");
            estimationMenuItem.Text = Languages.Libs.GetString("estimation");
            openMenuItem.Text = Languages.Libs.GetString("openChart");
            addToWatchListMenuItem.Text = Languages.Libs.GetString("addToWatchList");
            allProfitDetailMenu.Text = Languages.Libs.GetString("allProfitDetail");
            profitDetailMenu.Text = Languages.Libs.GetString("profitDetail");

            SetResultDataGridText();
            SetEstimateStrategyGridText();

            periodicityEd.SetLanguage();
            strategyClb.SetLanguage();
            codeSelectLb.SetLanguage();

            CreateContextMenu();
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
        public void ShowEstimationDataGeneral()
        {
            strategyEstimationPnl.Visible = true;
            DataPartResize();
        }
        public void ExportResult()
        {
            if (resultDataGrid.DataSource == null)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel((DataTable)resultDataGrid.DataSource, saveFileDialog.FileName);
        }
        public void ExportEstimation()
        {
            if (resultDataGrid.DataSource == null)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel((DataTable)strategyEstimationGrid.DataSource, saveFileDialog.FileName);
        }

        /// <summary>
        /// Function to calculate the backtest process
        /// </summary>
        public void Execute()
        {
            if (this.fOnProccessing) return;
            try
            {
                if (!DataValidate()) return;

                this.ShowMessage("");
                this.fOnProccessing = true;

                progressBar.Visible = true;
                this.myFormMode = formMode.OptionWithData;

                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                DoBackTesting();
                watch.Stop();

                FormResize();
                this.ShowMessage(Languages.Libs.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(watch.Elapsed));
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.fOnProccessing = false;
                this.ShowError(er);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        /// <summary>
        /// Get existing Back Testing form or create new Form
        /// </summary>
        /// <param name="formName"></param>
        /// <returns></returns>
        public static backTesting GetForm(string formName)
        {
            string cacheKey = typeof(backTesting).FullName + (formName != null && formName.Trim() == "" ? "-" + formName.Trim() : "");
            backTesting form = (backTesting)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new Forms.backTesting();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        private enum formMode : byte { OptionOnly = 0, OptionWithData = 1, DataOnly = 2 };
        private formMode myFormMode
        {
            get
            {
                if (dataPnl.Visible)
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
                        dataPnl.Visible = true; optionPnl.Visible = false;
                        break;
                    case formMode.OptionOnly: dataPnl.Visible = false; optionPnl.Visible = true; break;
                    case formMode.OptionWithData:
                        dataPnl.Visible = true; optionPnl.Visible = true;
                        this.Width = optionPnl.Width + dataPnl.Width;
                        break;
                }
                FormResize();
            }
        }

        public void SetSelectedCode(StringCollection codes)
        {
            codeSelectLb.ShowCheckedOnly = false;
            codeSelectLb.myValues = codes;
            codeSelectLb.ShowCheckedOnly = (codes.Count>0);
        }

        /// <summary>
        /// Set the contend of the Grid with DataTable value
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="tbl"></param>
        private void SetDataGrid(DataGridView grid, DataTable tbl)
        {
            grid.DataSource = tbl;

            DataGridViewCellStyle amountCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            amountCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            amountCellStyle.Format = "N" + common.system.GetPrecisionFromMask(Settings.sysMaskLocalAmt);
            amountCellStyle.NullValue = null;

            application.Strategy.Meta meta;
            grid.Columns.Clear();
            for (int idx = 0; idx < tbl.Columns.Count; idx++)
            {
                DataGridViewTextBoxColumn column = new System.Windows.Forms.DataGridViewTextBoxColumn();
                grid.Columns.Add(column);
                column.DataPropertyName = tbl.Columns[idx].ColumnName;
                if (idx == 0)
                {
                    column.Width = 70;
                    column.Frozen = true;
                }
                else
                {
                    meta = application.Strategy.Libs.FindMetaByCode(tbl.Columns[idx].ColumnName);
                    column.ToolTipText = meta.Name;
                    column.HeaderText = meta.ClassType.Name.Trim(); 
                    column.Width = 90;
                    column.DefaultCellStyle = amountCellStyle;
                }
                column.Name = idx.ToString();
            }
            SetResultDataGridText();
        }
        private void SetEstimateDataGrid(DataTable tbl)
        {
            SetDataGrid(strategyEstimationGrid, tbl);
            strategyEstimationGrid.Columns[0].Width = 120;
            strategyEstimationGrid.Columns[0].Frozen = true;
            SetEstimateStrategyGridText();
        }
        
        private void SetEstimateStrategyGridText()
        {
            DataTable tbl = (DataTable)strategyEstimationGrid.DataSource;
            StringCollection text = application.Strategy.Libs.GetStrategyStatsText();
            if (tbl == null || text.Count != strategyEstimationGrid.Rows.Count) return;
            for (int idx = 0; idx < text.Count; idx++)
            {
                tbl.Rows[idx][0] = text[idx];
            }
            strategyEstimationGrid.Columns[0].HeaderText = Languages.Libs.GetString("criteria");
            strategyEstimationGrid.Refresh();
        }
        private void SetResultDataGridText()
        {
            DataTable tbl = (DataTable)resultDataGrid.DataSource;
            if (tbl == null || resultDataGrid.ColumnCount < 1) return;
            for (int idx = 0; idx < tbl.Columns.Count; idx++)
            {
                if (idx == 0)
                {
                    resultDataGrid.Columns[idx].HeaderText = Languages.Libs.GetString("code");
                }
                else
                {
                    resultDataGrid.Columns[idx].HeaderText = application.Strategy.Libs.GetMetaName(tbl.Columns[idx].ColumnName);
                }
            }
            resultDataGrid.Refresh();
        }

        private void FormResize()
        {
            switch (this.myFormMode)
            {
                case formMode.OptionOnly:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;
                    //stockCodeSelect.Height = optionPnl.Height - stockCodeSelect.Location.Y;
                    this.Width = optionPnl.Width+5;
                    break;
                case formMode.DataOnly:
                    dataPnl.Location = new Point(0,0);
                    dataPnl.Width = this.ClientRectangle.Width - dataPnl.Location.X;
                    dataPnl.Height = this.ClientRectangle.Height - dataPnl.Location.Y - SystemInformation.CaptionHeight - 3;
                    break;
                case formMode.OptionWithData:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;
                    //stockCodeSelect.Height = optionPnl.Height - stockCodeSelect.Location.Y;
                    dataPnl.Location = new Point(optionPnl.Location.X + optionPnl.Width, 0);
                    dataPnl.Width = this.ClientRectangle.Width - dataPnl.Location.X;
                    dataPnl.Height = this.ClientRectangle.Height - dataPnl.Location.Y - SystemInformation.CaptionHeight - 3;
                    break;
            }
            DataPartResize();
        }
        private void DataPartResize()
        {
            resultDataGrid.Width = dataPnl.Width - resultDataGrid.Location.X;
            if (strategyEstimationPnl.Visible)
            {
                //Keep statistis height
                strategyEstimationGrid.Width = resultDataGrid.Width;
                resultDataGrid.Height = strategyEstimationPnl.Location.Y;
            }
            else
            {
                resultDataGrid.Height = dataPnl.Height;
            }
        }

        private bool DataValidate()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.strategyClb.myCheckedValues.Count == 0)
            {
                NotifyError(strategyLbl);
                retVal = false;
            }
            if (this.codeSelectLb.Enabled && this.codeSelectLb.myValues.Count == 0)
            {
                NotifyError(codeListLbl);
                retVal = false;
            }
            if (!this.periodicityEd.GetDate())
            {
                NotifyError(periodicityLbl);
                retVal = false;
            }
            return retVal;
        }
        private static DataTable CreateEstimateTbl(StringCollection strategyCode)
        {
            DataTable tbl = new DataTable();

            // Define columns
            DataColumn col = new DataColumn("item");
            tbl.Columns.Add(col);
            for (int colId = 0; colId < strategyCode.Count; colId++)
            {
                col = new DataColumn(strategyCode[colId].Trim(), typeof(Decimal));
                tbl.Columns.Add(col);
            }
            return tbl;
        }

        private void DoBackTesting()
        {
            this.ShowReccount("");
            this.myValueType = ValueTypes.Amount;
            this.Amount2PercentDenominator = Settings.sysStockTotalCapAmt;
            StringCollection strategyList = strategyClb.myCheckedValues;
            StringCollection stockCodeList = codeSelectLb.myValues;
            //Analysis cached data so we MUST reset to clear cache to ensure the system run correctly
            DataAccess.Libs.ClearCache();
            EstimateOptions estimateOption = new EstimateOptions();

            DataTable retsultTbl = CreateEstimateTbl(strategyList);
            SetDataGrid(resultDataGrid, retsultTbl);

            progressBar.Value = 0; progressBar.Minimum = 0; progressBar.Maximum = stockCodeList.Count;
            AppTypes.TimeRanges timeRange = periodicityEd.myTimeRange;
            string timeScaleCode = periodicityEd.myTimeScale.Code;
            string[] strategy = common.system.Collection2List(strategyList);

            this.ShowReccount(progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());

            int codeStartIdx=0, codeEndIdx=0;
            while (codeStartIdx < stockCodeList.Count)
            {
                codeEndIdx += Settings.sysNumberOfItemsInBatchProcess;
                if (codeEndIdx >= stockCodeList.Count) codeEndIdx = stockCodeList.Count - 1;

                string[] stocks = common.system.Collection2List(stockCodeList, codeStartIdx, codeEndIdx);
                decimal[][] retList = DataAccess.Libs.Estimate_Matrix_Profit(timeRange, timeScaleCode, stocks, strategy, estimateOption);
                for (int idx = 0; idx < retList.Length; idx++)
                {
                    DataRow row = retsultTbl.Rows.Add(stockCodeList[idx + codeStartIdx]);
                    for (int colId = 0; colId < retList[idx].Length; colId++)
                    {
                        row[colId + 1] = retList[idx][colId]; 
                    }
                }
                Application.DoEvents();
                codeStartIdx = codeEndIdx + 1;
                progressBar.Value = codeEndIdx+1;
                this.ShowReccount(progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());
            }
            common.system.RemoveEmptyItems(retsultTbl);
            SetDataGrid(resultDataGrid, retsultTbl);

            SetEstimateDataGrid(application.Strategy.Libs.GetStrategyStats(retsultTbl));
        }

        private void CreateContextMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(openMenuItem.Text);
            menuItem.Click += new System.EventHandler(openMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(addToWatchListMenuItem.Text);
            menuItem.Click += new System.EventHandler(addToWatchListMenuItem_Click);

            contextMenuStrip.Items.Add(new ToolStripSeparator());
            menuItem = contextMenuStrip.Items.Add(profitDetailMenu.Text);
            menuItem.Click += new System.EventHandler(profitDetailMenu_Click);

            menuItem = contextMenuStrip.Items.Add(allProfitDetailMenu.Text);
            menuItem.Click += new System.EventHandler(allProfitDetailMenu_Click);

            contextMenuStrip.Items.Add(new ToolStripSeparator());
            menuItem = contextMenuStrip.Items.Add(estimationMenuItem.Text);
            menuItem.Click += new System.EventHandler(estimationMenuItem_Click);

            resultDataGrid.ContextMenuStrip = contextMenuStrip;
        }

        protected override void Amount2Percent() 
        {
            if (this.Amount2PercentDenominator == 0) return;
            DataTable dataTbl = (DataTable)resultDataGrid.DataSource;
            decimal val =0;
            for (int rowId = 0; rowId < dataTbl.Rows.Count; rowId++)
            {
                for (int colId = 1; colId < dataTbl.Columns.Count; colId++)
                {
                    if (!decimal.TryParse(dataTbl.Rows[rowId][colId].ToString(), out val)) continue;
                    dataTbl.Rows[rowId][colId] = (val / this.Amount2PercentDenominator) * 100; 
                }
            }
        }
        protected override void Percent2Amount()
        {
            if (this.Amount2PercentDenominator == 0) return;
            DataTable dataTbl = (DataTable)resultDataGrid.DataSource;
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
            baseClass.Forms.addToWatchList_StockOnly myForm = baseClass.Forms.addToWatchList_StockOnly.GetForm("");
            myForm.ShowForm(stockCodes);
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
                if (resultDataGrid.CurrentRow == null) return;
                string stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                databases.tmpDS.stockCodeRow stockCodeRow;
                if (e.ColumnIndex == 0)
                {
                    ShowStock(stockCode, periodicityEd.myTimeRange, periodicityEd.myTimeScale);
                    return;
                }
                stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode);
                string strategyCode = strategyClb.myCheckedValues[e.ColumnIndex - 1];
                ShowTradeTransactions(stockCodeRow, strategyCode, this.myDataParam);
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
        private void backTesting_Resize(object sender, EventArgs e)
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
        private void exportEstimationMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ExportEstimation();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private bool strategyEstimationPnl_myOnClosing(object sender)
        {
            try
            {
                strategyEstimationPnl.Visible = false;
                DataPartResize();
                return true;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            return false;
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

        private void estimationMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEstimationDataGeneral();
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
                string stockCode;
                if (resultDataGrid.SelectedRows.Count > 0)
                {
                    for (int idx = 0; idx < resultDataGrid.SelectedRows.Count; idx++)
                    {
                        stockCode = resultDataGrid.SelectedRows[idx].Cells[0].Value.ToString();
                        ShowStock(stockCode, periodicityEd.myTimeRange, periodicityEd.myTimeScale);
                    }
                }
                else
                {
                    if (resultDataGrid.CurrentRow != null)
                    {
                        stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                        ShowStock(stockCode, periodicityEd.myTimeRange, periodicityEd.myTimeScale);
                    }
                }
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
                StringCollection stockCodes = new StringCollection();
                if (resultDataGrid.SelectedRows.Count > 0)
                {
                    for (int idx = 0; idx < resultDataGrid.SelectedRows.Count; idx++)
                        stockCodes.Add(resultDataGrid.SelectedRows[idx].Cells[0].Value.ToString());
                }
                else
                {
                    if (resultDataGrid.CurrentRow != null)
                        stockCodes.Add(resultDataGrid.CurrentRow.Cells[0].Value.ToString());
                }
                if (stockCodes.Count > 0)
                {
                    this.AddStockToWatchList(stockCodes);
                }
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
                using (new DataAccess.PleaseWait())
                {
                    string stockCode;
                    databases.tmpDS.stockCodeRow stockCodeRow;
                    if (resultDataGrid.SelectedRows.Count > 0)
                    {
                        for (int idx1 = 0; idx1 < resultDataGrid.SelectedRows.Count; idx1++)
                        {
                            stockCode = resultDataGrid.SelectedRows[idx1].Cells[0].Value.ToString();
                            stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode);
                            if (stockCodeRow == null) continue;
                            for (int idx2 = 0; idx2 < strategyClb.myCheckedValues.Count; idx2++)
                            {
                                ShowTradeTransactions(stockCodeRow, strategyClb.myCheckedValues[idx2],this.myDataParam);
                            }
                        }
                    }
                    else
                    {
                        if (resultDataGrid.CurrentRow != null)
                        {
                            stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                            stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode);
                            if (stockCodeRow == null) return;
                            for (int idx2 = 0; idx2 < strategyClb.myCheckedValues.Count; idx2++)
                            {
                                ShowTradeTransactions(stockCodeRow, strategyClb.myCheckedValues[idx2],this.myDataParam);
                            }
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
                
                if (resultDataGrid.CurrentRow == null) return;
                int cellId = (resultDataGrid.CurrentCell != null && resultDataGrid.CurrentCell.ColumnIndex >0 ? resultDataGrid.CurrentCell.ColumnIndex-1:0) ;
                string stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                databases.tmpDS.stockCodeRow stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode);
                if (stockCodeRow == null) return;
                ShowTradeTransactions(stockCodeRow, strategyClb.myCheckedValues[cellId], this.myDataParam);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}