using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Reflection;
using ZedGraph;

namespace application
{
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
                for(int idx=0;idx<value.Length;idx++) this.Add(value[idx]);
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
        public static DataSeries operator /(DataSeries ds, int d)
        {
            DataSeries retVal = new DataSeries();
            if (d != 0) for (int idx = 0; idx < ds.Count; idx++) retVal.Add(ds[idx] / d);
            else for (int idx = 0; idx < ds.Count; idx++) retVal.Add(0);
            retVal.FirstValidValue = ds.FirstValidValue;
            return retVal;
        }
        public static DataSeries operator >>(DataSeries ds, int n)
        {
            DataSeries retVal = new DataSeries();
            for (int idx = 0; idx < n; idx++) retVal.Add(0);
            for (int idx = 0; idx < ds.Count; idx++) retVal.Add(ds[idx]);
            retVal.FirstValidValue = ds.FirstValidValue+n;
            return retVal;
        }
        public static DataSeries operator <<(DataSeries ds, int n)
        {
            DataSeries retVal = new DataSeries();
            for (int idx = n; idx < ds.Count; idx++) retVal.Add(ds[idx]);
            retVal.FirstValidValue = ds.FirstValidValue-n;
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
    public class Data
    {
        //Number of units to read ahead
        const int constNoUnitToReadAhead = 100;
        
        // Maybe more data were read from DB, beyound the specified date/time.
        // The FirstDataStartAt specifies the possition the needed data starts
        private int _firstDataStartAt = 0;
        public int FirstDataStartAt
        {
            get { return _firstDataStartAt;}
        }
        public Data()
        {
            this.priceDataTbl = new data.baseDS.priceDataDataTable();
            this.DataTimeScale = AppTypes.MainDataTimeScale;
            this.DataTimeRange = AppTypes.TimeRanges.None; 
            this.DataStockCode = "";
        }
        public Data(AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale,string stockCode)
        {
            this.priceDataTbl = new data.baseDS.priceDataDataTable();
            this.DataTimeScale = timeScale;
            this.DataTimeRange = timeRange;
            this.DataStockCode = stockCode;
            Clear();
            Reload();
        }
        public Data New(string stockCode)
        {
            Data newData = new Data();
            newData.DataTimeScale =  this.DataTimeScale;
            newData.DataTimeRange = this.DataTimeRange;
            newData.DataStockCode = stockCode;
            newData.Reload(); 
            return newData;
        }

        /// <summary>
        /// Make 2 data the same lenght and DateTime Index
        /// </summary>
        /// <param name="ds"> Changed data that will be the same lenght and date tme index) with this data</param>
        /// <returns></returns>
        public void Sync(Data checkData)
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
                    newClose[idx] = double.NaN;
                    newOpen[idx] = double.NaN;
                    newHigh[idx] = double.NaN;
                    newLow[idx] = double.NaN;
                    newVolume[idx] = double.NaN;
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
        private int FindDate(DateTime dt,int startIdx)
        {
            return FindDate(dt.ToOADate(),startIdx);
        }
       

        private global::data.baseDS.priceDataDataTable priceDataTbl = null;

        public AppTypes.TimeScale DataTimeScale = AppTypes.MainDataTimeScale;
        public AppTypes.TimeRanges DataTimeRange = AppTypes.TimeRanges.None;

        public string DataStockCode = "";

        public void Reload()
        {
            DateTime startDate = common.Consts.constNullDate;
            DateTime endDate = common.Consts.constNullDate;
            if(!AppTypes.GetDate(this.DataTimeRange,out startDate,out endDate)) return;
            Reload(this.DataStockCode, this.DataTimeScale, startDate, endDate);
        }

        public void Reload(string stockCode, AppTypes.TimeScale timeScale, DateTime startDate, DateTime endDate)
        {
            priceDataTbl.Clear();
            this._firstDataStartAt = 0;
            this.DataStockCode = stockCode;
            this.DataTimeScale = timeScale;
            LoadData(this.DataStockCode, startDate, endDate, this.DataTimeScale, constNoUnitToReadAhead,
                                   priceDataTbl, out this._firstDataStartAt);
            Clear();
        }

        private common.DictionaryList dataCache = new common.DictionaryList();
        private void Clear()
        {
            this.dataCache.Clear();
            //this._dateTime = null;
            //this._bars = null;
        }
        public DataSeries DateTime
        {
            get
            {
                object obj = dataCache.Find("DateTime");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, DataType.DateTime);
                dataCache.Add("DateTime", series);
                return series;
            }
        }
        public DataSeries Close
        {
            get
            {
                object obj = dataCache.Find("Close");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, DataType.Close);
                dataCache.Add("Close", series);
                return series;
            }
        }
        public DataSeries High
        {
            get
            {
                object obj = dataCache.Find("High");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, DataType.High);
                dataCache.Add("High", series);
                return series;
            }
        }
        public DataSeries Low
        {
            get
            {
                object obj = dataCache.Find("Low");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, DataType.Low);
                dataCache.Add("Low", series);
                return series;
            }
        }
        public DataSeries Open
        {
            get
            {
                object obj = dataCache.Find("Open");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, DataType.Open);
                dataCache.Add("Open", series);
                return series;
            }
        }
        public DataSeries Volume
        {
            get
            {
                object obj = dataCache.Find("Volume");
                if (obj != null) return (DataSeries)obj;
                DataSeries series = GetData(this.priceDataTbl, this.FirstDataStartAt, DataType.Volume);
                dataCache.Add("Volume", series);
                return series;
            }
        }
        public DataBars Bars
        {
            get
            {
                object obj = dataCache.Find("Bars");
                if (obj != null) return (DataBars)obj;
                DataBars db = GetData(this.priceDataTbl, this.FirstDataStartAt);
                dataCache.Add("Bars", db);
                return db;
            }
        }

        public enum DataType : byte { High, Low, Open, Close, Volume, DateTime };
        public static DataSeries GetData(data.baseDS.priceDataDataTable dataTbl, int startIdx, DataType type)
        {
            DataSeries ds = new DataSeries();
            switch (type)
            {
                case DataType.High:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].highPrice);
                    break;
                case DataType.Low:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].lowPrice);
                    break;
                case DataType.Open:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].openPrice);
                    break;
                case DataType.Close:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].closePrice);
                    break;
                case DataType.Volume:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add((double)dataTbl[i].volume);
                    break;

                case DataType.DateTime:
                    for (int i = startIdx, j = 0; i < dataTbl.Count; i++, j++)
                        ds.Add(dataTbl[i].onDate.ToOADate());
                    break;
                default:
                    common.system.ThrowException("Invalid dataField in MakeDataList()"); break;
            }
            return ds;
        }
        public static DataBars GetData(data.baseDS.priceDataDataTable dataTbl, int startIdx)
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


        /// <summary>
        /// Load stock price data withd some point ahead of the specified date range
        /// </summary>
        /// <param name="stockCode"></param>
        /// <param name="frDate">Start date </param>
        /// <param name="toDate">End date</param>
        /// <param name="timeScale">Time scale</param>
        /// <param name="noUnitAhead">the number of units(minute,day,hour,week...) to read beyond the start time[frDate].</param>
        /// <param name="toTbl">Table keeps loaded data</param>
        /// <param name="startIdx">specify the row where the data in [frDate,toDate] range starts</param>
        public static void LoadData(string stockCode, DateTime frDate, DateTime toDate, AppTypes.TimeScale timeScale, int noUnitAhead,
                                    data.baseDS.priceDataDataTable toTbl, out int startIdx)
        {
            
            startIdx = toTbl.Count;
            toTbl.Clear();
            if (noUnitAhead != 0 && 
                frDate != System.DateTime.MinValue && toDate != System.DateTime.MaxValue)
            {
                // Find start date that return sufficient rows as required by [noBarAhead]
                DateTime checkFrDate = common.Consts.constNullDate;
                DateTime checkToDate = frDate.AddSeconds(-1);
                int totalGotRowCount = 0, gotRowCount;
                decimal rangeScale = 1;
                //int loopPass = 0;
                while (true)
                {
                    //loopPass++;
                    switch (timeScale.Type)
                    {
                        case AppTypes.TimeScaleTypes.Minnute:
                            checkFrDate = checkToDate.AddMinutes(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Hour:
                            checkFrDate = checkToDate.AddHours(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Day:
                            checkFrDate = checkToDate.AddDays(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Week:
                            checkFrDate = checkToDate.AddDays(-(int)(7 * noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Month:
                            checkFrDate = checkToDate.AddMonths(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.Year:
                            checkFrDate = checkToDate.AddYears(-(int)(noUnitAhead * rangeScale));
                            break;
                        case AppTypes.TimeScaleTypes.RealTime:
                            checkFrDate = checkToDate.AddMinutes(-(int)(Settings.sysAutoRefreshInSeconds * noUnitAhead * rangeScale) / 60);
                            break;
                        default: common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }
                    gotRowCount = dataLibs.GetTotalPriceRow(timeScale, checkFrDate, checkToDate, stockCode);
                    //No more data ??
                    if (checkFrDate < Settings.sysStartDataDate)
                        break;
                    //Sufficient data ??
                    totalGotRowCount += gotRowCount;
                    if (totalGotRowCount >= noUnitAhead) break;

                    checkToDate = checkFrDate.AddSeconds(-1);
                    if (gotRowCount == 0) rangeScale = noUnitAhead;
                    else
                    {
                        if ((decimal)(noUnitAhead - totalGotRowCount) / gotRowCount > 0)
                            rangeScale = rangeScale * (decimal)(noUnitAhead - totalGotRowCount) / gotRowCount;
                        if (rangeScale < 1) rangeScale = 1;
                    }
                }
                dataLibs.LoadData(toTbl, timeScale.Code, checkFrDate, frDate.AddSeconds(-1), stockCode);
                startIdx = toTbl.Count - startIdx;
            }
            dataLibs.LoadData(toTbl, timeScale.Code, frDate, toDate, stockCode);
        }
    }

    public class DrawCurve
    {
        public DrawCurve(CurveItem _curve, string _curveName, GraphPane _pane, string _paneName)
        {
            CurveName = _curveName;
            PaneName = _paneName;
            Curve = _curve;
            Pane = _pane;
        }
        public string CurveName = "";
        public string PaneName = "";
        public CurveItem Curve = null;
        public GraphPane Pane = null;
        
    }
    public class CurveList
    {
        common.DictionaryList Cache = new common.DictionaryList();
        public DrawCurve Find(string curveName)
        {
            return (DrawCurve)this.Cache.Find(curveName);
        }
        //Return curves that its name starts with [namePrefix]
        public DrawCurve[] FindAll(string namePrefix)
        {
            DrawCurve[] drawCurveList = new DrawCurve[0];
            DrawCurve drawCurve;
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                drawCurve = (DrawCurve)items[idx];
                if (drawCurve.CurveName.StartsWith(namePrefix))
                {
                    Array.Resize(ref drawCurveList, drawCurveList.Length + 1);
                    drawCurveList[drawCurveList.Length - 1] = drawCurve;
                }
            }
            return drawCurveList;
        }
        public void Add(CurveItem curve, string curveName, GraphPane pane, string paneName)
        {
            this.Cache.Add(curveName, new DrawCurve(curve,curveName,pane,paneName));
        }
        public void Remove(string curveName)
        {
            Remove(curveName, false);
        }
        public void Remove(string curveName, bool startWith)
        {
            DrawCurve drawCurve;
            if (!startWith)
            {
                drawCurve = Find(curveName);
                if (drawCurve != null) drawCurve.Pane.CurveList.Remove(drawCurve.Curve);
                this.Cache.Remove(curveName);
            }
            else
            {
                object[] items = Cache.Values;
                for (int idx = 0; idx < items.Length; idx++)
                {
                    drawCurve = (DrawCurve)items[idx];
                    if (drawCurve.CurveName.StartsWith(curveName))
                    {
                        drawCurve.Pane.CurveList.Remove(drawCurve.Curve);
                        this.Cache.Remove(drawCurve.CurveName);
                    }
                }
            }
        }
        public void RemoveByPane(string paneName)
        {
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                if (drawCurve.PaneName != paneName) continue;
                Remove(drawCurve.CurveName);
            }
        }
        public void RemoveAll()
        {
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                drawCurve.Pane.CurveList.Remove(drawCurve.Curve);
            }
            this.Cache.Clear();
        }
     
        public int NumberOfCurves(string paneName)
        {
            int count = 0;
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                if (drawCurve.PaneName == paneName) count++;
            }
            return count;
        }

        public CurveItem PlotCurveLine(GraphPane graphPane, string graphPaneName, DataSeries xSeries, DataSeries ySeries,
                                       Color color, int weight, string curveName)
        {
            CurveItem curveItem = AppLibs.PlotChartLine(graphPane, xSeries, ySeries, "", SymbolType.None, color, weight);
            this.Add(curveItem,curveName,graphPane,graphPaneName);
            return curveItem;
        }
        public CurveItem PlotCurveBar(GraphPane graphPane,string graphPaneName, DataSeries xSeries, DataSeries ySeries,
                                      Color color, Color borderCl, int weight, string curveName)
        {
            CurveItem curveItem = AppLibs.PlotChartBar(graphPane, xSeries, ySeries, "", color, borderCl, weight);
            this.Add(curveItem, curveName, graphPane, graphPaneName);
            return curveItem;
        }

        public CurveItem PlotCurveCandle(GraphPane graphPane, string graphPaneName, Data myData,
                                         Color color, Color stickColor, Color risingColor, Color fallingColor, string curveName)
        {
            CurveItem curveItem = AppLibs.PlotChartCandleStick(graphPane, myData.DateTime, myData.Bars, "",
                                                    color, stickColor,risingColor, fallingColor);
            this.Add(curveItem, curveName, graphPane, graphPaneName);
            return curveItem;
        }
    }

    /// <summary>
    /// The class provides functions for market indicators
    /// See http://www.onlinetradingconcepts.com/TechnicalAnalysis/MarketThrust.html
    /// </summary>
    public class MarketData
    {
        private enum DataTypes : byte { Advancing, Declining, NonChange };
        private enum DataFields : byte { Count, Volume, DateTime };
        private common.DictionaryList Cache = new common.DictionaryList();
        private DateTime StartDateTime = common.Consts.constNullDate, EndDateTime = common.Consts.constNullDate;
        private AppTypes.TimeScale TimeScale = AppTypes.MainDataTimeScale;
        private string StockCodeList = null;

        private static void LoadData(DateTime frDate, DateTime toDate, AppTypes.TimeScale timeScale, string stockCodeList,
                                     DataTypes type, data.tmpDS.marketDataDataTable toTbl)
        {
            string sqlCond = "";
            if (timeScale != AppTypes.MainDataTimeScale)
            {
                sqlCond += (sqlCond == "" ? "" : " AND ") + " type='" + timeScale.Code + "'";
            }
            sqlCond += (sqlCond == "" ? "" : " AND ") +
                        "onDate BETWEEN '" + common.system.ConvertToSQLDateString(frDate) + "'" +
                        " AND '" + common.system.ConvertToSQLDateString(toDate) + "'";

            sqlCond += (sqlCond == "" ? "" : " AND ");
            switch (type)
            {
                case DataTypes.Advancing: sqlCond += "closePrice>openPrice"; break;
                case DataTypes.Declining: sqlCond += "closePrice<openPrice"; break;
                default: sqlCond += "closePrice=openPrice"; break;
            }

            if (stockCodeList != null && stockCodeList != "")
            {
                sqlCond += (sqlCond == "" ? "" : " AND ") + " stockCode IN  (" + stockCodeList + ")";
            }
            else
            {
                sqlCond += (sqlCond == "" ? "" : " AND ") + 
                    " stockCode IN  (SELECT code FROM stockCode WHERE status & " + ((byte)AppTypes.CommonStatus.Enable).ToString() + ">0)";
            }
            string sqlCmd =
                "SELECT onDate,COUNT(*) AS val0,SUM(volume) AS val1" +
                " FROM " + (timeScale == AppTypes.MainDataTimeScale ? "priceData" : "priceDataSum") +
                " WHERE " + sqlCond +
                " GROUP BY onDate ORDER BY onDate";
            toTbl.Clear();
            dataLibs.LoadFromSQL(toTbl, sqlCmd);
        }
        private static DataSeries MakeData(data.tmpDS.marketDataDataTable dataTbl, DataFields type)
        {
            DataSeries ds = new DataSeries();
            switch (type)
            {
                case DataFields.Count:
                    for (int idx = 0; idx < dataTbl.Count; idx++) ds.Add(dataTbl[idx].val0); break;
                case DataFields.Volume:
                    for (int idx = 0; idx < dataTbl.Count; idx++) ds.Add(dataTbl[idx].val1); break;
                case DataFields.DateTime:
                    for (int idx = 0; idx < dataTbl.Count; idx++) ds.Add(dataTbl[idx].onDate.ToOADate()); break;
            }
            return ds;
        }
        private void Init(DateTime startDateTime, DateTime endDateTime, AppTypes.TimeScale timeScale, StringCollection stockCodes)
        {
            this.Cache.Clear();
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            if (stockCodes != null && stockCodes.Count != 0)
                this.StockCodeList = common.system.MakeConditionStr(stockCodes, "'", "'", ",");
            else this.StockCodeList = null;
            this.TimeScale = timeScale;
        }

        //Constructors
        private MarketData(DateTime startDateTime, DateTime endDateTime, AppTypes.TimeScale timeScale, StringCollection stockCodes)
        {
            this.Init(startDateTime, endDateTime, timeScale, stockCodes);
        }
        private MarketData(DateTime startDateTime, DateTime endDateTime, AppTypes.TimeScale timeScale)
        {
            this.Init(startDateTime, endDateTime, timeScale, null);
        }

        /// <summary>
        /// Constructors to create a market indicator's data for all enable stock
        /// </summary>
        /// <param name="timeRange"></param>
        /// <param name="timeScale"></param>
        public MarketData(AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            DateTime startDate = DateTime.Today, endDate = DateTime.Today;
            AppTypes.GetDate(timeRange, out startDate, out endDate);
            this.Init(startDate, endDate, timeScale, null);
        }

        /// <summary>
        /// Constructors to create a market indicator's data for specific stock list
        /// </summary>
        /// <param name="timeRange"></param>
        /// <param name="timeScale"></param>
        /// <param name="stockCodes"></param>
        public MarketData(AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale, StringCollection stockCodes)
        {
            DateTime startDate = DateTime.Today, endDate = DateTime.Today;
            AppTypes.GetDate(timeRange, out startDate, out endDate);
            this.Init(startDate, endDate, timeScale, stockCodes);
        }
        public MarketData(application.Data data, StringCollection stockCodes)
        {
            DateTime startDate = DateTime.Today, endDate = DateTime.Today;
            AppTypes.GetDate(data.DataTimeRange, out startDate, out endDate);
            this.Init(startDate,endDate,data.DataTimeScale, stockCodes);
        }
        public MarketData(application.Data data)
        {
            DateTime startDate = DateTime.Today, endDate = DateTime.Today;
            AppTypes.GetDate(data.DataTimeRange, out startDate, out endDate);
            this.Init(startDate, endDate, data.DataTimeScale, null);

        }

        public DataSeries AdvancingIssues
        {
            get
            {
                object dataObj = Cache.Find("data-advancing");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Advancing, dataTbl);
                    Cache.Add("data-advancing",dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("AdvancingIssues");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.Count);
                Cache.Add("AdvancingIssues", ds);
                return ds;
            }
        }
        public DataSeries AdvancingVolume
        {
            get
            {
                object dataObj = Cache.Find("data-advancing");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Advancing, dataTbl);
                    Cache.Add("data-advancing", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("AdvancingVolume");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.Volume);
                Cache.Add("AdvancingVolume", ds);
                return ds;

            }
        }
        public DataSeries AdvancingDateTime
        {
            get
            {
                object dataObj = Cache.Find("data-advancing");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Advancing, dataTbl);
                    Cache.Add("data-advancing", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("AdvancingDateTime");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.DateTime);
                Cache.Add("AdvancingDateTime", ds);
                return ds;

            }
        }

        public DataSeries DecliningIssues
        {
            get
            {
                object dataObj = Cache.Find("data-declining");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Declining, dataTbl);
                    Cache.Add("data-declining", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("DecliningIssues");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.Count);
                Cache.Add("DecliningIssues", ds);
                return ds;
            }
        }
        public DataSeries DecliningVolume
        {
            get
            {
                data.tmpDS.marketDataDataTable dataTbl = null;
                object dataObj = Cache.Find("data-declining");
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Declining, dataTbl);
                    Cache.Add("data-declining", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("DecliningVolume");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.Volume);
                Cache.Add("DecliningVolume", ds);
                return ds;
            }
        }
        public DataSeries DecliningDateTime
        {
            get
            {
                data.tmpDS.marketDataDataTable dataTbl = null;
                object dataObj = Cache.Find("data-declining");
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.Declining, dataTbl);
                    Cache.Add("data-declining", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("DecliningDateTime");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.DateTime);
                Cache.Add("DecliningDateTime", ds);
                return ds;
            }
        }

        public DataSeries NonChangeIssues
        {
            get
            {
                object dataObj = Cache.Find("data-NonChange");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.NonChange, dataTbl);
                    Cache.Add("data-NonChange", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;


                object obj = Cache.Find("NonChangeIssues");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.Count);
                Cache.Add("NonChangeIssues", ds);
                return ds;
            }
        }
        public DataSeries NonChangeVolume
        {
            get
            {
                object dataObj = Cache.Find("data-NonChange");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.NonChange, dataTbl);
                    Cache.Add("data-NonChange", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("NonChangeVolume");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.Volume);
                Cache.Add("NonChangeVolume", ds);
                return ds;
            }
        }
        public DataSeries NonChangeDateTime
        {
            get
            {
                object dataObj = Cache.Find("data-NonChange");
                data.tmpDS.marketDataDataTable dataTbl = null;
                if (dataObj == null)
                {
                    dataTbl = new data.tmpDS.marketDataDataTable();
                    LoadData(this.StartDateTime, this.EndDateTime, this.TimeScale, StockCodeList, DataTypes.NonChange, dataTbl);
                    Cache.Add("data-NonChange", dataObj);
                }
                else dataTbl = (data.tmpDS.marketDataDataTable)dataObj;

                object obj = Cache.Find("NonChangeDateTime");
                if (obj != null) return (DataSeries)obj;
                DataSeries ds = MakeData(dataTbl, DataFields.DateTime);
                Cache.Add("NonChangeDateTime", ds);
                return ds;
            }
        }

        /// <summary>
        /// Sample code for Market class
        /// </summary>
        private class Samples
        {
            //Create from analysis data for all enable stocks
            private MarketData Create1()
            {
                application.Data stockData = new application.Data(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"), "SSI");
                return new MarketData(stockData);
            }

            //Create from analysis data for stocks : ACB, FPT
            private MarketData Create2()
            {
                StringCollection list = new StringCollection();
                list.AddRange(new string[] { "ACB", "FPT" });

                application.Data stockData = new application.Data(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"), "SSI");
                return new MarketData(stockData);
            }

            //Create in specific time range and time scale for stocks : ACB, FPT
            private MarketData Create3()
            {
                StringCollection list = new StringCollection();
                list.AddRange(new string[]{"ACB","FPT"});
                return new MarketData(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"), list);
            }
            
            //Get market indicator series
            private void Access(MarketData data)
            {
                DataSeries ds;
                ds = data.AdvancingIssues;
                ds = data.AdvancingVolume;
                ds = data.AdvancingDateTime;

                ds = data.DecliningIssues;
                ds = data.DecliningVolume;

                ds = data.NonChangeIssues;
                ds = data.NonChangeVolume;
            }
        }
    }
}
