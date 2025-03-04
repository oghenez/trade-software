using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using application;

namespace baseClass.forms
{
    public partial class baseTradeAnalysis : baseAnalysis
    {
        protected data.baseDS.stockCodeRow myStockCodeRow = null;
        public baseTradeAnalysis()
        {
            try
            {
                InitializeComponent();

                chartTiming.LoadData();
                cbStrategy.LoadData();

                chartTiming.myTimeRange = AppTypes.TimeRanges.Y1;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void ReSize()
        {
            int constMinWidth = 550;
            int constMinHeight = 250;
            if (this.Width < constMinWidth) this.Width = constMinWidth;
            if (this.Height < constMinHeight) this.Height = constMinHeight;
            toolPnl.Location = new Point(0, this.ClientRectangle.Height - toolPnl.Height-SystemInformation.CaptionHeight);
            toolPnl.Width = this.ClientRectangle.Width + 20;

            stockChart.Location = new Point(0, 0);
            // Leave a small margin around the outside of the control
            stockChart.Size = new Size(this.ClientRectangle.Width, toolPnl.Location.Y-3);
        }

        #region chart + indicator
        protected const int constMaxSeriesPerIndicator = 3;
        protected const string constChartAreaPRICE = "PriceArea";
        protected const string constChartAreaVOLUME = "VolumeArea";

        protected const string constSeriPRICE = "PRICE";
        protected const string constSeriVOLUME = "VOLUME";

        #endregion chart + indicator

        #region event handler

        private void tradeAnalysis_Resize(object sender, EventArgs e)
        {
            try
            {
                ReSize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
 
        }


        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}