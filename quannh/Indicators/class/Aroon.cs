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
    /// Aroon Helper class
    /// </summary>
    public class AroonHelper : IndicatorHelper
    {
        public AroonHelper()
        {
            Init(typeof(Aroon), typeof(forms.Aroon), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }

    /// <summary>
    /// Aroon Helper class
    /// </summary>
    public class AroonOSCHelper : IndicatorHelper
    {
        public AroonOSCHelper()
        {
            Init(typeof(AroonOsc), typeof(forms.AroonOsc), Consts.constIndicatorMetaFile, typeof(DataBars));
        }
    }


    /// <summary>
    /// Aroon indicator
    /// </summary>
    public class Aroon : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Aroon Series(DataBars ds, int period, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (Aroon)obj;

            //Create Aroon, cache it, return it
            Aroon aroon = new Aroon(ds, period, description);
            ds.Cache.Add(description, aroon);
            return aroon;            
        }

        /// <summary>
        /// Calculation of Aroon indicators
        /// </summary>
        /// <param name="db">data to calculate Aroon</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public Aroon(DataBars db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] outputDown = new double[db.Count];
            double[] outputUp = new double[db.Count];

            retCode = Core.Aroon(0, db.Count - 1, db.High.Values, db.Low.Values, period, out begin, out length, outputDown, outputUp);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            DataSeries upValue = new DataSeries(db, name + "-aroon up");

            for (int i = begin, j = 0; j < length; i++, j++)
            {
                this[i] = outputDown[j];
                upValue.Values[i] = outputUp[j];
            }
            this.Cache.Add(upValue.Name,upValue);
        }

        /// <summary>
        /// the second output of Aroon indicator
        /// </summary>
        public DataSeries aroonUpSeries
        {
            get
            {
                string description = this.Name + "-aroon up";
                return (DataSeries)this.Cache.Find(description);
            }
        }

        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[] { this.aroonUpSeries };
            }
        }
    }

    /// <summary>
    /// Aroon Osc indicator
    /// </summary>
    public class AroonOsc : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AroonOsc Series(DataBars ds, int period, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (AroonOsc)obj;

            //Create indicator, cache it, return it
            AroonOsc indicator = new AroonOsc(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;            
        }

        /// <summary>
        /// Calculation of Aroon Oscillator indicators
        /// </summary>
        /// <param name="db">data to calculate Aroon oscillator</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public AroonOsc(DataBars db, int period, string name)
            : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[db.Count];

            retCode = Core.AroonOsc(0, db.Count - 1, db.High.Values, db.Low.Values, period, out begin, out length, output);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;

            for (int i = begin, j = 0; j < length; i++, j++)
                this[i] = output[j];
        }        
    }
}
