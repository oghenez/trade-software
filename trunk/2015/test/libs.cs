using System.Collections.Generic;
using System;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace test
{
    static class Libs
    {
        static databases.baseDS.priceDataDataTable priceDataTbl = new databases.baseDS.priceDataDataTable();
        static databases.importDS.importPriceDataTable importPriceTbl = new databases.importDS.importPriceDataTable();
        static Imports.Libs.DailyData myDailyPrice = new Imports.Libs.DailyData();

        public static void Reset()
        {
            myDailyPrice.Reset();
            Imports.Libs.Reset();
        }
        static CultureInfo vnCulture = new CultureInfo("vi-VN");
        public static void GenPriceData(string stockCode)
        {
            DateTime dt = DateTime.Now;
            decimal lastHighPrice = 0, lastLowPrice = 0, lastClosePrice = 0, lastOpenPrice = 0, lastVolume=0;
            databases.baseDS.priceDataSumRow dayPriceRow = myDailyPrice.GetData(stockCode,dt);
            if (dayPriceRow == null)
            {
                databases.baseDS.priceDataRow priceRow = databases.DbAccess.GetLastPriceData(stockCode);
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

            databases.importDS.importPriceRow importRow = importPriceTbl.NewimportPriceRow();
            databases.AppLibs.InitData(importRow);

            decimal highPrice = lastHighPrice + lastHighPrice * (decimal)common.system.Random(-4, 5) / 100;
            decimal lowPrice = lastLowPrice + lastLowPrice * (decimal)common.system.Random(-4, 5) / 100;
            decimal closePrice = lastClosePrice + lastClosePrice * (decimal)common.system.Random(-5, 5) / 100;

            importRow.volume = lastVolume + common.system.Random(0, 100);
            importRow.onDate = dt;
            importRow.stockCode = stockCode;
            importPriceTbl.AddimportPriceRow(importRow);

            Imports.Libs.AddImportPrice(importPriceTbl,priceDataTbl);
            databases.DbAccess.UpdateData(priceDataTbl);
            // In VN culture : start of week is Monday (not Sunday) 
            databases.AppLibs.AggregatePriceData(priceDataTbl, vnCulture, null);

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