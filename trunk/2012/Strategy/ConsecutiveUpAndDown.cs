using System;
using System.Collections.Generic;
using System.Text;
using application.Strategy;

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

            bool is_2days_down, is_3days_up = false;

            for (int idx = 20; idx < data.Close.Count; idx++)
            {
                is_2days_down = strategyLib.isCummulativeDown(data.Close, idx, CONSECUTIVE_DOWN);
                if (is_2days_down)
                    BuyAtClose(idx);

                is_3days_up = strategyLib.isCummulativeUp(data.Close, idx, CONSECUTIVE_UP);
                if (is_3days_up)
                    SellAtClose(idx);
            }
        }
    }
}
