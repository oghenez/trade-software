using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using commonTypes;

namespace server
{
    public partial class scheduleForm : baseClass.forms.baseForm   
    {
        private bool fRunning = false;
        private bool fProcessingTraderAlert = false, fProcessingFetchData = false;

        private int timerIntervalInSecs = 5;        //Tick event occurs each 5 second
        private int fetchDataElapseInSeconds = 0;   //Time elapsed since the last fetch data event
        private int alertElapseInSeconds = 0;       //Time elapsed since the last trade alert event
        public scheduleForm()
        {
            try
            {
                InitializeComponent();
                LoadConfig();
                myTimer.Interval = timerIntervalInSecs * 1000;
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void LoadConfig()
        {
            StringCollection aFields = new StringCollection();
            aFields.Add(this.Name + ".fetchStockInterval");
            aFields.Add(this.Name + ".tradeAlertInterval");
            application.Configuration.GetConfig(ref aFields);
            int val = 0;
            int.TryParse(aFields[0], out val);
            if (val != int.MaxValue)
            {
                fetchInSecsEd.Value = val;
                fetchDataChk.Checked = true;
            }
            else fetchDataChk.Checked = false;

            int.TryParse(aFields[1], out val);
            if (val != int.MaxValue)
            {
                tradeAlertEd.Value = val;
                tradeAlertChk.Checked = true;
            }
            else tradeAlertChk.Checked = false;
        }
        private void SaveConfig()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Add(this.Name + ".fetchStockInterval");
            aFields.Add(this.Name + ".tradeAlertInterval");

            int val = 0;
            val = (int)(fetchDataChk.Checked ? fetchInSecsEd.Value : int.MaxValue);
            aValues.Add(val.ToString());
            val = (int)(tradeAlertChk.Checked ? tradeAlertEd.Value : int.MaxValue);
            aValues.Add(val.ToString());

            application.Configuration.SaveConfig(aFields, aValues);
        }

        private void onTradeAlertProcessStart(int count)
        {
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Maximum = count;
        }
        private bool onTradeAlertProcessItem(string stockcode)
        {
            Application.DoEvents();
            progressBar.Value++;
            this.ShowMessage(stockcode);
            return fRunning;
        }
        private void onTradeAlertProcessEnd()
        {
            progressBar.Visible = false;
            this.ShowMessage("");
        }

        #region event handler
        private void runBtn_Click(object sender, EventArgs e)
        {
            try
            {
                fRunning = !fRunning;
                this.ShowMessage("");
                runBtn.Image = (fRunning ? pauseBtn.Image : startBtn.Image);
                alertElapseInSeconds = 0;
                fetchDataElapseInSeconds = 0;
                scheduleGb.Enabled = !fRunning;
                fProcessingFetchData = false;
                fProcessingTraderAlert = false;

                Imports.Gold.ResetGetPrice();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                SaveConfig();
                this.ShowMessage("Settings were saved.");
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void viewLogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                common.fileFuncs.DisplayFile(common.fileFuncs.ConcatFileName(commonClass.SysLibs.myExecuteDirectory, Consts.constFile_SysLog));
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            if (!fRunning) return;
            try
            {
                if (fetchDataChk.Checked)
                {
                    fetchDataElapseInSeconds += timerIntervalInSecs;
                    if (!fProcessingFetchData && (fetchDataElapseInSeconds >= fetchInSecsEd.Value))
                    {
                        fProcessingFetchData = true;
                        this.Text = DateTime.Now.ToString();
                        libs.FetchRealTimeData(DateTime.Now);
                        fetchDataElapseInSeconds = 0;
                        fProcessingFetchData = false;
                    }
                }
                if (tradeAlertChk.Checked)
                {
                    alertElapseInSeconds += timerIntervalInSecs;
                    if (!fProcessingTraderAlert && (alertElapseInSeconds >= tradeAlertEd.Value))
                    {
                        fProcessingTraderAlert = true;
                        commonClass.SysLibs.WriteSysLog("Trade alert started.");
                        Trade.AlertLibs.CreateTradeAlert(onTradeAlertProcessStart, onTradeAlertProcessItem, onTradeAlertProcessEnd);
                        commonClass.SysLibs.WriteSysLog("Trade alert ended.");
                        alertElapseInSeconds = 0;
                        fProcessingTraderAlert = false;
                    }
                }
            }
            catch (Exception er)
            {
                if (fProcessingFetchData)
                {
                    fProcessingFetchData = false;
                    commonClass.SysLibs.WriteSysLog(" - FetchData error " + er.Message);
                }
                if (fProcessingTraderAlert)
                {
                    fProcessingTraderAlert = false;
                    commonClass.SysLibs.WriteSysLog(" - Trader Alert error " + er.Message);
                }

                ShowError(er);
            }
        }
        private void fetchStockChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                fetchInSecsEd.Enabled = fetchDataChk.Checked;
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void tradeAlertChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tradeAlertEd.Enabled = tradeAlertChk.Checked;
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        #endregion
    }
}
