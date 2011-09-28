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
    /// MOM Helper class
    /// </summary>
    public class MOMHelper : Helpers
    {
        public MOMHelper()
        {
            Init(typeof(MOM), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// MOM indicator
    /// </summary>
    public class MOM : DataSeries
    {
        /// <summary>
        /// Static method to create MOM DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MOM Series(DataSeries ds, int period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (MOM)obj;

            //Create indicator, cache it, return it
            MOM indicator = new MOM(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;              
        }

        /// <summary>
        /// Calculation of MOM indicators
        /// </summary>
        /// <param name="db">data to calculate MOM</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public MOM(DataSeries db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Mom(0, db.Count - 1, db.Values, period, out begin, out length, output);
            
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }
    }
}
