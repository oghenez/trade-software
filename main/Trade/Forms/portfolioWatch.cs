using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AdvancedDataGridView;
using application;
using commonClass;

namespace Trade.Forms
{
    public partial class portfolioWatch : baseClass.forms.basePortfolioWatch
    {
        private Color headerBG1 = Color.Aqua, headerFG1 = Color.Black;
        private Color headerBG2 = Color.Green, headerFG2 = Color.White;
        private Color headerBG3 = Color.Pink, headerFG3 = Color.Black;

        public portfolioWatch()
        {
            try
            {
                InitializeComponent();
                this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        // See Making Thread-Safe Calls by using BackgroundWorker
        // http://msdn.microsoft.com/en-us/library/ms171728.aspx
        private BackgroundWorker bgWorker = new BackgroundWorker();
        public void RefreshData()
        {
            this.bgWorker.RunWorkerAsync();
        }

        public override void Init()
        {
            this.fOnProccessing = true;
            try
            {
                this.watchType = AppTypes.PortfolioTypes.Portfolio;
                base.Init();

                headerBG1 = stockGV.ColumnHeadersDefaultCellStyle.BackColor;
                headerFG1 = stockGV.ColumnHeadersDefaultCellStyle.ForeColor;
                this.stockGV.ColumnHeadersHeight = SystemInformation.CaptionHeight * 2;
                this.stockGV.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGV1_Paint);
                this.stockGV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGV1_Scroll);
                this.stockGV.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGV1_ColumnWidthChanged);

                LoadData();
                this.fOnProccessing = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
                this.fOnProccessing = false;
            }
        }

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
        protected override void LoadData(data.tmpDS.stockCodeDataTable toTbl, string[] portfolioCodes)
        {
            DateTime startTime = DateTime.Now;
            LoadStockList(toTbl,portfolioCodes);
            UpdateRealTime(toTbl, portfolioCodes);
            this.ShowMessage(common.dateTimeLibs.TimeSpan2String(DateTime.Now.Subtract(startTime)));
        }
        protected override void gridCellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.gridCellContentDoubleClick(sender, e);
            if (stockGV.Columns[e.ColumnIndex].Name == gridColumnName.Notes.ToString())
            {
                ShowTradeAlert();
                return;
            }
        }

        protected void UpdateRealTime(data.tmpDS.stockCodeDataTable reportTbl, string[] portfolioCodes)
        {
            //DateTime onTime = DataAccess.Libs.GetServerDateTime();
            //data.baseDS.priceDataRow priceRow;
            //data.tmpDS.portfolioListRow reportRow;
            //decimal qty = 0, boughtAmt = 0;
            //byte allTimeScaleMask = 0;
            //foreach (AppTypes.TimeScale item in Enum.GetValues(typeof(AppTypes.TimeScale))) allTimeScaleMask += (byte)item;


            //progressBar.Visible = true;
            //progressBar.Maximum = reportTbl.Count; progressBar.Value = 0;
            //for (int idx1 = 0; idx1 < reportTbl.Count; idx1++)
            //{
            //    reportRow = reportTbl[idx1];
            //    reportRow.qty = 0; reportRow.boughtAmt = 0;
            //    for (int idx2 = 0; idx2 < portfolioCodes.Length; idx2++)
            //    {
            //        dataLibs.GetOwnStock(reportRow.stockCode, portfolioCodes[idx2], 0, onTime, out qty, out boughtAmt);
            //        reportRow.qty += qty; reportRow.boughtAmt += boughtAmt;
            //    }
            //    reportRow.boughtPrice = (reportRow.qty == 0 ? 0 : reportRow.boughtAmt / reportRow.qty) / application.Settings.sysStockPriceWeight;

            //    priceRow = application.dataLibs.GetLastPrice(onTime.Date, onTime, AppTypes.TimeScale.Daily, reportRow.stockCode);
            //    reportRow.price = (priceRow == null ? 0 : priceRow.closePrice);
            //    reportRow.priceVariant = (priceRow == null ? 0 : reportRow.price - priceRow.openPrice);
            //    reportRow.volume = (priceRow == null ? 0 : priceRow.volume);
            //    reportRow.amt = reportRow.qty * reportRow.price * application.Settings.sysStockPriceWeight;
            //    reportRow.profitVariantAmt = reportRow.amt - reportRow.boughtAmt;
            //    reportRow.profitVariantPerc = (reportRow.boughtAmt == 0 ? 0 : reportRow.profitVariantAmt / reportRow.boughtAmt) * 100;

            //    //Alert summary info
            //    reportRow.notes = AlertSummaryInfo(onTime, reportRow.stockCode, allTimeScaleMask, (byte)AppTypes.CommonStatus.New);
            //    progressBar.Value++;
            //}
            //progressBar.Visible = false;
        }
        //protected string AlertSummaryInfo(DateTime onTime,string stockCode,string timeScale,byte statusMask)
        //{
        //    data.baseDS.tradeAlertRow row = dataLibs.GetLastAlertByInvestor(onTime.Date, onTime,stockCode,system.sysLoginCode,timeScale, statusMask);
        //    if (row == null) return "";
        //    return ((AppTypes.TradeActions)row.tradeAction).ToString() + " / " + row.strategy;
        //}
        protected void ShowTradeAlert()
        {
            if (portfolioListSource.Current == null) return;
            string stockCode = ((data.tmpDS.stockCodeRow)((DataRowView)portfolioListSource.Current).Row).code.Trim();
            if (watchListCb.IsAllValueSelected())
            {
                myTradeAlertListForm.SetFilterPortfolioStat(true,false);
            }
            else
            {
                myTradeAlertListForm.myPortfolioCode = watchListCb.myValue;
                myTradeAlertListForm.SetFilterPortfolioStat(false, true);
            }
            myTradeAlertListForm.SetFilterStockStat(false, true);
            myTradeAlertListForm.myStockCode  =  stockCode;
            myTradeAlertListForm.LoadData();
            common.system.ShowForm(myTradeAlertListForm, false);
        }

        #region event handler
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void dataGV1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = stockGV.DisplayRectangle;
            rtHeader.Height = stockGV.ColumnHeadersHeight / 2;
            stockGV.Invalidate(rtHeader);
        }
        private void dataGV1_Paint(object sender, PaintEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center; format.LineAlignment = StringAlignment.Center;
            Font font = stockGV.ColumnHeadersDefaultCellStyle.Font;

            common.gridView.DrawGridCell("Mã", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 0, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("Sàn", format, font, headerFG1, headerBG1,e.Graphics, stockGV, 1, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("Số.lượng", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 2, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("+/-Giá", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 9, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("Tổng KL", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 10, -1, 1, 1, 0, 0);
            common.gridView.DrawGridCell("Quyết định", format, font, headerFG1, headerBG1, e.Graphics, stockGV, 11, -1, 1, 1, 0, 0);
            
            int startColIdx = 3;
            string[] header11 = new string[] { "Giá", "Giá trị", "Lãi lỗ" };
            string[] header12 = new string[] { "Mua", "Hiện.tại", "Mua", "Hiện.tại", "Giá trị", "%", };
            for (int idx1 = 0, idx2 = 0; idx2 < header12.Length; idx1++, idx2 += 2)
            {
                common.gridView.DrawGridCell(header11[idx1], format, font, headerFG2, headerBG2,
                             e.Graphics, stockGV, startColIdx + idx2, -1, 2, 0.5m, 0, 0);

                //Retangle r2,r3 under r1 and for each column. 
                common.gridView.DrawGridCell(header12[idx2], format, font, headerFG3, headerBG3,
                             e.Graphics, stockGV, startColIdx + idx2, -1, 1, 0.5m, 0, 0.5m);

                common.gridView.DrawGridCell(header12[idx2 + 1], format, font, headerFG3, headerBG3,
                                             e.Graphics, stockGV, startColIdx + idx2 + 1, -1, 1, 0.5m, 0, 0.5m);
            }
        }
        private void dataGV1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = stockGV.DisplayRectangle;
            rtHeader.Height = stockGV.ColumnHeadersHeight / 2;
            stockGV.Invalidate(rtHeader);
        }
        #endregion
    }
}