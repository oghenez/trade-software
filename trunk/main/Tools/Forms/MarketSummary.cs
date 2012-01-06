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
            data.baseDS.investorDataTable investor=DataAccess.Libs.GetInvestor_ByCode(commonClass.SysLibs.sysLoginCode);
            TitleLbl.Text = "Hi " + investor[0].firstName + investor[0].lastName + ",\r\n" + TitleLbl.Text;
        }

        private void MarketSummary_Load(object sender, EventArgs e)
        {
            //Define trends of a Stock (SSI)
            
        }
    }
}
