using application.Strategy;
using commonClass;

namespace Strategy
{
    public class MACD_HistogramSCR_Helper : baseHelper
    {
        public MACD_HistogramSCR_Helper() : base(typeof(MACD_HistogramSCR)) { }
    }
    
    public class MACD_HistogramSCR : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            Rule rule = new MACD_HistogramRule(data.Close, parameters[0], parameters[1], parameters[2]);
            if (rule.isValid())
            {
                int Bar = data.Close.Count - 1;
                BusinessInfo info = new BusinessInfo();
                info.Weight = data.Close[Bar];
                SelectStock(Bar, info);
            }
        }
    }
}
