using application;
using commonClass;

namespace Strategy
{
    public class BasicAroon_Helper : baseHelper
    {
        public BasicAroon_Helper()
            : base(typeof(BasicAroon))
        {
        }
    }

    /// <summary>
    /// Rule using DMI indicator
    /// </summary>
    public class BasicAroonRule : Rule
    {
        public Indicators.Aroon aroon;

        public BasicAroonRule(DataBars db, double period)
        {
            aroon = new Indicators.Aroon(db, period, "aroon");
        }
        
        public override bool isValid_forBuy(int idx)
        {
            if (idx - 1 < aroon.FirstValidValue) return false;

            //If arron Down is at max level=> prepare for Buy
            if ((aroon[idx - 1] >= 99) && (aroon[idx] < 99)&&(aroon.aroonUpSeries[idx]<30))
                return true;
            
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
           if (idx - 1 < aroon.FirstValidValue) return false;
           //If arron Up is at max level=> prepare for Sell
           if ((aroon.aroonUpSeries[idx - 1] >= 99) && (aroon.aroonUpSeries[idx] < 99)&&(aroon[idx]<30))
                return true;
           return false;
        }
    }

    public class BasicAroon : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicAroonRule rule = new BasicAroonRule(data.Bars, parameters[0]);
            //PriceTwoSMARule smarule = new PriceTwoSMARule(data.Close, 10, 20);

            int cutlosslevel = (int)parameters[1];
            int takeprofitlevel = (int)parameters[2];

            for (int idx = rule.aroon.FirstValidValue; idx < rule.aroon.Count; idx++)
            {
                //Buy Condition
                if (rule.isValid_forBuy(idx))
                    BuyAtClose(idx);

                //Sell Condition
                if (rule.isValid_forSell(idx))
                    SellAtClose(idx);

                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
            }
        }
    }
}
