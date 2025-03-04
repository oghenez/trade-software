﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trade.Forms
{
    /// <summary>
    /// Showing Market Watch form
    /// </summary>
    public partial class marketWatch : baseClass.forms.baseForm 
    {
        /// <summary>
        /// Initiate
        /// </summary>
        public marketWatch()
        {
            try
            {
                InitializeComponent();
                this.stockCodeList.myGridView.RowHeadersVisible = false;
                this.stockCodeList.SetColumnVisibility(baseClass.controls.stockCodeSelectByWatchList.gridColumnName.StockExCode,false);
                this.stockCodeList.myOnError += new common.myEventHandler(stockCodeList_onError);
                LogAccess = false;

                this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private BackgroundWorker bgWorker = new BackgroundWorker();
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                stockCodeList.RefreshData((bool)e.Argument);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public void RefreshData(bool force)
        {
            if (this.bgWorker.IsBusy) return;
            
            this.bgWorker.RunWorkerAsync(force);
        }

        public void RefreshData(baseClass.controls.stockCodeSelectByWatchList.RefreshOptions options)
        {
            stockCodeList.RefreshData(options);
        }
        
        public ContextMenuStrip myContextMenuStrip
        {
            get { return stockCodeList.myContextMenuStrip; }
            set { this.stockCodeList.myContextMenuStrip = value;}
        }

        public StringCollection mySelectedCodes
        {
            get
            {
                return stockCodeList.mySelectedCodes;
            }
        }

        /// <summary>
        /// Add to work with Grid
        /// </summary>

        public common.controls.baseDataGridView myGrid{
            get { return stockCodeList.myGridView; }
        }

        /// <summary>
        /// Set language
        /// </summary>
        public override void SetLanguage()
        {
            base.SetLanguage();
            stockCodeList.SetLanguage();
        }

        /// <summary>
        /// Export stock code list
        /// </summary>
        public void Export()
        {
            stockCodeList.Export();
        }

        public delegate void onShowChart(databases.baseDS.stockCodeRow stockRow);
        public virtual event baseClass.Events.onShowChart myOnShowChart
        {
            add
            {
                stockCodeList.myOnShowChart += value;
            }
            remove
            {
                stockCodeList.myOnShowChart -= value;
            }
        }
        public databases.tmpDS.stockCodeRow CurrentRow
        {
            get
            {
                return stockCodeList.CurrentRow;
            }
        }

        private void stockCodeList_myOnError(object sender, EventArgs e)
        {
            this.ShowError(new System.ArgumentException(e.ToString()));
        }

        private void marketWatch_Resize(object sender, EventArgs e)
        {
            try
            {
                this.stockCodeList.Height = this.ClientRectangle.Height;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void stockCodeList_onError(object sender, common.myExceptionEventArgs e)
        {
            this.ShowError(e.myException);
        }

        private void stockCodeList_Load(object sender, EventArgs e)
        {

        }

    }
}
