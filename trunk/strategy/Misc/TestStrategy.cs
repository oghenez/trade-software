/*Test Strategy for all purpose of testing of new strategy
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class TestStrategy : GenericStrategy
    {
        public TestStrategy(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p): base(d, code, fExport, curStrategy,p) { }
        public override analysis.analysisResult Execute()
        {
            double[] sma5 = data.SMA((int)parameters.getParameter(0));
            double[] sma10 = data.SMA((int)parameters.getParameter(1));
            double coeff = parameters.getParameter(2);

            double[] price = data.closePrice;
            double[] volume = data.totalVolume;

            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;

            bool bVolumeCondition = false;

            for (int idx = 1; idx < sma5.Length ; idx++)
            {
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                bVolumeCondition = volume[idx] > coeff*volume[idx-1] ? true : false;
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy && bVolumeCondition)
                    BuyAtClose(idx);

                if (lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                    SellAtClose(idx);

                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data);
            return adviceInfo;
        }
    }
}
