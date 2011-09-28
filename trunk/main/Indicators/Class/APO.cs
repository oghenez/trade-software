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
    /// APO Helper class
    /// </summary>
    public class APOHelper : Helpers
    {
        public APOHelper()
        {
            Init(typeof(APO), typeof(forms.commonForm));
        }
    }

    /// <summary>
    /// APO indicator
    /// </summary>
    public class APO : DataSeries
    {
        /// <summary>
        /// Static method to create APO DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static APO Series(DataSeries ds, int fastperiod, int slowperiod, int matype, string name)
        {
            //Build description
            string description = "(" + name + fastperiod.ToString()+","+slowperiod.ToString()+","+matype.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (APO)obj;

            //Create indicator, cache it, return it
            APO indicator = new APO(ds, fastperiod,slowperiod,matype,description);
            ds.Cache.Add(description, indicator);
            return indicator;              
        }

        /// <summary>
        /// Calculation of APO indicators
        /// </summary>
        /// <param name="db">data to calculate MFI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public APO(DataSeries db, int fastperiod,int slowperiod, int matype,string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            switch (matype)
            {
                case 0: 
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.Dema, out begin, out length, output);
                    break;
                case 1: 
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.Ema, out begin, out length, output);
                    break;
                case 2: 
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.Kama, out begin, out length, output);
                    break;
                case 3:
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.Mama, out begin, out length, output);
                    break;
                case 4:
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.Sma, out begin, out length, output);
                    break;
                case 5:
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.T3, out begin, out length, output);
                    break;
                case 6:
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.Tema, out begin, out length, output);
                    break;
                case 7:
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.Trima, out begin, out length, output);
                    break;
                case 8:
                    retCode = Core.Apo(0, db.Count - 1, db.Values, fastperiod, slowperiod, Core.MAType.Wma, out begin, out length, output);
                    break;
            }
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }
    }
}
