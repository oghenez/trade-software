using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TicTacTec.TA.Library;
using test.application;

namespace test.Indicators
{
    public class Consts
    {
        public const string constIndicatorMetaFile = "indicators.xml";
    }

    //Ready-to-use data 
    public class MyData 
     {
         public MyData(global::data.baseDS.priceDataDataTable tbl)
         {
             this.priceDataTbl = tbl;
             Clear();
         }
         private global::data.baseDS.priceDataDataTable priceDataTbl = null;
         private DataSeries _close = null, _dateTime = null;
         private void Clear()
         {
             _close = null;
             _dateTime = null;
         }
         public DataSeries Close
         {
             get
             {
                 if (_close == null)
                 {
                     _close = libs.GetData(this.priceDataTbl, 0, libs.DataType.Close);
                 }
                 return _close;
             }
         }
         public DataSeries DateTime
         {
             get
             {
                 if (_dateTime == null)
                 {
                     _dateTime = libs.GetData(this.priceDataTbl, 0, libs.DataType.DateTime);
                 }
                 return _dateTime;
             }
         }
     }

    #region Indicator helper
    // SMA, EMA, WMA , RSI
    public class baseSMA : DataSeries
    {
        protected enum Types : byte { SMA = 1, EMA = 2, WMA = 3, RSI = 4 };
        protected static baseSMA CreateSeries(DataSeries ds, Types type, int period, string name)
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
            //Calculate moving average values
            for (int idx = 0; idx < begin; idx++) this[idx] = 0;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
    public class SMA : baseSMA
    {
        public SMA(DataSeries ds, int period, string name): base(ds,Types.SMA ,period,name){}
        public static baseSMA Series(DataSeries ds, int period, string name)
        {
            return CreateSeries(ds, Types.SMA, period, name);
        }
    }
    public class EMA : baseSMA
    {
        public EMA(DataSeries ds, int period, string name): base(ds,Types.EMA ,period,name){}
        public static baseSMA Series(DataSeries ds, int period, string name)
        {
            return CreateSeries(ds, Types.EMA, period, name);
        }
    }
    public class WMA : baseSMA
    {
        public WMA(DataSeries ds, int period, string name) : base(ds, Types.WMA, period, name) { }
        public static baseSMA Series(DataSeries ds, int period, string name)
        {
            return CreateSeries(ds, Types.WMA, period, name);
        }
    }
    public class RSI : baseSMA
    {
        public RSI(DataSeries ds, int period, string name) : base(ds, Types.RSI, period, name) { }
        public static baseSMA Series(DataSeries ds, int period, string name)
        {
            return CreateSeries(ds, Types.RSI, period, name);
        }
    }

    // MACD
    public class MACD : DataSeries
    {
        public static MACD Series(DataSeries ds, int fastPeriod, int slowPeriod,string name)
        {
            //Build description
            string description = "(" + name + "," + fastPeriod.ToString() + "," + slowPeriod.ToString() + ")";
            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description)) return (MACD)ds.Cache[description];
            //Create MACD, cache it, return it
            MACD macd = new MACD(ds, fastPeriod, slowPeriod, description);
            ds.Cache[description] = macd;
            return macd;
        }
        public MACD(DataSeries ds, int fastPeriod, int slowPeriod, string name) : base(ds, name)
        {
            DataSeries macd = EMA.Series(ds, fastPeriod,name) - EMA.Series(ds, slowPeriod,name);
            macd.FirstValidValue = slowPeriod - 1;
            this.Set(macd);
            this.Name = name;
        }

        //  Signal Line: 9-day EMA of MACD
        //  MACD Histogram: MACD - Signal Line
        public static DataSeries[] AllSeries(DataSeries ds, int fastPeriod, int slowPeriod, int signalPeriod, string name)
        {
            DataSeries[] seriesList = new DataSeries[3];

            //MACD
            DataSeries macd = new MACD(ds, fastPeriod, slowPeriod, name);
            seriesList[0] = macd;

            string description;
            //Signal series
            DataSeries signalMacd;
            description = "(" + name + "-signal," + signalPeriod.ToString() + ")";

            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description)) signalMacd = (DataSeries)ds.Cache[description];
            else
            {
                //Create,cache it, return it
                signalMacd = EMA.Series(macd,signalPeriod,name);
                ds.Cache[description] = signalMacd;
            }
            seriesList[1] = signalMacd;

            //Histogram series
            DataSeries histMacd;
            description = "(" + name + "-hist," + signalPeriod.ToString() + ")";
            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description)) histMacd = (DataSeries)ds.Cache[description];
            else
            {
                //Create,cache it, return it
                histMacd = macd - signalMacd;
                ds.Cache[description] = histMacd;
            }
            seriesList[2] = histMacd;
            return seriesList;
        }
    }

    //  ADX, PlusDI, MinusDI, PlusDM, MinusDM 
    public class baseDX : DataSeries 
    {
        protected enum Types : byte { ADX = 1, PlusDI = 2, MinusDI = 3, PlusDM = 4, MinusDM = 5 };
        protected static baseDX CreateSeries(DataBars ds, Types type, int period, string name)
        {
            //Build description
            string description = "(" + name + "," + period + ")";
            //See if it exists in the cache
            if (ds.Cache.ContainsKey(description))
                return (baseDX)ds.Cache[description];
            //Create DI, cache it, return it
            baseDX di = new baseDX(ds, type, period, description);
            ds.Cache[description] = di;
            return di;
        }
        protected baseDX(DataBars ds, Types type, int period, string name) : base(ds, name)
        {
            int begin = 0, length = 0;
            Core.RetCode retCode = Core.RetCode.UnknownErr;
            double[] output = new double[ds.Count];
            switch (type)
            {
                case Types.ADX:
                     retCode = Core.Dx(0, ds.Count - 1, ds.High.Values, ds.Low.Values, ds.Close.Values, period, out begin, out length, output); 
                     break;
                case Types.PlusDI :
                     retCode = Core.PlusDI(0, ds.Count - 1, ds.High.Values, ds.Low.Values, ds.Close.Values, period, out begin, out length, output); 
                     break;
                case Types.MinusDI:
                     retCode = Core.MinusDI(0, ds.Count - 1, ds.High.Values, ds.Low.Values, ds.Close.Values, period, out begin, out length, output); 
                     break;
                case Types.MinusDM:
                     retCode = Core.MinusDM(0, ds.Count - 1, ds.High.Values, ds.Low.Values,period, out begin, out length, output);
                     break;
                case Types.PlusDM:
                     retCode = Core.PlusDM(0, ds.Count - 1, ds.High.Values, ds.Low.Values, period, out begin, out length, output);
                     break;
            }
            if (retCode != Core.RetCode.Success) return;
            //Assign first bar that contains indicator data
            FirstValidValue = begin;
            this.Name = name;
            for (int idx = 0; idx < begin; idx++) this[idx] = 0;
            for (int i = begin, j = 0; j < length; i++, j++) this[i] = output[j];
        }
    }
    public class ADX : baseDX
    {
        public ADX(DataBars ds, int period, string name) : base(ds, Types.ADX, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return CreateSeries(ds, Types.ADX, period, name);
        }
    }
    public class PlusDI : baseDX
    {
        public PlusDI(DataBars ds, int period, string name) : base(ds, Types.PlusDI, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return CreateSeries(ds, Types.PlusDI, period, name);
        }
    }
    public class MinusDI : baseDX
    {
        public MinusDI(DataBars ds, int period, string name) : base(ds, Types.MinusDI, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return CreateSeries(ds, Types.MinusDI, period, name);
        }
    }
    public class PlusDM : baseDX
    {
        public PlusDM(DataBars ds, int period, string name) : base(ds, Types.PlusDM, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return CreateSeries(ds, Types.PlusDM, period, name);
        }
    }
    public class MinusDM : baseDX
    {
        public MinusDM(DataBars ds, int period, string name) : base(ds, Types.MinusDM, period, name) { }
        public static baseDX Series(DataBars ds, int period, string name)
        {
            return CreateSeries(ds, Types.MinusDM, period, name);
        }
    }

    #endregion

    #region Indicator helper
    
    //============================================================
    // - Each indicator requires an indicator helper class that 
    // provides information to dynamically plug-in to the system
    // - Indicator without helper is invisible to the system
    //=============================================================
    public class SMAHelper : IndicatorHelper
    {
        public SMAHelper()
        {
            Init(typeof(SMA), Consts.constIndicatorMetaFile);
        }
    }
    public class EMAHelper : IndicatorHelper
    {
        public EMAHelper()
        {
            Init(typeof(EMA), Consts.constIndicatorMetaFile);
        }
    }
    public class WMAHelper : IndicatorHelper
    {
        public WMAHelper()
        {
            Init(typeof(WMA), Consts.constIndicatorMetaFile);
        }
    }
    public class RSIHelper : IndicatorHelper
    {
        public RSIHelper()
        {
            Init(typeof(RSI), Consts.constIndicatorMetaFile);
        }
    }
    public class MACDHelper : IndicatorHelper
    {
        public MACDHelper()
        {
            Init(typeof(MACD), Consts.constIndicatorMetaFile);
        }
    }

    public class ADXHelper : IndicatorHelper
    {
        public ADXHelper()
        {
            Init(typeof(ADX), Consts.constIndicatorMetaFile);
        }
    }
    public class PlusDIHelper : IndicatorHelper
    {
        public PlusDIHelper()
        {
            Init(typeof(PlusDI), Consts.constIndicatorMetaFile);
        }
    }
    public class MinusDIHelper : IndicatorHelper
    {
        public MinusDIHelper()
        {
            Init(typeof(MinusDI), Consts.constIndicatorMetaFile);
        }
    }
    public class PlusDMHelper : IndicatorHelper
    {
        public PlusDMHelper()
        {
            Init(typeof(PlusDM), Consts.constIndicatorMetaFile);
        }
    }
    public class MinusDMHelper : IndicatorHelper
    {
        public MinusDMHelper()
        {
            Init(typeof(MinusDM), Consts.constIndicatorMetaFile);
        }
    }

    #endregion
    //Test
    public class test111
    {
        public enum indicatorType : byte
        {
            StockRSI = 11, BBANDS = 12, StochF = 13, StochS = 14
        };
        public static bool MakeStockRSI(int startIdx, int endIdx, double[] list, int rsiPeriod, int fastK_Period, int fastD_Period,
                                                out int begin, out int length, double[] outFastK, double[] outFastD)
        {
            begin = 0; length = 0;
            TicTacTec.TA.Library.Core.RetCode retCode = TicTacTec.TA.Library.Core.RetCode.UnknownErr;
            retCode = TicTacTec.TA.Library.Core.StochRsi(startIdx, endIdx, list, rsiPeriod, fastK_Period, fastD_Period, Core.MAType.Ema,
                                               out begin, out length, outFastK, outFastD);
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }


        public static bool MakeBBANDS(int startIdx, int endIdx, double[] list, int period, int kUp, int kDn,
                                      out int begin, out int length, double[] outUpperList, double[] outMiddleList, double[] outLowerList)
        {
            begin = 0; length = 0;
            TicTacTec.TA.Library.Core.RetCode retCode = TicTacTec.TA.Library.Core.RetCode.UnknownErr;
            retCode = TicTacTec.TA.Library.Core.Bbands(startIdx, endIdx, list, period, kUp, kDn, Core.MAType.Sma,
                                                       out begin, out length, outUpperList, outMiddleList, outLowerList);
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }

        public static bool MakeStochasticFast(int startIdx, int endIdx, double[] hiList, double[] loList, double[] closeList,
                                              int fastK_Period, int fastD_Period,
                                              out int begin, out int length, double[] outFastK, double[] outFastD)
        {
            begin = 0; length = 0;
            Core.RetCode retCode = Core.StochF(startIdx, endIdx, hiList, loList, closeList, fastK_Period, fastD_Period, Core.MAType.Sma,
                                               out begin, out length, outFastK, outFastD);
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }
        public static bool MakeStochasticSlow(int startIdx, int endIdx, double[] hiList, double[] loList, double[] closeList,
                                              int fastK_Period, int slowK_Period, int slowD_Period,
                                              out int begin, out int length, double[] outSlowK, double[] outSlowD)
        {
            begin = 0; length = 0;
            Core.RetCode retCode = Core.Stoch(startIdx, endIdx, hiList, loList, closeList, fastK_Period, slowK_Period,
                                              Core.MAType.Sma, slowD_Period, Core.MAType.Sma,
                                              out begin, out length, outSlowK, outSlowD);
            if (retCode != TicTacTec.TA.Library.Core.RetCode.Success) return false;
            return true;
        }
    }
}
