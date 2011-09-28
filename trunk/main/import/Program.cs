using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private static string configFile = "import.xml";
        static bool Init()
        {
            application.sysLibs.sysProductOwner = application.Consts.constProductOwner;
            application.sysLibs.sysProductCode = application.Consts.constProductCode;

            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            common.settings.sysConfigFile = configFile;
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
            return true;
        }

        static void UpdatePrice()
        {
            application.configuration.withEncryption = false;
            StringCollection aFields = new StringCollection();
            DateTime updateTime = application.sysLibs.GetServerDateTime();
            int idx = 0;
            while (true)
            {
                aFields.Clear();

                aFields.Add("url" + idx.ToString()); aFields.Add("stockExchange" + idx.ToString());
                if (!common.configuration.GetConfiguration(configFile, "SCHEDULE", "updatePrice", aFields))  break;
                Console.WriteLine("Import " + aFields[0] + " " +  aFields[1]);
                imports.libs.ImportPricedata_URL(updateTime,aFields[0], aFields[1]);
                idx++;
            }
            Console.WriteLine(idx.ToString() +  " items imported.");
            return;
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid argument");
                return;
            }
            if(!Init()) return;
            if (args[0].ToLower() == "updateprice".ToLower())
            {
                UpdatePrice();
            }
        }
    }
}
