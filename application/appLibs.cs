using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ZedGraph;

namespace application
{
   
    public class AppLibs
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
