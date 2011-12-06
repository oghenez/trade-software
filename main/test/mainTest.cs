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
        application.AnalysisData myData = new application.AnalysisData();
        public mainTest()
        {
            try
            {
                InitializeComponent();
                cbTimeScale.LoadData();
                cbTimeRange.LoadData();
                timer1.Interval = 5000;
                //data.system.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
                myData.DataStockCode = "SSI";
                myData.DataTimeScale = commonClass.AppTypes.MainDataTimeScale;
                myData.DataTimeRange = commonClass.AppTypes.TimeRanges.Y5;

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
            //myData.Reload();
            graphPane1.myGraphObj.myGraphPane.CurveList.Clear();
            graphPane1.myGraphObj.SetSeriesX(myData.DateTime.Values, Charts.AxisType.DateAsOrdinal);

            //candleCurve = graphPane1.myGraphObj.AddCandleStick(myData.DataStockCode, myData.High.Values, myData.Low.Values, myData.Open.Values, myData.Close.Values, myData.Volume.Values,
            //                                             Settings.sysChartBarUpColor, Settings.sysChartBarDnColor,
            //                                             Settings.sysChartBullCandleColor, Settings.sysChartBearCandleColor);

            lineCurve = graphPane1.myGraphObj.AddCurveLine(myData.DataStockCode, myData.Close.Values, SymbolType.Circle, Color.Red, 1);
            barCurve = graphPane1.myGraphObj.AddCurveBar(myData.DataStockCode, myData.Close.Values,Color.Navy,Color.Green, 1);
            graphPane1.myGraphObj.SetFont(14);
            graphPane1.myGraphObj.DefaultViewport();
            graphPane1.myGraphObj.UpdateChart();
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


            graphPane1.myGraphObj.DefaultViewport();
            

            graphPane1.myGraphObj.UpdateChart();
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
        
            //graphPane1.myGraphObj.SetSeriesX(myData.DateTime.Values, Charts.AxisType.DateAsOrdinal);
            graphPane1.myGraphObj.UpdateSeries();
            graphPane1.myGraphObj.MoveToEnd();
            graphPane1.myGraphObj.UpdateChart();


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

        private void DrawCurveIndicator(Indicators.Meta meta)
        {
            graphPane1.myGraphObj.myGraphPane.CurveList.Clear();

            //Indicators.Meta meta = Indicators.Libs.FindMetaByName(indicatorName);
            string curveName = meta.ClassType.Name + "-" + meta.ParameterString;
            Charts.Controls.baseGraphPanel myGraphPanel = graphPane1;

            commonClass.DataSeries indicatorSeries = Indicators.Libs.GetIndicatorData(this.myData, meta);
            this.myData.DateTime.FirstValidValue = indicatorSeries.FirstValidValue;
            switch (meta.Output[0].ChartType)
            {
                case commonClass.AppTypes.ChartTypes.Bar:
                    PlotCurveBar(curveName, myGraphPanel, this.myData.DateTime, indicatorSeries,
                                 meta.Output[0].Color, Color.Black, meta.Output[0].Weight);
                    break;
                case commonClass.AppTypes.ChartTypes.Line:
                    PlotCurveLine(curveName, myGraphPanel, this.myData.DateTime, indicatorSeries,
                                  meta.Output[0].Color, meta.Output[0].Weight);
                    break;
            }
            // Some indicator such as MACD having more than one output series.
            // In such case, indicator form MUST have [form.ExtraInfo] propery to provide information for the output series. 
            commonClass.DataSeries[] extraSeries = null;
            if (meta.Output.Length > 1) extraSeries = Indicators.Libs.GetIndicatorData(indicatorSeries, meta);
            if (extraSeries != null)
            {
                for (int idx = 0, metaIdx = 1; idx < extraSeries.Length && metaIdx < meta.Output.Length; idx++, metaIdx++)
                {
                    this.myData.DateTime.FirstValidValue = extraSeries[idx].FirstValidValue;
                    curveName = meta.ClassType.Name + "-" + meta.ParameterString + "-" + idx.ToString();
                    switch (meta.Output[metaIdx].ChartType)
                    {
                        case commonClass.AppTypes.ChartTypes.Bar:
                            PlotCurveBar(curveName, myGraphPanel, this.myData.DateTime, extraSeries[idx],
                                         meta.Output[metaIdx].Color, Color.Black, meta.Output[metaIdx].Weight);
                            break;
                        case commonClass.AppTypes.ChartTypes.Line:
                            PlotCurveLine(curveName, myGraphPanel, this.myData.DateTime, extraSeries[idx],
                                                    meta.Output[metaIdx].Color, meta.Output[metaIdx].Weight);
                            break;

                    }
                }
            }
            graphPane1.myGraphObj.DefaultViewport();
            graphPane1.myGraphObj.UpdateChart(); 
        }
        private CurveItem PlotCurveBar(string curveName, Charts.Controls.baseGraphPanel graphPane, commonClass.DataSeries xSeries, commonClass.DataSeries ySeries,
                                               Color color, Color bdColor, int weight)
        {
            graphPane1.myGraphObj.SetSeriesX(xSeries.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveBar(curveName, ySeries.Values, color, bdColor, weight);
            return curveItem;
        }
        private CurveItem PlotCurveLine(string curveName, Charts.Controls.baseGraphPanel graphPane, commonClass.DataSeries xSeries, commonClass.DataSeries ySeries,
                                       Color color, int weight)
        {
            graphPane1.myGraphObj.SetSeriesX(xSeries.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveLine(curveName, ySeries.Values, SymbolType.None, color, weight);
            return curveItem;
        }
        private CurveItem PlotCandleStick(string curveName, Charts.Controls.baseGraphPanel graphPane, application.AnalysisData data,
                                          Color barUpColor, Color barDnColor, Color bullCandleColor, Color bearCandleColor)
        {
            graphPane1.myGraphObj.SetSeriesX(data.DateTime.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCandleStick(curveName, data.High.Values, data.Low.Values, data.Open.Values, data.Close.Values, data.Volume.Values,
                                                                      barUpColor, barDnColor, bullCandleColor, bearCandleColor);
            return curveItem;
        }



        private void resetBtn_Click(object sender, EventArgs e)
        {
            graphPane1.myGraphObj.DefaultViewport();

            Indicators.Meta meta = Indicators.Libs.FindMetaByName("SMA");
            DrawCurveIndicator(meta);
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
            graphPane1.myGraphObj.ZoomIn();
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            graphPane1.myGraphObj.ZoomOut();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            graphPane1.myGraphObj.ZoomOut();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            graphPane1.myGraphObj.MoveBackward();
        }

        private void fowardBtn_Click(object sender, EventArgs e)
        {
            graphPane1.myGraphObj.MoveForward();
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
            graphPane1.myGraphObj.MoveToEnd();
        }
    }
}
