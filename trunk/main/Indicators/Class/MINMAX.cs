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
    /// MINMAX Helper class
    /// </summary>
    public class MINMAXHelper : Helpers
    {
        public MINMAXHelper()
        {
            Init(typeof(MINMAX), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// MINMAX indicator
    /// </summary>
    public class MINMAX : DataSeries
    {
        /// <summary>
        /// Static method to create MINMAX DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MINMAX Series(DataSeries ds, int period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (MINMAX)obj;

            //Create indicator, cache it, return it
            MINMAX indicator = new MINMAX(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator; 
        }

        /// <summary>
        /// Calculation of MINMAX indicators
        /// </summary>
        /// <param name="db">data to calculate MINMAX</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public MINMAX(DataSeries db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] outmin = new double[db.Count];
            double[] outmax = new double[db.Count];


            retCode = Core.MinMax(0, db.Count - 1, db.Values, period, out begin, out length, outmin,outmax);
            
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            DataSeries maxSeries = new DataSeries(db,name + "-max");
            maxSeries.FirstValidValue = begin;

            for (int i = begin, j = 0; j < length; i++, j++)
            {
                this[i] = outmin[j];
                maxSeries[i] = outmax[j];
            }
            this.Cache.Add(maxSeries.Name, maxSeries);
        }

        public DataSeries MaxSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-max");
            }
        }
        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[] { this.MaxSeries};
            }
        }
    }
}
