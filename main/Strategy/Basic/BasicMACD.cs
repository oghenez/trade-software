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

    public class BasicMACDSCR_Helper : baseHelper
    {
        public BasicMACDSCR_Helper() : base(typeof(BasicMACD_BUYSCR)) { }
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

    public class BasicMACDRule:Rule{
        public Indicators.MACD macd;
        public DataSeries ema;
        public BasicMACDRule(DataSeries ds,int fast,int slow,int signal)
        {
            macd = Indicators.MACD.Series(ds, fast, slow, signal, "macd");
            ema = macd.SignalSeries;
        }

        /// <summary>
        /// Condition for Screening
        /// </summary>
        /// <returns></returns>
        public override bool isValid()
        {
            return isValid_forBuy(macd.Count - 1);
        }

        /// <summary>
        /// If last Macd condition is downward and current Macd Condition upward then BUY
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public override bool isValid_forBuy(int idx)
        {
            if (DownTrend(idx-1)&&UpTrend(idx)) return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (DownTrend(idx)&&UpTrend(idx-1)) return true;
            return false;
        }

        public override bool isValid(int index)
        {
            return base.isValid_forBuy(index);
        }

        public override bool DownTrend(int index)
        {
            if (index < macd.FirstValidValue) return false;

            if ((macd[index] <= 0 || macd[index] <= ema[index]))
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index < macd.FirstValidValue) return false;

            if ((macd[index] > 0 && macd[index] > ema[index]))
                return true;
            return false;
        }
    }

    public class BasicMACD_BUYSCR : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            int Bar = data.Close.Count - 1;
            if (rule.isValid_forBuy(Bar))
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }            
        }
    }
    
}
