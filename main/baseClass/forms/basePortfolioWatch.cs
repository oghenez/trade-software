using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using commonClass;

namespace baseClass.forms
{
    public partial class  basePortfolioWatch : common.forms.baseForm
    {
        public AppTypes.PortfolioTypes watchType = AppTypes.PortfolioTypes.Portfolio;
        public enum gridColumnName 
        {
            StockCode, StockExCode, Qty, BoughtPrice, Price, BoughtAmt, CurrentAmt, 
            ProfitVariantAmt, ProfitVariantPerc, PriceVariant, Volume, Notes
        }
        public basePortfolioWatch()
        {
            try
            {
                this.fOnProccessing = true;
                InitializeComponent();
                stockCodeColumn.HeaderText = "";
                stockCodeColumn.Name = gridColumnName.StockCode.ToString();

                stockExCodeColumn.HeaderText = "";
                stockExCodeColumn.Name = gridColumnName.StockExCode.ToString();

                qtyColumn.HeaderText = "";
                qtyColumn.Name = gridColumnName.Qty.ToString();

                boughtPriceColumn.HeaderText = "";
                boughtPriceColumn.Name = gridColumnName.BoughtPrice.ToString();

                priceColumn.HeaderText = "";
                priceColumn.Name = gridColumnName.Price.ToString();

                boughtAmtColumn.HeaderText = "";
                boughtAmtColumn.Name = gridColumnName.BoughtAmt.ToString();

                amtColumn.HeaderText = "";
                amtColumn.Name = gridColumnName.CurrentAmt.ToString();

                profitVariantAmtColumn.HeaderText = "";
                profitVariantAmtColumn.Name = gridColumnName.ProfitVariantAmt.ToString();

                profitVariantPercColumn.HeaderText = "";
                profitVariantPercColumn.Name = gridColumnName.ProfitVariantPerc.ToString();

                priceVariantColumn.HeaderText = "";
                priceVariantColumn.Name = gridColumnName.PriceVariant.ToString();

                notesColumn.HeaderText = "";
                notesColumn.Name = gridColumnName.Notes.ToString();
                notesColumn.DefaultCellStyle.ForeColor = common.settings.sysColorHiLightFG1;

                volumeColumn.Name = gridColumnName.Volume.ToString();
                stockGV.DisableReadOnlyColumn = false;

                common.dialogs.SetFileDialogEXCEL(saveFileDialog); 

                Init();
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.fOnProccessing = false;
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            watchListCb.SetLanguage();

            stockCodeColumn.HeaderText = Languages.Libs.GetString("code");
            stockExCodeColumn.HeaderText = Languages.Libs.GetString("exchange");
            qtyColumn.HeaderText = Languages.Libs.GetString("qty");
            boughtPriceColumn.HeaderText = Languages.Libs.GetString("boughtPrice");
            priceColumn.HeaderText = Languages.Libs.GetString("price");
            boughtAmtColumn.HeaderText = Languages.Libs.GetString("boughtAmt");
            amtColumn.HeaderText = Languages.Libs.GetString("amount");
            notesColumn.HeaderText = Languages.Libs.GetString("notes");
        }
        public override void Refresh()
        {
            this.ShowMessage("");
            LoadData();
            base.Refresh();
        }

        public delegate void onShowChart(string stockCode);
        public event onShowChart myOnShowChart = null;

        private data.tmpDS.stockCodeRow CurrentRow
        {
            get
            {
                if (portfolioListSource.Current == null) return null;
                string stockCode = ((data.tmpDS.stockCodeRow)((DataRowView)portfolioListSource.Current).Row).code.Trim();
                return (portfolioListSource.DataSource as data.tmpDS.stockCodeDataTable).FindBycode(stockCode);
            }
        }
        public void Export()
        {
            if (stockGV.DataSource == null)
            {
                common.system.ShowErrorMessage(Languages.Libs.GetString("noData"));
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel(myTmpDS.stockCode, saveFileDialog.FileName);
        }

        public virtual void LoadData()
        {
            myTmpDS.stockCode.Clear();
            LoadData(myTmpDS.stockCode, watchListCb.GetValues());
        }
        public virtual void Init()
        {
            watchListCb.LoadData(AppTypes.PortfolioTypes.Portfolio, commonClass.SysLibs.sysLoginCode, true);
            watchListCb.SelectFirstIfNull();
        }
        protected virtual void LoadData(data.tmpDS.stockCodeDataTable toTbl, string[] portfolioCodes)
        {
            LoadStockList(toTbl,portfolioCodes);
        }
        protected virtual void SetListColor()
        {
            decimal variant = 0;
            for (int idx = 0; idx < stockGV.RowCount; idx++)
            {
                variant = (decimal)stockGV.Rows[idx].Cells[priceVariantColumn.Name].Value;
                if (variant < 0)
                {
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Color.Red;
                    continue;
                }
                if (variant > 0)
                {
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Color.Green;
                    continue;
                }
                stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Color.Yellow;
            }
        }
        protected virtual void gridCellContentDoubleClick(object sender, DataGridViewCellEventArgs e) 
        { 
            if (stockGV.Columns[e.ColumnIndex].Name == stockCodeColumn.Name) ShowChart();
        }
        protected virtual void FormResize()
        {
            stockGV.Location = new Point(0, watchListCb.Location.Y + watchListCb.Height);
            stockGV.Size = new Size(this.ClientSize.Width - stockGV.Location.X, this.ClientSize.Height - stockGV.Location.Y);
            common.system.AutoFitGridColumn(stockGV);
        }
        protected void LoadStockList(data.tmpDS.stockCodeDataTable toTbl, string[] watchCodes)
        {
            //Load stocks in portfolio
            data.tmpDS.stockCodeDataTable myStockCodeTbl = null;
            switch (this.watchType)
            { 
                case AppTypes.PortfolioTypes.Portfolio:
                     myStockCodeTbl = DataAccess.Libs.GetStock_InPortfolio(common.system.List2Collection(watchCodes));
                     break;
                case AppTypes.PortfolioTypes.WatchList:
                     myStockCodeTbl = DataAccess.Libs.GetStock_ByWatchList(common.system.List2Collection(watchCodes));
                     break;
                default:
                     common.system.ThrowException("Invalid WatchType"); 
                     break;
            }

            DataView myStockView = new DataView(myStockCodeTbl);
            data.baseDS.stockCodeRow stockRow;
            myStockView.Sort = myStockCodeTbl.codeColumn.ColumnName + "," + myStockCodeTbl.stockExchangeColumn.ColumnName;
            data.tmpDS.stockCodeRow reportRow;
            for (int idx1 = 0; idx1 < myStockView.Count; idx1++)
            {
                stockRow = (data.baseDS.stockCodeRow)myStockView[idx1].Row;
                //Ignore duplicate stocks
                reportRow = toTbl.FindBycode(stockRow.code);
                if (reportRow != null) continue;
                reportRow = toTbl.NewstockCodeRow();
                commonClass.AppLibs.InitData(reportRow);
                reportRow.code = stockRow.code;
                reportRow.stockExchange = stockRow.stockExchange;
                toTbl.AddstockCodeRow(reportRow);
            }
        }
        private void ShowChart()
        {
            if (this.myOnShowChart==null) return;
            data.tmpDS.stockCodeRow stockRow = this.CurrentRow;  
            if (stockRow==null) return;
            myOnShowChart(stockRow.code);
        }

        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        private void stockGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                SetListColor();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void stockGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridCellContentDoubleClick(sender,e);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void watchListCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                if (watchListCb.myValue == watchListCb.lastValue) return;
                this.ShowCurrorWait();
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                this.ShowCurrorDefault();
            }
        }
        private void basePortfolioView_Resize(object sender, EventArgs e)
        {
            try
            {
                FormResize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion
    }
}