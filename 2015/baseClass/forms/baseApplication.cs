using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonTypes;
using commonClass;

namespace baseClass.forms
{
    public partial class baseApplication : common.forms.baseApplication 
    {
        public baseApplication()
        {
            try
            {
                InitializeComponent();

                this.myStatusImageVisibled = true;
                this.myStatusImageEnabled = true;
                DataAccess.Libs.OnError += new DataAccess.OnErrorEvent(OnDataAccessError);
                DataAccess.Libs.OnConnStateChanged += new DataAccess.OnConnStateChangedEvent(OnDataAccessConnStateChanged);
                SetConnState(DataAccess.Libs.myConnState);

                AutoCheckingProc.WaitInSeconds = Settings.sysGlobal.AutoCheckInSeconds;
                AutoCheckingProc.OnProcess += new common.TimerProcess.OnProcessEvent(CheckConnection);

                loginRequired = true;
            }
            catch (Exception er)
            {
                common.system.ShowError(Languages.Libs.GetString("loadDataError"), er.Message);
                this.ShowError(er);
            }
        }

        private bool _logAccess = true;
        public bool LogAccess
        {
            get { return _logAccess; }
            set { _logAccess = value; }
        }

        static common.TimerProcess AutoCheckingProc = new common.TimerProcess();
        protected void OnDataAccessError(Exception er)
        {
            this.ShowError(er);
            DoCheckConnection();
        }
        protected void OnDataAccessConnStateChanged(DataAccess.ConnState connState)
        {
            SetConnState(connState);
        }
        protected void CheckConnection()
        {
            DoCheckConnection();
        }
        bool fDoCheckingConnection = false;
        protected void DoCheckConnection()
        {

            try
            {
                if (fDoCheckingConnection) return;
                fDoCheckingConnection = true;
                SetConnState(DataAccess.Libs.CheckConnection() ? DataAccess.ConnState.Connected : DataAccess.ConnState.Disconnected);
                fDoCheckingConnection = false;
            }
            catch 
            {
                fDoCheckingConnection = false;
            }
        }

        protected void SetConnState(DataAccess.ConnState connState)
        {
            this.myStatusImage = (connState == DataAccess.ConnState.Connected ? Properties.Resources.connected : Properties.Resources.disconnected);
            this.myStatusToolTipText = (connState == DataAccess.ConnState.Connected ? Languages.Libs.GetString("connected") : Languages.Libs.GetString("noConnection"));
            DataAccess.Libs.myConnState = connState;
        }
        protected void SetTimer(bool enabled)
        {
            if (enabled && Settings.sysGlobal.TimerIntervalInSecs > 0)
            {
                sysTimer.Interval = Settings.sysGlobal.TimerIntervalInSecs * 1000; //Convert to mili-seconds 
                sysTimer.Enabled = true;
            }
            else sysTimer.Enabled = false;
        }
        protected virtual void ProcessSysTimerTick()
        {
            if (AutoCheckingProc.IsEndWaitTime())
                AutoCheckingProc.Execute();
        }

        public MenuStrip mainMenuStrip = null;
        private bool _permissionRequired = false;
        protected bool permissionRequired
        {
            get { return _permissionRequired; }
            set { _permissionRequired = value; }
        }

        protected override bool LoadAppEnvironment() 
        {
            //commonClass.SysLibs.SetAppEnvironment();
            common.language.myCulture = AppTypes.Code2Culture(Settings.sysLanguage);
            return base.LoadAppEnvironment(); 
        }
        protected override bool LoadAppConfig()
        {
            common.Settings.sysProductOwner = Consts.constProductOwner;
            common.Settings.sysProductCode = Consts.constProductCode;

            common.Settings.sysConfigFile = common.fileFuncs.GetFullPath(this.myConfigFileName);
            DataAccess.Libs.Load_Global_Settings();
            common.configuration.withEncryption = true;
            application.Configuration.Load_User_Envir();
            return true;
        }
        protected override bool LoadUserConfig()
        {
            application.Configuration.Load_Local_UserSettings();
            //Image
            if (common.fileFuncs.FileExist(Settings.sysImgFilePathBackGround))
                this.BackgroundImage = common.images.LoadImage(Settings.sysImgFilePathBackGround);
            else this.BackgroundImage = null;
            if (common.fileFuncs.FileExist(Settings.sysImgFilePathIcon))
                this.Icon = common.images.LoadIcon(Settings.sysImgFilePathIcon);
            else this.Icon = null;
            return true;
        }
        protected override bool SaveAppEnvironment()
        {
            return application.Configuration.Save_User_Envir();
        }
        protected override void ShowError(Exception er)
        {
            switch (Settings.sysWriteLogException)
            {
                case AppTypes.SyslogMedia.Database:
                    DataAccess.Libs.WriteLog(commonClass.SysLibs.sysLoginCode, er);
                    break;
                case AppTypes.SyslogMedia.File:
                    commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error,"base004", er);
                    break;
            }
        }

        //Check user config file
        protected override bool CheckValid()
        {
            if (!common.fileFuncs.IsFileReadWritable(commonTypes.Settings.sysFileUserConfig))
            {
                common.system.ShowErrorMessage("Cannot acces file : "+ commonTypes.Settings.sysFileUserConfig);
            }
            //Ensure that user.xml file is valid
            if (!common.xmlLibs.IsValidXML(commonTypes.Settings.sysFileUserConfig))
            {
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error,"base004", "Invalid configuration file :" + commonTypes.Settings.sysFileUserConfig);
                if (!common.xmlLibs.CreateEmptyXML(commonTypes.Settings.sysFileUserConfig, true)) return false;
            }
            //Load settings from user.xml file 
            if (!application.Configuration.Load_Local_Settings()) return false;

            //Check whether time different b/w client and server is valid 
            if (Settings.sysTimeServer.Trim() != "")
            {
                DateTime serverDT = common.Networking.GetNetworkTime(Settings.sysTimeServer);
                DateTime currentDT = DateTime.Now;

                TimeSpan timeDiff = serverDT.Subtract(currentDT);
                double timeDiffInSecs = Math.Abs(common.dateTimeLibs.DateDiffInSecs(serverDT, currentDT));
                if (timeDiffInSecs > Settings.sysMaxTimeDifferenceInSecs)
                {
                    common.system.ShowErrorMessage(String.Format(Languages.Libs.GetString("serverClientTimeDifference"), common.dateTimeLibs.TimeSpan2String(timeDiff)));
                }
            }
            // Check connection, if fail, allowing user to setup the connection
            if (!DataAccess.Libs.CheckConnection())
            {
                ShowConfigForm();
                if (!DataAccess.Libs.CheckConnection())
                {
                    commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error,"base005", "Invalid configuration file :" + common.Settings.sysConfigFile);
                    return false;
                }
            }

            //Check version to ensure to exclude obsolete versions
            string productVersion = common.Settings.sysProductVersion.Trim();
            if (productVersion != "" && productVersion != common.Settings.sysProductVersion.Trim())
            {
                common.system.ShowErrorMessage(String.Format(Languages.Libs.GetString("pleaseUseVersion"), common.Settings.sysProductVersion));
                return false;
            }
            return base.CheckValid();
        }

        protected void ShowConfigForm()
        {
            baseClass.forms.configure form = new baseClass.forms.configure();
            form.ShowDialog();
        }

        protected string LicenseFileName()
        {
            return common.fileFuncs.FileNameOnly(common.system.GetExecuteFullPath()) + ".lic";
        }
        protected string _myConfigFileName = null;
        protected virtual string myConfigFileName
        {
            get
            {
                if (_myConfigFileName == null) _myConfigFileName = common.fileFuncs.FileNameOnly(common.system.GetExecuteFullPath()) + ".xml";
                return _myConfigFileName;
            }
            set
            {
                _myConfigFileName = value;
            }
        }

        protected override bool CheckLicense()
        {
            return true;
        }

        protected override bool ShowLogin()
        {
            baseClass.forms.investorLogin myLogin = new investorLogin();
            this.ShowForm(myLogin, true);
            if (!myLogin.isLoginOk) return false;

            this.loginInfoLbl.Text = "[" + commonClass.SysLibs.sysLoginCode.Trim() + "]  " + "[" + commonClass.SysLibs.sysLoginType + "]" ;
            //if (permissionRequired) SetUserMenu(commonClass.SysLibs.sysLoginUserId, mainMenuStrip);

            // Load permission
            return true;
        }
        //protected virtual void SetUserMenu(int workerId, MenuStrip myMenuStrip)
        //{
        //}
        //private void SetUserAllMenu(int workerId, ToolStripMenuItem menuItem)
        //{
        //    for (int idx = 0; idx < menuItem.DropDownItems.Count; idx++)
        //    {
        //        menuItem.DropDownItems[idx].Enabled = true;
        //    }
        //}

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                this.Font = Settings.sysFontMain;
                if (!LogAccess) return;
                switch (Settings.sysGlobal.WriteLogAccess)
                {
                    case AppTypes.SyslogMedia.Database:
                        DataAccess.Libs.WriteLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Opened : " + this.Name, null, null);
                        break;
                    case AppTypes.SyslogMedia.File:
                        commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational,"", commonClass.SysLibs.sysLoginCode + " Opened : " + this.Name);
                        break;
                }
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!LogAccess) return;
                switch (Settings.sysGlobal.WriteLogAccess)
                {
                    case AppTypes.SyslogMedia.Database:
                        DataAccess.Libs.WriteLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Closed : " + this.Name, null, null);
                        break;
                    case AppTypes.SyslogMedia.File:
                        commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational,"",commonClass.SysLibs.sysLoginCode+ " Closed : " + this.Name);
                        break;
                }
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void sysTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (bgWorkerTimer.IsBusy) return;
                bgWorkerTimer.RunWorkerAsync();
                //ProcessSysTimerTick();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void bgWorkerTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProcessSysTimerTick();
        }
    }
}