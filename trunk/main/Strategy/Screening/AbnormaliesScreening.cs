using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    public class AbnormaliesSCR_Helper : baseHelper
    {
        public AbnormaliesSCR_Helper() : base(typeof(AbnormaliesSCR)) { }
    }

    public class AbnormaliesSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int Bar = data.Close.Count - 1;
            if (Bar < data.Close.FirstValidValue) return;

            ////If Volume>2*Average Volume of 1 month
            Indicators.SMA smaVolume=new Indicators.SMA(data.Close,parameters[0],"sma");
            if (data.Volume[Bar]>1.5*smaVolume[Bar]){
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Volume[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
