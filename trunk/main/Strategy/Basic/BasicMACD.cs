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
            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[0], parameters[1], parameters[2], "");
            DataSeries ema = macd.SignalSeries;
            DataSeries hist = macd.HistSeries;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 0; idx < macd.Count; idx++)
            {
                currentTrend = ((macd[idx] > 0 && macd[idx] > ema[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }

    public class BasicMACDRule:Rule{
        public Indicators.MACD macd;
        public DataSeries ema;
        public BasicMACDRule(DataSeries ds,int fast,int slow,int signal)
        {
            macd = Indicators.MACD.Series(ds, fast, slow, signal, "");
            ema = macd.SignalSeries;
        }

        public override bool isValid()
        {
            if (macd.Count < 2) return false;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = macd.Count-2; idx < macd.Count; idx++)
            {
                currentTrend = ((macd[idx] > 0 && macd[idx] > ema[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    return true;
                lastTrend = currentTrend;
            }
            return false;
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
            //Rule rule1 = new TwoSMARule(data, 5, 10);
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
