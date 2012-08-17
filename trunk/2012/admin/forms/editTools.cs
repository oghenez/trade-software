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
    public partial class editTools : baseClass.forms.baseForm
    {
        public editTools()
        {
            try
            {
                InitializeComponent();
                editFrDateEd.myDateTime = Settings.sysStartDataDate;
                editToDateEd.myDateTime = DateTime.Today;
                fullMode = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        bool fullMode
        {
            get { return dataEditPnl.Visible; }
            set
            {
                dataEditPnl.Visible = value;
                dataEditPnl.Visible = value;
                this.Height = dataEditPnl.Location.Y + 2 * SystemInformation.CaptionHeight + 5 + (value ? dataEditPnl.Height : 0)+15;
                Application.DoEvents();
            }
        }

        public override void SetLanguage()
        {
            if (!isLoaded) return;
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("dataTools");

            editFrDateLbl.Text = Languages.Libs.GetString("fromDate");
            editToDateLbl.Text = Languages.Libs.GetString("toDate");
            
            ///Tool page
            dataCodeLbl.Text = Languages.Libs.GetString("code");

            loadPriceBtn.Text = Languages.Libs.GetString("load");
            saveDataBtn.Text = Languages.Libs.GetString("save");
            reAggregateBtn.Text = Languages.Libs.GetString("reAggregate");

            dataOnDateColumn.HeaderText = Languages.Libs.GetString("dateTime");
            dataClosePriceColumn.HeaderText = Languages.Libs.GetString("closePrice");
            dataOpenPriceColumn.HeaderText = Languages.Libs.GetString("openPrice");
            dataHighPriceColumn.HeaderText = Languages.Libs.GetString("highPrice");
            dataLowPriceColumn.HeaderText = Languages.Libs.GetString("lowPrice");
            dataVolumeColumn.HeaderText = Languages.Libs.GetString("volume");
        }

        private bool DataValid_Edit()
        {
            bool retVal = true;
            ClearNotifyError();
            if (editFrDateEd.myDateTime == common.Consts.constNullDate) 
            {
                this.NotifyError(editFrDateLbl);
                retVal = false;
            }
            if (editToDateEd.myDateTime == common.Consts.constNullDate)
            {
                this.NotifyError(editToDateLbl);
                retVal = false;
            }
            if (dataCodeEd.Text.Trim() == "") 
            {
                this.NotifyError(dataCodeLbl);
                retVal = false;
            }
            return retVal;
        }
        private bool DataValid_Aggregate()
        {
            bool retVal = true;
            ClearNotifyError();
            if (dataCodeEd.Text.Trim() == "")
            {
                this.NotifyError(dataCodeLbl);
                retVal = false;
            }
            return retVal;
        }

        private void loadPriceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (!DataValid_Edit()) return;

                loadPriceBtn.Enabled = false;

                DateTime frDate = editFrDateEd.myDateTime;
                DateTime toDate = editToDateEd.myDateTime;
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                string timeScaleCode = AppTypes.TimeScaleTypeToCode(AppTypes.TimeScaleTypes.RealTime);
                databases.baseDS.priceDataDataTable priceTbl = DataAccess.Libs.GetPriceData(dataCodeEd.Text.Trim(), timeScaleCode,
                                                                                            editFrDateEd.myDateTime, editToDateEd.myDateTime);

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

        private void saveDataBtn_Click(object sender, EventArgs e)
        {
            const short constNumberOfRowInBatchToSave = 500;
            try
            {
                this.ShowMessage("");

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
                if (!DataValid_Aggregate()) return;
                if (MessageBox.Show("Tổ hợp lại dữ liệu có thể mất nhiều thời gian. Tiếp tục thực hiện ?", 
                                    common.Settings.sysApplicationName,MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No) 
                    return;

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

        private void dataGrid_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                this.ShowMessage("");
                if (priceDataSource.Current != null)
                {
                    databases.baseDS.priceDataRow row = (databases.baseDS.priceDataRow)((DataRowView)priceDataSource.Current).Row;
                    databases.AppLibs.InitData(row);
                    row.stockCode = dataCodeEd.Text.Trim(); 
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
