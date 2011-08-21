using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using application;

namespace client.forms
{
    public partial class tradeAnalysis : baseClass.forms.baseTradeAnalysis
    {
        public tradeAnalysis()
        {
            InitializeComponent();
        }

        protected override analysis.analysisResult TradeAnalysis(analysis.workData data, string strategyCode)
        {
            return strategy.libs.Strategy(data, strategyCode.Trim());
        }
    }
}
