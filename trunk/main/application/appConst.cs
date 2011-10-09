using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;

namespace application
{
    public class Consts
    {
        // tmpDataset.analysisData only have 10 indicator values[0-9]
        //public const int constMaxIndicatorValueFld = 10;
        public const string constProductOwner = "Dung Vu";
        public const string constProductCode = "STOCKTRADING";

        public const char constUserPermissionADD = 'a';
        public const char constUserPermissionDEL = 'd';
        public const char constUserPermissionEDIT = 'e';

        public const string constNotAvailable = "N/A";
        //Statement type
        //public const string constSysPortfolioCode = "SPORTFOLIO";

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
    }
    public class Settings
    {
        public static string sysUserConfigFile
        {
            get
            {
                return common.fileFuncs.GetFullPath("user.xml");
            }
        }

        public static AppTypes.TimeRanges sysScreeningTimeRange = AppTypes.TimeRanges.Y1;
        public static AppTypes.TimeScale sysScreeningTimeScale = AppTypes.TimeScaleFromCode("D1");

        public static AppTypes.TimeRanges sysDefaultTimeRange = AppTypes.TimeRanges.Y5;
        public static string sysDefaultTimeScaleCode = "D1";

        public static string sysString_All_Description ="<All>";
        public static string sysString_All_Code = "**";

        public static DateTime sysStartDataDate = DateTime.Parse("2006/01/01");
        public static int sysAutoRefreshInSeconds = 5 * 60;

        // Multi-value field is stored in the format: <prefix><value><postfix><separator>
        public static string sysListSeparatorPrefix = "/";
        public static string sysListSeparatorPostfix = "/";
        public static string sysListSeparator = " ";

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

        //Country
        public static string sysDefaultCountry = "VN";


        //Date when the system start : used in create trade alert,...
        //public static DateTime sysStartDate = DateTime.Parse("2011/01/01");

        //Minimum pasword len
        public static byte sysPasswordMinLen = 0;

        public static Color sysColorTradePoint = Color.Red;
        public static Color sysColorTradePointAnnotation = Color.FromArgb(255, 255, 128);


        //Date format : use French
        public static string sysCultureCode = "vi-VN";

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

        public static string sysLocalAmtMask = "###,###,###,###,##0";
        public static string sysForeignAmtMask = "###,###,###,##0.00";
        public static string sysPercentMask = "#0";
        public static string sysQtyMask = "###,###,##0.00";

        //Stock
        public static short sysStockSell2BuyInterval = 3;
        public static decimal sysStockTransFeePercent = 0.2m;
        public static decimal sysStockPriceWeight = 1000;
        public static decimal sysStockVolumeWeight = 10;
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

        public static bool sysChartAutoScaleMetric = false;
        public static bool sysChartAutoPanMetric = false;
        public static decimal sysChartYScaleMetric = 1;
        public static decimal sysChartXScaleMetric = 1;
        public static decimal sysChartXPanMetric = 1;
        public static decimal sysChartYPanMetric = 1;
    }
    public class AppTypes
    {
        public enum ChartTypes : byte { None, Line, Bar, CandleStick };

        public enum MarketTrend : byte { Unspecified = 0, Sidebar = 1, Upward = 2, Downward = 3 };
        public enum TradeActions : byte { None = 0, Buy = 1, Sell = 2, Accumulate = 3, ClearAll = 4, Select = 5 };

        /// PortfolioTypes conatain all possible values in portfolio.Type column. PortfolioTypes value is bitwise.
        /// The meaning of each type is explained bellows.
        /// - Portfolio : users can create one or may portfolios to ease their management.Stocks are put into user's portfolios when trading.
        /// - SysWatchList : stockcodes list defined by system admin and listed in their watch list.
        /// - SysPortfolio : Default strategy list.
        /// - WatchList : stockcodes list defined by users.
        
        public enum PortfolioTypes : byte { Portfolio = 1, WatchList = 2, SysWatchList = 4, SysPortfolio = 8 };

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
        public static TimeScale[] myTimeScales = new TimeScale[]
        { 
            new TimeScale(TimeScaleTypes.RealTime,0,"RT","M5","5 "+ language.GetString("minute")), //Real time : collected in each 5 minutes
            new TimeScale(TimeScaleTypes.Hour,1, "H1","H1", "1 " + language.GetString("hour")), 
            new TimeScale(TimeScaleTypes.Hour,2, "H2","H2", "2 " + language.GetString("hours")), 
            new TimeScale(TimeScaleTypes.Day, 1, "D1","D1", language.GetString("day")), 
            new TimeScale(TimeScaleTypes.Week,1, "W1","W1", language.GetString("week")), 
            new TimeScale(TimeScaleTypes.Month,1,"O1","MN", language.GetString("month")) 
        };
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
                case StrategyTypes.Strategy: return language.GetString("strategy");
                case StrategyTypes.Screening: return language.GetString("screening");
                default: return "";
            }
        }
        public static string Type2Text(Sex value)
        {
            switch (value)
            {
                case Sex.Male: return language.GetString("male");
                case Sex.Female: return language.GetString("female");
                case Sex.Unspecified: return language.GetString("unspecifiedSex");
                default: return "";
            }
        }
        public static string Type2Text(CommonStatus value)
        {
            switch (value)
            {
                case CommonStatus.New: return language.GetString("newStat");
                case CommonStatus.Enable: return language.GetString("enableStat");
                case CommonStatus.Disable: return language.GetString("disableStat");
                case CommonStatus.Close: return language.GetString("closeStat");
                case CommonStatus.Ignore: return language.GetString("ignoreStat");
                default: return "N/A";
            }
        }
        public static string Type2Text(TimeRanges value)
        {
            switch (value)
            {
                case TimeRanges.W1: return "01 " + language.GetString("week");
                case TimeRanges.W2: return "02 " + language.GetString("weeks");
                case TimeRanges.W3: return "03 " + language.GetString("weeks");
                case TimeRanges.M1: return "01 " + language.GetString("week");
                case TimeRanges.M2:  return "02 " + language.GetString("months");
                case TimeRanges.M3: return "03 " + language.GetString("months");
                case TimeRanges.M4: return "04 " + language.GetString("months");
                case TimeRanges.M5: return "05 " + language.GetString("months");
                case TimeRanges.M6: return "06 " + language.GetString("months");
                case TimeRanges.YTD: return language.GetString("YTD");  //Year to date
                case TimeRanges.Y1: return "01 " + language.GetString("year");
                case TimeRanges.Y2: return "02 " + language.GetString("years");
                case TimeRanges.Y3: return "03 " + language.GetString("years");
                case TimeRanges.Y4: return "04 " + language.GetString("years");
                case TimeRanges.Y5: return "05 " + language.GetString("years");
                case TimeRanges.All: return language.GetString("all");
                default: return language.GetString("NA");
            }
        }
        public static string Type2Text(ChartTypes value)
        {
            switch (value)
            {
                case ChartTypes.Line: return language.GetString("line");
                case ChartTypes.Bar: return language.GetString("bar");
                case ChartTypes.CandleStick: return language.GetString("candleStick"); 
                default: return "<"+language.GetString("select")+">";
            }
        }
        public static string Type2Text(BizSectorTypes value)
        {
            switch (value)
            {
                case BizSectorTypes.Industry: return language.GetString("industry");
                case BizSectorTypes.SuperSector: return language.GetString("superSector");
                case BizSectorTypes.Sector: return language.GetString("sector");
                case BizSectorTypes.SubSector: return language.GetString("subsector");
                default: return "<"+language.GetString("select")+">";
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
        public static void LoadTimeScales(data.tmpDS.codeListDataTable tbl)
        {
            data.tmpDS.codeListRow row;
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                row = tbl.NewcodeListRow();
                row.code = AppTypes.myTimeScales[idx].Code;
                row.description = AppTypes.myTimeScales[idx].Text;
                tbl.AddcodeListRow(row);
            }
        }
        public static void LoadCommonStatus(data.tmpDS.codeListDataTable tbl)
        {
            data.tmpDS.codeListRow row;
            foreach (CommonStatus item in Enum.GetValues(typeof(CommonStatus)))
            {
                row  = tbl.NewcodeListRow();
                row.code = ((byte)item).ToString();
                row.byteValue = (byte)item;
                row.description = item.ToString();
                tbl.AddcodeListRow(row);
            }
        }
        public static void LoadTradeActions(data.tmpDS.codeListDataTable tbl)
        {
            data.tmpDS.codeListRow  row;
            foreach (TradeActions item in Enum.GetValues(typeof(TradeActions)))
            {
                row = tbl.NewcodeListRow();
                row.code = ((byte)item).ToString();
                row.description = item.ToString();
                tbl.AddcodeListRow(row);
            }
        }

        public static bool GetDate(application.AppTypes.TimeRanges timeRange, out DateTime startDate, out DateTime endDate)
        {
            startDate = common.Consts.constNullDate;
            endDate = common.Consts.constNullDate;
            bool retVal = true;
            switch (timeRange)
            {
                case application.AppTypes.TimeRanges.W1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-7);
                    break;
                case application.AppTypes.TimeRanges.W2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-14);
                    break;
                case application.AppTypes.TimeRanges.W3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddDays(-21);
                    break;

                case application.AppTypes.TimeRanges.M1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-1);
                    break;
                case application.AppTypes.TimeRanges.M2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-2);
                    break;
                case application.AppTypes.TimeRanges.M3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-3);
                    break;
                case application.AppTypes.TimeRanges.M4:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-5);
                    break;
                case application.AppTypes.TimeRanges.M5:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-5);
                    break;
                case application.AppTypes.TimeRanges.M6:
                    endDate = DateTime.Today;
                    startDate = endDate.AddMonths(-6);
                    break;

                case application.AppTypes.TimeRanges.YTD:
                    endDate = DateTime.Today;
                    common.dateTimeLibs.MakeDate(1, 1, endDate.Year, out startDate);
                    break;
                case application.AppTypes.TimeRanges.Y1:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-1);
                    break;
                case application.AppTypes.TimeRanges.Y2:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-2);
                    break;
                case application.AppTypes.TimeRanges.Y3:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-3);
                    break;
                case application.AppTypes.TimeRanges.Y4:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-4);
                    break;
                case application.AppTypes.TimeRanges.Y5:
                    endDate = DateTime.Today;
                    startDate = endDate.AddYears(-5);
                    break;

                case application.AppTypes.TimeRanges.All:
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
