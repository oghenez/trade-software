using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class StochasticSlow : GenericStrategy
    {
        public StochasticSlow(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p): base(d, code, fExport, curStrategy,p) { }
        public override analysis.analysisResult Execute()
        {
            double[] line1 = null, line2 = null;
            data.StochasticSlow((int)parameters.getParameter(0), (int)parameters.getParameter(1), 
                (int)parameters.getParameter(2), ref line1, ref line2);
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;

            int lastBuyId = 0;
            for (int idx = 0; idx < line1.Length; idx++)
            {
                currentTrend = ((line1[idx] > line2[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                {
                    adviceInfo.Add(analysis.tradeActions.Buy, idx);
                    lastBuyId = idx;
                }
                if (lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                {
                    adviceInfo.Add(analysis.tradeActions.Sell, idx);
                }
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, line1, line2);
            return adviceInfo;
        }
    }
}
