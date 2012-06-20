using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using commonTypes;
using commonClass;

namespace Trade.Forms
{
    public partial class transactionBase : baseClass.forms.baseForm
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
            transCodeEd.BackColor = common.Settings.sysColorHiLightBG1; transCodeEd.ForeColor = common.Settings.sysColorHiLightBG1;

            codeEd.BackColor = common.Settings.sysColorNormalBG; 
            codeEd.ForeColor = common.Settings.sysColorNormalFG;

            transTypeCb.BackColor = common.Settings.sysColorNormalBG; 
            transTypeCb.ForeColor = common.Settings.sysColorNormalFG;

            portfolioCb.BackColor = common.Settings.sysColorNormalBG; 
            portfolioCb.ForeColor = common.Settings.sysColorNormalFG;

            qtyEd.BackColor = common.Settings.sysColorNormalBG;
            qtyEd.ForeColor = common.Settings.sysColorNormalFG;

            onTimeEd.BackColor = common.Settings.sysColorNormalBG;
            onTimeEd.ForeColor = common.Settings.sysColorNormalFG;

            priceEd.BackColor = common.Settings.sysColorNormalBG;
            priceEd.ForeColor = common.Settings.sysColorNormalFG;

            subTotalEd.BackColor = common.Settings.sysColorHiLightBG1; 
            subTotalEd.ForeColor = common.Settings.sysColorHiLightFG1;

            feePercEd.BackColor = common.Settings.sysColorHiLightBG1;
            feePercEd.ForeColor = common.Settings.sysColorHiLightFG1;

            feeAmtEd.BackColor = common.Settings.sysColorHiLightBG1;
            feeAmtEd.ForeColor = common.Settings.sysColorHiLightFG1;

            totalAmtEd.BackColor = common.Settings.sysColorHiLightBG2; 
            totalAmtEd.ForeColor = common.Settings.sysColorHiLightFG2;
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
            codeEd.Text =  common.Settings.sysNewDataText;
            onTimeEd.myDateTime = DateTime.Now;
            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            transTypeCb.myValue = AppTypes.TradeActions.None;
            statusCb.myValue = AppTypes.CommonStatus.New;
            CalculatePriceAndFeePercentage();
            feePercEd.Value = 0;

            codeEd.Focus();
        }
        public virtual void SetEditData(databases.baseDS.transactionsRow row)
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
        public virtual void SetEditData(databases.baseDS.tradeAlertRow row)
        {
            transCodeEd.Text = "";
            databases.tmpDS.stockCodeRow stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(row.stockCode);
            if (stockCodeRow != null)
            {
                databases.baseDS.stockExchangeRow stockExchangeRow = DataAccess.Libs.myStockExchangeTbl.FindBycode(stockCodeRow.stockExchange);
                if (stockExchangeRow != null) feePercEd.Value = stockExchangeRow.tranFeePerc;
            }
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
            databases.baseDS.transactionsDataTable transTbl=
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