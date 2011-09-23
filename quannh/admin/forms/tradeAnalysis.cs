using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace stock.forms
{
    public partial class tradeAnalysis : Tools.Forms.tradeAnalysis
    {
        public tradeAnalysis()
        {
            InitializeComponent();
        }

        //protected override Strategy.TradePoints TradeAnalysis(application.Data data, string strategyCode)
        //{
        //    return Strategy.Libs.Analysis(data, strategyCode.Trim());
        //}
    }
}
