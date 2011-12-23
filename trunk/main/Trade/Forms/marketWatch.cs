using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trade.Forms
{
    public partial class marketWatch : baseClass.forms.baseForm 
    {
        public marketWatch()
        {
            try
            {
                InitializeComponent();
                this.stockCodeList.myGridView.RowHeadersVisible = false;
                this.stockCodeList.SetColumnVisibility(baseClass.controls.stockCodeSelectByWatchList.gridColumnName.StockExCode,false);

                this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        // See Making Thread-Safe Calls by using BackgroundWorker
        // http://msdn.microsoft.com/en-us/library/ms171728.aspx
        private BackgroundWorker bgWorker = new BackgroundWorker();

        public void RefreshData()
        {
            this.bgWorker.RunWorkerAsync();
        }
        public ContextMenuStrip myContextMenuStrip
        {
            get { return stockCodeList.myContextMenuStrip; }
            set { this.stockCodeList.myContextMenuStrip = value; }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            stockCodeList.SetLanguage();
        }
        public void Export()
        {
            stockCodeList.Export();
        }

        public delegate void onShowChart(data.baseDS.stockCodeRow stockRow);
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
        public data.tmpDS.stockCodeRow CurrentRow
        {
            get
            {
                return stockCodeList.CurrentRow;
            }
        }

        private void stockCodeList_myOnError(object sender, EventArgs e)
        {
            this.ShowMessage(e.ToString());
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
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                stockCodeList.RefreshPrice();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
