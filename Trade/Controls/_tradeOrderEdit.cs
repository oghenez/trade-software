using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace stockTrade.controls
{
    public partial class tradeOrderEdit : common.control.baseUserControl
    {
        public tradeOrderEdit()
        {
            try
            {
                InitializeComponent();

                stockCodeEd.BackColor = common.settings.sysColorNormalBG; stockCodeEd.ForeColor = common.settings.sysColorNormalFG;
                transTypeCb.BackColor = common.settings.sysColorNormalBG; transTypeCb.ForeColor = common.settings.sysColorNormalFG;
                codeEd.BackColor = common.settings.sysColorNormalBG; codeEd.ForeColor = common.settings.sysColorNormalFG;
                portpolioCb.BackColor = common.settings.sysColorNormalBG; portpolioCb.ForeColor = common.settings.sysColorNormalFG;
                onTimeEd.BackColor = common.settings.sysColorNormalBG; onTimeEd.ForeColor = common.settings.sysColorNormalFG;

                qtyEd.BackColor = common.settings.sysColorNormalBG; qtyEd.ForeColor = common.settings.sysColorNormalFG;
                priceEd.BackColor = common.settings.sysColorNormalBG; priceEd.ForeColor = common.settings.sysColorNormalFG;
                subTotalEd.BackColor = common.settings.sysColorHiLightBG1; subTotalEd.ForeColor = common.settings.sysColorHiLightFG1;
                feePercEd.BackColor = common.settings.sysColorNormalBG; feePercEd.ForeColor = common.settings.sysColorNormalFG;
                feeAmtEd.BackColor = common.settings.sysColorNormalBG; feeAmtEd.ForeColor = common.settings.sysColorNormalFG;
                totalAmtEd.BackColor = common.settings.sysColorHiLightBG2; totalAmtEd.ForeColor = common.settings.sysColorHiLightFG2;

                this.myMode = Modes.ViewOnly;
            }
            catch (Exception er)
            {
                this.ErrorHandler(this, er);
            }
        }        
        public enum Modes { Edit,EditDataFromAlert,ViewOnly };
        public Modes _myMode = Modes.ViewOnly;
        public Modes myMode
        {
            get { return this._myMode; }
            set 
            { 
                this._myMode = value;
                switch (value)
                {
                    case Modes.Edit: 
                                qtyEd.ReadOnly = false;
                                stockCodeEd.ReadOnly = false;
                                portpolioCb.Enabled = false;
                                transTypeCb.Enabled = false; 
                                break;
                    case Modes.EditDataFromAlert:
                                qtyEd.ReadOnly = false;
                                stockCodeEd.ReadOnly = true;  
                                portpolioCb.Enabled = true;
                                transTypeCb.Enabled = true; 
                                break;
                    default:    qtyEd.ReadOnly = true;
                                stockCodeEd.ReadOnly = true;
                                portpolioCb.Enabled = true;
                                transTypeCb.Enabled = true; 
                                break;
                }
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
                    DataBinding(value);
                    myDataSource.CurrentChanged += new System.EventHandler(this.DataSourceCurrentChanged);
                    DataSourceCurrentChanged(this, null);
                }
            }
        }
        public data.baseDS.investorTransHistoryRow myCurrentDataRow
        {
            get
            {
                if (this.myDataSource == null || this.myDataSource.Current == null) return null;
                return (data.baseDS.investorTransHistoryRow)((DataRowView)this.myDataSource.Current).Row;
            }
        }

        /// <summary>
        /// Calculate total,subtotal,fee when qty was changed
        /// </summary>
        private void CalculateDataEDIT()
        {
            subTotalEd.Value = qtyEd.Value * priceEd.Value;
            feeAmtEd.Value = Math.Round(feePercEd.Value * subTotalEd.Value / 1000, application.Settings.sysPrecisionLocal);
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
        }
        
        /// <summary>
        /// Price and fee percentage are not stored in the database so the function calculated the values form others
        /// </summary>
        private void CalculateDataVIEW()
        {
            priceEd.Value = (int)((qtyEd.Value==0?0:subTotalEd.Value / qtyEd.Value));
            feePercEd.Value =(subTotalEd.Value==0?0:(feeAmtEd.Value/subTotalEd.Value)*100);
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
        }
        private void DataBinding(BindingSource dataSource)
        {
            data.baseDS.investorTransHistoryDataTable tbl = new data.baseDS.investorTransHistoryDataTable();

            this.stockCodeEd.DataBindings.Clear();
            this.stockCodeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.stockCodeColumn.ColumnName, true));

            this.transTypeCb.DataBindings.Clear();
            this.transTypeCb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", dataSource, tbl.tranTypeColumn.ColumnName, true));

            this.codeEd.DataBindings.Clear();
            this.codeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.idColumn.ColumnName, true));

            this.portpolioCb.DataBindings.Clear();
            this.portpolioCb.DataBindings.Add(new System.Windows.Forms.Binding("myValue", dataSource, tbl.portfolioColumn.ColumnName, true));

            this.onTimeEd.DataBindings.Clear();
            this.onTimeEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", dataSource, tbl.onTimeColumn.ColumnName, true));

            this.qtyEd.DataBindings.Clear();
            this.qtyEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.qtyColumn.ColumnName, true));

            this.subTotalEd.DataBindings.Clear();
            this.subTotalEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.amtColumn.ColumnName, true));

            this.feeAmtEd.DataBindings.Clear();
            this.feeAmtEd.DataBindings.Add(new System.Windows.Forms.Binding("Value", dataSource, tbl.feeAmtColumn.ColumnName, true));
        }

        public decimal transFeePercent
        {
            get {return feePercEd.Value;}
            set{feePercEd.Value = value;}
        }
        public decimal stockPrice
        {
            get { return priceEd.Value; }
            set { priceEd.Value = value; }
        }
        public DateTime transDateTime
        {
            get { return onTimeEd.myDateTime; }
            set { onTimeEd.myDateTime = value; }
        }
        public void LoadData()
        {
            transTypeCb.LoadData();
            portpolioCb.LoadData();
        }
        public bool DataValid()
        {
            ClearNotifyError();
            bool retVal = true;
            if (qtyEd.Value <= 0)
            {
                NotifyError(qtyLbl);
                retVal = false;
            }
            if (stockCodeEd.Text.Trim()=="")
            {
                NotifyError(stockCodeLbl);
                retVal = false;
            }
            if (transTypeCb.myValue == application.analysis.tradeActions.None)
            {
                NotifyError(transTypeLbl);
                retVal = false;
            }
            if (this.myMode == Modes.Edit || this.myMode == Modes.EditDataFromAlert)
            {
                CalculateDataEDIT();
                myDataSource.EndEdit();
            }
            return retVal;
        }

        public virtual void SetFocus()
        {
            this.Focus();
            onTimeEd.Focus();
        }

        private void DataSourceCurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.myMode == stockTrade.controls.tradeOrderEdit.Modes.ViewOnly)
                {
                    CalculateDataVIEW();
                }
            }
            catch (Exception er)
            {
                this.ErrorHandler(this, er);
            }
        }
        private void qtyEd_Validated(object sender, EventArgs e)
        {
            try
            {
                if (this.myMode == Modes.Edit) CalculateDataEDIT();
            }
            catch (Exception er)
            {
                this.ErrorHandler(this, er);
            }
        }
    }
}
