using System;
using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    #region Indicator
    // SMA, EMA, WMA , RSI
    public class baseSMA : DataSeries
    {
        protected enum Types : byte { SMA = 1, EMA = 2, WMA = 3, RSI = 4 };
        protected static baseSMA Series(DataSeries ds, Types type, int period, string name)
        {
            //Build description
            string description = "(" + name + "," + period + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj!=null) return (baseSMA)obj;
            //Create SMA, cache it, return it
            baseSMA sma = new baseSMA(ds, type, period, description);
            ds.Cache.Add(description,sma);
            return sma;
        }
        protected baseSMA(DataSeries ds, Types type, int period, string name): base(ds, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;
            double[] output = new double[ds.Count];
            switch (type)
            {
                case Types.SMA:
                    retCode = Core.Sma(0, ds.Count - 1, ds.Values, period, out begin, out length, output); break;
                case Types.EMA:
                    retCode = Core.Ema(0, ds.Count - 1, ds.Values, period, out begin, out length, output); break;
                case Types.WMA:
                    retCode = Core.Wma(0, ds.Count - 1, ds.Values, period, out begin, out length, output); break;
                case Types.RSI:
                    retCode = Core.Rsi(0, ds.Count - 1, ds.Values, period, out begin, out length, output); break;
            }
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
    public class SMA : baseSMA
    {
        public SMA(DataSeries ds, int period, string name): base(ds,Types.SMA ,period,name){}
        public static baseSMA Series(DataSeries ds, int period, string name)
        {
            return Series(ds, Types.SMA, period, name);
        }
    }
    public class EMA : baseSMA
    {
        public EMA(DataSeries ds, int period, string name): base(ds,Types.EMA ,period,name){}
        public static baseSMA Series(DataSeries ds, int period, string name)
        {
            return Series(ds, Types.EMA, period, name);
        }
    }
    public class WMA : baseSMA
    {
        public WMA(DataSeries ds, int period, string name) : base(ds, Types.WMA, period, name) { }
        public static baseSMA Series(DataSeries ds, int period, string name)
        {
            return Series(ds, Types.WMA, period, name);
        }
    }
    public class RSI : baseSMA
    {
        public RSI(DataSeries ds, int period, string name) : base(ds, Types.RSI, period, name) { }
        public static baseSMA Series(DataSeries ds, int period, string name)
        {
            return Series(ds, Types.RSI, period, name);
        }
    }

    // MACD
    public class MACD : DataSeries
    {
        public static MACD Series(DataSeries ds, int fastPeriod, int slowPeriod, int signalPeriod, string name)
        {
            //Build description
            string description = "(" + name + "," + fastPeriod.ToString() + "," + slowPeriod.ToString() +","+signalPeriod.ToString()+ ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj!=null) return (MACD)obj;
            
            //Create MACD, cache it, return it
            MACD macd = new MACD(ds, fastPeriod, slowPeriod, signalPeriod, description);
            ds.Cache.Add(description,macd);
            return macd;
        }
        public MACD(DataSeries ds, int fastPeriod, int slowPeriod, int signalPeriod, string name) : base(ds, name)
        {
            this.Name = name;
            int begin = 0, length = 0;
            double[] output = new double[ds.Count];
            double[] sigOutput = new double[ds.Count];
            double[] histOutput = new double[ds.Count];
            Core.RetCode retCode = Core.Macd(0, ds.Count - 1, ds.Values, fastPeriod, slowPeriod, signalPeriod,
                                             out begin, out length, output, sigOutput, histOutput);

            if (retCode != Core.RetCode.Success) return;
            FirstValidValue = begin;
            this.Name = name;
            DataSeries sigSeries =  new DataSeries(ds, name + "-signal");
            DataSeries histSeries = new DataSeries(ds, name + "-hist");
            sigSeries.FirstValidValue = begin;
            histSeries.FirstValidValue = begin;
            for (int i = begin, j = 0; j < length; i++, j++)
            {
                this[i] = output[j];
                sigSeries.Values[i] = sigOutput[j];
                histSeries.Values[i] = histOutput[j];
            }
            //Cache series
            this.Cache.Add(sigSeries.Name,sigSeries);
            this.Cache.Add(histSeries.Name,histSeries);
            return;
        }
        public DataSeries SignalSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-signal");
            }
        }
        public DataSeries HistSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-hist");
            }
        }
        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[]{this.SignalSeries,this.HistSeries};
            }
        }
    }

    //  ADX, PlusDI, MinusDI, PlusDM, MinusDM 
    public class baseDX : DataSeries 
    {
        protected enum Types : byte { ADX = 1, PlusDI = 2, MinusDI = 3, PlusDM = 4, MinusDM = 5 };
        protected static baseDX Series(DataBars db, Types type, int period, string name)
        {
            //Build description
            string description = "(" + name + "," + period + ")";
            //See if it exists in the cache
            object obj = db.Cache.Find(description);
            if (obj!=null) return (baseDX)obj;
            //Create DI, cache it, return it
            baseDX di = new baseDX(db, type, period, description);
            db.Cache.Add(description, di);
            return di;
        }
        protected baseDX(DataBars db, Types type, int period, string name) : base(db, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;
            double[] output = new double[db.Count];
            switch (type)
            {
                case Types.ADX:
                     retCode = Core.Dx(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, period, out begin, out length, output); 
                     break;
                case Types.PlusDI :
                     retCode = Core.PlusDI(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, period, out begin, out length, output); 
                     break;
                case Types.MinusDI:
                     retCode = Core.MinusDI(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values, period, out begin, out length, output); 
                     break;
                case Types.MinusDM:
                     retCode = Core.MinusDM(0, db.Count - 1, db.High.Values, db.Low.Values,period, out begin, out length, output);
                     break;
                case Types.PlusDM:
                     retCode = Core.PlusDM(0, db.Count - 1, db.High.Values, db.Low.Values, period, out begin, out length, output);
                     break;
            }
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
    public class ADX : baseDX
    {
        public ADX(DataBars db, int period, string name) : base(db, Types.ADX, period, name) { }
        public static baseDX Series(DataBars db, int period, string name)
        {
            return Series(db, Types.ADX, period, name);
        }
    }
    public class PlusDI : baseDX
    {
        public PlusDI(DataBars ds, int period, string name) : base(ds, Types.PlusDI, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return Series(ds, Types.PlusDI, period, name);
        }
    }
    public class MinusDI : baseDX
    {
        public MinusDI(DataBars ds, int period, string name) : base(ds, Types.MinusDI, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return Series(ds, Types.MinusDI, period, name);
        }
    }
    public class PlusDM : baseDX
    {
        public PlusDM(DataBars ds, int period, string name) : base(ds, Types.PlusDM, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return Series(ds, Types.PlusDM, period, name);
        }
    }
    public class MinusDM : baseDX
    {
        public MinusDM(DataBars ds, int period, string name) : base(ds, Types.MinusDM, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return Series(ds, Types.MinusDM, period, name);
        }
    }

    // StockRSI
    public class StochRSI : DataSeries
    {
        public static StochRSI Series(DataSeries ds, int rsiPeriod, int fastK_Period, int fastD_Period, string name)
        {
            //Build description
            string description = "(" + name + "," + rsiPeriod.ToString()+ "," + fastK_Period.ToString() + "," + fastD_Period.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if( obj!=null) return (StochRSI)obj;

            StochRSI stochRSI = new StochRSI(ds, rsiPeriod, fastK_Period, fastD_Period, description);
            ds.Cache.Add(description,stochRSI);
            return stochRSI;
        }
        public StochRSI(DataSeries ds, int rsiPeriod, int fastK_Period, int fastD_Period, string name) : base(ds, name)
        {
            this.Name = name;
            int begin = 0, length = 0;
            double[] output = new double[ds.Count];
            double[] outFastK = new double[ds.Count];
            double[] outFastD = new double[ds.Count];
            Core.RetCode retCode = Core.StochRsi(0, ds.Count - 1, ds.Values, rsiPeriod, fastK_Period, fastD_Period,Core.MAType.Ema,
                                               out begin, out length, outFastK, outFastD);

            if (retCode != Core.RetCode.Success) return;
            FirstValidValue = begin;
            this.Name = name;
            DataSeries fastDSeries = new DataSeries(ds, name + "-fastD");
            fastDSeries.FirstValidValue = begin;
            for (int i = begin, j = 0; j < length; i++, j++)
            {
                this[i] = outFastK[j];
                fastDSeries.Values[i] = outFastD[j];
            }
            //Cache series
            this.Cache.Add(fastDSeries.Name,fastDSeries);
            return;
        }
        public DataSeries FastKSeries
        {
            get {return this;}
        }
        public DataSeries FastDSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-fastD");
            }
        }
        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[]{this.FastDSeries};
            }
        }
    }

    // BBANDS
    public class BBANDS : DataSeries
    {
        public static BBANDS Series(DataSeries ds, int period, int kUp, int kDn, string name)
        {
            //Build description
            string description = "(" + name + "," + period.ToString() + "," + kUp.ToString() + "," + kDn.ToString() + ")";
            //See if it exists in the cache
            object obj = ds.Cache.Find(description);
            if (obj != null) return (BBANDS)obj;

            BBANDS bBands = new BBANDS(ds, period, kUp, kDn, description);
            ds.Cache.Add(description,bBands);
            return bBands;
        }
        public BBANDS(DataSeries ds, int period, int kUp, int kDn, string name)  : base(ds, name)
        {
            this.Name = name;
            int begin = 0, length = 0;
            double[] outUpperList = new double[ds.Count];
            double[] outMiddleList = new double[ds.Count];
            double[] outLowerList = new double[ds.Count];
            Core.RetCode retCode = Core.Bbands(0, ds.Count - 1, ds.Values,period, kUp, kDn, Core.MAType.Sma,
                                               out begin, out length, outUpperList, outMiddleList, outLowerList);

            if (retCode != Core.RetCode.Success) return;
            FirstValidValue = begin;
            this.Name = name;
            DataSeries upperSeries = new DataSeries(ds, name + "-upper");
            DataSeries lowerSeries = new DataSeries(ds, name + "-lower");
            upperSeries.FirstValidValue = begin;
            lowerSeries.FirstValidValue = begin;
            for (int i = begin, j = 0; j < length; i++, j++)
            {
                this[i] = outMiddleList[j];
                upperSeries.Values[i] = outUpperList[j];
                lowerSeries.Values[i] = outLowerList[j];
            }
            //Cache series
            this.Cache.Add(upperSeries.Name,upperSeries);
            this.Cache.Add(lowerSeries.Name,lowerSeries);
            return;
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

    // StochF
    public class StochF : DataSeries
    {
        public static StochF Series(DataBars db, int fastK_Period, int fastD_Period, string name)
        {
            //Build description
            string description = "(" + name + "," + fastK_Period.ToString() + "," + fastD_Period.ToString() + ")";
            //See if it exists in the cache
            object obj = db.Cache.Find(description);
            if (obj != null) return (StochF)obj;

            StochF stochF = new StochF(db,fastK_Period, fastD_Period, description);
            db.Cache.Add(description, stochF);
            return stochF;
        }
        public StochF(DataBars db, int fastK_Period, int fastD_Period, string name)   : base(db, name)
        {
            this.Name = name;
            int begin = 0, length = 0;
            double[] outFastK = new double[db.Count];
            double[] outFastD = new double[db.Count];
            Core.RetCode retCode = Core.StochF(0, db.Count - 1, db.High.Values,db.Low.Values,db.Close.Values, fastK_Period, fastD_Period, Core.MAType.Sma,
                                                           out begin, out length, outFastK, outFastD);

            if (retCode != Core.RetCode.Success) return;
            FirstValidValue = begin;
            this.Name = name;
            DataSeries fastDSeries = new DataSeries(db, name + "-fastD");
            fastDSeries.FirstValidValue = begin;
            for (int i = begin, j = 0; j < length; i++, j++)
            {
                this[i] = outFastK[j];
                fastDSeries.Values[i] = outFastD[j];
            }
            //Cache series
            this.Cache.Add(fastDSeries.Name, fastDSeries);
            return;
        }
        public DataSeries FastKSeries
        {
            get { return this; }
        }
        public DataSeries FastDSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-fastD");
            }
        }
        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[] { this.FastDSeries };
            }
        }
    }

    public class Stoch : DataSeries
    {
        public static Stoch Series(DataBars db, int fastK_Period, int slowK_Period, int slowD_Period, string name)
        {
            //Build description
            string description = "(" + name + "," + fastK_Period.ToString() + "," + slowK_Period.ToString() + "," + slowD_Period.ToString() + ")";
            //See if it exists in the cache
            object obj = db.Cache.Find(description);
            if (obj != null) return (Stoch)obj;

            Stoch stoch = new Stoch(db, fastK_Period, slowK_Period, slowD_Period, description);
            db.Cache.Add(description,stoch);
            return stoch;
        }
        public Stoch(DataBars db, int fastK_Period, int slowK_Period, int slowD_Period, string name) : base(db, name)
        {
            this.Name = name;
            int begin = 0, length = 0;
            double[] outSlowK = new double[db.Count];
            double[] outSlowD = new double[db.Count];
            Core.RetCode retCode = Core.Stoch(0, db.Count - 1, db.High.Values, db.Low.Values, db.Close.Values,
                                                fastK_Period, slowK_Period, Core.MAType.Sma, slowD_Period, Core.MAType.Sma,
                                                out begin, out length, outSlowK, outSlowD);

            if (retCode != Core.RetCode.Success) return;
            FirstValidValue = begin;
            this.Name = name;
            DataSeries slowDSeries = new DataSeries(db, name + "-slowD");
            slowDSeries.FirstValidValue = begin;
            for (int i = begin, j = 0; j < length; i++, j++)
            {
                this[i] = outSlowK[j];
                slowDSeries.Values[i] = outSlowD[j];
            }
            //Cache series
            this.Cache.Add(slowDSeries.Name, slowDSeries);
            return;
        }
        public DataSeries SlowKSeries
        {
            get { return this; }
        }
        public DataSeries SlowDSeries
        {
            get
            {
                return (DataSeries)this.Cache.Find(this.Name + "-slowD");
            }
        }
        public DataSeries[] ExtraSeries
        {
            get
            {
                return new DataSeries[] { this.SlowDSeries };
            }
        }
    }

    #endregion

    #region Indicator helper
    
    //============================================================
    // - Each indicator requires an indicator helper class that 
    // provides information to dynamically plug-in to the system
    // - Indicator without helper is invisible to the system
    //=============================================================
    public class SMAHelper : Helpers
    {
        public SMAHelper()
        {
            Init(typeof(SMA), typeof(forms.commonForm));
        }
    }
    public class EMAHelper : Helpers
    {
        public EMAHelper()
        {
            Init(typeof(EMA), typeof(forms.commonForm));
        }
    }
    public class WMAHelper : Helpers
    {
        public WMAHelper()
        {
            Init(typeof(WMA), typeof(forms.commonForm));
        }
    }
    public class RSIHelper : Helpers
    {
        public RSIHelper()
        {
            Init(typeof(RSI), typeof(forms.commonForm));
        }
    }
    public class MACDHelper : Helpers
    {
        public MACDHelper()
        {
            //Init(typeof(MACD), typeof(forms.MACD));
            Init(typeof(MACD), typeof(forms.commonForm));
        }
    }

    public class ADXHelper : Helpers
    {
        public ADXHelper()
        {
            Init(typeof(ADX), typeof(forms.commonForm), typeof(DataBars));
        }
    }
    public class PlusDIHelper : Helpers
    {
        public PlusDIHelper()
        {
            Init(typeof(PlusDI), typeof(forms.commonForm), typeof(DataBars));
        }
    }
    public class MinusDIHelper : Helpers
    {
        public MinusDIHelper()
        {
            Init(typeof(MinusDI), typeof(forms.commonForm), typeof(DataBars));
        }
    }
    public class PlusDMHelper : Helpers
    {
        public PlusDMHelper()
        {
            Init(typeof(PlusDM), typeof(forms.commonForm), typeof(DataBars));
        }
    }
    public class MinusDMHelper : Helpers
    {
        public MinusDMHelper()
        {
            Init(typeof(MinusDM), typeof(forms.commonForm), typeof(DataBars));
        }
    }

    public class BBANDSIHelper : Helpers
    {
        public BBANDSIHelper()
        {
            Init(typeof(BBANDS), typeof(forms.commonForm));
        }
    }

    public class StochHelper : Helpers
    {
        public StochHelper()
        {
            Init(typeof(Stoch), typeof(forms.commonForm), typeof(DataBars));
        }
    }
    
    public class StochFHelper : Helpers
    {
        public StochFHelper()
        {
            Init(typeof(StochF), typeof(forms.commonForm), typeof(DataBars));
        }
    }

    public class StochRSIHelper : Helpers
    {
        public StochRSIHelper()
        {
            Init(typeof(StochRSI), typeof(forms.commonForm));
        }
    }

    #endregion
}
