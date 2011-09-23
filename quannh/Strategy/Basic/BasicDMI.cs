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

    public class BasicDMIScreening_Helper : baseHelper
    {
        public BasicDMIScreening_Helper() : base(typeof(BasicDMIScreening))
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
    public class BasicDMIScreening : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            DataSeries minusDmi_14 = new Indicators.MinusDI(data.Bars, parameters[0], "");
            DataSeries plusDmi_14 = new Indicators.PlusDI(data.Bars, parameters[1], "");

            if (minusDmi_14.Count - 2 < 0)
                return;

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = minusDmi_14.Count - 2; idx < minusDmi_14.Count; idx++)
            {
                currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(currentTrend, currentTrend, currentTrend);
                    info.Weight = data.Close[idx];
                    SelectStock(idx, info);
                }
                lastTrend = currentTrend;
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