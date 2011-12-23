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
    public class TYPPRICEHelper : Helpers
    {
        public TYPPRICEHelper()
        {
            Init(typeof(TYPPRICE), typeof(application.forms.commonIndicatorForm), typeof(DataBars));
        }
    }

    /// <summary>
    /// Average True Range Indicator
    /// </summary>
    public class TYPPRICE : DataSeries
    {
        /// <summary>
        /// Static method to create TYPPRICE DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TYPPRICE Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (TYPPRICE)obj;

            //Create indicator, cache it, return it
            TYPPRICE indicator = new TYPPRICE(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of Typical Price indicators
        /// </summary>
        /// <param name="db">data to calculate TYPPRICE</param>
        /// <param name="name"></param>
        public TYPPRICE(DataBars ds, string name)
            : base(ds, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[ds.Count];

            retCode = Core.TypPrice(0, ds.Count - 1, ds.High.Values, ds.Low.Values, ds.Close.Values, out begin, out length, output);

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
