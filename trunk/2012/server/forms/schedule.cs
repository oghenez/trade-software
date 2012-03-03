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
        common.TimerProcess fetchDataTimer = new common.TimerProcess();
        common.TimerProcess createTradeAlertTimer = new common.TimerProcess();
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
            Imports.Gold.ResetGetPrice();
            myTimer.Interval = Settings.sysGlobal.TimerIntervalInSecs * 1000;
            myTimer.Enabled = false;

            tradeAlertLbl.Text = Settings.sysGlobal.CheckAlertInSeconds.ToString() + " " + Languages.Libs.GetString("seconds");
            fetchStockLbl.Text = Settings.sysGlobal.RefreshDataInSecs.ToString() + " " + Languages.Libs.GetString("seconds");

            fetchDataTimer.WaitInSeconds = Settings.sysGlobal.RefreshDataInSecs;
            createTradeAlertTimer.WaitInSeconds = Settings.sysGlobal.CheckAlertInSeconds;

            fetchDataTimer.OnProcess += new common.TimerProcess.OnProcessEvent(FetchData);
            createTradeAlertTimer.OnProcess += new common.TimerProcess.OnProcessEvent(CreateTradeAlert);
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

        private void FetchData()
        {
            try
            {
                if (!fetchDataChk.Checked) return;
                libs.FetchRealTimeData(DateTime.Now);
            }
            catch (Exception er)
            {
                commonClass.SysLibs.WriteSysLog(" - Fetch Data error " + er.Message);
                ShowError(er);
            }
            
        }
        private void CreateTradeAlert()
        {
            try
            {
                if (!tradeAlertChk.Checked) return;

                commonClass.SysLibs.WriteSysLog("Trade alert started.");
                AlertLibs.CreateTradeAlert(onTradeAlertProcessStart, onTradeAlertProcessItem, onTradeAlertProcessEnd);
                //Trade.AlertLibs.CreateTradeAlert(null,null,null);
                commonClass.SysLibs.WriteSysLog("Trade alert ended.");
            }
            catch (Exception er)
            {
                commonClass.SysLibs.WriteSysLog(" - Trader Alert error " + er.Message);
                ShowError(er);
            }
        }

        #region event handler
        private void runBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Init();
                fRunning = !fRunning;
                this.ShowMessage("");
                runBtn.Image = (fRunning ? pauseBtn.Image : startBtn.Image);
                scheduleGb.Enabled = !fRunning;
                myTimer.Enabled = fRunning;
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
            try
            {
                fetchDataTimer.Execute();
                createTradeAlertTimer.Execute();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        #endregion
    }
}
