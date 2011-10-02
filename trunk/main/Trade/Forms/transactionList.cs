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
    public partial class  transactionList : common.forms.baseForm
    {
        public enum gridColumnName { TransType, OnTime, StockCode, Qty, Amt, View };
        public transactionList()
        {
            try
            {
                InitializeComponent();

                this.viewColumn.myImageType = common.controls.imageType.Edit;
                tranTypeColumn.Name = gridColumnName.TransType.ToString();
                onTimeColumn.Name = gridColumnName.OnTime.ToString();
                stockCodeColumn.Name = gridColumnName.StockCode.ToString();
                qtyColumn.Name = gridColumnName.Qty.ToString();
                amtColumn.Name = gridColumnName.Amt.ToString();
                viewColumn.Name = gridColumnName.View.ToString();

                //Load Data
                AppTypes.LoadTradeActions(myTmpDS.codeList);

                transactionCriteria.Init();

                //filterPnl.isExpanded = false;
                FormResize();
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public bool IsFilePaneOn
        {
            get
            {
                return filterPnl.isExpanded;
            }
            set
            {
                filterPnl.isExpanded = value;
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
            common.Export.ExportToExcel(myDataSet.transactions, saveFileDialog.FileName);
        }
        
        public static transactionList GetForm(string formName)
        {
            string cacheKey = typeof(transactionList).FullName + (formName == null || formName.Trim()==""? "" : "-" + formName);
            transactionList form = (transactionList)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new transactionList();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        public void ViewTransaction()
        {
            if (transactionsSource.Current == null) return;
            data.baseDS.transactionsRow row = (data.baseDS.transactionsRow)((DataRowView)transactionsSource.Current).Row;
            transactionView form = GetViewForm();
            form.SetEditData(row);
            form.LockEdit(true);
            form.ShowDialog();
        }

        protected void FormResize()
        {
            dataGrid.Location = new Point(0,(this.filterPnl.isExpanded ? filterPnl.Location.Y + filterPnl.Height:0));
            dataGrid.Height = this.ClientRectangle.Height - dataGrid.Location.Y - SystemInformation.CaptionHeight;
            common.system.AutoFitGridColumn(dataGrid, stockNameColumn.Name);
        }
        protected void SetColumnVisible(string[] colName, bool visible)
        {
            dataGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        protected void SetColumnVisible(string colName, bool visible)
        {
            dataGrid.SetColumnVisible(colName, visible);
            FormResize();
        }
        protected virtual void LoadData()
        {
            myDataSet.transactions.Clear();
            application.dataLibs.LoadFromSQL(myDataSet.transactions, transactionCriteria.GetSQL());
            for (int idx = 0; idx < myDataSet.transactions.Count; idx++)
            {
                application.dataLibs.FindAndCache(myDataSet.stockCode, myDataSet.transactions[idx].stockCode);
            }
            ShowReccount(transactionsSource.Count);
        }

        protected virtual Forms.transactionView GetViewForm()
        {
            return Forms.transactionView.GetForm("");
        }
        #region event handler
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