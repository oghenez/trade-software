using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    class RelativeStrength_Helper : baseHelper
    {
        public RelativeStrength_Helper() : base(typeof(RelativeStrengthSCR)) { }
    }

    class RelativeStrengthSCR: GenericStrategy
    {
        override protected void StrategyExecute()
        {
            int Bar = data.Close.Count - 1;
            if (Bar <= 1) return;
            // Dong sau tao mot data moi cua ^VNINDEX 
            application.Data vnidxData = data.New("^VNINDEX");
            int Barindex = vnidxData.Close.Count - 1;
            if (Barindex <= 1) return;
//            if (Bar == vnidxData.Close.Count - 1)
            {

                int period = (int)parameters[0];

                Indicators.ROCR100 roc = Indicators.ROCR100.Series(data.Close, period, "");
                Indicators.ROCR100 roc_index = Indicators.ROCR100.Series(vnidxData.Close, period, "");

                if (roc_index[Barindex] != 0)
                {
                    double rs = roc[Bar] / roc_index[Barindex];
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.Weight = rs * 100;
                    SelectStock(Bar, info);
                }
                //if (roc_index[Bar] != 0)
                //{
                //    double rs = roc[Bar] / roc_index[Bar];
                //    BusinessInfo info = new BusinessInfo();
                //    info.Weight = rs * 100;
                //    SelectStock(Bar, info);
                //}
            }
        }
    }
}
