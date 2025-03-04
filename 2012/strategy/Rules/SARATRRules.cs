﻿using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{
    public class SARATRRules : CompositeRule
    {
        public SARATRRules(DataBars db, double atrperiod, double optInAcc, double optLnMax)
        {
            rules = new Rule[2];
            rules[0] = new BasicSARRule(db, optInAcc, optLnMax);
            rules[1] = new BasicATRRule(db, atrperiod, "atr");
        }

        public override bool DownTrend(int index)
        {
            if (rules[0].DownTrend(index))
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            return (rules[0].UpTrend(index));
        }

        public override bool isValid_forBuy(int index)
        {
            if (rules[1].isValid_forBuy(index) && rules[0].UpTrend(index))
                return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (rules[0].isValid_forSell(index) || rules[1].isValid_forSell(index))
                return true;
            return false;
        }
    }
}
