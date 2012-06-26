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
    /// <summary>
    /// Integer Range
    /// </summary>
    public class IntRange
    {
        public int Max = int.MinValue, Min = int.MaxValue;
        public IntRange() { }
        /// <summary>
        /// Contructor for IntRange 
        /// </summary>
        /// <param name="min">minimum of range</param>
        /// <param name="max">maxium of range</param>
        public IntRange(int min, int max)
        {
            Min = min; Max = max;
        }
        /// <summary>
        /// Reset range
        /// </summary>
        public void Reset()
        {
            this.Max = int.MaxValue;
            this.Min = int.MinValue;
        }
        /// <summary>
        /// Set min max for range
        /// </summary>
        /// <param name="min">minimum of range</param>
        /// <param name="max">maxium of range</param>
        public void Set(int min, int max)
        {
            this.Max = max;
            this.Min = min;
        }
    }
    /// <summary>
    /// Double value range
    /// </summary>
    public class ValueRange
    {
        public double Max = double.MinValue, Min = double.MaxValue;
        public ValueRange() { }
        /// <summary>
        /// Contructor for ValueRange 
        /// </summary>
        /// <param name="min">minimum of range</param>
        /// <param name="max">maxium of range</param>
        public ValueRange(double min, double max)
        {
            Min = min; Max = max;
        }
        /// <summary>
        /// Reset range
        /// </summary>
        public void Reset()
        {
            this.Max = double.MaxValue;
            this.Min = double.MinValue;
        }
        /// <summary>
        /// Set min max for range
        /// </summary>
        /// <param name="min">minimum of range</param>
        /// <param name="max">maxium of range</param>
        public void Set(double min, double max)
        {
            this.Max = max;
            this.Min = min;
        }

    }
    /// <summary>
    /// Viewport State.None Zooming Panning
    /// </summary>
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

        /// <summary>
        /// Reset viewport
        /// </summary>
        public void Reset()
        {
            xRange.Reset();
            yRange.Reset();
            //isStickOutLEFT = false;
            //isStickOutRIGHT = false;
            state = StateType.None;
        }
    }
    /// <summary>
    /// Draw curve
    /// </summary>
    public class DrawCurve
    {
        /// <summary>
        /// Contructor for DrawCurve
        /// </summary>
        /// <param name="_curve">Curve Item</param>
        /// <param name="_curveName">Name of curve</param>
        /// <param name="_pane">Pane</param>
        /// <param name="_paneName">Name of Pane</param>
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
    /// <summary>
    /// List container for curves
    /// </summary>
    public class CurveList
    {
        common.DictionaryList Cache = new common.DictionaryList();
        /// <summary>
        /// Find out DrawCurve 
        /// </summary>
        /// <param name="curveName"></param>
        /// <returns></returns>
        public DrawCurve Find(string curveName)
        {
            return (DrawCurve)this.Cache.Find(curveName);
        }        
        /// <summary>
        /// Return curves that its name starts with [namePrefix]
        /// </summary>
        /// <param name="namePrefix"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add Curve to cache
        /// </summary>
        /// <param name="curve">Curve object</param>
        /// <param name="curveName">The name of curve</param>
        /// <param name="pane">the pane for putting curve on</param>
        /// <param name="paneName">the name of pane</param>
        public void Add(CurveItem curve, string curveName, GraphPane pane, string paneName)
        {
            this.Cache.Add(curveName, new DrawCurve(curve, curveName, pane, paneName));
        }
        /// <summary>
        /// Remove curve
        /// </summary>
        /// <param name="curveName"></param>
        public void Remove(string curveName)
        {
            Remove(curveName, false);
        }
        /// <summary>
        /// Remove curve by Name
        /// </summary>
        /// <param name="curveName"></param>
        /// <param name="startWith"></param>
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
        /// <summary>
        /// Remove pane by name
        /// </summary>
        /// <param name="paneName"></param>
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
        /// <summary>
        /// Remove all on cache
        /// </summary>
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
        /// <summary>
        /// Get list curves of Pane
        /// </summary>
        /// <param name="paneName"></param>
        /// <returns></returns>
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
    /// <summary>
    /// Libs class provide some static method for Get range and series in chart drawing
    /// </summary>
    public class Libs
    {
        /// <summary>
        /// Get the ValueRange with min max for set view port correctly
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="range"></param>
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
        /// <summary>
        /// Get the ValueRange with min max for set view port correctly
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="yRange"></param>
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
        /// <summary>
        /// Get the ValueRange with min max for set view port correctly
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="yRange"></param>
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
        /// <summary>
        /// Get the ValueRange with min max for set view port correctly
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="yRange"></param>
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
        /// <summary>
        /// Get the ValueRange with min max for set view port correctly
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="fromId"></param>
        /// <param name="toId"></param>
        /// <param name="yRange"></param>
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
        /// <summary>
        /// Get seresX values on the curve item
        /// </summary>
        /// <param name="curve"></param>
        /// <returns></returns>
        public static double[] GetSeriesX(CurveItem curve)
        {
            double[] seriesX = new double[curve.Points.Count];
            for (int idx = 0; idx < curve.Points.Count; idx++) seriesX[idx] =((PointPair)curve.Points[idx]).X;
            return seriesX;
        }

        /// <summary>
        /// Update seresX values on the curve item
        /// </summary>
        /// <param name="curve"></param>
        /// <param name="list"></param>
        public static void UpdateSeriesX(CurveItem curve,ref double[] list)
        {
            if (curve.Points.Count == list.Length) return;
            int lastSz = list.Length;
            Array.Resize(ref list,curve.Points.Count);
            for (int idx = lastSz; idx < curve.Points.Count; idx++) list[idx] = ((PointPair)curve.Points[idx]).X;
        }
    }
}
