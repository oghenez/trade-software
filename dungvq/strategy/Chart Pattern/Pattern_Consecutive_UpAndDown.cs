using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class Pattern_Consecutive_UpAndDown : GenericStrategy
    {
        public Pattern_Consecutive_UpAndDown(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p): base(d, code, fExport, curStrategy,p) { }        

        public override analysis.analysisResult Execute()
        {
            int CONSECUTIVE_DOWN = (int)parameters.getParameter(0);
            int CONSECUTIVE_UP = (int)parameters.getParameter(1);

            bool is_2days_down, is_3days_up = false;            
            double[] closePrice = data.closePrice;            

            for (int idx = 20; idx < closePrice.Length; idx++)
            {
                is_2days_down = strategyLib.isCummulativeDown(closePrice, idx, CONSECUTIVE_DOWN);
                if (is_2days_down)
                    BuyAtClose(idx);
               
                is_3days_up = strategyLib.isCummulativeUp(closePrice, idx, CONSECUTIVE_UP);
                if (is_3days_up)
                    SellAtClose(idx);
                
            }

            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, closePrice);
            return adviceInfo;
        }
    }
}
