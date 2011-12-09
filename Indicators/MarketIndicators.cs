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

    public class Market_ThrustHelper : Helpers
    {
        public Market_ThrustHelper()
        {
            Init(typeof(Market_Thrust), typeof(forms.commonForm));
        }
    }

    public class Market_BreadthTrustHelper : Helpers
    {
        public Market_BreadthTrustHelper()
        {
            Init(typeof(Market_BreadthTrust), typeof(forms.commonForm));
        }
    }

    public class Market_TRIN : DataSeries
    {
        /// <summary>
        /// Static method to create Thrust DataSeries
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
        /// Calculation of Thrust indicators
        /// </summary>
        /// <param name="ds">data to calculate CCI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public Market_TRIN(DataSeries ds, string name)
            : base(ds, name)
        {
            //application.Data stockData = new application.Data(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"), "SSI");
            MarketData market = new MarketData(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"));
            DataSeries advancingIssues = market.AdvancingIssues;
            DataSeries decliningIssues = market.DecliningIssues;

            DataSeries advancingVolume = market.AdvancingVolume;
            DataSeries decliningVolume = market.DecliningVolume;

            DataSeries result1 = advancingIssues / decliningIssues;
            DataSeries result2 = advancingVolume / decliningVolume;

            DataSeries result3 = result1 / result2;

            int begin = 0;
            FirstValidValue = 0;
            this.Name = name;
            for (int i = begin, j = 0; j < result3.Count; i++, j++)
                this[i] = result3[j];
        }
    }

    public class Market_Thrust : DataSeries
    {
        /// <summary>
        /// Static method to create Thrust DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Market_Thrust Series(DataSeries ds, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (Market_Thrust)obj;

            //Create indicator, cache it, return it
            Market_Thrust indicator = new Market_Thrust(ds, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of Thrust indicators
        /// </summary>
        /// <param name="ds">data to calculate CCI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public Market_Thrust(DataSeries ds, string name)
            : base(ds, name)
        {
            //application.Data stockData = new application.Data(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"), "SSI");
            MarketData market = new MarketData(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"));
            DataSeries advancingIssues = market.AdvancingIssues;
            DataSeries decliningIssues = market.DecliningIssues;

            DataSeries advancingVolume = market.AdvancingVolume;
            DataSeries decliningVolume = market.DecliningVolume;

            DataSeries result1 = advancingIssues * advancingVolume;
            DataSeries result2 = decliningIssues * decliningVolume;

            DataSeries result3 = result1 - result2;

            int begin = 0;
            FirstValidValue = 0;
            this.Name = name;
            for (int i = begin, j = 0; j < result3.Count; i++, j++)
                this[i] = result3[j];
        }
    }

    public class Market_BreadthTrust : DataSeries
    {
        /// <summary>
        /// Static method to create Thrust DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Market_BreadthTrust Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (Market_BreadthTrust)obj;

            //Create indicator, cache it, return it
            Market_BreadthTrust indicator = new Market_BreadthTrust(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        /// <summary>
        /// Calculation of Thrust indicators
        /// </summary>
        /// <param name="ds">data to calculate CCI</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public Market_BreadthTrust(DataSeries ds,double period, string name)
            : base(ds, name)
        {
            //application.Data stockData = new application.Data(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"), "SSI");
            MarketData market = new MarketData(AppTypes.TimeRanges.Y1, AppTypes.TimeScaleFromCode("D1"));
            DataSeries advancingIssues = market.AdvancingIssues;
            DataSeries decliningIssues = market.DecliningIssues;

            DataSeries emaAdvancingIssues = Indicators.EMA.Series(advancingIssues, period, "emaAdvancingIssues");
            DataSeries emaTotalIssues = Indicators.EMA.Series(advancingIssues + decliningIssues, period, "emaTotalIssues");

            DataSeries result3 = emaAdvancingIssues /emaTotalIssues;

            int begin = 0;
            FirstValidValue = 0;
            this.Name = name;
            for (int i = begin, j = 0; j < result3.Count; i++, j++)
                this[i] = result3[j];
        }
    }
}
