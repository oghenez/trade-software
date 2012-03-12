using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application.Strategy;
using commonClass;
using commonTypes;

namespace Strategy
{
    public class HybridTest_Helper : baseHelper
    {
        public HybridTest_Helper()
            : base(typeof(HybridTest))
        {
        }
    }

    public class HybridTestBUY_Helper : baseHelper
    {
        public HybridTestBUY_Helper()
            : base(typeof(HybridTestBUY))
        {
        }
    }

    public class HybridTestRules : CompositeRule
    {
        ADXMarketTrend adxTrend;
        PriceTwoSMARule volumeRule;
        DataBars data;
        double Volume_Filter;

        public HybridTestRules(DataBars db, double atrperiod, double shortperiod, double longperiod)
        {
            rules = new Rule[3];
            rules[0] = new TwoSMARule(db.Close, shortperiod, longperiod);
            rules[1] = new BasicATRRule(db, atrperiod, "atr");
            rules[2] = new BasicMACDRule(db.Close, 12, 26, 9);

            adxTrend = new ADXMarketTrend(db, 14);
            //Kiem tra volume
            volumeRule = new PriceTwoSMARule(db.Volume, 10, 30);
            data = db;
            Volume_Filter = 50000;
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
            //if not sideway, avoid pitfall false signal
            if (!adxTrend.SideWay(index))
            {                
                //if volume is ok then
                if (volumeRule.UpTrend(index)&&volumeRule.price[index]>Volume_Filter)
                {

                    if ((rules[1].isValid_forBuy(index) && rules[0].UpTrend(index)&&rules[2].UpTrend(index))
                        ||
                       ((rules[0].isValid_forBuy(index) && rules[1].UpTrend(index) && rules[2].UpTrend(index))))
                        return true;
                }
            }
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
    /// Screening following HybridTest, Buy Signal
    /// </summary>
    public class HybridTestBUY : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            HybridTestRules rule = new HybridTestRules(data.Bars, parameters[0], parameters[1], parameters[2]);
            int cutlosslevel = (int)parameters[3];
            int trailingstoplevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];
            int Bar = data.Close.Count - 1;
            if (rule.isValid_forBuy(Bar))
            {
                BusinessInfo info = new BusinessInfo();
                info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }

    public class HybridTestSELL : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            HybridTestRules rule = new HybridTestRules(data.Bars, parameters[0], parameters[1], parameters[2]);
            int cutlosslevel = (int)parameters[3];
            int trailingstoplevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];
            int Bar = data.Close.Count - 1;
            if (rule.isValid_forSell(Bar))
            {
                BusinessInfo info = new BusinessInfo();
                info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }


    public class HybridTest : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            HybridTestRules rule = new HybridTestRules(data.Bars, parameters[0], parameters[1], parameters[2]);
            int cutlosslevel = (int)parameters[3];
            int trailingstoplevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[1], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[2], "max");
            
            for (int idx = 1; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx))
                    {
                        BusinessInfo info = new BusinessInfo();
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
