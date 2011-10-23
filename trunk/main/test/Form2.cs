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

            myGraphObj.SetSeriesX(myData.DateTime.Values, Charts.Controls.myAxisType.DateAsOrdinal);
            myGraphObj.AddCurveLine("Line1", myData.Close.Values, ZedGraph.SymbolType.None, Color.Red,1);
            //myGraphObj.AddCurveBar("Line2", myData.Low.Values, Color.Red,Color.Green,1);
            //myGraphObj.AddCurveStick("Line3", myData.Open.Values, Color.Violet);
            myGraphObj.AddCandleStick("CandleStick", myData.High.Values,myData.Low.Values,myData.Open.Values,
                                      myData.Close.Values,myData.Volume.Values,Color.Red, Color.Green,Color.Violet,Color.Black);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            myGraphObj.DefaultViewport();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            myGraphObj.DefaultViewport();
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            myGraphObj.MoveBackward();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            myGraphObj.MoveForward();
        }


        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            myGraphObj.ZoomIn();
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            myGraphObj.ZoomOut();
        }
    }
}
