using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace strategy
{
    public class Price_3SMA_Risk_Reward : GenericStrategy
    {
        public Price_3SMA_Risk_Reward(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }
        protected override void StrategyExecute()
        {
            double[] sma5 = data.SMA((int)parameters.getParameter(0));
            double[] sma10 = data.SMA((int)parameters.getParameter(1));
            double[] sma20 = data.SMA((int)parameters.getParameter(2));

            double[] price = data.closePrice;
            analysis.tradeActions lastTrend = analysis.tradeActions.None;
            analysis.tradeActions currentTrend = analysis.tradeActions.None;            
            for (int idx = 0; idx < sma5.Length; idx++)
            {
                currentTrend = ((price[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) && (sma10[idx] > sma20[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
                if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
                {
                    double risk_reward_ratio = strategyLib.RiskRewardRatio(price,idx,60);
                    if (risk_reward_ratio>=2 || risk_reward_ratio==-1)
                        BuyAtClose(idx);
                }
                if (lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }
}
