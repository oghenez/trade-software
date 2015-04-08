using application.Strategy;
using commonTypes;
using commonClass;

namespace Strategy
{
    /// <summary>
    /// Rule using SAR indicator
    /// </summary>
    public class BasicSARRule : Rule
    {
        public DataSeries sar;
        public DataSeries close;
        public BasicSARRule(DataBars db, double optInAcc, double optLnMax)
        {
            sar = new Indicators.SAR(db, optInAcc, optLnMax, "sar");
            close = db.Close;
        }

        public override bool isValid()
        {
            return isValid_forBuy(sar.Count - 1);
        }

        public override bool isValid_forBuy(int idx)
        {
            if (idx - 1 < sar.FirstValidValue)
                return false;
            if ((close[idx] > sar[idx]) && (close[idx - 1] <= sar[idx - 1]))
                return true;
            return false;
        }

        public override bool isValid_forSell(int idx)
        {
            if (idx < sar.FirstValidValue)
                return false;
            if ((close[idx] < sar[idx]) && (close[idx - 1] >= sar[idx - 1]))
                return true;
            return false;
        }

        public override bool UpTrend(int index)
        {
            if (index < sar.FirstValidValue) return false;
            if (close[index] > sar[index])
                return true;
            return base.UpTrend(index);
        }

        public override bool DownTrend(int index)
        {
            if (index < sar.FirstValidValue) return false;
            if (close[index] <= sar[index])
                return true;
            return base.UpTrend(index);
        }

    }
}
