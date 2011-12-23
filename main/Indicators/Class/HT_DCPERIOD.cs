using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;
using application.Indicators;
using commonClass;


namespace Indicators
{
    /// <summary>
    /// Each indicator requires an indicator helper class that 
    /// provides information to dynamically plug-in to the system
    /// Indicator without helper is invisible to the system
    /// </summary>
    public class HT_DCPERIODHelper : Helpers
    {
        public HT_DCPERIODHelper()
        {
            Init(typeof(HT_DCPERIOD), typeof(application.forms.commonIndicatorForm));
        }
    }

    /// <summary>
    /// Average True Range Indicator
    /// </summary>
    public class HT_DCPERIOD : DataSeries
    {
        /// <summary>
        /// Static method to create HT_DCPERIOD DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HT_DCPERIOD Series(DataSeries ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (HT_DCPERIOD)obj;

            //Create indicator, cache it, return it
            HT_DCPERIOD indicator = new HT_DCPERIOD(ds,description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of Average True Range indicators
        /// </summary>
        /// <param name="db">data to calculate HT_DCPERIOD</param>
        /// <param name="period">the period</param>
        /// <param name="name"></param>
        public HT_DCPERIOD(DataSeries db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.HtDcPeriod(0, db.Count - 1, db.Values,out begin, out length, output);

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
