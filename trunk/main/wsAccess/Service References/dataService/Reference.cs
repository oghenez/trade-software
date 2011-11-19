﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wsAccess.dataService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="dataService.IStockService")]
    public interface IStockService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetData", ReplyAction="http://tempuri.org/IStockService/GetDataResponse")]
        string GetData(application.AppTypes.TimeRanges timeRange, string timeScaleCode, string dataCode, bool forceReadNew);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/ClearCache", ReplyAction="http://tempuri.org/IStockService/ClearCacheResponse")]
        void ClearCache();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/DeleteCache", ReplyAction="http://tempuri.org/IStockService/DeleteCacheResponse")]
        void DeleteCache(string cacheName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/CreateEstimateOption", ReplyAction="http://tempuri.org/IStockService/CreateEstimateOptionResponse")]
        string CreateEstimateOption(application.wsData.EstimateOptions option);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/DisposeEstimateOption", ReplyAction="http://tempuri.org/IStockService/DisposeEstimateOptionResponse")]
        void DisposeEstimateOption(string key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/Estimate_Matrix_Profit", ReplyAction="http://tempuri.org/IStockService/Estimate_Matrix_ProfitResponse")]
        decimal[][] Estimate_Matrix_Profit(application.AppTypes.TimeRanges timeRange, string timeScaleCode, string[] stockCodeList, string[] strategyList, application.wsData.EstimateOptions option);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/Estimate_Matrix_LastBizWeight", ReplyAction="http://tempuri.org/IStockService/Estimate_Matrix_LastBizWeightResponse")]
        double[][] Estimate_Matrix_LastBizWeight(application.AppTypes.TimeRanges timeRange, string timeScaleCode, string[] stockCodeList, string[] strategyList);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/Analysis", ReplyAction="http://tempuri.org/IStockService/AnalysisResponse")]
        application.wsData.TradePointInfo[] Analysis(string dataKey, string strategyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetStock", ReplyAction="http://tempuri.org/IStockService/GetStockResponse")]
        data.baseDS.stockCodeDataTable GetStock();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/test2", ReplyAction="http://tempuri.org/IStockService/test2Response")]
        decimal[][] test2();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IStockServiceChannel : wsAccess.dataService.IStockService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class StockServiceClient : System.ServiceModel.ClientBase<wsAccess.dataService.IStockService>, wsAccess.dataService.IStockService {
        
        public StockServiceClient() {
        }
        
        public StockServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StockServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(application.AppTypes.TimeRanges timeRange, string timeScaleCode, string dataCode, bool forceReadNew) {
            return base.Channel.GetData(timeRange, timeScaleCode, dataCode, forceReadNew);
        }
        
        public void ClearCache() {
            base.Channel.ClearCache();
        }
        
        public void DeleteCache(string cacheName) {
            base.Channel.DeleteCache(cacheName);
        }
        
        public string CreateEstimateOption(application.wsData.EstimateOptions option) {
            return base.Channel.CreateEstimateOption(option);
        }
        
        public void DisposeEstimateOption(string key) {
            base.Channel.DisposeEstimateOption(key);
        }
        
        public decimal[][] Estimate_Matrix_Profit(application.AppTypes.TimeRanges timeRange, string timeScaleCode, string[] stockCodeList, string[] strategyList, application.wsData.EstimateOptions option) {
            return base.Channel.Estimate_Matrix_Profit(timeRange, timeScaleCode, stockCodeList, strategyList, option);
        }
        
        public double[][] Estimate_Matrix_LastBizWeight(application.AppTypes.TimeRanges timeRange, string timeScaleCode, string[] stockCodeList, string[] strategyList) {
            return base.Channel.Estimate_Matrix_LastBizWeight(timeRange, timeScaleCode, stockCodeList, strategyList);
        }
        
        public application.wsData.TradePointInfo[] Analysis(string dataKey, string strategyCode) {
            return base.Channel.Analysis(dataKey, strategyCode);
        }
        
        public data.baseDS.stockCodeDataTable GetStock() {
            return base.Channel.GetStock();
        }
        
        public decimal[][] test2() {
            return base.Channel.test2();
        }
    }
}
