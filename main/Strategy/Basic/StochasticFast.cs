using application.Strategy;
using commonClass;

namespace Strategy
{
    public class StochFastSCR_Helper : baseHelper
    {
        public StochFastSCR_Helper() : base(typeof(StochFastSCR)) { }
    }

    public class StochasticFast_Helper : baseHelper
    {
        public StochasticFast_Helper() : base(typeof(StochasticFast)) { }
    }

    public class StockFastRule : Rule
    {
        public Indicators.StochF stoch;
        public DataSeries fastK, fastD;

        public StockFastRule(DataBars db,double _fastK,double _fastD,string _name)
        {
            stoch = Indicators.StochF.Series(db, _fastK,_fastD,_name);
            fastK = stoch.FastKSeries;
            fastD = stoch.FastDSeries;
        }

        public override bool  isValid()
        {
            if (fastK.Count < 2) return false;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = fastK.Count - 2; idx < fastK.Count; idx++)
            {
                currentTrend = ((fastK[idx] > fastD[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    return true;
                lastTrend = currentTrend;
            }

            return false;
        }

        public override bool UpTrend(int index)
        {
            if (fastK.Count < 1) return false;

            if (fastK[index] > fastD[index]) return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if (fastK.Count < 1) return false;

            if (fastK[index] < fastD[index]) return true;
            return base.DownTrend(index);
        }

        public override bool isValid_forBuy(int index)
        {
            if (UpTrend(index) && DownTrend(index - 1)) return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (UpTrend(index-1) && DownTrend(index)) return true;
            return false;
        }
    }

     public class StochFastSCR : GenericStrategy
     {
         override protected void StrategyExecute()
         {
             StockFastRule rule = new StockFastRule(data.Bars, parameters[0],parameters[1],"stoch");
             int Bar = data.Close.Count - 1;
             if (rule.isValid_forBuy(Bar))
             {
                 BusinessInfo info = new BusinessInfo();
                 info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                 info.Weight = data.Close[Bar];
                 SelectStock(Bar, info);
             }
         }
     }

    /// <summary>
    /// Strategy using stochastic fast
    /// </summary>
     public class StochasticFast : GenericStrategy
     {
         override protected void StrategyExecute()
         {
             StockFastRule rule = new StockFastRule(data.Bars, parameters[0], parameters[1], "stoch");
             int cutlosslevel = (int)parameters[2];
             int trailingstoplevel = (int)parameters[3];
             int takeprofitlevel = (int)parameters[4];

             Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
             Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

             for (int idx = 0; idx < data.Close.Count; idx++)
             {
                 if (rule.isValid_forBuy(idx))
                 {
                     BusinessInfo info = new BusinessInfo();
                     info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                     info.Short_Target = max[idx];
                     info.Stop_Loss = min[idx];
                     BuyAtClose(idx, info);
                 }
                 else
                     if (rule.isValid_forSell(idx))
                     {
                         BusinessInfo info = new BusinessInfo();
                         info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                         info.Short_Target = min[idx];
                         info.Stop_Loss = max[idx];
                         SellAtClose(idx, info);
                     }
                 if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                     SellCutLoss(idx);

                 if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                     SellTakeProfit(idx);

                 if (trailingstoplevel > 0)
                     TrailingStopWithBuyBack(rule, data.Close[idx], trailingstoplevel, idx);
                 //Indicators.StochF stoch = Indicators.StochF.Series(data.Bars, parameters[0], parameters[1], "");
                 //DataSeries line1 = stoch.FastKSeries;
                 //DataSeries line2 = stoch.FastDSeries;
                 //AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
                 //AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

                 //for (int idx = 0; idx < line1.Count; idx++)
                 //{
                 //    currentTrend = ((line1[idx] > line2[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                 //    if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                 //        BuyAtClose(idx);
                 //    if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                 //        SellAtClose(idx);
                 //    lastTrend = currentTrend;
                 //}
             }
         }
     }
}
