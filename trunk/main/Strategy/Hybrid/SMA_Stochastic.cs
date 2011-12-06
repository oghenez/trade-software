using application;
using commonClass;

namespace Strategy
{
    public class SMA_Stochastic_Helper : baseHelper
    {
        public SMA_Stochastic_Helper() : base(typeof(SMA_Stochastic)) { }
    }

    public class SMA_Stochastic : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int sma_short_period = (int)parameters[0];
            int sma_long_period = (int)parameters[1];
            int fastK = (int)parameters[2];
            int slowK = (int)parameters[3];
            int slowD = (int)parameters[4];

            DataSeries short_sma = Indicators.SMA.Series(data.Close,sma_short_period,"");
            DataSeries long_sma = Indicators.SMA.Series(data.Close, sma_long_period, "");

            Indicators.Stoch stoch = Indicators.Stoch.Series(data.Bars, fastK, slowK, slowD, "");
            DataSeries stoch1 = stoch.SlowKSeries;
            DataSeries stoch2 = stoch.SlowDSeries;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            AppTypes.MarketTrend stochTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 0; idx < short_sma.Count; idx++)
            {
                stochTrend = (stoch1[idx] > stoch2[idx] ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                currentTrend = ((data.Close[idx] > short_sma[idx]) && (short_sma[idx] > long_sma[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward && stochTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }
}
