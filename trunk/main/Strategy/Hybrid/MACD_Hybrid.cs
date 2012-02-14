//Copyright by NHQ, HCM city, 2011 
using Indicators;
using application.Strategy;
using commonClass;

namespace Strategy
{
    public class MACD_ADX_Helper : baseHelper
    {
        public MACD_ADX_Helper() : base(typeof(MACD_ADX)) { }

    }

    public class MACD_ADX_RiskMng_Helper : baseHelper
    {
        public MACD_ADX_RiskMng_Helper() : base(typeof(MACD_ADX_RiskMng)) { }
    }

    public class TwoSMAMACDSCR_Helper : baseHelper
    {
        public TwoSMAMACDSCR_Helper() : base(typeof(TwoSMAMACDSCR)) { }
    }

    public class TwoSMAMACD_SELL_Helper : baseHelper
    {
        public TwoSMAMACD_SELL_Helper() : base(typeof(TwoSMAMACD_SELL)) { }
    }

    public class TwoSMAMACD_UPTREND_Helper : baseHelper
    {
        public TwoSMAMACD_UPTREND_Helper() : base(typeof(TwoSMAMACD_UPTREND)) { }
    }

    public class TwoSMAMACD_DOWNTREND_Helper : baseHelper
    {
        public TwoSMAMACD_DOWNTREND_Helper() : base(typeof(TwoSMAMACD_DOWNTREND)) { }
    }

    public class TwoSMABasicMACD_Helper : baseHelper
    {
        public TwoSMABasicMACD_Helper() : base(typeof(TwoSMABasicMACD)) { }
    }

    public class MACD_ADX : GenericStrategy
    {
        override protected void StrategyExecute()
        {            
            MACD macd = Indicators.MACD.Series(data.Close,
                parameters[0], parameters[1],
                parameters[2],"");

            ADX adx=new ADX(data.Bars,parameters[3],"");
            double delta = 0, lastDelta = 0;

            for (int idx = 1; idx < macd.Values.Length; idx++)
            {
                delta = (macd.HistSeries[idx] - macd.HistSeries[idx - 1]);
                //If there is a trend
                if (adx[idx] > 25)
                {
                    if (delta > 0 && lastDelta < 0)
                        BuyAtClose(idx);
                }
                if (delta < 0 && lastDelta > 0)
                    SellAtClose(idx);
                lastDelta = delta;
            }
        }
    }

    public class MACD_ADX_RiskMng : GenericStrategy
    {
        override protected void StrategyExecute()
        {            
            MACD macd = Indicators.MACD.Series(data.Close,
                parameters[0], parameters[1],
                parameters[2],"");

            ADX adx=new ADX(data.Bars,parameters[3],"");

            int cutlosslevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];
            double delta = 0, lastDelta = 0;

            for (int idx = 1; idx < macd.Values.Length; idx++)
            {
                delta = (macd.HistSeries[idx] - macd.HistSeries[idx - 1]);
                //If there is a trend
                if (adx[idx] > 25)
                {
                    if (delta > 0 && lastDelta < 0)
                        BuyAtClose(idx);
                }
                if (delta < 0 && lastDelta > 0)
                    SellAtClose(idx);

                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
                lastDelta = delta;
            }
        }
    }

    /// <summary>
    /// Rule
    /// </summary>
    public class TwoSMABasicMACDRule : CompositeRule
    {
        public TwoSMABasicMACDRule(DataSeries ds, double fast, double slow, double signal, double shortperiod, double longperiod)
        {
            rules = new Rule[2];
            rules[0] = new BasicMACDRule(ds, (int)fast,(int)slow,(int)signal);
            rules[1] = new TwoSMARule(ds, shortperiod, longperiod);
        }

        public override bool DownTrend(int index)
        {
            if (rules[0].DownTrend(index)||rules[1].DownTrend(index))
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            return (rules[0].UpTrend(index)&&rules[1].UpTrend(index));
        }

        public override bool isValid_forBuy(int index)
        {
            if ((rules[1].isValid_forBuy(index) && rules[0].UpTrend(index))
                ||
            (rules[0].isValid_forBuy(index) && rules[1].UpTrend(index)))
                return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (rules[0].isValid_forSell(index) || rules[1].isValid_forSell(index))
                return true;
            return false;
        }
    }

    /// <summary>
    /// Strategy
    /// </summary>
    public class TwoSMABasicMACD : GenericStrategy
    {
        /// <summary>
        /// Strategy following hybrid : basic MACD rule&&2sma
        /// </summary>
        override protected void StrategyExecute()
        {
            //BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            //TwoSMARule rule1 = new TwoSMARule(data.Close, (int)parameters[3], (int)parameters[4]);
            TwoSMABasicMACDRule rule = new TwoSMABasicMACDRule(data.Close, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
            int cutlosslevel = (int)parameters[5];
            int trailingstoplevel = (int)parameters[6];
            int takeprofitlevel = (int)parameters[7];

            
            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                //Buy condition
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Weight = data.Close[idx];
                    BuyAtClose(idx, info);
                }
                //Sell condition
                else
                    if (rule.isValid_forSell(idx) )
                    {
                        BusinessInfo info = new BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        SellAtClose(idx, info);
                    }
                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);

                if (trailingstoplevel > 0)
                    TrailingStopWithBuyBack(rule, data.Close[idx], trailingstoplevel, idx);
            }
        }
    }

    /// <summary>
    /// Buy signal Screening
    /// </summary>
    public class TwoSMAMACDSCR : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            //BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            //TwoSMARule rule1 = new TwoSMARule(data.Close, (int)parameters[3], (int)parameters[4]);
            TwoSMABasicMACDRule rule = new TwoSMABasicMACDRule(data.Close, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
            int Bar = data.Close.Count - 1;
            if (rule.isValid_forBuy(Bar))
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }

    /// <summary>
    /// Sell signal Screening
    /// </summary>
    public class TwoSMAMACD_SELL : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            //BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            //TwoSMARule rule1 = new TwoSMARule(data.Close, (int)parameters[3], (int)parameters[4]);
            TwoSMABasicMACDRule rule = new TwoSMABasicMACDRule(data.Close, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
            int Bar = data.Close.Count - 1;
            if (rule.isValid_forSell(Bar) )
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }

    /// <summary>
    /// Up Trend Screening
    /// </summary>
    public class TwoSMAMACD_UPTREND : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            //BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            //TwoSMARule rule1 = new TwoSMARule(data.Close, (int)parameters[3], (int)parameters[4]);
            TwoSMABasicMACDRule rule = new TwoSMABasicMACDRule(data.Close, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
            int Bar = data.Close.Count - 1;
            if (rule.UpTrend(Bar))
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }

    /// <summary>
    /// Down Trend Screening
    /// </summary>
    public class TwoSMAMACD_DOWNTREND : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            //BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            //TwoSMARule rule1 = new TwoSMARule(data.Close, (int)parameters[3], (int)parameters[4]);
            TwoSMABasicMACDRule rule = new TwoSMABasicMACDRule(data.Close, parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
            int Bar = data.Close.Count - 1;
            if (rule.DownTrend(Bar))
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
