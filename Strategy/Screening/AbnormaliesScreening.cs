using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

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
            Indicators.SMA smaVolume=new Indicators.SMA(data.Volume,parameters[0],"smaVolume");
            double Multi = parameters[1];
            if (data.Volume[Bar]>Multi*smaVolume[Bar]){
                wsData.BusinessInfo info = new wsData.BusinessInfo();
                info.Weight = data.Volume[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
