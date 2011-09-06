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
        
        public main()
        {
            try
            {
                InitializeComponent();
                Init();
                sysLibs.sysLoginCode = "A00000004";
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

            //Assign chart type to each button
            lineChartBtn.Tag = myTypes.ChartTypes.Line;
            barChartBtn.Tag = myTypes.ChartTypes.Bar;
            candleSticksBtn.Tag = myTypes.ChartTypes.CandelStick;

            lineChartMenuItem.Tag = myTypes.ChartTypes.Line;
            barChartMenuItem.Tag = myTypes.ChartTypes.Bar;
            candleSticksMenuItem.Tag = myTypes.ChartTypes.CandelStick;

            //Create period button strips : M5,H1,H2,W1,D1,...
            periodicityStrip.Items.Clear();
            periodicityMenuItem.DropDownItems.Clear();
            PeriodicityStripCreation(periodicityStrip, periodicityMenuItem);

            this.ChartType = myTypes.ChartTypes.Line;
            this.ChartTimeScale = myTypes.MainDataTimeScale;

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
            myTypes.TimeScaleTypes lastTimeScaleType =  myTypes.TimeScaleTypes.Day;
            for (int idx = 0; idx < myTypes.myTimeScales.Length; idx++)
            {
                btn = new ToolStripButton();
                btn.Name = "Periodicity-" + myTypes.myTimeScales[idx].Code;
                btn.Text = myTypes.myTimeScales[idx].Text;
                btn.Tag = myTypes.myTimeScales[idx];
                btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
                btn.Click += new EventHandler(PeriodicityButon_Click);
                if (toStrip.Items.Count > 0)toStrip.Items.Add(new ToolStripSeparator());
                toStrip.Items.Add(btn);

                if (idx == 0) lastTimeScaleType = myTypes.myTimeScales[idx].Type;
                if (lastTimeScaleType != myTypes.myTimeScales[idx].Type)
                {
                    toMenu.DropDownItems.Add(new ToolStripSeparator());
                    lastTimeScaleType = myTypes.myTimeScales[idx].Type;
                }
                menuItem = new ToolStripMenuItem();
                menuItem.Name = "Periodicity-menu-" + myTypes.myTimeScales[idx].Code;
                menuItem.Text = myTypes.myTimeScales[idx].Text;
                menuItem.Tag = myTypes.myTimeScales[idx];
                menuItem.Click += new EventHandler(PeriodicityMenu_Click);
                toMenu.DropDownItems.Add(menuItem);
            }
        }
        private myTypes.TimeScale ChartTimeScale
        {
            get
            {
                for (int idx = 0; idx < periodicityStrip.Items.Count; idx++)
                {
                    if (periodicityStrip.Items[idx].GetType() != typeof(ToolStripButton)) continue;
                    ToolStripButton btn = (ToolStripButton)periodicityStrip.Items[idx];
                    if (btn.Checked) return  (myTypes.TimeScale)btn.Tag;
                }
                return myTypes.MainDataTimeScale;
            }
            set
            {
                myTypes.TimeScale saveTimeScale = this.ChartTimeScale;
                for (int idx = 0; idx < periodicityStrip.Items.Count; idx++)
                {
                    if (periodicityStrip.Items[idx].GetType() != typeof(ToolStripButton)) continue;
                    ToolStripButton btn = (ToolStripButton)periodicityStrip.Items[idx];
                    btn.Checked = ((myTypes.TimeScale)btn.Tag == value);
                }
                for (int idx = 0; idx < periodicityMenuItem.DropDownItems.Count; idx++)
                {
                    if (periodicityMenuItem.DropDownItems[idx].GetType() != typeof(ToolStripMenuItem)) continue;
                    ToolStripMenuItem item = (ToolStripMenuItem)periodicityMenuItem.DropDownItems[idx];
                    item.Checked =  ((myTypes.TimeScale)item.Tag == value);
                }
                if (saveTimeScale != this.ChartTimeScale)
                {
                    tools.forms.tradeAnalysis activeForm = FindActiveStockForm();
                    if (activeForm != null)
                    {
                        activeForm.ChartTimeScale = value;
                        activeForm.ReloadChart();
                    }
                }
            }
        }
        private myTypes.ChartTypes ChartType
        {
            get
            {
                if(barChartBtn.Checked) return myTypes.ChartTypes.Bar; 
                if(candleSticksBtn.Checked) return myTypes.ChartTypes.CandelStick; 
                return myTypes.ChartTypes.Line; 
            }
            set
            {
                switch (value)
                {
                    case myTypes.ChartTypes.Bar:
                        lineChartBtn.Checked = false;
                        barChartBtn.Checked = true;
                        candleSticksBtn.Checked = false;

                        lineChartMenuItem.Checked = false;
                        barChartMenuItem.Checked = true;
                        candleSticksMenuItem.Checked = false;
                        break;
                    case myTypes.ChartTypes.CandelStick:
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
                tools.forms.tradeAnalysis activeForm = FindActiveStockForm();
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
                tools.forms.tradeAnalysis activeForm = FindActiveStockForm();
                if (activeForm != null) activeForm.ChartVolumeVisibility = value;
            }
        }
        private bool ChartHaveGrid
        {
            get { return chartGridMenuItem.Checked; }
            set 
            { 
                chartGridMenuItem.Checked = value;
                tools.forms.tradeAnalysis activeForm = FindActiveStockForm();
                if (activeForm != null) activeForm.ChartHaveGrid = value;
            }
        }

        //Form that allow user to set date range of used data.
        private baseClass.forms.chartDataOptions _chartDataOptionForm = null;
        private baseClass.forms.chartDataOptions ChartDataOptionForm
        {
            get
            {
                if (_chartDataOptionForm == null)
                {
                    _chartDataOptionForm = new baseClass.forms.chartDataOptions();
                    _chartDataOptionForm.InitData();
                    _chartDataOptionForm.GetDate();
                }
                return _chartDataOptionForm;
            }
        }


        private stockTrade.forms.marketWatchList GetMarketWatchForm(bool createIfNotFound)
        {
            string formName = constFormNameWatchList + "Market";
            stockTrade.forms.marketWatchList myForm = (stockTrade.forms.marketWatchList)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                if (!createIfNotFound) return null;
                myForm = new stockTrade.forms.marketWatchList();
                myForm.Name = formName;
                myForm.myOnShowChart += new baseClass.forms.baseWatchList.onShowChart(ShowStockChart);
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
            stockTrade.forms.portfolioWatch myForm = (stockTrade.forms.portfolioWatch)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new stockTrade.forms.portfolioWatch();
                myForm.Name = formName;
                myForm.myOnShowChart += new baseClass.forms.baseWatchList.onShowChart(ShowStockChart);
                cachedForms.Add(formName, myForm);
            }
            myForm.Show(dockPanel, DockState.DockBottom);
        }
        private void ShowTradeAlertForm()
        {
            string formName = constFormNameTradeAlert;
            stockTrade.forms.tradeAlertList myForm = (stockTrade.forms.tradeAlertList)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new stockTrade.forms.tradeAlertList();
                myForm.Name = formName;
                myForm.Init();
                myForm.LoadData();
                //myForm.myOnShowChart += new baseClass.forms.basePortfolioView.onShowChart(ShowStockChart);
                cachedForms.Add(formName, myForm);
            }
            myForm.Show(dockPanel, DockState.DockBottom);
        }
        private void ShowStockChart(data.baseDS.stockCodeRow stockRow)
        {
            string formName = constFormNameStock + stockRow.code.Trim();
            tools.forms.tradeAnalysis myForm = (tools.forms.tradeAnalysis)cachedForms.Find(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new tools.forms.tradeAnalysis();
                myForm.Name = formName;
                //Ensure that data date range is set.
                ChartDataOptionForm.GetDate();
                myForm.ChartStartDate = ChartDataOptionForm.frDate;
                myForm.ChartEndDate = ChartDataOptionForm.toDate;
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
            tools.forms.tradeAnalysis tradeAnalysisForm;
            object[] foundForms = cachedForms.FindAll(constFormNameStock);
            for (int idx = 0; idx < foundForms.Length; idx++)
            {
                tradeAnalysisForm = (tools.forms.tradeAnalysis)foundForms[idx];
                if (tradeAnalysisForm.IsDisposed) continue;
                tradeAnalysisForm.ChartStartDate = ChartDataOptionForm.frDate;
                tradeAnalysisForm.ChartEndDate = ChartDataOptionForm.toDate;
                tradeAnalysisForm.ReloadChart();
            }
        }
        /// <summary>
        /// Refresh/Re-draw charts for all active trade analaysis forms.
        /// </summary>
        private void RefreshChart()
        {
            tools.forms.tradeAnalysis tradeAnalysisForm;
            object[] foundForms = cachedForms.FindAll(constFormNameStock);
            for (int idx = 0; idx < foundForms.Length; idx++)
            {
                tradeAnalysisForm = (tools.forms.tradeAnalysis)foundForms[idx];
                if (tradeAnalysisForm.IsDisposed) continue;
                tradeAnalysisForm.RefreshChart();
            }
        }

        /// <summary>
        /// Find active form. 
        /// </summary>
        /// <returns>Null if there is no active form.</returns>
        private tools.forms.tradeAnalysis FindActiveStockForm()
        {
            tools.forms.tradeAnalysis tradeAnalysisForm;
            object[] foundForms = cachedForms.FindAll(constFormNameStock);
            for (int idx = 0; idx < foundForms.Length; idx++)
            {
                tradeAnalysisForm = (tools.forms.tradeAnalysis)foundForms[idx];
                if (tradeAnalysisForm.IsDisposed) continue;
                if (tradeAnalysisForm.IsActivated) return tradeAnalysisForm;
            }
            return null;
        }

        #region event handler

        private void tradeAnalysisActivatedHandler(object sender, EventArgs e)
        {
            try
            {
                tools.forms.tradeAnalysis activeForm = (tools.forms.tradeAnalysis)sender;
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
                tools.forms.tradeAnalysis activeForm = FindActiveStockForm();
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
            this.ChartType = (myTypes.ChartTypes)((ToolStripButton)sender).Tag;
        }
        private void ChartTypeMenu_Click(object sender, EventArgs e)
        {
            this.ChartType = (myTypes.ChartTypes)((ToolStripMenuItem)sender).Tag;
        }

        private void PeriodicityButon_Click(object sender, EventArgs e)
        {
            this.ChartTimeScale = ((myTypes.TimeScale)((ToolStripButton)sender).Tag);
        }
        private void PeriodicityMenu_Click(object sender, EventArgs e)
        {
            this.ChartTimeScale = ((myTypes.TimeScale)((ToolStripMenuItem)sender).Tag);
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
            tools.forms.tradeAnalysis activeForm = FindActiveStockForm();
            if (activeForm != null)
            {
                activeForm.RefreshChart();
            }
        }

        private void NewChartMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                stockTrade.forms.marketWatchList form = GetMarketWatchForm(false);
                if (form == null) return;
                if (form.CurrentRow == null) return;
                ShowStockChart(form.CurrentRow);
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
                tools.forms.tradeAnalysis activeForm = FindActiveStockForm();
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



        private void backTestingMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("backTesting");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new stock.forms.backTesting();
                    myForm.MdiParent = this;
                    myForm.Name = "backTesting";
                }
                this.ShowForm(myForm, false);
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
        private void chartDataOptionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ChartDataOptionForm.ShowDialog();
                if (ChartDataOptionForm.myFormStatus.isCloseClick) return;
                if (!ChartDataOptionForm.GetDate()) return;
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
                baseClass.forms.chartProperties myForm = (baseClass.forms.chartProperties)this.FindForm("chartProperties");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new baseClass.forms.chartProperties();
                    myForm.Name = "chartProperties";
                    myForm.myOnProcess += new common.forms.baseDialogForm.onProcess(chartPropertyHandler);
                }
                myForm.Show(dockPanel, DockState.DockRightAutoHide);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void preferencesMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baseClass.forms.sysOptions myForm = (baseClass.forms.sysOptions)this.FindForm("sysOptions");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new baseClass.forms.sysOptions();
                    myForm.Name = "sysOptions";
                }
                myForm.Show(dockPanel);
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
                Form myForm = this.FindForm("transactionNew");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new stockTrade.forms.transactionNew();
                    myForm.MdiParent = this;
                    myForm.Name = "transactionNew";
                }
                ((stockTrade.forms.transactionNew)myForm).ShowForm();
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

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form  myForm = this.FindForm("sysOptions");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new baseClass.forms.sysOptions();
                    myForm.MdiParent = this;
                    myForm.Name = "sysOptions";
                    myForm.MdiParent = this;
                }
                this.ShowForm(myForm, false);
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

        private void transactionsBtn_Click(object sender, EventArgs e)
        {

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
        #endregion event handler
    }
}
