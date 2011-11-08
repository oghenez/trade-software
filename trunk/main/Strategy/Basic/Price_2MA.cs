using application;

namespace Strategy
{
    public class PriceTwoSMA_Helper : baseHelper
    {
        public PriceTwoSMA_Helper() : base(typeof(PriceTwoSMA)) { }
    }

    public class PriceTwoSMA : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            PriceTwoSMARule smarule = new PriceTwoSMARule(data.Close, parameters[0], parameters[1]);
            for (int idx = smarule.short_indicator.FirstValidValue; idx < smarule.short_indicator.Count; idx++)
            {
                if (smarule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                else
                if (smarule.isValid_forSell(idx))
                    SellAtClose(idx);
            }
        }
    }

    /// <summary>
    /// Rule based on two SMA lines
    /// </summary>
    public class PriceTwoSMARule : Rule
    {
        public DataSeries short_indicator, long_indicator,price;
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
            if ((price[index] > short_indicator[index]) && (short_indicator[index] > long_indicator[index]))
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if ((price[index] < short_indicator[index]) || (short_indicator[index] < long_indicator[index]))
                return true;
            return base.DownTrend(index);
        }

        public override bool isValid_forBuy(int idx)
        {
            if (idx-1 < short_indicator.FirstValidValue) return false;

            AppTypes.MarketTrend currentTrend = ((price[idx] > short_indicator[idx]) && (short_indicator[idx] > long_indicator[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            AppTypes.MarketTrend lastTrend = ((price[idx-1] > short_indicator[idx-1]) && (short_indicator[idx-1] > long_indicator[idx-1]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                return true;

            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx - 1 < short_indicator.FirstValidValue) return false;

            AppTypes.MarketTrend currentTrend = ((price[idx] > short_indicator[idx]) && (short_indicator[idx] > long_indicator[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            AppTypes.MarketTrend lastTrend = ((price[idx - 1] > short_indicator[idx - 1]) && (short_indicator[idx - 1] > long_indicator[idx - 1]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                return true;

            return false;
        }
    } 
}
