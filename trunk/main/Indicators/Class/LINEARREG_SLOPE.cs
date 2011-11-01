using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    /// <summary>
    /// CCI Helper class
    /// </summary>
    public class LINEARREG_SLOPEHelper : Helpers
    {
        public LINEARREG_SLOPEHelper()
        {
            Init(typeof(LINEARREG_SLOPE), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// CCI indicator
    /// </summary>
    public class LINEARREG_SLOPE : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static LINEARREG_SLOPE Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (LINEARREG_SLOPE)obj;

            //Create indicator, cache it, return it
            LINEARREG_SLOPE indicator = new LINEARREG_SLOPE(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of CCI indicators
        /// </summary>
        /// <param name="db">data to calculate CCI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public LINEARREG_SLOPE(DataSeries db, double period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.LinearRegSlope(0, db.Count - 1, db.Values,(int) period, out begin, out length, output);

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
