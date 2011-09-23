using System;
using System.Collections.Generic;
using System.Text;
using application;

namespace Strategy
{
    public class Price_3SMA_Risk_Reward : GenericStrategy
    {
        public Price_3SMA_Risk_Reward(analysis.workData d, string code, bool fExport, string curStrategy,Parameters p) : base(d, code, fExport, curStrategy,p) { }
        protected override void StrategyExecute()
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
                {
                    double risk_reward_ratio = strategyLib.RiskRewardRatio(price,idx,60);
                    if (risk_reward_ratio>=2 || risk_reward_ratio==-1)
                        BuyAtClose(idx);
                }
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
        }
    }
}
