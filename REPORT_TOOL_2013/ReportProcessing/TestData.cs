using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportProcessing
{
    public class TestData
    {
        public string testString(string expression)
        {
            ServiceConsumer.DataServiceConsumer sc = new ServiceConsumer.DataServiceConsumer();
            return sc.testString(expression);           
        }
    }
}
