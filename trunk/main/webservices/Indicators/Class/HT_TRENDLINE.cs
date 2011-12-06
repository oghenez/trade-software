using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;

using commonClass;

namespace Indicators
{
    /// <summary>
    /// CCI Helper class
    /// </summary>
    public class HT_TRENDLINEHelper : Helpers
    {
        public HT_TRENDLINEHelper()
        {
            Init(typeof(HT_TRENDLINE), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// CCI indicator
    /// </summary>
    public class HT_TRENDLINE : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HT_TRENDLINE Series(DataSeries ds,  string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (HT_TRENDLINE)obj;

            //Create indicator, cache it, return it
            HT_TRENDLINE indicator = new HT_TRENDLINE(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of CCI indicators
        /// </summary>
        /// <param name="db">data to calculate CCI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public HT_TRENDLINE(DataSeries db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.HtTrendline(0, db.Count - 1, db.Values, out begin, out length, output);

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
