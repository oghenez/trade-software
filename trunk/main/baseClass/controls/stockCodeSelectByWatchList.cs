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
    public partial class stockCodeSelectByWatchList : common.control.baseUserControl
    {
        public stockCodeSelectByWatchList()
        {
            try
            {
                InitializeComponent();
                stockExchangeColumn.Name = gridColumnName.StockExCode.ToString();
                codeColumn .Name = gridColumnName.StockCode.ToString();
                stockNameColumn.Name = gridColumnName.StockName.ToString();
                priceColumn.Name = gridColumnName.Price.ToString();
                priceVariantColumn.Name = gridColumnName.PriceVariant.ToString();
                priceColumn.DefaultCellStyle.Format = "N" + Settings.sysPrecisionPrice.ToString();
                priceVariantColumn.DefaultCellStyle.Format = "N" + Settings.sysPrecisionPercentage.ToString();

                myTmpDS.stockCode.priceColumn.ReadOnly = false;
                myTmpDS.stockCode.priceVariantColumn.ReadOnly = false;

                LoadWatchList();
                Refresh();
                common.dialogs.SetFileDialogEXCEL(saveFileDialog);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }            
        }
        private enum watchListTypes : byte { None, All, StockExchange, WatchList, SysWatchList,Others};
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
        public common.control.baseDataGridView myGridView
        {
            get { return stockGV; }
        }
        public event Events.onShowChart myOnShowChart = null;

        public void SetColumnVisibility(gridColumnName colName,bool status)
        {
            stockGV.Columns[colName.ToString()].Visible = status;
        }

        public override void Refresh()
        {
            LoadData();
            RefreshPriceData(myTmpDS.stockCode);
            base.Refresh();
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

        private void LoadWatchList()
        {
            watchListCb.Items.Clear();
            common.myKeyValueExt item = new common.myKeyValueExt(Settings.sysString_All_Description,Settings.sysString_All_Code);
            item.Attribute1 = ((byte)watchListTypes.All).ToString();
            watchListCb.Items.Add(item);        

            //stockExchange
            data.baseDS.stockExchangeDataTable stockExchangeTbl = new data.baseDS.stockExchangeDataTable();
            stockExchangeTbl.Clear();
            dataLibs.LoadData(stockExchangeTbl);
            for (int idx = 0; idx < stockExchangeTbl.Count; idx++)
            {
                item = new common.myKeyValueExt(stockExchangeTbl[idx].code,stockExchangeTbl[idx].code);
                item.Attribute1 = ((byte)watchListTypes.StockExchange).ToString();
                watchListCb.Items.Add(item);        
            }
            //Portfolio
            data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
            portfolioTbl.Clear();
            dataLibs.LoadPortfolioByInvestor(portfolioTbl,sysLibs.sysLoginCode,AppTypes.PortfolioTypes.SysWatchList);
            if (portfolioTbl.Count > 0)
            {
                item = new common.myKeyValueExt("--System--", "");
                item.Attribute1 = ((byte)watchListTypes.SysWatchList).ToString();
                watchListCb.Items.Add(item);
            }
            for (int idx = 0; idx < portfolioTbl.Count; idx++)
            {
                item = new common.myKeyValueExt(portfolioTbl[idx].name, portfolioTbl[idx].code);
                item.Attribute1 = ((byte)watchListTypes.SysWatchList).ToString();
                watchListCb.Items.Add(item);
            }
            portfolioTbl.Clear();
            dataLibs.LoadPortfolioByInvestor(portfolioTbl, sysLibs.sysLoginCode, AppTypes.PortfolioTypes.WatchList);
            if (portfolioTbl.Count > 0)
            {
                item = new common.myKeyValueExt("--Watch List--", "");
                item.Attribute1 = ((byte)watchListTypes.WatchList).ToString();
                watchListCb.Items.Add(item);
            }
            for (int idx = 0; idx < portfolioTbl.Count; idx++)
            {
                item = new common.myKeyValueExt(portfolioTbl[idx].name, portfolioTbl[idx].code);
                item.Attribute1 = ((byte)watchListTypes.WatchList).ToString();
                watchListCb.Items.Add(item);
            }
            if (watchListCb.Items.Count > 0)
            {
                watchListCb.MaxDropDownItems = watchListCb.Items.Count;
                watchListCb.SelectedIndex = 0;
            }
        }
        private void LoadData()
        {
            if (watchListCb.SelectedItem == null) return;
            common.myKeyValueExt item = (common.myKeyValueExt)watchListCb.SelectedItem;
            watchListTypes watchListType = (watchListTypes)byte.Parse(item.Attribute1);
            myTmpDS.stockCode.Clear();
            switch (watchListType)
            { 
                case watchListTypes.All:
                     dataLibs.LoadData(myTmpDS.stockCode, AppTypes.CommonStatus.Enable); 
                     break;
                case watchListTypes.StockExchange:
                     dataLibs.LoadStockCode_ByStockExchange(myTmpDS.stockCode, item.Value, AppTypes.CommonStatus.Enable);
                     break;
                case watchListTypes.SysWatchList:
                case watchListTypes.WatchList:
                     StringCollection watchList = new StringCollection();
                     //All stock codes of  specified type ??
                     if (item.Value != "")
                     {
                         watchList.Add(item.Value);
                     }
                     else
                     {
                         for (int idx = 0; idx < watchListCb.Items.Count; idx++)
                         {
                             common.myKeyValueExt tmpItem = (common.myKeyValueExt)watchListCb.Items[idx];
                             if (watchListType != (watchListTypes)byte.Parse(tmpItem.Attribute1) || (tmpItem.Value == "") ) continue;
                             watchList.Add(tmpItem.Value);
                         }
                     }
                     dataLibs.LoadStockCode_ByWatchList(myTmpDS.stockCode, watchList);
                     break;
            }
        }
        private static void RefreshPriceData(data.tmpDS.stockCodeDataTable dataTbl)
        {
            DateTime onTime = dataLibs.GetLastPriceDate(AppTypes.MainDataTimeScale.Code);
            data.baseDS.priceDataDataTable priceTbl = dataLibs.GetPrice(onTime,AppTypes.MainDataTimeScale.Code);
            data.tmpDS.stockCodeRow stockCodeRow;
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
        private void watchListCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Refresh();
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
                Refresh();
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
