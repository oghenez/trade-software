using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace admin
{
    public partial class main : common.forms.baseApplication
    //public partial class main : baseClass.forms.baseApplication
    {
        public main()
        {
            try
            {
                InitializeComponent();
                application.test.LoadTestConfig();
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

        private void sysWatchListMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baseClass.forms.sysWatchList myForm = baseClass.forms.sysWatchList.GetForm("sysWatchList");
                myForm.Show();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void sysInterestedStrategyMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baseClass.forms.sysInterestedStrategy myForm = baseClass.forms.sysInterestedStrategy.GetForm("sysInterestedStrategy");
                myForm.Show();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
