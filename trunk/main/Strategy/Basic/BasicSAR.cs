//Copyright by NHQ, HCM city, 2011 
//Basic DMI strategy
//Buy when there is cut between DI+ and DI-
//The cut loss function work with some cut loss level

using application;

namespace Strategy
{
    #region DMI Helper
    public class BasicSAR_Helper : baseHelper
    {
        public BasicSAR_Helper()
            : base(typeof(BasicSAR))
        {
        }
    }

    public class HybridSAR_Helper : baseHelper
    {
        public HybridSAR_Helper()
            : base(typeof(HybridSAR))
        {
        }
    }

    public class BasicSARScreening_Helper : baseHelper
    {
        public BasicSARScreening_Helper()
            : base(typeof(BasicSARSCR))
        {
        }
    }   
    #   endregion

    #region DMI Rule, Screening and Strategy

    

    /// <summary>
    /// Rule using SAR indicator
    /// </summary>
    public class BasicSARRule : Rule
    {
        public DataSeries sar;
        public DataSeries close;
        public BasicSARRule(DataBars db, double optInAcc,double optLnMax)
        {
            sar = new Indicators.SAR(db, optInAcc,optLnMax, "sar");
            close = db.Close;
        }

        public override bool isValid()
        {
            return isValid_forBuy(sar.Count-1);
        }

        public override bool isValid_forBuy(int idx)
        {
            if (idx < sar.FirstValidValue)
                return false;
            if (close[idx] > sar[idx])
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx < sar.FirstValidValue)
                return false;
            if (close[idx] < sar[idx])
                return true;
            return false;
        }
    }

    public class BasicSARSCR : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            Rule rule = new BasicSARRule(data.Bars, parameters[0], parameters[1]);
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                BusinessInfo info = new BusinessInfo();
                info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }

    public class HybridSAR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicSARRule sarRule = new BasicSARRule(data.Bars, parameters[0], parameters[1]);
            //TwoSMARule smarule = new TwoSMARule(data.Close, 5, 10);
            BasicDMIRule dmiRule = new BasicDMIRule(data.Bars, 14, 14);

            int cutlosslevel = (int)parameters[2];
            int takeprofitlevel = (int)parameters[3];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[1], "max");

            for (int idx = 0; idx < data.Close.Count - 1; idx++)
            {
                //if ((!is_bought)&&((rule.isValid_forBuy(idx)||smarule.isValid_forBuy(idx))))
                if (dmiRule.isValid_forBuy(idx)&&sarRule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                //if (is_bought &&(rule.isValid_forSell(idx)||smarule.isValid_forSell(idx)))
                if (dmiRule.isValid_forSell(idx))
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
            }
        }
    }

    public class BasicSAR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicSARRule rule = new BasicSARRule(data.Bars, parameters[0], parameters[1]);
            int cutlosslevel = (int)parameters[2];
            int takeprofitlevel = (int)parameters[3];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[1], "max");

            for (int idx = 0; idx < data.Close.Count - 1; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
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
            }
        }
    }    
    #   endregion
}