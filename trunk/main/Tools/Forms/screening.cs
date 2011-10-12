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
                strategyDescEd.BackColor = strategyCb.BackColor;
                stockCodeLb.LoadData();
                resultDataGrid.DisableReadOnlyColumn = false;
                LoadScreeningCodes();
                LockOptions(true);
                CreateContextMenu();
                minScrollBar.Maximum = Int32.MaxValue-1;
                maxScrollBar.Maximum = Int32.MaxValue-1;
                editColumn.myImageType = common.controls.imageType.Edit;
                LockOptions(criteriaSource.Count <= 0);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("screening");
            criteriaLbl.Text = language.GetString("criteria");
            descriptionLbl.Text = language.GetString("description");
            minLbl.Text = language.GetString("min");
            maxLbl.Text = language.GetString("max");
            addBtn.Text = language.GetString("add");
            delBtn.Text = language.GetString("delete");
            codeListLbl.Text = language.GetString("codeList");

            codeColumn.HeaderText = language.GetString("criteria");
            minColumn.HeaderText = language.GetString("min");
            maxColumn.HeaderText = language.GetString("max");

            stockCodeLb.SetLanguage();
            strategyCb.SetLanguage();
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

        private bool fExecute = false;
        public void Execute()
        {
            if (fExecute) return;
            fExecute = true;
            try
            {
                this.ShowMessage("");
                if (!DataValidate()) return;
                progressBar.Visible = true;
                this.myFormMode = formMode.OptionWithData;
                DateTime startTime = DateTime.Now;
                DoScreening();
                this.fullViewMenuItem.Enabled = true;
                this.exportResultMenuItem.Enabled = true;
                DateTime endTime = DateTime.Now;
                this.ShowMessage(language.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(endTime.Subtract(startTime)));
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

        public void Export()
        {
            if (resultDataGrid.DataSource == null)
            {
                common.system.ShowErrorMessage(language.GetString("noData"));
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
            string[] screeningKeys = Strategy.Data.MetaList.Keys;
            object[] screeningValues = Strategy.Data.MetaList.Values;
            Data.tmpDataSet.screeningCodeRow row;
            for (int idx = 0; idx < screeningKeys.Length; idx++)
            {
                Strategy.Meta meta = (Strategy.Meta)screeningValues[idx];
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
                    column.HeaderText = Strategy.Libs.GetMetaName(tbl.Columns[idx].ColumnName);
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
                    optionPnl.Height = this.ClientRectangle.Height - optionPnl.Location.Y - 10;
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
            DataTable testRetsultTbl = CreateDataTable(strategyList);
            SetDataGrid(resultDataGrid, testRetsultTbl);

            progressBar.Value = 0; progressBar.Minimum=0; progressBar.Maximum = stockCodeList.Count;
            data.baseDS.stockCodeRow stockCodeRow;
            bool fMatched = false;
            for (int rowId = 0; rowId < stockCodeList.Count; rowId++)
            {
                fMatched = false;
                stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCodeList[rowId]);
                if (stockCodeRow == null) continue;
                DataRow row = testRetsultTbl.NewRow();
                row[0] = stockCodeList[rowId];
                application.Data analysisData = new application.Data(Settings.sysScreeningTimeRange, Settings.sysScreeningTimeScale, stockCodeRow.code);
                for (int colId = 0; colId < strategyList.Count; colId++)
                {
                    //Analysis cached data so we MUST clear cache to ensure the system run correctly
                    Strategy.Data.ClearCache();
                    Strategy.TradePoints tradePoints = Strategy.Libs.Analysis(analysisData, strategyList[colId]);
                    // BusinessInfo.Weight value is used as estimation value. The higher value, the better chance to match user need.
                    if (tradePoints != null && tradePoints.Count>0)
                    {
                        weight = (decimal)tradePoints.GetItem(tradePoints.Count - 1).BusinessInfo.Weight;
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
                }
                if (fMatched) testRetsultTbl.Rows.Add(row);
                progressBar.Value++;
                Application.DoEvents();
            }
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

            resultDataGrid.ContextMenuStrip = contextMenuStrip;
        }

        private void EditScreeningOption(string code)
        {
            Strategy.Meta meta = Strategy.Libs.FindMetaByName(code);
            if (meta == null) return;
            Strategy.Libs.ShowStrategyForm(meta);
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
                    data.baseDS.stockCodeRow stockCodeRow;
                    stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                    if (stockCodeRow != null) ShowStock(stockCodeRow, Settings.sysScreeningTimeRange, Settings.sysScreeningTimeScale);
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
                FormResize();
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
                data.baseDS.stockCodeRow stockCodeRow;
                if (resultDataGrid.SelectedRows.Count > 0)
                {
                    for (int idx = 0; idx < resultDataGrid.SelectedRows.Count; idx++)
                    {
                        stockCode = resultDataGrid.SelectedRows[idx].Cells[0].Value.ToString();
                        stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                        if (stockCodeRow != null) ShowStock(stockCodeRow,Settings.sysScreeningTimeRange, Settings.sysScreeningTimeScale);
                    }
                }
                else
                {
                    if (resultDataGrid.CurrentRow != null)
                    {
                        stockCode = resultDataGrid.CurrentRow.Cells[0].Value.ToString();
                        stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, stockCode);
                        if (stockCodeRow != null) ShowStock(stockCodeRow, Settings.sysScreeningTimeRange, Settings.sysScreeningTimeScale);
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
                if(stockCodes.Count>0) this.AddStockToWatchList(stockCodes);
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
                //minLbl.Text = "Min : " + minScrollBar.Value.ToString(application.Settings.sysLocalAmtMask);
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
                //maxLbl.Text = "Max : " + maxScrollBar.Value.ToString(application.Settings.sysLocalAmtMask);
                criteriaSource.EndEdit();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void strategyCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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
        #endregion
    }
}
