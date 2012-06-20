using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using commonTypes;
using commonClass;

namespace admin 
{
    public class AnalysisData : commonClass.BaseAnalysisData 
    {
        public override void LoadData()
        {
            priceDataTbl.Clear();
            DataAccess.Libs.LoadAnalysisData(this);
        }
        public void Diagnose(string exchangeCode,commonTypes.AppTypes.PriceDataType dataType, double allowVariantPerc, ref databases.tmpDS.priceDiagnoseDataTable priceDiagnoseTbl)
        { 
            databases.tmpDS.stockCodeDataTable codeTbl = new databases.tmpDS.stockCodeDataTable();
            databases.DbAccess.LoadStockCode_ByStockExchange(codeTbl, exchangeCode, AppTypes.CommonStatus.Enable);
            for (int idx = 0; idx < codeTbl.Count; idx++)
            { 
                //Diagnose(dataType,allowVariantPerc, ref databases.tmpDS.priceDiagnoseDataTable priceDiagnoseTbl)
            }
            
        }

        public void Diagnose(commonTypes.AppTypes.PriceDataType dataType, double allowVariantPerc, ref databases.tmpDS.priceDiagnoseDataTable priceDiagnoseTbl)
        {
            string dataFld = "";
            switch (dataType)
            {
                case AppTypes.PriceDataType.High:
                     dataFld = priceDataTbl.highPriceColumn.ColumnName;
                     break;
                case AppTypes.PriceDataType.Low:
                     dataFld = priceDataTbl.lowPriceColumn.ColumnName;
                     break;
                case AppTypes.PriceDataType.Open:
                     dataFld = priceDataTbl.openPriceColumn.ColumnName;
                     break;
                case AppTypes.PriceDataType.Volume:
                     dataFld = priceDataTbl.volumeColumn.ColumnName;
                     break;
                default:
                     dataFld = priceDataTbl.closePriceColumn.ColumnName; 
                     break;
            }
            databases.tmpDS.priceDiagnoseRow priceDiagnoseRow;
            double d1, d2; 
            for (int idx = 1; idx < priceDataTbl.Count; idx++)
            {
                if (priceDataTbl[idx].RowState == System.Data.DataRowState.Deleted) continue;
                d1 = (double)priceDataTbl[idx-1][dataFld];
                d2 = (double)priceDataTbl[idx][dataFld];
                if (d1 == 0) continue;
                if (Math.Abs((d2 - d1)/d1) < allowVariantPerc) continue;
                priceDiagnoseRow = priceDiagnoseTbl.NewpriceDiagnoseRow();
                priceDiagnoseRow.code = this.DataStockCode;
                priceDiagnoseRow.date1 = priceDataTbl[idx-1].onDate;
                priceDiagnoseRow.date2 = priceDataTbl[idx].onDate;
                
                priceDiagnoseRow.price1 = d1;
                priceDiagnoseRow.price2 = d2;
                priceDiagnoseRow.variance = (d2 - d1) / d1;
                priceDiagnoseTbl.AddpriceDiagnoseRow(priceDiagnoseRow);
            }
        }
    }
}
