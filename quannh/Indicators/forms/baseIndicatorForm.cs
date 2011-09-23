using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using application;

namespace Indicators.forms
{
    public partial class baseIndicatorForm : common.forms.baseDialogForm
    {
        public Type indicatorType = null;
        public baseIndicatorForm()
        {
            InitializeComponent();
        }
        public baseIndicatorForm(Type type)
        {
            InitializeComponent();
            if(type!=null)  this.indicatorType = type; 
        }
        public delegate void PlotChart(baseIndicatorForm sender,bool removeChart);
        public event PlotChart onPlotChart = null;
        public virtual IndicatorFormInfo[] Info
        {
            get {return null; }
            set {}
        }
        public virtual IndicatorFormInfo[] ExtraInfo
        {
            get
            {
                return null;
            }
            set { }
        }
        protected override bool BeforeAcceptProcess() 
        { 
            this.Visible = true;
            return base.BeforeAcceptProcess();
        }
        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = true;
                myFormStatus.Reset();
                myFormStatus.sender = sender;
                DoProcess(sender, myFormStatus);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void baseIndicator_myOnProcess(object sender, common.baseDialogEvent e)
        {
            if (e.isCloseClick) return;
            if (onPlotChart == null) return;
            onPlotChart(this, true);
            if(sender != removeBtn)  onPlotChart(this, false);
        }
    }
}
