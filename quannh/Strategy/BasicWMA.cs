using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class BasicWMA_Helper : baseHelper
    {
        public BasicWMA_Helper()
            : base(typeof(BasicWMA))
        {
        }
    }
    public class BasicWMA : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries line1 = Indicators.WMA.Series(data.Close,parameters[0],"");
            DataSeries line2 = Indicators.WMA.Series(data.Close, parameters[1], "");

            AppTypes.MarketTrend trend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 0; idx < line1.Count; idx++)
            {
                double d1 = line1[idx];
                double d2 = line2[idx];
                if (d1 == 0 || d2 == 0) continue;

                trend = (d1 > d2 ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && trend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && trend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = trend;
            }
        }
    }
}
