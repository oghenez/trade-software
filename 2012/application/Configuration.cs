using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Data;
using System.Windows.Forms; 
using System.Data.SqlClient;
using System.Drawing;
using System.Transactions;
using commonTypes;
using commonClass;

namespace application
{
    public class Configuration
    {
        public const string constXMLElement_Root = "Application";
        public const string constXMLElement_Sub_System = "System";
        public const string constXMLElement_Sub_Database = "Database";
        public static bool withEncryption
        {
            get { return common.configuration.withEncryption; }
            set { common.configuration.withEncryption = value; }
        }

        public static bool GetConfig(ref StringCollection aFields)
        {
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                aFields[idx] = databases.DbAccess.GetConfig(aFields[idx].Trim());
                if (withEncryption && aFields[idx].Trim() != "")
                {
                    aFields[idx] = common.cryption.Decrypt(aFields[idx].Trim());
                }
            }
            return true;
        }
        public static bool SaveConfig(StringCollection aFields, StringCollection aValues)
        {
            string value;
            for (int idx = 0; idx < aFields.Count; idx++)
            {
                value = aValues[idx].Trim();
                if (withEncryption && (value.Trim() != ""))
                {
                    value = common.cryption.Encrypt(value);
                }
                databases.DbAccess.SaveConfig(aFields[idx].Trim(), value);
            }
            return true;
        }

        //From database
        public static bool Load_Global_Settings(ref GlobalSettings settings)
        {
            int num;
            StringCollection aFields = new StringCollection();
            // System
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.WriteLogAccess }));
            aFields.Add(common.system.GetName(new { settings.PasswordMinLen }));
            aFields.Add(common.system.GetName(new { settings.UseStrongPassword }));
            if (!GetConfig(ref aFields)) return false;

            if (int.TryParse(aFields[0], out num)) settings.WriteLogAccess = (AppTypes.SyslogMedia)num;
            if (int.TryParse(aFields[1], out num)) settings.PasswordMinLen = (byte)num;
            if (aFields[2].Trim() != "") settings.UseStrongPassword = (aFields[2] == Boolean.TrueString);

            // Data count
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DayScanForLastPrice }));
            aFields.Add(common.system.GetName(new { settings.AlertDataCount }));
            aFields.Add(common.system.GetName(new { settings.ChartMaxLoadCount_FIRST }));
            aFields.Add(common.system.GetName(new { settings.ChartMaxLoadCount_MORE }));
            if (!GetConfig(ref aFields)) return false;
            
            if (aFields[0].Trim() != "" & int.TryParse(aFields[0], out num)) settings.DayScanForLastPrice = (short)num;
            if (aFields[1].Trim() != "" & int.TryParse(aFields[1], out num)) settings.AlertDataCount = (short)num;
            if (aFields[2].Trim() != "" & int.TryParse(aFields[2], out num)) settings.ChartMaxLoadCount_FIRST = (short)num;
            if (aFields[3].Trim() != "" & int.TryParse(aFields[3], out num)) settings.ChartMaxLoadCount_MORE = (short)num;


            //Auto key
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DataKeyPrefix }));
            aFields.Add(common.system.GetName(new { settings.DataKeySize }));
            aFields.Add(common.system.GetName(new { settings.AutoEditKeySize }));
            aFields.Add(common.system.GetName(new { settings.TimeOut_AutoKey }));
            if(!GetConfig(ref aFields)) return false;
            if (aFields[0].Trim() != "") settings.DataKeyPrefix = aFields[0].Trim();
            if (int.TryParse(aFields[1], out num)) settings.DataKeySize = num;
            if (int.TryParse(aFields[2], out num)) settings.AutoEditKeySize = num;
            if (int.TryParse(aFields[3], out num)) settings.TimeOut_AutoKey = num;

            //Email
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.smtpAddress }));
            aFields.Add(common.system.GetName(new { settings.smtpPort }));
            aFields.Add(common.system.GetName(new { settings.smtpAuthAccount }));
            aFields.Add(common.system.GetName(new { settings.smtpAuthPassword }));
            aFields.Add(common.system.GetName(new { settings.smtpSSL}));
            if (!GetConfig(ref aFields)) return false;

            if (aFields[0].Trim() != "") settings.smtpAddress = aFields[0];
            if (aFields[1].Trim() != "" & int.TryParse(aFields[1], out num)) settings.smtpPort = num;
            settings.smtpAuthAccount = aFields[2].Trim();
            settings.smtpAuthPassword = aFields[3].Trim();
            settings.smtpSSL = (aFields[4].Trim() == Boolean.TrueString);

            //Default
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DefautLanguage }));
            aFields.Add(common.system.GetName(new { settings.DefaultTimeRange }));
            aFields.Add(common.system.GetName(new { settings.DefaultTimeScaleCode }));
            aFields.Add(common.system.GetName(new { settings.ScreeningTimeScaleCode }));

            aFields.Add(common.system.GetName(new { settings.AlertDataCount}));
            aFields.Add(common.system.GetName(new { settings.ScreeningDataCount}));

            if (!GetConfig(ref aFields)) return false;

            if (aFields[0].Trim() != "") settings.DefautLanguage = AppTypes.Code2Language(aFields[0].Trim());
            if (aFields[1].Trim() != "") settings.DefaultTimeRange = AppTypes.TimeRangeFromCode(aFields[1]);
            if (aFields[2].Trim() != "") settings.DefaultTimeScaleCode = aFields[2];
            if (aFields[3].Trim() != "") settings.ScreeningTimeScaleCode = aFields[3];

            if (aFields[4].Trim() != "" & int.TryParse(aFields[4], out num)) settings.AlertDataCount = (short)num;
            if (aFields[5].Trim() != "" & int.TryParse(aFields[5], out num)) settings.ScreeningDataCount = (short)num;

            //Timming 
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.TimerIntervalInSecs }));
            aFields.Add(common.system.GetName(new { settings.RefreshDataInSecs }));
            aFields.Add(common.system.GetName(new { settings.CheckAlertInSeconds }));
            aFields.Add(common.system.GetName(new { settings.AutoCheckInSeconds }));
            if (!GetConfig(ref aFields)) return false;

            if (aFields[0].Trim() != "" & int.TryParse(aFields[0], out num)) settings.TimerIntervalInSecs = (short)num;
            if (aFields[1].Trim() != "" & int.TryParse(aFields[1], out num)) settings.RefreshDataInSecs = (short)num;
            if (aFields[2].Trim() != "" & int.TryParse(aFields[2], out num)) settings.CheckAlertInSeconds = (short)num;
            if (aFields[3].Trim() != "" & int.TryParse(aFields[3], out num)) settings.AutoCheckInSeconds = (short)num;
            return true;
        }
        public static bool Save_Global_Settings(GlobalSettings settings)
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            //System
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.WriteLogAccess }));
            aFields.Add(common.system.GetName(new { settings.PasswordMinLen }));
            aFields.Add(common.system.GetName(new { settings.UseStrongPassword }));
            
            aValues.Clear();
            aValues.Add(((byte)settings.WriteLogAccess).ToString());
            aValues.Add(settings.PasswordMinLen.ToString());
            aValues.Add(settings.UseStrongPassword.ToString());
            if (!SaveConfig(aFields, aValues)) return false;

            //Data count
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DayScanForLastPrice }));
            aFields.Add(common.system.GetName(new { settings.AlertDataCount }));
            aFields.Add(common.system.GetName(new { settings.ChartMaxLoadCount_FIRST }));
            aFields.Add(common.system.GetName(new { settings.ChartMaxLoadCount_MORE }));

            aValues.Clear();
            aValues.Add(settings.DayScanForLastPrice.ToString());
            aValues.Add(settings.AlertDataCount.ToString());
            aValues.Add(settings.ChartMaxLoadCount_FIRST.ToString());
            aValues.Add(settings.ChartMaxLoadCount_MORE.ToString());
            if (!SaveConfig(aFields, aValues)) return false;

            //Autokey
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DataKeyPrefix }));
            aFields.Add(common.system.GetName(new { settings.DataKeySize }));
            aFields.Add(common.system.GetName(new { settings.AutoEditKeySize }));
            aFields.Add(common.system.GetName(new { settings.TimeOut_AutoKey }));
            
            aValues.Clear();
            aValues.Add(settings.DataKeyPrefix);
            aValues.Add(settings.DataKeySize.ToString());
            aValues.Add(settings.AutoEditKeySize.ToString());
            aValues.Add(settings.TimeOut_AutoKey.ToString());
            if (!SaveConfig(aFields, aValues)) return false;

            //Mail
            aFields.Clear(); 
            aFields.Add(common.system.GetName(new { settings.smtpAddress }));
            aFields.Add(common.system.GetName(new { settings.smtpPort }));
            aFields.Add(common.system.GetName(new { settings.smtpAuthAccount }));
            aFields.Add(common.system.GetName(new { settings.smtpAuthPassword }));
            aFields.Add(common.system.GetName(new { settings.smtpSSL }));

            aValues.Clear();
            aValues.Add(settings.smtpAddress);
            aValues.Add(settings.smtpPort.ToString());
            aValues.Add(settings.smtpAuthAccount);
            aValues.Add(settings.smtpAuthPassword);
            aValues.Add(settings.smtpSSL ? Boolean.TrueString : Boolean.FalseString);
            if (!SaveConfig(aFields, aValues)) return false;

            //Default
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.DefautLanguage }));
            aFields.Add(common.system.GetName(new { settings.AlertDataCount }));
            aFields.Add(common.system.GetName(new { settings.ScreeningDataCount }));

            aFields.Add(common.system.GetName(new { settings.ScreeningTimeScaleCode }));
            aFields.Add(common.system.GetName(new { settings.DefaultTimeRange }));
            aFields.Add(common.system.GetName(new { settings.DefaultTimeScaleCode }));

            aValues.Clear();
            aValues.Add(settings.DefautLanguage.ToString());
            aValues.Add(settings.AlertDataCount.ToString());
            aValues.Add(settings.ScreeningDataCount.ToString());
            aValues.Add(settings.ScreeningTimeScaleCode);
            aValues.Add(settings.DefaultTimeRange.ToString());
            aValues.Add(settings.DefaultTimeScaleCode);
            if (!SaveConfig(aFields, aValues)) return false;

            //Timming
            aFields.Clear();
            aFields.Add(common.system.GetName(new { settings.TimerIntervalInSecs }));
            aFields.Add(common.system.GetName(new { settings.RefreshDataInSecs }));
            aFields.Add(common.system.GetName(new { settings.CheckAlertInSeconds }));
            aFields.Add(common.system.GetName(new { settings.AutoCheckInSeconds }));

            aValues.Clear();
            aValues.Add(settings.TimerIntervalInSecs.ToString());
            aValues.Add(settings.RefreshDataInSecs.ToString());
            aValues.Add(settings.CheckAlertInSeconds.ToString());
            aValues.Add(settings.AutoCheckInSeconds.ToString());
            if (!SaveConfig(aFields, aValues)) return false;
            return true;
        }


        public static bool GetLocalUserConfig(string type, StringCollection aFields)
        {
            if (commonClass.SysLibs.sysLoginCode == "") return false;
            return commonClass.Configuration.GetLocalConfig(new string[] { commonClass.SysLibs.sysLoginCode, type }, aFields);
        }
        public static bool SaveLocalUserConfig(string type, StringCollection aFields, StringCollection aValues)
        {
            if (commonClass.SysLibs.sysLoginCode == "") return false;
            return commonClass.Configuration.SaveLocalConfig(new string[] { commonClass.SysLibs.sysLoginCode, type }, aFields, aValues);
        }

        //All from local config file
        public static bool Load_Local_UserSettings()
        {
            bool retVal = true;
            if (!Load_Local_UserSettings_STOCK()) retVal = false;
            if (!Load_Local_UserSettings_CHART()) retVal = false;
            if (!Load_Local_UserSettings_SYSTEM1()) retVal = false;
            if (!Load_Local_UserSettings_SYSTEM2()) retVal = false;
            return retVal;
        }
        public static bool Save_Local_UserSettings()
        {
            bool retVal = true;
            if (!Save_Local_UserSettings_STOCK()) retVal = false;
            if (!Save_Local_UserSettings_CHART()) retVal = false;
            if (!Save_Local_UserSettings_SYSTEM1()) retVal = false;
            if (!Save_Local_UserSettings_SYSTEM2()) retVal = false;
            return retVal;
        }

        //Local setting that apply to all users 
        public static bool Load_Local_Settings()
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysTimeServer }));
            common.configuration.GetConfiguration(new string[] { "System" }, aFields, Settings.sysFileUserConfig, false);
            Settings.sysTimeServer = aFields[0].Trim();

            Font font = commonClass.Configuration.GetLocalConfigFont(new string[] { "MainFont" });
            if (font != null) Settings.sysFontMain = font;
            font = commonClass.Configuration.GetLocalConfigFont(new string[] { "MenuFont" });
            if (font != null)  Settings.sysFontMenu= font;
            return true;
        }
        
        public static bool Save_Local_Settings()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysTimeServer }));
            aValues.Clear();
            aValues.Add(Settings.sysTimeServer);
            if (!common.configuration.SaveConfiguration(new string[] { "System" }, aFields, aValues, Settings.sysFileUserConfig, false)) return false;

            if (!commonClass.Configuration.SaveLocalConfigFont(new string[] {"MainFont" }, Settings.sysFontMain)) return false;
            if (!commonClass.Configuration.SaveLocalConfigFont(new string[] {"MenuFont" }, Settings.sysFontMenu)) return false;
            return true;
        }

        public static bool Load_Local_UserSettings_STOCK()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysStockMaxBuyQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockReduceQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockAccumulateQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockTotalCapAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysStockMaxBuyAmtPerc }));
            if (!GetLocalUserConfig("STOCK", aFields)) return false;

            decimal d = 0; 
            if (common.system.String2Number_Common(aFields[0], out d)) Settings.sysStockMaxBuyQtyPerc = d;
            if (common.system.String2Number_Common(aFields[1], out d)) Settings.sysStockReduceQtyPerc = d;
            if (common.system.String2Number_Common(aFields[2], out d)) Settings.sysStockAccumulateQtyPerc = d;
            if (common.system.String2Number_Common(aFields[3], out d)) Settings.sysStockTotalCapAmt = d;
            if (common.system.String2Number_Common(aFields[4], out d)) Settings.sysStockMaxBuyAmtPerc = d;
            return true;
        }
        public static bool Save_Local_UserSettings_STOCK()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysStockMaxBuyQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockReduceQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockAccumulateQtyPerc }));
            aFields.Add(common.system.GetName(new { Settings.sysStockTotalCapAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysStockMaxBuyAmtPerc }));
            aValues.Clear();
            aValues.Add(common.system.Number2String_Common(Settings.sysStockMaxBuyQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockReduceQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockAccumulateQtyPerc));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockTotalCapAmt));
            aValues.Add(common.system.Number2String_Common(Settings.sysStockMaxBuyAmtPerc));
            return SaveLocalUserConfig("STOCK", aFields, aValues);
        }

        public static bool Load_Local_UserSettings_CHART()
        {
            decimal d = 0;
            //Color page
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartBgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartFgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartGridColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartVolumesColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartLineCandleColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartBearCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBearBorderColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartBullCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBullBorderColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartBarDnColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarUpColor }));
            if (!GetLocalUserConfig("ChartColors", aFields)) return false;

            if (aFields[0].Trim() != "") Settings.sysChartBgColor = ColorTranslator.FromHtml(aFields[0]);
            if (aFields[1].Trim() != "") Settings.sysChartFgColor = ColorTranslator.FromHtml(aFields[1]);
            if (aFields[2].Trim() != "") Settings.sysChartGridColor = ColorTranslator.FromHtml(aFields[2]);
            if (aFields[3].Trim() != "") Settings.sysChartVolumesColor = ColorTranslator.FromHtml(aFields[3]);

            if (aFields[4].Trim() != "") Settings.sysChartLineCandleColor = ColorTranslator.FromHtml(aFields[4]);

            if (aFields[5].Trim() != "") Settings.sysChartBearCandleColor = ColorTranslator.FromHtml(aFields[5]);
            if (aFields[6].Trim() != "") Settings.sysChartBearBorderColor = ColorTranslator.FromHtml(aFields[6]);

            if (aFields[7].Trim() != "") Settings.sysChartBullCandleColor = ColorTranslator.FromHtml(aFields[7]);
            if (aFields[8].Trim() != "") Settings.sysChartBullBorderColor = ColorTranslator.FromHtml(aFields[8]);

            if (aFields[9].Trim() != "") Settings.sysChartBarDnColor = ColorTranslator.FromHtml(aFields[9]);
            if (aFields[10].Trim() != "") Settings.sysChartBarUpColor = ColorTranslator.FromHtml(aFields[10]);

            //Chart page
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartShowDescription }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowVolume }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowGrid }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowLegend }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_Percent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_MinCount }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MovePercent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MoveMinCount}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MouseRate }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_DEFA }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_MIN }));
            
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtRIGHT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginRIGHT}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginBOT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtRIGHT}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtTOP}));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtBOT}));

            if (!GetLocalUserConfig("ChartSettings", aFields)) return false;

            Settings.sysChartShowDescription = (aFields[0].Trim() == Boolean.TrueString);
            Settings.sysChartShowVolume = (aFields[1].Trim() == Boolean.TrueString);
            Settings.sysChartShowGrid = (aFields[2].Trim() == Boolean.TrueString);
            Settings.sysChartShowLegend = (aFields[3].Trim() == Boolean.TrueString);

            if (common.system.String2Number_Common(aFields[4], out d)) Charts.Settings.sysZoom_Percent = (int)d;
            if (common.system.String2Number_Common(aFields[5], out d)) Charts.Settings.sysZoom_MinCount = (int)d;

            if (common.system.String2Number_Common(aFields[6], out d)) Charts.Settings.sysPAN_MovePercent = (int)d;
            if (common.system.String2Number_Common(aFields[7], out d)) Charts.Settings.sysPAN_MoveMinCount = (int)d;
            if (common.system.String2Number_Common(aFields[8], out d)) Charts.Settings.sysPAN_MouseRate = (int)d;

            if (common.system.String2Number_Common(aFields[9], out d)) Charts.Settings.sysNumberOfPoint_DEFA = (int)d;
            if (common.system.String2Number_Common(aFields[10], out d)) Charts.Settings.sysNumberOfPoint_MIN = (int)d;

            if (common.system.String2Number_Common(aFields[11], out d)) Charts.Settings.sysViewMinBarAtLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[12], out d)) Charts.Settings.sysViewMinBarAtRIGHT = (int)d;

            if (common.system.String2Number_Common(aFields[13], out d)) Charts.Settings.sysChartMarginLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[14], out d)) Charts.Settings.sysChartMarginRIGHT = (int)d;
            if (common.system.String2Number_Common(aFields[15], out d)) Charts.Settings.sysChartMarginTOP = (int)d;
            if (common.system.String2Number_Common(aFields[16], out d)) Charts.Settings.sysChartMarginBOT = (int)d;

            if (common.system.String2Number_Common(aFields[17], out d)) Charts.Settings.sysViewSpaceAtLEFT = (int)d;
            if (common.system.String2Number_Common(aFields[18], out d)) Charts.Settings.sysViewSpaceAtRIGHT = (int)d;
            if (common.system.String2Number_Common(aFields[19], out d)) Charts.Settings.sysViewSpaceAtTOP = d;
            if (common.system.String2Number_Common(aFields[20], out d)) Charts.Settings.sysViewSpaceAtBOT = d;
            return true;
        }
        public static bool Save_Local_UserSettings_CHART()
        {
            //Systen tab 
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartBgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartFgColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartGridColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartVolumesColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartLineCandleColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartBearCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBearBorderColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartBullCandleColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBullBorderColor }));

            aFields.Add(common.system.GetName(new { Settings.sysChartBarDnColor }));
            aFields.Add(common.system.GetName(new { Settings.sysChartBarUpColor }));

            aValues.Clear();
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBgColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartFgColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartGridColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartVolumesColor));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartLineCandleColor));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBearCandleColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBearBorderColor));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBullCandleColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBullBorderColor));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBarDnColor));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysChartBarUpColor));
            if (!SaveLocalUserConfig("ChartColors", aFields, aValues)) return false;

            //Chart page
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysChartShowDescription }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowVolume }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowGrid }));
            aFields.Add(common.system.GetName(new { Settings.sysChartShowLegend }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_Percent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysZoom_MinCount}));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MovePercent }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MoveMinCount }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysPAN_MouseRate }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_DEFA }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysNumberOfPoint_MIN }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewMinBarAtRIGHT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginRIGHT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysChartMarginBOT }));

            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtLEFT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtRIGHT }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtTOP }));
            aFields.Add(common.system.GetName(new { Charts.Settings.sysViewSpaceAtBOT }));

            aValues.Clear();
            aValues.Add(Settings.sysChartShowDescription.ToString());
            aValues.Add(Settings.sysChartShowVolume.ToString());
            aValues.Add(Settings.sysChartShowGrid.ToString());
            aValues.Add(Settings.sysChartShowLegend.ToString());

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysZoom_Percent));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysZoom_MinCount));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MovePercent));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MoveMinCount));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysPAN_MouseRate));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysNumberOfPoint_DEFA));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysNumberOfPoint_MIN));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewMinBarAtLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewMinBarAtRIGHT));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginRIGHT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginTOP));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysChartMarginBOT));

            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewSpaceAtLEFT));
            aValues.Add(common.system.Number2String_Common(Charts.Settings.sysViewSpaceAtRIGHT));
            aValues.Add(common.system.Number2String_Common((decimal)Charts.Settings.sysViewSpaceAtTOP));
            aValues.Add(common.system.Number2String_Common((decimal)Charts.Settings.sysViewSpaceAtBOT));

            if (!SaveLocalUserConfig("ChartSettings", aFields, aValues)) return false;
            return true;
        }

        public static bool Load_Local_UserSettings_SYSTEM1()
        {
            StringCollection aFields = new StringCollection();

            //Format
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysMaskGeneralValue }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskLocalAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskForeignAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskPercent }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskQty }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskPrice }));
            if (!GetLocalUserConfig("Format", aFields)) return false; 

            if (aFields[0].Trim() != "") Settings.sysMaskGeneralValue = aFields[2];
            if (aFields[1].Trim() != "") Settings.sysMaskLocalAmt = aFields[2];
            if (aFields[2].Trim() != "") Settings.sysMaskForeignAmt = aFields[2];
            if (aFields[3].Trim() != "") Settings.sysMaskPercent = aFields[3];
            if (aFields[4].Trim() != "") Settings.sysMaskQty = aFields[4];
            if (aFields[5].Trim() != "") Settings.sysMaskPrice = aFields[5];

            //Color
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_FG }));
            if (!GetLocalUserConfig("Color", aFields)) return false; ;

            if (aFields[0].Trim() != "") Settings.sysPriceColor_Increase_BG = ColorTranslator.FromHtml(aFields[0]);
            if (aFields[1].Trim() != "") Settings.sysPriceColor_Increase_FG = ColorTranslator.FromHtml(aFields[1]);

            if (aFields[2].Trim() != "") Settings.sysPriceColor_Decrease_BG = ColorTranslator.FromHtml(aFields[2]);
            if (aFields[3].Trim() != "") Settings.sysPriceColor_Decrease_FG = ColorTranslator.FromHtml(aFields[3]);

            if (aFields[4].Trim() != "") Settings.sysPriceColor_NotChange_BG = ColorTranslator.FromHtml(aFields[4]);
            if (aFields[5].Trim() != "") Settings.sysPriceColor_NotChange_FG = ColorTranslator.FromHtml(aFields[5]);

            //System
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysLanguage }));
            aFields.Add(common.system.GetName(new { Settings.sysAutoRefreshData}));
            if (!GetLocalUserConfig("System", aFields)) return false; ;
            Settings.sysLanguage = AppTypes.Code2Language(aFields[0].Trim());
            Settings.sysAutoRefreshData = aFields[1].Trim() != Boolean.FalseString;
            return true;
        }
        public static bool Save_Local_UserSettings_SYSTEM1()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            //Format
            aFields.Clear();

            aFields.Add(common.system.GetName(new { Settings.sysMaskGeneralValue }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskLocalAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskForeignAmt }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskPercent }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskQty }));
            aFields.Add(common.system.GetName(new { Settings.sysMaskPrice }));

            aValues.Clear();
            aValues.Add(Settings.sysMaskGeneralValue);
            aValues.Add(Settings.sysMaskLocalAmt);
            aValues.Add(Settings.sysMaskForeignAmt);
            aValues.Add(Settings.sysMaskPercent);
            aValues.Add(Settings.sysMaskQty);
            aValues.Add(Settings.sysMaskPrice);
            if (!SaveLocalUserConfig("Format", aFields, aValues)) return false; ;

            //Color
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Increase_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_Decrease_FG }));

            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_BG }));
            aFields.Add(common.system.GetName(new { Settings.sysPriceColor_NotChange_FG }));

            aValues.Clear();
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Increase_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Increase_FG));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Decrease_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_Decrease_FG));

            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_NotChange_BG));
            aValues.Add(ColorTranslator.ToHtml(Settings.sysPriceColor_NotChange_FG));
            if (!SaveLocalUserConfig("Color", aFields, aValues)) return false; ;

            //System
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysLanguage }));
            aFields.Add(common.system.GetName(new { Settings.sysAutoRefreshData }));

            aValues.Clear();
            aValues.Add(Settings.sysLanguage.ToString());
            aValues.Add(Settings.sysAutoRefreshData.ToString());
            if (!SaveLocalUserConfig("System", aFields, aValues)) return false;
            return true;
        }

        public static bool Load_Local_UserSettings_SYSTEM2()
        {
            StringCollection aFields = new StringCollection();
            //Company
            aFields.Clear();
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyName }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr1 }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr2 }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr3 }));

            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyPhone }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyFax }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyEmail }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyURL }));
            if (GetLocalUserConfig("Investor", aFields))
            {
                commonClass.SysLibs.sysCompanyName = aFields[0].ToString();
                commonClass.SysLibs.sysCompanyAddr1 = aFields[1].ToString();
                commonClass.SysLibs.sysCompanyAddr2 = aFields[2].ToString();
                commonClass.SysLibs.sysCompanyAddr3 = aFields[3].ToString();

                commonClass.SysLibs.sysCompanyPhone = aFields[4].ToString();
                commonClass.SysLibs.sysCompanyFax = aFields[5].ToString();
                commonClass.SysLibs.sysCompanyEmail = aFields[6].ToString();
                commonClass.SysLibs.sysCompanyURL = aFields[7].ToString();
            }
            //Image and Icon
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathBackGround })); 
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathIcon }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathCompanyLogo1 }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathCompanyLogo2 }));
            if (GetLocalUserConfig("Others", aFields))
            {
                Settings.sysImgFilePathBackGround = common.fileFuncs.MakeRelativePath(aFields[0].ToString());
                Settings.sysImgFilePathIcon = common.fileFuncs.MakeRelativePath(aFields[1].ToString());
                Settings.sysImgFilePathCompanyLogo1 = common.fileFuncs.MakeRelativePath(aFields[2].ToString());
                Settings.sysImgFilePathCompanyLogo2 = common.fileFuncs.MakeRelativePath(aFields[3].ToString());
            }
            return true; 
        }
        public static bool Save_Local_UserSettings_SYSTEM2()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            //Investor
            aFields.Clear();
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyName }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr1 }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr2 }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyAddr3 }));

            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyPhone }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyFax }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyEmail }));
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysCompanyURL }));

            aValues.Clear();
            aValues.Add(commonClass.SysLibs.sysCompanyName);
            aValues.Add(commonClass.SysLibs.sysCompanyAddr1);
            aValues.Add(commonClass.SysLibs.sysCompanyAddr2);
            aValues.Add(commonClass.SysLibs.sysCompanyAddr3);

            aValues.Add(commonClass.SysLibs.sysCompanyPhone);
            aValues.Add(commonClass.SysLibs.sysCompanyFax);
            aValues.Add(commonClass.SysLibs.sysCompanyEmail);
            aValues.Add(commonClass.SysLibs.sysCompanyURL);
            SaveLocalUserConfig("Investor", aFields, aValues);
            
            //Image and icon
            aFields.Clear();
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathBackGround }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathIcon }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathCompanyLogo1 }));
            aFields.Add(common.system.GetName(new { Settings.sysImgFilePathCompanyLogo2 }));
            aValues.Clear();
            aValues.Add(common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathBackGround));
            aValues.Add(common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathIcon));
            aValues.Add(common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathCompanyLogo1));
            aValues.Add(common.fileFuncs.MakeRelativePath(Settings.sysImgFilePathCompanyLogo2));
            SaveLocalUserConfig("Others", aFields, aValues);
            return true;
        }

        public static bool GetDefaultFormState(string formName)
        {
            return GetDefaultFormState(formName, false);
        }

        public static bool GetDefaultFormState(string formName,bool nullAsTrue)
        {
            StringCollection aFields = new StringCollection();
            aFields.Clear();
            aFields.Add(formName);
            if (!GetLocalUserConfig("DefaultForms", aFields)) return nullAsTrue; 
            return (aFields[0]!=Boolean.FalseString);
        }
        public static bool SetDefaultFormState(string formName,bool isDefault)
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();
            aFields.Clear(); aValues.Clear();
            aFields.Add(formName);
            aValues.Add((isDefault?Boolean.TrueString:Boolean.FalseString) );
            if (!SaveLocalUserConfig("DefaultForms", aFields, aValues)) return false;
            return true;
        }

        public static bool Load_User_Envir()
        {
            StringCollection aFields = new StringCollection();
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysLoginAccount }));
            if (!common.configuration.GetConfiguration(Settings.sysFileUserConfig, "Environment", "", aFields, false)) return false;
            commonClass.SysLibs.sysLoginAccount = aFields[0].ToString();
            return true; 
        }
        public static bool Save_User_Envir()
        {
            StringCollection aFields = new StringCollection();
            StringCollection aValues = new StringCollection();

            aFields.Clear(); aValues.Clear();
            aFields.Add(common.system.GetName(new { commonClass.SysLibs.sysLoginAccount }));
            aValues.Add(commonClass.SysLibs.sysLoginAccount);
            return common.configuration.SaveConfiguration(Settings.sysFileUserConfig, "Environment", "", aFields, aValues, false);
        }
    }
}
