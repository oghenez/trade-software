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

namespace stockTrade.forms
{
    public partial class  transactionList : common.forms.baseForm
    {
        public enum gridColumnName { TransType, OnTime, StockCode, Qty, Amt, View };
        public transactionList()
        {
            try
            {
                InitializeComponent();

                this.viewColumn.myImageType = common.control.imageType.Edit;
                tranTypeColumn.Name = gridColumnName.TransType.ToString();
                onTimeColumn.Name = gridColumnName.OnTime.ToString();
                stockCodeColumn.Name = gridColumnName.StockCode.ToString();
                qtyColumn.Name = gridColumnName.Qty.ToString();
                amtColumn.Name = gridColumnName.Amt.ToString();
                viewColumn.Name = gridColumnName.View.ToString();

                filterPnl.isExpanded = false;

                //Load Data
                DataTable tradeActionTbl = application.analysis.CreateTradeActionsTable();
                transactionsSource.DataSource = tradeActionTbl;
                tranTypeColumn.ValueMember = tradeActionTbl.Columns[0].ColumnName;
                tranTypeColumn.DisplayMember = tradeActionTbl.Columns[1].ColumnName;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public void FormResize()
        {
            dataGrid.Location = new Point((this.filterPnl.isExpanded ? filterPnl.Location.Y + filterPnl.Height:0),0);
            dataGrid.Height = this.ClientRectangle.Height - (filterPnl.isExpanded ? filterPnl.Location.Y + filterPnl.Height : 0);
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
        public virtual void LoadData()
        {
            myDataSet.transactions.Clear();
            application.dataLibs.LoadFromSQL(myDataSet.transactions, transactionCriteria.GetSQL(application.sysLibs.sysLoginCode));
            ShowReccount(dataGrid.Rows.Count);
        }

        private forms.transactionBase _myTradeOrderEditForm = null;
        private forms.transactionBase myTradeOrderEditForm
        {
            get
            {
                if (_myTradeOrderEditForm == null || _myTradeOrderEditForm.IsDisposed)
                    _myTradeOrderEditForm = GetTradeOrderEditForm();
                return _myTradeOrderEditForm;
            }
        }
        protected virtual forms.transactionBase GetTradeOrderEditForm()
        {
            return new forms.transactionBase();
        }
        protected virtual forms.transactionFromAlert GetNewTradeOrderForm()
        {
            return new forms.transactionFromAlert();
        }

        private void ViewTransaction(int rowId)
        {
            myTradeOrderEditForm.ShowForm(transactionsSource, rowId);
        }
        private void ViewTransaction()
        {
            if (transactionsSource.Current == null) return;
            data.baseDS.transactionsRow row = (data.baseDS.transactionsRow)((DataRowView)transactionsSource.Current).Row;
            ViewTransaction(row.id);
        }

        #region event handler
        private void transactionList_Resize(object sender, EventArgs e)
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
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.transactionsSource.Current == null || e == null) return;
                if (dataGrid.Columns[e.ColumnIndex].Name == gridColumnName.View.ToString())
                {
                    ViewTransaction();
                }
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
        private void filterPnl_myOnShowStateChanged(object sender)
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