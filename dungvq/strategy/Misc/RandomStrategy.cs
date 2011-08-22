using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class RandomStrategy : GenericStrategy
    {
        public RandomStrategy(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }
        public override analysis.analysisResult Execute()
        {
            System.Random r=new Random();

            double[] price = data.closePrice;
            for (int idx = 0; idx < price.Length; idx++)
            {
                int n = r.Next(5);
                if (!is_bought&&n == 0)
                    BuyAtClose(idx);
                if (is_bought && n == 4)
                    SellAtClose(idx);                
            }
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, price);
            return adviceInfo;
        }
    }
}
