using application.Strategy;
using commonClass;

namespace Strategy
{
    public class HybridSAR_Helper : baseHelper
    {
        public HybridSAR_Helper()
            : base(typeof(TwoSMA_SAR))
        {
        }
    }

    public class EMASAR_Helper : baseHelper
    {
        public EMASAR_Helper()
            : base(typeof(EMASAR))
        {
        }
    }

    public class TwoSMA_SAR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicSARRule sarRule = new BasicSARRule(data.Bars, parameters[0], parameters[1]);
            TwoSMARule smarule = new TwoSMARule(data.Close, parameters[2], parameters[3]);
            //BasicDMIRule dmiRule = new BasicDMIRule(data.Bars, 14, 14);
            Indicators.ADX adx = new Indicators.ADX(data.Bars, 14, "");

            int cutlosslevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[3], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[3], "max");

            for (int idx = 0; idx < data.Close.Count ; idx++)
            {
                if (adx[idx] > 25)
                {
                    if ((!is_bought) && ((sarRule.isValid_forBuy(idx) && smarule.UpTrend(idx))))
                    {
                        BusinessInfo info = new BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = max[idx];
                        info.Stop_Loss = min[idx];
                        BuyAtClose(idx, info);
                    }
                }
                if (is_bought && (sarRule.isValid_forSell(idx) || smarule.isValid_forSell(idx)))
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
            }
        }
    }

    public class EMASAR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicSARRule sarRule = new BasicSARRule(data.Bars, parameters[0], parameters[1]);
            TwoEMARule emaRule = new TwoEMARule(data.Close, parameters[2], parameters[3]);
            int cutlosslevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];


            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if ((!is_bought) && ((sarRule.isValid_forBuy(idx) && emaRule.UpTrend(idx))))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    BuyAtClose(idx, info);
                }
                if (is_bought && (sarRule.isValid_forSell(idx) || emaRule.isValid_forSell(idx)))
                //if (dmiRule.isValid_forSell(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    SellAtClose(idx, info);
                }

                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
            }
        }
    }
}
