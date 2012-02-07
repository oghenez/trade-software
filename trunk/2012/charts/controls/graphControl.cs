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
            InitializeComponent();

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
        public int ChartMarginBOTTOM = Settings.sysChartMarginBOT;

        public ViewportState myViewportState = new ViewportState();

        public delegate void OnViewportChanged(object sender, ViewportState state);
        public event OnViewportChanged myOnViewportChanged = null;

        public delegate void OnDataRangeChanged(object sender);
        public event OnDataRangeChanged myOnDataRangeChanged = null;

        public delegate int OnGetMoreData(object sender,bool isBackward);
        public event OnGetMoreData myOnGetMoreData = null;

        public delegate string OnPointValue(CurveItem curve, int iPt);
        public event OnPointValue myOnPointValue = null;


        //Chart may have several curves with the same X-Axis data. 
        // - [mySeriesX] is used to keep the common X-Axis data
        // - [myAxisType] is used to keep the common X-Axis type
        private double[] mySeriesX = new double[0];
        public double[] SeriesX
        {
            get { return mySeriesX;}
        }
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
            range.Max += Settings.sysViewSpaceAtTOP;
            range.Min -= Settings.sysViewSpaceAtBOT;
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
            if (e.Button == this.myPanButton)
            {
                if (lastMouseLocation.X != e.Location.X) mouseMoveCount++;
                if (mouseMoveCount == Settings.sysPAN_MouseRate)
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
        public IntRange myViewportX 
        {
            get { return myViewportState.xRange; }
            set
            {
                if (fProcessing || this.mySeriesX == null) return;
                if (value.Max - value.Min < Settings.sysNumberOfPoint_MIN) return;
                if ((value.Min >= value.Max) || (value.Min < 0) || (value.Max >= this.mySeriesX.Length)) return;
                try
                {
                    //Turn on to prevent loop
                    fProcessing = true;
                    SetViewportX(value);
                    fProcessing = false;
                }
                catch (Exception er)
                {
                    fProcessing = false;
                    common.system.ThrowException(er);
                }
            }
        }

        private void SetViewportX(IntRange range)
        {
            int NoExtraBarAtRight = (int)((range.Max - range.Min) * Settings.sysViewSpaceAtRIGHT / 100);
            if (NoExtraBarAtRight < Settings.sysViewMinBarAtRIGHT) NoExtraBarAtRight = Settings.sysViewMinBarAtRIGHT;

            int NoExtraBarAtLeft = (int)((range.Max - range.Min) * Settings.sysViewSpaceAtLEFT / 100);
            if (NoExtraBarAtRight < Settings.sysViewMinBarAtLEFT) NoExtraBarAtRight = Settings.sysViewMinBarAtLEFT;

            myViewportState.xRange.Set(range.Min, range.Max);
            //Depend on [myAxisType], [Min,Max] should be assigned different values.
            switch (this.myViewportState.myAxisType)
            {
                case AxisType.Date:
                    if (NoExtraBarAtRight > 0 && this.myViewportX.Max > NoExtraBarAtRight)
                    {
                        DateTime prevDate = DateTime.FromOADate(this.mySeriesX[this.myViewportX.Max - NoExtraBarAtRight]);
                        DateTime curDate = DateTime.FromOADate(this.mySeriesX[this.myViewportX.Max]);
                        int seconds = common.dateTimeLibs.DateDiffInSecs(prevDate, curDate);
                        this.myGraphPane.XAxis.Scale.Max = DateTime.FromOADate(this.mySeriesX[this.myViewportX.Max]).AddSeconds(seconds).ToOADate();
                    }
                    else
                    {
                        this.myGraphPane.XAxis.Scale.Max = this.mySeriesX[this.myViewportX.Max];
                    }

                    if (NoExtraBarAtLeft > 0 && NoExtraBarAtLeft < this.mySeriesX.Length)
                    {
                        DateTime nextDate = DateTime.FromOADate(this.mySeriesX[NoExtraBarAtLeft]);
                        DateTime curDate = DateTime.FromOADate(this.mySeriesX[0]);
                        int seconds = common.dateTimeLibs.DateDiffInSecs(curDate, nextDate);
                        this.myGraphPane.XAxis.Scale.Min = curDate.AddSeconds(-seconds).ToOADate();
                    }
                    else
                    {
                        this.myGraphPane.XAxis.Scale.Min = this.mySeriesX[this.myViewportX.Min];
                    }
                    break;
                case AxisType.DateAsOrdinal:
                default:
                    this.myGraphPane.XAxis.Scale.Max = this.myViewportX.Max + NoExtraBarAtRight;
                    this.myGraphPane.XAxis.Scale.Min = this.myViewportX.Min - NoExtraBarAtLeft;
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
                state.xRange = range;
                myOnViewportChanged(this, state);
            }
           
            //if (xRangeBar.Visible)
            //{
            //    xRangeBar.RangeMinimum = range.Min;
            //    xRangeBar.RangeMaximum = range.Max;
            //}
        }


        // Different DateTime format for different X-Scale
        private void SetDateTimeFormat()
        {
            if (this.mySeriesX == null) return;
            if (this.myViewportX.Min < 0 || this.myViewportX.Min>=this.mySeriesX.Length) return;
            if (this.myViewportX.Max < 0 || this.myViewportX.Max >= this.mySeriesX.Length) return;

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
            if (myOnDataRangeChanged != null)  myOnDataRangeChanged(this);
        }
        public void DefaultViewport()
        {
            if (this.mySeriesX == null) return;

            int min = 0;
            if (this.mySeriesX.Length > Settings.sysNumberOfPoint_DEFA)
                min = this.mySeriesX.Length - Settings.sysNumberOfPoint_DEFA;

            this.myViewportState.Reset();
            this.SetViewportX(new IntRange(min, this.mySeriesX.Length - 1));
        }

        public bool IsLastView()
        {
            if (this.mySeriesX == null) return false;
            switch (this.myViewportState.myAxisType)
            {
                case AxisType.Date:
                    if (mySeriesX.Length <=0) return true;
                    return (mySeriesX[mySeriesX.Length - 1] >= this.myViewportX.Min && mySeriesX[mySeriesX.Length - 1] <= this.myViewportX.Max);
                default:
                    return (mySeriesX.Length - 1 >= this.myViewportX.Min && mySeriesX.Length - 1 <= this.myViewportX.Max);
            }
        }

        public void MoveToEnd()
        {
            if (this.mySeriesX == null) return;
            if (myOnGetMoreData!=null) myOnGetMoreData(this, false);

            IntRange xRange =  new IntRange(0, this.mySeriesX.Length-1);
            if (this.mySeriesX.Length >= Charts.Settings.sysNumberOfPoint_DEFA)
            {
                int size = this.myViewportX.Max - this.myViewportX.Min + 1;
                if (size <= 0) size = Charts.Settings.sysNumberOfPoint_DEFA;
                xRange.Min = xRange.Max - size+1;
            }
            this.myViewportState.Reset();
            this.myViewportState.state = ViewportState.StateType.Panning;
            this.myViewportX = xRange;
        }

        private int GetMoveCount()
        {
            int moveCount = (this.myViewportX.Max - this.myViewportX.Min) * Settings.sysPAN_MovePercent / 100;
            return (moveCount < Settings.sysPAN_MoveMinCount ? Settings.sysPAN_MoveMinCount : moveCount);
        }
        private int GetZoomCount()
        {
            int zoomCount = (this.myViewportX.Max - this.myViewportX.Min) * Settings.sysZoom_Percent/ 100;
            return (zoomCount < Settings.sysZoom_MinCount ? Settings.sysZoom_MinCount : zoomCount);
        }

        public void MoveBackward()
        {
            try
            {
                this.myViewportState.state = ViewportState.StateType.Panning;
                int max,min;

                int moveCount = GetMoveCount();
                if (this.myViewportX.Min < moveCount && myOnGetMoreData != null)
                {
                    int addCount = myOnGetMoreData(this, true);
                    max = this.myViewportX.Max + addCount/2;
                    min = this.myViewportX.Min + addCount/2;
                }
                else
                {
                    max = this.myViewportX.Max - moveCount;
                    min = this.myViewportX.Min - moveCount;
                }
                // IF there are some hidden points on  the left (this.myViewportX.Min >0)
                // AND this move will make it out of the left (min <0)
                // THEN ensures it will not go out of the left edge.
                if (this.myViewportX.Min>0 && min < 0) min = 0;
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
                int moveCount = GetMoveCount();
                if (this.mySeriesX.Length - this.myViewportX.Max - 1 <= moveCount && myOnGetMoreData != null) myOnGetMoreData(this, false);
                int min = this.myViewportX.Min + moveCount;
                int max = this.myViewportX.Max + moveCount;
                // IF there are some hidden points on  the right (this.myViewportX.Max < this.mySeriesX.Length-1)
                // AND this move will make it out of the right (max >= this.mySeriesX.Length)
                // THEN ensures it will not go out of the right edge.
                if ( (this.myViewportX.Max < this.mySeriesX.Length-1) && (max >= this.mySeriesX.Length) ) 
                     max = this.mySeriesX.Length - 1;

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
                int min = this.myViewportX.Min + GetZoomCount();
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
                //if (this.myViewportX.Min <= Settings.sysZoomRate && myOnGetMoreData != null) myOnGetMoreData(this, true);

                int max = this.myViewportX.Max;
                int min = this.myViewportX.Min - GetZoomCount();
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
        public LineItem ReDrawCurveLine(LineItem curve,double[] seriesY)
        {
            myGraphPane.CurveList.Remove(curve); 
            curve = myGraphPane.AddCurve("name", this.mySeriesX, seriesY, curve.Color, SymbolType.None);
            return curve;

            //myCurve.Line.Width = width;
            //myCurve.Symbol.Size = width + 1;
            //return myCurve;
        }

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
}
