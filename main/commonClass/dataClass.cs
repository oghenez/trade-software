using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization;

namespace commonClass
{
    [DataContract]
    public class TransactionInfo
    {
        [DataMember]
        public decimal price = 0, priceRatio=1,transFeePerc=0,availableCash = 0;
        [DataMember]
        public DateTime priceDate = common.Consts.constNullDate;
        [DataMember]
        public string stockCode = "", portfolio = "";
    }
    [DataContract]
    public class EstimateOptions
    {
        [DataMember]
        public decimal TotalCapAmt = Settings.sysStockTotalCapAmt;
        [DataMember]
        public decimal MaxBuyAmtPerc = Settings.sysStockMaxBuyAmtPerc;
        [DataMember]
        public decimal QtyReducePerc = Settings.sysStockReduceQtyPerc;
        [DataMember]
        public decimal QtyAccumulatePerc = Settings.sysStockAccumulateQtyPerc;
        [DataMember]
        public decimal MaxBuyQtyPerc = Settings.sysStockMaxBuyQtyPerc;

        //See http://social.msdn.microsoft.com/forums/en-US/wcf/thread/447149d5-b44c-47cd-a690-20928244b52b/
        //[OnDeserialized]
        //public void OnDeserialized(StreamingContext context)
        //{
        //    Init();
        //}
    }

    /// <summary>
    /// Forcasting information (market,priority...) generated from analysis process    
    /// </summary>
    [DataContract]
    public class BusinessInfo
    {
        public BusinessInfo() { }
        public BusinessInfo(AppTypes.MarketTrend shortTerm, AppTypes.MarketTrend mediumTerm, AppTypes.MarketTrend longTerm, double weight)
        {
            this.ShortTermTrend = shortTerm;
            this.MediumTermTrend = mediumTerm;
            this.LongTermTrend = longTerm;
            this.Weight = weight;
        }
        public void Set(BusinessInfo info)
        {
            this.ShortTermTrend = info.ShortTermTrend;
            this.MediumTermTrend = info.MediumTermTrend;
            this.LongTermTrend = info.LongTermTrend;
            this.Weight = info.Weight;
        }
        public void SetTrend(AppTypes.MarketTrend shortTerm, AppTypes.MarketTrend mediumTerm, AppTypes.MarketTrend longTerm)
        {
            this.ShortTermTrend = shortTerm;
            this.MediumTermTrend = mediumTerm;
            this.LongTermTrend = longTerm;
        }

        public string ToText()
        {
            string st = "";
            switch (ShortTermTrend)
            {
                case (AppTypes.MarketTrend.Upward):
                    st = st + "Short term trend is upward. ";
                    break;
                case AppTypes.MarketTrend.Downward:
                    st = st + "Short term trend is downward. ";
                    break;
                case AppTypes.MarketTrend.Sidebar:
                    st = st + "Short term trend is sideway. ";
                    break;
                case AppTypes.MarketTrend.Unspecified:
                    //st =st+ "Short term trend is unspecified. ";
                    break;
                default:
                    break;
            }
            switch (MediumTermTrend)
            {
                case (AppTypes.MarketTrend.Upward):
                    st = st + "Medium term trend is upward. ";
                    break;
                case AppTypes.MarketTrend.Downward:
                    st = st + "Medium term trend is downward. ";
                    break;
                case AppTypes.MarketTrend.Sidebar:
                    st = st + "Medium term trend is sideway. ";
                    break;
                case AppTypes.MarketTrend.Unspecified:
                    //st =st+ "Medium term trend is unspecified.";
                    break;
                default:
                    break;
            }
            switch (LongTermTrend)
            {
                case (AppTypes.MarketTrend.Upward):
                    st = st + "Long term trend is upward. ";
                    break;
                case AppTypes.MarketTrend.Downward:
                    st = st + "Long term trend is downward. ";
                    break;
                case AppTypes.MarketTrend.Sidebar:
                    st = st + "Long term trend is sideway. ";
                    break;
                case AppTypes.MarketTrend.Unspecified:
                    //st = "Long term trend is unspecified.";
                    break;
                default:
                    break;
            }

            if (Short_Target != 0)
                st += "Short Term Target is " + Short_Target.ToString() + ". ";

            if (Stop_Loss != 0)
                st += "Stop loss is " + Stop_Loss.ToString() + ".";

            if (Short_Resistance != 0)
                st += "Short term resistance is " + Short_Resistance.ToString() + ".";
            if (Short_Support != 0)
                st += " Short term support is " + Short_Support.ToString() + ".";
            return st;
        }

        [DataMember]
        public AppTypes.MarketTrend LongTermTrend = AppTypes.MarketTrend.Unspecified;

        [DataMember]
        public AppTypes.MarketTrend MediumTermTrend = AppTypes.MarketTrend.Unspecified;

        [DataMember]
        public AppTypes.MarketTrend ShortTermTrend = AppTypes.MarketTrend.Unspecified;
        [DataMember]
        public double Short_Target = 0;
        [DataMember]
        public double Stop_Loss = 0;
        [DataMember]
        public double Short_Resistance = 0;
        [DataMember]
        public double Short_Support = 0;
        [DataMember]
        public double Weight = 0;
    }

    [DataContract]
    public class TradePointInfo
    {
        public TradePointInfo() { }
        public TradePointInfo(AppTypes.TradeActions action, int dataIdx)
        {
            this.TradeAction = action;
            this.DataIdx = dataIdx;
        }
        public TradePointInfo(AppTypes.TradeActions action, int dataIdx, BusinessInfo info)
        {
            this.TradeAction = action;
            this.DataIdx = dataIdx;
            this.BusinessInfo.Set(info);
        }
        //TradePoint can be estimated by some way to decide whether the trade point is valid. 
        [DataMember]
        public bool isValid = true;

        // Data position where the trade point occured.
        // The index is used to get data (closePrice,openPrice...) of a trade point.
        [DataMember]
        public int DataIdx = 0;

        [DataMember]
        public AppTypes.TradeActions TradeAction = AppTypes.TradeActions.None;

        [DataMember]
        public BusinessInfo BusinessInfo = new BusinessInfo();
    }
    public class OHLCV
    {
        public OHLCV() { }
        public OHLCV(double _open, double _high, double _low, double _close, double _volume)
        {
            Open = _open;
            High = _high;
            Low = _low;
            Close = _close;
            Volume = _volume;
        }
        public double Open = 0, High = 0, Low = 0, Close = 0, Volume = 0;
        public static OHLCV operator +(OHLCV d1, OHLCV d2)
        {
            OHLCV retVal = new OHLCV();
            retVal.Open = d1.Open + d2.Open;
            retVal.High = d1.High + d2.High;
            retVal.Low = d1.Low + d2.Low;
            retVal.Close = d1.Close + d2.Close;
            retVal.Volume = d1.Volume + d2.Volume;
            return retVal;
        }
        public static OHLCV operator -(OHLCV d1, OHLCV d2)
        {
            OHLCV retVal = new OHLCV();
            retVal.Open = d1.Open - d2.Open;
            retVal.High = d1.High - d2.High;
            retVal.Low = d1.Low - d2.Low;
            retVal.Close = d1.Close - d2.Close;
            retVal.Volume = d1.Volume - d2.Volume;
            return retVal;
        }
        public static OHLCV operator /(OHLCV bar, int d)
        {
            if (d == 0) return bar;
            OHLCV retVal = new OHLCV();
            retVal.Open = bar.Open / d;
            retVal.High = bar.High / d;
            retVal.Low = bar.Low / d;
            retVal.Close = bar.Close / d;
            retVal.Volume = bar.Volume / d;
            return retVal;
        }
    }
    public class DataSeries
    {
        public DataSeries() { }
        public DataSeries(DataSeries ds, string _name)
        {
            _values = new double[ds.Count];
            Name = _name;
            for (int idx = 0; idx < _values.Length; idx++) _values[idx] = 0;
        }
        public DataSeries(DataBars ds, string _name)
        {
            _values = new double[ds.Count];
            Name = _name;
            for (int idx = 0; idx < _values.Length; idx++) _values[idx] = 0;
        }
        public DataSeries Clone()
        {
            DataSeries series = new DataSeries();
            series.Set(this);
            return series;
        }

        public string Name = "";
        private double[] _values = null;
        public common.DictionaryList Cache = new common.DictionaryList();

        public int FirstValidValue = 0;
        public int Count
        {
            get
            {
                if (_values != null) return _values.Length;
                return 0;
            }
        }
        public void Clear()
        {
            _values = null;
            FirstValidValue = 0;

        }
        public double[] Values
        {
            get { return _values; }
            set
            {
                Clear();
                for (int idx = 0; idx < value.Length; idx++) this.Add(value[idx]);
            }
        }
        public void Add(double d)
        {
            if (_values == null) _values = new double[0];
            Array.Resize(ref _values, Count + 1);
            _values[Count - 1] = d;
            return;
        }
        public void Remove(int idx)
        {
            if (idx < 0 || idx > Count) return;
            if (_values != null)
            {
                for (; idx < Count - 1; idx++) _values[idx] = _values[idx + 1];
                Array.Resize(ref _values, Count - 1);
            }
        }
        public double this[int index]
        {
            set
            {
                _values[index] = value;
                return;
            }
            get
            {
                if (_values != null) return _values[index];
                return 0;
            }
        }

        public double Max
        {
            get { return FindMax(0); }
        }
        public double Min
        {
            get { return FindMin(0); }
        }
        protected double FindMax(int startIdx)
        {
            if (startIdx < this.FirstValidValue) startIdx = this.FirstValidValue;
            if (startIdx >= this.Count) return double.NaN;
            int retIdx = startIdx;
            for (int idx = startIdx; idx < this.Count; idx++)
            {
                if (this._values[idx] > this._values[retIdx]) retIdx = idx;
            }
            return this._values[retIdx];
        }
        protected double FindMin(int startIdx)
        {
            if (startIdx < this.FirstValidValue) startIdx = this.FirstValidValue;
            if (startIdx >= this.Count) return double.NaN;
            int retIdx = startIdx;
            for (int idx = startIdx; idx < this.Count; idx++)
            {
                if (this._values[idx] < this._values[retIdx]) retIdx = idx;
            }
            return this._values[retIdx];
        }

        public enum CutState : byte { None = 0, Equal = 1, Up = 2, Down = 3 };
        /// <summary>
        /// Check if 2 series are cut 
        /// </summary>
        /// <param name="ds">Dataseriews to check against </param>
        /// <param name="position">Specufy the position to check</param>
        /// <returns></returns>
        public CutState Cut(DataSeries ds, int position)
        {
            if (position > this.Count || position > ds.Count ||
                position < this.FirstValidValue || position < ds.FirstValidValue) return CutState.None;
            //if (ds[position] == 0) return CutState.None;

            if (position == 0) return (this[0] == ds[0] ? CutState.Equal : CutState.None);

            if ((ds[position] == this[position - 1]) || (ds[position] == this[position])) return CutState.Equal;
            if ((ds[position - 1] < this[position]) && (ds[position] > this[position])) return CutState.Up;
            if ((ds[position - 1] > this[position]) && (ds[position] < this[position])) return CutState.Down;
            return CutState.None;
        }

        protected void Set(DataSeries d)
        {
            this._values = d._values;
            this.FirstValidValue = d.FirstValidValue;
        }

        public static DataSeries operator +(DataSeries d1, DataSeries d2)
        {
            DataSeries retVal = new DataSeries();
            if (d1.Count <= d2.Count)
            {
                for (int idx = 0; idx < d1.Count; idx++) retVal.Add(d1[idx] + d2[idx]);
                for (int idx = d1.Count; idx < d2.Count; idx++) retVal.Add(d2[idx]);
            }
            else
            {
                for (int idx = 0; idx < d2.Count; idx++) retVal.Add(d1[idx] + d2[idx]);
                for (int idx = d2.Count; idx < d1.Count; idx++) retVal.Add(d1[idx]);
            }
            retVal.FirstValidValue = d1.FirstValidValue;
            return retVal;
        }
        public static DataSeries operator -(DataSeries d1, DataSeries d2)
        {
            DataSeries retVal = new DataSeries();
            if (d1.Count <= d2.Count)
            {
                for (int idx = 0; idx < d1.Count; idx++) retVal.Add(d1[idx] - d2[idx]);
                for (int idx = d1.Count; idx < d2.Count; idx++) retVal.Add(-d2[idx]);
            }
            else
            {
                for (int idx = 0; idx < d2.Count; idx++) retVal.Add(d1[idx] - d2[idx]);
                for (int idx = d2.Count; idx < d1.Count; idx++) retVal.Add(-d1[idx]);
            }
            retVal.FirstValidValue = d1.FirstValidValue;
            return retVal;
        }
        public static DataSeries operator /(DataSeries ds, double d)
        {
            DataSeries retVal = new DataSeries();
            if (d != 0) for (int idx = 0; idx < ds.Count; idx++) retVal.Add(ds[idx] / d);
            else for (int idx = 0; idx < ds.Count; idx++) retVal.Add(0);
            retVal.FirstValidValue = ds.FirstValidValue;
            return retVal;
        }

        public static DataSeries operator *(double d, DataSeries ds)
        {
            DataSeries retVal = new DataSeries();
            for (int idx = 0; idx < ds.Count; idx++) retVal.Add(ds[idx] * d);
            retVal.FirstValidValue = ds.FirstValidValue;
            return retVal;
        }

        public static DataSeries operator /(DataSeries d1, DataSeries d2)
        {
            DataSeries retVal = new DataSeries();

            if (d1.Count <= d2.Count)
            {
                for (int idx = 0; idx < d1.Count; idx++)
                    if (d2[idx] != 0) retVal.Add(d1[idx] / d2[idx]);
                    else retVal.Add(0);
                for (int idx = d1.Count; idx < d2.Count; idx++) retVal.Add(d2[idx]);
            }
            else
            {
                for (int idx = 0; idx < d2.Count; idx++)
                    if (d2[idx] != 0) retVal.Add(d1[idx] / d2[idx]);
                    else retVal.Add(0);
                for (int idx = d2.Count; idx < d1.Count; idx++) retVal.Add(d1[idx]);
            }

            return retVal;
        }

        public static DataSeries operator *(DataSeries d1, DataSeries d2)
        {
            DataSeries retVal = new DataSeries();

            if (d1.Count <= d2.Count)
            {
                for (int idx = 0; idx < d1.Count; idx++)
                    retVal.Add(d1[idx] * d2[idx]);
                for (int idx = d1.Count; idx < d2.Count; idx++) retVal.Add(d2[idx]);
            }
            else
            {
                for (int idx = 0; idx < d2.Count; idx++)
                    retVal.Add(d1[idx] * d2[idx]);
                for (int idx = d2.Count; idx < d1.Count; idx++) retVal.Add(d1[idx]);
            }
            return retVal;
        }

        public static DataSeries operator >>(DataSeries ds, int n)
        {
            DataSeries retVal = new DataSeries();
            for (int idx = 0; idx < n; idx++) retVal.Add(0);
            for (int idx = 0; idx < ds.Count; idx++) retVal.Add(ds[idx]);
            retVal.FirstValidValue = ds.FirstValidValue + n;
            return retVal;
        }
        public static DataSeries operator <<(DataSeries ds, int n)
        {
            DataSeries retVal = new DataSeries();
            for (int idx = n; idx < ds.Count; idx++) retVal.Add(ds[idx]);
            retVal.FirstValidValue = ds.FirstValidValue - n;
            if (retVal.FirstValidValue < 0) retVal.FirstValidValue = 0;

            return retVal;
        }
    }
    public class DataBars
    {
        public DataBars() { }
        public DataBars(DataBars ds, string _name)
        {
            Open = new DataSeries(ds.Open, _name);
            High = new DataSeries(ds.High, _name);
            Low = new DataSeries(ds.Low, _name);
            Close = new DataSeries(ds.Close, _name);
            Volume = new DataSeries(ds.Volume, _name);
        }

        private int _FirstValidValue = 0;
        public int FirstValidValue
        {
            get { return _FirstValidValue; }
            set { _FirstValidValue = value; }
        }
        private string _Name = "";
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public common.DictionaryList Cache = new common.DictionaryList();

        public DataSeries Open = new DataSeries();
        public DataSeries High = new DataSeries();
        public DataSeries Low = new DataSeries();
        public DataSeries Close = new DataSeries();
        public DataSeries Volume = new DataSeries();
        public DataSeries DateTime = new DataSeries();
        public int Count
        {
            get
            {
                return High.Count;
            }
        }
        public void Add(double _open, double _high, double _low, double _close, double _volume, double _dateTime)
        {
            Open.Add(_open);
            High.Add(_high);
            Low.Add(_low);
            Close.Add(_close);
            Volume.Add(_volume);
            DateTime.Add(_dateTime);
            return;
        }
        public void Remove(int idx)
        {
            if (idx < 0 || idx > Count) return;
            Open.Remove(idx);
            High.Remove(idx);
            Low.Remove(idx);
            Close.Remove(idx);
            Volume.Remove(idx);
            DateTime.Remove(idx);
        }

        public static DataBars operator +(DataBars d1, DataBars d2)
        {
            DataBars retVal = new DataBars();
            retVal.Open = d1.Open + d2.Open;
            retVal.High = d1.High + d2.High;
            retVal.Low = d1.Low + d2.Low;
            retVal.Close = d1.Close + d2.Close;
            retVal.Volume = d1.Volume + d2.Volume;
            return retVal;
        }
        public static DataBars operator -(DataBars d1, DataBars d2)
        {
            DataBars retVal = new DataBars();
            retVal.Open = d1.Open - d2.Open;
            retVal.High = d1.High - d2.High;
            retVal.Low = d1.Low - d2.Low;
            retVal.Close = d1.Close - d2.Close;
            retVal.Volume = d1.Volume - d2.Volume;
            return retVal;
        }
        public static DataBars operator /(DataBars bar, int d)
        {
            if (d == 0) return bar;
            DataBars retVal = new DataBars();
            retVal.Open = bar.Open / d;
            retVal.High = bar.High / d;
            retVal.Low = bar.Low / d;
            retVal.Close = bar.Close / d;
            retVal.Volume = bar.Volume / d;
            return retVal;
        }
        public static DataBars operator >>(DataBars ds, int n)
        {
            DataBars retVal = new DataBars();
            retVal.Open = ds.Open >> n;
            retVal.High = ds.High >> n;
            retVal.Low = ds.Low >> n;
            retVal.Close = ds.Close >> n;
            retVal.Volume = ds.Volume >> n;
            retVal.DateTime = ds.DateTime >> n;
            return retVal;
        }
        public static DataBars operator <<(DataBars ds, int n)
        {
            DataBars retVal = new DataBars();
            retVal.Open = ds.Open << n;
            retVal.High = ds.High << n;
            retVal.Low = ds.Low << n;
            retVal.Close = ds.Close << n;
            retVal.Volume = ds.Volume << n;
            retVal.DateTime = ds.DateTime << n;
            return retVal;
        }
    }

    public class DataCategory
    {
        public string Code = "";
        public string Description = "";
        public DataCategory(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }

    public enum DataAccessMode : byte { Local, WebService };
    public enum PriceDataType : byte { High, Low, Open, Close, Volume, DateTime };
    public class BaseAnalysisData
    {
        public BaseAnalysisData()
        {
            this.DataTimeScale = commonClass.Settings.sysDefaultTimeScale;
            this.DataTimeRange = commonClass.AppTypes.TimeRanges.None;
            this.DataStockCode = "";
        }
        public BaseAnalysisData(commonClass.AppTypes.TimeRanges timeRange, 
                            commonClass.AppTypes.TimeScale timeScale, 
                            string stockCode, DataAccessMode accessMode)
        {
            this.DataTimeScale = timeScale;
            this.DataTimeRange = timeRange;
            this.DataStockCode = stockCode;
            this.AccessMode = accessMode;
            ClearCache();
            LoadData();
        }
        public DataAccessMode AccessMode = DataAccessMode.Local;

        // Maybe more data were read from DB, beyound the specified date/time.
        // The FirstDataStartAt specifies the possition the needed data starts
        public int FirstDataStartAt = 0;
        
        /// <summary>
        /// Make 2 data the same lenght and DateTime Index
        /// </summary>
        /// <param name="ds"> Changed data that will be the same lenght and date tme index) with this data</param>
        /// <returns></returns>
        public void Sync(BaseAnalysisData checkData)
        {
            int tmpIdx;
            double[] newClose = new double[this.DateTime.Count];
            double[] newOpen = new double[this.DateTime.Count];
            double[] newHigh = new double[this.DateTime.Count];
            double[] newLow = new double[this.DateTime.Count];
            double[] newVolume = new double[this.DateTime.Count];
            double[] newDateTime = new double[this.DateTime.Count];
            for (int idx = 0; idx < this.DateTime.Count; idx++)
            {
                tmpIdx = checkData.FindDate(this.DateTime[idx], idx);
                if (tmpIdx < 0)
                {
                    newClose[idx] = 0;
                    newOpen[idx] = 0;
                    newHigh[idx] = 0;
                    newLow[idx] = 0;
                    newVolume[idx] = 0;
                    newDateTime[idx] = this.DateTime[idx];
                }
                else
                {
                    newClose[idx] = checkData.Close[tmpIdx];
                    newOpen[idx] = checkData.Open[tmpIdx];
                    newHigh[idx] = checkData.High[tmpIdx];
                    newLow[idx] = checkData.Low[tmpIdx];
                    newVolume[idx] = checkData.Volume[tmpIdx];
                    newDateTime[idx] = checkData.DateTime[tmpIdx];
                }
            }
            checkData.Close.Values = newClose;
            checkData.Open.Values = newOpen;
            checkData.High.Values = newHigh;
            checkData.Low.Values = newLow;
            checkData.Volume.Values = newVolume;
            checkData.DateTime.Values = newDateTime;

            checkData.Bars.Close.Values = newClose;
            checkData.Bars.Open.Values = newOpen;
            checkData.Bars.High.Values = newHigh;
            checkData.Bars.Low.Values = newLow;
            checkData.Bars.Volume.Values = newVolume;
        }

        private int FindDate(double dtVal, int startIdx)
        {
            for (int idx = startIdx; idx < this.DateTime.Count; idx++)
            {
                if (this.DateTime[idx] == dtVal) return idx;
            }
            return -1;
        }
        private int FindDate(DateTime dt, int startIdx)
        {
            return FindDate(dt.ToOADate(), startIdx);
        }

        public data.baseDS.priceDataDataTable priceDataTbl = new data.baseDS.priceDataDataTable();

        public commonClass.AppTypes.TimeScale DataTimeScale = commonClass.Settings.sysDefaultTimeScale;
        public commonClass.AppTypes.TimeRanges DataTimeRange = commonClass.AppTypes.TimeRanges.None;
        public string DataStockCode = "";
        
        /// <summary>
        /// Load data to [priceDataTbl]
        /// </summary>
        public virtual void LoadData(){}
        /// <summary>
        /// Update data to the most recent from the last update.
        /// </summary>
        /// <returns>Number of updated items</returns>
        public virtual int UpdateDataFromLastTime() { return -1; }

        private common.DictionaryList dataCache = new common.DictionaryList();
        protected void ClearCache()
        {
            this.dataCache.Clear();
        }
        public commonClass.DataSeries DateTime
        {
            get
            {
                object obj = dataCache.Find("DateTime");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, PriceDataType.DateTime);
                dataCache.Add("DateTime", series);
                return series;
            }
        }
        public commonClass.DataSeries Close
        {
            get
            {
                object obj = dataCache.Find("Close");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, PriceDataType.Close);
                dataCache.Add("Close", series);
                return series;
            }
        }
        public commonClass.DataSeries High
        {
            get
            {
                object obj = dataCache.Find("High");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, PriceDataType.High);
                dataCache.Add("High", series);
                return series;
            }
        }
        public commonClass.DataSeries Low
        {
            get
            {
                object obj = dataCache.Find("Low");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, PriceDataType.Low);
                dataCache.Add("Low", series);
                return series;
            }
        }
        public commonClass.DataSeries Open
        {
            get
            {
                object obj = dataCache.Find("Open");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, PriceDataType.Open);
                dataCache.Add("Open", series);
                return series;
            }
        }
        public commonClass.DataSeries Volume
        {
            get
            {
                object obj = dataCache.Find("Volume");
                if (obj != null) return (commonClass.DataSeries)obj;
                commonClass.DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, PriceDataType.Volume);
                dataCache.Add("Volume", series);
                return series;
            }
        }
        public commonClass.DataBars Bars
        {
            get
            {
                object obj = dataCache.Find("Bars");
                if (obj != null) return (commonClass.DataBars)obj;
                commonClass.DataBars db = GetData(this.priceDataTbl, this.FirstDataStartAt);
                dataCache.Add("Bars", db);
                return db;
            }
        }

        private static commonClass.DataSeries GetData(data.baseDS.priceDataDataTable dataTbl, int startIdx, PriceDataType type)
        {
            commonClass.DataSeries ds = new commonClass.DataSeries();
            switch (type)
            {
                case PriceDataType.High:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        ds.Add((double)dataTbl[i].highPrice);
                    }
                    break;
                case PriceDataType.Low:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        ds.Add((double)dataTbl[i].lowPrice);
                    }
                    break;
                case PriceDataType.Open:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        ds.Add((double)dataTbl[i].openPrice);
                    }
                    break;
                case PriceDataType.Close:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        ds.Add((double)dataTbl[i].closePrice);
                    }
                    break;
                case PriceDataType.Volume:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted) continue;
                        ds.Add((double)dataTbl[i].volume);
                    }
                    break;

                case PriceDataType.DateTime:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                    {
                        if (dataTbl[i].RowState == System.Data.DataRowState.Deleted)
                            continue;
                        ds.Add(dataTbl[i].onDate.ToOADate());
                    }
                    break;
                default:
                    common.system.ThrowException("Invalid dataField in MakeDataList()"); break;
            }
            return ds;
        }
        private static commonClass.DataBars GetData(data.baseDS.priceDataDataTable dataTbl, int startIdx)
        {
            commonClass.DataBars bars = new commonClass.DataBars();
            for (int idx = startIdx; idx < dataTbl.Count; idx++)
            {
                bars.Add((double)dataTbl[idx].openPrice, (double)dataTbl[idx].highPrice,
                         (double)dataTbl[idx].lowPrice, (double)dataTbl[idx].closePrice,
                         (double)dataTbl[idx].volume, dataTbl[idx].onDate.ToOADate());
            }
            return bars;
        }
    }

    public class test
    {
        /// <summary>
        /// Update data to the most recent from the last update.
        /// </summary>
        /// <returns>Number of updated items</returns>
        public int UpdateDataFromLastTime()
        {
            int numberOfUpdate = 0;
            //switch (this.myDataAccessMode)
            //{
            //    case DataAccessMode.Local:
            //        numberOfUpdate = AppLibs.UpdateAnalysisData(this);
            //        break;
            //    case DataAccessMode.WebService:
            //        numberOfUpdate = DataAccess.Libs.UpdateAnalysisData(this);
            //        break;
            //}
            //this.dataCache.Clear();
            return numberOfUpdate;
        }
 
    }
}
