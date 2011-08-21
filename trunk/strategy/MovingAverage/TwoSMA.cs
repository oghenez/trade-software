using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class TwoSMA : GenericStrategy
    {
        public TwoSMA(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }
        public override analysis.analysisResult Execute()
        {
            double[] sma5 = data.SMA((int)parameters.getParameter(0));
            double[] sma10 = data.SMA((int)parameters.getParameter(1));

            analysis.tradeActions trend = analysis.tradeActions.None;
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            
            for (int idx = 0; idx < sma5.Length; idx++)
            {
                double d1 = sma5[idx];  //SMA 5
                double d2 = sma10[idx]; //SMA 10
                if (d1 == 0 || d2 == 0) continue;

                trend = (d1 > d2 ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && trend == analysis.tradeActions.Buy)
                    BuyAtClose(idx);

                if (lastTrend == analysis.tradeActions.Buy && trend == analysis.tradeActions.Sell)
                    SellAtClose(idx);
                lastTrend = trend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
