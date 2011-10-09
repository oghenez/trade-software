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

namespace baseClass.forms
{
    public partial class sysInterestedStrategy : baseForm 
    {
        public sysInterestedStrategy()
        {
            try
            {
                InitializeComponent();
                interestedStrategy.Init();
                LoadData();
                LockEdit(false);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("interestedStrategy");

            saveBtn.Text = language.GetString("save");
            refreshBtn.Text = language.GetString("reload");
            exitBtn.Text = language.GetString("close");
        }

        private void LoadData()
        {
            data.baseDS.portfolioRow sysPortfolioRow = dataLibs.GetSystemPortfolio();
            data.baseDS.portfolioDetailDataTable myPortfolioDetailTbl = new data.baseDS.portfolioDetailDataTable();
            application.dataLibs.LoadSysPortfolio(myPortfolioDetailTbl);
            interestedStrategy.myDataTbl = myPortfolioDetailTbl;

            interestedStrategy.myPorfolioCode = sysPortfolioRow.code;
            interestedStrategy.myStockCode = sysPortfolioRow.code;
            interestedStrategy.Refresh();
        }

        public static sysInterestedStrategy GetForm(string formName)
        {
            string cacheKey = typeof(sysInterestedStrategy).FullName + (formName != null && formName.Trim() == "" ? "-" + formName.Trim() : "");
            sysInterestedStrategy form = (sysInterestedStrategy)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new sysInterestedStrategy();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        private bool DataChanged()
        {
            return (interestedStrategy.myDataTbl.GetChanges() != null && interestedStrategy.myDataTbl.GetChanges().Rows.Count > 0);
        }
        #region event handler
       
        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                dataLibs.UpdateData(interestedStrategy.myDataTbl);
                this.ShowMessage(language.GetString("dataSaved"));
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
        private void sysInterestedStrategy_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!DataChanged()) return;
                DialogResult dialogResult = MessageBox.Show(language.GetString("saveDataBeforeClose"), common.settings.sysApplicationName, 
                                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult== DialogResult.Cancel)
                {
                    e.Cancel=true;
                    return;
                }
                if (dialogResult== DialogResult.Yes)
                {
                    application.dataLibs.UpdateData(interestedStrategy.myDataTbl);
                    this.ShowMessage(language.GetString("dataSaved"));
                }
            }
            catch (Exception er)
            {
                e.Cancel = true;
                this.ShowError(er);
            }
        }
        private void interestedStrategy_Load(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}