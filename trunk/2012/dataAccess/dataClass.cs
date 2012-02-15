using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Drawing;
using System.Reflection;
using commonTypes;
using commonClass;

namespace DataAccess 
{
    public class AnalysisData : application.AnalysisData 
    {
        public override void LoadData()
        {
            priceDataTbl.Clear();
            Libs.LoadAnalysisData(this);
        }
    }
}
