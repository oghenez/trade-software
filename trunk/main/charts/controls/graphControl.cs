using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Charts.Controls
{
    public enum myAxisType :byte
    {
        DateAsOrdinal = 0, Linear = 1
    }
    public class IntRange
    {
        public int Max = int.MinValue, Min = int.MaxValue;
        public IntRange() { }
        public IntRange(int min, int max)
        {
            Min = min; Max = max;
        }
        public void Reset()
        {
            this.Max = int.MaxValue;
            this.Min = int.MinValue;
        }
        public void Set(int min, int max)
        {
            this.Max = max;
            this.Min = min;
        }
    }
    public class ValueRange
    {
        public double Max = double.MinValue, Min = double.MaxValue;
        public ValueRange() { }
        public ValueRange(double min, double max)
        {
            Min = min; Max = max;
        }
        public void Reset()
        {
            this.Max = double.MaxValue;
            this.Min = double.MinValue;
        }
        public void Set(double min, double max)
        {
            this.Max = max;
            this.Min = min;
        }

    }

    public partial class myGraphControl : ZedGraph.ZedGraphControl
    {
        public myGraphControl()
        {
            this.IsEnableHZoom = false;
            this.IsEnableVZoom = false;
            this.IsEnableHPan = false;
            this.IsEnableVPan = false;

            this.PanButtons = MouseButtons.None;
            this.PanButtons2 = MouseButtons.None;

            this.ZoomButtons = MouseButtons.None;
            this.ZoomButtons2 = MouseButtons.None;
            this.ZoomStepFraction = 0;

            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(MouseWheelHandler);
            this.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseDownHandler);
            this.MouseUpEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseUpHandler);
            this.MouseMoveEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseMoveHandler);
        }

        //Chart may have several curves with the same X-Axis data. 
        // [mySeriesX] is used to keet the common X-Axis data
        //private application.DataSeries mySeriesX = null;
        private double[] mySeriesX = null;

        // To make the chart verically fit in the defined viewport, we must calculate [min,max] in Y-Axis for all curves.
        // So we need to keep the Y-Axis data in [mySeriesY] for the calculation, see GetViewportY().
        private common.DictionaryList mySeriesY = new common.DictionaryList();

        //To decide the direction (backward/forward) of chart-moving
        private Point lastMouseLocation = new Point();
        private int mouseMoveCount = 0; //See sysSensibilityPAN

        /// <summary>
        /// Get Y-Viewport(min,max) of all curves in the current X-Vieport defined by [myViewportX].  
        /// The function used Y-Axis data stored in [mySeriesY] 
        /// </summary>
        /// <returns></returns>
        private ValueRange GetViewportY()
        {
            ValueRange range = new ValueRange();
            for (int count = 0; count < this.mySeriesY.Keys.Length; count++)
            {
                double[] values = (double[])this.mySeriesY.Values[count];
                for (int idx = this.myViewportX.Min; idx < this.myViewportX.Max; idx++)
                {
                    if (range.Min > values[idx])
                    {
                        range.Min = values[idx];
                    }
                    if (range.Max < values[idx])
                    {
                        range.Max = values[idx];
                    }
                }
            }
            range.Max += Settings.sysPadTOP;
            range.Min -= Settings.sysPadBOT; 
            return range;
        }

        #region event handler
        private void MouseWheelHandler(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0) ZoomOut();
            else ZoomIn();
        }
        private bool MouseMoveHandler(ZedGraph.ZedGraphControl sender, MouseEventArgs e)
        {
            if (!isPanning)
            {
                return default(bool);
            }
            if (e.Button == this.myPanButton)
            {
                if (lastMouseLocation.X != e.Location.X) mouseMoveCount++;
                if (mouseMoveCount == Settings.sysSensibilityPAN)
                {
                    this.mouseMoveCount = 0;
                    if (lastMouseLocation.X > e.Location.X)
                    {
                        this.MoveBackward();
                    }
                    if (lastMouseLocation.X < e.Location.X)
                    {
                        this.MoveForward();
                    }
                    this.lastMouseLocation = e.Location;
                }
            }
            return default(bool);
        }
        private bool MouseUpHandler(ZedGraph.ZedGraphControl sender, MouseEventArgs e)
        {
            if (e.Button == this.myPanButton) this.isPanning = false;
            return default(bool);
        }
        private bool MouseDownHandler(ZedGraph.ZedGraphControl sender, MouseEventArgs e)
        {
            if (e.Button == this.myPanButton)
            {
                this.isPanning = true;
                this.lastMouseLocation = e.Location;
                this.mouseMoveCount = 0;
            }
            return default(bool);
        }
        #endregion


        #region public functions
        // The varriable definded the viewport of the chart. View port is the portion of the chart that is shown to users.
        // In the control, viewport is defined as a range [min,max] in X-Axis
        private IntRange _myViewportX = new IntRange();
        public IntRange myViewportX
        {
            get { return _myViewportX; }
            set
            {
                if (this.mySeriesX == null) return;
                if ((value.Min >= value.Max) || (value.Min < 0) || (value.Max >= this.mySeriesX.Length)) return;

                _myViewportX.Set(value.Min, value.Max);
                ValueRange viewportY = GetViewportY();

                this.myGraphPane.XAxis.Scale.Max = this.myViewportX.Max;
                this.myGraphPane.XAxis.Scale.Min = this.myViewportX.Min;

                this.myGraphPane.YAxis.Scale.Max = viewportY.Max;
                this.myGraphPane.YAxis.Scale.Min = viewportY.Min;

                UpdateChart();
            }
        }

        private bool _isPanning = false;  //Not in pan mode as the start
        public bool isPanning
        {
            get { return _isPanning;}
            set
            {
                _isPanning = value;
                Cursor.Current = (value ? Cursors.Hand : Cursors.Default);
            }
        }

        public void SetSeriesX(double[] xSeries, myAxisType axisType)
        {
            this.mySeriesX = xSeries;
            switch (axisType)
            { 
                case myAxisType.DateAsOrdinal :
                     this.myGraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
                     break;
            }
        }
        public void DefaultViewport()
        {
            if (this.mySeriesX == null) return;

            int min = 0;
            if (this.mySeriesX.Length  > Settings.sysNumberOfPoints)
                min = this.mySeriesX.Length - Settings.sysNumberOfPoints;

            this.myViewportX = new IntRange(min, this.mySeriesX.Length - 1);
        }
        public void MoveBackward()
        {
            int max = this.myViewportX.Max - Settings.sysMoveStep;
            int min = this.myViewportX.Min - Settings.sysMoveStep;
            this.myViewportX = new IntRange(min, max);
        }
        public void MoveForward()
        {
            int max = this.myViewportX.Max + Settings.sysMoveStep;
            int min = this.myViewportX.Min + Settings.sysMoveStep;
            this.myViewportX = new IntRange(min, max);
        }
        public void ZoomOut()
        {
            int max = this.myViewportX.Max;
            int min = this.myViewportX.Min + Settings.sysZoomScale;
            this.myViewportX = new IntRange(min, max);
        }
        public void ZoomIn()
        {
            int max = this.myViewportX.Max;
            int min = this.myViewportX.Min - Settings.sysZoomScale;
            this.myViewportX = new IntRange(min, max);
        }
        public void UpdateChart()
        {
            this.AxisChange();
            this.Invalidate();
        }

        public MouseButtons myPanButton = MouseButtons.Left;
        public ZedGraph.GraphPane myGraphPane
        {
            get
            {
                return this.MasterPane[0];
            }
        }
        #endregion

        #region Chart
        public LineItem AddCurveLine(string name, double[] seriesY, SymbolType symbol, Color color, int width)
        {
            LineItem myCurve = myGraphPane.AddCurve(name, this.mySeriesX, seriesY, color, symbol);
            myCurve.Line.Width = width;
            myCurve.Symbol.Size = width + 1;
            this.mySeriesY.Add(name, seriesY);
            return myCurve;
        }
        public BarItem AddCurveBar(string name, double[] seriesY,Color color, Color borderColor, int width)
        {
            BarItem myCurve = myGraphPane.AddBar(name, this.mySeriesX, seriesY, color);
            myCurve.Bar.Border.Color = borderColor;
            myCurve.Bar.Fill.Color = color;
            myCurve.Bar.Border.Width = width;
            this.mySeriesY.Add(name, seriesY);
            return myCurve;
        }
        public StickItem AddCurveStick(string name, double[] seriesY, Color color)
        {
            StickItem myCurve = myGraphPane.AddStick(name, this.mySeriesX, seriesY, color);
            this.mySeriesY.Add(name, seriesY);
            return myCurve;
        }
        public JapaneseCandleStickItem AddCandleStick(string name, double[] seriesHigh, double[] seriesLow, double[] seriesOpen, double[] seriesClose, double[] seriesVolume,
                                                      Color color, Color stickColor, Color risingColor, Color fallingColor)
        {
            StockPointList spl = new StockPointList();
            for (int idx = 0; idx < this.mySeriesX.Length; idx++)
            {
                StockPt pt = new StockPt(this.mySeriesX[idx], 
                                         seriesHigh[idx], seriesLow[idx], seriesOpen[idx],seriesClose[idx], seriesVolume[idx]);
                spl.Add(pt);
            }

            JapaneseCandleStickItem myCurve = myGraphPane.AddJapaneseCandleStick(name, spl);
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.Color = stickColor;

            myCurve.Color = color;

            myCurve.Stick.FallingColor = fallingColor;
            //myCurve.Stick.FallingFill.Color = fallingColor;
            //myCurve.Stick.FallingBorder.Color = fallingColor;

            //myCurve.Stick.RisingBorder.Color = fallingColor;
            myCurve.Stick.RisingFill.Color = risingColor;

            this.mySeriesY.Add(name, seriesHigh);
            return myCurve;
        }
        #endregion Chart

    }
}
