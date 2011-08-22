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
            myDataSet.company.Clear();
            myDataSet.stockCode.Clear();

            myDataSet.stockExchange.Clear();
            application.dataLibs.LoadData(myDataSet.company);
            application.dataLibs.LoadData(myDataSet.stockCode, ((byte)application.myTypes.commonStatus.All).ToString());

            this.ShowMessage(" Import from sheet : " + dataFileNameEd.Text);
            common.fileFuncs.WriteLog("Import from sheet : " + dataFileNameEd.Text);
            DataTable tbl = new DataTable();
            common.import.ImportFromExcel(dataFileNameEd.Text, (StringCollection)null, "*", true, tbl);
            Import_ValidateData(tbl);
            Import_UpdateCompany(tbl);
            //common.Export.ExportToExcel(tbl.DefaultView.ToTable(), "d://tmp.xls");
            this.ShowMessage("Hoàn tất");
        }
        //Fill empty cells with the above one and delete empty rows
        private static void Import_ValidateData(DataTable tbl)
        {
        }

        //Add to database
        private void Import_UpdateCompany(DataTable tbl)
        {
            data.baseDS.companyRow companyRow;
            data.baseDS.stockCodeRow stockCodeRow;
            string comCode = "",stockExchangeCode = "";
            data.baseDS.stockExchangeRow stockExchangeRow;
            decimal d = 0;  int num=0;

            progressBar.Value = 0; progressBar.Maximum = tbl.Rows.Count; 
            for (int count = 0; count < tbl.Rows.Count; count++)
            {
                progressBar.Value++;
                Application.DoEvents();

                if (tbl.Rows[count].RowState == DataRowState.Deleted) continue;
                //Company
                comCode = tbl.Rows[count][0].ToString().Trim();
                companyRow = myDataSet.company.FindBycode(comCode);
                if (companyRow == null)
                {
                    companyRow = myDataSet.company.NewcompanyRow();
                    application.dataLibs.InitData(companyRow);
                    companyRow.code = comCode;
                    companyRow.estDate = DateTime.Today;
                    myDataSet.company.AddcompanyRow(companyRow);
                }
                if(decimal.TryParse(tbl.Rows[count][6].ToString().Trim(),out d)) companyRow.capital = d;
                companyRow.name = tbl.Rows[count][8].ToString().Trim();
                companyRow.nameEn = tbl.Rows[count][9].ToString().Trim();
                companyRow.address1 = tbl.Rows[count][10].ToString().Trim();
                companyRow.phone = tbl.Rows[count][11].ToString().Trim();
                companyRow.fax = tbl.Rows[count][12].ToString().Trim();
                companyRow.website = tbl.Rows[count][13].ToString().Trim();

                //Stock Code
                stockExchangeCode = tbl.Rows[count][1].ToString().Trim();
                stockExchangeRow = application.dataLibs.FindAndCache(myDataSet.stockExchange, stockExchangeCode);
                if (stockExchangeRow == null)
                {
                    common.fileFuncs.WriteLog(" - StockExchange" + common.Consts.constTab + stockExchangeCode + common.Consts.constTab + "not found.");
                    continue;
                }
                stockCodeRow = myDataSet.stockCode.FindBycode(comCode);
                if (stockCodeRow == null)
                {
                    stockCodeRow = myDataSet.stockCode.NewstockCodeRow();
                    application.dataLibs.InitData(stockCodeRow);
                    stockCodeRow.tickerCode = comCode;
                    stockCodeRow.code = comCode;
                    stockCodeRow.comCode = comCode;
                    stockCodeRow.regDate = DateTime.Today;
                    stockCodeRow.stockExchange = tbl.Rows[count][2].ToString().Trim();
                    stockCodeRow.status = (byte)application.myTypes.commonStatus.Enable; 
                    myDataSet.stockCode.AddstockCodeRow(stockCodeRow);
                }
                if (int.TryParse(tbl.Rows[count][2].ToString(), out num)) stockCodeRow.noOpenShares = num;
                if (int.TryParse(tbl.Rows[count][3].ToString(), out num)) stockCodeRow.noShares = num;
                if (int.TryParse(tbl.Rows[count][5].ToString(), out num)) stockCodeRow.noForeignOwnShares = num;
                stockCodeRow.stockExchange = stockExchangeCode;
            }
            application.dataLibs.UpdateData(myDataSet.company);
            application.dataLibs.UpdateData(myDataSet.stockCode);
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
