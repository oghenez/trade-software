using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace server
{
    public partial class main : common.forms.baseApplication
    //public partial class main : baseClass.forms.baseApplication
    {
        public main()
        {
            try
            {
                common.language.myCulture = new System.Globalization.CultureInfo("vi-VN");
                commonClass.Settings.sysAccessMode = commonClass.AppTypes.DataAccessMode.WebService;
                InitializeComponent();
                //object obj = Strategy.Data.sysXmlDocument;
                //test.LoadTestConfig();
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
        
        private void reUpdatePriceMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                imports.forms.reUpdatePrice form = new imports.forms.reUpdatePrice();
                form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void updateDataMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                scheduleForm form = new scheduleForm();
                form.ShowDialog();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
