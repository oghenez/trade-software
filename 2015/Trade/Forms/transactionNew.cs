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
    public partial class transactionNew : transactionBase
    {
        public transactionNew()
        {
            try
            {
                InitializeComponent();
                //feePercEd.Value = Settings.sysStockTransFeePercent;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public static transactionNew GetForm(string formName)
        {
            string cacheKey = typeof(transactionNew).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            transactionNew form = (transactionNew)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new transactionNew();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        public override void Init()
        {
            base.Init();
            availableCashEd.BackColor = common.Settings.sysColorHiLightBG3;
            availableCashEd.ForeColor = common.Settings.sysColorHiLightBG3;
            
            remainCashEd.BackColor = common.Settings.sysColorHiLightBG3; 
            remainCashEd.ForeColor = common.Settings.sysColorHiLightBG3;
        }
        public override void ClearEditData()
        {
            base.ClearEditData();
            onTimeEd.myDateTime = common.Consts.constNullDate;
            availableCashEd.Value = 0;
            remainCashEd.Value = 0;
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            currentCashLbl.Text = Languages.Libs.GetString("currentCash");
            newCashLbl.Text = Languages.Libs.GetString("postTransCash");

            saveBtn.Text = Languages.Libs.GetString("accept");
            newBtn.Text = Languages.Libs.GetString("addNew");
            closeBtn.Text = Languages.Libs.GetString("close");
            string title = Languages.Libs.GetString("newOrder");
            this.SetTitle(title, title);
        }
        public override void SetFocus()
        {
            codeEd.Focus();
        }
        protected override bool Save()
        {
            this.ShowMessage("");
            if (common.system.ShowDialogYesNo(Languages.Libs.GetString("askDoTransaction")) == DialogResult.No) return false;
            if (!base.Save()) return false;
            common.system.ShowMessage(Languages.Libs.GetString("transactionCompleted"));
            return true;
        }

        commonClass.TransactionInfo transInfo = new TransactionInfo();
        common.DictionaryList tranDataCache = new common.DictionaryList();
        private void ClearCache()
        {
            tranDataCache.Clear();
        }
        private void RefreshTransData()
        {
            commonClass.TransactionInfo transInfo = null;
            string cachKey = this.codeEd.Text.Trim()+"-"+ portfolioCb.myValue.Trim();
            object obj = tranDataCache.Find(cachKey);
            if (obj == null)
            {
                transInfo = new TransactionInfo();
                transInfo.stockCode = this.codeEd.Text.Trim();
                transInfo.portfolio = portfolioCb.myValue.Trim();
                if (!DataAccess.Libs.GetTransactionInfo(ref transInfo))
                {
                    ClearEditData();
                    common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                    return;
                }
                tranDataCache.Add(cachKey, transInfo);
            }
            else transInfo = (TransactionInfo)obj;
            onTimeEd.myDateTime = transInfo.priceDate;
            feePercEd.Value = transInfo.transFeePerc;
            priceEd.Value = transInfo.price;
                //* transInfo.priceRatio;
            subTotalEd.Value = qtyEd.Value * priceEd.Value * transInfo.priceRatio;
            feeAmtEd.Value = (decimal)Math.Round(feePercEd.Value * subTotalEd.Value / 100,common.system.GetPrecisionFromMask(Settings.sysMaskLocalAmt) );
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
            availableCashEd.Value = transInfo.availableCash;
            
            switch(transTypeCb.myValue)
            {
                case AppTypes.TradeActions.Buy:
                    remainCashEd.Value = transInfo.availableCash - subTotalEd.Value;
                     break;
                case AppTypes.TradeActions.Sell :
                     remainCashEd.Value = transInfo.availableCash + subTotalEd.Value;
                     break;
                default:
                     common.system.ShowErrorMessage(Languages.Libs.GetString("invalidData")); 
                     break;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid()) return;
                if(Save()) this.Close();
                ClearCache();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CancelEdit(); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            try
            {
                tranDataCache.Clear();
                ClearCache();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid()) return;
                RefreshTransData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void qtyEd_Validated(object sender, EventArgs e)
        {
            try
            {
                qtyEd.EndEdit();
                if (!DataValid()) return;
                RefreshTransData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void portfolioCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid()) return;
                RefreshTransData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void transTypeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid()) return;
                RefreshTransData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void transactionNew_Load(object sender, EventArgs e)
        {
            try
            {
                ClearCache();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}