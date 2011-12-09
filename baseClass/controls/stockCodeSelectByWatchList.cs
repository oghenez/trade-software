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
    public partial class stockCodeSelectByWatchList : common.controls.baseUserControl
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
                priceColumn.DefaultCellStyle.Format = "N" + application.Settings.sysPrecisionPrice.ToString();
                priceVariantColumn.DefaultCellStyle.Format = "N" + application.Settings.sysPrecisionPercentage.ToString();

                myTmpDS.stockCode.priceColumn.ReadOnly = false;
                myTmpDS.stockCode.priceVariantColumn.ReadOnly = false;

                codeGroupCb.LoadData();
                codeGroupCb.SelectedItem = cbStockSelection.Options.All;
                LoadData();

                common.dialogs.SetFileDialogEXCEL(saveFileDialog);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }            
        }
        private enum watchListTypes : byte { None, All, StockExchange, WatchList, SysWatchList,Others};

        public override void SetLanguage()
        {
            base.SetLanguage();
            codeGroupCb.SetLanguage();
            stockExchangeColumn.HeaderText = language.GetString("exchange");
            codeColumn.HeaderText = language.GetString("code");
            priceColumn.HeaderText = language.GetString("price");
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
            int lastPosition = stockSource.Position;
            LoadData();
            if (lastPosition >= 0) stockSource.Position = lastPosition;
            base.Refresh();
        }
        public void RefreshPrice()
        {
            RefreshPriceData(myTmpDS.stockCode);
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
            myTmpDS.stockCode.Clear();
            common.myKeyValueExt item = (common.myKeyValueExt)codeGroupCb.SelectedItem;
            cbStockSelection.Options watchListType = (cbStockSelection.Options)byte.Parse(item.Attribute1);
            StringCollection stocCodeList = new StringCollection();
            switch (watchListType)
            {
                case cbStockSelection.Options.All:
                    dataLibs.LoadData(myTmpDS.stockCode, AppTypes.CommonStatus.Enable); 
                    break;
                case cbStockSelection.Options.StockExchange:
                    dataLibs.LoadStockCode_ByStockExchange(myTmpDS.stockCode, item.Value, AppTypes.CommonStatus.Enable);
                    break;
                case cbStockSelection.Options.SysWatchList:
                case cbStockSelection.Options.WatchList:
                    StringCollection watchList = new StringCollection();
                    //All stock codes of  specified type ??
                    if (item.Value != "")
                    {
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
                    dataLibs.LoadStockCode_ByWatchList(myTmpDS.stockCode, watchList);
                    break;
            }
            RefreshPrice();
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
        private void codeGroupCb_SelectionChangeCommitted(object sender, EventArgs e)
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
