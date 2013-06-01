using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace Indicators
{
    public class SRChannelHelper : Helpers
    {
        public SRChannelHelper()
        {
            Init(typeof(SRChannel), typeof(forms.commonForm));
        }
    }
    public class SRChannel : DataSeries
    {
        public static SRChannel Series(DataSeries ds, double period, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (SRChannel)obj;

            SRChannel indicator = new SRChannel(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public SRChannel(DataSeries ds, double period, string name)
            : base(ds, name)
        {
            this.Name = name;
            int begin = 0, length = 0;

            DataSeries min = Indicators.MIN.Series(ds, period, "min");
            DataSeries max = Indicators.MAX.Series(ds, period, "max");

            max.Name = name + "-resistance";

            FirstValidValue = min.FirstValidValue;
            this.Name = name;

            for (int i = begin, j = 0; j < min.Count; i++, j++)
            {
                this[i] = min[j];
            }
            this.Cache.Add(max.Name, max);
        }

        public DataSeries Resistance
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-resistance");
            }
        }

        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[] { this.Resistance};
            }
        }
    }
}
