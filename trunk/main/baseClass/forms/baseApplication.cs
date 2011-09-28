using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class baseApplication : common.forms.baseApplication 
    {
        public baseApplication()
        {
            InitializeComponent();
            loginRequired = true;
        }

        public MenuStrip mainMenuStrip = null;
        public static DateTime workPeriodStart, workPeriodEnd;
        private bool _permissionRequired = false;
        protected bool permissionRequired
        {
            get { return _permissionRequired; }
            set { _permissionRequired = value; }
        }

        public static bool InWorkPeriod(string dateTimeStr)
        {
            DateTime dt;
            if (!common.dateTimeLibs.StringToDateTime(dateTimeStr, out dt)) return false;
            if ((dt.CompareTo(workPeriodStart) >= 0) && (dt.CompareTo(workPeriodEnd) <= 0)) return true;
            return false;
        }
        public static bool InWorkPeriod(DateTime dt)
        {
            if ((dt.CompareTo(workPeriodStart) >= 0) && (dt.CompareTo(workPeriodEnd) <= 0)) return true;
            return false;
        }

        protected override bool LoadAppEnvironment() 
        {
            application.sysLibs.SetAppEnvironment();
            return base.LoadAppEnvironment(); 
        }
        protected override void SaveAppEnvironment() 
        {
            application.configuration.Save_User_Envir();
        }

        protected override bool LoadAppConfig()
        {
            application.sysLibs.sysProductOwner = application.Consts.constProductOwner ;
            application.sysLibs.sysProductCode = application.Consts.constProductCode;

            common.settings.sysConfigFile = this.myConfigFileName;
            application.configuration.withEncryption = true;

            application.configuration.Load_User_Envir();
            application.configuration.Load_Db_Config();
            //Check data connection after db-setting were loaded
            if (!data.system.CheckAllDbConnection())
            {
                common.system.ShowErrorMessage("Không thể kết nối đến nguồn dữ liệu.Xin vui lòng chạy lại chương trình [Setup].");
                return false;
            }
            application.configuration.Load_Sys_Settings();
            application.configuration.Load_User_Config(application.sysLibs.sysUseLocalConfigFile);

            //Image
            if (common.fileFuncs.FileExist(application.sysLibs.sysImgFilePathBackGround))
                this.BackgroundImage = common.images.LoadImage(application.sysLibs.sysImgFilePathBackGround);
            else this.BackgroundImage = null;
            if (common.fileFuncs.FileExist(application.sysLibs.sysImgFilePathIcon))
                this.Icon = common.images.LoadIcon(application.sysLibs.sysImgFilePathIcon);
            else this.Icon = null;
            return true;
        }

        protected override bool CheckValid()
        {
            string productVersion = application.sysLibs.sysProductVersion.Trim();
            if (productVersion != "" && productVersion != application.sysLibs.sysProductVersion.Trim())
            {
                common.system.ShowErrorMessage("Xin vui lòng sử dụng phiên bản : " + application.sysLibs.sysProductVersion);
                return false;
            }
            return true;
        }
        protected string LicenseFileName()
        {
            return common.fileFuncs.FileNameOnly(Application.ExecutablePath) + ".lic";
        }
        protected string _myConfigFileName = null;
        protected virtual string myConfigFileName
        {
            get
            {
                if (_myConfigFileName == null) _myConfigFileName = common.fileFuncs.FileNameOnly(Application.ExecutablePath) + ".xml";
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
            application.sysLibs.sysCompanyName = "";
            common.license.myLicenseItem lic;
            string licFile = LicenseFileName();
            
            int ticketCount = 1;
            while (true)
            {
                if (common.fileFuncs.FileExist(licFile))
                {
                    lic = common.license.GetLicence(licFile);
                    if ( (lic != null) && (lic.productCode == application.sysLibs.sysProductCode) && common.license.isSerialOk(lic)) 
                    {
                        // Set the company name from licence file
                        application.sysLibs.sysCompanyName = lic.companyName;
                        return true; 
                    }
                }
                if (ticketCount == 0) return false;
                Libs.ShowLicenseCheck(application.sysLibs.sysProductOwner, application.sysLibs.sysProductCode, this.LicenseFileName());
                ticketCount--;
            }
            return false;
        }

        protected override bool ShowLogin()
        {
            baseClass.forms.investorLogin myLogin = new investorLogin();
            this.ShowForm(myLogin, true);
            if (!myLogin.isLoginOk) return false;

            this.loginInfoLbl.Text = "[" + application.sysLibs.sysLoginCode.Trim() + "]  " + "[" + application.sysLibs.sysLoginType + "]  " +
                                     "[" + application.sysLibs.sysLoginLocationName.Trim() + "]";
            if (permissionRequired) SetUserMenu(application.sysLibs.sysLoginUserId, mainMenuStrip);

            // Load permission
            return true;
        }

        protected virtual void SetUserMenu(int workerId, MenuStrip myMenuStrip)
        {
            //if (myMenuStrip == null) return;
            //data.baseDS.geWorkerPermissionDataTable permission = application.dataLibs.GetWorkerAllPermission(application.Consts.constSysPermissionMenu,workerId);
            //bool fAdmin = application.sysLibs.isSupperAdminLogin();
            //for (int idx = 0; idx < myMenuStrip.Items.Count; idx++)
            //{
            //    if (fAdmin) SetUserAllMenu(workerId, (ToolStripMenuItem)myMenuStrip.Items[idx]);
            //    else SetUserMenuItem(permission, (ToolStripMenuItem)myMenuStrip.Items[idx]);
            //}
        }
        private void SetUserAllMenu(int workerId, ToolStripMenuItem menuItem)
        {
            for (int idx = 0; idx < menuItem.DropDownItems.Count; idx++)
            {
                menuItem.DropDownItems[idx].Enabled = true;
            }
        }
        //private void SetUserMenuItem(data.baseDS.geWorkerPermissionDataTable permmissionTbl, ToolStripMenuItem menuItem)
        //{
        //    DataRow[] drFound;
        //    string menuCode;
        //    for (int idx1 = 0; idx1 < menuItem.DropDownItems.Count; idx1++)
        //    {
        //        if (menuItem.DropDownItems[idx1].GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem")
        //        {
        //            ToolStripMenuItem subMenu = ((ToolStripMenuItem)menuItem.DropDownItems[idx1]);
        //            if (subMenu.DropDownItems.Count > 0)
        //            {
        //                SetUserMenuItem(permmissionTbl, subMenu);
        //                continue;
        //            }
        //        }
        //        //System menu,available to all users
        //        if (menuItem.DropDownItems[idx1].Tag == null) continue;
        //        menuCode = menuItem.DropDownItems[idx1].Tag.ToString().Trim();
        //        if (menuCode == "") continue;
        //        menuItem.DropDownItems[idx1].Enabled = false;
        //        drFound = permmissionTbl.Select(permmissionTbl.codeColumn + "='" + menuCode + "'");
        //        if (drFound == null || drFound.Length == 0) continue;
        //        menuItem.DropDownItems[idx1].Enabled = true;
        //    }
        //}
    }
}