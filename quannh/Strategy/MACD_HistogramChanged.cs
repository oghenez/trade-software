using application;

namespace Strategy
{
    public class MACD_Histogram_Helper : baseHelper
    {
        public MACD_Histogram_Helper() : base(typeof(MACD_Histogram)) { }
    }

    public class MACD_HistogramSCR_Helper : baseHelper
    {
        public MACD_HistogramSCR_Helper() : base(typeof(MACD_HistogramSCR)) { }
    }
    
    public class MACD_Histogram_RiskMng_Helper : baseHelper
    {
        public MACD_Histogram_RiskMng_Helper() : base(typeof(MACD_Histogram_RiskMng)) { }
    }
    public class MACD_HistogramSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[0], parameters[1], parameters[2], "");
            DataSeries ema = macd.SignalSeries;
            DataSeries hist = macd.HistSeries;

            decimal delta = 0, lastDelta = 0;
            int idx = macd.Count - 1;
            if (idx < 2) return;
            lastDelta = (decimal)(hist[idx-1] - hist[idx - 2]);;
            delta = (decimal)(hist[idx] - hist[idx - 1]);
            if (delta > 0 && lastDelta < 0)
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[idx];
                SelectStock(idx,info);
            }            
        }
    }

    public class MACD_Histogram:GenericStrategy
    {
        override protected void StrategyExecute()
        {
            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[0], parameters[1], parameters[2], "");
            DataSeries ema = macd.SignalSeries;
            DataSeries hist = macd.HistSeries;

            double delta = 0, lastDelta = 0;
            for (int idx = 1; idx < macd.Count; idx++)
            {
                delta = (hist[idx] - hist[idx - 1]);
                if (delta > 0 && lastDelta < 0)
                    BuyAtClose(idx);
                if (delta < 0 && lastDelta > 0)
                    SellAtClose(idx);
                lastDelta = delta;
            }
        }
    }

    public class MACD_Histogram_RiskMng : GenericStrategy
    {        
        override protected void StrategyExecute()
        {
            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[0], parameters[1], parameters[2], "");
            DataSeries hist = macd.HistSeries;

            int cutlosslevel=parameters[3];
            int takeprofitlevel = parameters[4];

            decimal delta = 0, lastDelta = 0;
            for (int idx = 1; idx < macd.Count; idx++)
            {
                delta = (decimal)(hist[idx] - hist[idx - 1]);
                if (delta > 0 && lastDelta < 0)
                    BuyAtClose(idx);
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
}
