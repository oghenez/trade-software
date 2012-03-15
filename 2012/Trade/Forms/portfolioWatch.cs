using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;
using commonTypes;
using commonClass;

namespace Trade.Forms
{
    public partial class  portfolioWatch : baseClass.forms.baseForm
    {
        private Color headerBG1 = Color.Aqua, headerFG1 = Color.Black;
        private Color headerBG2 = Color.Green, headerFG2 = Color.White;
        private Color headerBG3 = Color.Pink, headerFG3 = Color.Black;

        public enum gridColumnName 
        {
            Code, MarketCode, Qty,Name, BoughtPrice, Price, BoughtAmt, CurrentAmt, 
            ProfitVariantAmt, ProfitVariantPerc, PriceVariant, Volume, Notes
        }
        public portfolioWatch()
        {
            try
            {
                this.fOnProccessing = true;
                InitializeComponent();
                this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);

                SetDetailGrid();

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
        protected void SetDetailGrid()
        {
            byte amtPrecision = common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskLocalAmt);
            byte pricePrecision = common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskPrice);
            byte percPrecision = common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskPercent);
            byte qtyPrecision = common.system.GetPrecisionFromMask(commonTypes.Settings.sysMaskQty);

            codeColumn.HeaderText = "";
            codeColumn.Name = gridColumnName.Code.ToString();

            marketColumn.Name = gridColumnName.MarketCode.ToString();

            nameColumn.Name = gridColumnName.Name.ToString();

            qtyColumn.Name = gridColumnName.Qty.ToString();
            qtyColumn.DefaultCellStyle.Format = "N" + qtyPrecision; 

            boughtPriceColumn.Name = gridColumnName.BoughtPrice.ToString();
            boughtPriceColumn.DefaultCellStyle.Format = "N" + pricePrecision; 

            priceColumn.Name = gridColumnName.Price.ToString();
            priceColumn.DefaultCellStyle.Format = "N" + pricePrecision; 

            boughtAmtColumn.Name = gridColumnName.BoughtAmt.ToString();
            boughtAmtColumn.DefaultCellStyle.Format = "N" + amtPrecision; 

            amtColumn.Name = gridColumnName.CurrentAmt.ToString();
            amtColumn.DefaultCellStyle.Format = "N" + amtPrecision; 

            profitVariantAmtColumn.Name = gridColumnName.ProfitVariantAmt.ToString();
            profitVariantAmtColumn.DefaultCellStyle.Format = "N" + amtPrecision; 

            profitVariantPercColumn.Name = gridColumnName.ProfitVariantPerc.ToString();
            profitVariantPercColumn.DefaultCellStyle.Format = "N" + percPrecision; 

            priceVariantColumn.Name = gridColumnName.PriceVariant.ToString();
            priceVariantColumn.DefaultCellStyle.Format = "N" + amtPrecision; 

            //notesColumn.Name = gridColumnName.Notes.ToString();
            //notesColumn.DefaultCellStyle.ForeColor = common.Settings.sysColorHiLightFG1;

            transVolumeColumn.Name = gridColumnName.Volume.ToString();
            transVolumeColumn.DefaultCellStyle.Format = "N" + qtyPrecision; 
        }

        // See Making Thread-Safe Calls by using BackgroundWorker
        // http://msdn.microsoft.com/en-us/library/ms171728.aspx
        private BackgroundWorker bgWorker = new BackgroundWorker();

        private Forms.tradeAlertList _myTradeAlertListForm = null;
        private Forms.tradeAlertList myTradeAlertListForm
        {
            get
            {
                if (_myTradeAlertListForm == null || _myTradeAlertListForm.IsDisposed)
                    _myTradeAlertListForm = GetTradeAlertListForm();
                return _myTradeAlertListForm;
            }
        }
        protected virtual Forms.tradeAlertList GetTradeAlertListForm()
        {
            Forms.tradeAlertList myForm = new Forms.tradeAlertList();
            myForm.SetColumnVisible(tradeAlertList.gridColumnName.StockCode.ToString(), false);
            return myForm;
        }

        public void RefreshData()
        {
            this.bgWorker.RunWorkerAsync();
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            portfolioListCb.SetLanguage();
            Refresh();
        }
        public override void Refresh()
        {
            this.ShowMessage("");
            LoadData();
            base.Refresh();
        }

        public delegate void onShowChart(string stockCode);
        public event onShowChart myOnShowChart = null;

        private databases.tmpDS.stockCodeRow CurrentRow
        {
            get
            {
                if (portfolioWatchSource.Current == null) return null;
                string stockCode = ((databases.tmpDS.stockCodeRow)((DataRowView)portfolioWatchSource.Current).Row).code.Trim();
                return (portfolioWatchSource.DataSource as databases.tmpDS.stockCodeDataTable).FindBycode(stockCode);
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
            myTmpDS.porfolioWatch.Clear();
            LoadPorfolioWatch(myTmpDS.porfolioWatch, commonClass.SysLibs.sysLoginCode);
        }
        public virtual void Init()
        {
            this.fOnProccessing = true;
            try
            {
                portfolioListCb.LoadData(AppTypes.PortfolioTypes.Portfolio, commonClass.SysLibs.sysLoginCode, true);
                portfolioListCb.SelectFirstIfNull();

                headerBG1 = stockGV.ColumnHeadersDefaultCellStyle.BackColor;
                headerFG1 = stockGV.ColumnHeadersDefaultCellStyle.ForeColor;
                this.stockGV.ColumnHeadersHeight = SystemInformation.CaptionHeight * 2;
                this.stockGV.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGV1_Paint);
                this.stockGV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGV1_Scroll);
                this.stockGV.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGV1_ColumnWidthChanged);
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
                this.fOnProccessing = false;
            }
        }
        protected virtual void SetListColor()
        {
            decimal variant = 0;
            for (int idx = 0; idx < stockGV.RowCount; idx++)
            {
                variant = (decimal)stockGV.Rows[idx].Cells[priceVariantColumn.Name].Value;
                if (variant < 0)
                {
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_Decrease_BG;
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_Decrease_FG;
                    continue;
                }
                if (variant > 0)
                {
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_Increase_BG;
                    stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_Increase_FG;
                    continue;
                }
                stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_NotChange_BG;
                stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_NotChange_FG;
            }
        }
        protected virtual void gridCellContentDoubleClick(object sender, DataGridViewCellEventArgs e) 
        { 
            if (stockGV.Columns[e.ColumnIndex] == codeColumn) ShowChart();
        }
        protected virtual void FormResize()
        {
            stockGV.Location = new Point(0, portfolioListCb.Location.Y + portfolioListCb.Height);
            stockGV.Size = new Size(this.ClientSize.Width - stockGV.Location.X, this.ClientSize.Height - stockGV.Location.Y);
            common.system.AutoFitGridColumn(stockGV,nameColumn.Name);
        }
        protected void LoadPorfolioWatch(databases.tmpDS.porfolioWatchDataTable tbl,string investorCode)
        {
            databases.tmpDS.investorStockDataTable investorStockTbl = DataAccess.Libs.GetOwnedStockSum_ByInvestor(investorCode);
            databases.tmpDS.porfolioWatchRow porfolioWatchRow;
            for (int idx1 = 0; idx1 < investorStockTbl.Count; idx1++)
            {
                porfolioWatchRow = myTmpDS.porfolioWatch.FindBycode(investorStockTbl[idx1].stockCode);
                if (porfolioWatchRow == null)
                {
                    databases.tmpDS.stockCodeRow stockCodeRow = DataAccess.Libs.myStockCodeTbl.FindBycode(investorStockTbl[idx1].stockCode);
                    if (stockCodeRow == null) continue;

                    porfolioWatchRow = tbl.NewporfolioWatchRow();
                    databases.AppLibs.InitData(porfolioWatchRow);
                    porfolioWatchRow.code = investorStockTbl[idx1].stockCode;
                    porfolioWatchRow.stockExchange = stockCodeRow.stockExchange;
                    porfolioWatchRow.name = stockCodeRow.name;
                    porfolioWatchRow.nameEn = stockCodeRow.nameEn;
                    tbl.AddporfolioWatchRow(porfolioWatchRow);
                }
                porfolioWatchRow.qty += investorStockTbl[idx1].qty;
                porfolioWatchRow.boughtAmt += investorStockTbl[idx1].buyAmt;
            }
            UpdatePrice(tbl);
            SetListColor();
        }

        
        protected void UpdatePrice(databases.tmpDS.porfolioWatchDataTable reportTbl)
        {
            databases.baseDS.lastPriceDataDataTable lastOpenPriceTbl = DataAccess.Libs.myLastDataOpenPrice;
            databases.baseDS.lastPriceDataDataTable lastClosePriceTbl = DataAccess.Libs.myLastDataClosePrice;
            databases.baseDS.lastPriceDataDataTable lastVolumeTbl = DataAccess.Libs.myLastDataVolume;

            databases.tmpDS.porfolioWatchRow reportRow;
            databases.baseDS.lastPriceDataRow priceRow;
            databases.baseDS.stockExchangeRow stockExchangeRow;
            for (int idx1 = 0; idx1 < reportTbl.Count; idx1++)
            {
                reportRow = reportTbl[idx1];
                
                stockExchangeRow = DataAccess.Libs.myStockExchangeTbl.FindBycode(reportRow.stockExchange);
                if (stockExchangeRow == null || stockExchangeRow.priceRatio == 0) continue;

                decimal priceWeight = stockExchangeRow.priceRatio;
                decimal volumeWeight = stockExchangeRow.volumeRatio;
                reportRow.boughtPrice = (reportRow.qty == 0 ? 0 : reportRow.boughtAmt / reportRow.qty) / priceWeight;

                priceRow = lastClosePriceTbl.FindBystockCode(reportRow.code);
                if (priceRow != null)
                {
                    reportRow.price = priceRow.value;
                    priceRow = lastOpenPriceTbl.FindBystockCode(reportRow.code);
                    if (priceRow != null) reportRow.priceVariant = reportRow.price - priceRow.value;
                    else reportRow.priceVariant = 0;
                }
                priceRow = lastVolumeTbl.FindBystockCode(reportRow.code);
                if (priceRow != null) reportRow.transVolume = priceRow.value * volumeWeight;


                reportRow.amt = reportRow.qty * reportRow.price * priceWeight;
                reportRow.profitVariantAmt = reportRow.amt - reportRow.boughtAmt;
                reportRow.profitVariantPerc = (reportRow.boughtAmt == 0 ? 0 : reportRow.profitVariantAmt / reportRow.boughtAmt) * 100;
            }
        }
        private void ShowChart()
        {
            if (this.myOnShowChart == null) return;
            databases.tmpDS.stockCodeRow stockRow = this.CurrentRow;
            if (stockRow == null) return;
            myOnShowChart(stockRow.code);
        }

        //protected string AlertSummaryInfo(DateTime onTime,string stockCode,string timeScale,byte statusMask)
        //{
        //    databases.baseDS.tradeAlertRow row = dataLibs.GetLastAlertByInvestor(onTime.Date, onTime,stockCode,system.sysLoginCode,timeScale, statusMask);
        //    if (row == null) return "";
        //    return ((AppTypes.TradeActions)row.tradeAction).ToString() + " / " + row.strategy;
        //}


        protected void ShowTradeAlert()
        {
            if (portfolioWatchSource.Current == null) return;
            string stockCode = ((databases.tmpDS.stockCodeRow)((DataRowView)portfolioWatchSource.Current).Row).code.Trim();
            if (portfolioListCb.IsAllValueSelected())
            {
                myTradeAlertListForm.SetFilterPortfolioStat(true, false);
            }
            else
            {
                myTradeAlertListForm.myPortfolioCode = portfolioListCb.myValue;
                myTradeAlertListForm.SetFilterPortfolioStat(false, true);
            }
            myTradeAlertListForm.SetFilterStockStat(false, true);
            myTradeAlertListForm.myStockCode = stockCode;
            myTradeAlertListForm.LoadData();
            common.system.ShowForm(myTradeAlertListForm, false);
        }

        #region event handler
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void dataGV1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                Rectangle rtHeader = stockGV.DisplayRectangle;
                rtHeader.Height = stockGV.ColumnHeadersHeight / 2;
                stockGV.Invalidate(rtHeader);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void dataGV1_Paint(object sender, PaintEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center; format.LineAlignment = StringAlignment.Center;
            Font font = stockGV.ColumnHeadersDefaultCellStyle.Font;

            common.gridView.DrawGridCell(Languages.Libs.GetString("code"), format, font, headerFG1, headerBG1, e.Graphics, stockGV, 0, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell(Languages.Libs.GetString("exchange"), format, font, headerFG1, headerBG1, e.Graphics, stockGV, 1, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell(Languages.Libs.GetString("name"), format, font, headerFG1, headerBG1, e.Graphics, stockGV, 2, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell(Languages.Libs.GetString("qty"), format, font, headerFG1, headerBG1, e.Graphics, stockGV, 3, -1, 1, 1, 0, 0);

            common.gridView.DrawGridCell(Languages.Libs.GetString("price") + common.Consts.constCRLF +"(+/-)", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 10, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell(Languages.Libs.GetString("transVolume"), format, font, headerFG1, headerBG1, e.Graphics, stockGV, 11, -1, 1, 1, 0, 0);

            int startColIdx = 4;
            string[] header11 = new string[] { Languages.Libs.GetString("price"), Languages.Libs.GetString("value"), Languages.Libs.GetString("revennue") };
            string[] header12 = new string[] { Languages.Libs.GetString("buy"), Languages.Libs.GetString("current"), 
                                               Languages.Libs.GetString("sell"), Languages.Libs.GetString("current"), 
                                               Languages.Libs.GetString("value"), "%", };
            for (int idx1 = 0, idx2 = 0; idx2 < header12.Length; idx1++, idx2 += 2)
            {
                common.gridView.DrawGridCell(header11[idx1], format, font, headerFG2, headerBG2,
                             e.Graphics, stockGV, startColIdx + idx2, -1, 2, 0.55m, 0, 0);

                //Rectangle r2,r3 under r1 and for each column. 
                common.gridView.DrawGridCell(header12[idx2], format, font, headerFG3, headerBG3,
                             e.Graphics, stockGV, startColIdx + idx2, -1, 1, 0.5m, 0, 0.5m);

                common.gridView.DrawGridCell(header12[idx2 + 1], format, font, headerFG3, headerBG3,
                                             e.Graphics, stockGV, startColIdx + idx2 + 1, -1, 1, 0.5m, 0, 0.5m);
            }
        }

        private void dataGV1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                Rectangle rtHeader = stockGV.DisplayRectangle;
                rtHeader.Height = stockGV.ColumnHeadersHeight / 2;
                stockGV.Invalidate(rtHeader);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        private void stockGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                //SetListColor();
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
                if (stockGV.Columns[e.ColumnIndex].Name == gridColumnName.Notes.ToString())
                {
                    ShowTradeAlert();
                    return;
                }
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
                if (portfolioListCb.myValue == portfolioListCb.lastValue) return;
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