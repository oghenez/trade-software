using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace Strategy
{
    public class HybridEMAATR_Helper : baseHelper
    {
        public HybridEMAATR_Helper()
            : base(typeof(HybridEMAATR))
        {
        }
    }

    public class HybridSMAATR_Helper : baseHelper
    {
        public HybridSMAATR_Helper()
            : base(typeof(HybridSMAATR))
        {
        }
    }

    public class HybridMACDHistATR_Helper : baseHelper
    {
        public HybridMACDHistATR_Helper()
            : base(typeof(HybridMACDHistATR))
        {
        }
    }

    public class HybridSARATR_Helper : baseHelper
    {
        public HybridSARATR_Helper()
            : base(typeof(HybridSARATR))
        {
        }
    }

    public class HybridEMAATR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicATRRule rule = new BasicATRRule(data.Bars, parameters[0], "atr");
            TwoEMARule emaRule = new TwoEMARule(data.Close, parameters[1], parameters[2]);
            int cutlosslevel = (int)parameters[3];
            int trailingstoplevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

            for (int idx = 0; idx < data.Close.Count - 1; idx++)
            {
                if (rule.isValid_forBuy(idx) && emaRule.UpTrend(idx))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx) || emaRule.isValid_forSell(idx))
                    {
                        wsData.BusinessInfo info = new wsData.BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = min[idx];
                        info.Stop_Loss = max[idx];
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

    public class SMAATRRules : CompositeRule
    {
        public SMAATRRules(DataBars db, double atrperiod, double shortperiod, double longperiod)
        {
            rules = new Rule[2];
            rules[0] = new TwoSMARule(db.Close, shortperiod, longperiod);
            rules[1] = new BasicATRRule(db, atrperiod, "atr");
        }

        public override bool DownTrend(int index)
        {
            if (rules[0].DownTrend(index))
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            return (rules[0].UpTrend(index));
        }

        public override bool isValid_forBuy(int index)
        {
            if (rules[1].isValid_forBuy(index) && rules[0].UpTrend(index))
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

    public class SARATRRules : CompositeRule
    {
        public SARATRRules(DataBars db, double atrperiod, double optInAcc,double optLnMax)
        {
            rules = new Rule[2];
            rules[0] = new BasicSARRule(db, optInAcc, optLnMax);
            rules[1] = new BasicATRRule(db, atrperiod, "atr");
        }

        public override bool DownTrend(int index)
        {
            if (rules[0].DownTrend(index))
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            return (rules[0].UpTrend(index));
        }

        public override bool isValid_forBuy(int index)
        {
            if (rules[1].isValid_forBuy(index) && rules[0].UpTrend(index))
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

    public class MACDHistATRRules : CompositeRule
    {
        public MACDHistATRRules(DataBars db, double atrperiod, double fast, double slow,double signal)
        {
            rules = new Rule[2];
            rules[0] = new MACD_HistogramRule(db.Close, fast, slow,signal);
            rules[1] = new BasicATRRule(db, atrperiod, "atr");
        }

        public override bool DownTrend(int index)
        {
            if (rules[0].DownTrend(index))
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            return (rules[0].UpTrend(index));
        }

        public override bool isValid_forBuy(int index)
        {
            if (rules[1].isValid_forBuy(index) && rules[0].UpTrend(index))
                return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (rules[0].isValid_forSell(index) || rules[1].isValid_forSell(index))
                return true;
            //if (rules[1].isValid_forSell(index) && rules[0].DownTrend(index))
            //    return true;
            return false;
        }
    }

    public class HybridSMAATR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            SMAATRRules rule = new SMAATRRules(data.Bars, parameters[0], parameters[1], parameters[2]);
            int cutlosslevel = (int)parameters[3];
            int trailingstoplevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[1], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[2], "max");

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx))
                    {
                        wsData.BusinessInfo info = new wsData.BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = min[idx];
                        info.Stop_Loss = max[idx];
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

    public class HybridMACDHistATR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            MACDHistATRRules rule = new MACDHistATRRules(data.Bars, parameters[0], parameters[1], parameters[2],parameters[3]);
            MarketTrend marketTrend=new ADXMarketTrend(data.Bars,parameters[4]);
            int cutlosslevel = (int)parameters[5];
            int trailingstoplevel = (int)parameters[6];
            int takeprofitlevel = (int)parameters[7];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx)&&(marketTrend.Trending(idx)))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx))
                    {
                        wsData.BusinessInfo info = new wsData.BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = min[idx];
                        info.Stop_Loss = max[idx];
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

    public class HybridSARATR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            SARATRRules rule = new SARATRRules(data.Bars, parameters[0], parameters[1], parameters[2]);
            //MarketTrend marketTrend = new ADXMarketTrend(data.Bars, parameters[4]);
            int cutlosslevel = (int)parameters[3];
            int trailingstoplevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx))
                    {
                        wsData.BusinessInfo info = new wsData.BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = min[idx];
                        info.Stop_Loss = max[idx];
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
}
