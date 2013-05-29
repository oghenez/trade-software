using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceConsumer
{
    interface IReportDataQuery
    {        
        string stringData(string expression);
        QuantumStockServiceProvider.AnalysisRequest tableData(string expression, int tableType);
        byte[] chartData(string expression, int chartType);
    }
}
