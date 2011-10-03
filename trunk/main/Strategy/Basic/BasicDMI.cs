//Copyright by NHQ, HCM city, 2011 
//Basic DMI strategy
//Buy when there is cut between DI+ and DI-
//The cut loss function work with some cut loss level

using application;

namespace Strategy
{
    #region DMI Helper
    public class BasicDMI_Helper : baseHelper
    {
        public BasicDMI_Helper() : base(typeof(BasicDMI))
        {
        }
    }

    public class BasicADX_Helper : baseHelper
    {
        public BasicADX_Helper()
            : base(typeof(BasicADXSCR))
        {
        }
    }

    public class BasicDMIScreening_Helper : baseHelper
    {
        public BasicDMIScreening_Helper() : base(typeof(BasicDMISCR))
        {
        }
    }

    public class BasicDMICutLoss_Helper : baseHelper
    {
        public BasicDMICutLoss_Helper() : base(typeof(BasicDMI_CutLoss))
        {
        }
    }
    #   endregion

    #region DMI Rule, Screening and Strategy

    public class BasicADXSCR : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            Indicators.ADX adx = new Indicators.ADX(data.Bars, parameters[0], "");
            int Bar = adx.Count - 1;
            if (Bar < 0) return;
            BusinessInfo info = new BusinessInfo();
            info.SetTrend(application.AppTypes.MarketTrend.Unspecified,
                application.AppTypes.MarketTrend.Unspecified, application.AppTypes.MarketTrend.Unspecified);
            info.Weight = adx[Bar];
            SelectStock(Bar, info);
        }
    }

    /// <summary>
    /// Rule using DMI indicator
    /// </summary>
    public class BasicDMIRule:Rule
    {
        public DataSeries minusDmi_14;
        public DataSeries plusDmi_14;
        public BasicDMIRule(DataBars db,double minusperiod,double plusperiod)
        {
            minusDmi_14 = new Indicators.MinusDI(db, minusperiod, "");
            plusDmi_14 = new Indicators.PlusDI(db, plusperiod, "");
        }
        public override bool isValid()
        {
            if (minusDmi_14.Count - 2 < 0)
                return false;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = minusDmi_14.Count - 2; idx < minusDmi_14.Count; idx++)
            {
                currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    return true;
                lastTrend = currentTrend;
            }

            return false;
        }

        public override bool isValid_forBuy(int idx)
        {
            if (idx - 1 < 0) return false;

            AppTypes.MarketTrend lastTrend = ((plusDmi_14[idx - 1] > minusDmi_14[idx - 1]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            AppTypes.MarketTrend currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);

            if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx - 1 < 0)
                return false;

            AppTypes.MarketTrend lastTrend = ((plusDmi_14[idx - 1] > minusDmi_14[idx - 1]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
            AppTypes.MarketTrend currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);

            if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                return true;
            return false;
        }
    }

    public class BasicDMISCR : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            Rule rule = new BasicDMIRule(data.Bars, parameters[0], parameters[1]);
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

    public class BasicDMI : GenericStrategy
    { 
        override protected void StrategyExecute()
        {
            Rule rule = new BasicDMIRule(data.Bars, parameters[0], parameters[1]);
            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[1], "max");

            for (int idx = 0; idx < data.Close.Count-1; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target=max[idx];
                    info.Stop_Loss=min[idx];
                    //info.Short_Target = NextTargetFibo(min[idx],max[idx],data.Close[idx]);
                    BuyAtClose(idx,info);
                }
                if (rule.isValid_forSell(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = min[idx];
                    info.Stop_Loss = max[idx];
                    SellAtClose(idx,info);
                }
            }
        }
    }

    public class BasicDMI_CutLoss : GenericStrategy
    { 
        override protected void StrategyExecute()
        {
            DataSeries minusDmi_14 = new Indicators.MinusDI(data.Bars, parameters[0], "");
            DataSeries plusDmi_14 = new Indicators.PlusDI(data.Bars, parameters[1], "");
            int cutlosslevel = (int)parameters[2];
            int takeprofitlevel = (int)parameters[3];

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 0; idx < minusDmi_14.Count; idx++)
            {
                currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                //Buy Condition
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);

                //Sell Condition
                if (is_bought && lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);

                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
                lastTrend = currentTrend;
            }
        }
    }
    #   endregion
}