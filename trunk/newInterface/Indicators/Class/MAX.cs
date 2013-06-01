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
    /// CCI Helper class
    /// </summary>
    public class MAXHelper : Helpers
    {
        public MAXHelper()
        {
            Init(typeof(MAX), typeof(application.forms.commonIndicatorForm));
        }
    }

    /// <summary>
    /// CCI indicator
    /// </summary>
    public class MAX : DataSeries
    {
        /// <summary>
        /// Static method to create MAX
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MAX Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (MAX)obj;

            //Create indicator, cache it, return it
            MAX indicator = new MAX(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of MAX indicators
        /// </summary>
        /// <param name="db">data to calculate MAX</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public MAX(DataSeries ds, double period, string name)
            : base(ds, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[ds.Count];
            retCode = Core.Max(0, ds.Count - 1, ds.Values,(int) period, out begin, out length, output);

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
