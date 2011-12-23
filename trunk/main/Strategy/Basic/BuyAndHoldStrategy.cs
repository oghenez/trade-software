//Copyright by NHQ, HCM city, 2011 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application.Strategy;
using Indicators;

namespace Strategy
{
    public class BuyAndHold_Helper : baseHelper
    {
        public BuyAndHold_Helper() : base(typeof(BuyAndHold)) { }
    }

    public class BuyAndHold : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            if (data.Close.Count > 0)
            {
                BuyAtClose(0);
                SellAtClose(data.Close.Count - 1);
            }
        }
    }
}
