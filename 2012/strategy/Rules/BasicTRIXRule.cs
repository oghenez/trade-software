using Indicators;
using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{
    public class BasicTRIXRule : Rule
    {
        public readonly TRIX trix;
        public BasicTRIXRule(DataSeries ds, double period, string name)
        {
            trix = new Indicators.TRIX(ds, period, name);
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

}
