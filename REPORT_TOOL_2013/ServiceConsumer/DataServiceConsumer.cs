using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceConsumer.Test;

namespace ServiceConsumer
{
    public class DataServiceConsumer
    {
        public DataServiceConsumer()
        {         
        }
        public string testString(string expression)
        {            
            return new TestStringData().stringData(expression);
        }
    }
}
