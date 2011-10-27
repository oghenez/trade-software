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

            myPriceGraphObj.SetSeriesX(myData.DateTime.Values, Charts.Controls.myAxisType.DateAsOrdinal);
            myPriceGraphObj.AddCurveLine("Line1", myData.Close.Values, ZedGraph.SymbolType.None, Color.Red,1);
            myPriceGraphObj.AddCandleStick("CandleStick", myData.High.Values,myData.Low.Values,myData.Open.Values,
                                      myData.Close.Values,myData.Volume.Values,Color.Red, Color.Green,Color.Violet,Color.Black);

            myVolumeGraphObj.SetSeriesX(myData.DateTime.Values, Charts.Controls.myAxisType.DateAsOrdinal);
            myVolumeGraphObj.AddCurveStick("Stick", myData.Volume.Values, Color.Green);



            myPriceGraphObj.Width = this.ClientRectangle.Width;
            myVolumeGraphObj.Width = this.ClientRectangle.Width;

            myPriceGraphObj.Location = new Point(0,myPriceGraphObj.Location.Y);
            myVolumeGraphObj.Location = new Point(0, myVolumeGraphObj.Location.Y);

            //myPriceGraphObj.myGraphPane.YAxis.IsVisible = false;
            //myVolumeGraphObj.myGraphPane.YAxis.IsVisible = false;

            //myPriceGraphObj.myGraphPane.Margin.Left = 35;
            //myVolumeGraphObj.myGraphPane.Margin.Left = 100;

            //myVolumeGraphObj.myGraphPane.YAxis.MinSpace = 100;
            //myVolumeGraphObj.myGraphPane.Margin.Left = 100;
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
        private void myPriceGraphObj_myOnViewportChanged(object sender, Charts.Controls.myGraphControl.ViewportState state)
        {
            myVolumeGraphObj.myViewportX = state.Range;
        }
        private void myVolumeGraphObj_myOnViewportChanged(object sender, Charts.Controls.myGraphControl.ViewportState state)
        {
            myPriceGraphObj.myViewportX = state.Range;
        }
    }
}
