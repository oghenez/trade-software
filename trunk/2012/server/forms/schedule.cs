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
using System.Diagnostics;

namespace server
{
    public partial class scheduleForm : baseClass.forms.baseForm   
    {
        private bool fRunning = false;
        common.TimerProcess fetchDataTimer = new common.TimerProcess();
        common.TimerProcess fetchDataTimerHOSE = new common.TimerProcess();
        common.TimerProcess fetchDataTimerHASTC = new common.TimerProcess();
        common.TimerProcess fetchDataTimerGOLD = new common.TimerProcess();

        common.TimerProcess createTradeAlertTimer = new common.TimerProcess();

        BackgroundWorker bWorker;

        public scheduleForm()
        {
            try
            {
                InitializeComponent();
                Init();                
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public void Init()
        {
            tradeAlertLbl.Text = Settings.sysGlobal.CheckAlertInSeconds.ToString() + " " + Languages.Libs.GetString("seconds");
            fetchStockLbl.Text = Settings.sysGlobal.RefreshDataInSecs.ToString() + " " + Languages.Libs.GetString("seconds");
            //fetchDataTimer.OnProcess += new common.TimerProcess.OnProcessEvent(FetchData);
            fetchDataTimerHOSE.OnProcess += new common.TimerProcess.OnProcessEvent(FetchDataHOSE);
            fetchDataTimerHASTC.OnProcess += new common.TimerProcess.OnProcessEvent(FetchDataHASTC);
            fetchDataTimerGOLD.OnProcess += new common.TimerProcess.OnProcessEvent(FetchDataGOLD);

            createTradeAlertTimer.OnProcess += new common.TimerProcess.OnProcessEvent(CreateTradeAlert);

            bWorker = new BackgroundWorker();
            bWorker.DoWork += new DoWorkEventHandler(bWorker_DoWork);
            bWorker.ProgressChanged += new ProgressChangedEventHandler(bWorker_ProgressChanged);
            bWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bWorker_DoWork_RunWorkerCompleted);

            bWorker.WorkerReportsProgress = true;
            bWorker.WorkerSupportsCancellation = true;
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (fFetchDataHOSERunning) myStatusStrip.Text = "Downloading HOSE data..";
            if (fFetchDataHASTCRunning) myStatusStrip.Text = "Downloading HASTC data..";
            if (fFetchDataGOLDRunning) myStatusStrip.Text = "Downloading Gold data..";
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FetchData();
        }

        void bWorker_DoWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void onTradeAlertProcessStart(int count)
        {
            if (myStatusStrip.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    DoOnTradeAlertProcessStart(count);
                });
            }
            else
            {
                DoOnTradeAlertProcessStart(count);
            }
        }
        private bool onTradeAlertProcessItem(string code)
        {
            if (myStatusStrip.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    DoOnTradeAlertProcessItem(code);
                });
            }
            else
            {
                DoOnTradeAlertProcessItem(code);
            }
            return fRunning;
        }
        private void onTradeAlertProcessEnd()
        {
            if (myStatusStrip.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate()
                {
                    DoOnTradeAlertProcessEnd();
                });
            }
            else
            {
                DoOnTradeAlertProcessEnd();
            }
        }

        private void DoOnTradeAlertProcessStart(int count)
        {
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = count;
        }
        private bool DoOnTradeAlertProcessItem(string stockcode)
        {
            Application.DoEvents();
            progressBar.Value++;
            this.ShowMessage(stockcode);
            return fRunning;
        }
        private void DoOnTradeAlertProcessEnd()
        {
            progressBar.Visible = false;
            this.ShowMessage("");
        }


        Boolean fFetchDataRunning = false;
        Boolean fFetchDataHOSERunning = false;
        Boolean fFetchDataHASTCRunning = false;
        Boolean fFetchDataGOLDRunning = false;

        Boolean fCreateAlertRunning = false;
        private void FetchData()
        {
            try
            {
                if (fFetchDataRunning)  return;
                
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();            
 
                fFetchDataRunning = true;
                //libs.FetchRealTimeData(DateTime.Now,"HOSE");
                //libs.FetchRealTimeData(DateTime.Now, "HASTC");
                //libs.FetchRealTimeData(DateTime.Now, "GOLD");
                //09-Jul-14 update tat ca cac du lieu o cac san
                libs.FetchRealTimeData(DateTime.Now);

                fFetchDataRunning = false;
                
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                //commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Warning, "Time01",elapsedTime);
            }
            catch (Exception er)
            {
                fFetchDataRunning = false;
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV002",er);
            }
            
        }

        private void FetchDataHOSE()
        {
            try
            {
                if (fFetchDataHOSERunning) return;

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                fFetchDataHOSERunning = true;
                libs.FetchRealTimeData(DateTime.Now, "HOSE");
                fFetchDataHOSERunning = false;

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Warning, "TimeHOSE", elapsedTime);
            }
            catch (Exception er)
            {
                fFetchDataHOSERunning = false;
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV002", er);
            }

        }

        private void FetchDataHASTC()
        {
            try
            {
                if (fFetchDataHASTCRunning) return;

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                fFetchDataHASTCRunning = true;
                libs.FetchRealTimeData(DateTime.Now, "HASTC");
                fFetchDataHASTCRunning = false;

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Warning, "TimeHASTC", elapsedTime);
            }
            catch (Exception er)
            {
                fFetchDataHASTCRunning = false;
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV002", er);
            }

        }

        private void FetchDataGOLD()
        {
            try
            {
                if (fFetchDataGOLDRunning) return;

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                fFetchDataGOLDRunning = true;
                libs.FetchRealTimeData(DateTime.Now, "GOLD");
                fFetchDataGOLDRunning = false;

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Warning, "TimeGOLD", elapsedTime);
            }
            catch (Exception er)
            {
                fFetchDataGOLDRunning = false;
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV002", er);
            }

        }

        private void CreateTradeAlert()
        {
            try
            {
                if (fCreateAlertRunning)
                {
                    commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational, "", "Ignore Trade alert");
                    return;
                }
                fCreateAlertRunning = true;
                int noAlertCreated = application.TradeAlert.CreateTradeAlert(onTradeAlertProcessStart, onTradeAlertProcessItem, onTradeAlertProcessEnd);
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational, "", " - Trade alert run successfully : " + noAlertCreated + " alerts created");
                fCreateAlertRunning = false;
            }
            catch (Exception er)
            {
                fCreateAlertRunning = false;
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV003", " - Trader Alert error " + er.Message);
                ShowError(er);
            }
        }

        #region event handler

        /// <summary>
        /// Xu ly hanh vi nhan chuot. 
        /// Khoi tao hanh vi cua Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runBtn_Click(object sender, EventArgs e)
        {
            fFetchDataRunning = false;
            fCreateAlertRunning = false;
            try
            {
                fRunning = !fRunning;
                this.ShowMessage("");
                runBtn.Image = (fRunning ? pauseBtn.Image : startBtn.Image);
                scheduleGb.Enabled = !fRunning;

                //fetchDataTimer.WaitInSeconds = (short)(fetchDataChk.Checked?Settings.sysGlobal.RefreshDataInSecs:0);
                fetchDataTimerHOSE.WaitInSeconds = (short)(fetchDataChk.Checked ? Settings.sysGlobal.RefreshDataInSecs : 0);
                fetchDataTimerHASTC.WaitInSeconds = (short)(fetchDataChk.Checked ? Settings.sysGlobal.RefreshDataInSecs : 0);
                fetchDataTimerGOLD.WaitInSeconds = (short)(fetchDataChk.Checked ? Settings.sysGlobal.RefreshDataInSecs : 0);

                createTradeAlertTimer.WaitInSeconds = (short)(tradeAlertChk.Checked ? Settings.sysGlobal.CheckAlertInSeconds : 0);
                //createTradeAlertTimer.WaitInSeconds = 10;

                if (fRunning)
                {
                    myTimer.Start();

                    //Init last price before importing
                    databases.AppLibs.GetLastClosePrices();
                }
                else myTimer.Stop();
                //if (fRunning)
                //{
                //    //databases.AppLibs.GetLastClosePrices();
                //    bWorker.RunWorkerAsync();
                //}
                //else bWorker.CancelAsync();
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
                common.fileFuncs.DisplayFile(Settings.sysFileUserLog);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!bWorker.IsBusy)
                    bWorker.RunWorkerAsync();
                //if (fetchDataTimerHOSE.IsEndWaitTime()) 
                //    fetchDataTimerHOSE.Execute();

                //if (fetchDataTimerHASTC.IsEndWaitTime())
                //    fetchDataTimerHASTC.Execute();

                //if (fetchDataTimerGOLD.IsEndWaitTime())
                //    fetchDataTimerGOLD.Execute();

                //if (createTradeAlertTimer.IsEndWaitTime()) 
                //    createTradeAlertTimer.Execute();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        #endregion

        private void timerAlert_Tick(object sender, EventArgs e)
        {
            try
            {                
                if (createTradeAlertTimer.IsEndWaitTime())
                    createTradeAlertTimer.Execute();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
    }
}
