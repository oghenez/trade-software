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

    #region DMI Screening and Strategy

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

    public class BasicDMIRule:Rule
    {
        public DataSeries minusDmi_14;
        public DataSeries plusDmi_14;
        public BasicDMIRule(DataBars db,int minusperiod,int plusperiod)
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
            DataSeries minusDmi_14 = new Indicators.MinusDI(data.Bars, parameters[0], "");
            DataSeries plusDmi_14 = new Indicators.PlusDI(data.Bars, parameters[1], "");

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 0; idx < minusDmi_14.Count; idx++)
            {
                currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }

    public class BasicDMI_CutLoss : GenericStrategy
    { 
        override protected void StrategyExecute()
        {
            DataSeries minusDmi_14 = new Indicators.MinusDI(data.Bars, parameters[0], "");
            DataSeries plusDmi_14 = new Indicators.PlusDI(data.Bars, parameters[1], "");
            int cutlosslevel = parameters[2]; 
            int takeprofitlevel=parameters[3];

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