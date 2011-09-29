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
    public partial class stockCodeSelectBySector : common.controls.baseUserControl
    {
        private data.baseDS.stockCodeDataTable _stockCodeTbl = null;
        protected data.baseDS.stockCodeDataTable myStockCodeTbl
        {
            get
            {
                if (this._stockCodeTbl == null)
                {
                    this._stockCodeTbl = new data.baseDS.stockCodeDataTable();
                    dataLibs.LoadData(this._stockCodeTbl,AppTypes.CommonStatus.Enable);
                }
                return this._stockCodeTbl;
            }
        }

        public stockCodeSelectBySector()
        {
            try
            {
                InitializeComponent();
                bizSectorTypesSelection.LoadData();
                selectCodeEd.isToUpperCase = true;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }            
        }
        protected void ClearCache()
        {
            this._stockCodeTbl = null;
        }
        public override void Refresh()
        {
            ClearCache();
            LoadStockList();
        }

        public StringCollection myValues
        {
            get { return stockCodeClb.myCheckedValues;}
            set { stockCodeClb.myCheckedValues = value;}
        }
        public string myItemString
        {
            get { return stockCodeClb.myItemString; }
            set { stockCodeClb.myItemString = value; }
        }
        public int maxLen
        {
            set { stockCodeClb.maxLen = value; }
        }
        public void CheckAll(bool state)
        {
            stockCodeClb.CheckAll(state);
        }
        public bool ShowCheckedOnly
        {
            get
            {
                return this.stockCodeClb.ShowCheckedOnly;
            }
            set
            {
                showOnlyCheckedChk.Checked = value;
                this.stockCodeClb.ShowCheckedOnly = value;
            }
        }
        public virtual void LoadData()
        {
            this.stockCodeClb.LoadData();
        }
        public virtual void DataBining(BindingSource source,string fldName)
        {
            this.stockCodeClb.DataBindings.Clear();
            this.stockCodeClb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", source, fldName, true));
        }
        public virtual void LockEdit(bool state)
        {
            this.Enabled = !state;
            this.stockCodeClb.Enabled = !state;
            showOnlyCheckedChk.Enabled = !state;
            bizSectorTypesSelection.LockEdit(state);
        }
        public virtual void LoadStockList()
        {
            StringCollection subSectorCodeList = bizSectorTypesSelection.myCurrentSubSectorCodes;
            if (subSectorCodeList == null)
            {
                stockCodeClb.myDataTbl = this.myStockCodeTbl;
            }
            else
            {
                string cond = common.system.MakeConditionStr(subSectorCodeList,
                                                     this.myStockCodeTbl.bizSectorsColumn.ColumnName + " LIKE '" +
                                                     common.Consts.SQL_CMD_ALL_MARKER + common.settings.sysListSeparatorPrefix,
                                                     common.settings.sysListSeparatorPostfix + common.Consts.SQL_CMD_ALL_MARKER + "'",
                                                     "OR");
                DataView stockCodeView = new DataView(myStockCodeTbl);
                stockCodeView.Sort = myStockCodeTbl.codeColumn.ColumnName;
                stockCodeView.RowFilter = cond;
                StringCollection stocCodeList = new StringCollection();
                for (int idx = 0; idx < stockCodeView.Count; idx++)
                {
                    stocCodeList.Add(stockCodeView[idx][myStockCodeTbl.codeColumn.ColumnName].ToString());
                }
                stockCodeClb.myItemValues = stocCodeList;
            }
        }


        private void showOnlyCheckedChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.stockCodeClb.ShowCheckedOnly = showOnlyCheckedChk.Checked;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }            
        }
        private void bizSectorTypesSelection_mySectorSelectionChange(object sender, EventArgs e)
        {
            try
            {
                LoadStockList();

                selectAllChk.Checked = false; 
                showOnlyCheckedChk.Checked = false; 
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }
        }

        private void selectAllChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                stockCodeClb.CheckAll(selectAllChk.Checked);
                if (selectAllChk.Checked)
                    stockCodeClb.ShowCheckedOnly = stockCodeClb.ShowCheckedOnly;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }         
        }

        private void selectCodeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StringCollection curList = stockCodeClb.myCheckedValues;
                curList.AddRange(common.system.String2List(selectCodeEd.Text));
                stockCodeClb.myCheckedValues = curList;
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }         
        }

        private void selectCodeEd_Validated(object sender, EventArgs e)
        {
            selectCodeBtn_Click(sender, e);
        }

        private void optionPnl_Resize(object sender, EventArgs e)
        {
            try
            {
                selectCodeBtn.Location = new Point(this.Width - selectCodeBtn.Width,0);
                selectCodeEd.Width = selectCodeBtn.Location.X - selectCodeEd.Location.X; 
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }       
        }
    }
}
