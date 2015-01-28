using application.Strategy;
using commonClass;

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
            StochSlowRule stochRule = new StochSlowRule(data.Bars, parameters[0], parameters[1], parameters[2]);

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if (stochRule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                if (stochRule.isValid_forSell(idx))
                    SellAtClose(idx);
            }
        }
    }
}
