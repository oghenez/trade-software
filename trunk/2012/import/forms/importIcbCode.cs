using System;
using System.Collections.Generic;
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
    public partial class importIcbCode : common.forms.baseForm
    {
        public importIcbCode()
        {
            InitializeComponent();
            sysCodeCatEd.isToUpperCase = true;
        }

        private void ImportICB()
        {
            this.ShowMessage("");
            string flds = "Industry,Supersector,Sector,Subsector,Definition";
            data.importDS.icbCodeDataTable icbTbl = new data.importDS.icbCodeDataTable();
            common.import.ImportFromExcel(dataFileNameEd.Text, sheetNameEd.Text, flds, true, icbTbl);
            ImportICB_ValidateData(icbTbl);
            
            //Add to database
            string sysCodeCat = sysCodeCatEd.Text.Trim();
            data.baseDS.sysCodeDataTable sysCodeTbl = new data.baseDS.sysCodeDataTable();
            ImportICB_AddToDb(icbTbl, icbTbl.industryColumn.ColumnName, false, sysCodeTbl, sysCodeCat, null);
            ImportICB_AddToDb(icbTbl, icbTbl.superSectorColumn.ColumnName, false, sysCodeTbl, sysCodeCat, icbTbl.industryColumn.ColumnName);
            ImportICB_AddToDb(icbTbl, icbTbl.sectorColumn.ColumnName, false, sysCodeTbl, sysCodeCat, icbTbl.superSectorColumn.ColumnName);
            ImportICB_AddToDb(icbTbl, icbTbl.subSectorColumn.ColumnName, true, sysCodeTbl, sysCodeCat, icbTbl.sectorColumn.ColumnName);

            application.DbAccess.DeleteSysCode_ByCategory(sysCodeCat);
            application.DbAccess.UpdateData(sysCodeTbl);

            this.ShowMessage("Hòan tất");
            //ImportICB_AddToDb("ICB", icbTbl);
            //common.Export.ExportToExcel(icbTbl.DefaultView.ToTable(),"d://tmp.xls");
        }
        //Fill empty cells with the above one and delete empty rows
        private static void ImportICB_ValidateData(data.importDS.icbCodeDataTable tbl)
        {
            string lastIndusty = "", lastSupperSector = "", lastSector = "", lastSubSector = "";
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                //If  subSector is Null,assume that it is an empty roe, delete it
                if (tbl[idx].IssubSectorNull())
                {
                    tbl[idx].Delete(); continue;
                }
                if (tbl[idx].IsindustryNull()) tbl[idx].industry = lastIndusty;
                else lastIndusty = tbl[idx].industry;

                if (tbl[idx].IssuperSectorNull()) tbl[idx].superSector = lastSupperSector;
                else lastSupperSector = tbl[idx].superSector;

                if (tbl[idx].IssectorNull()) tbl[idx].sector = lastSector;
                else lastSector = tbl[idx].sector;

                if (tbl[idx].IssubSectorNull()) tbl[idx].subSector = lastSubSector;
                else lastSubSector = tbl[idx].subSector;
            }
        }

        //Add to database
        private void ImportICB_AddToDb(data.importDS.icbCodeDataTable tbl, string fldName, bool haveDefitionFld, 
                                              data.baseDS.sysCodeDataTable sysCodeTbl,string category,string codeGroupFldName)
        {
            data.baseDS.sysCodeRow sysCodeRow;
            common.myKeyValueItem item;
            for (int idx = 0; idx < tbl.Count; idx++)
            {
                if (tbl[idx].RowState == DataRowState.Deleted) continue;
                item = libs.SplitKeyValue(tbl[idx][fldName].ToString()," ");
                if (item == null)
                {
                    common.fileFuncs.WriteLog(tbl[idx][fldName].ToString() + " not found.");
                    continue;
                }
                if (sysCodeTbl.FindBycategorycode(category, item.Key) == null)
                {
                    sysCodeRow = sysCodeTbl.NewsysCodeRow();
                    commonClass.AppLibs.InitData(sysCodeRow);
                    sysCodeRow.category = category;
                    sysCodeRow.code = item.Key;
                    sysCodeRow.description1 = item.Value;
                    sysCodeRow.tag1 = fldName;
                    if (codeGroupFldName != null) sysCodeRow.inGroup = tbl[idx][codeGroupFldName].ToString();
                    if (haveDefitionFld && !tbl[idx].IsdefinitionNull()) sysCodeRow.notes = tbl[idx].definition;
                    sysCodeTbl.AddsysCodeRow(sysCodeRow);
                }
                tbl[idx][fldName] = item.Key;
            }
        }

        private bool ValidateImport()
        {
            bool retVal = true;
            ClearNotifyError();
            this.ShowMessage("");
            if (sheetNameEd.Text.Trim() == "")
            {
                NotifyError(sheetNameLbl);
                retVal = false;
            }
            if (dataFileNameEd.Text.Trim() == "")
            {
                NotifyError(dataFileLbl);
                retVal = false;
            }

            if (sysCodeCatEd.Text.Trim() == "")
            {
                NotifyError(sysCodeCatLbl);
                retVal = false;
            }
            return retVal;
        }
        
        private void importBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!ValidateImport()) return;
                viewLogBtn.Enabled = false;
                importBtn.Enabled = false;
                ShowCurrorWait();
                ImportICB();
                ShowCurrorDefault();
                return;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            finally
            {
                viewLogBtn.Enabled = true;
                importBtn.Enabled = true;
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
