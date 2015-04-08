using application.Strategy;
using commonClass;

namespace Strategy
{
    public class MACD_Histogram_Helper : baseHelper
    {
        public MACD_Histogram_Helper() : base(typeof(MACD_Histogram)) { }
    }

    /// <summary>
    /// Strategy MACD using histogram changed
    /// </summary>
    public class MACD_Histogram : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            MACD_HistogramRule rule = new MACD_HistogramRule(data.Close, parameters[0], parameters[1], parameters[2]);
            double cutlosslevel = parameters[3];
            double takeprofitlevel = parameters[4];

            for (int idx = rule.macd.FirstValidValue; idx < data.Close.Count - 1; idx++)
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
        }
    }  
}
