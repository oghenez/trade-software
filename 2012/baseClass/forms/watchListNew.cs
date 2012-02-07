using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using application;
using commonClass;

namespace baseClass.forms
{
    public partial class watchListNew : baseForm
    {
        data.baseDS.portfolioDataTable myPortfolioTbl = new data.baseDS.portfolioDataTable();
        public watchListNew()
        {
            try
            {
                InitializeComponent();
                codeEd.MaxLength = myPortfolioTbl.codeColumn.MaxLength;
                nameEd.MaxLength = myPortfolioTbl.nameColumn.MaxLength;
                descriptionEd.MaxLength = myPortfolioTbl.descriptionColumn.MaxLength;
                codeEd.BackColor = common.Settings.sysColorDisableBG; codeEd.ForeColor = common.Settings.sysColorDisableFG;
                LockEdit(false);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private string myInvestorCode = null;
        private AppTypes.PortfolioTypes myPortfolioType = AppTypes.PortfolioTypes.Portfolio;
        public static watchListNew GetForm()
        {
            string cacheKey = typeof(watchListNew).FullName;
            watchListNew form = (watchListNew)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new watchListNew();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        public data.baseDS.portfolioRow ShowNew(AppTypes.PortfolioTypes type,string investorCode)
        {
            codeEd.Text = commonClass.Consts.constNotMarkerNEW;
            nameEd.Text = "";
            descriptionEd.Text = "";

            this.nameEd.Focus();
            this.myInvestorCode = investorCode;
            this.myPortfolioType = type;
            this.ShowDialog();
            return (myPortfolioTbl.Count>0?myPortfolioTbl[0]:null);
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("watchList");
            this.codeLbl.Text = Languages.Libs.GetString("code");
            this.nameLbl.Text = Languages.Libs.GetString("name");
            this.descriptionLbl.Text = Languages.Libs.GetString("description");
            this.saveBtn.Text = Languages.Libs.GetString("save");
            this.exitBtn.Text = Languages.Libs.GetString("close");
        }

        protected bool DataValid()
        {
            ClearNotifyError();
            bool retVal = true;
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
            return retVal;
        }
        protected void SaveData()
        {
            data.baseDS.portfolioRow portfolioRow;
            if (myPortfolioTbl.Count == 0)
            {
                portfolioRow = myPortfolioTbl.NewportfolioRow();
                commonClass.AppLibs.InitData(portfolioRow);
                portfolioRow.code = commonClass.Consts.constNotMarkerNEW;
                myPortfolioTbl.AddportfolioRow(portfolioRow);
            }
            else portfolioRow = myPortfolioTbl[0];
            portfolioRow.type = (byte)this.myPortfolioType;
            portfolioRow.investorCode = this.myInvestorCode;
            portfolioRow.name = nameEd.Text;
            portfolioRow.description = descriptionEd.Text;
            portfolioRow = DataAccess.Libs.UpdateData(myPortfolioTbl[0]);
            codeEd.Text = portfolioRow.code;
        }

        #region event handler
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid()) return;
                SaveData();
                this.Close();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion event handler
    }
}