using TicTacTec.TA.Library;

using commonClass;

namespace Indicators
{
    /// <summary>
    /// Each indicator requires an indicator helper class that 
    /// provides information to dynamically plug-in to the system
    /// Indicator without helper is invisible to the system
    /// </summary>
    public class TRANGEHelper : Helpers
    {
        public TRANGEHelper()
        {
            Init(typeof(TRANGE), typeof(forms.commonForm), typeof(DataBars));
        }
    }

    /// <summary>
    /// Average True Range Indicator
    /// </summary>
    public class TRANGE : DataSeries
    {
        /// <summary>
        /// Static method to create TRANGE DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TRANGE Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (TRANGE)obj;

            //Create indicator, cache it, return it
            TRANGE indicator = new TRANGE(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of Average True Range indicators
        /// </summary>
        /// <param name="db">data to calculate TRANGE</param>
        /// <param name="period">the period</param>
        /// <param name="name"></param>
        public TRANGE(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.TrueRange(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values,out begin, out length, output);

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
