using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class investorList : investorEdit
    {
        public investorList()
        {
            try
            {
                InitializeComponent();
                this.CloseOnSave = false;
                ShowFindPanel(false);
                SetDetailGrid();
                findCriteria.LoadData();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("find");
            findBtn.Text = Languages.Libs.GetString("find");
            closeFindBtn.Text = Languages.Libs.GetString("close");

            codeColumn.HeaderText = Languages.Libs.GetString("code");
            displayNameColumn.HeaderText = Languages.Libs.GetString("displayName");

            findCriteria.SetLanguage();
        }
        protected override bool FindData()
        {
            ShowFindPanel(true);
            return base.FindData();
        }
        protected override void LoadData()
        {
            this.ShowMessage("");
            myMasterSource.DataSource = DataAccess.Libs.GetInvestor_BySQL(findCriteria.GetSQL());
            CurrentDataChanged();
        }
        private void SetDetailGrid()
        {
            data.baseDS.investorDataTable investorTbl = new data.baseDS.investorDataTable();
            // 
            // codeColumn
            // 
            this.codeColumn.DataPropertyName = investorTbl.codeColumn.ColumnName;
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            // 
            // displayNameColumn
            // 
            this.displayNameColumn.DataPropertyName = investorTbl.displayNameColumn.ColumnName;
            this.displayNameColumn.HeaderText = "Name";
            this.displayNameColumn.Name = "displayNameColumn";
            this.displayNameColumn.ReadOnly = true;
            
            // 
            // dataGrid
            // 

            this.dataGrid.DataSource = this.myMasterSource;
            this.dataGrid.Columns.Clear();
            this.dataGrid.Columns.AddRange(new DataGridViewColumn[] { this.codeColumn, this.displayNameColumn });
            this.dataGrid.ReadOnly = true;

            common.system.AutoFitGridColumn(dataGrid, this.displayNameColumn.Name);
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
                LoadData();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
    }
}
