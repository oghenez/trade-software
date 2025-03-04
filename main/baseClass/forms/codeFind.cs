using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Globalization;
using application;

namespace application
{
    public partial class invoiceFind : baseForm
    {
        public DataRowView selectedDataRow;
        public bool LoadDataOnShow = true;

        //Key trapping
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Make ENTER key work as TAB key for all controls except BUTTON
            if ((application.Consts.constEnterSameAsTabKey && (msg.WParam.ToInt32() == (int)Keys.Enter) &&
                (this.ActiveControl != null) && (this.ActiveControl.GetType().Name.ToUpper().Trim() != "BUTTON")))
            {
                SendKeys.Send("{Tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void SetQueryInvoice(string code)
        {
            this.invoiceNoEd.Text = code;
            this.invoiceNoChk.Checked = (this.invoiceNoEd.Text.Trim() != "");
        }

        public bool Find(string invoiceNo)
        {
            return Find(invoiceNo, true);
        }
        
        public bool Find(string invoiceNo, bool ShowSelectionIfNotFound)
        {
            try
            {
                selectedDataRow = null;
                InvoiceSource.Filter = "";
                this.invoiceTableAdapter.FillByInvoiceNo(this.myMasterDataSet.Invoice,invoiceNo);
                if (this.myMasterDataSet.Invoice.Rows.Count == 1)
                {
                    selectedDataRow = ((DataRowView)InvoiceSource.Current);
                    return true;
                }
                if (!ShowSelectionIfNotFound) return false;
                LoadDataOnShow = false;
                LoadData(); DoFilter();
                this.ShowDialog();
                LoadDataOnShow = true;
                return (this.selectedDataRow != null);
            }
            catch (Exception er)
            {
                commonLibs.sysLibs.ShowErrorMessage(er.Message);
            }
            return false;
        }

        public bool Find(DateTime frDate, DateTime toDate)
        {
            return Find(frDate, toDate,true);
        }
        
        public bool Find(DateTime frDate, DateTime toDate, bool ShowSelectionIfNotFound)
        {
           try
           {
                selectedDataRow = null;
                InvoiceSource.Filter = "";
                this.invoiceTableAdapter.FilByDateRange(this.myMasterDataSet.Invoice, frDate, toDate);
                if (this.myMasterDataSet.Invoice.Rows.Count == 1)
                {
                   selectedDataRow = ((DataRowView)InvoiceSource.Current);
                   return true;
                }
                if (!ShowSelectionIfNotFound) return false;
                LoadDataOnShow = false;
                LoadData(); DoFilter();
                this.ShowDialog();
                LoadDataOnShow = true;
                return (this.selectedDataRow != null); 
            }
            catch (Exception er)
            {
                commonLibs.sysLibs.ShowErrorMessage(er.Message);
            }
            return false;
        }

        public invoiceFind()
        {
            InitializeComponent();
        }


        private void LoadData()
        {
            if (!this.dateTimeRange.GetDateRange()) return;
            this.invoiceTableAdapter.FilByDateRange(this.myMasterDataSet.Invoice,this.dateTimeRange.frDate,this.dateTimeRange.toDate);
        }

        private void DoFilter()
        {
            string strFilter = "";
            if (this.invoiceNoEd.Enabled && this.invoiceNoEd.Text.Trim() != "")
            {
                if (strFilter != "") strFilter += " AND ";
                strFilter += "(invoiceNo LIKE '" + this.invoiceNoEd.Text.Trim() + "%')";
            }
            InvoiceSource.Filter = strFilter;
        }
      
        private void closeBtn_Click(object sender, EventArgs e)
        {
            selectedDataRow = ((DataRowView)InvoiceSource.Current);
            this.Hide();
        }
        
        private void invoiceFind_Load(object sender, EventArgs e)
        {
            if (!LoadDataOnShow) return;
            LoadData();
            DoFilter();
        }

        private void invoiceNoChk_CheckedChanged(object sender, EventArgs e)
        {
            this.invoiceNoEd.Enabled = this.invoiceNoChk.Checked;
            DoFilter();
        }

        private void invoiceNoEd_Validated(object sender, EventArgs e)
        {
            DoFilter();
        }

        private void findListGrid_DoubleClick(object sender, EventArgs e)
        {
            selectBtn_Click(sender, e);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (findListGrid.CurrentRow == null) selectedDataRow = null;
            else selectedDataRow = ((DataRowView)InvoiceSource.Current);
            this.Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            selectedDataRow = null;
            this.Hide();
        }

        private void findListGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Tab))
                selectBtn_Click(sender, null);
        }

        private void invoiceFind_Shown(object sender, EventArgs e)
        {
            this.findListGrid.Focus();
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            LoadData(); DoFilter();
        }
   }
}