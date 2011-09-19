using System;
using application;

namespace Strategy
{
    #region strategy
    public class SMACUT : baseStrategy
    {
        public TradePoints Execute(application.Data data, int[] paras)
        {
            DataSeries line0 = Indicators.SMA.Series(data.Close, paras[0], "");
            DataSeries line1 = Indicators.SMA.Series(data.Close, paras[1], "");
            TradePoints tradePoints = new TradePoints();
            for (int idx = Math.Max(line0.FirstValidValue, line1.FirstValidValue); idx < Math.Min(line0.Count, line1.Count); idx++)
            {
                AppTypes.TradeActions action = (line0.Cut(line1, idx) == DataSeries.CutState.Up ? AppTypes.TradeActions.Sell : AppTypes.TradeActions.Buy);
                tradePoints.Add(action, idx);
            }
            return tradePoints;
        }
    }

    public class EMACUT : GenericStrategy
    {
        new public TradePoints Execute(application.Data data, int[] paras)
        {
            DataSeries line0 = Indicators.EMA.Series(data.Close, paras[0], "");
            DataSeries line1 = Indicators.EMA.Series(data.Close, paras[1], "");
            TradePoints tradePoints = new TradePoints();
            for (int idx = Math.Max(line0.FirstValidValue, line1.FirstValidValue); idx < Math.Min(line0.Count,line1.Count); idx++)
            {
                AppTypes.TradeActions action = (line0.Cut(line1, idx) == DataSeries.CutState.Up ? AppTypes.TradeActions.Sell : AppTypes.TradeActions.Buy);
                tradePoints.Add(action, idx);
            }
            return tradePoints;
        }
    }

    public class WMACUT : GenericStrategy
    {
        override public TradePoints Execute(application.Data data, int[] paras)
        {
            DataSeries line0 = Indicators.WMA.Series(data.Close, paras[0], "");
            DataSeries line1 = Indicators.WMA.Series(data.Close, paras[1], "");
            TradePoints tradePoints = new TradePoints();
            for (int idx = Math.Max(line0.FirstValidValue, line1.FirstValidValue); idx < Math.Min(line0.Count, line1.Count); idx++)
            {
                AppTypes.TradeActions action = (line0.Cut(line1, idx) == DataSeries.CutState.Up ? AppTypes.TradeActions.Sell : AppTypes.TradeActions.Buy);
                //BusinessInfo
                tradePoints.Add(action, idx);
            }
            return tradePoints;
        }
    }

    public class MACDSMACUT : GenericStrategy
    {
        override public TradePoints Execute(application.Data data, int[] paras)
        {
            DataSeries line0 = Indicators.MACD.Series(data.Close, paras[0], paras[1], paras[2], "");
            DataSeries line1 = Indicators.SMA.Series(data.Close, paras[3], "");
            TradePoints tradePoints = new TradePoints();
            for (int idx = Math.Max(line0.FirstValidValue, line1.FirstValidValue); idx < Math.Min(line0.Count, line1.Count); idx++)
            {
                AppTypes.TradeActions action = (line0.Cut(line1, idx) == DataSeries.CutState.Up ? AppTypes.TradeActions.Sell : AppTypes.TradeActions.Buy);
                tradePoints.Add(action, idx);
            }
            return tradePoints;
        }
    }
    #endregion

    #region strategy helper
    //============================================================
    // - Each strategy requires a  helper class that 
    // provides information to dynamically plug-in to the system
    // - Strategy without helper is invisible to the system
    //=============================================================
    public class SMACUT_Helper : baseHelper
    {
        public SMACUT_Helper() : base(typeof(SMACUT)) { }
    }
    public class EMACUT_Helper : baseHelper
    {
        public EMACUT_Helper() : base(typeof(EMACUT)) { }
    }
    public class WMACUT_Helper : baseHelper
    {
        public WMACUT_Helper() : base(typeof(WMACUT)) { }
    }

    public class MACDSMACUT_Helper : baseHelper
    {
        public MACDSMACUT_Helper() : base(typeof(MACDSMACUT)) { }
    }

    #endregion
}
