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

            tradeAlertLbl.Text = Settings.sysGlobal.CheckAlertInSeconds.ToString() + " " + Languages.Libs.GetString("seconds");
            fetchStockLbl.Text = Settings.sysGlobal.RefreshDataInSecs.ToString() + " " + Languages.Libs.GetString("seconds");
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


        Boolean fFetchDataRunning = false;
        Boolean fCreateAlertRunning = false;
        private void FetchData()
        {
            try
            {
                if (fFetchDataRunning)
                {
                    //commonClass.SysLibs.WriteSysLog("Ignore fetch Data ");
                    return;
                }
                fFetchDataRunning = true;
                //commonClass.SysLibs.WriteSysLog("Start fetch Data ");
                libs.FetchRealTimeData(DateTime.Now);
                fFetchDataRunning = false;
            }
            catch (Exception er)
            {
                fFetchDataRunning = false;
                commonClass.SysLibs.WriteSysLog("Error " + er.Message);
            }
            
        }
        private void CreateTradeAlert()
        {
            try
            {
                if (fCreateAlertRunning)
                {
                    commonClass.SysLibs.WriteSysLog("Ignore Trade alert");
                    return;
                }
                fCreateAlertRunning = true;
                commonClass.SysLibs.WriteSysLog("-Trade alert started.");
                AlertLibs.CreateTradeAlert(onTradeAlertProcessStart, onTradeAlertProcessItem, onTradeAlertProcessEnd);
                fCreateAlertRunning = false;
            }
            catch (Exception er)
            {
                fCreateAlertRunning = false;
                commonClass.SysLibs.WriteSysLog(" - Trader Alert error " + er.Message);
                ShowError(er);
            }
        }

        #region event handler
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

                fetchDataTimer.WaitInSeconds = (short)(fetchDataChk.Checked?Settings.sysGlobal.RefreshDataInSecs:0);
                createTradeAlertTimer.WaitInSeconds = (short)(tradeAlertChk.Checked ? Settings.sysGlobal.CheckAlertInSeconds : 0);
                
                if (fRunning) myTimer.Start();
                else myTimer.Stop();
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
