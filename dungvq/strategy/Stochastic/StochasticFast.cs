using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class StochasticFast : GenericStrategy
    {
        public StochasticFast(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p): base(d, code, fExport, curStrategy,p) { }

        protected override void ScreeningExecute()
        {
            double[] line1 = null, line2 = null;
            data.StochasticFast((int)parameters.getParameter(0), (int)parameters.getParameter(1), ref line1, ref line2);
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;
            
            //analysis.tradePointInfo info;
            //info.marketTrend =
            //info.price = data.closePrice[line1.Length - 1];

            for (int idx = line1.Length-2; idx < line1.Length; idx++)
            {
                currentTrend = ((line1[idx] > line2[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                    SelectStock(idx,null);                
                lastTrend = currentTrend;
            }
        }

        public override analysis.analysisResult Execute()
        {
            double[] line1 = null, line2 = null;
            data.StochasticFast((int)parameters.getParameter(0), (int)parameters.getParameter(1), ref line1, ref line2);
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;
                        
            for (int idx = 0; idx < line1.Length; idx++)
            {
                currentTrend = ((line1[idx] > line2[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                    BuyAtClose(idx);
                if (lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, line1, line2);
            return adviceInfo;
        }
    }
}
