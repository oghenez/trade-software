using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;
using TicTacTec.TA.Library;

namespace application
{
    public class stockLibs
    {
        public static double[] MakeDataList(data.baseDS.priceDataDataTable dataTbl, int startIdx, Data.DataType dataField)
        {
            Data.GetData(dataTbl, startIdx, dataField);
            return null;
        }
    }
    public class analysis
    {
        #region analysis core
        public class estimateOptions
        {
            public decimal totalCapAmt = Settings.sysStockTotalCapAmt;
            public decimal maxBuyAmtPerc = Settings.sysStockMaxBuyAmtPerc;
            public decimal qtyReducePerc = Settings.sysStockReduceQtyPerc;
            public decimal qtyAccumulatePerc = Settings.sysStockAccumulateQtyPerc;
            public decimal transFeecPerc = Settings.sysStockTransFeePercent;
            public decimal priceWeight = Settings.sysStockPriceWeight;
            public decimal maxBuyQtyPerc = Settings.sysStockMaxBuyQtyPerc;
            public short buy2SellInterval = Settings.sysStockSell2BuyInterval;
        }

        public class workData
        {
            public workData(){}
            public workData(string timeScale,DateTime frDate, DateTime toDate, data.baseDS.stockCodeRow stockCodeRow) 
            {
                Init(timeScale, frDate, toDate, stockCodeRow);
            }

            public data.baseDS.stockCodeRow stockCodeRow = null;
            public DateTime startDate = common.Consts.constNullDate;
            public DateTime endDate = common.Consts.constNullDate;
            // noDayToReadAhead  : price data will be read in 2 ranges  [startDate-noDayToReadAhead,frDate] and  [startDate,endDate]
            //private int noUnitToReadAhead = 100;

            // Because data will beread ahead some lengh,
            // the [priceStartIdx] is used to mark where the data in range [frDate,toDate] start
            public int priceStartIdx = 0;

            private data.baseDS.priceDataDataTable priceDataTbl = new data.baseDS.priceDataDataTable();
            // _buffClosePrice : closePrice + read adead items
            private double[] _buffClosePrice = null, _closePrice = null;
            private double[] _buffHiPrice = null, _hiPrice = null;
            private double[] _buffLoPrice = null, _loPrice = null;
            private double[] _openPrice = null;
            private double[] _totalVolume = null;
            private DateTime[] _priceDate = null;

            private double[] buffClosePrice
            {
                get
                {
                    if (_buffClosePrice == null)
                        _buffClosePrice = stockLibs.MakeDataList(this.priceDataTbl, 0, Data.DataType.Close);
                    return _buffClosePrice;
                }
            }
            private double[] buffHiPrice
            {
                get
                {
                    if (_buffHiPrice == null)
                        _buffHiPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, Data.DataType.High);
                    return _buffHiPrice;
                }
            }
            private double[] buffLoPrice
            {
                get
                {
                    if (_buffLoPrice == null)
                        _buffLoPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, Data.DataType.Low);
                    return _buffLoPrice;
                }
            }

            public double[] closePrice
            {
                get
                {
                    if (_closePrice == null)
                        //_closePrice = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, Data.DataType.Close);
                        _closePrice = stockLibs.MakeDataList(this.priceDataTbl,0, Data.DataType.Close);
                    return _closePrice;
                }
            }
            public double[] hiPrice
            {
                get
                {
                    if (_hiPrice == null)
                        //_hiPrice = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, Data.DataType.High);
                        _hiPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, Data.DataType.High);
                    return _hiPrice;
                }
            }
            public double[] loPrice
            {
                get
                {
                    if (_loPrice == null)
                        //_loPrice = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, Data.DataType.Low);
                        _loPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, Data.DataType.Low);
                    return _loPrice;
                }
            }
            public double[] openPrice
            {
                get
                {
                    if (_openPrice == null)
                        //_openPrice = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, Data.DataType.Open);
                        _openPrice = stockLibs.MakeDataList(this.priceDataTbl, 0, Data.DataType.Open);
                    return _openPrice;
                }
            }
            public double[] totalVolume
            {
                get
                {
                    if (_totalVolume == null)
                        //_totalVolume = stockLibs.MakeDataList(this.priceDataTbl, this.priceStartIdx, Data.DataType.Volume);
                        _totalVolume = stockLibs.MakeDataList(this.priceDataTbl, 0, Data.DataType.Volume);
                    return _totalVolume;
                }
            }
            public DateTime[] priceDate
            {
                get
                {
                    if (_priceDate == null)
                    {
                        //for (int i = this.priceStartIdx, j = 0; i < this.priceDataTbl.Count; i++, j++)
                        for (int i = 0, j = 0; i < this.priceDataTbl.Count; i++, j++)
                        {
                            Array.Resize(ref _priceDate, j+1);
                            _priceDate[j] = this.priceDataTbl[i].onDate;
                        }
                    }
                    return _priceDate;
                }
            }
            public double[] StockData(string timeScale,string stockCode, Data.DataType dataField)
            {
                data.baseDS.priceDataDataTable dataTbl = new data.baseDS.priceDataDataTable();
                application.dataLibs.LoadData(dataTbl,timeScale,startDate, endDate, stockCode);

                double[] outList = new double[this.priceDataTbl.Count];
                data.baseDS.priceDataRow row;

                string dataFldName = "";
                switch (dataField)
                {
                    case Data.DataType.High:
                         dataFldName = this.priceDataTbl.highPriceColumn.ColumnName; break;
                    case Data.DataType.Low:
                         dataFldName = this.priceDataTbl.lowPriceColumn.ColumnName; break;
                    case Data.DataType.Open:
                         dataFldName = this.priceDataTbl.openPriceColumn.ColumnName; break;
                    case Data.DataType.Close:
                         dataFldName = this.priceDataTbl.closePriceColumn.ColumnName; break;
                    case Data.DataType.Volume:
                         dataFldName = this.priceDataTbl.volumeColumn.ColumnName; break;
                    default: return outList;
                }
                for (int idx = 0; idx < this.priceDataTbl.Count; idx++)
                {
                    row = dataTbl.FindBystockCodeonDate(stockCode, this.priceDataTbl[idx].onDate);
                    if (row != null) 
                         outList[idx] = double.Parse(row[dataFldName].ToString());
                    else outList[idx] = 0;
                }
                return outList;
            }

            public void Init(string timeScale, DateTime frDate, DateTime toDate, data.baseDS.stockCodeRow stockRow)
            {
                this.startDate = frDate; this.endDate = toDate;
                this.stockCodeRow = stockRow;
                this.priceDataTbl.Clear();
                this.priceStartIdx = 0;
                //??stockLibs.LoadStockPrice(stockRow.code, this.startDate, this.endDate,timeScale, this.noUnitToReadAhead, 
                //                         this.priceDataTbl, out this.priceStartIdx);
                _buffClosePrice = null; _closePrice = null;
                _buffHiPrice = null; _hiPrice = null;
                _buffLoPrice = null; _loPrice = null;
                _openPrice = null;
                _priceDate = null;
                _totalVolume = null;
            }
        }
        public enum tradeActions : byte { None = 0, Buy = 1, Sell = 2, Accumulate = 3, ClearAll = 4, Select = 5};

        //Convert all TradeActions to table of (code,description)
        public static DataTable CreateTradeActionsTable()
        {
            DataTable tbl = new DataTable();
            // Define columns
            DataColumn col1 = new DataColumn("code", typeof(byte)); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn("description"); tbl.Columns.Add(col2);
            foreach (analysis.tradeActions item in Enum.GetValues(typeof(analysis.tradeActions)))
            {
                DataRow row = tbl.Rows.Add((byte)item);
                row[1] = item.ToString();
            }
            return tbl;
        }

        public enum marketTrend : byte { Unspecified=0, Sidebar = 1, Upward = 2, Downward = 3 };
        public class tradePointInfo
        {
            public marketTrend marketTrend = marketTrend.Unspecified;
            public double price = 0;
            public int volume = 0;
            public double weight = 0;
            public void Set(tradePointInfo info)
            {
                this.marketTrend = info.marketTrend;
                this.price = info.price;
                this.volume = info.volume;
                this.weight = info.weight;
            }
        }
        public class tradePoint
        {
            // Data position where the trade point occured.
            // The index is used to get data (closePrice,openPrice...) of a trade point.
            public int dataIdx = 0;
            // Position where the point appears in the chart.  
            public int pointIdx = 0;
            public DateTime onDateTime = common.Consts.constNullDate;
            public tradePointInfo tradeInfo = new tradePointInfo();
            public tradeActions tradeAction = tradeActions.None;

            public tradePoint(tradeActions action, int idx, tradePointInfo info)
            {
                this.tradeAction = action;
                if(info!=null)  this.tradeInfo.Set(info);
                this.dataIdx = idx;
            }
            public tradePoint(tradeActions action, int idx)
            {
                this.tradeAction = action;
                this.dataIdx = idx;
            }
        }
        public class analysisResult : ArrayList
        {
            public analysisResult() { }
            public void Add(tradeActions action, int idx,tradePointInfo info)
            {
                this.Add(new tradePoint(action, idx,info));
            }
            public void Add(tradeActions action, int idx)
            {
                this.Add(new tradePoint(action, idx, null));
            }
            public tradePoint GetItem(int idx)
            {
                return (tradePoint)this[idx];
            }
        }
        #endregion

        #region usefull functions

        public static void EstimateAdvice(workData analysisData, analysisResult advices,estimateOptions options, 
                                          data.tmpDS.tradeEstimateDataTable toTbl)
        {
            decimal initCapAmt = options.totalCapAmt * options.maxBuyAmtPerc / 100;
            decimal priceWeight= options.priceWeight;
            decimal feePerc = options.transFeecPerc/100;
            short buy2SellInterval = options.buy2SellInterval;

            data.tmpDS.tradeEstimateRow row;
            int adviceDataIdx, lastBuyId = -1;
            decimal stockQty = 0,qty;
            decimal maxBuyQty = (decimal)(analysisData.stockCodeRow.noOutstandingStock * options.maxBuyQtyPerc / 100); 
            decimal stockAmt = 0, stockPrice = 0, amt, feeAmt, totalFeeAmt = 0;
            decimal cashAmt = initCapAmt;
            toTbl.Clear();

            DateTime tmpDate, transDate = common.Consts.constNullDate; ;
            data.baseDS.priceDataRow priceDataRow; 
            bool keepInApplicableSell = true;
            for (int idx = 0; idx < advices.Count; idx++)
            {
                adviceDataIdx = advices.GetItem(idx).dataIdx;
                qty = 0; amt = 0;
                row = toTbl.NewtradeEstimateRow();
                row.ignored = false;
                analysis.tradeActions action = advices.GetItem(idx).tradeAction;

                stockPrice = (decimal)analysisData.closePrice[adviceDataIdx];
                transDate = analysisData.priceDate[adviceDataIdx];
                switch (action)
                {
                    case analysis.tradeActions.Buy:
                        //Assume that we can only buy if we have money 
                        qty = (stockPrice == 0 ? 0 : Math.Floor(cashAmt / ( (stockPrice * priceWeight) * (1 + feePerc))));
                        if (qty > maxBuyQty) qty = maxBuyQty;
                        if (qty != 0)
                        {
                            amt = qty * stockPrice * priceWeight;
                            stockAmt += amt;
                            stockQty += qty;
                            feeAmt = Math.Round(amt * feePerc, 0);
                            cashAmt -= amt + feeAmt;
                            totalFeeAmt += feeAmt;
                            lastBuyId = adviceDataIdx;
                        }
                        else row.ignored = true;
                        break;
                    case analysis.tradeActions.Sell:
                        //Can sell if own some stock
                        if (stockQty <= 0) 
                        {
                            row.ignored = true;
                            break;
                        }
                        // Not applicable to sell
                        if (lastBuyId < 0)
                        {
                            row.ignored = true;
                            break;
                        }
                        if (common.dateTimeLibs.DateDiffInDays(analysisData.priceDate[lastBuyId].Date, 
                                                               analysisData.priceDate[adviceDataIdx].Date) < buy2SellInterval)
                        {
                            // Keep inapplicable Sells ??
                            if (keepInApplicableSell)
                            {
                                string realTimeType = myTypes.MainDataTimeScale.Code;
                                DateTime minAllowSellDate = analysisData.priceDate[lastBuyId].Date.AddDays(buy2SellInterval);
                                for (int idx2 = idx + 1; idx2 < advices.Count; idx2++)
                                {
                                    //There is any advice from from [this date , this date +buy2SellInterval], ignore the inapplicable sell 
                                    if (analysisData.priceDate[advices.GetItem(idx2).dataIdx].Date <= minAllowSellDate)
                                    {
                                        row.ignored = true;
                                        break;
                                    }
                                    //No advice, keep this inapplicable sell. 
                                    if (analysisData.priceDate[advices.GetItem(idx2).dataIdx].Date > minAllowSellDate)
                                    {
                                        // minAllowSellDate may be a holiday so we need to find a sell date in range [minAllowSellDate, analysisData.priceDate[advices.GetItem(idx2).dataIdx].Date]
                                        // We assume that there are no data on hodidays and use the price,date as transaction price/date
                                        tmpDate = analysisData.priceDate[advices.GetItem(idx2).dataIdx].Date;
                                        priceDataRow = dataLibs.GetNextPrice(minAllowSellDate, realTimeType, analysisData.stockCodeRow.code);
                                        //priceDataRow == null : there must be some error.
                                        if (priceDataRow == null) row.ignored = true;
                                        else
                                        {
                                            stockPrice = priceDataRow.closePrice;
                                            transDate = priceDataRow.onDate;
                                        }
                                        break;
                                    }
                                }
                            }
                            else row.ignored = true;
                        }
                        //Ok, sell it
                        qty = stockQty;
                        amt = qty * stockPrice * priceWeight;
                        stockQty = 0; stockAmt = 0;
                        feeAmt = Math.Round(amt * feePerc, 0);
                        cashAmt += amt - feeAmt;
                        totalFeeAmt += feeAmt;
                        break;
                }
                row.tradeAction = action.ToString();
                row.onDate = transDate;
                row.price = stockPrice;
                row.qty = qty;
                row.amt = amt;
                row.feeAmt = totalFeeAmt;
                row.stockQty = stockQty;
                row.stockAmt = stockAmt;
                row.cashAmt = cashAmt;
                row.totalAmt = row.cashAmt + row.stockAmt;
                row.revenue = row.totalAmt - initCapAmt;
                toTbl.AddtradeEstimateRow(row);
            }
        }

        public static void ExportData(string toFileName, workData data, params object[] paras)
        {
            if (paras.Length == 0) return;
            // Define the new datatable
            DataTable tbl = new DataTable();
            DataColumn col0 = new DataColumn("onDate", typeof(DateTime)); tbl.Columns.Add(col0);
            DataColumn col1 = new DataColumn("open", typeof(Decimal)); tbl.Columns.Add(col1);
            DataColumn col2 = new DataColumn("close", typeof(Decimal)); tbl.Columns.Add(col2);
            DataColumn col3 = new DataColumn("hi", typeof(Decimal)); tbl.Columns.Add(col3);
            DataColumn col4 = new DataColumn("low", typeof(Decimal)); tbl.Columns.Add(col4);
            DataColumn col5 = new DataColumn("volume", typeof(Decimal)); tbl.Columns.Add(col5);
            for (int colId = 0; colId < paras.Length; colId++)
            {
                DataColumn col = new DataColumn("val" + colId.ToString().Trim(), typeof(Decimal));
                tbl.Columns.Add(col);
            }
            double[] val = new double[paras.Length];
            int rowCount = ((double[])paras[0]).Length;
            DataRow row;
            for (int rowId = 0; rowId < rowCount; rowId++)
            {
                row = tbl.Rows.Add();
                row[0] = data.priceDate[rowId];
                row[1] = data.openPrice[rowId];
                row[2] = data.closePrice[rowId];
                row[3] = data.hiPrice[rowId];
                row[4] = data.loPrice[rowId];
                row[5] = data.totalVolume[rowId];
                for (int colId = 0; colId < paras.Length; colId++)
                {
                    row[colId + 6] = ((double[])paras[colId])[rowId];
                }
            }
            common.Export.ExportToExcel(tbl, toFileName);
        }
        #endregion

        #region strategy estimation
        //Estimate for one stock ; ??Will be done

        //Structure represent the estimation criteria for the "strategy accuracry" on specific stock.
        public class oneStockStrategyStats
        {
            public string strategyCode = "";
            public decimal startAmt = 0, closingAmt = 0;
            public int totalTrans = 0, noWinTrans = 0, noLossTrans = 0;
            public decimal winPerc = 0, lossPerc = 0;
            public decimal maxAmtInWin = 0, maxAmtInLoss = 0, avgAmtInWin = 0, avgAmtInLoss = 0;
            public decimal totalWinAmt = 0, totalLossAmt = 0;
            public decimal avgNoDayHoldStockInWin = 0;   //average of the number of days to hlod stock in win transaction;
            public decimal maxNoTransWinInRow = 0, maxNoTransLossInRow = 0;
        }

        //Estimate for all stock
        private class strategyStats
        {
            public int winStockCount = 0, lossStockCount = 0;
            public double winStockPerc = 0, lossStockPerc = 0;
            public double maxWinAmt = 0, maxLossAmt = 0;
            public double avgWinAmt = 0, avgLossAmt = 0;
            public double totalWinAmt = 0, totalLossAmt = 0;
        }

        //Structure represent the estimation criteria for the "strategy accuracry" on all stocks.
        private static strategyStats EstimateStrategy(decimal[] list)
        {
            strategyStats estData = new strategyStats();
            for (int rowId = 0; rowId < list.Length; rowId++)
            {
                if (list[rowId] > 0)
                {
                    estData.winStockCount++;
                    if ((double)list[rowId] > estData.maxWinAmt) estData.maxWinAmt = (double)list[rowId];
                    estData.totalWinAmt += (double)list[rowId];
                }
                if (list[rowId] < 0)
                {
                    estData.lossStockCount++;
                    if ((double)list[rowId] < estData.maxLossAmt) estData.maxLossAmt = (double)list[rowId];
                    estData.totalLossAmt += (double)list[rowId];
                }
            }
            if (list.Length > 0)
            {
                estData.winStockPerc = 100 * estData.winStockCount / (double)list.Length;
                estData.lossStockPerc = 100 * estData.lossStockCount / (double)list.Length;
            }
            if (estData.winStockCount > 0)
            {
                estData.avgWinAmt = estData.totalWinAmt / (double)estData.winStockCount;
            }
            if (estData.lossStockCount > 0)
            {
                estData.avgLossAmt = estData.totalLossAmt / (double)estData.lossStockCount;
            }
            return estData;
        }
        public static DataTable GetStrategyStats(DataTable tbl)
        {
            ArrayList estDataList = new ArrayList();
            decimal[] dataList = new decimal[tbl.Rows.Count];
            for (int colId = 1; colId < tbl.Columns.Count; colId++)
            {
                //Convert to list
                for (int rowId = 0; rowId < tbl.Rows.Count; rowId++) dataList[rowId] = (decimal)tbl.Rows[rowId][colId];
                estDataList.Add(EstimateStrategy(dataList));
            }
            //Create table to store data
            DataTable retTbl = tbl.Clone();
            strategyStats estData;
            retTbl.Rows.Add("01.Tỉ lệ CP lời");         //winStockPerc; 
            retTbl.Rows.Add("02.Tỉ lệ CP lỗ");          //lossStockPerc
            retTbl.Rows.Add("03.ST lời lớn nhất");      //maxWinAmt 
            retTbl.Rows.Add("04.ST lỗ lớn nhất");       //maxLossAmt
            retTbl.Rows.Add("05.ST lời trung bình");    //avgWinAmt 
            retTbl.Rows.Add("06.ST lỗ trung bình");     //avgLossAmt
            //retTbl.Rows.Add("07.Số lượng CP lời");      //winStockCount 
            //retTbl.Rows.Add("08.Số lượng CP lỗ");       //lossStockCount
            //retTbl.Rows.Add("09.Tổng lời");             //totalWinAmt 
            //retTbl.Rows.Add("10.Tồng lỗ");              //totalLossAmt
            for (int colId = 0; colId < estDataList.Count; colId++)
            {
                estData = (strategyStats)estDataList[colId];

                retTbl.Rows[0][colId + 1] = estData.winStockPerc;
                retTbl.Rows[1][colId + 1] = estData.lossStockPerc;

                retTbl.Rows[2][colId + 1] = estData.maxWinAmt;
                retTbl.Rows[3][colId + 1] = estData.maxLossAmt;

                retTbl.Rows[4][colId + 1] = estData.avgWinAmt;
                retTbl.Rows[5][colId + 1] = estData.avgLossAmt;

                //retTbl.Rows[6][colId + 1] = estData.winStockCount;
                //retTbl.Rows[7][colId + 1] = estData.lossStockCount;
                //retTbl.Rows[8][colId + 1] = estData.totalWinAmt;
                //retTbl.Rows[9][colId + 1] = estData.totalLossAmt;
            }
            return retTbl;
        }
        #endregion
    }
    public class screening
    {
        public static bool GetStockList(data.baseDS.stockCodeDataTable stockCodeTbl, myTypes.ScreeningCriteria[] criteriaList)
        {
            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();
            DateTime curDate = application.sysLibs.GetServerDateTime();
            string sqlCmdStock = "", sqlCmdPrice = "";
            for(int idx=0; idx<criteriaList.Length;idx++)
            {
                switch (criteriaList[idx].code)
                {
                    //From stock
                    case myTypes.ScreeningCriteriaTypes.MarketCap:

                        sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                                        "(" + stockCodeTbl.workingCapColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";
                        if (criteriaList[idx].max > criteriaList[idx].min)
                        {
                            sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                    "(" + stockCodeTbl.workingCapColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                        }
                        break;

                    case myTypes.ScreeningCriteriaTypes.TotalVolume:
                         sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                 "(" + stockCodeTbl.noOutstandingStockColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";
                         if (criteriaList[idx].max > criteriaList[idx].min)
                         {
                             sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                     "(" + stockCodeTbl.noOutstandingStockColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                         }
                         break;

                    case myTypes.ScreeningCriteriaTypes.ForeignOwnVolume:
                         sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                 "(" + stockCodeTbl.noForeignOwnedStockColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";
                         if (criteriaList[idx].max > criteriaList[idx].min)
                         {
                             sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                     "(" + stockCodeTbl.noForeignOwnedStockColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                         }
                         break;

                    case myTypes.ScreeningCriteriaTypes.TargetPrice:
                         sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                 "(" + stockCodeTbl.targetPriceColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";
                         if (criteriaList[idx].max > criteriaList[idx].min)
                         {
                             sqlCmdStock += (sqlCmdStock == "" ? "" : " AND ") +
                                     "(" + stockCodeTbl.targetPriceColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                         }
                         break;
                    //From price
                    case myTypes.ScreeningCriteriaTypes.LastMonthTransVolume:
                         sqlCmdPrice += (sqlCmdPrice == "" ? "" : " AND ") +
                                 "(" + priceTbl.volumeColumn.ColumnName + ">=" + criteriaList[idx].min.ToString() + ")";

                         if (criteriaList[idx].max > criteriaList[idx].min)
                         {
                             
                             sqlCmdPrice += (sqlCmdPrice == "" ? "" : " AND ") +
                                        "(" + priceTbl.volumeColumn.ColumnName + "<=" + criteriaList[idx].max.ToString() + ")";
                         }
                         sqlCmdPrice += (sqlCmdPrice == "" ? "" : " AND ") +
                                    "(" +  priceTbl.onDateColumn.ColumnName +
                                          " BETWEEN '" + common.system.ConvertToSQLDateString(curDate.AddMonths(-1)) + "' AND " +
                                          " '" + common.system.ConvertToSQLDateString(curDate) +
                                    "')";
                         break;
                }
            }
            string sqlCmd = "";
            if (sqlCmdStock != "" && sqlCmdPrice != "")
            {
                sqlCmd =  " SELECT *" +
                          " FROM " + stockCodeTbl.TableName +
                          " WHERE " + sqlCmdStock +
                          " AND " + stockCodeTbl.codeColumn.ColumnName + " IN " +
                          "(" +
                          " SELECT " + priceTbl.stockCodeColumn.ColumnName +
                          " FROM " + priceTbl.TableName +
                          " WHERE " + sqlCmdPrice +
                          ")";
            }
            if (sqlCmd == "" && sqlCmdStock != "")
            {
                sqlCmd =  " SELECT * " +
                          " FROM " + stockCodeTbl.TableName +
                          " WHERE " + sqlCmdStock;
            }
            if (sqlCmd == "" && sqlCmdPrice != "")
            {
                sqlCmd = " SELECT *" +
                          " FROM " + stockCodeTbl.TableName +
                          " WHERE " + stockCodeTbl.codeColumn.ColumnName + " IN " +
                          "(" +
                          " SELECT " + priceTbl.stockCodeColumn.ColumnName +
                          " FROM " + priceTbl.TableName +
                          " WHERE " + sqlCmdPrice +
                          ")";
            }
            if (sqlCmd == "") return false;

            dataLibs.LoadFromSQL(stockCodeTbl, sqlCmd);
            return true;
        }
    }

}
