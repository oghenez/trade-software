using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading; 
using application;
using commonTypes;
using commonClass;

namespace baseClass.controls
{
    /// <summary>
    /// This control provides different ways to display stock code list 
    /// - All : all enable stocks
    /// - StockExchange : stockcodes from stock exchange
    /// - SysWatchList : stockcodes from system watch lists
    /// - WatchList : stockcodes from user's m watch lists
    /// 
    /// </summary>
    public partial class stockCodeSelectByWatchList : common.controls.baseUserControl
    {
        //BackgroundWorker backgroundWorker = new BackgroundWorker();
        public stockCodeSelectByWatchList()
        {
            try
            {
                InitializeComponent();
                //backgroundWorker.DoWork += backgroundWorker_DoRefreshData;
                //backgroundWorker.WorkerSupportsCancellation = true;
                InitGrid();
                if (!DesignMode)
                {
                    codeGroupCb.SelectedItem = cbStockSelection.Options.All;
                    common.dialogs.SetFileDialogEXCEL(saveFileDialog);
                }
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        private void backgroundWorker_DoRefreshData(object sender, DoWorkEventArgs e)
        {
            if (codeGroupCb.InvokeRequired)
            {
                codeGroupCb.Invoke((MethodInvoker)delegate()
                {
                    DoRefreshData((RefreshOptions)e.Argument);
                });
            }
            else
            {
                DoRefreshData((RefreshOptions)e.Argument);
            }
        }

        private bool fProcessing = false;
        private DataGridViewTextBoxColumn stockExchangeColumn = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn codeColumn = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn priceVariantColumn = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn stockNameColumn = new DataGridViewTextBoxColumn();
        private void InitGrid()
        {
            // 
            // stockGV
            // 
            this.stockGV.Columns.AddRange(new DataGridViewColumn[] {
            this.stockExchangeColumn,
            this.codeColumn,
            this.priceColumn,
            this.priceVariantColumn,
            this.stockNameColumn});
            this.stockGV.DataSource = this.stockSource;
            this.stockGV.ReadOnly = true;
            // 
            // stockExchangeColumn
            // 
            this.stockExchangeColumn.DataPropertyName = this.myStockTbl.stockExchangeColumn.ColumnName; 
            this.stockExchangeColumn.HeaderText = "Exchange";
            this.stockExchangeColumn.Name = gridColumnName.StockExCode.ToString();
            this.stockExchangeColumn.ReadOnly = true;
            this.stockExchangeColumn.Width = 65;
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = this.myStockTbl.codeColumn.ColumnName;
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = gridColumnName.StockCode.ToString();
            //this.codeColumn.ToolTipText = gridColumnName.StockName.ToString();
            this.codeColumn.Width = 55;
            // 
            // priceColumn
            // 
            DataGridViewCellStyle priceCellType = new DataGridViewCellStyle();
            this.priceColumn.DataPropertyName = this.myStockTbl.priceColumn.ColumnName;
            priceCellType.Alignment = DataGridViewContentAlignment.MiddleRight;
            priceCellType.Format = "N" + Settings.sysPrecisionPrice.ToString();
            priceCellType.NullValue = null;
            this.priceColumn.DefaultCellStyle = priceCellType;
            this.priceColumn.HeaderText = "Price";
            this.priceColumn.Name = gridColumnName.Price.ToString();
            this.priceColumn.Width = 65;
            // 
            // priceVariantColumn
            // 
            DataGridViewCellStyle priceVariantCellType = new DataGridViewCellStyle();
            this.priceVariantColumn.DataPropertyName = this.myStockTbl.priceVariantColumn.ColumnName;
            priceVariantCellType.Alignment = DataGridViewContentAlignment.MiddleRight;
            priceVariantCellType.Format = "N" + Settings.sysPrecisionPercentage.ToString();
            priceVariantCellType.NullValue = null;
            this.priceVariantColumn.DefaultCellStyle = priceVariantCellType;
            this.priceVariantColumn.HeaderText = "+/-";
            this.priceVariantColumn.Name = gridColumnName.PriceVariant.ToString();
            this.priceVariantColumn.ReadOnly = true;
            this.priceVariantColumn.Width = 50;
            // 
            // stockNameColumn
            // 
            this.stockNameColumn.DataPropertyName = this.myStockTbl.nameColumn.ColumnName;
            this.stockNameColumn.HeaderText = "Name";
            this.stockNameColumn.Name = gridColumnName.StockName.ToString();
            this.stockNameColumn.Visible = false;
        }
        
        private enum watchListTypes : byte { None, All, StockExchange, WatchList, SysWatchList,Others};

        private databases.tmpDS.stockCodeDataTable myStockTbl = DataAccess.Libs.myStockCodeTbl;

        public override void SetLanguage()
        {
            base.SetLanguage();
            codeGroupCb.SetLanguage();
            stockExchangeColumn.HeaderText = Languages.Libs.GetString("exchange");
            codeColumn.HeaderText = Languages.Libs.GetString("code");
            priceColumn.HeaderText = Languages.Libs.GetString("price");
        }

        public ContextMenuStrip myContextMenuStrip
        {
            get { return stockGV.ContextMenuStrip; }
            set { stockGV.ContextMenuStrip  = value; }
        }

        public enum gridColumnName
        {
            StockCode, StockExCode, StockName, Price, PriceVariant
        }
        public common.controls.baseDataGridView myGridView
        {
            get { return stockGV; }
        }
        public event Events.onShowChart myOnShowChart = null;

        public void SetColumnVisibility(gridColumnName colName,bool status)
        {
            stockGV.Columns[colName.ToString()].Visible = status;
        }

        public enum RefreshOptions : byte { CodeGroup = 1, PriceData = 4 , All = 255}
        // To prevent "cross-thread operation not valid" error
        // See http://helpprogramming.blogspot.com/2011/10/invalid-cross-thread-operation.html
        //public void RefreshData(RefreshOptions options)
        //{
        //    //if (backgroundWorker.IsBusy)
        //    {
        //        //backgroundWorker.CancelAsync();
        //        //return;
        //    }
        //    myRefreshOptions = options;
        //    backgroundWorker.RunWorkerAsync();
        //}
        public void RefreshData(bool force)
        {
            try
            {
                if (fProcessing) return;
                fProcessing = true;
                if (force)
                {
                    DoRefreshData(RefreshOptions.All);
                }
                else
                {
                    DoRefreshData(RefreshOptions.PriceData);
                    //if (backgroundWorker.IsBusy) 
                    //    backgroundWorker.CancelAsync();
                    //else
                    //{
                    //    backgroundWorker.RunWorkerAsync(RefreshOptions.PriceData);
                    //}
                }
                fProcessing = false;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
                fProcessing = false;
            }
        }
        private void DoRefreshData(RefreshOptions option)
        {
            int lastPosition = stockSource.Position;
            if (stockSource.DataSource == null)
                stockSource.DataSource = this.myStockTbl;
            if (((byte)option & (byte)RefreshOptions.CodeGroup) > 0)
            {
                int saveGroupIndex = codeGroupCb.SelectedIndex;
                codeGroupCb.LoadData();
                if (saveGroupIndex >= 0 && saveGroupIndex < codeGroupCb.Items.Count)
                    codeGroupCb.SelectedIndex = saveGroupIndex;
                DoFilter(true);
            }
            if (lastPosition >= 0) stockSource.Position = lastPosition;

            if (((byte)option & (byte)RefreshOptions.PriceData) > 0) DoRefreshPrice(this.myStockTbl);
        }
        
        public void Export()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel((DataTable)stockGV.DataSource, saveFileDialog.FileName);
        }
        public databases.tmpDS.stockCodeRow CurrentRow
        {
            get
            {
                if (stockSource.Current == null) return null;
                return (databases.tmpDS.stockCodeRow)((DataRowView)stockSource.Current).Row;
            }
        }
        
        private void DoFilter(bool notUseCache)
        {
            string cacheKey;
            common.myKeyValueExt item = (common.myKeyValueExt)common.Threading.GetValue(codeGroupCb,"SelectedItem");
            cbStockSelection.Options watchListType = (cbStockSelection.Options)byte.Parse(item.Attribute1);
            StringCollection stocCodeList = new StringCollection();
            myStockTbl.Columns[myStockTbl.selectedColumn.ColumnName].ReadOnly = false;
            switch (watchListType)
            {
                case cbStockSelection.Options.All:
                    stockSource.Filter = "";
                    break;
                case cbStockSelection.Options.StockExchange:
                    stockSource.Filter = this.myStockTbl.stockExchangeColumn.ColumnName +"='" + item.Value + "'";
                    break;
                case cbStockSelection.Options.SysWatchList:
                case cbStockSelection.Options.WatchList:

                    cacheKey = watchListType.ToString(); ;
                    StringCollection watchList = new StringCollection();
                    //All stock codes of  specified type ??
                    if (item.Value != "")
                    {
                        cacheKey += "-" + item.Value;
                        watchList.Add(item.Value);
                    }
                    else
                    {
                        for (int idx = 0; idx < codeGroupCb.Items.Count; idx++)
                        {
                            common.myKeyValueExt tmpItem = (common.myKeyValueExt)codeGroupCb.Items[idx];
                            if (watchListType != (cbStockSelection.Options)byte.Parse(tmpItem.Attribute1) || (tmpItem.Value == "")) continue;
                            watchList.Add(tmpItem.Value);
                        }
                    }
                    cacheKey = DataAccess.Libs.MakeCacheKey(this, cacheKey);
                    if (notUseCache)
                    {
                        DataAccess.Libs.ClearCache(cacheKey);
                    }
                    StringCollection selectStockList = null;
                    object obj = DataAccess.Libs.GetCache(cacheKey);
                    if (obj != null) selectStockList = (obj as StringCollection);
                    else
                    {
                        selectStockList = common.system.List2Collection(DataAccess.Libs.GetStockList_ByWatchList(watchList));
                        DataAccess.Libs.AddCache(cacheKey, selectStockList);
                    }
                    for (int idx = 0; idx <  this.myStockTbl.Count; idx++)
                    {
                        this.myStockTbl[idx].selected = (selectStockList.Contains(this.myStockTbl[idx].code)?1:0);
                    }
                    stockSource.Filter = this.myStockTbl.selectedColumn+"=1";
                    break;

                
                case cbStockSelection.Options.UserPorfolio:
                    cacheKey = watchListType.ToString(); ;
                    StringCollection porfolioList = new StringCollection();
                    //All stock codes of the specified type ??
                    if (item.Value != "")
                    {
                        cacheKey += "-" + item.Value;
                        porfolioList.Add(item.Value);
                    }
                    else
                    {
                        for (int idx = 0; idx < codeGroupCb.Items.Count; idx++)
                        {
                            common.myKeyValueExt tmpItem = (common.myKeyValueExt)codeGroupCb.Items[idx];
                            if (watchListType != (cbStockSelection.Options)byte.Parse(tmpItem.Attribute1) || (tmpItem.Value == "")) continue;
                            porfolioList.Add(tmpItem.Value);
                        }
                    }
                    cacheKey = DataAccess.Libs.MakeCacheKey(this, cacheKey);
                    if (notUseCache)
                    {
                        DataAccess.Libs.ClearCache(cacheKey);
                    }
                    databases.tmpDS.stockCodeDataTable codeTbl = null;
                    obj = DataAccess.Libs.GetCache(cacheKey);
                    if (obj != null) codeTbl = (obj as databases.tmpDS.stockCodeDataTable);
                    else
                    {
                        codeTbl =  DataAccess.Libs.GetStock_InPortfolio(porfolioList);
                        DataAccess.Libs.AddCache(cacheKey, codeTbl);
                    }
                    for (int idx = 0; idx < this.myStockTbl.Count; idx++)
                    {
                        this.myStockTbl[idx].selected = (codeTbl.FindBycode(this.myStockTbl[idx].code)!=null ? 1 : 0);
                    }
                    stockSource.Filter = this.myStockTbl.selectedColumn + "=1";
                    break;
            }
        }

        static databases.baseDS.lastPriceDataDataTable openPriceTbl = null;
        static DateTime openPriceDate = DateTime.Now.Date;
        private void DoRefreshPrice(databases.tmpDS.stockCodeDataTable dataTbl)
        {
            //Open price is the same all day.
            if (openPriceTbl == null || openPriceDate != DateTime.Today)
            {
                openPriceTbl = DataAccess.Libs.GetLastPrice(AppTypes.PriceDataType.Open);
                openPriceDate = DateTime.Today;
            }
            databases.baseDS.lastPriceDataDataTable closePriceTbl = DataAccess.Libs.GetLastPrice(AppTypes.PriceDataType.Close);
            if (openPriceTbl==null || closePriceTbl == null) return;

            dataTbl.priceColumn.ReadOnly = false;
            dataTbl.priceVariantColumn.ReadOnly = false;

            databases.tmpDS.stockCodeRow stockCodeRow;
            databases.baseDS.lastPriceDataRow openPriceRow, closePriceRow;
            for (int idx = 0; idx < stockGV.RowCount; idx++)
            {
                stockCodeRow = dataTbl.FindBycode(stockGV.Rows[idx].Cells[codeColumn.Name].Value.ToString());
                if (stockCodeRow == null) continue;
                closePriceRow = closePriceTbl.FindBystockCode(stockCodeRow.code);
                if (closePriceRow == null) continue;

                if (stockCodeRow.price == closePriceRow.value) continue;
                stockCodeRow.price = closePriceRow.value;
                openPriceRow = openPriceTbl.FindBystockCode(stockCodeRow.code);
                if (openPriceRow != null)
                    stockCodeRow.priceVariant = closePriceRow.value - openPriceRow.value;
                else stockCodeRow.priceVariant = 0;
                SetColor(idx);
            }
        }

        private void SetColor(int idx)
        {
            decimal variant = (decimal)stockGV.Rows[idx].Cells[priceVariantColumn.Name].Value;
            if (variant < 0)
            {
                stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_Decrease_BG;
                stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_Decrease_FG;
                return; 
            }
            if (variant > 0)
            {
                stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_Increase_BG;
                stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_Increase_FG;
                return;
            }
            stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.BackColor = Settings.sysPriceColor_NotChange_BG;
            stockGV.Rows[idx].Cells[priceVariantColumn.Name].Style.ForeColor = Settings.sysPriceColor_NotChange_FG;
        }
        private void SetColor()
        {
            for (int idx = 0; idx < stockGV.RowCount; idx++) SetColor(idx);
        }

        #region event handler
        private void form_Resize(object sender, EventArgs e)
        {
            try
            {
                common.system.AutoFitGridColumn(stockGV);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }         
        }
        private void codeGroupCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DoFilter(false);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }        
        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshData(true);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }        
        }
        private void stockGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.myOnShowChart == null) return;
                databases.tmpDS.stockCodeRow stockRow = this.CurrentRow;
                if (stockRow == null) return;
                myOnShowChart(stockRow.code);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        private void stockCodeSelectByWatchList_Load(object sender, EventArgs e)
        {
        }
        private void stockGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (!fProcessing) SetColor();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        private void stockGV_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= stockGV.Rows.Count) return;
                if (e.ColumnIndex < 0 || e.ColumnIndex >= stockGV.Columns .Count) return;
                if (stockGV.Columns[e.ColumnIndex] != codeColumn) return;
                databases.tmpDS.stockCodeRow row = (databases.tmpDS.stockCodeRow)((DataRowView)stockGV.Rows[e.RowIndex].DataBoundItem).Row;
                if (row == null) return;
                e.ToolTipText = (commonClass.SysLibs.IsUseVietnamese() ? row.name : row.nameEn);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        #endregion
    }
}
