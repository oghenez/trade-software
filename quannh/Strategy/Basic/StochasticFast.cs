using application;

namespace Strategy
{
    public class StochFastSCR_Helper : baseHelper
    {
        public StochFastSCR_Helper() : base(typeof(StochFastSCR)) { }
    }

    public class StochasticFast_Helper : baseHelper
    {
        public StochasticFast_Helper() : base(typeof(StochasticFast)) { }
    }

     public class StochFastSCR : GenericStrategy
     {
         override protected void StrategyExecute()
         {
             Indicators.StochF stoch = Indicators.StochF.Series(data.Bars, parameters[0], parameters[1], "");

             DataSeries line1 = stoch.FastKSeries;
             DataSeries line2 = stoch.FastDSeries;
             if (line1.Count < 2) return;

             AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
             AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

             for (int idx = line1.Count - 2; idx < line1.Count; idx++)
             {
                 currentTrend = ((line1[idx] > line2[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                 if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                 {
                     BusinessInfo info = new BusinessInfo();
                     info.Weight = line1[idx];
                     SelectStock(idx, info);
                 }
                 lastTrend = currentTrend;
             }
         }
     }

    /// <summary>
    /// Strategy using stochastic fast
    /// </summary>
     public class StochasticFast : GenericStrategy
     {
         override protected void StrategyExecute()
         {
             Indicators.StochF stoch = Indicators.StochF.Series(data.Bars, parameters[0], parameters[1], "");
             DataSeries line1 = stoch.FastKSeries;
             DataSeries line2 = stoch.FastDSeries;
             AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
             AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

             for (int idx = 0; idx < line1.Count; idx++)
             {
                 currentTrend = ((line1[idx] > line2[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                 if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                     BuyAtClose(idx);
                 if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                     SellAtClose(idx);
                 lastTrend = currentTrend;
             }
         }
     }
}
