using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace Indicators
{
    public class KELTNERHelper : Helpers
    {
        public KELTNERHelper()
        {
            Init(typeof(KELTNER), typeof(forms.commonForm),typeof(DataBars));
        }
    }
	public class KELTNER : DataSeries
    {
        public static KELTNER Series(DataBars ds, double EmaPeriod, double AtrMult, double AtrPeriod, string name)
        {
            //Build description
            string description = "(" + name + "," + EmaPeriod.ToString() + "," + AtrMult.ToString() + "," + AtrPeriod.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (KELTNER)obj;

            KELTNER indicator = new KELTNER(ds, EmaPeriod, AtrMult, AtrPeriod, description);
            ds.Cache.Add(description,indicator);
            return indicator;
        }

        public KELTNER(DataBars ds, double EmaPeriod, double AtrMult, double AtrPeriod, string name)
            : base(ds, name)
        {
            this.Name = name;
            int begin = 0, length = 0;

            DataSeries ema = EMA.Series(ds.Close, EmaPeriod, "ema");
            DataSeries atr = ATR.Series(ds, AtrPeriod, "atr");

            //DataSeries upperSeries = new DataSeries(ds, name + "-upper");
            DataSeries upperSeries = ema + AtrMult * atr;
            upperSeries.Name = name + "-upper";

            // DataSeries lowerSeries = new DataSeries(ds, name + "-lower");
            DataSeries lowerSeries = ema - AtrMult * atr;
            lowerSeries.Name = name + "-lower";
            FirstValidValue = Math.Max(ema.FirstValidValue, upperSeries.FirstValidValue);
            this.Name = name;

            upperSeries.FirstValidValue = FirstValidValue;
            lowerSeries.FirstValidValue = FirstValidValue;
            for (int i = begin, j = 0; j < ema.Count; i++, j++)
            {
                this[i] = ema[j];
            }
            //Cache series
            this.Cache.Add(upperSeries.Name,upperSeries);
            this.Cache.Add(lowerSeries.Name,lowerSeries);
        }
      
        public DataSeries UpperSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-upper");
            }
        }
        public DataSeries LowerSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-lower");
            }
        }
        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[] { this.UpperSeries,this.LowerSeries};
            }
        }
    }
}
