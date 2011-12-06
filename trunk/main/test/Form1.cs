using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace test
{
    public partial class Form1 : baseClass.forms.baseForm
    {
        application.AnalysisData myData = new application.AnalysisData();
        public Form1()
        {
            InitializeComponent();
            data.SysLibs.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
            myData.DataStockCode = "ACB";
            myData.DataTimeRange = commonClass.AppTypes.TimeRanges.Y1;
            //myData.Reload();
            test();
        }


        private void test()
        {
            //Graph 1
            graphControl1.MasterPane[0].GraphObjList.Clear();
            //graphControl1.MasterPane[0].Chart.Rect = new RectangleF(Charts.Settings.sysChartMarginLEFT,
            //                                                Charts.Settings.sysChartMarginTOP,
            //                                                graphControl1.Width - Charts.Settings.sysChartMarginRIGHT - 60,
            //                                                graphControl1.Height - Charts.Settings.sysChartMarginBOTTOM);

            graphControl1.MasterPane[0].XAxis.IsVisible = true;
            graphControl1.MasterPane[0].XAxis.MinSpace = 100;
            graphControl1.MasterPane[0].XAxis.Scale.MinGrace = 10;
            graphControl1.MasterPane[0].XAxis.Scale.MaxGrace = 10;


            graphControl1.MasterPane[0].XAxis.Type = AxisType.DateAsOrdinal; 
            CurveItem curveItem1 = graphControl1.MasterPane[0].AddCurve("line1",myData.DateTime.Values, myData.Close.Values,Color.Red);
            

            ////Add 3 mmarkers at left, middle, right locations
            //PointPairList list = new PointPairList();
            //int[] idList = new int[] { 0, myData.Close.Count/2, myData.Close.Count - 1 };

            //for (int idx = 0; idx < curveItem1.Points.Count-1; idx += 2)
            //{
            //    PointPair point = curveItem1.Points[idx];

            //    TextObj text = new TextObj();
            //    text.Text = "o";
            //    text.Location.CoordinateFrame = CoordType.AxisXYScale;
            //    PointF p = graphControl1.MasterPane[0].GeneralTransform(point.X, point.Y, text.Location.CoordinateFrame);

            //    text.Location.X = idx;
            //    text.Location.Y = point.Y;

            //    text.Location.AlignH = AlignH.Center;
            //    text.Location.AlignV = AlignV.Top;
                
            //    text.FontSpec.FontColor = Color.Green;
            //    text.FontSpec.IsBold = false;
            //    text.FontSpec.Size = 12;
            //    graphControl1.MasterPane[0].GraphObjList.Add(text);
            //}

            //Graph 2
            myGraph2.myGraphPane.GraphObjList.Clear();

            myGraph2.SetFont(12);
            
            myGraph2.myGraphPane.Chart.Rect = new RectangleF(Charts.Settings.sysChartMarginLEFT,
                                                Charts.Settings.sysChartMarginTOP,
                                                myGraph2.Width - Charts.Settings.sysChartMarginRIGHT,
                                                myGraph2.Height - Charts.Settings.sysChartMarginBOTTOM);

            myGraph2.SetSeriesX(myData.DateTime.Values, Charts.AxisType.Date);
            CurveItem curveItem2 = myGraph2.AddCurveBar("line2", myData.Close.Values, Color.Green, Color.Navy, 1);
            myGraph2.DefaultViewport();

            graphControl1.AxisChange();
            graphControl1.Invalidate();

            myGraph2.UpdateChart();

        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            ShowStockChart("ACB");
        }
        private void ShowStockChart(string code)
        {
            //data.baseDS.stockCodeRow stockRow = application.AnalysisDataLibs.GetStockData(code);
            //string formName = stockRow.code.Trim();
            //Tools.Forms.test myForm = new Tools.Forms.test();
            //myForm.Name = formName;
            //myForm.UseStock(stockRow);  //Get data first
            //myForm.ShowDialog();
        }
    }
}
