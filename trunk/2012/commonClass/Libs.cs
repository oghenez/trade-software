﻿using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using commonTypes;

namespace commonClass
{
    public static class DataLibs
    {
        public static double[] GetDataList(databases.baseDS.priceDataDataTable dataTbl, int startIdx, AppTypes.PriceDataType type)
        {
            return GetDataList(dataTbl, startIdx, dataTbl.Count - 1, type);
        }
        public static double[] GetDataList(databases.baseDS.priceDataDataTable dataTbl, int startIdx,int endIdx,AppTypes.PriceDataType type)
        {
            double[] data = new double[endIdx - startIdx+1];
            switch (type)
            {
                case AppTypes.PriceDataType.High:
                    for (int i = startIdx, j = 0; i <= endIdx; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        data[j] = (double)dataTbl[i].highPrice;
                    }
                    break;
                case AppTypes.PriceDataType.Low:
                    for (int i = startIdx, j = 0; i <=endIdx; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        data[j] = (double)dataTbl[i].lowPrice;
                    }
                    break;
                case AppTypes.PriceDataType.Open:
                    for (int i = startIdx, j = 0; i <= endIdx; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        data[j] = (double)dataTbl[i].openPrice;
                    }
                    break;
                case AppTypes.PriceDataType.Close:
                    for (int i = startIdx, j = 0; i <= endIdx; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        data[j] = (double)dataTbl[i].closePrice;
                    }
                    break;
                case AppTypes.PriceDataType.Volume:
                    for (int i = startIdx, j = 0; i <= endIdx; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        data[j] = (double)dataTbl[i].volume;
                    }
                    break;

                case AppTypes.PriceDataType.DateTime:
                    for (int i = startIdx, j = 0; i <= endIdx; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        data[j] = dataTbl[i].onDate.ToOADate();
                    }
                    break;
                default:
                    common.system.ThrowException("Invalid dataField in MakeDataList()"); break;
            }
            return data;
        }
        public static DataSeries GetData(databases.baseDS.priceDataDataTable dataTbl, int startIdx, AppTypes.PriceDataType type)
        {
            DataSeries ds = new DataSeries();
            ds.Values = GetDataList(dataTbl, startIdx, type);
            return ds;
        }
        public static DataBars GetData(databases.baseDS.priceDataDataTable dataTbl, int startIdx)
        {
            DataBars bars = new DataBars();
            for (int idx = startIdx; idx < dataTbl.Count; idx++)
            {
                bars.Add((double)dataTbl[idx].openPrice, (double)dataTbl[idx].highPrice,
                         (double)dataTbl[idx].lowPrice, (double)dataTbl[idx].closePrice,
                         (double)dataTbl[idx].volume, dataTbl[idx].onDate.ToOADate());
            }
            return bars;
        }
    }
    public static class SysLibs
    {
        //The folder from where the application run
        private static string _executeDirectory = null;
        public static string myExecuteDirectory
        {
            get
            {
                //For testing 
                if (common.Settings.sysDebugMode)
                    return "D:\\work\\stockProject\\code\\wsServices\\obj\\Debug"; 

                if (_executeDirectory == null)
                {
                    string tmp = common.system.GetWebRootPath();
                    //Run on web server
                    if (tmp != null)
                        _executeDirectory = common.fileFuncs.ConcatFileName(tmp, "bin");
                    else _executeDirectory = common.system.GetExecutePath();
                }
                return _executeDirectory;
            }
        }
        public static bool IsUseVietnamese()
        {
            return (Settings.sysLanguage == AppTypes.LanguageCodes.VI);
        }        
        public static void SetLanguage()
        {
            AppTypes.ReLoadTimeScales();
        }

        public static DateTime GetWorkDayDate(DateTime frDate, int days) { return frDate.AddDays(days); }

        public static bool isSupperAdminLogin(string loginName)
        {
            return loginName.Trim().ToLower() == Settings.sysSuperAdminName;
        }
        public static bool isSupperAdminLogin()
        {
            return isSupperAdminLogin(sysLoginCode);
        }
        public static bool isAdminLogin(string loginType)
        {
            return (loginType.Trim() == Consts.constWorkerTypeAdmin);
        }
        public static bool isAdminLogin()
        {
            return isAdminLogin(sysLoginType);
        }
        public static void ClearLogin()
        {
            sysLoginCode = "";
            sysLoginAccount = "";
            sysLoginType = "";
        }

        public static void WriteSysLog(AppTypes.SyslogTypes type, string investorCode, string text)
        {
            common.fileFuncs.WriteLog(DateTime.Now.ToString() + common.Consts.constTab + type.ToString() + common.Consts.constTab +
                                      (investorCode==null || investorCode.Trim() == "" ? common.Consts.constNotAvailable : investorCode.Trim()) + 
                                      common.Consts.constTab + text, 
                                      common.fileFuncs.ConcatFileName(myExecuteDirectory, Consts.constFile_SysLog));
        }
        public static void WriteSysLog(Exception er, string investorCode)
        {
            WriteSysLog(AppTypes.SyslogTypes.Exception, investorCode,common.system.MakeLogString(er, common.Consts.constTab));
        }

        #region system environment
        public static bool sysUseTransactionInUpdate = false;

        public static short sysConnectionTimeout = 30; //In seconds
        
        //Upload
        //??public static DateTime sysDataStartDate = common.Consts.constNullDate;
        public static int sysLoginUserId = common.Consts.constNullInt;
        

        //User
        public static string sysLoginCode = "";
        public static string sysLoginAccount = "";
        public static string sysLoginType = "";
        public static string sysCompanyName = "";
        public static string sysCompanyAddr1 = "";
        public static string sysCompanyAddr2 = "";
        public static string sysCompanyAddr3 = "";
        public static string sysCompanyPhone = "";
        public static string sysCompanyFax = "";
        public static string sysCompanyEmail = "";
        public static string sysCompanyURL = "";
        #endregion system environment
    }
    public static class Configuration
    {
        public static XmlDocument GetLocalXmlDocSTRATEGY()
        {
            string tmp = common.fileFuncs.ConcatFileName(new string[] { commonClass.SysLibs.myExecuteDirectory, common.language.myCulture.Name, Consts.constConfFile_Meta_Strategy });
            return common.xmlLibs.GetXmlDocument(tmp);
        }
        public static XmlDocument GetLocalXmlDocINDICATOR()
        {
            string tmp = common.fileFuncs.ConcatFileName(new string[] { commonClass.SysLibs.myExecuteDirectory, common.language.myCulture.Name, Consts.constConfFile_Meta_Indicator });
            return common.xmlLibs.GetXmlDocument(tmp);
        }

        public static bool GetLocalConfig(string type, StringCollection aFields)
        {
            return common.configuration.GetConfiguration(Settings.sysUserConfigFile, SysLibs.sysLoginCode,type, aFields, false);
        }
        public static bool SaveLocalConfig(string type, StringCollection aFields, StringCollection aValues)
        {
            if (SysLibs.sysLoginCode.Trim() == "") return false;
            return common.configuration.SaveConfiguration(Settings.sysUserConfigFile, SysLibs.sysLoginCode, type, aFields, aValues, false);
        }

        //private const string constRootXMLElementStr = "Configuration";
        //public const string constXMLElement_Root = "Application";
        //public const string constXMLElement_Sub_System = "System";
        //public const string constXMLElement_Sub_Database = "Database";
        //public static bool withEncryption
        //{
        //    get { return common.configuration.withEncryption; }
        //    set { common.configuration.withEncryption = value; }
        //}

        //public static string BuidConnectionString(string serverAddr, string dbName, string account, string password)
        //{
        //    string configStr = "";
        //    configStr = "Data Source=" + serverAddr.Trim() +
        //                ";Initial Catalog=" + dbName.Trim() +
        //                ";Persist Security Info=True;User ID=" + account.Trim();
        //    if (password.Trim() != "") configStr += ";password=" + password;
        //    return configStr;
        //}
    }
}