using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace baseClass.forms
{
    public partial class baseBackTesting : baseAnalysis
    {
        public baseBackTesting()
        {
            try
            {
                InitializeComponent();
                strategyClb.LoadData(myTypes.strategyType.Strategy,true,false);

                portfolioCb.LoadData(application.sysLibs.sysLoginCode,true);
                stockCodeSelect.LoadData();
                dateRangeEd.LoadData();
                stockCodeSelect.LockEdit(false);
                testResultDataGrid.DisableReadOnlyColumn = false;
                strategyEstDataGrid.DisableReadOnlyColumn = false;
                stockCodeOptionCb.SelectedIndex = 0;
                stockCodeOptionCb_SelectionChangeCommitted(null, null);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }


        private baseTradeAnalysis _myTradeAnalysisForm = null;
        private baseTradeAnalysis myTradeAnalysisForm
        {
            get
            {
                if (_myTradeAnalysisForm == null || _myTradeAnalysisForm.IsDisposed)
                    _myTradeAnalysisForm = GetTradeAnalysisForm();
                return _myTradeAnalysisForm;
            }
        }
        
        private baseBackTestingChart _myBackTestingChartForm = null;
        private baseBackTestingChart myBackTestingChartForm
        {
            get
            {
                if (_myBackTestingChartForm == null || _myBackTestingChartForm.IsDisposed)
                    _myBackTestingChartForm = GetBackTestingChartFrom();
                return _myBackTestingChartForm;
            }
        }

        protected virtual baseTradeAnalysis GetTradeAnalysisForm()
        {
            return new baseTradeAnalysis();
        }
        protected virtual baseBackTestingChart GetBackTestingChartFrom()
        {
            return new baseBackTestingChart();
        }

        private enum formMode : byte { OptionOnly = 0, OptionWithData = 1, DataOnly= 2};
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
                dataToolbarPnl.Visible = dataPnl.Visible;
                FormResize();
            }
        }

        private static void SetDataGrid(DataGridView grid, DataTable tbl)
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
                    column.HeaderText = "Mã.CK";
                    column.Width = 60;
                    column.Frozen = true;
                }
                else
                {
                    column.HeaderText = tbl.Columns[idx].ColumnName;
                    column.Width = 90;
                    column.DefaultCellStyle = amountCellStyle;
                }
                column.Name = idx.ToString();
            }
            AdjustTestGridSize(grid);
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
        private void SetEstimateStrateDataGrid(DataTable tbl)
        {
            SetDataGrid(strategyEstDataGrid, tbl);
            strategyEstDataGrid.Columns[0].Width = 120;
            strategyEstDataGrid.Columns[0].HeaderText = "Tiêu chí";
            strategyEstDataGrid.Columns[0].Frozen = true;
        }
        private DataTable CreateDataTable(StringCollection strategyCode)
        {
            // Define the new datatable
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

        private void FormResize()
        {
            mainToolbarPnl.Width = this.Width + 10;
            switch (this.myFormMode)
            {
                case formMode.OptionOnly:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;
                    stockCodeSelect.Height = optionPnl.Height - stockCodeSelect.Location.Y;
                    this.Width = optionPnl.Width + SystemInformation.CaptionButtonSize.Width; 
                    break;
                case formMode.DataOnly:
                    dataPnl.Location = new Point(0, mainToolbarPnl.Location.Y + mainToolbarPnl.Height);
                    dataPnl.Width = this.ClientRectangle.Width - dataPnl.Location.X; 
                    dataPnl.Height = this.ClientRectangle.Height- dataPnl.Location.Y - SystemInformation.CaptionHeight-3;
                    break;
                case formMode.OptionWithData:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;
                    stockCodeSelect.Height = optionPnl.Height - stockCodeSelect.Location.Y;
                    dataPnl.Location = new Point(optionPnl.Location.X + optionPnl.Width, mainToolbarPnl.Location.Y + mainToolbarPnl.Height);
                    dataPnl.Width = this.ClientRectangle.Width - dataPnl.Location.X;
                    dataPnl.Height = this.ClientRectangle.Height - dataPnl.Location.Y-SystemInformation.CaptionHeight-3;
                    break;
            }
            DataPartResize();
        }
        private void DataPartResize()
        {
            testResultDataGrid.Width = dataPnl.Width - testResultDataGrid.Location.X;
            if (strategyEstDataGrid.Visible)
            {
                //Keep statistis height
                strategyEstDataGrid.Location = new Point(0,dataPnl.Height - strategyEstDataGrid.Height);
                strategyEstDataGrid.Width = testResultDataGrid.Width;
                testResultDataGrid.Height = strategyEstDataGrid.Location.Y;
                AdjustTestGridSize(strategyEstDataGrid);
            }
            else
            {
                testResultDataGrid.Height = dataPnl.Height;
            }
            AdjustTestGridSize(testResultDataGrid);
        }

        private bool DataValidate()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.strategyClb.myCheckedValues.Count==0)
            {
                NotifyError(strategyLbl);
                retVal = false;
            }
            if (this.stockCodeSelect.Enabled && this.stockCodeSelect.myCheckedValues.Count == 0)
            {
                NotifyError(stockCodeLbl);
                retVal = false;
            }
            if (!this.dateRangeEd.GetDate())
            {
                NotifyError(dateRangeLbl);
                retVal = false;
            }
            return retVal;
        }
        private void BackTest()
        {
            StringCollection strategyList = strategyClb.myCheckedValues;
            StringCollection stockCodeList;
            if (stockCodeSelect.Enabled) stockCodeList = stockCodeSelect.myCheckedValues;
            else
            {
                stockCodeList = new StringCollection();
                //Load stocks in portfolio
                data.baseDS.stockCodeExtDataTable myStockCodeTbl = new data.baseDS.stockCodeExtDataTable();
                StringCollection portfolioList = common.system.List2Collection(portfolioCb.GetValues());
                dataLibs.LoadStockCode_ByPortfolios(myStockCodeTbl, portfolioList);

                DataView myStockView = new DataView(myStockCodeTbl);
                data.baseDS.stockCodeExtRow stockRow;
                myStockView.Sort = myStockCodeTbl.codeColumn.ColumnName + "," + myStockCodeTbl.stockExchangeColumn.ColumnName;
                for (int idx1 = 0; idx1 < myStockView.Count; idx1++)
                {
                    stockRow = (data.baseDS.stockCodeExtRow)myStockView[idx1].Row;
                    //Ignore duplicate stocks
                    if (stockCodeList.Contains(stockRow.code)) continue;
                    stockCodeList.Add(stockRow.code);
                }
            }
            DataTable testRetsultTbl = CreateDataTable(strategyList);
            SetDataGrid(testResultDataGrid, testRetsultTbl);

            progressBar.Value = 0; progressBar.Maximum = stockCodeList.Count;

            analysis.workData analysisData = new analysis.workData();
            myDataSet.strategy.Clear();
            data.baseDS.strategyRow strategyRow;
            for (int idx = 0; idx < strategyList.Count; idx++)
            {
                strategyRow = application.dataLibs.FindAndCache(myDataSet.strategy, strategyList[idx]);
                if (strategyRow == null) common.system.ThrowException("Invalid strategy " + strategyList[idx]);
                strategyList[idx] = strategyList[idx].Trim();
            }

            data.baseDS.stockCodeExtRow stockCodeRow;
            for (int rowId = 0; rowId < stockCodeList.Count; rowId++)
            {
                stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCodeExt, stockCodeList[rowId]);
                if (stockCodeRow == null) continue;
                DataRow row = testRetsultTbl.Rows.Add(stockCodeList[rowId]);
                analysisData.Init(dateRangeEd.myTimeScale,dateRangeEd.frDate, dateRangeEd.toDate, stockCodeRow);
                for (int colId = 0; colId < strategyList.Count; colId++)
                {
                    decimal revenue = 0;

                    analysis.analysisResult advices = appHub.strategy.TradeAnalysis(analysisData, strategyList[colId]);
                    if (advices != null)
                    {
                        myTmpDS.tradeEstimate.Clear();
                        analysis.EstimateAdvice(analysisData, advices,new application.analysis.estimateOptions(), myTmpDS.tradeEstimate);

                        revenue = (myTmpDS.tradeEstimate.Count == 0 ? 0 : revenue = myTmpDS.tradeEstimate[myTmpDS.tradeEstimate.Count - 1].revenue);
                    }
                    row[colId + 1] = revenue;
                }
                progressBar.Value++;
                Application.DoEvents();
            }
            SetEstimateStrateDataGrid(analysis.GetStrategyStats(testRetsultTbl));
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
                dateRangeEd.myTimeRange = application.myTypes.timeRanges.YTD;
                FormResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
       
        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (!DataValidate()) return;
                progressBar.Visible = true;
                this.myFormMode = formMode.OptionWithData; 
                DateTime startTime = DateTime.Now;
                BackTest();
                this.fullScreenBtn.Enabled = true;
                this.oneStockEstimateBtn.Enabled = true;
                this.strategyEstimateBtn.Enabled = true;

                DateTime endTime = DateTime.Now;
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

        private void chartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (testResultDataGrid.DataSource == null) return;
                myBackTestingChartForm.ShowChart((DataTable)testResultDataGrid.DataSource);
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
                if (testResultDataGrid.CurrentRow == null) return;
                string stockCode = testResultDataGrid.CurrentRow.Cells[0].Value.ToString();
                if (e.ColumnIndex == 0)
                {
                    ShowAnalysisForm(stockCode,dateRangeEd);
                    return;
                }
                string strategyCode = strategyClb.myCheckedValues[e.ColumnIndex - 1];
                data.baseDS.strategyRow strategyRow = application.dataLibs.FindAndCache(myDataSet.strategy, strategyCode);
                data.baseDS.stockCodeExtRow stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCodeExt, stockCode);
                ShowEstimationForm(stockCodeRow, strategyRow,dateRangeEd.myTimeScale, dateRangeEd.frDate, dateRangeEd.toDate);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void ShowAnalysisForm(string stockCode,baseClass.controls.chartTiming  timing)
        {
            data.baseDS.stockCodeExtRow stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCodeExt, stockCode);
            myTradeAnalysisForm.ShowForm(stockCodeRow, timing); 
        }
        private void ShowEstimationForm(data.baseDS.stockCodeExtRow stockCodeRow, data.baseDS.strategyRow strategyRow, 
                                        myTypes.timeScales timeScale, DateTime frDate, DateTime toDate)
        {
            analysis.workData data = new analysis.workData(timeScale, frDate, toDate, stockCodeRow);
            analysis.analysisResult advices = appHub.strategy.TradeAnalysis(data, strategyRow.code);
            if (advices != null)
            {
                myAdviceEstimateForm.Init(data,advices);
                myAdviceEstimateForm.ShowForm();
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                interfaces.ShowEstimateOptionForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void fullScreenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.myFormMode == formMode.OptionOnly)
                {
                    this.myFormMode = formMode.DataOnly;
                    return;
                }
                this.myFormMode = (this.myFormMode == formMode.DataOnly ? formMode.OptionWithData : formMode.DataOnly);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void strategyEstimateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                strategyEstDataGrid.Visible = !strategyEstDataGrid.Visible;
                DataPartResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void exportTestResultBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (testResultDataGrid.DataSource == null) return;
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
                common.Export.ExportToExcel((DataTable)testResultDataGrid.DataSource, saveFileDialog.FileName);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void exportStrategyStatsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (testResultDataGrid.DataSource == null) return;
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
                common.Export.ExportToExcel((DataTable)strategyEstDataGrid.DataSource, saveFileDialog.FileName);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void baseBackTesting_ResizeEnd(object sender, EventArgs e)
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

        private void stockCodeOptionCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                portfolioCb.Enabled = stockCodeOptionCb.SelectedIndex==0;
                stockCodeSelect.Enabled = !portfolioCb.Enabled;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}
