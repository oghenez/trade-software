using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class Price_SMA_5_10_20_Risk_Reward : GenericStrategy
    {
        public Price_SMA_5_10_20_Risk_Reward(analysis.workData d, string code, bool fExport, string curStrategy) : base(d, code, fExport, curStrategy) { }
        public override analysis.analysisResult Execute()
        {
            return null;
        }
    }
}
