﻿using System;
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
    public partial class backTesting : baseTesting
    {
        public backTesting()
        {
            try
            {
                InitializeComponent();

                strategyEstimationPnl.Visible = false;

                strategyClb.LoadData(AppTypes.StrategyTypes.Strategy, true, false);
                codeSelectLb.LoadData();
                periodicityEd.LoadData();
                resultDataGrid.DisableReadOnlyColumn = false;
                strategyEstimationGrid.DisableReadOnlyColumn = false;

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
            this.Text = language.GetString("backTest");

            periodicityLbl.Text = language.GetString("periodicity");
            codeListLbl.Text = language.GetString("codeList");
            //Menu
            backTestMenuItem.Text = language.GetString("backTest");
            exportResultMenuItem.Text = language.GetString("exportResult");
            exportEstimationMenuItem.Text = language.GetString("exportEstimation");
            runMenuItem.Text = language.GetString("run");
            fullViewMenuItem.Text = language.GetString("fullView");
            estimationMenuItem.Text = language.GetString("estimation");
            openMenuItem.Text = language.GetString("open");
            addToWatchListMenuItem.Text = language.GetString("addToWatchList");
            allProfitDetailMenu.Text = language.GetString("allProfitDetail");
            profitDetailMenu.Text = language.GetString("profitDetail");

            SetResultDataGridText();
            SetEstimateStrategyGridText();

            periodicityEd.SetLanguage();
            strategyClb.SetLanguage();
            codeSelectLb.SetLanguage();
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
                common.system.ShowErrorMessage(language.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel((DataTable)resultDataGrid.DataSource, saveFileDialog.FileName);
        }
        public void ExportEstimation()
        {
            if (resultDataGrid.DataSource == null)
            {
                common.system.ShowErrorMessage(language.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel((DataTable)strategyEstimationGrid.DataSource, saveFileDialog.FileName);
        }

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
                DateTime startTime = DateTime.Now;

                if (application.Settings.sysUseWebservice)  DoBackTestUseWS();
                else DoBackTestUseDB();
                //DoBackTestUseDB();
                FormResize();

                DateTime endTime = DateTime.Now;
                this.ShowMessage(language.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(endTime.Subtract(startTime)));

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

        private void SetDataGrid(DataGridView grid, DataTable tbl)
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
                    column.Width = 70;
                    column.Frozen = true;
                }
                else
                {
                    column.HeaderText = Strategy.Libs.GetMetaName(tbl.Columns[idx].ColumnName);
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
            StringCollection text = Strategy.Libs.GetStrategyStatsText();
            if (tbl == null || text.Count != strategyEstimationGrid.Rows.Count) return;
            for (int idx = 0; idx < text.Count; idx++)
            {
                tbl.Rows[idx][0] = text[idx];
            }
            strategyEstimationGrid.Columns[0].HeaderText = language.GetString("criteria");
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
                    resultDataGrid.Columns[idx].HeaderText = language.GetString("code");
                }
                else
                {
                    resultDataGrid.Columns[idx].HeaderText = Strategy.Libs.GetMetaName(tbl.Columns[idx].ColumnName);
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

        private void DoBackTestUseDB()
        {
            this.myValueType = ValueTypes.Amount;
            this.Amount2PercentDenominator = Settings.sysStockTotalCapAmt;
            StringCollection strategyList = strategyClb.myCheckedValues;
            StringCollection stockCodeList = codeSelectLb.myValues;
            DataTable testRetsultTbl = CreateEstimateTbl(strategyList);
            SetDataGrid(resultDataGrid, testRetsultTbl);

            progressBar.Value = 0; progressBar.Minimum = 0; progressBar.Maximum = stockCodeList.Count;
            for (int rowId = 0; rowId < stockCodeList.Count; rowId++)
            {
                application.Data analysisData = new application.Data(periodicityEd.myTimeRange, periodicityEd.myTimeScale, stockCodeList[rowId]);
                DataRow row = testRetsultTbl.Rows.Add(stockCodeList[rowId]);
                for (int colId = 0; colId < strategyList.Count; colId++)
                {
                    try
                    {
                        //Analysis cached data so we MUST clear cache to ensure the system run correctly
                        Strategy.Data.ClearCache();
                        Strategy.Data.TradePoints advices = Strategy.Libs.Analysis(analysisData, strategyList[colId]);
                        if (advices != null)
                        {
                            row[colId + 1] = Strategy.Libs.EstimateTrading_Profit(analysisData, Strategy.Libs.ToTradePointInfo(advices), new wsData.EstimateOptions());
                        }
                        else row[colId + 1] = 0;
                    }
                    catch (Exception er)
                    {
                        this.WriteError(stockCodeList[rowId] + " : " + strategyList[colId], er.Message);
                        this.ShowError(er);
                    }
                }
                progressBar.Value++;
                this.ShowReccount(progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());
                Application.DoEvents();
            }
            SetEstimateDataGrid(Strategy.Libs.GetStrategyStats(testRetsultTbl));
        }
        private void DoBackTestUseWS()
        {
            this.ShowReccount("");
            this.myValueType = ValueTypes.Amount;
            this.Amount2PercentDenominator = Settings.sysStockTotalCapAmt;
            StringCollection strategyList = strategyClb.myCheckedValues;
            StringCollection stockCodeList = codeSelectLb.myValues;
            //Analysis cached data so we MUST reset to clear cache to ensure the system run correctly
            wsAccess.libs.Reset();
            wsData.EstimateOptions estimateOption = new wsData.EstimateOptions();

            DataTable retsultTbl = CreateEstimateTbl(strategyList);
            SetDataGrid(resultDataGrid, retsultTbl);

            progressBar.Value = 0; progressBar.Minimum = 0; progressBar.Maximum = stockCodeList.Count;
            application.AppTypes.TimeRanges timeRange = periodicityEd.myTimeRange;
            string timeScaleCode = periodicityEd.myTimeScale.Code;
            string[] strategy = common.system.Collection2List(strategyList);

            this.ShowReccount(progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());

            int codeStartIdx=0, codeEndIdx=0;
            while (codeStartIdx < stockCodeList.Count)
            {
                codeEndIdx += application.Settings.sysNumberOfItemsInBatchProcess;
                if (codeEndIdx >= stockCodeList.Count) codeEndIdx = stockCodeList.Count - 1;

                string[] stocks = common.system.Collection2List(stockCodeList, codeStartIdx, codeEndIdx);
                decimal[][] retList = wsAccess.libs.myClient.Estimate_Matrix_Profit(timeRange, timeScaleCode, stocks, strategy, estimateOption);
                for (int idx = 0; idx < retList.Length; idx++)
                {
                    DataRow row = retsultTbl.Rows.Add(stockCodeList[idx + codeStartIdx]);
                    for (int colId = 0; colId < retList[idx].Length; colId++)
                    {
                        row[colId + 1] = retList[idx][colId]; 
                    }
                    Application.DoEvents();
                }
                codeStartIdx = codeEndIdx + 1;
                progressBar.Value = codeEndIdx+1;
                this.ShowReccount(progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());
            }
            SetEstimateDataGrid(Strategy.Libs.GetStrategyStats(retsultTbl));
        }

        private void CreateContextMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(openMenuItem.Text);
            menuItem.Click += new System.EventHandler(openMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(addToWatchListMenuItem.Text);
            menuItem.Click += new System.EventHandler(addToWatchListMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(profitDetailMenu.Text);
            menuItem.Click += new System.EventHandler(profitDetailMenu_Click);

            menuItem = contextMenuStrip.Items.Add(allProfitDetailMenu.Text);
            menuItem.Click += new System.EventHandler(allProfitDetailMenu_Click);

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
            addToWatchList_StockOnly myForm = addToWatchList_StockOnly.GetForm("");
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
                data.tmpDS.stockCodeRow stockCodeRow;
                if (e.ColumnIndex == 0)
                {
                    ShowStock(stockCode, periodicityEd.myTimeRange, periodicityEd.myTimeScale);
                    return;
                }
                stockCodeRow = dataLibs.FindAndCache_StockCodeShort(stockCode);
                string strategyCode = strategyClb.myCheckedValues[e.ColumnIndex - 1];
                ShowTradeTransactions(stockCodeRow, strategyCode, periodicityEd.myTimeRange, periodicityEd.myTimeScale);
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
                string stockCode;
                data.tmpDS.stockCodeRow stockCodeRow;
                if (resultDataGrid.SelectedRows.Count > 0)
                {
                    for (int idx1 = 0; idx1 < resultDataGrid.SelectedRows.Count; idx1++)
                    {
                        stockCode = resultDataGrid.SelectedRows[idx1].Cells[0].Value.ToString();
                        stockCodeRow = dataLibs.FindAndCache_StockCodeShort(stockCode);
                        if (stockCodeRow == null) continue;
                        for (int idx2 = 0; idx2 < strategyClb.myCheckedValues.Count; idx2++)
                        {
                            ShowTradeTransactions(stockCodeRow, strategyClb.myCheckedValues[idx2],
                                                  periodicityEd.myTimeRange,periodicityEd.myTimeScale);
                        }
                    }
                }
                else
                {
                    if (resultDataGrid.CurrentRow != null)
                    {
                        stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                        stockCodeRow = dataLibs.FindAndCache_StockCodeShort(stockCode);
                        if (stockCodeRow == null) return;
                        for (int idx2 = 0; idx2 < strategyClb.myCheckedValues.Count; idx2++)
                        {
                            ShowTradeTransactions(stockCodeRow, strategyClb.myCheckedValues[idx2],
                                                  periodicityEd.myTimeRange, periodicityEd.myTimeScale);
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
                if (resultDataGrid.CurrentRow == null || resultDataGrid.CurrentCell == null) return;
                if (resultDataGrid.CurrentCell.ColumnIndex <= 0) return;

                string stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                data.tmpDS.stockCodeRow stockCodeRow = dataLibs.FindAndCache_StockCodeShort(stockCode);
                if (stockCodeRow == null) return;
                ShowTradeTransactions(stockCodeRow, strategyClb.myCheckedValues[resultDataGrid.CurrentCell.ColumnIndex-1],
                                      periodicityEd.myTimeRange, periodicityEd.myTimeScale);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}