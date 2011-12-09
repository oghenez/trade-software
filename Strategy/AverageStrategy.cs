using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class AverageStrategy_Helper : baseHelper
    {
        public AverageStrategy_Helper()
            : base(typeof(AverageStrategy))
        {
        }
    }
    public class AverageStrategy : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int NUM_AVERAGE = (int)parameters[0];
            int PERCENT_BUY = (int)parameters[1];
            int PERCENT_SELL = (int)parameters[2];
            
            double value, distance,distance1;
            
            for (int idx = 20; idx < data.Close.Count; idx++)
            {
                // Calculate the average value of NUM_AVERAGE days from idx point
                value = strategyLib.findAverage(data.Close, idx, NUM_AVERAGE);
                distance = (data.Close[idx] - value) / value * 100;
                distance1 = (data.Close[idx - 1] - value) / value * 100;
                if (distance1 < PERCENT_BUY && distance>PERCENT_BUY)
                   BuyAtClose(idx);                
                if (distance > PERCENT_SELL && distance1<PERCENT_SELL)                
                    SellAtClose(idx);
                
            }
        }
    }
}
