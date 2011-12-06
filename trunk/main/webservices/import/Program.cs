using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using commonClass; 

namespace ConsoleApplication1
{
    class Program
    {
        private static string configFile = "import.xml";
        static bool Init()
        {
            common.settings.sysProductOwner = Consts.constProductOwner;
            common.settings.sysProductCode = Consts.constProductCode;

            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            common.settings.sysConfigFile = configFile;
            common.configuration.withEncryption = true;

            application.Configuration.Load_User_Envir();
            //Check data connection after db-setting were loaded
            if (!data.SysLibs.CheckAllDbConnection())
            {
                common.system.ShowErrorMessage("Không thể kết nối đến nguồn dữ liệu.Xin vui lòng chạy lại chương trình [Setup].");
                return false;
            }
            application.Configuration.Load_Global_Settings();
            application.Configuration.Load_Local_Settings();
            return true;
        }

        static void UpdatePrice()
        {
            common.configuration.withEncryption = false;
            StringCollection aFields = new StringCollection();
            DateTime updateTime = DateTime.Now;
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
