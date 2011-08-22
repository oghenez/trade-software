/*Tim kiem cac co phieu 
 */
using System;
using System.Collections.Generic;
using System.Text;
using application;
namespace strategy
{
    public class PriceScreening : GenericScreening
    {
        public PriceScreening(analysis.workData d, string code, bool fExport, string curStrategy, Parameters p) : base(d, code, fExport, curStrategy, p) { }
        protected override void StrategyExecute()
        {
            int Bar = data.closePrice.Length-1;
            if (Bar <= 1) return;
            double[] close = data.closePrice;
            double[] sma5 = data.SMA(5);

            double[] volume = data.totalVolume;

            bool condition = (close[Bar] > sma5[Bar]) && (volume[Bar] > volume[Bar - 1])&&(volume[Bar]>30000)?true:false;
           
            analysis.tradePointInfo tradepointinfo = new analysis.tradePointInfo();
            tradepointinfo.price = (decimal)close[Bar];
            tradepointinfo.volume = (int)volume[Bar];
            //tradepointinfo.value1 = Price_3SMA_Risk_Reward*2+3-volueme ;
            //tradepointinfo.value2= sales*2/income;
            //tradepointinfo.value3=sales;

            if (condition)
                BuyAtClose(Bar);
                 //(Bar, tradepointinfo);

            //Find all stocks that have Buy Signal from Strategy from x days
            //signal=0,1,2,3 ; adviceInfo=dataseries; 
            
            //if buysignal()

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
            if (fExportData) 
                analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data,close, sma5, volume);
        }

        public override analysis.analysisResult Execute()
        {
            StrategyExecute();            
            return adviceInfo;
        }
    }
}
