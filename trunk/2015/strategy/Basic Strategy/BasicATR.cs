//Copyright by NHQ, HCM city, 2011 
//Basic DMI strategy
//Buy when there is cut between DI+ and DI-
//The cut loss function work with some cut loss level

using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{
    #region ATR Helper
    public class BasicATR_Helper : baseHelper
    {
        public BasicATR_Helper()
            : base(typeof(BasicATR))
        {
        }
    }    

    #   endregion

    #region ATR Strategy       

    public class BasicATR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicATRRule rule = new BasicATRRule(data.Bars, parameters[0], "atr");
            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

            for (int idx = 0; idx < data.Close.Count ; idx++)
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
            }
        }
    }
    
    #   endregion
}