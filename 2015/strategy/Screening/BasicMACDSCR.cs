using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application.Strategy;
using commonClass;

namespace Strategy
{
    public class BasicMACDSCR_Helper : baseHelper
    {
        public BasicMACDSCR_Helper() : base(typeof(BasicMACDSCR)) { }
    }

    public class BasicMACDSCR : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                BusinessInfo info = new BusinessInfo();
                info.Weight = rule.macd[Bar] * 100;
                SelectStock(Bar, info);
            }
        }
    }
}
