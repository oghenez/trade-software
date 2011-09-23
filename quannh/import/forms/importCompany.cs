using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LumenWorks.Framework.IO.Csv;


namespace imports.forms
{
    public partial class importCompany : common.forms.baseForm
    {
        public importCompany()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void Import()
        {
            this.ShowMessage("");
            myDataSet.stockCode.Clear();

            myDataSet.stockExchange.Clear();
            application.dataLibs.LoadData(myDataSet.stockCode);

            this.ShowMessage(" Import from sheet : " + dataFileNameEd.Text);
            common.fileFuncs.WriteLog("Import from sheet : " + dataFileNameEd.Text);
            DataTable tbl = new DataTable();
            common.import.ImportFromExcel(dataFileNameEd.Text, (StringCollection)null, "*", true, tbl);
            Import_ValidateData(tbl);
            if (Import_UpdateStockCode(tbl)) this.ShowMessage("Hoàn tất");
            //common.Export.ExportToExcel(tbl.DefaultView.ToTable(), "d://tmp.xls");
            
        }
        //Fill empty cells with the above one and delete empty rows
        private static void Import_ValidateData(DataTable tbl)
        {
        }

        //Add to database
        private bool Import_UpdateStockCode(DataTable tbl)
        {
            data.baseDS.stockCodeRow stockCodeRow;
            string comCode = "",stockExchangeCode = "";
            data.baseDS.stockExchangeRow stockExchangeRow;
            
            myDataSet.stockCode.Clear();
            myDataSet.stockExchange.Clear();
            try
            {
                progressBar.Value = 0; progressBar.Maximum = tbl.Rows.Count;
                for (int count = 0; count < tbl.Rows.Count; count++)
                {
                    progressBar.Value++;
                    Application.DoEvents();

                    if (tbl.Rows[count].RowState == DataRowState.Deleted) continue;

                    this.ShowMessage("Import : " +tbl.Rows[count][0].ToString().Trim());
                    // Stock Exchange
                    stockExchangeCode = tbl.Rows[count][1].ToString().Trim();
                    stockExchangeRow = libs.AddStockExchange(myDataSet.stockExchange, stockExchangeCode);
                    //stockCode
                    comCode = tbl.Rows[count][0].ToString().Trim();
                    stockCodeRow = application.dataLibs.FindAndCache(myDataSet.stockCode, comCode);
                    if (stockCodeRow == null)
                    {
                        stockCodeRow = myDataSet.stockCode.NewstockCodeRow();
                        application.dataLibs.InitData(stockCodeRow);
                        stockCodeRow.code = comCode;
                        stockCodeRow.tickerCode = comCode;
                        stockCodeRow.code = comCode;
                        stockCodeRow.regDate = DateTime.Today;
                        stockCodeRow.stockExchange = stockExchangeCode;
                        stockCodeRow.status = (byte)application.AppTypes.CommonStatus.Enable;
                        myDataSet.stockCode.AddstockCodeRow(stockCodeRow);
                    }
                    stockCodeRow.name = tbl.Rows[count][25].ToString().Trim();
                    stockCodeRow.nameEn = tbl.Rows[count][26].ToString().Trim();
                    stockCodeRow.address1 = tbl.Rows[count][27].ToString().Trim();
                    stockCodeRow.phone = tbl.Rows[count][28].ToString().Trim();
                    stockCodeRow.fax = tbl.Rows[count][29].ToString().Trim();
                    stockCodeRow.website = tbl.Rows[count][30].ToString().Trim();

                    //Stock Code
                    stockCodeRow.stockExchange = stockExchangeCode;
                    stockCodeRow.noOutstandingStock = (int)GetNum(tbl.Rows[count][15].ToString());
                    stockCodeRow.noListedStock = (int)GetNum(tbl.Rows[count][16].ToString());
                    stockCodeRow.noTreasuryStock = (int)GetNum(tbl.Rows[count][17].ToString());
                    stockCodeRow.noForeignOwnedStock = (int)GetNum(tbl.Rows[count][18].ToString());

                    stockCodeRow.bookPrice = GetNum(tbl.Rows[count][3].ToString()) * application.Settings.sysStockPriceWeight;
                    stockCodeRow.sales = GetNum(tbl.Rows[count][20].ToString());
                    stockCodeRow.profit = GetNum(tbl.Rows[count][21].ToString());

                    stockCodeRow.PB = GetNum(tbl.Rows[count][4].ToString())*100;
                    stockCodeRow.EPS = GetNum(tbl.Rows[count][7].ToString());
                    stockCodeRow.PE = GetNum(tbl.Rows[count][8].ToString());
                    stockCodeRow.ROA = GetNum(tbl.Rows[count][11].ToString());
                    stockCodeRow.ROE = GetNum(tbl.Rows[count][12].ToString());
                    stockCodeRow.BETA = GetNum(tbl.Rows[count][14].ToString());

                    stockCodeRow.workingCap = GetNum(tbl.Rows[count][19].ToString());
                    stockCodeRow.equity = GetNum(tbl.Rows[count][22].ToString());
                    stockCodeRow.totalDebt = GetNum(tbl.Rows[count][23].ToString());
                    stockCodeRow.totaAssets = GetNum(tbl.Rows[count][24].ToString());
                    application.dataLibs.UpdateData(stockCodeRow);
                }
            }
            catch (Exception er)
            {
                common.system.ShowErrorMessage(er.Message);
                return false;
            }
            return true;
        }

        private decimal GetNum(string str)
        {
            decimal d=0;
            if (str.Contains("%")) 
            {
                str = str.Replace("%","");
            }
            decimal.TryParse(str, out d);
            return d;
        }

        private bool ValidateImport()
        {
            bool retVal = true;
            ClearNotifyError();
            this.ShowMessage("");
            if (dataFileNameEd.Text.Trim() == "")
            {
                NotifyError(dataFileLbl);
                retVal = false;
            }
            return retVal;
        }
        
        private void importBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!ValidateImport()) return;
                progressBar.Visible = true;
                importBtn.Enabled = false;
                viewLogBtn.Enabled = false;
                ShowCurrorWait();
                Import();
                ShowCurrorDefault();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                importBtn.Enabled = true;
                viewLogBtn.Enabled = true;
                progressBar.Visible = false;
            }
        }
        private void selectFileBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataFileNameEd.Text = openFileDialog.FileName.Trim();
                }
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewLogBtn_Click(object sender, EventArgs e)
        {
            try
            {
                common.fileFuncs.DisplayFile(common.fileFuncs.myLogFileName);
            }
            catch (Exception er)
            {
                ShowError(er);
            }
        }
    }
}
