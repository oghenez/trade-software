using application.Strategy;
using commonClass;
using commonTypes;

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

            int cutlosslevel = 5;
            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[1], "max");
            Indicators.Fibonnanci fibo = Indicators.Fibonnanci.Series(data.Bars, parameters[1], "fibo");


            for (int idx = smarule.long_indicator.FirstValidValue; idx < smarule.long_indicator.Count; idx++)
            {
                if (smarule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Resistance = max[idx];
                    info.Short_Support = min[idx];
                    info.Short_Target = fibo.Fibo23pc[idx];
                    info.Stop_Loss = data.Close[idx] * (1 - cutlosslevel / 100);
                    BuyAtClose(idx,info);
                }
                else
                    if (smarule.isValid_forSell(idx))
                    {
                        BusinessInfo info = new BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Resistance = max[idx];
                        info.Short_Support = min[idx];
                        info.Short_Target = fibo.Fibo23pc[idx];
                        info.Stop_Loss = data.Close[idx] * (1 - cutlosslevel / 100);
                        SellAtClose(idx,info);
                    }
            }
        }
    }

    
}
