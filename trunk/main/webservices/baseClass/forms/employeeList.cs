using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class employeeList : employeeEdit
    {
        public employeeList()
        {
            try
            {
                InitializeComponent();
                this.CloseOnSave = false;
                ShowFindPanel(false);
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        protected override void LoadData() 
        {
            application.dataLibs.LoadData(myDataSet.employee, null);
            if (myMasterSource.Current != null)
            {
                data.baseDS.employeeRow employeeRow = (data.baseDS.employeeRow)((DataRowView)myMasterSource.Current).Row;
                SetData(employeeRow);
            }
        }
        protected override bool FindData()
        {
            ShowFindPanel(true);
            return base.FindData();
        }
        private void ShowFindPanel(bool state)
        {
            findBtn.Enabled = !state;
            findPnl.Visible = state;
            dataGrid.Height = (state ? findPnl.Location.Y - dataGrid.Location.Y : this.Height - dataGrid.Location.Y - 2 * SystemInformation.CaptionHeight - 9);
        }
        private void closeFindBtn_Click(object sender, EventArgs e)
        {
            ShowFindPanel(false);
        }
        private void filterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                employeeSource.Filter = employeeCriteria.GetCriteria();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
    }
}
