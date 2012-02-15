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
using commonTypes;
using application;

namespace baseClass.controls
{
    public partial class stockCodeSelectBySector : common.controls.baseUserControl
    {
        protected databases.tmpDS.stockCodeDataTable myStockCodeTbl
        {
            get
            {
                return DataAccess.Libs.myStockCodeTbl;
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
        public override void SetLanguage()
        {
            base.SetLanguage();
            onlySeletedChk.Text = Languages.Libs.GetString("onlySelected");
            selectAllChk.Text = Languages.Libs.GetString("selectAll");

            bizSectorTypesSelection.SetLanguage();
            stockCodeClb.SetLanguage();
        }

        public override void Refresh()
        {
            DataAccess.Libs.ClearCache();
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
                onlySeletedChk.Checked = value;
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
            onlySeletedChk.Enabled = !state;
            bizSectorTypesSelection.LockEdit(state);
        }
        public virtual void LoadStockList()
        {
            StringCollection sectorCodeList = bizSectorTypesSelection.myCurrentSubSectorCodes;
            if (sectorCodeList == null)
            {
                stockCodeClb.myDataTbl = this.myStockCodeTbl;
            }
            else
            {
                stockCodeClb.myItemValues = common.system.List2Collection(DataAccess.Libs.GetStockList_ByBizSector(sectorCodeList));
            }
        }


        private void onlySeletedChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.stockCodeClb.ShowCheckedOnly = onlySeletedChk.Checked;
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
                onlySeletedChk.Checked = false; 
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
