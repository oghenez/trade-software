using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{
    public class BasicATRSCR_Helper : baseHelper
    {
        public BasicATRSCR_Helper()
            : base(typeof(BasicATRSCR))
        {
        }
    }

    public class BasicATRSCR : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            Rule rule = new BasicATRRule(data.Bars, parameters[0], "atr");
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                BusinessInfo info = new BusinessInfo();
                info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
