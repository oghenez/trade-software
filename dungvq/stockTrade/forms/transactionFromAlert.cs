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
    public partial class transactionFromAlert : transactionNew
    {
        public transactionFromAlert()
        {
            try
            {
                InitializeComponent();
                qtyEd.ReadOnly = false;
                stockCodeEd.ReadOnly = true;
                portfolioCb.Enabled = false;
                transTypeCb.Enabled = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public bool ShowForm(data.baseDS.tradeAlertRow alertRow)
        {
            this.feePercEd.Value = application.Settings.sysStockTransFeePercent;

            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            portfolioCb.myValue  = alertRow.portfolio;
            stockCodeEd.Text = alertRow.stockCode.Trim();
            transTypeCb.myValue = (analysis.tradeActions)alertRow.tradeAction;
            statusCb.myValue = myTypes.CommonStatus.New;

            //Price
            data.baseDS.priceDataRow priceRow = application.dataLibs.GetLastPrice(alertRow.stockCode);
            if (priceRow != null) priceEd.Value = priceRow.closePrice * application.Settings.sysStockPriceWeight;
            SetFocus();

            ShowDialog();
            return true;
        }
    }
}