using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace stockTrade.forms
{
    public partial class marketWatchList : baseClass.forms.baseWatchList 
    {
        public marketWatchList()
        {
            try
            {
                InitializeComponent();
                Init();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public override void Init()
        {
            watchListCb.WatchType = application.myTypes.PortfolioTypes.WatchList;
            base.Init();
            LoadData();
        }
        protected override void FormResize()
        {
            base.FormResize();
            this.refreshBtn.Location = new Point(this.Width - this.refreshBtn.Width, 0);
            this.watchListCb.Width = this.refreshBtn.Location.X;
        }       

      

        private void watchList_Load(object sender, EventArgs e)
        {
            try
            {
                stockGV.SetColumnVisible(new string[] { gridColumnName.StockCode.ToString(), 
                                                    gridColumnName.Price.ToString(), 
                                                    gridColumnName.PriceVariant.ToString()}, true);
                stockGV.Columns[gridColumnName.StockCode.ToString()].HeaderText = "Mã";
                stockGV.Columns[gridColumnName.Price.ToString()].HeaderText = "Giá";
                stockGV.Columns[gridColumnName.PriceVariant.ToString()].HeaderText = "+/-";

                stockGV.RowHeadersVisible = false;
                myStatusStrip.Visible = false;
                FormResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
