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
        public abstract databases.baseDS.priceDataDataTable GetImportFromWeb(DateTime updateTime,databases.baseDS.exchangeDetailRow row);
        public abstract databases.baseDS.priceDataDataTable GetImportFromCSV(string fileName,string market,OnUpdatePriceData onUpdateDataFunc);
        public virtual bool ImportFromWeb(DateTime updateTime, databases.baseDS.exchangeDetailRow exchangeDetailRow)
        {
            databases.baseDS.priceDataDataTable priceTbl = GetImportFromWeb(updateTime, exchangeDetailRow);
            if (priceTbl == null) return false;

            // Different culture has different start of week, ie in VN culture : start of week is Monday (not Sunday) 
            CultureInfo exchangeCulture = application.AppLibs.GetExchangeCulture(exchangeDetailRow.marketCode);
            databases.AppLibs.AggregatePriceData(priceTbl, exchangeCulture, null);
            return true;
        }
    }

    public class importOHLCV : commonClass.OHLCV
    {
        public string code = "";
        public DateTime dateTime = common.Consts.constNullDate;
    }

    public delegate importOHLCV ImportRowHandler(LumenWorks.Framework.IO.Csv.CsvReader data, importStat myImportStat);
    public delegate void OnUpdatePriceData(databases.baseDS.priceDataRow row, importStat stat);
    public delegate void OnCodeAdded(string code);
    public delegate void OnEndImportPriceData(databases.baseDS.priceDataDataTable tbl);
    public class importStat
    {
        public bool cancel = false;
        public common.dateTimeLibs.DateTimeFormats dateDataFormat = common.dateTimeLibs.DateTimeFormats.Default;
        public CultureInfo dstCulture = null;
        public CultureInfo srcCulture = null;
        public int dataCount = 0, updateCount = 0, errorCount = 0;
        public void Reset()
        {
            cancel = false;
            dataCount = 0;
            updateCount = 0;
            errorCount = 0;
        }
    }


    public class ImportData
    {
        databases.importDS.importPriceDataTable dataTbl = null;
        public ImportData()
        { 
            dataTbl = new databases.importDS.importPriceDataTable();
            dataTbl.DefaultView.Sort = dataTbl.stockCodeColumn.ColumnName;
        }
        public databases.importDS.importPriceRow Find(databases.importDS.importPriceRow row)
        {
            DataRowView[] foundRows = dataTbl.DefaultView.FindRows(new object[] { row.stockCode });
            if (foundRows.Length <= 0) return null;
            return (databases.importDS.importPriceRow)foundRows[0].Row;
        }
        public bool IsSameData(databases.importDS.importPriceRow row1, databases.importDS.importPriceRow row2)
        {
            if (row1==null && row2==null) return false;
            if (row1 == null && row2 != null) return false;
            if (row1 != null && row2 == null) return false;
            return  (row1.closePrice == row2.closePrice) &&(row1.volume == row2.volume);
        }
        public void Update(databases.importDS.importPriceRow row)
        {
            databases.importDS.importPriceRow oldRow = Find(row);
            if (oldRow == null)
            {
                oldRow = dataTbl.NewimportPriceRow();
                databases.AppLibs.InitData(oldRow);
                dataTbl.AddimportPriceRow(oldRow);
            }
            oldRow.onDate = row.onDate;
            oldRow.stockCode = row.stockCode;
            oldRow.closePrice = row.closePrice;
            oldRow.volume = row.volume;
            oldRow.isTotalVolume = row.isTotalVolume;
        }
    }
}
