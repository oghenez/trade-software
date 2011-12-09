﻿//Copyright by NHQ, HCM city, 2011 
using application;

namespace Strategy
{
    public class RSI_MACD_Histogram_Helper : baseHelper
    {
        public RSI_MACD_Histogram_Helper() : base(typeof(RSI_MACD_Histogram)) { }
    }

    public class TwoRSI_MACD_Hist_Helper : baseHelper
    {
        public TwoRSI_MACD_Hist_Helper() : base(typeof(TwoRSI_MACD_Histogram)) { }
    }

    public class RSI_MACD_Histogram : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int fast_macd = (int)parameters[0];
            int slow_macd = (int)parameters[1];
            int signal_macd = (int)parameters[2];

            int rsi_period = (int)parameters[3];
            int RSI_LOWER_LEVEL = (int)parameters[4];
            int RSI_UPPER_LEVEL = (int)parameters[5];
            int cutlosslevel = (int)parameters[6];
            int takeprofitlevel = (int)parameters[7];

            //double delta = 0, lastDelta = 0;

            //DataSeries line1 = Indicators.RSI.Series(data.Close, rsi_period, "");
            //Indicators.MACD macd = Indicators.MACD.Series(data.Close, fast_macd, slow_macd, signal_macd, "");
            //DataSeries hist = macd.HistSeries;

            MACD_HistogramRule macdrule = new MACD_HistogramRule(data.Close, fast_macd, slow_macd, signal_macd);
            BasicRSI_Rule rsirule = new BasicRSI_Rule(data.Close, rsi_period, RSI_LOWER_LEVEL, RSI_UPPER_LEVEL);
          
            for (int idx = 1; idx < data.Close.Count; idx++)
            {
                if (rsirule.isValid_forBuy(idx)||macdrule.isValid_forBuy(idx))
                    BuyAtClose(idx);
                if (rsirule.isValid_forSell(idx) || macdrule.isValid_forSell(idx))
                    SellAtClose(idx);
                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);
                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
            }

            //for (int idx = 1; idx < line1.Count; idx++)
            //{
            //    delta = (hist[idx] - hist[idx - 1]);
            //    if (line1[idx] < RSI_LOWER_LEVEL && delta > 0 && lastDelta < 0)
            //        BuyAtClose(idx);
            //    if (is_bought)
            //        if ((delta < 0 && lastDelta > 0) || line1[idx] > RSI_UPPER_LEVEL)
            //            SellAtClose(idx);
            //    if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
            //        SellCutLoss(idx);

            //    if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
            //        SellTakeProfit(idx);

            //    lastDelta = delta;
            //}
        }
    }

    public class TwoRSI_MACD_Histogram : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int fast_macd = (int)parameters[0];
            int slow_macd = (int)parameters[1];
            int signal_macd = (int)parameters[2];

            int rsi_period = (int)parameters[3];
            int RSI_LOWER_LEVEL = (int)parameters[4];
            int RSI_UPPER_LEVEL = (int)parameters[5];
            int cutlosslevel = (int)parameters[6];
            int takeprofitlevel = (int)parameters[7];

            MACD_HistogramRule macdrule = new MACD_HistogramRule(data.Close, fast_macd, slow_macd, signal_macd);
            BasicRSI_Rule rsirule = new BasicRSI_Rule(data.Close, rsi_period, RSI_LOWER_LEVEL, RSI_UPPER_LEVEL);
            
            TwoSMARule rule = new TwoSMARule(rsirule.rsi, 5,10);

            for (int idx = 1; idx < data.Close.Count; idx++)
            {
                //if (rsirule.isValid_forBuy(idx) && macdrule.isValid_forBuy(idx))
                //    BuyAtClose(idx);
                //if (rsirule.isValid_forSell(idx) || macdrule.isValid_forSell(idx))
                //    SellAtClose(idx);
                if (rule.isValid_forBuy(idx)&&
                    macdrule.isValid_forBuy(idx))
                        BuyAtClose(idx);
                if (rule.isValid_forSell(idx) || macdrule.isValid_forSell(idx))
                    SellAtClose(idx);
                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);
                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
            }            
        }
    }
}
