using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace Strategy
{
    /// <summary>
    /// Determine the trend of the market. Used for selecting the appropriate strategy
    /// </summary>
    public class MarketTrend:Rule
    {
    }

    public class ADXMarketTrend : MarketTrend
    {
        Indicators.ADX adx;
        public ADXMarketTrend(DataBars db,double period)
        {
            adx=new Indicators.ADX(db,period,"adx");
        }

        public override bool SideWay(int index)
        {
            if (index < adx.FirstValidValue) return false;
            if (adx[index] < 25) return true;
            return false;
        }

        public override bool Trending(int index)
        {
            if (index < adx.FirstValidValue) return false;
            if (adx[index] >= 25) return true;
            return false;
        }
    }

    public class BollingerKeltnerMarketTrend : MarketTrend
    {
        Indicators.BBANDS bolliger;
        Indicators.KELTNER keltner;

        public BollingerKeltnerMarketTrend(DataBars db, double BolligerPeriod, double kUp, double kDn, double EmaPeriod, double AtrMult, double AtrPeriod)
        {
            bolliger = Indicators.BBANDS.Series(db.Close, BolligerPeriod, kUp, kDn, "bolliger");
            keltner = Indicators.KELTNER.Series(db, EmaPeriod, AtrMult, AtrPeriod, "keltner");
        }

        
        public override bool SideWay(int index)        
        {
            if (index < Math.Max(bolliger.UpperSeries.FirstValidValue, keltner.UpperSeries.FirstValidValue))
                return false;
            if ((bolliger.UpperSeries[index] < keltner.UpperSeries[index])
               && (bolliger.LowerSeries[index] > keltner.LowerSeries[index]))
                return true;
            return false;
        }

        public override bool Trending(int index)
        {
            if (index < Math.Max(bolliger.UpperSeries.FirstValidValue, keltner.UpperSeries.FirstValidValue))
                return false;
            if ((bolliger.UpperSeries[index] >= keltner.UpperSeries[index])
               || (bolliger.LowerSeries[index] < keltner.LowerSeries[index]))
                return true;
            return false;
        }
    }

    public class ATRMarketTrend : MarketTrend
    {
        DataSeries atr;
        DataBars data;
        public ATRMarketTrend(DataBars db, double period, string name)
        {
            atr = Indicators.ATR.Series(db, period, name);
            data = db;
        }
        
        public override bool  SideWay(int index)
        {
            if (index - 1 < data.Close.FirstValidValue) return false;
            if ((data.Close[index]<=atr[index]+data.Close[index-1])
            &&  (data.Close[index]>-atr[index]+data.Close[index-1]))
                return true;
 	        return false;
        }
    }
}
