using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        application.Data myData = new application.Data();
        public Form2()
        {
            InitializeComponent();
            data.system.dbConnectionString = "Data Source=(local);Initial Catalog=stock;Integrated Security=True";
            myData.DataStockCode = "SSI";
            myData.DataTimeRange = application.AppTypes.TimeRanges.All;
            myData.Reload();

            myPriceGraphObj.SetSeriesX(myData.DateTime.Values, Charts.AxisType.Date);
            myPriceGraphObj.AddCurveLine("Line1", myData.Close.Values, ZedGraph.SymbolType.None, Color.Red,1);
            myPriceGraphObj.AddCandleStick("CandleStick", myData.High.Values,myData.Low.Values,myData.Open.Values,
                                      myData.Close.Values,myData.Volume.Values,Color.Red, Color.Green,Color.Violet,Color.Black);

            myVolumeGraphObj.SetSeriesX(myData.DateTime.Values, Charts.AxisType.Date);
            myVolumeGraphObj.AddCurveStick("Stick", myData.Volume.Values, Color.Green);


            myPriceGraphObj.myGraphPane.BaseDimension = 8.0F;
            myVolumeGraphObj.myGraphPane.BaseDimension = 8.0F;

            myPriceGraphObj.Width = this.ClientRectangle.Width;
            myVolumeGraphObj.Width = this.ClientRectangle.Width;

            myPriceGraphObj.Location = new Point(0,myPriceGraphObj.Location.Y);
            myVolumeGraphObj.Location = new Point(0, myVolumeGraphObj.Location.Y);

            //myPriceGraphObj.myGraphPane.Title.IsVisible = true;
            //myPriceGraphObj.myGraphPane.Legend.IsVisible = true;
            myPriceGraphObj.myGraphPane.XAxis.Title.IsVisible = true;
            myPriceGraphObj.myGraphPane.Y2Axis.Title.IsVisible = true;

            myPriceGraphObj.myGraphPane.YAxis.Scale.FontSpec.Size = 8;
            myVolumeGraphObj.myGraphPane.YAxis.Scale.FontSpec.Size = 12;

            myPriceGraphObj.myGraphPane.Chart.Rect = new RectangleF(50, 0, myPriceGraphObj.Width-100, myPriceGraphObj.Height-0);
            //myPriceGraphObj.AxisChange();
            //myPriceGraphObj.Invalidate();

            
            myVolumeGraphObj.myGraphPane.Chart.Rect = new RectangleF(50,0, myVolumeGraphObj.Width-100, myVolumeGraphObj.Height-20);
            //myVolumeGraphObj.AxisChange();
            //myVolumeGraphObj.Invalidate();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            myPriceGraphObj.DefaultViewport();
            myVolumeGraphObj.DefaultViewport();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            myPriceGraphObj.MoveBackward();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            myPriceGraphObj.MoveForward();
        }

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            myPriceGraphObj.ZoomIn();
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            myPriceGraphObj.ZoomOut();
        }


        //Sync to chart
        private void myPriceGraphObj_myOnViewportChanged(object sender, Charts.ViewportState state)
        {
            myVolumeGraphObj.myViewportX = state.xRange;
        }
        private void myVolumeGraphObj_myOnViewportChanged(object sender, Charts.ViewportState state)
        {
            myPriceGraphObj.myViewportX = state.xRange;
        }
    }
}
