using Indicators;
using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{
    public class TwoLineTRIXRule : Rule
    {
        public readonly TRIX short_trix;
        public readonly TRIX long_trix;

        public TwoLineTRIXRule(DataSeries ds, double short_period, double long_period, string name)
        {
            short_trix = new Indicators.TRIX(ds, short_period, name);
            long_trix = new Indicators.TRIX(ds, long_period, name);
        }

        public override bool DownTrend(int index)
        {
            if (index < long_trix.FirstValidValue) return false;
            if (short_trix[index] <= long_trix[index]) return true;
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
}
