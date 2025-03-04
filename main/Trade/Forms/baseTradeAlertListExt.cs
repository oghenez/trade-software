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
    public partial class baseTradeAlertListExt : baseTradeAlertList
    {
        public baseTradeAlertListExt()
        {
            try
            {
                InitializeComponent();
                tradeAlertCriteria.LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        protected void LoadDataForFilter()
        {
            myDataSet.tradeAlert.Clear();
            application.dataLibs.LoadFromSQL(myDataSet.tradeAlert, tradeAlertCriteria.GetSQL());
            ShowReccount();
        }
        protected override void ResizeForm()
        {
            //tradeAlertList.Location = new Point(0, toolbarPnl.Location.Y + toolbarPnl.Height);
            //tradeAlertList.Size = new Size(this.ClientRectangle.Width,
            //                               this.ClientRectangle.Height - tradeAlertList.Location.Y - SystemInformation.CaptionHeight-3);
            //toolbarPnl.Width = this.Width + 5;
        }

        #region event handler
        private void showFilterBtn_Click(object sender, EventArgs e)
        {
            if (filterPnl.Visible) filterPnl.Hide();
            else
            {
                filterPnl.BringToFront();
                filterPnl.Show();
            }
        }
        private void filterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDataForFilter();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //if (tradeAlertList.tradeAlertGrid.SelectedRows.Count == 0)
                //{
                //    common.system.ShowErrorMessage("Xin vui lòng chọn các dòng cần hủy !");
                //    return;
                //}
                //if (common.system.ShowDialogYesNo("Tạm hủy " + tradeAlertList.tradeAlertGrid.SelectedRows.Count.ToString() + " cảnh báo ?") == DialogResult.No) return;
                //for (int idx = 0; idx < tradeAlertList.tradeAlertGrid.SelectedRows.Count; idx++)
                //{
                //    RemoveRow( (data.baseDS.tradeAlertRow)((DataRowView)tradeAlertList.tradeAlertGrid.SelectedRows[idx].DataBoundItem).Row);
                //}
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}