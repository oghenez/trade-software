using System;
using System.Collections.Generic;
using System.Text;
using application.Strategy;

namespace Strategy
{
    public class RandomStrategy_Helper : baseHelper
    {
        public RandomStrategy_Helper() : base(typeof(RandomStrategy)) { }
    }

    public class RandomStrategy : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            System.Random r=new Random();

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                int n = r.Next(5);
                if (!is_bought&&n == 0)
                    BuyAtClose(idx);
                if (is_bought && n == 4)
                    SellAtClose(idx);                
            }
        }
    }
}
