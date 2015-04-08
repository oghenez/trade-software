﻿using System;
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
    /// DEMA Helper class
    /// </summary>
    public class DEMAHelper : Helpers
    {
        public DEMAHelper()
        {
            Init(typeof(DEMA), typeof(application.forms.commonIndicatorForm));
        }
    }

    /// <summary>
    /// DEMA indicator
    /// </summary>
    public class DEMA : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DEMA Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (DEMA)obj;

            //Create indicator, cache it, return it
            DEMA indicator = new DEMA(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;            
        }

        /// <summary>
        /// Calculation of DEMA indicators
        /// </summary>
        /// <param name="db">data to calculate DEMA</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public DEMA(DataSeries db, double period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Dema(0, db.Count - 1, db.Values, (int)period, out begin, out length, output);
            
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
