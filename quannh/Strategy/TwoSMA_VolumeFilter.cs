using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class TwoSMA_VolumeFilter : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            DataSeries sma5 = data.SMA(parameters[0]);
            DataSeries sma10 = data.SMA(parameters[1]);
            int VOLUME_FILTER = (int)parameters.getParameter(2);

            double[] price = data.closePrice;
            double[] volume = data.totalVolume;
            
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;;

            bool bVolumeCondition = false;
           
            for (int idx = 0; idx < sma5.Length-1; idx++)
            {
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                bVolumeCondition = volume[idx] > VOLUME_FILTER ? true : false;
                if (bVolumeCondition && lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                 
                if (is_bought && lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
              
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
