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
    
    public class MACD_HistogramRule:Rule
    {
        public Indicators.MACD macd;
        public DataSeries ema, hist;

        public MACD_HistogramRule(DataSeries ds, double fast, double slow, double signal)
        {
            macd = Indicators.MACD.Series(ds, fast, slow,signal, "macd");
            ema = macd.SignalSeries;
            hist = macd.HistSeries;
        }

        public override bool isValid()
        {
            return isValid_forBuy(macd.Count - 1);
        }

        public override bool isValid(int idx)
        {
            return isValid_forBuy(idx);
        }

        override public bool isValid_forBuy(int idx)
        {
            //Fixed by Dung  19 Nov 2011
            if (hist == null) return false;

            double delta = 0, lastDelta = 0;
            if (idx -2 < hist.FirstValidValue) return false;
            lastDelta = (hist[idx - 1] - hist[idx - 2]);
            delta = (hist[idx] - hist[idx - 1]);
            if (delta > 0 && lastDelta < 0)
                return true;
            return false;
        }

        override public bool isValid_forSell(int idx)
        {
            double delta = 0, lastDelta = 0;
            if (idx-2 < hist.FirstValidValue) return false;
            lastDelta = (hist[idx - 1] - hist[idx - 2]);
            delta = (hist[idx] - hist[idx - 1]);
            if (delta < 0 && lastDelta > 0)
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if (index - 1 < hist.FirstValidValue) return false;
            double delta = (hist[index] - hist[index - 1]);
            if (delta <= 0) return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index - 1 < hist.FirstValidValue) return false;
            double delta = (hist[index] - hist[index - 1]);
            if (delta > 0) return true;
            return false;
        }
    }

    public class MACD_HistogramSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            Rule rule = new MACD_HistogramRule(data.Close, parameters[0],parameters[1],parameters[2]);
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                wsData.BusinessInfo info = new wsData.BusinessInfo();
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
            MACD_HistogramRule rule = new MACD_HistogramRule(data.Close, parameters[0],parameters[1],parameters[2]);
            MoneyManagement riskManagement = new MoneyManagement(parameters[3], parameters[4], parameters[5]);

            for (int idx = rule.macd.FirstValidValue; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                if (rule.isValid_forSell(idx))
                    SellAtClose(idx);
                if (is_bought && riskManagement.CutLossCondition(data.Close[idx], buy_price))
                    SellCutLoss(idx);

                if (is_bought && riskManagement.TakeProfitCondition(data.Close[idx], buy_price))
                    SellTakeProfit(idx);

                if (riskManagement.TrailingStopLevel > 0)
                    riskManagement.TrailingStopWithBuyBack(this, rule, data.Close[idx], idx);
            }
        }
    }

    //public class MACD_Histogram_RiskMng : GenericStrategy
    //{        
    //    override protected void StrategyExecute()
    //    {
    //        MACD_HistogramRule rule = new MACD_HistogramRule(data.Close, parameters[0], parameters[1], parameters[2]);
    //        double cutlosslevel = parameters[3];
    //        double takeprofitlevel = parameters[4];

    //        for (int idx = rule.macd.FirstValidValue; idx < data.Close.Count - 1; idx++)
    //        {
    //            if (rule.isValid_forBuy(idx))
    //                BuyAtClose(idx);
    //            if (rule.isValid_forSell(idx))
    //                SellAtClose(idx);
    //            if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
    //                SellCutLoss(idx);

    //            if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
    //                SellTakeProfit(idx);
    //        }            
    //    }
    //}
}
