using application;
using commonClass;

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

    public class StockFastRule : Rule
    {
        public Indicators.StochF stoch;
        public DataSeries line1, line2;

        public StockFastRule(DataBars db,Parameters parameters)
        {
            stoch = Indicators.StochF.Series(db, parameters[0], parameters[1], "");
            line1 = stoch.FastKSeries;
            line2 = stoch.FastDSeries;
        }

        public override bool  isValid()
        {
            if (line1.Count < 2) return false;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = line1.Count - 2; idx < line1.Count; idx++)
            {
                currentTrend = ((line1[idx] > line2[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    return true;
                lastTrend = currentTrend;
            }

            return false;
        }
    }
     public class StochFastSCR : GenericStrategy
     {
         override protected void StrategyExecute()
         {
             StockFastRule rule = new StockFastRule(data.Bars, parameters);
             if (rule.isValid())
             {
                 int Bar = data.Close.Count - 1;
                 BusinessInfo info = new BusinessInfo();
                 info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                 info.Weight = rule.stoch[Bar];
                 SelectStock(Bar, info);
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
