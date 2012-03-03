﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using application;
using commonTypes;
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
        const string constFormNameMarketSummary = "MarketSummary";
        const string constFormNameEstimateTrade = "EstimateTrade-";

        public main()
        {
            try
            {
                using (new common.PleaseWait(new Point(), new forms.startSplash()))
                {
                    InitializeComponent();
                    SetTimer(false);
                    SetFormAppearance();

                    InitSystem(false);
                    this.LogAccess = false;
                }
                testMenuItem.Visible = false;
            }
            catch (Exception er)
            {
                //common.system.ShowError(Languages.Libs.GetString("loadDataError"), Languages.Libs.GetString("internetError"));
                common.system.ShowError(Languages.Libs.GetString("loadDataError"),er.Message);
                this.ShowError(er);
            }
        }
        private bool InitSystem(bool force)
        {
            if (force) DataAccess.Libs.ClearCache();
            //Load XML meta for STRATEGY and INDICATOR
            application.Strategy.Data.sysXmlDocument = DataAccess.Libs.GetXmlDocumentSTRATEGY();
            application.Indicators.Data.sysXmlDocument = DataAccess.Libs.GetXmlDocumentINDICATOR();
            DataAccess.Libs.LoadSystemVars();
            return true;
        }

        #region CreateContextMenu
        private ContextMenuStrip CreateContextMenu_MarketWatch()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(NewChartMenuItem.Text);
            menuItem.Click += new System.EventHandler(NewChartMenuItem_Click);

            contextMenuStrip.Items.Add(new ToolStripSeparator());
            menuItem = contextMenuStrip.Items.Add(Languages.Libs.GetString("addToWatchList"));
            menuItem.Click += new System.EventHandler(addToWatchListMenuItem_Click);
            menuItem = contextMenuStrip.Items.Add(orderMenuItem.Text);
            menuItem.Click += new System.EventHandler(orderMenuItem_Click);

            contextMenuStrip.Items.Add(new ToolStripSeparator());
            menuItem = contextMenuStrip.Items.Add(backTestingMenuItem.Text);
            menuItem.Click += new System.EventHandler(backTestingMenuItem_Click);
            menuItem = contextMenuStrip.Items.Add(strategyRankingMenuItem.Text);
            menuItem.Click += new System.EventHandler(strategyRankingMenuItem_Click);
            menuItem = contextMenuStrip.Items.Add(screeningMenuItem.Text);
            menuItem.Click += new System.EventHandler(screeningMenuItem_Click);
            
            return contextMenuStrip;
        }
        private ContextMenuStrip CreateContextMenu_TradeAnalysis()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;

            
            menuItem = contextMenuStrip.Items.Add(zoomInMenuItem.Text);
            menuItem.Click += new System.EventHandler(zoomInMenuItem_Click);
            menuItem = contextMenuStrip.Items.Add(zoomOutMenuItem.Text);
            menuItem.Click += new System.EventHandler(zoomOutMenuItem_Click);

            //menu for Strategy
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            System.Windows.Forms.ToolStripMenuItem strategyMenuItem = new ToolStripMenuItem();
            strategyMenuItem.Text = Languages.Libs.GetString("strategy");
            application.Strategy.Libs.CreateMenu(AppTypes.StrategyTypes.Strategy, strategyMenuItem, PlotTradepointHandler);
            contextMenuStrip.Items.Add(strategyMenuItem);

            //menu for indicator
            System.Windows.Forms.ToolStripMenuItem indicatorMenuItem = new ToolStripMenuItem();
            indicatorMenuItem.Text = Languages.Libs.GetString("indicator");
            
            application.Indicators.Libs.CreateIndicatorMenu(indicatorMenuItem, showIndicatorHandler);
            contextMenuStrip.Items.Add(indicatorMenuItem);

            //Tools
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            menuItem = contextMenuStrip.Items.Add(backTestingMenuItem.Text);
            menuItem.Click += new System.EventHandler(backTestingMenuItem_Click);
            menuItem = contextMenuStrip.Items.Add(strategyRankingMenuItem.Text);
            menuItem.Click += new System.EventHandler(strategyRankingMenuItem_Click);
            menuItem = contextMenuStrip.Items.Add(screeningMenuItem.Text);
            menuItem.Click += new System.EventHandler(screeningMenuItem_Click);


            return contextMenuStrip;
        }
        private ContextMenuStrip CreateContextMenu_TradeAlert()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(NewChartMenuItem.Text);
            menuItem.Click += new System.EventHandler(Alert_OpenChartMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(orderMenuItem.Text);
            menuItem.Click += new System.EventHandler(Alert_MakeOrderMenuItem_Click);

            contextMenuStrip.Items.Add(new ToolStripSeparator());
            menuItem = contextMenuStrip.Items.Add(backTestingMenuItem.Text);
            menuItem.Click += new System.EventHandler(backTestingMenuItem_Click);
            menuItem = contextMenuStrip.Items.Add(strategyRankingMenuItem.Text);
            menuItem.Click += new System.EventHandler(strategyRankingMenuItem_Click);
            menuItem = contextMenuStrip.Items.Add(screeningMenuItem.Text);
            menuItem.Click += new System.EventHandler(screeningMenuItem_Click);

            return contextMenuStrip;
        }
        #endregion

        static common.TimerProcess RefreshDataProc = null;
        static common.TimerProcess RefreshAlertProc = null;
        protected override void ProcessSysTimerTick()
        {
            base.ProcessSysTimerTick();
            if (!Settings.sysAutoRefreshData) return;

            if (RefreshDataProc == null)
            {
                RefreshDataProc = new common.TimerProcess();
                RefreshDataProc.WaitInSeconds = Settings.sysGlobal.RefreshDataInSecs;
                RefreshDataProc.OnProcess += new common.TimerProcess.OnProcessEvent(RefreshData);
            }
            RefreshDataProc.Execute();

            if (RefreshAlertProc == null)
            {
                RefreshAlertProc = new common.TimerProcess();
                RefreshAlertProc.WaitInSeconds = Settings.sysGlobal.CheckAlertInSeconds;
                RefreshAlertProc.OnProcess += new common.TimerProcess.OnProcessEvent(RefreshAlert);
            }
            RefreshAlertProc.Execute();
        }
        /// <summary>
        /// Set language for controls's main form
        /// </summary>
        public override void SetLanguage()
        {
            try
            {
                base.SetLanguage();
                this.FileMenuStrip.Text = Languages.Libs.GetString("file");
                this.loginMenuItem.Text = Languages.Libs.GetString("login");
                this.logOutMenuItem.Text = Languages.Libs.GetString("logout");
                this.changePassMenuItem.Text = Languages.Libs.GetString("changePassword");
                this.MyProfileMenuItem.Text = Languages.Libs.GetString("myProfile"); ;


                this.NewChartMenuItem.Text = Languages.Libs.GetString("openChart");
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
                this.strategyOptionsMenuItem.Text = Languages.Libs.GetString("strategyOption");
                this.screeningOptionsMenuItem.Text = Languages.Libs.GetString("screeningOption");

                this.sysOptionMenuItem.Text = Languages.Libs.GetString("sysOptions");


                this.windowsMenuItem.Text = Languages.Libs.GetString("windows");
                this.closeAllMenuItem.Text = Languages.Libs.GetString("closeAll");

                this.helpMenuItem.Text = Languages.Libs.GetString("help");
                this.contentsMenuItem.Text = Languages.Libs.GetString("contents");
                this.indexMenuItem.Text = Languages.Libs.GetString("index");
                this.searchMenuItem.Text = Languages.Libs.GetString("search");
                this.aboutMenuItem.Text = Languages.Libs.GetString("about");

                this.screeningMenuItem.Text = Languages.Libs.GetString("screening");
                this.orderMenuItem.Text = Languages.Libs.GetString("order");
                this.strategyEstimationMenuItem.Text = Languages.Libs.GetString("strategyEstimation");
                this.screeningMenuItem.Text = Languages.Libs.GetString("screening");


                //Create indicator menu
                indicatorMenuItem.DropDownItems.Clear();
                application.Indicators.Libs.CreateIndicatorMenu(indicatorMenuItem, showIndicatorHandler);

                //Strategy menu
                strategyEstimationMenuItem.DropDownItems.Clear();
                application.Strategy.Libs.CreateMenu(AppTypes.StrategyTypes.Strategy, strategyEstimationMenuItem, PlotTradepointHandler);

                strategyOptionsMenuItem.DropDownItems.Clear();
                application.Strategy.Libs.CreateMenu(AppTypes.StrategyTypes.Strategy, strategyOptionsMenuItem, StrategyParaEditHandler);

                screeningOptionsMenuItem.DropDownItems.Clear();
                application.Strategy.Libs.CreateMenu(AppTypes.StrategyTypes.Screening, screeningOptionsMenuItem, StrategyParaEditHandler);

                strategyCbStrip.Items.Clear();
                strategyCbStrip.LoadData();

                //Tool tip
                this.addChartBtn.ToolTipText = this.NewChartMenuItem.Text;
                this.printChartBtn.ToolTipText = this.printMenuItem.Text;

                this.transHistoryBtn.ToolTipText = this.transHistoryMenuItem.Text;
                this.marketWatchBtn.ToolTipText = this.marketWatchMenuItem.Text;
                this.tradeAlertBtn.ToolTipText = this.tradeAlertMenuItem.Text;
                this.myPortfolioBtn.ToolTipText = this.myPortfolioMenuItem.Text;
                this.chartPropertiesBtn.ToolTipText = this.chartPropertyMenuItem.Text;

                this.lineChartBtn.ToolTipText = this.lineChartMenuItem.Text;
                this.barChartBtn.ToolTipText = this.barChartMenuItem.Text;
                this.candleSticksBtn.ToolTipText = this.candleSticksMenuItem.Text;
                this.chartVolumeBtn.ToolTipText = this.chartVolumeMenuItem.Text;

                this.zoomInBtn.ToolTipText = this.zoomInMenuItem.Text;
                this.zoomOutBtn.ToolTipText = this.zoomOutMenuItem.Text;
                this.chartRefreshBtn.ToolTipText = this.chartPropertyMenuItem.Text;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        //Check user config file
        protected override bool CheckValid()
        {
            if(!base.CheckValid()) return false;

            if (!DataAccess.Libs.OpenConnection())
            {
                ShowConfigForm();
                if (!DataAccess.Libs.OpenConnection())
                {
                    commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Others, null, "Invalid configuration file :" + common.Settings.sysConfigFile);
                    return false;
                }
            }
            //Ensure that user.xml file is valid
            if (!common.xmlLibs.IsValidXML(commonTypes.Settings.sysUserConfigFile))
            {
                commonClass.SysLibs.WriteSysLog(AppTypes.SyslogTypes.Others, null,"Invalid configuration file :" +  commonTypes.Settings.sysUserConfigFile);
                common.xmlLibs.CreateEmptyXML(commonTypes.Settings.sysUserConfigFile);
            }
            return true;
        }

        private void SetCulture(AppTypes.LanguageCodes code)
        {
            Settings.sysLanguage = code;
            common.language.myCulture = AppTypes.Code2Culture(code);
            switch (code)
            {
                case AppTypes.LanguageCodes.VI: 
                    vietnameseMenuItem.Checked = true;
                    englishMenuItem.Checked = false;
                    break;
                default:
                    vietnameseMenuItem.Checked = false;
                    englishMenuItem.Checked = true;
                    break;
            }
            common.language.SetLanguage();
            commonClass.SysLibs.SetLanguage();
            application.Strategy.Data.Clear();
            application.Indicators.Data.Clear();
            SetLanguage();
            SetLanguageAllOpenForms();
        }

        private void SetLanguageAllOpenForms()
        {
            ContextMenuStrip tradeAnalysisContextMenu = CreateContextMenu_TradeAnalysis();
            foreach (Form form in Application.OpenForms)
            {
                System.Reflection.MethodInfo method = form.GetType().GetMethod("SetLanguage");
                try
                {
                    if (method != null)
                        method.Invoke(form, null);
                }
                catch (Exception er)
                {
                    ShowError(er);
                }

                if (form.GetType() == typeof(Tools.Forms.tradeAnalysis))
                {
                    (form as Tools.Forms.tradeAnalysis).myContextMenuStrip = tradeAnalysisContextMenu;
                }
                if (form.GetType() == typeof(Trade.Forms.tradeAlertList))
                {
                    (form as Trade.Forms.tradeAlertList).myContextMenuStrip = CreateContextMenu_TradeAlert();
                }
                if (form.GetType() == typeof(Trade.Forms.marketWatch))
                {
                    (form as Trade.Forms.marketWatch).myContextMenuStrip = CreateContextMenu_MarketWatch();
                }
            }
        }

        /// <summary>
        /// Startup Form - Login
        /// </summary>
        /// <returns></returns>
        protected override bool ShowLogin()
        {
            if (!base.ShowLogin())
            {
                System.Environment.Exit(1);
                return false;
            }
            CloseAllForms();
            return true;
        }

        private common.DictionaryList cachedForms = new common.DictionaryList();  // To cache used forms 

        protected override bool LoadUserConfig()
        {
            if (!base.LoadUserConfig()) return false;
            SetCulture(Settings.sysLanguage);

            // Restore the last settings from user config file.
            marketWatchMenuItem.Checked = application.Configuration.GetDefaultFormState("marketWatch");
            tradeAlertMenuItem.Checked = application.Configuration.GetDefaultFormState("tradeAlert");
            myPortfolioMenuItem.Checked = application.Configuration.GetDefaultFormState("portfolio");
            transHistoryMenuItem.Checked = application.Configuration.GetDefaultFormState("transHistory");

            //common.Data.Clear();
            return true;
        }
        protected override void SaveUserConfig()
        {
            application.Configuration.SetDefaultFormState("marketWatch", marketWatchMenuItem.Checked);
            application.Configuration.SetDefaultFormState("tradeAlert", tradeAlertMenuItem.Checked);
            application.Configuration.SetDefaultFormState("portfolio", myPortfolioMenuItem.Checked);
            application.Configuration.SetDefaultFormState("transHistory", transHistoryMenuItem.Checked);
        }

        private void OpenDefaultForm()
        {
            if (marketWatchMenuItem.Checked) ShowMarketWatchForm();
            else HideMarketWatchForm();

            if (tradeAlertMenuItem.Checked) ShowTradeAlertForm();
            else HideTradeAlertForm();

            if (myPortfolioMenuItem.Checked) ShowPortfolioWatchtForm();
            else HidePortfolioWatchtForm();

            if (transHistoryMenuItem.Checked) ShowTransHistForm();
            else HideTransHistForm();
        }

        private void SetFormAppearance()
        {
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
            this.ChartTimeScale = AppTypes.TimeScaleFromCode(Settings.sysGlobal.DefaultTimeScaleCode);

            //dockPanel
            dockPanel.Parent = this;     
            dockPanel.DockLeftPortion = (double)constPaneLeftWidth/100;
            dockPanel.AllowDrop = true;
            dockPanel.ActiveAutoHideContent = null;

            //Default language from global settings
            SetCulture(Settings.sysGlobal.DefautLanguage);
        }
        private void Reset()
        {
            DataAccess.Libs.Reset();
            SetTimer(true);
        }

        //Map form to checked menu button  : 
        // Check menu -> Open/Close form 
        // Close form -> uncheck menu
        private void MapForm(Form form, ToolStripMenuItem menuBtn)
        {
            form.Tag = menuBtn;
            form.FormClosed += new FormClosedEventHandler(MapFormClosed);
            form.Activated += new EventHandler(MapFormActivated);
        }
        private void MapFormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Form).Tag.GetType() == typeof(ToolStripMenuItem))
            {
                ((sender as Form).Tag as ToolStripMenuItem).Checked = false;
            }
        }
        private void MapFormActivated(object sender, EventArgs e)
        {
            if ((sender as Form).Tag.GetType() == typeof(ToolStripMenuItem))
            {
                ((sender as Form).Tag as ToolStripMenuItem).Checked = true;
            }
        }

        
        /// <summary>
        /// Refresh data : market watch, stock analysis and porfolio  
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
                    (dockPanel.Contents[idx] as Trade.Forms.marketWatch).RefreshData(false);
                    continue;
                }
                //Portfolio watch
                if (dockPanel.Contents[idx].GetType() == typeof(Trade.Forms.transactionList))
                {
                    (dockPanel.Contents[idx] as Trade.Forms.transactionList).Refresh();
                    continue;
                }
            }
        }
        private void RefreshAlert()
        {
            Trade.Forms.tradeAlertList form = GetTradeAlertForm(false);
            if(form!=null && !form.IsDisposed && form.Visible)
                form.Refresh();
        }

        /// <summary>
        /// Close All Forms except System form
        /// </summary>
        /// <param name="excludeSysForm"></param>
        private void CloseAllForms()
        {
            FormCollection formList = Application.OpenForms;
            for(int idx=0;idx<formList.Count;idx++) 
            {
                Type formType = formList[idx].GetType();
                //Do not close main form
                if (formType.Name == this.Name)  continue;
                if (formList[idx].IsDisposed) continue;
                formList[idx].Close();
                idx--;
            }
            for (int idx = 0; idx < cachedForms.Values.Length; idx++)
            {
                Form form = (cachedForms.Values[idx] as Form);
                if (form == null || form.IsDisposed) continue;
                form.Close();
            }
            cachedForms.Clear();
        }

        /// <summary>
        /// Create Peridodicity Strip
        /// </summary>
        /// <param name="toStrip"></param>
        /// <param name="toMenu"></param>
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
                    btn.Checked = ((AppTypes.TimeScale)btn.Tag).Code == value.Code;
                }
                for (int idx = 0; idx < periodicityMenuItem.DropDownItems.Count; idx++)
                {
                    if (periodicityMenuItem.DropDownItems[idx].GetType() != typeof(ToolStripMenuItem)) continue;
                    ToolStripMenuItem item = (ToolStripMenuItem)periodicityMenuItem.DropDownItems[idx];
                    item.Checked =  ((AppTypes.TimeScale)item.Tag).Code == value.Code;
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
                myForm = new Trade.Forms.marketWatch();
                myForm.Name = formName;
                cachedForms.Add(formName, myForm);

                MapForm(myForm, marketWatchMenuItem);
            }
            return myForm;
        }
        private void ShowMarketWatchForm()
        {
            Trade.Forms.marketWatch form = GetMarketWatchForm(true);
            form.myContextMenuStrip = CreateContextMenu_MarketWatch();
            form.myGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(NewChartMenuItem_Click);
            form.RefreshData(true);
            form.Show(dockPanel, DockState.DockLeft);
        }
        private void HideMarketWatchForm()
        {
            Trade.Forms.marketWatch form = GetMarketWatchForm(false);
            if (form!=null) form.Hide();
        }

        private Tools.Forms.MarketSummary GetMarketSummaryForm(bool createIfNotFound)
        {
            string formName = constFormNameMarketSummary + "Market ";
            Tools.Forms.MarketSummary myForm = (Tools.Forms.MarketSummary)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                if (!createIfNotFound) return null;
                myForm = new Tools.Forms.MarketSummary();
                myForm.Name = formName;
                cachedForms.Add(formName, myForm);
            }
            return myForm;
        }
        private void ShowMarketSummaryForm()
        {
            Tools.Forms.MarketSummary form = GetMarketSummaryForm(true);
            //form.myContextMenuStrip = CreateContextMenu_MarketWatch();
            //form.myGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(NewChartMenuItem_Click);
            form.Show(dockPanel, DockState.Document);
        }
        private void HideMarketSummaryForm()
        {
            Tools.Forms.MarketSummary form = GetMarketSummaryForm(false);
            if (form != null) form.Hide();
        }

        private Trade.Forms.tradeAlertList GetTradeAlertForm(bool createIfNotExisted)
        {
            string formName = constFormNameTradeAlert;
            Trade.Forms.tradeAlertList myForm = (Trade.Forms.tradeAlertList)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                if (!createIfNotExisted) return null;
                myForm = new Trade.Forms.tradeAlertList();
                myForm.Name = formName;
                myForm.Init();
                myForm.LoadData();
                cachedForms.Add(formName, myForm);
            }
            return myForm;
        }
        private void ShowTradeAlertForm()
        {
            Trade.Forms.tradeAlertList myForm = GetTradeAlertForm(true);
            myForm.myContextMenuStrip = CreateContextMenu_TradeAlert();
            myForm.Show(dockPanel, DockState.DockBottom);
            MapForm(myForm, tradeAlertMenuItem);
        }
        private void HideTradeAlertForm()
        {
            Trade.Forms.tradeAlertList form = GetTradeAlertForm(false);
            if (form != null) form.Hide();
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
                MapForm(myForm, myPortfolioMenuItem);
            }
            myForm.Show(dockPanel, DockState.DockBottom);
        }
        private void HidePortfolioWatchtForm()
        {
            string formName = constFormNameWatchList + "Portfolio";
            Trade.Forms.portfolioWatch myForm = (Trade.Forms.portfolioWatch)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed) return;
            myForm.Close();
        }

        private void ShowTransHistForm()
        {
            string formName = constFormNameWatchList + "TransactionList";
            Trade.Forms.transactionList myForm = (Trade.Forms.transactionList)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Trade.Forms.transactionList();
                myForm.Name = formName;
                cachedForms.Add(formName, myForm);
                MapForm(myForm, transHistoryMenuItem);
            }
            myForm.Show(dockPanel, DockState.DockBottom);
        }
        private void HideTransHistForm()
        {
            string formName = constFormNameWatchList + "TransactionList";
            Trade.Forms.transactionList myForm = (Trade.Forms.transactionList)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed) return;
            myForm.Close();
        }
                
        private void ShowStockChart(string stockCode)
        {
            string formName = constFormNameStock + stockCode.Trim();
            Tools.Forms.tradeAnalysis myForm = (Tools.Forms.tradeAnalysis)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Tools.Forms.tradeAnalysis();
                myForm.Name = formName;

                myForm.UseStock(DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode) );  //Get data first

                myForm.ChartPriceType = this.ChartType;
                myForm.Activated += new System.EventHandler(this.tradeAnalysisActivatedHandler);
                myForm.myEstimateTradePoints += new Tools.Forms.tradeAnalysis.EstimateTradePointFunc(EstimateTradePointHandler);
                //Cache it if no error occured
                cachedForms.Add(formName, myForm);
            }
            myForm.myContextMenuStrip = CreateContextMenu_TradeAnalysis();
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
                myForm.ChartTimeRange = AppTypes.TimeRanges.None; // timeRange;
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

        private IDockContent[] GetCurrentForms()
        {
            return GetCurrentForms(null);
        }
        private IDockContent[] GetCurrentForms(Type type)
        {
            IDockContent[] fomrs = new IDockContent[0];
            for (int idx = 0; idx < dockPanel.Contents.Count; idx++)
            {
                if (type !=null && dockPanel.Contents[idx].GetType() != type) continue;
                Array.Resize(ref fomrs, fomrs.Length + 1);
                fomrs[fomrs.Length - 1] = dockPanel.Contents[idx];
            }
            return fomrs;
        }

        private void MainMenuItemVisiblity()
        {
            if (dockPanel.ActiveContent == null) return;
            IDockContent curContent  = dockPanel.ActiveContent;
            IDockContent curDocument = (dockPanel.ActiveDocument==null?null:dockPanel.ActiveDocument);

            chartStrip.Enabled = (curContent.GetType() == typeof(Tools.Forms.tradeAnalysis));
            periodicityStrip.Enabled = chartStrip.Enabled;
            chartMenuStrip.Visible = chartStrip.Enabled;

            strategyStrip.Enabled = chartStrip.Enabled ||
                                 (curContent.GetType() == typeof(Tools.Forms.profitEstimate));


            toolsStrip.Enabled = (curContent.GetType() == typeof(Tools.Forms.backTesting)) ||
                                 (curContent.GetType() == typeof(Tools.Forms.screening)) ||
                                 (curContent.GetType() == typeof(Tools.Forms.strategyRanking));
            formatStrip.Enabled = toolsStrip.Enabled;
            
        }

        #region event handler

        private void EstimateTradePointHandler(Tools.Forms.tradeAnalysis sender, string strategyCode, 
                                               EstimateOptions option, databases.tmpDS.tradeEstimateDataTable tbl)
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

            myForm.myDataParam = new DataParams(sender.myData.DataTimeScale.Code,sender.myData.DataTimeRange,0);
            myForm.myStockCode = sender.myData.DataStockCode;
            myForm.myStrategyCode = strategyCode;
            myForm.myOptions = option;
            myForm.SetData(tbl);
            myForm.IsShowChart = true;
            myForm.PlotProfitChart();
            myForm.IsShowAllTransactions = false;
            myForm.Show(dockPanel, DockState.DockBottom);
            myForm.BringToFront();
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
                application.Strategy.Meta meta = (application.Strategy.Meta)(sender as ToolStripMenuItem).Tag;
                application.Strategy.Libs.ShowStrategyForm(meta);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void PlotTradepointHandler(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm == null) return;
                application.Strategy.Meta meta;
                if (sender.GetType() == typeof(ToolStripMenuItem))
                {
                    meta = (application.Strategy.Meta)(sender as ToolStripMenuItem).Tag;
                }
                else
                {
                    baseClass.controls.ToolStripCbStrategy item = (baseClass.controls.ToolStripCbStrategy)sender;
                    meta = application.Strategy.Libs.FindMetaByCode(item.myValue);
                }
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
            try
            {
                CloseAllForms();
            }
            catch (Exception er)
            {
                this.ShowError(er);
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
                //Hiển thị form Back Test
                Tools.Forms.backTesting backTestingForm = Tools.Forms.backTesting.GetForm("");

                //Kiếm các list selected từ trong watchlist
                Trade.Forms.marketWatch marketWatch=GetMarketWatchForm(false);
                //marketWatch
                if (marketWatch != null)
                {
                    common.controls.baseDataGridView mW_Grid = marketWatch.myGrid;
                    DataGridViewSelectedRowCollection rowCollection = mW_Grid.SelectedRows;
                    List<string> list = new List<string>();
                    for (int i = 0; i < rowCollection.Count; i++)
                        list.Add((rowCollection[i].Cells[1]).Value.ToString());

                    backTestingForm.SetSelectedStocks(mW_Grid.SelectedRows);
                }

                backTestingForm.myDockedPane = dockPanel;
                backTestingForm.myShowStock += new Tools.Forms.backTesting.ShowStockFunc(ShowStockHandler);

                backTestingForm.Name = "backTesting";
                backTestingForm.Show(dockPanel);
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
                this.ShowMessage("");
                this.ShowLogin();
                LoadUserConfig();
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
                SaveUserConfig();
                commonClass.SysLibs.ClearLogin();
                if (!this.ShowLogin())
                {
                    common.system.ExitApplication();
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
                marketWatchMenuItem.Checked = !marketWatchMenuItem.Checked;
                if (marketWatchMenuItem.Checked) ShowMarketWatchForm();
                else HideMarketWatchForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void myPortfolioBtn_Click(object sender, EventArgs e)
        {
            try
            {
                myPortfolioMenuItem.Checked = !myPortfolioMenuItem.Checked;
                if (myPortfolioMenuItem.Checked) ShowPortfolioWatchtForm();
                else HidePortfolioWatchtForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void transHistoryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                transHistoryMenuItem.Checked = !transHistoryMenuItem.Checked;
                if (transHistoryMenuItem.Checked) ShowTransHistForm();
                else HideTransHistForm();
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
                tradeAlertMenuItem.Checked = !tradeAlertMenuItem.Checked;
                if (tradeAlertMenuItem.Checked)  ShowTradeAlertForm();
                else HideTradeAlertForm();
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
                    myForm.myOnWatchListChanged += new common.forms.baseMasterEditForm.onDataChanged(UpdateWatchList);
                    myForm.myOnPortfolioChanged += new common.forms.baseMasterEditForm.onDataChanged(UpdateWatchList);  
                }
                myForm.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void UpdateWatchList(object sender, common.forms.baseMasterEditForm.myEventArgs e)
        {
            try
            {
                Trade.Forms.marketWatch form = GetMarketWatchForm(false);
                if (form == null) return;
                form.RefreshData(baseClass.controls.stockCodeSelectByWatchList.RefreshOptions.CodeGroup);
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
       

        private void orderMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.marketWatch marketWatchForm = GetMarketWatchForm(false);
                if (marketWatchForm != null && marketWatchForm.CurrentRow!=null) 
                    Trade.AppLibs.OrderForm(marketWatchForm.CurrentRow.code);
                else
                    Trade.AppLibs.OrderForm(null);
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

        /// <summary>
        /// Strategy ranking Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Change from Amount (in VND) to Percent
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// Amount to Percent Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Percentage Event (for backtesting and strategy ranking forms)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// Vietnamese language event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vietnameseMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetCulture(AppTypes.LanguageCodes.VI);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        
        /// <summary>
        /// Englist language event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void englishMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetCulture(AppTypes.LanguageCodes.EN);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        
        /// <summary>
        /// Zoom In Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Zoom Out Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Configuration Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowConfigForm();
                Reset();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void sysOptionMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baseClass.forms.sysOptionLocal.GetForm("").ShowDialog();
                Reset();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void Alert_OpenChartMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.tradeAlertList myForm = GetTradeAlertForm(false);
                if (myForm == null) return;
                if (myForm.CurrentRow == null) return;
                ShowStockChart(myForm.CurrentRow.stockCode);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void Alert_MakeOrderMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.tradeAlertList myForm = GetTradeAlertForm(false);
                if (myForm == null) return;
                myForm.PlaceOrder();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void marketSummaryMenuItem_Click(object sender, EventArgs e)
        {
            ShowMarketSummaryForm();
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CloseAllForms();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void changePassMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string formName = "changePassword";
                baseClass.forms.changePassword myForm = (baseClass.forms.changePassword)cachedForms.Find(formName);
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new baseClass.forms.changePassword();
                    myForm.Name = formName;
                    cachedForms.Add(formName, myForm);
                }
                if (myForm == null) return;
                myForm.loginAccount = commonClass.SysLibs.sysLoginAccount;
                myForm.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        /// <summary>
        /// Show main windows : MarketWatchForm and MarketSummary Form
        /// </summary>
        private void main_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            DataAccess.PleaseWait waitObj = null;
            using (waitObj = new DataAccess.PleaseWait())
            {
                try
                {
                    OpenDefaultForm();
                    //ShowMarketSummaryForm();
                    SetTimer(true);
                    this.ShowMessage(common.dateTimeLibs.TimeSpan2String(stopWatch.Elapsed));
                    SetTimer(true);
                }
                catch (Exception er)
                {
                    this.ShowError(er);
                }
                finally
                {
                    if (waitObj != null) waitObj.Dispose();
                }
            }
            stopWatch.Stop();
            this.ShowMessage(common.dateTimeLibs.TimeSpan2String(stopWatch.Elapsed));
        }

        private void addToWatchListMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.marketWatch form = GetMarketWatchForm(false);
                if (form == null) return;
                if (form.CurrentRow == null) return;
                StringCollection codes = new StringCollection();
                codes.Add(form.CurrentRow.code);
                baseClass.AppLibs.AddStockToWatchList(codes);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void dockPanel_ActiveContentChanged(object sender, EventArgs e)
        {
            try
            {
                MainMenuItemVisiblity();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler

        private void testMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.marketWatch form = GetMarketWatchForm(false);
                if (form == null) return;
                form.RefreshData(false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
