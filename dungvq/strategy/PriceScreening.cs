using System;
using System.Collections.Generic;
using System.Text;
using application;
namespace strategy
{
    public class PriceScreening : GenericStrategy
    {
        public PriceScreening(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p) : base(d, code, fExport, curStrategy, p) { }
        public override analysis.analysisResult Execute()
        {
            int Bar = data.closePrice.Length-1;
            if (Bar <= 1) return adviceInfo;
            double[] close = data.closePrice;
            
            double[] volume = data.totalVolume;
            if (volume[Bar] >volume[Bar-1])
                BuyAtClose(Bar);

            //Find all stocks that have Macd Signal above Macd Line
            //double[] macd = null, ema = null, hist = null;
            //data.MACD(12,26,9, ref macd, ref ema, ref hist);

            //if ((macd[Bar]>0) &&(macd[Bar] > ema[Bar]))
            //    BuyAtClose(Bar);

            ////Find all stocks that have SMA 5 above SMA 10
            //double[] sma5 = data.SMA(5);
            //double[] sma10 = data.SMA(10);

            //if ((close[Bar] > sma5[Bar]) && (sma5[Bar] > sma10[Bar]))
            //    BuyAtClose(Bar);

            ////Find all stocks that have Price above SMa 200
            //double[] sma200 = data.SMA(200);
            //if ((close[Bar] > sma200[Bar]))
            //    BuyAtClose(Bar);
            if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, close);
            return adviceInfo;
        }
    }
}
