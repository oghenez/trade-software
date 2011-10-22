using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        
        application.Data myData = new application.Data();
        myGraphControl myGraphObj = null;
        public Form1()
        {
            InitializeComponent();
            data.system.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
            myData.DataStockCode = "SSI";
            myData.DataTimeRange = application.AppTypes.TimeRanges.All;
            myData.Reload();

            myGraphObj = new myGraphControl(graphObj);
            myGraphObj.SetSeriesX(myData.DateTime); 

            myGraphObj.AddCurve(myData.Low, "Line1", Color.Red);
            myGraphObj.AddCurve(myData.High, "Line2", Color.Green);
        }
        
        public class IntRange 
        {
            public int Max = int.MinValue, Min = int.MaxValue;
            public IntRange(){}
            public IntRange(int min, int max)
            {
                Min = min;  Max = max;
            }
            public void Reset()
            {
                this.Max = int.MaxValue;
                this.Min = int.MinValue;
            }
            public void Set(int min,int max)
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

        public class myGraphControl 
        {
            private IntRange viewportX = new IntRange();
            private ValueRange viewportY = new ValueRange();
            private bool _isPanning = false;
            public bool isPanning
            {
                get
                {
                    return _isPanning;
                }
                set
                {
                    _isPanning = value;
                    Cursor.Current = (value ? Cursors.Hand : Cursors.Default);
                }
            }
            private Point lastMouseLocation = new Point();
            private int mouseMoveCount = 0;

            public MouseButtons myPanButton = MouseButtons.Left;
            
            private ZedGraph.GraphPane myGraphPane
            {
                get
                {
                    return _myGraphControl.MasterPane[0];
                }
            }
            private ZedGraph.ZedGraphControl _myGraphControl = null;
            public myGraphControl(ZedGraph.ZedGraphControl obj)
            {
                _myGraphControl = obj;
                obj.IsEnableHZoom = false;
                obj.IsEnableVZoom = false;
                obj.IsEnableHPan = false;
                obj.IsEnableVPan = false;

                obj.PanButtons = MouseButtons.None;
                obj.PanButtons2 = MouseButtons.None;

                obj.ZoomButtons = MouseButtons.None;
                obj.ZoomButtons2 = MouseButtons.None;
                obj.ZoomStepFraction = 0;

                obj.MouseWheel += new System.Windows.Forms.MouseEventHandler(MouseWheelHandler);
                obj.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseDownHandler);
                obj.MouseUpEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseUpHandler);
                obj.MouseMoveEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(MouseMoveHandler);
            }

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
                    if (mouseMoveCount == settings.sysSensibilityPAN)
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

            private application.DataSeries mySeriesX = null;
            private common.DictionaryList mySeriesY = new common.DictionaryList();

            /// <summary>
            /// Get Y-Viewport(min,max) of all curves in the current X-Vieport.  
            /// </summary>
            /// <returns></returns>
            private ValueRange GetViewportY()
            {
                ValueRange range = new ValueRange();
                for (int count = 0; count < this.mySeriesY.Keys.Length; count++)
                {
                    double[] values = ((application.DataSeries)this.mySeriesY.Values[count]).Values;
                    for (int idx = this.viewportX.Min; idx < this.viewportX.Max; idx++)
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
                return range;
            }
            private bool SetViewport(int min,int max)
            {
                if ( (min>max) || (min < 0) || (max >= this.mySeriesX.Count)) return false;

                this.viewportX.Set(min, max);
                this.viewportY = GetViewportY();

                this.myGraphPane.XAxis.Scale.Max = this.viewportX.Max;
                this.myGraphPane.XAxis.Scale.Min = this.viewportX.Min;

                this.myGraphPane.YAxis.Scale.Max = this.viewportY.Max;
                this.myGraphPane.YAxis.Scale.Min = this.viewportY.Min;

                UpdateChart();
                return true;
            }

            public void SetSeriesX(application.DataSeries xSeries)
            {
                this.mySeriesX = xSeries;
                this.myGraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
            }
            public void AddCurve(application.DataSeries seriesY, string name, Color color)
            {
                myGraphPane.AddCurve(name, this.mySeriesX.Values, seriesY.Values, color, ZedGraph.SymbolType.None);
                this.mySeriesY.Add(name, seriesY);
            }

            public void DefaultViewport()
            {
                int min = 0;
                if (this.mySeriesX.Count > settings.sysNumberOfPoints)
                     min = this.mySeriesX.Count - settings.sysNumberOfPoints;

                SetViewport(min, this.mySeriesX.Count-1);
            }
            public void MoveBackward()
            {
                int max = this.viewportX.Max - settings.sysMoveStep;
                int min = this.viewportX.Min - settings.sysMoveStep;
                SetViewport(min,max);
            }
            public void MoveForward()
            {
                int max = this.viewportX.Max + settings.sysMoveStep;
                int min = this.viewportX.Min + settings.sysMoveStep;
                SetViewport(min, max);
            }
            public void ZoomOut()
            {
                int max = this.viewportX.Max;
                int min = this.viewportX.Min + settings.sysZoomScale;
                SetViewport(min, max);
            }
            public void ZoomIn()
            {
                int max = this.viewportX.Max;
                int min = this.viewportX.Min - settings.sysZoomScale;
                SetViewport(min, max);
            }
            public void UpdateChart()
            {
                _myGraphControl.AxisChange();
                _myGraphControl.Invalidate();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            myGraphObj.DefaultViewport();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            myGraphObj.DefaultViewport();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            myGraphObj.MoveBackward();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            myGraphObj.MoveForward();
        }
       

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            myGraphObj.ZoomIn();
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            myGraphObj.ZoomOut();
        }
    }
}
