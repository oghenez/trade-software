using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    public class Market_TRINHelper : Helpers
    {
        public Market_TRINHelper()
        {
            Init(typeof(Market_TRIN), typeof(forms.commonForm));
        }
    }

    public class Market_TRIN : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Market_TRIN Series(DataSeries ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (Market_TRIN)obj;

            //Create indicator, cache it, return it
            Market_TRIN indicator = new Market_TRIN(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of CCI indicators
        /// </summary>
        /// <param name="ds">data to calculate CCI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public Market_TRIN(DataSeries ds, string name)
            : base(ds, name)
        {
            //application.Data stockData = new application.Data(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"),"SSI");
            //MarketData market= new MarketData(AppTypes.TimeRanges.W1,AppTypes.TimeScaleFromCode("D1"));
            //DataSeries advancingIssues= market.AdvancingIssues;
            //DataSeries decliningIssues = market.DecliningIssues;
            //DataSeries result1=advancingIssues/decliningIssues;

            //DataSeries advancingVolume = market.AdvancingVolume;
            //DataSeries decliningVolume = market.DecliningVolume;
            //DataSeries result2 = advancingVolume / decliningVolume;

            //FirstValidValue = 0;
            //this.Name = name;

            //int begin = 0, length = 0;
            //Core.RetCode retCode = Core.RetCode.UnknownErr;

            //double[] output = new double[ds.Count];

            //retCode = Core.Trix(0, ds.Count - 1, ds.Values, (int)period, out begin, out length, output);

            //if (retCode != Core.RetCode.Success) return;
            ////Assign first bar that contains indicator data
            //FirstValidValue = begin;
            //this.Name = name;

            //for (int i = begin, j = 0; j < length; i++, j++)
            //    this[i] = output[j];
        }
    }
}
