using System.Collections.Generic;
using System;
using System.Text;

namespace test
{
    static class genData
    {
        static decimal open = 17, low = 16, high = 18, close = 17, volume = 1000;
        static data.baseDS.priceDataDataTable priceDataTbl = new data.baseDS.priceDataDataTable();
        static data.importDS.importPriceDataTable importPriceTbl = new data.importDS.importPriceDataTable();
        public static void GenPriceData(string stockCode)
        {
            priceDataTbl.Clear();
            importPriceTbl.Clear();
            data.importDS.importPriceRow importRow = importPriceTbl.NewimportPriceRow();
            application.dataLibs.InitData(importRow);

            //open += common.system.Random(0, 10) / 10;
            high += (decimal)common.system.Random(50, 300) / 100;
            decimal rand = common.system.Random(0, 10);
            if (rand <8)
            {
                close += (decimal)common.system.Random(20, 200) / 100;
            }
            else
            {
                decimal var = (decimal)common.system.Random(50, 200) / 100;
                if (low > var && close > var)
                {
                    close -= var;
                    low -= var;
                }
            }
            volume += common.system.Random(10000, 10000);

            importRow.onDate = DateTime.Now;
            importRow.stockCode = stockCode;
            importRow.openPrice = open;
            importRow.lowPrice = low;
            importRow.highPrice = high;
            importRow.closePrice = close;
            importRow.volume = volume;

            importPriceTbl.AddimportPriceRow(importRow);

            imports.libs.AddImportPrice(importPriceTbl, priceDataTbl);
            application.dataLibs.UpdateData(priceDataTbl);

            // In VN culture : start of week is Monday (not Sunday) 
            imports.libs.AggregatePriceData(priceDataTbl, "vi-VN", false, null);
        }
    }
}