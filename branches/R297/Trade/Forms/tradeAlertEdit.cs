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
                Init();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public void Init()
        {
            strategyCb.LoadData();
            statusCb.LoadData();
            actionCb.LoadData();
            timeScaleCb.LoadData();
            portfolioCb.LoadData(sysLibs.sysLoginCode,false);
            onDateEd.BackColor = common.settings.sysColorNormalBG; onDateEd.ForeColor = common.settings.sysColorNormalFG;
            alertCodeEd.BackColor = common.settings.sysColorNormalBG; alertCodeEd.ForeColor = common.settings.sysColorNormalFG;
            codeEd.BackColor = common.settings.sysColorNormalBG; codeEd.ForeColor = common.settings.sysColorNormalFG;
            subjectEd.BackColor = common.settings.sysColorNormalBG; subjectEd.ForeColor = common.settings.sysColorNormalFG;
            informationEd.BackColor = common.settings.sysColorNormalBG; informationEd.ForeColor = common.settings.sysColorNormalFG;

            statusCb.BackColor = common.settings.sysColorNormalBG; statusCb.ForeColor = common.settings.sysColorNormalFG;
            portfolioCb.BackColor = common.settings.sysColorNormalBG; portfolioCb.ForeColor = common.settings.sysColorNormalFG;
            strategyCb.BackColor = common.settings.sysColorNormalBG; strategyCb.ForeColor = common.settings.sysColorNormalFG;
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("tradeAlert");
            this.codeLbl.Text = language.GetString("code");
            this.onDateLbl.Text = language.GetString("onDate");
            this.subjectLbl.Text = language.GetString("subject");
            this.actionLbl.Text = language.GetString("tradeAction");
            this.statusLbl.Text = language.GetString("status");
            this.portfolioLbl.Text = language.GetString("portfolio");
            this.strategyLbl.Text = language.GetString("strategy");
            this.informationLbl.Text = language.GetString("information");

            this.orderBtn.Text = language.GetString("order");
            this.ignoreBtn.Text = language.GetString("ignore");
            this.recoverBtn.Text = language.GetString("recover");
            this.closeBtn.Text = language.GetString("close");

            this.actionCb.SetLanguage();
            this.statusCb.SetLanguage();
            this.portfolioCb.SetLanguage();
            this.strategyCb.SetLanguage();
            this.timeScaleCb.SetLanguage();
        }

        public virtual void SetFocus()
        {
            this.Focus();
            onDateEd.Focus();
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

                this.onDateEd.DataBindings.Clear();
                this.onDateEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.onTimeColumn.ColumnName, true));

                this.alertCodeEd.DataBindings.Clear();
                this.alertCodeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.idColumn.ColumnName, true));

                this.codeEd.DataBindings.Clear();
                this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.stockCodeColumn.ColumnName, true));

                this.subjectEd.DataBindings.Clear();
                this.subjectEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.subjectColumn.ColumnName, true));

                this.informationEd.DataBindings.Clear();
                this.informationEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", value, tbl.msgColumn.ColumnName, true));

                this.strategyCb.DataBindings.Clear();
                this.strategyCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", value, tbl.strategyColumn.ColumnName, true));

                this.timeScaleCb.DataBindings.Clear();
                this.timeScaleCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", value, tbl.timeScaleColumn.ColumnName, true));

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
                this.ShowMessage(language.GetString("noData"));
                return;
            }
            //Trade order 
            data.baseDS.tradeAlertRow row = this.myCurrentRow;
            myNewTradeOrderForm.ShowNew(row);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (this.myCurrentRow==null) 
                {
                    this.ShowMessage(language.GetString("noData"));
                    return;
                }
                if (this.myCurrentRow.status == (byte)AppTypes.CommonStatus.Close)
                {
                    return;
                }
                data.baseDS.tradeAlertRow row = this.myCurrentRow;
                dataLibs.CloseTradeAlert(row);
                dataLibs.UpdateData(row);
                this.ShowMessage(language.GetString("alertClosed"));
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
                    this.ShowMessage(language.GetString("noData"));
                    return;
                }
                data.baseDS.tradeAlertRow row = this.myCurrentRow;
                if (row.status == (byte)AppTypes.CommonStatus.New) return;
                dataLibs.RenewTradeAlert(row);
                dataLibs.UpdateData(row);
                this.ShowMessage(language.GetString("alertRecovered"));
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