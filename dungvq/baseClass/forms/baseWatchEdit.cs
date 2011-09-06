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
    public partial class baseWatchEdit : baseMasterEdit
    {
        public baseWatchEdit()
        {
            try
            {
                InitializeComponent();
                this.LoadDataOnLoad = false;
                myMasterSource = portfolioSource;
                codeEd.MaxLength = myDataSet.portfolio.codeColumn.MaxLength;
                nameEd.MaxLength = myDataSet.portfolio.nameColumn.MaxLength;
                descriptionEd.MaxLength = myDataSet.portfolio.descriptionColumn.MaxLength;

                interestedBizSectorClb.maxLen = myDataSet.portfolio.interestedSectorColumn.MaxLength;
                interestedStockClb.maxLen = myDataSet.portfolio.interestedStockColumn.MaxLength;

                interestedStrategy.Init();
                interestedStockClb.LoadData();
                interestedBizSectorClb.LoadData();

                codeEd.BackColor = common.settings.sysColorDisableBG; codeEd.ForeColor = common.settings.sysColorDisableFG;
                usedAmtEd.BackColor = common.settings.sysColorHiLightBG1; usedAmtEd.ForeColor = common.settings.sysColorHiLightFG1;
                cashAmtEd.BackColor = common.settings.sysColorHiLightBG2; cashAmtEd.ForeColor = common.settings.sysColorHiLightFG2;

                capitalUnitLbl.Text = application.Settings.sysMainCurrencyText;

                LockEdit(true);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private string investorCode = null;

        public void ShowForm(string _investorCode, string _portfolioCode)
        {
            try
            {
                this.investorCode = _investorCode;
                this.fOnProccessing = true;
                LoadData();
                this.fOnProccessing = false;
                if (_portfolioCode == null)
                {
                    AddNew("");
                    _portfolioCode = codeEd.Text;
                }
                Goto(_portfolioCode);
                CalculateCashAmt();
                common.system.ShowForm(this, true);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                this.fOnProccessing = false;
            }
        }

        private void CalculateCashAmt()
        {
            if (this.portfolioSource.Current == null) return;
            data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;
            cashAmtEd.Value = row.startCapAmt - row.usedCapAmt;
        }
        private void Goto(string portfolioCode)
        {
            if (portfolioCode == null)
            {
                if (portfolioSource.Count > 0) portfolioSource.Position = 0;
            }
            else
            {
                for (int idx = 0; idx < portfolioSource.Count; idx++)
                {
                    if (((data.baseDS.portfolioRow)((DataRowView)portfolioSource[idx]).Row).code != portfolioCode) continue;
                    portfolioSource.Position = idx;
                    break;
                }
            }
            LoadDetailData();
        }
        protected void UpdateEditStatus()
        {
            CalculateCashAmt();
            ShowReccount((this.portfolioSource.Position + 1).ToString() + "/" + this.portfolioSource.Count.ToString());
        }
        protected void LoadDetailData()
        {
            if (this.portfolioSource.Current == null) return;
            data.baseDS.portfolioRow portfolioRow = (data.baseDS.portfolioRow)((DataRowView)this.portfolioSource.Current).Row;

            //interested strategy
            interestedStrategy.LoadData(portfolioRow.code);
        }


        #region override funcs
        protected override void SetFirstFocus()
        {
            this.nameEd.Focus();
        }
        protected override void LoadData()
        {
            this.myDataSet.portfolio.Clear();
            application.dataLibs.LoadPortfolioByInvestor(this.myDataSet.portfolio, this.investorCode, application.myTypes.PortfolioTypes.WatchList);
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            this.nameEd.Enabled = !lockState;
            this.descriptionEd.Enabled = !lockState;
            this.capitalAmtEd.Enabled = !lockState;
            this.maxBuyAmtPercEd.Enabled = !lockState;
            this.stockAccumulatePercEd.Enabled = !lockState;
            this.stockReducePercEd.Enabled = !lockState;

            this.interestedBizSectorClb.Enabled = !lockState;
            this.interestedStockClb.Enabled = !lockState;
            this.interestedStrategy.LockData(lockState);

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
            if (capitalAmtEd.Value == 0)
            {
                NotifyError(capitalAmtLbl);
                retVal = false;
            }
            if (!interestedStockClb.DataValid(false))
            {
                NotifyError(interestedStockLbl);
                retVal = false;
            }
            if (!interestedBizSectorClb.DataValid(false))
            {
                NotifyError(interestedStockLbl);
                retVal = false;
            }
            if (!retVal) this.ShowMessage("Dữ liệu không hợp lệ");
            return retVal;
        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            data.baseDS.portfolioRow row = (data.baseDS.portfolioRow)((DataRowView)myMasterSource.Current).Row;
            if (row == null) return;
            application.dataLibs.InitData(row);

            common.myAutoKeyInfo info = application.sysLibs.GetAutoKey(myDataSet.portfolio.TableName, false);
            row.code = info.value.ToString().PadLeft(myDataSet.portfolio.codeColumn.MaxLength, '0');
            row.investorCode = this.investorCode;
            codeEd.Text = row.code;
            interestedStrategy.Clear();
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

            interestedStrategy.SaveData();
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
                UpdateEditStatus();
                LoadDetailData();
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