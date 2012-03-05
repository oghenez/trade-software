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
using application;


namespace Imports.Forms
{
    public partial class reAggregatePrice : common.forms.baseForm
    {
        public reAggregatePrice()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                ClearNotifyError();
                codeEd.Text = codeEd.Text.Trim();
                if (codeEd.Text == "")
                {
                    NotifyError(codeLbl);
                    return; 
                }

                ClearNotifyError();
                this.ShowMessage("");
                this.ShowMessage("");
                okBtn.Enabled = false;
                ShowCurrorWait();

                CultureInfo stockCulture = application.AppLibs.GetStockCulture(codeEd.Text);
                databases.AppLibs.ReAggregatePriceData(codeEd.Text, stockCulture);
                this.ShowMessage("Hòan tất");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                progressBar.Visible = false;
                okBtn.Enabled = true;
                progressBar.Visible = false;
                ShowCurrorDefault();
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
