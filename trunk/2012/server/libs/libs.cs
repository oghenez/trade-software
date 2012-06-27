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
using commonTypes;

namespace server
{
    public partial class libs
    {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuDateTime"></param>
        /// <param name="holidayRules">
        /// For example : 30/04:01/05; 02/09;7/1:7/30 
        /// Date in the format d/M/yyyy with/without [M] and [yyyy] parts
        /// </param>
        /// <returns></returns>
        public static bool IsHolidays(DateTime cuDateTime, string holidayRules)
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

        /// <summary>
        /// Parse the configuratione and decide whether to update
        /// </summary>
        /// <param name="curDateTime"></param>
        /// <param name="workTimes"> there may be one ore more lines as in the following
        /// - Line 0 : 8:00;23:59;Mon,Tue,Wed,Thu,Fri
        /// - Line 1 : 8:00;12:00;Sat
        /// </param>
        /// <returns></returns>
        public static bool IsWorktime(DateTime curDateTime,StringCollection workTimeRules)
        {
            string[] list;
            DateTime dt = common.Consts.constNullDate;
            
            //Empty  means ALL
            if (workTimeRules.Count == 0) return true;

            for (int idx = 0; idx < workTimeRules.Count; idx++)
            {
                //"Start time" ;  "End Time" ; "Dow,,Dow"
                list = common.system.String2List(workTimeRules[idx], ";");
                if (list.Length != 3)
                {
                    commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error,"SRV001", "Invalid config : " + workTimeRules[idx]);
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


        static Imports.Stock.hoseImport hoseImport = new Imports.Stock.hoseImport();
        static Imports.Stock.htastcImport htastcImport = new Imports.Stock.htastcImport();

        static Imports.Stock.vnIdxImport vnIdxImport = new Imports.Stock.vnIdxImport();
        static Imports.Stock.hnIdxImport hnIdxImport = new Imports.Stock.hnIdxImport();

        static Imports.Gold.forexImport forexImport = new Imports.Gold.forexImport();
        public static void FetchRealTimeData(DateTime updateTime)
        {
            DataView myDataView = new DataView(application.SysLibs.myExchangeDetailTbl);
            myDataView.Sort =  application.SysLibs.myExchangeDetailTbl.orderIdColumn.ColumnName;
            string[] parts;
            DataRowView[] foundRows;
            databases.baseDS.stockExchangeRow marketRow;
            databases.baseDS.exchangeDetailRow exchangeDetailRow;
            for (int idx1 = 0; idx1 < application.SysLibs.myStockExchangeTbl.Count; idx1++)
            {
                marketRow = application.SysLibs.myStockExchangeTbl[idx1];
                if (IsHolidays(updateTime, marketRow.holidays)) continue;

                // WorkTimes can have multipe parts separated by charater |
                parts = marketRow.workTime.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                StringCollection confWorkTimes = new StringCollection();
                for(int idx2=0;idx2<parts.Length;idx2++) confWorkTimes.Add(parts[idx2]);
                if (!IsWorktime(updateTime, confWorkTimes)) continue;

                myDataView.RowFilter = application.SysLibs.myExchangeDetailTbl.marketCodeColumn.ColumnName + "='" + marketRow.code + "'";
                if (myDataView.Count == 0) continue;

                
                bool retVal = true;
                exchangeDetailRow = (databases.baseDS.exchangeDetailRow)myDataView[0].Row;
                while (true)
                {
                    try
                    {
                        switch ((AppTypes.DataSourceCodes)exchangeDetailRow.sourceCode)
                        {
                            case AppTypes.DataSourceCodes.HOSE1:
                                retVal = hoseImport.ImportFromWeb(updateTime, exchangeDetailRow);
                                break;
                            case AppTypes.DataSourceCodes.HASTC1:
                                retVal = htastcImport.ImportFromWeb(updateTime, exchangeDetailRow);
                                break;
                            case AppTypes.DataSourceCodes.GOLD1:
                                retVal = forexImport.ImportFromWeb(updateTime, exchangeDetailRow);
                                break;

                            case AppTypes.DataSourceCodes.VNVN30_IDX1:
                                retVal = vnIdxImport.ImportFromWeb(updateTime, exchangeDetailRow);
                                break;
                            case AppTypes.DataSourceCodes.HN_IDX1:
                                retVal = hnIdxImport.ImportFromWeb(updateTime, exchangeDetailRow);
                                break;

                            default: return; //To avoid loop
                        }
                    }
                    catch (Exception er)
                    {
                        retVal = false;
                        commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV004", er);
                    }

                    int nextRunId = 0;
                    if (retVal)
                    {
                        commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational, "", " - Updated from " + exchangeDetailRow.address + " successful");
                        nextRunId = exchangeDetailRow.goFalse;
                    }
                    else
                    {
                        commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Informational, "", " - Updated from " + exchangeDetailRow.address + " failed");
                        nextRunId = exchangeDetailRow.goTrue;
                    }
                    //Find next line to run
                    foundRows = myDataView.FindRows(new object[]{nextRunId});
                    if (foundRows.Length <= 0) break;
                    exchangeDetailRow = (databases.baseDS.exchangeDetailRow)foundRows[0].Row;
                }
            }
            return;
        }
    }
}
