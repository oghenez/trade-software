//Copyright by NHQ, HCM city, 2011 
using System;
using System.Collections.Generic;
using System.Text;
using application;
using Indicators;

namespace strategy
{
    public class MACD_ADX : GenericStrategy
    {
        public MACD_ADX(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p) : base(d, code, fExport, curStrategy, p) { }
        
        protected override void StrategyExecute()
        {            
            MACD macd = Indicators.MACD.Series(new DataSeries(data.closePrice,""),
                (int)parameters.getParameter(0), (int)parameters.getParameter(1),
                (int)parameters.getParameter(2),"");
            DataBars db = new DataBars(new DataSeries(data.openPrice, ""), new DataSeries(data.hiPrice, "")
                , new DataSeries(data.loPrice, ""), new DataSeries(data.closePrice, ""), new DataSeries(data.totalVolume,""));

            ADX adx=new ADX(db,(int)parameters.getParameter(3),"");
            double delta = 0, lastDelta = 0;

            for (int idx = 1; idx < macd.Values.Length; idx++)
            {
                delta = (macd.HistSeries[idx] - macd.HistSeries[idx - 1]);
                //If there is a trend
                if (adx[idx] > 25)
                {
                    if (delta > 0 && lastDelta < 0)
                        BuyAtClose(idx);
                }
                //else
                //{
                //    Indicators.Stoch stoch = Indicators.Stoch.Series(db,15,5,5 ,"");
                //    //if (cu
                //}
                if (delta < 0 && lastDelta > 0)
                    SellAtClose(idx);
                lastDelta = delta;
            }
        }
    }
}
