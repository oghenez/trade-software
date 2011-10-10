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
    /// Each indicator requires an indicator helper class that 
    /// provides information to dynamically plug-in to the system
    /// Indicator without helper is invisible to the system
    /// </summary>
    public class CORRELHelper : Helpers
    {
        public CORRELHelper()
        {
            Init(typeof(CORREL), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// Average True Range Indicator
    /// </summary>
    public class CORREL : DataSeries
    {
        /// <summary>
        /// Static method to create CORREL DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CORREL Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CORREL)obj;

            //Create indicator, cache it, return it
            CORREL indicator = new CORREL(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of Average True Range indicators
        /// </summary>
        /// <param name="db">data to calculate CORREL</param>
        /// <param name="period">the period</param>
        /// <param name="name"></param>
        public CORREL(DataSeries db, double period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Correl(0, db.Count - 1,db.Values ,db.Values, (int)period, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
}
