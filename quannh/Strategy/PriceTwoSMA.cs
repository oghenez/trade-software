using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class PriceTwoSMA : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries sma5 = data.SMA(parameters[0]);
            DataSeries sma10 = data.SMA(parameters[1]);

            double[] price = data.closePrice;
            
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;;

            //int lastBuyId = 0;
            for (int idx = 0; idx < sma5.Length; idx++)
            {
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }
}
