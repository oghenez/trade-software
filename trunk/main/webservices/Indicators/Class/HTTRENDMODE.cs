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
    /// HTTRENDMODE Helper class
    /// </summary>
    public class HTTRENDMODEHelper : Helpers
    {
        public HTTRENDMODEHelper()
        {
            Init(typeof(HTTRENDMODE), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// HTTRENDMODE indicator
    /// </summary>
    public class HTTRENDMODE : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HTTRENDMODE Series(DataSeries ds, string name)
        {
            //Build description
            string description = "(" + name  + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (HTTRENDMODE)obj;

            //Create indicator, cache it, return it
            HTTRENDMODE indicator = new HTTRENDMODE(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;  
        }

        /// <summary>
        /// Calculation of HTTRENDMODE indicators
        /// </summary>
        /// <param name="db">data to calculate HTTRENDMODE</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public HTTRENDMODE(DataSeries db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            int[] output = new int[db.Count];

            retCode = Core.HtTrendMode(0, db.Count - 1, db.Values, out begin, out length, output);

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
