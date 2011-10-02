using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    /// <summary>
    /// Min Index Helper class
    /// </summary>
    public class MININDEXHelper : Helpers
    {
        public MININDEXHelper()
        {
            Init(typeof(MININDEX), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// Min Index indicator
    /// </summary>
    public class MININDEX : DataSeries
    {
        /// <summary>
        /// Static method to create Min Index DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MININDEX Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (MININDEX)obj;

            //Create indicator, cache it, return it
            MININDEX indicator = new MININDEX(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of Min Index indicators
        /// </summary>
        /// <param name="db">data to calculate Min Index</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public MININDEX(DataSeries db, double period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.MinIndex(0, db.Count - 1, db.Values,(int) period, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }
    }
}
