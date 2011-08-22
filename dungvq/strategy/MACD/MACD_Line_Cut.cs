using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class MACD_Line_Cut : GenericStrategy
    {
        public MACD_Line_Cut(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        public override analysis.analysisResult Execute()
        {
            double[] macd = null, ema = null, hist = null;
            data.MACD(12, 26, 9, ref macd, ref ema, ref hist);
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;

            int lastBuyId = 0;
            for (int idx = 0; idx < macd.Length; idx++)
            {
                currentTrend = ((macd[idx] > ema[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
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
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, macd, ema, hist);
            return adviceInfo;
        }
    }
}
