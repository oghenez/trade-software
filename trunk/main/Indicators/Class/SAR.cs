using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    /// <summary>
    /// Each indicator requires an indicator helper class that 
    /// provides information to dynamically plug-in to the system
    /// Indicator without helper is invisible to the system
    /// </summary>
    public class SARHelper : Helpers
    {
        public SARHelper()
        {
            Init(typeof(SAR), typeof(forms.commonForm), typeof(DataBars));
        }
    }

    /// <summary>
    /// Average True Range Indicator
    /// </summary>
    public class SAR : DataSeries
    {
        /// <summary>
        /// Static method to create SAR DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SAR Series(DataBars ds, double optInAcceleration, double optLnMaximum, string name)
        {
            //Build description
            string description = "(" + name + "," + optInAcceleration.ToString() + "," + optLnMaximum.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (SAR)obj;

            //Create indicator, cache it, return it
            SAR indicator = new SAR(ds, optInAcceleration,optLnMaximum, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// SAR calculation
        /// </summary>
        /// <param name="db"></param>
        /// <param name="optInAcceleration"></param>
        /// <param name="optLnMaximum"></param>
        /// <param name="name"></param>
        public SAR(DataBars db, double optInAcceleration,double optLnMaximum, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Sar(0, db.Count - 1, db.High.Values, db.Low.Values, optInAcceleration,optLnMaximum, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
}
