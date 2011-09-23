using application;

namespace Strategy
{
    public class BasicMACD_LineCut_Helper : baseHelper
    {
        public BasicMACD_LineCut_Helper() : base(typeof(BasicMACD_LineCut)) { }
    }

    public class BasicMACD_LineCut : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[0], parameters[1], parameters[2], "");
            DataSeries ema = macd.SignalSeries;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 0; idx < macd.Count; idx++)
            {
                currentTrend = (macd[idx] > ema[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward;
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }
}
