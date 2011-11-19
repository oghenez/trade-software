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
    public partial class myGraphControl : ZedGraph.ZedGraphControl
    {
        public myGraphControl()
        {
            this.IsShowPointValues = true;
            this.IsEnableHZoom = false;
            this.IsEnableVZoom = false;
            this.IsEnableHPan = false;
            this.IsEnableVPan = false;
            this.IsShowContextMenu = false;
            this.myGraphPane.IsFontsScaled = false;

            this.PanButtons = MouseButtons.None;
            this.PanButtons2 = MouseButtons.None;

            this.ZoomButtons = MouseButtons.None;
            this.ZoomButtons2 = MouseButtons.None;
            //this.ZoomStepFraction = 0;

            this.myGraphPane.Legend.IsVisible = false;
            this.myGraphPane.Title.IsVisible = false;
            this.myGraphPane.YAxis.MajorGrid.IsVisible = true;
            this.myGraphPane.YAxis.Title.IsVisible = false;
            this.myGraphPane.XAxis.Title.IsVisible = false;
            this.myGraphPane.Border.IsVisible = false;

            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(MouseWheelHandler);
            this.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseDownHandler);
            this.MouseUpEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseUpHandler);
            this.MouseMoveEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseMoveHandler);

            this.PointValueEvent += new ZedGraphControl.PointValueHandler(GraphPointValueHandler);
        }
        public void SetFont(Font font)
        {
            this.Font = font;

            this.myGraphPane.XAxis.Scale.FontSpec.Family = font.FontFamily.Name;
            this.myGraphPane.XAxis.Scale.FontSpec.Size = font.Size;
            this.myGraphPane.XAxis.Scale.FontSpec.IsBold = font.Bold;
            this.myGraphPane.XAxis.Scale.FontSpec.IsItalic = font.Italic;
            this.myGraphPane.XAxis.Scale.FontSpec.IsUnderline = font.Underline;

            this.myGraphPane.YAxis.Scale.FontSpec.Family = font.FontFamily.Name;
            this.myGraphPane.YAxis.Scale.FontSpec.Size = font.Size;
            this.myGraphPane.YAxis.Scale.FontSpec.IsBold = font.Bold;
            this.myGraphPane.YAxis.Scale.FontSpec.IsItalic = font.Italic;
            this.myGraphPane.YAxis.Scale.FontSpec.IsUnderline = font.Underline;

            this.myGraphPane.X2Axis.Scale.FontSpec.Family = font.FontFamily.Name;
            this.myGraphPane.X2Axis.Scale.FontSpec.Size = font.Size;
            this.myGraphPane.X2Axis.Scale.FontSpec.IsBold = font.Bold;
            this.myGraphPane.X2Axis.Scale.FontSpec.IsItalic = font.Italic;
            this.myGraphPane.X2Axis.Scale.FontSpec.IsUnderline = font.Underline;

            this.myGraphPane.Y2Axis.Scale.FontSpec.Family = font.FontFamily.Name;
            this.myGraphPane.Y2Axis.Scale.FontSpec.Size = font.Size;
            this.myGraphPane.Y2Axis.Scale.FontSpec.IsBold = font.Bold;
            this.myGraphPane.Y2Axis.Scale.FontSpec.IsItalic = font.Italic;
            this.myGraphPane.Y2Axis.Scale.FontSpec.IsUnderline = font.Underline;
        }
        public void SetFont(int fontSize)
        {
            this.Font = new Font(this.Font.FontFamily.Name, fontSize);

            this.myGraphPane.XAxis.Scale.FontSpec.Size = fontSize;
            this.myGraphPane.X2Axis.Scale.FontSpec.Size = fontSize;

            this.myGraphPane.YAxis.Scale.FontSpec.Size = fontSize;
            this.myGraphPane.Y2Axis.Scale.FontSpec.Size = fontSize;
        }

        public int ChartMarginLEFT = Settings.sysChartMarginLEFT;
        public int ChartMarginRIGHT = Settings.sysChartMarginRIGHT;
        public int ChartMarginTOP = Settings.sysChartMarginTOP;
        public int ChartMarginBOTTOM = Settings.sysChartMarginBOTTOM;

        public ViewportState myViewportState = new ViewportState();

        public delegate void OnViewportChanged(object sender, ViewportState state);
        public event OnViewportChanged myOnViewportChanged = null;

        public delegate string OnPointValue(CurveItem curve, int iPt);
        public event OnPointValue myOnPointValue = null;


        //Chart may have several curves with the same X-Axis data. 
        // - [mySeriesX] is used to keep the common X-Axis data
        // - [myAxisType] is used to keep the common X-Axis type
        private double[] mySeriesX = new double[0];
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
            for (int idx = 0; idx < this.myGraphPane.CurveList.Count; idx++)
            {
                Libs.GetRangeY(this.myGraphPane.CurveList[idx], this.myViewportX.Min, this.myViewportX.Max, ref range);
            }
            range.Max += Settings.sysViewportMarginTOP;
            range.Min -= Settings.sysViewportMarginBOT;
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
            if (myViewportState.state == ViewportState.StateType.None)
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
            if (e.Button == this.myPanButton)
                this.myViewportState.state = ViewportState.StateType.None;
            return default(bool);
        }
        private bool MouseDownHandler(ZedGraph.ZedGraphControl sender, MouseEventArgs e)
        {
            if (e.Button == this.myPanButton)
            {
                this.myViewportState.state = ViewportState.StateType.Panning;
                this.lastMouseLocation = e.Location;
                this.mouseMoveCount = 0;
            }
            return default(bool);
        }

        private string GraphPointValueHandler(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            if (myOnPointValue != null) return myOnPointValue(curve, iPt);
            return "";
        }
        #endregion

        #region public functions
        private bool fProcessing = false;

        // The varriable definded the viewport of the chart. View port is the portion of the chart that is shown to users.
        // In the control, viewport is defined as a range [min,max] in X-Axis
        public IntRange _save_myViewportX
        {
            get { return myViewportState.xRange; }
            set
            {
                if (fProcessing) return;
                if (this.mySeriesX == null) return;

                //Add some space at LEFT and RIGHT
                int addToLeft = 0, addToRight = 0;
                bool fStickOutRIGHT = this.myViewportState.isStickOutRIGHT;
                bool fStickOutLEFT = this.myViewportState.isStickOutLEFT;

                if (value.Min > value.Max) return;
                if (value.Max < 0 || value.Max >= this.mySeriesX.Length - 1)
                {
                    if (myViewportX.Max >= this.mySeriesX.Length - 1 && this.myViewportState.isStickOutRIGHT &&
                        this.myViewportState.state == ViewportState.StateType.Panning) return;
                    value.Max = this.mySeriesX.Length - 1;
                    addToRight = (int)((myViewportX.Max - myViewportX.Min) * Settings.sysViewportMarginRIGHT) + 1;
                    fStickOutRIGHT = (myViewportX.Max > myViewportX.Min);
                }
                else
                {
                    fStickOutRIGHT = false;
                }
                if (value.Min > value.Max) value.Min = value.Max;

                if (value.Min <= 0)
                {
                    if (myViewportX.Min <= 0 && this.myViewportState.isStickOutLEFT) return;
                    value.Min = 0;
                    addToLeft = (int)((myViewportX.Max - myViewportX.Min) * Settings.sysViewportMarginLEFT) + 1;
                    fStickOutLEFT = (myViewportX.Max > myViewportX.Min);
                }
                else
                {
                    fStickOutLEFT = false;
                }
                
                try
                {
                    //Turn on to detect loop
                    fProcessing = true;

                    myViewportState.xRange.Set(value.Min, value.Max);
                    //Depend on [myAxisType], [Min,Max] should be assigned different values.
                    switch (this.myViewportState.myAxisType)
                    {
                        case AxisType.Date:
                            this.myGraphPane.XAxis.Scale.Max = this.mySeriesX[this.myViewportX.Max];
                            this.myGraphPane.XAxis.Scale.Min = this.mySeriesX[this.myViewportX.Min];

                            if (addToRight > 0 && this.myViewportX.Max > addToRight)
                            {
                                DateTime prevDate = DateTime.FromOADate(this.mySeriesX[this.myViewportX.Max - addToRight]);
                                DateTime curDate = DateTime.FromOADate(this.mySeriesX[this.myViewportX.Max]);
                                int seconds = common.dateTimeLibs.DateDiffInSecs(prevDate, curDate);
                                this.myGraphPane.XAxis.Scale.Max = DateTime.FromOADate(this.mySeriesX[this.myViewportX.Max]).AddSeconds(seconds).ToOADate();
                            }

                            if (addToLeft > 0 && addToLeft < this.mySeriesX.Length)
                            {
                                DateTime nextDate = DateTime.FromOADate(this.mySeriesX[addToLeft]);
                                DateTime curDate = DateTime.FromOADate(this.mySeriesX[0]);
                                int seconds = common.dateTimeLibs.DateDiffInSecs(curDate, nextDate);
                                this.myGraphPane.XAxis.Scale.Min = curDate.AddSeconds(-seconds).ToOADate();
                            }
                            break;
                        case AxisType.DateAsOrdinal:
                        default:
                            this.myGraphPane.XAxis.Scale.Max = this.myViewportX.Max + addToRight;
                            this.myGraphPane.XAxis.Scale.Min = this.myViewportX.Min - addToLeft;
                            break;
                    }
                    this.myViewportState.yRange = GetViewportY();

                    this.myGraphPane.YAxis.Scale.Max = this.myViewportState.yRange.Max;
                    this.myGraphPane.YAxis.Scale.Min = this.myViewportState.yRange.Min;

                    SetDateTimeFormat(); // Different DateTime format for different X-Scale

                    this.myViewportState.isStickOutRIGHT = fStickOutRIGHT;
                    this.myViewportState.isStickOutLEFT = fStickOutLEFT;
                    //Update change to chart
                    UpdateChart();

                    //Create changed event
                    if (myOnViewportChanged != null)
                    {
                        ViewportState state = new ViewportState();
                        state.xRange = value;
                        myOnViewportChanged(this, state);
                    }
                }
                catch (Exception er)
                {
                    common.system.ThrowException(er);
                }
                finally
                {
                    fProcessing = false;
                }
            }
        }

        public IntRange myViewportX
        {
            get { return myViewportState.xRange; }
            set
            {
                if (fProcessing) return;
                if (this.mySeriesX == null) return;
                if ((value.Min >= value.Max) || (value.Min < 0) || (value.Max >= this.mySeriesX.Length)) return;

                try
                {
                    //Turn on to detect loop
                    fProcessing = true;

                    myViewportState.xRange.Set(value.Min, value.Max);

                    //Depend on [myAxisType], [Min,Max] should be assigned different values.
                    switch (this.myViewportState.myAxisType)
                    {
                        case AxisType.Date:
                            this.myGraphPane.XAxis.Scale.Max = this.mySeriesX[this.myViewportX.Max];
                            this.myGraphPane.XAxis.Scale.Min = this.mySeriesX[this.myViewportX.Min];
                            break;
                        case AxisType.DateAsOrdinal:
                        default:
                            this.myGraphPane.XAxis.Scale.Max = this.myViewportX.Max;
                            this.myGraphPane.XAxis.Scale.Min = this.myViewportX.Min;
                            break;
                    }

                    ValueRange viewportY = GetViewportY();
                    this.myGraphPane.YAxis.Scale.Max = viewportY.Max;
                    this.myGraphPane.YAxis.Scale.Min = viewportY.Min;

                    SetDateTimeFormat();

                    UpdateChart();
                    if (myOnViewportChanged != null)
                    {
                        ViewportState state = new ViewportState();
                        state.xRange = value;
                        myOnViewportChanged(this, state);
                    }
                }
                catch (Exception er)
                {
                    common.system.ThrowException(er);
                }
                finally
                {
                    fProcessing = false;
                }
            }
        }


        // Different DateTime format for different X-Scale
        private void SetDateTimeFormat()
        {
            if (this.mySeriesX == null) return;
            DateTime startDate = DateTime.FromOADate(this.mySeriesX[this.myViewportX.Min]);
            DateTime endDate = DateTime.FromOADate(this.mySeriesX[this.myViewportX.Max]);
            if (startDate.Year != endDate.Year)
            {
                this.myGraphPane.XAxis.Scale.Format = "MMM-yy";
                return;
            }
            if (startDate.Month != endDate.Month)
            {
                this.myGraphPane.XAxis.Scale.Format = "dd-MMM-yy";
                return;
            }
            if (startDate.Day != endDate.Day)
            {
                this.myGraphPane.XAxis.Scale.Format = "MMM-dd";
                return;
            }
            if (startDate.Hour != endDate.Hour)
            {
                this.myGraphPane.XAxis.Scale.Format = "hh:mm";
                return;
            }
            this.myGraphPane.XAxis.Scale.Format = "hh:mm:ss";
        }

        // Chart series can be added dynamically, after such update UpdateSeries() should be called to update the chart's serries(mySeriesX...)
        public void UpdateSeries()
        {
            if (mySeriesX == null)
            {
                 if (this.myGraphPane.CurveList.Count == 0)  return;
                 this.mySeriesX = new double[0];
            }
            Libs.UpdateSeriesX(this.myGraphPane.CurveList[0], ref mySeriesX);
        }

        public void SetSeriesX(double[] xSeries, AxisType axisType)
        {
            SetSeriesX(xSeries, axisType, AxisUnit.Day);
        }
        public void SetSeriesX(double[] xSeries, AxisType axisType, AxisUnit axisUnit)
        {
            this.myViewportState.myAxisType = axisType;
            this.myViewportState.myAxisUnit = axisUnit;
            this.mySeriesX = xSeries;
            if (xSeries == null)
            {
                this.myViewportState.xRange = new IntRange(0, 0);
            }
            else
            {
                if (this.myViewportState.xRange.Max > xSeries.Length - 1)
                {
                    this.myViewportState.xRange.Min = 0;
                    this.myViewportState.xRange.Max = xSeries.Length - 1;
                }
            }

            switch (axisType)
            {
                case AxisType.DateAsOrdinal:
                    this.myGraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
                    break;
                case AxisType.Date:
                    this.myGraphPane.XAxis.Type = ZedGraph.AxisType.Date;
                    break;
                default:
                    this.myGraphPane.XAxis.Type = ZedGraph.AxisType.Linear;
                    break;
            }
            switch (axisUnit)
            {
                case AxisUnit.Second:
                    this.myGraphPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Second;
                    break;
                case AxisUnit.Minute:
                    this.myGraphPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Minute;
                    break;
                case AxisUnit.Hour:
                    this.myGraphPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Hour;
                    break;
                case AxisUnit.Month:
                    this.myGraphPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Month;
                    break;
                case AxisUnit.Year:
                    this.myGraphPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Year;
                    break;
                default:
                    this.myGraphPane.XAxis.Scale.MajorUnit = ZedGraph.DateUnit.Day;
                    break;
            }
        }
        public void DefaultViewport()
        {
            if (this.mySeriesX == null) return;

            int min = 0;
            if (this.mySeriesX.Length > Settings.sysNumberOfPoints)
                min = this.mySeriesX.Length - Settings.sysNumberOfPoints;

            this.myViewportState.Reset();
            this.myViewportX = new IntRange(min, this.mySeriesX.Length-1);
        }

        public void MoveToEnd()
        {
            if (this.mySeriesX == null) return;
            IntRange xRange =  new IntRange(0, this.mySeriesX.Length-1);
            if (this.mySeriesX.Length >= Charts.Settings.sysNumberOfPoints)
            {
                int size = this.myViewportX.Max - this.myViewportX.Min + 1;
                if (size <=0) size = Charts.Settings.sysNumberOfPoints;
                xRange.Min = xRange.Max - size+1;
            }
            this.myViewportState.Reset();
            this.myViewportState.state = ViewportState.StateType.Panning;
            this.myViewportX = xRange;
        }
        public void MoveBackward()
        {
            try
            {
                this.myViewportState.state = ViewportState.StateType.Panning;
                int max = this.myViewportX.Max - Settings.sysMoveStep;
                int min = this.myViewportX.Min - Settings.sysMoveStep;
                this.myViewportX = new IntRange(min, max);
            }
            finally
            {
                this.myViewportState.state = ViewportState.StateType.None;
            }
        }
        public void MoveForward()
        {
            try
            {
                this.myViewportState.state = ViewportState.StateType.Panning;
                int max = this.myViewportX.Max + Settings.sysMoveStep;
                int min = this.myViewportX.Min + Settings.sysMoveStep;
                this.myViewportX = new IntRange(min, max);
            }
            finally
            {
                this.myViewportState.state = ViewportState.StateType.None;
            }
        }
        public void ZoomOut()
        {
            try
            {
                this.myViewportState.state = ViewportState.StateType.Zooming;
                int max = this.myViewportX.Max;
                int min = this.myViewportX.Min + Settings.sysZoomScale;
                this.myViewportX = new IntRange(min, max);
            }
            finally
            {
                this.myViewportState.state = ViewportState.StateType.None;
            }
        }
        public void ZoomIn()
        {
            try
            {
                this.myViewportState.state = ViewportState.StateType.Zooming;
                int max = this.myViewportX.Max;
                int min = this.myViewportX.Min - Settings.sysZoomScale;
                this.myViewportX = new IntRange(min, max);
            }
            finally
            {
                this.myViewportState.state = ViewportState.StateType.None;
            }
        }
        public void UpdateChart()
        {
            this.AxisChange();
            this.Invalidate();
        }

        public virtual void CalcGraphSize()
        {
            this.myGraphPane.Chart.Rect = new RectangleF(this.ChartMarginLEFT, this.ChartMarginTOP,
                                                         this.Width - this.ChartMarginRIGHT,
                                                         this.Height - this.ChartMarginBOTTOM);

            this.myGraphPane.Margin.Left = this.ChartMarginLEFT;
            this.myGraphPane.Margin.Top = this.ChartMarginTOP;
            this.myGraphPane.Margin.Right = this.ChartMarginRIGHT;
            this.myGraphPane.Margin.Bottom = this.ChartMarginBOTTOM;
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
            return myCurve;
        }
        public BarItem AddCurveBar(string name, double[] seriesY, Color color, Color borderColor, int width)
        {
            BarItem myCurve = myGraphPane.AddBar(name, this.mySeriesX, seriesY, color);
            myCurve.Bar.Border.Color = borderColor;
            myCurve.Bar.Fill.Color = color;
            myCurve.Bar.Border.Width = width;
            return myCurve;
        }
        public StickItem AddCurveStick(string name, double[] seriesY, Color color)
        {
            StickItem myCurve = myGraphPane.AddStick(name, this.mySeriesX, seriesY, color);
            return myCurve;
        }
        public JapaneseCandleStickItem AddCandleStick(string name, double[] seriesHigh, double[] seriesLow, double[] seriesOpen, double[] seriesClose, double[] seriesVolume,
                                                      Color color, Color stickColor, Color risingColor, Color fallingColor)
        {
            if (this.mySeriesX == null) return null;
            StockPointList spl = new StockPointList();
            for (int idx = 0; idx < this.mySeriesX.Length; idx++)
            {
                StockPt pt = new StockPt(this.mySeriesX[idx],
                                         seriesHigh[idx], seriesLow[idx], seriesOpen[idx], seriesClose[idx], seriesVolume[idx]);
                spl.Add(pt);
            }

            JapaneseCandleStickItem myCurve = myGraphPane.AddJapaneseCandleStick(name, spl);
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.Color = stickColor;

            myCurve.Color = color;

            myCurve.Stick.FallingColor = fallingColor;
            myCurve.Stick.RisingFill.Color = risingColor;
            return myCurve;
        }
        #endregion Chart

    }
  
    public partial class _myGraphControl_save : ZedGraph.ZedGraphControl
    {
        public _myGraphControl_save()
        {
            this.IsShowPointValues = true;
            this.IsEnableHZoom = false;
            this.IsEnableVZoom = false;
            this.IsEnableHPan = false;
            this.IsEnableVPan = false;
            this.IsShowContextMenu = false;
            this.myGraphPane.IsFontsScaled = false;

            this.PanButtons = MouseButtons.None;
            this.PanButtons2 = MouseButtons.None;

            this.ZoomButtons = MouseButtons.None;
            this.ZoomButtons2 = MouseButtons.None;
            this.ZoomStepFraction = 0;

            this.myGraphPane.Legend.IsVisible = false;
            this.myGraphPane.Title.IsVisible = false;
            this.myGraphPane.YAxis.MajorGrid.IsVisible = true;
            this.myGraphPane.YAxis.Title.IsVisible = false;
            this.myGraphPane.XAxis.Title.IsVisible = false;
            this.myGraphPane.Border.IsVisible = false;

            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(MouseWheelHandler);
            this.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseDownHandler);
            this.MouseUpEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseUpHandler);
            this.MouseMoveEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseMoveHandler);

            this.PointValueEvent += new ZedGraphControl.PointValueHandler(GraphPointValueHandler);
            
        }
        public void SetFont(Font font)
        {
            this.Font = font;

            this.myGraphPane.XAxis.Scale.FontSpec.Family = font.FontFamily.Name;
            this.myGraphPane.XAxis.Scale.FontSpec.Size = font.Size;
            this.myGraphPane.XAxis.Scale.FontSpec.IsBold = font.Bold;
            this.myGraphPane.XAxis.Scale.FontSpec.IsItalic = font.Italic;
            this.myGraphPane.XAxis.Scale.FontSpec.IsUnderline = font.Underline;

            this.myGraphPane.YAxis.Scale.FontSpec.Family = font.FontFamily.Name;
            this.myGraphPane.YAxis.Scale.FontSpec.Size = font.Size;
            this.myGraphPane.YAxis.Scale.FontSpec.IsBold = font.Bold;
            this.myGraphPane.YAxis.Scale.FontSpec.IsItalic = font.Italic;
            this.myGraphPane.YAxis.Scale.FontSpec.IsUnderline = font.Underline;

            this.myGraphPane.X2Axis.Scale.FontSpec.Family = font.FontFamily.Name;
            this.myGraphPane.X2Axis.Scale.FontSpec.Size = font.Size;
            this.myGraphPane.X2Axis.Scale.FontSpec.IsBold = font.Bold;
            this.myGraphPane.X2Axis.Scale.FontSpec.IsItalic = font.Italic;
            this.myGraphPane.X2Axis.Scale.FontSpec.IsUnderline = font.Underline;

            this.myGraphPane.Y2Axis.Scale.FontSpec.Family = font.FontFamily.Name;
            this.myGraphPane.Y2Axis.Scale.FontSpec.Size = font.Size;
            this.myGraphPane.Y2Axis.Scale.FontSpec.IsBold = font.Bold;
            this.myGraphPane.Y2Axis.Scale.FontSpec.IsItalic = font.Italic;
            this.myGraphPane.Y2Axis.Scale.FontSpec.IsUnderline = font.Underline;
        }
        public void SetFont(int fontSize)
        {
            this.Font = new Font(this.Font.FontFamily.Name, fontSize);

            this.myGraphPane.XAxis.Scale.FontSpec.Size = fontSize;
            this.myGraphPane.X2Axis.Scale.FontSpec.Size = fontSize;

            this.myGraphPane.YAxis.Scale.FontSpec.Size = fontSize;
            this.myGraphPane.Y2Axis.Scale.FontSpec.Size = fontSize;
        }

        public int ChartMarginLEFT = Settings.sysChartMarginLEFT;
        public int ChartMarginRIGHT = Settings.sysChartMarginRIGHT;
        public int ChartMarginTOP = Settings.sysChartMarginTOP;
        public int ChartMarginBOTTOM = Settings.sysChartMarginBOTTOM;

        public class ViewportState
        {
            public IntRange xRange = new IntRange();
            public StateType state = StateType.None; 
            public enum StateType:byte    //Resevered 
            {
                None = 0,
                Zoom = 1,
                Pan = 2
            }
        }

        public delegate void OnViewportChanged(object sender, ViewportState state);
        public event OnViewportChanged myOnViewportChanged = null;

        public delegate string OnPointValue(CurveItem curve, int iPt);
        public event OnPointValue myOnPointValue = null;


        //Chart may have several curves with the same X-Axis data. 
        // - [mySeriesX] is used to keep the common X-Axis data
        // - [myAxisType] is used to keep the common X-Axis type
        private double[] mySeriesX = null;
        private AxisType myAxisType = AxisType.Linear;

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
            range.Max += Settings.sysChartMarginTOP;
            range.Min -= Settings.sysChartMarginBOTTOM; 
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

        private string GraphPointValueHandler(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            if (myOnPointValue != null) return myOnPointValue(curve, iPt);
            return "";
        }
        #endregion

        #region public functions
        private bool fProcessing = false;

        // The varriable definded the viewport of the chart. View port is the portion of the chart that is shown to users.
        // In the control, viewport is defined as a range [min,max] in X-Axis
        private IntRange _myViewportX = new IntRange();
        public IntRange myViewportX
        {
            get { return _myViewportX; }
            set
            {
                if (fProcessing) return;
                if (this.mySeriesX == null) return;
                if ((value.Min >= value.Max) || (value.Min < 0) || (value.Max >= this.mySeriesX.Length)) return;

                try
                {
                    //Turn on to detect loop
                    fProcessing = true;

                    _myViewportX.Set(value.Min, value.Max);
                    
                    //Depend on [myAxisType], [Min,Max] should be assigned different values.
                    switch (this.myAxisType)
                    { 
                        case AxisType.Date:
                             this.myGraphPane.XAxis.Scale.Max = this.mySeriesX[this.myViewportX.Max];
                             this.myGraphPane.XAxis.Scale.Min = this.mySeriesX[this.myViewportX.Min];
                             break;
                        case AxisType.DateAsOrdinal:
                        default:
                             this.myGraphPane.XAxis.Scale.Max = this.myViewportX.Max;
                             this.myGraphPane.XAxis.Scale.Min = this.myViewportX.Min;
                             break;
                    }

                    ValueRange viewportY = GetViewportY();
                    this.myGraphPane.YAxis.Scale.Max = viewportY.Max;
                    this.myGraphPane.YAxis.Scale.Min = viewportY.Min;

                    UpdateChart();
                    if (myOnViewportChanged != null)
                    {
                        ViewportState state = new ViewportState();
                        state.xRange = value;
                        myOnViewportChanged(this, state);
                    }
                }
                catch (Exception er) 
                { 
                    common.system.ThrowException(er); 
                }
                finally
                {
                    fProcessing = false;
                }
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

        public void SetSeriesX(double[] xSeries, AxisType axisType)
        {
            this.myAxisType = axisType;
            this.mySeriesX = xSeries;
            switch (axisType)
            { 
                case AxisType.DateAsOrdinal :
                     this.myGraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
                     break;
                case AxisType.Date:
                     this.myGraphPane.XAxis.Type = ZedGraph.AxisType.Date;
                     break;
                default:
                     this.myGraphPane.XAxis.Type = ZedGraph.AxisType.Linear;
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

        public virtual void CalcGraphSize()
        {
            this.myGraphPane.Chart.Rect = new RectangleF(this.ChartMarginLEFT, this.ChartMarginTOP,
                                                         this.Width - this.ChartMarginRIGHT,
                                                         this.Height - this.ChartMarginBOTTOM);

            this.myGraphPane.Margin.Left = this.ChartMarginLEFT;
            this.myGraphPane.Margin.Top = this.ChartMarginTOP;
            this.myGraphPane.Margin.Right = this.ChartMarginRIGHT;
            this.myGraphPane.Margin.Bottom = this.ChartMarginBOTTOM;
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

            //Add 2 series to ensure that the viewport max/min points are in th viewport.
            this.mySeriesY.Add(name, seriesHigh);
            this.mySeriesY.Add(name+"1", seriesLow);

            return myCurve;
        }
        #endregion Chart

    }
}
