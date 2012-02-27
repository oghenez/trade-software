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
using commonTypes;
using commonClass;

namespace Tools.Forms
{
    public partial class screening : baseTesting
    {
        private const int constDefaultMax = 1000;
        public screening()
        {
            try
            {
                InitializeComponent();
                this.fOnProccessing = true;
                strategyDescEd.BackColor = strategyCb.BackColor;
                stockCodeLb.LoadData();
                LockOptions(true);
                minScrollBar.Maximum = Int32.MaxValue - 1;
                maxScrollBar.Maximum = Int32.MaxValue - 1;
                editColumn.myImageType = common.controls.imageType.Edit;
                LockOptions(criteriaSource.Count <= 0);

                timeScaleCb.BackColor = common.Settings.sysColorDisableBG;
                timeScaleCb.ForeColor = common.Settings.sysColorDisableFG;

                dataCounEd.BackColor = common.Settings.sysColorDisableBG;
                dataCounEd.ForeColor = common.Settings.sysColorDisableFG;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                this.fOnProccessing = false;
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            menuStrip.Text = Languages.Libs.GetString("screening");
            mainMenuItem.Text = Languages.Libs.GetString("screening");
            runMenuItem.Text = Languages.Libs.GetString("run");
            fullViewMenuItem.Text = Languages.Libs.GetString("fullView");
            exportResultMenuItem.Text = Languages.Libs.GetString("exportResult");
            openMenuItem.Text = Languages.Libs.GetString("openChart");
            addToWatchListMenuItem.Text = Languages.Libs.GetString("addToWatchList");

            this.Text = Languages.Libs.GetString("screening");
            maxDataCountLbl.Text = Languages.Libs.GetString("noDataBars");
            timeScaleLbl.Text = Languages.Libs.GetString("timeScale");

            criteriaLbl.Text = Languages.Libs.GetString("criteria");
            descriptionLbl.Text = Languages.Libs.GetString("description");
            minLbl.Text = Languages.Libs.GetString("min");
            maxLbl.Text = Languages.Libs.GetString("max");
            addBtn.Text = Languages.Libs.GetString("add");
            delBtn.Text = Languages.Libs.GetString("delete");
            codeListLbl.Text = Languages.Libs.GetString("codeList");

            codeColumn.HeaderText = Languages.Libs.GetString("criteria");
            minColumn.HeaderText = Languages.Libs.GetString("min");
            maxColumn.HeaderText = Languages.Libs.GetString("max");

            timeScaleCb.LoadData();

            dataCounEd.Value = Settings.sysGlobal.ScreeningDataCount;
            timeScaleCb.myValue = AppTypes.TimeScaleFromCode(Settings.sysGlobal.ScreeningTimeScaleCode);

            stockCodeLb.SetLanguage();
            strategyCb.SetLanguage();

            LoadScreeningCodes();
            CreateContextMenu();
        }
        public static screening GetForm()
        {
            string cacheKey = typeof(screening).FullName;
            screening form = (screening)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new Forms.screening();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
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
                DoScreening();
                this.fullViewMenuItem.Enabled = true;
                this.exportResultMenuItem.Enabled = true;
                DateTime endTime = DateTime.Now;
                this.ShowMessage(Languages.Libs.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(endTime.Subtract(startTime)));
                fOnProccessing = false;
            }
            catch (Exception er)
            {
                fOnProccessing = false;
                this.ShowError(er);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        public void Export()
        {
            if (resultDataGrid.DataSource == null)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel((DataTable)resultDataGrid.DataSource, saveFileDialog.FileName);
        }
        public bool IsFullScreen
        {
            get { return this.myFormMode == formMode.DataOnly; }
            set
            {
                if (value) this.myFormMode = formMode.DataOnly;
                else this.myFormMode = formMode.OptionWithData;
            }
        }

        private void LockOptions(bool state)
        {
            strategyCb.Enabled = !state;
            minScrollBar.Enabled = !state;
            maxScrollBar.Enabled = !state;
        }
        private void LoadScreeningCodes()
        {
            tmpDS.screeningCode.Clear();
            tmpDS.screeningCriteria.Clear();
            string[] screeningKeys = application.Strategy.Data.MetaList.Keys;
            object[] screeningValues = application.Strategy.Data.MetaList.Values;
            Data.tmpDataSet.screeningCodeRow row;
            for (int idx = 0; idx < screeningKeys.Length; idx++)
            {
                application.Strategy.Meta meta = (application.Strategy.Meta)screeningValues[idx];
                if (meta.Type != AppTypes.StrategyTypes.Screening) continue;
                row = tmpDS.screeningCode.NewscreeningCodeRow();
                row.code = meta.Code;
                row.description = meta.Name;
                tmpDS.screeningCode.AddscreeningCodeRow(row);

                //As default add all criteria to allow users select what they need more quickly.
                AddCriteria(row.code, false);
            }
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

        private static void SetDataGrid(DataGridView grid, DataTable tbl)
        {
            grid.DataSource = tbl;

            DataGridViewCellStyle amountCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            amountCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            amountCellStyle.Format = "N" + Settings.sysPrecisionPrice.ToString();
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
                    column.HeaderText = "Codes";
                    column.Width = 60;
                    column.Frozen = true;
                }
                else
                {
                    meta = application.Strategy.Libs.FindMetaByCode(tbl.Columns[idx].ColumnName);
                    column.ToolTipText = meta.Name.Trim();
                    column.HeaderText = meta.ClassType.Name.Trim(); 
                    column.Width = 90;
                    column.DefaultCellStyle = amountCellStyle;
                }
                column.Name = idx.ToString();
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
            switch (this.myFormMode)
            {
                case formMode.OptionOnly:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight-3;
                    this.Width = optionPnl.Width + SystemInformation.CaptionButtonSize.Width;
                    break;
                case formMode.DataOnly:
                    dataPnl.Location = new Point(0, 0);
                    dataPnl.Width = this.ClientRectangle.Width - dataPnl.Location.X;
                    dataPnl.Height = this.ClientRectangle.Height - dataPnl.Location.Y - SystemInformation.CaptionHeight - 3;
                    break;
                case formMode.OptionWithData:
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - SystemInformation.CaptionHeight;

                    dataPnl.Location = new Point(optionPnl.Location.X + optionPnl.Width, 0);
                    dataPnl.Width = this.ClientRectangle.Width - dataPnl.Location.X;
                    dataPnl.Height = this.ClientRectangle.Height - dataPnl.Location.Y - SystemInformation.CaptionHeight - 3;
                    break;
            }
            common.system.AutoFitGridColumn(criteriaGrid, this.codeColumn.Name);
            DataPartResize();
        }
        private void DataPartResize()
        {
            resultDataGrid.Width = dataPnl.Width - resultDataGrid.Location.X;
            resultDataGrid.Height = dataPnl.Height;
        }

        private bool DataValidate()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.stockCodeLb.myValues.Count == 0)
            {
                NotifyError(codeListLbl);
                retVal = false;
            }

            bool fHaveCriteria = false;
            criteriaSource.EndEdit();
            for (int idx = 0; idx < tmpDS.screeningCriteria.Count; idx++)
            {
                tmpDS.screeningCriteria[idx].code = tmpDS.screeningCriteria[idx].code.Trim();
                if (tmpDS.screeningCriteria[idx].code  != "" && tmpDS.screeningCriteria[idx].selected) 
                {
                    fHaveCriteria = true;
                    break;
                }
            }
            if (!fHaveCriteria)
            {
                NotifyError(criteriaGridLbl);
                retVal = false;
            }
            criteriaGrid.Refresh();
            return retVal;
        }
        private void DoScreening()
        {
            decimal weight = 0;
            StringCollection stockCodeList = stockCodeLb.myValues;

            StringCollection strategyList = new StringCollection();
            for (int idx = 0; idx < tmpDS.screeningCriteria.Count; idx++)
            {
                if (tmpDS.screeningCriteria[idx].code != "" && tmpDS.screeningCriteria[idx].selected)
                {
                    if (strategyList.Contains(tmpDS.screeningCriteria[idx].code)) continue;
                    strategyList.Add(tmpDS.screeningCriteria[idx].code);
                }
            }
            DataTable retsultTbl = CreateDataTable(strategyList);
            SetDataGrid(resultDataGrid, retsultTbl);

            //Analysis cached data so we MUST clear cache to ensure the system run correctly
            DataAccess.Libs.ClearCache();

            progressBar.Value = 0; progressBar.Minimum = 0; progressBar.Maximum = stockCodeList.Count;
            this.ShowReccount(progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());

            string[] strategy = common.system.Collection2List(strategyList);
            this.ShowReccount(progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());
            int codeStartIdx=0, codeEndIdx=0;
            DataParams dataParam = new DataParams(timeScaleCb.myValue.Code, AppTypes.TimeRanges.None, (int)dataCounEd.Value);
            while (codeStartIdx < stockCodeList.Count)
            {
                codeEndIdx += Settings.sysNumberOfItemsInBatchProcess;
                if (codeEndIdx >= stockCodeList.Count) codeEndIdx = stockCodeList.Count - 1;

                string[] stocks = common.system.Collection2List(stockCodeList, codeStartIdx, codeEndIdx);
                double[][] weightList = DataAccess.Libs.Estimate_Matrix_LastBizWeight(dataParam, stocks, strategy);

                for (int idx1 = 0, rowId = codeStartIdx; idx1 < weightList.Length; idx1++, rowId++)
                {
                    bool fMatched = false;
                    DataRow row = retsultTbl.NewRow();
                    row[0] = stockCodeList[rowId];

                    for (int colId = 0; colId < weightList[idx1].Length; colId++)
                    {
                        if (double.IsNaN(weightList[idx1][colId])) continue;
                        weight = (decimal)weightList[idx1][colId];
                        DataView criteriaView = new DataView(tmpDS.screeningCriteria);
                        criteriaView.RowFilter = tmpDS.screeningCriteria.codeColumn + "='" + strategyList[colId] + "' AND " +
                                                 tmpDS.screeningCriteria.selectedColumn + "=1";
                        Data.tmpDataSet.screeningCriteriaRow criteriaRow;
                        // If there is more than one criteria for the same code,
                        // matching one criteria is viewed as MATCHED , as OR operaror. 
                        for (int idx = 0; idx < criteriaView.Count; idx++)
                        {
                            criteriaRow = (Data.tmpDataSet.screeningCriteriaRow)criteriaView[idx].Row;
                            if (weight < criteriaRow.min || weight > criteriaRow.max) continue;
                            row[colId + 1] = weight;
                            fMatched = true;
                            break;
                        }
                    }
                    if (fMatched) retsultTbl.Rows.Add(row);
                    Application.DoEvents();
                }
                codeStartIdx = codeEndIdx + 1;
                progressBar.Value = codeEndIdx + 1;
                this.ShowReccount(progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());
                Application.DoEvents();
            }
            common.system.RemoveEmptyItems(retsultTbl);
            SetDataGrid(resultDataGrid, retsultTbl);
            this.ShowReccount(resultDataGrid.Rows.Count);
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
            menuItem = contextMenuStrip.Items.Add(exportResultMenuItem.Text);
            menuItem.Click += new System.EventHandler(exportResultMenuItem_Click);

            resultDataGrid.ContextMenuStrip = contextMenuStrip;
        }

        private void EditScreeningOption(string code)
        {
            application.Strategy.Meta meta = application.Strategy.Libs.FindMetaByCode(code);
            if (meta == null) return;
            application.Strategy.Libs.ShowStrategyForm(meta);
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
        private void okBtn_Click(object sender, EventArgs e)
        {
            Execute();
        }
        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (resultDataGrid.CurrentRow == null) return;
                string stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                if (e.ColumnIndex == 0)
                {
                    //ShowStock(stockCode, Settings.sysScreeningTimeRange, Settings.sysScreeningTimeScale);
                    ShowStock(stockCode, Settings.sysGlobal.DefaultTimeRange, AppTypes.TimeScaleFromCode(Settings.sysGlobal.ScreeningTimeScaleCode));
                    return;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
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
        private void exportResultMenuItem_Click(object sender, EventArgs e)
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
        private void Form_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                this.fOnProccessing = true;
                FormResize();
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.fOnProccessing = false;
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
                        //ShowStock(stockCode, Settings.sysScreeningTimeRange, Settings.sysScreeningTimeScale);
                        ShowStock(stockCode, Settings.sysGlobal.DefaultTimeRange, AppTypes.TimeScaleFromCode(Settings.sysGlobal.ScreeningTimeScaleCode));
                    }
                }
                else
                {
                    if (resultDataGrid.CurrentRow != null)
                    {
                        stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                        //ShowStock(stockCode, Settings.sysScreeningTimeRange, Settings.sysScreeningTimeScale);
                        ShowStock(stockCode, Settings.sysGlobal.DefaultTimeRange, AppTypes.TimeScaleFromCode(Settings.sysGlobal.ScreeningTimeScaleCode));
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
                    if (resultDataGrid.CurrentRow!=null)
                        stockCodes.Add(resultDataGrid.CurrentRow.Cells[0].Value.ToString());
                }
                if(stockCodes.Count>0) baseClass.AppLibs.AddStockToWatchList(stockCodes);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void strategyLbl_Click(object sender, EventArgs e)
        {

        }

        private void AddCriteria(string code,bool selected)
        {
            Data.tmpDataSet.screeningCriteriaRow row = tmpDS.screeningCriteria.NewscreeningCriteriaRow();
            row.code = code;
            row.min = 0;
            row.max = constDefaultMax;
            row.selected = selected;
            tmpDS.screeningCriteria.AddscreeningCriteriaRow(row);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AddCriteria(strategyCb.myValue, true);
                criteriaSource.Position = criteriaSource.Count - 1;
                LockOptions(criteriaSource.Count <= 0);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (criteriaSource.Current != null) criteriaSource.RemoveCurrent();
                LockOptions(criteriaSource.Count<=0);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void minScrollBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //minLbl.Text = "Min : " + minScrollBar.Value.ToString(Settings.sysLocalAmtMask);
                criteriaSource.EndEdit();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }

        }

        private void maxScrollBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //maxLbl.Text = "Max : " + maxScrollBar.Value.ToString(Settings.sysLocalAmtMask);
                criteriaSource.EndEdit();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (strategyCb.myValue == "") return;
                EditScreeningOption(strategyCb.myValue);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void criteriaGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 0) return;
                if (criteriaGrid.Columns[e.ColumnIndex].Name != editColumn.Name) return;
                if (criteriaSource.Current == null) return;
                EditScreeningOption( ((Data.tmpDataSet.screeningCriteriaRow)((DataRowView)criteriaSource.Current).Row).code);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message); 
            }
        }
        private void selectAllChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int idx = 0; idx < tmpDS.screeningCriteria.Count; idx++)
                {
                    if (tmpDS.screeningCriteria[idx].RowState == DataRowState.Deleted) continue;
                    tmpDS.screeningCriteria[idx].selected = selectAllChk.Checked;
                }
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void resultDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex<=0) return;
                this.ShowReccount("["+(e.RowIndex+1).ToString()+"/"+resultDataGrid.Rows.Count.ToString()+"]");
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
        #endregion
    }
}
