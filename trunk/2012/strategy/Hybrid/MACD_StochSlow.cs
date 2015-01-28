using application.Strategy;
using commonClass;

namespace Strategy
{
    public class MACD_StochSlow_Helper : baseHelper
    {
        public MACD_StochSlow_Helper() : base(typeof(MACD_StochSlow)) { }
    }

    public class MACD_StochSlow : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            //DataSeries sma20 = Indicators.SMA.Series(data.Close, parameters[0], "");

            MACD_HistogramRule macdHistogramRule = new MACD_HistogramRule(data.Close, parameters[1], parameters[2],
                parameters[3]);

            StochSlowRule stochSlowRule = new StochSlowRule(data.Bars, parameters[4], parameters[5],
                parameters[6]);

            for (int idx = 1; idx < data.Close.Count; idx++)
            {
                if (macdHistogramRule.isValid_forBuy(idx) && stochSlowRule.UpTrend(idx))
                    BuyAtClose(idx);

                if (macdHistogramRule.isValid_forSell(idx))
                    SellAtClose(idx);
            }
        }
    }
}
