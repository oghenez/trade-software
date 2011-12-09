using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class employeeFind : common.forms.baseForm
    {
        private employeeEdit myEmployeeFind = null;

        public employeeFind()
        {
            InitializeComponent();
            dataGrid.Location = new Point(0, 0);
            dataGrid.Size = dataPnl.Size;
            fullMode = false;
        }
        public DataRowView selectedDataRow = null;
        protected bool fullMode
        {
            get
            {
                return dataGrid.Visible;
            }
            set
            {
                dataPnl.Visible = value;
                optionPnl.Visible = !dataPnl.Visible;
                this.Height = (value ? dataPnl.Location.Y + dataPnl.Height : optionPnl.Location.Y + optionPnl.Height);
                this.Height += 2 * SystemInformation.CaptionHeight + 10;
            }
        }

        public string keyFldName
        {
            get { return myBaseDS.employee.emCodeColumn.ColumnName; }
        }

        public bool Find(string code)
        {
            return Find(code, true);
        }

        public bool Find(string code, bool ShowSelectionIfNotFound)
        {
            try
            {
                selectedDataRow = null;
                employeeSource.Filter = "";

                code = code.Trim();
                bool haveMarker = common.system.HaveFindMarker(ref code);
                if (!haveMarker && code != "")
                {
                    this.myBaseDS.employee.Clear();
                    application.dataLibs.LoadData(this.myBaseDS.employee, code);
                    if (this.myBaseDS.employee.Count > 0)
                    {
                        selectedDataRow = ((DataRowView)employeeSource.Current);
                        return true;
                    }
                    if (!ShowSelectionIfNotFound) return false;
                }
                LoadData(); 
                this.ShowDialog();
                return (this.selectedDataRow != null);
            }
            catch (Exception er)
            {
                common.system.ShowErrorMessage(er.Message);
            }
            return false;
        }
       
        private void LoadData()
        {
            myBaseDS.employee.Clear();
            string cond = emCriteria.GetCriteria().Trim();
            string sqlCmd = "SELECT * FROM " + myBaseDS.employee.TableName + (cond == "" ? "" : " WHERE " + cond);
            application.dataLibs.LoadFromSQL(myBaseDS.employee, sqlCmd);
            ShowReccount("[" + myBaseDS.employee.Count.ToString() + "]");
        }

        private void DoSelect()
        {
            selectedDataRow = ((DataRowView)employeeSource.Current);
            this.fullMode = false;
            this.Hide();
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            try
            {
                fullMode = false;
                LoadData();
                fullMode = true;
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void employeeFind_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void employeesGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            if (myEmployeeFind == null || myEmployeeFind.IsDisposed) myEmployeeFind = new employeeEdit();
            myEmployeeFind.ShowEmployee(null);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DoSelect();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void closeListBtn_Click(object sender, EventArgs e)
        {
            this.fullMode = false;
        }
    }
}
