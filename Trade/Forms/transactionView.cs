using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trade.Forms
{
    public partial class transactionView : transactionBase
    {
        public transactionView()
        {
            InitializeComponent();
        }
        public static transactionView GetForm(string formName)
        {
            string cacheKey = typeof(transactionView).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            transactionView form = (transactionView)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new transactionView();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }
    }
}
