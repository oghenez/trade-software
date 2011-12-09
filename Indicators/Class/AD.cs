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
    /// AD helper
    /// </summary>
    public class ADHelper : Helpers
    {
        public ADHelper()
        {
            Init(typeof(AD), typeof(forms.commonForm),typeof(DataBars));
        }
    }

    /// <summary>
    /// ADOSC helper
    /// </summary>
    public class ADOSCHelper : Helpers
    {
        public ADOSCHelper()
        {
            Init(typeof(ADOSC), typeof(forms.commonForm), typeof(DataBars));
        }
    }

    /// <summary>
    /// Chaikin A/D Line Indicator
    /// </summary>
    public class AD : DataSeries
    {
        /// <summary>
        /// Static method to create AD DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AD Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (AD)obj;

            //Create AD, cache it, return it
            AD ad = new AD(ds, description);
            ds.Cache.Add(description, ad);
            return ad;            
        }

        /// <summary>
        /// Calculation of Chaikin A/D Line indicators
        /// </summary>
        /// <param name="db">data to calculate AD</param>        
        /// <param name="name"></param>
        public AD(DataBars db, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.Ad(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, db.Volume.Values, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }

    /// <summary>
    /// Chaikin A/D Oscillator Indicator
    /// </summary>
    public class ADOSC : DataSeries
    {
        /// <summary>
        /// Static method to create ADOSC DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="fastPeriod"></param>
        /// <param name="slowPeriod"></param>
        /// <param name="name"></param>
        /// <returns></returns>       
        public static ADOSC Series(DataBars ds, double fastPeriod, double slowPeriod, string name)
        {
            //Build description
            string description = "(" + name + "," + fastPeriod.ToString() + "," + slowPeriod.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (ADOSC)obj;

            //Create ADOSC, cache it, return it
            ADOSC adosc = new ADOSC(ds, fastPeriod, slowPeriod, description);
            ds.Cache.Add(description, adosc);
            return adosc;
        }
            

        /// <summary>
        /// Calculation of Chaikin A/D Oscillator indicators
        /// </summary>
        /// <param name="db">data to calculate AD</param>        
        /// <param name="name"></param>
        public ADOSC(DataBars db, double fastPeriod, double slowPeriod, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.AdOsc(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, db.Volume.Values, (int)fastPeriod, (int)slowPeriod, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
}
