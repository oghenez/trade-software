using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tools.Forms
{
    public partial class MarketSummary : baseClass.forms.baseForm 
    {
        public MarketSummary()
        {
            InitializeComponent();
            databases.baseDS.investorDataTable investor=DataAccess.Libs.GetInvestor_ByCode(commonClass.SysLibs.sysLoginCode);
            TitleLbl.Text = "Hi " + investor[0].firstName + investor[0].lastName + ",\r\n" + TitleLbl.Text;
        }

        private void MarketSummary_Load(object sender, EventArgs e)
        {
            //Define trends of a Stock (SSI)
            //commonClass.BaseAnalysisData stockData = new commonClass.BaseAnalysisData(commonClass.AppTypes.TimeRanges.Y1,
            //                                                                      commonClass.AppTypes.TimeScaleFromCode("D1"), "SSI",
            //                                                                      DataAccessMode.WebService);
            //Ap dung Rule
            //Strategy
        }
    }
}
