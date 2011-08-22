using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class BasicMACD : GenericStrategy
    {
        public BasicMACD(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }

        //Screening following basic MACD rule
        protected override void ScreeningExecute()
        {
            double[] macd = null, ema = null, hist = null;
            data.MACD((int)parameters.getParameter(0), (int)parameters.getParameter(1),
                (int)parameters.getParameter(2), ref macd, ref ema, ref hist);
            if (macd.Length < 2) return;

            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;
           
            for (int idx = macd.Length-2; idx < macd.Length; idx++)
            {
                currentTrend = ((macd[idx] > 0 && macd[idx] > ema[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                    BuyAtClose(idx);                
                lastTrend = currentTrend;
            }
        }

        public override analysis.analysisResult Execute()
        {
            double[] macd = null, ema = null, hist = null;
            data.MACD((int)parameters.getParameter(0), (int)parameters.getParameter(1),
                (int)parameters.getParameter(2), ref macd, ref ema, ref hist);
            
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;
            
            for (int idx = 0; idx < macd.Length; idx++)
            {
                currentTrend = ((macd[idx] > 0 && macd[idx] > ema[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                    BuyAtClose(idx);
                if (lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, macd, ema, hist);
            return adviceInfo;
        }
    }
}
