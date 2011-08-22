using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class investorFind : common.forms.baseForm
    {
        private investorEdit myInvestorEdit = null;

        public investorFind()
        {
            InitializeComponent();
            fullMode = false;
        }
        public data.baseDS.companyRow selectedDataRow = null;
        protected bool fullMode
        {
            get
            {
                return dataGrid.Visible;
            }
            set
            {
                dataGrid.Visible = value;
                this.Height = this.dataGrid.Location.Y + 2 * SystemInformation.CaptionHeight +10;
                if (value) this.Height += dataGrid.Height;
            }
        }

        public string keyFldName
        {
            get { return myBaseDS.company.codeColumn.ColumnName; }
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
                investorSource.Filter = "";

                code = code.Trim();
                if (code != "")
                {
                    this.myBaseDS.company.Clear();
                    application.dataLibs.LoadData(this.myBaseDS.company, code);
                    if (this.myBaseDS.company.Count > 0)
                    {
                        selectedDataRow = (data.baseDS.companyRow)(((DataRowView)investorSource.Current).Row);
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
            myBaseDS.company.Clear();
            string cond = findCriteria.GetCriteria().Trim();
            string sqlCmd = "SELECT * FROM " + myBaseDS.company.TableName + (cond==""?"": " WHERE " + cond);
            application.dataLibs.LoadFromSQL(myBaseDS.company, sqlCmd);
            ShowReccount("["+myBaseDS.company.Count.ToString()+"]");
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

        private void form_Load(object sender, EventArgs e)
        {
            try
            {
                findCriteria.LoadData();
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            if (myInvestorEdit == null || myInvestorEdit.IsDisposed) myInvestorEdit = new investorEdit();
            myInvestorEdit.ShowInvestor(null);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (investorSource.Current == null) selectedDataRow =null;
            else selectedDataRow = (data.baseDS.companyRow)(((DataRowView)investorSource.Current).Row);
            this.Hide();
        }
    }
}
