using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LumenWorks.Framework.IO.Csv;


namespace baseClass.forms
{
    public partial class importPriceData : common.forms.baseForm
    {
        private bool fCanceled = false;
        private System.Windows.Forms.OpenFileDialog openFileDialogCSVFilePath = new OpenFileDialog();
        public importPriceData()
        {
            InitializeComponent();
            stockExchangeCb.LoadData();
        }

        private void onGotData(application.importLibs.importStat stat)
        {
            if (fCanceled) stat.cancel =true;
            this.ShowMessage(stat.updateCount.ToString() + "/" + stat.errorCount.ToString() + "/" + stat.dataCount.ToString(),"Import");
        }
        private void onAggregateData(application.importLibs.agrregateStat stat)
        {
            if (fCanceled) stat.cancel = true;
            this.ShowMessage(stat.count.ToString() + "/" + stat.maxCount.ToString(),"Aggregate");
        }

        private void AggregatePriceData(data.baseDS myDataSet) 
        {
            application.importLibs.AggregatePriceData(myDataSet, "vi-VN", onAggregateData);

            this.ShowMessage("");
            cancelBtn.Enabled = false;
            progressBar.Visible = true;
            progressBar.Maximum = myDataSet.priceData.Count + myDataSet.priceDataDay.Count + myDataSet.priceDataWeek.Count +
                                  myDataSet.priceDataMonth.Count + myDataSet.priceDataYear.Count;
            progressBar.Value = 0;
            for (int idx = 0; idx < myDataSet.priceData.Count; idx++)
            {
                application.dataLibs.UpdateData(myDataSet.priceData[idx]);
                progressBar.Value++;
                Application.DoEvents();
            }
            for (int idx = 0; idx < myDataSet.priceDataDay.Count; idx++)
            {
                application.dataLibs.UpdateData(myDataSet.priceDataDay[idx]);
                progressBar.Value++;
            }
            for (int idx = 0; idx < myDataSet.priceDataWeek.Count; idx++)
            {
                application.dataLibs.UpdateData(myDataSet.priceDataWeek[idx]);
                progressBar.Value++;
                Application.DoEvents();
            }
            for (int idx = 0; idx < myDataSet.priceDataMonth.Count; idx++)
            {
                application.dataLibs.UpdateData(myDataSet.priceDataMonth[idx]);
                progressBar.Value++;
                Application.DoEvents();
            }
            for (int idx = 0; idx < myDataSet.priceDataYear.Count; idx++)
            {
                application.dataLibs.UpdateData(myDataSet.priceDataYear[idx]);
                progressBar.Value++;
                Application.DoEvents();
            }
        }

        private void importBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool retVal = true;
                ClearNotifyError();
                this.ShowMessage("");
                if (dataFileNameEd.Text.Trim() == "")
                {
                    NotifyError(dataFileLbl);
                    retVal = false;
                }
                if (stockExchangeCb.myValue.Trim() == "")
                {
                    NotifyError(stockExchangeLbl);
                    retVal = false;
                }
                if (retVal)
                {
                    fCanceled = false;
                    importBtn.Enabled = false;
                    cancelBtn.Enabled = true;
                    ShowCurrorWait();
                    application.importLibs.ImportPricedata_CSV(dataFileNameEd.Text.Trim(), stockExchangeCb.myValue,
                                                               "en-US", myDataSet, onGotData, null, AggregatePriceData);
                    ShowCurrorDefault();
                }
                return;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                cancelBtn.Enabled = false;
                importBtn.Enabled = true;
                progressBar.Visible = false;
            }
        }
        private void selectFileBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (openFileDialogCSVFilePath.ShowDialog() == DialogResult.OK)
                {
                    dataFileNameEd.Text = openFileDialogCSVFilePath.FileName.Trim();
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
            if (MessageBox.Show("Dừng thực hiện chuyển dữ liệu ?", common.settings.sysApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            fCanceled = true;
        }

    }
}
