using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXMLDemo
{
    class TestMethods
    {
        public static ReportResult getDateString()
        {
            ReportResult rr =  ReportResultFactory.createReportResult(ContentTypes.TEXT);
            rr.Data[0][0] = DateTime.Now.ToShortDateString();
            return rr;
        }

        public static ReportResult getVNIndex(string date)
        {
            ReportResult rr = ReportResultFactory.createReportResult(ContentTypes.TEXT);
            try
            {
                DateTime time = DateTime.Parse(date);
                rr.Data[0][0] = time.ToOADate().ToString();
                return rr;
            }
            catch(Exception ex){
                rr.Data[0][0]="PARSE ERROR!!!";
                return rr;
            }           
        }

        public static ReportResult getPicture(string stockCode, string date)
        {
            ReportResult rr = ReportResultFactory.createReportResult(ContentTypes.IMAGE);
            return rr;
        }

        public static ReportResult getTable(string stockCode, string fromDate, string toDate)
        {
            ReportResult rr = ReportResultFactory.createReportResult(ContentTypes.TABLE);
            return rr;
        }
    }
}
