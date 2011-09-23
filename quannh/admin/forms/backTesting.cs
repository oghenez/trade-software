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
    public partial class backTesting : Tools.Forms.backTesting 
    {
        public backTesting()
        {
            InitializeComponent();
        }
        //protected override tools.forms.tradeAnalysis GetTradeAnalysisForm()
        //{
        //    return new tools.forms.tradeAnalysis(); 
        //}
    }
}
