using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace Indicators
{
    public class FibonnanciHelper : Helpers
    {
        public FibonnanciHelper()
        {
            Init(typeof(Fibonnanci), typeof(forms.commonForm), typeof(DataBars));
        }
    }

    /// <summary>
    /// Trong 14 ngay, chon min va max. Tu diem min va max se tao ra 
    /// </summary>
    public class Fibonnanci : DataSeries
    {
        public static Fibonnanci Series(DataBars ds, double period, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (Fibonnanci)obj;

            Fibonnanci indicator = new Fibonnanci(ds, period, description);
            ds.Cache.Add(description, indicator);
            return indicator;
        }

        public Fibonnanci(DataBars ds, double period, string name)
            : base(ds, name)
        {
            this.Name = name;
            int begin = 0, length = 0;

            DataSeries min = Indicators.MIN.Series(ds.Low, period, "min");
            DataSeries fibo100 = Indicators.MAX.Series(ds.High, period, "max");
            DataSeries fibo23pc = new DataSeries(min, "fibo 23pc");
            DataSeries fibo38pc = new DataSeries(min, "fibo 38pc");
            DataSeries fibo50pc = new DataSeries(min, "fibo 50pc");
            DataSeries fibo62pc = new DataSeries(min, "fibo 62pc");

            fibo23pc.Name = name + "-fibo 23pc";
            fibo38pc.Name = name + "-fibo 38pc";
            fibo50pc.Name = name + "-fibo 50pc";
            fibo62pc.Name = name + "-fibo 62pc";

            fibo100.Name = name + "-fibo100";

            FirstValidValue = (int)Math.Max(0,min.Count-period-1);;
            fibo100.FirstValidValue=FirstValidValue;
            fibo23pc.FirstValidValue = FirstValidValue;
            fibo38pc.FirstValidValue=FirstValidValue;
            fibo50pc.FirstValidValue = FirstValidValue;
            fibo62pc.FirstValidValue = FirstValidValue;

            this.Name = name;

            for (int i = FirstValidValue; i < min.Count; i++)
            {
                this[i] = min[min.Count - 1];
                fibo100[i] = fibo100[fibo100.Count - 1];
                fibo23pc[i] = min[min.Count - 1] + (fibo100[fibo100.Count - 1] - min[min.Count - 1]) * 23.6 / 100;
                fibo38pc[i] = min[min.Count - 1] + (fibo100[fibo100.Count - 1] - min[min.Count - 1])*38.2/100;
                fibo50pc[i] = min[min.Count - 1] + (fibo100[fibo100.Count - 1] - min[min.Count - 1]) * 50 / 100;
                fibo62pc[i] = min[min.Count - 1] + (fibo100[fibo100.Count - 1] - min[min.Count - 1]) * 61.8 / 100;
            }
            this.Cache.Add(fibo100.Name, fibo100);
            this.Cache.Add(fibo23pc.Name, fibo38pc);
            this.Cache.Add(fibo38pc.Name, fibo38pc);
            this.Cache.Add(fibo50pc.Name, fibo50pc);
            this.Cache.Add(fibo62pc.Name, fibo62pc);
        }

        public DataSeries Fibo100
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-fibo100");
            }
        }

        public DataSeries Fibo23pc
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-fibo 23pc");
            }
        }

        public DataSeries Fibo38pc
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-fibo 38pc");
            }
        }

        public DataSeries Fibo50pc
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-fibo 50pc");
            }
        }

        public DataSeries Fibo62pc
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-fibo 62pc");
            }
        }

        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[] { this.Fibo23pc,this.Fibo38pc, this.Fibo50pc, this.Fibo62pc, this.Fibo100 };
            }
        }
    }
}
