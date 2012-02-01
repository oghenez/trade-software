﻿//Copyright by NHQ, HCM city, 2011 
//Basic DMI strategy
//Buy when there is cut between DI+ and DI-
//The cut loss function work with some cut loss level

using application.Strategy;
using commonClass;

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
            if (Bar < adx.FirstValidValue) return;
            BusinessInfo info = new BusinessInfo();
            info.SetTrend(AppTypes.MarketTrend.Unspecified,
                AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
            info.Weight = adx[Bar];
            SelectStock(Bar, info);
        }
    }

    /// <summary>
    /// Rule using DMI indicator
    /// </summary>
    public class BasicDMIRule:Rule
    {
        public DataSeries minusDmi;
        public DataSeries plusDmi;
        public DataSeries adx,emaadx;
        public BasicDMIRule(DataBars db,double minusperiod,double plusperiod)
        {
            minusDmi = new Indicators.MinusDI(db, minusperiod, "minusDmi");
            plusDmi = new Indicators.PlusDI(db, plusperiod, "plusDmi");
            adx = new Indicators.ADX(db, minusperiod, "adx");
            emaadx = Indicators.EMA.Series(adx, 5, "emaadx");
        }
        public override bool isValid()
        {
            return isValid_forBuy(minusDmi.Count - 1);
        }

        public override bool isValid_forBuy(int idx)
        {
            if (UpTrend(idx ) && DownTrend(idx-1)&&(emaadx[idx]<adx[idx]))
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (UpTrend(idx - 1) && DownTrend(idx) && (emaadx[idx] < adx[idx]) )
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if (index < minusDmi.FirstValidValue) 
                return false;
            if (minusDmi[index] > plusDmi[index])
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index < minusDmi.FirstValidValue)
                return false;
            if (minusDmi[index] <= plusDmi[index])
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
            BasicDMIRule rule = new BasicDMIRule(data.Bars, parameters[0], parameters[1]);
            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[1], "max");

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target=max[idx];
                    info.Stop_Loss=min[idx];
                    BuyAtClose(idx,info);
                }
                else
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
            BasicDMIRule rule = new BasicDMIRule(data.Bars, parameters[0], parameters[1]);

            int cutlosslevel = (int)parameters[2];
            int takeprofitlevel = (int)parameters[3];

            for (int idx = rule.minusDmi.FirstValidValue; idx < rule.minusDmi.Count; idx++)
            {
                //Buy Condition
                if (rule.isValid_forBuy(idx))
                    BuyAtClose(idx);

                //Sell Condition
                if (rule.isValid_forSell(idx))
                    SellAtClose(idx);

                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
            }
        }
    }
    #   endregion
}