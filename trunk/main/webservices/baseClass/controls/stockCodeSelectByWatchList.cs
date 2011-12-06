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
using application;
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
        public stockCodeSelectByWatchList()
        {
            try
            {
                InitializeComponent();
                InitGrid();
                codeGroupCb.LoadData();
                codeGroupCb.SelectedItem = cbStockSelection.Options.All;
                RefreshAll();

                common.dialogs.SetFileDialogEXCEL(saveFileDialog);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }

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
            this.stockGV.DisableReadOnlyColumn = false;
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
            this.codeColumn.Width = 55;
            // 
            // priceColumn
            // 
            DataGridViewCellStyle priceCellType = new DataGridViewCellStyle();
            this.priceColumn.DataPropertyName = this.myStockTbl.priceColumn.ColumnName;
            priceCellType.Alignment = DataGridViewContentAlignment.MiddleRight;
            priceCellType.Format = "N" + commonClass.Settings.sysPrecisionPrice.ToString();
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
            priceVariantCellType.Format = "N" + commonClass.Settings.sysPrecisionPercentage.ToString();
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

        private data.tmpDS.stockCodeDataTable myStockTbl = DataAccess.Libs.myStockCodeTbl;

        public override void SetLanguage()
        {
            base.SetLanguage();
            codeGroupCb.SetLanguage();
            stockExchangeColumn.HeaderText = Languages.Libs.GetString("exchange");
            codeColumn.HeaderText = Languages.Libs.GetString("code");
            priceColumn.HeaderText = Languages.Libs.GetString("price");
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

        public void RefreshAll()
        {
            DataAccess.Libs.ClearCache();
            int lastPosition = stockSource.Position;
            LoadData();
            if (lastPosition >= 0) stockSource.Position = lastPosition;
            base.Refresh();
        }
        public void RefreshPrice()
        {
            RefreshPriceData(this.myStockTbl);
        }

        public void Export()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            common.Export.ExportToExcel((DataTable)stockGV.DataSource, saveFileDialog.FileName);
        }
        public data.tmpDS.stockCodeRow CurrentRow
        {
            get
            {
                if (stockSource.Current == null) return null;
                return (data.tmpDS.stockCodeRow)((DataRowView)stockSource.Current).Row;
            }
        }

        private  void LoadData()
        {
            stockSource.DataSource = this.myStockTbl;
            RefreshPrice();
        }

        
        private void DoFilter()
        {
            common.myKeyValueExt item = (common.myKeyValueExt)codeGroupCb.SelectedItem;
            cbStockSelection.Options watchListType = (cbStockSelection.Options)byte.Parse(item.Attribute1);
            StringCollection stocCodeList = new StringCollection();
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

                    string cacheKey = watchListType.ToString(); ;
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
                    StringCollection selectStockList = null;
                    object obj = DataAccess.Libs.GetCache(cacheKey);
                    if (obj != null) selectStockList = (obj as StringCollection);
                    else
                    {
                        selectStockList = common.system.List2Collection(DataAccess.Libs.GetStockList_ByWatchList(watchList));
                        DataAccess.Libs.AddCache(cacheKey, selectStockList);
                    }
                    myStockTbl.Columns[myStockTbl.selectedColumn.ColumnName].ReadOnly = false;
                    for (int idx = 0; idx <  this.myStockTbl.Count; idx++)
                    {
                        this.myStockTbl[idx].selected = (selectStockList.Contains(this.myStockTbl[idx].code)?1:0);
                    }
                    stockSource.Filter = this.myStockTbl.selectedColumn+"=1";
                    break;
            }
        }

        private static void RefreshPriceData(data.tmpDS.stockCodeDataTable dataTbl)
        {
            data.baseDS.priceDataDataTable priceTbl = DataAccess.Libs.GetLastPrice(AppTypes.MainDataTimeScale.Code);
            data.tmpDS.stockCodeRow stockCodeRow;
            dataTbl.priceColumn.ReadOnly = false;
            dataTbl.priceVariantColumn.ReadOnly = false;
            for (int idx = 0; idx < priceTbl.Count; idx++)
            {
                stockCodeRow = dataTbl.FindBycode(priceTbl[idx].stockCode);
                if (stockCodeRow == null) continue;
                stockCodeRow.price = priceTbl[idx].closePrice;
                stockCodeRow.priceVariant = priceTbl[idx].closePrice - priceTbl[idx].openPrice;
            }
        }

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
                DoFilter();
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
                RefreshAll();
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
                data.tmpDS.stockCodeRow stockRow = this.CurrentRow;
                if (stockRow == null) return;
                myOnShowChart(stockRow.code);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
        private void stockGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if(priceVariantColumn.Visible) SetListColor();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }
    }
}
