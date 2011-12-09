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

namespace baseClass.controls
{
    public partial class stockCodeSelection : common.control.baseUserControl
    {
        private data.baseDS.stockCodeDataTable _allStockCodeTbl = null;
        private data.baseDS.stockCodeDataTable allStockCodeTbl
        {
            get
            {
                if (this._allStockCodeTbl == null)
                {
                    this._allStockCodeTbl = new data.baseDS.stockCodeDataTable();
                    application.dataLibs.LoadData(this._allStockCodeTbl);
                }
                return this._allStockCodeTbl;
            }
        }

        public stockCodeSelection()
        {
            try
            {
                InitializeComponent();
                bizSectorTypeSelection.LoadData();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);;
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
            bizSectorTypeSelection.LockEdit(state);
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
                stockCodeClb.Location = new Point(0, selectAllChk.Height);
                bizSectorTypeSelection.Location = new Point(0, this.Height - bizSectorTypeSelection.Height);

                bizSectorTypeSelection.Width = this.Width;
                stockCodeClb.Size = new Size(this.Width, bizSectorTypeSelection.Location.Y - stockCodeClb.Location.Y);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er); ;
            }         
        }

        private void bizSectorTypeSelection_mySectorSelectionChange(object sender, EventArgs e)
        {
            try
            {
                data.baseDS.stockCodeDataTable dataTbl = new data.baseDS.stockCodeDataTable();
                StringCollection subSectorCodeList = bizSectorTypeSelection.myCurrentSubSectorCodes;
                if (subSectorCodeList == null)
                {
                    stockCodeClb.myDataTbl = this.allStockCodeTbl;
                }
                else
                {
                    application.dataLibs.LoadStockCode_ByBizSector(dataTbl, subSectorCodeList);
                    stockCodeClb.myDataTbl = dataTbl;
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
    }
}
