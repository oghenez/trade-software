using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace baseClass.forms
{
    public partial class companyList : companyEdit
    {
        public companyList()
        {
            try
            {
                InitializeComponent();
                SetDetailGrid();
                findCriteria.LoadData();
                dataGrid.DisableReadOnlyColumn = false;
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
            base.LoadData();
            SetDetailGrid();
            SetLanguage();
        }
        public override void SetLanguage()
        {
            if (!isLoaded) return;
            base.SetLanguage();
            this.Text = Languages.Libs.GetString("companyList");
            filterBtn.Text = Languages.Libs.GetString("find");
            closeFindBtn.Text = Languages.Libs.GetString("close");

            codeColumn.HeaderText = Languages.Libs.GetString("code");
            nameColumn.HeaderText = Languages.Libs.GetString("name");

            if (commonClass.AppLibs.IsUseVietnamese())
                 this.nameColumn.DataPropertyName = myDataSet.stockCode.nameColumn.ColumnName;
            else this.nameColumn.DataPropertyName = myDataSet.stockCode.nameEnColumn.ColumnName;
        }
        protected override bool FindData()
        {
            ShowFindPanel(true);
            return base.FindData();
        }

        private DataGridViewTextBoxColumn codeColumn = new DataGridViewTextBoxColumn();
        private DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
        private void SetDetailGrid()
        {
            if (this.dataGrid == null) return;
            // 
            // codeColumn
            // 
            this.codeColumn.HeaderText = "Code";
            this.codeColumn.Name = "codeColumn";
            this.codeColumn.ReadOnly = true;
            this.codeColumn.DataPropertyName = myDataSet.stockCode.codeColumn.ColumnName;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.DataPropertyName = myDataSet.stockCode.nameColumn.ColumnName;

            this.dataGrid.DataSource = this.myMasterSource;
            this.dataGrid.Columns.Clear();
            this.dataGrid.Columns.AddRange(new DataGridViewColumn[] { this.codeColumn, this.nameColumn });
            this.dataGrid.ReadOnly = true;
            this.dataGrid.ReOrderColumn(new string[] { "codeColumn", "nameColumn" });
            common.system.AutoFitGridColumn(dataGrid, this.nameColumn.Name);
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
                myMasterSource.Filter = findCriteria.GetCriteria("", false); 
                ShowReccount();
            }
            catch (Exception er)
            {
                this.ShowMessage(er.Message);
            }
        }
        private void companyList_Resize(object sender, EventArgs e)
        {
            try
            {
                common.system.AutoFitGridColumn(dataGrid, nameColumn.Name);
                findCriteria.Location = new Point((findPnl.Width - findCriteria.Width) / 2,findCriteria.Location.Y);
                xpPanelGroup_Info.Height = this.ClientSize.Height - xpPanelGroup_Info.Location.Y - SystemInformation.CaptionHeight; 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
    }
}
