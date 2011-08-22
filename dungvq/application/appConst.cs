using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;

namespace application
{
    public class Settings
    {
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
        public static string sysMainCurrencyDisplay = "VNĐ";
        public static string sysMainCurrencyText = "đồng";
        public static string sysMainCurrencyName = "Việt nam đồng";

        //Customed format
        public static int sysPrecisionPercentage = 1;
        public static int sysPrecisionQty = 2;
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
    }
    public class Consts
    {
        // tmpDataset.analysisData only have 10 indicator values[0-9]
        public const int constMaxIndicatorValueFld = 10;
        public const string constProductOwner = "Dung Vu";
        public const string constProductCode = "STOCKTRADING";

        public const char constUserPermissionADD = 'a';
        public const char constUserPermissionDEL = 'd';
        public const char constUserPermissionEDIT = 'e';

        public const string constNotAvailable = "N/A";
        
        public const string constWorkReward = "RE";
        public const string constWorkReward_Punish = "RP";

        //Statement type
        public const string constStatementType_wgLoan = "LOA";
        public const string constStatementType_wgPayment = "PAY";
        public const string constStatementType_wgReceive = "REI";
        public const string constStatementType_wgOutOffice = "OOF";
        public const string constStatementType_wgProduct = "WPR";
        public const string constStatementType_wgBonus = "BON";
        public const string constStatementType_wgEmSalay = "WES";
        public const string constStatementType_wgPolicy = "WPO";
        public const string constStatementType_geProdUnitCost = "PUC";

        //Worker type
        public const string constWorkerTypeAdmin = "ADM";

        //=================================================================================
        //Sys configuration 
        //=================================================================================
        //Microsoft system : http://support.microsoft.com/kb/320584
        public const int WM_KEYDOWN = 0x100;
        public const int WM_SYSKEYDOWN = 0x104;

        //Application titles
        public const string constApplicationName = "Quan ly";
        public const string constSysPermissionMenu = "MEN";   
    }
    public class myTypes
    {
        public enum screeningCritType : byte { None = 0, TotalVolume = 1, ForeignOwnVolume = 2, TargetPrice = 3, MarketCap = 4, LastMonthTransVolume = 5, };
        public class screeningCriteria
        {
            public screeningCritType code = screeningCritType.None;
            public double min = 0, max = 0;
        }

        public enum portfolioType : byte { Portfolio = 1, WatchList = 2 };
        public enum strategyType : byte { Strategy = 1, Screening = 2 };

        public enum portfolioDetailDataType : byte { None = 0, Strategy = 1 };
        public enum bizSectorType : byte { None = 0, Industry = 1, SuperSector = 2, Sector = 3, SubSector = 4 };
        public enum commonStatus : byte { None = 0, New = 1, Enable = 2, Disable = 4, Close = 8, Ignore = 16, All = 255 };
        public enum indicatorType : byte
        {
            None = 0, SMA = 1, EMA = 2, WMA = 3, MACD = 4, RSI = 5,
            DI = 6, DIPlus = 7, DIMinus = 8, DMPlus = 9, DMMinus = 10,
            StockRSI = 11, BBANDS = 12, StochF = 13, StochS = 14
        };

        public enum chartType : byte { None = 0, Line = 1, Bar = 2, CandelTick = 3 };
        public enum timeScales : byte { None = 0, RealTime = 1, Hourly = 2, Daily = 3, Weekly = 4, Monthly = 5, Yearly = 6 };
        public enum timeRanges : byte
        {
            None = 0, D1 = 1, D3 = 2, W = 10, M1 = 20, M3 = 21, YTD = 30,
            Y1 = 40, Y2 = 41, Y3 = 42, Y4 = 43, Y5 = 44, Range = 255
        };
        public enum sex : byte { None = 0, Male = 1, Female = 2, Unspecified = 3 };

        public static string Type2Text(screeningCritType value)
        {
            switch (value)
            {
                case screeningCritType.LastMonthTransVolume: return "KLGD tháng cuối";
                case screeningCritType.TotalVolume: return "Tổng KL";
                case screeningCritType.ForeignOwnVolume: return "KLNN sở hữu";
                case screeningCritType.TargetPrice: return "Giá đích";
                case screeningCritType.MarketCap: return "Vốn";
                default: return "";
            }
        }
        public static string Type2Text(strategyType value)
        {
            switch (value)
            {
                case strategyType.Strategy: return "Strategy";
                case strategyType.Screening: return "Screening";
                default: return "";
            }
        }
        public static string Type2Text(portfolioType value)
        {
            switch (value)
            {
                case portfolioType.Portfolio: return "Portfolio";
                case portfolioType.WatchList: return "WatchList";
                default: return "";
            }
        }
        public static string Type2Text(sex value)
        {
            switch (value)
            {
                case sex.Male: return "Nam";
                case sex.Female: return "Nữ";
                case sex.Unspecified: return "Không xác định";
                default: return "";
            }
        }
        public static string Type2Text(commonStatus value)
        {
            switch (value)
            {
                case commonStatus.New: return "Mới";
                case commonStatus.Enable: return "Họat động";
                case commonStatus.Disable: return "Ngưng";
                case commonStatus.Close: return "Đóng";
                case commonStatus.Ignore: return "Tạm hủy";
                default: return "N/A";
            }
        }
        public static string Type2Text(timeRanges value)
        {
            switch (value)
            {
                case timeRanges.D1: return "1 ngày";
                case timeRanges.D3: return "3 ngày";
                case timeRanges.W: return "1 tuần";
                case timeRanges.M1: return "1 tháng";
                case timeRanges.M3: return "3 tháng";
                case timeRanges.YTD: return "Từ đầu năm"; //Year to date
                case timeRanges.Y1: return "1 năm";
                case timeRanges.Y2: return "2 năm";
                case timeRanges.Y3: return "3 năm";
                case timeRanges.Y4: return "4 năm";
                case timeRanges.Y5: return "5 năm";
                case timeRanges.Range: return "Tự chọn";
                default: return "N/A";
            }
        }
        public static string Type2Text(chartType value)
        {
            switch (value)
            {
                case chartType.Line: return "Dạng Đường";
                case chartType.Bar: return "Dạng Thanh";
                case chartType.CandelTick: return "Dạng Nến";
                default: return "<Chọn>";
            }
        }
        public static string Type2Text(bizSectorType value)
        {
            switch (value)
            {
                case bizSectorType.Industry: return "Ngành/Industry)";
                case bizSectorType.SuperSector: return "Nhóm ngành/SuperSector";
                case bizSectorType.Sector: return "Nhóm lãnh vực/Sector";
                case bizSectorType.SubSector: return "Lãnh vực/Subsector";
                default: return "<Chọn>";
            }
        }
        public static string Type2Text(indicatorType value)
        {
            switch (value)
            {
                case indicatorType.SMA: return "Simple Moving Average" + "(" + value.ToString() + ")";
                case indicatorType.EMA: return "Exponential Moving Average" + "(" + value.ToString() + ")";
                case indicatorType.WMA: return "Weighted Moving Average" + "(" + value.ToString() + ")";
                case indicatorType.MACD: return "Moving Average Convergence/Divergence" + "(" + value.ToString() + ")";

                case indicatorType.DI: return "Directional Movement Index" + "(" + value.ToString() + ")";
                case indicatorType.DIPlus: return "Plus Directional Indicator" + "(" + value.ToString() + ")";
                case indicatorType.DIMinus: return "Minus Directional Indicator" + "(" + value.ToString() + ")";

                case indicatorType.DMPlus: return "Plus Directional Movement" + "(" + value.ToString() + ")";
                case indicatorType.DMMinus: return "Minus Directional Movement" + "(" + value.ToString() + ")";

                case indicatorType.RSI: return "Relative Strength Index" + "(" + value.ToString() + ")";
                case indicatorType.StockRSI: return "Stochastic Relative Strength Index" + "(" + value.ToString() + ")";
                case indicatorType.BBANDS: return "Bollinger Bands" + "(" + value.ToString() + ")";

                case indicatorType.StochF: return "Stochastic Fast" + "(" + value.ToString() + ")";
                case indicatorType.StochS: return "Stochastic Slow" + "(" + value.ToString() + ")";
                default: return value.ToString();
            }
        }
        public static string Type2Text(timeScales value)
        {
            switch (value)
            {
                case timeScales.RealTime: return "Thực tế";
                case timeScales.Hourly: return "Giờ";
                case timeScales.Daily: return "Ngày";
                case timeScales.Weekly: return "Tuần";
                case timeScales.Monthly: return "Tháng";
                case timeScales.Yearly: return "Năm";
                default: return value.ToString();
            }
        }
        //Convert all myTypes.commonStatus to table of (code,description)
        public static DataTable CreateCommonStatusTable()
        {
            DataTable tbl = new DataTable();
            // Define columns
            DataColumn col1 = new DataColumn("code", typeof(byte)); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn("description"); tbl.Columns.Add(col2);
            foreach (myTypes.commonStatus item in Enum.GetValues(typeof(myTypes.commonStatus)))
            {
                DataRow row = tbl.Rows.Add((byte)item);
                row[1] = myTypes.Type2Text(item);
            }
            return tbl;
        }
        public static DataTable CreateTimeScaleTable()
        {
            DataTable tbl = new DataTable();
            // Define columns
            DataColumn col1 = new DataColumn("code", typeof(byte)); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn("description"); tbl.Columns.Add(col2);
            foreach (myTypes.timeScales item in Enum.GetValues(typeof(myTypes.timeScales)))
            {
                DataRow row = tbl.Rows.Add((byte)item);
                row[1] = myTypes.Type2Text(item);
            }
            return tbl;
        }

        public static indicatorType GetIndictorType(string indicatorCode)
        {
            indicatorCode = indicatorCode.Trim().ToUpper();
            foreach (myTypes.indicatorType item in Enum.GetValues(typeof(myTypes.indicatorType)))
            {
                if (indicatorCode == item.ToString().Trim().ToUpper()) return item;
            }
            return myTypes.indicatorType.None;
        }


    }
}
