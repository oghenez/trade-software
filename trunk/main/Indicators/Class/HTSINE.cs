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
    /// HTSINE Helper class
    /// </summary>
    public class HTSINEHelper : Helpers
    {
        public HTSINEHelper()
        {
            Init(typeof(HTSINE), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// HTSINE indicator
    /// </summary>
    public class HTSINE : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HTSINE Series(DataSeries ds, string name)
        {
            //Build description
            string description = "(" + name + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (HTSINE)obj;

            //Create indicator, cache it, return it
            HTSINE indicator = new HTSINE(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;  
        }

        /// <summary>
        /// Calculation of HTSINE indicators
        /// </summary>
        /// <param name="db">data to calculate HTSINE</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public HTSINE(DataSeries db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] outsine = new double[db.Count];
            double[] outleadsine = new double[db.Count];


            retCode = Core.HtSine(0, db.Count - 1, db.Values, out begin, out length, outsine,outleadsine);
            
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = outsine[j];
        }
    }
}
