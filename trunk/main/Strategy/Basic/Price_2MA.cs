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
            for (int idx = 0; idx < smarule.short_indicator.Count; idx++)
            {
                if (smarule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                if (smarule.isValid_forSell(idx))
                    SellAtClose(idx);
            }
            //DataSeries sma5 = Indicators.SMA.Series(data.Close, parameters[0], "");
            //DataSeries sma10 = Indicators.SMA.Series(data.Close, parameters[1], "");

            //AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            //AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;;

            //for (int idx = 0; idx < sma5.Count; idx++)
            //{
            //    currentTrend = ((data.Close[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            //    if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
            //        BuyAtClose(idx);
            //    if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
            //        SellAtClose(idx);
            //    lastTrend = currentTrend;
            //}
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

        public override bool isValid_forBuy(int idx)
        {
            if (idx < short_indicator.FirstValidValue) return false;

            if ((short_indicator[idx] > long_indicator[idx])
                &&(price[idx]>short_indicator[idx]))
                return true;

            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx < short_indicator.FirstValidValue) return false;

            if ((short_indicator[idx] < long_indicator[idx])||(price[idx]<short_indicator[idx]))
                return true;

            return false;
        }
    } 
}
