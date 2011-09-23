//Copyright by NHQ, HCM city, 2011 
using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class MACD_Stochastic_Bottom : GenericStrategy
    {
        public MACD_Stochastic_Bottom(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p) : base(d, code, fExport, curStrategy, p) { }
        public override analysis.analysisResult Execute()
        {
            double[] line1 = null, line2 = null;
            data.StochasticSlow(15, 5, 3, ref line1, ref line2);
            double[] sma20 = data.SMA(20);

            double[] macd = null, ema = null, hist = null;
            data.MACD(12, 26, 9, ref macd, ref ema, ref hist);
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            decimal delta = 0, lastDelta = 0;
            bool is_bought = false;
            bool macd_swicth_to_up_trend = false, macd_swicth_to_down_trend = false, sto_switch_to_up_trend = false, sto_switch_to_down_trend = false;

            analysis.tradeActions stochasticTrend = analysis.tradeActions.None;

            for (int idx = 1; idx < macd.Length; idx++)
            {
                delta = (decimal)(hist[idx] - hist[idx - 1]);
                macd_swicth_to_up_trend = (delta > 0 && lastDelta < 0 ? true : false);
                macd_swicth_to_down_trend = (delta < 0 && lastDelta > 0 ? true : false);
                stochasticTrend = (line1[idx] > line2[idx] ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                sto_switch_to_up_trend = (line1[idx] > line2[idx]) && (line1[idx - 1] < line2[idx - 1]) ? true : false;
                sto_switch_to_down_trend = (line1[idx] < line2[idx]) && (line1[idx - 1] > line2[idx - 1]) ? true : false;


                if (!is_bought && data.closePrice[idx] > sma20[idx])
                    if ((macd_swicth_to_up_trend || sto_switch_to_up_trend) && (line1[idx] < 70))
                    {
                        is_bought = true;
                        adviceInfo.Add(analysis.tradeActions.Buy, idx);
                    }

                if (is_bought)
                    if (sto_switch_to_down_trend || macd_swicth_to_down_trend)
                    {
                        adviceInfo.Add(analysis.tradeActions.Sell, idx);
                        is_bought = false;
                    }
                lastDelta = delta;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, line1, line2);
            return adviceInfo;
        }
    }
}
