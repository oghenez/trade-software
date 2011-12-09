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
        public double[] Values
        {
            get { return _values; }
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
        /// <param name="ds"></param>
        /// <returns></returns>
        public CutState Cut(DataSeries ds)
        {
            for (int idx1 = this.FirstValidValue + 1, idx2 = ds.FirstValidValue; 
                 idx1 < this.Count && idx2 < ds.Count; idx1++, idx2++)
            {
                //Cut equal
                if ( (this[idx1 - 1] == ds[idx2]) || (this[idx1] == ds[idx2])) return CutState.Equal;
                //Cut up 
                if ((this[idx1-1] < ds[idx2]) && (this[idx1] > ds[idx2])) return CutState.Up;
                //Cut down
                if ((this[idx1 - 1] > ds[idx2]) && (this[idx1] < ds[idx2])) return CutState.Down;
            }
            return CutState.None; 
        }

        public DataSeries Clone()
        {
            DataSeries series = new DataSeries();
            series.Set(this);
            return series;
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
        //public Dictionary<string, DataSeries> Cache = new Dictionary<string, DataSeries>();
        public common.DictionaryList Cache = new common.DictionaryList();

        public DataSeries Open = new DataSeries();
        public DataSeries High = new DataSeries();
        public DataSeries Low = new DataSeries();
        public DataSeries Close = new DataSeries();
        public DataSeries Volume = new DataSeries();
        public int Count
        {
            get
            {
                return High.Count;
            }
        }
        public void Add(double _open, double _high, double _low, double _close, double _volume)
        {
            Open.Add(_open);
            High.Add(_high);
            Low.Add(_low);
            Close.Add(_close);
            Volume.Add(_volume);
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
        public static DataBars operator /(DataBars ds, int d)
        {
            DataBars retVal = new DataBars();
            retVal.Open = ds.Open / d;
            retVal.High = ds.High / d;
            retVal.Low = ds.Low / d;
            retVal.Close = ds.Close / d;
            retVal.Volume = ds.Volume / d;
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
            return retVal;
        }
    }
    public class Data
    {
        //Number of units to read ahead
        const int constNoUnitToReadAhead = 100;
        
        // Maybe more data were read from DB, beyound the specified date/time.
        // The NeedDataStartAt specifies the possition the needed data starts
        private int NeedDataStartAt = 0;

        public Data(global::data.baseDS.priceDataDataTable tbl)
        {
            this.priceDataTbl = tbl;
            Clear();
        }
        private global::data.baseDS.priceDataDataTable priceDataTbl = null;
        public myTypes.TimeScale DataTimeScale = application.myTypes.MainDataTimeScale;
        public DateTime DataStartDate = common.Consts.constNullDate;
        public DateTime DataEndDate = common.Consts.constNullDate;
        public string DataStockCode = "";

        public void Reload()
        {
            priceDataTbl.Clear();
            //application.dataLibs.LoadData(this.priceDataTbl, this.DataTimeScale.Code,
            //                              this.DataStartDate, this.DataEndDate, this.DataStockCode);

            int startIdx=0;
            LoadData(this.DataStockCode,this.DataStartDate, this.DataEndDate,this.DataTimeScale, constNoUnitToReadAhead,
                                   priceDataTbl, out startIdx);
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
                DataSeries series = GetData(this.priceDataTbl, this.NeedDataStartAt, DataType.DateTime);
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
                DataSeries series = GetData(this.priceDataTbl, this.NeedDataStartAt, DataType.Close);
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
                DataSeries series = GetData(this.priceDataTbl, this.NeedDataStartAt, DataType.High);
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
                DataSeries series = GetData(this.priceDataTbl, this.NeedDataStartAt, DataType.Low);
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
                DataSeries series = GetData(this.priceDataTbl, this.NeedDataStartAt, DataType.Open);
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
                DataSeries series = GetData(this.priceDataTbl, this.NeedDataStartAt, DataType.Volume);
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
                DataBars db = GetData(this.priceDataTbl, this.NeedDataStartAt);
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
                         (double)dataTbl[idx].lowPrice, (double)dataTbl[idx].closePrice, (double)dataTbl[idx].volume);
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
        public static void LoadData(string stockCode, DateTime frDate, DateTime toDate, myTypes.TimeScale timeScale, int noUnitAhead,
                                    data.baseDS.priceDataDataTable toTbl, out int startIdx)
        {
            startIdx = toTbl.Count;
            toTbl.Clear();
            if (noUnitAhead != 0)
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
                        case myTypes.TimeScaleTypes.Minnute:
                            checkFrDate = checkToDate.AddMinutes(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.TimeScaleTypes.Hour:
                            checkFrDate = checkToDate.AddHours(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.TimeScaleTypes.Day:
                            checkFrDate = checkToDate.AddDays(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.TimeScaleTypes.Week:
                            checkFrDate = checkToDate.AddDays(-(int)(7 * noUnitAhead * rangeScale));
                            break;
                        case myTypes.TimeScaleTypes.Month:
                            checkFrDate = checkToDate.AddMonths(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.TimeScaleTypes.Year:
                            checkFrDate = checkToDate.AddYears(-(int)(noUnitAhead * rangeScale));
                            break;
                        case myTypes.TimeScaleTypes.RealTime:
                            checkFrDate = checkToDate.AddMinutes(-(int)(application.Settings.sysAutoRefreshInSeconds * noUnitAhead * rangeScale) / 60);
                            break;
                        default: common.system.ThrowException("Invalid parametter in calling to LoadStockPrice()");
                            break;
                    }
                    gotRowCount = dataLibs.GetTotalPriceRow(timeScale, checkFrDate, checkToDate, stockCode);
                    //No more data ??
                    if (checkFrDate < application.Settings.sysStartDataDate) break;
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
            object[] items = Cache.Items;
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
                object[] items = Cache.Items;
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
            object[] items = Cache.Items;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                if (drawCurve.PaneName != paneName) continue;
                Remove(drawCurve.CurveName);
            }
        }
        public void RemoveAll()
        {
            object[] items = Cache.Items;
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
            object[] items = Cache.Items;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                if (drawCurve.PaneName == paneName) count++;
            }
            return count;
        }

        public CurveItem PlotCurveLine(GraphPane graphPane, string graphPaneName, DataSeries xSeries, DataSeries ySeries,
                                       Color color, byte weight, string curveName)
        {
            CurveItem curveItem = libs.PlotChartLine(graphPane, xSeries, ySeries, "", SymbolType.None, color, weight);
            this.Add(curveItem,curveName,graphPane,graphPaneName);
            return curveItem;
        }
        public CurveItem PlotCurveBar(GraphPane graphPane,string graphPaneName, DataSeries xSeries, DataSeries ySeries,
                                      Color color, Color borderCl, byte weight, string curveName)
        {
            CurveItem curveItem = libs.PlotChartBar(graphPane, xSeries, ySeries, "", color, borderCl, weight);
            this.Add(curveItem, curveName, graphPane, graphPaneName);
            return curveItem;
        }

        public CurveItem PlotCurveCandle(GraphPane graphPane, string graphPaneName, Data myData,
                                         Color color, Color stickColor, Color risingColor, Color fallingColor, string curveName)
        {
            CurveItem curveItem = libs.PlotChartCandleStick(graphPane, myData.DateTime, myData.Bars, "",
                                                    color, stickColor,risingColor, fallingColor);
            this.Add(curveItem, curveName, graphPane, graphPaneName);
            return curveItem;
        }
    }

    public class libs
    {
        #region Chart

        public static LineItem PlotChartLine(GraphPane myPane, DataSeries seriesX, DataSeries seriesY, string title, SymbolType symbol, Color color, int width)
        {
            DataSeries newSeriesY = seriesY.Clone() << seriesY.FirstValidValue;
            DataSeries newSeriesX = seriesX.Clone() << seriesX.FirstValidValue;
            LineItem myCurve = myPane.AddCurve(title, newSeriesX.Values, newSeriesY.Values, color, symbol);
            myCurve.Line.Width = width;
            myCurve.Symbol.Size = width + 1;
            return myCurve;
        }
        public static BarItem PlotChartBar(GraphPane myPane, DataSeries seriesX, DataSeries seriesY, string title, Color color, Color borderColor, int width)
        {
            BarItem myCurve = myPane.AddBar(title, seriesX.Values, seriesY.Values, color);
            myCurve.Bar.Border.Color = borderColor;
            myCurve.Bar.Fill.Color = color;
            myCurve.Bar.Border.Width = width;
            return myCurve;
        }
        public static StickItem PlotChartStick(GraphPane myPane, DataSeries seriesX, DataSeries seriesY, string title, Color color)
        {
            StickItem myCurve = myPane.AddStick(title, seriesX.Values, seriesY.Values, color);
            return myCurve;
        }
        public static JapaneseCandleStickItem PlotChartCandleStick(GraphPane myPane, DataSeries seriesX, DataBars seriesY, string title,
                                                                   Color color, Color stickColor, Color risingColor, Color fallingColor)
        {
            StockPointList spl = new StockPointList();
            for (int idx = 0; idx < seriesX.Count; idx++)
            {
                StockPt pt = new StockPt(seriesX.Values[idx], seriesY.High.Values[idx],
                                         seriesY.Low.Values[idx], seriesY.Open.Values[idx],
                                         seriesY.Close.Values[idx], seriesY.Volume.Values[idx]);
                spl.Add(pt);
            }

            JapaneseCandleStickItem myCurve = myPane.AddJapaneseCandleStick(title, spl);
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.Color = stickColor;

            myCurve.Color = color;
            
            myCurve.Stick.FallingColor = fallingColor;
            //myCurve.Stick.FallingFill.Color = fallingColor;
            //myCurve.Stick.FallingBorder.Color = fallingColor;

            //myCurve.Stick.RisingBorder.Color = fallingColor;
            myCurve.Stick.RisingFill.Color = risingColor;
            return myCurve;
        }
        #endregion Chart
    }
}
