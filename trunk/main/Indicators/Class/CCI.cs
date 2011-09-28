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
    /// CCI Helper class
    /// </summary>
    public class CCIHelper : Helpers
    {
        public CCIHelper()
        {
            Init(typeof(CCI), typeof(forms.commonForm), typeof(DataBars));
        }
    }

    /// <summary>
    /// CCI indicator
    /// </summary>
    public class CCI : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static CCI Series(DataBars ds, int period, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (CCI)obj;

            //Create CCI, cache it, return it
            CCI cci = new CCI(ds, period, description);
            ds.Cache.Add(description, cci);
            return cci;
        }

        /// <summary>
        /// Calculation of CCI indicators
        /// </summary>
        /// <param name="db">data to calculate CCI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public CCI(DataBars db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Cci(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, period, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }
    }
}
