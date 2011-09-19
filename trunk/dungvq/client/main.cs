using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using application; 

namespace client
{
    public partial class main : common.forms.baseApplication
    //public partial class main : baseClass.forms.baseApplication
    {
        private enum Language {Vi,En };
        private Language language
        {
            get
            {
                if (vietnameseMenuItem.Checked) return Language.Vi;
                return Language.En;
            }
            set
            {
                switch (value)
                { 
                    case Language.En:
                         vietnameseMenuItem.Checked = false;
                         englishMenuItem.Checked = true;
                         break;
                    default: 
                         vietnameseMenuItem.Checked = true;
                         englishMenuItem.Checked = false;
                         break;
                }
            }
        }

        const int constPaneLeftWidth = 200;
        const string constFormNameIndicator = "indicator-";
        const string constFormNameStock = "stock-";
        const string constFormNameWatchList = "WatchList-";
        const string constFormNameTradeAlert = "TradeAlert";
        const string constFormNameEstimateTrade = "EstimateTrade-";
        
        public main()
        {
            try
            {
                InitializeComponent();
                test.LoadTestConfig();
                Init();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
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

        private void Init()
        {
            //Create indicator menu
            indicatorMenuItem.DropDownItems.Clear();
            Indicators.Libs.CreateIndicatorMenu(indicatorMenuItem, showIndicatorHandler);

            //Strategy menu
            strategyListMenuItem.DropDownItems.Clear();
            Strategy.Libs.CreateMenu(AppTypes.StrategyTypes.Strategy,strategyListMenuItem, StrategyParaEditHandler);
            
            //Tool strip
            standartStrip.Location = new Point(0, 0);
            chartStrip.Location = new Point(standartStrip.Location.X + standartStrip.Width, 0);
            toolsStrip.Location = new Point(chartStrip.Location.X + chartStrip.Width, 0);
            periodicityStrip.Location = new Point(toolsStrip.Location.X + toolsStrip.Width, 0);

            //Combobox that allow user to set date range of used data.
            dataTimeRangeCb.LoadData();

            standartStrip.BringToFront();
            chartStrip.BringToFront();
            toolsStrip.BringToFront();
            periodicityStrip.BringToFront();

            //Assign chart type to each button
            lineChartBtn.Tag = AppTypes.ChartTypes.Line;
            barChartBtn.Tag = AppTypes.ChartTypes.Bar;
            candleSticksBtn.Tag = AppTypes.ChartTypes.CandelStick;

            lineChartMenuItem.Tag = AppTypes.ChartTypes.Line;
            barChartMenuItem.Tag = AppTypes.ChartTypes.Bar;
            candleSticksMenuItem.Tag = AppTypes.ChartTypes.CandelStick;

            //Create period button strips : M5,H1,H2,W1,D1,...
            periodicityStrip.Items.Clear();
            periodicityMenuItem.DropDownItems.Clear();
            PeriodicityStripCreation(periodicityStrip, periodicityMenuItem);

            this.ChartType = AppTypes.ChartTypes.Line;
            this.ChartTimeScale = AppTypes.MainDataTimeScale;

            //dockPanel
            dockPanel.Parent = this;     
            dockPanel.DockLeftPortion = 0.12;
            dockPanel.AllowDrop = true;
            dockPanel.ActiveAutoHideContent = null;
        }
        private void PeriodicityStripCreation(ToolStrip toStrip,ToolStripMenuItem toMenu)
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
                if (saveTimeScale != this.ChartTimeScale)
                {
                    Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                    if (activeForm != null)
                    {
                        activeForm.ChartTimeScale = value;
                        activeForm.ReloadChart();
                    }
                }
            }
        }
        private AppTypes.ChartTypes ChartType
        {
            get
            {
                if(barChartBtn.Checked) return AppTypes.ChartTypes.Bar; 
                if(candleSticksBtn.Checked) return AppTypes.ChartTypes.CandelStick; 
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
                    case AppTypes.ChartTypes.CandelStick:
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
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm != null) activeForm.ChartPriceType = value;
            }
        }
        private bool ChartVolumeVisibility
        {
            get
            {
                return chartVolumeBtn.Checked;
            }
            set
            {
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm != null) activeForm.ChartVolumeVisibility = value;
            }
        }
        private bool ChartHaveGrid
        {
            get { return chartGridMenuItem.Checked; }
            set 
            { 
                chartGridMenuItem.Checked = value;
                Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
                if (activeForm != null) activeForm.ChartHaveGrid = value;
            }
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

            if (activeType == typeof(Tools.Forms.stockRanking))
            {
                ((Tools.Forms.stockRanking)activeObj).ExportResult();
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
                myForm.myOnShowChart += new baseClass.Events.onShowChart(ShowStockChart);
                cachedForms.Add(formName, myForm);
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
            data.baseDS.stockCodeRow stockRow = dataLibs.GetStockData(stockCode);
            if (stockRow == null) return;
            ShowStockChart(stockRow);
        }

        private void ShowStockChart(data.baseDS.stockCodeRow stockRow)
        {
            string formName = constFormNameStock + stockRow.code.Trim();
            Tools.Forms.tradeAnalysis myForm = (Tools.Forms.tradeAnalysis)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Tools.Forms.tradeAnalysis();
                myForm.Name = formName;
                myForm.ChartTimeRange = dataTimeRangeCb.myValue;
                myForm.ChartPriceType = this.ChartType;
                myForm.UseStock(stockRow);

                myForm.Activated += new System.EventHandler(this.tradeAnalysisActivatedHandler);

                //Cache it if no error occured
                cachedForms.Add(formName, myForm);
            }
            myForm.Show(dockPanel);
        }
        private void ShowStockChart(data.baseDS.stockCodeRow stockRow,AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            DateTime frDate = common.Consts.constNullDate, toDate = common.Consts.constNullDate;
            if (!AppTypes.GetDate(timeRange, out frDate, out toDate)) return;

            string formName = constFormNameStock + stockRow.code.Trim();
            Tools.Forms.tradeAnalysis myForm = (Tools.Forms.tradeAnalysis)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new Tools.Forms.tradeAnalysis();
                myForm.Name = formName;
                myForm.ChartTimeRange = timeRange;
                myForm.ChartTimeScale = timeScale;
                myForm.ChartPriceType = this.ChartType;
                myForm.UseStock(stockRow);
                myForm.Activated += new System.EventHandler(this.tradeAnalysisActivatedHandler);
                //Cache it if no error occured
                cachedForms.Add(formName, myForm);
            }
            myForm.Show(dockPanel);
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
        private void RefreshChart()
        {
            Tools.Forms.tradeAnalysis tradeAnalysisForm;
            object[] foundForms = cachedForms.FindAll(constFormNameStock);
            for (int idx = 0; idx < foundForms.Length; idx++)
            {
                tradeAnalysisForm = (Tools.Forms.tradeAnalysis)foundForms[idx];
                if (tradeAnalysisForm.IsDisposed) continue;
                tradeAnalysisForm.RefreshChart();
            }
        }

        /// <summary>
        /// Get active form. 
        /// </summary>
        /// <returns>Null if there is no active form.</returns>
        private Tools.Forms.tradeAnalysis GetActiveStockForm()
        {
            object activeObj = dockPanel.ActiveContent;
            if (activeObj == null) return null;
            Type activeType = activeObj.GetType();
            if (activeType == typeof(Tools.Forms.tradeAnalysis))
            {
                return (Tools.Forms.tradeAnalysis)activeObj;
            }
            return null;
        }

        #region event handler

        private void tradeAnalysisActivatedHandler(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.tradeAnalysis activeForm = (Tools.Forms.tradeAnalysis)sender;
                this.ChartType = activeForm.ChartPriceType;
                this.ChartTimeScale = activeForm.ChartTimeScale;
                this.ChartVolumeVisibility = activeForm.ChartVolumeVisibility;
                this.ChartHaveGrid = activeForm.ChartHaveGrid;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void chartPropertyHandler(object sender, common.baseDialogEvent e)
        {
            if (e != null && e.isCloseClick) return;
            RefreshChart();
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
        private void ShowStockHandler(data.baseDS.stockCodeRow stockCodeRow,AppTypes.TimeRanges timeRange, AppTypes.TimeScale timeScale)
        {
            try
            {
                ShowStockChart(stockCodeRow, timeRange, timeScale);
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
        }
        private void ChartTypeMenu_Click(object sender, EventArgs e)
        {
            this.ChartType = (AppTypes.ChartTypes)((ToolStripMenuItem)sender).Tag;
        }

        private void PeriodicityButon_Click(object sender, EventArgs e)
        {
            this.ChartTimeScale = ((AppTypes.TimeScale)((ToolStripButton)sender).Tag);
        }
        private void PeriodicityMenu_Click(object sender, EventArgs e)
        {
            this.ChartTimeScale = ((AppTypes.TimeScale)((ToolStripMenuItem)sender).Tag);
        }

        private void ChartVolume_Click(object sender, EventArgs e)
        {
            this.ChartVolumeVisibility = true;
        }
        private void ChartGridMenuItem_Click(object sender, EventArgs e)
        {
            this.ChartHaveGrid = !this.ChartHaveGrid;
        }

        private void ChartRefreshBtn_Click(object sender, EventArgs e)
        {
            Tools.Forms.tradeAnalysis activeForm = GetActiveStockForm();
            if (activeForm != null)
            {
                activeForm.RefreshChart();
            }
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
        private Tools.Forms.stockRanking GetActiveStockRankingForm()
        {
            object activeObj = dockPanel.ActiveContent;
            if (activeObj == null) return null;
            Type activeType = activeObj.GetType();
            if (activeType == typeof(Tools.Forms.stockRanking))
            {
                return ((Tools.Forms.stockRanking)activeObj);
            }
            return null;
        }
        private Tools.Forms.screening GetActiveScreeningForm()
        {
            Tools.Forms.screening myForm = Tools.Forms.screening.GetForm();
            if (myForm == null || myForm.IsDisposed || !myForm.IsActivated) return null;
            return myForm;
        }
        
        private void backTestingOnShowEstimateTrade(application.Data data, string strategyCode, Strategy.TradePoints advices)
        {
            try
            {
                string formName = constFormNameStock + data.DataStockCode + " - " + strategyCode;
                Tools.Forms.profitEstimate myForm = (Tools.Forms.profitEstimate)cachedForms.Find(formName);
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new Tools.Forms.profitEstimate();
                    myForm.Text = "$(" + data.DataStockCode.Trim() + "," + strategyCode.Trim() + ")";
                }
                cachedForms.Add(formName, myForm);
                myForm.Init(data, advices);
                myForm.Show(dockPanel);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
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
                sysLibs.ClearLogin();
                if (!this.ShowLogin())
                {
                    sysLibs.ExitApplication();
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
                sysLibs.ExitApplication();
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

        private void strategyRankingMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                common.system.ShowMessage("Sorry, the function was not implemented!");
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

                Tools.Forms.stockRanking stockRankingForm = GetActiveStockRankingForm();
                if (stockRankingForm != null)
                {
                    stockRankingForm.Execute();
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

                Tools.Forms.stockRanking stockRankingForm = GetActiveStockRankingForm();
                if (stockRankingForm != null)
                {
                    stockRankingForm.IsFullScreen = !stockRankingForm.IsFullScreen;
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

        private void stockRankingMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tools.Forms.stockRanking form = Tools.Forms.stockRanking.GetForm("");
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

            if (activeType == typeof(Tools.Forms.stockRanking))
            {
                ((Tools.Forms.stockRanking)activeObj).myValueType = value;
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
        #endregion event handler
    }
}
