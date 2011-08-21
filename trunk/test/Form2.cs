using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using application;


namespace test
{
    public partial class Form2 : Form
    {
        LineItem myLineChar = null;
        baseClass.controls.graphPane testPane = new baseClass.controls.graphPane();
        public Form2()
        {
            InitializeComponent();

            data.system.dbConnectionString = "Data Source=localhost;Initial Catalog=stock;Persist Security Info=True;User ID=sa;Password=1234567";
            myGraphObj.GraphPane.Legend.IsVisible = false;
            myGraphObj.GraphPane.Title.IsVisible = false;
            myGraphObj.GraphPane.YAxis.MajorGrid.IsVisible = true;
            myGraphObj.GraphPane.YAxis.Title.IsVisible = false;
            myGraphObj.GraphPane.XAxis.Title.IsVisible = false;
            //myGraphObj.GraphPane.Border.IsVisible = false;

            data.baseDS.priceDataDataTable priceTbl = new data.baseDS.priceDataDataTable();
            DateTime toDate = DateTime.Today;
            DateTime frDate = toDate.AddYears(-3);
            dataLibs.LoadData(priceTbl, myTypes.timeScales.Daily, frDate, toDate, "ACB");

            if (priceTbl.Count <= 0) return;
            //testPane.SetDateRange(priceTbl[0].onDate, priceTbl[priceTbl.Count - 1].onDate);
            PointPairList list = application.chart.MakePointPairList(priceTbl, stockLibs.stockDataField.Close);
            LineItem myCurve = myGraphObj.GraphPane.AddCurve("aa", list, Color.Red);
            
            myGraphObj.AxisChange();
            //myGraphObj.Invalidate();
            myGraphObj.GraphPane.X2Axis.Scale.TextLabels = new string[] { "1", "2" }; 
            SetSize();
        }
         

        private void SetSize()
        {
            myGraphObj.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height - myGraphObj.Location.Y);
        }
        private void Form2_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (myLineChar == null) return;
            myLineChar.Clear();
            testPane.PlotGraph();
        }
    }
}
