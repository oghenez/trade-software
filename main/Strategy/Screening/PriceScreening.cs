using System;
using System.Collections.Generic;
using System.Text;
using application.Strategy;
using commonClass;

namespace Strategy
{
    public class PriceChangeSCR_Helper : baseHelper
    {
        public PriceChangeSCR_Helper() : base(typeof(PriceChangeSCR)) { }
    }

    public class PriceSCR_Helper : baseHelper
    {
        public PriceSCR_Helper() : base(typeof(PriceSCR)) { }
    }

    public class BasicPriceSCR_Helper : baseHelper
    {
        public BasicPriceSCR_Helper() : base(typeof(BasicPriceSCR)) { }
    }

    public class BasicVolumeSCR_Helper : baseHelper
    {
        public BasicVolumeSCR_Helper() : base(typeof(BasicVolumeSCR)) { }
    }

    public class VolumeSCR_Helper : baseHelper
    {
        public VolumeSCR_Helper() : base(typeof(VolumeSCR)) { }
    }


    public class BasicPriceSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int Bar = data.Close.Count - 1;
            if (Bar <= 1) return;
            BusinessInfo info = new BusinessInfo();
            info.Weight = data.Close[Bar];
            SelectStock(Bar, info);
        }
    }

    public class PriceChangeSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int Bar = data.Close.Count - 1;
            int period = (int)parameters[0];//period la gia cua Bar phia truoc, default=30
            if (Bar-period < 0) return;

            //Tim cac stocks co Price hom nay lon hon SMA
            BusinessInfo info = new BusinessInfo();
            if (data.Close[Bar - period] != 0)
                info.Weight = (data.Close[Bar] - data.Close[Bar - period]) / data.Close[Bar - period] * 100;
            else
                info.Weight = double.NegativeInfinity;
            SelectStock(Bar, info);
        }
    }

    public class PriceSCR : GenericStrategy 
    {
        override protected void StrategyExecute()
        {
            int Bar = data.Close.Count-1;
            if (Bar <= 1) return;

            int period = (int)parameters[0];
            DataSeries sma = Indicators.SMA.Series(data.Close,period,"");

            //Tim cac stocks co Price hom nay lon hon SMA
            if (data.Close[Bar] > sma[Bar])
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }

    public class BasicVolumeSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int Bar = data.Close.Count - 1;
            if (Bar <= 1) return;
            BusinessInfo info = new BusinessInfo();
            info.Weight = data.Volume[Bar];
            SelectStock(Bar, info);
        }
    }

    public class VolumeSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int Bar = data.Close.Count - 1;
            if (Bar <= 1) return;

            //Tim cac stocks co volume hom nay lon hon hom truoc
            if (data.Volume[Bar] > data.Volume[Bar - 1])
            {
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Volume[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
