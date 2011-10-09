﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class watchListEdit : baseMasterEdit
    {
        public application.AppTypes.PortfolioTypes myWatchListType = application.AppTypes.PortfolioTypes.WatchList;
        private data.baseDS.portfolioDetailDataTable defaPortfolioDataTbl = new data.baseDS.portfolioDetailDataTable();
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
                this.defaPortfolioDataTbl.Clear();
                application.dataLibs.LoadSysPortfolio(this.defaPortfolioDataTbl);
                codeEd.BackColor = common.settings.sysColorDisableBG; codeEd.ForeColor = common.settings.sysColorDisableFG;
                LockEdit(true);
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

 
        #region override funcs
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("watchList");

            codeColumn.HeaderText = language.GetString("code");
            nameColumn.HeaderText = language.GetString("name");

            xpPane_generalInfo.Caption = language.GetString("generalInfo");
            codeLbl.Text = language.GetString("code");
            nameLbl.Text = language.GetString("name");
            descriptionLbl.Text = language.GetString("description");

            xpPanel_options.Caption = language.GetString("option");
            interestedStockLbl.Text = language.GetString("interestedCode");

            interestedStrategy.SetLanguage();
        }

        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.nameEd.Enabled = !lockState;
            this.descriptionEd.Enabled = !lockState;

            this.interestedStockClb.Enabled = !lockState;
            this.interestedStrategy.LockData(lockState);

        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);
            row.type = (byte)this.myWatchListType;
            common.myAutoKeyInfo info = application.sysLibs.GetAutoKey(myDataSet.portfolio.TableName, false);
            row.code = info.value.ToString().PadLeft(myDataSet.portfolio.codeColumn.MaxLength, '0');
            row.investorCode = this.myInvestorCode;
            codeEd.Text = row.code;
            interestedStrategy.Clear();
        }

        protected override bool DataChanged()
        {
            return (myDataSet.portfolioDetail.GetChanges() != null && myDataSet.portfolioDetail.GetChanges().Rows.Count > 0);
        }
        protected override void SetFirstFocus()
        {
            this.nameEd.Focus();
        }
        protected override void LoadData()
        {
            this.myDataSet.portfolio.Clear();
            application.dataLibs.LoadPortfolioByInvestor(this.myDataSet.portfolio, this.myInvestorCode, this.myWatchListType);
            interestedStrategy.myStockCode = "";
            interestedStrategy.Clear();
            portfolioSource_CurrentChanged(null, null);
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
            if (!retVal) this.ShowMessage(language.GetString("invalidData"));
            return retVal;
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null)
            {
                application.dataLibs.UpdateData(myDataSet.portfolio);
                return;
            }
            data.baseDS.portfolioRow portfolioRow = (data.baseDS.portfolioRow)row;
            if (portfolioRow.code.Trim() == "")
            {
                common.myAutoKeyInfo info = application.sysLibs.GetAutoKey(myDataSet.portfolio.TableName, false);
                portfolioRow.code = info.value.ToString().PadLeft(myDataSet.portfolio.codeColumn.MaxLength, '0');
            }
            application.dataLibs.UpdateData(portfolioRow);
            application.dataLibs.UpdateData(myDataSet.portfolioDetail);
        }
       
        #endregion override funcs

        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
        private void portfolioSource_CurrentChanged(object sender, EventArgs e)
        {
            bool saveOnProccessing = this.fOnProccessing;
            try
            {
                if (this.fOnProccessing) return;
                this.fOnProccessing = true;
                ShowReccount((this.portfolioSource.Position + 1).ToString() + "/" + this.portfolioSource.Count.ToString());
                myDataSet.portfolioDetail.Clear();
                data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;
                application.dataLibs.LoadData(myDataSet.portfolioDetail, row.code);
                interestedStrategy.myDataTbl = myDataSet.portfolioDetail;
                interestedStrategy.myPorfolioCode = row.code;
                interestedStrategy.myStockCode = "";
                interestedStrategy.Clear();
            }
            catch (Exception er)
            {
                ShowError(er);
            }
            finally
            {
                this.fOnProccessing = saveOnProccessing;
            }
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            try
            {
                xpPanelGroup_Info.Height = this.ClientRectangle.Height - this.xpPanelGroup_Info.Location.Y - SystemInformation.CaptionHeight + 3;
                xpPanel_options.Height = xpPanelGroup_Info.Height - xpPanel_options.Location.Y;
                interestedStrategy.Height = xpPanel_options.Height - interestedStrategy.Location.X-1; 
                common.system.AutoFitGridColumn(portfolioGrid, nameColumn.Name);
                this.ShowMessage(xpPanelGroup_Info.Height.ToString() + "-" + xpPanel_options.Height.ToString() +"-"+ this.ClientRectangle.Height.ToString());
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
                interestedStrategy.myStockCode = "";
                if ((((baseClass.controls.lbStockCode)sender).SelectedItem) != null)
                {
                    string stockCode = ((common.myComboBoxItem)(((baseClass.controls.lbStockCode)sender).SelectedItem)).Value;
                    interestedStrategy.myStockCode = stockCode;
                }
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
                application.dataLibs.CopyPortfolioData(this.defaPortfolioDataTbl,myDataSet.portfolioDetail,interestedStrategy.myPorfolioCode, codes[idx]);
            }
            interestedStrategy.Refresh();
            return true;
        }
        private bool interestedStockClb_myOnRemoveItemList(object sender, StringCollection codes)
        {
            int saveCount = 0;
            DataView myView = new DataView(myDataSet.portfolioDetail);
            string cond = common.system.MakeConditionStr(codes,myDataSet.portfolioDetail.codeColumn.ColumnName+"='","'"," OR ");
            if (cond !="") cond = "("+ cond + ")";
            cond += (cond=="" ? "":" AND ") + 
                     myDataSet.portfolioDetail.portfolioColumn.ColumnName + "='" +  interestedStrategy.myPorfolioCode + "'";

            myView.RowFilter = cond;
            for (int idx = 0; idx < myView.Count; idx++)
            {
                saveCount = myView.Count;
                myView[idx].Delete();
                if (saveCount != myView.Count) idx--;
            }
            return true; 
        }
        #endregion event handler
    }
}