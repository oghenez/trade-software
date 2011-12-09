using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class ConsecutiveUpDown_Helper : baseHelper
    {
        public ConsecutiveUpDown_Helper()
            : base(typeof(ConsecutiveUpDown))
        {
        }
    }
    public class ConsecutiveUpDown : GenericStrategy
    {
        protected override void  StrategyExecute()
        {
            int CONSECUTIVE_DOWN = (int)parameters[0];
            int CONSECUTIVE_UP = (int)parameters[1];


            for (int idx = 20; idx < data.Close.Count; idx++)
            {
                if (strategyLib.isCummulativeDown(data.Close, idx, CONSECUTIVE_DOWN))
                    BuyAtClose(idx);

                if (strategyLib.isCummulativeUp(data.Close, idx, CONSECUTIVE_UP))
                    SellAtClose(idx);
            }
        }
    }
}
