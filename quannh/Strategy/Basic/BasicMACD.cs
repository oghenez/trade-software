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

    public class BasicMACDSCR : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[0], parameters[1], parameters[2], "");
            DataSeries ema = macd.SignalSeries;
            DataSeries hist = macd.HistSeries;
            if (macd.Count < 2) return;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = macd.Count-2; idx < macd.Count; idx++)
            {
                currentTrend = ((macd[idx] > 0 && macd[idx] > ema[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);                
                lastTrend = currentTrend;
            }
        }
    }
}
