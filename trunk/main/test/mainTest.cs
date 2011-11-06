using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using application;

namespace test
{
    public partial class mainTest : baseClass.forms.baseForm
    {
        bool fGenData = false;
        application.Data myData = new application.Data();
        public mainTest()
        {
            try
            {
                InitializeComponent();
                cbTimeScale.LoadData();
                cbTimeRange.LoadData();
                timer1.Interval = 5000;
                data.system.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
                myData.DataStockCode = "SSI";
                myData.DataTimeScale = application.AppTypes.MainDataTimeScale;
                myData.DataTimeRange = application.AppTypes.TimeRanges.Y5;

                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        JapaneseCandleStickItem candleCurve = null;
        LineItem lineCurve = null;
        BarItem barCurve = null;
        private void LoadData()
        {

            myData.Reload();
            myGraph1.myGraphPane.CurveList.Clear();
            myGraph1.SetSeriesX(myData.DateTime.Values, Charts.AxisType.DateAsOrdinal);

            //candleCurve = myGraph1.AddCandleStick(myData.DataStockCode, myData.High.Values, myData.Low.Values, myData.Open.Values, myData.Close.Values, myData.Volume.Values,
            //                                             Settings.sysChartBarUpColor, Settings.sysChartBarDnColor,
            //                                             Settings.sysChartBullCandleColor, Settings.sysChartBearCandleColor);

            lineCurve = myGraph1.AddCurveLine(myData.DataStockCode, myData.Close.Values, SymbolType.Circle, Color.Red, 1);
            barCurve = myGraph1.AddCurveBar(myData.DataStockCode, myData.Close.Values,Color.Navy,Color.Green, 1);
            myGraph1.SetFont(14);
            myGraph1.DefaultViewport();
            myGraph1.UpdateChart();
        }

        private void UpdatePriceRandom()
        {
            if (candleCurve == null) return;
            // Get the PointPairList
            IPointListEdit list = candleCurve.Points as IPointListEdit;
            int lastPos = list.Count - 1;
            if (lastPos < 0) return;
            StockPt item = (StockPt)candleCurve.Points[lastPos];

            item = new StockPt();
            //(list as StockPointList).RemoveAt(lastPos);
            item.Open += (double)common.system.Random(0, 10) / 10;
            item.High += (double)common.system.Random(1, 100) / 100;
            if (common.system.Random(0, 10) % 2 == 0)
            {
                item.Close += (double)common.system.Random(0, 70) / 100;
            }
            else
            {
                item.Close -= (double)common.system.Random(0, 70) / 100;
                item.Low -= (double)common.system.Random(0, 50) / 100;
            }
            item.Vol += common.system.Random(100, 1000);
            item = new StockPt(DateTime.FromOADate(item.Date).AddSeconds(10).ToOADate(),item.High,item.Low,item.Open,item.Close,item.Vol);

            (list as StockPointList).Add(item);


            myGraph1.DefaultViewport();
            

            myGraph1.UpdateChart();
            this.Text = list.Count.ToString();
            Application.DoEvents();
        }
       
        private void UpdatePrice()
        {
            int noOfUpdate = myData.UpdateDataFromLastTime();
            if (noOfUpdate < 0) return;

            //UpdatePrice(noOfUpdate, candleCurve);
            UpdatePrice(noOfUpdate, lineCurve);
            UpdatePrice(noOfUpdate, barCurve);
        
            //myGraph1.SetSeriesX(myData.DateTime.Values, Charts.AxisType.DateAsOrdinal);
            myGraph1.UpdateSeries();
            myGraph1.MoveToEnd();
            myGraph1.UpdateChart();


            this.Text = myData.DateTime.Count.ToString();
        }

        private void UpdatePrice(int noOfUpdate, CurveItem curve)
        {
            IPointListEdit list = curve.Points as IPointListEdit;
            int lastPos = list.Count - 1;

            if (curve.GetType() == typeof(JapaneseCandleStick))
            {
                if (lastPos >= 0)(list as StockPointList).RemoveAt(lastPos);
                for (int idx = Math.Max(0, lastPos); idx < myData.DateTime.Count; idx++)
                {
                    StockPt item = new StockPt(myData.DateTime[idx], myData.High.Values[idx], myData.Low.Values[idx],
                                               myData.Open.Values[idx], myData.Close.Values[idx], myData.Volume.Values[idx]);

                    (list as StockPointList).Add(item);
                }
            }
            else
            {
                if (lastPos >= 0) (list as PointPairList).RemoveAt(lastPos);
                for (int idx = Math.Max(0,lastPos); idx < myData.DateTime.Count; idx++)
                {
                    PointPair item = new PointPair(myData.DateTime[idx], myData.Close.Values[idx]);
                    (list as PointPairList).Add(item);
                }
            }
        }



        //??
        //private void DrawCurveIndicator(Indicators.Meta meta)
        //{
        //    //Indicators.Meta meta = Indicators.Libs.FindMetaByName(indicatorName);
        //    string curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + meta.ParameterString;
        //    //Remove the old one if any
        //    if (this.CurrentEditCurveName.Trim() != "")
        //    {
        //        RemoveCurveIndicator(this.CurrentEditCurveName, true);
        //        this.CurrentEditCurveName = curveName;
        //    }

        //    baseClass.controls.graphPanel myGraphPanel = (meta.DrawInNewWindow ? this.newPanel : this.pricePanel);

        //    DataSeries indicatorSeries = Indicators.Libs.GetIndicatorData(this.myData, meta);
        //    this.myData.DateTime.FirstValidValue = indicatorSeries.FirstValidValue;
        //    switch (meta.Output[0].ChartType)
        //    {
        //        case AppTypes.ChartTypes.Bar:
        //            PlotCurveBar(curveName, myGraphPanel, this.myData.DateTime, indicatorSeries,
        //                         meta.Output[0].Color, Color.Black, meta.Output[0].Weight);
        //            break;
        //        case AppTypes.ChartTypes.Line:
        //            PlotCurveLine(curveName, myGraphPanel, this.myData.DateTime, indicatorSeries,
        //                          meta.Output[0].Color, meta.Output[0].Weight);
        //            break;
        //    }
        //    // Some indicator such as MACD having more than one output series.
        //    // In such case, indicator form MUST have [form.ExtraInfo] propery to provide information for the output series. 
        //    DataSeries[] extraSeries = null;
        //    if (meta.Output.Length > 1) extraSeries = Indicators.Libs.GetIndicatorData(indicatorSeries, meta);
        //    if (extraSeries != null)
        //    {
        //        for (int idx = 0, metaIdx = 1; idx < extraSeries.Length && metaIdx < meta.Output.Length; idx++, metaIdx++)
        //        {
        //            this.myData.DateTime.FirstValidValue = extraSeries[idx].FirstValidValue;
        //            curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + meta.ParameterString + "-" + idx.ToString();
        //            switch (meta.Output[metaIdx].ChartType)
        //            {
        //                case AppTypes.ChartTypes.Bar:
        //                    PlotCurveBar(curveName, myGraphPanel, this.myData.DateTime, extraSeries[idx],
        //                                 meta.Output[metaIdx].Color, Color.Black, meta.Output[metaIdx].Weight);
        //                    break;
        //                case AppTypes.ChartTypes.Line:
        //                    PlotCurveLine(curveName, myGraphPanel, this.myData.DateTime, extraSeries[idx],
        //                                            meta.Output[metaIdx].Color, meta.Output[metaIdx].Weight);
        //                    break;

        //            }
        //        }
        //    }

        //    if (meta.DrawInNewWindow)
        //        newPanel.myGraphObj.myViewportX = pricePanel.myGraphObj.myViewportX;

        //    string paraStr = meta.ParameterString;
        //    curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + paraStr;
        //    string text = meta.ClassType.Name + (paraStr == "" ? "" : "(" + paraStr + ")");
        //    ListViewItem item = activeIndicatorLV.Add(curveName, text, meta.Output[0].Color);
        //    item.Tag = new IndicatorCurveInfo(curveName, meta);
        //}

        private void resetBtn_Click(object sender, EventArgs e)
        {
            myGraph1.DefaultViewport();
        }

        bool fProcessing = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;
                if (fGenData)
                    genData.GenPriceData(myData.DataStockCode);
                UpdatePrice();
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }

        private void timerBtn_Click(object sender, EventArgs e)
        {
            timer1.Interval = (int)intervalEd.Value*1000;
            timer1.Enabled = !timer1.Enabled;
            timerBtn.Text = (timer1.Enabled ? "Running" : "Stop");
        }

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            myGraph1.ZoomIn();
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            myGraph1.ZoomOut();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myGraph1.ZoomOut();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            myGraph1.MoveBackward();
        }

        private void fowardBtn_Click(object sender, EventArgs e)
        {
            myGraph1.MoveForward();
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            ClearNotifyError();
            if (codeEd.Text.Trim() == "")
            {
                NotifyError(codeLbl);
                return;
            }
            myData.DataTimeRange = cbTimeRange.myValue; 
            myData.DataTimeScale = cbTimeScale.myValue; 
            myData.DataStockCode = codeEd.Text.Trim();
            LoadData();
            this.Text = "";
            this.ShowMessage("");
        }

        private void genDataBtn_Click(object sender, EventArgs e)
        {
            fGenData = !fGenData;
            genDataBtn.Text = (fGenData? "Running" : "Stop");
        }

        private void moveToEndBtn_Click(object sender, EventArgs e)
        {
            myGraph1.MoveToEnd();
        }
    }
}
