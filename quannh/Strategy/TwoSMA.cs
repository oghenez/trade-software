using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class TwoSMA : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries sma5 = Indicators.SMA.Series(data.Close,parameters[0],"");
            DataSeries sma10 = Indicators.SMA.Series(data.Close, parameters[1], "");

            AppTypes.MarketTrend trend = AppTypes.MarketTrend.Unspecified;;
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            
            for (int idx = 0; idx < sma5.Count; idx++)
            {
                double d1 = sma5[idx];  //SMA 5
                double d2 = sma10[idx]; //SMA 10
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
