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

namespace stockTrade.forms
{
    public partial class _baseTradeAlertList : common.forms.baseForm
    {
        public _baseTradeAlertList()
        {
            try
            {
                InitializeComponent();
                // load image strip
                this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
                this.imageStrip.TransparentColor = System.Drawing.Color.Transparent;
                this.imageStrip.ImageSize = new Size(16, 16);
                this.imageStrip.Images.AddStrip(Properties.Resources.alert_images);
                tradeAlertList.ImageList = imageStrip;
                ResizeForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private baseTradeAlertEdit _myTradeAlertEditForm = null;
        private baseTradeAlertEdit myTradeAlertEditForm
        {
            get
            {
                if (_myTradeAlertEditForm == null || _myTradeAlertEditForm.IsDisposed)
                    _myTradeAlertEditForm = GetTradeAlertEditForm();
                return _myTradeAlertEditForm;
            }
        }
        protected virtual baseTradeAlertEdit GetTradeAlertEditForm()
        {
            return new baseTradeAlertEdit();
        }

        private baseAlertFilter _myAlertFilterForm = null;
        private baseAlertFilter myAlertFilterForm
        {
            get
            {
                if (_myAlertFilterForm == null || _myAlertFilterForm.IsDisposed)
                {
                    _myAlertFilterForm = GetAlertFilterForm();
                    _myAlertFilterForm.myOnAccept += new common.forms.baseDialogForm.onProcess(DoAlertFilter);
                }
                return _myAlertFilterForm;
            }
        }
        protected virtual baseAlertFilter GetAlertFilterForm()
        {
            return new baseAlertFilter();
        }


        private baseTradeOrderNewFromAlert _myNewTradeOrderForm = null;
        private baseTradeOrderNewFromAlert myNewTradeOrderForm
        {
            get
            {
                if (_myNewTradeOrderForm == null || _myNewTradeOrderForm.IsDisposed)
                    _myNewTradeOrderForm = GetNewTradeOrderForm();
                return _myNewTradeOrderForm;
            }
        }
        protected virtual baseTradeOrderNewFromAlert GetNewTradeOrderForm()
        {
            return new baseTradeOrderNewFromAlert();
        }


        public void LoadData()
        {
            myDataSet.tradeAlert.Clear();
            application.dataLibs.LoadFromSQL(myDataSet.tradeAlert, myAlertFilterForm.GetSQL());
        }
        public void LoadData(application.myTypes.commonStatus status)
        {
            myDataSet.tradeAlert.Clear();
            //application.dataLibs.LoadData(myDataSet.tradeAlert, application.sysLibs.sysLoginCode, (byte)status);
        }
       
        private void DoAlertFilter(object sender)
        {
            try
            {
                LoadData();
                RefreshGrid();
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
       
        protected void ShowReccount()
        {
            base.ShowReccount("["+myDataSet.tradeAlert.Count.ToString("###,###,###,##0")+"]"); 
        }
        public int myReccount
        {
            get { return myDataSet.tradeAlert.Count; }
        }
        protected virtual void ResizeForm()
        {
            toolBarPnl.Width = this.Width + 3;
        }

        private void EditTradeAlert()
        {
            if (tradeAlertList.CurrentRow==null || 
                tradeAlertList.CurrentRow.Cells[idColumn.Name].Value == null) return;
            int rowId = (int)tradeAlertList.CurrentRow.Cells[idColumn.Name].Value;
            myTradeAlertEditForm.ShowForm(tradeAlertSource, rowId);
        }
        private void PlaceOrder()
        {
            if (tradeAlertList.CurrentRow == null ||
                tradeAlertList.CurrentRow.Cells[idColumn.Name].Value == null) return;
            int rowId = (int)tradeAlertList.CurrentRow.Cells[idColumn.Name].Value;
            data.baseDS.tradeAlertRow alertRow = myDataSet.tradeAlert.FindByid(rowId);
            if (alertRow == null) return;
            this.myNewTradeOrderForm.ShowForm(alertRow);
        }

        #region DataGridTreeView
        public enum alertViewModes : byte { PortfolioStockStrategy = 0, PortfolioStrategyStock = 1, StockStrategy = 2, StrategyStock = 3, StockOnly = 4 };

        private byte AlertStatImageIdx(byte stat)
        {
            return AlertStatImageIdx((myTypes.commonStatus)stat);
        }
        private byte AlertStatImageIdx(myTypes.commonStatus stat)
        {
            switch (stat)
            {
                case myTypes.commonStatus.New: return 1;
                case myTypes.commonStatus.Ignore: return 2;
                case myTypes.commonStatus.Close : return 4;
            }
            return 3;
        }
        private static TreeGridNode AddNode(TreeGridNodeCollection parentNodes, data.baseDS.tradeAlertRow row, Font fon, int imgIdx)
        {
            string msg = row.msg.Replace(common.Consts.constCRLF, "  ");
            TreeGridNode node = parentNodes.Add(msg, row.subject, row.onTime, row.id);
            if (fon != null) node.DefaultCellStyle.Font = fon;
            if (imgIdx >= 0) node.ImageIndex = imgIdx;
            return node;
        }
        private static TreeGridNode AddNode(TreeGridNodeCollection parentNodes,
                                            data.baseDS.tradeAlertRow row, data.baseDS.portfolioDataTable portfolioTbl,
                                            Font fon, int imgIdx)
        {
            TreeGridNode node;
            data.baseDS.portfolioRow portfolioRow = dataLibs.FindAndCache(portfolioTbl, row.portfolio);
            node = parentNodes.Add(portfolioRow.description,null,null,null);
            if (fon != null) node.DefaultCellStyle.Font = fon;
            if (imgIdx >= 0) node.ImageIndex = imgIdx;
            return node;
        }
        private static TreeGridNode AddNode(TreeGridNodeCollection parentNodes,
                                            data.baseDS.tradeAlertRow row, data.baseDS.strategyDataTable strategyTbl,
                                            Font fon, int imgIdx)
        {
            TreeGridNode node;
            data.baseDS.strategyRow strategyRow = dataLibs.FindAndCache(strategyTbl, row.strategy);
            node = parentNodes.Add(strategyRow.code.Trim() + " -  " + strategyRow.description + " (" + myTypes.Type2Text((myTypes.timeScales)row.timeScale) + ")", null, null, null);
            if (fon != null) node.DefaultCellStyle.Font = fon;
            if (imgIdx >= 0) node.ImageIndex = imgIdx;
            return node;
        }
        private static TreeGridNode AddNode(TreeGridNodeCollection parentNodes,
                                            data.baseDS.tradeAlertRow row, data.baseDS.stockCodeExtDataTable stockTbl,
                                            Font fon, int imgIdx)
        {
            TreeGridNode node;
            data.baseDS.stockCodeExtRow stockRow = dataLibs.FindAndCache(stockTbl, row.stockCode);
            node = parentNodes.Add(stockRow.code.Trim() + " - " + stockRow.name, null, null, null);
            node.DefaultCellStyle.Font = fon; node.ImageIndex = imgIdx;
            return node;
        }
        private void CreateDataGridTreeView_PortfolioStockStrategy(data.baseDS.tradeAlertDataTable tradeAlertTbl, TreeGridView treeGV)
        {
            DataView tradeAlertView = new DataView(tradeAlertTbl);
            tradeAlertView.Sort = tradeAlertTbl.portfolioColumn.ColumnName + "," +
                                    tradeAlertTbl.stockCodeColumn.ColumnName + "," +
                                    tradeAlertTbl.strategyColumn.ColumnName + "," +
                                    tradeAlertTbl.timeScaleColumn.ColumnName + "," +
                                    tradeAlertTbl.onTimeColumn.ColumnName + " DESC";

            TreeGridNodeCollection portfolioNodes = null;
            TreeGridNodeCollection stockNodes = null;
            TreeGridNodeCollection strategyNodes = null;

            data.baseDS.tradeAlertRow alertRow;

            Font boldFont = new Font(treeGV.DefaultCellStyle.Font, FontStyle.Bold);
            string lastPortfolio = "", lastStock = "", lastStrategy = "";
            for (int idx = 0; idx < tradeAlertView.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)tradeAlertView[idx].Row;
                if (lastPortfolio != alertRow.portfolio)
                {
                    portfolioNodes = AddNode(treeGV.Nodes, alertRow, myDataSet.portfolio, boldFont, 0).Nodes;
                    lastPortfolio = alertRow.portfolio;
                    lastStock = ""; lastStrategy = "";
                }
                if (lastStock != alertRow.stockCode)
                {
                    stockNodes = AddNode((portfolioNodes == null ? treeGV.Nodes : portfolioNodes), alertRow, myDataSet.stockCodeExt, boldFont, 0).Nodes;
                    lastStock = alertRow.stockCode;
                    lastStrategy = "";
                }
                if (lastStrategy != alertRow.strategy + alertRow.timeScale.ToString())
                {
                    strategyNodes = AddNode((stockNodes == null ? treeGV.Nodes : stockNodes), alertRow, myDataSet.strategy, boldFont, 0).Nodes;
                    lastStrategy = alertRow.strategy + alertRow.timeScale.ToString();
                }
                AddNode((strategyNodes == null ? treeGV.Nodes : strategyNodes), alertRow, null, AlertStatImageIdx(alertRow.status));
            }
        }
        private void CreateDataGridTreeView_PortfolioStrategyStock(data.baseDS.tradeAlertDataTable tradeAlertTbl, TreeGridView treeGV)
        {
            DataView tradeAlertView = new DataView(tradeAlertTbl);
            tradeAlertView.Sort = tradeAlertTbl.portfolioColumn.ColumnName + "," +
                                  tradeAlertTbl.strategyColumn.ColumnName + "," +
                                  tradeAlertTbl.timeScaleColumn.ColumnName + "," +
                                  tradeAlertTbl.stockCodeColumn.ColumnName + "," +
                                  tradeAlertTbl.onTimeColumn.ColumnName + " DESC";

            TreeGridNodeCollection portfolioNodes = null;
            TreeGridNodeCollection stockNodes = null;
            TreeGridNodeCollection strategyNodes = null;
            data.baseDS.tradeAlertRow alertRow;

            Font boldFont = new Font(treeGV.DefaultCellStyle.Font, FontStyle.Bold);
            string lastPortfolio = "", lastStock = "", lastStrategy = "";
            for (int idx = 0; idx < tradeAlertView.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)tradeAlertView[idx].Row;
                if (lastPortfolio != alertRow.portfolio)
                {
                    portfolioNodes = AddNode(treeGV.Nodes, alertRow, myDataSet.portfolio, boldFont, 0).Nodes;
                    lastPortfolio = alertRow.portfolio;
                    lastStrategy = ""; lastStock = "";
                }
                if (lastStrategy != alertRow.strategy + alertRow.timeScale.ToString())
                {
                    strategyNodes = AddNode((portfolioNodes == null ? treeGV.Nodes : portfolioNodes), alertRow, myDataSet.strategy, boldFont, 0).Nodes;
                    lastStrategy = alertRow.strategy + alertRow.timeScale.ToString();
                    lastStock = "";
                }

                if (lastStock != alertRow.stockCode)
                {
                    stockNodes = AddNode((strategyNodes == null ? treeGV.Nodes : strategyNodes), alertRow, myDataSet.stockCodeExt, boldFont, 0).Nodes;
                    lastStock = alertRow.stockCode;
                }
                AddNode((stockNodes == null ? treeGV.Nodes : stockNodes), alertRow, null, AlertStatImageIdx(alertRow.status));
            }
        }
        private void CreateDataGridTreeView_StockStrategy(data.baseDS.tradeAlertDataTable tradeAlertTbl, TreeGridView treeGV)
        {
            DataView tradeAlertView = new DataView(tradeAlertTbl);
            tradeAlertView.Sort = tradeAlertTbl.stockCodeColumn.ColumnName + "," +
                                    tradeAlertTbl.strategyColumn.ColumnName + "," +
                                    tradeAlertTbl.timeScaleColumn.ColumnName + "," +
                                    tradeAlertTbl.onTimeColumn.ColumnName + " DESC";

            TreeGridNodeCollection stockNodes = null;
            TreeGridNodeCollection strategyNodes = null;
            data.baseDS.tradeAlertRow alertRow;

            Font boldFont = new Font(treeGV.DefaultCellStyle.Font, FontStyle.Bold);
            string lastStock = "", lastStrategy = "";
            for (int idx = 0; idx < tradeAlertView.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)tradeAlertView[idx].Row;
                if (lastStock != alertRow.stockCode)
                {
                    stockNodes = AddNode(treeGV.Nodes, alertRow, myDataSet.stockCodeExt, boldFont, 0).Nodes;
                    lastStock = alertRow.stockCode;
                    lastStrategy = "";
                }
                if (lastStrategy != alertRow.strategy + alertRow.timeScale.ToString())
                {
                    strategyNodes = AddNode((stockNodes == null ? treeGV.Nodes : stockNodes), alertRow, myDataSet.strategy, boldFont, 0).Nodes;
                    lastStrategy = alertRow.strategy + alertRow.timeScale.ToString();
                }
                AddNode((strategyNodes == null ? treeGV.Nodes : strategyNodes), alertRow, null, AlertStatImageIdx(alertRow.status));
            }
        }
        private void CreateDataGridTreeView_StrategyStock(data.baseDS.tradeAlertDataTable tradeAlertTbl, TreeGridView treeGV)
        {
            DataView tradeAlertView = new DataView(tradeAlertTbl);
            tradeAlertView.Sort = tradeAlertTbl.strategyColumn.ColumnName + "," +
                                    tradeAlertTbl.timeScaleColumn.ColumnName + "," +
                                    tradeAlertTbl.stockCodeColumn.ColumnName + "," +
                                    tradeAlertTbl.onTimeColumn.ColumnName + " DESC";

            TreeGridNodeCollection stockNodes = null;
            TreeGridNodeCollection strategyNodes = null;
            data.baseDS.tradeAlertRow alertRow;

            Font boldFont = new Font(treeGV.DefaultCellStyle.Font, FontStyle.Bold);
            string lastStock = "", lastStrategy = "";
            for (int idx = 0; idx < tradeAlertView.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)tradeAlertView[idx].Row;
                if (lastStrategy != alertRow.strategy + alertRow.timeScale.ToString())
                {
                    strategyNodes = AddNode(treeGV.Nodes, alertRow, myDataSet.strategy, boldFont, 0).Nodes;
                    lastStrategy = alertRow.strategy + alertRow.timeScale.ToString();
                    lastStock = "";
                }
                if (lastStock != alertRow.stockCode)
                {
                    stockNodes = AddNode((strategyNodes == null ? treeGV.Nodes : strategyNodes), alertRow, myDataSet.stockCodeExt, boldFont, 0).Nodes;
                    lastStock = alertRow.stockCode;
                }
                AddNode((stockNodes == null ? treeGV.Nodes : stockNodes), alertRow, null, AlertStatImageIdx(alertRow.status));
            }
        }
        private void CreateDataGridTreeView_Stock(data.baseDS.tradeAlertDataTable tradeAlertTbl, TreeGridView treeGV)
        {
            DataView tradeAlertView = new DataView(tradeAlertTbl);
            tradeAlertView.Sort = tradeAlertTbl.stockCodeColumn.ColumnName + "," +
                                    tradeAlertTbl.onTimeColumn.ColumnName + " DESC";

            TreeGridNodeCollection stockNodes = null;

            data.baseDS.stockCodeExtDataTable stockTbl = new data.baseDS.stockCodeExtDataTable();
            data.baseDS.tradeAlertRow alertRow;

            Font boldFont = new Font(treeGV.DefaultCellStyle.Font, FontStyle.Bold);
            string lastStock = "";
            for (int idx = 0; idx < tradeAlertView.Count; idx++)
            {
                alertRow = (data.baseDS.tradeAlertRow)tradeAlertView[idx].Row;
                if (lastStock != alertRow.stockCode)
                {
                    stockNodes = AddNode(treeGV.Nodes, alertRow, stockTbl, boldFont, 0).Nodes;
                    lastStock = alertRow.stockCode;
                }
                AddNode((stockNodes == null ? treeGV.Nodes : stockNodes), alertRow, null, AlertStatImageIdx(alertRow.status));
            }
        }
        private void CreateDataGridTreeView(data.baseDS.tradeAlertDataTable tradeAlertTbl, TreeGridView treeGV, alertViewModes mode)
        {
            switch (mode)
            {
                case alertViewModes.PortfolioStockStrategy:
                    CreateDataGridTreeView_PortfolioStockStrategy(tradeAlertTbl, treeGV);
                    break;
                case alertViewModes.PortfolioStrategyStock:
                    CreateDataGridTreeView_PortfolioStrategyStock(tradeAlertTbl, treeGV);
                    break;
                case alertViewModes.StockStrategy:
                    CreateDataGridTreeView_StockStrategy(tradeAlertTbl, treeGV);
                    break;
                case alertViewModes.StrategyStock:
                    CreateDataGridTreeView_StrategyStock(tradeAlertTbl, treeGV);
                    break;
                case alertViewModes.StockOnly:
                    CreateDataGridTreeView_Stock(tradeAlertTbl, treeGV);
                    break;
                default:
                    common.system.ThrowException("Invalid mode " + mode.ToString());
                    break;
            }
        }
        private void RefreshGrid()
        {
            tradeAlertList.Nodes.Clear();
            byte selectIdx = (byte)(viewModeCb.SelectedIndex < 0 ? 0 : viewModeCb.SelectedIndex);
            CreateDataGridTreeView(myDataSet.tradeAlert, tradeAlertList, (alertViewModes)selectIdx);
            ShowReccount();
        }
        #endregion

        #region event handler
        private void showFilterBtn_Click(object sender, EventArgs e)
        {
            myAlertFilterForm.ShowForm();
        }
       
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowCurrorWait();
                LoadData();
                RefreshGrid();
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
        
        private void baseTradeAlert_Resize(object sender, EventArgs e)
        {
            try
            {
                ResizeForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void viewModeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ShowCurrorWait();
                RefreshGrid();
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

        private void baseTradeAlertList_Shown(object sender, EventArgs e)
        {
            {
                try
                {
                    LoadData();
                    viewModeCb.SelectedIndex = 0;
                    ResizeForm();
                }
                catch (Exception er)
                {
                    this.ShowError(er);
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tradeAlertList.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage("Xin vui lòng chọn các dòng cần hủy !");
                    return;
                }
                if (common.system.ShowDialogYesNo("Hủy bỏ các cảnh báo đã chọn ?") == DialogResult.No) return;
                int count = 0;
                TreeGridNode node;
                for (int idx = 0; idx < tradeAlertList.SelectedRows.Count; idx++)
                {
                    if (tradeAlertList.SelectedRows[idx].Cells[idColumn.Name].Value == null) continue;
                    dataLibs.DeleteTradeAlert((int)tradeAlertList.SelectedRows[idx].Cells[idColumn.Name].Value);
                    node = (TreeGridNode)(tradeAlertList.SelectedRows[idx]);
                    node.Parent.Nodes.Remove(node);
                    count++;
                }
                this.ShowMessage("Đã hủy bỏ " + count.ToString() + " cảnh báo.");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void ignoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tradeAlertList.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage("Xin vui lòng chọn các dòng cần hủy !");
                    return;
                }
                int count = 0;
                data.baseDS.tradeAlertRow tradeAlertRow;
                for (int idx = 0; idx < tradeAlertList.SelectedRows.Count; idx++)
                {
                    if (tradeAlertList.SelectedRows[idx].Cells[idColumn.Name].Value == null) continue;
                    tradeAlertRow = myDataSet.tradeAlert.FindByid((int)tradeAlertList.SelectedRows[idx].Cells[idColumn.Name].Value);
                    ((TreeGridNode)tradeAlertList.SelectedRows[idx]).ImageIndex = AlertStatImageIdx(myTypes.commonStatus.Ignore);
                    dataLibs.CancelTradeAlert(tradeAlertRow);
                    dataLibs.UpdateData(tradeAlertRow);
                    count++;
                }
                this.ShowMessage("Tạm hủy " + count.ToString() + " cảnh báo.");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void recoverBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (tradeAlertList.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage("Xin vui lòng chọn các dòng phục hồi !");
                    return;
                }
                int count = 0;
                data.baseDS.tradeAlertRow tradeAlertRow;
                for (int idx = 0; idx < tradeAlertList.SelectedRows.Count; idx++)
                {
                    if (tradeAlertList.SelectedRows[idx].Cells[idColumn.Name].Value == null) continue;
                    tradeAlertRow = myDataSet.tradeAlert.FindByid((int)tradeAlertList.SelectedRows[idx].Cells[idColumn.Name].Value);
                    ((TreeGridNode)tradeAlertList.SelectedRows[idx]).ImageIndex = AlertStatImageIdx(myTypes.commonStatus.New);
                    dataLibs.RenewTradeAlert(tradeAlertRow);
                    dataLibs.UpdateData(tradeAlertRow);
                    count++;
                }
                this.ShowMessage("Phục hồi " + count.ToString() + " cảnh báo.");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void tradeAlertList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EditTradeAlert();
            }
            catch(Exception er)
            { 
                this.ShowError(er);
            }
        }

        private void expandAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowCurrorWait();
                TreeGridNode node;
                for (int idx = 0; idx < tradeAlertList.SelectedRows.Count; idx++)
                {
                    node = (TreeGridNode)(tradeAlertList.SelectedRows[idx]);
                    node.Expand();
                    if (node.HasChildren) common.treeView.ExpandAll(node.Nodes);
                }
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

        private void collapseAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowCurrorWait();
                TreeGridNode node;
                for (int idx = 0; idx < tradeAlertList.SelectedRows.Count; idx++)
                {
                    node = (TreeGridNode)(tradeAlertList.SelectedRows[idx]);
                    if (node.Nodes.Count > 0) common.treeView.CollapseAll(node.Nodes);
                    node.Collapse();
                }
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
        private void viewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EditTradeAlert();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void orderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PlaceOrder();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void tradeAlertList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        #endregion
    }
}