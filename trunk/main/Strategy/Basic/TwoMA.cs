using application;

namespace Strategy
{
    public class TwoSMASCR_Helper : baseHelper
    {
        public TwoSMASCR_Helper() : base(typeof(TwoSMASCR)) { }
    }

    public class TwoSMA_Helper : baseHelper
    {
        public TwoSMA_Helper() : base(typeof(TwoSMA)) { }
    }

    public class TwoEMA_Helper : baseHelper
    {
        public TwoEMA_Helper()
            : base(typeof(TwoEMA))
        {
        }
    }

    public class TwoWMA_Helper : baseHelper
    {
        public TwoWMA_Helper()
            : base(typeof(TwoWMA))
        {
        }
    }

    public class TwoWMA : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries line1 = Indicators.WMA.Series(data.Close, parameters[0], "");
            DataSeries line2 = Indicators.WMA.Series(data.Close, parameters[1], "");

            AppTypes.MarketTrend trend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 0; idx < line1.Count; idx++)
            {
                double d1 = line1[idx];
                double d2 = line2[idx];
                if (d1 == 0 || d2 == 0) continue;

                trend = (d1 > d2 ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && trend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && trend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = trend;
            }
        }
    }
    public class TwoEMA : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            DataSeries line1 = Indicators.EMA.Series(data.Close, parameters[0], "");
            DataSeries line2 = Indicators.EMA.Series(data.Close, parameters[1], "");

            AppTypes.MarketTrend trend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            for (int idx = 0; idx < line1.Count; idx++)
            {
                double d1 = line1[idx];
                double d2 = line2[idx];
                if (d1 == 0 || d2 == 0) continue;

                trend = (d1 > d2 ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && trend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && trend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = trend;
            }
        }
    }
    public class TwoSMA : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries sma5 = Indicators.SMA.Series(data.Close,parameters[0],"");
            DataSeries sma10 = Indicators.SMA.Series(data.Close, parameters[1], "");

            AppTypes.MarketTrend trend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            
            for (int idx = 0; idx < sma5.Count; idx++)
            {
                double d1 = sma5[idx];  //SMA 5
                double d2 = sma10[idx]; //SMA 10
                if (d1 == 0 || d2 == 0) continue;

                trend = (d1 > d2 ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && trend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);

                if (lastTrend == AppTypes.MarketTrend.Upward && trend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = trend;
            }
        }
    }

    public class TwoSMARule : Rule
    {
        public DataSeries short_indicator, long_indicator;
        public TwoSMARule(DataSeries ds, int shortperiod, int longperiod)
        {
            short_indicator = Indicators.SMA.Series(ds, shortperiod, "");
            long_indicator = Indicators.SMA.Series(ds, longperiod, "");
        }

        public override bool isValid()
        {
            int Bar = short_indicator.Count - 1;
            if (Bar < 0) return false;

            if (short_indicator[Bar] > long_indicator[Bar])
                return true;

            return false;
        }

        public override bool isValid(int index)
        {
            if (index < 0) return false;

            if (short_indicator[index] > long_indicator[index])
                return true;

            return false;
        }
    }    

    public class TwoSMASCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            TwoSMARule rule = new TwoSMARule(data.Close, (int)parameters[0], (int)parameters[1]);
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                BusinessInfo info = new BusinessInfo();
                info.Weight = rule.short_indicator[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
