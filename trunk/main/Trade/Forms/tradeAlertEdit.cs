using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace Trade.Forms
{
    public partial class tradeAlertEdit : common.forms.baseDialogForm 
    {
        public tradeAlertEdit()
        {
            try
            {
                InitializeComponent();

                strategyCb.LoadData();
                statusCb.LoadData();
                actionCb.LoadData();
                portfolioCb.LoadData();

                onTimeEd.BackColor = common.settings.sysColorNormalBG; onTimeEd.ForeColor = common.settings.sysColorNormalFG;
                codeEd.BackColor = common.settings.sysColorNormalBG; codeEd.ForeColor = common.settings.sysColorNormalFG;
                stockEd.BackColor = common.settings.sysColorNormalBG; stockEd.ForeColor = common.settings.sysColorNormalFG;
                subjectEd.BackColor = common.settings.sysColorNormalBG; subjectEd.ForeColor = common.settings.sysColorNormalFG;
                messageEd.BackColor = common.settings.sysColorNormalBG; messageEd.ForeColor = common.settings.sysColorNormalFG;

                statusCb.BackColor = common.settings.sysColorNormalBG; statusCb.ForeColor = common.settings.sysColorNormalFG;
                portfolioCb.BackColor = common.settings.sysColorNormalBG; portfolioCb.ForeColor = common.settings.sysColorNormalFG;
                strategyCb.BackColor = common.settings.sysColorNormalBG; strategyCb.ForeColor = common.settings.sysColorNormalFG;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public virtual void SetFocus()
        {
            this.Focus();
            onTimeEd.Focus();
        }

        private transactionFromAlert _myNewTradeOrderForm = null;
        private transactionFromAlert myNewTradeOrderForm
        {
            get
            {
                if (_myNewTradeOrderForm == null || _myNewTradeOrderForm.IsDisposed)
                    _myNewTradeOrderForm = GetNewTradeOrderForm();
                return _myNewTradeOrderForm;
            }
        }
        protected virtual transactionFromAlert GetNewTradeOrderForm()
        {
            return new transactionFromAlert();
        }

        public void ShowForm(BindingSource dataSource,int rowId)
        {
            this.myDataSource = dataSource;
            dataNavigator.BindingSource = dataSource;
            for (int idx = 0; idx < dataSource.Count; idx++)
            {
                if (((data.baseDS.tradeAlertRow)((DataRowView)dataSource[idx]).Row).id != rowId) continue;
                dataSource.Position = idx;
                break;
            }
            SetFocus();
            ShowDialog();
        }
        private BindingSource _myDataSource = null;
        private BindingSource myDataSource
        {
            get {return _myDataSource;}
            set
            {
                this._myDataSource = value;
                data.baseDS.tradeAlertDataTable tbl = new data.baseDS.tradeAlertDataTable();

                this.onTimeEd.DataBindings.Clear();
                this.onTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.onTimeColumn.ColumnName, true));

                this.codeEd.DataBindings.Clear();
                this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.idColumn.ColumnName, true));

                this.stockEd.DataBindings.Clear();
                this.stockEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.stockCodeColumn.ColumnName, true));

                this.subjectEd.DataBindings.Clear();
                this.subjectEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.subjectColumn.ColumnName, true));

                this.messageEd.DataBindings.Clear();
                this.messageEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.msgColumn.ColumnName, true));

                this.strategyCb.DataBindings.Clear();
                this.strategyCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", value, tbl.strategyColumn.ColumnName, true));

                this.portfolioCb.DataBindings.Clear();
                this.portfolioCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", value, tbl.portfolioColumn.ColumnName, true));

                this.statusCb.DataBindings.Clear();
                this.statusCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", value, tbl.statusColumn.ColumnName, true));

                this.actionCb.DataBindings.Clear();
                this.actionCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", value, tbl.tradeActionColumn.ColumnName, true));
            }
        }

        private data.baseDS.tradeAlertRow myCurrentRow 
        {
            get
            {
                if (this.myDataSource == null || this.myDataSource.Current == null) return null;
                return (data.baseDS.tradeAlertRow)((DataRowView)this.myDataSource.Current).Row;
            }
        }

        #region event handler
        private void orderBtn_Click(object sender, EventArgs e)
        {
            this.ShowMessage("");
            if (this.myCurrentRow == null)
            {
                common.system.ShowMessage("Dữ liệu không hợp lệ !");
                return;
            }
            //Trade order 
            data.baseDS.tradeAlertRow row = this.myCurrentRow;

            if (row.status == (byte)application.AppTypes.CommonStatus.Close)
            {
                common.system.ShowMessage("Không thể thực hiện lại giao dịch đã đóng !");
                return;
            }
            if(!myNewTradeOrderForm.ShowNew(row)) return;
            application.dataLibs.CloseTradeAlert(row);
            application.dataLibs.UpdateData(row);
            this.ShowMessage("Đã lưu dữ liệu.");
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (this.myCurrentRow==null) 
                {
                    common.system.ShowMessage("Dữ liệu không hợp lệ !");
                    return;
                }
                if (this.myCurrentRow.status == (byte)application.AppTypes.CommonStatus.Close)
                {
                    common.system.ShowMessage("Giao dịch đã đóng, không thể thực hiện lại!");
                    return;
                }
                if (common.system.ShowDialogYesNo("Tạm hủy cảnh báo này ?") == DialogResult.No) return;
                data.baseDS.tradeAlertRow row = this.myCurrentRow;
                application.dataLibs.CancelTradeAlert(row);
                application.dataLibs.UpdateData(row);
                this.ShowMessage("Đã tạm hủy cảnh báo.");
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
                this.ShowMessage("");
                if (this.myCurrentRow == null)
                {
                    common.system.ShowMessage("cảnh báo không hợp lệ !");
                    return;
                }
                if (common.system.ShowDialogYesNo("Hủy cảnh báo này ?") == DialogResult.No) return;
                data.baseDS.tradeAlertRow row = this.myCurrentRow;
                application.dataLibs.DeleteTradeAlert(row.id);
                this.ShowMessage("Đã hủy cảnh báo.");
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
                this.ShowMessage("");
                if (this.myCurrentRow == null)
                {
                    common.system.ShowMessage("Dữ liệu không hợp lệ !");
                    return;
                }
                data.baseDS.tradeAlertRow row = this.myCurrentRow;
                if (row.status != (byte)application.AppTypes.CommonStatus.Ignore)
                {
                    common.system.ShowMessage("Chỉ có thể phục hồi giao dịch đã xóa !");
                    return;
                }
                application.dataLibs.RenewTradeAlert(row);
                application.dataLibs.UpdateData(row);
                this.ShowMessage("Đã phục hồi dữ liệu về trạng thái : " + ((application.AppTypes.CommonStatus)row.status).ToString());
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}