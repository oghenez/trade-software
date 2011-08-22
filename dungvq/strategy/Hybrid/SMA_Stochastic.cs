using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class SMA_Stochastic : GenericStrategy
    {
        public SMA_Stochastic(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p): base(d, code, fExport, curStrategy,p) { }
        
        public override analysis.analysisResult Execute()
        {
            int sma_short_period = (int)parameters.getParameter(0);
            int sma_long_period = (int)parameters.getParameter(1);
            int fastK = (int)parameters.getParameter(2);
            int slowK = (int)parameters.getParameter(3);
            int slowD = (int)parameters.getParameter(4);

            double[] sma5 = data.SMA(sma_short_period);
            double[] sma10 = data.SMA(sma_long_period);
            double[] price = data.closePrice;
            double[] stoch1 = null, stoch2 = null;
            data.StochasticSlow(fastK, slowK, slowD, ref stoch1, ref stoch2);

            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;
            analysis.tradeActions stochTrend = analysis.tradeActions.None;

            int lastBuyId = 0;
            for (int idx = 0; idx < sma5.Length; idx++)
            {
                stochTrend = (stoch1[idx] > stoch2[idx] ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy && stochTrend == analysis.tradeActions.Buy)
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
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
