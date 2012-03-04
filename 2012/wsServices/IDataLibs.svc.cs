using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Reflection;
using System.Web;
using System.Xml;
using commonTypes;
using commonClass;

namespace wsServices
{
    [ServiceContract]
    interface IStockService
    {
        #region system
        [OperationContract]
        void Reset();
        [OperationContract]
        void ClearCache();
        [OperationContract]
        void DeleteCache(string cacheName);

        [OperationContract]
        DateTime GetServerDateTime();

        [OperationContract]
        bool IsWorking();
        #endregion

        #region update
        [OperationContract]
        bool UpdateMessage(ref databases.baseDS.messagesDataTable messageTbl);

        [OperationContract]
        bool UpdatePriceData(ref databases.baseDS.priceDataDataTable priceDataTbl);

        [OperationContract]
        bool UpdateSysCodeCat(ref databases.baseDS.sysCodeCatDataTable sysCodeCatTbl);
        [OperationContract]
        bool UpdateSysCode(ref databases.baseDS.sysCodeDataTable sysCodeTbl);

        [OperationContract]
        bool UpdateStock(ref databases.baseDS.stockCodeDataTable stockCodeTbl);
        [OperationContract]
        bool UpdateInvestor(ref databases.baseDS.investorDataTable investorTbl);
        [OperationContract]
        bool UpdatePortfolio(ref databases.baseDS.portfolioDataTable portfolioTbl);
        [OperationContract]
        bool UpdatePortfolioDetail(ref databases.baseDS.portfolioDetailDataTable portfolioDetailTbl);
        [OperationContract]
        bool UpdateStockExchange(ref databases.baseDS.stockExchangeDataTable stockExchangeTbl);
        [OperationContract]
        bool UpdateTransactions(ref databases.baseDS.transactionsDataTable transactionsTbl);
        [OperationContract]
        bool UpdateInvestorStock(ref databases.baseDS.investorStockDataTable investorStockTbl);
        [OperationContract]
        bool UpdateTradeAlert(ref databases.baseDS.tradeAlertDataTable tradeAlertTbl);

        [OperationContract]
        bool UpdateSysAutoKeyPending(ref databases.baseDS.sysAutoKeyPendingDataTable sysAutoKeyPendingTbl);

        #endregion

        #region Delete
        [OperationContract]
        void DeleteStock(string stockCode);
        [OperationContract]
        void DeleteStockExchange(string code);
        [OperationContract]
        void DeleteInvestor(string investorCode);
        [OperationContract]
        void DeletePortfolio(string portfolioCode);
        [OperationContract]
        void DeleteSysCodeCat(string catCode);
        [OperationContract]
        void DeleteSysCode(string catCode, string code);

        [OperationContract]
        void DeleteTradeAlert(int alertId);
        #endregion

        #region Get/Load
        [OperationContract]
        databases.tmpDS.stockCodeDataTable GetStockByStatus(AppTypes.CommonStatus status);

        [OperationContract]
        databases.baseDS.priceDataDataTable GetAbnormalData(string code,DateTime frDate, DateTime toDate,string timeSacleCode);

        [OperationContract]
        databases.tmpDS.investorDataTable GetInvestorShortList();

        [OperationContract]
        databases.baseDS.sysLogDataTable GetSyslog_ByDate(DateTime frDate, DateTime toDate);
        [OperationContract]
        databases.baseDS.sysLogDataTable GetSyslog_BySQL(string sql);
        
        [OperationContract]
        databases.baseDS.stockCodeDataTable GetStockFull();

        [OperationContract]
        string[] GetStockList_ByWatchList(string[] watchList);
        [OperationContract]
        string[] GetStockList_ByBizSector(string[] sectors);

        [OperationContract]
        databases.baseDS.stockExchangeDataTable GetStockExchange();
        [OperationContract]
        databases.baseDS.employeeRangeDataTable GetEmployeeRange();
        [OperationContract]
        databases.baseDS.bizIndustryDataTable GetBizIndustry();
        [OperationContract]
        databases.baseDS.bizSuperSectorDataTable GetBizSuperSector();
        [OperationContract]
        databases.baseDS.bizSectorDataTable GetBizSector();
        
        [OperationContract]
        databases.baseDS.bizSubSectorDataTable GetBizSubSector();
        [OperationContract]
        databases.baseDS.bizSubSectorDataTable GetBizSubSectorByIndustry(string industryCode);
        [OperationContract]
        databases.baseDS.bizSubSectorDataTable GetBizSubSectorBySuperSector(string superSectorCode);
        [OperationContract]
        databases.baseDS.bizSubSectorDataTable GetBizSubSectorBySector(string sectorCode);

        [OperationContract]
        databases.baseDS.feedbackCatDataTable GetFeedbackCat(string cultureCode);

        [OperationContract]
        databases.baseDS.countryDataTable GetCountry();
        [OperationContract]
        databases.baseDS.currencyDataTable GetCurrency();
        [OperationContract]
        databases.baseDS.investorCatDataTable GetInvestorCat();
        [OperationContract]
        databases.baseDS.sysCodeDataTable GetSysCode(string catCode);
        [OperationContract]
        databases.baseDS.sysCodeCatDataTable GetSysCodeCat();

        [OperationContract]
        databases.baseDS.investorDataTable GetInvestor_ByAccount(string account);
        [OperationContract]
        databases.baseDS.investorDataTable GetInvestor_ByCode(string code);
        [OperationContract]
        databases.baseDS.investorDataTable GetInvestor_ByEmail(string email);
        [OperationContract]
        databases.baseDS.investorDataTable GetInvestor_BySQL(string sql);
        
        
        [OperationContract]
        databases.tmpDS.stockCodeDataTable GetStock_InPortfolio(string[] portfolios);
        [OperationContract]
        databases.tmpDS.stockCodeDataTable GetStock_ByBizSector(string[] bizSector);
        [OperationContract]
        databases.baseDS.bizSubSectorDataTable GetBizSubSector_ByIndustry(string code);
        [OperationContract]
        databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySuperSector(string code);
        [OperationContract]
        databases.baseDS.bizSubSectorDataTable GetBizSubSector_BySector(string code);

        [OperationContract]
        databases.baseDS.portfolioDataTable GetPortfolio_ByInvestorAndType(string investorCode, AppTypes.PortfolioTypes type);
        [OperationContract]
        databases.baseDS.portfolioDataTable GetPortfolio_ByType(AppTypes.PortfolioTypes type);
        [OperationContract]
        databases.baseDS.portfolioDataTable GetPortfolio_ByCode(string portfolioCode);
        [OperationContract]
        databases.baseDS.portfolioDataTable GetPortfolio_ByInvestor(string investorCode);

        [OperationContract]
        databases.baseDS.tradeAlertDataTable GetTradeAlert_BySQL(string alertSql);
        [OperationContract]
        databases.baseDS.transactionsDataTable GetTransaction_BySQL(string transSql);

        [OperationContract]
        databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByType(AppTypes.PortfolioTypes[] types);
        [OperationContract]
        databases.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByCode(string portfolioCode);
        
        [OperationContract]
        databases.baseDS.investorStockDataTable GetOwnedStock(string portfolioCode);

        [OperationContract]
        databases.baseDS.lastPriceDataDataTable GetLastPrice(AppTypes.PriceDataType type);

        [OperationContract]
        databases.baseDS.priceDataDataTable GetPriceData(string stockCode, string timeScaleCode, DateTime frDate, DateTime toDate);
        
        [OperationContract]
        DateTime GetLastAlertTime(string investorCode);

        [OperationContract]
        databases.baseDS.priceDataDataTable GetData_ByTimeScale_Code_FrDate(string timeScaleCode, string stockCode, DateTime fromDate);
        [OperationContract]
        databases.baseDS.priceDataDataTable GetData_ByTimeScale_Code_DateRange(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate);
        [OperationContract]
        databases.tmpDS.marketDataDataTable GetMarketData_BySQL(string sqlCmd1);
        [OperationContract]
        int GetData_TotalRow(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate);
        [OperationContract]
        bool GetTransactionInfo(ref TransactionInfo transInfo);

        [OperationContract]
        databases.baseDS.messagesDataTable GetMesssage_ByDate(DateTime frDate, DateTime toDate);
        [OperationContract]
        databases.baseDS.messagesDataTable GetMesssage_BySql(string sqlCmd2);


        //[OperationContract]
        //object[] GetPriceByCode(string stockCode);

        #endregion

        #region application
        
        [OperationContract]
        string LoadAnalysisData(string code, commonClass.DataParams dataParam, bool forceReadNew);
        [OperationContract]
        databases.baseDS.priceDataDataTable GetAnalysis_Data_ByKey(string dataKey, out int firstData);

        [OperationContract]
        databases.baseDS.priceDataDataTable GetAnalysis_Data(string stockCode, DataParams dataParam, out int firstData);


        [OperationContract]
        List<decimal[]> Estimate_Matrix_Profit(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                               string[] stockCodeList, string[] strategyList,
                                               EstimateOptions option);
        
        [OperationContract]
        List<double[]> Estimate_Matrix_LastBizWeight(DataParams dataParams,string[] stockCodeList, string[] strategyList);
        [OperationContract]
        TradePointInfo[] Analysis(string dataKey, string strategyCode);

        [OperationContract]
        databases.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type, string stockCode, string portfolioCode, int qty, decimal feePerc,out string errorText);

        [OperationContract]
        TradePointInfo[] GetTradePointWithEstimationDetail(DataParams dataParam,string stockCode, string strategyCode, EstimateOptions options,
                                                           out databases.tmpDS.tradeEstimateDataTable toTbl);

        [OperationContract]
        databases.tmpDS.priceDiagnoseDataTable DiagnosePrice_CloseAndNextOpen(DateTime frDate, DateTime toDate, string timeScaleCode,
                                                           string exchangeCode,string code, double variantPerc,double variance,byte precision);

        //[OperationContract]
        //void AdjustPriceData(string code, DateTime toDate, double weight);

        [OperationContract]
        void ReAggregatePriceData(string code);

        [OperationContract]
        string GetXmlDoc2StringSTRATEGY();
        [OperationContract]
        string GetXmlDoc2StringINDICATOR();

        [OperationContract]
        void Load_Global_Settings(ref GlobalSettings settings);
        [OperationContract]
        void Save_Global_Settings(GlobalSettings settings);

        #endregion

        [OperationContract]
        void WriteLog(byte logType, string investorCode, string desc, string source, string msg);
        [OperationContract]
        void WriteExcptionLog(string investorCode, common.SysLog.LogData logData);
        
        [OperationContract]
        DataTable Test(string sql);
    }
}
