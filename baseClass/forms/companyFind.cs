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
            try
            {
                InitializeComponent();
                fullMode = false;
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
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
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("find");
            findBtn.Text = Languages.Libs.GetString("find");
            selectBtn.Text = Languages.Libs.GetString("select");
            closeBtn.Text = Languages.Libs.GetString("close");

            codeColumn.HeaderText = Languages.Libs.GetString("code");
            nameColumn.HeaderText = Languages.Libs.GetString("name");
        }

        public databases.tmpDS.stockCodeRow selectedDataRow = null;
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
            get { return myTmpDS.stockCode.codeColumn.ColumnName; }
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
                code = code.Trim();
                if (code != "")
                {
                    selectedDataRow = DataAccess.Libs.myStockCodeTbl.FindBycode(code);
                    if(selectedDataRow != null) return true;
                    if (!ShowSelectionIfNotFound) return false;
                }
                LoadData(); 
                this.ShowDialog();
                return (this.selectedDataRow != null);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
            return false;
        }
       
        private void LoadData()
        {
            dataSource.DataSource = DataAccess.Libs.myStockCodeTbl; 
            ShowReccount(dataGrid.RowCount);
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            try
            {
                fullMode = false;
                dataSource.Filter = findCriteria.GetCriteria("", false);
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
            if (dataSource.Current == null) selectedDataRow =null;
            else selectedDataRow = (databases.tmpDS.stockCodeRow)(((DataRowView)dataSource.Current).Row);
            this.Close();
        }
    }
}
