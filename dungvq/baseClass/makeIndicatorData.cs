using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicTacTec.TA.Library;

namespace baseClass.forms
{
    public partial class makeIndicatorData : common.forms.baseForm
    {
        private bool fCanceled = false;
        public makeIndicatorData()
        {
            try
            {
                InitializeComponent();
                clbIndicator.LoadData();
                stockCodeClb.LoadData();
                stockCodeClb.LockEdit(false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void MakeIndicatorData(DateTime frDate, DateTime toDate,StringCollection indicatorCode,StringCollection stockCode)
        {
            int priceAdjustDay = 100;
            DateTime frPriceDate = frDate.AddDays(-priceAdjustDay);

            progressBar.Visible = true;
            myDataSet.indicator.Clear();
            application.dataLibs.LoadData(myDataSet.indicator,false);
            
            common.myKeyValueItem[] indicatorCodeList = new common.myKeyValueItem[0];
            for (int idx = 0; idx < myDataSet.indicator.Count; idx++)
            {
                if(!indicatorCode.Contains(myDataSet.indicator[idx].code.Trim())) continue;
                Array.Resize(ref indicatorCodeList,indicatorCodeList.Length+1);
                indicatorCodeList[indicatorCodeList.Length-1]= new common.myKeyValueItem(myDataSet.indicator[idx].code.Trim(),myDataSet.indicator[idx].parameter.Trim());
            }
            //this.ShowMessage("Calculating...");
            progressBar.Maximum = stockCode.Count;
            progressBar.Value = 0;
            myDataSet.indicatorData.Clear();

            for (int count = 0; count < stockCode.Count; count++)
            {
                if (fCanceled) break;
                myDataSet.indicatorData.Clear();
                myDataSet.priceData.Clear();
                application.dataLibs.LoadData(myDataSet.priceData, frPriceDate, toDate, stockCode[count]);
                MakeIndicatorData(indicatorCodeList, myDataSet.priceData, myDataSet.indicatorData);
                //Update database           
                application.dataLibs.DeleteIndicatorDataByStockCode(frDate, toDate, stockCode[count]);
                for (int idx = 0; idx < myDataSet.indicatorData.Count; idx++)
                {
                    if (myDataSet.indicatorData[idx].onDate < frDate || myDataSet.indicatorData[idx].onDate > toDate) continue;
                    application.dataLibs.UpdateData(myDataSet.indicatorData[idx]);
                }
                progressBar.Value++;
                Application.DoEvents();
            }
            progressBar.Visible = false;
            this.ShowMessage("");
            return;
        }
        private void MakeIndicatorData(common.myKeyValueItem[] indicatorCode,
                                       data.baseDS.priceDataDataTable priceDataTbl,
                                       data.baseDS.indicatorDataDataTable toTbl)
        {
            common.myKeyValueItem[] smaCodes = new common.myKeyValueItem[0];
            common.myKeyValueItem[] macdCodes = new common.myKeyValueItem[0];
            for (int idx = 0; idx < indicatorCode.Length; idx++)
            {
                if (indicatorCode[idx].Key.StartsWith("SMA"))
                {
                    Array.Resize(ref smaCodes, smaCodes.Length + 1);
                    smaCodes[smaCodes.Length - 1] = new common.myKeyValueItem(indicatorCode[idx].Key, indicatorCode[idx].Value);
                    continue;
                }
                if (indicatorCode[idx].Key.StartsWith("MACD"))
                {
                    Array.Resize(ref macdCodes, macdCodes.Length + 1);
                    macdCodes[macdCodes.Length - 1] = new common.myKeyValueItem(indicatorCode[idx].Key, indicatorCode[idx].Value);
                    continue;
                }
            }
        }
        private void  okBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool retVal = true;
                ClearNotifyError();
                this.ShowMessage("");
                if (!dateRange.GetDateRange())
                {
                    NotifyError(dateRange);
                    retVal = false;
                }
                if (clbIndicator.myCheckedValues.Count <= 0)
                {
                    NotifyError(allIndicatorChk);
                    retVal = false;
                }
                if (stockCodeClb.myCheckedValues.Count <= 0)
                {
                    NotifyError(stockCodeLbl);
                    retVal = false;
                }
                if (retVal)
                {
                    fCanceled = false;
                    okBtn.Enabled = false;
                    cancelBtn.Enabled = true;
                    ShowCurrorWait();
                    MakeIndicatorData(dateRange.frDate, dateRange.toDate, clbIndicator.myCheckedValues, stockCodeClb.myCheckedValues);
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
                okBtn.Enabled = true;
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

        private void allIndicatorChk_CheckedChanged(object sender, EventArgs e)
        {
            clbIndicator.CheckAll(allIndicatorChk.Checked);
        }
        private void makeIndicatorData_Load(object sender, EventArgs e)
        {
            try
            {
                allIndicatorChk.Checked = true;
            }
            catch (Exception er)
            { 
                this.ShowError(er);
            }
        }
    }
}
