using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class AverageStrategy : GenericStrategy
    {
        public AverageStrategy(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }

        /* Get average of a list for 0 to position
         */
        //public static double findAverage(double[] list, int position, int length)
        //{
        //    if (list.Length == 0 || position - length < 0) return 0;

        //    double average = 0;
        //    for (int i = position; i > position - length; i--)
        //        average += list[i];
        //    return average / length;
        //}

        public override analysis.analysisResult Execute()
        {
            int NUM_AVERAGE = (int)parameters.getParameter(0) ;
            int PERCENT_BUY = (int)parameters.getParameter(1);
            int PERCENT_SELL = (int)parameters.getParameter(2);
            double[] closePrice = data.closePrice;
            
            double value, distance,distance1;
            
            for (int idx = 20; idx < closePrice.Length; idx++)
            {
                // Calculate the average value of NUM_AVERAGE days from idx point
                value = strategyLib.findAverage(closePrice, idx, NUM_AVERAGE);
                distance = (closePrice[idx] - value) / value * 100;
                distance1 = (closePrice[idx-1] - value) / value * 100;
                if (distance1 < PERCENT_BUY && distance>PERCENT_BUY)
                   BuyAtClose(idx);                
                if (distance > PERCENT_SELL && distance1<PERCENT_SELL)                
                    SellAtClose(idx);
                
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, closePrice);
            return adviceInfo;
        }
    }
}
