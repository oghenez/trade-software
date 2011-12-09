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
        public override void SetLanguage()
        {
            base.SetLanguage();
            this.Text = language.GetString("companyList");
            filterBtn.Text = language.GetString("find");
            closeFindBtn.Text = language.GetString("close");

            codeColumn.HeaderText = language.GetString("code");
            nameColumn.HeaderText = language.GetString("name");
        }

        protected override bool FindData()
        {
            ShowFindPanel(true);
            return base.FindData();
        }
        protected override void LoadData()
        {
            this.ShowMessage("");
            myDataSet.stockCode.Clear();
            application.dataLibs.LoadFromSQL(myDataSet.stockCode, findCriteria.GetSQL());
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
