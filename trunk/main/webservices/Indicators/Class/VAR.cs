using TicTacTec.TA.Library;

using commonClass;

namespace Indicators
{
    /// <summary>
    /// CCI Helper class
    /// </summary>
    public class VARHelper : Helpers
    {
        public VARHelper()
        {
            Init(typeof(VAR), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// CCI indicator
    /// </summary>
    public class VAR : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static VAR Series(DataSeries ds, double period,double NbDev, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (VAR)obj;

            //Create indicator, cache it, return it
            VAR indicator = new VAR(ds, period,NbDev, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of VAR indicators
        /// </summary>
        /// <param name="db">data to calculate VAR</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public VAR(DataSeries db, double period, double optInNbDev, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Variance(0, db.Count - 1, db.Values, (int)period, optInNbDev ,out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }
    }
}
