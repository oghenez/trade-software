using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using LumenWorks.Framework.IO.Csv;
using application;
using commonTypes;
using commonClass;

namespace Imports.Forms
{
    public partial class importPriceData : common.forms.baseForm
    {
        private static CultureInfo dataCultureInfo = null;
        private static CultureInfo marketCultureInfo = null;
        const int constNumberOfImportInBatch = 10000;
        private bool fCanceled = false;
        public importPriceData()
        {
            try
            {
                InitializeComponent();
                marketCb.LoadDataDB();
                actionCb.SelectedIndex = 0;
                dataSourceCb.SelectedIndex = 0;
                dataCultureCb.SelectedIndex = 0;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void onAddCompany(string code)
        {
            common.SysLog.WriteLog(" - Add company : " + code);
        }
        private void OnUpdateData(databases.baseDS.priceDataRow row, importStat stat)
        {
            if (fCanceled) stat.cancel =true;
            this.ShowMessage(stat.updateCount.ToString("###,###,##0") + "/" + 
                             stat.errorCount.ToString("###,###,##0") + "/"  + 
                             stat.dataCount.ToString("###,###,##0"), "Import");

            //Do Aggregate and reset import to clear system resource
            if (myDataSet.priceData.Count > constNumberOfImportInBatch)
            {
                databases.DbAccess.UpdateData(myDataSet.priceData);
                DoAggregate(myDataSet.priceData, marketCultureInfo);
                myDataSet.priceData.Clear();
            }
        }
        private void onAggregateData(databases.AppLibs.AgrregateInfo stat)
        {
            if (fCanceled) stat.cancel = true;
            this.ShowMessage(stat.count.ToString("###,###,##0") + "/" + stat.maxCount.ToString("###,###,##0"), "Aggregate " + stat.phase.ToString());
        }

        private void DoImport()
        {
            myDataSet.priceData.Clear();
            switch (dataSourceCb.SelectedIndex)
            {
                case 0: //Data from copheu 68
                    Imports.Stock.Libs.ImportFromCVS(dataFileNameEd.Text, marketCb.myValue, dataCultureInfo, myDataSet.priceData, OnUpdateData);
                    databases.DbAccess.UpdateData(myDataSet.priceData);
                    DoAggregate(myDataSet.priceData,marketCultureInfo);
                    break;
                case 1: // Data from BVSC MMDDYYYY - Neu xu ly tay thi ko can
                    Imports.Stock.Libs.ImportFromCVS_BVSC(dataFileNameEd.Text, marketCb.myValue, dataCultureInfo, myDataSet.priceData, OnUpdateData);
                    databases.DbAccess.UpdateData(myDataSet.priceData);
                    DoAggregate(myDataSet.priceData, marketCultureInfo);
                    break;
                case 2:// Gold
                    Imports.Gold.Libs.ImportFromCVS(dataFileNameEd.Text, marketCb.myValue, dataCultureInfo, myDataSet.priceData, OnUpdateData);
                    databases.DbAccess.UpdateData(myDataSet.priceData);
                    DoAggregate(myDataSet.priceData, marketCultureInfo);
                    break;
            }
        }
        private void DoAggregate(databases.baseDS.priceDataDataTable tbl, CultureInfo CultureInfo)
        {
            databases.AppLibs.AggregatePriceData(tbl, CultureInfo, onAggregateData);
        }

        private void importBtn_Click(object sender, System.EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            
            try
            {
                marketCultureInfo = application.AppLibs.GetExchangeCulture(marketCb.myValue);
                dataCultureInfo = common.language.GetCulture(dataCultureCb.Text);

                bool retVal = true;
                ClearNotifyError();
                this.ShowMessage("");
                if (dataFileNameEd.Enabled && dataFileNameEd.Text.Trim() == "")
                {
                    NotifyError(dataFileLbl);
                    retVal = false;
                }
                if (marketCb.Enabled && marketCb.myValue.Trim() == "")
                {
                    NotifyError(stockExchangeLbl);
                    retVal = false;
                }
                if (!retVal) return;

                fCanceled = false;
                closeBtn.Enabled = false;
                importBtn.Enabled = false;
                cancelBtn.Enabled = true;
                ShowCurrorWait();
                this.ShowMessage("");
                switch(actionCb.SelectedIndex)
                {
                    case 0:
                        DoImport(); 
                        break;
                    case 2:
                        myDataSet.stockCode.Clear();
                        this.ShowMessage("Delete aggregation data...");
                        databases.DbAccess.DeletePriceSumData();
                        this.ShowMessage("Loading data...");
                        databases.DbAccess.LoadStockCode_ByStatus(myDataSet.stockCode, AppTypes.CommonStatus.Enable);
                        for (int idx = 0; idx < myDataSet.stockCode.Count; idx++)
                        {
                            if (fCanceled) break;
                            this.ShowMessage("Arregate stock : " + myDataSet.stockCode[idx].code);
                            myDataSet.priceData.Clear();
                            databases.DbAccess.LoadData(myDataSet.priceData,AppTypes.MainDataTimeScale.Code,DateTime.MinValue, DateTime.MaxValue,myDataSet.stockCode[idx].code);
                            databases.AppLibs.AggregatePriceData(myDataSet.priceData, marketCultureInfo, null);
                            this.ShowMessage("");
                        }
                        break;
                }
                ShowCurrorDefault();
                DateTime endTime = DateTime.Now;
                this.ShowMessage(common.dateTimeLibs.TimeSpan2String(endTime.Subtract(startTime)));
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                closeBtn.Enabled = true;
                cancelBtn.Enabled = false;
                importBtn.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private void selectFileBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {                    dataFileNameEd.Text = openFileDialog.FileName.Trim();
                }
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dừng thực hiện chuyển dữ liệu ?", common.Settings.sysApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            fCanceled = true;
        }
        private void viewLogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                common.fileFuncs.DisplayFile(common.SysLog.myLogFileName);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void actionCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataFileNameEd.Enabled = actionCb.SelectedIndex != 2;
            selectFileBtn.Enabled = dataFileNameEd.Enabled;
            marketCb.Enabled = dataFileNameEd.Enabled;
        }

        private void dataSourceCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataCultureCb.SelectedIndex = 0;
        }
    }
}
