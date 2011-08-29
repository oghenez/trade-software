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
    /// Linear Regression Helper class
    /// </summary>
    public class LinearRegHelper : IndicatorHelper
    {
        public LinearRegHelper()
        {
            Init(typeof(LinearReg), typeof(forms.LinearReg), Consts.constIndicatorMetaFile);
        }
    }

    /// <summary>
    /// Linear Regression indicator
    /// </summary>
    public class LinearReg : DataSeries
    {
        /// <summary>
        /// Static method to create Linear Regression DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static LinearReg Series(DataSeries ds, int period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";
            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description)) return (LinearReg)ds.Cache[description];

            //Create aroon, cache it, return it
            LinearReg cci = new LinearReg(ds, period, description);
            ds.Cache[description] = cci;
            return cci;
        }

        /// <summary>
        /// Calculation of LinearReg indicators
        /// </summary>
        /// <param name="db">data to calculate LinearReg</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public LinearReg(DataSeries db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.LinearReg(0, db.Count - 1, db.Values, period, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }
    }
}
