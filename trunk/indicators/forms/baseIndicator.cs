using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace indicators.forms
{
    public partial class baseIndicator : common.forms.baseDialogForm
    {
        public baseIndicator()
        {
            InitializeComponent();
        }
        public bool isDisplayChart = false;
        public baseClass.forms.baseGraphForm myParentForm = null;
        public baseClass.controls.graphPane mainGraphPane = null;
        private baseClass.controls.graphPane _workGraphPane = null;
        protected baseClass.controls.graphPane workGraphPane
        {
            get
            {
                if (!inNewPaneChk.Checked)
                {
                    //if (_workGraphPane != null) myParentForm.RemovePane(_workGraphPane);
                    return mainGraphPane;
                }
                if (_workGraphPane == null || _workGraphPane.IsDisposed)
                {
                    _workGraphPane = myParentForm.CreatePane(common.system.UniqueString(), -1, mainGraphPane.Name);
                    _workGraphPane.Height = mainGraphPane.Height/4;
                    _workGraphPane.Width = mainGraphPane.Width;
                    _workGraphPane.mySizingOptions = common.control.basePanel.SizingOptions.Top | 
                                                     common.control.basePanel.SizingOptions.Bottom;
                    _workGraphPane.minSizingHeight = 20;
                }
                return _workGraphPane;
            }
        }

        //private override Color[] colors
        //{
        //    get { return new Color[] { mainColorEd.Color}; }
        //    set 
        //    {
        //        if (value.Length < 1) return; 
        //        mainColorEd.Color = value[0];
        //    }
        //}
        
        public class indicatorData
        {
            public indicatorData(){}
            public indicatorData(int _begin, int _endIdx, double[] _values0, double[] _values1)
            {
                beginIdx = _begin;
                endIdx = _endIdx;
                values0 = _values0;  
                values1 = _values1;
            }
            public int beginIdx = 0, endIdx = 0;
            public double[] values0, values1;
        }

        //Return an array of indicator data, each array item represent an indicator. 
        protected virtual indicatorData[] MakeIndicator(data.baseDS data) { return null; }
        public virtual void Init()
        {
            mainColorEd.LoadColors();
        }
        public void PlotChart()
        {
            PlotChart(MakeGraphData(MakeIndicator(this.myParentForm.myDataSet)));
        }
        protected virtual void PlotChart(PointPairList[] list) { }
        protected virtual void RemoveChart() { }

        // Make chart data from indicator data.
        //  - indicatorData.values0 -> Y
        //  - indicatorData.values1 -> X
        protected virtual PointPairList[] MakeGraphData(indicatorData[] data)
        {
            PointPairList[] outputList = new PointPairList[data.Length];
            for (int idx1 = 0; idx1 < data.Length; idx1++)
            {
                if (data[idx1].values0 != null && data[idx1].values1 != null)
                {
                    PointPairList list = new PointPairList();
                    for (int idx2 = data[idx1].beginIdx; idx2 <= data[idx1].endIdx; idx2++)
                    {
                        list.Add(data[idx1].values1[idx2], data[idx1].values0[idx2]);
                    }
                    outputList[idx1] = list;
                }
                else outputList[idx1] = null;
            }
            return outputList;
        }
        protected override bool BeforeAcceptProcess() 
        { 
            isDisplayChart= true;
            return base.BeforeAcceptProcess();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                isDisplayChart = false;
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
            RemoveChart();
            if (isDisplayChart)
            {
                PlotChart(MakeGraphData(MakeIndicator(this.myParentForm.myDataSet)));
            }
        }
    }
}
