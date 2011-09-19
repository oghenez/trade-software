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
    public partial class stockCodeSelectBySector : common.control.baseUserControl
    {
        private data.baseDS.stockCodeDataTable _stockCodeTbl = null;
        private data.baseDS.stockCodeDataTable stockCodeTbl
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
        private data.baseDS.stockCodeDataTable _companyCodeTbl = null;
        private data.baseDS.stockCodeDataTable companyCodeTbl
        {
            get
            {
                if (this._companyCodeTbl == null)
                {
                    this._companyCodeTbl = new data.baseDS.stockCodeDataTable();
                    application.dataLibs.LoadData(this._companyCodeTbl, AppTypes.CommonStatus.Enable);
                }
                return this._companyCodeTbl;
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
        public StringCollection myCheckedValues
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

        private void form_Resize(object sender, EventArgs e)
        {
            try
            {
                bizSectorTypesSelection.Width = this.Width;
                optionPnl.Width = this.Width;

                optionPnl.Location = new Point(0, this.Height - optionPnl.Height);
                stockCodeClb.Location = new Point(0, bizSectorTypesSelection.Height);
                stockCodeClb.Size = new Size(this.Width, optionPnl.Location.Y - stockCodeClb.Location.Y);
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
                StringCollection subSectorCodeList = bizSectorTypesSelection.myCurrentSubSectorCodes;
                if (subSectorCodeList == null)
                {
                    stockCodeClb.myDataTbl = this.stockCodeTbl;
                }
                else
                {
                    string cond = common.system.MakeConditionStr(subSectorCodeList,
                                                         this.companyCodeTbl.bizSectorsColumn.ColumnName + " LIKE '" +
                                                         common.Consts.SQL_CMD_ALL_MARKER + common.settings.sysListSeparatorPrefix,
                                                         common.settings.sysListSeparatorPostfix + common.Consts.SQL_CMD_ALL_MARKER + "'",
                                                         "OR");
                    DataView companyView = new DataView(companyCodeTbl);
                    companyView.RowFilter = cond;

                    DataView stockCodeView = new DataView(stockCodeTbl);
                    stockCodeView.Sort = stockCodeTbl.codeColumn.ColumnName;
                    StringCollection stocCodeList = new StringCollection();
                    DataRowView[] foundStockCodes;
                    for (int idx = 0; idx < companyView.Count; idx++)
                    {
                        foundStockCodes = stockCodeView.FindRows(companyView[idx][companyCodeTbl.codeColumn.ColumnName]);
                        if (foundStockCodes.Length == 0) continue;
                        for (int idx2 = 0; idx2 < foundStockCodes.Length; idx2++)
                            stocCodeList.Add(foundStockCodes[idx2][stockCodeTbl.codeColumn.ColumnName].ToString());
                    }
                    stockCodeClb.myItemValues = stocCodeList;
                }
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
