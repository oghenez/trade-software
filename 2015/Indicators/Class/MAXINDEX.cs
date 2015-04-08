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
    /// MAXINDEX Helper class
    /// </summary>
    public class MAXINDEXHelper : Helpers
    {
        public MAXINDEXHelper()
        {
            Init(typeof(MAXINDEX), typeof(application.forms.commonIndicatorForm));
        }
    }

    /// <summary>
    /// MAXINDEX indicator
    /// </summary>
    public class MAXINDEX : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MAXINDEX Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (MAXINDEX)obj;

            //Create indicator, cache it, return it
            MAXINDEX indicator = new MAXINDEX(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;   
        }

        /// <summary>
        /// Calculation of MAXINDEX indicators
        /// </summary>
        /// <param name="db">data to calculate MAXINDEX</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public MAXINDEX(DataSeries db, double period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];


            retCode = Core.MaxIndex(0, db.Count - 1, db.Values, (int)period, out begin, out length, output);
            
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
