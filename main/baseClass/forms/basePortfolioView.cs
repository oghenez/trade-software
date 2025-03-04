using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace baseClass.forms
{
    public partial class basePortfolioView : common.forms.baseForm
    {
        public enum gridColumnName 
        {
            StockCode, StockExCode, Qty, BoughtPrice, Price, BoughtAmt, CurrentAmt, 
            ProfitVariantAmt, ProfitVariantPerc, PriceVariant, Volume, Notes
        };
        public basePortfolioView()
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

                Init();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                this.fOnProccessing = false;
            }
        }

        public delegate void onShowChart(data.baseDS.stockCodeRow stockRow);
        public event onShowChart myOnShowChart = null;

        public virtual void LoadData()
        {
            myTmpDS.portfolioList.Clear();
            LoadData(myTmpDS.portfolioList, watchListCb.GetValues());
        }
        public virtual void Init()
        {
            watchListCb.LoadData(application.sysLibs.sysLoginCode, true);
            watchListCb.SelectFirstIfNull();
        }
        protected virtual void LoadData(data.tmpDS.portfolioListDataTable toTbl, string[] portfolioCodes)
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
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Color.SkyBlue;
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
        protected void LoadStockList(data.tmpDS.portfolioListDataTable toTbl, string[] watchCodes)
        {
            //Load stocks in portfolio
            data.baseDS.stockCodeDataTable myStockCodeTbl = new data.baseDS.stockCodeDataTable();
            switch (watchListCb.WatchType)
            { 
                case myTypes.portfolioType.Portfolio:
                    dataLibs.LoadStockCode_ByPortfolios(myStockCodeTbl, common.system.List2Collection(watchCodes));
                     break;
                case myTypes.portfolioType.WatchList:
                     dataLibs.LoadStockCode_ByWatchList(myStockCodeTbl, common.system.List2Collection(watchCodes));
                     break;
                default:
                     common.system.ThrowException("Imvalid WatchType"); 
                     break;
            }

            DataView myStockView = new DataView(myStockCodeTbl);
            data.baseDS.stockCodeRow stockRow;
            myStockView.Sort = myStockCodeTbl.codeColumn.ColumnName + "," + myStockCodeTbl.stockExchangeColumn.ColumnName;
            data.tmpDS.portfolioListRow reportRow;
            for (int idx1 = 0; idx1 < myStockView.Count; idx1++)
            {
                stockRow = (data.baseDS.stockCodeRow)myStockView[idx1].Row;
                //Ignore duplicate stocks
                reportRow = toTbl.FindBystockCode(stockRow.code);
                if (reportRow != null) continue;
                reportRow = toTbl.NewportfolioListRow();
                dataLibs.InitData(reportRow);
                reportRow.stockCode = stockRow.code;
                reportRow.stockExCode = stockRow.stockExchange;
                toTbl.AddportfolioListRow(reportRow);
            }
        }
        private void ShowChart()
        {
            if (this.myOnShowChart==null || portfolioListSource.Current == null) return;
            string stockCode = ((data.tmpDS.portfolioListRow)((DataRowView)portfolioListSource.Current).Row).stockCode.Trim();
            data.baseDS.stockCodeRow stockRow = dataLibs.FindAndCache(myDataSet.stockCode,stockCode);  
            if (stockRow==null) return;
            myOnShowChart(stockRow);
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