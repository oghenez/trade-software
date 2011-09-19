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
    /// Bop helper
    /// </summary>
    public class BopHelper : IndicatorHelper
    {
        public BopHelper()
        {
            Init(typeof(Bop), typeof(forms.Bop), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }

    /// <summary>
    /// Chaikin A/D Line Indicator
    /// </summary>
    public class Bop : DataSeries
    {
        /// <summary>
        /// Static method to create Bop DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Bop Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (Bop)obj;

            //Create indicator, cache it, return it
            Bop indicator = new Bop(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;              
        }

        /// <summary>
        /// Calculation of Balance of Power indicators
        /// </summary>
        /// <param name="db">data to calculate Bop</param>        
        /// <param name="name"></param>
        public Bop(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Bop(0, db.Count - 1, db.Open.Values,db.High.Values, db.Low.Values, db.Close.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
}
