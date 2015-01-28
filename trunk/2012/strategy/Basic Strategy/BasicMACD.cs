using System;
using System.Collections.Generic;
using System.Text;
using application.Strategy;
using commonClass;

namespace Strategy
{
    public class BasicMACD_Helper : baseHelper
    {
        public BasicMACD_Helper() : base(typeof(BasicMACD)) { }
    }

    /// <summary>
    /// Strategy with MACD
    /// </summary>
    public class BasicMACD : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);

            for (int idx = 0; idx < rule.macd.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                if (rule.isValid_forSell(idx))
                    SellAtClose(idx);
            }            
        }
    }           
}
