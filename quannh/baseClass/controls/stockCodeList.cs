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
    public partial class stockCodeList : common.control.baseListEdit2
    {
        public stockCodeList()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                ErrorHandler(this, er);;
            }            
        }
        protected override common.control.baseListBox CreateListObj()
        {
            controls.lbStockCode lbox = new controls.lbStockCode();
            lbox.SelectionMode = SelectionMode.MultiExtended;
            return lbox;
        }
        protected override common.forms.baseListSelection CreateCodeSelectionForm()
        {
            return new forms.stockSelectionForm();
        }
    }
}
