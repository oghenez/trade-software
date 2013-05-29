using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXMLDemo
{
    class ReportResultFactory
    {
        public static ReportResult createReportResult( ContentTypes type)
        {
            ReportResult rr = new ReportResult();
            rr.Meta.ContentType = type;
            switch (type)
            {
                case ContentTypes.TEXT:
                    rr.Data = new string[1][];
                    rr.Data[0] = new string[1];
                    rr.Data[0][0]=string.Empty;
                    return rr;
                    
                case ContentTypes.IMAGE:
                    rr.Data = new string[1][];
                    rr.Data[0] = new string[1];
                    rr.Data[0][0] = string.Empty;           
                    return rr;
                    
                case ContentTypes.TABLE:
                    rr.Data = new string[1][];
                    rr.Data[0] = new string[1];
                    rr.Data[0][0] = string.Empty;
                    return rr;                    
                default:
                    return null;
            }            
        }
    }
}
