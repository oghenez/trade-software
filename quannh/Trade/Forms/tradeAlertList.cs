using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AdvancedDataGridView;
using application;

namespace Trade.Forms
{
    public partial class  tradeAlertList : common.forms.baseForm
    {
        public tradeAlertList()
        {
            try
            {
                InitializeComponent();
                toolBarPnl.isVisible = true;
                common.dialogs.SetFileDialogEXCEL(saveFileDialog);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public enum gridColumnName { OnTime, Subject, StockCode, Strategy, TimeScale, Status, View, Cancel };
        public virtual void  Init()
        {
            dataLibs.LoadData(myDataSet.strategy, true);
            CommonStatusTbl = AppTypes.CreateTableCommonStatus();
            timeScaleTbl = AppTypes.CreateTableTimeScale();
            CommonStatusSource.DataSource = CommonStatusTbl;
            timeScaleSource.DataSource = timeScaleTbl;

            DateTime onDate = application.sysLibs.GetServerDateTime();
            SetFilterDateRange(onDate, onDate);
            SetFilterDateRangeStat(true, true);
            SetFilterStatus(AppTypes.CommonStatus.New);
            SetDataGrid();
        }

        public delegate void onCellClick(gridColumnName colName, data.baseDS.tradeAlertRow row);
        public event onCellClick myOnCellClick = null;
        
        private string _myPortfolioCode = "";
        public string myPortfolioCode
        {
            get {return _myPortfolioCode; }
            set 
            {
                _myPortfolioCode = value; 
                myAlertFilterForm.myPortfolio = value; 
            }
        }
        private string _myStockCode = "";
        public string myStockCode
        {
            get {return _myStockCode; }
            set 
            {
                _myStockCode = value; 
                myAlertFilterForm.myStockCode = value; 
            }
        }

        public void Export()
        {
            if (dataGrid.DataSource == null)
            {
                common.system.ShowErrorMessage("Không có dữ liệu.");
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel(myDataSet.tradeAlert, saveFileDialog.FileName);
        }
        public bool ToolBarShowState
        {
            get { return this.toolBarPnl.isExpanded; }
            set 
            {
                this.toolBarPnl.isExpanded = value;
                FormResize();
            }
        }
        public void FormResize()
        {
            toolBarPnl.Location = new Point(0, 0);
            toolBarPnl.Width = this.Width - toolBarPnl.Location.X-2*SystemInformation.BorderSize.Width-2;
            //toolBarPnl.Height = viewBtn.Location.Y + viewBtn.Height + 5;
            if (this.toolBarPnl.isExpanded)
            {
                dataGrid.Location = new Point(0, toolBarPnl.Location.Y + toolBarPnl.Height+2);
                toolBarPnl.BringToFront();
            }
            else
            {
                dataGrid.Location = new Point(0, 0);
            }
            dataGrid.Size  = new Size(this.Width-5,this.ClientRectangle.Height - dataGrid.Location.Y); // - SystemInformation.CaptionHeight);
            common.system.AutoFitGridColumn(dataGrid, strategyColumn.Name);
            toolBarPnl.BringToFront();
        }
        public void SetColumnVisible(string[] colName, bool visible)
        {
            dataGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        public void SetColumnVisible(string colName, bool visible)
        {
            dataGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        public void SetFilterDateRangeDefault()
        {
            myAlertFilterForm.myFromDate = application.sysLibs.GetServerDateTime();
            myAlertFilterForm.myToDate = myAlertFilterForm.myFromDate;
        }
        public void SetFilterDateRange(DateTime frDate,DateTime toDate)
        {
            myAlertFilterForm.myFromDate = frDate;
            myAlertFilterForm.myToDate = toDate;
        }
        public void SetFilterDateRangeStat(bool enable,bool check)
        {
            myAlertFilterForm.SetDateRange(enable,check);
        }
        public void SetFilterPortfolioStat(bool enable, bool check)
        {
            myAlertFilterForm.SetPortfolio(enable, check);
        }
        public void SetFilterStockStat(bool enable, bool check)
        {
            myAlertFilterForm.SetStockCode(enable, check);
        }
        public void SetFilterStatusStat(bool enable, bool check)
        {
            myAlertFilterForm.SetStatus(enable, check);
        }
        public void SetFilterStatus(application.AppTypes.CommonStatus status)
        {
            myAlertFilterForm.myStatus =  status;
        }
        public virtual void LoadData()
        {
            myDataSet.tradeAlert.Clear();
            application.dataLibs.LoadFromSQL(myDataSet.tradeAlert, myAlertFilterForm.GetSQL());
            ShowReccount(myDataSet.tradeAlert.Count);
        }

        private DataTable CommonStatusTbl, timeScaleTbl;

        private Forms.tradeAlertEdit _myTradeAlertEditForm = null;
        private Forms.tradeAlertEdit myTradeAlertEditForm
        {
            get
            {
                if (_myTradeAlertEditForm == null || _myTradeAlertEditForm.IsDisposed)
                    _myTradeAlertEditForm = GetTradeAlertEditForm();
                return _myTradeAlertEditForm;
            }
        }
        protected virtual Forms.tradeAlertEdit GetTradeAlertEditForm()
        {
            return new Forms.tradeAlertEdit();
        }

        private Forms.alertFilter _myAlertFilterForm = null;
        private Forms.alertFilter myAlertFilterForm
        {
            get
            {
                if (_myAlertFilterForm == null || _myAlertFilterForm.IsDisposed)
                {
                    _myAlertFilterForm = GetAlertFilterForm();
                    _myAlertFilterForm.myOnProcess += new common.forms.baseDialogForm.onProcess(DoAlertFilter);
                }
                return _myAlertFilterForm;
            }
        }
        protected virtual Forms.alertFilter GetAlertFilterForm()
        {
            return new Forms.alertFilter();
        }

        private Forms.transactionFromAlert _myNewTradeOrderForm = null;
        private Forms.transactionFromAlert myNewTradeOrderForm
        {
            get
            {
                if (_myNewTradeOrderForm == null || _myNewTradeOrderForm.IsDisposed)
                    _myNewTradeOrderForm = GetNewTradeOrderForm();
                return _myNewTradeOrderForm;
            }
        }
        protected virtual Forms.transactionFromAlert GetNewTradeOrderForm()
        {
            return new Forms.transactionFromAlert();
        }
        
        private void DoAlertFilter(object sender,common.baseDialogEvent e)
        {
            try
            {
                common.system.ShowCurrorWait();
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                common.system.ShowCurrorDefault();
            }
        }
        private void EditTradeAlert(int rowId)
        {
            myTradeAlertEditForm.ShowForm(tradeAlertSource, rowId);
        }
        private void EditTradeAlert()
        {
            if (tradeAlertSource.Current == null) return;
            data.baseDS.tradeAlertRow row = (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
            EditTradeAlert(row.id);
        }
        private bool DeleteTradeAlert(int rowId)
        {
            if (common.system.ShowDialogYesNo("Hủy bỏ cảnh báo ?") == DialogResult.No) return false;
            dataLibs.DeleteTradeAlert(rowId);
            return true;
        }
        private void DeleteTradeAlerts()
        {
            if (dataGrid.SelectedRows.Count == 0)
            {
                common.system.ShowErrorMessage("Xin vui lòng chọn các dòng cần hủy !");
                return;
            }
            if (common.system.ShowDialogYesNo("Hủy bỏ các cảnh báo đã chọn ?") == DialogResult.No) return;
            int count = 0;
            data.baseDS.tradeAlertRow row;
            for (int idx = 0; idx < dataGrid.SelectedRows.Count; idx++)
            {
                row = (data.baseDS.tradeAlertRow)((DataRowView)dataGrid.SelectedRows[idx].DataBoundItem).Row;
                if (row == null) continue;
                dataLibs.DeleteTradeAlert(row.id);
                count++;
                dataGrid.Rows.RemoveAt(dataGrid.SelectedRows[idx].Index); 
            }
            common.system.ShowMessage("Đã hủy bỏ " + count.ToString() + " cảnh báo.");
        }
        private void IgnnoreAlerts()
        {
            data.baseDS.tradeAlertRow alertRow;
            for (int idx = 0; idx < dataGrid.SelectedRows.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)((DataRowView)dataGrid.SelectedRows[idx].DataBoundItem).Row;
                if (alertRow == null) continue;
                dataLibs.CancelTradeAlert(alertRow);
                dataLibs.UpdateData(alertRow);
            }
        }
        private void RecoverAlerts()
        {
            data.baseDS.tradeAlertRow alertRow;
            for (int idx = 0; idx < dataGrid.SelectedRows.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)((DataRowView)dataGrid.SelectedRows[idx].DataBoundItem).Row;
                if (alertRow == null) continue;
                dataLibs.RenewTradeAlert(alertRow);
                dataLibs.UpdateData(alertRow);
            }
        }
        private void PlaceOrder()
        {
            if (dataGrid.CurrentRow == null) return;
            data.baseDS.tradeAlertRow row = (data.baseDS.tradeAlertRow)dataGrid.CurrentRow.DataBoundItem;
            this.myNewTradeOrderForm.ShowNew(row);
        }
        protected void SetDataGrid()
        {
            data.baseDS.tradeAlertDataTable tbl = myDataSet.tradeAlert;
            // 
            // onTimeColumn
            // 
            this.onTimeColumn.Name = gridColumnName.OnTime.ToString();
            this.onTimeColumn.DataPropertyName = tbl.onTimeColumn.ColumnName;

            // 
            // stockCodeColumn
            // 
            this.stockCodeColumn.Name = gridColumnName.StockCode.ToString();
            this.stockCodeColumn.DataPropertyName = tbl.stockCodeColumn.ColumnName;
            this.stockCodeColumn.HeaderText = "Mã CK";
            // 
            // subjectColumn
            // 
            this.subjectColumn.Name = gridColumnName.Subject.ToString();
            this.subjectColumn.DataPropertyName = tbl.subjectColumn.ColumnName;

            // 
            // strategyColumn
            // 
            this.strategyColumn.Name = gridColumnName.Strategy.ToString();
            this.strategyColumn.DataPropertyName = tbl.strategyColumn.ColumnName;
            // 
            // statusColumn
            // 
            this.statusColumn.Name = gridColumnName.Status.ToString();
            this.statusColumn.DataPropertyName = tbl.statusColumn.ColumnName;
            this.statusColumn.DisplayMember = CommonStatusTbl.Columns[1].ColumnName;
            this.statusColumn.ValueMember = CommonStatusTbl.Columns[0].ColumnName;
            this.statusColumn.DataSource = CommonStatusSource;
            this.statusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            // 
            // timeScaleColumn
            // 
            this.timeScaleColumn.Name = gridColumnName.TimeScale.ToString();
            this.timeScaleColumn.DataPropertyName = tbl.timeScaleColumn.ColumnName;
            this.timeScaleColumn.DisplayMember = timeScaleTbl.Columns[1].ColumnName;
            this.timeScaleColumn.ValueMember = timeScaleTbl.Columns[0].ColumnName;
            this.timeScaleColumn.DataSource = timeScaleSource;

            this.timeScaleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeScaleColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            // 
            // cancelColumn
            // 
            this.cancelColumn.Name = gridColumnName.Cancel.ToString();
            this.cancelColumn.ReadOnly = true;
            this.cancelColumn.Width = 25;
            this.cancelColumn.myImageType = common.control.imageType.Cancel;
            this.cancelColumn.Visible = false;

            // 
            // viewColumn
            // 
            this.viewColumn.Name = gridColumnName.View.ToString();
            this.viewColumn.ReadOnly = true;
            this.viewColumn.Width = 25;
            this.viewColumn.myImageType = common.control.imageType.Edit;

            // 
            // dataGrid
            // 
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.DisableReadOnlyColumn = false;
            this.dataGrid.Columns.Clear();
            this.dataGrid.Columns.AddRange(new DataGridViewColumn[]
                {this.onTimeColumn,
                 this.stockCodeColumn,
                 this.strategyColumn,
                 this.timeScaleColumn,
                 this.subjectColumn,
                 this.statusColumn,
                 this.viewColumn,this.cancelColumn});
        }

        #region event handler
        private void tradeAlertList_Resize(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                this.fOnProccessing = true;
                dataGrid.Size = this.Size;
                FormResize();
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
                this.fOnProccessing = false;
            }
        }
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                data.baseDS.tradeAlertRow alertRow; 
                if (this.tradeAlertSource.Current == null || e == null) return;

                if (dataGrid.Columns[e.ColumnIndex].Name == gridColumnName.View.ToString())
                {
                    alertRow = (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
                    EditTradeAlert(alertRow.id);
                    return;
                }
                if (dataGrid.Columns[e.ColumnIndex].Name == gridColumnName.Cancel.ToString())
                {
                    alertRow = (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
                    if(!DeleteTradeAlert(alertRow.id)) return;
                    dataGrid.Rows.RemoveAt(e.RowIndex); 
                    return;
                }

                if (this.tradeAlertSource.Current == null || e == null || myOnCellClick == null) return;
                foreach (gridColumnName item in Enum.GetValues(typeof(gridColumnName)))
                {
                    if (item.ToString() != dataGrid.Columns[e.ColumnIndex].Name) continue;
                    myOnCellClick(item, (data.baseDS.tradeAlertRow)((DataRowView)this.tradeAlertSource.Current).Row);
                    break;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteTradeAlerts();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void viewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EditTradeAlert();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void orderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PlaceOrder();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void showFilterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myAlertFilterForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void ignoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.RowCount == 0) return;
                if (dataGrid.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage("Xin vui lòng chọn các dòng cần hủy !");
                    return;
                }
                IgnnoreAlerts();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void recoverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.RowCount == 0) return;

                if (dataGrid.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage("Xin vui lòng chọn các dòng phục hồi !");
                    return;
                }
                RecoverAlerts();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void toolBarPnl_myOnShowStateChanged(object sender)
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
        #endregion event handler
    }
}