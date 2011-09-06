using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace baseClass
{
    public class interfaces
    {
        public static CultureInfo myCultureInfo = new CultureInfo(application.Settings.sysCultureCode);

        private static forms.companyFind _myCompanyFind = null;
        public static forms.companyFind myCompanyFind
        {
            get
            {
                if (_myCompanyFind == null || _myCompanyFind.IsDisposed)
                {
                    _myCompanyFind = new forms.companyFind();
                }
                return _myCompanyFind;
            }
        }


        private static baseClass.licenseCheck licenseCheckForm = null;
        public static void ShowLicenseCheck(string productVendor, string productCode, string licenseFile)
        {
            if (licenseCheckForm == null || licenseCheckForm.IsDisposed)
                licenseCheckForm = new licenseCheck();
            licenseCheckForm.myProductCode = productCode;
            licenseCheckForm.myProdVendor = productVendor;
            licenseCheckForm.myLicenceFile = licenseFile;
            licenseCheckForm.LoadLicence();
            licenseCheckForm.ShowDialog();
        }

        private static baseClass.forms.sysOptions myEstimateOptionForm = null;
        public static void ShowEstimateOptionForm()
        {
            if (myEstimateOptionForm == null || myEstimateOptionForm.IsDisposed)
                myEstimateOptionForm = new baseClass.forms.sysOptions();
            myEstimateOptionForm.ShowForm();
        }
    }
}
