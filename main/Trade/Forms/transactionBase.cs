using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using commonClass;

namespace Trade.Forms
{
    public partial class transactionBase : common.forms.baseForm
    {
        public transactionBase()
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
        public override void SetLanguage()
        {
            base.SetLanguage();
            codeLbl.Text = Languages.Libs.GetString("code");
            transactionNoLbl.Text = Languages.Libs.GetString("transactionNo");
            portfolioLbl.Text = Languages.Libs.GetString("portfolio");
            onTimeLbl.Text = Languages.Libs.GetString("onDate");
            statusLbl.Text = Languages.Libs.GetString("status");
            qtyLbl.Text = Languages.Libs.GetString("qty");
            priceLbl.Text = Languages.Libs.GetString("price");
            subTotalLbl.Text = Languages.Libs.GetString("subTotal");
            feeAmtLbl.Text = Languages.Libs.GetString("feeAmt");
            totalAmtLbl.Text = Languages.Libs.GetString("totalAmt");

            portfolioCb.SetLanguage();
            transTypeCb.SetLanguage();
            statusCb.SetLanguage();
        }

        public virtual void Init()
        {
            transTypeCb.LoadList(new AppTypes.TradeActions[] { AppTypes.TradeActions.Sell, AppTypes.TradeActions.Buy});
            portfolioCb.LoadData(commonClass.SysLibs.sysLoginCode, AppTypes.PortfolioTypes.Portfolio);
            statusCb.LoadData();

            //Color
            transCodeEd.BackColor = common.settings.sysColorHiLightBG1; transCodeEd.ForeColor = common.settings.sysColorHiLightBG1;

            codeEd.BackColor = common.settings.sysColorNormalBG; 
            codeEd.ForeColor = common.settings.sysColorNormalFG;

            transTypeCb.BackColor = common.settings.sysColorNormalBG; 
            transTypeCb.ForeColor = common.settings.sysColorNormalFG;

            portfolioCb.BackColor = common.settings.sysColorNormalBG; 
            portfolioCb.ForeColor = common.settings.sysColorNormalFG;

            qtyEd.BackColor = common.settings.sysColorNormalBG;
            qtyEd.ForeColor = common.settings.sysColorNormalFG;

            onTimeEd.BackColor = common.settings.sysColorNormalBG;
            onTimeEd.ForeColor = common.settings.sysColorNormalFG;

            priceEd.BackColor = common.settings.sysColorNormalBG;
            priceEd.ForeColor = common.settings.sysColorNormalFG;

            subTotalEd.BackColor = common.settings.sysColorHiLightBG1; 
            subTotalEd.ForeColor = common.settings.sysColorHiLightFG1;

            feePercEd.BackColor = common.settings.sysColorHiLightBG1;
            feePercEd.ForeColor = common.settings.sysColorHiLightFG1;

            feeAmtEd.BackColor = common.settings.sysColorHiLightBG1;
            feeAmtEd.ForeColor = common.settings.sysColorHiLightFG1;

            totalAmtEd.BackColor = common.settings.sysColorHiLightBG2; 
            totalAmtEd.ForeColor = common.settings.sysColorHiLightFG2;
        }

        public string myCode
        {
            set { codeEd.Text = value; }
        }

        /// <summary>
        /// Calculate total,subtotal,fee when qty was changed
        /// </summary>
        protected void CalculatePriceAndFeePercentage()
        {
            priceEd.Value = (int)((qtyEd.Value == 0 ? 0 : subTotalEd.Value / qtyEd.Value));
            feePercEd.Value = (subTotalEd.Value == 0 ? 0 : (feeAmtEd.Value / subTotalEd.Value) * 100);
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
        }
        public virtual void ClearEditData()
        {
            transCodeEd.Text = "";
            codeEd.Text = "";
            onTimeEd.myDateTime = DateTime.Now;
            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            transTypeCb.myValue = AppTypes.TradeActions.None;
            statusCb.myValue = AppTypes.CommonStatus.New;
            CalculatePriceAndFeePercentage();
            feePercEd.Value = 0;

            codeEd.Focus();
        }
        public virtual void SetEditData(data.baseDS.transactionsRow row)
        {
            transCodeEd.Text = row.id.ToString();
            codeEd.Text = row.stockCode;
            onTimeEd.myDateTime = row.onTime;
            portfolioCb.myValue = row.portfolio; 
            qtyEd.Value = row.qty;
            subTotalEd.Value = row.amt;
            feeAmtEd.Value = row.feeAmt;
            totalAmtEd.Value = row.amt + row.feeAmt;
            transTypeCb.myValue = (AppTypes.TradeActions)row.tranType;
            statusCb.myValue = (AppTypes.CommonStatus)row.status;
            CalculatePriceAndFeePercentage();

            codeEd.Focus();
        }
        public virtual void SetEditData(data.baseDS.tradeAlertRow row)
        {
            transCodeEd.Text = "";
            data.baseDS.stockExchangeRow stockExchangeRow = application.AppLibs.GetStockExchange(row.stockCode);
            if (stockExchangeRow != null) feePercEd.Value = stockExchangeRow.tranFeePerc;
            codeEd.Text = row.stockCode;
            onTimeEd.myDateTime = row.onTime;
            portfolioCb.myValue = row.portfolio;
            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            transTypeCb.myValue = (AppTypes.TradeActions)row.tradeAction;
            statusCb.myValue = AppTypes.CommonStatus.New;
            CalculatePriceAndFeePercentage();

            codeEd.Focus();
        }

        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            codeEd.ReadOnly = lockState;
            onTimeEd.ReadOnly = lockState;
            qtyEd.ReadOnly = lockState;
            subTotalEd.ReadOnly = lockState;
            feeAmtEd.ReadOnly = lockState;
            totalAmtEd.ReadOnly = lockState;
            portfolioCb.Enabled = !lockState;
            transTypeCb.Enabled = !lockState;
            statusCb.Enabled = false;
            codeEd.Focus();
        }

        protected virtual bool Save()
        {
            if (statusCb.myValue != AppTypes.CommonStatus.New)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("transactionIsClosed"));
                return false;
            }
            data.baseDS.transactionsDataTable transTbl=
                            DataAccess.Libs.MakeTransaction(transTypeCb.myValue, codeEd.Text, portfolioCb.myValue, 
                                                          (int)qtyEd.Value,feePercEd.Value);
            if (transTbl == null) return false;
            SetEditData(transTbl[0]);
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
            if (codeEd.Text.Trim() == "")
            {
                NotifyError(codeLbl);
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