using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportProcessing
{
    public class ReportResult
    {
        public static string processString(string expression)
        {
            StockReport stockReport = StockReport.getInstance();
            string[] arr = expression.Split(':');           
            string first = arr[0];
            string method = first.Split('_')[1];            
            object[] arrParams = new object[arr.Length - 1];
            for (int i = 1; i <arr.Length; i++)
            {
                arrParams[i - 1] = arr[i]; 
            }         
            string result = "###";
            try
            {
                result = ReflectionUtils.GetMethod(stockReport, method, arrParams) as string;
            }
            catch (Exception)
            {
                return "Undefined";
            }
            return result;
        }        
    }
}
