using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using application;

namespace strategy
{
    public class libs
    {
        private static bool fExportData = false;
        private static string curStrategyCode = "";

        public static analysis.analysisResult Strategy(analysis.workData data, string strategyCode)
        {
            GenericStrategy strategy;
            curStrategyCode = strategyCode;

            switch (strategyCode)
            {
                #region Screening
                case "SCRPRICE":
                    {
                        Parameters p = null;
                        strategy = new PriceScreening(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                case "SCRMACD01":
                    {
                        Parameters p = new Parameters(12, 26, 9);
                        strategy = new BasicMACD(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Screening();
                    }
                case "SCRMACD02":
                    {
                        Parameters p = new Parameters(12, 26, 9);
                        strategy = new MACD_HistogramChanged(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Screening();
                    }
                case "SCRDMI":
                    {
                        Parameters p = new Parameters(14, 14);
                        strategy = new BasicDMI(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Screening();
                    }
                case "SCRSupport":
                    {
                        Parameters p = new Parameters(30, 0.01);
                        strategy = new SupportScreening(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Screening();
                    }
                case "SCRResist":
                    {
                        Parameters p = new Parameters(30, 0.01);
                        strategy = new ResistanceScreening(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Screening();
                    }

                case "BUYANDHOLD":
                    {
                        strategy = new BuyAndHoldStrategy(data, strategyCode, fExportData, curStrategyCode);
                        return strategy.Execute();
                    }
                #endregion

                #region SMA Strategy
                case "SMAONLY":
                    {
                        Parameters p = new Parameters(5, 10);
                        strategy = new TwoSMA(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                case "EMAONLY":
                    {
                        Parameters p = new Parameters(5, 10);
                        strategy = new TwoEMA(data, strategyCode, fExportData, curStrategyCode,p);
                        return strategy.Execute();
                    }
                case "WMAONLY":
                    {
                        strategy = new BasicWMA_5_10(data, strategyCode, fExportData, curStrategyCode);
                        return strategy.Execute();
                    }

                case "SMAPRICE":
                    {
                        //strategy = new Price_SMA_5_10(data, strategyCode, fExportData, curStrategyCode);
                        //return strategy.Execute();
                        Parameters p = new Parameters(50, 100);
                        strategy = new PriceTwoSMA(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }

                case "SMAVFIL":
                    {
                        Parameters p = new Parameters(5, 10, 50000);
                        strategy = new TwoSMA_VolumeFilter(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }

                case "3SMAPRICE":
                    {
                        Parameters p = new Parameters(5, 10, 20);
                        strategy = new BasicPrice_3SMA(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                case "3SMANEW":
                    {
                        Parameters p = new Parameters(10, 20, 30);
                        strategy = new BasicPrice_3SMA(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                case "SMARIRW":
                    {
                        Parameters p = new Parameters(5, 10, 20);
                        strategy = new Price_3SMA_Risk_Reward(data, strategyCode, fExportData, curStrategyCode,p);
                        return strategy.Execute();
                    }
                case "SMAMID":
                    {
                        Parameters p = new Parameters(20, 50);
                        strategy = new PriceTwoSMA(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                        //strategy = new Price_SMA_20_50(data, strategyCode, fExportData, curStrategyCode);
                        //return strategy.Execute();
                    }
                case "SMAM50_100":
                    {
                        Parameters p = new Parameters(50, 100);
                        strategy = new PriceTwoSMA(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                #endregion

                #region Statistic
                case "AVERAGE":
                    {
                        Parameters p = new Parameters(30, -15, 10);
                        strategy = new AverageStrategy(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }

                //Statistic
                case "AVERAGE1":
                    {
                        Parameters p = new Parameters(30, -15, 15);
                        strategy = new AverageStrategy(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                case "RAND":
                    {
                        Parameters p = null;
                        strategy = new RandomStrategy(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                //Statistic
                case "MARKOV":
                    {
                        Parameters p = null;
                        strategy = new SimpleMarkov(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                #endregion

                #region MACD strategy
                //MACD strategy

                case "MACDBAS":
                    {
                        Parameters p = new Parameters(12, 26, 9);
                        strategy = new BasicMACD(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                case "MACD1":
                    {
                        strategy = new MACD_Line_Cut(data, strategyCode, fExportData, curStrategyCode);
                        return strategy.Execute();
                    }
                case "MACD2":
                    {
                        Parameters p = new Parameters(12, 26, 9);
                        strategy = new MACD_HistogramChanged(data, strategyCode, fExportData, curStrategyCode,p);
                        return strategy.Execute();
                    }

                case "MACD_CL":
                    {
                        strategy = new MACD_HistogramChanged_CutLoss(data, strategyCode, fExportData, curStrategyCode);
                        return strategy.Execute();
                    }
                
                #endregion
                //Strategy with DMI indicator
                case "DMI":
                    {
                        Parameters p = new Parameters(14, 14);
                        strategy = new BasicDMI(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }

                case "DMI_CL":
                    {
                        Parameters p = new Parameters(14, 14, -5);
                        strategy = new BasicDMI(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute_CutLoss();
                    }

                //Strategy with Stochastic
                case "STOCHFAST":
                    {
                        Parameters p = new Parameters(14, 3);
                        strategy = new StochasticFast(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }

                //Strategy with Stochastic
                case "STOCHSLOW":
                    {
                        Parameters p = new Parameters(15, 5, 3);
                        strategy = new StochasticSlow(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }

                //Strategy with pattern
                case "PATERN32":
                    {
                        const int CONSECUTIVE_UP = 4;
                        const int CONSECUTIVE_DOWN = 3;
                        Parameters p = new Parameters(CONSECUTIVE_DOWN, CONSECUTIVE_UP);
                        strategy = new Pattern_Consecutive_UpAndDown(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }

                #region Hybrid strategy
                ////Hybrid strategy

                case "RSI":
                    {
                        int RSI_LOWER_LEVEL = 30;
                        int RSI_UPPER_LEVEL = 70;
                        double[] d = { 14, 26, 12, 9, RSI_LOWER_LEVEL, RSI_UPPER_LEVEL };
                        Parameters p = new Parameters(d);
                        strategy = new RSI_MACD_Histogram(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }

                case "SMASTOCH":
                    {
                        double[] d = { 5, 10, 15, 5, 3 };
                        Parameters p = new Parameters(d); ;
                        strategy = new SMA_Stochastic(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }

                case "MACDSTOC":
                    {
                        double[] d = { 20, 12, 26, 9, 15, 5, 3 };
                        Parameters p = new Parameters(d);
                        strategy = new MACD_Stochastic(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }

                case "MS_BOTTOM":
                    {
                        Parameters p = null;
                        strategy = new MACD_Stochastic_Bottom(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }

                case "MS_BOTv1":
                    {
                        Parameters p = null;
                        strategy = new MACD_Stochastic_Bottom_v1(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }
                case "TEST":
                    {
                        Parameters p = new Parameters(5, 10, 1.5);
                        strategy = new TestStrategy(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();

                    }

                case "MACD_ADX":
                    {
                        Parameters p = new Parameters(12, 26, 9,14);
                        strategy = new MACD_ADX(data, strategyCode, fExportData, curStrategyCode, p);
                        return strategy.Execute();
                    }
                #endregion

                default:
                    return null;
            }
        }


        //public static analysis.analysisResult StrategyCUT(analysis.workData data)
        //{
        //    double[] sma5 = data.SMA(5);
        //    double[] sma10 = data.SMA(10);
        //    analysis.analysisResult adviceInfo = new analysis.analysisResult();
        //    analysis.cutStat cutStat;
        //    for (int idx = 0; idx < sma5.Length; idx++)
        //    {
        //        cutStat = analysis.Cut(sma5, sma10, idx);
        //        analysis.tradeActions action = (cutStat == analysis.cutStat.Up ? analysis.tradeActions.Sell : analysis.tradeActions.Buy);
        //        //analysis.cutStat.
        //        adviceInfo.Add(action, idx);
        //    }
        //    if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
        //    return adviceInfo;
        //}

        //public static analysis.analysisResult StrategyVNIDX(analysis.workData data)
        //{
        //    double[] sma5 = data.SMA(5);
        //    double[] sma10 = data.SMA(10);
        //    double[] vnindex = data.StockData("^VNINDEX", stockLibs.stockDataField.Close);
        //    analysis.analysisResult adviceInfo = new analysis.analysisResult();
        //    analysis.tradeActions lastTrend = analysis.tradeActions.None;
        //    analysis.tradeActions currentTrend = analysis.tradeActions.None;

        //    int lastBuyId = 0;
        //    for (int idx = 0; idx < sma5.Length; idx++)
        //    {
        //        currentTrend = ((vnindex[idx] > sma5[idx]) && (sma5[idx] > sma10[idx]) ? analysis.tradeActions.Buy : analysis.tradeActions.Sell);
        //        if (lastTrend == analysis.tradeActions.Sell && currentTrend == analysis.tradeActions.Buy)
        //        {
        //            adviceInfo.Add(analysis.tradeActions.Buy, idx);
        //            lastBuyId = idx;
        //        }
        //        if (lastTrend == analysis.tradeActions.Buy && currentTrend == analysis.tradeActions.Sell)
        //        {
        //            adviceInfo.Add(analysis.tradeActions.Sell, idx);
        //        }
        //        lastTrend = currentTrend;
        //    }
        //    if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, sma5, sma10);
        //    return adviceInfo;
        //}

        //// sample
        //public static analysis.analysisResult StrategyTest(analysis.workData data)
        //{
        //    //get Bollinger Bands data
        //    double[] upperBand = null, middleBand = null, lowerBand = null;
        //    data.BBands(20, 2, 2, ref upperBand, ref middleBand, ref lowerBand); //Period = 20 , kUpTime = kDownTime=2

        //    analysis.analysisResult adviceInfo = new analysis.analysisResult();
        //    //for (int idx = 0; idx < upperBand.Length; idx++)
        //    //{
        //    //    ....strategy code goes here
        //    //}

        //    // Export data for testing
        //    //if (fExportData) analysis.ExportData(curStrategyCode + "-" + data.stockCodeRow.code + ".xls", data, upperBand);
        //    return adviceInfo;
        //}
    }
}
