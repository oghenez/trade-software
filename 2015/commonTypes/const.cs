using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace commonTypes
{
    /// <summary>
    /// Constant
    /// </summary>
    public class Consts
    {
        public const bool constEditionPROFESSIONALL = true;

        public const string constDefaultCultureCode = "vi-VN";

        public const string constWebServiceConf = "wsStock.xml";

        public const string constTextMergeMarkerLEFT = "<";
        public const string constTextMergeMarkerRIGHT = ">";
        
        public const string constProductOwner = "Dung Vu";
        public const string constProductCode = "STOCKTRADING";

        public const char constUserPermissionADD = 'a';
        public const char constUserPermissionDEL = 'd';
        public const char constUserPermissionEDIT = 'e';

        public const string constMarkerNEW = "<New>";

        //Worker type
        public const string constWorkerTypeAdmin = "ADM";

        //Web service config
        public const int constWebServiceTimeOutInSecs = 50;
        public const int constWebServiceMaxReceivedMessageSize = 655360000;
        public const int constWebServiceMaxStringContentLength = 655360000;
        public const int constWebServiceMaxBytesPerRead = 65536000;

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
        //public const string constConfFile_User = "user.xml";
        //public const string constFile_SysLog = "syslog.log";
    }
    
    public class AppTypes
    {
        public enum MessageTypes : byte { Feedback=0, Message=1 };

        public enum MarketDataTypes : byte { Advancing, Declining, NonChange };

        public enum UserTypes : byte { Investor = 0, System = 1};

        public enum LanguageCodes : byte  { VI=0,EN=1 };
        public enum DataAccessMode : byte { Local, WebService };
        public enum PriceDataType : byte { High, Low, Open, Close, Volume, DateTime };
        //public enum DataDiagnoseTypes : byte { CloseAndNextOpen};

        public enum SyslogMedia : byte { None = 0, File = 1, Database = 2};
        public enum SyslogTypes : byte { Exception = 0, Access = 1, Others = 255 };

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

        #region classes for TimeScale
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
            public TimeScaleTypes Type = TimeScaleTypes.Day;
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
                             new TimeScale(TimeScaleTypes.RealTime,0,"RT","RT","0 "+ Languages.Libs.GetString("minute")) //Real time : collected in each 10 seconds
                            ,new TimeScale(TimeScaleTypes.Minnute,5, "M5","M5","5 "+ Languages.Libs.GetString("minute"))
                            ,new TimeScale(TimeScaleTypes.Minnute,10,"MT","M10","10 "+ Languages.Libs.GetString("minute")) 
                            ,new TimeScale(TimeScaleTypes.Minnute,15,"MF","M15","15 "+ Languages.Libs.GetString("minute")) 
                            ,new TimeScale(TimeScaleTypes.Minnute,30,"M3","M30","30 "+ Languages.Libs.GetString("minute")) 
                            ,new TimeScale(TimeScaleTypes.Hour,1, "H1","H1", "1 " + Languages.Libs.GetString("hour")) 
                            ,new TimeScale(TimeScaleTypes.Hour,2, "H2","H2", "2 " + Languages.Libs.GetString("hours")) 
                            ,new TimeScale(TimeScaleTypes.Hour,4, "H4","H4", "4 " + Languages.Libs.GetString("hours")) 
                            ,new TimeScale(TimeScaleTypes.Day, 1, "D1","D1", Languages.Libs.GetString("day")) 
                            ,new TimeScale(TimeScaleTypes.Week,1, "W1","W1", Languages.Libs.GetString("week")) 
                            ,new TimeScale(TimeScaleTypes.Month,1,"O1","MN", Languages.Libs.GetString("month")) 
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
                if (item.Code == str) 
                    return item;
            }
            return MainDataTimeScale;
        }
        public static TimeScale TimeScaleFromType(TimeScaleTypes type)
        {
            switch (type)
            {
                case TimeScaleTypes.Minnute: return TimeScaleFromCode("M1");
                case TimeScaleTypes.Hour: return TimeScaleFromCode("H1");
                case TimeScaleTypes.Day: return TimeScaleFromCode("D1");
                case TimeScaleTypes.Week: return TimeScaleFromCode("W1");
                case TimeScaleTypes.Month: return TimeScaleFromCode("O1");
                case TimeScaleTypes.Year: return TimeScaleFromCode("Y1");
                default :
                    return TimeScaleFromCode("RT");
            }
        }
        public static string TimeScaleToCode(AppTypes.TimeScale  timeScale)
        {
            foreach (AppTypes.TimeScale item in myTimeScales)
            {
                if (item == timeScale) return item.Code;
            }
            return MainDataTimeScale.Code;
        }
        public static string TimeScaleTypeToCode(AppTypes.TimeScaleTypes type)
        {
            foreach (AppTypes.TimeScale item in myTimeScales)
            {
                if (item.Type == type) return item.Code;
            }
            return MainDataTimeScale.Code;
        }

        #endregion

        #region classes for TimeRanges
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

        #endregion

        public enum Sex : byte { None = 0, Male = 1, Female = 2, Unspecified = 3 };

        public static AppTypes.LanguageCodes Code2Language(string value)
        {
            foreach (AppTypes.LanguageCodes item in Enum.GetValues(typeof(AppTypes.LanguageCodes)))
            {
                if (item.ToString() == value) return item;
            }
            return LanguageCodes.EN;
        }
        public static CultureInfo Code2Culture(AppTypes.LanguageCodes value)
        {
            switch (value)
            {
                case AppTypes.LanguageCodes.VI: return common.language.GetCulture("vi-VN");
                default: return common.language.GetCulture("en-US");
            }
        }
        public static AppTypes.LanguageCodes Culture2Code(CultureInfo value)
        {
            switch (value.Name)
            {
                case "vi-VN": return AppTypes.LanguageCodes.VI;
                default: return AppTypes.LanguageCodes.EN;
            }
        }

        public static string Type2Text(UserTypes value)
        {
            switch (value)
            {
                case UserTypes.System: 
                     return Languages.Libs.GetString("system");
                default :
                     return Languages.Libs.GetString("investor");
            }
        }
        
        public static string Type2Text(SyslogMedia value)
        {
            return value.ToString();
        }
        public static string Type2Text(SyslogTypes value)
        {
            return value.ToString();
        }
        public static string Type2Text(LanguageCodes value)
        {
            switch (value)
            {
                case LanguageCodes.VI: return Languages.Libs.GetString("vietnamese");
                default: return Languages.Libs.GetString("english");
            }
        }
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
        public static string Type2Text(PriceDataType value)
        {
            switch (value)
            {
                case PriceDataType.High: return Languages.Libs.GetString("highData");
                case PriceDataType.Low: return Languages.Libs.GetString("lowData");
                case PriceDataType.Open: return Languages.Libs.GetString("openData");
                case PriceDataType.Close: return Languages.Libs.GetString("closeData");
                case PriceDataType.Volume: return Languages.Libs.GetString("volumeData");
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

        /// <summary>
        /// Return the Range (start Date, end Date) based on the Type timeRange (Week, Month, Year..) 
        /// </summary>
        /// <param name="timeRange"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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
