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
    public partial class reUpdatePrice : common.forms.baseForm
    {
        public reUpdatePrice()
        {
            InitializeComponent();
            dateRangeEd.frDate = common.dateTimeLibs.MakeDate(1, 10, 2011);
            dateRangeEd.toDate = DateTime.Today;
        }

        private void importBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                ClearNotifyError();
                this.ShowMessage("");
                if (!dateRangeEd.GetDateRange()) return;
                this.ShowMessage("");
                importBtn.Enabled = false;
                ShowCurrorWait();
                myImportDS.importPrice.Clear();

                DateTime curDate = dateRangeEd.frDate;
                DateTime endDate = dateRangeEd.toDate;

                progressBar.Visible = true;
                progressBar.Maximum = common.dateTimeLibs.DateDiffInDays(curDate, endDate)+1;
                progressBar.Value = 0;
                while (curDate <= endDate)
                {
                    libs.ReImportPricedata(curDate, curDate.AddDays(1).AddMinutes(-1), codeEd.Text);
                    curDate = curDate.AddDays(1);
                    if (progressBar.Value<progressBar.Maximum) progressBar.Value++;
                    Application.DoEvents();
                }
                this.ShowMessage("Hòan tất");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                progressBar.Visible = false;
                importBtn.Enabled = true;
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
