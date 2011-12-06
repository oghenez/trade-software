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
    /// ADXR Helper class
    /// </summary>
    public class ADXRHelper : Helpers
    {
        public ADXRHelper()
        {
            Init(typeof(ADXR), typeof(forms.commonForm), typeof(DataBars));
        }
    }

    /// <summary>
    /// ADXR indicator
    /// </summary>
    public class ADXR : DataSeries
    {
        /// <summary>
        /// Static method to create ADXR DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ADXR Series(DataBars ds, double period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (ADXR)obj;

            //Create indicator, cache it, return it
            ADXR indicator = new ADXR(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;  
        }

        /// <summary>
        /// Calculation of ADXR indicators
        /// </summary>
        /// <param name="db">data to calculate ADXR</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public ADXR(DataBars db, double period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Adxr(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, (int)period, out begin, out length, output);
            
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
