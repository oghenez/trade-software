using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client.forms
{
    public partial class watchList : baseClass.forms.basePortfolioView
    {
        public watchList()
        {
            try
            {
                InitializeComponent();
                InitForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        public void InitForm()
        {
            for (int idx=0;idx<stockGV.Columns.Count;idx++) stockGV.Columns[idx].Visible=false;
            stockGV.Columns[gridColumnName.StockCode.ToString()].Visible = true;
            stockGV.Columns[gridColumnName.StockCode.ToString()].HeaderText = "Mã";

            stockGV.Columns[gridColumnName.Price.ToString()].Visible = true;
            stockGV.Columns[gridColumnName.Price.ToString()].HeaderText = "Giá";

            stockGV.Columns[gridColumnName.PriceVariant.ToString()].Visible = true;
            stockGV.Columns[gridColumnName.PriceVariant.ToString()].HeaderText = "+/-";
            stockGV.Width = refreshBtn.Location.X + refreshBtn.Width;
            stockNAV.Visible = false;
            stockGV.RowHeadersVisible = false;
            stockGV.ColumnHeadersHeight = SystemInformation.CaptionHeight;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            myStatusStrip.Visible = false;
            //this.Width = refreshBtn.Location.X + refreshBtn.Width + 5;
        }
        protected override void ResizeForm()
        {
            if (this.Width < 3 * refreshBtn.Width) this.Width = 3 * refreshBtn.Width;
            base.ResizeForm();
            porfolioCb.Width = this.Width - porfolioCb.Location.X - refreshBtn.Width;
            refreshBtn.Location = new Point(porfolioCb.Location.X + porfolioCb.Width, refreshBtn.Location.Y);
        }
        private void stockList_myOnStockSeleted(object sender, EventArgs e)
        {
            //try
            //{
            //    string formName = "baseTradeAnalysis" + this.myStockRow.code.Trim();
            //    Form myForm = common.formList.FindForm(formName);
            //    if (myForm == null || myForm.IsDisposed)
            //    {
            //        myForm = new tradeAnalysis();
            //        myForm.Name = formName;
            //        common.formList.AddForm(myForm);
            //    }
            //    ((tradeAnalysis)myForm).ShowForm(this.myStockRow);
            //}
            //catch (Exception er)
            //{
            //    this.ShowError(er);
            //}
        }
    }
}
