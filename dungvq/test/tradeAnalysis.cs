using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ZedGraph;
using application;

namespace test
{
    public partial class tradeAnalysis : baseClass.forms.baseGraphForm 
    {
        Indicators.Data myData = null; 
        DataCache graphCache = new DataCache(), 
                  indicatorFormCache = new DataCache(),
                  dataCache = new DataCache();

        private Indicators.IndicatorMeta[] indicatorMetas = null;

        private const string constPricePaneName = "pricePane", constVolumePaneName = "volume";
        private const byte constPricePaneWeight = 100;
        public tradeAnalysis()
        {
            try
            {
                InitializeComponent();
                
                //For testing
                LoadAppConfig();

                cbStrategy.LoadData();
                timeScaleCb.LoadData();

                cbStrategy.SelectFirstIfNull();
                timeScaleCb.SelectFirstIfNull();

                this.pricePane = CreatePane(constPricePaneName,constPricePaneWeight);
                pricePane.haveCloseButton = false;
                //this.volumePane = CreateVolumePane();
                //volumePane.haveCloseButton = true;

                mainContainer.Location = new Point(0, toolBarPnl.Location.Y + toolBarPnl.Height);
                
                
                mainContainer.ArrangeChildren();

                Init();

                //For testing
                //data.baseDS.stockCodeExtDataTable tbl = new data.baseDS.stockCodeExtDataTable();
                //myStockCodeRow = application.dataLibs.GetStockData("SSI");
                //ShowForm(myStockCodeRow);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private baseClass.controls.graphPane CreateVolumePane()
        {
            baseClass.controls.graphPane myPane = CreatePane(constVolumePaneName, 0);
            myPane.Height = this.ClientRectangle.Height / 3;
            myPane.mySizingOptions = common.control.basePanel.SizingOptions.Top;
            myPane.minSizingHeight = 50;
            return myPane;
        }

        private bool LoadAppConfig()
        {
            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";

            application.sysLibs.sysProductOwner = application.Consts.constProductOwner;
            application.sysLibs.sysProductCode = application.Consts.constProductCode;

            //common.settings.sysConfigFile = common.system.myConfigFileName;
            application.configuration.withEncryption = true;
            application.configuration.Load_User_Envir();
            
            //Check data connection after db-setting were loaded
            application.configuration.Load_Sys_Settings();
            application.configuration.Load_User_Config(application.sysLibs.sysUseLocalConfigFile);
            
            application.sysLibs.SetAppEnvironment();
            return true;
        }

        protected baseClass.controls.graphPane pricePane = null;
        protected baseClass.controls.graphPane volumePane = null;
        protected baseClass.controls.graphPane newPane = null;
        
        protected enum chartTypeEnum : byte {Line, Bar,CandelStick};
        protected chartTypeEnum myChartType
        {
            get
            {
                if (chartBarBtn.isDownState) return chartTypeEnum.Bar;
                if (chartCandelBtn.isDownState) return chartTypeEnum.CandelStick;
                return chartTypeEnum.Line;
            }
            set
            {
                switch (value)
                {
                    case chartTypeEnum.Bar:
                         chartBarBtn.isDownState = true;
                         chartLineBtn.isDownState = false;
                         chartCandelBtn.isDownState = false;
                         break;
                    case chartTypeEnum.CandelStick:
                         chartBarBtn.isDownState = false;
                         chartLineBtn.isDownState = false;
                         chartCandelBtn.isDownState = true;
                         break;
                    default:
                         chartBarBtn.isDownState = false;
                         chartLineBtn.isDownState = true;
                         chartCandelBtn.isDownState = false;
                         break;
                }
            }

        }

        protected data.baseDS.stockCodeExtRow myStockCodeRow = null;
        protected virtual baseClass.forms.baseChartDataOptions CreateChartDataOptionForm()
        {
            return new baseClass.forms.baseChartDataOptions();
        }
        private baseClass.forms.baseChartDataOptions _myChartDataOptionForm = null;
        protected baseClass.forms.baseChartDataOptions myChartDataOptionForm
        {
            get
            {
                if (_myChartDataOptionForm == null)
                {
                    _myChartDataOptionForm = CreateChartDataOptionForm();
                    _myChartDataOptionForm.InitData();
                    _myChartDataOptionForm.myOnProcess += new common.forms.baseDialogForm.onProcess(ChartDataOptionHandler);
                }
                return _myChartDataOptionForm;
            }
        }

        public void ShowForm(data.baseDS.stockCodeExtRow stockCodeRow)
        {
            ShowForm(stockCodeRow, myChartDataOptionForm.myTimeRange);
        }
        public void ShowForm(data.baseDS.stockCodeExtRow stockCodeRow, application.myTypes.timeRanges timing)
        {
            this.ShowMessage("");
            if (stockCodeRow == null) return;
            myChartDataOptionForm.myTimeRange = timing;
            this.Text = "(" + stockCodeRow.tickerCode.Trim() + "," + stockCodeRow.nameEn + ")";
            this.myStockCodeRow = stockCodeRow;

            if (!Validate_StockChart()) return;

            LoadData();
            RefreshForm();
            this.Show();
            this.BringToFront();
            this.FormReSize();
        }

        private void Init()
        {
            this.indicatorMetas = Indicators.libs.GetIndicatorMeta();
            CreateIndicatorContextMenu(this.indicatorMetas);

            //Test
            this.myStockCodeRow = application.dataLibs.GetStockData("SSI");

            myData = new Indicators.Data(new data.baseDS.priceDataDataTable());
            myChartDataOptionForm.GetDate();
            LoadData();
            PlotChart();
        }
        private void LoadData()
        {
            myData.DataTimeScale = timeScaleCb.myValue;
            myData.DataEndDate = myChartDataOptionForm.toDate;
            myData.DataStartDate = myChartDataOptionForm.frDate;
            myData.DataStockCode = this.myStockCodeRow.code;
            myData.Reload();
        }

        //??
        private void PlotChart()
        {
            PlotMainChart();
            //smaIndicatorForm.PlotChart();
        }
        private void PlotMainChart()
        {
            pricePane.RemoveAllCurves();
            switch (this.myChartType)
            {
                case chartTypeEnum.Bar:
                     chartLibs.PlotChartBar(pricePane.myGraphPane,myData.DateTime,myData.Close, "Bar",Color.Blue,Color.Black,1);
                     break;
                case chartTypeEnum.CandelStick:
                     chartLibs.PlotChartCandleStick(pricePane.myGraphPane,myData.DateTime,myData.Bars, "CandelStick",Color.Blue, Color.Black, Color.Red);
                     break;
                default:
                     chartLibs.PlotChartLine(pricePane.myGraphPane,myData.DateTime,myData.Close, "Line", SymbolType.None,Color.Blue,1);
                     break;
            }
            pricePane.PlotGraph();
            if (mainContainer.GetChild(volumePane) != null)
            {
                volumePane.RemoveAllCurves();
                chartLibs.PlotChartBar(volumePane.myGraphPane, myData.DateTime, myData.Volume, "Bar", Color.Navy, Color.Black, 1);
                volumePane.myGraphPane.XAxis.Type = AxisType.DateAsOrdinal;
                volumePane.myGraphPane.XAxis.Scale.Min = new XDate(myDataSet.priceData[0].onDate);
                volumePane.myGraphPane.XAxis.Scale.Max = new XDate(myDataSet.priceData[myDataSet.priceData.Count - 1].onDate);
                volumePane.PlotGraph();
            }
        }
        private bool Validate_StockChart()
        {
            bool retVal = true;
            ClearNotifyError();
            if (this.myStockCodeRow == null)
            {
                retVal = false;
            }
            if (!myChartDataOptionForm.GetDate())
            {
                retVal = false;
            }
            return retVal;
        }


        private void ShowIndicator(object sender, EventArgs e)
        {
            try
            {
                Indicators.forms.baseIndicatorForm form = GetIndicatorForm(((MenuItem)sender).Tag.ToString());
                if (form == null) return;
                form.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        //Plot indicator's chart
        private void PlotChartHandler(Indicators.forms.baseIndicatorForm form, bool removeChart)
        {
            baseClass.controls.graphPane myGraphPane = this.pricePane;
            Indicators.IndicatorFormInfo[] indicatorInfo = form.Info;
            if (removeChart) RemoveChart(myGraphPane, form);
            else PlotChart(myGraphPane, form);
        }
        public void PlotChart(baseClass.controls.graphPane myGraphPane, Indicators.forms.baseIndicatorForm form)
        {
            Indicators.IndicatorFormInfo[] indicatorInfo = form.Info;
            CurveItem curveItem;
            DataSeries[] extraSeries = null;
            PropertyInfo propertyInfo;
            Indicators.IndicatorFormInfo[] extraIndicatorInfo;
            for (int idx = 0; idx < indicatorInfo.Length; idx++)
            {
                string cacheName = form.indicatorType.Name;
                //object[] paras = new object[] { this.myData.Close };

                Indicators.IndicatorMeta meta = Indicators.libs.FindMetaByName(this.indicatorMetas, form.indicatorType.Name);

                object[] paras = new object[1];
                if(meta.InputDataType == typeof(DataBars)) paras[0] = this.myData.Bars;
                else paras[0] = this.myData.Close;

                for (int idx2 = 0; idx2 < indicatorInfo[idx].paras.Length; idx2++)
                {
                    Array.Resize(ref paras, paras.Length + 1);
                    paras[paras.Length - 1] = indicatorInfo[idx].paras[idx2];
                    cacheName += "-" + indicatorInfo[idx].paras[idx2].ToString();
                }
                Array.Resize(ref paras, paras.Length + 1);
                paras[paras.Length - 1] = form.indicatorType.Name;

                DataSeries indicatorSeries = (DataSeries)this.dataCache.Find(cacheName);
                if (indicatorSeries == null)
                {
                    indicatorSeries = (DataSeries)Activator.CreateInstance(form.indicatorType, paras);
                    this.dataCache.Add(cacheName, indicatorSeries);
                }

                this.myData.DateTime.FirstValidValue = indicatorSeries.FirstValidValue;
                curveItem = PlotCurve(myGraphPane, this.myData.DateTime, indicatorSeries,
                                      indicatorInfo[idx].chartType, indicatorInfo[idx].color[0], indicatorInfo[idx].weight);
                if (curveItem != null)
                    graphCache.Add(form.indicatorType.Name + idx.ToString(), curveItem);

                // Some indicator such as MACD having more than one output series which can be accessed by "ExtraSeries".
                // In such case, indicator form MUST have [form.ExtraInfo] propery providing information for these extra series 
                propertyInfo = form.indicatorType.GetProperty("ExtraSeries");
                if (propertyInfo != null)
                {
                    extraIndicatorInfo = form.ExtraInfo;
                    extraSeries = (DataSeries[])propertyInfo.GetValue(indicatorSeries, null);
                    for (int idx1 = 0; idx1 < extraIndicatorInfo.Length; idx1++)
                    {
                        this.myData.DateTime.FirstValidValue = extraSeries[idx1].FirstValidValue;
                        curveItem = PlotCurve(myGraphPane, this.myData.DateTime, extraSeries[idx1],
                                              extraIndicatorInfo[idx1].chartType, extraIndicatorInfo[idx1].color[0], extraIndicatorInfo[idx1].weight);
                        if (curveItem != null)
                            graphCache.Add(form.indicatorType.Name + idx.ToString() + "-" + idx1.ToString(), curveItem);
                    }
                }
            }
            myGraphPane.PlotGraph();
        }
        private void RemoveChart(baseClass.controls.graphPane myGraphPane, Indicators.forms.baseIndicatorForm form)
        {
            Indicators.IndicatorFormInfo[] indicatorInfo = form.Info;
            CurveItem curveItem;
            PropertyInfo propertyInfo;
            Indicators.IndicatorFormInfo[] extraIndicatorInfo;
            for (int idx = 0; idx < indicatorInfo.Length; idx++)
            {
                curveItem = (CurveItem)graphCache.Find(form.indicatorType.Name + idx.ToString());
                if (curveItem == null) continue;
                myGraphPane.RemoveCurve(curveItem);
                propertyInfo = form.indicatorType.GetProperty("ExtraSeries");
                if (propertyInfo != null)
                {
                    extraIndicatorInfo = form.ExtraInfo;
                    for (int idx1 = 0; idx1 < extraIndicatorInfo.Length; idx1++)
                    {
                        curveItem = (CurveItem)graphCache.Find(form.indicatorType.Name + idx.ToString() + "-" + idx1.ToString());
                        if (curveItem == null) continue;
                        myGraphPane.RemoveCurve(curveItem);
                    }
                }
            }
            myGraphPane.PlotGraph();
        }
        private CurveItem PlotCurve(baseClass.controls.graphPane graphPane, DataSeries xSeries, DataSeries ySeries, 
                              myTypes.chartType chartType,Color color,byte weight)
        {
            switch (chartType)
            {
                case myTypes.chartType.Line:
                    return chartLibs.PlotChartLine(graphPane.myGraphPane, xSeries, ySeries, "", SymbolType.None,color,weight);
                case myTypes.chartType.Bar:
                    return chartLibs.PlotChartBar(graphPane.myGraphPane, xSeries, ySeries, "", color,Color.Black,weight);
            }
            return null;
        }

        //Get indicator form from indicator type (SMA, MACD,Stoch...)
        private  Indicators.forms.baseIndicatorForm GetIndicatorForm(string typeName)
        {
            Indicators.IndicatorMeta meta = Indicators.libs.FindMetaByName(indicatorMetas, typeName);
            if (meta == null) return null;
            Indicators.forms.baseIndicatorForm form = null;

            form = (Indicators.forms.baseIndicatorForm)this.indicatorFormCache.Find(meta.Type.Name);
            if (form == null || form.IsDisposed)
            {
                form = (Indicators.forms.baseIndicatorForm)Activator.CreateInstance(meta.FormType, meta.Type);
                form.Text = meta.Name;
                form.onPlotChart += new Indicators.forms.baseIndicatorForm.PlotChart(PlotChartHandler);
            }
            this.indicatorFormCache.Add(meta.Type.Name,form);
            return form;
        }

        // Create menu listing all indictors with click events. 
        // - Indicators having category existed in indicatorCat table are grouped to that category
        // - Indicators having category NOT existed in indicatorCat are placed under the category menus
        private void CreateIndicatorContextMenu(Indicators.IndicatorMeta[] indicatorMetas)
        {
            ContextMenu mainContextMenu = new ContextMenu();
            data.baseDS.indicatorCatDataTable indicatorCatTbl = new data.baseDS.indicatorCatDataTable();
            application.dataLibs.LoadData(indicatorCatTbl);
            for (int idx1 = 0; idx1 < indicatorCatTbl.Count; idx1++)
            {
                Indicators.IndicatorMeta[] tmpMetas = Indicators.libs.FindMetaByCat(indicatorMetas, indicatorCatTbl[idx1].code);
                if (tmpMetas==null || tmpMetas.Length == 0) continue;

                MenuItem catMenuItem = new MenuItem();
                catMenuItem.Name = "catMenuItem" + indicatorCatTbl[idx1].code;
                catMenuItem.Text = indicatorCatTbl[idx1].description;
                mainContextMenu.MenuItems.Add(catMenuItem);
                for (int idx2 = 0; idx2 < tmpMetas.Length; idx2++)
                {
                    MenuItem menuItem = new MenuItem();
                    menuItem.Name = "menuItem" + tmpMetas[idx2].Type.Name;
                    menuItem.Tag = tmpMetas[idx2].Type.Name;
                    menuItem.Text = tmpMetas[idx2].Name;
                    catMenuItem.MenuItems.Add(menuItem);
                    menuItem.Click += new System.EventHandler(ShowIndicator);
                }
            }
            for (int idx2 = 0; idx2 < indicatorMetas.Length; idx2++)
            {
                if (indicatorCatTbl.FindBycode(indicatorMetas[idx2].Category.Trim()) != null) continue;
                MenuItem menuItem = new MenuItem();
                menuItem.Name = "menuItem" + indicatorMetas[idx2].Type.Name;
                menuItem.Tag = indicatorMetas[idx2].Type.Name;
                menuItem.Text = indicatorMetas[idx2].Name;
                mainContextMenu.MenuItems.Add(menuItem);
                menuItem.Click += new System.EventHandler(ShowIndicator);
            }
            indicatorBtn.ContextMenu = mainContextMenu;
        }

        protected override void RefreshForm()
        {
            PlotChart();
        }

        #region event handler
        private void ChartDataOptionHandler(object sender,common.baseDialogEvent e)
        {
            if (e != null && e.isCloseClick) return; 
            if (!Validate_StockChart()) return;
            LoadData();
            PlotChart();
        }
        
        private void dataBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myChartDataOptionForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void indicatorBtn_Click(object sender, EventArgs e)
        {
            indicatorBtn.ContextMenu.Show(indicatorBtn,
                                          new Point(indicatorBtn.Location.X + 150, indicatorBtn.Location.Y + indicatorBtn.Height-10),
                                          LeftRightAlignment.Left);
        }
        private void estimationBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!Validate_TradeAdvice()) return;
                //ClearTradeAdvice();
                //ShowChart();
                //ShowEstimation(this.myStockCodeRow, cbStrategy.GetDataInfo(), chartTiming.myTimeScale,chartTiming.frDate, chartTiming.toDate);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void chartLineBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.myChartType = chartTypeEnum.Line; 
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void chartCandelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.myChartType = chartTypeEnum.CandelStick;
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void chartBarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.myChartType = chartTypeEnum.Bar;
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void volumeChartBtn_Click(object sender, EventArgs e)
        {
            try
            {
                volumeChartBtn.isDownState = !volumeChartBtn.isDownState;
                if (volumeChartBtn.isDownState)
                {
                    if (mainContainer.GetChild(volumePane) == null) this.volumePane = CreateVolumePane();
                    volumePane.Visible = true;
                }
                else
                {
                    RemovePane(volumePane);
                }
                mainContainer.ArrangeChildren();
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void timeScaleCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PlotChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void cbStrategy_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }       

        private void test_myOnChildPaneClosed(baseClass.controls.graphPane sender)
        {
            if (sender.Name == constVolumePaneName)
            {
                volumeChartBtn.isDownState = false;
            }
        }
        #endregion event handler
    }
}