using System;
using System.Collections.Generic;
using System.Text;
using ZedGraph;

namespace Charts
{
    public class DrawCurve
    {
        public DrawCurve(CurveItem _curve, string _curveName, GraphPane _pane, string _paneName)
        {
            CurveName = _curveName;
            PaneName = _paneName;
            Curve = _curve;
            Pane = _pane;
        }
        public string CurveName = "";
        public string PaneName = "";
        public CurveItem Curve = null;
        public GraphPane Pane = null;

    }
    public class CurveList
    {
        common.DictionaryList Cache = new common.DictionaryList();
        public DrawCurve Find(string curveName)
        {
            return (DrawCurve)this.Cache.Find(curveName);
        }
        //Return curves that its name starts with [namePrefix]
        public DrawCurve[] FindAll(string namePrefix)
        {
            DrawCurve[] drawCurveList = new DrawCurve[0];
            DrawCurve drawCurve;
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                drawCurve = (DrawCurve)items[idx];
                if (drawCurve.CurveName.StartsWith(namePrefix))
                {
                    Array.Resize(ref drawCurveList, drawCurveList.Length + 1);
                    drawCurveList[drawCurveList.Length - 1] = drawCurve;
                }
            }
            return drawCurveList;
        }
        public void Add(CurveItem curve, string curveName, GraphPane pane, string paneName)
        {
            this.Cache.Add(curveName, new DrawCurve(curve, curveName, pane, paneName));
        }
        public void Remove(string curveName)
        {
            Remove(curveName, false);
        }
        public void Remove(string curveName, bool startWith)
        {
            DrawCurve drawCurve;
            if (!startWith)
            {
                drawCurve = Find(curveName);
                if (drawCurve != null) drawCurve.Pane.CurveList.Remove(drawCurve.Curve);
                this.Cache.Remove(curveName);
            }
            else
            {
                object[] items = Cache.Values;
                for (int idx = 0; idx < items.Length; idx++)
                {
                    drawCurve = (DrawCurve)items[idx];
                    if (drawCurve.CurveName.StartsWith(curveName))
                    {
                        drawCurve.Pane.CurveList.Remove(drawCurve.Curve);
                        this.Cache.Remove(drawCurve.CurveName);
                    }
                }
            }
        }
        public void RemoveByPane(string paneName)
        {
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                if (drawCurve.PaneName != paneName) continue;
                Remove(drawCurve.CurveName);
            }
        }
        public void RemoveAll()
        {
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                drawCurve.Pane.CurveList.Remove(drawCurve.Curve);
            }
            this.Cache.Clear();
        }

        public int NumberOfCurves(string paneName)
        {
            int count = 0;
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                if (drawCurve.PaneName == paneName) count++;
            }
            return count;
        }
    }
}
