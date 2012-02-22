using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;

namespace commonTypes
{
    [DataContract]
    public class GlobalSettings
    {
        [DataMember]
        public byte PasswordMinLen = 0; //Minimum pasword len

        [DataMember]
        public AppTypes.LanguageCodes DeafautLanguage = AppTypes.LanguageCodes.EN;

        [DataMember]
        public bool UseStrongPassword = false;

        // Auto-generated edit key has the form  <number><postfix>
        // myAutoEditKeySize specifies the lenght of <number> part 
        [DataMember]
        public int AutoEditKeySize = 4;

        // Auto-generated data has the form  <prefix><numeric string>
        // DataKeySize specifies the lenght of <number string> part 
        [DataMember]
        public int DataKeySize = 9;
        [DataMember]
        public string DataKeyPrefix = "A";

        //Maximum time (in seconds) that consider an auto key is valid.
        [DataMember]
        public int TimeOut_AutoKey = 120; //2*60= 2 Minutes

        [DataMember]
        public string smtpAddress = "";

        [DataMember]
        public int smtpPort = 25;

        [DataMember]
        public string smtpAuthAccount = "";

        [DataMember]
        public string smtpAuthPassword = "";

        [DataMember]
        public bool smtpSSL = false;

        [DataMember]
        public int AlertDataCount = 50;

        [DataMember]
        public int ScreeningDataCount = 50;

        [DataMember]
        public AppTypes.TimeRanges DefaultTimeRange = AppTypes.TimeRanges.Y5;

        [DataMember]
        public string ScreeningTimeScaleCode = "";
        [DataMember]
        public string DefaultTimeScaleCode = "";

        //Interval in seconds at which  system time events occur.
        [DataMember]
        public short TimerUnitInSecs = 5;   // 5 Possitive number to enable system timer

        //How long (seconds) to perform auto checking (connection,...) :  TimerUnitToAutoCheck * sysTimerUnitInSecs
        [DataMember]
        public short TimerUnitToAutoCheck = 10;   //50*5 seconds

        //The number of days to scan for getting the last price. The bigger the numer is, the more time needs for the system to get the last price
        //The system will look for the last price in date range [today-DayScanForLastPrice,today]
        [DataMember]
        public short DayScanForLastPrice = 90;

        // Loading long chart can be very slow, the setting limit the maximum number of points to be loaded
        [DataMember]
        public short ChartMaxLoadCount_FIRST = 6000; //For the first time
        [DataMember]
        public short ChartMaxLoadCount_MORE = 0;   //For each "get more" load
    }
    public static class Settings
    {
        private static GlobalSettings _sysGlobal = null;
        public static GlobalSettings sysGlobal
        {
            get
            {
                if (_sysGlobal == null) 
                    _sysGlobal = new GlobalSettings();
                return _sysGlobal;
            }
            set
            {
                _sysGlobal = value;
                common.sendMail.mySettings.smtpAddress = value.smtpAddress;
                common.sendMail.mySettings.smtpPort = value.smtpPort;
                common.sendMail.mySettings.authAccount = value.smtpAuthAccount.Trim();
                common.sendMail.mySettings.authPassword = value.smtpAuthPassword.Trim();
                common.sendMail.mySettings.smtpSSL = value.smtpSSL;
            }
        }

        //The max datetime diffences b/w server and client in seconds
        //public static int sysMaxTimeDifferenceInSecs = 600; //10 Mins

        //Whether to keep sell that was blocked by T+4 and issue it when the time come
        public static bool sysKeepInApplicableSell = true;

        // Some process such as backtesting need to slit a process into several batches 
        // The setting specifies the number of items put in each batch process.
        public static int sysNumberOfItemsInBatchProcess = 50;

        //How long (seconds) to make update : seconds = sysTimerUnitToRefresh * sysTimerUnitInSecs
        public static short sysTimerUnitToRefresh = 1;

        // Price can be querried from SQL continouously and cause some bottleneck. 
        // The setting specified the time (in seconds) that data cached in the application server
        public static int sysDataDelayTimeInSecs = 5;

        public static string sysUserConfigFile
        {
            get
            {
                return common.fileFuncs.GetFullPath(Consts.constConfFile_User);
            }
        }

        //Images and logo
        public static string sysImgFilePathIcon = "";
        public static string sysImgFilePathBackGround = "";
        public static string sysImgFilePathCompanyLogo1 = "";
        public static string sysImgFilePathCompanyLogo2 = "";

        public static int sysChartFontSize = 12;
        public static int sysTradePointMarkerFontSize = 12;
        public static Color sysTradePointMarkerColorBG = Color.LightYellow;
        public static Color sysTradePointMarkerColorBUY = Color.Blue;
        public static Color sysTradePointMarkerColorSELL = Color.Red;
        public static Color sysTradePointMarkerColorOTHER = Color.Pink;
        public static string sysTradePointMarkeBUY = "B";
        public static string sysTradePointMarkerSELL = "S";
        public static string sysTradePointMarkerOTHER = "O";


        public static Color sysPriceColor_Decrease_BG = Color.Red;
        public static Color sysPriceColor_Increase_BG = Color.SkyBlue;
        public static Color sysPriceColor_NotChange_BG = Color.Yellow;
        public static Color sysPriceColor_Decrease_FG = Color.Black;
        public static Color sysPriceColor_Increase_FG = Color.Black;
        public static Color sysPriceColor_NotChange_FG = Color.Black;


        public static string sysString_All_Description
        {
            get
            {
                return "<" + Languages.Libs.GetString("all") + ">";
            }
        }
        public static string sysString_All_Code = "**";

        public static DateTime sysStartDataDate = DateTime.Parse("2006/01/01");
        public static int sysAutoRefreshInSeconds = 5 * 60;

        // Multi-value field is stored in the format: <prefix><value><postfix><separator>
        public static string sysListSeparatorPrefix = "/";
        public static string sysListSeparatorPostfix = "/";
        public static string sysListSeparator = " ";

        //Default        
        public static int sysDefaultLoginAccountDayToExpire = 365;
        public static string sysSuperAdminName = "admin";
        public static string sysDefaultImageFile = "images/employee.png";
        public static AppTypes.LanguageCodes sysLanguage = AppTypes.LanguageCodes.EN; 

        //Country
        public static string sysDefaultCountry = "VN";

        public static Color sysColorTradePoint = Color.Red;
        public static Color sysColorTradePointAnnotation = Color.FromArgb(255, 255, 128);

        //Currency
        public static string sysMainCurrency = "V";
        public static string sysMainCurrencyDisplay = "VND";
        public static string sysMainCurrencyText = "dong";
        public static string sysMainCurrencyName = "Viet nam dong";

        //Customed format
        public static int sysPrecisionPercentage = 1;
        public static int sysPrecisionPrice = 1;
        public static int sysPrecisionQty = 0;
        public static int sysPrecisionLocal = 0;
        public static int sysPrecisionForeign = 2;

        public static string sysMaskGeneralValue = "###,###,###,##0.000";
        public static string sysMaskLocalAmt = "###,###,###,###,##0";
        public static string sysMaskForeignAmt = "###,###,###,##0.00";
        public static string sysMaskPercent = "#0";
        public static string sysMaskQty = "###,###,###,##0";
        public static string sysMaskPrice = "###,###,##0.0";

        //Stock
        public static decimal sysStockMaxBuyQtyPerc = 10;
        public static decimal sysStockReduceQtyPerc = 10;
        public static decimal sysStockAccumulateQtyPerc = 10;
        public static decimal sysStockTotalCapAmt = 10000000;
        public static decimal sysStockMaxBuyAmtPerc = 100;

        //Chart property settings
        public static Color sysChartBgColor = Color.White;
        public static Color sysChartFgColor = Color.Black;
        public static Color sysChartGridColor = Color.Black;

        public static Color sysChartVolumesColor = Color.Navy;
        public static Color sysChartLineCandleColor = Color.DarkBlue;
        public static Color sysChartBearCandleColor = Color.Red;
        public static Color sysChartBullCandleColor = Color.Green;
        public static Color sysChartBarDnColor = Color.Pink;
        public static Color sysChartBarUpColor = Color.Blue;

        public static bool sysChartShowDescription = true;
        public static bool sysChartShowVolume = true;
        public static bool sysChartShowGrid = true;
        public static bool sysChartShowLegend = true;

        // Whether to log exception, user access...
        public static AppTypes.SyslogMedia sysWriteLogException = AppTypes.SyslogMedia.File;
        public static AppTypes.SyslogMedia sysWriteLogAccess = AppTypes.SyslogMedia.None;
    }
}
