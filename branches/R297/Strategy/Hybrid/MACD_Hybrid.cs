//Copyright by NHQ, HCM city, 2011 
using Indicators;
using application;

namespace Strategy
{
    public class MACD_ADX_Helper : baseHelper
    {
        public MACD_ADX_Helper() : base(typeof(MACD_ADX)) { }

    }

    public class MACD_ADX_Rule : CompositeRule
    {
        public MACD_ADX_Rule(DataBars db,double fast,double slow,double signal,double adxPeriod)
        {
            rules = new Rule[3];
            rules[0] = new MACD_HistogramRule(db.Close, fast, slow, signal);
            rules[1]=new ADXMarketTrend(db,adxPeriod);
            rules[2] = new BollingerKeltnerMarketTrend(db, 20, 2, 2, 20, 2, 10);
        }

        public override bool isValid_forBuy(int index)
        {
            if (rules[1].Trending(index) && rules[2].Trending(index))
            //if (rules[1].Trending(index))
                return rules[0].isValid_forBuy(index);
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            return rules[0].isValid_forSell(index);
        }

        public override bool DownTrend(int index)
        {
            return rules[0].DownTrend(index);
        }

        public override bool UpTrend(int index)
        {
            return rules[0].UpTrend(index);
        }
    }

    public class MACD_ADX : GenericStrategy
    {
        override protected void StrategyExecute()
        {            
            MACD_ADX_Rule rule = new MACD_ADX_Rule(data.Bars, parameters[0], parameters[1],
                parameters[2],parameters[3]);
            MoneyManagement riskManagement = new MoneyManagement(parameters[4], parameters[5], parameters[6]);

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[3], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[3], "max");

            for (int idx = 0; idx < data.Close.Count; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    wsData.BusinessInfo info = new wsData.BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
                else
                    if (rule.isValid_forSell(idx))
                    {
                        wsData.BusinessInfo info = new wsData.BusinessInfo();
                        info.SetTrend(AppTypes.MarketTrend.Downward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                        info.Short_Target = min[idx];
                        info.Stop_Loss = max[idx];
                        SellAtClose(idx, info);
                    }
                if (is_bought && riskManagement.CutLossCondition(data.Close[idx], buy_price))
                    SellCutLoss(idx);

                if (is_bought && riskManagement.TakeProfitCondition(data.Close[idx], buy_price))
                    SellTakeProfit(idx);

                if (riskManagement.TrailingStopLevel > 0)
                    riskManagement.TrailingStopWithBuyBack(this, rule, data.Close[idx], idx);
            }
        }
    }

    public class TwoSMAMACDSCR : GenericStrategy
    {
        /// <summary>
        /// Screening following basic MACD rule
        /// </summary>
        override protected void StrategyExecute()
        {
            BasicMACDRule rule = new BasicMACDRule(data.Close, (int)parameters[0], (int)parameters[1], (int)parameters[2]);
            TwoSMARule rule1 = new TwoSMARule(data.Close, (int)parameters[3], (int)parameters[4]);
            if (rule.isValid() && rule1.isValid())
            {
                int Bar = data.Close.Count - 1;
                wsData.BusinessInfo info = new wsData.BusinessInfo();
                info.Weight = rule.macd[Bar] * 100;
                SelectStock(Bar, info);
            }
        }
    }
}
