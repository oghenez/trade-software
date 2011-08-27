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
    public class ATRHelper : IndicatorHelper
    {
        public ATRHelper()
        {
            Init(typeof(ATR), typeof(forms.ATR), Consts.constIndicatorMetaFile);
        }
    }

    /// <summary>
    /// Average True Range Indicator
    /// </summary>
    public class ATR : DataSeries
    {
        /// <summary>
        /// Static method to create ATR DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ATR Series(DataBars ds, int period, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + ")";
            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description)) return (ATR)ds.Cache[description];

            //Create ATR, cache it, return it
            ATR atr = new ATR(ds, period, description);
            ds.Cache[description] = atr;
            return atr;
        }

        /// <summary>
        /// Calculation of Average True Range indicators
        /// </summary>
        /// <param name="db">data to calculate ATR</param>
        /// <param name="period">the period</param>
        /// <param name="name"></param>
        public ATR(DataBars db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Atr(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, period, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
}
