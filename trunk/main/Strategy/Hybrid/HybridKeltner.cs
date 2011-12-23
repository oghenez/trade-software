using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application.Strategy;
using commonClass;

namespace Strategy
{
    public class HybridKeltner_Helper : baseHelper
    {
        public HybridKeltner_Helper()
            : base(typeof(HybridKeltnerEMA))
        {
        }
    }

    public class BollingerKeltnerEMARule : Rule
    {
        Indicators.BBANDS bolliger;
        Indicators.KELTNER keltner;
        TwoEMARule emaRule; 
        
        public BollingerKeltnerEMARule(DataBars db,double BolligerPeriod,double kUp,double kDn,double EmaPeriod,double AtrMult,double AtrPeriod,double emaShortPeriod,double emaLongPeriod)
        {
            bolliger=Indicators.BBANDS.Series(db.Close,BolligerPeriod,kUp,kDn,"bolliger");
            keltner=Indicators.KELTNER.Series(db,EmaPeriod,AtrMult,AtrPeriod,"keltner");
            emaRule = new TwoEMARule(db.Close, emaShortPeriod, emaLongPeriod);
        }

        public override bool DownTrend(int index)
        {
            if (index < emaRule.long_indicator.FirstValidValue)
                return false;
            if (emaRule.DownTrend(index))
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index < emaRule.long_indicator.FirstValidValue)
                return false;
            return (emaRule.UpTrend(index));
        }

        public bool isBolligerInsideKeltner(int index)
        {
            if (index < Math.Max(bolliger.UpperSeries.FirstValidValue,keltner.UpperSeries.FirstValidValue)) 
                return false;
            if ((bolliger.UpperSeries[index]<keltner.UpperSeries[index])
               &&(bolliger.LowerSeries[index]>keltner.LowerSeries[index]))
                return true;
            return false;

        }

        public override bool isValid_forBuy(int index)
        {
            if (isBolligerInsideKeltner(index-1)&&(!isBolligerInsideKeltner(index))&&emaRule.UpTrend(index))
                return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            //if ((isBolligerInsideKeltner(index)&&(!isBolligerInsideKeltner(index-1)))
            //    ||(emaRule.isValid_forSell(index)))
            if (isBolligerInsideKeltner(index - 1) && (!isBolligerInsideKeltner(index)) && emaRule.DownTrend(index))
                return true;
            return false;
        }
    }

    public class HybridKeltnerEMA : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BollingerKeltnerEMARule rule = new BollingerKeltnerEMARule(data.Bars, parameters[0], parameters[1], parameters[2], parameters[3],parameters[4],parameters[5],parameters[6],parameters[7]);
            int cutlosslevel = (int)parameters[8];
            int trailingstoplevel = (int)parameters[9];
            int takeprofitlevel = (int)parameters[10];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[7], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[7], "max");

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx))
                    {
                        BusinessInfo info = new BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = min[idx];
                        info.Stop_Loss = max[idx];
                        SellAtClose(idx, info);
                    }
                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);

                if (trailingstoplevel > 0)
                    TrailingStopWithBuyBack(rule, data.Close[idx], trailingstoplevel, idx);
            }
        }
    }
}
