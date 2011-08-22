using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace appHub
{
    public class strategy
    {
        public static analysis.analysisResult TradeAnalysis(analysis.workData data, string strategyCode)
        {
            analysis.analysisResult advices = global::strategy.libs.Strategy(data, strategyCode.Trim());
            InValidateAnalysisResult(ref advices, data);
            return advices;
        }
        //Validate analysis result  : currently this functions do the followings
        // - Remove all trade poind that occur outside date range
        // - Assign pointIdx to reach point
        private static void InValidateAnalysisResult(ref analysis.analysisResult results, analysis.workData data)
        {
            if (results == null) return;
            analysis.tradePoint tradePoint;
            for (int idx = 0; idx < results.Count; )
            {
                tradePoint = (analysis.tradePoint)results[idx];
                if (data.priceDate[tradePoint.dataIdx] >= data.startDate &&
                    data.priceDate[tradePoint.dataIdx] <= data.endDate)
                {
                    tradePoint.pointIdx = tradePoint.dataIdx - data.priceStartIdx;
                    idx++; continue;
                }
                results.RemoveAt(idx);
            }
        }

    }
}
