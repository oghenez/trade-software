using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using commonTypes;
using commonClass;

namespace Imports
{
    public abstract class generalImport
    {
        //Keep the last import price to excluse non-changed data
        public ImportData lastImportData = new ImportData();
        public abstract databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow row);
        public abstract databases.baseDS.priceDataDataTable GetImportFromCSV(string fileName, string market, OnUpdatePriceData onUpdateDataFunc);
        public virtual bool ImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            try
            {
                databases.baseDS.priceDataDataTable priceTbl = GetImportFromWeb(updateTime, exchangeDetailRow);
                if (priceTbl == null) return false;

                // Different culture has different start of week, ie in VN culture : start of week is Monday (not Sunday) 
                CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(exchangeDetailRow.marketCode);
                databases.AppLibs.AggregatePriceData(priceTbl, exchangeCulture, null);
                return true;
            }
            catch (Exception er)
            {
                //retVal = false;
                commonClass.SysLibs.WriteSysLog(common.SysSeverityLevel.Error, "SRV004", er);
                return false;
            }
        }
    }
}
