using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;
using application.Indicators;
using commonTypes;
using commonClass;

namespace Indicators
{
    /// <summary>
    /// Aroon Helper class
    /// </summary>
    public class RiskRewardHelper : Helpers
    {
        public RiskRewardHelper()
        {
            Init(typeof(RiskReward), typeof(application.forms.commonIndicatorForm));
        }
    }

    /// <summary>
    /// Risk reward indicator
    /// </summary>
    public class RiskReward : DataSeries
    {
        /// <summary>
        /// Static method to create Arron DataSeries
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="period"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static RiskReward Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + ")";

            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (RiskReward)obj;

            //Create Aroon, cache it, return it
            RiskReward riskreward = new RiskReward(ds, period, description);
            ds.Cache.Add(description, riskreward);
            return riskreward;
        }

        /// <summary>
        /// Calculation of RiskReward indicators
        /// </summary>
        /// <param name="db">data to calculate Aroon</param>        
        /// <param name="period">period to calculate</param>
        /// <param name="name"></param>
        public RiskReward(DataSeries ds, double period, string name)
            : base(ds, name)
        {
            int begin = 0;

            Indicators.MIN min = Indicators.MIN.Series(ds, period, "min");
            Indicators.MAX max = Indicators.MAX.Series(ds, period, "max");
            DataSeries distance1 = ds - min;
            DataSeries distance2 = max - ds;
            DataSeries riskreward = distance2 / distance1;
            
            FirstValidValue = max.FirstValidValue;
            this.Name = name;

            for (int i = begin, j = 0; j < riskreward.Count; i++, j++)
            {
                this[i] = riskreward[j];
            }
        }
    }
}
