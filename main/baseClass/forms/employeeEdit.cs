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
    public partial class employeeEdit : baseMasterEdit  
    {
        public employeeEdit()
        {
            try
            {
                InitializeComponent();

                myMasterSource = employeeSource;
                this.CloseOnSave = true;
                this.allowToChangeDeleteCode = true;
                this.myFormCode = this.Name;

                emGeneral.Init();
                emPrivate.Init();
                emIdentity.Init();
                emWork.Init();
                emEmergency.Init();

                emEducation.Init();
                emLanguage.Init();
                emProject.Init();

                emRelatives.Init();
                emWorkHistory.Init();
                emDocFile.Init();

                emWorkRewards.Init();
                emWorkPunishment.Init();

                emWorkLeave.Init();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        public void ShowEmployee(string code)
        {
            try
            {
                //LockEdit(true);
                //data.system.employeeTA.FillByCode(myDataSet.employee, code);
                //if (myDataSet.employee.Count <= 0) return;
                //LockEdit(false);
                //this.SetFirstFocus();
                //this.ShowDialog();
            }
            catch (Exception ex)
            {
                common.system.ShowErrorMessage(ex.Message.ToString());
            }
        }
        public override void LockEdit(bool lockState)
        {
            base.LockEdit(lockState);
            emGeneral.LockEdit(lockState);
            emPrivate.LockEdit(lockState);
            emIdentity.LockEdit(lockState);
            emWork.LockEdit(lockState);
            emEmergency.LockEdit(lockState);

            emEducation.LockEdit(lockState);
            emLanguage.LockEdit(lockState);
            emProject.LockEdit(lockState);

            emRelatives.LockEdit(lockState);
            emWorkHistory.LockEdit(lockState);
            emDocFile.LockEdit(lockState);

            emWorkPunishment.LockEdit(lockState);
            emWorkRewards.LockEdit(lockState);

            emWorkLeave.LockEdit(lockState);
        }
      
        protected override void SetFirstFocus() 
        {
            xpGroup_Info.Focus();
            if (xpPanel_General.PanelState == UIComponents.XPPanelState.Expanded)
            {
                emGeneral.SetFocus();
                return;
            }
            if (xpPanel_Identity.PanelState == UIComponents.XPPanelState.Expanded)
            {
                emIdentity.SetFocus();
                return;
            }
            if (xpPanel_Work.PanelState == UIComponents.XPPanelState.Expanded)
            {
                emWork.SetFocus();
                return;
            }
            if (xpPanel_Private.PanelState == UIComponents.XPPanelState.Expanded)
            {
                emPrivate.SetFocus();
                return;
            }
            if (xpPanel_Emergency.PanelState == UIComponents.XPPanelState.Expanded)
            {
                emEmergency.SetFocus();
                return;
            }
            if (xpPanel_Leave.PanelState == UIComponents.XPPanelState.Expanded)
            {
                emWorkLeave.SetFocus();
                return;
            }
        }
        protected override bool DataValid(bool showMsg)
        {
            this.ShowMessage("");
            TabPage saveTabPage = tabMain.SelectedTab;
            bool retVal = true;

            tabMain.SelectedTab = pageInfo;
            bool retVal1 = emGeneral.CheckData();
            if (!retVal1) xpPanel_General.PanelState = UIComponents.XPPanelState.Expanded;  
            
            bool retVal2 = emPrivate.CheckData();
            if (!retVal2) xpPanel_Private.PanelState = UIComponents.XPPanelState.Expanded;
            
            bool retVal3 = emIdentity.CheckData();
            if (!retVal3) xpPanel_Identity.PanelState = UIComponents.XPPanelState.Expanded;  

            bool retVal4 = emWork.CheckData();
            if (!retVal4) xpPanel_Work.PanelState = UIComponents.XPPanelState.Expanded;  

            bool retVal5 = emEmergency.CheckData();
            if (!retVal5) xpPanel_Emergency.PanelState = UIComponents.XPPanelState.Expanded;  

            if (!retVal1 || !retVal2 || !retVal3 || !retVal4 || !retVal5)
            {
                saveTabPage = pageInfo;
                retVal = false;
            }

            tabMain.SelectedTab = pageEducation;
            bool retVal6 = emEducation.CheckData();
            if (!retVal6) xpPanel_Edu_Cerificate.PanelState = UIComponents.XPPanelState.Expanded;
           
            bool retVal7 = emLanguage.CheckData();
            if (!retVal7) xpPanel_Edu_Language.PanelState = UIComponents.XPPanelState.Expanded;

            if (!retVal6 || !retVal7)
            {
                saveTabPage = pageEducation;
                retVal = false;
            }

            tabMain.SelectedTab = pageProject;
            bool retVal8 = emProject.CheckData();
            if (!retVal8)
            {
                saveTabPage = pageProject;
                retVal = false;
            }
           
            tabMain.SelectedTab = pageProfile;
            bool retVal9 = emRelatives.CheckData();
            if (!retVal9) xpPanel_Relatives.PanelState = UIComponents.XPPanelState.Expanded;

            bool retVal10 = emWorkHistory.CheckData();
            if (!retVal10) xpPanel_WorkHistory.PanelState = UIComponents.XPPanelState.Expanded;
            bool retVal11 = emDocFile.CheckData();
            if (!retVal11) xpPanel_emDocFile.PanelState = UIComponents.XPPanelState.Expanded;

            if (!retVal9 || !retVal10 || !retVal11)
            {
                saveTabPage = pageProfile;
                retVal = false;
            }

            tabMain.SelectedTab = pageWorkReward;
            bool retVal12 = emWorkRewards.CheckData();
            if (!retVal12) xpPanel_Reward.PanelState = UIComponents.XPPanelState.Expanded;  

            bool retVal13 = emWorkPunishment.CheckData();
            if (!retVal13) xpPanel_Punishment.PanelState = UIComponents.XPPanelState.Expanded;

            if (!retVal12 || !retVal13)
            {
                saveTabPage = pageWorkReward;
                retVal = false;
            }

            bool retVal14 = emWorkLeave.CheckData();
            if (!retVal14) xpPanel_Leave.PanelState = UIComponents.XPPanelState.Expanded;

            if (!retVal14)
            {
                saveTabPage = leavePg;
                retVal = false;
            }

            tabMain.SelectedTab = saveTabPage;
            if (!retVal && showMsg)  
            {
                this.ShowMessage("Dữ liệu không hợp lệ.");
            }
            return retVal; 
        }
        protected override void UpdateData(DataRow row)
        {
            if (row == null)
            {
                application.dataLibs.UpdateData(myDataSet.employee);
            }
            else
            {
                data.baseDS.employeeRow employeeRow = (data.baseDS.employeeRow)row;
                emGeneral.GetData(employeeRow);
                emPrivate.GetData(employeeRow);
                emIdentity.GetData(employeeRow);
                emWork.GetData(employeeRow);
                emEmergency.GetData(employeeRow);
                application.dataLibs.UpdateData(employeeRow);

                emEducation.SaveData(employeeRow.emCode);
                emLanguage.SaveData(employeeRow.emCode);
                emProject.SaveData(employeeRow.emCode);

                emRelatives.SaveData(employeeRow.emCode);
                emWorkHistory.SaveData(employeeRow.emCode);
                emDocFile.SaveData(employeeRow.emCode);

                emWorkRewards.SaveData(employeeRow.emCode);
                emWorkPunishment.SaveData(employeeRow.emCode);

                emWorkLeave.SaveData(employeeRow.emCode);
            }
        }
        public override void AddNew(string code)
        {
            string[] saveData = this.SaveEditData();
            this.AddNewRow();

            data.baseDS.employeeRow employeeRow = (data.baseDS.employeeRow)((DataRowView)myMasterSource.Current).Row;
            if (employeeRow == null) return;
            application.dataLibs.InitData(employeeRow);
            employeeRow.emCode = code;
            SetData(employeeRow);
        }
        protected virtual void SetData(data.baseDS.employeeRow employeeRow)
        {
            emGeneral.SetData(employeeRow);
            emPrivate.SetData(employeeRow);
            emIdentity.SetData(employeeRow);
            emWork.SetData(employeeRow);
            emEmergency.SetData(employeeRow);

            emEducation.LoadData(employeeRow.emCode);
            emLanguage.LoadData(employeeRow.emCode);
            emProject.LoadData(employeeRow.emCode);
            
            emRelatives.LoadData(employeeRow.emCode);
            emWorkHistory.LoadData(employeeRow.emCode);
            emDocFile.LoadData(employeeRow.emCode);

            emWorkRewards.LoadData(employeeRow.emCode);
            emWorkPunishment.LoadData(employeeRow.emCode);

            emWorkLeave.LoadData(employeeRow.emCode);            
        }
        //Get key value in a row.
        protected override string GetKeyValue(DataRow dr)
        {
            return ((data.baseDS.employeeRow)dr).emCode;
        }
        //When delete a code, deleted code in existing data must be changed to retain the intergrity
        protected override bool ChangeCode(DataRowView drOld, string toCode, bool deleteAfterChange)
        {
            //toCode = toCode.Trim();
            //if (toCode == "") return true;

            //data.baseDS.employeeRow oldRow = (data.baseDS.employeeRow)drOld.Row;
            //data.baseDS.employeeRow newRow = application.dataLibs.Getemployee(toCode);
            //if (newRow == null) newRow = CreateDuplicate(oldRow, toCode);
            ////??employeeTA.ChangeemployeeCode(oldRow.code, newRow.code);

            //if (deleteAfterChange) RemoveCurrent();
            return true;
        }
        protected override DataRow FindCode(string code, bool showSelectionIfnotFound)
        {
            return null;
            //baseClass.interfaces.myemployeeFind.Find(code, showSelectionIfnotFound);
            //return baseClass.interfaces.myemployeeFind.selectedDataRow;
        }

        private void employeeSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.fOnProccessing || myMasterSource.Current == null) return;
                data.baseDS.employeeRow employeeRow = (data.baseDS.employeeRow) ((DataRowView)myMasterSource.Current).Row;
                SetData(employeeRow);
                LockEdit(this.isLockEdit);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void myOnError(object sender, EventArgs e)
        {
            if (e == null) this.ShowMessage("");
            else this.ShowError(((common.myExceptionEventArgs)e).myException);
        }
    }    
}