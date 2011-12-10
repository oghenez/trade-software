using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using application;
using commonClass;

namespace client
{
    //public partial class main : common.forms.baseApplication
    public partial class main : baseClass.forms.baseApplication
    {
        const int constPaneLeftWidth = 13; //In percentage
        const string constFormNameIndicator = "indicator-";
        const string constFormNameStock = "stock-";
        const string constFormNameWatchList = "WatchList-";
        const string constFormNameTradeAlert = "TradeAlert";
        const string constFormNameEstimateTrade = "EstimateTrade-";

        private bool fProcessing = false;

        public main()
        {
            try
            {
                using (new common.PleaseWait(new Point(),new forms.startSplash() ))
                {
                    commonClass.SysLibs.myAccessMode = DataAccessMode.WebService;
                    InitializeComponent();
                    DataAccess.Libs.LoadSystemVars();
                    if (Settings.sysTimerIntervalInSecs > 0)
                    {
                        sysTimer.Interval = Settings.sysTimerIntervalInSecs * 1000; //Convert to mili-seconds 
                        sysTimer.Enabled = true;
                    }
                    //test.LoadTestConfig();
                    Init();
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.FileMenuStrip.Text = Languages.Libs.GetString("file");
            this.loginMenuItem.Text = Languages.Libs.GetString("login");
            this.logOutMenuItem.Text = Languages.Libs.GetString("logout");
            this.MyProfileMenuItem.Text = Languages.Libs.GetString("myProfile"); ;
            this.NewChartMenuItem.Text = Languages.Libs.GetString("newChart");
            this.closeChartMenuItem.Text = Languages.Libs.GetString("closeChart");

            this.configMenuItem.Text = Languages.Libs.GetString("configure");
            this.printSetupMenuItem.Text = Languages.Libs.GetString("printSetup");
            this.printPreViewMenuItem.Text = Languages.Libs.GetString("printPreview");
            this.printMenuItem.Text = Languages.Libs.GetString("print");
            this.exitMenuItem.Text = Languages.Libs.GetString("exit");

            this.editMenuStrip.Text = Languages.Libs.GetString("edit");
            this.undoMenuItem.Text = Languages.Libs.GetString("undo");
            this.redoMenuItem.Text = Languages.Libs.GetString("redo");
            this.copyMenuItem.Text = Languages.Libs.GetString("copy");
            this.cutMenuItem.Text = Languages.Libs.GetString("cut");
            this.pasteMenuItem.Text = Languages.Libs.GetString("paste");
            this.deleteMenuItem.Text = Languages.Libs.GetString("delete");
            this.selectAllMenuItem.Text = Languages.Libs.GetString("selectAll");

            this.viewMenuStrip.Text = Languages.Libs.GetString("view");
            this.languageMenuItem.Text = Languages.Libs.GetString("language");
            this.englishMenuItem.Text = Languages.Libs.GetString("english");
            this.vietnameseMenuItem.Text = Languages.Libs.GetString("vietnamese");

            this.toolBarMenuItem.Text = Languages.Libs.GetString("toolBar");
            this.tbStandardMenuItem.Text = Languages.Libs.GetString("standard");
            this.tbChartMenuItem.Text = Languages.Libs.GetString("chart");
            this.tbPeriodicityMenuItem.Text = Languages.Libs.GetString("periodicity");

            this.marketWatchMenuItem.Text = Languages.Libs.GetString("marketWatch");
            this.tradeAlertMenuItem.Text = Languages.Libs.GetString("tradeAlert");
            this.transHistoryMenuItem.Text = Languages.Libs.GetString("transHistory");
            this.myPortfolioMenuItem.Text = Languages.Libs.GetString("myPortfolio");
            this.strategyEstimationiMenuItem.Text = Languages.Libs.GetString("strategyEstimation");

            this.chartMenuStrip.Text = Languages.Libs.GetString("chart");
            this.indicatorMenuItem.Text = Languages.Libs.GetString("indicator");
            this.chartMenuItem.Text = Languages.Libs.GetString("chart");
            this.lineChartMenuItem.Text = Languages.Libs.GetString("lineChart");
            this.barChartMenuItem.Text = Languages.Libs.GetString("barChart");
            this.candleSticksMenuItem.Text = Languages.Libs.GetString("candleSticks");
            this.chartGridMenuItem.Text = Languages.Libs.GetString("chartGrid");
            this.periodicityMenuItem.Text = Languages.Libs.GetString("periodicity");
            this.zoomInMenuItem.Text = Languages.Libs.GetString("zoomIn");
            this.zoomOutMenuItem.Text = Languages.Libs.GetString("zoomOut");
            this.chartVolumeMenuItem.Text = Languages.Libs.GetString("chartVolume");
            this.chartPropertyMenuItem.Text = Languages.Libs.GetString("chartProperty");

            this.toolsMenuItem.Text = Languages.Libs.GetString("tools");
            this.backTestingMenuItem.Text = Languages.Libs.GetString("backTesting");
            this.strategyRankingMenuItem.Text = Languages.Libs.GetString("strategyRanking");
            this.companyListMenuItem.Text = Languages.Libs.GetString("companyList");
            
            this.toolOptionMenu.Text = Languages.Libs.GetString("toolAllOptions");
            this.toolOptionsMenuItem.Text = Languages.Libs.GetString("toolOption");
            this.strategyOptionsMenuItem.Text = Languages.Libs.GetString("strategyOption");
            this.screeningOptionsMenuItem.Text = Languages.Libs.GetString("screeningOption");


            this.windowsMenuItem.Text = Languages.Libs.GetString("windows");
            this.closeAllMenuItem.Text = Languages.Libs.GetString("closeAll");

            this.helpMenuItem.Text = Languages.Libs.GetString("help");
            this.contentsMenuItem.Text = Languages.Libs.GetString("contents");
            this.indexMenuItem.Text = Languages.Libs.GetString("index");
            this.searchMenuItem.Text = Languages.Libs.GetString("search");
            this.aboutMenuItem.Text = Languages.Libs.GetString("about");


            this.screeningMenuItem.Text = Languages.Libs.GetString("screening");
            this.orderMenuItem.Text = Languages.Libs.GetString("order");
            this.strategyListMenuItem.Text = Languages.Libs.GetString("strategy");
            this.screeningMenuItem.Text = Languages.Libs.GetString("screening");

            dataTimeRangeCb.SetLanguage();

            //Create indicator menu
            indicatorMenuItem.DropDownItems.Clear();
            Indicators.Libs.CreateIndicatorMenu(indicatorMenuItem, showIndicatorHandler);

            //Strategy menu
            strategyListMenuItem.DropDownItems.Clear();
            Strategy.Libs.CreateMenu(AppTypes.StrategyTypes.Strategy, strategyListMenuItem, PlotTradepointHandler);

            strategyOptionsMenuItem.DropDownItems.Clear();
            Strategy.Libs.CreateMenu(AppTypes.StrategyTypes.Strategy, strategyOptionsMenuItem,StrategyParaEditHandler);

            screeningOptionsMenuItem.DropDownItems.Clear();
            Strategy.Libs.CreateMenu(AppTypes.StrategyTypes.Screening, screeningOptionsMenuItem,StrategyParaEditHandler);

            strategyCbStrip.Items.Clear();
            strategyCbStrip.LoadData();
        }

        private common.DictionaryList cachedForms = new common.DictionaryList();  // To cache used forms 

        protected override bool LoadAppConfig()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            return base.LoadAppConfig();
        }
        protected override bool CheckValid()
        {
            return true;
        }

        private common.DictionaryList cultureCache = new common.DictionaryList();
        private void SetCulture()
        {
            SetCulture("en-US");
        }
        private void SetCulture(string code)
        {
            CultureInfo cultureInfo = null;
            object obj = cultureCache.Find(code);
            if (obj == null)
            {
                cultureInfo = common.language.CreateCulture(code);
                cultureCache.Add(code, cultureInfo);
            }
            else
            {
                cultureInfo = (CultureInfo)obj;
            }
            switch (cultureInfo.Name)
            { 
                case "vi-VN":
                    vietnameseMenuItem.Checked = true;
                    englishMenuItem.Checked = false;
                    break;
                default:
                    vietnameseMenuItem.Checked = false;
                    englishMenuItem.Checked = true;
                    break;
            }
            common.language.myCulture = cultureInfo;
            common.language.SetLanguage();
            commonClass.SysLibs.SetLanguage();
            Strategy.Data.Clear();
            Indicators.Data.Clear();
            common.language.SetLanguageForAllOpenForms(cultureInfo);
            SetLanguage();
        }

        private void Init()
        {
            //Combobox that allow user to set date range of used data.
            dataTimeRangeCb.LoadData();

            standartStrip.BringToFront();
            chartStrip.BringToFront();
            toolsStrip.BringToFront();
            periodicityStrip.BringToFront();

            //Assign chart type to each button
            lineChartBtn.Tag = AppTypes.ChartTypes.Line;
            barChartBtn.Tag = AppTypes.ChartTypes.Bar;
            candleSticksBtn.Tag = AppTypes.ChartTypes.CandleStick;

            lineChartMenuItem.Tag = AppTypes.ChartTypes.Line;
            barChartMenuItem.Tag = AppTypes.ChartTypes.Bar;
            candleSticksMenuItem.Tag = AppTypes.ChartTypes.CandleStick;

            //Create period button strips : M5,H1,H2,W1,D1,...
            periodicityStrip.Items.Clear();
            periodicityMenuItem.DropDownItems.Clear();
            CreatePeriodicityStrip(periodicityStrip, periodicityMenuItem);

            strategyCbStrip.SelectedIndexChanged += new EventHandler(PlotTradepointHandler);

            this.ChartType = AppTypes.ChartTypes.CandleStick;
            this.ChartTimeScale = AppTypes.MainDataTimeScale;

            //dockPanel
            dockPanel.Parent = this;     
            dockPanel.DockLeftPortion = (double)constPaneLeftWidth/100;
            dockPanel.AllowDrop = true;
            dockPanel.ActiveAutoHideContent = null;
            
            //Language default
            SetCulture();
        }

        private void CreatePeriodicityStrip(ToolStrip toStrip,ToolStripMenuItem toMenu)
        {
            ToolStripButton btn;
            ToolStripMenuItem menuItem;
            AppTypes.TimeScaleTypes lastTimeScaleType =  AppTypes.TimeScaleTypes.Day;
            for (int idx = 0; idx < AppTypes.myTimeScales.Length; idx++)
            {
                btn = new ToolStripButton();
                btn.Name = "Periodicity-" + AppTypes.myTimeScales[idx].Code;
                btn.Text = AppTypes.myTimeScales[idx].Text;
                btn.Tag = AppTypes.myTimeScales[idx];
                btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
                btn.Click += new EventHandler(PeriodicityButon_Click);
                if (toStrip.Items.Count > 0)toStrip.Items.Add(new ToolStripSeparator());
                toStrip.Items.Add(btn);

                if (idx == 0) lastTimeScaleType = AppTypes.myTimeScales[idx].Type;
                if (lastTimeScaleType != AppTypes.myTimeScales[idx].Type)
                {
                    toMenu.DropDownItems.Add(new ToolStripSeparator());
                    lastTimeScaleType = AppTypes.myTimeScales[idx].Type;
                }
                menuItem = new ToolStripMenuItem();
                menuItem.Name = "Periodicity-menu-" + AppTypes.myTimeScales[idx].Code;
                menuItem.Text = AppTypes.myTimeScales[idx].Text;
                menuItem.Tag = AppTypes.myTimeScales[idx];
                menuItem.Click += new EventHandler(PeriodicityMenu_Click);
                toMenu.DropDownItems.Add(menuItem);
            }
        }

        private AppTypes.TimeScale ChartTimeScale
        {
            get
            {
                for (int idx = 0; idx < periodicityStrip.Items.Count; idx++)
                {
                    if (periodicityStrip.Items[idx].GetType() != typeof(ToolStripButton)) continue;
                    ToolStripButton btn = (ToolStripButton)periodicityStrip.Items[idx];
                    if (btn.Checked) return  (AppTypes.TimeScale)btn.Tag;
                }
                return AppTypes.MainDataTimeScale;
            }
            set
            {
                AppTypes.TimeScale saveTimeScale = this.ChartTimeScale;
                for (int idx = 0; idx < periodicityStrip.Items.Count; idx++)
                {
                    if (periodicityStrip.Items[idx].GetType() != typeof(ToolStripButton)) continue;
                    ToolStripButton btn = (ToolStripButton)periodicityStrip.Items[idx];
                    btn.Checked = ((AppTypes.TimeScale)btn.Tag == value);
                }
                for (int idx = 0; idx < periodicityMenuItem.DropDownItems.Count; idx++)
                {
                    if (periodicityMenuItem.DropDownItems[idx].GetType() != typeof(ToolStripMenuItem)) continue;
                    ToolStripMenuItem item = (ToolStripMenuItem)periodicityMenuItem.DropDownItems[idx];
                    item.Checked =  ((AppTypes.TimeScale)item.Tag == value);
                }
            }
        }

        /// <summary>
        /// Update waht part in the active form
        /// </summary>
        private enum FormOptions : byte
        {
            PricePane = 0, VolumePane = 1, ChartType =4, HaveGrid =8, TimeScale=16, All = 255
        }
        private void UpdateActiveForm()
        {
            UpdateActiveForm(FormOptions.All);
        }
        private void UpdateActiveForm(FormOptions parts)
        {
            Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
            if (activeForm == null) return;

            if ((parts & FormOptions.VolumePane) != 0) 
                activeForm.ChartVolumeVisibility = true;

            if ((parts & FormOptions.ChartType) != 0) 
                activeForm.ChartPriceType = this.ChartType;

            if ((parts & FormOptions.HaveGrid) != 0) 
                activeForm.ChartHaveGrid = this.ChartHaveGrid;

            if ((parts & FormOptions.TimeScale) != 0)
            {
                activeForm.ChartTimeScale = this.ChartTimeScale;
                activeForm.ReloadChart();
            }
        }

        /// <summary>
        /// Refresh data  : the function will be called after each [sysTimerIntervalInSecs] seconds 
        /// </summary>
        private void RefreshData()
        {
            IDockContent[] fomrs = new IDockContent[0];
            for (int idx = 0; idx < dockPanel.Contents.Count; idx++)
            {
                //Update stock charts
                if (dockPanel.Contents[idx].GetType() == typeof(Tools.Forms.tradeAnalysis))
                {
                    (dockPanel.Contents[idx] as Tools.Forms.tradeAnalysis).UpdateDataFromLastTime();
                    continue;
                }
                //Market watch
                if (dockPanel.Contents[idx].GetType() == typeof(Trade.Forms.marketWatch))
                {
                    (dockPanel.Contents[idx] as Trade.Forms.marketWatch).RefreshPrice();
                    continue;
                }
                //Portfolio watch
                if (dockPanel.Contents[idx].GetType() == typeof(Trade.Forms.portfolioWatch))
                {
                    (dockPanel.Contents[idx] as Trade.Forms.portfolioWatch).Refresh();
                    continue;
                }
                //Trade Alert
                if (dockPanel.Contents[idx].GetType() == typeof(Trade.Forms.tradeAlertList))
                {
                    (dockPanel.Contents[idx] as Trade.Forms.tradeAlertList).Refresh();
                    continue;
                }
            }
        }

        private AppTypes.ChartTypes ChartType
        {
            get
            {
                if(barChartBtn.Checked) return AppTypes.ChartTypes.Bar;
                if (candleSticksBtn.Checked) return AppTypes.ChartTypes.CandleStick; 
                return AppTypes.ChartTypes.Line; 
            }
            set
            {
                switch (value)
                {
                    case AppTypes.ChartTypes.Bar:
                        lineChartBtn.Checked = false;
                        barChartBtn.Checked = true;
                        candleSticksBtn.Checked = false;

                        lineChartMenuItem.Checked = false;
                        barChartMenuItem.Checked = true;
                        candleSticksMenuItem.Checked = false;
                        break;
                    case AppTypes.ChartTypes.CandleStick:
                        lineChartBtn.Checked = false;
                        barChartBtn.Checked = false;
                        candleSticksBtn.Checked = true;

                        lineChartMenuItem.Checked = false;
                        barChartMenuItem.Checked = false;
                        candleSticksMenuItem.Checked = true;
                        break;
                    default:
                        lineChartBtn.Checked = true;
                        barChartBtn.Checked = false;
                        candleSticksBtn.Checked = false;

                        lineChartMenuItem.Checked = true;
                        barChartMenuItem.Checked = false;
                        candleSticksMenuItem.Checked = false;
                        break;
                }
            }
        }
        
        private bool ChartHaveGrid
        {
            get { return chartGridMenuItem.Checked; }
            set { chartGridMenuItem.Checked = value;}
        }

        private bool ChartHaveStrategyEstimation
        {
            get { return strategyEstimationiMenuItem.Checked; }
            set { strategyEstimationiMenuItem.Checked = value;}
        }

        private void Export()
        {
            object activeObj = dockPanel.ActiveContent;
            if (activeObj == null) return;
            Type activeType = activeObj.GetType();
            if (activeType == typeof(Tools.Forms.backTesting))
            {
                ((Tools.Forms.backTesting)activeObj).ExportResult();
                return;
            }

            if (activeType == typeof(Tools.Forms.strategyRanking))
            {
                ((Tools.Forms.strategyRanking)activeObj).ExportResult();
                return;
            }

            if (activeType == typeof(Tools.Forms.profitEstimate))
            {
                ((Tools.Forms.profitEstimate)activeObj).Export();
                return;
            }
            if (activeType == typeof(Tools.Forms.screening))
            {
                ((Tools.Forms.screening)activeObj).Export();
                return;
            }
            if (activeType == typeof(Trade.Forms.transactionList))
            {
                ((Trade.Forms.transactionList)activeObj).Export();
                return;
            }
            if (activeType == typeof(Trade.Forms.tradeAlertList))
            {
                ((Trade.Forms.tradeAlertList)activeObj).Export();
                return;
            }
            if (activeType == typeof(Trade.Forms.portfolioWatch))
            {
                ((Trade.Forms.portfolioWatch)activeObj).Export();
                return;
            }
            if (activeType == typeof(Trade.Forms.marketWatch))
            {
                ((Trade.Forms.marketWatch)activeObj).Export();
                return;
            }
        }

        private Trade.Forms.marketWatch GetMarketWatchForm(bool createIfNotFound)
        {
            string formName = constFormNameWatchList + "Market";
            Trade.Forms.marketWatch myForm = (Trade.Forms.marketWatch)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                if (!createIfNotFound) return null;
                using (new DataAccess.PleaseWait())
                {
                    myForm = new Trade.Forms.marketWatch();
                    myForm.Name = formName;
                    myForm.myOnShowChart += new baseClass.Events.onShowChart(ShowStockChart);
                    cachedForms.Add(formName, myForm);
                }
            }
            return myForm;
        }
        private void ShowMarketWatchForm()
        {
            GetMarketWatchForm(true).Show(dockPanel, DockState.DockLeft);
        }
        private void ShowPortfolioWatchtForm()
        {
            string formName = constFormNameWatchList + "Portfolio";
            Trade.Forms.portfolioWatch myForm = (Trade.Forms.portfolioWatch)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Trade.Forms.portfolioWatch();
                myForm.Name = formName;
                myForm.myOnShowChart += new baseClass.forms.basePortfolioWatch.onShowChart(ShowStockChart);
                cachedForms.Add(formName, myForm);
            }
            myForm.Show(dockPanel, DockState.DockBottom);
        }
        private void ShowTradeAlertForm()
        {
            string formName = constFormNameTradeAlert;
            Trade.Forms.tradeAlertList myForm = (Trade.Forms.tradeAlertList)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Trade.Forms.tradeAlertList();
                myForm.Name = formName;
                myForm.Init();
                myForm.LoadData();
                //myForm.myOnShowChart += new baseClass.forms.basePortfolioView.onShowChart(ShowStockChart);
                cachedForms.Add(formName, myForm);
            }
            myForm.Show(dockPanel, DockState.DockBottom);
        }

        private void ShowStockChart(string stockCode)
        {
            string formName = constFormNameStock + stockCode.Trim();
            Tools.Forms.tradeAnalysis myForm = (Tools.Forms.tradeAnalysis)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Tools.Forms.tradeAnalysis();
                myForm.Name = formName;

                myForm.ChartTimeRange = dataTimeRangeCb.myValue;
                myForm.UseStock(DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode) );  //Get data first

                
                myForm.ChartPriceType = this.ChartType;
                myForm.Activated += new System.EventHandler(this.tradeAnalysisActivatedHandler);
                myForm.myEstimateTradePoints += new Tools.Forms.tradeAnalysis.EstimateTradePointFunc(EstimateTradePointHandler);
                //Cache it if no error occured
                cachedForms.Add(formName, myForm);
            }
            myForm.Show(dockPanel);
            UpdateActiveForm(FormOptions.ChartType); 
        }

        private void ShowStockChart(string stockCode,AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            DateTime frDate = common.Consts.constNullDate, toDate = common.Consts.constNullDate;
            if (!AppTypes.GetDate(timeRange, out frDate, out toDate)) return;

            string formName = constFormNameStock + stockCode.Trim();
            Tools.Forms.tradeAnalysis myForm = (Tools.Forms.tradeAnalysis)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Tools.Forms.tradeAnalysis();
                myForm.Name = formName;
                myForm.ChartTimeRange = timeRange;
                myForm.ChartTimeScale = timeScale;
                myForm.ChartPriceType = this.ChartType;
                myForm.UseStock(DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode));
                myForm.Activated += new System.EventHandler(this.tradeAnalysisActivatedHandler);
                myForm.myEstimateTradePoints += new Tools.Forms.tradeAnalysis.EstimateTradePointFunc(EstimateTradePointHandler);
                //Cache it if no error occured
                cachedForms.Add(formName, myForm);
            }
            myForm.Show(dockPanel);
            UpdateActiveForm(FormOptions.ChartType); 
        }

        /// <summary>
        /// Update (re-load data,re-draw charts...) for all active trade analaysis forms 
        /// </summary>
        private void UpdateChartData()
        {
            Tools.Forms.tradeAnalysis myForm;
            object[] foundForms = cachedForms.FindAll(constFormNameStock);
            for (int idx = 0; idx < foundForms.Length; idx++)
            {
                myForm = (Tools.Forms.tradeAnalysis)foundForms[idx];
                if (myForm.IsDisposed) continue;
                myForm.ChartTimeRange = dataTimeRangeCb.myValue; 
                myForm.ReloadChart();
            }
        }
        /// <summary>
        /// Refresh/Re-draw charts for all active trade analaysis forms.
        /// </summary>
        private void RefreshAllCharts()
        {
            Tools.Forms.tradeAnalysis tradeAnalysisForm;
            object[] foundForms = cachedForms.FindAll(constFormNameStock);
            for (int idx = 0; idx < foundForms.Length; idx++)
            {
                tradeAnalysisForm = (Tools.Forms.tradeAnalysis)foundForms[idx];
                if (tradeAnalysisForm.IsDisposed) continue;
                tradeAnalysisForm.ReDrawChart();
            }
        }

        /// <summary>
        /// Get active form. 
        /// </summary>
        /// <returns>Null if there is no active form.</returns>
        private Tools.Forms.tradeAnalysis GetActiveStockForm()
        {
            object activeObj = dockPanel.ActiveDocument;
            if (activeObj == null) return null;
            Type activeType = activeObj.GetType();
            if (activeType == typeof(Tools.Forms.tradeAnalysis))
            {
                return (Tools.Forms.tradeAnalysis)activeObj;
            }
            return null;
        }

        private IDockContent[] GetCurrentForms(Type type)
        {
            IDockContent[] fomrs = new IDockContent[0];
            for (int idx = 0; idx < dockPanel.Contents.Count; idx++)
            {
                if (dockPanel.Contents[idx].GetType() != type) continue;
                Array.Resize(ref fomrs, fomrs.Length + 1);
                fomrs[fomrs.Length - 1] = dockPanel.Contents[idx];
            }
            return fomrs;
        }


        #region event handler

        private void EstimateTradePointHandler(Tools.Forms.tradeAnalysis sender, string strategyCode, 
                                               EstimateOptions option, data.tmpDS.tradeEstimateDataTable tbl)
        {
            string formName = constFormNameEstimateTrade + "-" + sender.myData.DataStockCode;
            Tools.Forms.profitEstimate myForm = (Tools.Forms.profitEstimate)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Tools.Forms.profitEstimate();
                myForm.Name = formName;
                cachedForms.Add(formName, myForm);
            }
            //myForm.CheckTradepoints(sendder.myData, tradePoints);

            myForm.myTimeRange = sender.myData.DataTimeRange;
            myForm.myTimeScale = sender.myData.DataTimeScale;
            myForm.myStockCode = sender.myData.DataStockCode;
            myForm.myStrategyCode = strategyCode;
            myForm.myOptions = option;
            myForm.SetData(tbl);
            myForm.IsShowChart = true;
            myForm.PlotProfitChart();
            myForm.IsShowAllTransactions = false;
            myForm.Show(dockPanel, DockState.DockBottom);
        }
        private void tradeAnalysisActivatedHandler(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = (Tools.Forms.tradeAnalysis)sender;
                if (activeForm == null) return;
                this.ChartType = activeForm.ChartPriceType;
                this.ChartTimeScale = activeForm.ChartTimeScale;
                this.ChartHaveGrid = activeForm.ChartHaveGrid;

                activeForm.RestoreChart();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void chartPropertyHandler(object sender, common.baseDialogEvent e)
        {
            if (e != null && e.isCloseClick) return;
            RefreshAllCharts();
        }
        private void showIndicatorHandler(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm != null)
                {
                    activeForm.PlotIndicator(((ToolStripMenuItem)sender).Tag.ToString());
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        
        private void StrategyParaEditHandler(object sender, EventArgs e)
        {
            try
            {
                Strategy.Meta meta = Strategy.Libs.FindMetaByName(((ToolStripMenuItem)sender).Tag.ToString());
                Strategy.Libs.ShowStrategyForm(meta);
            }
            catch (Exception er)
            {
                common.system.ShowErrorMessage(er.Message);
            }
        }

        private void PlotTradepointHandler(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm == null) return;

                baseClass.controls.ToolStripCbStrategy item = (baseClass.controls.ToolStripCbStrategy)sender;
                Strategy.Meta meta = Strategy.Libs.FindMetaByCode(item.myValue);
                if (meta == null) activeForm.ClearStrategyTradepoints();
                else activeForm.PlotStrategyTradepoints(meta, this.ChartHaveStrategyEstimation); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }


        private void ShowStockHandler(string stockCode,AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            try
            {
                ShowStockChart(stockCode, timeRange, timeScale);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void View_ToolBar_MenuClick(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(ToolStripMenuItem)) return;
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            if (menu == tbStandardMenuItem)
            {
                standartStrip.Visible = menu.Checked;
                return;
            }
            if (menu == tbChartMenuItem)
            {
                chartStrip.Visible = menu.Checked;
                return;
            }
            if (menu == tbPeriodicityMenuItem)
            {
                periodicityStrip.Visible = menu.Checked;
                return;
            }
        }

        private void ChartTypeButton_Click(object sender, EventArgs e)
        {
            this.ChartType = (AppTypes.ChartTypes)((ToolStripButton)sender).Tag;
            UpdateActiveForm(FormOptions.ChartType); 
        }
        private void ChartTypeMenu_Click(object sender, EventArgs e)
        {
            this.ChartType = (AppTypes.ChartTypes)((ToolStripMenuItem)sender).Tag;
            Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
            UpdateActiveForm(FormOptions.ChartType); 
        }

        private void PeriodicityButon_Click(object sender, EventArgs e)
        {
            this.ChartTimeScale = ((AppTypes.TimeScale)((ToolStripButton)sender).Tag);
            UpdateActiveForm(FormOptions.TimeScale); 
        }
        private void PeriodicityMenu_Click(object sender, EventArgs e)
        {
            this.ChartTimeScale = ((AppTypes.TimeScale)((ToolStripMenuItem)sender).Tag);
            UpdateActiveForm(FormOptions.TimeScale); 
        }

        private void ChartVolume_Click(object sender, EventArgs e)
        {
            UpdateActiveForm(FormOptions.VolumePane);
        }
        private void ChartGridMenuItem_Click(object sender, EventArgs e)
        {
            this.ChartHaveGrid = !this.ChartHaveGrid;
        }

        private void ChartRefreshBtn_Click(object sender, EventArgs e)
        {
            UpdateActiveForm(FormOptions.ChartType); 
        }

        private void NewChartMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.marketWatch form = GetMarketWatchForm(false);
                if (form == null) return;
                if (form.CurrentRow == null) return;
                ShowStockChart(form.CurrentRow.code);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void CloseChartMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm != null) activeForm.Close();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void closeAllMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private Tools.Forms.backTesting GetActiveBackTestingForm()
        {
            object activeObj = dockPanel.ActiveContent;
            if (activeObj == null) return null;
            Type activeType = activeObj.GetType();
            if (activeType == typeof(Tools.Forms.backTesting))
            {
                return ((Tools.Forms.backTesting)activeObj);
            }
            return null;
        }
        private Tools.Forms.strategyRanking GetActivestrategyRankingForm()
        {
            object activeObj = dockPanel.ActiveContent;
            if (activeObj == null) return null;
            Type activeType = activeObj.GetType();
            if (activeType == typeof(Tools.Forms.strategyRanking))
            {
                return ((Tools.Forms.strategyRanking)activeObj);
            }
            return null;
        }
        private Tools.Forms.screening GetActiveScreeningForm()
        {
            Tools.Forms.screening myForm = Tools.Forms.screening.GetForm();
            if (myForm == null || myForm.IsDisposed || !myForm.IsActivated) return null;
            return myForm;
        }

        
        private void backTestingMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.backTesting form = Tools.Forms.backTesting.GetForm("");
                form.myDockedPane = dockPanel;
                form.myShowStock += new Tools.Forms.backTesting.ShowStockFunc(ShowStockHandler);

                form.Name = "backTesting";
                form.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void screeningMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.screening myForm = Tools.Forms.screening.GetForm();
                myForm.myShowStock += new Tools.Forms.backTesting.ShowStockFunc(ShowStockHandler);
                myForm.Name = "screening";
                myForm.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }


        private void loginMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowLogin(); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void logOutMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                commonClass.SysLibs.ClearLogin();
                if (!this.ShowLogin())
                {
                    commonClass.SysLibs.ExitApplication();
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                commonClass.SysLibs.ExitApplication();
                this.Close();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void marketWatchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMarketWatchForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void portfolioWatchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ShowPortfolioWatchtForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void tradeAlertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ShowTradeAlertForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void dataTimeRangeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Update data for all active stocks
                UpdateChartData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void chartPropertiesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                baseClass.forms.chartProperties.GetForm("").Show(dockPanel, DockState.DockRightAutoHide);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void companyListMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                forms.companyList myForm = (forms.companyList)this.FindForm("companyList");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new forms.companyList();
                    myForm.Name = "companyList";
                }
                myForm.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void MyProfileMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                forms.investorEdit myForm = (forms.investorEdit)this.FindForm("investorEdit");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new forms.investorEdit();
                    myForm.Name = "investorEdit";
                    myForm.myDockedPane = dockPanel;
                }
                myForm.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void printSetupMenuItem_Click(object sender, EventArgs e)
        {
            myPrintDialog.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {
            try
            {
                //Start forms
                marketWatchBtn_Click(this, null);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void toolRunBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.backTesting backTestingForm = GetActiveBackTestingForm();
                if (backTestingForm != null)
                {
                    backTestingForm.Execute();
                    return;
                }

                Tools.Forms.strategyRanking strategyRankingForm = GetActivestrategyRankingForm();
                if (strategyRankingForm != null)
                {
                    strategyRankingForm.Execute();
                    return;
                }

                Tools.Forms.screening screeningForm = GetActiveScreeningForm();
                if (screeningForm != null)
                {
                    screeningForm.Execute();
                    return;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void toolFullViewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.backTesting backTestingForm = GetActiveBackTestingForm();
                if (backTestingForm != null)
                {
                    backTestingForm.IsFullScreen = !backTestingForm.IsFullScreen;
                    return;
                }

                Tools.Forms.strategyRanking strategyRankingForm = GetActivestrategyRankingForm();
                if (strategyRankingForm != null)
                {
                    strategyRankingForm.IsFullScreen = !strategyRankingForm.IsFullScreen;
                    return;
                }

                Tools.Forms.screening screeningForm = GetActiveScreeningForm();
                if (screeningForm != null)
                {
                    screeningForm.IsFullScreen = !screeningForm.IsFullScreen;
                    return;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
       

        private void transHistoryMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.transactionList myForm = Trade.Forms.transactionList.GetForm("");
                myForm.Show(dockPanel, DockState.DockBottom);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void orderMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.transactionNew form = Trade.Forms.transactionNew.GetForm("");
                form.ClearEditData();
                form.LockEdit(false);
                form.ShowDialog();                
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Export();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void rankingBtn_Click(object sender, EventArgs e)
        {

        }

        private void strategyRankingMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.strategyRanking form = Tools.Forms.strategyRanking.GetForm("");
                form.myShowStock += new Tools.Forms.backTesting.ShowStockFunc(ShowStockHandler);
                form.myDockedPane = dockPanel;
                form.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }


        private void Amount2Percent(Tools.Forms.baseTesting.ValueTypes value)
        {
            object activeObj = dockPanel.ActiveContent;
            if (activeObj == null) return;
            Type activeType = activeObj.GetType();

            if (activeType == typeof(Tools.Forms.backTesting))
            {
                ((Tools.Forms.backTesting)activeObj).myValueType = value;
                return;
            }

            if (activeType == typeof(Tools.Forms.strategyRanking))
            {
                ((Tools.Forms.strategyRanking)activeObj).myValueType = value;
                return;
            }
        }        
        private void amountBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Amount2Percent(Tools.Forms.baseTesting.ValueTypes.Amount); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void percentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Amount2Percent(Tools.Forms.baseTesting.ValueTypes.Percentage);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        
        private void toolOptionMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.options.GetForm("").ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void vietnameseMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetCulture("vi-VN");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        
        private void englishMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetCulture("en-US");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        

        private void zoomInMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm == null) return;
                activeForm.ZoomIn();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void zoomOutMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm == null) return;
                activeForm.ZoomOut();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        
        private void sysTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;

                RefreshData();
                fProcessing = false;
            }
            catch (Exception er)
            {
                fProcessing = false;
                this.ShowError(er);
            }
        }

        private void configMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baseClass.forms.configure form = new baseClass.forms.configure();
                form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}
