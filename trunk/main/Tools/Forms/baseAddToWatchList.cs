﻿using System;
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
    public partial class baseAddToWatchList : baseClass.forms.baseDialogForm  
    {
        public baseAddToWatchList()
        {
            try
            {
                InitializeComponent();
                watchListLb.WatchType = application.AppTypes.PortfolioTypes.WatchList;
            }
            catch(Exception er)
            {
                this.ShowError(er);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("addToWatchList");
            addToLbl.Text = language.GetString("addToWatchList");
            newWatchListBtn.Text = language.GetString("addNew");
            watchListLb.SetLanguage();
        }

        protected virtual void SaveData(){}
        protected virtual bool DataValid() 
        {
            errorProvider.Clear();
            if (watchListLb.myCheckedValues.Count == 0)
            {
                errorProvider.SetError(addToLbl, "Invalid data");
                return false;
            }
            return true;
        }
        private void Form_myOnProcess(object sender, common.baseDialogEvent e)
        {
            this.ShowMessage("");
            if (myFormStatus.isCloseClick)
            {
                myFormStatus.acceptClose = true;
                return;
            }
            if (!DataValid()) return;
            SaveData();
            myFormStatus.acceptClose = true;
        }
        private void newWatchListBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowMessage("");
                baseClass.forms.watchListNew form = baseClass.forms.watchListNew.GetForm();
                data.baseDS.portfolioRow row = form.ShowNew(AppTypes.PortfolioTypes.WatchList, sysLibs.sysLoginCode);
                if (row == null) return;
                watchListLb.LoadData(sysLibs.sysLoginCode, false);
                StringCollection list = watchListLb.myCheckedValues;
                if (!list.Contains(row.code))
                {
                    list.Add(row.code);
                    watchListLb.myCheckedValues = list;
                }
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
