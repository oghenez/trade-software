﻿using System;
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
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
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
        public override void Refresh()
        {
            stockCodeList.Refresh();
            base.Refresh();
        }

        private void stockCodeList_myOnError(object sender, EventArgs e)
        {
            this.ShowMessage(e.ToString());
        }
    }
}
