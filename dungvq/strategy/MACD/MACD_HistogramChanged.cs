using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class MACD_HistogramChanged : GenericStrategy
    {
        public MACD_HistogramChanged(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }

        protected override void ScreeningExecute()
        {
            double[] macd = null, ema = null, hist = null;
            int fastperiod = (int)parameters.getParameter(0);
            int slowperiod = (int)parameters.getParameter(1);
            int signalperiod = (int)parameters.getParameter(2);

            data.MACD(fastperiod, slowperiod, signalperiod, ref macd, ref ema, ref hist);
            decimal delta = 0, lastDelta = 0;
            int idx = macd.Length - 1;
            if (idx < 2) return;
            lastDelta = (decimal)(hist[idx-1] - hist[idx - 2]);;
            delta = (decimal)(hist[idx] - hist[idx - 1]);
            if (delta > 0 && lastDelta < 0)
               BuyAtClose(idx);
            
            //analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, macd, ema, hist);
            
        }

        public override analysis.analysisResult Execute()
        {
            double[] macd = null, ema = null, hist = null;
            int fastperiod=(int)parameters.getParameter(0);
            int slowperiod = (int)parameters.getParameter(1);
            int signalperiod = (int)parameters.getParameter(2);

            data.MACD(fastperiod, slowperiod, signalperiod, ref macd, ref ema, ref hist);            
            decimal delta = 0, lastDelta = 0;
            for (int idx = 1; idx < macd.Length; idx++)
            {
                delta = (decimal)(hist[idx] - hist[idx - 1]);
                if (delta > 0 && lastDelta < 0)
                    BuyAtClose(idx);
                if (delta < 0 && lastDelta > 0)
                    SellAtClose(idx);
                lastDelta = delta;
            }
            //analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, macd, ema, hist);
            return adviceInfo;
        }
    }

    public class MACD_HistogramChanged_CutLoss : GenericStrategy
    {
        const int CUTLOSS_LEVEL = -5;// cut loss at -5%
        public MACD_HistogramChanged_CutLoss(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        public override analysis.analysisResult Execute()
        {
            double[] macd = null, ema = null, hist = null;
            data.MACD(12, 26, 9, ref macd, ref ema, ref hist);
            bool cutloss = false, is_bought = false;

            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            decimal delta = 0, lastDelta = 0, price = 0, bought_price = 0, distanceStopLoss = 0;

            for (int idx = 1; idx < macd.Length; idx++)
            {
                delta = (decimal)(hist[idx] - hist[idx - 1]);
                price = (decimal)data.closePrice[idx];
                if (delta > 0 && lastDelta < 0)
                {
                    adviceInfo.Add(analysis.tradeActions.Buy, idx);
                    is_bought = true;
                    bought_price = (decimal)data.closePrice[idx];
                }

                if (is_bought)
                {
                    if (bought_price > 0) distanceStopLoss = (decimal)(price - bought_price) / bought_price * 100;
                    else distanceStopLoss = 0;

                    if (distanceStopLoss <= CUTLOSS_LEVEL)
                        cutloss = true;

                    if ((delta < 0 && lastDelta > 0) || (cutloss))
                    {
                        adviceInfo.Add(analysis.tradeActions.Sell, idx);
                        cutloss = false;
                        is_bought = false;
                    }
                }
                lastDelta = delta;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, macd, ema, hist);
            return adviceInfo;
        }
    }
}
