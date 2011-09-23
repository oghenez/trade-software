﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    /// <summary>
    /// MIN Helper class
    /// </summary>
    public class MINHelper : IndicatorHelper
    {
        public MINHelper()
        {
            Init(typeof(MIN), typeof(forms.MIN), Consts.constIndicatorMetaFile);
        }
    }

    /// <summary>
    /// MIN indicator
    /// </summary>
    public class MIN : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MIN Series(DataSeries ds, int period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (MIN)obj;

            //Create indicator, cache it, return it
            MIN indicator = new MIN(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;     
        }

        /// <summary>
        /// Calculation of MIN indicators
        /// </summary>
        /// <param name="db">data to calculate MIN</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public MIN(DataSeries db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Min(0, db.Count - 1, db.Values, period, out begin, out length, output);
            
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }
    }
}
