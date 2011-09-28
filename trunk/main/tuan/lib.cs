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
        
        public static JapaneseCandleStickItem PlotChartCandleStick(GraphPane myPane, data.baseDS.priceDataDataTable data, string title,
                                                                   Color color, Color stickColor, Color fallingColor)
        {
            StockPointList spl = new StockPointList();
            List<DateTime> lst = new List<DateTime>();
            for (int idx = 0; idx < data.Count; idx++)
            {                
                    lst.Add(data[idx].onDate);
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
            myPane.XAxis.Type = AxisType.DateAsOrdinal;                       
            _parent.AxisChange();
            _parent.Refresh();                       
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
            myPane.XAxis.Type = AxisType.DateAsOrdinal;            
            
            return ohlcBarItem;    
        }
        public static BarItem PlotVolumeChart(GraphPane myPane, data.baseDS.priceDataDataTable data, string title, Color color)
        {
            PointPairList ppl = new PointPairList();
            for (int idx = 0; idx < data.Count; idx++)
            {
                PointPair pp = new PointPair(new XDate(data[idx].onDate), (double)data[idx].volume/1000000);
                ppl.Add(pp);
            }
            BarItem barItem = myPane.AddBar(title, ppl, color);
            myPane.XAxis.Type = AxisType.DateAsOrdinal;
            
            return barItem;  
        }
    }
}
