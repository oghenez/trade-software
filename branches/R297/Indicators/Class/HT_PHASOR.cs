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
    /// Each indicator requires an indicator helper class that 
    /// provides information to dynamically plug-in to the system
    /// Indicator without helper is invisible to the system
    /// </summary>
    public class HT_PHASORHelper : Helpers
    {
        public HT_PHASORHelper()
        {
            Init(typeof(HT_PHASOR), typeof(forms.commonForm),  typeof(DataBars));
        }
    }

    /// <summary>
    /// Average True Range Indicator
    /// </summary>
    public class HT_PHASOR : DataSeries
    {
        /// <summary>
        /// Static method to create HT_PHASOR DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HT_PHASOR Series(DataBars ds, string name)
        {
            //Build description
            string description = "(" + name  + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (HT_PHASOR)obj;

            //Create indicator, cache it, return it
            HT_PHASOR indicator = new HT_PHASOR(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of Average True Range indicators
        /// </summary>
        /// <param name="ds">data to calculate HT_PHASOR</param>
        /// <param name="period">the period</param>
        /// <param name="name"></param>
        public HT_PHASOR(DataBars ds, string name)
            : base(ds, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;

            double[] output = new double[ds.Count];
            double[] quadrature = new double[ds.Count];

            retCode = Core.HtPhasor(0, ds.Count - 1, ds.High.Values, out begin, out length, output, quadrature);

            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            DataSeries quadratureSeries= new DataSeries(ds, name + "-quadrature");
            if (length <= 0)
                FirstValidValue = begin + output.Length + 1;
            else
                FirstValidValue = begin;
            quadratureSeries.FirstValidValue = FirstValidValue;

            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++)
            {
                quadratureSeries.Values[i] = quadrature[j];
                this[i] = output[j];
            }
            this.Cache.Add(quadratureSeries.Name, quadratureSeries);
        }

        public DataSeries QuadratureSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-quadrature");
            }
        }
        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[] { this.QuadratureSeries };
            }
        }
    }
}
