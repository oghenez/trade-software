using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class BasicSMA : GenericStrategy
    {
        public BasicSMA(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p): base(d, code, fExport, curStrategy,p) { }
        public override analysis.analysisResult Execute()
        {
            double[] sma5 = data.SMA((int)parameters.getParameter(0));
            double[] sma10 = data.SMA((int)parameters.getParameter(1));

            double[] price = data.closePrice;
            
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;

            //int lastBuyId = 0;
            for (int idx = 0; idx < sma5.Length; idx++)
            {
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                {
                    BuyAtClose(idx);
                   
                }
                if (lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                {
                    SellAtClose(idx);
                }
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
