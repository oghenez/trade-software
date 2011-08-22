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
    public partial class backTesting : baseClass.forms.baseBackTesting
    {
        public backTesting()
        {
            InitializeComponent();
        }
        protected override baseClass.forms.baseTradeAnalysis GetTradeAnalysisForm()
        {
            return new tradeAnalysis();
        }
    }
}
