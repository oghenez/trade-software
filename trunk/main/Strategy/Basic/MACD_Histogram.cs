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

    public class MACD_HistogramRule:Rule
    {
        public Indicators.MACD macd;
        public DataSeries ema, hist;

        public MACD_HistogramRule(DataSeries ds,Parameters parameters)
        {
            macd = Indicators.MACD.Series(ds, parameters[0], parameters[1], parameters[2], "");
            ema = macd.SignalSeries;
            hist = macd.HistSeries;
        }

        public override bool isValid()
        {
            decimal delta = 0, lastDelta = 0;
            int idx = macd.Count - 1;
            if (idx < 2) return false;
            lastDelta = (decimal)(hist[idx - 1] - hist[idx - 2]); 
            delta = (decimal)(hist[idx] - hist[idx - 1]);
            if (delta > 0 && lastDelta < 0)
                return true;     
            return false;
        }

        public override bool isValid(int idx)
        {
            decimal delta = 0, lastDelta = 0;
            if (idx < 2) return false;
            lastDelta = (decimal)(hist[idx - 1] - hist[idx - 2]);
            delta = (decimal)(hist[idx] - hist[idx - 1]);
            if (delta > 0 && lastDelta < 0)
                return true;
            return false;
        }

        override public bool isValid_forBuy(int idx)
        {
            decimal delta = 0, lastDelta = 0;
            if (idx < 2) return false;
            lastDelta = (decimal)(hist[idx - 1] - hist[idx - 2]);
            delta = (decimal)(hist[idx] - hist[idx - 1]);
            if (delta > 0 && lastDelta < 0)
                return true;
            return false;
        }

        override public bool isValid_forSell(int idx)
        {
            decimal delta = 0, lastDelta = 0;
            if (idx < 2) return false;
            lastDelta = (decimal)(hist[idx - 1] - hist[idx - 2]);
            delta = (decimal)(hist[idx] - hist[idx - 1]);
            if (delta < 0 && lastDelta > 0)
                return true;
            return false;
        }
    }

    public class MACD_HistogramSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            Rule rule = new MACD_HistogramRule(data.Close, parameters);
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }            
        }
    }

    /// <summary>
    /// Strategy MACD using histogram changed
    /// </summary>
    public class MACD_Histogram : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            MACD_HistogramRule rule = new MACD_HistogramRule(data.Close, parameters);

            for (int idx = 1; idx < data.Close.Count-1; idx++)
            {
                if (rule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                if (rule.isValid_forSell(idx))
                    SellAtClose(idx);                
            }
        }
    }

    public class MACD_Histogram_RiskMng : GenericStrategy
    {        
        override protected void StrategyExecute()
        {
            MACD_HistogramRule rule = new MACD_HistogramRule(data.Close, parameters);
            int cutlosslevel = (int)parameters[3];
            int takeprofitlevel = (int)parameters[4];

            for (int idx = 1; idx < data.Close.Count - 1; idx++)
            {
                if (rule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                if (rule.isValid_forSell(idx))
                    SellAtClose(idx);
                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
            }
            //Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[0], parameters[1], parameters[2], "");
            //DataSeries hist = macd.HistSeries;

            //int cutlosslevel = (int)parameters[3];
            //int takeprofitlevel = (int)parameters[4];

            //decimal delta = 0, lastDelta = 0;
            //for (int idx = 1; idx < macd.Count; idx++)
            //{
            //    delta = (decimal)(hist[idx] - hist[idx - 1]);
            //    if (delta > 0 && lastDelta < 0)
            //        BuyAtClose(idx);
            //    if (delta < 0 && lastDelta > 0)
            //        SellAtClose(idx);

            //    if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
            //        SellCutLoss(idx);

            //    if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
            //        SellTakeProfit(idx);
            //    lastDelta = delta;
            //}
        }
    }
}
