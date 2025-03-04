using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace baseClass.forms
{
    public partial class projectEdit : baseMasterEdit 
    {
        //private projCommentEdit myProjCommentEdit = null;
        public projectEdit()
        {
            try
            {
                InitializeComponent();
                codeEd.isToUpperCase = true;
                codeEd.MaxLength  = myDataSet.emProject.projectCodeColumn.MaxLength;
                projTitleEd.MaxLength = myDataSet.emProject.titleColumn.MaxLength;
                ownerEd.MaxLength = myDataSet.emProject.ownerColumn.MaxLength;
                descriptionEd.MaxLength = myDataSet.emProject.descriptionColumn.MaxLength;
                subjectCodeCb.maxLen = myDataSet.emProject.subjectCodeColumn.MaxLength;

                this.subjectCodeCb.DataBindings.Add(new System.Windows.Forms.Binding("myItemString", this.projectsSource, "subjectCode", true));
                this.subjectCodeCb.minSelectedItems = 1;

                this.CloseOnSave = true;
                this.allowToChangeDeleteCode = true;
                this.myFormCode = this.Name;

                projectTypeCb.LoadData();
                budgetUnitCb.LoadData();
                subjectCodeCb.LoadData();

                myDataSet.emProjComment.Clear();
                application.dataLibs.LoadData(myDataSet.emProjComment, codeEd.Text);

                myMasterSource = projectsSource;
            }
            catch (Exception ex)
            {
                common.system.ShowErrorMessage(ex.Message.ToString());
            }
        }
       
        public void ShowProject(string code)
        {
            try
            {
                if (code == null)
                {
                    AddNew("");
                    LockEdit(false);
                }
                else
                {
                    LockEdit(true);
                    myDataSet.emProject.Clear();
                    application.dataLibs.LoadData(myDataSet.emProject, code);
                }
                if (myMasterSource.Current ==null) return;
                this.SetFirstFocus();
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                common.system.ShowErrorMessage(ex.Message.ToString());
            }
        }

        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            codeEd.Enabled = !lockState;
            projectTypeCb.Enabled = !lockState;
            projTitleEd.Enabled = !lockState;
            descriptionEd.Enabled = !lockState;
            startDateEd.Enabled = !lockState;
            endDateEd.Enabled = !lockState;
            budgetEd.Enabled = !lockState;
            budgetUnitCb.Enabled = !lockState;
            subjectCodeCb.Enabled = !lockState;
            ownerEd.Enabled = !lockState; 
        }
        protected override void SetFirstFocus() { codeEd.Focus(); }
        protected override bool DataValid(bool showMsg)
        {
            this.ShowMessage("");
            bool retVal = true;
            ClearNotifyError();
            if (codeEd.Text.Trim() == "") 
            {
                NotifyError(codeLbl);
                retVal = false; 
            }
            if (projTitleEd.Text.Trim() == "")
            {
                NotifyError(projTitleLbl);
                retVal = false;
            }
            if (startDateEd.myDateTime == common.Consts.constNullDate)
            {
                NotifyError(startDateLbl);
                retVal = false;
            }
            if (ownerEd.Text.Trim() == "")
            {
                NotifyError(ownerLbl);
                retVal = false;
            }
            if (budgetEd.Value == 0)
            {
                NotifyError(budgetLbl);
                retVal = false;
            }
            if (budgetUnitCb.myValue == "")
            {
                NotifyError(budgetLbl);
                retVal = false;
            }
            if (!subjectCodeCb.DataValid(false))
            {
                NotifyError(subjectCodeLbl);
                retVal = false;
            }
            if (!retVal && showMsg) this.ShowMessage("Dữ liệu không hợp lệ.");
            return retVal;
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null)
            {
                application.dataLibs.UpdateData(myDataSet.emProject);
            }
            else
            {
                application.dataLibs.UpdateData((data.baseDS.emProjectRow)row);
            }
        }
        public override void AddNew(string code)
        {
            this.AddNewRow();
            string saveType = projectTypeCb.myValue;
            string saveCurrency = budgetUnitCb.myValue;

            data.baseDS.emProjectRow projectsRow = (data.baseDS.emProjectRow)((DataRowView)myMasterSource.Current).Row;
            if (projectsRow == null) return;
            projectsRow.projectCode = code;
            projectsRow.type = saveType;
            projectsRow.budgetUnit = saveCurrency;

            projectTypeCb.myValue = projectsRow.type;
            budgetUnitCb.myValue = projectsRow.budgetUnit; 

            projectTypeCb.SelectFirstIfNull();
            budgetUnitCb.SelectFirstIfNull();
        }
        //Get key value in a row.
        protected override string GetKeyValue(DataRow dr)
        {
            return ((data.baseDS.emProjectRow)dr).projectCode;
        }
        //When delete a code, deleted code in existing data must be changed to retain the intergrity
        protected override bool ChangeCode(DataRowView drOld, string toCode, bool deleteAfterChange)
        {
            //toCode = toCode.Trim();
            //if (toCode == "") return true;

            //data.baseDS.emProjectRow oldRow = (data.baseDS.emProjectRow)drOld.Row;
            //data.baseDS.emProjectRow newRow = application.dataLibs.Getprojects(toCode);
            //if (newRow == null) newRow = CreateDuplicate(oldRow, toCode);
            ////??projectsTA.ChangeprojectsCode(oldRow.code, newRow.code);

            //if (deleteAfterChange) RemoveCurrent();
            return true;
        }
        private data.baseDS.emProjectRow CreateDuplicate(data.baseDS.emProjectRow oldRow, string newCode)
        {
            data.baseDS.emProjectRow newRow = myDataSet.emProject.NewemProjectRow();
            newRow.ItemArray = oldRow.ItemArray;
            newRow.projectCode = newCode;
            myDataSet.emProject.AddemProjectRow(newRow);
            application.dataLibs.UpdateData(newRow);
            return newRow;
        }

        protected override DataRow FindCode(string code, bool showSelectionIfnotFound)
        {
            return null;
            //baseClass.interfaces.myprojectsFind.Find(code, showSelectionIfnotFound);
            //return baseClass.interfaces.myprojectsFind.selectedDataRow;
        }
        
        private void codeEd_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = this.CheckDuplicateKey(codeEd.Text.Trim(), myDataSet.emProject.projectCodeColumn.ColumnName);
        }

        private void commentGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }
        private void commentGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex != 3) return;
                //if (commentGrid.CurrentRow == null) return;
                //data.baseDS.projCommentRow row = (data.baseDS.projCommentRow)((DataRowView)commentGrid.CurrentRow.DataBoundItem).Row;
                //if (row == null) return;
                //if (myProjCommentEdit == null) myProjCommentEdit = new projCommentEdit();
                //myProjCommentEdit.Name = "projCommentEdit";
                //myProjCommentEdit.ShowProjectComment(row.id);
            }
            catch (Exception ex)
            {
                common.system.ShowErrorMessage(ex.Message.ToString());
            }
        }
    }    
}