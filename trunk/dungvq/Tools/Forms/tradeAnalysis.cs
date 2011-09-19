using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using application;

namespace Tools.Forms
{
    public partial class tradeAnalysis : baseClass.forms.baseGraphForm
    {
        #region private variables
        const string constPaneNamePrice = "pricePanel";
        const string constPaneNameVolume = "volumePanel";
        const string constPaneNameNew = "newPanel";
        const string constCurveNamePrefixIndicator = "Indicator-";

        // Keep infomation of all indicators dynamically collected form plug-in .dll
        private application.Data myData = null;     //Working data loaded from SQL database
        private application.CurveList curveList = new application.CurveList();           // Keep all drawn curves in the chart
        private common.DictionaryList indicatorFormCache = new common.DictionaryList();  // To cache used indicator forms 
        private common.DictionaryList dataCache = new common.DictionaryList();           // To cache data used in indicator chart

        private baseClass.controls.graphPanel _pricePanel = null, _volumePanel = null, _newPanel = null;
        private baseClass.controls.graphPanel pricePanel
        {
            get
            {
                baseClass.controls.graphPanel pane = (baseClass.controls.graphPanel)mainContainer.GetChild(constPaneNamePrice);
                if (pane == null)
                {
                    _pricePanel = CreatePane(constPaneNamePrice, 100);
                    _pricePanel.onPointValueEvent += new common.control.baseGraphPanel.OnPointValue(PointValueEventPrice); 
                    _pricePanel.haveCloseButton = false;
                    //_pricePanel.SetXAxisType(typeof(DateTime), false);
                }
                else _pricePanel = pane;
                return _pricePanel;
            }
        }
        private baseClass.controls.graphPanel volumePanel
        {
            get
            {
                baseClass.controls.graphPanel pane = (baseClass.controls.graphPanel)mainContainer.GetChild(constPaneNameVolume);
                if (pane == null)
                {
                    _volumePanel = CreatePane(constPaneNameVolume, 0);
                    _volumePanel.Height = this.ClientRectangle.Height / 4;
                    _volumePanel.haveCloseButton = true;
                    _volumePanel.onPointValueEvent += new common.control.baseGraphPanel.OnPointValue(PointValueEventVolume); 
                    //_volumePanel.SetXAxisType(typeof(DateTime), false);
                }
                else _volumePanel = pane;
                return _volumePanel;
            }
        }
        private baseClass.controls.graphPanel newPanel
        {
            get
            {
                baseClass.controls.graphPanel pane = (baseClass.controls.graphPanel)mainContainer.GetChild(constPaneNameNew);
                if (pane == null)
                {
                    _newPanel = CreatePane(constPaneNameNew, 0, pricePanel.Name);
                    _newPanel.Height = this.ClientRectangle.Height / 5;
                    _newPanel.haveCloseButton = false;
                    _newPanel.SetXAxisType(typeof(DateTime), false);
                }
                else _newPanel = pane;
                return _newPanel;
            }
        }

        private string PointValueEventPrice(CurveItem curve, int pointIdx)
        {
            DateTime dt = DateTime.FromOADate(curve[pointIdx].X);
            string retVal = "";
            switch (this.ChartTimeScale.Type)
            { 
                case AppTypes.TimeScaleTypes.RealTime:
                case AppTypes.TimeScaleTypes.Minnute:
                case AppTypes.TimeScaleTypes.Hour: retVal = "Time: " + dt.ToString(); break;
                case AppTypes.TimeScaleTypes.Day:  retVal = "Date: " + dt.ToShortDateString(); break;
                case AppTypes.TimeScaleTypes.Week: retVal = "Week: " + common.dateTimeLibs.WeekOfYear(dt).ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Month: retVal ="Month: " + dt.Month.ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Year: retVal = "Year: " + dt.Year.ToString(); break;
            }
            retVal += common.Consts.constCRLF + "Price: " + curve[pointIdx].Y.ToString(application.Settings.sysQtyMask);
            return retVal;
        }
        private string PointValueEventVolume(CurveItem curve, int pointIdx)
        {
            DateTime dt = DateTime.FromOADate(curve[pointIdx].X);
            string retVal = "";
            switch (this.ChartTimeScale.Type)
            {
                case AppTypes.TimeScaleTypes.RealTime:
                case AppTypes.TimeScaleTypes.Minnute:
                case AppTypes.TimeScaleTypes.Hour: retVal = "Time: " + dt.ToString(); break;
                case AppTypes.TimeScaleTypes.Day: retVal = "Date: " + dt.ToShortDateString(); break;
                case AppTypes.TimeScaleTypes.Week: retVal = "Week: " + common.dateTimeLibs.WeekOfYear(dt).ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Month: retVal = "Month: " + dt.Month.ToString() + "/" + dt.Year.ToString(); break;
                case AppTypes.TimeScaleTypes.Year: retVal = "Year: " + dt.Year.ToString(); break;
            }
            retVal += common.Consts.constCRLF + "Volume: " + curve[pointIdx].Y.ToString(application.Settings.sysLocalAmtMask);
            return retVal;
        }

        private class IndicatorCurveInfo
        {
            public IndicatorCurveInfo(string curveName, string indicatorName, Indicators.IndicatorFormInfo info)
            {
                CurveName = curveName;
                IndicatorName = indicatorName;
                FormInfo = info;
            }
            public string CurveName = "", IndicatorName = "";
            public Indicators.IndicatorFormInfo FormInfo =null;
        }
        private string CurrentEditCurveName = "";

        #endregion 

        public tradeAnalysis()
        {
            try
            {
                InitializeComponent();
                this.myData = new application.Data();
                mainContainer.Visible = true;
                mainContainer.Location = new Point(0, activeIndicatorLV.Location.Y + activeIndicatorLV.Height);
                activeIndicatorLV.Visible = true;

                pricePanel.isVisible = true;
                volumePanel.isVisible = false;
                newPanel.isVisible = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public static tradeAnalysis GetForm(data.baseDS.stockCodeRow stockCodeRow,
                                            AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
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
            form.UseStock(stockCodeRow);
            form.Visible = true;
            return form;
        }

        protected data.baseDS.stockCodeRow myStockCodeRow = null;
        private AppTypes.ChartTypes _priceChartType = AppTypes.ChartTypes.None;
        public AppTypes.ChartTypes ChartPriceType
        {
            get { return this._priceChartType; }
            set
            {
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
                this.volumePanel.isVisible = value;
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
        public void UseStock(data.baseDS.stockCodeRow stockCodeRow)
        {
            this.myStockCodeRow = stockCodeRow;
            this.myData.DataStockCode = stockCodeRow.code;

            this.ShowMessage("");
            this.Text = stockCodeRow.tickerCode.Trim() + " - " + stockCodeRow.name;

            ReloadChart();
        }

        /// <summary>
        /// Re-draw all curves in chart
        /// </summary>
        public void RefreshChart()
        {
            ResetChart();
            DrawAllCurves();
            UpdateChart();
        }

        /// <summary>
        /// Reload data, and re-draw chart
        /// </summary>
        public void ReloadChart()
        {
            myData.Reload();
            Indicators.Libs.ClearCache();

            //Remove all curves in chart
            curveList.RemoveAll();
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
            Indicators.forms.baseIndicatorForm form = GetIndicatorForm(indicatorName);
            if (form == null) return;
            form.ShowDialog();
        }

        //==================================
        // Draw and remove curves
        //==================================

        //?? Bug : do not reset when change data source 
        private void ResetChart()
        {
            pricePanel.ResetGraph();
            volumePanel.ResetGraph();
            newPanel.ResetGraph();
        }

        private void DrawCurvePRICE()
        {
            string curveName = pricePanel.Name;
            curveList.Remove(curveName);
            switch (this.ChartPriceType)
            {
                case AppTypes.ChartTypes.Bar:
                    curveList.PlotCurveBar(pricePanel.myGraphPane, pricePanel.Name, this.myData.DateTime, myData.Close,
                                           Settings.sysChartBarUpColor, Settings.sysChartBarUpColor, 1, curveName);
                    break;
                case AppTypes.ChartTypes.Line:
                    curveList.PlotCurveLine(pricePanel.myGraphPane, pricePanel.Name, this.myData.DateTime, myData.Close,
                                            Settings.sysChartLineCandleColor, 1, curveName);
                    break;
                case AppTypes.ChartTypes.CandelStick:
                    curveList.PlotCurveCandle(pricePanel.myGraphPane, pricePanel.Name, myData,
                                              Settings.sysChartBarUpColor, Settings.sysChartBarDnColor,
                                              Settings.sysChartBullCandleColor, Settings.sysChartBearCandleColor, curveName);
                    break;
            }
        }
        private void DrawCurveVOLUME()
        {
            string curveName = volumePanel.Name;
            curveList.Remove(curveName);
            this.myData.DateTime.FirstValidValue = myData.Volume.FirstValidValue;
            curveList.PlotCurveBar(volumePanel.myGraphPane, volumePanel.Name, this.myData.DateTime, myData.Volume,
                                   Settings.sysChartVolumesColor, Settings.sysChartVolumesColor, 1, volumePanel.Name);
        }

        //Draw / Remove indicator curves
        private void RemoveCurveIndicator(string name, bool allStartWith)
        {
            curveList.Remove(name, allStartWith);
            activeIndicatorLV.Remove(name);
        }
        private void DrawCurveIndicator(string indicatorName, Indicators.IndicatorFormInfo indicatorInfo, Indicators.IndicatorFormInfo[] extraInfo)
        {
            Indicators.IndicatorMeta meta = Indicators.Libs.FindMetaByName(indicatorName);
            string curveName;
            baseClass.controls.graphPanel myGraphPanel = (indicatorInfo.inNewWindows ? this.newPanel : this.pricePanel);
            DataSeries indicatorSeries = Indicators.Libs.GetIndicatorData(this.myData,meta, indicatorInfo.paras);
            
            this.myData.DateTime.FirstValidValue = indicatorSeries.FirstValidValue;
            curveName = constCurveNamePrefixIndicator + indicatorName + "-" + indicatorInfo.ParasString;

            //Remove the old one if any
            if (this.CurrentEditCurveName.Trim() != "")
            {
                RemoveCurveIndicator(this.CurrentEditCurveName, true);
                this.CurrentEditCurveName = curveName;
            }

            switch (indicatorInfo.chartType)
            {
                case AppTypes.ChartTypes.Bar:
                    curveList.PlotCurveBar(myGraphPanel.myGraphPane, myGraphPanel.Name, this.myData.DateTime, indicatorSeries,
                                               indicatorInfo.color[0], Color.Black, indicatorInfo.weight, curveName);
                    break;
                case AppTypes.ChartTypes.Line:
                    curveList.PlotCurveLine(myGraphPanel.myGraphPane, myGraphPanel.Name, this.myData.DateTime, indicatorSeries,
                                               indicatorInfo.color[0], indicatorInfo.weight, curveName);
                    break;
            }
            // Some indicator such as MACD having more than one output series.
            // In such case, indicator form MUST have [form.ExtraInfo] propery to provide information for the output series. 
            DataSeries[] extraSeries = null;
            if (extraInfo != null) extraSeries = Indicators.Libs.GetIndicatorData(indicatorSeries, meta, extraInfo);
            if (extraSeries != null)
            {
                for (int idx1 = 0; idx1 < extraSeries.Length; idx1++)
                {
                    this.myData.DateTime.FirstValidValue = extraSeries[idx1].FirstValidValue;
                    curveName = constCurveNamePrefixIndicator + indicatorName + "-" + indicatorInfo.ParasString + "-" + idx1.ToString();
                    switch (extraInfo[idx1].chartType)
                    {
                        case AppTypes.ChartTypes.Bar:
                            curveList.PlotCurveBar(myGraphPanel.myGraphPane, myGraphPanel.Name, this.myData.DateTime, extraSeries[idx1],
                                                       extraInfo[idx1].color[0], Color.Black, extraInfo[idx1].weight, curveName);
                            break;
                        case AppTypes.ChartTypes.Line:
                            curveList.PlotCurveLine(myGraphPanel.myGraphPane, myGraphPanel.Name, this.myData.DateTime, extraSeries[idx1],
                                                        extraInfo[idx1].color[0], extraInfo[idx1].weight, curveName);
                            break;

                    }
                }
            }
            string paraStr = indicatorInfo.ParasString;
            curveName = constCurveNamePrefixIndicator + indicatorName + "-" + paraStr;
            string text = indicatorName +(paraStr==""?"" : "(" + paraStr+")");
            ListViewItem item = activeIndicatorLV.Add(curveName, text, indicatorInfo.color[0]);
            item.Tag = new IndicatorCurveInfo(curveName,indicatorName, indicatorInfo);
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
            newPanel.isVisible = curveList.NumberOfCurves(newPanel.Name) > 0;
            pricePanel.PlotGraph();
            volumePanel.PlotGraph();
            newPanel.PlotGraph();
            mainContainer.ArrangeChildren();
        }

        //Get indicator form from indicator type (SMA, MACD,Stoch...)
        private Indicators.forms.baseIndicatorForm GetIndicatorForm(string typeName)
        {
            Indicators.IndicatorMeta meta = Indicators.Libs.FindMetaByName(typeName);
            if (meta == null) return null;
            Indicators.forms.baseIndicatorForm form = null;

            form = (Indicators.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.Type.Name);
            if (form == null || form.IsDisposed)
            {
                form = Indicators.Libs.GetIndicatorForm(meta);
                form.Text = meta.Name;
                form.onPlotChart += new Indicators.forms.baseIndicatorForm.PlotChart(IndicatorFormHandler);
            }
            this.indicatorFormCache.Add(meta.Type.Name, form);
            return form;
        }
        private Indicators.forms.baseIndicatorForm FindIndicatorForm(string typeName)
        {
            Indicators.IndicatorMeta meta = Indicators.Libs.FindMetaByName(typeName);
            if (meta == null) return null;
            Indicators.forms.baseIndicatorForm form = (Indicators.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.Type.Name);
            if (form == null || form.IsDisposed) return null;
            return form;
        }
        //IndicatorFormHandler : Draw / Remove indicator's curves
        private void IndicatorFormHandler(Indicators.forms.baseIndicatorForm indicatorForm, bool removeChart)
        {
            if (removeChart)
            {
                string curveName = constCurveNamePrefixIndicator + indicatorForm.indicatorType.Name + "-" + 
                                   indicatorForm.Info.ParasString;
                RemoveCurveIndicator(curveName, true);
            }
            else
                DrawCurveIndicator(indicatorForm.indicatorType.Name, indicatorForm.Info, indicatorForm.ExtraInfo);
            UpdateChart();
        }
        protected override void RefreshForm()
        {
            RefreshChart();
        }

        #region event handler
        private void editIndicatorMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeIndicatorLV.FocusedItem == null) return;
                IndicatorCurveInfo info = (IndicatorCurveInfo)activeIndicatorLV.FocusedItem.Tag;
                Indicators.forms.baseIndicatorForm form = GetIndicatorForm(info.IndicatorName);
                if (form == null) return;
                form.Info = info.FormInfo;
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
        #endregion event handler
    }
}