using System;
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
    public partial class portfolioEdit : baseMasterEdit
    {
        public application.AppTypes.PortfolioTypes myPortfolioType = application.AppTypes.PortfolioTypes.Portfolio;
        public portfolioEdit()
        {
            try
            {
                InitializeComponent();
                this.LoadDataOnLoad = false;
                myMasterSource = portfolioSource;
                stockGrid.DisableReadOnlyColumn = false;

                codeEd.MaxLength = myDataSet.portfolio.codeColumn.MaxLength;
                nameEd.MaxLength = myDataSet.portfolio.nameColumn.MaxLength;
                descriptionEd.MaxLength = myDataSet.portfolio.descriptionColumn.MaxLength;
                
                codeEd.BackColor = common.settings.sysColorDisableBG; codeEd.ForeColor = common.settings.sysColorDisableFG;
                capitalUnitLbl.Text = application.Settings.sysMainCurrencyText;

                usedAmtEd.BackColor = common.settings.sysColorHiLightBG1;
                usedAmtEd.ForeColor = common.settings.sysColorHiLightFG1;

                cashAmtEd.BackColor = common.settings.sysColorHiLightBG2;
                cashAmtEd.ForeColor = common.settings.sysColorHiLightFG2; 

                common.system.AutoFitGridColumn(stockGrid, stockNameColumn.Name);
                LockEdit(true);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("portfolio");

            codeColumn.HeaderText = language.GetString("code");
            nameColumn.HeaderText = language.GetString("name");

            xpPane_generalInfo.Caption = language.GetString("generalInfo");
            codeLbl.Text = language.GetString("code");
            nameLbl.Text = language.GetString("name");
            descriptionLbl.Text = language.GetString("description");

            xpPanel_Investment.Caption = language.GetString("investment");
            capitalAmtLbl.Text = language.GetString("capitalAmt");
            usedAmtLbl.Text = language.GetString("usedAmt");
            cashAmtLbl.Text = language.GetString("cashAmt");
            maxBuyAmtPercLbl.Text = language.GetString("maxBuyAmtPercent");
            maxAccumulatePercLbl.Text = language.GetString("maxAccumulatePercent");
            maxReducePercLbl.Text = language.GetString("maxReducePercent");

            xpPane_ownedStock.Caption = language.GetString("ownedList");
            stockCodeColumn.HeaderText = language.GetString("code");
            stockNameColumn.HeaderText = language.GetString("name");
            qtyColumn.HeaderText = language.GetString("qty");
        }

        private void CalculateCashAmt()
        {
            if (this.portfolioSource.Current == null) return;
            data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;
            cashAmtEd.Value = row.startCapAmt - row.usedCapAmt;
            cashAmtEd.Refresh();
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
        public static portfolioEdit GetForm()
        {
            string cacheKey = typeof(portfolioEdit).FullName;
            portfolioEdit form = (portfolioEdit)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new portfolioEdit();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        protected void UpdateEditStatus()
        {
            ShowReccount((this.portfolioSource.Position + 1).ToString() + "/" + this.portfolioSource.Count.ToString());
        }
        protected void LoadDetailData()
        {
            if (this.portfolioSource.Current == null) return;
            data.baseDS.portfolioRow portfolioRow = (data.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;

            //Investor stock
            this.myDataSet.investorStock.Clear();
            application.dataLibs.LoadData(this.myDataSet.investorStock, portfolioRow.code);
            for (int idx = 0; idx < myDataSet.investorStock.Count; idx++)
            {
                if (myDataSet.investorStock[idx].RowState == DataRowState.Deleted) continue;
                application.dataLibs.FindAndCache(myDataSet.stockCode, myDataSet.investorStock[idx].stockCode);
            }
            //Transaction history
            myDataSet.transactions.Clear();
        }

        #region override funcs
        protected override void SetFirstFocus()
        {
            this.nameEd.Focus();
        }
        protected override void LoadData()
        {
            this.myDataSet.portfolio.Clear();
            application.dataLibs.LoadPortfolioByInvestor(this.myDataSet.portfolio, this.myInvestorCode, this.myPortfolioType);
            CalculateCashAmt();
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.nameEd.Enabled = !lockState;
            this.descriptionEd.Enabled = !lockState;

            this.capitalAmtEd.Enabled = !lockState;
            this.usedAmtEd.Enabled = !lockState;
            this.cashAmtEd.Enabled = !lockState;

            this.maxBuyAmtPercEd.Enabled = !lockState;
            this.stockAccumulatePercEd.Enabled = !lockState;
            this.stockReducePercEd.Enabled = !lockState;
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
            if (!retVal) this.ShowMessage(language.GetString("invalidData"));
            return retVal;
        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);
            row.type = (byte)this.myPortfolioType;

            common.myAutoKeyInfo info = application.sysLibs.GetAutoKey(myDataSet.portfolio.TableName, false);
            row.code = info.value.ToString().PadLeft(myDataSet.portfolio.codeColumn.MaxLength, '0');
            row.investorCode = this.myInvestorCode;
            codeEd.Text = row.code;
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
        }

        protected override bool DataChanged()
        {
            return false;
        }

        #endregion override funcs

        #region event handler
        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowError(e.Exception);
        }
        private void portfolioSource_CurrentChanged(object sender, EventArgs e)
        {
            bool saveOnProccessing = this.fOnProccessing;
            try
            {
                if (this.fOnProccessing) return;
                this.fOnProccessing = true;
                CalculateCashAmt();
                UpdateEditStatus();
                LoadDetailData();
                this.fOnProccessing = saveOnProccessing;
            }
            catch (Exception er)
            {
                this.fOnProccessing = saveOnProccessing;
                ShowError(er);
            }
        }
        private void basePortfolioEdit_Resize(object sender, EventArgs e)
        {
            try
            {
                xpPanelGroup_Info.Height = this.ClientRectangle.Height - this.xpPanelGroup_Info.Location.Y - SystemInformation.CaptionHeight+3;
                xpPane_ownedStock.Height = xpPanelGroup_Info.Height - xpPane_ownedStock.Location.Y;
                if (xpPane_ownedStock.Height < 150) xpPane_ownedStock.Height = 150;
                common.system.AutoFitGridColumn(portfolioGrid, nameColumn.Name);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void capitalAmtEd_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                CalculateCashAmt();
            }
            catch (Exception er)
            {
                ShowError(er);
            }

        }
        #endregion event handler
    }
}