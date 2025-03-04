using System;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using application;
using commonClass;

namespace baseClass
{
    public class Events
    {
        public delegate void onShowChart(string stockCode);
    }
    public class Libs
    {
        //??public static CultureInfo myCultureInfo = new CultureInfo(commonClass.Settings.sysCultureCode);
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
    }


    public class AppLibs
    {
        public static void AddStockToWatchList(StringCollection stockCodes)
        {
            Forms.addToWatchList_StockOnly myForm = Forms.addToWatchList_StockOnly.GetForm("");
            myForm.ShowForm(stockCodes);
        }
    }
}
