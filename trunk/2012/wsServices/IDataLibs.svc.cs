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
using application;
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
        #endregion

        #region update
        [OperationContract]
        void UpdateSysCodeCat(ref data.baseDS.sysCodeCatDataTable sysCodeCatTbl);
        [OperationContract]
        void UpdateSysCode(ref data.baseDS.sysCodeDataTable sysCodeTbl);

        [OperationContract]
        void UpdateStock(ref data.baseDS.stockCodeDataTable stockCodeTbl);
        [OperationContract]
        void UpdateInvestor(ref data.baseDS.investorDataTable investorTbl);
        [OperationContract]
        void UpdatePortfolio(ref data.baseDS.portfolioDataTable portfolioTbl);
        [OperationContract]
        void UpdatePortfolioDetail(ref data.baseDS.portfolioDetailDataTable portfolioDetailTbl);
        [OperationContract]
        void UpdateStockExchange(ref data.baseDS.stockExchangeDataTable stockExchangeTbl);
        [OperationContract]
        void UpdateTransactions(ref data.baseDS.transactionsDataTable transactionsTbl);
        [OperationContract]
        void UpdateInvestorStock(ref data.baseDS.investorStockDataTable investorStockTbl);
        [OperationContract]
        void UpdateTradeAlert(ref data.baseDS.tradeAlertDataTable tradeAlertTbl);
        [OperationContract]
        void UpdateSysAutoKeyPending(ref data.baseDS.sysAutoKeyPendingDataTable sysAutoKeyPendingTbl);

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
        data.tmpDS.stockCodeDataTable GetStockByStatus(AppTypes.CommonStatus status);
        
        [OperationContract]
        data.baseDS.stockCodeDataTable GetStockFull();

        [OperationContract]
        string[] GetStockList_ByWatchList(string[] watchList);
        [OperationContract]
        string[] GetStockList_ByBizSector(string[] sectors);

        [OperationContract]
        data.baseDS.stockExchangeDataTable GetStockExchange();
        [OperationContract]
        data.baseDS.employeeRangeDataTable GetEmployeeRange();
        [OperationContract]
        data.baseDS.bizIndustryDataTable GetBizIndustry();
        [OperationContract]
        data.baseDS.bizSuperSectorDataTable GetBizSuperSector();
        [OperationContract]
        data.baseDS.bizSectorDataTable GetBizSector();
        
        [OperationContract]
        data.baseDS.bizSubSectorDataTable GetBizSubSector();
        [OperationContract]
        data.baseDS.bizSubSectorDataTable GetBizSubSectorByIndustry(string industryCode);
        [OperationContract]
        data.baseDS.bizSubSectorDataTable GetBizSubSectorBySuperSector(string superSectorCode);
        [OperationContract]
        data.baseDS.bizSubSectorDataTable GetBizSubSectorBySector(string sectorCode);

        [OperationContract]
        data.baseDS.countryDataTable GetCountry();
        [OperationContract]
        data.baseDS.currencyDataTable GetCurrency();
        [OperationContract]
        data.baseDS.investorCatDataTable GetInvestorCat();
        [OperationContract]
        data.baseDS.sysCodeDataTable GetSysCode(string catCode);
        [OperationContract]
        data.baseDS.sysCodeCatDataTable GetSysCodeCat();

        [OperationContract]
        data.baseDS.investorDataTable GetInvestor_ByAccount(string account);
        [OperationContract]
        data.baseDS.investorDataTable GetInvestor_ByCode(string code);
        [OperationContract]
        data.baseDS.investorDataTable GetInvestor_BySQL(string sql);
        
        
        [OperationContract]
        data.tmpDS.stockCodeDataTable GetStock_InPortfolio(string[] portfolios);
        [OperationContract]
        data.tmpDS.stockCodeDataTable GetStock_ByBizSector(string[] bizSector);
        [OperationContract]
        data.baseDS.bizSubSectorDataTable GetBizSubSector_ByIndustry(string code);
        [OperationContract]
        data.baseDS.bizSubSectorDataTable GetBizSubSector_BySuperSector(string code);
        [OperationContract]
        data.baseDS.bizSubSectorDataTable GetBizSubSector_BySector(string code);

        [OperationContract]
        data.baseDS.portfolioDataTable GetPortfolio_ByInvestorAndType(string investorCode, AppTypes.PortfolioTypes type);
        [OperationContract]
        data.baseDS.portfolioDataTable GetPortfolio_ByType(AppTypes.PortfolioTypes type);
        [OperationContract]
        data.baseDS.portfolioDataTable GetPortfolio_ByCode(string portfolioCode);
        [OperationContract]
        data.baseDS.portfolioDataTable GetPortfolio_ByInvestor(string investorCode);

        [OperationContract]
        data.baseDS.tradeAlertDataTable GetTradeAlert_BySQL(string alertSql);
        [OperationContract]
        data.baseDS.transactionsDataTable GetTransaction_BySQL(string transSql);

        [OperationContract]
        data.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByType(AppTypes.PortfolioTypes[] types);
        [OperationContract]
        data.baseDS.portfolioDetailDataTable GetPortfolioDetail_ByCode(string portfolioCode);
        
        [OperationContract]
        data.baseDS.investorStockDataTable GetOwnedStock(string portfolioCode);

        [OperationContract]
        data.baseDS.lastPriceDataDataTable GetLastPrice(AppTypes.PriceDataType type);
        
        [OperationContract]
        DateTime GetLastAlertTime(string investorCode);

        [OperationContract]
        data.baseDS.priceDataDataTable GetData_ByTimeScale_Code_FrDate(string timeScaleCode, string stockCode, DateTime fromDate);
        [OperationContract]
        data.baseDS.priceDataDataTable GetData_ByTimeScale_Code_DateRange(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate);
        [OperationContract]
        data.tmpDS.marketDataDataTable GetMarketData_BySQL(string sqlCmd);
        [OperationContract]
        int GetData_TotalRow(string timeScaleCode, string stockCode, DateTime frDate, DateTime toDate);
        [OperationContract]
        bool GetTransactionInfo(ref TransactionInfo transInfo);

        [OperationContract]
        object[] GetPriceByCode(string stockCode);

        #endregion

        #region application
        
        [OperationContract]
        string LoadAnalysisData(AppTypes.TimeRanges timeRange, string timeScaleCode, string code, bool forceReadNew);
        [OperationContract]
        data.baseDS.priceDataDataTable GetAnalysis_Data_ByKey(string dataKey, out int firstData);

        [OperationContract]
        data.baseDS.priceDataDataTable GetAnalysis_Data(AppTypes.TimeRanges timeRanges, string timeScaleCode, string stockCode, out int firstData);


        [OperationContract]
        List<decimal[]> Estimate_Matrix_Profit(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                               string[] stockCodeList, string[] strategyList,
                                               EstimateOptions option);
        
        [OperationContract]
        List<double[]> Estimate_Matrix_LastBizWeight(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                     string[] stockCodeList, string[] strategyList);

        [OperationContract]
        TradePointInfo[] Analysis(string dataKey, string strategyCode);

        [OperationContract]
        data.baseDS.transactionsDataTable MakeTransaction(AppTypes.TradeActions type, string stockCode, string portfolioCode, int qty, decimal feePerc,out string errorText);

        [OperationContract]
        TradePointInfo[] GetTradePointWithEstimationDetail(AppTypes.TimeRanges timeRange, string timeScaleCode,
                                                           string stockCode, string strategyCode, EstimateOptions options,
                                                           out data.tmpDS.tradeEstimateDataTable toTbl);

        [OperationContract]
        string GetXml(string filePath);

        [OperationContract]
        void Load_Global_Settings();
        [OperationContract]
        void Save_Global_Settings();

        #endregion

        [OperationContract]
        void WriteSyslog(AppTypes.SyslogTypes logType, string investorCode, string desc, string source, string msg);
        
        [OperationContract]
        DataTable Test(string sql);
    }
}
