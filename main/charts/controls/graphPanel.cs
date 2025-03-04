using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace Charts.Controls
{
    public partial class baseGraphPanel : common.controls.basePanel
    {
        public myGraphControl myGraphObj = new myGraphControl();
       
        public baseGraphPanel()
        {
            this.Controls.Add(myGraphObj);
            this.haveCloseButton = true;
            myGraphObj.Location = new Point(0, 0);
        }
        
        public void ResetGraph()
        {
            myGraphObj.DefaultViewport();
        }

        public void PlotGraph()
        {
            // Tell ZedGraph to calculate the axis ranges
            myGraphObj.AxisChange();
            myGraphObj.Invalidate();
        }
        public void RemoveAllCurves()
        {
            while (myGraphObj.myGraphPane.CurveList.Count > 0)
                myGraphObj.myGraphPane.CurveList.Remove(myGraphObj.myGraphPane.CurveList[0]);
        }
        public void RemoveCurve(CurveItem item)
        {
            myGraphObj.myGraphPane.CurveList.Remove(item);
        }
        #region override functions
        protected override void OnResize(EventArgs e)
        {
            myGraphObj.Location = new Point(0, 0);
            myGraphObj.Size = new Size(this.Width, this.Height);
            myGraphObj.CalcGraphSize();
            base.OnResize(e);
        }
        #endregion override functions
    }

}