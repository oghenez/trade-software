using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using application;

namespace stockTrade.controls
{
    public partial class _tradeAlertList : common.control.baseUserControl
    {
        public _tradeAlertList()
        {
            try
            {
                InitializeComponent();
                tradeAlertSource.DataSource = tradeAlertTbl;

                commonStatusTbl = myTypes.CreateCommonStatusTable();
                commonStatusSource.DataSource = commonStatusTbl;
                timeScaleTbl = myTypes.CreateTimeScaleTable();
                timeScaleSource.DataSource = timeScaleTbl;
                SetDataGrid();
                AutoResize();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
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

        public string myPortfolioCode = "", myStockCode = "";
        private DataTable commonStatusTbl, timeScaleTbl;
        protected data.baseDS.tradeAlertDataTable tradeAlertTbl = new data.baseDS.tradeAlertDataTable();

        private forms.baseTradeAlertEdit _myTradeAlertEditForm = null;
        private forms.baseTradeAlertEdit myTradeAlertEditForm
        {
            get
            {
                if (_myTradeAlertEditForm == null || _myTradeAlertEditForm.IsDisposed)
                    _myTradeAlertEditForm = GetTradeAlertEditForm();
                return _myTradeAlertEditForm;
            }
        }
        protected virtual forms.baseTradeAlertEdit GetTradeAlertEditForm()
        {
            return new forms.baseTradeAlertEdit();
        }

        private forms.baseAlertFilter _myAlertFilterForm = null;
        private forms.baseAlertFilter myAlertFilterForm
        {
            get
            {
                if (_myAlertFilterForm == null || _myAlertFilterForm.IsDisposed)
                {
                    _myAlertFilterForm = GetAlertFilterForm();
                    _myAlertFilterForm.myOnAccept += new common.forms.baseDialogForm.onProcess(DoAlertFilter);
                }
                return _myAlertFilterForm;
            }
        }
        protected virtual forms.baseAlertFilter GetAlertFilterForm()
        {
            return new forms.baseAlertFilter();
        }

        private forms.baseTradeOrderNewFromAlert _myNewTradeOrderForm = null;
        private forms.baseTradeOrderNewFromAlert myNewTradeOrderForm
        {
            get
            {
                if (_myNewTradeOrderForm == null || _myNewTradeOrderForm.IsDisposed)
                    _myNewTradeOrderForm = GetNewTradeOrderForm();
                return _myNewTradeOrderForm;
            }
        }
        protected virtual forms.baseTradeOrderNewFromAlert GetNewTradeOrderForm()
        {
            return new forms.baseTradeOrderNewFromAlert();
        }

        public delegate void onCellClick(gridColumnName colName,data.baseDS.tradeAlertRow row);
        public event onCellClick myOnCellClick = null;
        public enum gridColumnName { OnTime, Subject, StockCode,Strategy,TimeScale,Status,View,Cancel };

        public virtual void LoadData()
        {
            tradeAlertTbl.Clear();
            myAlertFilterForm.myPortfolio = this.myPortfolioCode;
            myAlertFilterForm.myStockCode = this.myStockCode;
            application.dataLibs.LoadFromSQL(tradeAlertTbl, myAlertFilterForm.GetSQL());
        }

        public void SetColumnVisible(string[] colName, bool visible)
        {
            //Hide all column first
            for (int idx = 0; idx < dataGrid.ColumnCount; idx++) dataGrid.Columns[idx].Visible = false;
            for (int idx = 0; idx < colName.Length; idx++)
                SetColumnVisible(colName[idx], visible);
        }
        public void SetColumnVisible(string colName, bool visible)
        {
            colName = colName.ToUpper();
            for (int idx = 0; idx < dataGrid.ColumnCount; idx++)
            {
                if (dataGrid.Columns[idx].Name.ToUpper() == colName)
                {
                    dataGrid.Columns[idx].Visible = visible;
                    break;
                }
            }
        }

        public bool IsToolBarVisible
        {
            get
            {
                return toolBarPnl.Visible;
            }
            set
            {
                toolBarPnl.Visible = value;
                showHideBtn.Image = (value ? Properties.Resources.hide : Properties.Resources.show);
                AutoResize();
            }
        }

        public void AutoResize()
        {
            showHideBtn.Location = new Point(this.Width - showHideBtn.Width-7,2);
            toolBarPnl.Location = new Point(0,0);
            if (this.IsToolBarVisible)
            {
                dataGrid.Location = new Point(0, toolBarPnl.Location.Y + toolBarPnl.Height );
                dataGrid.Width = this.Width;
                dataGrid.Height = this.Height - dataGrid.Location.Y;
            }
            else
            {
                dataGrid.Location = new Point(0, 0);
                dataGrid.Width = this.Width;
                dataGrid.Height = this.Height;
            }
            common.system.AutoFitGridColumn(dataGrid, strategyColumn.Name);
            toolBarPnl.BringToFront();
            showHideBtn.BringToFront();
        }

        private void DoAlertFilter(object sender)
        {
            try
            {
                common.system.ShowCurrorWait();
                LoadData();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
            finally
            {
                common.system.ShowCurrorDefault();
            }
        }
        
        private System.Windows.Forms.DataGridViewTextBoxColumn onTimeColumn = new DataGridViewTextBoxColumn();
        private System.Windows.Forms.DataGridViewTextBoxColumn stockCodeColumn = new DataGridViewTextBoxColumn();
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectColumn = new DataGridViewTextBoxColumn();
        private System.Windows.Forms.DataGridViewTextBoxColumn strategyColumn = new DataGridViewTextBoxColumn();
        private System.Windows.Forms.DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
        private System.Windows.Forms.DataGridViewComboBoxColumn timeScaleColumn = new DataGridViewComboBoxColumn();
        private common.control.gridViewImageColumn cancelColumn = new common.control.gridViewImageColumn();
        private common.control.gridViewImageColumn viewColumn = new common.control.gridViewImageColumn();

        protected void SetDataGrid()
        {
            data.baseDS.tradeAlertDataTable tbl = new data.baseDS.tradeAlertDataTable();
            // 
            // onTimeColumn
            // 
            this.onTimeColumn.Name = gridColumnName.OnTime.ToString();
            this.onTimeColumn.DataPropertyName = tbl.onTimeColumn.ColumnName;
            this.onTimeColumn.HeaderText = "Thời gian";
            this.onTimeColumn.ReadOnly = true;
            this.onTimeColumn.Width = 160;

            // 
            // stockCodeColumn
            // 
            this.stockCodeColumn.Name = gridColumnName.StockCode.ToString();
            this.stockCodeColumn.DataPropertyName = tbl.stockCodeColumn.ColumnName;
            this.stockCodeColumn.HeaderText = "Mã CK";
            this.stockCodeColumn.ReadOnly = true;
            this.stockCodeColumn.Width = 80;
            // 
            // subjectColumn
            // 
            this.subjectColumn.Name = gridColumnName.Subject.ToString();
            this.subjectColumn.DataPropertyName = tbl.subjectColumn.ColumnName;
            this.subjectColumn.HeaderText = "";
            this.subjectColumn.ReadOnly = true;
            this.subjectColumn.Width = 70;
            
            // 
            // strategyColumn
            // 
            this.strategyColumn.Name = gridColumnName.Strategy.ToString();
            this.strategyColumn.DataPropertyName = tbl.strategyColumn.ColumnName;
            this.strategyColumn.HeaderText = "Chiến lược";
            this.strategyColumn.ReadOnly = true;
            this.strategyColumn.Width = 100;
            this.strategyColumn.Visible = true;
            // 
            // statusColumn
            // 
            this.statusColumn.Name = gridColumnName.Status.ToString();            
            this.statusColumn.DataPropertyName = tbl.statusColumn.ColumnName;
            this.statusColumn.DisplayMember = commonStatusTbl.Columns[1].ColumnName;
            this.statusColumn.ValueMember = commonStatusTbl.Columns[0].ColumnName;
            this.statusColumn.DataSource = commonStatusSource;
            this.statusColumn.HeaderText = "";
            
            this.statusColumn.ReadOnly = true;
            this.statusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.statusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.statusColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            this.statusColumn.Width = 50;

            // 
            // timeScaleColumn
            // 
            this.timeScaleColumn.Name = gridColumnName.TimeScale.ToString();
            this.timeScaleColumn.DataPropertyName = tbl.timeScaleColumn.ColumnName;
            this.timeScaleColumn.DisplayMember = timeScaleTbl.Columns[1].ColumnName;
            this.timeScaleColumn.ValueMember = timeScaleTbl.Columns[0].ColumnName;
            this.timeScaleColumn.DataSource = timeScaleSource;
            this.timeScaleColumn.HeaderText = "Loại";

            this.timeScaleColumn.ReadOnly = true;
            this.timeScaleColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.timeScaleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.timeScaleColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            this.timeScaleColumn.Width = 70;

            // 
            // cancelColumn
            // 
            this.cancelColumn.Name = gridColumnName.Cancel.ToString();
            this.cancelColumn.HeaderText = "";
            this.cancelColumn.myValue = "";
            this.cancelColumn.ReadOnly = true;
            this.cancelColumn.Width = 25;
            this.cancelColumn.myImageType = common.control.imageType.Cancel;
            
            // 
            // viewColumn
            // 
            this.viewColumn.Name = gridColumnName.View.ToString();
            this.viewColumn.HeaderText = "";
            this.viewColumn.myValue = "";
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
            AutoResize();
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
            this.myNewTradeOrderForm.ShowForm(row);
        }

        private void tradeAlertList_Resize(object sender, EventArgs e)
        {
            try
            {
                AutoResize();
            }
            catch (Exception er)
            {
                this.ErrorHandler(sender,er);
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
                this.ErrorHandler(sender, er);
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
                this.ErrorHandler(sender,er);
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
                this.ErrorHandler(sender,er);
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
                this.ErrorHandler(sender,er);
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
                this.ErrorHandler(sender, er);
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
                this.ErrorHandler(sender, er);
            }
        }
        private void ignoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage("Xin vui lòng chọn các dòng cần hủy !");
                    return;
                }
                IgnnoreAlerts();
            }
            catch (Exception er)
            {
                this.ErrorHandler(sender,er);
            }
        }
        private void recoverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrid.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage("Xin vui lòng chọn các dòng phục hồi !");
                    return;
                }
                RecoverAlerts();
            }
            catch (Exception er)
            {
                this.ErrorHandler(sender,er);
            }
        }

        private void showHideBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.IsToolBarVisible = !this.IsToolBarVisible;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
    }
}