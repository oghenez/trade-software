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
    public partial class transactionFromAlert : transactionNew
    {
        public transactionFromAlert()
        {
            try
            {
                InitializeComponent();
                qtyEd.ReadOnly = false;
                codeEd.ReadOnly = true;
                transTypeCb.Enabled = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public bool ShowNew(databases.baseDS.tradeAlertRow alertRow)
        {
            this.Refresh();
            qtyEd.Value = 0; subTotalEd.Value = 0; feeAmtEd.Value = 0; totalAmtEd.Value = 0;
            portfolioCb.myValue  = alertRow.portfolio;
            codeEd.Text = alertRow.stockCode.Trim();
            transTypeCb.myValue = (AppTypes.TradeActions)alertRow.tradeAction;
            statusCb.myValue = AppTypes.CommonStatus.New;
            SetFocus();
            ShowDialog();
            return true;
        }
    }
}