using System;
using System.Collections;
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
    public partial class baseScreening : baseAnalysis
    {
        private DataTable myScrCriteriaTbl = null;
        public baseScreening()
        {
            try
            {
                InitializeComponent();
                strategyClb.LoadData(myTypes.strategyType.Screening,true,false);

                subSectorSelect.LoadData();
                dateRangeEd.LoadData();
                testResultDataGrid.DisableReadOnlyColumn = false;

                myScrCriteriaTbl = CreateCriteriaTable();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private DataTable CreateCriteriaTable()
        {
            //Type data
            DataTable typeTbl = new DataTable();
            DataColumn col1 = new DataColumn("code", typeof(byte)); 
            typeTbl.Columns.Add(col1);

            DataColumn col2 = new DataColumn("description"); 
            typeTbl.Columns.Add(col2);

            foreach (myTypes.screeningCritType item in Enum.GetValues(typeof(myTypes.screeningCritType)))
            {
                DataRow row = typeTbl.Rows.Add((byte)item);
                row[1] = myTypes.Type2Text(item);
            }

            //Binding
            this.scrTypeCol.DataPropertyName = "type";
            this.scrTypeCol.DisplayMember = typeTbl.Columns[1].ColumnName;
            this.scrTypeCol.ValueMember = typeTbl.Columns[0].ColumnName;
            this.scrTypeCol.DataSource = typeTbl;

            this.scrMinCol.DataPropertyName = "min";
            this.scrMaxCol.DataPropertyName = "max";

            //Grid datasource
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("type", typeof(byte)));
            tbl.Columns.Add(new DataColumn("min", typeof(double)));
            tbl.Columns.Add(new DataColumn("max", typeof(double)));
            scrCriteriaGrid.DataSource = tbl;

            common.system.AutoFitGridColumn(scrCriteriaGrid, this.scrTypeCol.Name);
            return tbl;
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
        protected virtual baseTradeAnalysis GetTradeAnalysisForm()
        {
            return new baseTradeAnalysis();
        }

        private enum formMode : byte { OptionOnly = 0, OptionWithData = 1, DataOnly= 2};
        private formMode myFormMode
        {
            get 
            {
                if (dataPnl.Visible)
                {
                    if (xpPanelGroup_Info.Visible) return formMode.OptionWithData;
                    return formMode.DataOnly;
                }
                return formMode.OptionOnly;
            }
            set 
            {
                switch (value)
                {
                    case formMode.DataOnly:
                                  dataPnl.Visible = true; xpPanelGroup_Info.Visible = false;  
                                  break;
                    case formMode.OptionOnly: dataPnl.Visible = false; xpPanelGroup_Info.Visible = true; break;
                    case formMode.OptionWithData:
                                  dataPnl.Visible = true; xpPanelGroup_Info.Visible = true;
                                  this.Width = xpPanelGroup_Info.Width + dataPnl.Width;  
                                  break;
                }
                FormResize();
            }
        }

        private myTypes.screeningCriteria[] GetScrCriteria()
        {
            double val = 0;
            myTypes.screeningCriteria[] criteria = new myTypes.screeningCriteria[0];
            for (int idx = 0; idx < myScrCriteriaTbl.Rows.Count; idx++)
            {
                if (myScrCriteriaTbl.Rows[idx]["type"].ToString() == "") continue;
                Array.Resize(ref criteria, criteria.Length + 1);
                criteria[criteria.Length - 1] = new myTypes.screeningCriteria();
                
                criteria[criteria.Length - 1].code = (myTypes.screeningCritType)myScrCriteriaTbl.Rows[idx]["type"];
                val = 0; double.TryParse(myScrCriteriaTbl.Rows[idx]["min"].ToString(), out val);
                criteria[criteria.Length - 1].min = val;

                val = 0; double.TryParse(myScrCriteriaTbl.Rows[idx]["max"].ToString(), out val);
                criteria[criteria.Length - 1].max = val;
            }
            return criteria;
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
                    xpPanelGroup_Info.Height = this.ClientRectangle.Height - xpPanelGroup_Info.Location.Y - SystemInformation.CaptionHeight;
                    xpPanel_Advance.Height = xpPanelGroup_Info.Height - xpPanel_Advance.Location.Y;
                    subSectorSelect.Height = xpPanel_Advance.Height - subSectorSelect.Location.Y;
                    this.Width = xpPanel_Advance.Width + SystemInformation.CaptionButtonSize.Width; 
                    break;
                case formMode.DataOnly:
                    dataPnl.Location = new Point(0, 0);
                    dataPnl.Width = this.ClientRectangle.Width - dataPnl.Location.X; 
                    dataPnl.Height = this.ClientRectangle.Height- dataPnl.Location.Y - SystemInformation.CaptionHeight-3;
                    break;
                case formMode.OptionWithData:
                    xpPanelGroup_Info.Height = this.ClientRectangle.Height - xpPanelGroup_Info.Location.Y - SystemInformation.CaptionHeight;
                    xpPanel_Advance.Height = xpPanelGroup_Info.Height - xpPanel_Advance.Location.Y;
                    subSectorSelect.Height = xpPanel_Advance.Height - subSectorSelect.Location.Y;

                    dataPnl.Location = new Point(xpPanelGroup_Info.Location.X + xpPanelGroup_Info.Width, 0);
                    dataPnl.Width = this.ClientRectangle.Width - dataPnl.Location.X;
                    dataPnl.Height = this.ClientRectangle.Height - dataPnl.Location.Y-SystemInformation.CaptionHeight-3;
                    break;
            }
            DataPartResize();
        }
        private void DataPartResize()
        {
            testResultDataGrid.Width = dataPnl.Width - testResultDataGrid.Location.X;
            testResultDataGrid.Height = dataPnl.Height;
            AdjustTestGridSize(testResultDataGrid);
        }

        private bool DataValidate()
        {
            bool retVal = true;
            ClearNotifyError();
            //if (this.strategyClb.myCheckedValues.Count==0)
            //{
            //    NotifyError(strategyLbl);
            //    retVal = false;
            //}
            if (!this.dateRangeEd.GetDate())
            {
                NotifyError(strategyLbl);
                retVal = false;
            }
            return retVal;
        }

        private StringCollection GetStockList()
        {
            StringCollection stockCodeList = new StringCollection();

            //Load stocks in selected subsectors if existed
            data.baseDS.stockCodeExtDataTable selectedStockCodeTbl = null;
            StringCollection subSectorCodeList = subSectorSelect.myCheckedValues;
            if (subSectorCodeList != null && subSectorCodeList.Count>0)
            {
                selectedStockCodeTbl = new data.baseDS.stockCodeExtDataTable();
                dataLibs.LoadStockCode_ByBizSectors(selectedStockCodeTbl, subSectorCodeList);
                if (selectedStockCodeTbl.Count==0) 
                {
                    selectedStockCodeTbl.Dispose();
                    selectedStockCodeTbl = null;
                }
            }
            
            //User specify screening criteria ??
            data.baseDS.stockCodeExtDataTable tmpStockCodeTbl = new data.baseDS.stockCodeExtDataTable();
            bool haveScrList = screening.GetStockList(tmpStockCodeTbl, GetScrCriteria());
            if (haveScrList)
            {
                DataView myStockView = new DataView(tmpStockCodeTbl);
                data.baseDS.stockCodeExtRow stockRow;
                myStockView.Sort = tmpStockCodeTbl.codeColumn.ColumnName + "," + tmpStockCodeTbl.stockExchangeColumn.ColumnName;
                for (int idx = 0; idx < myStockView.Count; idx++)
                {
                    stockRow = (data.baseDS.stockCodeExtRow)myStockView[idx].Row;
                    //Ignore stock NOT in selected subsectors
                    if (selectedStockCodeTbl != null && selectedStockCodeTbl.FindBycode(stockRow.code) == null) continue;
                    //Ignore duplicate stocks
                    if (stockCodeList.Contains(stockRow.code)) continue;
                    stockCodeList.Add(stockRow.code);
                }
                return stockCodeList;
            }
            //If user NOT specify screening criteria BUT  specify stock code 
            if (selectedStockCodeTbl != null)
            {
                for (int idx = 0; idx < selectedStockCodeTbl.Count; idx++)
                {
                    //Ignore duplicate stocks
                    if (stockCodeList.Contains(selectedStockCodeTbl[idx].code)) continue;
                    stockCodeList.Add(selectedStockCodeTbl[idx].code);
                }
            }
            return stockCodeList;
        }
        private void Screening()
        {
            StringCollection strategyList = strategyClb.myCheckedValues;
            StringCollection stockCodeList = GetStockList();

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
            this.ShowReccount(stockCodeList.Count);
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
                Screening();
                this.fullScreenBtn.Enabled = true;
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
        #endregion
    }
}
