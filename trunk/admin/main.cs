using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace admin
{
    //public partial class main : common.forms.baseApplication
    public partial class main : baseClass.forms.baseApplication
    {
        //private int timerIntervalInSecs = 10;       //Tick event occurs each 10 second
        //private int tradeAlertIntervalInSecs = 10;  //Time interval to check new trade alerts
        //private int tradeAlertElapseInSecs = 0;     //Time elapsed since the last trade alert event

        public main()
        {
            try
            {
                InitializeComponent();
                //this.myStatusImageVisibled = false;
                //this.myStatusImage = Properties.Resources.mail;
                //myMainTimer.Interval = this.timerIntervalInSecs*1000;  
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        protected override bool LoadAppConfig()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            return base.LoadAppConfig();
        }
        protected override bool CheckValid()
        {
            return true;
        }

        private void ShowStockChart(data.baseDS.stockCodeExtRow row)
        {
            string formName = "baseTradeAnalysis" + row.code.Trim();
            stock.forms.tradeAnalysis myForm = (stock.forms.tradeAnalysis)common.formList.FindForm(formName);
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new stock.forms.tradeAnalysis();
                myForm.Name = formName;
                common.formList.AddForm(myForm);
            }
            myForm.ShowForm(row);
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.QuitApplication();
        }
        private void sysCodeCatMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("sysCodeCatEdit");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.sysCodeCatEdit();
                myForm.Name = "sysCodeCatEdit";
            }
            this.ShowForm(myForm, false);
        }
        private void sysCodeEditMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("sysCodeEdit");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.sysCodeEdit();
                myForm.Name = "sysCodeEdit";
            }
            this.ShowForm(myForm, false);
        }
        private void companyMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("companyList");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.companyList();
                myForm.Name = "companyList";
            }
            this.ShowForm(myForm, false);
        }
        private void licenseMenuItem_Click(object sender, EventArgs e)
        {
            //baseClass.interfaces.ShowLicenseCheck(application.sysLibs.sysProductOwner, application.sysLibs.sysProductCode, this.LicenseFileName());
        }

        private void investorMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("investorList");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.investorList();
                myForm.Name = "investorList";
            }
            this.ShowForm(myForm, false);
        }

        private void indicatorMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("indicatorEdit");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.indicatorEdit();
                myForm.Name = "indicatorEdit";
            }
            this.ShowForm(myForm, false);
        }

        private void stockExchangeMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("stockExchangeEdit");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.stockExchangeEdit();
                myForm.Name = "stockExchangeEdit";
            }
            this.ShowForm(myForm, false);
          
        }

        private void strategyMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("strategyEdit");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.strategyEdit();
                myForm.Name = "strategyEdit";
            }
            this.ShowForm(myForm, false);
        }

        private void importPriceDataMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("importPriceData");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new imports.forms.importPriceData();
                myForm.Name = "importPriceData";
            }
            this.ShowForm(myForm, false);
        }

        private void analyisMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("stockList");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new stock.forms.watchList();
                myForm.Name = "stockList";
                myForm.Location = new Point(0, SystemInformation.CaptionHeight +  myMainMenu.Height);
                myForm.Height = this.ClientRectangle.Height - myForm.Location.Y-5; 
                ((stock.forms.watchList)myForm).myOnStockSeleted += new baseClass.forms.baseStockList.OnStockSeleted(ShowStockChart);  
            }
            this.ShowForm(myForm, false);
        }

        private void loginMenu_Click(object sender, EventArgs e)
        {
            this.ShowLogin();
        }

        private void configMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("configure");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.configure();
                myForm.Name = "configure";
            }
            this.ShowForm(myForm, false);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backTestingMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("backTesting");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new stock.forms.backTesting();
                myForm.Name = "backTesting";
            }
            this.ShowForm(myForm, false);
        }

        private void importIcbMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("importIcbCode");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new imports.forms.importIcbCode();
                myForm.Name = "importIcbCode";
            }
            this.ShowForm(myForm, false);
        }

        private void importCompanyMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("importCompany");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new imports.forms.importCompany();
                myForm.Name = "importCompany";
            }
            this.ShowForm(myForm, false);
        }

        private void importComSectorMenu_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("importComSector");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new imports.forms.importComSector();
                myForm.Name = "importComSector";
            }
            this.ShowForm(myForm, false);
        }

        private void updatePriceMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("updatePrice");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new imports.forms.updatePrice();
                myForm.Name = "updatePrice";
            }
            this.ShowForm(myForm, false);
        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //stockTrade.libs.CreateTradeAlert(null, null, null);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void myMainTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //Show Trade alerts ??
                //if (this.tradeAlertStripItem.isTurnOn)
                //{
                //    this.tradeAlertElapseInSecs += this.timerIntervalInSecs;
                //    if (this.tradeAlertElapseInSecs >= this.tradeAlertIntervalInSecs)
                //    {
                //        myTradeAlertForm.LoadData();
                //        if (myTradeAlertForm.myReccount > 0)
                //        {
                //            ShowTradeAlertBaloon("Trade alert", "New trade alerts available." + common.Consts.constCRLF + "Please click on the message icon to open.");
                //            this.myStatusImageVisibled = true;
                //        }
                //        else this.myStatusImageVisibled = false;
                //        this.tradeAlertElapseInSecs = 0;
                //    }
                //}
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void newOrderMenu_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("TradeOrderAddNew");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new stockTrade.forms.baseTradeOrderAddNew();
                    myForm.Name = "TradeOrderAddNew";
                }
                ((stockTrade.forms.baseTradeOrderAddNew)myForm).ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void tradeAlertMenu_Click(object sender, EventArgs e)
        {
            try
            {
                stockTrade.forms.baseTradeAlertList myForm = (stockTrade.forms.baseTradeAlertList)this.FindForm("TradeAlertList");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new stockTrade.forms.baseTradeAlertList();
                    myForm.MdiParent = this;
                    myForm.Name = "TradeAlertList";
                    myForm.InitForm();
                    myForm.SetColumnVisible(stockTrade.forms.baseTradeAlertList.gridColumnName.Status.ToString(), false);
                    myForm.Size = new Size(500,615);
                    myForm.ToolBarShowState = true;
                    myForm.LoadData();
                    myForm.StartPosition = FormStartPosition.CenterScreen;
                }
                this.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

      

        private void portfolioManaMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("portfolioView");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new stockTrade.forms.basePortfolioManagement();
                    myForm.Name = "portfolioView";
                    ((stockTrade.forms.basePortfolioManagement)myForm).myOnShowChart += new stockTrade.forms.basePortfolioManagement.onShowChart(ShowStockChart);
                }
                this.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void screeningMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("stockScreening");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.baseScreening();
                myForm.Name = "stockScreening";
            }
            this.ShowForm(myForm, false);
        }
    }
}
