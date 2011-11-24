using application;

namespace Strategy
{
    public class BasicStochRSI_Helper : baseHelper
    {
        public BasicStochRSI_Helper()
            : base(typeof(BasicStochRSI))
        {
        }
    }

    /// <summary>
    /// Define rule using stochRSI indicator
    /// </summary>
    public class BasicStochRSIRule : Rule
    {
        public Indicators.StochRSI stochRsi;
        DataSeries fastDSeries, fastKSeries;
        public BasicStochRSIRule(DataSeries ds,double rsiPeriod,double fastK,double fastD)
        {
            stochRsi = new Indicators.StochRSI(ds, rsiPeriod, fastK, fastD, "stochRSI");
            fastDSeries = stochRsi.FastDSeries;
            fastKSeries = stochRsi.FastKSeries;
        }

        public override bool UpTrend(int index)
        {
            if (index < stochRsi.FirstValidValue) return false;
            if (fastKSeries[index] > fastDSeries[index])
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if (index < stochRsi.FirstValidValue) return false;
            if (fastKSeries[index] <= fastDSeries[index])
                return true;
            return false;
        }

        public override bool isValid_forBuy(int index)
        {
            if (DownTrend(index - 1) && UpTrend(index))
                return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (DownTrend(index) && UpTrend(index-1))
                return true;
            return false;
        }
    }

    public class BasicStochRSI:GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicStochRSIRule rule = new BasicStochRSIRule(data.Close, parameters[0], parameters[1],parameters[2]);
            int cutlosslevel = (int)parameters[3];
            int trailingstoplevel = (int)parameters[4];
            int takeprofitlevel = (int)parameters[5];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");


            for (int idx = rule.stochRsi.FirstValidValue; idx < rule.stochRsi.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                if (rule.isValid_forSell(idx))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
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
            }
        }
    }
}
