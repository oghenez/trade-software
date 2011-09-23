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
    public partial class porfolioStrategy : common.control.baseUserControl
    {
        private AppTypes.PortfolioDetailDataType myDataType = AppTypes.PortfolioDetailDataType.Strategy;
        private data.baseDS.portfolioDetailDataTable myDataTbl = new data.baseDS.portfolioDetailDataTable();
        public porfolioStrategy()
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
                ErrorHandler(this, er);;
            }            
        }
        public string myPorfolioCode = null;
        public void LoadData(string porfolioCode)
        {
            this.myPorfolioCode = porfolioCode;  
            myDataTbl.Clear();
            dataLibs.LoadData(myDataTbl, porfolioCode,this.myDataType);
            RefreshView();
        }
        public void SaveData()
        {
            dataLibs.UpdateData(this.myDataTbl);
        }

        public void Init()
        {
            strategyCb.LoadData();
            timeScaleClb.LoadData();
        }
        public void Clear()
        {
            timeScaleClb.myItemString ="";
            this.myDataTbl.Clear();
            RefreshView();
        }
        public void LockData(bool lockStat)
        {
            strategyCb.Enabled = !lockStat;
            timeScaleClb.Enabled = !lockStat;
            treeGV.Enabled = !lockStat;
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

        private static TreeGridNode AddNode(TreeGridNodeCollection parentNodes,
                                    data.baseDS.portfolioDetailRow row, data.baseDS.strategyDataTable strategyTbl, Font fon)
        {
            TreeGridNode node;
            data.baseDS.strategyRow strategyRow = dataLibs.FindAndCache(strategyTbl, row.dataCode.Trim());
            node = parentNodes.Add(strategyRow.code.Trim() + " -  " + strategyRow.description);
            node.Tag = new nodeData(strategyRow.code.Trim(), AppTypes.MainDataTimeScale.Code);

            if (fon != null) node.DefaultCellStyle.Font = fon;
            node.ImageIndex = 0;
            return node;
        }

        private static void AddNodes(TreeGridNodeCollection parentNodes, data.baseDS.portfolioDetailRow row, Font fon)
        {
            StringCollection list = common.MultiValueString.String2List(row.data.Trim());
            TreeGridNode node;
            for (int idx = 0; idx < list.Count; idx++)
            {
                node = parentNodes.Add(list[idx]);
                node.Tag = new nodeData(row.dataCode.Trim(), list[idx]);
                node.ImageIndex = 1;
                if (fon != null) node.DefaultCellStyle.Font = fon;
            }
        }

        private void RefreshView()
        {
            treeGV.Nodes.Clear();
            CreateTreeView(this.myDataTbl, treeGV); 
        }
        private void CreateTreeView(data.baseDS.portfolioDetailDataTable dataTbl, TreeGridView treeGV)
        {
            data.baseDS.strategyDataTable strategyTbl = new data.baseDS.strategyDataTable();
            DataView dataView = new DataView(dataTbl);
            dataView.Sort = dataTbl.dataCodeColumn.ColumnName;
            data.baseDS.portfolioDetailRow dataRow;
            Font boldFont = new Font(treeGV.DefaultCellStyle.Font, FontStyle.Bold);
            string lastStrategy = "";
            TreeGridNodeCollection strategyNodes = null;
            for (int idx = 0; idx < dataView.Count; idx++)
            {
                dataRow = (data.baseDS.portfolioDetailRow)dataView[idx].Row;
                if (lastStrategy != dataRow.dataCode.Trim())
                {
                    strategyNodes = AddNode(treeGV.Nodes, dataRow, strategyTbl, boldFont).Nodes;
                    lastStrategy = dataRow.dataCode.Trim();
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
                row = this.myDataTbl.FindByportfoliodataTypedataCode(this.myPorfolioCode, (byte)this.myDataType, strategyCb.myValue);
                if (row == null)
                {
                    row = this.myDataTbl.NewportfolioDetailRow();
                    dataLibs.InitData(row);
                    row.dataType = (byte)this.myDataType;
                    row.dataCode = strategyCb.myValue;
                    row.portfolio = this.myPorfolioCode;
                    row.data = timeScaleClb.myItemString;
                    this.myDataTbl.AddportfolioDetailRow(row);
                }
                row.data = timeScaleClb.myItemString;
                RefreshView();
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
                    common.system.ShowErrorMessage("Xin vui lòng chọn ít nhất 01 dòng trong danh sách");
                    treeGV.Focus();
                    return;
                }
                nodeData nodeData;
                data.baseDS.portfolioDetailRow row;
                for (int idx = 0; idx < treeGV.SelectedRows.Count; idx++)
                {
                    nodeData = (nodeData)treeGV.SelectedRows[idx].Tag;
                    row = this.myDataTbl.FindByportfoliodataTypedataCode(this.myPorfolioCode, (byte)this.myDataType, nodeData.strategy);
                    if (row != null) row.Delete();
                }
                RefreshView();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }

        private void porfolioStrategy_Resize(object sender, EventArgs e)
        {
            try
            {
                addNewBtn.Size = new Size(25, 24);
                addAllBtn.Size = new Size(25, 24);
                deleteBtn.Size = new Size(25, 24);

                deleteBtn.Location = new Point(this.Width - deleteBtn.Width, deleteBtn.Location.Y);
                addAllBtn.Location = new Point(this.Width - addAllBtn.Width - deleteBtn.Width, addAllBtn.Location.Y);
                addNewBtn.Location = new Point(this.Width - addNewBtn.Width - deleteBtn.Width- addAllBtn.Width, addNewBtn.Location.Y);

                timeScaleClb.Location = new Point(addNewBtn.Location.X - timeScaleClb.Width, timeScaleClb.Location.Y);
                timeScaleLbl.Location = new Point(timeScaleClb.Location.X, timeScaleLbl.Location.Y);

                strategyCb.Width = this.Width - timeScaleClb.Width - addNewBtn.Width+2;

                treeGV.Location = new Point(0, strategyCb.Location.Y + strategyCb.Height);
                treeGV.Size = new Size(this.Width, this.Height - treeGV.Location.Y);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }

        private void ExpandTimeScale()
        {
            timeScaleClb.Height = this.Height - 2 * timeScaleClb.Height;
        }
        private void CollapseTimeScale()
        {
            timeScaleClb.Height = this.strategyCb.Height;
        }

        private void timeScaleClb_Enter(object sender, EventArgs e)
        {
            ExpandTimeScale();
        }

        private void timeScaleClb_Leave(object sender, EventArgs e)
        {
            CollapseTimeScale();
        }

        private void timeScaleClb_MouseHover(object sender, EventArgs e)
        {
            ExpandTimeScale();
        }

        private void timeScaleClb_MouseLeave(object sender, EventArgs e)
        {
            CollapseTimeScale();
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
                data.baseDS.strategyRow strategyRow;
                for (int idx = 0; idx < strategyCb.Items.Count; idx++)
                {
                    strategyRow = (data.baseDS.strategyRow)((DataRowView)strategyCb.Items[idx]).Row;
                    row = this.myDataTbl.NewportfolioDetailRow();
                    dataLibs.InitData(row);
                    row.dataType = (byte)this.myDataType;
                    row.dataCode = strategyRow.code;
                    row.portfolio = this.myPorfolioCode;
                    row.data = timeScaleClb.myItemString;
                    this.myDataTbl.AddportfolioDetailRow(row);
                }
                RefreshView();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }
        }
    }
}
