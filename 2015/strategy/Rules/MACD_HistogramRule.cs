using application.Strategy;
using commonClass;

namespace Strategy
{
    public class MACD_HistogramRule : Rule
    {
        public Indicators.MACD macd;
        public DataSeries ema, hist;

        public MACD_HistogramRule(DataSeries ds, double fast, double slow, double signal)
        {
            macd = Indicators.MACD.Series(ds, fast, slow, signal, "macd");
            ema = macd.SignalSeries;
            hist = macd.HistSeries;
        }

        public override bool isValid()
        {
            return isValid_forBuy(macd.Count - 1);
        }

        public override bool isValid(int idx)
        {
            return isValid_forBuy(idx);
        }

        override public bool isValid_forBuy(int idx)
        {
            //Fixed by Dung  19 Nov 2011
            if (hist == null) return false;

            double delta = 0, lastDelta = 0;
            if (idx - 2 < hist.FirstValidValue) return false;
            lastDelta = (hist[idx - 1] - hist[idx - 2]);
            delta = (hist[idx] - hist[idx - 1]);
            if (delta > 0 && lastDelta < 0)
                return true;
            return false;
        }

        override public bool isValid_forSell(int idx)
        {
            double delta = 0, lastDelta = 0;
            if (idx - 2 < hist.FirstValidValue) return false;
            lastDelta = (hist[idx - 1] - hist[idx - 2]);
            delta = (hist[idx] - hist[idx - 1]);
            if (delta < 0 && lastDelta > 0)
                return true;
            return false;
        }

        public override bool DownTrend(int index)
        {
            if (index - 1 < hist.FirstValidValue) return false;
            double delta = (hist[index] - hist[index - 1]);
            if (delta <= 0) return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index - 1 < hist.FirstValidValue) return false;
            double delta = (hist[index] - hist[index - 1]);
            if (delta > 0) return true;
            return false;
        }
    }
}
