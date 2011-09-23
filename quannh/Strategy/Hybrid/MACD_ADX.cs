//Copyright by NHQ, HCM city, 2011 
using Indicators;

namespace Strategy
{
    public class MACD_ADX_Helper : baseHelper
    {
        public MACD_ADX_Helper() : base(typeof(MACD_ADX)) { }
    }

    public class MACD_ADX_RiskMng_Helper : baseHelper
    {
        public MACD_ADX_RiskMng_Helper() : base(typeof(MACD_ADX_RiskMng)) { }
    }

    public class MACD_ADX : GenericStrategy
    {
        override protected void StrategyExecute()
        {            
            MACD macd = Indicators.MACD.Series(data.Close,
                parameters[0], parameters[1],
                parameters[2],"");

            ADX adx=new ADX(data.Bars,parameters[3],"");
            double delta = 0, lastDelta = 0;

            for (int idx = 1; idx < macd.Values.Length; idx++)
            {
                delta = (macd.HistSeries[idx] - macd.HistSeries[idx - 1]);
                //If there is a trend
                if (adx[idx] > 25)
                {
                    if (delta > 0 && lastDelta < 0)
                        BuyAtClose(idx);
                }
                if (delta < 0 && lastDelta > 0)
                    SellAtClose(idx);
                lastDelta = delta;
            }
        }
    }

    public class MACD_ADX_RiskMng : GenericStrategy
    {
        override protected void StrategyExecute()
        {            
            MACD macd = Indicators.MACD.Series(data.Close,
                parameters[0], parameters[1],
                parameters[2],"");

            ADX adx=new ADX(data.Bars,parameters[3],"");
            double delta = 0, lastDelta = 0;

            for (int idx = 1; idx < macd.Values.Length; idx++)
            {
                delta = (macd.HistSeries[idx] - macd.HistSeries[idx - 1]);
                //If there is a trend
                if (adx[idx] > 25)
                {
                    if (delta > 0 && lastDelta < 0)
                        BuyAtClose(idx);
                }
                if (delta < 0 && lastDelta > 0)
                    SellAtClose(idx);
                lastDelta = delta;
            }
        }
    }
}
