using application;
using Indicators;
using commonClass;

namespace Strategy
{
    public class TimeSeriesLinearRegStrategy_Helper : baseHelper
    {
        public TimeSeriesLinearRegStrategy_Helper() : base(typeof(TSFLIN)) { }
    }

    public class TimeSeriesRule:Rule
    {
        public Indicators.TSF tsf;
        public DataSeries price;
        public TimeSeriesRule(DataSeries ds, double period)
        {
            tsf = new Indicators.TSF(ds, period, "tsf");
            price=ds;
        }

        public override bool  DownTrend(int index)
        {
            if (index<tsf.FirstValidValue) return false;
            if (price[index]<tsf[index]) return true;
            return false;
        }

        public override bool  UpTrend(int index)
        {
            if (index<tsf.FirstValidValue) return false;
            if (price[index]>tsf[index]) return true;
            return false;
        }

        public override bool  isValid_forBuy(int index)
        {
            if (index-1<tsf.FirstValidValue) return false;
            if (DownTrend(index-1)&&UpTrend(index))
                return true;
 	        return false;
        }

        public override bool  isValid_forSell(int index)
        {
            if (index-1<tsf.FirstValidValue) return false;
            if (DownTrend(index)&&UpTrend(index-1))
                return true;
 	        return false;
        }
    }


    public class LinearRegRule : Rule
    {
        public Indicators.LinearReg lng;
        public DataSeries price;
        public LinearRegRule(DataSeries ds, double period)
        {
            lng = new Indicators.LinearReg(ds, period, "lng");
            price=ds;
        }

        public override bool  DownTrend(int index)
        {
            if (index < lng.FirstValidValue) return false;
            if (price[index] < lng[index]) return true;
            return false;
        }

        public override bool  UpTrend(int index)
        {
            if (index < lng.FirstValidValue) return false;
            if (price[index] > lng[index]) return true;
            return false;
        }

        public override bool  isValid_forBuy(int index)
        {
            if (index - 1 < lng.FirstValidValue) return false;
            if (DownTrend(index-1)&&UpTrend(index))
                return true;
 	        return false;
        }

        public override bool  isValid_forSell(int index)
        {
            if (index - 1 < lng.FirstValidValue) return false;
            if (DownTrend(index)&&UpTrend(index-1))
                return true;
 	        return false;
        }
    }

    public class TSFLIN : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            TimeSeriesRule timeSeriesRule = new TimeSeriesRule(data.Close, parameters[0]);
            LinearRegRule lngRule = new LinearRegRule(data.Close, parameters[1]);
            int cutlosslevel = (int)parameters[2];
            int takeprofitlevel = (int)parameters[3];

            for (int idx = timeSeriesRule.tsf.FirstValidValue; idx < timeSeriesRule.tsf.Count; idx++)
            {
                //Buy Condition
                if ((timeSeriesRule.isValid_forBuy(idx)&&lngRule.UpTrend(idx))
                    ||(lngRule.isValid_forBuy(idx)&&timeSeriesRule.UpTrend(idx)))
                    BuyAtClose(idx);

                //Sell Condition
                if (timeSeriesRule.isValid_forSell(idx)||lngRule.isValid_forSell(idx))
                    SellAtClose(idx);

                if (is_bought && CutLossCondition(data.Close[idx], buy_price, cutlosslevel))
                    SellCutLoss(idx);

                if (is_bought && TakeProfitCondition(data.Close[idx], buy_price, takeprofitlevel))
                    SellTakeProfit(idx);
            }
        }
    }
}
