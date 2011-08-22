//Copyright by NHQ, HCM city, 2011 
using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class MACD_Stochastic : GenericStrategy
    {
        public MACD_Stochastic(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p) : base(d, code, fExport, curStrategy, p) { }
        public override analysis.analysisResult Execute()
        {
            double[] line1 = null, line2 = null;
            double[] sma20 = data.SMA((int)parameters.getParameter(0));
            double[] macd = null, ema = null, hist = null;
            data.MACD((int)parameters.getParameter(1), (int)parameters.getParameter(2),
                (int)parameters.getParameter(3), ref macd, ref ema, ref hist);
            data.StochasticSlow((int)parameters.getParameter(4), (int)parameters.getParameter(5),
                (int)parameters.getParameter(6), ref line1, ref line2);            
            
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            decimal delta = 0, lastDelta = 0;
            bool is_bought = false, upTrend=false;

            analysis.tradeActions stochasticTrend = analysis.tradeActions.None;

            for (int idx = 1; idx < macd.Length; idx++)
            {
                delta = (decimal)(hist[idx] - hist[idx - 1]);
                stochasticTrend = ((line1[idx] > line2[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                upTrend=(data.closePrice[idx]> sma20[idx]?true:false);
                if (upTrend && delta > 0 && lastDelta < 0 && stochasticTrend == analysis.tradeActions.Buy)
                {
                    is_bought = true;
                    adviceInfo.Add(analysis.tradeActions.Buy, idx);
                }
                //if (delta < 0 && lastDelta > 0)
                if (is_bought && stochasticTrend == analysis.tradeActions.Sell)
                {
                    adviceInfo.Add(analysis.tradeActions.Sell, idx);
                    is_bought = false;
                }
                lastDelta = delta;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data,line1,line2 );
            return adviceInfo;
        }
    }
}
