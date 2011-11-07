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
    public partial class importComSector : common.forms.baseForm
    {
        DataView mySubSectorView = null;
        public importComSector()
        {
            try
            {
                InitializeComponent();
                bizIndustryClb.LoadData();
                bizIndustryClb.CheckAll(true); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void Import()
        {
            this.ShowMessage("");
            DataTable tbl = new DataTable();
            ArrayList tmpList = bizIndustryClb.myCheckedItems;

            myDataSet.stockCode.Clear();
            myDataSet.bizSubSector.Clear();

            application.dataLibs.LoadStockCode_ByStatus(myDataSet.stockCode,application.AppTypes.CommonStatus.Enable);
            application.dataLibs.LoadData(myDataSet.bizSubSector);

            mySubSectorView = new DataView(myDataSet.bizSubSector);
            mySubSectorView.Sort = myDataSet.bizSubSector.description1Column.ColumnName;

            //Clear all sector before update
            for (int idx = 0; idx < myDataSet.stockCode.Count; idx++) myDataSet.stockCode[idx].bizSectors = "";
            for (int idx = 0; idx < tmpList.Count; idx++)
            {
                tbl.Clear();
                this.ShowMessage(" Import from sheet : " + tmpList[idx].ToString());
                common.fileFuncs.WriteLog("Import from sheet : " + tmpList[idx].ToString());
                common.import.ImportFromExcel(dataFileNameEd.Text, tmpList[idx].ToString(), "*", false, tbl);
                Import_ValidateData(tbl);
                //Add to database
                Import_UpdateSectors(tbl);
                Application.DoEvents();
            }
            common.fileFuncs.WriteLog(common.Consts.constCRLF + "Companies do not have sectors");
            for (int idx = 0; idx < myDataSet.stockCode.Count; idx++)
            {
                if (myDataSet.stockCode[idx].bizSectors.Trim() != "") continue;
                common.fileFuncs.WriteLog(" - " + myDataSet.stockCode[idx].code + common.Consts.constTab + myDataSet.stockCode[idx].name);
            }
            //common.Export.ExportToExcel(tbl.DefaultView.ToTable(), "d://tmp.xls");
            this.ShowMessage("Hoàn tất");
        }
        //Fill empty cells with the above one and delete empty rows
        private static void Import_ValidateData(DataTable tbl)
        {
            //int num = 0;
            //for (int idx = 0; idx < tbl.Rows.Count; idx++)
            //{
            //    //If  subSector is Null,assume that it is an empty roe, delete it
            //    if (!int.TryParse(tbl.Rows[idx][0].ToString().Trim(),out num))
            //    {
            //        tbl.Rows[idx].Delete(); continue;
            //    }
            //}
        }

        //Add to database
        private void Import_UpdateSectors(DataTable tbl)
        {
            data.baseDS.stockCodeRow stockCodeRow;
            string comCode = "", comName, subSectorDesc;

            DataRowView[] foundRows;
            string foundSectorCode;
            int num = 0;
            for (int count = 0; count < tbl.Rows.Count; count++)
            {
                if (tbl.Rows[count].RowState == DataRowState.Deleted) continue;
                //If  subSector is Null,assume that it is an empty row, delete it
                if (!int.TryParse(tbl.Rows[count][0].ToString().Trim(), out num))
                {
                    tbl.Rows[count].Delete(); continue;
                }

                //stockCode
                comCode = tbl.Rows[count][1].ToString().Trim();
                comName = tbl.Rows[count][3].ToString().Trim();
                stockCodeRow = myDataSet.stockCode.FindBycode(comCode);
                if (stockCodeRow == null)
                {
                    stockCodeRow = myDataSet.stockCode.NewstockCodeRow();
                    application.dataLibs.InitData(stockCodeRow);
                    stockCodeRow.code = comCode;
                    stockCodeRow.name = "<New>";
                    stockCodeRow.regDate = DateTime.Today;
                    stockCodeRow.stockExchange = tbl.Rows[count][2].ToString().Trim(); ;
                    myDataSet.stockCode.AddstockCodeRow(stockCodeRow);
                    common.fileFuncs.WriteLog(" - New stockCode " + common.Consts.constTab + comCode + common.Consts.constTab + " at " + comName);
                }
                //subSector ->code
                subSectorDesc = tbl.Rows[count][5].ToString().Trim();
                foundRows = mySubSectorView.FindRows(subSectorDesc);
                if (foundRows.Length == 0)
                {
                    mySubSectorView.RowFilter = myDataSet.bizSubSector.description1Column.ColumnName +
                                              " LIKE '" + subSectorDesc + common.Consts.SQL_CMD_ALL_MARKER + "'";

                    if (mySubSectorView.Count > 0)
                    {
                        foundSectorCode = mySubSectorView[0][myDataSet.bizSubSector.codeColumn.ColumnName].ToString();
                        common.fileFuncs.WriteLog(" - Match subsector " + common.Consts.constTab + subSectorDesc + common.Consts.constTab + "->" + common.Consts.constTab +
                                  mySubSectorView[0][myDataSet.bizSubSector.description1Column.ColumnName].ToString() + common.Consts.constTab + " at " + comCode);
                    }
                    else
                    {
                        foundSectorCode = null;
                        common.fileFuncs.WriteLog(" - New subsector " + common.Consts.constTab + subSectorDesc + common.Consts.constTab + "at " + comCode);
                    }
                    mySubSectorView.RowFilter = "";
                }
                else foundSectorCode = foundRows[0][myDataSet.bizSubSector.codeColumn.ColumnName].ToString();

                if (foundSectorCode != null)
                {
                    stockCodeRow.bizSectors = common.system.StrConcat(foundSectorCode,
                                                                    stockCodeRow.bizSectors,
                                                                    common.settings.sysListSeparator,
                                                                    common.settings.sysListSeparatorPrefix,
                                                                    common.settings.sysListSeparatorPostfix);
                }
            }
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
