using application;
using commonClass;

namespace Strategy
{
    public class Price_3SMA_Helper : baseHelper
    {
        public Price_3SMA_Helper() : base(typeof(Price_3SMA)) { }
    }

    public class Price_3SMA_Risk_Reward_Helper : baseHelper
    {
        public Price_3SMA_Risk_Reward_Helper() : base(typeof(Price_3SMA_Risk_Reward)) { }
    }

    public class Price_3SMA_Risk_Reward : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            DataSeries sma5 = Indicators.SMA.Series(data.Close, parameters[0], "");
            DataSeries sma10 = Indicators.SMA.Series(data.Close, parameters[1], "");
            DataSeries sma20 = Indicators.SMA.Series(data.Close, parameters[2], "");
            int RISKREWARD = (int)parameters[3];
            int PERIOD = (int)parameters[4];

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified; 
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified; 
            for (int idx = 0; idx < sma5.Count; idx++)
            {
                currentTrend = ((data.Close[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) && (sma10[idx] > sma20[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                {
                    double risk_reward_ratio = strategyLib.RiskRewardRatio(data.Close, idx, PERIOD);
                    if (risk_reward_ratio >= RISKREWARD)
                        BuyAtClose(idx);
                }
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }

    public class Price_3SMA : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries sma5 = Indicators.SMA.Series(data.Close, parameters[0], "");
            DataSeries sma10 = Indicators.SMA.Series(data.Close, parameters[1], "");
            DataSeries sma20 = Indicators.SMA.Series(data.Close, parameters[2], "");

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;
            
            for (int idx = 0; idx < sma5.Count; idx++)
            {
                currentTrend = ((data.Close[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) && (sma10[idx] > sma20[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }
}
