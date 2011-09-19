using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class Price_SMA_5_10_Volume_Filter : GenericStrategy
    {
        const int VOLUME_FILTER = 100000;

        public Price_SMA_5_10_Volume_Filter(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        public override analysis.analysisResult Execute()
        {
            double[] sma5 = data.SMA(5);
            double[] sma10 = data.SMA(10);
            double[] price = data.closePrice;
            double[] volume = data.totalVolume;
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;

            bool bVolumeCondition = false, is_bought = false;

            int lastBuyId = 0;
            for (int idx = 0; idx < sma5.Length-1; idx++)
            {
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                bVolumeCondition = volume[idx] > VOLUME_FILTER ? true : false;
                if (bVolumeCondition && lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                {
                    adviceInfo.Add(analysis.tradeActions.Buy, idx);
                    lastBuyId = idx;
                    is_bought = true;
                }
                if (is_bought && lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                {
                    adviceInfo.Add(analysis.tradeActions.Sell, idx);
                    is_bought = false;
                }
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
