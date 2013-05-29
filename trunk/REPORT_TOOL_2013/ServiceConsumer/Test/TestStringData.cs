using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceConsumer.Test
{
    class TestStringData:IReportDataQuery
    {
        public TestStringData()
        {
            MethodTableReference.initTable();
            Data.DataTest.initDataTest();
        }
        #region IReportDataQuery Members        
        public string stringData(string expression)
        {            
            string[] arr = expression.Split(':');
            if (arr.Length == 1)
            {
                return "ERROR#1";
            }    
            string methodName = arr[0];
            string stockCode = arr[1];
            string timeRangeType = "W0";
            if (arr.Length>=3)
            {
                timeRangeType = arr[2];
            }            
            switch (stockCode.ToUpper())
            {
                default:
                    string result = "###";
                    try
                    {
                        result = ReflectionUtils.GetPropValue(Data.DataTest.lstDataTest[stockCode.ToUpper()], MethodTableReference.getMethodName(methodName)).ToString();
                    }
                    catch (Exception)
                    {                                                
                    }                    
                    return result;
            }
            return "Undefined";
        }

        public ServiceConsumer.QuantumStockServiceProvider.AnalysisRequest tableData(string expression, int tableType)
        {
            throw new NotImplementedException();
        }

        public byte[] chartData(string expression, int chartType)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
