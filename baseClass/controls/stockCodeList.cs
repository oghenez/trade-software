using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace baseClass.controls
{
    public partial class stockCodeList : common.controls.baseListEdit2
    {
        public delegate void StockCodeSelectionChange(object sender, EventArgs e);
        public event StockCodeSelectionChange myStockCodeSelectionChange = null;

        public stockCodeList()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }            
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            stockCodeLb.SetLanguage();
        }

        protected override common.controls.baseListBox CreateListObj()
        {
            stockCodeLb.SelectionMode = SelectionMode.MultiExtended;
            return stockCodeLb;
        }
        protected override common.forms.baseListSelection CreateCodeSelectionForm()
        {
            return new forms.stockSelectionForm();
        }

        private void stockCodeLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (myStockCodeSelectionChange==null) return;
                myStockCodeSelectionChange(sender, e);
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);
            }            
        }
    }
}
