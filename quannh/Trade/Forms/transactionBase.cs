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
    public partial class transactionBase : common.forms.baseForm
    {
        public transactionBase()
        {
            try
            {
                InitializeComponent();
                transTypeCb.LoadData();
                portfolioCb.LoadData();
                statusCb.LoadData();

                //Color
                transCodeEd.BackColor = common.settings.sysColorHiLightBG1; transCodeEd.ForeColor = common.settings.sysColorHiLightBG1;

                stockCodeEd.BackColor = common.settings.sysColorNormalBG; stockCodeEd.ForeColor = common.settings.sysColorNormalFG;
                transTypeCb.BackColor = common.settings.sysColorNormalBG; transTypeCb.ForeColor = common.settings.sysColorNormalFG;
                portfolioCb.BackColor = common.settings.sysColorNormalBG; portfolioCb.ForeColor = common.settings.sysColorNormalFG;
                onTimeEd.BackColor = common.settings.sysColorHiLightBG1; onTimeEd.ForeColor = common.settings.sysColorHiLightFG1;

                qtyEd.BackColor = common.settings.sysColorNormalBG; qtyEd.ForeColor = common.settings.sysColorNormalFG;
                priceEd.BackColor = common.settings.sysColorNormalBG; priceEd.ForeColor = common.settings.sysColorNormalFG;
                subTotalEd.BackColor = common.settings.sysColorHiLightBG2; subTotalEd.ForeColor = common.settings.sysColorHiLightFG2;
                feePercEd.BackColor = common.settings.sysColorNormalBG; feePercEd.ForeColor = common.settings.sysColorNormalFG;
                feeAmtEd.BackColor = common.settings.sysColorNormalBG; feeAmtEd.ForeColor = common.settings.sysColorNormalFG;
                totalAmtEd.BackColor = common.settings.sysColorHiLightBG3; totalAmtEd.ForeColor = common.settings.sysColorHiLightFG3;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        /// <summary>
        /// Calculate total,subtotal,fee when qty was changed
        /// </summary>
        private void CalculatePriceAndFeePercentage()
        {
            priceEd.Value = (int)((qtyEd.Value == 0 ? 0 : subTotalEd.Value / qtyEd.Value));
            feePercEd.Value = (subTotalEd.Value == 0 ? 0 : (feeAmtEd.Value / subTotalEd.Value) * 100);
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
        }
        public void ClearEditData()
        {
            transCodeEd.Text = "";
            stockCodeEd.Text = "";
            onTimeEd.myDateTime = DateTime.Now;
            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            transTypeCb.myValue = AppTypes.TradeActions.None;
            statusCb.myValue = AppTypes.CommonStatus.New;
            CalculatePriceAndFeePercentage();
            feePercEd.Value = Settings.sysStockTransFeePercent;

            stockCodeEd.Focus();
        }
        public void SetEditData(data.baseDS.transactionsRow row)
        {
            transCodeEd.Text = row.id.ToString();
            stockCodeEd.Text = row.stockCode;
            onTimeEd.myDateTime = row.onTime;
            portfolioCb.myValue = row.portfolio; 
            qtyEd.Value = row.qty;
            subTotalEd.Value = row.amt;
            feeAmtEd.Value = row.feeAmt;
            totalAmtEd.Value = row.amt + row.feeAmt;
            transTypeCb.myValue = (AppTypes.TradeActions)row.tranType;
            statusCb.myValue = (AppTypes.CommonStatus)row.status;
            CalculatePriceAndFeePercentage();

            stockCodeEd.Focus();
        }
        public void SetEditData(data.baseDS.tradeAlertRow row)
        {
            transCodeEd.Text = "";
            feePercEd.Value = Settings.sysStockTransFeePercent;
            stockCodeEd.Text = row.stockCode;
            onTimeEd.myDateTime = row.onTime;
            portfolioCb.myValue = row.portfolio;
            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            transTypeCb.myValue = (AppTypes.TradeActions)row.tradeAction;
            statusCb.myValue = AppTypes.CommonStatus.New;
            CalculatePriceAndFeePercentage();

            stockCodeEd.Focus();
        }

        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            stockCodeEd.ReadOnly = lockState;
            onTimeEd.ReadOnly = lockState;
            qtyEd.ReadOnly = lockState;
            subTotalEd.ReadOnly = lockState;
            feeAmtEd.ReadOnly = lockState;
            totalAmtEd.ReadOnly = lockState;
            portfolioCb.Enabled = !lockState;
            transTypeCb.Enabled = !lockState;
            statusCb.Enabled = false;
            stockCodeEd.Focus();
        }

        protected virtual bool Save()
        {
            if (statusCb.myValue != AppTypes.CommonStatus.New)
            {
                common.system.ShowErrorMessage("Không thể lưu lại giao dịch đã kết thúc.");
                return false;
            }
            data.baseDS.transactionsRow transRow =
                            dataLibs.MakeStockTransaction(transTypeCb.myValue,stockCodeEd.Text, portfolioCb.myValue, 
                                                          (int)qtyEd.Value,feePercEd.Value);
            if (transRow == null) return false;
            SetEditData(transRow);
            return true;
        }
        protected virtual void CancelEdit() { this.Close(); }
        //protected virtual void Find() { }
        //protected virtual void Print() { }
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
            if (transTypeCb.myValue == AppTypes.TradeActions.None)
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
            qtyEd.Focus();
        }
    }
}