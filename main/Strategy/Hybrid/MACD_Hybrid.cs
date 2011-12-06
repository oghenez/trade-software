//Copyright by NHQ, HCM city, 2011 
using Indicators;
using application;
using commonClass;

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

            int cutlosslevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];
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

                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
                lastDelta = delta;
            }
        }
    }

    public class TwoSMAMACDSCR : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            TwoSMARule rule1 = new TwoSMARule(data.Close, (int)parameters[3], (int)parameters[4]);
            if (rule.isValid() && rule1.isValid())
            {
                int Bar = data.Close.Count - 1;
                BusinessInfo info = new BusinessInfo();
                info.Weight = rule.macd[Bar] * 100;
                SelectStock(Bar, info);
            }
        }
    }
}
