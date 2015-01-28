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
    /// <summary>
    /// Define the rule based on RSI indicator
    /// </summary>
    class BasicRSI_Rule : Rule
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
            if (idx - 1 < rsi.FirstValidValue) return false;
            if ((rsi[idx] > RSI_LOWER_LEVEL) && (rsi[idx - 1] <= RSI_LOWER_LEVEL))
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx < rsi.FirstValidValue) return false;
            if ((rsi[idx - 1] >= RSI_UPPER_LEVEL) && (rsi[idx] < RSI_UPPER_LEVEL))
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
}
