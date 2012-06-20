using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace server
{
    public partial class libs
    {
        private static string _configFile = null;
        private static string myConfigFile
        {
            get
            {
                if (_configFile == null)
                    _configFile = common.fileFuncs.MakeFileNameFromExecutablePath(".conf");
                return _configFile;
            }
        }

        private static bool GetConfig(string type,string subType,StringCollection aFields)
        {
            return common.configuration.GetConfiguration(myConfigFile, type, subType, aFields,false);
        }

        // Convert incompleted date string to date
        private static DateTime String2Date(string dateStr,DateTime curDate)
        {
            string[] items = dateStr.Split(new char[] { '/'}, StringSplitOptions.RemoveEmptyEntries);
            switch(items.Length)
            {
                case 0 : return common.Consts.constNullDate;
                case 1: dateStr += curDate.Month.ToString() + "/" + curDate.Year.ToString(); break;
                case 2: dateStr += "/" + curDate.Year.ToString(); break;
            }
            if (DateTime.TryParseExact(dateStr, "d/M/yyyy",null,DateTimeStyles.None, out curDate)) return curDate;
            return common.Consts.constNullDate; 
        }

        // holidayRules : for example "30/04:01/05 ; 02/09"  
        // Date in the format d/M/yyyy with/without  [M] and [yyyy] parts
        private static bool IsHolidays(DateTime cuDateTime, string holidayRules)
        {
            DateTime frDate = common.Consts.constNullDate, toDate=common.Consts.constNullDate;
            string[] items = common.system.String2List(holidayRules, ";");
            for (int idx1 = 0; idx1 < items.Length; idx1++)
            {
                string[] subItems = common.system.String2List(items[idx1], ":");
                if (subItems.Length <= 0) continue;
                frDate = String2Date(subItems[0],cuDateTime);
                if (frDate==common.Consts.constNullDate) continue;
                if (subItems.Length > 1)
                {
                    toDate = String2Date(subItems[1], cuDateTime);
                    if (toDate == common.Consts.constNullDate) continue;
                }
                else toDate = frDate;
                if (cuDateTime >= frDate && cuDateTime <= toDate) return true;
            }
            return false;
        }

        //Read the config file and decide whether a task can be started or not
        public static bool AllowToUpdate(DateTime curDateTime)
        {
            string[] list;
            DateTime dt = common.Consts.constNullDate;
            StringCollection aFields = new StringCollection();
            bool saveEncryption = common.configuration.withEncryption;
            common.configuration.withEncryption = false;
            aFields.Clear();
            aFields.Add("Holidays");
            if (GetConfig("UPDATEDATA", "updateTime", aFields) && IsHolidays(curDateTime, aFields[0])) return false;

            int idx = -1;
            while (true)
            {
                idx++;
                aFields.Clear();
                aFields.Add("range" + idx.ToString());
                if (!GetConfig("UPDATEDATA", "updateTime", aFields)) break;
                //"Start time"  "End Time"  "Dow,,Dow"
                list = common.system.String2List(aFields[0], ";");
                if (list.Length != 3)
                {
                    common.fileFuncs.WriteLog("Invalid config : " + aFields[0]);
                    return false;
                }
                //Start date
                if (common.dateTimeLibs.StringToDateTime(list[0], out dt))
                {
                    if (curDateTime < dt) continue;
                }
                //End date
                if (common.dateTimeLibs.StringToDateTime(list[1], out dt))
                {
                    if (curDateTime > dt) continue;
                }
                //dayOfWeek
                string[] dow = common.system.String2List(list[2]);
                if (dow.Length > 0 && !dow.Contains(curDateTime.DayOfWeek.ToString().Substring(0, 3))) continue;
                return true;
            }
            return false;
        }
        public static void FetchRealTimeData(DateTime updateTime)
        {
            StringCollection aFields = new StringCollection();
            int idx = 0;
            while (true)
            {
                aFields.Clear();
                aFields.Add("url" + idx.ToString()); aFields.Add("stockExchange" + idx.ToString());
                if (!GetConfig("UPDATEDATA","updateSource", aFields)) break;
                common.fileFuncs.WriteLog(updateTime.ToString() + " : update data from " + aFields[0] + " " + aFields[1]);
                imports.libs.ImportPricedata_URL(updateTime, aFields[0], aFields[1]);
                idx++;
            }
            return;
        }
    }
}
