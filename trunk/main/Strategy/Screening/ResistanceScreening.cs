using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application.Strategy;
using commonClass;

namespace Strategy
{
    public class SupportSCR_Helper : baseHelper
    {
        public SupportSCR_Helper() : base(typeof(SupportSCR)) { }
    }

    public class ResistanceSCR_Helper : baseHelper
    {
        public ResistanceSCR_Helper() : base(typeof(ResistanceSCR)) { }
    }

    class SupportSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int period = (int)parameters[0];
            double distance = (double)parameters[1];

            int Bar = data.Close.Count - 1;
            if (Bar <= 1) return;
            double support = strategyLib.findSupport(data.Close, Bar, period);
            if (support == -1) return;
            if ((data.Close[Bar] - support) / support*100 < distance)
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = support;
                SelectStock(Bar, info);
            }
        }
    }

    class ResistanceSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int period = (int)parameters[0];
            double distance = (double)parameters[1];

            int Bar = data.Close.Count - 1;
            if (Bar <= 1) return;
            double resistance = strategyLib.findResistance(data.Close, Bar, period);
            if (resistance == -1) return;

            if ((resistance - data.Close[Bar]) / data.Close[Bar]*100 < distance)
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = resistance;
                SelectStock(Bar, info);
            }
        }
    }
}
