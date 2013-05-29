using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXMLDemo
{
    public class ReportResult
    {
        MetaObject meta;

        public MetaObject Meta
        {
            get { return meta; }
            set { meta = value; }
        }
        String[][] data;

        public String[][] Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
