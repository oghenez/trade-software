using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using application;

namespace stock.forms
{
    public partial class tradeAnalysis : baseClass.forms.baseTradeAnalysis
    {
        public tradeAnalysis()
        {
            InitializeComponent();
        }

        protected override stockLibs.analysisResult TradeAnalysis(data.tmpDS.analysisDataDataTable dataTbl,string stockCode, string strategyCode, DateTime frDate, DateTime toDate)
        {
            return strategy.libs.Strategy(dataTbl, stockCode,strategyCode.Trim(), frDate, toDate);
        }
    }
}
