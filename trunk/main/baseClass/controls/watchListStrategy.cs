using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using AdvancedDataGridView;
using application;

namespace baseClass.controls
{
    public partial class watchListStrategy : common.controls.baseUserControl
    {
        public watchListStrategy()
        {
            try
            {
                InitializeComponent();
                // load image strip
                this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
                this.imageStrip.TransparentColor = System.Drawing.Color.Transparent;
                this.imageStrip.ImageSize = new Size(16, 16);
                this.imageStrip.Images.AddStrip(Properties.Resources.strategy_images);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }            
        }

        private data.baseDS.portfolioDetailDataTable _myDataTbl = null;
        public data.baseDS.portfolioDetailDataTable myDataTbl
        {
            get { return _myDataTbl; }
            set 
            { 
                _myDataTbl = value;
            }
        }

        public string myPorfolioCode = null;
        public string myStockCode = null;

        public void Init()
        {
            strategyCb.LoadData();
            timeScaleClb.LoadData();
        }
        public void Clear()
        {
            treeGV.Nodes.Clear();
        }
        public void LockData(bool lockStat)
        {
            addNewBtn.Enabled = !lockStat;
            addAllBtn.Enabled = false; // !lockStat;
            deleteBtn.Enabled = !lockStat;

            strategyCb.Enabled = !lockStat;
            timeScaleClb.Enabled = !lockStat;
            treeGV.Enabled = !lockStat;
        }
        public override void Refresh()
        {
            base.Refresh();
            treeGV.Nodes.Clear();
            CreateTreeView(this.myDataTbl, treeGV);
        }

        private class nodeData
        {
            public nodeData(string _strategy, string _timeScale)
            {
                this.strategy = _strategy;
                this.timeScale = _timeScale;
            }
            public string strategy = "";
            public string timeScale = "";
        }

        private static TreeGridNode AddNode(TreeGridNodeCollection parentNodes,string strategyCode, string strategyDescription, Font fon)
        {
            TreeGridNode node;
            node = parentNodes.Add(strategyCode + " - " + strategyDescription);
            node.Tag = new nodeData(strategyCode, AppTypes.MainDataTimeScale.Code);

            if (fon != null) node.DefaultCellStyle.Font = fon;
            node.ImageIndex = 0;
            return node;
        }

        private static void AddNodes(TreeGridNodeCollection parentNodes,data.baseDS.portfolioDetailRow row, Font fon)
        {
            StringCollection list = common.MultiValueString.String2List(row.data.Trim());
            TreeGridNode node;
            for (int idx = 0; idx < list.Count; idx++)
            {
                node = parentNodes.Add(list[idx]);
                node.Tag = new nodeData(row.subCode.Trim(), list[idx]);
                node.ImageIndex = 1;
                if (fon != null) node.DefaultCellStyle.Font = fon;
            }
        }

        private string GetStrategyDescription(string code)
        {
            for(int idx=0;idx<strategyCb.Items.Count;idx++)
            {
                common.myComboBoxItem item = (common.myComboBoxItem)strategyCb.Items[idx];
                if (item.Value == code) return item.Text;
            }
            return null;
        }

        private void CreateTreeView(data.baseDS.portfolioDetailDataTable dataTbl, TreeGridView treeGV)
        {
            if (this.myPorfolioCode == null || this.myStockCode == null) return;

            DataView dataView = new DataView(dataTbl);
            dataView.Sort = dataTbl.subCodeColumn.ColumnName;
            dataView.RowFilter = dataTbl.portfolioColumn + "='" + this.myPorfolioCode + "' AND " +
                                 dataTbl.codeColumn + "='" + this.myStockCode + "'";
            data.baseDS.portfolioDetailRow dataRow;
            Font boldFont = new Font(treeGV.DefaultCellStyle.Font, FontStyle.Bold);
            string lastStrategy = "";
            TreeGridNodeCollection strategyNodes = null;
            for (int idx = 0; idx < dataView.Count; idx++)
            {
                dataRow = (data.baseDS.portfolioDetailRow)dataView[idx].Row;
                if (lastStrategy != dataRow.subCode.Trim())
                {
                    strategyNodes = AddNode(treeGV.Nodes, dataRow.subCode, GetStrategyDescription(dataRow.subCode), boldFont).Nodes;
                    lastStrategy = dataRow.subCode.Trim();
                }
                AddNodes((strategyNodes == null ? treeGV.Nodes : strategyNodes), dataRow,null);
            }
        }

        private void addNewBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ClearNotifyError();
                if (strategyCb.myValue=="")
                {
                    NotifyError(strategyLbl); 
                    return;
                }
                if (timeScaleClb.myItemString.Trim() == "")
                {
                    NotifyError(timeScaleLbl);
                    return;
                }
                data.baseDS.portfolioDetailRow row;
                row = this.myDataTbl.FindByportfoliocodesubCode(this.myPorfolioCode, this.myStockCode, strategyCb.myValue);
                if (row == null)
                {
                    row = this.myDataTbl.NewportfolioDetailRow();
                    dataLibs.InitData(row);
                    row.portfolio = this.myPorfolioCode;
                    row.code = this.myStockCode;
                    row.subCode = strategyCb.myValue;
                    row.data = timeScaleClb.myItemString;
                    this.myDataTbl.AddportfolioDetailRow(row);
                }
                row.data = timeScaleClb.myItemString;
                Refresh();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeGV.SelectedRows.Count == 0)
                {
                    common.system.ShowErrorMessage("Please select one or more rows!");
                    treeGV.Focus();
                    return;
                }
                nodeData nodeData;
                data.baseDS.portfolioDetailRow row;
                for (int idx = 0; idx < treeGV.SelectedRows.Count; idx++)
                {
                    nodeData = (nodeData)treeGV.SelectedRows[idx].Tag;
                    row = this.myDataTbl.FindByportfoliocodesubCode(this.myPorfolioCode,this.myStockCode, nodeData.strategy);
                    if (row != null) row.Delete();
                }
                Refresh();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
       
        private void ExpandTimeScale()
        {
            timeScaleClb.Height = Math.Min(timeScaleClb.Items.Count * (timeScaleClb.Font.Height + 2 * SystemInformation.BorderSize.Height + 3),
                                           this.Height - 1 * timeScaleClb.Height);
        }
        private void CollapseTimeScale()
        {
            timeScaleClb.Height = this.strategyCb.Height;
        }

        private void timeScaleClb_Enter(object sender, EventArgs e)
        {
            try
            {
                ExpandTimeScale();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }

        private void timeScaleClb_Leave(object sender, EventArgs e)
        {
            try
            {
                CollapseTimeScale();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }

        private void timeScaleClb_MouseHover(object sender, EventArgs e)
        {
            try
            {
                ExpandTimeScale();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }

        private void timeScaleClb_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                CollapseTimeScale();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }

        private void addAllBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ClearNotifyError();
                if (strategyCb.myValue == "")
                {
                    NotifyError(strategyLbl);
                    return;
                }
                if (timeScaleClb.myItemString.Trim() == "")
                {
                    NotifyError(timeScaleLbl);
                    return;
                }
                data.baseDS.portfolioDetailRow row;

                for (int idx = 0; idx < this.myDataTbl.Count; idx++)
                {
                    this.myDataTbl[idx].Delete();
                }
                for (int idx = 0; idx < strategyCb.Items.Count; idx++)
                {
                    common.myComboBoxItem item = (common.myComboBoxItem)strategyCb.Items[idx];
                    row = this.myDataTbl.NewportfolioDetailRow();
                    dataLibs.InitData(row);
                    row.portfolio = this.myPorfolioCode;
                    row.code  = this.myStockCode;
                    row.subCode = item.Value;
                    row.data = timeScaleClb.myItemString;
                    this.myDataTbl.AddportfolioDetailRow(row);
                }
                Refresh();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
    }
}
