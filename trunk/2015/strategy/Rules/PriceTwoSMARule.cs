using application.Strategy;
using commonClass;
using commonTypes;

namespace Strategy
{
    /// <summary>
    /// Rule based on two SMA lines
    /// </summary>
    public class PriceTwoSMARule : Rule
    {
        public DataSeries short_indicator, long_indicator, price;
        public PriceTwoSMARule(DataSeries ds, double shortperiod, double longperiod)
        {
            price = ds;
            short_indicator = Indicators.SMA.Series(ds, shortperiod, "sma");
            long_indicator = Indicators.SMA.Series(ds, longperiod, "sma");
        }

        public override bool isValid()
        {
            int Bar = short_indicator.Count - 1;
            return isValid_forBuy(Bar);
        }

        public override bool isValid(int idx)
        {
            return isValid_forBuy(idx);
        }

        public override bool UpTrend(int index)
        {
            if (index < long_indicator.FirstValidValue) return false;
            if ((price[index] >= short_indicator[index]) && (short_indicator[index] >= long_indicator[index]))
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if (index < long_indicator.FirstValidValue) return false;
            if ((price[index] < short_indicator[index]) || (short_indicator[index] < long_indicator[index]))
                return true;
            return base.DownTrend(index);
        }

        public override bool isValid_forBuy(int idx)
        {
            if (UpTrend(idx) && DownTrend(idx - 1))
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (UpTrend(idx - 1) && DownTrend(idx))
                return true;
            return false;
        }
    } 
}
