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
            : base(typeof(RSIOverSoldSCR))
        {
        }
    }

    public class RSIOverBought_Helper : baseHelper
    {
        public RSIOverBought_Helper()
            : base(typeof(RSIOverBoughtSCR))
        {
        }
    }    

    public class RSIOverSoldSCR : GenericStrategy
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

    public class RSIOverBoughtSCR : GenericStrategy
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
