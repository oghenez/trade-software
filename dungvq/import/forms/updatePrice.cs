using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HtmlAgilityPack;


namespace imports.forms
{
    public partial class updatePrice : common.forms.baseForm
    {
        public updatePrice()
        {
            InitializeComponent();
            stockExchangeCb.LoadData();
        }

        private void importBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool retVal = true;
                ClearNotifyError();
                this.ShowMessage("");
                if (urlEd.Text.Trim() == "")
                {
                    NotifyError(urlLbl);
                    retVal = false;
                }
                if (stockExchangeCb.myValue.Trim() == "")
                {
                    NotifyError(stockExchangeLbl);
                    retVal = false;
                }
                if (retVal)
                {
                    this.ShowMessage("");
                    importBtn.Enabled = false;
                    ShowCurrorWait();
                    myImportDS.importPrice.Clear();
                    libs.ImportPricedata_URL(urlEd.Text.Trim(), stockExchangeCb.myValue.Trim());
                    ShowCurrorDefault();
                    this.ShowMessage("Hòan tất");
                }
                return;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                importBtn.Enabled = true;
                progressBar.Visible = false;
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
