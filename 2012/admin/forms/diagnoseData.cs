using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonTypes;

namespace admin.forms
{
    public partial class diagnoseData : baseClass.forms.baseForm
    {
        public diagnoseData()
        {
            try
            {
                InitializeComponent();
                exchangeCb.LoadData();
                timeScaleCb.LoadData();
                fullMode = false;
                tabControl.SendToBack();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        bool fullMode
        {
            get { return resultPnl.Visible; }
            set 
            {
                resultPnl.Visible = value;
                tabControl.Height = resultPnl.Location.Y + 2 * SystemInformation.CaptionHeight + 5 + (value ? resultPnl.Height : 0);
                this.Height = tabControl.Location.Y + tabControl.Height + 2 * SystemInformation.CaptionHeight + 15;
                Application.DoEvents();
            }
        }
        private bool DiagnoseValid()
        {
            bool retVal = true;
            ClearNotifyError();
            if (!dateRangeEd.GetDateRange()) retVal = false;
            if (exchangeCb.myValue.Trim() == "")
            {
                this.NotifyError(exchangeLbl);
                retVal = false;
            }
            return retVal;
        }
        private bool DataFixValid()
        {
            bool retVal = true;
            ClearNotifyError();
            if (adjustToDateEd.myDateTime == common.Consts.constNullDate) 
            {
                this.NotifyError(adjustToDateLbl);
                retVal = false;
            }
            if (adjustCodeEd.Text.Trim() == "") 
            {
                this.NotifyError(adjustCodeLbl);
                retVal = false;
            }
            if (adjWeightEd.Value == 0)
            {
                this.NotifyError(adjWeightLbl);
                retVal = false;
            }
            return retVal;
        }

        private void SwithTagPage()
        {
            tabControl.SelectedTab = (tabControl.SelectedTab == dataAdjPg ? searchPg : dataAdjPg);
        }

        private void diagnoseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                fullMode = false;
                if (!DiagnoseValid()) return;

                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                priceDiagnoseSource.DataSource = DataAccess.Libs.DiagnosePrice_CloseAndNextOpen(dateRangeEd.frDate, dateRangeEd.toDate, timeScaleCb.myValue.Code,
                                                                                                exchangeCb.myValue, (double)variancePercEd.Value, (double)varianceEd.Value);
                watch.Stop();
                this.ShowMessage(Languages.Libs.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(watch.Elapsed));
                this.ShowReccount(priceDiagnoseSource.Count);
                fullMode = true;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void fixDataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (!DiagnoseValid()) return;

                DateTime toDate = adjustToDateEd.myDateTime;
                decimal weight = (decimal)adjWeightEd.Value;
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                databases.baseDS.priceDataDataTable priceTbl= DataAccess.Libs.GetPriceData(adjustCodeEd.Text.Trim(), timeScaleCb.myValue.Code);
                if (priceTbl == null) return;
                priceDataSource.DataSource = priceTbl;
                //Only adjust before specified date
                if (weight > 0)
                {
                    weight = (1+weight)/100;
                    for (int idx = 0; idx < priceTbl.Count; idx++)
                    {
                        if (priceTbl[idx].RowState == DataRowState.Deleted) continue;
                        if (priceTbl[idx].onDate > toDate) continue;
                        priceTbl[idx].lowPrice *= weight;
                        priceTbl[idx].highPrice *= weight;
                        priceTbl[idx].closePrice *= weight;
                        priceTbl[idx].openPrice *= weight;
                    }
                }
                else
                {
                    weight = (1 - weight) / 100;
                    for (int idx = 0; idx < priceTbl.Count; idx++)
                    {
                        if (priceTbl[idx].RowState == DataRowState.Deleted) continue;
                        if (priceTbl[idx].onDate > toDate) continue;
                        priceTbl[idx].lowPrice /= weight;
                        priceTbl[idx].highPrice /= weight;
                        priceTbl[idx].closePrice /= weight;
                        priceTbl[idx].openPrice /= weight;
                    }
                }
                watch.Stop();
                this.ShowMessage(Languages.Libs.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(watch.Elapsed));
                this.ShowReccount(priceDiagnoseSource.Count);
                fullMode = true;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl.SelectedTab != dataAdjPg) return;
                if (priceDiagnoseSource.Current == null) return;
                databases.tmpDS.priceDiagnoseRow row = (databases.tmpDS.priceDiagnoseRow)(priceDiagnoseSource.Current as DataRowView).Row;
                adjustCodeEd.Text = row.code;
                adjustToDateEd.myDateTime = row.date1;
                adjWeightEd.Value = (decimal)row.variance;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void DataGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SwithTagPage();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
