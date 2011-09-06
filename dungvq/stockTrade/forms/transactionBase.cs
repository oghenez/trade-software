using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace stockTrade.forms
{
    public partial class transactionBase : common.forms.baseForm
    {
        protected data.baseDS.transactionsDataTable myTransactionsTbl = new data.baseDS.transactionsDataTable();
        public transactionBase()
        {
            try
            {
                InitializeComponent();
                transTypeCb.LoadData();
                portfolioCb.LoadData();
                statusCb.LoadData();
                feePercEd.Value = Settings.sysStockTransFeePercent;
                this.myDataSource = new BindingSource();
                this.myDataSource.DataSource = this.myTransactionsTbl;
                dataNavigator.Visible = false;

                //Color
                stockCodeEd.BackColor = common.settings.sysColorNormalBG; stockCodeEd.ForeColor = common.settings.sysColorNormalFG;
                transTypeCb.BackColor = common.settings.sysColorNormalBG; transTypeCb.ForeColor = common.settings.sysColorNormalFG;
                codeEd.BackColor = common.settings.sysColorNormalBG; codeEd.ForeColor = common.settings.sysColorNormalFG;
                portfolioCb.BackColor = common.settings.sysColorNormalBG; portfolioCb.ForeColor = common.settings.sysColorNormalFG;
                onTimeEd.BackColor = common.settings.sysColorNormalBG; onTimeEd.ForeColor = common.settings.sysColorNormalFG;

                qtyEd.BackColor = common.settings.sysColorNormalBG; qtyEd.ForeColor = common.settings.sysColorNormalFG;
                priceEd.BackColor = common.settings.sysColorNormalBG; priceEd.ForeColor = common.settings.sysColorNormalFG;
                subTotalEd.BackColor = common.settings.sysColorHiLightBG1; subTotalEd.ForeColor = common.settings.sysColorHiLightFG1;
                feePercEd.BackColor = common.settings.sysColorNormalBG; feePercEd.ForeColor = common.settings.sysColorNormalFG;
                feeAmtEd.BackColor = common.settings.sysColorNormalBG; feeAmtEd.ForeColor = common.settings.sysColorNormalFG;
                totalAmtEd.BackColor = common.settings.sysColorHiLightBG2; totalAmtEd.ForeColor = common.settings.sysColorHiLightFG2;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private BindingSource _myDataSource = null;
        public BindingSource myDataSource
        {
            get { return _myDataSource; }
            set
            {
                _myDataSource = value;
                if (value != null)
                {
                    _myDataSource.CurrentChanged += new System.EventHandler(this.DataSourceCurrentChanged);
                    DataSourceCurrentChanged(this, null);
                    DataBinding(value);
                }
            }
        }
       
        private void DataBinding(BindingSource dataSource)
        {
            data.baseDS.transactionsDataTable tbl = new data.baseDS.transactionsDataTable();

            this.stockCodeEd.DataBindings.Clear();
            this.stockCodeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.stockCodeColumn.ColumnName, true));

            this.transTypeCb.DataBindings.Clear();
            this.transTypeCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", dataSource, tbl.tranTypeColumn.ColumnName, true));

            this.codeEd.DataBindings.Clear();
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.idColumn.ColumnName, true));

            this.portfolioCb.DataBindings.Clear();
            this.portfolioCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", dataSource, tbl.portfolioColumn.ColumnName, true));

            this.onTimeEd.DataBindings.Clear();
            this.onTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.onTimeColumn.ColumnName, true));

            this.qtyEd.DataBindings.Clear();
            this.qtyEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.qtyColumn.ColumnName, true));

            this.subTotalEd.DataBindings.Clear();
            this.subTotalEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.amtColumn.ColumnName, true));

            this.feeAmtEd.DataBindings.Clear();
            this.feeAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.feeAmtColumn.ColumnName, true));
        }
        /// <summary>
        /// Calculate total,subtotal,fee when qty was changed
        /// </summary>
       
        /// <summary>
        /// Price and fee percentage are not stored in the database so the function calculated the values form others
        /// </summary>
        private void CalculatePriceAndFeePercentage()
        {
            priceEd.Value = (int)((qtyEd.Value == 0 ? 0 : subTotalEd.Value / qtyEd.Value));
            feePercEd.Value = (subTotalEd.Value == 0 ? 0 : (feeAmtEd.Value / subTotalEd.Value) * 100);
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
        }
       
        protected virtual data.baseDS.transactionsRow AddNew()
        {
            this.myTransactionsTbl.Clear();
            data.baseDS.transactionsRow transRow = this.myTransactionsTbl.NewtransactionsRow();
            dataLibs.InitData(transRow);
            feeAmtEd .Value = Settings.sysStockTransFeePercent;
            //Date
            DateTime onTime = sysLibs.GetServerDateTime();
            onTimeEd.myDateTime  = onTime;
            transRow.onTime = onTime;
            this.myTransactionsTbl.AddtransactionsRow(transRow);

            stockCodeEd.Text = "";
            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            priceEd.Value = 0;
            statusCb.myValue = myTypes.CommonStatus.New;

            SetFocus();
            return transRow;
        }

        protected virtual bool Save()
        {
            if (statusCb.myValue == myTypes.CommonStatus.Close)
            {
                common.system.ShowErrorMessage("Không thể lưu lại giao dịch đã đóng."); 
                return false;
            }
            data.baseDS.transactionsRow saveTransRow = 
                            dataLibs.MakeStockTransaction(transTypeCb.myValue,
                                                          stockCodeEd.Text,portfolioCb.myValue, (int)qtyEd.Value,
                                                          feePercEd.Value);
            if (saveTransRow==null) return false;
            statusCb.myValue = myTypes.CommonStatus.Close;
            onTimeEd.myDateTime = saveTransRow.onTime;
            codeEd.Text = saveTransRow.id.ToString();
            subTotalEd.Value = saveTransRow.amt;
            feeAmtEd.Value = saveTransRow.feeAmt;
            CalculatePriceAndFeePercentage();
            return true;
        }
        protected virtual void CancelEdit() { this.Close(); }
        protected virtual void Find(){ }
        protected virtual void Print() { }
        protected virtual bool DataValid() 
        {
            ClearNotifyError();
            bool retVal = true;
            if (qtyEd.Value <= 0)
            {
                NotifyError(qtyLbl);
                retVal = false;
            }
            if (stockCodeEd.Text.Trim() == "")
            {
                NotifyError(stockCodeLbl);
                retVal = false;
            }
            if (transTypeCb.myValue == analysis.tradeActions.None)
            {
                NotifyError(transTypeLbl);
                retVal = false;
            }
            if (portfolioCb.myValue == "")
            {
                NotifyError(portfolioLbl);
                retVal = false;
            }
            return retVal;
        }
        public virtual void SetFocus()
        {
            //this.Focus();
            qtyEd.Focus();
        }

        public bool ShowForm(BindingSource dataSource, int orderId)
        {
            this.myDataSource = dataSource;
            this.dataNavigator.BindingSource = dataSource;
            for (int idx = 0; idx < dataSource.Count; idx++)
            {
                if (((data.baseDS.transactionsRow)((DataRowView)dataSource[idx]).Row).id != orderId) continue;
                dataSource.Position = idx;
                break;
            }
            SetFocus();
            ShowDialog();
            return true;
        }
        private void DataSourceCurrentChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.myDataSource==null || this.myDataSource.Current==null) return;
                //data.baseDS.transactionsRow row = (data.baseDS.transactionsRow)((DataRowView)this.myDataSource.Current).Row;
                //this.stockCodeEd.Text = row.stockCode;
                //this.transTypeCb.myValue =  (analysis.tradeActions)row.tranType;
                //this.codeEd.Text = row.id.ToString();
                //this.portfolioCb.myValue = row.portfolio;
                //this.onTimeEd.myDateTime = row.onTime;
                //this.qtyEd.Value = row.qty;
                //this.subTotalEd.Value = row.amt;
                //this.feeAmtEd.Value = row.feeAmt;
                CalculatePriceAndFeePercentage();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}