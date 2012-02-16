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

                AutoCheckingProc.WaitingUnit = Settings.sysGlobal.TimerUnitToAutoCheck;
                AutoCheckingProc.OnProcess += new common.TimerProcess.OnProcessEvent(CheckConnection);

                loginRequired = true;
            }
            catch (Exception er)
            {
                //common.system.ShowError(Languages.Libs.GetString("loadDataError"), Languages.Libs.GetString("internetError"));
                common.system.ShowError(Languages.Libs.GetString("loadDataError"), er.Message);
                this.ShowError(er);
            }
        }

        static common.TimerProcess AutoCheckingProc = new common.TimerProcess();
        protected void OnDataAccessError(Exception er)
        {
            CheckConnection();
        }
        protected void OnDataAccessConnStateChanged(DataAccess.ConnState connState)
        {
            SetConnState(connState);
        }
        protected void CheckConnection()
        {
            SetConnState(DataAccess.Libs.CheckConnection() ? DataAccess.ConnState.Connected : DataAccess.ConnState.Disconnected);
        }
        protected void SetConnState(DataAccess.ConnState connState)
        {
            this.myStatusImage = (connState == DataAccess.ConnState.Connected ? Properties.Resources.connected : Properties.Resources.disconnected);
            this.myStatusToolTipText = (connState == DataAccess.ConnState.Connected ? Languages.Libs.GetString("connected") : Languages.Libs.GetString("noConnection"));
            DataAccess.Libs.myConnState = connState;
        }
        protected void SetTimer(bool enabled)
        {
            if (enabled && Settings.sysGlobal.TimerUnitInSecs > 0)
            {
                sysTimer.Interval = Settings.sysGlobal.TimerUnitInSecs * 1000; //Convert to mili-seconds 
                sysTimer.Enabled = true;
            }
            else sysTimer.Enabled = false;
        }
        protected virtual void ProcessSysTimerTick()
        {
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
            application.Configuration.Load_Local_Settings();
            //Image
            if (common.fileFuncs.FileExist(Settings.sysImgFilePathBackGround))
                this.BackgroundImage = common.images.LoadImage(Settings.sysImgFilePathBackGround);
            else this.BackgroundImage = null;
            if (common.fileFuncs.FileExist(Settings.sysImgFilePathIcon))
                this.Icon = common.images.LoadIcon(Settings.sysImgFilePathIcon);
            else this.Icon = null;
            return true;
        }
        protected override void SaveAppEnvironment()
        {
            application.Configuration.Save_User_Envir();
        }

        protected override bool CheckValid()
        {
            //if(!base.CheckValid()) return false;
            string productVersion = common.Settings.sysProductVersion.Trim();
            if (productVersion != "" && productVersion != common.Settings.sysProductVersion.Trim())
            {
                common.system.ShowErrorMessage(String.Format(Languages.Libs.GetString("pleaseUseVersion"), common.Settings.sysProductVersion));
                return false;
            }
            if (!DataAccess.Libs.OpenConnection())
            {
                ShowConfigForm();
                if (!DataAccess.Libs.OpenConnection())
                {
                    commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Others, null, "Invalid configuration file :" + common.Settings.sysConfigFile);
                    return false;
                }
            }
            //Ensure that user.xml file is valid
            if (!common.xmlLibs.IsValidXML(commonTypes.Settings.sysUserConfigFile))
            {
                commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Others, null,"Invalid configuration file :" +  commonTypes.Settings.sysUserConfigFile);
                common.xmlLibs.CreateEmptyXML(commonTypes.Settings.sysUserConfigFile);
            }
            //int timeDiff = Math.Abs(common.dateTimeLibs.DateDiffInSecs(DataAccess.Libs.GetServerDateTime(), DateTime.Now));
            //if (timeDiff > Settings.sysMaxTimeDifferenceInSecs)
            //{
            //    common.system.ShowErrorMessage(String.Format(Languages.Libs.GetString("serverClientTimeDifference"), timeDiff)); 
            //    return false;
            //}
            return true;
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
                switch (Settings.sysWriteLogException)
                {
                    case AppTypes.SyslogMedia.Database:
                        DataAccess.Libs.WriteSyslog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Opened : " + this.Name, null, null);
                        break;
                    case AppTypes.SyslogMedia.File:
                        commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Opened : " + this.Name);
                        break;
                }
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        protected override void ShowError(Exception er)
        {
            switch (Settings.sysWriteLogException)
            {
                case AppTypes.SyslogMedia.Database:
                    DataAccess.Libs.WriteSyslog(er, commonClass.SysLibs.sysLoginCode);
                    break;
                case AppTypes.SyslogMedia.File:
                    commonClass.SysLibs.WriteSysLog(er, commonClass.SysLibs.sysLoginCode);
                    break;
            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                switch (Settings.sysWriteLogException)
                {
                    case AppTypes.SyslogMedia.Database:
                        DataAccess.Libs.WriteSyslog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Closed : " + this.Name, null, null);
                        break;
                    case AppTypes.SyslogMedia.File:
                        commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Access, commonClass.SysLibs.sysLoginCode, "Closed : " + this.Name);
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
                ProcessSysTimerTick();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}