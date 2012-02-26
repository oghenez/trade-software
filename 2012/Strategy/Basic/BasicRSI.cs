using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application.Strategy;
using commonClass;
using commonTypes;
using application.Indicators;

namespace Strategy
{
    public class RSIOverSold_Helper : baseHelper
    {
        public RSIOverSold_Helper()
            : base(typeof(RSIOverSold))
        {
        }
    }

    public class RSIOverBought_Helper : baseHelper
    {
        public RSIOverBought_Helper()
            : base(typeof(RSIOverBought))
        {
        }
    }

    /// <summary>
    /// Define the rule based on RSI indicator
    /// </summary>
    class BasicRSI_Rule:Rule
    {
        public DataSeries rsi;
        double RSI_LOWER_LEVEL, RSI_UPPER_LEVEL;

        public BasicRSI_Rule(DataSeries ds, double rsi_period, double _rsi_lower, double _rsi_upper)
        {
            rsi = Indicators.RSI.Series(ds, rsi_period, "rsi");
            RSI_LOWER_LEVEL = _rsi_lower;
            RSI_UPPER_LEVEL = _rsi_upper;
        }

        public override bool isValid_forBuy(int idx)
        {
            if (idx-1 < rsi.FirstValidValue) return false;
            if ((rsi[idx] > RSI_LOWER_LEVEL)&&(rsi[idx-1]<=RSI_LOWER_LEVEL))
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx < rsi.FirstValidValue) return false;
            if ((rsi[idx-1] >= RSI_UPPER_LEVEL)&&(rsi[idx]<RSI_UPPER_LEVEL))
                return true;
            return false;
        }

        public override bool isValid()
        {
            return isValid_forBuy(rsi.Count - 1);
        }

        public override bool isValid(int index)
        {
            return isValid_forBuy(index);
        }
    }

    public class RSIOverSold : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            //BasicRSI_Rule rule = new BasicRSI_Rule(data.Close, parameters[0], parameters[1], parameters[2]);
            DataSeries rsi = Indicators.RSI.Series(data.Close, parameters[0], "rsi");
            double OVERSOLD_LEVEL=parameters[1];
            int Bar = data.Close.Count - 1;
            if (Bar < rsi.FirstValidValue) return;

            if (rsi[Bar] < OVERSOLD_LEVEL)
            {
                BusinessInfo info = new BusinessInfo();
                info.SetTrend(AppTypes.MarketTrend.Unspecified,
                    AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }

    public class RSIOverBought : GenericStrategy
    {
        protected override void StrategyExecute()
        {
            //BasicRSI_Rule rule = new BasicRSI_Rule(data.Close, parameters[0], parameters[1], parameters[2]);
            DataSeries rsi = Indicators.RSI.Series(data.Close, parameters[0], "rsi");
            double OVERBOUGHT_LEVEL = parameters[1];
            int Bar = data.Close.Count - 1;
            if (Bar < rsi.FirstValidValue) return;

            if (rsi[Bar] > OVERBOUGHT_LEVEL)
            {
                BusinessInfo info = new BusinessInfo();
                info.SetTrend(AppTypes.MarketTrend.Unspecified,
                    AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
