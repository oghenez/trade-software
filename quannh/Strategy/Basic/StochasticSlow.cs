using application;

namespace Strategy
{
    public class StochasticSlow_Helper : baseHelper
    {
        public StochasticSlow_Helper() : base(typeof(StochasticSlow)) { }
    }

    public class StochasticSlow : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            Indicators.Stoch stoch = Indicators.Stoch.Series(data.Bars, parameters[0], parameters[1],parameters[2], "");
            DataSeries line1 = stoch.SlowKSeries;
            DataSeries line2 = stoch.SlowDSeries;
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
