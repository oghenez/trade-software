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
    public partial class transactionNew : transactionBase
    {
        public transactionNew()
        {
            try
            {
                InitializeComponent();
                
                qtyEd.ReadOnly = false;
                codeEd.ReadOnly = false;
                portfolioCb.Enabled = true;
                transTypeCb.Enabled = true;
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

        public override void SetLanguage()
        {
            base.SetLanguage();
            saveBtn.Text = Languages.Libs.GetString("accept");
            newBtn.Text = Languages.Libs.GetString("addNew");
            closeBtn.Text = Languages.Libs.GetString("close");
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
        private void CalculateAmt()
        {
            subTotalEd.Value = qtyEd.Value * priceEd.Value;
            feeAmtEd.Value = Math.Round(feePercEd.Value * subTotalEd.Value / 1000, Settings.sysPrecisionLocal);
            totalAmtEd.Value = subTotalEd.Value + feeAmtEd.Value;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid()) return;
                Save();
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
        private void qtyEd_Validated(object sender, EventArgs e)
        {
            try
            {
                CalculateAmt();
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
                ClearEditData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}