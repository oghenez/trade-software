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

namespace imports.forms
{
    public partial class importPriceData : common.forms.baseForm
    {
        private static CultureInfo CultureInfoVN = new CultureInfo("vi-VN");
        const int constNumberOfImportInBatch = 10000;
        private bool fCanceled = false;
        public importPriceData()
        {
            try
            {
                InitializeComponent();
                stockExchangeCb.LoadDataDB();
                actionCb.SelectedIndex = 0;
                importTypeCb.SelectedIndex = 0;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void onAddCompany(string code)
        {
            common.fileFuncs.WriteLog(" - Add company : " + code);
        }
        private void OnUpdateData(databases.baseDS.priceDataRow row, ImportLibs.importStat stat)
        {
            if (fCanceled) stat.cancel =true;
            this.ShowMessage(stat.updateCount.ToString("###,###,##0") + "/" + 
                             stat.errorCount.ToString("###,###,##0") + "/"  + 
                             stat.dataCount.ToString("###,###,##0"), "Import");

            //Do Aggregate and reset import to clear system resource
            if (myDataSet.priceData.Count > constNumberOfImportInBatch)
            {
                databases.DbAccess.UpdateData(myDataSet.priceData);
                DoAggregate(myDataSet.priceData);
                myDataSet.priceData.Clear();
            }
        }
        private void onAggregateData(ImportLibs.agrregateStat stat)
        {
            if (fCanceled) stat.cancel = true;
            this.ShowMessage(stat.count.ToString("###,###,##0") + "/" + stat.maxCount.ToString("###,###,##0"), "Aggregate " + stat.phase.ToString());
        }

        private void DoImport()
        {
            myDataSet.priceData.Clear();
            switch (importTypeCb.SelectedIndex)
            {
                case 0: //Data from copheu 68
                    stock.ImportOHLCV_CSV(dataFileNameEd.Text,stockExchangeCb.myValue,
                                          myDataSet.priceData, OnUpdateData);
                    databases.DbAccess.UpdateData(myDataSet.priceData);
                    DoAggregate(myDataSet.priceData);
                    break;
                case 1:
                    gold.ImportOHLCV_CSV(dataFileNameEd.Text,stockExchangeCb.myValue,
                                         myDataSet.priceData, OnUpdateData);
                    databases.DbAccess.UpdateData(myDataSet.priceData);
                    DoAggregate(myDataSet.priceData);
                    break;
            }
        }
        private void DoAggregate(databases.baseDS.priceDataDataTable tbl )
        {
            ImportLibs.AggregatePriceData(tbl,CultureInfoVN, onAggregateData);
        }

        private void importBtn_Click(object sender, System.EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            try
            {
                bool retVal = true;
                ClearNotifyError();
                this.ShowMessage("");
                if (dataFileNameEd.Enabled && dataFileNameEd.Text.Trim() == "")
                {
                    NotifyError(dataFileLbl);
                    retVal = false;
                }
                if (stockExchangeCb.Enabled && stockExchangeCb.myValue.Trim() == "")
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
                            ImportLibs.AggregatePriceData(myDataSet.priceData,CultureInfoVN, null);
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
                common.fileFuncs.DisplayFile(common.fileFuncs.myLogFileName);
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
            stockExchangeCb.Enabled = dataFileNameEd.Enabled;
        }
    }
}
