using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;

namespace commonClass
{
    public class Consts
    {
        public const string constTextMergeMarkerLEFT = "<";
        public const string constTextMergeMarkerRIGHT = ">";
        
        public const string constProductOwner = "Dung Vu";
        public const string constProductCode = "STOCKTRADING";

        public const char constUserPermissionADD = 'a';
        public const char constUserPermissionDEL = 'd';
        public const char constUserPermissionEDIT = 'e';

        public const string constNotAvailable = "N/A";
        public const string constNotMarkerNEW = "<New>";

        //Worker type
        public const string constWorkerTypeAdmin = "ADM";

        //=================================================================================
        //Sys configuration 
        //=================================================================================
        //Microsoft system : http://support.microsoft.com/kb/320584
        public const int WM_KEYDOWN = 0x100;
        public const int WM_SYSKEYDOWN = 0x104;

        //Application titles
        public const string constApplicationName = "System";
        public const string constSysPermissionMenu = "MEN";

        //Config file
        public const string constConfFile_Meta_Strategy = "strategyInfo.xml";
        public const string constConfFile_Meta_Indicator = "indicators.xml";
        public const string constConfFile_User = "user.xml";
        public const string constFile_SysLog = "syslog.txt";
    }
    public class Settings
    {
        //Whether to keep sell that was blocked by T+4 and issue it when the time come
        public static bool sysKeepInApplicableSell = true; 

        //Use webservice or not
        public static bool sysUseWebservice = true;

        // Some process such as backtesting need to slit a process into several batches 
        // The setting specifies the number of items put in each batch process.
        public static int sysNumberOfItemsInBatchProcess = 5;

        //Interval in seconds at which  system time events occur.
        public static int sysTimerIntervalInSecs = 5;   // Possitive number to enable system timer

        // Price can be querried from SQL continouously and cause some bottleneck. 
        // The setting specified the time (in seconds) that data cached in the application server
        public static int sysDataDelayTimeInSecs = 5;  

        public static string sysUserConfigFile
        {
            get
            {
                return common.fileFuncs.GetFullPath(commonClass.Consts.constConfFile_User);
            }
        }

        public static int sysChartFontSize = 12;
        public static int sysTradePointMarkerFontSize = 12;
        public static Color sysTradePointMarkerColorBG = Color.LightYellow;
        public static Color sysTradePointMarkerColorBUY = Color.Green;
        public static Color sysTradePointMarkerColorSELL = Color.Red;
        public static Color sysTradePointMarkerColorOTHER = Color.Pink;
        public static string sysTradePointMarkeBUY = "B";
        public static string sysTradePointMarkerSELL = "S";
        public static string sysTradePointMarkerOTHER = "O";


        public static Color sysPriceColor_Decrease_BG = Color.Red;
        public static Color sysPriceColor_Increase_BG = Color.Green;
        public static Color sysPriceColor_NotChange_BG = Color.Yellow;
        public static Color sysPriceColor_Decrease_FG = Color.Red;
        public static Color sysPriceColor_Increase_FG = Color.Red;
        public static Color sysPriceColor_NotChange_FG = Color.Black;
        

        public static AppTypes.TimeRanges sysAlertTimeRange = AppTypes.TimeRanges.M2;
        public static AppTypes.TimeRanges sysScreeningTimeRange = AppTypes.TimeRanges.M2;
        public static AppTypes.TimeScale sysScreeningTimeScale = AppTypes.TimeScaleFromCode("D1");

        public static AppTypes.TimeRanges sysDefaultTimeRange = AppTypes.TimeRanges.Y3;
        public static AppTypes.TimeScale sysDefaultTimeScale = AppTypes.TimeScaleFromCode("D1");

        public static string sysString_All_Description
        {
            get
            {
                return "<" + Languages.Libs.GetString("all") +">";
            }
        }
        public static string sysString_All_Code = "**";

        public static DateTime sysStartDataDate = DateTime.Parse("2006/01/01");
        public static int sysAutoRefreshInSeconds = 5 * 60;

        // Multi-value field is stored in the format: <prefix><value><postfix><separator>
        public static string sysListSeparatorPrefix = "/";
        public static string sysListSeparatorPostfix = "/";
        public static string sysListSeparator = " ";

        //Write log where having error ?
        public static bool sysLogError = true;

        public static bool sysDebugMode
        {
            get { return common.settings.sysDebugMode;}
            set
            {
                common.settings.sysDebugMode = value;
            }
        }
        public static bool sysUseStrongPassword = false;

        // Auto-generated edit key has the form  <number><postfix>
        // myAutoEditKeySize specifies the lenght of <number> part 
        public static int sysAutoEditKeySize = 4;
        
        // Auto-generated data has the form  <prefix><numeric string>
        // sysDataKeySize specifies the lenght of <number string> part 
        public static int sysDataKeySize = 9;
        public static string sysDataKeyPrefix = "A";

        //Maximum time (in seconds) that consider an auto key is valid.
        public static int sysTimeOut_AutoKey = 2 * 60; //2 Minutes

        //Default        
        public static int sysDefaultLoginAccountDayToExpire = 365;
        public static string sysSuperAdminName = "admin";
        public static string sysDefaultImageFile = "images/employee.png";
        public static string sysCultureCode = "vi-VN";

        //Country
        public static string sysDefaultCountry = "VN";


        //Date when the system start : used in create trade alert,...
        //public static DateTime sysStartDate = DateTime.Parse("2011/01/01");

        //Minimum pasword len
        public static byte sysPasswordMinLen = 0;

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
    }
    public class AppTypes
    {
        public enum ChartTypes : byte { None, Line, Bar, CandleStick };

        public enum MarketTrend : byte { Unspecified = 0, Sidebar = 1, Upward = 2, Downward = 3 };
        public enum TradeActions : byte { None = 0, Buy = 1, Sell = 2, Accumulate = 3, ClearAll = 4, Select = 5 };

        /// PortfolioTypes conatain all possible values in portfolio.Type column. PortfolioTypes value is bitwise.
        /// The meaning of each type is explained bellows.
        /// - Portfolio : users can create one or several portfolios for owned-stock management.
        ///   When trading, stocks are put into user's portfolios to easy management.
        /// - WatchList : users can create one or several watch lists to keep track of the market.
        /// - SysWatchList : stockcodes list defined by system admin and listed in all users' watch list.
        /// - PortfolioDefaultStrategy : system will send alerts to users based on what stockcode and strategy they want to monitor.
        ///   PortfolioDefaultStrategy keeps the default strategy setup by system admin

        public enum PortfolioTypes : byte { Portfolio = 1, WatchList = 2, SysWatchList = 4, PortfolioDefaultStrategy = 8 };

        public enum StrategyTypes : byte { Strategy = 1, Screening = 2 };

        //public enum PortfolioDetailDataType : byte { None = 0, Strategy = 1 };
        public enum BizSectorTypes : byte { None = 0, Industry = 1, SuperSector = 2, Sector = 3, SubSector = 4 };
        public enum CommonStatus : byte { None = 0, New = 1, Enable = 2, Disable = 4, Close = 8, Ignore = 16, All = 255 };

        public enum  TimeScaleTypes { RealTime, Minnute, Hour, Day, Week, Month, Year};
        public class TimeScale
        {
            public TimeScale(TimeScaleTypes type, byte value, string code, string text)
            {
                new TimeScale(type, value, code, text, text);
            }
            public TimeScale(TimeScaleTypes type, byte value, string code, string text, string description)
            { 
                this.Type = type;
                this.AggregationValue = value;
                this.Code = code;
                this.Text = text;
                this.Description = description ;
            }
            public TimeScaleTypes Type = TimeScaleTypes.RealTime;
            // The number of time (minute,hour,day,week...) to aggregate data
            public byte AggregationValue = 1;
            public string Code = "", Text = "",Description="";
        };
        //List all time scale used in the system

        public static void ReLoadTimeScales()
        {
            _myTimeScales = null;
        }
        private static TimeScale[] _myTimeScales = null;
        public static TimeScale[] myTimeScales
        {
            get
            {
                if (_myTimeScales==null)
                {
                    _myTimeScales = new TimeScale[]
                        { 
                            new TimeScale(TimeScaleTypes.RealTime,0,"RT","M5","5 "+ Languages.Libs.GetString("minute")), //Real time : collected in each 5 minutes
                            new TimeScale(TimeScaleTypes.Hour,1, "H1","H1", "1 " + Languages.Libs.GetString("hour")), 
                            new TimeScale(TimeScaleTypes.Hour,2, "H2","H2", "2 " + Languages.Libs.GetString("hours")), 
                            new TimeScale(TimeScaleTypes.Day, 1, "D1","D1", Languages.Libs.GetString("day")), 
                            new TimeScale(TimeScaleTypes.Week,1, "W1","W1", Languages.Libs.GetString("week")), 
                            new TimeScale(TimeScaleTypes.Month,1,"O1","MN", Languages.Libs.GetString("month")) 
                        };
                }
                return _myTimeScales;
            }
        }
                
        // Data collected in realtime and then aggregate to different time scales  
        // MainDataTimeScale specifies the TimeScale for the realtime data 
        public static TimeScale MainDataTimeScale
        {
            get
            {
                return myTimeScales[0];
            }
        }
        public static TimeScale TimeScaleFromCode(string str)
        {
            foreach (AppTypes.TimeScale item in myTimeScales)
            {
                if (item.Code == str) return item;
            }
            return MainDataTimeScale;
        }
        public static TimeRanges TimeRangeFromCode(string str)
        {
            foreach (AppTypes.TimeRanges item in Enum.GetValues(typeof(AppTypes.TimeRanges)))
            {
                if (item.ToString()== str) return item;
            }
            return TimeRanges.None;
        }

        public enum TimeRanges : byte
        {
            None,W1,W2,W3,M1,M2,M3,M4,M5,M6,YTD,Y1,Y2,Y3,Y4,Y5,All
        };
        public enum Sex : byte { None = 0, Male = 1, Female = 2, Unspecified = 3 };

        public static string Type2Text(StrategyTypes value)
        {
            switch (value)
            {
                case StrategyTypes.Strategy: return Languages.Libs.GetString("strategy");
                case StrategyTypes.Screening: return Languages.Libs.GetString("screening");
                default: return "";
            }
        }
        public static string Type2Text(Sex value)
        {
            switch (value)
            {
                case Sex.Male: return Languages.Libs.GetString("male");
                case Sex.Female: return Languages.Libs.GetString("female");
                case Sex.Unspecified: return Languages.Libs.GetString("unspecifiedSex");
                default: return "";
            }
        }
        public static string Type2Text(CommonStatus value)
        {
            switch (value)
            {
                case CommonStatus.New: return Languages.Libs.GetString("newStat");
                case CommonStatus.Enable: return Languages.Libs.GetString("enableStat");
                case CommonStatus.Disable: return Languages.Libs.GetString("disableStat");
                case CommonStatus.Close: return Languages.Libs.GetString("closeStat");
                case CommonStatus.Ignore: return Languages.Libs.GetString("ignoreStat");
                default: return "N/A";
            }
        }
        public static string Type2Text(TimeRanges value)
        {
            switch (value)
            {
                case TimeRanges.W1: return "01 " + Languages.Libs.GetString("week");
                case TimeRanges.W2: return "02 " + Languages.Libs.GetString("weeks");
                case TimeRanges.W3: return "03 " + Languages.Libs.GetString("weeks");
                case TimeRanges.M1: return "01 " + Languages.Libs.GetString("month");
                case TimeRanges.M2:  return "02 " + Languages.Libs.GetString("months");
                case TimeRanges.M3: return "03 " + Languages.Libs.GetString("months");
                case TimeRanges.M4: return "04 " + Languages.Libs.GetString("months");
                case TimeRanges.M5: return "05 " + Languages.Libs.GetString("months");
                case TimeRanges.M6: return "06 " + Languages.Libs.GetString("months");
                case TimeRanges.YTD: return Languages.Libs.GetString("YTD");  //Year to date
                case TimeRanges.Y1: return "01 " + Languages.Libs.GetString("year");
                case TimeRanges.Y2: return "02 " + Languages.Libs.GetString("years");
                case TimeRanges.Y3: return "03 " + Languages.Libs.GetString("years");
                case TimeRanges.Y4: return "04 " + Languages.Libs.GetString("years");
                case TimeRanges.Y5: return "05 " + Languages.Libs.GetString("years");
                case TimeRanges.All: return Languages.Libs.GetString("all");
                default: return Languages.Libs.GetString("NA");
            }
        }
        public static string Type2Text(ChartTypes value)
        {
            switch (value)
            {
                case ChartTypes.Line: return Languages.Libs.GetString("line");
                case ChartTypes.Bar: return Languages.Libs.GetString("bar");
                case ChartTypes.CandleStick: return Languages.Libs.GetString("candleStick"); 
                default: return "<"+Languages.Libs.GetString("select")+">";
            }
        }
        public static string Type2Text(BizSectorTypes value)
        {
            switch (value)
            {
                case BizSectorTypes.Industry: return Languages.Libs.GetString("industry");
                case BizSectorTypes.SuperSector: return Languages.Libs.GetString("superSector");
                case BizSectorTypes.Sector: return Languages.Libs.GetString("sector");
                case BizSectorTypes.SubSector: return Languages.Libs.GetString("subsector");
                default: return "<"+Languages.Libs.GetString("select")+">";
            }
        }
        public static string Type2Text(TradeActions value)
        {
            switch (value)
            {
                case TradeActions.Accumulate: return Languages.Libs.GetString("accumulateAction");
                case TradeActions.Buy: return Languages.Libs.GetString("buyAction");
                case TradeActions.Select: return Languages.Libs.GetString("selectAction");
                case TradeActions.Sell: return Languages.Libs.GetString("sellAction");
                case TradeActions.ClearAll: return Languages.Libs.GetString("clearAllAction");
                default: return "<" + Languages.Libs.GetString("select") + ">";
            }
        }

        public static StrategyTypes Text2StrategyType(string str)
        {
            if (str.ToLower().Trim() == StrategyTypes.Screening.ToString().ToLower()) return StrategyTypes.Screening;
            return StrategyTypes.Strategy;
        }
        public static ChartTypes Text2ChartType(string str)
        {
            str = str.Trim().ToLower();
            if (str == ChartTypes.Bar.ToString().ToLower()) return ChartTypes.Bar;
            if (str == ChartTypes.CandleStick.ToString().ToLower()) return ChartTypes.CandleStick;
            return ChartTypes.Line;
        }        

        public static bool GetDate(AppTypes.TimeRanges timeRange, out DateTime startDate, out DateTime endDate)
        {
            startDate = common.Consts.constNullDate;
            endDate = common.Consts.constNullDate;
            bool retVal = true;
            switch (timeRange)
            {
                case AppTypes.TimeRanges.W1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-7);
                    break;
                case AppTypes.TimeRanges.W2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-14);
                    break;
                case AppTypes.TimeRanges.W3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-21);
                    break;

                case AppTypes.TimeRanges.M1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-1);
                    break;
                case AppTypes.TimeRanges.M2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-2);
                    break;
                case AppTypes.TimeRanges.M3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-3);
                    break;
                case AppTypes.TimeRanges.M4:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-5);
                    break;
                case AppTypes.TimeRanges.M5:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-5);
                    break;
                case AppTypes.TimeRanges.M6:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-6);
                    break;

                case AppTypes.TimeRanges.YTD:
                    endDate = DateTime.Today;
                    common.dateTimeLibs.MakeDate(1, 1, endDate.Year, out startDate);
                    break;
                case AppTypes.TimeRanges.Y1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-1);
                    break;
                case AppTypes.TimeRanges.Y2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-2);
                    break;
                case AppTypes.TimeRanges.Y3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-3);
                    break;
                case AppTypes.TimeRanges.Y4:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-4);
                    break;
                case AppTypes.TimeRanges.Y5:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-5);
                    break;

                case AppTypes.TimeRanges.All:
                    startDate = DateTime.MinValue;
                    endDate = DateTime.MaxValue;
                    return true;
                default:
                    retVal = false;
                    break;
            }
            endDate = endDate.Date.AddDays(1).AddSeconds(-1);
            return retVal;
        }
    }
}
