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
    /// MFI Helper class
    /// </summary>
    public class MFIHelper : IndicatorHelper
    {
        public MFIHelper()
        {
            Init(typeof(MFI), typeof(forms.MFI), Consts.constIndicatorMetaFile,typeof(DataBars));
        }
    }

    /// <summary>
    /// MFI indicator
    /// </summary>
    public class MFI : DataSeries
    {
        /// <summary>
        /// Static method to create MFI DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MFI Series(DataBars ds, int period, string name)
        {
            //Build description
            string description = "(" + name + period.ToString() + ")";
            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description)) return (MFI)ds.Cache[description];

            //Create aroon, cache it, return it
            MFI mfi = new MFI(ds, period, description);
            ds.Cache[description] = mfi;
            return mfi;
        }

        /// <summary>
        /// Calculation of MFI indicators
        /// </summary>
        /// <param name="db">data to calculate MFI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public MFI(DataBars db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Mfi(0, db.Count - 1, db.High.Values,db.Low.Values,db.Close.Values, db.Volume.Values,period, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }
    }
}
