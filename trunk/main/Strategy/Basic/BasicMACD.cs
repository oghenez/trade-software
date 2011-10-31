using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class BasicMACD_Helper : baseHelper
    {
        public BasicMACD_Helper() : base(typeof(BasicMACD)) { }
    }

    public class BasicMACDSCR_Helper : baseHelper
    {
        public BasicMACDSCR_Helper() : base(typeof(BasicMACDSCR)) { }
    }

    //???
    //public class TwoSMAMACDSCR_Helper : baseHelper
    //{
    //    public TwoSMAMACDSCR_Helper() : base(typeof(TwoSMAMACDSCR)) { }
    //}

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
            //AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            //AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            //for (int idx = 0; idx < macd.Count; idx++)
            //{
            //    currentTrend = ((macd[idx] > 0 && macd[idx] > ema[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            //    if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
            //        BuyAtClose(idx);
            //    if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
            //        SellAtClose(idx);
            //    lastTrend = currentTrend;
            //}
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
            if (idx - 1 < macd.FirstValidValue) return false;
            
            AppTypes.MarketTrend lastTrend,currentTrend;
            lastTrend = ((macd[idx-1] > 0 && macd[idx-1] > ema[idx-1]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            currentTrend = ((macd[idx] > 0 && macd[idx] > ema[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            
            if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx - 1 < macd.FirstValidValue) return false;

            AppTypes.MarketTrend lastTrend, currentTrend;
            lastTrend = ((macd[idx - 1] > 0 && macd[idx - 1] > ema[idx - 1]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            currentTrend = ((macd[idx] > 0 && macd[idx] > ema[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);

            if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                return true;
            return false;
        }

        public override bool isValid(int index)
        {
            return base.isValid_forBuy(index);
        }
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
