using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using ZedGraph;

namespace Charts
{
    public enum AxisType : byte
    {
        DateAsOrdinal = 0, Date = 1, Linear = 2
    }
    public enum AxisUnit : byte
    {
        Second = 0, Minute = 1, Hour = 2, Day = 3, Month = 4, Year = 5
    }
    public class IntRange
    {
        public int Max = int.MinValue, Min = int.MaxValue;
        public IntRange() { }
        public IntRange(int min, int max)
        {
            Min = min; Max = max;
        }
        public void Reset()
        {
            this.Max = int.MaxValue;
            this.Min = int.MinValue;
        }
        public void Set(int min, int max)
        {
            this.Max = max;
            this.Min = min;
        }
    }
    public class ValueRange
    {
        public double Max = double.MinValue, Min = double.MaxValue;
        public ValueRange() { }
        public ValueRange(double min, double max)
        {
            Min = min; Max = max;
        }
        public void Reset()
        {
            this.Max = double.MaxValue;
            this.Min = double.MinValue;
        }
        public void Set(double min, double max)
        {
            this.Max = max;
            this.Min = min;
        }

    }
    public class ViewportState
    {
        public IntRange xRange = new IntRange();
        public ValueRange yRange = new ValueRange();
        public StateType state = StateType.None;
        public enum StateType : byte
        {
            None = 0,
            Zooming = 1,
            Panning = 2
        }
        //public bool isStickOutLEFT = false, isStickOutRIGHT = false;
        public AxisType myAxisType = AxisType.Linear;
        public AxisUnit myAxisUnit = AxisUnit.Day;

        public void Reset()
        {
            xRange.Reset();
            yRange.Reset();
            //isStickOutLEFT = false;
            //isStickOutRIGHT = false;
            state = StateType.None;
        }
    }
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

        public DrawCurve[] CurveInPane(string paneName)
        {
            DrawCurve[] list = new DrawCurve[0];
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                if (drawCurve.PaneName == paneName) 
                {
                    Array.Resize(ref list, list.Length + 1);
                    list[list.Length-1] = (DrawCurve)items[idx];
                }
            }
            return list;
        }
        //TUAN - Update Curve Name in Pane when the pane name changed
        public void UpdateCurveWhenPaneNameChanged(string oldPane,string newPane)
        {            
            object[] items = Cache.Values;
            for (int idx = 0; idx < items.Length; idx++)
            {
                DrawCurve drawCurve = (DrawCurve)items[idx];
                if (drawCurve.PaneName == oldPane)
                {
                    drawCurve.PaneName = newPane;
                }
            }            
        }
        //TUAN
        //public int NumberOfCurves(string paneName)
        //{
        //    int count = 0;
        //    object[] items = Cache.Values;
        //    for (int idx = 0; idx < items.Length; idx++)
        //    {
        //        DrawCurve drawCurve = (DrawCurve)items[idx];
        //        if (drawCurve.PaneName == paneName) count++;
        //    }
        //    return count;
        //}
    }

    public class Libs
    {
        public static void GetRangeY(CurveItem curve,int fromId, int toId,ref ValueRange range)
        {
            if (curve.GetType() == typeof(JapaneseCandleStickItem))
            {
                GetRangeY((curve as JapaneseCandleStickItem), fromId, toId, ref range);
                return;
            }

            if (curve.GetType() == typeof(LineItem))
            {
                GetRangeY((curve as LineItem), fromId, toId, ref range);
                return;
            }

            if (curve.GetType() == typeof(BarItem))
            {
                GetRangeY((curve as BarItem), fromId, toId, ref range);
                return;
            }

            if (curve.GetType() == typeof(StickItem))
            {
                GetRangeY((curve as StickItem), fromId, toId, ref range);
                return;
            }
        }
        public static void GetRangeY(JapaneseCandleStickItem curve, int fromId, int toId, ref ValueRange yRange)
        {
            fromId = Math.Max(fromId, 0);
            toId = Math.Min(toId, curve.Points.Count - 1);
            for (int idx = fromId; idx <= toId; idx++)
            {
                StockPt item = (StockPt)curve.Points[idx];
                if (item.Low < yRange.Min) yRange.Min = item.Low;
                if (item.High > yRange.Max) yRange.Max = item.High;
            }
        }
        public static void GetRangeY(LineItem curve, int fromId, int toId, ref ValueRange yRange)
        {
            fromId = Math.Max(fromId, 0);
            toId = Math.Min(toId, curve.Points.Count - 1);
            for (int idx = fromId; idx <= toId; idx++)
            {
                if (idx < 0 || idx >= curve.Points.Count) continue;
                PointPair item = (PointPair)curve.Points[idx];
                if (item.Y < yRange.Min) yRange.Min = item.Y;
                if (item.Y > yRange.Max) yRange.Max = item.Y;
            }
        }
        public static void GetRangeY(BarItem curve, int fromId, int toId, ref ValueRange yRange)
        {
            fromId = Math.Max(fromId, 0);
            toId = Math.Min(toId, curve.Points.Count - 1);
            for (int idx = fromId; idx <= toId; idx++)
            {
                if (idx < 0 || idx >= curve.Points.Count) continue;
                PointPair item = (PointPair)curve.Points[idx];
                if (item.Y < yRange.Min) yRange.Min = item.Y;
                if (item.Y > yRange.Max) yRange.Max = item.Y;
            }
        }
        public static void GetRangeY(StickItem curve, int fromId, int toId, ref ValueRange yRange)
        {
            fromId = Math.Max(fromId, 0);
            toId = Math.Min(toId, curve.Points.Count - 1);
            for (int idx = fromId; idx <= toId; idx++)
            {
                if (idx < 0 || idx >= curve.Points.Count) continue;
                PointPair item = (PointPair)curve.Points[idx];
                if (item.Y < yRange.Min) yRange.Min = item.Y;
                if (item.Y > yRange.Max) yRange.Max = item.Y;
            }
        }

        public static double[] GetSeriesX(CurveItem curve)
        {
            double[] seriesX = new double[curve.Points.Count];
            for (int idx = 0; idx < curve.Points.Count; idx++) seriesX[idx] =((PointPair)curve.Points[idx]).X;
            return seriesX;
        }

        public static void UpdateSeriesX(CurveItem curve,ref double[] list)
        {
            if (curve.Points.Count == list.Length) return;
            int lastSz = list.Length;
            Array.Resize(ref list,curve.Points.Count);
            for (int idx = lastSz; idx < curve.Points.Count; idx++) list[idx] = ((PointPair)curve.Points[idx]).X;
        }
    }
}
