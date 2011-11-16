using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indicators;
using application;

namespace Strategy
{
    public class BasicTRIX_Helper : baseHelper
    {
        public BasicTRIX_Helper()
            : base(typeof(BasicTRIX))
        {
        }
    }

    public class BasicTRIX_Trailing_Helper : baseHelper
    {
        public BasicTRIX_Trailing_Helper()
            : base(typeof(BasicTRIX_Trailing))
        {
        }
    }

    public class TwoLineTRIX_Helper : baseHelper
    {
        public TwoLineTRIX_Helper()
            : base(typeof(TwoLineTRIX))
        {
        }
    }

    public class BasicTRIXRule:Rule
    {
        public readonly TRIX trix;
        public BasicTRIXRule(DataSeries ds, double period, string name)
        {
            trix=new Indicators.TRIX(ds,period,name);
        }

        public override bool DownTrend(int index)
        {
            if (index < trix.FirstValidValue) return false;
            if (trix[index] <= 0) return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index < trix.FirstValidValue) return false;
            if (trix[index] > 0) return true;
            return base.UpTrend(index);
        }

        public override bool isValid_forBuy(int index)
        {
            if (DownTrend(index - 1) && UpTrend(index))
                return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (DownTrend(index) && UpTrend(index - 1))
                return true;
            return false;
        }
    }

    public class TwoLineTRIXRule : Rule
    {
        public readonly TRIX short_trix;
        public readonly TRIX long_trix;

        public TwoLineTRIXRule(DataSeries ds, double short_period,double long_period, string name)
        {
            short_trix = new Indicators.TRIX(ds, short_period, name);
            long_trix = new Indicators.TRIX(ds, long_period, name);
        }

        public override bool DownTrend(int index)
        {
            if (index < long_trix.FirstValidValue) return false;
            if (short_trix[index] <=long_trix[index]) return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index < long_trix.FirstValidValue) return false;
            if (short_trix[index] > long_trix[index]) return true;
            return false;
        }

        public override bool isValid_forBuy(int index)
        {
            if (DownTrend(index - 1) && UpTrend(index))
                return true;
            return false;
        }

        public override bool isValid_forSell(int index)
        {
            if (DownTrend(index) && UpTrend(index - 1))
                return true;
            return false;
        }
    }

    public class BasicTRIX : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicTRIXRule rule = new BasicTRIXRule(data.Close, parameters[0],"TRIX");
            int cutlosslevel = (int)parameters[1];
            int takeprofitlevel = (int)parameters[2];

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

            for (int idx = rule.trix.FirstValidValue; idx < data.Close.Count - 1; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
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

                //Trailing stop strategy test
                //new_trailing_stop = price * 0.85;
                //if new_trailing_stop>trailing_stop trailing_stop=new_trailing_stop;
                //else if new_trailing_stop<trailing_stop SellTakeProfit(idx)
            }
        }
    }

    public class BasicTRIX_Trailing : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            BasicTRIXRule rule = new BasicTRIXRule(data.Close, parameters[0], "TRIX");
            int cutlosslevel = (int)parameters[1];
            int trailingstoplevel = (int)parameters[2];
            int takeprofitlevel = (int)parameters[3];
            double new_trailing_stop,trailing_stop=-1;

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");


            for (int idx = rule.trix.FirstValidValue; idx < data.Close.Count - 1; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
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

                if (trailingstoplevel>0) 
                    TrailingStopWithBuyBack(rule,data.Close[idx],trailingstoplevel,idx);
                //Trailing stop strategtest
                //new_trailing_stop = data.Close[idx] * (1 - trailingstoplevel / 100);
                //if (new_trailing_stop > trailing_stop)
                //{
                //    trailing_stop = new_trailing_stop;
                //    //Buy back share if 
                //    if ((!is_bought) && rule.UpTrend(idx)) BuyAtClose(idx);
                //}
                //else
                //    if (data.Close[idx]<trailing_stop)
                //    {
                //        SellTakeProfit(idx);
                //        trailing_stop = -1;
                //    }
            }
        }
    }

    public class TwoLineTRIX : GenericStrategy
    {
        override protected void StrategyExecute()
        {
            TwoLineTRIXRule rule = new TwoLineTRIXRule(data.Close, parameters[0],parameters[1], "Two Line TRIX");
            int cutlosslevel = (int)parameters[2];
            int takeprofitlevel = (int)parameters[3];
            double new_trailing_stop, trailing_stop = -1;
            int trailingstoplevel = 15;

            Indicators.MIN min = Indicators.MIN.Series(data.Close, parameters[0], "min");
            Indicators.MAX max = Indicators.MAX.Series(data.Close, parameters[0], "max");

            for (int idx = rule.long_trix.FirstValidValue; idx < data.Close.Count - 1; idx++)
            {
                if (rule.isValid_forBuy(idx))
                {
                    BusinessInfo info = new BusinessInfo();
                    info.SetTrend(AppTypes.MarketTrend.Upward, AppTypes.MarketTrend.Unspecified, AppTypes.MarketTrend.Unspecified);
                    info.Short_Target = max[idx];
                    info.Stop_Loss = min[idx];
                    BuyAtClose(idx, info);
                }
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

                //Trailing stop strategtest
                //if (trailingstoplevel > 0)
                //    TrailingStopWithBuyBack(rule, data.Close[idx], trailingstoplevel, idx);
            }
        }
    }
}
