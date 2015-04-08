using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{
    /// <summary>
    /// Rule using DMI indicator
    /// </summary>
    public class BasicATRRule : Rule
    {
        DataSeries atr;
        DataBars data;
        public BasicATRRule(DataBars db, double period, string name)
        {
            atr = Indicators.ATR.Series(db, period, name);
            data = db;
        }
        public override bool isValid()
        {
            return isValid_forBuy(atr.Count - 1);
        }

        public override bool isValid_forBuy(int idx)
        {
            if (idx - 1 < data.Close.FirstValidValue) return false;
            if (data.Close[idx] > atr[idx] + data.Close[idx - 1])
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx - 1 < data.Close.FirstValidValue) return false;
            if (data.Close[idx] < -atr[idx] + data.Close[idx - 1])
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            return false;
        }

        public override bool UpTrend(int index)
        {
            return false;
        }
    }
}
