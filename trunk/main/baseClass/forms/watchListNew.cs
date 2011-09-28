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
    public partial class watchListNew : baseForm
    {
        public watchListNew()
        {
            try
            {
                InitializeComponent();
                codeEd.MaxLength = myDataSet.portfolio.codeColumn.MaxLength;
                nameEd.MaxLength = myDataSet.portfolio.nameColumn.MaxLength;
                descriptionEd.MaxLength = myDataSet.portfolio.descriptionColumn.MaxLength;
                codeEd.BackColor = common.settings.sysColorDisableBG; codeEd.ForeColor = common.settings.sysColorDisableFG;
                LockEdit(false);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private string myInvestorCode = null;
        private application.AppTypes.PortfolioTypes myPortfolioType = application.AppTypes.PortfolioTypes.Portfolio;
        private data.baseDS.portfolioRow myPortfolioRow = null;
        public static watchListNew GetForm()
        {
            string cacheKey = typeof(watchListNew).FullName;
            watchListNew form = (watchListNew)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new watchListNew();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
        public data.baseDS.portfolioRow ShowNew(application.AppTypes.PortfolioTypes type,string investorCode)
        {
            codeEd.Text="";
            nameEd.Text = "";
            descriptionEd.Text = "";

            this.nameEd.Focus();
            this.myInvestorCode = investorCode;
            this.myPortfolioType = type;
            this.myPortfolioRow = null;
            this.ShowDialog();
            return this.myPortfolioRow;
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
            this.myPortfolioRow = null;
            if (codeEd.Text.Trim() != "")
            {
                this.myPortfolioRow = application.dataLibs.FindAndCache(myDataSet.portfolio, codeEd.Text);
            }
            if (this.myPortfolioRow == null)
            {
                this.myPortfolioRow = myDataSet.portfolio.NewportfolioRow();
                application.dataLibs.InitData(this.myPortfolioRow);
                common.myAutoKeyInfo info = application.sysLibs.GetAutoKey(myDataSet.portfolio.TableName, false);
                this.myPortfolioRow.code = info.value.ToString().PadLeft(myDataSet.portfolio.codeColumn.MaxLength, '0');
                codeEd.Text = this.myPortfolioRow.code;
                myDataSet.portfolio.AddportfolioRow(this.myPortfolioRow);
            }
            this.myPortfolioRow.type = (byte)this.myPortfolioType;
            this.myPortfolioRow.investorCode = this.myInvestorCode;
            this.myPortfolioRow.name = nameEd.Text;
            this.myPortfolioRow.description = descriptionEd.Text;
            application.dataLibs.UpdateData(this.myPortfolioRow);
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
            this.myPortfolioRow = null;
            this.Close();
        }
        #endregion event handler
    }
}