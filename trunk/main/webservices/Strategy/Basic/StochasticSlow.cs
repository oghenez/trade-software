using application;
using commonClass;

namespace Strategy
{
    public class StochasticSlow_Helper : baseHelper
    {
        public StochasticSlow_Helper() : base(typeof(StochasticSlow)) { }
    }

    public class StochSlowRule : Rule
    {
        public Indicators.Stoch stoch;
        DataSeries line1, line2;

        public StochSlowRule(DataBars db, double fastK, double slowK, double slowD)
        {
            stoch = Indicators.Stoch.Series(db, fastK, slowK, slowD, "stoch");
            line1 = stoch.SlowKSeries;
            line2 = stoch.SlowDSeries;
        }

        public override bool UpTrend(int index)
        {
            if (index < line2.FirstValidValue)
                return false;
            if (line1[index] > line2[index])
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if (index < line2.FirstValidValue)
                return false;
            if (line1[index] <= line2[index])
                return true;
            return false;
        }

        public override bool isValid_forBuy(int index)
        {
            if (DownTrend(index - 1) && UpTrend(index))
                return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (UpTrend(index - 1) && DownTrend(index))
                return true;
            return false;
        }
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
