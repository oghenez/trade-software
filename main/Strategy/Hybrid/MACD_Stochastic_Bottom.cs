//Copyright by NHQ, HCM city, 2011 
using application;
using commonClass;

namespace Strategy
{
    public class MACD_Stochastic_Bottom_Helper : baseHelper
    {
        public MACD_Stochastic_Bottom_Helper() : base(typeof(MACD_Stochastic_Bottom)) { }
    }

    public class MACD_Stochastic_Bottom_v1_Helper : baseHelper
    {
        public MACD_Stochastic_Bottom_v1_Helper() : base(typeof(MACD_Stochastic_Bottom_v1)) { }
    }

    public class MACD_Stochastic_Bottom : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries sma20 = Indicators.SMA.Series(data.Close, parameters[0], "");

            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[1], parameters[2],
                parameters[3], "");
            DataSeries hist = macd.HistSeries;

            Indicators.Stoch stoch = Indicators.Stoch.Series(data.Bars, parameters[4], parameters[5],
                parameters[6], "");

            DataSeries line1 = stoch.SlowKSeries;
            DataSeries line2 = stoch.SlowDSeries;

            double delta = 0, lastDelta = 0;
            bool macd_swicth_to_up_trend = false, macd_swicth_to_down_trend = false, sto_switch_to_up_trend = false, sto_switch_to_down_trend = false;


            AppTypes.MarketTrend stochasticTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 1; idx < macd.Count; idx++)
            {
                delta = (hist[idx] - hist[idx - 1]);
                macd_swicth_to_up_trend = (delta > 0 && lastDelta < 0 ? true : false);
                macd_swicth_to_down_trend = (delta < 0 && lastDelta > 0 ? true : false);
                stochasticTrend = (line1[idx] > line2[idx] ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                sto_switch_to_up_trend = (line1[idx] > line2[idx]) && (line1[idx - 1] < line2[idx - 1]) ? true : false;
                sto_switch_to_down_trend = (line1[idx] < line2[idx]) && (line1[idx - 1] > line2[idx - 1]) ? true : false;


                if (!is_bought && data.Close[idx] > sma20[idx])
                    if ((macd_swicth_to_up_trend || sto_switch_to_up_trend) && (line1[idx] < 70))
                        BuyAtClose(idx);

                if (is_bought)
                    if (sto_switch_to_down_trend || macd_swicth_to_down_trend)
                        SellAtClose(idx);
                lastDelta = delta;
            }
        }
    }

    public class MACD_Stochastic_Bottom_v1 : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries sma20 = Indicators.SMA.Series(data.Close, parameters[0], "");

            Indicators.MACD macd = Indicators.MACD.Series(data.Close, parameters[1], parameters[2],
                parameters[3], "");
            DataSeries hist = macd.HistSeries;

            Indicators.Stoch stoch = Indicators.Stoch.Series(data.Bars, parameters[4], parameters[5],
                parameters[6], "");

            DataSeries line1 = stoch.SlowKSeries;
            DataSeries line2 = stoch.SlowDSeries;

            double delta = 0, lastDelta = 0;
            bool macd_swicth_to_up_trend = false, macd_swicth_to_down_trend = false, sto_switch_to_up_trend = false, sto_switch_to_down_trend = false;


            AppTypes.MarketTrend stochasticTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 1; idx < macd.Count; idx++)
            {
                delta = (hist[idx] - hist[idx - 1]);
                macd_swicth_to_up_trend = (delta > 0 && lastDelta < 0 ? true : false);
                macd_swicth_to_down_trend = (delta < 0 && lastDelta > 0 ? true : false);
                stochasticTrend = (line1[idx] > line2[idx] ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                sto_switch_to_up_trend = (line1[idx] > line2[idx]) && (line1[idx - 1] < line2[idx - 1]) ? true : false;
                sto_switch_to_down_trend = (line1[idx] < line2[idx]) && (line1[idx - 1] > line2[idx - 1]) ? true : false;


                if (!is_bought && data.Close[idx] > sma20[idx])
                    if (macd_swicth_to_up_trend && stochasticTrend == AppTypes.MarketTrend.Downward)
                        BuyAtClose(idx);

                if (is_bought)
                    if (sto_switch_to_down_trend || macd_swicth_to_down_trend)
                        SellAtClose(idx);
                lastDelta = delta;
            }
        }
    }
}
