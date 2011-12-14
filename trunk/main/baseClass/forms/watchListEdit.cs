using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using commonClass;

namespace baseClass.forms
{
    public partial class watchListEdit : baseMasterEdit
    {
        public commonClass.AppTypes.PortfolioTypes myWatchListType = commonClass.AppTypes.PortfolioTypes.WatchList;
        private data.baseDS.portfolioDetailDataTable defaultStrategyTbl = null;
        public watchListEdit()
        {
            try
            {
                InitializeComponent();
                this.LoadDataOnLoad = false;
                myMasterSource = portfolioSource;
                codeEd.MaxLength = myDataSet.portfolio.codeColumn.MaxLength;
                nameEd.MaxLength = myDataSet.portfolio.nameColumn.MaxLength;
                descriptionEd.MaxLength = myDataSet.portfolio.descriptionColumn.MaxLength;

                interestedStockClb.maxLen = myDataSet.portfolio.interestedStockColumn.MaxLength;

                interestedStrategy.Init();
                interestedStockClb.LoadData();

                //Load default Portfolio Data
                this.defaultStrategyTbl = DataAccess.Libs.GetPortfolioDetail_ByCode(DataAccess.Libs.GetPortfolio_DefaultStrategy().code);
                codeEd.BackColor = common.settings.sysColorDisableBG; codeEd.ForeColor = common.settings.sysColorDisableFG;
                LockEdit(true);
                Form_Resize(null, null);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private string _myInvestorCode = "";
        public string myInvestorCode
        {
            get { return _myInvestorCode; }
            set 
            { 
                _myInvestorCode = value;
                LoadData();
            }
        }
        public static watchListEdit GetForm(string formName)
        {
            string cacheKey = typeof(watchListEdit).FullName + (formName != null && formName.Trim() == "" ? "-" + formName.Trim() : "");
            watchListEdit form = (watchListEdit)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new watchListEdit();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        private bool isLockEditDetail
        {
            get { return !xpPanel_options.Enabled; }
            set 
            {
                bool lockState = true;
                if (this.portfolioSource != null && this.portfolioSource.Current != null)
                {
                    data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;
                    lockState =  this.isLockEdit || isNewRow(row);
                }
                xpPanel_options.Enabled = !lockState;
            }
        }
 
        #region override funcs
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("watchList");

            codeColumn.HeaderText = Languages.Libs.GetString("code");
            nameColumn.HeaderText = Languages.Libs.GetString("name");

            xpPane_generalInfo.Caption = Languages.Libs.GetString("generalInfo");
            codeLbl.Text = Languages.Libs.GetString("code");
            nameLbl.Text = Languages.Libs.GetString("name");
            descriptionLbl.Text = Languages.Libs.GetString("description");

            xpPanel_options.Caption = Languages.Libs.GetString("option");
            interestedStockLbl.Text = Languages.Libs.GetString("interestedCode");

            interestedStrategy.SetLanguage();
        }

        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.nameEd.Enabled = !lockState;
            this.descriptionEd.Enabled = !lockState;

            this.interestedStockClb.Enabled = !lockState;
            this.interestedStrategy.LockData(lockState);
            this.isLockEditDetail = this.isLockEditDetail;
        }
        public override void AddNew(string code)
        {
            bool saveOnProccessing = this.fOnProccessing;
            try
            {
                this.fOnProccessing = true;
                data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)myMasterSource.AddNew()).Row;
                if (row != null)
                {
                    commonClass.AppLibs.InitData(row);
                    row.type = (byte)this.myWatchListType;
                    row.investorCode = this.myInvestorCode;
                    row.code = Consts.constNotMarkerNEW;
                    interestedStrategy.Clear();
                    int position = myMasterSource.Position;
                    myMasterSource.Position = -1;
                    myMasterSource.Position = position;
                    SetFirstFocus();
                }
                PortfolioCurrentChanged();
                this.fOnProccessing = saveOnProccessing;
            }
            catch (Exception er)
            {
                this.fOnProccessing = saveOnProccessing;
                ShowError(er);
            }
        }

        protected override bool DataChanged()
        {
            return false;
            //if (portfolioSource.DataSource == null || myPortfolioDetailTbl == null) return false;
            //return ( (portfolioSource.DataSource as data.baseDS.portfolioDataTable).GetChanges().Rows.Count > 0)||
            //         (myPortfolioDetailTbl.GetChanges() != null && myPortfolioDetailTbl.GetChanges().Rows.Count > 0);
        }
        protected override void SetFirstFocus()
        {
            this.nameEd.Focus();
        }
        protected override void LoadData()
        {
            bool saveOnProccessing = this.fOnProccessing;
            try
            {
                this.fOnProccessing = true;
                myMasterSource.DataSource = DataAccess.Libs.GetPortfolio_ByType(this.myWatchListType);
                PortfolioCurrentChanged();
                this.fOnProccessing = saveOnProccessing;
            }
            catch (Exception er)
            {
                this.fOnProccessing = saveOnProccessing;
                ShowError(er);
            }
        }
        protected override bool DataValid(bool showMsg)
        {
            ClearNotifyError();
            bool retVal = base.DataValid(showMsg);
            if (nameEd.Text.Trim() == "")
            {
                NotifyError(nameLbl);
                retVal = false;
            }
            if (descriptionEd.Text.Trim() == "")
            {
                NotifyError(descriptionLbl);
                retVal = false;
            }
            if (!interestedStockClb.DataValid(false))
            {
                NotifyError(interestedStockLbl);
                retVal = false;
            }
            if (!retVal) this.ShowMessage(Languages.Libs.GetString("invalidData"));
            return retVal;
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null) return;
            data.baseDS.portfolioRow portfolioRow = (data.baseDS.portfolioRow)row;
            portfolioRow.ItemArray = DataAccess.Libs.UpdateData(portfolioRow).ItemArray;
            portfolioRow.AcceptChanges();
            isLockEditDetail = false; 

            if (this.interestedStrategy.myDataTbl != null)
            {
                DataAccess.Libs.UpdateData(this.interestedStrategy.myDataTbl);
                interestedStrategy.myDataTbl.AcceptChanges();
            }
            PortfolioCurrentChanged();
        }
        protected override void RemoveCurrent()
        {
            this.ShowMessage("");
            if (myMasterSource.Current == null) return;
            data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)(myMasterSource.Current as DataRowView).Row;
            if (row.HasVersion(DataRowVersion.Original))
                DataAccess.Libs.DeleteData(row);
            myMasterSource.RemoveCurrent();
            this.ShowMessage(Languages.Libs.GetString("dataWasDeleted"));
        }
       
        #endregion override funcs

        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void PortfolioCurrentChanged()
        {
            if (this.portfolioSource.Current == null) return;
            data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;
            if (isNewRow(row))
            {
                interestedStrategy.myPorfolioCode = null;
                interestedStrategy.myDataTbl = null;
            }
            else
            {
                interestedStrategy.myPorfolioCode = row.code;
                interestedStrategy.myDataTbl = DataAccess.Libs.GetPortfolioDetail_ByCode(row.code);
            }
            this.isLockEditDetail = this.isLockEditDetail;
            interestedStrategy.myStockCode = null;
            interestedStrategy.Refresh();
            ShowReccount((this.portfolioSource.Position + 1).ToString() + "/" + this.portfolioSource.Count.ToString());
        }
        private void portfolioSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                PortfolioCurrentChanged();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }


        private void Form_Resize(object sender, EventArgs e)
        {
            try
            {
                xpPanelGroup_Info.Height = this.ClientRectangle.Height - this.xpPanelGroup_Info.Location.Y - SystemInformation.CaptionHeight + 3;
                xpPanel_options.Height = xpPanelGroup_Info.Height - xpPanel_options.Location.Y-5;
                interestedStrategy.Height = xpPanel_options.Height - interestedStrategy.Location.X-1; 
                common.system.AutoFitGridColumn(portfolioGrid, nameColumn.Name);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }

        private void interestedStockClb_myStockCodeSelectionChange(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing) return;
                
                if( ((baseClass.controls.lbStockCode)sender).SelectedItem ==null) return;
                data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;
                interestedStrategy.Clear();
                interestedStrategy.myStockCode = ((common.myComboBoxItem)(((baseClass.controls.lbStockCode)sender).SelectedItem)).Value;
                interestedStrategy.Refresh();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void interestedStockClb_myOnError(object sender, common.myExceptionEventArgs e)
        {
            ShowError(e.myException);
        }
        private bool interestedStockClb_myOnAddItemList(object sender, StringCollection codes)
        {
            for (int idx = 0; idx < codes.Count; idx++)
            {
                commonClass.AppLibs.CopyPortfolioData(this.defaultStrategyTbl, interestedStrategy.myDataTbl, interestedStrategy.myPorfolioCode, codes[idx]);
            }
            interestedStrategy.Refresh();
            return true;
        }
        private bool interestedStockClb_myOnRemoveItemList(object sender, StringCollection codes)
        {
            int saveCount = 0;
            DataView myView = new DataView(interestedStrategy.myDataTbl);
            string cond = common.system.MakeConditionStr(codes, interestedStrategy.myDataTbl.codeColumn.ColumnName + "='", "'", " OR ");
            if (cond !="") cond = "("+ cond + ")";
            cond += (cond=="" ? "":" AND ") +
                     this.interestedStrategy.myDataTbl.portfolioColumn.ColumnName + "='" + interestedStrategy.myPorfolioCode + "'";

            myView.RowFilter = cond;
            for (int idx = 0; idx < myView.Count; idx++)
            {
                saveCount = myView.Count;
                myView[idx].Delete();
                if (saveCount != myView.Count) idx--;
            }
            interestedStrategy.Clear();
            return true; 
        }
        #endregion event handler

        bool fSizing = false;
        private void xpPanel_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void xpPanelGroup_Info_Layout(object sender, LayoutEventArgs e)
        {
            
        }

        private void xpPane_CollapseExpand(object sender, EventArgs e)
        {
            try
            {
                if (fSizing) return;
                fSizing = true;
                xpPanel_options.Height = xpPanelGroup_Info.Height - xpPanel_options.Location.Y;
                xpPanel_options.Width = xpPanelGroup_Info.Width;

                interestedStrategy.Height = xpPanel_options.Height - interestedStrategy.Location.Y;
                interestedStrategy.Width = xpPanel_options.Width;
                fSizing = false;
            }
            catch (Exception er)
            {
                fSizing = false;
                this.ShowError(er);
            }
        }
    }
}