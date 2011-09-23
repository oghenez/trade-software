using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class BasicPrice_3SMA : GenericStrategy
    {
        public BasicPrice_3SMA(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }
        override protected void StrategyExecute()
        {
            DataSeries sma5 = data.SMA(parameters[0]);
            DataSeries sma10 = data.SMA(parameters[1]);
            double[] sma20 = data.SMA((int)parameters.getParameter(2));

            double[] price = data.closePrice;            
            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;;

            
            for (int idx = 0; idx < sma5.Length; idx++)
            {
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) && (sma10[idx] > sma20[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
            return adviceInfo;
        }
    }
}
