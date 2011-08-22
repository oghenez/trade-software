//Copyright by NHQ, HCM city, 2011 
using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class RSI_MACD_Histogram : GenericStrategy
    {
        public RSI_MACD_Histogram(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p): base(d, code, fExport, curStrategy,p) { }
        public override analysis.analysisResult Execute()
        {
            int rsi_period=(int)parameters.getParameter(0);
            int fast_macd=(int)parameters.getParameter(1);
            int slow_macd = (int)parameters.getParameter(2);
            int signal_macd= (int)parameters.getParameter(3);
            int RSI_LOWER_LEVEL = (int)parameters.getParameter(4);
            int RSI_UPPER_LEVEL = (int)parameters.getParameter(5);

            double[] macd = null, ema = null, hist = null;
            bool is_bought = false;
            decimal delta = 0, lastDelta = 0;
            double[] line1 = data.RSI(rsi_period);
            data.MACD(fast_macd, slow_macd, signal_macd, ref macd, ref ema, ref hist);

            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            for (int idx = 1; idx < line1.Length; idx++)
            {
                delta = (decimal)(hist[idx] - hist[idx - 1]);
                if (line1[idx] < RSI_LOWER_LEVEL && delta > 0 && lastDelta < 0)
                {
                    adviceInfo.Add(analysis.tradeActions.Buy, idx);
                    is_bought = true;
                }
                if (is_bought)
                    if ((delta < 0 && lastDelta > 0) || line1[idx] > RSI_UPPER_LEVEL)
                    {
                        is_bought = false;
                        adviceInfo.Add(analysis.tradeActions.Sell, idx);
                    }
                lastDelta = delta;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, line1);
            return adviceInfo;
        }
    }
}
