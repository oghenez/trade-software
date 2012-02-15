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
    //public partial class scheduleForm : common.forms.baseApplication  
    public partial class scheduleForm : baseClass.forms.baseApplication  
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
                if (!Init()) commonClass.SysLibs.ExitApplication();
                LoadConfig();
                myTimer.Interval = timerIntervalInSecs * 1000;
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        protected override bool ShowLogin() { return true; }
        protected override bool CheckLicense() { return true; }

        private static bool Init()
        {
            //application.sysLibs.sysProductOwner = application.Consts.constProductOwner;
            //application.sysLibs.sysProductCode = application.Consts.constProductCode;

            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            //common.Settings.sysConfigFile = configFile;
            common.configuration.withEncryption = true;

            application.Configuration.Load_User_Envir();
            //Check data connection after db-setting were loaded
            if (!databases.SysLibs.CheckAllDbConnection())
            {
                common.system.ShowMessage("Không thể kết nối đến nguồn dữ liệu.Xin vui lòng chạy lại chương trình [Setup].");
                return false;
            }
            GlobalSettings globalSetting = Settings.sysGlobal;
            application.Configuration.Load_Global_Settings(ref globalSetting);
            Settings.sysGlobal = globalSetting;

            application.Configuration.Load_Local_Settings();
            return true;
        }
        protected override bool LoadAppConfig()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            return base.LoadAppConfig();
        }
        protected override bool CheckValid()
        {
            return true;
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

                imports.gold.ResetGetPrice();
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
                common.fileFuncs.DisplayFile(common.fileFuncs.myLogFileName);
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
                        common.fileFuncs.WriteLog("Trade alert start");
                        Trade.AlertLibs.CreateTradeAlert(onTradeAlertProcessStart, onTradeAlertProcessItem, onTradeAlertProcessEnd);
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
                    common.fileFuncs.WriteLog(" - FetchData error " + er.Message);
                }
                if (fProcessingTraderAlert)
                {
                    fProcessingTraderAlert = false;
                    common.fileFuncs.WriteLog(" - Trader Alert error " + er.Message);
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
