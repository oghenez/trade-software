using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using commonTypes;

namespace admin
{
    //public partial class main : common.forms.baseApplication
    public partial class main : baseClass.forms.baseApplication
    {
        public main()
        {
            try
            {
                common.language.myCulture = new System.Globalization.CultureInfo("vi-VN");
                InitializeComponent();
                LogAccess = false;
                //test.LoadTestConfig();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        protected override bool CheckValid()
        {
            return true;
        }
        protected override bool ShowLogin()
        {
            if (!base.ShowLogin())
            {
                System.Environment.Exit(1);
                return false;
            }
            if (commonClass.SysLibs.sysLoginType != AppTypes.UserTypes.System)
            {
                common.system.ShowErrorMessage("Không thể đăng nhập bằng tài khoản này !");
                return false;
            }
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

        private void loginMenu_Click(object sender, EventArgs e)
        {
            this.ShowLogin();
        }

        private void configMenuItem_Click(object sender, EventArgs e)
        {
            Form myForm = this.FindForm("sysOptions");
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new baseClass.forms.sysOptionGlobal();
                myForm.Name = "sysOptions";
            }
            this.ShowForm(myForm);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void configureMenuItem_Click(object sender, EventArgs e)
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

        private void resetServiceMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(Languages.Libs.GetString("askToRestartService"), common.Settings.sysApplicationName,
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) 
                    DataAccess.Libs.ResetService(); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void dataDiagnoseMenu_Click(object sender, EventArgs e)
        {
            try
            {
                forms.dataTools form = new forms.dataTools();
                form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void syslogViewerMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("syslogViewer");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new baseClass.forms.syslogViewer();
                    myForm.Name = "syslogViewer";
                }
                this.ShowForm(myForm);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void feesbackViewerMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("feedbackViewer");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new baseClass.forms.feedbackViewer();
                    myForm.Name = "feedbackViewer";
                }
                this.ShowForm(myForm);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void dataEditMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                forms.editTools form = new forms.editTools();
                form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
