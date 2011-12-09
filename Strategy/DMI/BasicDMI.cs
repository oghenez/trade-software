//Copyright by NHQ, HCM city, 2011 
//Basic DMI strategy
//Buy when there is cut between DI+ and DI-
//The cut loss function work with some cut loss level

using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class BasicDMI : GenericStrategy
    {
        public BasicDMI(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p): base(d, code, fExport, curStrategy,p) { }

        protected override void ScreeningExecute()
        {
            double[] minusDmi_14 = data.MinusDI((int)parameters.getParameter(0));//default=14
            double[] plusDmi_14 = data.PlusDI((int)parameters.getParameter(1));
            if (minusDmi_14.Length - 2 < 0) return;

            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;


            for (int idx = minusDmi_14.Length-2; idx < minusDmi_14.Length; idx++)
            {
                currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                    SelectStock(idx, null);                
                lastTrend = currentTrend;
            }
        }
        public override analysis.analysisResult Execute()
        {
            double[] minusDmi_14 = data.MinusDI((int)parameters.getParameter(0));//default=14
            double[] plusDmi_14 = data.PlusDI((int)parameters.getParameter(1));
            
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;

            for (int idx = 0; idx < minusDmi_14.Length; idx++)
            {

                currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                    BuyAtClose(idx);
                if (lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                    SellAtClose(idx);

                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, plusDmi_14, minusDmi_14);
            return adviceInfo;
        }

        public override analysis.analysisResult Execute_CutLoss()
        {

            double[] minusDmi_14 = data.MinusDI((int)parameters.getParameter(0));
            double[] plusDmi_14 = data.PlusDI((int)parameters.getParameter(1));
            int CUTLOSS_LEVEL = (int)parameters.getParameter(2);

            double bought_price = 0, distanceStopLoss = 0;
            bool is_bought = false;
            analysis.analysisResult adviceInfo = new analysis.analysisResult();
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;

            for (int idx = 0; idx < minusDmi_14.Length; idx++)
            {

                currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);

                //Buy Condition
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                {
                    adviceInfo.Add(analysis.tradeActions.Buy, idx);
                    bought_price = data.closePrice[idx];
                    is_bought = true;
                }

                //Sell Condition
                if (is_bought && lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                {
                    adviceInfo.Add(analysis.tradeActions.Sell, idx);
                    is_bought = false;
                }

                //Cut loss Condition
                if (bought_price > 0)
                    distanceStopLoss = (data.closePrice[idx] - bought_price) / bought_price * 100;
                else
                    distanceStopLoss = 0;

                if (is_bought && distanceStopLoss <= CUTLOSS_LEVEL)
                {
                    adviceInfo.Add(analysis.tradeActions.Sell, idx);
                    is_bought = false;
                }
                lastTrend = currentTrend;
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, plusDmi_14, minusDmi_14);
            return adviceInfo;
        }
    }
}
