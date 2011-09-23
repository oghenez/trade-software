using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class BasicSMA_5_10 : GenericStrategy
    {
        public BasicSMA_5_10(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        override protected void StrategyExecute()
        {
            DataSeries sma5 = data.SMA(5);
            DataSeries sma10 = data.SMA(10);

            AppTypes.MarketTrend trend = AppTypes.MarketTrend.Unspecified;;
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            for (int idx = 0; idx < sma5.Length; idx++)
            {
                double d1 = sma5[idx];  //SMA 5
                double d2 = sma10[idx]; //SMA 10
                if (d1 == 0 || d2 == 0) continue;

                trend = (d1 > d2 ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && trend == AppTypes.MarketTrend.Upward)
                {
                    adviceInfo.Add(AppTypes.MarketTrend.Upward, idx);
                }
                if (lastTrend == AppTypes.MarketTrend.Upward && trend == AppTypes.MarketTrend.Downward)
                {
                    adviceInfo.Add(AppTypes.MarketTrend.Downward, idx);
                }
                lastTrend = trend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
