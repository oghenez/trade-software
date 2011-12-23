using System.Collections.Generic;
using System;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace test
{
    static class genData
    {
        static data.baseDS.priceDataDataTable priceDataTbl = new data.baseDS.priceDataDataTable();
        static data.importDS.importPriceDataTable importPriceTbl = new data.importDS.importPriceDataTable();
        static imports.libs.DailyPrice myDailyPrice = new imports.libs.DailyPrice();

        public static void Reset()
        {
            myDailyPrice.Reset();
            imports.libs.Reset();
        }
        static CultureInfo vnCulture = new CultureInfo("vi-VN");
        public static void GenPriceData(string stockCode)
        {
            DateTime dt = DateTime.Now;
            decimal lastHighPrice = 0, lastLowPrice = 0, lastClosePrice = 0, lastOpenPrice = 0, lastVolume=0;
            data.baseDS.priceDataSumRow dayPriceRow = myDailyPrice.GetData(stockCode,dt);
            if (dayPriceRow == null)
            {
                data.baseDS.priceDataRow priceRow = application.DbAccess.GetLastPriceData(stockCode);
                lastHighPrice = priceRow.highPrice;
                lastLowPrice = priceRow.lowPrice;
                lastClosePrice = priceRow.closePrice;
                lastOpenPrice = priceRow.openPrice;
                lastVolume = 0;
            }
            else
            {
                lastHighPrice = dayPriceRow.highPrice;
                lastLowPrice = dayPriceRow.lowPrice;
                lastClosePrice = dayPriceRow.closePrice;
                lastOpenPrice = dayPriceRow.openPrice;
                lastVolume = dayPriceRow.volume;
            }
            priceDataTbl.Clear();
            importPriceTbl.Clear();

            data.importDS.importPriceRow importRow = importPriceTbl.NewimportPriceRow();
            application.DbAccess.InitData(importRow);

            decimal highPrice = lastHighPrice + lastHighPrice * (decimal)common.system.Random(-4, 5) / 100;
            decimal lowPrice = lastLowPrice + lastLowPrice * (decimal)common.system.Random(-4, 5) / 100;
            decimal closePrice = lastClosePrice + lastClosePrice * (decimal)common.system.Random(-5, 5) / 100;

            importRow.openPrice = lastOpenPrice;
            importRow.highPrice = Math.Max(lastHighPrice, highPrice);
            if (lowPrice < importRow.highPrice) importRow.lowPrice = lowPrice;
            else importRow.lowPrice = importRow.highPrice;

            if (closePrice>=importRow.lowPrice && closePrice<=importRow.highPrice)
                importRow.closePrice = closePrice;
            else 
            {
                importRow.closePrice = (importRow.lowPrice+importRow.highPrice)/2;
            }
            importRow.volume = lastVolume + common.system.Random(0, 100);
            importRow.onDate = dt;
            importRow.stockCode = stockCode;
            importPriceTbl.AddimportPriceRow(importRow);

            imports.libs.AddImportPrice(importPriceTbl,priceDataTbl);
            application.DbAccess.UpdateData(priceDataTbl);
            // In VN culture : start of week is Monday (not Sunday) 
            imports.libs.AggregatePriceData(priceDataTbl, vnCulture, null);

            myDailyPrice.UpdateData(importRow);
        }
    }
    
    public class PleaseWait : IDisposable
    {
        private Form mSplash;
        private Point mLocation;

        public PleaseWait(Point location) 
        {
            Init(location, null);
        }
        public PleaseWait(Point location, common.forms.baseSlashForm form)
        {
            Init(location, form);
        }
        public void Init(Point location, common.forms.baseSlashForm form)
        {
            mLocation = location;
            mSplash = (form == null ? new common.forms.baseSlashForm() : form);
            Thread t = new Thread(new ThreadStart(workerThread));
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }


        public void Dispose()
        {
            mSplash.Invoke(new MethodInvoker(stopThread));
        }
        private void stopThread()
        {
            mSplash.Close();
        }
        private void workerThread()
        {
            //mSplash = (mFormType == null ? new common.forms.baseSlashForm() : (Form)Activator.CreateInstance(mFormType));
            //mSplash = new common.forms.baseSlashForm();
            mSplash.StartPosition = FormStartPosition.CenterScreen;
            mSplash.Location = mLocation;
            mSplash.TopMost = true;
            Application.Run(mSplash);
        }
    }

}