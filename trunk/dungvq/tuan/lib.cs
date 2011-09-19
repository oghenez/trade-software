using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ZedGraph;

namespace test
{
    public class chart
    {
        public static ZedGraphControl _parent;
        public static PointPairList MakePointPairList(double[] dataX, double[] dataY)
        {
            PointPairList list = new PointPairList();
            for (int idx = 0; idx < Math.Min(dataX.Length, dataY.Length); idx++)
            {
                list.Add(dataX[idx], dataY[idx]);
            }
            return list;
        }
        public enum stockDataField : byte { OnDate, High, Low, Open, Close, Volume };
        public static PointPairList MakePointPairList(data.baseDS.priceDataDataTable data, stockDataField valueType)
        {
            PointPairList list = new PointPairList();
            switch (valueType)
            {
                case stockDataField.Close:
                    for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].closePrice);
                    break;
                case stockDataField.Open:
                    for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].openPrice);
                    break;
                case stockDataField.Low:
                    for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].lowPrice);
                    break;
                case stockDataField.High:
                    for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].highPrice);
                    break;
                case stockDataField.Volume:
                    for (int idx = 0; idx < data.Count; idx++) list.Add(new XDate(data[idx].onDate), (double)data[idx].volume);
                    break;
                default:
                    common.system.ThrowException("Invalid valueType in MakePointPairList()");
                    break;
            }
            return list;
        }

        public static JapaneseCandleStickItem PlotChartCandleStick(GraphPane myPane, data.baseDS.priceDataDataTable data, string title,
                                                                   Color color, Color stickColor, Color fallingColor)
        {
            StockPointList spl = new StockPointList();
            for (int idx = 0; idx < data.Count; idx++)
            {
                StockPt pt = new StockPt(new XDate(data[idx].onDate), (double)data[idx].highPrice,
                                         (double)data[idx].lowPrice, (double)data[idx].openPrice,
                                         (double)data[idx].closePrice, (double)data[idx].volume);
                spl.Add(pt);
            }

            JapaneseCandleStickItem myCurve = myPane.AddJapaneseCandleStick(title, spl);
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.Color = stickColor;
            myCurve.Stick.FallingColor = fallingColor;
            myCurve.Color = color;
            myPane.XAxis.Type = AxisType.Date;

            _parent.AxisChange();
            _parent.Refresh();
            //myPane.XAxis.Scale.Min = 1.0f;

            // Use Date to skip weekend gaps
            //myPane.XAxis.Type = AxisType.Date;
            //myPane.XAxis.Scale.Min = new XDate(2006, 1, 1);

            // pretty it up a little
            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            //myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);
            return myCurve;
        }
        public static ZedGraph.LineItem PlotLineChart(GraphPane myPane, data.baseDS.priceDataDataTable data, string title,
                                                                   Color color, Color stickColor, Color fallingColor)
        {
            PointPairList ppl = new PointPairList();
            for (int idx = 0; idx < data.Count; idx++)
            {
                PointPair pp = new PointPair(new XDate(data[idx].onDate), (double)data[idx].closePrice);
                ppl.Add(pp);
            }
            LineItem myCurve = myPane.AddCurve("Volume", ppl, Color.FromArgb(160, 230, 145, 205));
            myCurve.Line.Color = stickColor;
            myCurve.Color = color;
            myCurve.Line.IsSmooth = true;
            myCurve.Line.SmoothTension = 0.1F;
            myCurve.Line.Width = 1.5F;
            myCurve.Line.Fill.IsVisible = false;
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.MinorGrid.IsVisible = true;
            return myCurve;
        }
        public static ZedGraph.BarItem PlotBarChart(GraphPane myPane, data.baseDS.priceDataDataTable data, string title, Color color)
        {
            PointPairList ppl = new PointPairList();
            for (int idx = 0; idx < data.Count; idx++)
            {
                PointPair pp = new PointPair(new XDate(data[idx].onDate), (double)data[idx].openPrice);
                ppl.Add(pp);
            }
            BarItem barItem = myPane.AddBar(title, ppl, color);
            return barItem;
        }
        public static OHLCBarItem PlotOHLCBar(GraphPane myPane, data.baseDS.priceDataDataTable data, string title, Color color)
        {
            StockPointList spl = new StockPointList();
            for (int idx = 0; idx < data.Count; idx++)
            {
                StockPt pt = new StockPt(new XDate(data[idx].onDate), (double)data[idx].highPrice,
                                         (double)data[idx].lowPrice, (double)data[idx].openPrice,
                                         (double)data[idx].closePrice, (double)data[idx].volume);
                spl.Add(pt);
            }
            OHLCBarItem ohlcBarItem = myPane.AddOHLCBar(title, spl, color);
            ohlcBarItem.Bar.IsAutoSize = true;
            // Use Date to skip weekend gaps
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.AxisGap = 1;

            return ohlcBarItem;
        }
        public static BarItem PlotVolumeChart(GraphPane myPane, data.baseDS.priceDataDataTable data, string title, Color color)
        {
            PointPairList ppl = new PointPairList();
            for (int idx = 0; idx < data.Count; idx++)
            {
                PointPair pp = new PointPair(new XDate(data[idx].onDate), (double)data[idx].volume / 1000000);
                ppl.Add(pp);
            }
            BarItem barItem = myPane.AddBar(title, ppl, color);
            myPane.XAxis.Type = AxisType.Date;

            return barItem;
        }
    }
}
