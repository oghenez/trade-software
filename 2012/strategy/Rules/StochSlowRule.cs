using application.Strategy;
using commonClass;

namespace Strategy
{
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
}
