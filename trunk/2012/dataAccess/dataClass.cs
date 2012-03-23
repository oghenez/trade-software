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
        /// <summary>
        /// Update data to the most recent from the last update.
        /// </summary>
        /// <returns>Number of updated items</returns>
        public override int UpdateDataFromLastTime()
        {
            int numberOfUpdate = DataAccess.Libs.UpdateAnalysisData(this);
            //if (numberOfUpdate>=0) this.ClearCache();
            return numberOfUpdate;
        }
    }
}
