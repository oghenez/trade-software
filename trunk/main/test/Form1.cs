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
            myData.DataTimeRange = application.AppTypes.TimeRanges.M3;
            myData.Reload();
            test();
        }


        private void test()
        {

            //Graph 1
            myGraph1.myGraphPane.GraphObjList.Clear();
            myGraph1.myGraphPane.GraphObjList.Clear();
            myGraph1.SetFont(12);
            myGraph1.myGraphPane.Chart.Rect = new RectangleF(Charts.Settings.sysChartMarginLEFT,
                                                            Charts.Settings.sysChartMarginTOP,
                                                            myGraph1.Width - Charts.Settings.sysChartMarginRIGHT-60,
                                                            myGraph1.Height - Charts.Settings.sysChartMarginBOTTOM);


            myGraph1.SetSeriesX(myData.DateTime.Values, Charts.AxisType.Date);
            CurveItem curveItem1 = myGraph1.AddCurveLine("line1", myData.Close.Values, SymbolType.None, Color.Red,1);
            myGraph1.DefaultViewport();

            //Add 3 mmarkers at left, middle, right locations
            PointPairList list = new PointPairList();
            int[] idList = new int[] { 4, myData.Close.Count/2, myData.Close.Count - 1 };
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
            //Graph 2

            myGraph2.myGraphPane.GraphObjList.Clear();

            //Set font size but it is not the same as myGraph1, why ??
            myGraph2.SetFont(12);
            
            myGraph2.myGraphPane.Chart.Rect = new RectangleF(Charts.Settings.sysChartMarginLEFT,
                                                Charts.Settings.sysChartMarginTOP,
                                                myGraph2.Width - Charts.Settings.sysChartMarginRIGHT,
                                                myGraph2.Height - Charts.Settings.sysChartMarginBOTTOM);

            myGraph2.SetSeriesX(myData.DateTime.Values, Charts.AxisType.Date);
            CurveItem curveItem2 = myGraph2.AddCurveBar("line2", myData.Close.Values, Color.Green, Color.Navy, 1);
            myGraph2.DefaultViewport();

            myGraph1.UpdateChart();
            myGraph2.UpdateChart();

        }

        private void testBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
