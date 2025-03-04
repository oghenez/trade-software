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
using commonTypes;
using commonClass;

namespace Trade.Forms
{
    public partial class  tradeAlertList : baseClass.forms.baseForm
    {
        private BackgroundWorker bgWorker = new BackgroundWorker();
        public tradeAlertList()
        {
            try
            {
                InitializeComponent();
                common.dialogs.SetFileDialogEXCEL(saveFileDialog);

                stockCodeSource.DataSource = DataAccess.Libs.myStockCodeTbl;
                tradeActionSource.DataSource = application.AppLibs.GetTradeActions();
                timeScaleSource.DataSource = application.AppLibs.GetTimeScales();
                CommonStatusSource.DataSource = application.AppLibs.GetCommonStatus();
                SetDataGrid();

                this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("tradeAlert");
            onDateColumn.HeaderText = Languages.Libs.GetString("onDate");
            codeColumn.HeaderText = Languages.Libs.GetString("code");
            strategyColumn.HeaderText = Languages.Libs.GetString("strategy");
            timeScaleColumn.HeaderText = Languages.Libs.GetString("timeScale");
            msgColumn.HeaderText = Languages.Libs.GetString("information");
            actionColumn.HeaderText = Languages.Libs.GetString("tradeAction");

            sumOnDateColumn.HeaderText = Languages.Libs.GetString("onDate");
            sumCodeColumn.HeaderText = Languages.Libs.GetString("code");
            sumNameColumn.HeaderText = Languages.Libs.GetString("description");
            sumMessageColumn.HeaderText = Languages.Libs.GetString("alertSummary");

            sumNameColumn.DisplayMember = (commonClass.SysLibs.IsUseVietnamese() ? myTmpDS.stockCode.nameColumn.ColumnName : 
                                              myTmpDS.stockCode.nameEnColumn.ColumnName); 

            myAlertFilterForm.SetLanguage();
            LoadData(true);
        }

        public enum gridColumnName { OnTime, TradeAction, StockCode, Strategy, TimeScale, Status, View};
        public virtual void  Init()
        {
            databases.tmpDS.codeListDataTable strategyTbl = new databases.tmpDS.codeListDataTable();
            application.Strategy.StrategyLibs.LoadStrategy(strategyTbl, AppTypes.StrategyTypes.Strategy);
            strategySource.DataSource = strategyTbl;

            DateTime lastAlertDate = DataAccess.Libs.GetLastAlertTime(commonClass.SysLibs.sysLoginCode);
            DateTime onDate = DataAccess.Libs.GetServerDateTime();
            if (lastAlertDate == common.Consts.constNullDate) lastAlertDate = onDate;
            lastAlertDate = lastAlertDate.Date;

            SetFilterDateRange(lastAlertDate, onDate);
            SetFilterDateRangeStat(true, true);
            SetFilterStatus(AppTypes.CommonStatus.New);
            
        }

        public delegate void onCellClick(gridColumnName colName, databases.baseDS.tradeAlertRow row);
        public event onCellClick myOnCellClick = null;

        public ContextMenuStrip myContextMenuStrip
        {
            get 
            { 
                return detailGrid.ContextMenuStrip; 
            }
            set 
            { 
                this.detailGrid.ContextMenuStrip = value;
                this.summaryGrid.ContextMenuStrip = value; 
            }
        }        

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
        public databases.baseDS.tradeAlertRow CurrentRow
        {
            get
            {
                if (tradeAlertSource.Current == null) return null;
                return (databases.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
            }
        }

        public databases.baseDS.tradeAlertRow CurrentSummaryRow
        {
            get
            {
                if (alertSummarySource.Current == null) return null;
                return (databases.baseDS.tradeAlertRow)((DataRowView)alertSummarySource.Current).Row;
            }
        }

        public void Export()
        {
            if (summaryGrid.DataSource == null)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel(myDataSet.tradeAlert, saveFileDialog.FileName);
        }
        public void FormResize()
        {
            common.system.AutoFitGridColumn(detailGrid, strategyColumn.Name);
            common.system.AutoFitGridColumn(summaryGrid, sumNameColumn.Name);
        }
        public void SetColumnVisible(string[] colName, bool visible)
        {
            summaryGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        public void SetColumnVisible(string colName, bool visible)
        {
            summaryGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        public void SetFilterDateRangeDefault()
        {
            myAlertFilterForm.myFromDate = DataAccess.Libs.GetServerDateTime();
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
        public void SetFilterStatus(AppTypes.CommonStatus status)
        {
            myAlertFilterForm.myStatus =  status;
        }
        public virtual void LoadData(bool force)
        {
            databases.baseDS.tradeAlertDataTable tradeAlertTbl = DataAccess.Libs.GetTradeAlert_BySQL(myAlertFilterForm.GetSQL());
            for (int idx =0; idx<tradeAlertTbl.Count; idx++)
            {
                if (tradeAlertTbl[idx].RowState == DataRowState.Deleted) continue;
                tradeAlertTbl[idx].msg = AppLibs.AlertMessageText(tradeAlertTbl[idx].msg, "      ");
            }

            tradeAlertSource.DataSource = tradeAlertTbl;
            alertSummarySource.DataSource = AppLibs.MakeAlertSummary(tradeAlertSource.DataSource as databases.baseDS.tradeAlertDataTable);
            SetDataGrid();
            ShowReccount(alertSummarySource.Count);
        }

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

        
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //LoadData((bool)e.Argument);
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        LoadData((bool)e.Argument);
                        Refresh();
                    });
                }
                else
                {
                    LoadData((bool)e.Argument);
                    Refresh();
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public void RefreshData(bool force)
        {
            if (this.bgWorker.IsBusy) return;
            this.bgWorker.RunWorkerAsync(force);
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
                LoadData(false);
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
            databases.baseDS.tradeAlertRow row = (databases.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
            EditTradeAlert(row.id);
        }
        public void PlaceOrder()
        {
            if (this.CurrentRow == null) return;
            this.myNewTradeOrderForm.ShowNew(this.CurrentRow);
        }
        protected void SetDataGrid()
        {
            this.onDateColumn.Name = gridColumnName.OnTime.ToString();
            this.codeColumn.Name = gridColumnName.StockCode.ToString();
            this.actionColumn.Name = gridColumnName.TradeAction.ToString();
            this.strategyColumn.Name = gridColumnName.Strategy.ToString();
            this.statusColumn.Name = gridColumnName.Status.ToString();
            this.viewColumn.Name = gridColumnName.View.ToString();
            
            this.viewColumn.myImageType = common.controls.imageType.Edit;
            this.toDetailBtn.myImageType = common.controls.imageType.Detail;
            this.toSummaryBtn.myImageType = common.controls.imageType.Detail;
        }

        #region event handler
        private void tradeAlertList_Resize(object sender, EventArgs e)
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
                this.ShowError(er);
                this.fOnProccessing = false;
            }
        }
        private void detailGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0 && detailGrid.Columns[e.ColumnIndex] == toSummaryBtn)
                    mainTab.SelectedTab = summaryPg;

                databases.baseDS.tradeAlertRow alertRow; 
                if (this.tradeAlertSource.Current == null || e == null) return;

                if (detailGrid.Columns[e.ColumnIndex].Name == gridColumnName.View.ToString())
                {
                    alertRow = (databases.baseDS.tradeAlertRow)((DataRowView)tradeAlertSource.Current).Row;
                    EditTradeAlert(alertRow.id);
                    return;
                }
                if (this.tradeAlertSource.Current == null || e == null || myOnCellClick == null) return;
                foreach (gridColumnName item in Enum.GetValues(typeof(gridColumnName)))
                {
                    if (item.ToString() != summaryGrid.Columns[e.ColumnIndex].Name) continue;
                    myOnCellClick(item, (databases.baseDS.tradeAlertRow)((DataRowView)this.tradeAlertSource.Current).Row);
                    break;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void summaryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex>=0 && summaryGrid.Columns[e.ColumnIndex] == toDetailBtn)
                    mainTab.SelectedTab = detailPg;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
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
        private void mainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (mainTab.SelectedTab == summaryPg)
                    common.system.AutoFitGridColumn(summaryGrid, sumNameColumn.Name);
                else
                {
                    string stockcode = "";
                    if (alertSummarySource.Current != null)
                    {
                        stockcode = ((databases.baseDS.tradeAlertRow)(alertSummarySource.Current as DataRowView).Row).stockCode;
                    }
                    tradeAlertSource.Filter = myDataSet.tradeAlert.stockCodeColumn.ColumnName + "='" + stockcode + "'"; 
                    common.system.AutoFitGridColumn(detailGrid, strategyColumn.Name);
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}