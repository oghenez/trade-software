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
        application.Data myData = new application.Data();
        public Form1()
        {
            InitializeComponent();
            data.system.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
            myData.DataStockCode = "SSI";
            myData.DataTimeRange = application.AppTypes.TimeRanges.Y1;
            myData.Reload();
            test();
        }


        private void test()
        {
            int fontSize = 20;

            //Graph 1
            myGraph1.myGraphPane.GraphObjList.Clear();
            myGraph1.myGraphPane.GraphObjList.Clear();
            myGraph1.myGraphPane.XAxis.Scale.FontSpec.Size = fontSize;
            myGraph1.myGraphPane.X2Axis.Scale.FontSpec.Size = fontSize;

            myGraph1.myGraphPane.YAxis.Scale.FontSpec.Size = fontSize;
            myGraph1.myGraphPane.Y2Axis.Scale.FontSpec.Size = fontSize;

            myGraph1.myGraphPane.Y2Axis.IsVisible = false;


            myGraph1.myGraphPane.Chart.Rect = new RectangleF(Charts.Settings.sysChartMarginLEFT,
                                                            Charts.Settings.sysChartMarginTOP,
                                                            myGraph1.Width - Charts.Settings.sysChartMarginRIGHT-60,
                                                            myGraph1.Height - Charts.Settings.sysChartMarginBOTTOM);


            myGraph1.SetSeriesX(myData.DateTime.Values, Charts.Controls.myAxisType.Date);
            CurveItem curveItem1 = myGraph1.AddCurveLine("line1", myData.Close.Values, SymbolType.None, Color.Red,1);
            myGraph1.DefaultViewport();

            //Add 3 mmarkers at left, middle, right locations
            PointPairList list = new PointPairList();
            int[] idList = new int[] { 0, myData.Close.Count/2, myData.Close.Count - 1 };
            for (int idx = 0; idx < idList.Length; idx++)
            {
                PointPair point = curveItem1.Points[idList[idx]];

                TextObj text = new TextObj();
                text.Text = "o";
                text.Location.X = point.X;
                text.Location.Y = point.Y;
                text.Location.CoordinateFrame = CoordType.AxisXYScale;
                text.FontSpec.FontColor = Color.Green;
                text.FontSpec.IsBold = false;
                text.FontSpec.Size = 12;
                myGraph1.myGraphPane.GraphObjList.Add(text);
            }
            myGraph1.UpdateChart();

            //Graph 2

            myGraph2.myGraphPane.GraphObjList.Clear();


            //Set font size but it is not the same as myGraph1, why ??
            myGraph2.myGraphPane.XAxis.Scale.FontSpec.Size = fontSize;
            myGraph2.myGraphPane.X2Axis.Scale.FontSpec.Size = fontSize;
            myGraph2.myGraphPane.YAxis.Scale.FontSpec.Size = fontSize;
            myGraph2.myGraphPane.Y2Axis.Scale.FontSpec.Size = fontSize;

            myGraph2.myGraphPane.Chart.Rect = new RectangleF(Charts.Settings.sysChartMarginLEFT,
                                                Charts.Settings.sysChartMarginTOP,
                                                myGraph1.Width - Charts.Settings.sysChartMarginRIGHT,
                                                myGraph1.Height - Charts.Settings.sysChartMarginBOTTOM);


            myGraph2.SetSeriesX(myData.DateTime.Values, Charts.Controls.myAxisType.Date);
            CurveItem curveItem2 = myGraph2.AddCurveBar("line2", myData.Close.Values, Color.Green, Color.Navy, 1);
            myGraph2.DefaultViewport();

        }

        private void testBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
