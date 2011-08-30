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

    /// <summary>
    /// Data Series class
    /// </summary>
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

        public DataSeries(double[] ds, string _name)
        {
            _values = new double[ds.Length];
            Name = _name;
            for (int idx = 0; idx < _values.Length; idx++) _values[idx] = ds[idx];
        }

        public string Name = "";
        private double[] _values = null;
        public Dictionary<string, DataSeries> Cache = new Dictionary<string, DataSeries>();

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
        public double FindMax(int startIdx)
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
        public double FindMin(int startIdx)
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

        public DataSeries Clone()
        {
            DataSeries series = new DataSeries();
            series.Set(this);
            return series;
        }
        public void Set(DataSeries d)
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
            retVal.FirstValidValue = ds.FirstValidValue;
            return retVal;
        }
        public static DataSeries operator <<(DataSeries ds, int n)
        {
            DataSeries retVal = new DataSeries();
            for (int idx = n; idx < ds.Count; idx++) retVal.Add(ds[idx]);
            retVal.FirstValidValue = ds.FirstValidValue;
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
        public Dictionary<string, DataSeries> Cache = new Dictionary<string, DataSeries>();

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

    public class DataCache
    {
        private Dictionary<string, object> Cache = new Dictionary<string, object>();
        public DataCache(){}
        public object Find(string key)
        {
            if (this.Cache.ContainsKey(key))
            {
                return this.Cache[key];
            }
            return null;
        }
        public void Add(string key,object obj)
        {
            this.Cache[key] = obj;
        }
        public void Remove(string key, object obj)
        {
            if (this.Find(key) == null) return;
            this.Cache.Remove(key);
        }
        public void Clear()
        {
            this.Cache.Clear();
        }
    }

    public class libs
    {
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
    }

    public class chartLibs
    {
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
            BarItem myCurve = myPane.AddBar(title,seriesX.Values, seriesY.Values, color);
            myCurve.Bar.Border.Color = borderColor;
            myCurve.Bar.Border.Width = width; 
            return myCurve;
        }
        public static StickItem PlotChartStick(GraphPane myPane, DataSeries seriesX, DataSeries seriesY, string title, Color color)
        {
            StickItem myCurve = myPane.AddStick(title, seriesX.Values, seriesY.Values, color);
            return myCurve;
        }
        public static JapaneseCandleStickItem PlotChartCandleStick(GraphPane myPane, DataSeries seriesX, DataBars seriesY,string title,
                                                                   Color color, Color stickColor, Color fallingColor)
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
            myCurve.Stick.FallingColor = fallingColor;
            myCurve.Color = color;
            return myCurve;
        }

       
    }
}
