using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class Price_SMA_20_50 : GenericStrategy
    {
        public Price_SMA_20_50(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        override protected void StrategyExecute()
        {
            double[] sma20 = data.SMA(20);
            DataSeries sma50 = data.SMA(50);
            double[] price = data.closePrice;
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;;

            int lastBuyId = 0;
            for (int idx = 0; idx < sma20.Length; idx++)
            {
                currentTrend = ((price[idx] > sma20[idx]) && (sma20[idx] > sma50[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                {
                    adviceInfo.Add(AppTypes.MarketTrend.Upward, idx);
                    lastBuyId = idx;
                }
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                {
                    adviceInfo.Add(AppTypes.MarketTrend.Downward, idx);
                }
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma20, sma50);
            return adviceInfo;
        }
    }
}
