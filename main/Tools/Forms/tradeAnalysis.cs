using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using ZedGraph;
using commonClass;

namespace Tools.Forms
{
    public partial class tradeAnalysis : baseClass.forms.baseGraphForm
    {
        #region private variables
        const int constPriceChartMarginBOTTOM = 45;
        const int constPriceChartMarginTOP = 5;
        const string constPaneNamePrice = "pricePanel";
        const string constPaneNameVolume = "volumePanel";
        const string constPaneNameNew = "newPanel";
        const string constCurveNamePrefixIndicator = "Indicator-";

        // Keep infomation of all indicators dynamically collected form plug-in .dll
        public AnalysisData myData = null;     //Working data loaded from SQL database

        private Charts.CurveList myCurveList = new Charts.CurveList();           // Keep all drawn curves in the chart
        private common.DictionaryList indicatorFormCache = new common.DictionaryList();  // To cache used indicator forms 
        private common.DictionaryList dataCache = new common.DictionaryList();           // To cache data used in indicator chart

        private baseClass.controls.graphPanel _pricePanel = null, _volumePanel = null, _newPanel = null;
        private baseClass.controls.graphPanel pricePanel
        {
            get
            {
                baseClass.controls.graphPanel pane = this.GetPane(constPaneNamePrice);
                if (pane == null)
                {
                    _pricePanel = CreatePane(constPaneNamePrice, 100);
                    _pricePanel.haveCloseButton = false;
                    _pricePanel.myGraphObj.SetFont(Settings.sysChartFontSize); 
                    _pricePanel.myGraphObj.ChartMarginTOP = constPriceChartMarginTOP;
                    _pricePanel.myGraphObj.ChartMarginBOTTOM = constPriceChartMarginBOTTOM;
                    _pricePanel.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);
                    _pricePanel.myGraphObj.myOnPointValue += new Charts.Controls.myGraphControl.OnPointValue(PointValueEventPrice);
                }
                else _pricePanel = pane;
                return _pricePanel;
            }
        }
        private baseClass.controls.graphPanel volumePanel
        {
            get
            {
                baseClass.controls.graphPanel pane = this.GetPane(constPaneNameVolume);
                if (pane == null)
                {
                    _volumePanel = CreatePane(constPaneNameVolume, 0);
                    _volumePanel.myGraphObj.SetFont(Settings.sysChartFontSize); 
                    _volumePanel.Height = this.ClientRectangle.Height / 4;
                    _volumePanel.haveCloseButton = true;
                    _volumePanel.Visible = false; //Defaul is invisible
                    _volumePanel.mySizingOptions = common.controls.basePanel.SizingOptions.Top;
                    _volumePanel.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);
                    _volumePanel.myGraphObj.myOnPointValue += new Charts.Controls.myGraphControl.OnPointValue(PointValueEventPrice);
                }
                else _volumePanel = pane;
                return _volumePanel;
            }
        }
        private baseClass.controls.graphPanel newPanel
        {
            get
            {
                baseClass.controls.graphPanel pane = this.GetPane(constPaneNameNew);
                if (pane == null)
                {
                    _newPanel = CreatePane(constPaneNameNew, 0, pricePanel.Name);
                    _newPanel.myGraphObj.SetFont(Settings.sysChartFontSize); 
                    _newPanel.Height = this.ClientRectangle.Height / 5;
                    _newPanel.haveCloseButton = true;
                    _newPanel.Visible = false;//Defaul is invisible
                    _newPanel.mySizingOptions = common.controls.basePanel.SizingOptions.Top; 
                    _newPanel.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);
                    _newPanel.myGraphObj.myOnPointValue += new Charts.Controls.myGraphControl.OnPointValue(PointValueEventIndicator);
                    _newPanel.myOnClosing += new common.controls.basePanel.OnClosing(NewPane_OnClosing);

                }
                else _newPanel = pane;
                return _newPanel;
            }
        }


        /// <summary>
        /// Synchronize charts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="state"></param>
        private void Chart_OnViewportChanged(object sender, Charts.ViewportState state)
        {
            if (pricePanel.Visible) pricePanel.myGraphObj.myViewportX = state.xRange;
            if (volumePanel.Visible) volumePanel.myGraphObj.myViewportX = state.xRange;
            if (newPanel.Visible) newPanel.myGraphObj.myViewportX = state.xRange;
        }
        public bool NewPane_OnClosing(object sender)
        {
            Charts.DrawCurve[] list = myCurveList.CurveInPane(newPanel.Name);
            for (int idx = 0; idx < list.Length; idx++)
            {
                RemoveCurveIndicator(list[idx].CurveName, false);
            }
            this.ReArrangePanes();
            return true;
        }

        private string PointValueEventPrice(CurveItem curve, int pointIdx)
        {
            if (!commonClass.Settings.sysChartShowDescription) return null;

            DateTime dt = DateTime.FromOADate(curve[pointIdx].X);
            string retVal = "";
            switch (this.ChartTimeScale.Type)
            { 
                case AppTypes.TimeScaleTypes.RealTime:
                case AppTypes.TimeScaleTypes.Minnute:
                case AppTypes.TimeScaleTypes.Hour: retVal = Languages.Libs.GetString("time") + " : " + dt.ToString(); break;
                case AppTypes.TimeScaleTypes.Day:  retVal = Languages.Libs.GetString("date") + " : " + dt.ToShortDateString(); break;
                case AppTypes.TimeScaleTypes.Week: retVal = Languages.Libs.GetString("week") + " : " + common.dateTimeLibs.WeekOfYear(dt).ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Month: retVal= Languages.Libs.GetString("month")+ " : " + dt.Month.ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Year: retVal = Languages.Libs.GetString("year") + " : " + dt.Year.ToString(); break;
            }
            retVal += common.Consts.constCRLF + Languages.Libs.GetString("openPrice") + " : " + myData.Open.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + Languages.Libs.GetString("highPrice") + " : " + myData.High.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + Languages.Libs.GetString("lowPrice") + " : " + myData.Low.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + Languages.Libs.GetString("closePrice") + " : " + myData.Close.Values[pointIdx].ToString(Settings.sysMaskPrice) +
                      common.Consts.constCRLF + Languages.Libs.GetString("volume") + " : " + myData.Volume.Values[pointIdx].ToString(Settings.sysMaskQty);
            return retVal;
        }
        private string PointValueEventIndicator(CurveItem curve, int pointIdx)
        {
            DateTime dt = DateTime.FromOADate(curve[pointIdx].X);
            string retVal = "";
            switch (this.ChartTimeScale.Type)
            {
                case AppTypes.TimeScaleTypes.RealTime:
                case AppTypes.TimeScaleTypes.Minnute:
                case AppTypes.TimeScaleTypes.Hour: retVal = Languages.Libs.GetString("time") + " : " + dt.ToString(); break;
                case AppTypes.TimeScaleTypes.Day: retVal = Languages.Libs.GetString("date") + " : " + dt.ToShortDateString(); break;
                case AppTypes.TimeScaleTypes.Week: retVal = Languages.Libs.GetString("week") + " : " + common.dateTimeLibs.WeekOfYear(dt).ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Month: retVal = Languages.Libs.GetString("month") + " : " + dt.Month.ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Year: retVal = Languages.Libs.GetString("year") + " : " + dt.Year.ToString(); break;
            }
            retVal  +=  common.Consts.constCRLF + curve.Label.Text +  " : " + curve[pointIdx].Y.ToString(Settings.sysMaskGeneralValue);
            return retVal;
        }

        private class IndicatorCurveInfo
        {
            public IndicatorCurveInfo(string curveName, application.Indicators.Meta metaData)
            {
                CurveName = curveName;
                meta = metaData;
            }
            public string CurveName = "";
            public application.Indicators.Meta meta = null;
        }
        private string CurrentEditCurveName = "";

        #endregion 
        // See Making Thread-Safe Calls by using BackgroundWorker
        // http://msdn.microsoft.com/en-us/library/ms171728.aspx
        private BackgroundWorker bgWorker = new BackgroundWorker();

        public tradeAnalysis()
        {
            try
            {
                InitializeComponent();
                this.myData = new AnalysisData();
                //Switch to use webservice
                this.myData.AccessMode = commonClass.DataAccessMode.WebService;

                this.SetMasterPane(new Point(0, activeIndicatorLV.Location.Y + activeIndicatorLV.Height));
                activeIndicatorLV.Visible = true;
                this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public ContextMenuStrip myContextMenuStrip
        {
            get { return pricePanel.myGraphObj.ContextMenuStrip; }
            set { pricePanel.myGraphObj.ContextMenuStrip = value; }
        }

        public override void SetLanguage()
        {
            this.ShowMessage("");
            base.SetLanguage();
            if (this.myData.DataStockCode == null) return;
            data.tmpDS.stockCodeRow stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(this.myData.DataStockCode);
            if (stockCodeRow != null)
            {
                if (commonClass.AppLibs.IsUseVietnamese())
                    this.Text = stockCodeRow.tickerCode.Trim() + " - " + stockCodeRow.name;
                else this.Text = stockCodeRow.tickerCode.Trim() + " - " + (stockCodeRow.IsnameEnNull()?common.Consts.constNotAvailable:stockCodeRow.nameEn);
            }
        }

        public delegate void EstimateTradePointFunc(tradeAnalysis sender,string strategyCode,
                                                    EstimateOptions options, data.tmpDS.tradeEstimateDataTable tbl);
        public event EstimateTradePointFunc myEstimateTradePoints = null;

        public static tradeAnalysis GetForm(string stockCode,AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            string cacheKey = typeof(tradeAnalysis).ToString();
            tradeAnalysis form = (tradeAnalysis)common.Data.dataCache.Find(cacheKey);
            if (form == null || form.IsDisposed)
            {
                form = new Forms.tradeAnalysis();
                common.Data.dataCache.Add(cacheKey, form);
            }
            form.ChartTimeRange = timeRange;
            form.ChartTimeScale = timeScale;
            form.ChartPriceType = AppTypes.ChartTypes.Line;
            form.UseStock(DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode));
            form.Visible = true;
            return form;
        }

        private AppTypes.ChartTypes _priceChartType = AppTypes.ChartTypes.None;
        public AppTypes.ChartTypes ChartPriceType
        {
            get { return this._priceChartType; }
            set
            {
                pricePanel.Visible = true;
                if (this._priceChartType == value) return;
                this._priceChartType = value;
                DrawCurvePRICE();
                UpdateChart();
            }
        }
        public AppTypes.TimeScale ChartTimeScale
        {
            get { return this.myData.DataTimeScale; }
            set
            {
                this.myData.DataTimeScale = value;
            }
        }

        private AppTypes.TimeRanges _chartTimeRange = AppTypes.TimeRanges.None;
        public AppTypes.TimeRanges ChartTimeRange
        {
            get { return _chartTimeRange; }
            set
            {
                _chartTimeRange = value;
                this.myData.DataTimeRange = value;
            }
        }

        public bool ChartVolumeVisibility
        {
            get { return this.volumePanel.Visible; }
            set
            {
                this.volumePanel.Visible = value;
                if (value)
                {
                    DrawCurveVOLUME();
                    UpdateChart();
                }
            }
        }
        public bool ChartHaveGrid = true;

        /// <summary>
        /// Set what stock to be used as default
        /// </summary>
        /// <param name="stockCodeRow"></param>
        public void UseStock(data.tmpDS.stockCodeRow stockCodeRow)
        {
            this.ShowMessage("");
            this.myData.DataStockCode = stockCodeRow.code;
            ReloadChart();
            SetLanguage();
        }

        /// <summary>
        /// Re-draw all curves in chart
        /// </summary>
        public void ReDrawChart()
        {
            ResetChart();
            DrawAllCurves();
            UpdateChart();
        }

        public void RestoreChart()
        {
            Charts.IntRange range = pricePanel.myGraphObj.myViewportX;
            UpdateChart();
            pricePanel.myGraphObj.myViewportX = range;
        }

        /// <summary>
        /// Reload data, and re-draw chart
        /// </summary>
        public void ReloadChart()
        {
            myData.LoadData();
            application.Indicators.Libs.ClearCache();

            //Remove all curves in chart
            myCurveList.RemoveAll();
            //And plot 2 curves : Price  and Volume 
            DrawCurvePRICE();
            DrawCurveVOLUME();
            UpdateChart();
        }

        /// <summary>
        /// Plot indicator charts. The function displays a form to collect indicator options and then plot the chart.
        /// </summary>
        /// <param name="indicatorTypeName">Indicator name to be drawn</param>
        /// 
        public void PlotIndicator(string indicatorName)
        {
            application.forms.baseIndicatorForm form = GetIndicatorForm(indicatorName);
            if (form == null) return;
            form.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>

        protected void PlotStrategyTradepoints(application.Strategy.Data.TradePoints tradePoints, baseClass.controls.graphPanel toPanel)
        {
            ClearStrategyTradepoints(toPanel);
            Charts.DrawCurve[] curveList = myCurveList.CurveInPane(toPanel.Name);
            if (curveList.Length == 0) return;
            CurveItem curveItem = curveList[0].Curve;

            TradePointInfo tradePointInfo;
            for (int idx = 0; idx < tradePoints.Count; idx++)
            {
                tradePointInfo = (TradePointInfo)tradePoints[idx];
                if (!tradePointInfo.isValid) continue;

                TextObj obj = new TextObj();
                obj.FontSpec.Size = Settings.sysTradePointMarkerFontSize;
                obj.FontSpec.IsBold = true;
                obj.FontSpec.Border.IsVisible = true;
                obj.FontSpec.Fill.IsVisible = true;
                obj.FontSpec.Fill.Color = Settings.sysTradePointMarkerColorBG;
                switch (toPanel.myGraphObj.myViewportState.myAxisType)
                {
                    case Charts.AxisType.DateAsOrdinal :
                        obj.Location.X = tradePointInfo.DataIdx+1; 
                        break;
                    default:
                        obj.Location.X = curveItem.Points[tradePointInfo.DataIdx].X;
                        break;
                }
                obj.Location.Y = curveItem.Points[tradePointInfo.DataIdx].Y;
                obj.Location.CoordinateFrame = CoordType.AxisXYScale;
                obj.Location.AlignH = AlignH.Center;
                switch (tradePointInfo.TradeAction)
                {
                    case AppTypes.TradeActions.Buy:
                    case AppTypes.TradeActions.Accumulate:
                        obj.Text = Settings.sysTradePointMarkeBUY;
                        obj.FontSpec.FontColor = Settings.sysTradePointMarkerColorBUY;
                        break;
                    case AppTypes.TradeActions.Sell:
                    case AppTypes.TradeActions.ClearAll:
                        obj.Text = Settings.sysTradePointMarkerSELL;
                        obj.FontSpec.FontColor = Settings.sysTradePointMarkerColorSELL;
                        break;
                    default:
                        obj.Text = Settings.sysTradePointMarkerOTHER;
                        obj.FontSpec.FontColor = Settings.sysTradePointMarkerColorOTHER;
                        break;
                }
                toPanel.myGraphObj.myGraphPane.GraphObjList.Add(obj);
            }
            toPanel.myGraphObj.UpdateChart();
        }

        protected void ClearStrategyTradepoints(baseClass.controls.graphPanel toPanel)
        {
           toPanel.myGraphObj.myGraphPane.GraphObjList.Clear();
           toPanel.myGraphObj.UpdateChart();
        }

        public void ClearStrategyTradepoints()
        {
            ClearStrategyTradepoints(pricePanel);
        }
        public void PlotStrategyTradepoints(application.Strategy.Meta meta, bool showEstimation)
        {
            ShowMessage("");
            EstimateOptions estOption = new EstimateOptions();
            data.tmpDS.tradeEstimateDataTable tbl = new data.tmpDS.tradeEstimateDataTable();
            TradePointInfo[] tradePoints = DataAccess.Libs.GetTradePointWithEstimationDetail(myData.DataTimeRange,myData.DataTimeScale.Code,myData.DataStockCode,meta.Code,
                                                                                             estOption, out tbl); 
            /// Estimate trade points and set tradepoint's [isValid] property to mark whether a tradepoint is valid or not.
            for (int idx = 0; idx < tradePoints.Length; idx++)
            {
                tradePoints[idx].isValid = !tbl[idx].ignored; 
            }
            PlotStrategyTradepoints(application.Strategy.Libs.ToTradePoints(tradePoints), pricePanel);

            //Call estimation handler if any.
            if (showEstimation && myEstimateTradePoints != null) 
                myEstimateTradePoints(this,meta.Code,estOption, tbl);
        }

        public void ZoomIn()
        {
            pricePanel.myGraphObj.ZoomIn();
        }
        public void ZoomOut()
        {
            pricePanel.myGraphObj.ZoomOut();
        }

        #region Functions for real-time chart
        public void UpdateDataFromLastTime()
        {
            this.bgWorker.RunWorkerAsync();
        }
        private void UpdateCurvePRICE(int noOfUpdate)
        {
            CurveItem curve = pricePanel.myGraphObj.myGraphPane.CurveList[pricePanel.Name];
            IPointListEdit list = curve.Points as IPointListEdit;
            int lastPos = list.Count - 1;
            if (curve.GetType() == typeof(JapaneseCandleStickItem))
            {
                if (lastPos>=0) (list as StockPointList).RemoveAt(lastPos);
                for (int idx = Math.Max(0,lastPos); idx < myData.DateTime.Count; idx++)
                {
                    (list as StockPointList).Add(new StockPt(myData.DateTime[idx], myData.High.Values[idx], myData.Low.Values[idx],
                                                             myData.Open.Values[idx], myData.Close.Values[idx], myData.Volume.Values[idx]));
                }
            }
            else
            {
                if (lastPos >= 0) (list as PointPairList).RemoveAt(lastPos);
                for (int idx = Math.Max(0, lastPos); idx < myData.DateTime.Count; idx++)
                {
                    (list as PointPairList).Add(new PointPair(myData.DateTime[idx], myData.Close.Values[idx]));
                }
            }
            //Only update chart when it is at the last view
            if (pricePanel.myGraphObj.IsLastView())
            {
                pricePanel.myGraphObj.UpdateSeries();
                pricePanel.myGraphObj.MoveToEnd();
            }
            pricePanel.myGraphObj.UpdateChart();
        }
        private void UpdateCurveVOLUME(int noOfUpdate)
        {
            IPointListEdit list = volumePanel.myGraphObj.myGraphPane.CurveList[volumePanel.Name].Points as IPointListEdit;
            int lastPos = list.Count - 1;
            (list as PointPairList).RemoveAt(lastPos);
            for (int idx = lastPos; idx < myData.DateTime.Count; idx++)
            {
                (list as PointPairList).Add(new PointPair(myData.DateTime[idx], myData.Close.Values[idx]));
            }
            volumePanel.myGraphObj.UpdateSeries();
            volumePanel.myGraphObj.MoveToEnd();
            volumePanel.myGraphObj.UpdateChart();
        }
        #endregion 

        //==================================
        // Draw and remove curves
        //==================================

        //Bug : do not reset when change data source 
        private void ResetChart()
        {
            pricePanel.ResetGraph();
            volumePanel.ResetGraph();
            newPanel.ResetGraph();
        }

        private void DrawCurvePRICE()
        {
            ClearStrategyTradepoints(pricePanel);

            string curveName = pricePanel.Name;
            pricePanel.myGraphObj.myGraphPane.GraphObjList.Clear();
            myCurveList.Remove(curveName);

            CurveItem curveItem = null;
            switch (this.ChartPriceType)
            {
                case AppTypes.ChartTypes.Bar:
                    curveItem = PlotCurveBar(curveName, pricePanel, this.myData.DateTime, myData.Close,
                                 Settings.sysChartBarUpColor, Settings.sysChartBarUpColor, 1);
                    break;
                case AppTypes.ChartTypes.Line:
                    curveItem = PlotCurveLine(curveName, pricePanel, this.myData.DateTime, myData.Close,
                                  Settings.sysChartLineCandleColor, 1);
                    break;
                default:
                    curveItem = PlotCandleStick(curveName, pricePanel, myData, Settings.sysChartBarUpColor, Settings.sysChartBarDnColor,
                                    Settings.sysChartBullCandleColor, Settings.sysChartBearCandleColor);
                    break;
            }
            pricePanel.myGraphObj.DefaultViewport();
        }

        // ZedGraph ignores points with double.NaN so invalid value must set to this.
        private double[] MakeChartValue(DataSeries ds)
        {
            double[] retList = new double[ds.Count];
            for (int idx = 0; idx < ds.Count; idx++)
            {
                retList[idx] = (idx<ds.FirstValidValue?double.NaN:ds.Values[idx]);
            }
            return retList;
        }
        private CurveItem PlotCurveBar(string curveName,Charts.Controls.baseGraphPanel graphPane, DataSeries xSeries, DataSeries ySeries,
                                       Color color, Color bdColor, int weight)
        {
            graphPane.myGraphObj.SetSeriesX(xSeries.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveBar(curveName, MakeChartValue(ySeries), color, bdColor, weight);
            myCurveList.Add(curveItem, curveName, graphPane.myGraphObj.myGraphPane, graphPane.Name);
            return curveItem;
        }
        private CurveItem PlotCurveLine(string curveName,Charts.Controls.baseGraphPanel graphPane, DataSeries xSeries, DataSeries ySeries,
                                       Color color, int weight)
        {
            graphPane.myGraphObj.SetSeriesX(xSeries.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveLine(curveName, MakeChartValue(ySeries), SymbolType.Default, color, weight);
            myCurveList.Add(curveItem, curveName, graphPane.myGraphObj.myGraphPane, graphPane.Name);
            return curveItem;
        }
        private CurveItem PlotCandleStick(string curveName, Charts.Controls.baseGraphPanel graphPane, AnalysisData data,
                                          Color barUpColor,Color  barDnColor,Color bullCandleColor,Color bearCandleColor)
        {
            graphPane.myGraphObj.SetSeriesX(data.DateTime.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCandleStick(curveName,
                                                                      MakeChartValue(data.High),
                                                                      MakeChartValue(data.Low),
                                                                      MakeChartValue(data.Open),
                                                                      MakeChartValue(data.Close),
                                                                      MakeChartValue(data.Volume),
                                                                      barUpColor,barDnColor,bullCandleColor,bearCandleColor);
            myCurveList.Add(curveItem, curveName, graphPane.myGraphObj.myGraphPane, graphPane.Name);
            return curveItem;
        }

        private void DrawCurveVOLUME()
        {
            string curveName = volumePanel.Name;
            myCurveList.Remove(curveName);
            this.myData.DateTime.FirstValidValue = myData.Volume.FirstValidValue;
            PlotCurveBar(volumePanel.Name,volumePanel,this.myData.DateTime, myData.Volume,
                         Settings.sysChartVolumesColor, Settings.sysChartVolumesColor, 1);
            volumePanel.myGraphObj.DefaultViewport();
        }

        //Draw / Remove indicator curves
        private void RemoveCurveIndicator(string name, bool allStartWith)
        {
            myCurveList.Remove(name, allStartWith);
            activeIndicatorLV.Remove(name);
        }
        private void DrawCurveIndicator(application.Indicators.Meta meta)
        {
            //Indicators.Meta meta = Indicators.Libs.FindMetaByName(indicatorName);
            string curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + meta.ParameterString;
            //Remove the old one if any
            if (this.CurrentEditCurveName.Trim() != "")
            {
                RemoveCurveIndicator(this.CurrentEditCurveName, true);
                this.CurrentEditCurveName = curveName;
            }

            baseClass.controls.graphPanel myGraphPanel = (meta.DrawInNewWindow ? this.newPanel : this.pricePanel);

            DataSeries indicatorSeries = application.Indicators.Libs.GetIndicatorData(this.myData, meta);
            this.myData.DateTime.FirstValidValue = indicatorSeries.FirstValidValue;
            switch (meta.Output[0].ChartType)
            {
                case AppTypes.ChartTypes.Bar:
                     PlotCurveBar(curveName,myGraphPanel, this.myData.DateTime, indicatorSeries,
                                  meta.Output[0].Color, Color.Black, meta.Output[0].Weight );
                     break;
                case AppTypes.ChartTypes.Line:
                     PlotCurveLine(curveName, myGraphPanel,this.myData.DateTime, indicatorSeries,
                                   meta.Output[0].Color, meta.Output[0].Weight);
                    break;
            }
            // Some indicator such as MACD having more than one output series.
            // In such case, indicator form MUST have [form.ExtraInfo] propery to provide information for the output series. 
            DataSeries[] extraSeries = null;
            if (meta.Output.Length > 1) extraSeries = application.Indicators.Libs.GetIndicatorData(indicatorSeries, meta);
            if (extraSeries != null)
            {
                for (int idx = 0, metaIdx = 1; idx < extraSeries.Length && metaIdx < meta.Output.Length; idx++, metaIdx++)
                {
                    this.myData.DateTime.FirstValidValue = extraSeries[idx].FirstValidValue;
                    curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + meta.ParameterString + "-" + idx.ToString();
                    switch (meta.Output[metaIdx].ChartType)
                    {
                        case AppTypes.ChartTypes.Bar:
                            PlotCurveBar(curveName, myGraphPanel, this.myData.DateTime, extraSeries[idx],
                                         meta.Output[metaIdx].Color, Color.Black, meta.Output[metaIdx].Weight);
                            break;
                        case AppTypes.ChartTypes.Line:
                            PlotCurveLine(curveName, myGraphPanel, this.myData.DateTime, extraSeries[idx],
                                                    meta.Output[metaIdx].Color, meta.Output[metaIdx].Weight);
                            break;

                    }
                }
            }

            if (meta.DrawInNewWindow)
                newPanel.myGraphObj.myViewportX = pricePanel.myGraphObj.myViewportX;

            string paraStr = meta.ParameterString;
            curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + paraStr;
            string text = meta.ClassType.Name + (paraStr == "" ? "" : "(" + paraStr + ")");
            ListViewItem item = activeIndicatorLV.Add(curveName, text, meta.Output[0].Color);
            item.Tag = new IndicatorCurveInfo(curveName,meta);
        }

        private void DrawActiveIndicator()
        {
            //Indicators.forms.baseIndicatorForm form;
            //Indicators.IndicatorMeta meta;
            //for (int idx = 0; idx < activeIndicatorLV.Items.Count; idx++)
            //{
            //    meta = Indicators.Libs.FindMetaByName(activeIndicatorLV.Items[idx].Name);
            //    if (meta == null) continue;
            //    indicatorFormCache.Find(meta.FormType.Name);
            //    form = (Indicators.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.Type.Name);
            //    if (form == null || form.IsDisposed) continue;
            //    //RemoveCurves(form);
            //    //DrawIndicatorCurves(form);
            //}
        }
        private void DrawAllCurves()
        {
            DrawCurvePRICE();
            DrawCurveVOLUME();
            DrawActiveIndicator();
        }
        private void UpdateChart()
        {
            newPanel.Visible = myCurveList.CurveInPane(newPanel.Name).Length > 0;
            pricePanel.PlotGraph();
            volumePanel.PlotGraph();
            newPanel.PlotGraph();
            this.ReArrangePanes();
        }

        //Get indicator form from indicator type (SMA, MACD,Stoch...)
        private application.forms.baseIndicatorForm GetIndicatorForm(string typeName)
        {
            application.Indicators.Meta meta = application.Indicators.Libs.FindMetaByName(typeName);
            if (meta == null) return null;
            return GetIndicatorForm(meta);
        }

        private application.forms.baseIndicatorForm GetIndicatorForm(application.Indicators.Meta meta)
        {
            if (meta == null) return null;
            application.forms.baseIndicatorForm form = null;

            form = (application.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.ClassType.Name);
            if (form == null || form.IsDisposed)
            {
                form = application.Indicators.Libs.GetIndicatorForm(meta);
                form.Text = meta.Name;
                form.onPlotChart += new application.forms.baseIndicatorForm.PlotChart(IndicatorFormHandler);
            }
            this.indicatorFormCache.Add(meta.ClassType.Name, form);
            return form;
        }
        private application.forms.baseIndicatorForm FindIndicatorForm(string typeName)
        {
            application.Indicators.Meta meta = application.Indicators.Libs.FindMetaByName(typeName);
            if (meta == null) return null;
            application.forms.baseIndicatorForm form = (application.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.ClassType.Name);
            if (form == null || form.IsDisposed) return null;
            return form;
        }
        //IndicatorFormHandler : Draw / Remove indicator's curves
        private void IndicatorFormHandler(application.forms.baseIndicatorForm indicatorForm, bool removeChart)
        {
            if (removeChart)
            {
                string curveName = constCurveNamePrefixIndicator + indicatorForm.FormMeta.ClassType.Name + "-" +
                                   indicatorForm.FormMeta.ParameterString;
                RemoveCurveIndicator(curveName, true);
            }
            else
            {
                DrawCurveIndicator(indicatorForm.FormMeta);
            }
            UpdateChart();
        }
        protected override void RefreshForm()
        {
            ReDrawChart();
        }

        #region event handler
        private void editIndicatorMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeIndicatorLV.FocusedItem == null) return;
                IndicatorCurveInfo info = (IndicatorCurveInfo)activeIndicatorLV.FocusedItem.Tag;
                application.forms.baseIndicatorForm form = GetIndicatorForm(info.meta);
                if (form == null) return;
                this.CurrentEditCurveName = info.CurveName;
                form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                this.CurrentEditCurveName = "";
            }
        }
        private void removeIndicatorMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeIndicatorLV.FocusedItem == null) return;
                RemoveCurveIndicator(((IndicatorCurveInfo)activeIndicatorLV.FocusedItem.Tag).CurveName, true);
                UpdateChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }


        //UpdateDataFromLastTime
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                int noOfUpdate = myData.UpdateDataFromLastTime();
                if (noOfUpdate < 0) return;
                if (pricePanel.Visible) UpdateCurvePRICE(noOfUpdate);
                if (volumePanel.Visible) UpdateCurveVOLUME(noOfUpdate);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}