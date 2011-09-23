using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class Price_SMA_5_10_Volume_Filter : GenericStrategy
    {
        const int VOLUME_FILTER = 100000;

        public Price_SMA_5_10_Volume_Filter(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        override protected void StrategyExecute()
        {
            DataSeries sma5 = data.SMA(5);
            DataSeries sma10 = data.SMA(10);
            double[] price = data.closePrice;
            double[] volume = data.totalVolume;
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;;

            bool bVolumeCondition = false, is_bought = false;

            int lastBuyId = 0;
            for (int idx = 0; idx < sma5.Length-1; idx++)
            {
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                bVolumeCondition = volume[idx] > VOLUME_FILTER ? true : false;
                if (bVolumeCondition && lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                {
                    adviceInfo.Add(AppTypes.MarketTrend.Upward, idx);
                    lastBuyId = idx;
                    is_bought = true;
                }
                if (is_bought && lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                {
                    adviceInfo.Add(AppTypes.MarketTrend.Downward, idx);
                    is_bought = false;
                }
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
