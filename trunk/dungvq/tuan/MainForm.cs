using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using application;
using ZedGraph;
using test1.Panel;


namespace test
{
    public partial class MainForm : Form
    {
        baseClass.controls.graphPanel testPane = new baseClass.controls.graphPanel();
        JapaneseCandleStickItem candleStick;
        BarItem barItem;
        LineItem line;
        OHLCBarItem ohlcBarItem;
        bool isExistMarketWatch = true;
        bool isExistIndicator = true;
        List<GraphPane> lstPanes = new List<GraphPane>();
        public MainForm()
        {
            InitializeComponent();
            myGraphObj.IsEnableSelection = false;
            //myGraphObj.IsEnableVZoom = false;
            chart._parent = this.myGraphObj;
            indicatorPanel1._mFormParent = this;
            marketWatchPanel1._mFormParent = this;

            data.system.dbConnectionString = @"Data Source=NGUYENVU-PC;Initial Catalog=stock;Integrated Security=True";
            //Master pane
            indicatorPanel1.InitData();
            MasterPane master = myGraphObj.MasterPane;

            master.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);
            master.PaneList.Clear();

            master.Title.IsVisible = true;
            master.Title.Text = "SMI";

            master.Margin.All = 1;
            master.InnerPaneGap = 0;

            GraphPane Pane1 = new GraphPane();

            Pane1.YAxis.Scale.MinAuto = false;
            Pane1.YAxis.Scale.Min = 0;

            Pane1.Border.IsVisible = false;
            Pane1.XAxis.IsVisible = true;
            Pane1.Legend.IsVisible = false;

            GraphPane Pane2 = new GraphPane();

            Pane2.YAxis.Scale.MinAuto = false;
            Pane2.YAxis.Scale.Min = 0;

            Pane2.Border.IsVisible = false;
            Pane2.Title.IsVisible = false;
            Pane2.Legend.IsVisible = false;
            Pane2.XAxis.IsVisible = false;

            //Pane2.Y2Axis.Scale.IsSkipLastLabel = true;

            //add pane
            lstPanes.Add(Pane1);
            lstPanes.Add(Pane2);
            master.Add(Pane1);
            master.Add(Pane2);
            using (Graphics g = myGraphObj.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SingleColumn);
                myGraphObj.AxisChange();
                myGraphObj.IsSynchronizeXAxes = true;
                myGraphObj.IsSynchronizeYAxes = true;

            }

            Pane1.YAxis.MajorGrid.IsVisible = true;
            Pane1.XAxis.MajorGrid.IsVisible = true;

            Pane2.YAxis.MajorGrid.IsVisible = true;
            Pane2.XAxis.MajorGrid.IsVisible = true;
            myGraphObj.IsShowPointValues = true;
            //myGraphObj.GraphPane.Border.IsVisible = false;

            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();

            //data.baseDS.ind
            DateTime toDate = DateTime.Today;
            DateTime frDate = toDate.AddYears(-3);
            dataLibs.LoadData(priceTbl, myTypes.timeScales.Daily, frDate, toDate, "SSI");



            if (priceTbl.Count <= 0) return;
            // Line chart example
            //PointPairList list = chart.MakePointPairList(priceTbl, chart.stockDataField.Close);
            //LineItem myCurve = myGraphObj.GraphPane.AddCurve("aa", list, Color.Red);
            line = chart.PlotLineChart(Pane1, priceTbl, "Line", Color.Blue, Color.Brown, Color.Red);
            candleStick = chart.PlotChartCandleStick(Pane1, priceTbl, "Candle Stick", Color.Blue, Color.Brown, Color.Red);
            ohlcBarItem = chart.PlotOHLCBar(Pane1, priceTbl, "Bar", Color.Red);
            chart.PlotVolumeChart(Pane2, priceTbl, "Volume", Color.Blue);
            ohlcBarItem.IsVisible = false;
            myGraphObj.AxisChange();
            myGraphObj.GraphPane.X2Axis.Scale.TextLabels = new string[] { "1", "2" };
        }

        string myGraphObj_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            var pp = curve[iPt];
            tsDate.Text = "Date: " + (new XDate(pp.X)).DateTime.ToShortDateString();
            if (pp.GetType().Name.Equals("StockPt"))
            {
                StockPt pt = pp as StockPt;
                return "Date: " + (new XDate(pt.Date)).DateTime.ToShortDateString() + "\nHigh:" + pt.High.ToString("f2") + "\nOpen:" + pt.Open.ToString("f2") + "\nClose:" + pt.Close.ToString("f2") + "\nLow:" + pt.Low.ToString("f2");
            }

            return "Date: " + (new XDate(pp.X)) + "\nVolume: " + (pp.Y).ToString("f2");
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //SetSize();
        }

        private void candleStickToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void barToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Bar Chart
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ActiveChartView("Bar");
        }
        void ActiveChartView(string type)
        {
            switch (type)
            {
                case "Candle Stick":
                    {
                        ohlcBarItem.IsVisible = false;
                        candleStick.IsVisible = true;
                        line.IsVisible = false;
                    }
                    break;
                case "Bar":
                    {
                        ohlcBarItem.IsVisible = true;
                        candleStick.IsVisible = false;
                        line.IsVisible = false;
                    }
                    break;
                case "Line":
                    {
                        ohlcBarItem.IsVisible = false;
                        candleStick.IsVisible = false;
                        line.IsVisible = true;
                    }
                    break;
                default:
                    break;
            }
            this.myGraphObj.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            ActiveChartView("Candle Stick");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ActiveChartView("Line");
        }

        private void indicatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isExistIndicator)
            {
                IndicatorPanel indicatorPanel = new IndicatorPanel() { _mFormParent = this };
                indicatorPanel.InitData();
                leftPanel.Controls.Add(indicatorPanel);
            }
        }

        private void marketWatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isExistMarketWatch)
            {
                leftPanel.Controls.Add(new MarketWatchPanel() { _mFormParent = this });
            }
        }

        private void leftPanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.GetType().Equals(typeof(MarketWatchPanel)))
            {
                isExistMarketWatch = false;
            }
            if (e.Control.GetType().Equals(typeof(IndicatorPanel)))
            {
                isExistIndicator = false;
            }
        }

        private void myGraphObj_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            foreach (var item in lstPanes)
            {
                item.AxisChange();
                item.XAxis.MinSpace = item.CalcScaleFactor();
            }
        }
    }
}
