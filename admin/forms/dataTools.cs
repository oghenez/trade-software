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
        byte constPrecision = 3;
        public dataTools()
        {
            try
            {
                InitializeComponent();
                srcFrDateEd.myDateTime = Settings.sysStartDataDate;
                srcToDateEd.myDateTime = DateTime.Today;
                exchangeCb.LoadData();
                srcTimeScaleCb.LoadData();
                dataTimeScaleCb.LoadData();
                dataTimeScaleCb.myValue = AppTypes.MainDataTimeScale;
                fullMode = false;
                tabControl.SendToBack();

                dataVarianceEd.myFormat = "##0.000";
                adjustWeightEd.myFormat = "###,##0.000";

                srcSelectColumn.myImageType = common.controls.imageType.Edit;
                dataSelectColumn.myImageType = common.controls.imageType.Search; 
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
        public override void SetLanguage()
        {
            if (!isLoaded) return;
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("dataTools");

            searchPg.Text = Languages.Libs.GetString("search");
            srcFrDateLbl.Text = Languages.Libs.GetString("fromDate");
            srcToDateLbl.Text = Languages.Libs.GetString("toDate");

            srcTimeScaleLbl.Text = Languages.Libs.GetString("timeScale");
            exchangeLbl.Text = Languages.Libs.GetString("exchange");
            srcCodeLbl.Text = Languages.Libs.GetString("code");

            varianceParamGb.Text = Languages.Libs.GetString("variance");
            variancePerctLb.Text = Languages.Libs.GetString("percent");
            variancetLbl.Text = Languages.Libs.GetString("value");
            diagnoseBtn.Text = Languages.Libs.GetString("search");

            srcCodeColumn.HeaderText = Languages.Libs.GetString("code");
            srcClosePriceColumn.HeaderText = Languages.Libs.GetString("closePrice");
            srcOpenPriceColumn.HeaderText = Languages.Libs.GetString("openPrice");
            
            srcOpenDateColumn.HeaderText = Languages.Libs.GetString("openDate");
            srcCloseDateColumn.HeaderText = Languages.Libs.GetString("closeDate");
            
            ///Tool page
            dataAdjPg.Text = Languages.Libs.GetString("tools");
            dataToDateLbl.Text = Languages.Libs.GetString("toDate");
            dataCodeLbl.Text = Languages.Libs.GetString("code");
            dataTimeScaleLbl.Text = Languages.Libs.GetString("timeScale");
            dataVarianceLbl.Text = Languages.Libs.GetString("variance");
            adjustWeightLbl.Text = Languages.Libs.GetString("adjustWeight");

            loadPriceBtn.Text = Languages.Libs.GetString("load");
            testAdjustDataBtn.Text = Languages.Libs.GetString("autoAdjust");
            saveDataBtn.Text = Languages.Libs.GetString("save");
            reAggregateBtn.Text = Languages.Libs.GetString("reAggregate");

            dataOnDateColumn.HeaderText = Languages.Libs.GetString("dateTime");
            dataClosePriceColumn.HeaderText = Languages.Libs.GetString("closePrice");
            dataOpenPriceColumn.HeaderText = Languages.Libs.GetString("openPrice");
            dataHighPriceColumn.HeaderText = Languages.Libs.GetString("highPrice");
            dataLowPriceColumn.HeaderText = Languages.Libs.GetString("lowPrice");
            dataVolumeColumn.HeaderText = Languages.Libs.GetString("volume");
        }

        private bool DiagnoseValid()
        {
            bool retVal = true;
            ClearNotifyError();
            if (srcFrDateEd.myDateTime == common.Consts.constNullDate || srcToDateEd.myDateTime == common.Consts.constNullDate) retVal = false;
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
            if (dataToDateEd.myDateTime == common.Consts.constNullDate) 
            {
                this.NotifyError(dataToDateLbl);
                retVal = false;
            }
            if (dataCodeEd.Text.Trim() == "") 
            {
                this.NotifyError(dataCodeLbl);
                retVal = false;
            }
            if (adjustWeightEd.Value == 0)
            {
                this.NotifyError(adjustWeightLbl);
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
        private void SwithTabControlPage()
        {
            tabControl.SelectedTab = (tabControl.SelectedTab == dataAdjPg ? searchPg : dataAdjPg);
            if (tabControl.SelectedTab == dataAdjPg)
            {
                if (priceDiagnoseSource.Current == null) return;
                databases.tmpDS.priceDiagnoseRow row = (databases.tmpDS.priceDiagnoseRow)(priceDiagnoseSource.Current as DataRowView).Row;
                dataCodeEd.Text = row.code;
                dataToDateEd.myDateTime = row.date2;

                dataVarianceEd.Value = (decimal)row.variance;
                adjustWeightEd.Value = VarianceToWeight((decimal)row.variance);
            }
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
                priceDiagnoseSource.DataSource = 
                    DataAccess.Libs.DiagnosePrice_CloseAndNextOpen(srcFrDateEd.myDateTime, srcToDateEd.myDateTime, srcTimeScaleCb.myValue.Code,
                                                                   exchangeCb.myValue,srcCodeEd.Text.Trim(), (double)checkVariancePercEd.Value,
                                                                   (double)checkVarianceEd.Value, constPrecision);
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
        private void varianceEd_Validated(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;
                adjustWeightEd.Value = VarianceToWeight(dataVarianceEd.GetValue());
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
                dataVarianceEd.Value = WeightToVariance(adjustWeightEd.GetValue());
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

                DateTime toDate = dataToDateEd.myDateTime;
                decimal weight = (decimal)adjustWeightEd.Value;
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                databases.baseDS.priceDataDataTable priceTbl = DataAccess.Libs.GetPriceData(dataCodeEd.Text.Trim(),dataTimeScaleCb.myValue.Code,
                                                                                            Settings.sysStartDataDate,toDate.AddDays(1) );

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

                DateTime toDate = dataToDateEd.myDateTime;
                decimal weight = (decimal)adjustWeightEd.Value;

                databases.baseDS.priceDataDataTable priceTbl = (priceDataSource.DataSource as databases.baseDS.priceDataDataTable);
                if (priceTbl == null) return;
                //Only adjust before the specified date
                if (weight > 0)
                {
                    //weight = (1+weight)/100;
                    for (int idx = 0; idx < priceTbl.Count; idx++)
                    {
                        if (priceTbl[idx].RowState == DataRowState.Deleted) continue;
                        if (priceTbl[idx].onDate >= toDate) continue;
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
                        if (priceTbl[idx].onDate >= toDate) continue;
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


        private void saveDataBtn_Click(object sender, EventArgs e)
        {
            const short constNumberOfRowInBatchToSave = 500;
            try
            {
                this.ShowMessage("");
                //if (!DataFixValid()) return;

                saveDataBtn.Enabled = false;
                common.system.ShowCurrorWait(); 
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                //Only update changed data
                databases.baseDS.priceDataDataTable tbl = new databases.baseDS.priceDataDataTable();
                databases.baseDS.priceDataDataTable sourceTbl = (databases.baseDS.priceDataDataTable)priceDataSource.DataSource;

                progressBar.Visible = true;
                progressBar.Value =0;
                progressBar.Maximum = sourceTbl.Count;
                int batchCount = Settings.sysNumberOfItemsInBatchProcess;
                for (int idx = 0; idx < sourceTbl.Count; idx++)
                {
                    progressBar.Value++;
                    Application.DoEvents();

                    if (sourceTbl[idx].RowState == DataRowState.Unchanged) continue;
                    tbl.ImportRow(sourceTbl[idx]);
                    batchCount--;
                    if (batchCount == 0)
                    {
                        DataAccess.Libs.UpdateData(tbl);
                        tbl.Clear();
                        batchCount = constNumberOfRowInBatchToSave;
                    }
                }
                DataAccess.Libs.UpdateData(tbl);
                sourceTbl.AcceptChanges();
                watch.Stop();
                this.ShowMessage(Languages.Libs.GetString("finished") + " : " + tbl.Count.ToString() +" - " + common.dateTimeLibs.TimeSpan2String(watch.Elapsed) );
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                common.system.ShowCurrorDefault();
                saveDataBtn.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private void reAggregateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (!DataFixValid()) return;

                reAggregateBtn.Enabled = false;
                common.system.ShowCurrorWait();

                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                DataAccess.Libs.ReAggregatePriceData(dataCodeEd.Text.Trim());
                
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
                reAggregateBtn.Enabled = true;
            }
        }

        private void resultGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (fProcessing) return;
                if (resultGrid.Columns[e.ColumnIndex] != srcSelectColumn) return;

                fProcessing = true;
                SwithTabControlPage();
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }

        private void dataAdjGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (fProcessing) return;
                if (dataAdjGrid.Columns[e.ColumnIndex] != dataSelectColumn) return;

                fProcessing = true;
                SwithTabControlPage();
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }

        private void exchangeCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                databases.baseDS.stockExchangeRow row = exchangeCb.GetInfo(exchangeCb.myValue);
                checkVariancePercEd.Value = (row==null?0:row.priceAmplitude); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        //private void abnormalDataBtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.ShowMessage("");
        //        if (!DataFixValid()) return;

        //        common.system.ShowCurrorWait();
        //        abnormalDataBtn.Enabled = false;

        //        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        //        watch.Start();
        //        databases.baseDS.priceDataDataTable priceTbl = DataAccess.Libs.GetAbnormalData(adjustCodeEd.Text.Trim(),
        //                                                       Settings.sysStartDataDate,adjustToDateEd.myDateTime,
        //                                                       dataTimeScaleCb.myValue.Code);

        //        if (priceTbl == null) return;
        //        priceDataSource.DataSource = priceTbl;
        //        priceDataSource.Sort = priceTbl.onDateColumn.ColumnName + " DESC";
        //        watch.Stop();
        //        this.ShowMessage(Languages.Libs.GetString("finished") + " : " + common.dateTimeLibs.TimeSpan2String(watch.Elapsed));
        //        this.ShowReccount(priceDataSource.Count);
        //        fullMode = true;
        //    }
        //    catch (Exception er)
        //    {
        //        this.ShowError(er);
        //    }
        //    finally
        //    {
        //        common.system.ShowCurrorDefault();
        //        abnormalDataBtn.Enabled = true;
        //    }
        //}
    }
}
