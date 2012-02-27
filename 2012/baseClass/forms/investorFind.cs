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
        public static investorFind GetForm(string formName)
        {
            string cacheKey = typeof(investorFind).FullName + (formName == null || formName.Trim() == "" ? "" : "-" + formName);
            investorFind form = (investorFind)common.Data.dataCache.Find(cacheKey);
            if (form != null && !form.IsDisposed) return form;
            form = new investorFind();
            common.Data.dataCache.Add(cacheKey, form);
            return form;
        }

        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("investor");

            findBtn.Text = Languages.Libs.GetString("find");
            selectBtn.Text = Languages.Libs.GetString("select");
            closeBtn.Text = Languages.Libs.GetString("close");
            newBtn.Text = Languages.Libs.GetString("addNew");

            codeColumn.HeaderText = Languages.Libs.GetString("code") + " 1";
            displayNameColumn.HeaderText = Languages.Libs.GetString("name");
            addressColumn.HeaderText = Languages.Libs.GetString("address");

            findCriteria.SetLanguage();
        }

        public databases.baseDS.investorRow selectedDataRow = null;
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

        public bool Find(string account, bool ShowSelectionIfNotFound)
        {
            try
            {
                selectedDataRow = null;
                investorSource.Filter = "";

                account = account.Trim();
                if (account != "")
                {
                    investorSource.DataSource = DataAccess.Libs.GetInvestor_ByAccount(account);
                    if (investorSource.Count > 0)
                    {
                        selectedDataRow = (databases.baseDS.investorRow)(((DataRowView)investorSource.Current).Row);
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
                this.ShowError(er);
            }
            return false;
        }
       
        private void LoadData()
        {
            investorSource.DataSource = DataAccess.Libs.GetInvestor_BySQL(findCriteria.GetSQL());
            ShowReccount(investorSource.Count);
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
            else selectedDataRow = (databases.baseDS.investorRow)(((DataRowView)investorSource.Current).Row);
            this.Close();
        }
    }
}
