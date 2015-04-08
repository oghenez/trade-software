using System;
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
using System.Diagnostics;
using client.forms;

namespace client
{
    //public partial class main : common.forms.baseApplication
    public partial class main : baseClass.forms.baseApplication
    {
        // The sizes (in percentage) of 4 main panel's parts.
        const int constPaneTop = 20; 
        const int constPaneBottom = 27; 
        const int constPaneLeft = 15;   
        const int constPaneRight = 20; 
        
        const string constFormNameIndicator = "indicator-";
        const string constFormNameStock = "stock-";
        const string constFormNameWatchList = "WatchList-";
        const string constFormNamePorfolioWatch = "PorfolioWatch-";
        const string constFormNameTradeAlert = "TradeAlert";
        const string constFormNameMarketSummary = "MarketSummary";
        const string constFormNameEstimateTrade = "EstimateTrade-";
        const string constFormNameFundamentalData = "Fundamental Data -";
        public main()
        {
            try
            {
                //common.language.myCulture = new System.Globalization.CultureInfo("vi-VN");
                InitializeComponent();
                testMenuItem.Visible = false;                
            }
            catch (Exception er)
            {
                //common.system.ShowError(Languages.Libs.GetString("loadDataError"), Languages.Libs.GetString("internetError"));
                common.system.ShowError(Languages.Libs.GetString("loadDataError"),er.Message);
                this.ShowError(er);
            }
        }

        protected override bool CheckValid()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {                
                common.system.ShowMessage(Languages.Libs.GetString("appErrorManyInstances"));
                return false;
            }

            bool retVal = true;
            if (!commonTypes.Settings.sysDebugMode)
            {
                using (new common.PleaseWait(new Point(), new forms.startSplash()))
                {
                    DateTime time1 = DateTime.Now;
                    try
                    {
                        //retVal = base.CheckValid();
                    }
                    catch (Exception er)
                    {
                        retVal = false;
                        common.system.ShowError(Languages.Libs.GetString("systemError"), er.Message);
                    }
                    if (retVal)
                    {
                        InitSystem(false);
                        this.LogAccess = false;
                    }
                    DateTime time2 = DateTime.Now;
                    TimeSpan ts = time2 - time1;
                    //Neu chua du 3 giay = 3000 ms
                    if (3000 - ts.TotalMilliseconds > 0) Thread.Sleep((int)(3000 - ts.TotalMilliseconds));
                }
            }
            return retVal;
        }

        /// <summary>
        /// Set Timer and Form Appearance before loading Main Form
        /// </summary>
        /// <returns></returns>
        protected override bool BeforeLoadForm()
        {
            SetTimer(false);
            SetFormAppearance();
            return true;
        }
        private common.TimerProcess RefreshDataProc = null;
        private common.TimerProcess RefreshAlertProc = null;
        private common.DictionaryList cachedForms = new common.DictionaryList();  // To cache used forms 

        private bool InitSystem(bool force)
        {
            if (force) DataAccess.Libs.ClearCache();
            //Load XML meta for STRATEGY and INDICATOR
            application.Strategy.StrategyData.sysXmlDocument = DataAccess.Libs.GetXmlDocumentSTRATEGY();
            application.Indicators.Data.sysXmlDocument = DataAccess.Libs.GetXmlDocumentINDICATOR();
            DataAccess.Libs.LoadSystemVars();
            return true;
        }

        /// <summary>
        /// Set language for the application
        /// </summary>
        /// <param name="code"></param>
        /// <param name="force"></param>
        private void SetCulture(AppTypes.LanguageCodes code,bool force)
        {
            Settings.sysLanguage = code;
            CultureInfo newCulture = AppTypes.Code2Culture(code);
            if (!force && (newCulture == common.language.myCulture)) return;

            common.language.myCulture = newCulture;
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
            application.Strategy.StrategyData.Clear();
            application.Indicators.Data.Clear();
            SetLanguage();
            SetLanguageAllOpenForms();
        }

        /// <summary>
        /// set language for all open forms
        /// </summary>
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
                    (form as Tools.Forms.tradeAnalysis).myContextMenuStrip.Font = Settings.sysFontMenu;
                }
                if (form.GetType() == typeof(Trade.Forms.tradeAlertList))
                {
                    (form as Trade.Forms.tradeAlertList).myContextMenuStrip = CreateContextMenu_TradeAlert();
                    (form as Trade.Forms.tradeAlertList).myContextMenuStrip.Font = Settings.sysFontMenu; 
                }
                if (form.GetType() == typeof(Trade.Forms.marketWatch))
                {
                    (form as Trade.Forms.marketWatch).myContextMenuStrip = CreateContextMenu_MarketWatch();
                    (form as Trade.Forms.marketWatch).myContextMenuStrip.Font = Settings.sysFontMenu;
                }
            }
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
            
            //Order
            menuItem = contextMenuStrip.Items.Add(orderMenuItem.Text);
            menuItem.Image = client.Properties.Resources.money_icon;
            menuItem.Click += new System.EventHandler(orderMenuItem_Click);

            //Tools
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            if (commonTypes.Consts.constEditionPROFESSIONALL)
            {
                menuItem = contextMenuStrip.Items.Add(backTestingMenuItem.Text);
                menuItem.Image = client.Properties.Resources.Network_icon;
                menuItem.Click += new System.EventHandler(backTestingMenuItem_Click);

                menuItem = contextMenuStrip.Items.Add(strategyRankingMenuItem.Text);
                menuItem.Image = client.Properties.Resources.OnLamp_icon_16;
                menuItem.Click += new System.EventHandler(strategyRankingMenuItem_Click);
            }

            menuItem = contextMenuStrip.Items.Add(screeningMenuItem.Text);
            menuItem.Image = client.Properties.Resources.sort_ascending_icon;
            menuItem.Click += new System.EventHandler(screeningMenuItem_Click);
            
            
            return contextMenuStrip;
        }

        /// <summary>
        /// Create contextual menu for main Chart
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip CreateContextMenu_TradeAnalysis()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;

            //Zoom menu
            menuItem = contextMenuStrip.Items.Add(zoomInMenuItem.Text);
            menuItem.Image = client.Properties.Resources.zoomIn;
            menuItem.Click += new System.EventHandler(zoomInMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(zoomOutMenuItem.Text);
            menuItem.Image = client.Properties.Resources.zoomOut;
            menuItem.Click += new System.EventHandler(zoomOutMenuItem_Click);

            //menu for Strategy
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            System.Windows.Forms.ToolStripMenuItem strategyMenuItem = new ToolStripMenuItem();
            strategyMenuItem.Text = Languages.Libs.GetString("strategy");
            application.Strategy.StrategyLibs.CreateMenu(AppTypes.StrategyTypes.Strategy, strategyMenuItem, PlotTradepointHandler);
            contextMenuStrip.Items.Add(strategyMenuItem);

            //menu for indicator
            System.Windows.Forms.ToolStripMenuItem indicatorMenuItem = new ToolStripMenuItem();
            indicatorMenuItem.Text = Languages.Libs.GetString("indicator");
            
            application.Indicators.Libs.CreateIndicatorMenu(indicatorMenuItem, showIndicatorHandler);
            contextMenuStrip.Items.Add(indicatorMenuItem);

            //menu for Fundamental data
            contextMenuStrip.Items.Add(new ToolStripSeparator());            
            menuItem = contextMenuStrip.Items.Add(companyOverviewMenuItem.Text);
            menuItem.Click += new System.EventHandler(companyOverviewMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(financialDataMenuItem.Text);
            menuItem.Click += new System.EventHandler(financialDataMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(financialRatioToolStripMenuItem.Text);
            menuItem.Click += new System.EventHandler(financialRatioToolStripMenuItem_Click);

            menuItem = contextMenuStrip.Items.Add(companyNToolStripMenuItem.Text);
            menuItem.Click += new System.EventHandler(companyNToolStripMenuItem_Click);

            //Tools
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            if (commonTypes.Consts.constEditionPROFESSIONALL)
            {
                menuItem = contextMenuStrip.Items.Add(backTestingMenuItem.Text);
                menuItem.Image = client.Properties.Resources.Network_icon;
                menuItem.Click += new System.EventHandler(backTestingMenuItem_Click);

                menuItem = contextMenuStrip.Items.Add(strategyRankingMenuItem.Text);
                menuItem.Image = client.Properties.Resources.OnLamp_icon_16;
                menuItem.Click += new System.EventHandler(strategyRankingMenuItem_Click);
            }

            menuItem = contextMenuStrip.Items.Add(screeningMenuItem.Text);
            menuItem.Image = client.Properties.Resources.sort_ascending_icon;
            menuItem.Click += new System.EventHandler(screeningMenuItem_Click);
            return contextMenuStrip;
        }

        /// <summary>
        /// Create contextual menu for Alerts
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip CreateContextMenu_TradeAlert()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(NewChartMenuItem.Text);
            menuItem.Click += new System.EventHandler(Alert_OpenChartMenuItem_Click);

            //Order
            menuItem = contextMenuStrip.Items.Add(orderMenuItem.Text);
            menuItem.Image = client.Properties.Resources.money_icon;
            menuItem.Click += new System.EventHandler(Alert_MakeOrderMenuItem_Click);

            //Tools
            contextMenuStrip.Items.Add(new ToolStripSeparator());
            if (commonTypes.Consts.constEditionPROFESSIONALL)
            {
                menuItem = contextMenuStrip.Items.Add(backTestingMenuItem.Text);
                menuItem.Image = client.Properties.Resources.Network_icon;
                menuItem.Click += new System.EventHandler(backTestingMenuItem_Click);

                menuItem = contextMenuStrip.Items.Add(strategyRankingMenuItem.Text);
                menuItem.Image = client.Properties.Resources.OnLamp_icon_16;
                menuItem.Click += new System.EventHandler(strategyRankingMenuItem_Click);
            }
            
            menuItem = contextMenuStrip.Items.Add(screeningMenuItem.Text);
            menuItem.Image = client.Properties.Resources.sort_ascending_icon;
            menuItem.Click += new System.EventHandler(screeningMenuItem_Click);
            return contextMenuStrip;
        }

        /// <summary>
        /// Contextual menu for portfolio watch
        /// </summary>
        /// <returns></returns>
        private ContextMenuStrip CreateContextMenu_PorfolioWatch()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripItem menuItem;
            menuItem = contextMenuStrip.Items.Add(NewChartMenuItem.Text);
            menuItem.Click += new System.EventHandler(PorfolioWatch_OpenChartMenuItem_Click);

            //Order
            menuItem = contextMenuStrip.Items.Add(orderMenuItem.Text);
            menuItem.Image=client.Properties.Resources.money_icon;
            menuItem.Click += new System.EventHandler(PorfolioWatch_MakeOrderMenuItem_Click);
            return contextMenuStrip;
        }
        #endregion

        protected void ChartLeverage()
        {
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

            ShowMarketSummaryForm();
        }

        /// <summary>
        /// Create ,enu and toolbars item
        /// </summary>
        private void SetFormAppearance()
        {
            standardStrip.BringToFront();
            chartStrip.BringToFront();
            toolsStrip.BringToFront();
            autoCreateStrip.BringToFront();

            //Assign chart type to each button
            lineChartBtn.Tag = AppTypes.ChartTypes.Line;
            barChartBtn.Tag = AppTypes.ChartTypes.Bar;
            candleSticksBtn.Tag = AppTypes.ChartTypes.CandleStick;

            lineChartMenuItem.Tag = AppTypes.ChartTypes.Line;
            barChartMenuItem.Tag = AppTypes.ChartTypes.Bar;
            candleSticksMenuItem.Tag = AppTypes.ChartTypes.CandleStick;

            //Create period button strips : M5,H1,H2,W1,D1,...
            autoCreateStrip.Items.Clear();
            periodicityMenuItem.DropDownItems.Clear();
            CreatePeriodicityStrip(autoCreateStrip, periodicityMenuItem);

            strategyCbStrip.SelectedIndexChanged += new EventHandler(PlotTradepointHandler);

            this.ChartType = AppTypes.ChartTypes.CandleStick;
            this.ChartTimeScale = AppTypes.TimeScaleFromCode(Settings.sysGlobal.DefaultTimeScaleCode);

            //dockPanel
            dockPanel.Parent = this;     
            dockPanel.DockLeftPortion = (double)constPaneLeft/100;
            dockPanel.DockRightPortion = (double)constPaneRight / 100;
            
            dockPanel.DockTopPortion = (double)constPaneTop / 100;
            dockPanel.DockBottomPortion = (double)constPaneBottom / 100;

            dockPanel.AllowDrop = true;
            dockPanel.ActiveAutoHideContent = null;

            //Default language from global settings
            //SetCulture(Settings.sysGlobal.DefautLanguage);
        }

        /// <summary>
        /// Reset timer and data access
        /// </summary>
        private void Reset()
        {
            DataAccess.Libs.Reset();
            SetTimer(true);
        }

        /// <summary>
        /// Map form to checked menu button
        /// Check menu -> Open/Close form 
        /// Close form -> uncheck me
        /// </summary>
        /// <returns></returns>
        private void MapForm(Form form, ToolStripMenuItem menuBtn)
        {
            form.Tag = menuBtn;
            form.FormClosed += new FormClosedEventHandler(MapFormClosed);
            form.Activated += new EventHandler(MapFormActivated);
        }
        
        /// <summary>
        /// Close form -> uncheck me
        /// </summary>
        private void MapFormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Form).Tag.GetType() == typeof(ToolStripMenuItem))
            {
                ((sender as Form).Tag as ToolStripMenuItem).Checked = false;
            }
        }
        
        /// <summary>
        /// Active form -> uncheck me
        /// </summary>
        private void MapFormActivated(object sender, EventArgs e)
        {
            if ((sender as Form).Tag.GetType() == typeof(ToolStripMenuItem))
            {
                ((sender as Form).Tag as ToolStripMenuItem).Checked = true;
            }
        }


        bool fRefreshingData = false;
        
        /// <summary>
        /// Refresh data : market watch, stock analysis and porfolio  
        /// </summary>
        private void RefreshData()
        {
            try
            {
                if (fRefreshingData) return;
                fRefreshingData = true;

                IDockContent[] fomrs = new IDockContent[0];
                for (int idx = 0; idx < dockPanel.Contents.Count; idx++)
                {
                    //Update stock charts
                    if ((dockPanel.Contents[idx].GetType() == typeof(Tools.Forms.tradeAnalysis)) && (dockPanel.Contents[idx].DockHandler.IsActivated))
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
                    if (dockPanel.Contents[idx].GetType() == typeof(Trade.Forms.portfolioWatch))
                    {
                        (dockPanel.Contents[idx] as Trade.Forms.portfolioWatch).RefreshData(false);
                        continue;
                    }
                    ////TransactionList watch
                    //if (dockPanel.Contents[idx].GetType() == typeof(Trade.Forms.transactionList))
                    //{
                    //    (dockPanel.Contents[idx] as Trade.Forms.transactionList).RefreshData(false);
                    //    continue;
                    //}
                }
                //Update trade point on chart
                //PlotTradepointHandler(strategyCbStrip, null);

                fRefreshingData = false;
            }
            catch(Exception er)
            {
                fRefreshingData = false;
                ShowError(er);
            }
        }

        bool fRefreshingAlert = false;
        
        /// <summary>
        /// Refresh alert form
        /// </summary>
        private void RefreshAlert()
        {
            try
            {
                if (fRefreshingAlert) return;
                fRefreshingAlert = true;
                
                Trade.Forms.tradeAlertList form = GetTradeAlertForm(false);
                if (form != null && !form.IsDisposed && form.Visible)
                    form.RefreshData(false);

                fRefreshingAlert = false;
            }
            catch (Exception er)
            {
                fRefreshingAlert = false;
                ShowError(er);
            }
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
                if (AppTypes.myTimeScales[idx].Code == AppTypes.MainDataTimeScale.Code) continue;

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
                for (int idx = 0; idx < autoCreateStrip.Items.Count; idx++)
                {
                    if (autoCreateStrip.Items[idx].GetType() != typeof(ToolStripButton)) continue;
                    ToolStripButton btn = (ToolStripButton)autoCreateStrip.Items[idx];
                    if (btn.Checked) return  (AppTypes.TimeScale)btn.Tag;
                }
                return AppTypes.MainDataTimeScale;
            }
            set
            {
                AppTypes.TimeScale saveTimeScale = this.ChartTimeScale;
                for (int idx = 0; idx < autoCreateStrip.Items.Count; idx++)
                {
                    if (autoCreateStrip.Items[idx].GetType() != typeof(ToolStripButton)) continue;
                    ToolStripButton btn = (ToolStripButton)autoCreateStrip.Items[idx];
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
        /// Update what part in the active form
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
            form.myContextMenuStrip.Font = Settings.sysFontMenu;
            form.myGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(NewChartMenuItem_Click);
            form.RefreshData(true);
            form.Show(dockPanel, DockState.DockLeft);
        }
        private void HideMarketWatchForm()
        {
            Trade.Forms.marketWatch form = GetMarketWatchForm(false);
            if (form!=null) form.Hide();
        }

        private Trade.Forms.MarketSummary GetMarketSummaryForm(bool createIfNotFound)
        {
            string formName = constFormNameMarketSummary + "Market";
            Trade.Forms.MarketSummary myForm = (Trade.Forms.MarketSummary)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                if (!createIfNotFound) return null;
                myForm = new Trade.Forms.MarketSummary();
                myForm.Name = formName;
                cachedForms.Add(formName, myForm);
            }
            return myForm;
        }
        private void ShowMarketSummaryForm()
        {
            Trade.Forms.MarketSummary form = GetMarketSummaryForm(true);
            form.Show(dockPanel, DockState.Document);
            form.RefreshData(true);
        }
        private void HideMarketSummaryForm()
        {
            Trade.Forms.MarketSummary form = GetMarketSummaryForm(false);
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
                myForm.LoadData(true);
                cachedForms.Add(formName, myForm);
            }
            return myForm;
        }
        private void ShowTradeAlertForm()
        {
            Trade.Forms.tradeAlertList myForm = GetTradeAlertForm(true);
            myForm.myContextMenuStrip = CreateContextMenu_TradeAlert();
            myForm.myContextMenuStrip.Font = Settings.sysFontMenu;
            myForm.Show(dockPanel, DockState.DockBottom);
            MapForm(myForm, tradeAlertMenuItem);
        }
        private void HideTradeAlertForm()
        {
            Trade.Forms.tradeAlertList myForm = GetTradeAlertForm(false);
            if (myForm == null || myForm.IsDisposed) return;
            myForm.Close();
        }

        private Trade.Forms.portfolioWatch GetPorfolioWatchForm(bool createIfNotExisted)
        {
            string formName = constFormNamePorfolioWatch;
            Trade.Forms.portfolioWatch myForm = (Trade.Forms.portfolioWatch)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                if (!createIfNotExisted) return null;
                myForm = new Trade.Forms.portfolioWatch();
                myForm.Name = formName;
                myForm.Init();
                cachedForms.Add(formName, myForm);
            }
            return myForm;
        }
        private void ShowPortfolioWatchtForm()
        {
            Trade.Forms.portfolioWatch myForm = GetPorfolioWatchForm(true);
            myForm.myContextMenuStrip = CreateContextMenu_PorfolioWatch();
            myForm.myContextMenuStrip.Font = Settings.sysFontMenu;
            myForm.Show(dockPanel, DockState.DockBottom);
            MapForm(myForm, myPortfolioMenuItem);
        }
        private void HidePortfolioWatchtForm()
        {
            Trade.Forms.portfolioWatch form = GetPorfolioWatchForm(false);
            if (form == null || form.IsDisposed) return;
            form.Close();
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
            myForm.Show(dockPanel, DockState.Document);
        }
        private void HideTransHistForm()
        {
            string formName = constFormNameWatchList + "TransactionList";
            Trade.Forms.transactionList myForm = (Trade.Forms.transactionList)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed) return;
            myForm.Close();
        }

        /// <summary>
        /// Create new name for new stock form
        /// </summary>
        /// <returns>Name of new stock form</returns>
        private string CreateNewStockFormName()
        {
            return constFormNameStock + common.system.UniqueString();
        }
       
        private void ShowStockChart(string stockCode)
        {
            //string formName = constFormNameStock + stockCode.Trim();

            //TUAN- enable open new form with a same stock code
            string formName = CreateNewStockFormName();
            //TUAN- enable open new form with a same stock code

            Tools.Forms.tradeAnalysis myForm = (Tools.Forms.tradeAnalysis)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Tools.Forms.tradeAnalysis();
                myForm.Name = formName;

                myForm.UseStock(DataAccess.Libs.myStockCodeTbl.FindBycode(stockCode) );  //Get data first

                myForm.ChartPriceType = this.ChartType;
                myForm.Activated += new System.EventHandler(this.tradeAnalysisActivatedHandler);
                //Cache it if no error occured
                cachedForms.Add(formName, myForm);
            }
            myForm.myContextMenuStrip = CreateContextMenu_TradeAnalysis();
            myForm.myContextMenuStrip.Font = Settings.sysFontMenu;
            myForm.Show(dockPanel);
            UpdateActiveForm(FormOptions.ChartType); 
        }
        private void ShowStockChart(string stockCode,AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            DateTime frDate = common.Consts.constNullDate, toDate = common.Consts.constNullDate;
            if (!AppTypes.GetDate(timeRange, out frDate, out toDate)) return;

            //string formName = constFormNameStock + stockCode.Trim();

            //TUAN- enable open new form with a same stock code
            string formName = CreateNewStockFormName();
            //TUAN- enable open new form with a same stock code

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
                
                //Cache it if no error occured
                cachedForms.Add(formName, myForm);
            }
            myForm.myContextMenuStrip = CreateContextMenu_TradeAnalysis();
            myForm.myContextMenuStrip.Font = Settings.sysFontMenu;
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
            autoCreateStrip.Enabled = chartStrip.Enabled;
            chartMenuStrip.Visible = chartStrip.Enabled;

            strategyStrip.Enabled = chartStrip.Enabled ||
                                 (curContent.GetType() == typeof(Tools.Forms.profitEstimate));


            toolsStrip.Enabled = (curContent.GetType() == typeof(Tools.Forms.backTesting)) ||
                                 (curContent.GetType() == typeof(Tools.Forms.screening)) ||
                                 (curContent.GetType() == typeof(Tools.Forms.strategyRanking));
            formatStrip.Enabled = toolsStrip.Enabled;

        }

        #region overwtite functions
        protected override bool LoadUserConfig()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            try
            {
                if (!base.LoadUserConfig()) return false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            SetCulture(Settings.sysLanguage,false);

            // Restore the last settings from user config file.
            marketWatchMenuItem.Checked = application.Configuration.GetDefaultFormState("marketWatch",true);
            tradeAlertMenuItem.Checked = application.Configuration.GetDefaultFormState("tradeAlert");
            myPortfolioMenuItem.Checked = application.Configuration.GetDefaultFormState("portfolio");
            transHistoryMenuItem.Checked = application.Configuration.GetDefaultFormState("transHistory");

            OpenDefaultForm();
            SetTimer(true);

            stopWatch.Stop();
            this.ShowMessage(common.dateTimeLibs.TimeSpan2String(stopWatch.Elapsed));

            return true;
        }
        protected override bool SaveUserConfig()
        {
            return application.Configuration.SetDefaultFormState("marketWatch", marketWatchMenuItem.Checked) &&
                   application.Configuration.SetDefaultFormState("tradeAlert", tradeAlertMenuItem.Checked) &&
                   application.Configuration.SetDefaultFormState("portfolio", myPortfolioMenuItem.Checked) &&
                   application.Configuration.SetDefaultFormState("transHistory", transHistoryMenuItem.Checked);
        }

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
            if (RefreshDataProc.IsEndWaitTime())
                RefreshDataProc.Execute();

            if (RefreshAlertProc == null)
            {
                RefreshAlertProc = new common.TimerProcess();
                RefreshAlertProc.WaitInSeconds = Settings.sysGlobal.CheckAlertInSeconds;
                RefreshAlertProc.OnProcess += new common.TimerProcess.OnProcessEvent(RefreshAlert);
            }
            if (RefreshAlertProc.IsEndWaitTime())
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
                this.marketSummaryMenuItem.Text = Languages.Libs.GetString("marketSummary");
                //fundamental
                this.companyOverviewMenuItem.Text = Languages.Libs.GetString("companyOverview");
                this.FundamentalMenuItem.Text = Languages.Libs.GetString("fundamentalData");
                this.financialDataMenuItem.Text = Languages.Libs.GetString("financialStatement");
                this.financialRatioToolStripMenuItem.Text = Languages.Libs.GetString("financialRatio");
                this.analysisReportsToolStripMenuItem.Text = Languages.Libs.GetString("analysistReport");
                this.companyNToolStripMenuItem.Text = Languages.Libs.GetString("companyNews");
                this.companyHottestNewsIn24hToolStripMenuItem.Text = Languages.Libs.GetString("companyHotNews");

                this.toolOptionMenu.Text = Languages.Libs.GetString("toolAllOptions");
                this.strategyOptionsMenuItem.Text = Languages.Libs.GetString("strategyOption");
                this.screeningOptionsMenuItem.Text = Languages.Libs.GetString("screeningOption");

                this.sysOptionMenuItem.Text = Languages.Libs.GetString("sysOptions");

                this.windowsMenuItem.Text = Languages.Libs.GetString("windows");
                this.closeAllMenuItem.Text = Languages.Libs.GetString("closeAll");

                this.feedbackMenuItem.Text = Languages.Libs.GetString("feedback");
                this.helpMenuItem.Text = Languages.Libs.GetString("help");
                this.contentsMenuItem.Text = Languages.Libs.GetString("contents");
                this.indexMenuItem.Text = Languages.Libs.GetString("index");
                this.searchMenuItem.Text = Languages.Libs.GetString("search");
                this.aboutMenuItem.Text = Languages.Libs.GetString("about");

                this.screeningMenuItem.Text = Languages.Libs.GetString("screening");
                this.orderMenuItem.Text = Languages.Libs.GetString("order");
                this.strategyEstimationMenuItem.Text = Languages.Libs.GetString("strategyEstimation");
                this.screeningMenuItem.Text = Languages.Libs.GetString("screening");

                //this.feedbackStripItem.Text = Languages.Libs.GetString("feedback");


                //Create indicator menu
                indicatorMenuItem.DropDownItems.Clear();
                application.Indicators.Libs.CreateIndicatorMenu(indicatorMenuItem, showIndicatorHandler);

                //Strategy menu
                strategyEstimationMenuItem.DropDownItems.Clear();
                application.Strategy.StrategyLibs.CreateMenu(AppTypes.StrategyTypes.Strategy, strategyEstimationMenuItem, PlotTradepointHandler);

                strategyOptionsMenuItem.DropDownItems.Clear();
                application.Strategy.StrategyLibs.CreateMenu(AppTypes.StrategyTypes.Strategy, strategyOptionsMenuItem, StrategyParaEditHandler);

                screeningOptionsMenuItem.DropDownItems.Clear();
                application.Strategy.StrategyLibs.CreateMenu(AppTypes.StrategyTypes.Screening, screeningOptionsMenuItem, StrategyParaEditHandler);

                strategyCbStrip.Items.Clear();
                strategyCbStrip.LoadData();

                //Tool tip
                this.addChartBtn.ToolTipText = this.NewChartMenuItem.Text;
                this.printChartBtn.ToolTipText = this.printMenuItem.Text;
                
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

        #endregion

        #region event handler

        private void ShowTradePointEstimate(Tools.Forms.tradeAnalysis sender, string strategyCode, 
                                            EstimateOptions option, databases.tmpDS.tradeEstimateDataTable tbl)
        {
            string formName = constFormNameEstimateTrade + "-" + sender.myData.DataStockCode;
            Tools.Forms.profitEstimate myForm = (Tools.Forms.profitEstimate)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Tools.Forms.profitEstimate();
                myForm.Name = formName;
                cachedForms.Add(formName, myForm);

                MapForm(myForm, strategyEstimationiMenuItem);
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
                application.Strategy.StrategyMeta meta = (application.Strategy.StrategyMeta)(sender as ToolStripMenuItem).Tag;
                application.Strategy.StrategyLibs.ShowStrategyForm(meta);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        /// <summary>
        /// 23-03-15: Xu ly viec select mot strategy trong combobox va tinh toan diem Buy/Sell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlotTradepointHandler(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm == null) return;
                application.Strategy.StrategyMeta meta;
                if (sender.GetType() == typeof(ToolStripMenuItem))
                {
                    meta = (application.Strategy.StrategyMeta)(sender as ToolStripMenuItem).Tag;
                }
                else
                {
                    baseClass.controls.ToolStripCbStrategy item = (baseClass.controls.ToolStripCbStrategy)sender;
                    meta = application.Strategy.StrategyLibs.FindMetaByCode(item.myValue);
                }
                if (meta == null) activeForm.ClearStrategyTradepoints();
                else activeForm.PlotStrategyTradepoints(meta, this.ChartHaveStrategyEstimation, ShowTradePointEstimate);
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
                standardStrip.Visible = menu.Checked;
                return;
            }
            if (menu == tbChartMenuItem)
            {
                chartStrip.Visible = menu.Checked;
                return;
            }
            if (menu == tbPeriodicityMenuItem)
            {
                autoCreateStrip.Visible = menu.Checked;
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
                Tools.Forms.backTesting backTestingForm = Tools.Forms.backTesting.GetForm("");
                backTestingForm.myDockedPane = dockPanel;
                backTestingForm.myShowStock += new Tools.Forms.backTesting.ShowStockFunc(ShowStockHandler);

                backTestingForm.Name = "backTesting";
                backTestingForm.Show(dockPanel);
                
                Trade.Forms.marketWatch marketWatch = GetMarketWatchForm(false);
                if (marketWatch != null)
                {
                    backTestingForm.SetSelectedCode(marketWatch.mySelectedCodes);
                }
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

                Trade.Forms.marketWatch marketWatch = GetMarketWatchForm(false);
                if (marketWatch != null)
                {
                    myForm.SetSelectedCode(marketWatch.mySelectedCodes);
                }
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
                client.forms.AboutBox about = new client.forms.AboutBox();
                about.ShowDialog();
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
                Tools.Forms.strategyRanking myForm = Tools.Forms.strategyRanking.GetForm("");
                myForm.myShowStock += new Tools.Forms.backTesting.ShowStockFunc(ShowStockHandler);
                myForm.myDockedPane = dockPanel;
                myForm.Show(dockPanel);

                Trade.Forms.marketWatch marketWatch = GetMarketWatchForm(false);
                if (marketWatch != null)
                {
                    myForm.SetSelectedCode(marketWatch.mySelectedCodes);
                }
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
                SetCulture(AppTypes.LanguageCodes.VI,false);
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
                SetCulture(AppTypes.LanguageCodes.EN,false);
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
                if (myForm.CurrentSummaryRow == null) return;
                ShowStockChart(myForm.CurrentSummaryRow.stockCode);
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


        private void PorfolioWatch_OpenChartMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.portfolioWatch myForm = GetPorfolioWatchForm(false);
                if (myForm == null) return;
                if (myForm.myCurrentRow == null) return;
                ShowStockChart(myForm.myCurrentRow.code);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void PorfolioWatch_MakeOrderMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.portfolioWatch myForm = GetPorfolioWatchForm(false);
                if (myForm != null && myForm.myCurrentRow != null)
                    Trade.AppLibs.OrderForm(myForm.myCurrentRow.code);
                else
                    Trade.AppLibs.OrderForm(null);
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
                //Action for Feedback ??

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
        /// </summary>
        private void main_Load(object sender, EventArgs e)
        {
            if (mainMenu != null)
            {
                this.mainMenu.Font = Settings.sysFontMenu;
                if (commonTypes.Consts.constEditionPROFESSIONALL)
                {
                    backTestingMenuItem.Visible = true;
                    strategyRankingMenuItem.Visible = true;
                }
                else
                {
                    backTestingMenuItem.Visible = false;
                    strategyRankingMenuItem.Visible = false;
                }
            }
            dockPanel.Font = Settings.sysFontMain;
        }


        private void addToWatchListMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Trade.Forms.marketWatch form = GetMarketWatchForm(false);
                if (form == null) return;
                baseClass.AppLibs.AddStockToWatchList(form.mySelectedCodes);
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

        static baseClass.forms.feedbackEdit feedbackForm = null;
        private void feedbackMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (feedbackForm == null || feedbackForm.IsDisposed)
                    feedbackForm = new baseClass.forms.feedbackEdit();
                feedbackForm.ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void chartLeverageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ChartLeverage();
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

        private void companyOverviewMenuItem_Click(object sender, EventArgs e)
        {            
            
            string companyCode="SSI";
            try
            {
                //Get company name
                //Get active chart or selected item in Watchlist
                Trade.Forms.marketWatch marketWatchForm = GetMarketWatchForm(false);
                if (marketWatchForm == null) return;
                if (marketWatchForm.CurrentRow == null) return;
                companyCode = marketWatchForm.CurrentRow.code;

                //Open Web Browser
                string URL = "https://www.vndirect.com.vn/portal/tong-quan/"+companyCode+".shtml";
                fundamentalWebBrowserForm form = new fundamentalWebBrowserForm(companyCode,URL);                
                form.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void financialDataMenuItem_Click(object sender, EventArgs e)
        {
            string companyCode = "SSI";
            try
            {
                //Get company name
                //Get active chart or selected item in Watchlist
                Trade.Forms.marketWatch marketWatchForm = GetMarketWatchForm(false);
                if (marketWatchForm == null) return;
                if (marketWatchForm.CurrentRow == null) return;
                companyCode = marketWatchForm.CurrentRow.code;

                //Open Web Browser            
                string URL = "https://www.vndirect.com.vn/portal/bang-can-doi-ke-toan/" + companyCode + ".shtml";
                fundamentalWebBrowserForm form = new fundamentalWebBrowserForm(companyCode, URL);
                form.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void financialRatioToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            string companyCode = "SSI";
            try
            {
                //Get company name
                //Get active chart or selected item in Watchlist
                Trade.Forms.marketWatch marketWatchForm = GetMarketWatchForm(false);
                if (marketWatchForm == null) return;
                if (marketWatchForm.CurrentRow == null) return;
                companyCode = marketWatchForm.CurrentRow.code;

                //Open Web Browser            
                string URL = "https://www.vndirect.com.vn/portal/thong-ke-co-ban/" + companyCode + ".shtml";
                fundamentalWebBrowserForm form = new fundamentalWebBrowserForm(companyCode, URL);
                form.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void analysisReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string companyCode = "SSI";
            try
            {
                //Get company name
                //Get active chart or selected item in Watchlist
                Trade.Forms.marketWatch marketWatchForm = GetMarketWatchForm(false);
                if (marketWatchForm == null) return;
                if (marketWatchForm.CurrentRow == null) return;
                companyCode = marketWatchForm.CurrentRow.code;

                //Open Web Browser    
                //http://stox.vn/Report/Search?Kw=acb&Cat=-1&Industry=-1

                string URL = "http://stox.vn/Report/Search?Kw=" + companyCode + @"&Cat=-1&Industry=-1";
                fundamentalWebBrowserForm form = new fundamentalWebBrowserForm(companyCode, URL);
                form.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void companyNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string companyCode = "SSI";
            try
            {
                //Get company name
                //Get active chart or selected item in Watchlist
                Trade.Forms.marketWatch marketWatchForm = GetMarketWatchForm(false);
                if (marketWatchForm == null) return;
                if (marketWatchForm.CurrentRow == null) return;
                companyCode = marketWatchForm.CurrentRow.code;

                //Open Web Browser    
                //https://www.vndirect.com.vn/portal/tin-doanh-nghiep/

                string URL = "https://www.vndirect.com.vn/portal/tin-doanh-nghiep/" + companyCode + @".shtml";
                fundamentalWebBrowserForm form = new fundamentalWebBrowserForm(companyCode, URL);
                form.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void companyHottestNewsIn24hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string companyCode = "SSI";
            try
            {
                //Get company name
                //Get active chart or selected item in Watchlist
                Trade.Forms.marketWatch marketWatchForm = GetMarketWatchForm(false);
                //Tools.Forms.tradeAnalysis stockchartForm = GetActiveStockForm();
                //if (stockchartForm == null) return;
                if (marketWatchForm == null) return;

                if (marketWatchForm.CurrentRow == null) return;
                companyCode = marketWatchForm.CurrentRow.code;

                //Open Web Browser    
                //https://www.google.com/search?as_q=SSI&as_epq=&as_oq=&as_eq=&as_nlo=&as_nhi=&lr=lang_vi&cr=countryVN&as_qdr=d&as_sitesearch=&as_occt=any&safe=images&as_filetype=&as_rights=&gws_rd=ssl

                string URL = @"https://www.google.com/search?as_q=" + companyCode + @"&as_epq=&as_oq=&as_eq=&as_nlo=&as_nhi=&lr=lang_vi&cr=countryVN&as_qdr=d&as_sitesearch=&as_occt=any&safe=images&as_filetype=&as_rights=&gws_rd=ssl";
                fundamentalWebBrowserForm form = new fundamentalWebBrowserForm(companyCode, URL);
                form.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        /// <summary>
        /// 2015-03-21: Thuc hien xac dinh Buy/Sell dua vao chien luoc tot nhat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bestStrategyToolStripButton_Click(object sender, EventArgs e)
        {
        //    //1. Find the best strategy (in database)
            
        //    //2. Apply the strategy into the stock
        //    DataAccess.Libs.GetBestStrategy();
        //    try
        //    {
        //        Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
        //        if (activeForm == null) return;
        //        application.Strategy.StrategyMeta meta;
        //        ////if (sender.GetType() == typeof(ToolStripMenuItem))
        //        ////{
        //        ////    meta = (application.Strategy.StrategyMeta)(sender as ToolStripMenuItem).Tag;
        //        ////}
        //        ////else
        //        ////{
        //        ////    baseClass.controls.ToolStripCbStrategy item = (baseClass.controls.ToolStripCbStrategy)sender;
        //        ////    meta = application.Strategy.StrategyLibs.FindMetaByCode(item.myValue);
        //        ////}
        //        //if (meta == null) activeForm.ClearStrategyTradepoints();
        //        //else 
        //        activeForm.co
        //        activeForm.PlotStrategyTradepoints(meta, this.ChartHaveStrategyEstimation, ShowTradePointEstimate);
        //    }
        //    catch (Exception er)
        //    {
        //        this.ShowError(er);
        //    }
        }

    }
}
