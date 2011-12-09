//Copyright by NHQ, HCM city, 2011 
//Basic DMI strategy
//Buy when there is cut between DI+ and DI-
//The cut loss function work with some cut loss level

using System;
using System.Collections.Generic;
using System.Text;
using application;
using Indicators;

namespace Strategy
{
    public class BasicDMI_Helper : baseHelper
    {
        public BasicDMI_Helper() : base(typeof(BasicDMI)) { }
    }

    public class BasicDMI : GenericStrategy
    {
        override public TradePoints Execute(application.Data data, int[] parameters)
        {
            //application.Data vnidxData1 =  data.New("^VNINDEX");
            
            adviceInfo = new TradePoints();
            DataSeries minusDmi_14 = new Indicators.MinusDI(data.Bars, parameters[0], "");
            DataSeries plusDmi_14 = new Indicators.PlusDI(data.Bars, parameters[1], "");

            AppTypes.MarketTrend lastTrend = AppTypes.MarketTrend.Unspecified;
            AppTypes.MarketTrend currentTrend = AppTypes.MarketTrend.Unspecified;

            for (int idx = 0; idx < minusDmi_14.Count; idx++)
            {

                currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? AppTypes.MarketTrend.Upward : AppTypes.MarketTrend.Downward);
                if (lastTrend == AppTypes.MarketTrend.Downward && currentTrend == AppTypes.MarketTrend.Upward)
                    BuyAtClose(idx);
                if (lastTrend == AppTypes.MarketTrend.Upward && currentTrend == AppTypes.MarketTrend.Downward)
                    SellAtClose(idx);
                lastTrend = currentTrend;
            }
            return adviceInfo;

        }

        //public override TradePoints Execute_CutLoss()
        //{

        //    double[] minusDmi_14 = data.MinusDI((int)parameters.getParameter(0));
        //    double[] plusDmi_14 = data.PlusDI((int)parameters.getParameter(1));
        //    int CUTLOSS_LEVEL = (int)parameters.getParameter(2);

        //    double bought_price = 0, distanceStopLoss = 0;
        //    bool is_bought = false;
        //    analysis.analysisResult adviceInfo = new analysis.analysisResult();
        //    AppTypes.TradeActions lastTrend = AppTypes.TradeActions.None;
        //    AppTypes.TradeActions currentTrend = AppTypes.TradeActions.None;

        //    for (int idx = 0; idx < minusDmi_14.Length; idx++)
        //    {

        //        currentTrend = ((plusDmi_14[idx] > minusDmi_14[idx]) ? AppTypes.TradeActions.Buy : AppTypes.TradeActions.Sell);

        //        //Buy Condition
        //        if (lastTrend == AppTypes.TradeActions.Sell && currentTrend == AppTypes.TradeActions.Buy)
        //        {
        //            adviceInfo.Add(AppTypes.TradeActions.Buy, idx);
        //            bought_price = data.closePrice[idx];
        //            is_bought = true;
        //        }

        //        //Sell Condition
        //        if (is_bought && lastTrend == AppTypes.TradeActions.Buy && currentTrend == AppTypes.TradeActions.Sell)
        //        {
        //            adviceInfo.Add(AppTypes.TradeActions.Sell, idx);
        //            is_bought = false;
        //        }

        //        //Cut loss Condition
        //        if (bought_price > 0)
        //            distanceStopLoss = (data.closePrice[idx] - bought_price) / bought_price * 100;
        //        else
        //            distanceStopLoss = 0;

        //        if (is_bought && distanceStopLoss <= CUTLOSS_LEVEL)
        //        {
        //            adviceInfo.Add(AppTypes.TradeActions.Sell, idx);
        //            is_bought = false;
        //        }
        //        lastTrend = currentTrend;
        //    }
        //    if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, plusDmi_14, minusDmi_14);
        //    return adviceInfo;
        //}
    }
}
