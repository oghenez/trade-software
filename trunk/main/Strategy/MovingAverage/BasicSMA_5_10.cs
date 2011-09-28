using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class BasicSMA_5_10 : GenericStrategy
    {
        public BasicSMA_5_10(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        public override analysis.analysisResult Execute()
        {
            double[] sma5 = data.SMA(5);
            double[] sma10 = data.SMA(10);

            analysis.tradeActions trend = analysis.tradeActions.None;
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            for (int idx = 0; idx < sma5.Length; idx++)
            {
                double d1 = sma5[idx];  //SMA 5
                double d2 = sma10[idx]; //SMA 10
                if (d1 == 0 || d2 == 0) continue;

                trend = (d1 > d2 ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && trend == analysis.tradeActions.Buy)
                {
                    adviceInfo.Add(analysis.tradeActions.Buy, idx);
                }
                if (lastTrend == analysis.tradeActions.Buy && trend == analysis.tradeActions.Sell)
                {
                    adviceInfo.Add(analysis.tradeActions.Sell, idx);
                }
                lastTrend = trend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
