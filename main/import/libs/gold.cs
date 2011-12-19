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
using HtmlAgilityPack;
using System.Linq;
using commonClass;

namespace imports
{
    public class gold
    {
        public static bool ImportOHLCV_CSV(string csvFileName, string stockExchangeForNewCode,
                                            data.baseDS.priceDataDataTable priceDataTbl,
                                            libs.OnUpdatePriceData onUpdateDataFunc)
        {

            return libs.ImportOHLCV_CSV(csvFileName, ',',common.dateTimeLibs.DateTimeFormats.YYMMDDhhmmss,
                                        stockExchangeForNewCode, "en-US",
                                        priceDataTbl, DoImportRow, onUpdateDataFunc, null);

        }
        static DateTime tmpDate = common.Consts.constNullDate;
        static double tmpVal = 0;
        private static libs.importOHLCV DoImportRow(LumenWorks.Framework.IO.Csv.CsvReader csv, libs.importStat importStat)
        {
            libs.importOHLCV data = new libs.importOHLCV();
            if (csv[0] == null) return null;
            data.code = csv[0];

            if (!common.dateTimeLibs.Str2Date(csv[1] + csv[2], importStat.dateFormat, out tmpDate)) return null;
            data.dateTime = tmpDate;

            if (!double.TryParse(csv[3], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Open = tmpVal;

            if (!double.TryParse(csv[4], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.High = tmpVal;

            if (!double.TryParse(csv[5], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Low = tmpVal;

            if (!double.TryParse(csv[6], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Close = tmpVal;

            if (!double.TryParse(csv[7], NumberStyles.Number, importStat.culture, out tmpVal)) return null;
            data.Volume = tmpVal;
            return data;
        }
        

    }
   
}
