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
    public partial class dataTools : baseClass.forms.baseForm
    {
        public dataTools()
        {
            try
            {
                InitializeComponent();
                dateRangeEd.frDate = commonTypes.Settings.sysStartDataDate;
                dateRangeEd.toDate = DateTime.Today;
                exchangeCb.LoadData();
                diagTimeScaleCb.LoadData();
                dataTimeScaleCb.LoadData();
                fullMode = false;
                tabControl.SendToBack();

                varianceEd.myPrecision = 3;
                adjWeightEd.myPrecision = 3;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        bool fProcessing = false;
        bool fullMode
        {
            get { return resultPnl.Visible; }
            set 
            {
                resultPnl.Visible = value;
                dataAjustPnl.Visible = value;
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

        private decimal VarianceToWeight(decimal variance)
        {
            return variance + 1;
        }
        private decimal WeightToVariance(decimal weight)
        {
            return weight - 1;
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

                diagnoseBtn.Enabled = false;
                common.system.ShowCurrorWait();
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                priceDiagnoseSource.DataSource = DataAccess.Libs.DiagnosePrice_CloseAndNextOpen(dateRangeEd.frDate, dateRangeEd.toDate, diagTimeScaleCb.myValue.Code,
                                                                                                exchangeCb.myValue, (double)checkVariancePercEd.Value, (double)checkVarianceEd.Value);
                priceDiagnoseSource.Sort = tmpDS.priceDiagnose.codeColumn.ColumnName;
                watch.Stop();
                this.ShowMessage(Languages.Libs.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(watch.Elapsed));
                this.ShowReccount(priceDiagnoseSource.Count);
                fullMode = true;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                common.system.ShowCurrorDefault();
                diagnoseBtn.Enabled = true;
            }
        }
        private void DataGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;
                SwithTagPage();
                if (tabControl.SelectedTab == dataAdjPg)
                {
                    if (priceDiagnoseSource.Current == null) return;
                    databases.tmpDS.priceDiagnoseRow row = (databases.tmpDS.priceDiagnoseRow)(priceDiagnoseSource.Current as DataRowView).Row;
                    adjustCodeEd.Text = row.code;
                    adjustToDateEd.myDateTime = row.date1;

                    varianceEd.Value = (decimal)row.variance;
                    adjWeightEd.Value = VarianceToWeight((decimal)row.variance);
                    //fullMode = false;
                }
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }
        private void varianceEd_Validated(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;
                adjWeightEd.Value = VarianceToWeight(varianceEd.GetValue());
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }
        private void adjWeightEd_Validated(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;
                varianceEd.Value = WeightToVariance(adjWeightEd.GetValue());
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }

        private void loadPriceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (!DataFixValid()) return;

                loadPriceBtn.Enabled = false;

                DateTime toDate = adjustToDateEd.myDateTime;
                decimal weight = (decimal)adjWeightEd.Value;
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                databases.baseDS.priceDataDataTable priceTbl = DataAccess.Libs.GetPriceData(adjustCodeEd.Text.Trim(), dataTimeScaleCb.myValue.Code);

                if (priceTbl == null) return;
                priceDataSource.DataSource = priceTbl;
                priceDataSource.Sort = priceTbl.onDateColumn.ColumnName + " DESC";
                watch.Stop();
                this.ShowMessage(Languages.Libs.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(watch.Elapsed));
                this.ShowReccount(priceDataSource.Count);
                fullMode = true;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                loadPriceBtn.Enabled = true;
            }
        }
        private void testAdjustDataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                testAdjustDataBtn.Enabled = false;
                common.system.ShowCurrorWait();

                DateTime toDate = adjustToDateEd.myDateTime;
                decimal weight = (decimal)adjWeightEd.Value;

                databases.baseDS.priceDataDataTable priceTbl = (priceDataSource.DataSource as databases.baseDS.priceDataDataTable);
                if (priceTbl == null) return;
                //Only adjust before specified date
                if (weight > 0)
                {
                    //weight = (1+weight)/100;
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
                    weight = -weight;
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
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                testAdjustDataBtn.Enabled = true;
                common.system.ShowCurrorDefault();
            }
        }

        private void saveFixDataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (!DataFixValid()) return;

                saveFixDataBtn.Enabled = false;
                common.system.ShowCurrorWait(); 

                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                DataAccess.Libs.AjustPriceData(adjustCodeEd.Text.Trim(), adjustToDateEd.myDateTime, (double)adjWeightEd.Value);
                watch.Stop();
                this.ShowMessage(Languages.Libs.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(watch.Elapsed));
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                common.system.ShowCurrorDefault();
                saveFixDataBtn.Enabled = true;
            }
        }
    }
}
