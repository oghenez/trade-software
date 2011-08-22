//Copyright by NHQ, HCM city, 2011 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace strategy
{
    public class BuyAndHoldStrategy : GenericStrategy
    {
        public BuyAndHoldStrategy() : base() { }

        public BuyAndHoldStrategy(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        
        public override analysis.analysisResult Execute()
        {
            double[] closePrice = data.closePrice;            
            if (closePrice.Length > 0)
            {
                BuyAtClose(0);
                SellAtClose(closePrice.Length - 1);
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, closePrice);
            return adviceInfo;
        }
    }
}
