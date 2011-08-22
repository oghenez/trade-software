using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace server
{
    //public partial class scheduleForm : common.forms.baseApplication  
    public partial class scheduleForm : baseClass.forms.baseApplication  
    {
        private static string _configFile = null;
        private static string myConfigFile
        {
            get
            {
                if (_configFile == null)
                    _configFile = common.system.MakeFileNameFromExecutablePath(".conf");
                return _configFile;
            }
        }

        private bool fRunning = false;
        private bool fProcessingTraderAlert = false, fProcessingFetchData = false;

        private int timerIntervalInSecs = 10;       //Tick event occurs each 10 second
        private int fetchDataElapseInSeconds = 0;   //Time elapsed since the last fetch data event
        private int alertElapseInSeconds = 0;       //Time elapsed since the last trade alert event
        public scheduleForm()
        {
            try
            {
                InitializeComponent();
                //if (!Init()) application.sysLibs.ExitApplication();
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

        //private static bool Init()
        //{
        //    //application.sysLibs.sysProductOwner = application.Consts.constProductOwner;
        //    //application.sysLibs.sysProductCode = application.Consts.constProductCode;

        //    common.Consts.constValidCallString = common.Consts.constValidCallMarker;
        //    //common.settings.sysConfigFile = configFile;
        //    application.configuration.withEncryption = true;

        //    application.configuration.Load_User_Envir();
        //    application.configuration.Load_Db_Config();
        //    //Check data connection after db-setting were loaded
        //    if (!data.system.CheckAllDbConnection())
        //    {
        //        common.system.ShowMessage("Không thể kết nối đến nguồn dữ liệu.Xin vui lòng chạy lại chương trình [Setup].");
        //        return false;
        //    }
        //    application.configuration.Load_Sys_Settings();
        //    application.configuration.Load_User_Config(application.sysLibs.sysUseLocalConfigFile);
        //    return true;
        //}
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
            application.configuration.GetConfig(ref aFields);
            int val = 0;
            int.TryParse(aFields[0], out val);
            if (val != int.MaxValue)
            {
                fetchStockEd.Value = val;
                fetchStockChk.Checked = true;
            }
            else fetchStockChk.Checked = false;

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
            val = (int)(fetchStockChk.Checked ? fetchStockEd.Value : int.MaxValue);
            aValues.Add(val.ToString());
            val = (int)(tradeAlertChk.Checked ? tradeAlertEd.Value : int.MaxValue);
            aValues.Add(val.ToString());

            application.configuration.SaveConfig(aFields, aValues);
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
                if (fetchStockChk.Checked)
                {
                    fetchDataElapseInSeconds += timerIntervalInSecs;
                    if (!fProcessingFetchData && (fetchDataElapseInSeconds >= fetchStockEd.Value))
                    {
                        fProcessingFetchData = true;
                        if (!libs.AllowToUpdate(DateTime.Now))
                        {
                            common.fileFuncs.WriteLog(DateTime.Now.ToString() + " : ignored FetchRealTimeData().");
                        }
                        else
                        {
                            libs.FetchRealTimeData();
                        }
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
                        if (!libs.AllowToUpdate(DateTime.Now))
                        {
                            common.fileFuncs.WriteLog(DateTime.Now.ToString() + " : ignored CreateTradeAlert().");
                        }
                        else
                        {
                            common.fileFuncs.WriteLog(DateTime.Now.ToString() + " : Trade alert start");
                            stockTrade.libs.CreateTradeAlert(onTradeAlertProcessStart, onTradeAlertProcessItem, onTradeAlertProcessEnd);
                        }
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
                fetchStockEd.Enabled = fetchStockChk.Checked;
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
        private void viewConfigBtn_Click(object sender, EventArgs e)
        {
            try
            {
                common.fileFuncs.DisplayFile(myConfigFile);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        #endregion
    }
}
