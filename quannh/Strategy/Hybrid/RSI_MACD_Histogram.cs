//Copyright by NHQ, HCM city, 2011 
using application;

namespace Strategy
{
    public class RSI_MACD_Histogram_Helper : baseHelper
    {
        public RSI_MACD_Histogram_Helper() : base(typeof(RSI_MACD_Histogram)) { }
    }

    public class RSI_MACD_Histogram : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int fast_macd=parameters[0];
            int slow_macd = parameters[1];
            int signal_macd= parameters[2];
            
            int rsi_period = parameters[3];
            int RSI_LOWER_LEVEL = parameters[4];
            int RSI_UPPER_LEVEL = parameters[5];
            int cutlosslevel = parameters[6];
            int takeprofitlevel = parameters[7];

            double delta = 0, lastDelta = 0;
            
            DataSeries line1 = Indicators.RSI.Series(data.Close,rsi_period,"");
            Indicators.MACD macd = Indicators.MACD.Series(data.Close, fast_macd, slow_macd, signal_macd, "");
            DataSeries hist = macd.HistSeries;

            for (int idx = 1; idx < line1.Count; idx++)
            {
                delta = (hist[idx] - hist[idx - 1]);
                if (line1[idx] < RSI_LOWER_LEVEL && delta > 0 && lastDelta < 0)
                    BuyAtClose(idx);
                if (is_bought)
                    if ((delta < 0 && lastDelta > 0) || line1[idx] > RSI_UPPER_LEVEL)
                        SellAtClose(idx);
                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);

                lastDelta = delta;
            }
        }
    }
}
