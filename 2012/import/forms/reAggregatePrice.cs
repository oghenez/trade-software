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
        bool fCanceled = false;
        private void okBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                ClearNotifyError();
                codeEd.Text = codeEd.Text.Trim();
                if (codeChk.Checked &&  codeEd.Text == "")
                {
                    NotifyError(codeChk);
                    return; 
                }

                ClearNotifyError();
                this.ShowMessage("");
                this.ShowMessage("");
                okBtn.Enabled = false;
                codeChk.Enabled = false;
                codeEd.Enabled = false;

                ShowCurrorWait();
                fCanceled = false;
                
                System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
                stopWatch.Start();

                CultureInfo stockCulture = application.AppLibs.GetStockCulture(codeEd.Text);
                if (codeChk.Checked)
                {
                    databases.AppLibs.ReAggregatePriceData(codeEd.Text, stockCulture);
                }
                else
                {
                    databases.baseDS.stockCodeDataTable tbl = new databases.baseDS.stockCodeDataTable();
                    databases.DbAccess.LoadData(tbl);
                    for (int idx = 0; idx < tbl.Count; idx++)
                    {
                        if (fCanceled) break;
                        this.ShowMessage(tbl[idx].code);
                        databases.AppLibs.ReAggregatePriceData(tbl[idx].code, stockCulture);
                        this.ShowMessage("");
                        Application.DoEvents();
                    }
                }
                stopWatch.Stop();
                this.ShowMessage("Hòan tất " + common.dateTimeLibs.TimeSpan2String(stopWatch.Elapsed));
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                progressBar.Visible = false;
                okBtn.Enabled = true;
                codeChk.Enabled = true;
                codeChk_CheckedChanged(null,null);

                progressBar.Visible = false;
                ShowCurrorDefault();
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            fCanceled = true;
            this.Close();
        }

        private void codeChk_CheckedChanged(object sender, EventArgs e)
        {
            codeEd.Enabled = codeChk.Checked;
        }
    }
}
