using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace tradeAlert.forms
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
            //tradeAlertList.SetData(myDataSet.tradeAlert);
            //tradeAlertList.SetData(tradeAlert);
            ShowReccount();
        }
        protected override void ResizeForm()
        {
            tradeAlertList.Location = new Point(0, toolbarPnl.Location.Y + toolbarPnl.Height);
            tradeAlertList.Size = new Size(this.ClientRectangle.Width,
                                           this.ClientRectangle.Height - tradeAlertList.Location.Y - SystemInformation.CaptionHeight-3);
            toolbarPnl.Width = this.Width + 5;
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
        #endregion

    }
}