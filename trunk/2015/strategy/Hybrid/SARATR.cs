using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{    
    public class SARATR_Helper : baseHelper
    {
        public SARATR_Helper()
            : base(typeof(SARATR))
        {
        }
    }
    public class SARATR : GenericStrategy
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
