using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using commonClass;
using application;

namespace test
{
    public partial class chartTest : baseClass.forms.baseForm
    {
        bool fGenData = false;
        application.AnalysisData myData = new application.AnalysisData();
        public chartTest()
        {
            try
            {
                InitializeComponent();
                cbTimeScale.LoadData();
                cbTimeRange.LoadData();
                cbChartType.LoadData();
                timer1.Interval = 5000;
                data.SysLibs.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
                myData.DataStockCode = "";
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
        private void Chart_OnViewportChanged(object sender, Charts.ViewportState state)
        {
            if (pricePane.Visible) pricePane.myGraphObj.myViewportX = state.xRange;
            if (volumePanel.Visible) volumePanel.myGraphObj.myViewportX = state.xRange;
        }
        private void LoadData()
        {
            DataAccess.Libs.ClearAnalysisDataCache(myData);
            myData.LoadData();

            pricePane.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);
            volumePanel.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);

            pricePane.myGraphObj.myOnPointValue += new Charts.Controls.myGraphControl.OnPointValue(PointValueEventPrice);
            volumePanel.myGraphObj.myOnPointValue += new Charts.Controls.myGraphControl.OnPointValue(PointValueEventPrice);

            pricePane.myGraphObj.myGraphPane.CurveList.Clear();
            pricePane.myGraphObj.SetSeriesX(myData.DateTime.Values, Charts.AxisType.DateAsOrdinal);

            switch (cbChartType.myValue)
            {
                case AppTypes.ChartTypes.CandleStick:
                    candleCurve = pricePane.myGraphObj.AddCandleStick(myData.DataStockCode, myData.High.Values, myData.Low.Values, myData.Open.Values, myData.Close.Values, myData.Volume.Values,
                                                                      commonClass.Settings.sysChartBarUpColor, commonClass.Settings.sysChartBarDnColor,
                                                                      commonClass.Settings.sysChartBullCandleColor, commonClass.Settings.sysChartBearCandleColor);
                    break;
                case AppTypes.ChartTypes.Line:
                    lineCurve = pricePane.myGraphObj.AddCurveLine(myData.DataStockCode, myData.Close.Values, SymbolType.Circle, Color.Blue, 1);
                    break;
                case AppTypes.ChartTypes.Bar:
                    barCurve = pricePane.myGraphObj.AddCurveBar(myData.DataStockCode, myData.Close.Values, Color.Blue, Color.Blue, 1);
                    break;
            }
            pricePane.myGraphObj.SetFont(14);
            pricePane.myGraphObj.DefaultViewport();
            pricePane.myGraphObj.UpdateChart();

            volumePanel.myGraphObj.myGraphPane.CurveList.Clear();
            volumePanel.myGraphObj.SetSeriesX(myData.DateTime.Values, Charts.AxisType.DateAsOrdinal);
            barCurve = volumePanel.myGraphObj.AddCurveBar(myData.DataStockCode, myData.Volume.Values, Color.Navy, Color.Green, 1);
            volumePanel.myGraphObj.SetFont(14);
            volumePanel.myGraphObj.DefaultViewport();
            volumePanel.myGraphObj.UpdateChart();
        }

        private void UpdatePrice()
        {
            int noOfUpdate = myData.UpdateDataFromLastTime();
            if (myData.Close.Count > 0)
            {
                this.Text = DateTime.FromOADate(myData.DateTime[myData.DateTime.Count - 1]).ToString() + " - " +
                            myData.Close[myData.Close.Count - 1].ToString() + " - " +
                            myData.Volume[myData.Volume.Count - 1].ToString();
            }
            if (noOfUpdate < 0) return;
            switch (cbChartType.myValue)
            {
                case AppTypes.ChartTypes.CandleStick:
                    UpdatePrice(noOfUpdate, candleCurve);
                    break;
                case AppTypes.ChartTypes.Line:
                    UpdatePrice(noOfUpdate, lineCurve);
                    break;
                case AppTypes.ChartTypes.Bar:
                    UpdatePrice(noOfUpdate, barCurve);
                    break;
            }
            //graphPane1.myGraphObj.SetSeriesX(myData.DateTime.Values, Charts.AxisType.DateAsOrdinal);
            pricePane.myGraphObj.UpdateSeries();
            pricePane.myGraphObj.MoveToEnd();
            pricePane.myGraphObj.UpdateChart();

            //this.Text = myData.DateTime.Count.ToString();
        }

        private void UpdatePrice(int noOfUpdate, CurveItem curve)
        {
            this.ShowMessage("Update " + noOfUpdate.ToString());
            IPointListEdit list = curve.Points as IPointListEdit;
            int lastPos = list.Count - 1;

            if (curve.GetType() == typeof(JapaneseCandleStickItem))
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
            pricePane.myGraphObj.myGraphPane.CurveList.Clear();

            //Indicators.Meta meta = Indicators.Libs.FindMetaByName(indicatorName);
            string curveName = meta.ClassType.Name + "-" + meta.ParameterString;
            Charts.Controls.baseGraphPanel myGraphPanel = pricePane;

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
            pricePane.myGraphObj.DefaultViewport();
            pricePane.myGraphObj.UpdateChart(); 
        }
        private CurveItem PlotCurveBar(string curveName, Charts.Controls.baseGraphPanel graphPane, commonClass.DataSeries xSeries, commonClass.DataSeries ySeries,
                                               Color color, Color bdColor, int weight)
        {
            pricePane.myGraphObj.SetSeriesX(xSeries.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveBar(curveName, ySeries.Values, color, bdColor, weight);
            return curveItem;
        }
        private CurveItem PlotCurveLine(string curveName, Charts.Controls.baseGraphPanel graphPane, commonClass.DataSeries xSeries, commonClass.DataSeries ySeries,
                                       Color color, int weight)
        {
            pricePane.myGraphObj.SetSeriesX(xSeries.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveLine(curveName, ySeries.Values, SymbolType.None, color, weight);
            return curveItem;
        }
        private CurveItem PlotCandleStick(string curveName, Charts.Controls.baseGraphPanel graphPane, application.AnalysisData data,
                                          Color barUpColor, Color barDnColor, Color bullCandleColor, Color bearCandleColor)
        {
            pricePane.myGraphObj.SetSeriesX(data.DateTime.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCandleStick(curveName, data.High.Values, data.Low.Values, data.Open.Values, data.Close.Values, data.Volume.Values,
                                                                      barUpColor, barDnColor, bullCandleColor, bearCandleColor);
            return curveItem;
        }

        private string PointValueEventPrice(CurveItem curve, int pointIdx)
        {
            DateTime dt = DateTime.FromOADate(curve[pointIdx].X);
            string retVal = "";
            retVal =  pointIdx.ToString() + common.Consts.constCRLF +
                      Languages.Libs.GetString("date") + " : " + dt.ToShortDateString(); 
            retVal += common.Consts.constCRLF + Languages.Libs.GetString("openPrice") + " : " + myData.Open.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + Languages.Libs.GetString("highPrice") + " : " + myData.High.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + Languages.Libs.GetString("lowPrice") + " : " + myData.Low.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + Languages.Libs.GetString("closePrice") + " : " + myData.Close.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + Languages.Libs.GetString("volume") + " : " + myData.Volume.Values[pointIdx].ToString(Settings.sysMaskQty);
            //this.Text = pointIdx.ToString() + "/" + (myData.DateTime.Count-1).ToString();
            return retVal;
        }


        protected void PlotTradepoints()
        {
            pricePane.myGraphObj.myGraphPane.GraphObjList.Clear();
            CurveItem curveItem = candleCurve;
            TextObj obj = new TextObj();
            obj.FontSpec.Size = 14;
            obj.FontSpec.Border.IsVisible = true;
            obj.FontSpec.Fill.IsVisible = true;
            obj.Location.X = curveItem.Points.Count;
            obj.Location.Y = curveItem.Points[curveItem.Points.Count - 1].Y;
            obj.Location.CoordinateFrame = CoordType.AxisXYScale;
            obj.Text = "O";
            pricePane.myGraphObj.myGraphPane.GraphObjList.Add(obj);
            pricePane.myGraphObj.UpdateChart();
        }


        private void resetBtn_Click(object sender, EventArgs e)
        {
            pricePane.myGraphObj.DefaultViewport();

            //Indicators.Meta meta = Indicators.Libs.FindMetaByName("SMA");
            //DrawCurveIndicator(meta);
        }

        bool fProcessing = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;
                if (fGenData)
                {
                    genData.GenPriceData(myData.DataStockCode);
                    if (updateChartChk.Checked) UpdatePrice();
                }
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            pricePane.myGraphObj.ZoomIn();
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            pricePane.myGraphObj.ZoomOut();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pricePane.myGraphObj.ZoomOut();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            pricePane.myGraphObj.MoveBackward();
        }

        private void fowardBtn_Click(object sender, EventArgs e)
        {
            pricePane.myGraphObj.MoveForward();
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            genData.Reset();
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
            //PlotTradepoints();

            this.Text = "";
            this.ShowMessage("");
        }

        private void genDataBtn_Click(object sender, EventArgs e)
        {
            fGenData = !fGenData;
            timer1.Enabled = fGenData;
            timer1.Interval = (int)intervalEd.Value * 1000;
            genDataBtn.Text = (fGenData? "Running" : "Stop");
            if (fGenData) genData.Reset();
        }

        private void moveToEndBtn_Click(object sender, EventArgs e)
        {
            pricePane.myGraphObj.MoveToEnd();
        }

        private string zedGraphControl1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointValueEventPrice(curve, iPt);
            return default(string);
        }

        private void mainTest_Resize(object sender, EventArgs e)
        {
            volumePanel.Width = this.Width;
            pricePane.Size = new Size(this.Width, this.Height - pricePane.Location.Y - volumePanel.Height - 2 * SystemInformation.CaptionHeight-15);
        }
    }
}
