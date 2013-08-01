using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceConsumer.ReportModel
{
    public class StockCommonInfo:CommonModel
    {
        public string GiaTri { get; set; }
        public string TangGiam { get; set; }
        public string DiemTangGiam { get; set; }
        public string PhanTramTangGiam { get; set; }
        public string StockCode { get; set; }

        public StockCommonInfo(string stockCode)
        {
            this.StockCode = stockCode;
        }
        #region CommonModel Members

        public bool ParseData()
        {
            
        }

        #endregion
    }
}
