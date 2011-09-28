using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class companyFind : common.forms.baseForm
    {
        public companyFind()
        {
            InitializeComponent();
            fullMode = false;
        }
        public static companyFind GetForm(string formName)
        {
            string cacheKey = typeof(companyFind).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            companyFind form = (companyFind)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new companyFind();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        public data.baseDS.stockCodeRow selectedDataRow = null;
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
            get { return myBaseDS.stockCode.codeColumn.ColumnName; }
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
                itemSource.Filter = "";

                code = code.Trim();
                if (code != "")
                {
                    this.myBaseDS.stockCode.Clear();
                    application.dataLibs.LoadData(this.myBaseDS.stockCode, code);
                    if (this.myBaseDS.stockCode.Count > 0)
                    {
                        selectedDataRow = (data.baseDS.stockCodeRow)(((DataRowView)itemSource.Current).Row);
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
            myBaseDS.stockCode.Clear();
            application.dataLibs.LoadFromSQL(myBaseDS.stockCode, findCriteria.GetSQL());
            ShowReccount("["+myBaseDS.stockCode.Count.ToString()+"]");
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
        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (itemSource.Current == null) selectedDataRow =null;
            else selectedDataRow = (data.baseDS.stockCodeRow)(((DataRowView)itemSource.Current).Row);
            this.Close();
        }
    }
}
