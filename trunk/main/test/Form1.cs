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
    public partial class Form1 : baseClass.forms.baseGraphForm
    {
        const int constPriceChartMarginBOTTOM = 40;
        const string constPaneNamePrice = "pricePanel";
        const string constPaneNameVolume = "volumePanel";
        const string constPaneNameNew = "newPanel";
        const string constCurveNamePrefixIndicator = "Indicator-";
        
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
            graphPane.myGraphObj.SetSeriesX(myData.DateTime.Values, Charts.Controls.myAxisType.Date);
            CurveItem curveItem = graphPane.myGraphObj.AddCurveLine("curveName", myData.Close.Values, SymbolType.None, Color.Red, 1);

            PointPairList list = new PointPairList();
            int[] idList = new int[] { 10, 30, 40, 52, 60, 80, 90, 95 };
            for (int idx = 0; idx < idList.Length; idx++)
            {
                break;
                PointPair point = curveItem.Points[idList[idx]];

                TextObj text = new TextObj();
                text.Text = "B";
                text.Location.X = point.X;
                text.Location.Y = point.Y;
                text.Location.CoordinateFrame = CoordType.AxisXYScale;
                text.FontSpec.FontColor = Color.Green;
                text.FontSpec.IsBold = false;
                text.FontSpec.Size = 12;
                // Disable the border and background fill options for the text
                text.FontSpec.Border.IsVisible = false;
                text.FontSpec.Fill.IsVisible = false;
                // Align the text such the the Left-Bottom corner is at the specified coordinates
                //text.Location.AlignH = AlignH.Left;
                //text.Location.AlignV = AlignV.Bottom;
                graphPane.myGraphObj.myGraphPane.GraphObjList.Add(text);
            }

            for (int idx = 0; idx < idList.Length; idx++)
            {
                PointPair point = curveItem.Points[idList[idx]];

                ImageObj text = new ImageObj();
                text.Image = (idx%2==0?Properties.Resources.flag:Properties.Resources.budget);

                text.Location.X = point.X;
                text.Location.Y = point.Y;
                text.Location.Width = 5.5;
                text.Location.Height = 0.5;
                text.Location.CoordinateFrame = CoordType.AxisXYScale;
                // Align the text such the the Left-Bottom corner is at the specified coordinates
                //text.Location.AlignH = AlignH.Left;
                //text.Location.AlignV = AlignV.Bottom;
                graphPane.myGraphObj.myGraphPane.GraphObjList.Add(text);
            }


            graphPane.myGraphObj.AxisChange();
            graphPane.myGraphObj.Invalidate();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {

            //PointPairList list = new PointPairList();
            //int[]  idList = new int[] {10,30,40,52,60,80,90,95};
            //for(int idx=0;idx<idList.Length;idx++)
            //{
            //    list.Add(new PointPair(myData.DateTime[idList[idx]], myData.Close[idList[idx]], idList[idx].ToString()));
            //}
            //var pointsCurve = pricePanel.myGraphObj.myGraphPane.AddCurve("", list, Color.Green);
            //pricePanel.myGraphObj.AxisChange();
            //pricePanel.myGraphObj.Invalidate();


            //LineItem myCurve = myGraphPane.AddCurve(name, this.mySeriesX, seriesY, color, symbol);

            //ZedGraph.CurveItem curveItem = myPanel.myGraphObj.AddCurveLine("Line1", myData.Close.Values, ZedGraph.SymbolType.Diamond, Color.Red, 1);


            //myPriceGraphObj.myGraphPane.XAxis.Scale.MajorStep = (myData.Close.Max - myData.Close.Min) / (myData.Close.Count*10);
            //myPriceGraphObj.myGraphPane.XAxis.Scale.MinorStep = myPriceGraphObj.myGraphPane.XAxis.Scale.MinorStep / 2;
            //myPriceGraphObj.myGraphPane.XAxis.Scale.MajorStep = (myData.Close.Max - myData.Close.Min) / (1*myData.Close.Count);
            //myPriceGraphObj.myGraphPane.XAxis.Scale.MinorStep = myPriceGraphObj.myGraphPane.XAxis.Scale.MajorStep/2;

            //myPriceGraphObj.myGraphPane.XAxis.Type = AxisType.Date;
            //myPriceGraphObj.myGraphPane.XAxis.Scale.MajorUnit = DateUnit.Day;
            //myPriceGraphObj.myGraphPane.XAxis.Scale.MinorUnit = DateUnit.Minute; 

        }
    }
}
