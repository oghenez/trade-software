using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class projectFind : common.forms.baseForm
    {
        private projectEdit myProjectEdit = null;

        public projectFind()
        {
            InitializeComponent();
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
                dataGrid.Visible = value;
                this.Height = this.dataGrid.Location.Y + 2 * SystemInformation.CaptionHeight +10;
                if (value) this.Height += dataGrid.Height;
            }
        }

        public string keyFldName
        {
            get { return myBaseDS.emProject.projectCodeColumn.ColumnName; }
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
                projectsSource.Filter = "";

                code = code.Trim();
                bool haveMarker = common.system.HaveFindMarker(ref code);
                if (!haveMarker && code != "")
                {
                    this.myBaseDS.emProject.Clear();
                    application.dataLibs.LoadData(this.myBaseDS.emProject, code);
                    if (this.myBaseDS.emProject.Count > 0)
                    {
                        selectedDataRow = ((DataRowView)projectsSource.Current);
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
            myBaseDS.emProject.Clear();
            string cond = projectCriteria.GetCriteria().Trim();
            string sqlCmd = "SELECT * FROM " + myBaseDS.emProject.TableName + (cond==""?"": " WHERE " + cond);
            application.dataLibs.LoadFromSQL(myBaseDS.emProject, sqlCmd);
            ShowReccount("["+myBaseDS.emProject.Count.ToString()+"]");
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

        private void projectFind_Load(object sender, EventArgs e)
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

        private void projectsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.ShowMessage(e.Exception.Message);
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            if (myProjectEdit == null || myProjectEdit.IsDisposed) myProjectEdit = new projectEdit();
            myProjectEdit.ShowProject(null);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            selectedDataRow = ((DataRowView)projectsSource.Current);
            this.Hide();
        }
    }
}
