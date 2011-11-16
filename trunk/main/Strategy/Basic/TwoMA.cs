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
            DataSeries line1 = Indicators.WMA.Series(data.Close, parameters[0], "wma");
            DataSeries line2 = Indicators.WMA.Series(data.Close, parameters[1], "wma");

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
            DataSeries line1 = Indicators.EMA.Series(data.Close, parameters[0], "ema");
            DataSeries line2 = Indicators.EMA.Series(data.Close, parameters[1], "ema");

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
            TwoSMARule rule = new TwoSMARule(data.Close, parameters[0], parameters[1]);

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                else
                    if (rule.isValid_forSell(idx))
                        SellAtClose(idx);
            }
        }
    }

    /// <summary>
    /// Rule based on two EMA lines
    /// </summary>
    public class TwoEMARule : Rule
    {
        public DataSeries short_indicator, long_indicator;
        public TwoEMARule(DataSeries ds, double shortperiod, double longperiod)
        {
            short_indicator = Indicators.EMA.Series(ds, shortperiod, "ema");
            long_indicator = Indicators.EMA.Series(ds, longperiod, "ema");
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

        public override bool UpTrend(int idx)
        {
            if (idx < long_indicator.FirstValidValue) return false;

            if (short_indicator[idx] > long_indicator[idx])
                return true;

            return false;
        }

        public override bool DownTrend(int idx)
        {
            if (idx < long_indicator.FirstValidValue) return false;

            if (short_indicator[idx] < long_indicator[idx])
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
            if (DownTrend(index) && UpTrend(index - 1))
                return true;
            return false;
        }
    }

    /// <summary>
    /// Rule based on two WMA lines
    /// </summary>
    public class TwoWMARule : Rule
    {
        public DataSeries short_indicator, long_indicator;
        public TwoWMARule(DataSeries ds, double shortperiod, double longperiod)
        {
            short_indicator = Indicators.WMA.Series(ds, shortperiod, "wma");
            long_indicator = Indicators.WMA.Series(ds, longperiod, "wma");
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

        public override bool UpTrend(int idx)
        {
            if (idx < long_indicator.FirstValidValue) return false;

            if (short_indicator[idx] > long_indicator[idx])
                return true;

            return false;
        }

        public override bool DownTrend(int idx)
        {
            if (idx < long_indicator.FirstValidValue) return false;

            if (short_indicator[idx] < long_indicator[idx])
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
            if (DownTrend(index) && UpTrend(index - 1))
                return true;
            return false;
        }
    }

    /// <summary>
    /// Rule based on two SMA lines
    /// </summary>
    public class TwoSMARule : Rule
    {
        public DataSeries short_indicator, long_indicator;
        public TwoSMARule(DataSeries ds, double shortperiod, double longperiod)
        {
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
            if (idx - 1 < short_indicator.FirstValidValue) return false;

            AppTypes.MarketTrend currentTrend = (short_indicator[idx] > long_indicator[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward;
            AppTypes.MarketTrend lastTrend = (short_indicator[idx - 1] > long_indicator[idx - 1]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward;
            if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                return true;

            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (index - 1 < short_indicator.FirstValidValue) return false;

            AppTypes.MarketTrend currentTrend = (short_indicator[index] > long_indicator[index]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward;
            AppTypes.MarketTrend lastTrend = (short_indicator[index - 1] > long_indicator[index - 1]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward;
            if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                return true;

            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index < short_indicator.FirstValidValue) return false;
            if (short_indicator[index] > long_indicator[index])
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if (index < short_indicator.FirstValidValue) return false;
            if (short_indicator[index] < long_indicator[index])
                return true;
            return false;
        }
    }

    /// <summary>
    /// Screening based on two SMA lines cut
    /// </summary>
    public class TwoSMASCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            TwoSMARule rule = new TwoSMARule(data.Close, parameters[0], parameters[1]);
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                wsData.BusinessInfo info = new wsData.BusinessInfo();
                info.Weight = rule.short_indicator[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
