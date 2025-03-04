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
using commonTypes;
using commonClass;
using System.Reflection;
using System.Collections;
using WeifenLuo.WinFormsUI.Docking;

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
        public DataAccess.AnalysisData myData = null;     //Working data loaded from SQL database
        private TradePointInfo[] tradePoints;

        private Charts.CurveList myCurveList = new Charts.CurveList();           // Keep all drawn curves in the chart
        private common.DictionaryList indicatorFormCache = new common.DictionaryList();  // To cache used indicator forms 
        private common.DictionaryList dataCache = new common.DictionaryList();           // To cache data used in indicator chart

        private baseClass.controls.graphPanel _pricePanel = null, _volumePanel = null, _newPanel = null;
        
        //???

        class NewPanelList : Hashtable
        {
            //Hashtable list = new Hashtable();
            internal void Add(baseClass.controls.graphPanel panel)
            {
                this.Add(panel.Name,panel);
            }
            internal baseClass.controls.graphPanel Find(string key)
            {
                return (baseClass.controls.graphPanel)this[key];
            }

            internal baseClass.controls.graphPanel FindByText(string text)
            {
                foreach (DictionaryEntry item in this)
                {
                    if ((item.Value as baseClass.controls.graphPanel).getText().Contains(text)) return (item.Value as baseClass.controls.graphPanel);
                }
                return null;
            }
            internal void SetViewportX(Charts.IntRange xRange)
            {
                foreach (DictionaryEntry item in this)
                {
                    if ((item.Value as baseClass.controls.graphPanel).Visible)
                    {
                        (item.Value as baseClass.controls.graphPanel).myGraphObj.myViewportX = xRange;
                    }
                }
            }


            internal void Remove(baseClass.controls.graphPanel pane)
            {
                this.Remove(pane.Name);
            }

            internal void ResetGraph()
            {
                foreach (DictionaryEntry item in this)
                {
                    (item.Value as baseClass.controls.graphPanel).ResetGraph();
                }
            }

            internal void PlotGraph()
            {
                foreach (DictionaryEntry item in this)
                {
                     (item.Value as baseClass.controls.graphPanel).PlotGraph();
                }
            }
        }
        NewPanelList myNewPanelList = new NewPanelList();
       

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
        

        private string MakeNewPanelName(string value)
        {
            return "NewWindow-" + common.system.UniqueString();
        }
        
        /// <summary>
        /// Create new Panel for drawing
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public baseClass.controls.graphPanel CreateNewPanel(string name)
        {                  
            _newPanel = CreatePane(name, 0, pricePanel.Name);
            _newPanel.myGraphObj.SetFont(Settings.sysChartFontSize);
            _newPanel.Height = this.ClientRectangle.Height / 5;
            _newPanel.haveCloseButton = true;
            _newPanel.Visible = true;
            _newPanel.mySizingOptions = common.controls.basePanel.SizingOptions.Top;
            _newPanel.myGraphObj.myOnViewportChanged += new Charts.Controls.myGraphControl.OnViewportChanged(this.Chart_OnViewportChanged);
            _newPanel.myGraphObj.myOnPointValue += new Charts.Controls.myGraphControl.OnPointValue(PointValueEventIndicator);
            _newPanel.myOnClosing += new common.controls.basePanel.OnClosing(NewPane_OnClosing);
            myNewPanelList.Add(_newPanel);
            return _newPanel;            
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
            //if (newPanel.Visible) newPanel.myGraphObj.myViewportX = state.xRange;

            myNewPanelList.SetViewportX(state.xRange);

           
        }

        /// <summary>
        /// Manipulate the closing action
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public bool NewPane_OnClosing(object sender)
        {
            //Remove Curves in Panel
            baseClass.controls.graphPanel closingPane = sender as baseClass.controls.graphPanel;
            myNewPanelList.Remove(closingPane);
            RemovePane(closingPane);

            Charts.DrawCurve[] list = myCurveList.CurveInPane(closingPane.Name);
            for (int idx = 0; idx < list.Length; idx++)
            {
                RemoveCurveIndicator(list[idx].CurveName, true);
            }
            this.ReArrangePanes();            
            return true;
        }

        /// <summary>
        /// The hien thong tin tren moi diem ve
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="pointIdx"></param>
        /// <returns></returns>
        private string PointValueEventPrice(CurveItem curve, int pointIdx)
        {
            if (!Settings.sysChartShowDescription) return null;
            if (pointIdx>=myData.Open.Values.Length) return null;

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
            TradePointInfo info=findTradePointInfo(pointIdx);
            if (info!=null)
                retVal += common.Consts.constCRLF + Languages.Libs.GetString("targetPrice") + " : " + info.BusinessInfo.Short_Target+
                       common.Consts.constCRLF + Languages.Libs.GetString("resistance") + " : " + info.BusinessInfo.Short_Resistance +
                       common.Consts.constCRLF + Languages.Libs.GetString("support") + " : " + info.BusinessInfo.Short_Support;
            return retVal;
        }

        /// <summary>
        /// Tim tradepointInfo cua Pointidx
        /// </summary>
        /// <param name="pointIdx">diem tren do thi</param>
        /// <returns></returns>
        private TradePointInfo findTradePointInfo(int pointIdx)
        {
            TradePointInfo info=null;
            if (tradePoints == null) return null;
            //Array.BinarySearch(tradePoints,
            for (int i = 0; i < tradePoints.Length; i++)
                if ((tradePoints[i].DataIdx == pointIdx) && (tradePoints[i].isValid))
                    return tradePoints[i];
            return info;
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
                this.myData = new DataAccess.AnalysisData();
                this.myData.DataMaxCount = Settings.sysGlobal.ChartMaxLoadCount_FIRST;

                this.SetMasterPane(new Point(0, activeIndicatorLV.Location.Y + activeIndicatorLV.Height));
                activeIndicatorLV.Visible = true;
                this.myNewPanelList.Add(constPaneNamePrice,pricePanel);
                this.bgWorker.DoWork += new DoWorkEventHandler(this.bgWorker_DoWork);
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
            databases.tmpDS.stockCodeRow stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(this.myData.DataStockCode);
            if (stockCodeRow != null)
            {
                if (commonClass.SysLibs.IsUseVietnamese())
                    this.Text = stockCodeRow.tickerCode.Trim() + " - " + stockCodeRow.name;
                else this.Text = stockCodeRow.tickerCode.Trim() + " - " + (stockCodeRow.IsnameEnNull()?common.Consts.constNotAvailable:stockCodeRow.nameEn);
            }
        }

        public delegate void EstimateTradePointFunc(tradeAnalysis sender,string strategyCode,
                                                    EstimateOptions options, databases.tmpDS.tradeEstimateDataTable tbl);

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
        public void UseStock(databases.tmpDS.stockCodeRow stockCodeRow)
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
            myData.ClearCache();
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
        /// Draw tradepoints/recommendations for buy/sell decision
        /// </summary>

        protected void PlotStrategyTradepoints(application.TradePoints tradePoints, baseClass.controls.graphPanel toPanel)
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
        public void PlotStrategyTradepoints(application.Strategy.StrategyMeta meta, bool showEstimation, EstimateTradePointFunc estimateFunc)
        {
            int idx;
            ShowMessage("");
            EstimateOptions estOption = new EstimateOptions();
            databases.tmpDS.tradeEstimateDataTable tbl = new databases.tmpDS.tradeEstimateDataTable();
            application.StrategyStatistics statistics=new StrategyStatistics();
            //TradePointInfo[] 
            tradePoints = DataAccess.Libs.GetTradePointWithEstimationDetail(myData.myDataParam,myData.DataStockCode,meta.Code,
                                                                                             estOption, out tbl,out statistics); 
            /// Estimate trade points and set tradepoint's [isValid] property to mark whether a tradepoint is valid or not.
            for (idx = 0; idx < tradePoints.Length; idx++)
            {
                tradePoints[idx].isValid = !tbl[idx].ignored; 
            }

            for (idx = tradePoints.Length - 1; idx > 0; idx--)
                if (tradePoints[idx].isValid) break;

            TradePointInfo tpiTradePointInfo = (TradePointInfo)tradePoints[idx];
            BusinessInfo biLastTrade = tpiTradePointInfo.BusinessInfo;
            BusinessInfo biLastPoint=tradePoints[tradePoints.Length-1].BusinessInfo;

            double price= myData.Close[myData.Close.Count-1];
            double risk = (biLastPoint.Short_Resistance - price) / (price - biLastPoint.Short_Support);
            //string sResult = "Close price=" + price+
            //                 "Target="+biLastTrade.Short_Target+
            //                 "Resistance=" + biLastPoint.Short_Resistance +
            //                 " Support=" + biLastPoint.Short_Support +
            //                 " Risk return=" +risk+
            //                 " Winning Percentage:"+ String.Format("{0:P2}",statistics.dWinningPercentagePerTrade)+
            //                 " Max %Win Per Trade:" +  String.Format("{0:P2}",statistics.dMaxWinningPercentage)+
            //                 " Max %Lose Per Trade" + String.Format("{0:P2}", statistics.dMaxLosingPercentage)+
            //                 " Average %Win Per Trade" + String.Format("{0:P2}", statistics.dAverageWinningPercentage)+
            //                 " Average %Lose Per Trade" + String.Format("{0:P2}", statistics.dAverageLosingPercentage); ; 

            PlotStrategyTradepoints(application.Strategy.StrategyLibs.ToTradePoints(tradePoints), pricePanel);
            
            
            
            //MessageBox.Show(sResult);
            //Show form
            Tools.Forms.TradeStatistics formStatistic = new Tools.Forms.TradeStatistics();
            formStatistic.AddStatisticInfo("Close price",price);
            formStatistic.AddStatisticInfo("Target", biLastTrade.Short_Target);
            formStatistic.AddStatisticInfo("Resistance", biLastPoint.Short_Resistance);
            formStatistic.AddStatisticInfo("Support", biLastPoint.Short_Support);
            formStatistic.AddStatisticInfo("Risk return", risk);
            formStatistic.AddStatisticInfo("Winning Percentage", String.Format("{0:P2}", statistics.dWinningPercentagePerTrade));
            formStatistic.AddStatisticInfo("Max %Win Per Trade", String.Format("{0:P2}",statistics.dMaxWinningPercentage));
            formStatistic.AddStatisticInfo("Max %Lose Per Trade", String.Format("{0:P2}", statistics.dMaxLosingPercentage));
            formStatistic.AddStatisticInfo("Average %Win Per Trade", String.Format("{0:P2}", statistics.dAverageWinningPercentage));
            formStatistic.AddStatisticInfo("Average %Lose Per Trade", String.Format("{0:P2}", statistics.dAverageLosingPercentage));

            formStatistic.Show(this.DockPanel,DockState.DockRightAutoHide);

            //Call estimation handler if any.
            if (showEstimation && estimateFunc != null)
                estimateFunc(this, meta.Code, estOption, tbl);
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
            if (this.bgWorker.IsBusy) return;
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
            myNewPanelList.ResetGraph();
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
                    curveItem = PlotCandleStick(curveName, pricePanel, myData);
                    break;
            }
            pricePanel.myGraphObj.DefaultViewport();
        }

        // ZedGraph ignores points with double.NaN so invalid value must set to this.
        private double[] MakeChartValue(DataValues dv)
        {
            double[] retList = new double[dv.Count];
            for (int idx = 0; idx < dv.Count; idx++)
            {
                retList[idx] = (idx<dv.FirstValidValue?double.NaN:dv.Values[idx]);
            }
            return retList;
        }
        private CurveItem PlotCurveBar(string curveName, Charts.Controls.baseGraphPanel graphPane, DataValues xValues, DataValues yValues,
                                       Color color, Color bdColor, int weight)
        {
            graphPane.myGraphObj.SetSeriesX(xValues.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveBar(curveName, MakeChartValue(yValues), color, bdColor, weight);
            myCurveList.Add(curveItem, curveName, graphPane.myGraphObj.myGraphPane, graphPane.Name);
            return curveItem;
        }
        private CurveItem PlotCurveLine(string curveName, Charts.Controls.baseGraphPanel graphPane, DataValues xValues, DataValues yValues,
                                       Color color, int weight)
        {            
            graphPane.myGraphObj.SetSeriesX(xValues.Values, Charts.AxisType.DateAsOrdinal);          
            CurveItem curveItem = graphPane.myGraphObj.AddCurveLine(curveName, MakeChartValue(yValues), SymbolType.None, color, weight);            
            myCurveList.Add(curveItem, curveName, graphPane.myGraphObj.myGraphPane, graphPane.Name);
            return curveItem;
        }
        private CurveItem PlotCandleStick(string curveName, Charts.Controls.baseGraphPanel graphPane, AnalysisData data)
        {
            graphPane.myGraphObj.SetSeriesX(data.DateTime.Values, Charts.AxisType.DateAsOrdinal);
            CurveItem curveItem = graphPane.myGraphObj.AddCandleStick(curveName,
                                                                      MakeChartValue(data.High),
                                                                      MakeChartValue(data.Low),
                                                                      MakeChartValue(data.Open),
                                                                      MakeChartValue(data.Close),
                                                                      MakeChartValue(data.Volume),
                                                                      Settings.sysChartBarUpColor, Settings.sysChartBarDnColor,
                                                                      Settings.sysChartBullCandleColor, Settings.sysChartBullBorderColor, 
                                                                      Settings.sysChartBearCandleColor, Settings.sysChartBearBorderColor); 
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

        
        /// <summary>
        /// Draw / Remove indicator curves
        /// </summary>
        /// <param name="name"></param>
        /// <param name="allStartWith"></param>
        private void RemoveCurveIndicator(string name, bool allStartWith)
        {                        
            Charts.DrawCurve[] arr  = myCurveList.CurveInPane(pricePanel.Name);
            foreach (var item in arr)
	        {
                if (item.CurveName.Equals(name))
                {
                    pricePanel.clearText();
                }
	        }
            myCurveList.Remove(name, allStartWith);
            activeIndicatorLV.Remove(name);
        }

        /// <summary>
        /// Draw curve for indicator
        /// </summary>
        /// <param name="meta"></param>
        private void DrawCurveIndicator(application.Indicators.Meta meta)
        {
            //Indicators.Meta meta = Indicators.Libs.FindMetaByName(indicatorName);
            string curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + meta.ParameterString;
            string paraStr = meta.ParameterString;
            if (paraStr == string.Empty)
            {
                curveName = meta.ClassType.Name;
            }
            else
            {
                curveName = meta.ClassType.Name + "-" + paraStr;
            }
            //Remove the old one if any
            if (this.CurrentEditCurveName.Trim() != "")
            {
                RemoveCurveIndicator(this.CurrentEditCurveName, true);
                this.CurrentEditCurveName = curveName;
            }
            //Determine panel for drawing.
            //TUAN-BEGIN
            baseClass.controls.graphPanel myGraphPanel = null;
            myGraphPanel = myNewPanelList.Find(meta.SelectedWindowName);
            if (myGraphPanel == null)
            {                
                myGraphPanel = CreateNewPanel(MakeNewPanelName(curveName));
            }    
            //TUAN-END

            //DataValues[] indicatorValue = DataAccess.Libs.GetIndicatorData(myData.DataStockCode,myData.myDataParam, meta.ClassType.Name);   
            //TUAN - fix bug - SMA 5 and 10 are the same curve line data when draw both of them.
            DataValues[] indicatorValue = application.Indicators.Libs.GetIndicatorData(myData, meta);            
            this.myData.DateTime.FirstValidValue = indicatorValue[0].FirstValidValue;
            for (int idx = 0; idx < indicatorValue.Length; idx++)
            {
                curveName = constCurveNamePrefixIndicator + meta.ClassType.Name + "-" + meta.ParameterString + "-" + idx.ToString();
                switch (meta.Output[idx].ChartType)
                {
                    case AppTypes.ChartTypes.Bar:
                        PlotCurveBar(curveName, myGraphPanel, this.myData.DateTime, indicatorValue[idx],
                                     meta.Output[idx].Color, Color.Black, meta.Output[idx].Weight);
                        break;
                    case AppTypes.ChartTypes.Line:
                        PlotCurveLine(curveName, myGraphPanel, this.myData.DateTime, indicatorValue[idx],
                                      meta.Output[idx].Color, meta.Output[idx].Weight);
                        break;
                }
            }

            myGraphPanel.myGraphObj.myViewportX = pricePanel.myGraphObj.myViewportX;
            
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

        /// <summary>
        /// Update chart with new data for all panels
        /// </summary>
        private void UpdateChart()
        {            
            pricePanel.PlotGraph();
            volumePanel.PlotGraph();
            myNewPanelList.PlotGraph();
            RemoveEmptyCurveLinePanel();
            this.ReArrangePanes();
        }

        private void RemoveEmptyCurveLinePanel()
        {
            int count = 0;
            foreach (DictionaryEntry item in myNewPanelList)
            {                
                baseClass.controls.graphPanel pane = (item.Value as baseClass.controls.graphPanel);
                if (myCurveList.CurveInPane(pane.Name).Length==0)
                {
                    myNewPanelList.Remove(pane);
                    RemovePane(pane);
                    break;
                }
                count++;
            }
            if (count<myNewPanelList.Count)
            {
                RemoveEmptyCurveLinePanel();
            }
        }

        //Get indicator form from indicator type (SMA, MACD,Stoch...)
        private application.forms.baseIndicatorForm GetIndicatorForm(string typeName)
        {
            application.Indicators.Meta meta = application.Indicators.Libs.FindMetaByName(typeName);
            if (meta == null) return null;
            //TUAN-BEGIN
            meta.SelectedWindowName = constPaneNameNew;
            meta.ListWindowNames = new Hashtable();
            if (meta.DrawInNewWindow)
            {
                meta.ListWindowNames.Add(constPaneNameNew, constPaneNameNew);
                meta.ListWindowNames.Add(constPaneNamePrice, constPaneNamePrice);
            }
            else
            {
                meta.ListWindowNames.Add(constPaneNamePrice, constPaneNamePrice);
                meta.ListWindowNames.Add(constPaneNameNew, constPaneNameNew);               
            }
            //UpdateHashtable();
            foreach (DictionaryEntry item in myNewPanelList)
            {
                if (item.Key.Equals(constPaneNamePrice))
                {
                    continue;
                }
                meta.ListWindowNames.Add((item.Value as baseClass.controls.graphPanel).getText(), (item.Value as baseClass.controls.graphPanel).Name);   
            }            
            //TUAN-END
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
            //TUAN update list new windows on indicator form
            else
            {
                if (form.GetType().Equals(typeof(application.forms.commonIndicatorForm)))
                {
                    ((application.forms.commonIndicatorForm)(form)).updateFormFromMeta(meta);
                }
            }
            //TUAN
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
        private bool fUpdating = false;
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (fUpdating) return;
                fUpdating = true;
                int noOfUpdate = myData.UpdateDataFromLastTime();
                if (noOfUpdate >= 0)
                {
                    if (pricePanel.Visible) UpdateCurvePRICE(noOfUpdate);
                    if (volumePanel.Visible) UpdateCurveVOLUME(noOfUpdate);
                }
                fUpdating = false;
            }
            catch (Exception er)
            {
                fUpdating = false;
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}