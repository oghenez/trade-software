using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace Tools.Forms
{
    public partial class addToWatchList : common.forms.baseDialogForm
    {
        StringCollection myStockCodes = null;
        common.MultiValueString mvString = new common.MultiValueString();
        data.baseDS.portfolioDataTable portfolioTbl = new data.baseDS.portfolioDataTable();
        public addToWatchList()
        {
            try
            {
                InitializeComponent();
                watchListCb.WatchType = application.AppTypes.PortfolioTypes.WatchList;
            }
            catch(Exception er)
            {
                this.ShowError(er);
            }
        }
        public static addToWatchList GetForm(string formName)
        {
            string cacheKey = typeof(addToWatchList).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            addToWatchList form = (addToWatchList)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new addToWatchList();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        public void AddToWatchList(StringCollection stockCodes)
        {
            watchListCb.LoadData(sysLibs.sysLoginCode, false);
            this.myStockCodes = stockCodes;
            this.ShowDialog();
        }

        private void SaveWatchList()
        {
            portfolioTbl.Clear();
            data.baseDS.portfolioRow portfolioRow = dataLibs.FindAndCache(portfolioTbl, watchListCb.myValue);
            if (portfolioRow == null) return;
            mvString.myFormatString = portfolioRow.interestedStock;
            for (int idx = 0; idx < myStockCodes.Count; idx++)
            {
                mvString.Add(myStockCodes[idx]);
            }
            portfolioRow.interestedStock = mvString.myFormatString;
            dataLibs.UpdateData(portfolioRow);
            common.system.ShowMessage("Đã lưu dữ liệu.");
        }
        private void AddToWatchLish_myOnProcess(object sender, common.baseDialogEvent e)
        {
            if (myFormStatus.isCloseClick)
            {
                myFormStatus.acceptClose = true;
                return;
            }
            errorProvider.Clear();
            if (watchListCb.myValue.Trim() == "")
            {
                errorProvider.SetError(listNameLbl, "Invalid"); 
                return;
            }
            SaveWatchList();
            myFormStatus.acceptClose = true;
        }

        private void newWatchListBtn_Click(object sender, EventArgs e)
        {
            baseClass.forms.watchListNew form = baseClass.forms.watchListNew.GetForm();
            data.baseDS.portfolioRow row = form.ShowNew(AppTypes.PortfolioTypes.WatchList, sysLibs.sysLoginCode);
            if (row == null) return;
            watchListCb.LoadData(sysLibs.sysLoginCode, false);
            watchListCb.myValue = row.code;
        }
    }
}
