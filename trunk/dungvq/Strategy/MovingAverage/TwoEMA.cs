using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class TwoEMA : GenericStrategy
    {
        public TwoEMA(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }
        
        protected override void StrategyExecute()
        {
            double[] line1 = data.EMA((int)parameters.getParameter(0));
            double[] line2 = data.EMA((int)parameters.getParameter(1));

            analysis.tradeActions trend = analysis.tradeActions.None;
            analysis.tradeActions lastTrend = analysis.tradeActions.None;            
            for (int idx = 0; idx < line1.Length; idx++)
            {
                double d1 = line1[idx];
                double d2 = line2[idx];
                if (d1 == 0 || d2 == 0) continue;

                trend = (d1 > d2 ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && trend == analysis.tradeActions.Buy)
                    BuyAtClose(idx);
                if (lastTrend == analysis.tradeActions.Buy && trend == analysis.tradeActions.Sell)
                    SellAtClose(idx);
                lastTrend = trend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, line1, line2);           
        }
    }
}
