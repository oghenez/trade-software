using application;
using commonClass;

namespace Strategy
{
    public class TwoSMA_VolumeFilter_Helper : baseHelper
    {
        public TwoSMA_VolumeFilter_Helper() : base(typeof(TwoSMA_VolumeFilter)) { }
    }

    public class TwoSMA_VolumeFilter : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries sma5 = Indicators.SMA.Series(data.Close, parameters[0], "");
            DataSeries sma10 = Indicators.SMA.Series(data.Close, parameters[1], "");
            int VOLUME_FILTER = (int)parameters[2];
            
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;;

            bool bVolumeCondition = false;
           
            for (int idx = 0; idx < sma5.Count-1; idx++)
            {
                currentTrend = ((data.Close[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                bVolumeCondition = data.Volume[idx] > VOLUME_FILTER ? true : false;
                if (bVolumeCondition && lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                 
                if (is_bought && lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }
}
