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


        ////protected override void PlotChart(DataSeries seriesX, DataSeries[] seriesY)
        //{
        //    if (lineCurves.Length < seriesY.Length) Array.Resize(ref lineCurves, seriesY.Length);
        //    for (int idx = 0; idx < seriesY.Length; idx++)
        //    {
        //        lineCurves[idx] = chartLibs.PlotChartLine(workGraphPane.myGraphPane,seriesX,seriesY[idx],"", SymbolType.None, 
        //                                                  this.colorEd.Color,(byte)this.weightEd.Value);
        //    }
        //}

        //protected LineItem[] lineCurves = new LineItem[0];
        //public virtual void RemoveChart()
        //{
        //    for (int idx = 0; idx < lineCurves.Length; idx++)
        //    {
        //        if (lineCurves[idx] == null) continue;
        //        workGraphPane.RemoveCurve(lineCurves[idx]);
        //        mainGraphPane.RemoveCurve(lineCurves[idx]);
        //    }
        //    mainGraphPane.PlotGraph();
        //    workGraphPane.PlotGraph();
        //}
        //public baseClass.forms.baseGraphForm myParentForm = null;
        //public baseClass.controls.graphPane mainGraphPane = null;
        //private baseClass.controls.graphPane _workGraphPane = null;
        //protected baseClass.controls.graphPane workGraphPane
        //{
        //    get
        //    {
        //        if (!inNewPaneChk.Checked)
        //        {
        //            //if (_workGraphPane != null) myParentForm.RemovePane(_workGraphPane);
        //            return mainGraphPane;
        //        }
        //        if (_workGraphPane == null || _workGraphPane.IsDisposed)
        //        {
        //            _workGraphPane = myParentForm.CreatePane(common.system.UniqueString(), -1, mainGraphPane.Name);
        //            _workGraphPane.Height = mainGraphPane.Height/4;
        //            _workGraphPane.Width = mainGraphPane.Width;
        //            _workGraphPane.mySizingOptions = common.control.basePanel.SizingOptions.Top | 
        //                                             common.control.basePanel.SizingOptions.Bottom;
        //            _workGraphPane.minSizingHeight = 20;
        //        }
        //        return _workGraphPane;
        //    }
        //}
    }
}
