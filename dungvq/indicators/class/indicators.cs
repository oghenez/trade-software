using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;
using application;

namespace Indicators
{
    
    public class IndicatorFormInfo
    {
        public myTypes.chartType chartType = myTypes.chartType.Line;
        public Color[] color = null;
        public int[] paras = null;
        public byte weight = 1;
        public bool inNewWindows = false;
    }
    
    
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
            if (ds.Cache.ContainsKey(description))
                return (baseSMA)ds.Cache[description];
            //Create SMA, cache it, return it
            baseSMA sma = new baseSMA(ds, type, period, description);
            ds.Cache[description] = sma;
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
        protected static MACD Series(DataSeries ds, int fastPeriod, int slowPeriod, int signalPeriod, string name)
        {
            //Build description
            string description = "(" + name + "," + fastPeriod.ToString() + "," + slowPeriod.ToString() + ")";
            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description)) return (MACD)ds.Cache[description];

            //Create MACD, cache it, return it
            MACD macd = new MACD(ds, fastPeriod, slowPeriod, signalPeriod, description);
            ds.Cache[description] = macd;
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
            this.Cache[sigSeries.Name] = sigSeries;
            this.Cache[histSeries.Name] = histSeries;
            return;
        }
        public DataSeries SignalSeries
        {
            get
            {
                string description = this.Name + "-signal";
                return (this.Cache.ContainsKey(description) ? this.Cache[description] : null);
            }
        }
        public DataSeries HistSeries
        {
            get
            {
                string description = this.Name + "-hist";
                return (this.Cache.ContainsKey(description) ? this.Cache[description] : null);
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
            if (db.Cache.ContainsKey(description))
                return (baseDX)db.Cache[description];
            //Create DI, cache it, return it
            baseDX di = new baseDX(db, type, period, description);
            db.Cache[description] = di;
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
        protected static StochRSI Series(DataSeries ds, int rsiPeriod, int fastK_Period, int fastD_Period, string name)
        {
            //Build description
            string description = "(" + name + "," + rsiPeriod.ToString()+ "," + fastK_Period.ToString() + "," + fastD_Period.ToString() + ")";
            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description)) return (StochRSI)ds.Cache[description];

            StochRSI stochRSI = new StochRSI(ds, rsiPeriod, fastK_Period, fastD_Period, description);
            ds.Cache[description] = stochRSI;
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
            this.Cache[fastDSeries.Name] = fastDSeries;
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
                string description = this.Name + "-fastD";
                return (this.Cache.ContainsKey(description) ? this.Cache[description] : null);
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
        //protected static BBANDS Series(DataSeries ds, int period, int kUp, int kDn, string name)
        //{
        //    //Build description
        //    string description = "(" + name + "," + period.ToString() + "," + kUp.ToString() + "," + kDn.ToString() + ")";
        //    //See if it exists in the cache
        //    if (ds.Cache.ContainsKey(description)) return (BBANDS)ds.Cache[description];

        //    BBANDS bBands = new BBANDS(ds, period, kUp, kDn, description);
        //    ds.Cache[description] = bBands;
        //    return bBands;
        //}
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
            this.Cache[upperSeries.Name] = upperSeries;
            this.Cache[lowerSeries.Name] = lowerSeries;
            return;
        }
      
        public DataSeries UpperSeries
        {
            get
            {
                string description = this.Name + "-upper";                
                return (this.Cache.ContainsKey(description) ? this.Cache[description] : null);
            }
        }
        public DataSeries LowerSeries
        {
            get
            {
                string description = this.Name + "-lower";
                return (this.Cache.ContainsKey(description) ? this.Cache[description] : null);
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
        protected static StochF Series(DataBars db, int fastK_Period, int fastD_Period, string name)
        {
            //Build description
            string description = "(" + name + "," + fastK_Period.ToString() + "," + fastD_Period.ToString() + ")";
            //See if it exists in the cache
            if (db.Cache.ContainsKey(description)) return (StochF)db.Cache[description];

            StochF stochF = new StochF(db,fastK_Period, fastD_Period, description);
            db.Cache[description] = stochF;
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
            this.Cache[fastDSeries.Name] = fastDSeries;
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
                string description = this.Name + "-fastD";
                return (this.Cache.ContainsKey(description) ? this.Cache[description] : null);
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
        protected static Stoch Series(DataBars db, int fastK_Period, int slowK_Period, int slowD_Period, string name)
        {
            //Build description
            string description = "(" + name + "," + fastK_Period.ToString() + "," + slowK_Period.ToString() + "," + slowD_Period.ToString() + ")";
            //See if it exists in the cache
            if (db.Cache.ContainsKey(description)) return (Stoch)db.Cache[description];

            Stoch stoch = new Stoch(db, fastK_Period, slowK_Period, slowD_Period, description);
            db.Cache[description] = stoch;
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
            this.Cache[slowDSeries.Name] = slowDSeries;
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
                string description = this.Name + "-slowD";
                return (this.Cache.ContainsKey(description) ? this.Cache[description] : null);
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

}
