using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace update
{
    public class fetchStockData
    {
        private static string dbConfigFile = common.settings.sysConfigFile;
        private static string workConfigFile
        {
            get
            {
                return common.system.MakeFileNameFromExecutablePath(".conf");
            }
        }
        private static bool Init()
        {
            //application.sysLibs.sysProductOwner = application.Consts.constProductOwner;
            //application.sysLibs.sysProductCode = application.Consts.constProductCode;

            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            //common.settings.sysConfigFile = configFile;
            application.configuration.withEncryption = true;

            application.configuration.Load_User_Envir();
            application.configuration.Load_Db_Config();
            //Check data connection after db-setting were loaded
            if (!data.system.CheckAllDbConnection())
            {
                common.fileFuncs.WriteLog("Không thể kết nối đến nguồn dữ liệu.Xin vui lòng chạy lại chương trình [Setup].");
                return false;
            }
            application.configuration.Load_Sys_Settings();
            application.configuration.Load_User_Config(application.sysLibs.sysUseLocalConfigFile);
            return true;
        }


        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    common.fileFuncs.WriteLog("Invalid argument");
                    return;
                }
                if (!Init()) return;
                if (args[0].ToLower() == "fetchData".ToLower())
                {
                    if (!server.libs.AllowToUpdate())
                        common.fileFuncs.WriteLog(DateTime.Now.ToString() + " : ignored FetchRealTimeData().");                    
                    else server.libs.FetchRealTimeData();
                }
            }
            catch (Exception er)
            {
                common.fileFuncs.WriteLog(er.Message);
            }
        }
    }
}
